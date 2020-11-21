Imports risersoft.shared.portable.Model
Imports risersoft.shared.portable.Enums
Imports risersoft.shared.portable
Imports risersoft.shared.portable.Models.HR
Imports risersoft.shared.portable.Models
Imports System.IO
Imports risersoft.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports System.Reflection
Imports MobileServiceRsMx
Imports risersoft.shared.cloud
Imports System.Net
Imports risersoft.app.reports.erp
Imports GeoTimeZone
Imports TimeZoneConverter
Imports System.Threading.Tasks
Imports risersoft.shared.web

''' <summary>
''' ESS Repository
''' </summary>
''' <remarks></remarks>
Public Class ESSRepository
    Inherits ServerRepositoryBase(Of EmployeeInfo, Integer)
    Implements IESSRepository

    Protected Friend Function GetEmployeeRow() As DataRow
        Dim sql As String = String.Format("select * from hrpListAllEmp() where userid='{0}' and onrolls=1", Me.User.UserId.ToString)
        Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
        If dt1.Rows.Count > 0 Then Return dt1.Rows(0) Else Return Nothing
    End Function
    Protected Friend Function GetSubordinates(EmployeeID As Integer) As DataTable
        Dim sql As String = String.Format("select * from hrpListAllEmp() where onrolls=1 and (leaveauth1id={0} or leaveauth2id={0})", EmployeeID)
        Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
        Return dt1
    End Function
    Public Function AddMyLeaveApplication(info As LeaveAppInfo) As ResultInfo(Of Integer, HttpStatusCode) Implements IESSRepository.AddMyLeaveApplication
        Try
            info.ApplicationDate = Now
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim rApp As DataRow = objPOCO.GenerateRow(info, True, "leaveappid")
            If (Not rEmp Is Nothing) AndAlso (Not rApp Is Nothing) Then
                Dim oRet As New clsProcOutput
                If Me.LeaveApplyEnabled(rEmp) Then
                    Dim oProc As New clsEmpSelfBase(Me.WebController)
                    oRet = oProc.SaveApplication(rEmp("employeeid"), rApp)
                    If oRet.Success Then
                        Dim oRet1 = SendEmailForLeaveApplied(oRet.ID, 1)
                        Dim oRet2 = SendEmailForLeaveApplied(oRet.ID, 2)
                        oProc.SaveMailMessages(oRet.ID, oRet1.Message, oRet2.Message)
                    End If
                Else
                    oRet.AddError("Leave Authority Not Defined")
                End If
                Return BuildOutputResponse(oRet)
            Else
                Return BuildResponse(0, HttpStatusCode.InternalServerError, "Invalid input")
            End If

        Catch ex As Exception
            Return BuildExceptionResponse(Of Integer)(ex)
        End Try
    End Function
    Public Function CancelMyLeaveApplication() As ResultInfo(Of Boolean, HttpStatusCode) Implements IESSRepository.CancelMyLeaveApplication
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow, cont As Boolean = False
            Dim sql As String = String.Format("select * from hrplistleaveapp() where employeeid={0} and isnull(statuscode,0)=0", rEmp("employeeid"))
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            If dt1.Rows.Count > 0 Then
                Dim oProc As New clsEmpSelfBase(Me.WebController)
                dt1.Rows(0)("cancellationdate") = Now
                dt1.Rows(0)("statuscode") = EnumApprovalAction.Cancelled
                dt1.Rows(0)("statustext") = oProc.CalculateAppStatus(dt1.Rows(0))
                Me.WebController.DataProvider.objSQLHelper.SaveResults(dt1, "select leaveappid, cancellationdate, statuscode, statustext from leaveapp")
                cont = True
            End If
            Return BuildResponse(cont)

        Catch ex As Exception
            Return BuildExceptionResponse(Of Boolean)(ex)

        End Try

    End Function
    Protected Friend Function LeaveApplyEnabled(rEmp As DataRow) As Boolean
        Dim enabled As Boolean = (myUtils.cValTN(rEmp("leaveauth1id")) > 0 OrElse myUtils.cValTN(rEmp("leaveauth2id")) > 0)
        Return enabled
    End Function
    Public Async Function GetMyEmployeeInfo() As Task(Of ResultInfo(Of EmployeeInfo, HttpStatusCode)) Implements IESSRepository.GetMyEmployeeInfo
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim info = objPOCO.GenerateObject(Of EmployeeInfo)(rEmp)
            If info Is Nothing Then
                Return BuildResponse(info, HttpStatusCode.NotFound, "Not found")
            Else
                Dim dtSub As DataTable = Me.GetSubordinates(rEmp("employeeid"))
                info.LeaveAuthCount = dtSub.Select.Length
                info.LeaveApplyEnabled = Me.LeaveApplyEnabled(rEmp)
                If myUtils.cStrTN(rEmp("profilepicurilist")).Trim.Length > 0 Then
                    Try
                        Dim provider As New clsBlobFileProvider(Me.WebController)
                        Dim pathList = myUtils.DeSerialize(Of List(Of String))(myUtils.cStrTN(rEmp("profilepicurilist")))
                        If pathList.Count > 0 Then
                            Dim path = pathList(pathList.Count - 1)
                            If myUtils.InStrList(path, "//") Then path = Me.WebController.FTP.GetRelativePath(path)
                            info.ProfilePicUris.Add((Await provider.GetDownloadUriFromPath(path)).Result.Uri.ToString)
                        End If
                    Catch ex As Exception
                        Trace.WriteLine("GetMyEmployeInfo:" & ex.Message)
                    End Try
                End If

                Return BuildResponse(info)
            End If

        Catch ex As Exception
            Return BuildExceptionResponse(Of EmployeeInfo)(ex)

        End Try
    End Function

    Public Function GetMyLeaveApplication() As ResultInfo(Of LeaveAppInfo, HttpStatusCode) Implements IESSRepository.GetMyLeaveApplication
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim sql As String = String.Format("select * from hrplistleaveapp() where employeeid={0} and isnull(statuscode,0)=0", rEmp("employeeid"))
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim info = objPOCO.GenerateObject(Of LeaveAppInfo)(dt1)
            Dim str1 As String = String.Format("No Pending Application for employeeid={0}", rEmp("employeeid"))
            If info Is Nothing Then Return BuildResponse(info, HttpStatusCode.OK, str1) Else Return BuildResponse(info)

        Catch ex As Exception
            Return BuildExceptionResponse(Of LeaveAppInfo)(ex)

        End Try

    End Function

    Public Function GetMyLeaveBalance() As ResultInfo(Of List(Of LeaveBalanceInfo), HttpStatusCode) Implements IESSRepository.GetMyLeaveBalance
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim sql As String = String.Format("select {0},sum(Qty) as Balance  from hrplistleavebal() 
                        where iscurrent=1 and employeeid={1} group by {0}", "LeaveMasterID,EmployeeID,PersonID,DepID,EmpCode,FullName,DepName,UseLeaveGroup", rEmp("employeeid"))
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim info = objPOCO.GenerateObjectList(Of LeaveBalanceInfo)(dt1, "", "", "")
            If info Is Nothing Then Return BuildResponse(info, HttpStatusCode.OK, "No Leave Balance") Else Return BuildResponse(info)

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of LeaveBalanceInfo))(ex)

        End Try
    End Function
    Protected Friend Function ReportRow(ReportAppcode As String, fKey As String, fName As String, Tag As String, ClassPath As String) As DataRow
        Dim dt As DataTable
        dt = New DataTable
        dt.Columns.Add("ReportAppCode", GetType(String))
        dt.Columns.Add("fKey", GetType(String))
        dt.Columns.Add("fName", GetType(String))
        dt.Columns.Add("Tag", GetType(String))
        dt.Columns.Add("ClassPath", GetType(String))
        Dim nr As DataRow = dt.NewRow
        nr("ReportAppcode") = ReportAppcode
        nr("fKey") = fKey
        nr("fName") = fName
        nr("Tag") = Tag
        nr("ClassPath") = ClassPath
        dt.Rows.Add(nr)
        Return nr
    End Function
    Public Function GetPayslip(ID As Integer) As Stream Implements IESSRepository.GetPayslip
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim oMaster As New clsMasterDataHRP(Me.WebController)
            Dim sql As String = String.Format("select payslipid,payperiodid,employeeid from hrplistpsbasic() 
                            where payslipid = {0} and employeeid={1} ", ID, rEmp("employeeid"))
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            Dim vwModel As New clsViewModel(Me.WebController)
            If (Not dt1 Is Nothing) AndAlso (dt1.Rows.Count > 0) Then
                Dim provider As New hrpReportDataProvider(Me.WebController)
                vwModel.ListFilts.ActivateFilters("crppppayslip", "<FILTER KEY=""EMP""><VALUE VALUE1=""" & rEmp("employeeid") & """/></FILTER>", EnumViewCallType.acNormal)
                Dim fRow = Me.ReportRow("hrp", "crppppayslip", "Payslip", "", "risersoft.app.reports.erp")
                Dim Model = provider.GenerateReportModel(Me.WebController.GetAppInfo, fRow, vwModel, dt1.Rows(0)("payperiodid"))
                If Model.ds.Tables(0).Rows.Count = 1 AndAlso Model.ds.Tables(0).Rows(0)("payslipid") = ID Then
                    Dim output = Me.WebController.PrintingPress.SpecReportStream(vwModel, fRow, Model)
                    Return output
                Else
                    Return Me.WebController.PrintingPress.TextAndPicStream("Generator Error", "Payslip")
                End If
            Else
                Return Me.WebController.PrintingPress.TextAndPicStream("Not found", "Payslip")
            End If

            '            Return myAssy.GetStream(Assembly.GetExecutingAssembly.GetName.Name, "payslip-test.pdf")

        Catch ex As Exception
            Return Me.WebController.PrintingPress.TextAndPicStream("Not found", "Payslip")

        End Try
    End Function

    Public Function GetMyPersonInfo() As ResultInfo(Of PersonInfo, HttpStatusCode) Implements IESSRepository.GetMyPersonInfo
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim oView As New clsViewModel(Me.WebController)
            Dim oForm As frmHRPersonModel = Me.WebController.DataProvider.LoadForm(Me.WebController.GetAppInfo, oView.ViewState, "frmHRPersonModel", "", EnumfrmMode.acEditM, rEmp("personid")).Result
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim info = objPOCO.GenerateObject(Of PersonInfo)(oForm.myRow.Row)
            info.PmAddress = objPOCO.GenerateObject(Of AddressInfo)(oForm.myRow.Row, "pm")
            info.PmAddress.AddressType = "pm"
            info.PrAddress = objPOCO.GenerateObject(Of AddressInfo)(oForm.myRow.Row, "pr")
            info.PrAddress.AddressType = "pr"
            info.PersEdus = objPOCO.GenerateObjectList(Of PersEduInfo)(oForm.GridViews("edu").MainGrid.myDS.Tables(0), "", "", "")
            info.PersFamilies = objPOCO.GenerateObjectList(Of PersFamilyInfo)(oForm.GridViews("fam").MainGrid.myDS.Tables(0), "", "", "")

            If info Is Nothing Then
                Return BuildResponse(info, HttpStatusCode.NotFound, "Not found")
            Else
                Return BuildResponse(info)
            End If

        Catch ex As Exception
            Return BuildExceptionResponse(Of PersonInfo)(ex)

        End Try
    End Function

    Public Function GetSubordinateApplications() As ResultInfo(Of List(Of LeaveAppInfo), HttpStatusCode) Implements IESSRepository.GetSubordinateApplications
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim dtSub As DataTable = Me.GetSubordinates(rEmp("employeeid"))
            Dim sql As String = String.Format("select * from hrplistleaveapp() where employeeid in ({0}) And isnull(statuscode,0)=0", myUtils.MakeCSV(dtSub.Select, "employeeid"))
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim lst = objPOCO.GenerateObjectList(Of LeaveAppInfo)(dt1, "", "", "")
            If lst Is Nothing Then Return BuildResponse(lst, HttpStatusCode.OK, "No Pending Application") Else Return BuildResponse(lst)


        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of LeaveAppInfo))(ex)

        End Try
    End Function
    Public Function GetSubordinateApplication(LeaveAppID As Integer) As ResultInfo(Of LeaveAppInfo, HttpStatusCode) Implements IESSRepository.GetSubordinateApplication
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim dtSub As DataTable = Me.GetSubordinates(rEmp("employeeid"))
            Dim sql As String = String.Format("select * from hrplistleaveapp() where employeeid in ({0}) And leaveappid={1} and isnull(statuscode,0)=0", myUtils.MakeCSV(dtSub.Select, "employeeid"), LeaveAppID)
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            Dim objPOCO As New clsPOCOConverter(Me.WebController)

            Dim lst = objPOCO.GenerateObjectList(Of LeaveAppInfo)(dt1, "", "", "")
            If (lst Is Nothing) OrElse (lst.Count = 0) Then Return BuildResponse(Of LeaveAppInfo)(Nothing, HttpStatusCode.OK, "No Pending Application") Else Return BuildResponse(lst(0))


        Catch ex As Exception
            Return BuildExceptionResponse(Of LeaveAppInfo)(ex)

        End Try
    End Function

    Public Function GetSubordinateBalance(employeeid As Integer) As ResultInfo(Of List(Of LeaveBalanceInfo), HttpStatusCode) Implements IESSRepository.GetSubordinateBalance
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim dtSub As DataTable = Me.GetSubordinates(rEmp("employeeid"))
            Dim sql As String = String.Format("select {0},sum(Qty) as Balance  from hrplistleavebal() 
                        where iscurrent=1 and employeeid in ({1}) group by {0}", "LeaveMasterID,EmployeeID,PersonID,DepID,EmpCode,FullName,DepName,UseLeaveGroup", myUtils.MakeCSV(dtSub.Select("employeeid=" & employeeid), "employeeid"))
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim info = objPOCO.GenerateObjectList(Of LeaveBalanceInfo)(dt1, "", "", "")
            If info Is Nothing Then Return BuildResponse(info, HttpStatusCode.OK, "No Leave Balance") Else Return BuildResponse(info)

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of LeaveBalanceInfo))(ex)

        End Try

    End Function
    Public Async Function GetMyLocation(Lat As Double, Lng As Double) As Task(Of ResultInfo(Of String, HttpStatusCode)) Implements IESSRepository.GetMyLocation
        Dim oProc As New clsEmpSelfBase(Me.WebController)
        Dim oRet = Await oProc.GetAddress(Lat, Lng)
        If oRet.Success Then
            Return BuildResponse(Of String)(oRet.description)
        Else
            Return BuildResponse("", Me.GetStatus(True), oRet.Message)
        End If

    End Function
    Public Async Function PostMyPunch(location As GeoCoordinate) As Task(Of ResultInfo(Of Integer, HttpStatusCode)) Implements IESSRepository.PostMyPunch
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow, oRet As clsProcOutput
            If myUtils.cBoolTN(rEmp("punchenabled")) Then
                'https://stackoverflow.com/questions/16086962/how-to-get-a-time-zone-from-a-location-using-latitude-and-longitude-coordinates
                Dim zone As String = TZConvert.IanaToWindows(TimeZoneLookup.GetTimeZone(location.Latitude, location.Longitude).Result)
                Dim tst As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(zone)
                Dim Dated As DateTime = DateTime.UtcNow
                If tst IsNot Nothing Then
                    Dated = TimeZoneInfo.ConvertTime(Dated, TimeZoneInfo.Utc, tst)
                End If
                Dim oProc As New clsEmpSelfBase(Me.WebController)
                Dim oRet1 = Await oProc.GetAddress(location.Latitude, location.Longitude)
                If oRet1.Success Then location.Description = oRet1.Description
                oRet1 = oProc.PostPunch(rEmp("employeeid"), Dated, location)

                Dim oProc2 As New CLSProcessPunch(Me.WebController)
                Dim strf1 As String = "EmployeeID = " & rEmp("employeeid")
                Dim oRet2 = oProc2.processPunch(Dated.Date, strf1)

                oRet = oRet1 + oRet2
            Else
                oRet = New clsProcOutput(False, "Punch not enabled")
            End If
            Return BuildOutputResponse(oRet)

        Catch ex As Exception
            Return BuildExceptionResponse(Of Integer)(ex)

        End Try

    End Function

    Public Function SaveMyAddress(info As AddressInfo) As ResultInfo(Of Boolean, HttpStatusCode) Implements IESSRepository.SaveMyAddress
        Try
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim rAdd As DataRow = objPOCO.GenerateRow(info, False, "personid")
            Dim rEmp As DataRow = Me.GetEmployeeRow
            If (Not rAdd Is Nothing) AndAlso (Not rEmp Is Nothing) Then
                Return BuildResponse(False, HttpStatusCode.InternalServerError, "Please email HR Dept")
                If (0 = 1) Then
                    Dim sql As String = String.Format("select * from persons where personid={0}", rEmp("personid"))
                    Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
                    myUtils.MergeDataRow(rAdd, dt1.Rows(0), rAdd("addresstype"))
                    Me.WebController.DataProvider.objSQLHelper.SaveResults(dt1, sql)
                    Return BuildResponse(True)
                End If
            Else
                Return BuildResponse(False, HttpStatusCode.InternalServerError, "Invalid input")
            End If

        Catch ex As Exception
            Return BuildExceptionResponse(Of Boolean)(ex)

        End Try
    End Function

    Public Function SaveMyEducation(info As PersEduInfo) As ResultInfo(Of Integer, HttpStatusCode) Implements IESSRepository.SaveMyEducation
        Try
            Dim objPOCO As New clsPOCOConverter(Me.WebController), nr As DataRow
            Dim rEdu As DataRow = objPOCO.GenerateRow(info, (info.PersEduID = 0), "perseduid")
            Dim rEmp As DataRow = Me.GetEmployeeRow
            If (Not rEdu Is Nothing) AndAlso (Not rEmp Is Nothing) Then
                Return BuildResponse(0, HttpStatusCode.InternalServerError, "Please email HR Dept")
                If (0 = 1) Then
                    Dim sql As String = String.Format("select * from persedu where personid={0}", rEmp("personid"))
                    Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
                    If rEdu.RowState = DataRowState.Added Then
                        nr = myUtils.CopyOneRow(rEdu, dt1)
                    Else
                        Dim rr() As DataRow = dt1.Select("perseduid=" & info.PersEduID)
                        If rr.Length > 0 Then
                            nr = myUtils.MergeDataRow(rEdu, rr(0))
                        End If
                    End If
                    If Not nr Is Nothing Then
                        nr("personid") = rEmp("personid")
                        Me.WebController.DataProvider.objSQLHelper.SaveResults(dt1, sql)
                        Return BuildResponse(CInt(nr("perseduid")))
                    End If
                End If
            End If
            Return BuildResponse(0, HttpStatusCode.InternalServerError, "Invalid input")

        Catch ex As Exception
            Return BuildExceptionResponse(Of Integer)(ex)

        End Try
    End Function

    Public Function SaveMyFamily(info As PersFamilyInfo) As ResultInfo(Of Integer, HttpStatusCode) Implements IESSRepository.SaveMyFamily
        Try
            Dim objPOCO As New clsPOCOConverter(Me.WebController), nr As DataRow
            Dim rFam As DataRow = objPOCO.GenerateRow(info, (info.PersFamilyID = 0), "persfamilyid")
            Dim rEmp As DataRow = Me.GetEmployeeRow
            If (Not rFam Is Nothing) AndAlso (Not rEmp Is Nothing) Then
                Return BuildResponse(0, HttpStatusCode.InternalServerError, "Please email HR Dept")
                If (0 = 1) Then
                    Dim sql As String = String.Format("select * from persfamily where personid={0}", rEmp("personid"))
                    Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
                    If rFam.RowState = DataRowState.Added Then
                        nr = myUtils.CopyOneRow(rFam, dt1)
                    Else
                        Dim rr() As DataRow = dt1.Select("persfamilyid=" & info.PersFamilyID)
                        If rr.Length > 0 Then
                            If String.IsNullOrEmpty(info.MemberName) Then
                                Return BuildResponse(info.PersFamilyID, HttpStatusCode.InternalServerError, "Delete Request - Pl contact HR Dept")
                            Else
                                nr = myUtils.MergeDataRow(rFam, rr(0))
                            End If
                        End If
                    End If
                    If Not nr Is Nothing Then
                        nr("personid") = rEmp("personid")
                        Me.WebController.DataProvider.objSQLHelper.SaveResults(dt1, sql)
                        Return BuildResponse(CInt(nr("persfamilyid")), HttpStatusCode.OK, "Data updated")
                    End If
                End If
            End If
            Return BuildResponse(0, HttpStatusCode.InternalServerError, "Invalid input")

        Catch ex As Exception
            Return BuildExceptionResponse(Of Integer)(ex)

        End Try
    End Function

    Public Function SaveSubordinateApplication(LeaveAppId As Integer, Accepted As Boolean, Comments As String) As ResultInfo(Of Boolean, HttpStatusCode) Implements IESSRepository.SaveSubordinateApplication
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim dtSub As DataTable = Me.GetSubordinates(rEmp("employeeid"))
            Dim sql As String = String.Format("select * from hrplistleaveapp() where employeeid in ({0}) and isnull(statuscode,0)=0", myUtils.MakeCSV(dtSub.Select, "employeeid"))
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            Dim oProc As New clsEmpSelfBase(Me.WebController)
            For Each r1 As DataRow In dt1.Select("leaveappid=" & LeaveAppId)
                'single run loop
                If myUtils.cValTN(r1("authority1id")) = rEmp("employeeid") Then
                    r1("authority1comments") = Comments
                    r1("authority1action") = If(Accepted, EnumApprovalAction.Approved, EnumApprovalAction.Rejected)
                ElseIf myUtils.cValTN(r1("authority2id")) = rEmp("employeeid") Then
                    r1("authority2comments") = Comments
                    r1("authority2action") = If(Accepted, EnumApprovalAction.Approved, EnumApprovalAction.Rejected)
                End If
                r1("statustext") = oProc.CalculateAppStatus(r1)
            Next
            Me.WebController.DataProvider.objSQLHelper.SaveResults(dt1, "select leaveappid,authority1action,authority1comments,authority2action,authority2comments,statuscode,statustext from leaveapp where 0=1")
            Return BuildResponse(True)

        Catch ex As Exception
            Return BuildExceptionResponse(Of Boolean)(ex)

        End Try

    End Function

    Public Function GetMyPayslips() As ResultInfo(Of List(Of PayslipInfo), HttpStatusCode) Implements IESSRepository.GetMyPayslips
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim sql As String = String.Format("select top 13 payslipid,employeeid,sdate,strPeriod, TWDay  from hrplistpsbasic() 
                        where isfinal=1 and employeeid={0}", rEmp("employeeid") & " order by sdate desc")
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim info = objPOCO.GenerateObjectList(Of PayslipInfo)(dt1, "", "sdate desc", "")
            If info Is Nothing Then Return BuildResponse(info, HttpStatusCode.OK, "No payslip in system") Else Return BuildResponse(info)

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of PayslipInfo))(ex)

        End Try
    End Function

    Public Function GetMyPunches() As ResultInfo(Of List(Of GeoCoordinate), HttpStatusCode) Implements IESSRepository.GetMyPunches
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim sql As String = String.Format("select top 10 punchdate,  punchtime, location, geopoint from punchdata 
                        where employeeid={0} order by punchdate desc, punchtime desc", rEmp("employeeid"))
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            Dim objPOCO As New clsPOCOConverter(Me.WebController)
            Dim info As New List(Of GeoCoordinate)
            For Each r1 As DataRow In dt1.Select
                Dim coord As GeoCoordinate
                If GeoCoordinate.TryParse(myUtils.cStrTN(r1("geopoint")).Replace("(", "").Replace(")", ""), coord) Then
                    coord.TimeStamp = Convert.ToDateTime(Format(r1("punchdate"), "dd-MMM-yyyy") & " " & myUtils.cStrTN(r1("punchtime")))
                    coord.Description = myUtils.cStrTN(r1("location"))
                    info.Add(coord)
                End If
            Next
            If info Is Nothing Then Return BuildResponse(info, HttpStatusCode.OK, "No punches in system") Else Return BuildResponse(info)

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of GeoCoordinate))(ex)

        End Try
    End Function

    Public Function GetUploadURL() As ResultInfo(Of String, HttpStatusCode) Implements IESSRepository.GetUploadURL
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Dim provider As New clsBlobFileProvider(Me.WebController)
            Dim oRet = provider.CreateUploadUri("profile", rEmp("employeeid") & "-" & Now.ToUniversalTime.ToString("HHmm"), "ess")
            If oRet.Success Then Return BuildResponse(oRet.Result.Uri.ToString) Else Return BuildResponse("", HttpStatusCode.InternalServerError, "Cannot Create")

        Catch ex As Exception
            Return BuildExceptionResponse(Of String)(ex)

        End Try

    End Function

    Public Function ConfirmURL(url As String) As ResultInfo(Of Boolean, HttpStatusCode) Implements IESSRepository.ConfirmURL
        Try
            Dim rEmp As DataRow = Me.GetEmployeeRow
            Try
                Dim uriList As New List(Of String)
                If myUtils.cStrTN(rEmp("profilepicurilist")).Trim.Length > 0 Then uriList = myUtils.DeSerialize(Of List(Of String))(myUtils.cStrTN(rEmp("profilepicurilist")))
                Dim relativePath As String = Me.WebController.FTP.GetRelativePath(url)
                uriList.Add(relativePath)
                rEmp("profilepicurilist") = myUtils.Serialize(Of List(Of String))(uriList)
                Me.WebController.DataProvider.objSQLHelper.SaveResults(rEmp.Table, "select employeeid,profilepicurilist from employees")
                Return BuildResponse(Of Boolean)(True)
            Catch ex As Exception
                Return BuildResponse(Of Boolean)(False, HttpStatusCode.InternalServerError, ex.Message)
            End Try


        Catch ex As Exception
            Return BuildExceptionResponse(Of Boolean)(ex)

        End Try
    End Function
    Private Function SendEmailForLeaveApplied(LeaveAppID As Integer, AuthNum As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            Dim sql As String = String.Format("select * from hrplistleaveapp() where leaveappid={0}", LeaveAppID)
            Dim dt1 As DataTable = Me.WebController.DataProvider.objSQLHelper.ExecuteDataset(Data.CommandType.Text, sql).Tables(0)
            If dt1.Rows.Count > 0 Then
                Dim rApp As DataRow = dt1.Rows(0)
                Dim mailer As New MailModuleBase(Me.WebController)
                If myUtils.cValTN(rApp("Authority" & AuthNum & "ID")) > 0 AndAlso myUtils.cStrTN(rApp("Authority" & AuthNum & "Email")).Trim.Length > 0 Then
                    Dim message As String = mailer.ReadHtmlTemplate("LeaveApplied.html")
                    message = message.Replace("[AUTHORITYNAME]", rApp("Authority" & AuthNum & "Name"))
                    message = message.Replace("[FULLNAME]", rApp("fullname"))
                    message = message.Replace("[EMPCODE]", rApp("empcode"))
                    message = message.Replace("[STARTDATE]", Format(rApp("startdate"), "dd-MMM-yyyy"))
                    message = message.Replace("[ENDDATE]", Format(rApp("enddate"), "dd-MMM-yyyy"))
                    oRet = Task.Run(Function() mailer.SendGenericMail(rApp("Authority" & AuthNum & "Email"), "Leave Application", message)).Result
                End If

            End If
        Catch ex As Exception
            oRet.AddException(ex)
            Trace.WriteLine("Leave App Send Mail:" & ex.Message)
        End Try
        Return oRet
    End Function
End Class
