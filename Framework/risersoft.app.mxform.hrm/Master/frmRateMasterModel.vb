Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmRateMasterModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("SalBenRate")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String

        sql = myFuncsBase.CodeWordSQL("calendar", "weekday", "")
        Me.AddLookupField("WeekStart", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "CalWeek").TableName)
        Me.AddLookupField("WeeklyOff1", "CalWeek")
        Me.AddLookupField("Weeklyoff2", "CalWeek")

        Dim vlist As New clsValueList
        vlist.Add(True, "Yes")
        vlist.Add(False, "No")
        Me.ValueLists.Add("InclHDaysForAbDays", vlist)
        Me.AddLookupField("InclHDaysForAbDays", "InclHDaysForAbDays")

        Dim vlist1 As New clsValueList
        vlist1.Add(False, "Constant Basic")
        vlist1.Add(True, "Actual Basic")
        Me.ValueLists.Add("VDAOnActualBasic", vlist1)
        Me.AddLookupField("VDAOnActualBasic", "VDAOnActualBasic")

        sql = myFuncsBase.CodeWordSQL("sal", "WeekOffType", "")
        Me.AddLookupField("WeeklyOff2Type", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "WeekOffType").TableName)

        sql = "select companyid, compname from company order by compname"
        Me.AddLookupField("companyid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Company").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, sql1, str1 As String, dtRtMstr As DataTable

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0

        sql = "select * from RateMaster where RateMasterID = " & prepIDX
        Me.InitData(sql, "companyid", oView, prepMode, prepIDX, strXML, "Ratemasterid")

        sql = "select SalBenefitRateId, SalBenefitid, RateMasterid, BenefitCode, BenefitName, peree, perer1, perer2, limit, perAdminAmount1, " &
            "perAdminAmount2, perAdminAmount3, RoundingType from hrpListSalBenefitRate() where companyid = " & myUtils.cValTN(myRow.Row("CompanyID")) & ""
        sql1 = sql & " And ratemasterid = " & frmIDX & ""
        myView.MainGrid.MainConf("fixcols") = "4"
        myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""peree"" CAPTION=""Employee Share""/><COL KEY=""perer1"" CAPTION=""% Employer Share1""/><COL KEY=""perer2"" CAPTION=""% Employer Share2""/><COL KEY=""limit"" CAPTION=""Maximum Limit""/><COL KEY=""perAdminAmount1"" CAPTION=""% Admin Amount1""/><COL KEY=""perAdminAmount2"" CAPTION=""% Admin Amount2""/><COL KEY=""perAdminAmount3"" CAPTION=""% Admin Amount3""/><COL KEY=""RoundingType"" CAPTION=""Rounding""/>"
        myView.MainGrid.QuickConf(sql1, True, "3-3-3-4-4-3-4-4-4-3", True)
        str1 = "<BAND INDEX = ""0"" TABLE = ""SalBenefitRate"" IDFIELD=""SalBenefitRateID""><COL KEY ="" RateMasterID, SalBenefitID, BenefitCode, BenefitName, perEE, perER1, perER2, Limit, perAdminAmount1, perAdminAmount2, perAdminAmount3""/><COL KEY=""RoundingType"" CAPTION=""Rounding"" VLIST=""PP;PayPeriod|PS;Payslip""/></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        If CopyIDX > 0 Then
            sql1 = sql & " And ratemasterid = " & CopyIDX & ""
            dtRtMstr = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql1).Tables(0)
            myUtils.CopyRows(dtRtMstr.Select, myView.MainGrid.myDS.Tables(0))
        End If

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.NullNot(myRow("Dated")) Then Me.AddError("Dated", "Select Valid Date")
        If Me.SelectedRow("WeeklyOff1") Is Nothing Then Me.AddError("WeeklyOff1", "Select Weekly Off1")
        If Me.SelectedRow("WeekStart") Is Nothing Then Me.AddError("WeekStart", "Select Week Start")
        If myUtils.cStrTN(myRow("VDASkill")).Trim.Length = 0 Then Me.AddError("VDASkill", "Enter VDA Skill")
        If myUtils.cStrTN(myRow("VDAUnSkill")).Trim.Length = 0 Then Me.AddError("VDAUnSkill", "Enter VDA UnSkill")
        If myUtils.cStrTN(myRow("VDASemi")).Trim.Length = 0 Then Me.AddError("VDASemi", "Enter VDA Semi")
        If myUtils.cStrTN(myRow("VDABaseIndex")).Trim.Length = 0 Then Me.AddError("VDABaseIndex", "Enter VDA Base Index")
        If myUtils.cStrTN(myRow("VDACurrentIndex")).Trim.Length = 0 Then Me.AddError("VDACurrentIndex", "Enter VDA Current Index")
        If myUtils.cStrTN(myRow("MonthWorkDays")).Trim.Length = 0 Then Me.AddError("MonthWorkDays", "Enter Working Days")
        If myUtils.cStrTN(myRow("MinWorkDays")).Trim.Length = 0 Then Me.AddError("MinWorkDays", "Enter Minimum Working Days")
        Return Me.CanSave
    End Function

    Public Overrides Function GenerateDataOutput(dataKey As String, ds As DataSet, frmIDX As Integer) As clsProcOutput
        Dim oRet As clsProcOutput = Nothing, oProc As New clsRateMasterBase(myContext)
        Dim rRM As DataRow = ds.Tables("RateMaster").Rows(0)
        Dim RateMasterID As Integer = myUtils.cValTN(rRM("RateMasterID"))
        Select Case dataKey
            Case "checksave"
                oRet = oProc.CheckSave(rRM, ds.Tables(0))
            Case "generate"
                oRet = oProc.GenerateSalBenefitRate(rRM, ds.Tables(0))
                oRet.Data = ds
        End Select
        Return oRet
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objProc As clsProcOutput, objRateMaster As New clsRateMasterBase(myContext)
        VSave = False

        If Me.Validate Then
            objProc = objRateMaster.TrySave(myRow.Row, myView.MainGrid.myDS.Tables(0))
            If objProc.Success Then
                frmIDX = myRow("RateMasterID")
                frmMode = EnumfrmMode.acEditM
                VSave = True
            Else
                Me.AddError("", objProc.Message)
            End If
        End If

        Return VSave
    End Function

End Class
