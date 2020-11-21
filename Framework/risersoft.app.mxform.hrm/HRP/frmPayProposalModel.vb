Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmPayProposalModel
    Inherits clsFormDataModel
    Dim objPayProp As New clsPayProposalBase(myContext), sql As String
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("EmpSal")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        sql = "select PayPeriodID, PayPeriodName from PayPeriod where SalCalcOn is not null order by SDate desc"
        Me.AddLookupField("RefPPID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "PayPeriod").TableName)

        sql = "select RateMasterID, Descrip from hrpListRateMaster()"
        Me.AddLookupField("PropRMID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "RateMaster").TableName)

        sql = "select CompanyID, CompName from Company"
        Me.AddLookupField("CompanyID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Company").TableName)

        Dim vlist As New clsValueList
        vlist.Add(True, "RateMaster")
        vlist.Add(False, "Salary")
        Me.ValueLists.Add("OnlyRM", vlist)
        Me.AddLookupField("OnlyRM", "OnlyRM")

        Dim vlst As New clsValueList
        vlst.Add(True, "Update")
        vlst.Add(False, "Don't Update")
        Me.ValueLists.Add("UpdateLastPP", vlst)
        Me.AddLookupField("UpdateLastPP", "UpdateLastPP")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "select * from payproposal where payproposalid = " & prepIDX
        Me.InitData(sql, "payproposalid,payprojectionid,companyid", oView, prepMode, prepIDX, strXML)

        sql = "select EmpCode, FullName, Dated, SkillText from empsalary inner join hrplistemp() hle on " &
              "empsalary.employeeid = hle.employeeid where payproposalid = " & myUtils.cValTN(prepIDX)
        myView.MainGrid.QuickConf(sql, True, "1-1-1-1", True)

        Me.FormPrepared = True
        Return Me.FormPrepared

    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.NullNot(myRow("PropDate")) Then Me.AddError("PropDate", "Select Valid Date")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objProc, objProc1 As clsProcOutput
        VSave = False

        If Me.Validate Then
            objProc1 = objPayProp.CheckSave(myRow.Row)
            If objProc1.Success Then
                objProc = objPayProp.TrySave(myRow.Row)
                If objProc.Success Then
                    frmIDX = myRow("payproposalid")
                    frmMode = EnumfrmMode.acEditM
                    VSave = True
                Else
                    Me.AddError("", objProc.Message)
                End If
            Else
                Me.AddError("", objProc1.Message)
            End If
        End If

        Return VSave
    End Function
    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Select Case dataKey.Trim.ToLower
                Case "enforce"
                    Dim PayProposalID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@payproposalid", Params))
                    Dim PayPeriodID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@payperiodid", Params))
                    Dim oProc As New clsPayProposalBase(myContext)
                    oRet = oProc.Enforce(PayProposalID, PayPeriodID)
            End Select
        End If
        Return oRet
    End Function
    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput
        Select Case dataKey.Trim.ToLower
            Case "enforcepp"
                Dim sqlProp = "select * from payproposal where payproposalid =" & ID
                Dim dt1 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sqlProp).Tables(0)
                If dt1.Rows.Count = 1 Then
                    If myUtils.NullNot(dt1.Rows(0)("smeffdate")) AndAlso myUtils.NullNot(dt1.Rows(0)("enforceon")) Then
                        sql = "select payperiodid, isfinal, salcalcon, sdate, dbo.fnccalcstrdate(sdate,edate) as Descrip from payperiod where isnull(isfinal,0)=0 order by sdate"
                        oRet.Data = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                    Else
                        oRet.AddError("Already enforced")
                    End If
                Else
                    oRet.AddError("Not found")
                End If

        End Select
        Return oRet
    End Function
End Class
