Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmCompanyHRModel
    Inherits clsFormDataModel

    Dim myViewRates, myViewBonus, myViewLeave As clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Ben")
        myViewRates = Me.GetViewModel("Rate")
        myViewBonus = Me.GetViewModel("Bonus")
        myViewLeave = Me.GetViewModel("Leave")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String

        sql = "select shiftid, Shift  from Shift "
        Me.AddLookupField("shiftid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "shift").TableName)

        sql = "select LeavePolicyID, PolicyName  from LeavePolicy "
        Me.AddLookupField("LeavePolicyID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "lvepolicy").TableName)

        Dim vlistb As New clsValueList
        vlistb.Add("MO", "MO-Monday")
        vlistb.Add("TU", "TU-Tuesday")
        vlistb.Add("WE", "WE-Wednesday")
        vlistb.Add("TH", "TH-Thursday")
        vlistb.Add("FR", "FR-Friday")
        vlistb.Add("SA", "SA-Saturday")
        vlistb.Add("SU", "SU-Sunday")


        Me.ValueLists.Add("Envb", vlistb)
        Me.AddLookupField("WeekStart", "WeekStart", "envb")



        Dim vliste As New clsValueList
        vliste.Add("MO", "MO-Monday")
        vliste.Add("TU", "TU-Tuesday")
        vliste.Add("WE", "WE-Wednesday")
        vliste.Add("TH", "TH-Thursday")
        vliste.Add("FR", "FR-Friday")
        vliste.Add("SA", "SA-Saturday")
        vliste.Add("SU", "SU-Sunday")


        Me.ValueLists.Add("Envw", vliste)
        Me.AddLookupField("WeekEnd", "WeekEnd", "envw")

        Dim vlisto As New clsValueList
        vlisto.Add("MO", "MO-Monday")
        vlisto.Add("TU", "TU-Tuesday")
        vlisto.Add("WE", "WE-Wednesday")
        vlisto.Add("TH", "TH-Thursday")
        vlisto.Add("FR", "FR-Friday")
        vlisto.Add("SA", "SA-Saturday")
        vlisto.Add("SU", "SU-Sunday")


        Me.ValueLists.Add("Envo", vlisto)
        Me.AddLookupField("WeekEndOff", "WeekEndOff", "envo")

        Dim vlistbp As New clsValueList
        vlistbp.Add("AE", "Alternate Even")
        vlistbp.Add("AO", "Alternate Odd")
        vlistbp.Add("F", "All Days")



        Me.ValueLists.Add("Envwo", vlistbp)
        Me.AddLookupField("WeekStartn", "WeekStartn", "envwo")




        Dim vlistp As New clsValueList
        vlistp.Add(True, "Yes")
        vlistp.Add(False, "No")

        Me.ValueLists.Add("Mnvp", vlistp)
        Me.AddLookupField("Absents", "Absents", "Mnvp")



        Dim vlistc As New clsValueList
        vlistc.Add(True, "Constant Basic")
        vlistc.Add(False, "Actual Basic")

        Me.ValueLists.Add("Mnvcal", vlistc)
        Me.AddLookupField("VDACal", "VDACal", "Mnvcal")





        Dim vlistoc As New clsValueList
        vlistoc.Add(True, "X-Ex-Gratia")
        vlistoc.Add(False, "Z-Zero")

        Me.ValueLists.Add("Mnvcalo", vlistoc)
        Me.AddLookupField("CutOff", "CutOff", "Mnvcalo")
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, sql1 As String, ds As DataSet

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            sql = "select * from Company Where CompanyID = " & prepIDX
            Me.InitData(sql, " ", oView, prepMode, prepIDX, strXML)
            myViewRates.MainGrid.MainConf("fixcols") = "5"

            ds = GenerateData("ratemaster", frmIDX)
            sql1 = "select CodeWord, DescripShort from CodeWords where CodeClass = 'calendar' and CodeType = 'weekday'"
            myViewRates.MainGrid.MainConf("FORMATXML") = "<COL KEY=""VDASkill"" CAPTION=""Skill"" GROUP=""VDA""/><COL KEY=""VDASemi"" CAPTION=""SemiSkill"" GROUP=""VDA""/><COL KEY=""VDAUnSkill"" CAPTION=""UnSkill"" GROUP=""VDA""/><COL KEY=""VDABaseIndex"" CAPTION=""BaseIndex"" GROUP=""VDA""/><COL KEY=""VDACurrentIndex"" CAPTION=""CurrentIndex"" GROUP=""VDA""/><COL KEY=""Dated"" CAPTION=""Date""/><COL KEY=""Compname"" CAPTION=""Company""/><COL KEY=""WeekStart"" CAPTION=""Week Start From"" LOOKUPSQL = """ & sql1 & """ Group = ""Week""/><COL KEY=""Weeklyoff1"" CAPTION=""First Week Off"" LOOKUPSQL = """ & sql1 & """ Group = ""Week""/><COL KEY=""Weeklyoff2"" CAPTION=""Second Week Off"" LOOKUPSQL = """ & sql1 & """ Group = ""Week""/><COL KEY=""Weeklyoff2Type"" CAPTION=""Second Week Off Type"" Group = ""Week""/>"
            myViewRates.MainGrid.BindGridData(ds, 0)
            myViewRates.MainGrid.QuickConf("", True, "1-1-1.5-1.5-1.5-1.5-1-1-1.5-1.5", True, "Rate Master")

            ds = GenerateData("bonus", frmIDX)
            myViewBonus.MainGrid.MainConf("fixcols") = "5"
            myViewBonus.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Descrip"" CAPTION=""BonusPeriod""/><COL KEY=""sDate"" CAPTION=""Start Date""/><COL KEY=""eDate"" CAPTION=""End Date""/><COL KEY=""BonusCalcOn"" CAPTION=""Calculated On""/><COL KEY=""BonusPaidOn"" CAPTION=""Paid On""/><COL KEY=""BonusCutOff"" CAPTION=""Cut Off""/><COL KEY=""BonusPer"" CAPTION=""Percentage""/><COL KEY=""BonusPerCas"" CAPTION=""BonusPerCas""/><COL KEY=""BonusMinDays"" CAPTION=""Minimum Days""/><COL KEY=""BonusLimit"" CAPTION=""Limit""/>"
            myViewBonus.MainGrid.BindGridData(ds, 0)
            myViewBonus.MainGrid.QuickConf("", True, "1-1-1-1-1-1-1-1-1-1", True, "Bonus Master")

            ds = GenerateData("leave", frmIDX)
            myViewLeave.MainGrid.MainConf("fixcols") = "5"
            myViewLeave.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Descrip"" CAPTION=""LeavePeriod""/><COL KEY=""sDate"" CAPTION=""Start Date""/><COL KEY=""eDate"" CAPTION=""End Date""/><COL KEY=""LeaveCalcOn"" CAPTION=""Leave Calculated On""/>"
            myViewLeave.MainGrid.BindGridData(ds, 0)
            myViewLeave.MainGrid.QuickConf("", True, "1-1-1-1", True, "Leave Master")

            ds = GenerateData("salbenefitcomp", frmIDX)
            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""BenefitCode"" CAPTION=""Code""/><COL KEY=""BenefitName"" CAPTION=""Name""/><COL KEY=""CompCode"" CAPTION=""Company Code""/><COL KEY=""StartDate"" CAPTION=""Start Date""/><COL KEY=""EndDate"" CAPTION=""End Date""/>"
            myView.MainGrid.BindGridData(ds, 0)
            myView.MainGrid.QuickConf("", True, "1-1-1-1-1-1", True, "Salary Benefits")

            Dim dic As New clsCollecString(Of String)
            dic.Add("BM", "select BonusMasterID from BonusMaster where companyid = " & frmIDX)
            dic.Add("LM", "select LeaveMasterID from LeaveMaster where companyid = " & frmIDX)
            Me.AddDataSet("Master", dic)

            Dim oRet As clsProcOutput = myHRFuncs.CanSavePolicy(myContext, myUtils.cValTN(myRow("LeavePolicyID")))
            If oRet.Success Then
                Me.ModelParams.Add(New clsSQLParam("@LeavePolicyID", myUtils.cValTN(myRow("LeavePolicyID")), GetType(Integer), False))
            End If

            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.NullNot(myRow("HRStartDate")) Then Me.AddError("HRStartDate", "Select HR Start Date")
        If myUtils.NullNot(myRow("AdvanceDay")) Then Me.AddError("AdvanceDay", "Enter Day For Advance")
        If myUtils.NullNot(myRow("AdvanceRequestDays")) Then Me.AddError("AdvanceRequestDays", "Enter Request Days For Advance")
        If myUtils.NullNot(myRow("LeaveStartMonth")) Then Me.AddError("LeaveStartMonth", "Enter Leave Start Month")
        If myUtils.NullNot(myRow("BonusStartMonth")) Then Me.AddError("BonusStartMonth", "Enter Bonus Start Month")

        Return Me.CanSave
    End Function

    ' CheckDelete need to ask for confirmation from user, before deletion.

    Public Overrides Function GenerateIDOutput(dataKey As String, frmIDX As Integer) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Me.ClientParams), dt As DataTable
        Dim rRM As DataRow, objPayPeriod As New clsPayPeriodBase(myContext), objProc As clsProcOutput = Nothing
        Dim objRMstr As New clsRateMasterBase(myContext), objSalBenComp As New clsSalBenefitCompBase(myContext)
        Select Case dataKey.Trim.ToLower
            Case "deleterm"
                rRM = objPayPeriod.oMasterData.rRateMasterID(frmIDX)
                objProc = objRMstr.CheckDelete(rRM)
            Case "deletesalbencomp"
                Dim sql As String = " select * from SalBenefitComp where SalBenefitCompID = " & frmIDX & ""
                dt = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                objProc = objSalBenComp.CheckDelete(dt.Rows(0))
        End Select
        Return objProc
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            If Not (myUtils.NullNot(myRow("AdvanceDay"))) Then
                If (myUtils.cValTN(myRow("AdvanceDay")) < 1) AndAlso (myUtils.cValTN(myRow("AdvanceDay")) > 25) Then
                    Me.AddError("AdvanceDay", "Must Enter the Valid Day For Advance")
                End If
            End If

            If Not (myUtils.NullNot(myRow("HRStartDate"))) Then
                If Convert.ToDateTime(myRow("HRStartDate")).Date.Day <> 1 Then
                    Me.AddError("HRStartDate", "Must Select date as starting day of the month")
                End If
            End If

            If Me.CanSave Then
                Dim CompanyHRDescrip As String = " HR Configuration for: " & myUtils.cStrTN(myRow("CompName"))
                Try
                    myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "CompanyID", frmIDX)
                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                    frmIDX = myRow("CompanyID")

                    frmMode = EnumfrmMode.acEditM
                    myContext.Provider.dbConn.CommitTransaction(CompanyHRDescrip, frmIDX)
                    VSave = True
                Catch ex As Exception
                    myContext.Provider.dbConn.RollBackTransaction(CompanyHRDescrip, ex.Message)
                    Me.AddError("", ex.Message)
                End Try
            End If
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params), dt As DataTable
        Dim rRM As DataRow, objPayPeriod As New clsPayPeriodBase(myContext), objProc As clsProcOutput = Nothing
        Dim objRMstr As New clsRateMasterBase(myContext), objSalBenComp As New clsSalBenefitCompBase(myContext)
        If oRet.Success Then
            Dim CompID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@CompanyID", Params))
            Dim EntityID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@EntityID", Params))
            Select Case dataKey.Trim.ToLower
                Case "deleterm"
                    rRM = objPayPeriod.oMasterData.rRateMasterID(EntityID)
                    objProc = objRMstr.TryDelete(rRM)
                    If objProc.Success = False Then
                        oRet.AddError(objProc.Message)
                    Else
                        oRet.Data = GenerateData("ratemaster", CompID)
                    End If

                Case "deletesalbencomp"
                    Dim salBenCompID = myUtils.cValTN(myContext.SQL.ParamValue("@EntityID", Params))
                    Dim sql As String = "select * from SalBenefitComp where SalBenefitCompID = " & salBenCompID
                    dt = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                    objProc = objSalBenComp.TryDelete(dt.Rows(0))
                    If objProc.Success = False Then
                        oRet.AddError(objProc.Message)
                    Else
                        oRet.Data = GenerateData("salbenefitcomp", CompID)
                    End If
                Case "refreshrm"
                    oRet.Data = GenerateData("ratemaster", CompID)
                Case "refreshsalbencomp"
                    oRet.Data = GenerateData("salbenefitcomp", CompID)
                Case "bonus", "leave"
                    oRet.Data = GenerateData(dataKey, CompID)
            End Select
        End If
        Return oRet
    End Function

    Protected Overrides Function GenerateData(DataKey As String, ID As String) As DataSet
        Dim oRet As New clsProcOutput, sql As String, ds As DataSet
        Select Case DataKey.Trim.ToLower
            Case "ratemaster"
                Dim oView As New clsViewModel(myContext)
                sql = "select RateMasterID, CompanyID, Dated, WeekStart, Weeklyoff1, Weeklyoff2, Weeklyoff2Type, VDASkill, VDASemi, VDAUnSkill, VDABaseIndex," &
                      "VDACurrentIndex from hrpListRateMaster()  where CompanyID = " & ID
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds

            Case "salbenefitcomp"
                Dim oView As New clsViewModel(myContext)
                sql = "select sb.SalBenefitID, CompanyID, SalBenefitCompID,  BenefitCode, BenefitName, CompCode, StartDate, EndDate, ReturnMonths from SalBenefit " &
                      "sb inner join SalBenefitComp sbc on sb.SalBenefitID= sbc.SalBenefitID where CompanyID = " & ID
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds

            Case "bonus"
                sql = "select BonusMasterID, CompanyID,  Finyearid, Descrip, sDate, eDate , BonusCalcOn, BonusPaidOn, BonusCutOff, " &
                  "BonusPer, BonusPerCas, BonusMinDays, BonusLimit from BonusMaster  where CompanyID = " & ID
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds

            Case "leave"
                sql = "Select LeaveMasterID, CompanyID, Descrip, sDate, eDate, LeaveCalcOn from LeaveMaster where CompanyID = " & ID
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds
        End Select
        Return oRet.Data
    End Function

End Class
