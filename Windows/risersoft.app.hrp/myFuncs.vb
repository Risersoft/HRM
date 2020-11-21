Imports System.Windows.Forms

Public Class myFuncs
    Public DoRefresh As Boolean = False
    Public Sub fncReinsEmp(oView As clsView, frmIDX As String)
        Dim context As IProviderContext = oView.mvwContext
        Dim oRet As clsProcOutput = context.Provider.GenerateIDOutput(context.GetAppInfo, "frmEmpModel", "", "reinstate", frmIDX).Result
        If oRet.Success Then
            Me.DoRefresh = True
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, context.Vars("appname"))

        End If

    End Sub

    Public Sub fncFinalPP(oView As clsView, frmIDX As String)
        Dim context As IProviderContext = oView.mvwContext
        Dim oRet As clsProcOutput = context.Provider.GenerateIDOutput(context.GetAppInfo, "frmPayPeriodModel", "", "finalize", frmIDX).Result
        If oRet.Success Then
            Me.DoRefresh = True
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, context.Vars("appname"))

        End If

    End Sub
    Public Sub fncFinalPPWOT(oView As clsView, frmIDX As String)

        Dim context As IProviderContext = oView.mvwContext
        Dim oRet As clsProcOutput = context.Provider.GenerateIDOutput(context.GetAppInfo, "frmPayPeriodModel", "", "finalwot", frmIDX).Result
        If oRet.Success Then
            Me.DoRefresh = True
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, context.Vars("appname"))
        End If

    End Sub
    Public Sub fncEnforcePayProp(oView As clsView, frmIDX As String)

        Dim context As IProviderContext = oView.mvwContext
        Dim oRet As clsProcOutput = context.Provider.GenerateIDOutput(context.GetAppInfo, "frmPayProposalModel", "", "enforcepp", frmIDX).Result
        If oRet.Success Then
            Dim f As New frmGrid
            f.myView.mainGrid.DataSource = oRet.Data
            f.myView.mainGrid.QuickConf("", True, "1-3", True)
            f.Text = "Select Pay Period"
            If f.ShowDialog = DialogResult.OK Then
                Dim Params As New List(Of clsSQLParam)
                Params.Add(New clsSQLParam("@payproposalid", frmIDX, GetType(Integer), False))
                Params.Add(New clsSQLParam("@payperiodid", myUtils.cValTN(f.myView.mainGrid.myGrid.ActiveRow.Cells("payperiodid").Value), GetType(Integer), False))
                Dim oRet2 As clsProcOutput = context.Provider.GenerateParamsOutput(context.GetAppInfo, "frmPayProposalModel", "", "enforce", Params).Result
                MsgBox(oRet2.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
            Else
                MsgBox("No Selection", MsgBoxStyle.Information, myWinApp.Vars("appname"))
            End If

            Me.DoRefresh = True
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, context.Vars("appname"))
        End If

    End Sub


End Class
