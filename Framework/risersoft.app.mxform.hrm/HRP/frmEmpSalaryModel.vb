Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmEmpSalaryModel
    Inherits clsFormDataModel

    Dim myViewEmpSalRateCalc, myViewLastCalculated As clsViewModel, sql As String

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("EmpSalComp")
        myViewEmpSalRateCalc = Me.GetViewModel("SalRateCalc")
        myViewLastCalculated = Me.GetViewModel("LastCalculated")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        sql = myFuncsBase.CodeWordSQL("sal", "skill", "")
        Me.AddLookupField("SkillText", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "SkillText").TableName)

        sql = "select SalStructureID, StructureName from SalStructure "
        Me.AddLookupField("SalStructureID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "SalStructure").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1 As String, ds As DataSet

        Me.FormPrepared = False
        If (prepMode = EnumfrmMode.acEditM) OrElse (prepMode = EnumfrmMode.acCopyM) Then
            If myUtils.cValTN(prepIDX) = 0 Then prepIDX = oView.ContextRow.CellValue("EmpSalaryID")
        Else
            prepIDX = 0
        End If

        sql = "select * from EmpSalary where EmpSalaryID = " & prepIDX
        Me.InitData(sql, "ratemasterid,pGross,EmployeeID,payproposalid", oView, prepMode, prepIDX, strXML)

        sql = "select EmpSalCompID, EmpSalaryID, SalComponentID, Amount from EmpSalComp where EmpSalaryID = " & frmIDX
        myView.MainGrid.QuickConf(sql, True, "5-5", True)
        str1 = "<BAND INDEX = ""0"" TABLE = ""EmpSalComp"" IDFIELD=""EmpSalCompID""><COL KEY=""Amount""/><COL NOEDIT=""TRUE"" KEY=""SalComponentID"" LOOKUPSQL=""select SalComponentID, ComponentName from SalComponent"" CAPTION=""Component"" /></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        If prepMode = EnumfrmMode.acAddM Then
            myRow("OTSalMult") = 1
            Me.CopyIDX = myUtils.cValTN(Me.vBag("oldsmid"))
        End If

        If CopyIDX > 0 Then
            sql = "select * from empsalary where empsalaryid = " & CopyIDX
            sql = sql & "; select EmpSalCompID, EmpSalaryID, SalComponentID, Amount from EmpSalComp where EmpSalaryID = " & CopyIDX & ""
            ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)

            myUtils.MergeDataRow(ds.Tables(0).Rows(0), myRow.Row)
            myRow("EmpSalaryID") = DBNull.Value
            myRow("dated") = DBNull.Value
            myRow("PayProposalID") = If(myUtils.cValTN(Me.vBag("PayProposalID")) > 0, Me.vBag("PayProposalID"), DBNull.Value)
            myUtils.CopyRows(ds.Tables(1).Select, myView.MainGrid.myDS.Tables(0))
        End If

        Dim dic As New clsCollecString(Of String)
        dic.Add("EmployeeID", "select * from hrpListEmp() where employeeid = " & myUtils.cValTN(myRow("EmployeeID")))
        Me.AddDataSet("Emp", dic)

        Dim dic1 As New clsCollecString(Of String)
        dic1.Add("SalRCComp", "select  EmpSalRateCalcID, ComponentName, BenefitName,  Amount, BaseAmount, AmountEE, AmountER  from EmpSalRateCalcComp esrc left join " &
        "SalComponent sc on  esrc.SalComponentID = sc.SalComponentID left join SalBenefit sb on esrc.SalBenefitID = sb.SalBenefitID " &
        "where EmpSalRateCalcID in (select EmpSalRateCalcID from EmpSalRateCalc where EmpSalaryID = " & frmIDX & ") ")
        Me.AddDataSet("SalRCComp", dic1)

        If Me.DatasetCollection("emp").Tables(0).Rows.Count > 0 Then populateCalculatedViews()
        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Private Sub populateCalculatedViews()

        myViewEmpSalRateCalc.MainGrid.MainConf("fixcols") = "5"
        sql = "select EmpSalRateCalcID, Dated, TotalBasic, TotalAllow, TotalPay, TakeHome, Bonus, LeaveNCash, Gratuity, CTC " &
              "from EmpSalRateCalc where EmpSalaryID = " & myUtils.cValTN(frmIDX) & " order by dated desc"
        myViewEmpSalRateCalc.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Dated"" CAPTION=""Date""/><COL KEY=""TotalBasic"" CAPTION=""Basic""/><COL KEY=""TotalAllow"" CAPTION=""Allowance""/>"
        myViewEmpSalRateCalc.MainGrid.QuickConf(sql, True, "1-1-1-1-1-1-1-1-1", True)

        sql = "select  top 1  Dated, TotalBasic, TotalAllow, TotalPay, TakeHome, Bonus, LeaveNCash, Gratuity, CTC " &
              "from EmpSalRateCalc where EmpSalaryID = " & frmIDX & " order by dated desc"
        myViewLastCalculated.MainGrid.MainConf("invertedview") = True
        myViewLastCalculated.MainGrid.MainConf("HIDECOLS") = "LeaveNCash"
        myViewLastCalculated.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Dated"" CAPTION=""Date"" ALIGN=""RIGHT""/><COL KEY=""TotalBasic,TotalAllow,TotalPay,TakeHome,Bonus,LeaveNCash,Gratuity,CTC"" ALIGN=""RIGHT""/>"
        myViewLastCalculated.MainGrid.QuickConf(sql, True, "5-5-5-5-5-5-5-5-5", True)

    End Sub

    Public Overrides Function GenerateDataParamsOutput(dataKey As String, ds As DataSet, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim objEmpSal As New clsEmpSalaryBase(myContext)
        Dim oRet As New clsProcOutput
        Select Case dataKey.Trim.ToLower
            Case "generate"
                Dim EmpSalaryID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@EmpSalaryID", Params))
                Dim SalStructureID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@SalStructureID", Params))
                objEmpSal.GenerateSalComponents(EmpSalaryID, SalStructureID, ds.Tables(0))
                oRet.Data = ds
            Case "backcalcsal"

                Dim RMID, basicper As Integer, tarGross As Double, IgnorePrev As Boolean, dtEmp As DataTable

                RMID = myUtils.cValTN(myContext.SQL.ParamValue("@RMID", Params))
                basicper = myUtils.cValTN(myContext.SQL.ParamValue("@basicper", Params))
                tarGross = myUtils.cValTN(myContext.SQL.ParamValue("@tarGross", Params))
                IgnorePrev = myUtils.cBoolTN(myContext.SQL.ParamValue("@IgnorePrev", Params))

                Dim dtPS As DataTable, lastdiff, cnt, inc As Integer, rRM As DataRow,
                    objPayPeriod As New clsPayPeriodBase(myContext), objESB As New clsEmpSalaryBase(myContext), rCurrCTC As DataRow

                Dim rEmpSal As DataRow = ds.Tables("empsal").Rows(0)
                Dim EmpSalaryID As Integer = myUtils.cValTN(rEmpSal("EmpSalaryID"))
                Dim dic As New clsCollecString(Of String)
                dic.Add("Emp", "select * from hrpListEmp() where employeeid = " & myUtils.cValTN(rEmpSal("employeeid")))
                dic.Add("PS", "Select count(payslipid) as cPaySlip from hrpListPSBasic() where empsalaryid = " & EmpSalaryID & " and isfinal=1")
                dic.Add("SC", "select * from SalComponent ")
                Dim ds2 As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)

                rRM = objPayPeriod.oMasterData.rRateMasterID(RMID)
                If myUtils.cValTN(ds2.Tables("PS")) > 0 Then
                    oRet.Data = ds2
                Else
                    Dim cntAllow As Integer = 0, cntBasic As Integer = 0, rr() As DataRow

                    For Each r As DataRow In ds.Tables(0).Select()
                        rr = ds2.Tables("SC").Select("SalComponentID = " & r("SalComponentID") & "")
                        If rr(0)("CompType") = "A" Then cntAllow = cntAllow + 1
                        If rr(0)("CompType") = "B" AndAlso rr(0)("ComponentCode") <> "VDA" Then cntBasic = cntBasic + 1
                    Next

                    If IgnorePrev = 0 Then

                        sql = "select top 1 empsalaryid from empsalary  where empsalaryid <> " & EmpSalaryID & " " &
                     "and employeeid = (select employeeid from empsalary as es2 where es2.empsalaryid = " & EmpSalaryID & ") order by dated desc"
                        dtPS = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dtPS.Rows.Count > 0 Then
                            If myUtils.cValTN(dtPS.Rows(0)("EmpsalaryID")) > 0 Then
                                For Each r As DataRow In ds.Tables(0).Select()
                                    rr = ds2.Tables("SC").Select("SalComponentID = " & r("SalComponentID") & "")
                                    If (rr(0)("CompType") = "B") AndAlso (rr(0)("ComponentCode") <> "VDA") Then
                                        r("Amount") = (tarGross * ((basicper) / cntBasic / 100))

                                    ElseIf cntAllow = 0 Then
                                        r("Amount") = (tarGross / cntBasic)
                                    Else
                                        r("Amount") = (tarGross * ((100 - basicper) / cntAllow / 100))
                                    End If
                                Next
                            End If
                        End If

                    End If

                    For Each r As DataRow In ds.Tables(0).Select()
                        r("Amount") = DBNull.Value
                    Next


                    dtEmp = ds2.Tables("emp")

                    rCurrCTC = objESB.CalculateEmpSalRate(dtEmp.Rows(0), rEmpSal, ds.Tables(0), rRM)
                    lastdiff = tarGross - rCurrCTC("CTC")
                    If lastdiff <> 0 Then cnt = 1

                    While cnt = 1
                        inc = 10
                        rCurrCTC = objESB.CalculateEmpSalRate(dtEmp.Rows(0), rEmpSal, ds.Tables(0), rRM)
                        If rCurrCTC("CTC") > tarGross Then inc = -10
                        If (lastdiff < 0) AndAlso (inc > 0) Then
                            cnt = 0
                        ElseIf (lastdiff > 0) AndAlso (inc < 0) Then
                            cnt = 0
                        Else
                            For Each r As DataRow In ds.Tables(0).Select()
                                rr = ds2.Tables("SC").Select("SalComponentID = " & r("SalComponentID") & "")
                                If (rr(0)("CompType") = "B") AndAlso (rr(0)("ComponentCode") <> "VDA") AndAlso (cntAllow > 0) Then
                                    r("Amount") = myUtils.cValTN(r("Amount")) + inc / 100 * (basicper / cntBasic)
                                ElseIf (cntAllow = 0) AndAlso (rr(0)("ComponentCode") <> "VDA") Then
                                    r("Amount") = myUtils.cValTN(r("Amount")) + inc
                                Else
                                    r("Amount") = myUtils.cValTN(r("Amount")) + inc / 100 * ((100 - basicper) / cntAllow)
                                End If
                            Next
                        End If
                    End While
                End If
                ds.Tables.Remove("empsal")
                oRet.Data = ds
        End Select

        Return oRet
    End Function

    Public Overrides Function GenerateDataOutput(dataKey As String, ds As DataSet, frmIDX As Integer) As clsProcOutput
        Dim oRet As clsProcOutput = Nothing, objEmpSal As New clsEmpSalaryBase(myContext)
        Select Case dataKey
            Case "checksave"
                Dim rEmpSal As DataRow = ds.Tables("empsal").Rows(0)
                Dim EmpSalaryID As Integer = myUtils.cValTN(rEmpSal("EmpSalaryID"))
                oRet = objEmpSal.CheckSave(rEmpSal, ds.Tables(0))
                oRet.Data = ds
        End Select
        Return oRet
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If (myUtils.NullNot(myRow("PayProposalID"))) AndAlso (myUtils.NullNot(myRow("Dated"))) Then Me.AddError("Dated", "Select Valid Date")

        If myUtils.cValTN(myRow("OTHourRate")) > 0 Then

        Else
            If (myUtils.NullNot(myUtils.cValTN(myRow("OTSalMult")))) AndAlso (myUtils.NullNot(myUtils.cValTN(myRow("OTHourRate")))) Then Me.AddError("OTSalMult", "Must Enter OT Salary Multiple")
        End If

        If myUtils.NullNot(Me.SelectedRow("SalStructureID")) Then Me.AddError("SalStructureID", "Must Select a SalStructure")
        If myUtils.NullNot(Me.SelectedRow("SkillText")) Then Me.AddError("SkillText", "Must Select Skill")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objProc As clsProcOutput = Nothing, objEmpSal As New clsEmpSalaryBase(myContext)

        VSave = False
        If Me.Validate Then
            objProc = objEmpSal.TrySave(myRow.Row, myView.MainGrid.myDS.Tables(0))
            If objProc.Success Then
                frmIDX = myRow("EmpSalaryID")
                frmMode = EnumfrmMode.acEditM
                populateCalculatedViews()
                VSave = True
            Else
                Me.AddError("", objProc.Message)
            End If
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput, compid As Integer, dated As DateTime, objPayPeriod As New clsPayPeriodBase(myContext), rRM As DataRow
        oRet = myContext.SQL.ValidateSQLParams(Params)

        If oRet.Success Then
            Select Case dataKey.Trim.ToLower
                Case "ratemaster"
                    compid = myUtils.cValTN(myContext.SQL.ParamValue("@compid", Params))
                    dated = myContext.SQL.ParamValue("@dated", Params)

                    rRM = objPayPeriod.oMasterData.rRateMaster(compid, dated)
                    oRet.ID = rRM("RateMasterID")
            End Select
        End If
        Return oRet

    End Function

End Class