Imports Newtonsoft.Json
Imports risersoft.shared
Imports risersoft.app.mxent
Imports risersoft.shared.dal

Public Class Import_AttendanceTaskProvider
    Inherits ImportTaskProviderFileBase

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Property DocType As String = "ATTENDANCE"
    Public Overrides Property TemplateName As String = "Attendance"
    Public Overrides Property TemplateFunctionName As String = ""
    Public Overrides Property DocName As String = "Attendance"

    Public Overrides Async Function TryImportRowGroup(provider As IAppDataProvider, objGroup As clsRowGroup, objPortion As clsPortionInfo) As Task(Of clsProcOutput)
        Dim dic As New clsCollecString(Of DataRow)
        Dim oRet = Await Me.HandleGroupData(provider, objGroup, objPortion)
        Dim info As New ImportErrorInfo()
        If oRet.WarningCount > 0 Then info.Voucher.AddWarning(Me.DocumentExistsErrorCode, oRet.WarningMessage)
        'Have a new dataset ready for data to be saved from database and copy level 1 and level 2 rows into it
        Dim dsDB = oRet.Data
        Dim rVouch = dsDB.Tables(0).Select()(0)

        If objGroup.Rows.Count > 1 Then
            oRet.AddError("Multiple Records found from Same Employee")
            info.Voucher.AddError(Me.PreValidationErrorCode, "Multiple Records found from Same Employee")
            Me.UpdateError(objGroup.Rows, info.Voucher)
        Else
            'Do the pre-operations, like getting IDs
            oRet = Me.ExecutePreValidation(provider, rVouch, dsDB.Tables("attendance"), objGroup.Rows(0), objGroup)
            If oRet.Success Then

                Me.RunValidator(info, objGroup.Rows, rVouch, dsDB, "", Sub(obj, rItem)
                                                                           If rItem Is Nothing Then
                                                                               For Each kvp In dic
                                                                                   obj.AddOrUpdateRow(kvp.Value, kvp.Key)
                                                                               Next
                                                                           End If
                                                                       End Sub)
                If info.Errorcount = 0 Then
                    'If all OK, go ahead and save. If not OK, add validation errors obtained to a new error datatable with same schema as ds, but with Validation and Warning columns.
                    Dim VouchDescrip = "Attendance for Dated " & rVouch("Dated") & ""
                    Try
                        provider.dbConn.BeginTransaction(myContext, Me.GetType.Name, EnumfrmMode.acAddM, "ID")

                        provider.objSQLHelper.SaveResults(dsDB.Tables("attendance"), objGroup.dicSQL("attendance"), dicOpInfo("attendance"))

                        provider.dbConn.CommitTransaction(VouchDescrip, rVouch("Dated").ToString)
                    Catch ex As Exception
                        oRet.AddException(ex)
                        provider.dbConn.RollBackTransaction(VouchDescrip, ex.Message, False)
                        Dim obj = info.Voucher.AddException(Me.DatabaseTransactionErrorCode, ex)
                        Me.UpdateError(objGroup.Rows, info.Voucher)
                    End Try

                Else
                    If Not Me.ImportFileID = Guid.Empty Then
                        Dim nr = Me.CreateFileVouchRow(objPortion, rVouch, dsDB, objGroup, info, Sub(x)
                                                                                                     x("vouchnum") = rVouch("Aadhar")
                                                                                                 End Sub)
                    End If
                    oRet.AddError(info.ErrorDescripTot)
                End If

            Else
                oRet.AddError("Unforeseen error in pre validation")
                info.Voucher.AddError(Me.PreValidationErrorCode, "Unforeseen error in pre validation")
                Me.UpdateError(objGroup.Rows, info.Voucher)
            End If

        End If

        Return oRet

    End Function
    Public Overridable Function ExecutePreValidationMaster(rVouch As DataRow, dtItems As DataTable, rXL As DataRow, dic As clsCollecString(Of DataRow)) As clsProcOutput
        Dim oRet As New clsProcOutput, oMasterData As New clsMasterDataHRP(Me.myContext)

        Try
            If dic.ContainsKey("employee") Then rVouch("employeeid") = dic("Employee")("employeeid")
            If dic.ContainsKey("shift") Then rVouch("shiftid") = dic("Shift")("shiftid")
            Dim CompanyID As Integer = dic("Employee")("Companyid")
            Dim Dated As String = myUtils.cStrTN(rXL("Dated")).Replace("'", "")
            Me.CalculateDate(Dated)

            Dim rPP As DataRow = oMasterData.rPayPeriod(CompanyID, Dated)
            If Not rPP Is Nothing Then
                rVouch("PayperiodID") = rPP("PayPeriodID")

            End If

        Catch ex As Exception
            oRet.AddException(ex)
        End Try
        Return oRet
    End Function
    Public Overrides Function ExecutePreValidation(provider As IAppDataProvider, rVouch As DataRow, dtItems As DataTable, rXL As DataRow, objGroup As clsRowGroup) As clsProcOutput
        Dim oRet As New clsProcOutput, LineSNum As Integer = 0
        Dim dic = objGroup.dic
        Try
            oRet = Me.ExecutePreValidationMaster(rVouch, dtItems, rXL, dic)

        Catch ex As Exception
            oRet.AddException(ex)

        End Try
        Return oRet
    End Function

    Public Overrides Async Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim Params = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(myUtils.cStrTN(rTask("infojson")))
        Dim path = Await myFuncs.DownloadIfReqd(myContext, rTask, Params("path"))
        Dim oRet = Await Me.ExecuteImport(path, myUtils.cStrTN(rTask("username")), myUtils.cStrTN(rTask("importfileid")))
        Return oRet
    End Function

    Protected Overrides Function GenerateSQL(provider As IAppDataProvider, objGroup As clsRowGroup, objPortion As clsPortionInfo) As clsCollecString(Of String)
        Dim dicSQL As New clsCollecString(Of String)
        Dim rXL = objGroup.Rows(0)

        Dim Dated As String = myUtils.cStrTN(rXL("Dated")).Replace("'", "")
        Dim EmpCode = String.Format("EmpCode='{0}'", Me.CleanFilterString(myUtils.cStrTN(rXL("EmpCode"))))
        Me.CalculateDate(Dated)
        Dim strf1 As String = myUtils.CombineWhere(False, "Dated='" & Dated & "'")
        dicSQL.Add("attendance", "select * from Attendance where " & strf1 & " and EmployeeID in (select EmployeeID from Employees where " & EmpCode & ")")

        Return dicSQL

    End Function

    Protected Overrides Function HandleGroupData(provider As IAppDataProvider, objGroup As clsRowGroup, objPortion As clsPortionInfo) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim rXL = objGroup.Rows(0)
        Me.GetMasterData(provider, objGroup, objPortion)
        objGroup.dicSQL.Clear()
        Dim dic2 = Me.GenerateSQL(provider, objGroup, objPortion)
        dic2.CopyTo(objGroup.dicSQL)

        Dim Dated As String = myUtils.cStrTN(rXL("Dated")).Replace("'", "")
        Me.CalculateDate(Dated)
        Dim EmpCode As String = myUtils.cStrTN(rXL("EmpCode")).Replace("'", "")
        Dim dsDB = provider.objSQLHelper.ExecuteDataset(CommandType.Text, objGroup.dicSQL)
        Me.CheckAddOpInfo(provider, objGroup.dicSQL)

        Dim rr1() As DataRow = dsDB.Tables("attendance").Select("Dated='" & Dated & "'")

        Dim rAttend As DataRow
        'Attendance Import
        If rr1.Length > 0 Then
            rAttend = rr1(0)
        Else
            rAttend = myContext.Tables.AddNewRow(dsDB.Tables("attendance"))
            rAttend("Dated") = rXL("Dated")
            rAttend("AttendIDFH") = rXL("AttendIDFH")
            rAttend("AttendIDSH") = rXL("AttendIDSH")
            rAttend("OTHour") = rXL("OTHour")
            rAttend("Comment") = rXL("Comment")
            rAttend("LateInMin") = rXL("LateInMin")
            rAttend("EarlyOutMin") = rXL("EarlyOutMin")
            rAttend("LocationCode") = rXL("LocationCode")
            Dim Intime = DateTime.FromOADate(myUtils.cValTN(rXL("Intime")))
            Dim Outtime = DateTime.FromOADate(myUtils.cValTN(rXL("Outtime")))
            rAttend("Intime") = Intime
            rAttend("Outtime") = Outtime
        End If

        oRet.Data = dsDB
        Return Task.FromResult(oRet)
    End Function

    Protected Overrides Function GenerateFilter() As String
        Return "isnull(dated,'')<>''"
    End Function

    Protected Overrides Sub PopulateErrorFile(importer As ISSGImport, ds As DataSet, dtErrorFinal As DataTable)
        MyBase.PopulateErrorFile(importer, ds, dtErrorFinal)
        'importer.CopyData("UserAssignment", ds.Tables("UserAssignment"), 1, "dd/MM/yyyy", AddressOf DateFromString)

    End Sub

    Protected Overrides Function UniqueFieldList(DocType As String, TableName As String) As List(Of String)
        Dim lst1 As New List(Of String)
        Select Case DocType.Trim.ToLower
            Case "attendance"
                lst1 = New List(Of String)(New String() {"dated", "empcode"})

        End Select
        Return lst1
    End Function

    Public Overrides Sub PopulateMaster()
        oMaster.GetDataset2(False)

        Dim dicSQL As New clsCollecString(Of String)
        dicSQL.Add("atm", "select * from AttendTagMaster")
        dicSQL.Add("payperiod", "select * from Payperiod")
        dicSQL.Add("employee", "select * from hrplistemp()")
        dicSQL.Add("shift", "select * from Shift")
        dicSQL.Add("deps", "select * from Deps")

        dsMaster = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, dicSQL)

    End Sub
    Public Function FindEmployee(EmpCode As String) As DataRow
        Dim rrEmp() As DataRow = dsMaster.Tables("employee").Select("EmpCode='" & EmpCode & "'")
        If rrEmp.Length > 0 Then Return rrEmp(0)
    End Function

    'Public Function FindDep(Department As String) As DataRow
    '    Dim rrDep() As DataRow = dsMaster.Tables("deps").Select("Department='" & Department & "'")
    '    If rrDep.Length > 0 Then Return rrDep(0)
    'End Function
    Public Function FindShift(Shift As String) As DataRow
        Dim rrShift() As DataRow = dsMaster.Tables("shift").Select("Shift='" & Shift & "'")
        If rrShift.Length > 0 Then Return rrShift(0)
    End Function
    Public Overrides Sub AddRecord(info As FileImportInfo, objGroup As clsRowGroup)
        info.AddRecord(myUtils.cStrTN(objGroup.Rows(0)("department")), objGroup.Rows.Count, objGroup.Output.Success)

    End Sub

    Protected Overrides Function BuildFileUrl(authority As String, rootFile As String, currFile As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overridable Async Function GetMasterData(provider As IAppDataProvider, objGroup As clsRowGroup, objPortion As clsPortionInfo) As Task(Of Boolean)
        Dim dic2 As New clsCollecString(Of String)
        Dim rXL = objGroup.Rows(0), dic = objGroup.dic

        Dim rEmp As DataRow = Me.FindEmployee(myUtils.cStrTN(rXL("EmpCode")))
        Dim rShift As DataRow = Me.FindShift(myUtils.cStrTN(rXL("Shift")))
        If rEmp IsNot Nothing Then dic.Add("employee", rEmp)
        If rShift IsNot Nothing Then dic.Add("shift", rShift)


        Return True
    End Function

    Protected Overrides Function CreateData(provider As IAppDataProvider, Groups As List(Of clsRowGroup), objPortion As clsPortionInfo) As Task(Of Boolean)
        Throw New NotImplementedException()
    End Function
End Class
