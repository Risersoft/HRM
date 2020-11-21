Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmEmpModel
    Inherits clsFormDataModel

    Dim myViewEmpSalBen As clsViewModel
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("EmpSal")
        myViewEmpSalBen = Me.GetViewModel("EmpSalBen")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String

        sql = "SELECT statusnum, statusText from status where StatusType = 'Emp'"
        Me.AddLookupField("statusnum", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "status").TableName)

        sql = "select campusid, dispname, WODate, CompletedOn from mmlistCampus() order by dispname"
        Me.AddLookupField("campusid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "campus").TableName)

        sql = "Select depid, depname, companyid from deps order by depname"
        Me.AddLookupField("depid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "dep").TableName)

        sql = "select employeeid,isNull(EmpCode,'') + ' - ' + descrip [EmployeeName], JoinDate, LeaveDate from hrplistallemp() where onrolls=1 order by EmpCode"
        Me.AddLookupField("ReportsToID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "rep").TableName)

        sql = "select vendorid, partyname from hrplistparty() order by partyname"
        Me.AddLookupField("ContractorID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "party").TableName)

        sql = "select shiftid, shift from shift order by shift"
        Me.AddLookupField("shiftid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "shift").TableName)

        sql = "select VendorID,isNull(IFSCNum,'') + ' | ' + PartyName from acclistFiParty() where PartyType = 'F'"
        Me.AddLookupField("BankBranchID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "bank").TableName)

        sql = "select employeeid,isNull(EmpCode,'') + ' - ' + descrip [EmployeeName], JoinDate, LeaveDate from hrplistallemp() where onrolls=1 order by descrip"
        Me.AddLookupField("LeaveAuth1ID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "leave1").TableName)

        sql = "select employeeid,isNull(EmpCode,'') + ' - ' + descrip [EmployeeName], JoinDate, LeaveDate from hrplistallemp() where onrolls=1 order by descrip"
        Me.AddLookupField("LeaveAuth2ID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "leave2").TableName)

        Dim vlist As New clsValueList
        vlist.Add(False, "Disabled")
        vlist.Add(True, "Enabled")
        Me.ValueLists.Add("EnableList", vlist)
        Me.AddLookupField("ImprestEnabled", "EnableList")
        Me.AddLookupField("PunchEnabled", "EnableList")

        Dim vlst As New clsValueList
        vlst.Add("F", "F - Father")
        vlst.Add("S", "S - Husband")
        Me.ValueLists.Add("Relationship", vlst)
        Me.AddLookupField("Relationship", "Relationship")

        Dim vlst1 As New clsValueList
        vlst1.Add(False, "Salary")
        vlst1.Add(True, "Wages")
        Me.ValueLists.Add("haswage", vlst1)
        Me.AddLookupField("haswage", "haswage")

        Dim vlst2 As New clsValueList
        vlst2.Add(False, "Staff")
        vlst2.Add(True, "Worker")
        Me.ValueLists.Add("isworker", vlst2)
        Me.AddLookupField("isworker", "isworker")

        Dim vlisttag As New clsValueList
        vlisttag.Add(False, "Normal")
        vlisttag.Add(True, "Casual")
        Me.ValueLists.Add("IsCasual", vlisttag)
        Me.AddLookupField("IsCasual", "IsCasual")

        sql = "SELECT Divisionid, DivisionName  from Division"
        Me.AddLookupField("Divisionid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Division").TableName)

        sql = myFuncsBase.CodeWordSQL("emp", "leavereason", "")
        Me.AddLookupField("LeftReasonCode", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "emp").TableName)

        sql = myFuncsBase.CodeWordSQL("emp", "paymentthru", "")
        Me.AddLookupField("paymentthrucode", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "emp1").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1, sql As String, dtEmpSal As DataTable, oMasterData As New clsMasterDataHRP(myContext)
        Dim ds As DataSet

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select *, 0 as CompanyID from Employees where employeeid = " & prepIDX
        Me.InitData(sql, "personid", oView, prepMode, prepIDX, strXML)

        Dim myuserid = If(myRow("userid") Is DBNull.Value, Guid.Empty, myRow("userid"))
        sql = $"Select userid, username from users where isnull(isdeleted,0)=0 And (userid Not In (Select userid from employees where userid is not null) Or userid='{myuserid}') order by username"
        Me.AddLookupField("userid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "user").TableName)

        Dim dic As New clsCollecString(Of String)
        dic.Add("fullname", "select fullname from persons where personid =" & myUtils.cValTN(myRow("personid")))
        dic.Add("employeeid", "select employeeid From employees where leavedate is null and personid = " & myUtils.cValTN(myRow("personid")))
        dic.Add("VendorCode", "select * from vendor where employeeid = " & frmIDX)
        ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        If ds.Tables(0).Rows.Count > 0 Then Me.ModelParams.Add(New clsSQLParam("@Name", "'" & ds.Tables(0).Rows(0)("fullName") & "'", GetType(String), False))
        If (ds.Tables(1).Rows.Count > 0) AndAlso (frmMode = EnumfrmMode.acAddM) Then Me.AddError("EmpCode", "This person is already added as an Employee")
        If ds.Tables("VendorCode").Rows.Count = 0 Then
            Me.ModelParams.Add(New clsSQLParam("@VendorCode", "'" & "Not Defined" & "'", GetType(String), False))
        Else
            Me.ModelParams.Add(New clsSQLParam("@VendorCode", "'" & ds.Tables("vendorcode").Rows(0)("vendorcode") & "'", GetType(String), False))
        End If

        If myUtils.IsInList(myUtils.cStrTN(myContext.Vars("appcode")), "HRP", "NHRM") Then

            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Dated"" CAPTION=""Date""/><COL KEY=""OTSalMult"" CAPTION=""OTSalMultiple""/><COL KEY=""SkillText"" CAPTION=""Skill""/>"
            myView.MainGrid.BindGridData(GenerateData("sal", frmIDX), 0)
            myView.MainGrid.QuickConf("", True, "1-1-1-1-1-1", True)

            myViewEmpSalBen.MainGrid.MainConf("fixcols") = "5"
            sql = "Select EmpSalBenefitID, EmployeeID, 0 As PayPeriodID, 0 As IsFinal, SalBenefitID, BenefitMemNum, EEDate, Remark  from empsalbenefit where employeeid = " & frmIDX & ""
            myViewEmpSalBen.MainGrid.MainConf("FORMATXML") = "<COL KEY=""BenefitMemNum"" CAPTION=""Benefit Number""/>"
            myViewEmpSalBen.MainGrid.QuickConf(sql, True, "1-1-1-1", True)
            str1 = "<BAND INDEX=""0"" TABLE=""EmpSalBenefit"" IDFIELD=""EmpSalBenefitID""><COL NOEDIT=""True"" KEY=""SalBenefitID "" LOOKUPSQL = ""Select SalBenefitID, BenefitName from salbenefit"" CAPTION = ""Benefit""/> <COL KEY="" EmpSalBenefitID, EmployeeID, BenefitName, BenefitMemNum, EEDate, Remark""/></BAND>"
            myViewEmpSalBen.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

            Dim dtPP As DataTable = oMasterData.dtPayPeriod()
            For Each r1 As DataRow In myViewEmpSalBen.MainGrid.myDS.Tables(0).Select()
                If Not myUtils.NullNot(r1("EEDate")) Then
                    Dim rr1() As DataRow = dtPP.Select("SDate <= '" & Format(r1("EEDate"), "yyyy-MMM-dd") & "'  and EDate >= '" & Format(r1("EEDate"), "yyyy-MMM-dd") & "'")
                    If (Not IsNothing(rr1)) AndAlso (rr1.Length > 0) Then
                        r1("PayperiodID") = rr1(0)("PayperiodID")
                        r1("isfinal") = rr1(0)("isfinal")
                    End If
                End If
            Next


            Dim dic1 As New clsCollecString(Of String)
            dic1.Add("empsal", "select * from empsalary where employeeid = " & frmIDX)
            Me.AddDataSet("empsal", dic1)

            dtEmpSal = DatasetCollection("empsal").Tables(0)

            If dtEmpSal.Rows.Count > 0 Then Me.ModelParams.Add(New clsSQLParam("@EmpSalCnt", 1, GetType(Integer), False))
        End If
        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If Me.myRow("empcode").Trim.Length = 0 Then Me.AddError("empcode", "Enter Code")
        If Me.SelectedRow("campusid") Is Nothing Then Me.AddError("campusid", "Enter Campus")
        If Me.SelectedItem("haswage") Is Nothing Then Me.AddError("haswage", "Enter Wage/Salary")
        If Me.SelectedItem("isworker") Is Nothing Then Me.AddError("isworker", "Enter Staff/Worker")
        If Me.SelectedRow("paymentthrucode") Is Nothing Then Me.AddError("paymentthrucode", "Must Select PaymentThruCode")
        If Me.SelectedRow("shiftid") Is Nothing Then Me.AddError("shiftid", "Enter Shift")
        If Me.SelectedRow("StatusNum") Is Nothing Then Me.AddError("StatusNum", "Enter Status")
        If Me.SelectedRow("depid") Is Nothing Then Me.AddError("depid", "Enter Dep")
        If Me.SelectedRow("divisionid") Is Nothing Then Me.AddError("divisionid", "Enter Division")
        If myUtils.NullNot(myRow("JoinDate")) Then Me.AddError("JoinDate", "Please Select Join Date.")

        If myUtils.IsInList(myUtils.cValTN(myRow("paymentthrucode")), 1) AndAlso Me.SelectedRow("BankBranchID") Is Nothing Then Me.AddError("BankBranchID", "Enter Bankname")
        If myUtils.IsInList(myUtils.cStrTN(myContext.Vars("appcode")), "HRP", "NHRM") Then
            myViewEmpSalBen.MainGrid.CheckValid("BenefitMemNum,EEDate")
        End If

        If myUtils.cValTN(myRow("leaveAuth1ID")) = myUtils.cValTN(myRow("leaveAuth2ID")) AndAlso myUtils.cValTN(myRow("leaveAuth2ID")) > 0 Then
            Me.AddError("leaveAuth2ID", "LeaveAuthority1 and LeaveAuthority2 can't be same")
        End If

        Return Me.CanSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim empid As Integer, dtEmps As DataTable = Nothing
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)

        If oRet.Success Then
            Select Case dataKey.Trim.ToUpper
                Case "EMPID"
                    empid = myUtils.cValTN(myContext.SQL.ParamValue("@empid", Params))
                    Dim sql As String = myContext.SQL.PopulateSQLParams("select EmployeeID, FullName, ReportsToID from hrplistemp() where onrolls=1 and employeeid in (@idcsv)", Params)
                    dtEmps = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                    For Each r1 As DataRow In dtEmps.Select()
                        r1("reportstoid") = empid
                    Next
                    myContext.Provider.objSQLHelper.SaveResults(dtEmps, "select employeeid, reportstoid from employees")
                    oRet.Message = "Successfully Updated"
            End Select
        End If
        Return oRet

    End Function

    Public Overrides Function VSave() As Boolean
        Dim rLM As DataRow, oMasterData As New clsMasterDataHRP(myContext), objLM As New clsLeaveBase(myContext), objProc As New clsProcOutput
        VSave = False

        If Me.Validate Then
            Dim sql As String = "select * from employees where personid  <>  " & myUtils.cValTN(myRow("personid")) & " and empcode = '" & myUtils.cStrTN(myRow("empcode")) & "' and (iscasual=0 or onrolls=1)"
            Dim dt1 As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
            If dt1.Select.Length > 0 Then Me.AddError("", "Empcode already exists")

            sql = "select employeeid,joindate,leavedate from employees where employeeid = " & frmIDX
            dt1 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
            If (dt1.Rows.Count > 0) AndAlso myRow("Joindate") <> dt1.Rows(0)("Joindate") Then
                If myRow("depid") > 0 Then
                    Dim CompanyID As Integer = myContext.CommonData.GetCompanyIDFromDepHR(myRow("depid"))
                    Dim r As DataRow = oMasterData.PPRow(CompanyID, myRow("Joindate"))
                    Dim r1 As DataRow = oMasterData.PPRow(CompanyID, dt1.Rows(0)("Joindate"))

                    If (r IsNot Nothing AndAlso myUtils.cValTN(r("IsFinal")) = 1) OrElse (r1 IsNot Nothing AndAlso myUtils.cValTN(r1("IsFinal")) = 1) Then
                        Me.AddError("", "JoinDate Cannot be changed as Payperiod is already finalized")
                    End If
                End If
            End If

            If myUtils.IsInList(myUtils.cStrTN(myContext.Vars("appcode")), "HRP", "NHRM") Then
                Dim oProc As New clsEmpSelfBase(myContext)
                For Each r1 As DataRow In myViewEmpSalBen.MainGrid.myDS.Tables(0).Select()
                    If (Not myUtils.NullNot(r1("BenefitMemNum"))) AndAlso (Not myUtils.NullNot(r1("EEDate"))) Then
                        Dim oRet1 = oProc.ValidateBenefitEEDate(myRow.Row, r1)
                        If Not oRet1.Success Then Me.AddError("empsalben", r1, 0, "eedate", "", oRet1.Message)

                        Dim oRet2 = oProc.ValidateBenefitEENum(myRow.Row, r1)
                        If Not oRet2.Success Then Me.AddError("empsalben", r1, 0, "benefitmemnum", "", oRet2.Message)
                    End If
                Next

            End If


            If Me.CanSave Then
                Dim Sql1 As String = "Select PersonID, FullName from genListPersons() where PersonID = " & myUtils.cValTN(myRow("PersonID"))
                Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql1)
                Dim EmpDescrip As String = " Code: " & myRow("EmpCode").ToString & ", Name: " & myUtils.cStrTN(ds.Tables(0).Rows(0)("FullName"))
                Try
                    myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "employeeid", frmIDX)
                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                    frmIDX = myRow("employeeid")
                    If myUtils.IsInList(myUtils.cStrTN(myContext.Vars("appcode")), "HRP", "NHRM") Then
                        myViewEmpSalBen.MainGrid.SaveChanges(, "employeeid=" & frmIDX)
                    End If
                    Dim dtPP As DataTable = oMasterData.dtPayPeriod()
                    Dim rr1() As DataRow = dtPP.Select("sdate < = '" & Format(myRow("JoinDate"), "yyyy-MMM-dd") & "' and edate >= '" & Format(myRow("JoinDate"), "yyyy-MMM-dd") & "'")

                    If Not IsNothing(rr1) AndAlso rr1.Length > 0 Then
                        If myUtils.cValTN(rr1(0)("IsFinal")) <> 1 Then
                            rLM = oMasterData.rLeaveMasterID(rr1(0)("LeaveMasterID"))
                            myRow.Row("CompanyID") = myContext.CommonData.GetCompanyIDFromCampus(myRow.Row("CampusID"))
                            objProc = objLM.CalculateLeaveBalanceEmp(myRow.Row)
                        End If
                    End If

                    frmMode = EnumfrmMode.acEditM
                    myContext.Provider.dbConn.CommitTransaction(EmpDescrip, frmIDX)
                    VSave = True
                Catch e As Exception
                    myContext.Provider.dbConn.RollBackTransaction(EmpDescrip, e.Message)
                    Me.AddException("", e)
                End Try


            End If
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput, sql As String, ds As DataSet
        Select Case dataKey
            Case "vendor"
                sql = "select * from vendor where employeeid = " & ID
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)

                If ds.Tables(0).Rows.Count = 0 Then
                    If (frmMode = EnumfrmMode.acEditM) OrElse (Me.VSave) Then
                        Dim nr As DataRow = myContext.Tables.AddNewRow(ds.Tables(0))
                        nr("employeeid") = ID
                        nr("vendortype") = "EM"
                        Dim objNum As New clsVoucherNum(myContext)
                        nr("vendorcode") = objNum.GetNewSerialNo("VendorID", "EM", nr)
                        myContext.Provider.objSQLHelper.SaveResults(ds.Tables(0), "select * from vendor where 0=1")
                    End If
                End If
                oRet.Data = ds

            Case "calcleavebal"
                Dim objProc As New clsLeaveBase(myContext)
                oRet = objProc.CalculateELBalanceEmp(ID)

            Case "sal"
                oRet.Data = GenerateData("sal", myUtils.cValTN(ID))
            Case "reinstate"
                Dim oProc As New clsFullFinalBase(myContext)
                oRet = oProc.ReinstateFullFinal(ID)
        End Select
        Return oRet
    End Function

    Protected Overrides Function GenerateData(DataKey As String, ID As String) As DataSet
        Dim oRet As New clsProcOutput
        Select Case DataKey.Trim.ToLower
            Case "sal"
                Dim sql As String = "select EmpSalaryID, Dated, perTDSNorm, Other, OTHourRate, OTSalMult, SkillText from empsalary where employeeid = " & ID & " and dated is not null"
                oRet.Data = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
        End Select

        Return oRet.Data
    End Function

    Public Overrides Function GenerateParamsModel(vwState As clsViewState, SelectionKey As String, Params As List(Of clsSQLParam)) As clsViewModel
        Dim Model As clsViewModel = Nothing, sql As String
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Select Case SelectionKey.Trim.ToLower
                Case "salbenefit"
                    Dim empid As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@empid", Params))
                    sql = "select * from SalBenefit where SalBenefitID not in (select SalBenefitID from EmpSalBenefit where EmployeeID = " & empid & ")"
                    Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                    Dim Str1 As String = myUtils.MakeCSV(dt.Select(), "SalBenefitID")
                    Model = myContext.Provider.GenerateSelectionModel(vwState, "<SYS ID=""SalBenefitID""/>", True, , "<MODROW><SQLWHERE2>SalBenefitID in (" & Str1 & ")</SQLWHERE2></MODROW>")

                Case "emp"
                    Dim empid As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@employeeid", Params))
                    sql = "select EmployeeID, FullName, ReportsToID from hrplistemp() where onrolls=1 and reportstoid = " & empid
                    Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                    Dim Str1 As String = myUtils.MakeCSV(dt.Select(), "EmployeeID")
                    Model = myContext.Provider.GenerateSelectionModel(vwState, "<SYS ID=""EmployeeID""/>", True, , "<MODROW><SQLWHERE2>EmployeeID in (" & Str1 & ")</SQLWHERE2></MODROW>")

                Case "newemp"
                    Dim empid As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@empid", Params))
                    Dim empcsv As String = myUtils.cValTN(myContext.SQL.ParamValue("@idcsv", Params))

                    sql = "select EmployeeID, FullName, ReportsToID from hrplistemp() where onrolls=1 and reportstoid <> " & empid & " and employeeid not in (" & empcsv & ")"
                    Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                    Dim Str1 As String = myUtils.MakeCSV(dt.Select(), "EmployeeID")
                    Model = myContext.Provider.GenerateSelectionModel(vwState, "<SYS ID=""EmployeeID""/>", False, , "<MODROW><SQLWHERE2>EmployeeID in (" & Str1 & ")</SQLWHERE2></MODROW>")

                Case "bankbranch"
                    Model = myContext.Provider.GenerateSelectionModel(vwState, "<SYS ENT=""F""/>", False, , "<MODROW><SQLWHERE2>Partytype ='F'</SQLWHERE2></MODROW>")
            End Select
        End If
        Return Model
    End Function

End Class
