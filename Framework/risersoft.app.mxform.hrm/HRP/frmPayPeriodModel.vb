Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud

<DataContract>
Public Class frmPayPeriodModel
    Inherits clsFormDataModel

    Dim myViewPayPeriodBenefit, myViewPayPVouch, myViewPayPCampus As clsViewModel
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Holiday")
        myViewPayPeriodBenefit = Me.GetViewModel("PayPBen")
        myViewPayPVouch = Me.GetViewModel("PayPVouch")
        myViewPayPCampus = Me.GetViewModel("PayPCampus")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()


        Dim vlistlp As New clsValueList
        vlistlp.Add(True, "Working")
        vlistlp.Add(False, "Holiday")



        Me.ValueLists.Add("Tnvlp", vlistlp)
        Me.AddLookupField("HolidayType", "HolidayType", "Tnvlp")
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql1 As String
        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        Dim sql As String = "Select * from PayPeriod where PayPeriodID = " & prepIDX
        Me.InitData(sql, "companyid", oView, prepMode, prepIDX, strXML)

        AssignMasters()

        sql = "select holidayid, PayPeriodID, CampusID, Dated, Holiday, Isworking from holiday where CampusID in (select CampusID  from Campus where CompanyID in (select Companyid from RateMaster where RateMasterID= " & myUtils.cValTN(myRow("RateMasterID")) & ")) and dated > = '" & Format(myRow("sdate"), "yyyy-MMM-dd") & "' and Dated < = '" & Format(myRow("edate"), "yyyy-MMM-dd") & "' and PayPeriodID = " & frmIDX & ""
        myView.MainGrid.QuickConf(sql, True, "1-1-1-1")
        sql1 = " select CampusID, DispName  from Campus where CompanyID in (select Companyid from RateMaster where RateMasterID = " & myUtils.cValTN(myRow("RateMasterID")) & ") "
        myView.MainGrid.PrepEdit("<BAND INDEX=""0"" TABLE=""HOLIDAY"" IDFIELD=""HOLIDAYID""><COL KEY=""Dated,Holiday,PayPeriodID""/><COL KEY=""Isworking"" CAPTION=""Type"" VLIST=""False;Holiday|True;Working""/><COL KEY=""CampusID"" CAPTION=""Campus"" WFACTOR=""2"" LOOKUPSQL = """ & sql1 & """/></BAND>", EnumEditType.acCommandAndEdit)
        fillGrids()

        If (Not (frmMode = EnumfrmMode.acEditM) AndAlso (myUtils.cBoolTN(myRow("isfinal")))) Then Me.FormPrepared = True

        If myUtils.NullNot(myRow("AccVouchDate")) Then myRow("AccVouchDate") = myRow("EDate")

        Return Me.FormPrepared
    End Function

    Private Sub AssignMasters()
        Dim dt As DataTable, sql As String, rComp As DataRow

        If frmMode = EnumfrmMode.acAddM Then
            rComp = myContext.CommonData.rCompany(Me.vBag("CompanyID"))
            myRow("CompanyID") = rComp("CompanyID")
            Dim str1 As String = "ratemasterid in (select ratemasterid from ratemaster where companyid=" & myRow("companyid") & ")"
            If myUtils.cStrTN(Me.vBag("TYPE")).Trim.ToLower = "old" Then
                sql = "SELECT top 1 (sdate) as st from payperiod where " & str1 & "  order by sdate asc"
            Else
                sql = "Select top 1 (edate) As ed from payperiod where " & str1 & " order by edate desc"
            End If
            dt = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
            If dt.Rows.Count > 0 Then
                If myUtils.cStrTN(Me.vBag("TYPE")).Trim.ToLower = "old" Then
                    myRow("sdate") = DateAdd("m", -1, dt.Rows(0)(0))
                Else
                    myRow("sdate") = DateAdd("d", 1, dt.Rows(0)(0))
                End If
            Else
                myRow("sdate") = rComp("HRStartDate")

            End If
            myRow("edate") = DateAdd("d", -1, DateAdd("m", 1, myRow("sdate")))
        Else
            rComp = myContext.CommonData.rCompany(myRow("CompanyID"))
        End If

        Dim objPayPeriod As New clsPayPeriodBase(myContext)
        objPayPeriod.AssignMasters(myRow.Row)

        'Above statement may cause master creation, hence lookupfields should be called later.

        sql = $" select ratemasterid,  'Rate Master Dt. ' + convert(varchar,dated,106) as Descrip , Dated from ratemaster where companyid = {rComp("CompanyID")} "
        Me.AddLookupField("ratemasterid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "rm").TableName)

        sql = $"select companyid, compname from company where companyid = {rComp("CompanyID")}"
        Me.AddLookupField("companyid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "company").TableName)

        sql = $"Select leavemasterid, descrip, sdate, edate from leavemaster where companyid = {rComp("CompanyID")}"
        Me.AddLookupField("leavemasterid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "lve").TableName)

        sql = $"Select bonusmasterid,descrip,sdate,edate from bonusmaster where companyid = {rComp("CompanyID")}"
        Me.AddLookupField("bonusmasterid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "bonus").TableName)

        sql = "Select postperiodid,qtrdescrip from PostPeriod"
        Me.AddLookupField("postperiodid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "postperiod").TableName)

        If myRow("sdate") < rComp("hrstartdate") Then myRow("isfinal") = True
    End Sub

    Private Sub fillGrids()
        Dim str, sql As String
        If Not IsNothing(frmIDX) Then

            myViewPayPVouch.MainGrid.MainConf("fixcols") = "5"
            sql = "Select PayPeriodID, ContractorID, PayPeriodName, VouchTypeDescrip, PayDueTypeDescrip, Payee, TotalAmount, PaymentThruCodeDescrip from " &
                "hrplistPaymentHRVouch() where PayPeriodid = " & frmIDX & " "
            myViewPayPVouch.MainGrid.MainConf("FORMATXML") = "<COL KEY=""PaymentThruCodeDescrip"" CAPTION=""Payment Mode""/><COL KEY=""VouchTypeDescrip"" CAPTION=""Voucher Type""/><COL KEY=""PayDueTypeDescrip"" CAPTION=""PayDue Type""/>"
            myViewPayPVouch.MainGrid.QuickConf(sql, True, "1-1-1-1-1", True)

            sql = "Select PayPeriodID, PayPeriodName, DispName, HWDay, TWDay from hrpListPayPeriodCampus()  where PayPeriodID = " & frmIDX & " "
            myViewPayPCampus.MainGrid.MainConf("FORMATXML") = "<COL KEY=""DispName"" CAPTION=""Campus""/><COL KEY=""HWDay"" CAPTION=""Half Month Working Days""/><COL KEY=""TWDay"" CAPTION=""Month Working Days""/>"
            myViewPayPCampus.MainGrid.QuickConf(sql, True, "1-1-1-1", True)

            myViewPayPeriodBenefit.MainGrid.MainConf("fixcols") = "5"
            sql = "Select PayPeriodBenefitID, PayPeriodid, SalBenefitid, BenefitCode, BenefitName, payperiodName, ChallanDate, Limit, perEE, perER1, " &
                  "perER2,  perAdminAmount1, perAdminAmount2, perAdminAmount3, AmountEE, AmountER1, AmountER2, AdminAmount1, AdminAmount2 from hrpListPayPeriodBenefit() " &
                  "where PayPeriodid = " & frmIDX & ""

            myViewPayPeriodBenefit.MainGrid.MainConf("FORMATXML") = "<COL KEY=""BenefitCode"" CAPTION=""Code"" GROUP=""Benefit""/><COL KEY=""ChallanDate"" CAPTION=""Challan"" GROUP=""Benefit""/><COL KEY=""Limit"" CAPTION=""Limit"" GROUP=""Benefit""/><COL KEY=""BenefitName"" CAPTION=""Name"" GROUP=""Benefit""/><COL KEY=""payperiodName"" CAPTION=""PayPeriod"" GROUP=""Benefit""/><COL KEY=""perEE"" CAPTION=""Employee"" GROUP=""Share Percentage""/><COL KEY=""perER1"" CAPTION=""Employer1"" GROUP=""Share Percentage""/><COL KEY=""perER2"" CAPTION=""Employer2"" GROUP=""Share Percentage""/><COL KEY=""perAdminAmount1"" CAPTION=""Amount1"" GROUP=""Admin Percentage""/><COL KEY=""perAdminAmount2"" CAPTION=""Amount2"" GROUP=""Admin Percentage""/><COL KEY=""perAdminAmount3"" CAPTION=""Amount3"" GROUP=""Admin Percentage""/><COL KEY=""AmountEE"" CAPTION=""Employee"" GROUP=""Amount""/><COL KEY=""AmountER1"" CAPTION=""Employer1"" GROUP=""Amount""/><COL KEY=""AmountER2"" CAPTION=""Employer2""  GROUP=""Amount""/><COL KEY=""AdminAmount1"" CAPTION=""Amount1"" GROUP = ""Admin""/><COL KEY=""AdminAmount2"" CAPTION=""Amount2"" GROUP = ""Admin""/>"
            myViewPayPeriodBenefit.MainGrid.QuickConf(sql, True, "1-1-1.5-1-1-1-1-1-1-1-1-1-1-1-1", True)
            str = "<BAND INDEX=""0"" TABLE=""PayPeriodBenefit"" IDFIELD=""PayPeriodBenefitID""><COL KEY="" PayPeriodID, SalBenefitID,  ChallanDate""/></BAND>"
            myViewPayPeriodBenefit.MainGrid.PrepEdit(str, EnumEditType.acCommandAndEdit)

        End If
    End Sub

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.NullNot(myRow("SDate")) Then Me.AddError("SDate", "Select a starting Date")
        If myUtils.NullNot(myRow("eDate")) Then Me.AddError("eDate", "Select an ending Date")
        If Me.SelectedRow("RateMasterID") Is Nothing Then Me.AddError("RateMasterID", "Select a Rate Master")
        If Me.SelectedRow("BonusMasterID") Is Nothing Then Me.AddError("BonusMasterID", "Select a Bonus Master")
        If Me.SelectedRow("LeaveMasterID") Is Nothing Then Me.AddError("LeaveMasterID", "Select a Leave Master")
        If Me.SelectedRow("CompanyID") Is Nothing Then Me.AddError("CompanyID", "Select a Company")
        If myUtils.cStrTN(myRow("PayPeriodName")).Trim.Length = 0 Then Me.AddError("PayPeriodName", "Enter a Description")
        If myUtils.NullNot(myRow("Ratemasterid")) Then Me.AddError("PayPeriodName", "Date Out Of Range")

        myView.MainGrid.CheckValid("Dated,isworking,holiday,CampusID", , , "<CHECK COND=""Dated&gt;='" & Format(myRow("sdate"), "yyyy-MMM-dd") & "' AND Dated&lt;='" & Format(myRow("edate"), "yyyy-MMM-dd") & "'"" MSG=""Select Date within limits""/>")

        If Math.Abs(DateDiff(DateInterval.Day, myRow("edate"), myRow("AccVouchDate"))) > 10 Then
            Me.AddError("AccVouchDate", "Select Date within 10 days of End date")
        End If

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            Dim PayperiodDescrip As String = myUtils.cStrTN(myRow("PayPeriodName"))
            Try
                If frmMode = EnumfrmMode.acAddM Then
                    myRow("isfinal") = False
                    myRow("isfinalwot") = False
                    myRow("haswot") = True
                    myRow("forcesingleot") = True
                End If
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "PayPeriodID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow.Row("PayPeriodID")

                Me.myView.MainGrid.SaveChanges(, "payperiodid = " & frmIDX)
                Me.myViewPayPeriodBenefit.MainGrid.SaveChanges(, "payperiodid = " & frmIDX)

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(PayperiodDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(PayperiodDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput
        Select Case dataKey.Trim.ToLower
            Case "advancedep"
                Dim objPayP As New clsPayPeriodBase(myContext)
                oRet = objPayP.GenerateAdvanceDep(ID)
            Case "advance"
                Dim objPayP As New clsPayPeriodBase(myContext)
                oRet = objPayP.GenerateAdvance(ID)
            Case "finalize"
                oRet = Me.FinalizePPField(ID, "isfinal", "saldirtyon", "Payperiod already finalized")
            Case "finalwot"
                oRet = Me.FinalizePPField(ID, "isfinalwot", "wotdirtyon", "Payperiod Incentive and overtime already finalized")
            Case "finaladv"
                oRet = Me.FinalizePPField(ID, "isfinaladv", "", "Payperiod Advance already finalized")
        End Select
        Return oRet
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        Dim PayPeriodID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@payperiodid", Params))
        Dim BenefitCode As String = myUtils.cStrTN(myContext.SQL.ParamValue("@benefitcode", Params))
        Dim ReturnTaskID As String = myContext.SQL.ParamValue("@ApiTaskID", Params)

        If oRet.Success Then
            Dim queueName = myContext.Controller.CalcQueueName
            If myUtils.IsInList(dataKey, "infojson") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet.Description = myContext.Provider.objSQLHelper.ExecuteScalar(CommandType.Text, "SELECT INFOJSON FROM APITASK WHERE APITaskID ='" & ReturnTaskID.ToString & "'").ToString
            ElseIf myUtils.IsInList(dataKey, "payloadstatus") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet = QueueTaskProvider.GetTaskStatus(myContext, ReturnTaskID)
            Else
                Select Case dataKey.Trim.ToLower
                    Case "benefit"
                        Dim sql As String = "select hlSalB.BenefitCode, hlSalB.BenefitMemNum, hlSalB.FullName, hlSalB.sDate, hlSalB.eDate,hlPsb.Birthday, hlPsb.JoinDate, " &
                  "hlPsb.LeaveDate, hlSalB.EEDate,hlPsb.CellNum, hlPsb.Email, hlPsb.CareOf, hlPsb.RelationShip,hlPsb.IsFemale,hlPsb.LeftReasonCode, " &
                  "hlPsb.Sex, hlSalB.BenefitEarn,hlPsb.TotalBasicPS,hlpsb.TotalBasicES, hlPsb.TotalAllow, hlPsb.EWDay, hlPsb.Absent, hlSalB.AmountEE, " &
                  "hlSalB.AmountER1, hlSalB.AmountER2  from hrpListPSBenefit() as hlSalB  inner join hrpListPSBasic() as hlPsb  on " &
                  "hlSalB.PaySlipID = hlPsb.PaySlipID  where hlSalB.iscasual = 0 and  BenefitMemNum is not null and BenefitCode = '" & BenefitCode & "' and hlSalB.payperiodid = " & PayPeriodID

                        oRet.Data = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)

                    Case "left"
                        Dim sql As String = "select hlSalB.BenefitCode, hlSalB.BenefitMemNum, hlSalB.FullName, hlSalB.sDate, hlSalB.eDate, hlPsb.JoinDate, " &
                  "hlPsb.LeaveDate, hlPsb.LeftReasonCode from hrpListPSBenefit() as hlSalB  inner join hrpListPSBasic() as hlPsb  on " &
                  "hlSalB.PaySlipID = hlPsb.PaySlipID  where hlSalB.iscasual = 0 and BenefitMemNum is not null and  hlPsb.leavedate is not null " &
                  "and hlPsb.leavedate between hlSalB.sDate and hlSalB.eDate and BenefitCode = '" & BenefitCode & "' and hlSalB.payperiodid = " & PayPeriodID

                        oRet.Data = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                    Case "calcppsal"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "pp", dataKey, PayPeriodID, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                    Case "calcppinc"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "pp", dataKey, PayPeriodID, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                    Case "calcppsumm"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "pp", dataKey, PayPeriodID, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                    Case "calcincsumm"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "pp", dataKey, PayPeriodID, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                    Case "uncalcppsal"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "pp", dataKey, PayPeriodID, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                End Select
            End If
        End If
        Return oRet
    End Function

    Protected Friend Function FinalizePPField(PayPeriodID As Integer, FinalFieldName As String, DirtyFieldName As String, ErrorMessage As String) As clsProcOutput
        Dim oRet As New clsProcOutput, sql As String
        If String.IsNullOrEmpty(DirtyFieldName) Then
            sql = String.Format("select payperiodid,{0} from payperiod where payperiodid={1}", FinalFieldName, PayPeriodID)
        Else
            sql = String.Format("select payperiodid,{0},{1} from payperiod where payperiodid={2}", FinalFieldName, DirtyFieldName, PayPeriodID)
        End If
        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
        If dt.Rows.Count > 0 Then
            If myUtils.cBoolTN(dt.Rows(0)(FinalFieldName)) Then
                oRet.AddError(ErrorMessage)
            ElseIf (Not String.IsNullOrEmpty(DirtyFieldName)) AndAlso (Not myUtils.NullNot(dt.Rows(0)(DirtyFieldName))) Then
                oRet.AddError("Payperiod calculation dirty .. Pl recalculate")
            Else
                dt.Rows(0)(FinalFieldName) = True
                'SQLHelper.SaveResults(dt, sql)
                myContext.Provider.objSQLHelper.SaveResults(dt, sql)
            End If
        End If
        Return oRet
    End Function
End Class
