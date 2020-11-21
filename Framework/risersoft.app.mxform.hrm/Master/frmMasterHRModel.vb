Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmMasterHRModel
    Inherits clsFormDataModel

    Dim myViewSalBenefit, myviewShift, myviewLvePolicy As clsViewModel, objSS As New clsSalStructureBase(myContext),
        objSalBen As New clsSalBenefitBase(myContext), sql As String

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("SalComp")
        myViewSalBenefit = Me.GetViewModel("SalBen")
        myviewShift = Me.GetViewModel("Shift")
        myviewLvePolicy = Me.GetViewModel("LvePolicy")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim vlistb As New clsValueList
        vlistb.Add("F", "Fixed Amount")
        vlistb.Add("V", "VDA")
        Me.ValueLists.Add("Envb", vlistb)
        Me.AddLookupField("behave", "Behave", "envb")

        Dim vlist As New clsValueList
        vlist.Add("A", "Allowance")
        vlist.Add("B", "Basic")
        Me.ValueLists.Add("Envc", vlist)
        Me.AddLookupField("comptype", "Comptype", "envc")

        Dim vlistw As New clsValueList
        vlistw.Add("FM", "Fixed Monthly")
        vlistw.Add("NR", "Normal")
        vlistw.Add("OO", "Out of Office")
        vlistw.Add("ST", "Site")
        Me.ValueLists.Add("Envp", vlistw)
        Me.AddLookupField("type", "Type", "envp")


        Dim vlistp As New clsValueList
        vlistp.Add(True, "Yes")
        vlistp.Add(False, "No")

        Me.ValueLists.Add("Mnvp", vlistp)
        Me.AddLookupField("Machine", "Machine", "Mnvp")

        Dim vliste As New clsValueList
        vliste.Add(True, "Yes")
        vliste.Add(False, "No")

        Me.ValueLists.Add("Mnvh", vliste)
        Me.AddLookupField("Monitor", "Monitor", "Mnvh")
        Dim vlistch As New clsValueList
        vlistch.Add(True, "Yes")
        vlistch.Add(False, "No")

        Me.ValueLists.Add("Pnvc", vlistch)
        Me.AddLookupField("Person", "Person", "Pnvc")


        Dim vlisth As New clsValueList
        vlisth.Add("PL", "PL-% with Limit")
        vlisth.Add("PN", "PN-% with NA")

        Me.ValueLists.Add("Bnvc", vlisth)
        Me.AddLookupField("CBehave", "CBehave", "Bnvc")


        Dim vlisttag As New clsValueList
        vlisttag.Add(1, "Present")
        vlisttag.Add(3, "Leave")

        vlisttag.Add(2, "Absent")
        vlisttag.Add(4, "Substitute Leave")
        Me.ValueLists.Add("Tnvc", vlisttag)
        Me.AddLookupField("TagType", "TagType", "Tnvc")


        Dim vlistyp As New clsValueList
        vlistyp.Add("B", "Beginning")
        vlistyp.Add("E", "Earned")

        vlistyp.Add("P", "Periodic")

        Me.ValueLists.Add("Tnvcp", vlistyp)
        Me.AddLookupField("AccureType", "AccureType", "Tnvcp")


        Dim vlistlp As New clsValueList
        vlistlp.Add("M", "Month")
        vlistlp.Add("Q", "Quater")


        Me.ValueLists.Add("Tnvlp", vlistlp)
        Me.AddLookupField("LeavePeriodType", "LeavePeriodType", "Tnvlp")


        Dim vlistlm As New clsValueList
        vlistlm.Add(True, "Yes")
        vlistlm.Add(False, "No")

        Me.ValueLists.Add("LMnvp", vlistlm)
        Me.AddLookupField("EnLM", "EnLM", "LMnvp")


        Dim vlistf As New clsValueList
        vlistf.Add(True, "Yes")
        vlistf.Add(False, "No")

        Me.ValueLists.Add("FFnvp", vlistf)
        Me.AddLookupField("EnFF", "EnFF", "FFnvp")


        Dim vlistlo As New clsValueList
        vlistlo.Add(True, "Yes")
        vlistlo.Add(False, "No")

        Me.ValueLists.Add("LMnvo", vlistlo)
        Me.AddLookupField("CoutO", "CoutO", "LMnvo")
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim ds As DataSet
        Me.FormPrepared = False
        If frmMode = EnumfrmMode.acAddM Then prepIDX = 0

        ds = GenerateData("ss", 0)
        myView.MainGrid.BindGridData(ds, 0)
        myView.MainGrid.QuickConf("", True, "1-1-1-1-1-1", True, "Salary Components")

        ds = GenerateData("sb", 0)
        myViewSalBenefit.MainGrid.BindGridData(ds, 0)
        myViewSalBenefit.MainGrid.QuickConf("", True, "1-1-1-1-1-1-0", True, "Salary Benefit")

        ds = GenerateData("sh", 0)
        myviewShift.MainGrid.BindGridData(ds, 0)
        myviewShift.MainGrid.QuickConf("", True, "1-1-1-1-1-1-1-1-1-1-1", True, "Shifts")

        ds = GenerateData("lp", 0)
        myviewLvePolicy.MainGrid.BindGridData(ds, 0)
        myviewLvePolicy.MainGrid.QuickConf("", True, "1-1-1-1", True, "Leave Policies")

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        Return Me.CanSave
    End Function

    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Me.ClientParams), dt As DataTable

        Select Case dataKey.Trim.ToLower
        End Select
        Return oRet
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim ID As Integer, dataKey2 As String = ""
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params), dt As DataTable
        If oRet.Success Then
            Select Case dataKey.Trim.ToLower

                Case "ss", "sb", "sh", "lp"
                    oRet.Data = GenerateData(dataKey, 0)
                    dataKey2 = dataKey.Trim.ToLower
            End Select

            If oRet.Success Then
                oRet.Data = GenerateData(dataKey2, 0)
            End If
        End If
        Return oRet
    End Function

    Protected Overrides Function GenerateData(DataKey As String, ID As String) As DataSet
        Dim oRet As New clsProcOutput, sql As String, ds As DataSet
        Select Case DataKey.Trim.ToLower

            Case "ss"
                sql = "Select SalComponentId, sc.SalStructureID, StructureName, ComponentCode, ComponentName, Behave, CompType, AllowType from " &
                   "salcomponent sc inner join SalStructure ss on sc.SalStructureID = ss.SalStructureID "
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds

            Case "sb"
                Dim oView As New clsViewModel(myContext)
                sql = "Select SalBenefitID, sortindex, BenefitCode, BenefitName, Behave, ApplyCompType, AdminAmount1Name, AdminAmount2Name, AdminAmount3Name from SalBenefit"
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds

            Case "sh"
                sql = "Select ShiftID, Shift, STime, ETime, WHours, BHours, LunchOut, LunchIn, ETimeAct, ForMachine, ForPersons, MonitorAbsent from Shift "
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds

            Case "lp"
                sql = "Select LeavePolicyID, PolicyName, Dated, TagVList, Remark from LeavePolicy "
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds
        End Select
        Return oRet.Data
    End Function

End Class
