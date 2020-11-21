Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform

Public Class frmPayProjection
    Inherits frmMax

    Dim myViewProp As New clsWinView, f1 As New frmPayProposal, objProc As clsProcOutput
    Private Sub InitForm()
        myViewProp.SetGrid(Me.UltraGridProposal)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmPayProjectionModel = Me.InitData("frmPayProjectionModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            myWinSQL.AssignCmb(Me.dsCombo, "Company", "", Me.cmb_CompanyID)
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("ListEmp"))
            myViewProp.PrepEdit(Me.Model.GridViews("PayProp"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        Dim strXML As String, Params As New List(Of clsSQLParam)
        Me.InitError()
        If myUtils.NullNot(myRow("PAYPROJECTIONID")) Then WinFormUtils.AddError(Me.dt_startdate, "Must Add PayProjection First")

        If Me.CanSave() Then
            VSave()
            strXML = "<PARAMS PAYPROJECTIONID=""" & frmIDX & """ COMPANYID=""" & myUtils.cValTN(myRow("CompanyID")) & """/>"

            If myUtils.cValTN(myRow("CompanyID")) > 0 Then
                f1.PrepForm(Me.myView, EnumfrmMode.acAddM, "", strXML)
                f1.ShowDialog()
                refresh()
            Else
                If myUtils.NullNot(Me.cmb_CompanyID.Value) Then WinFormUtils.AddError(Me.cmb_CompanyID, "Must Select Comany")
            End If
        End If
    End Sub

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        Dim Params As New List(Of clsSQLParam)
        If myViewProp.mainGrid.myDS.Tables(0).Rows.Count > 0 Then
            f1.PrepForm(Me.myViewProp, EnumfrmMode.acEditM, myUtils.cValTN(myWinUtils.DataRowFromGridRow(myViewProp.mainGrid.ActiveRow.Row)("PayProposalID")))
            f1.ShowDialog()
            refresh()
        End If

    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        Dim Params As New List(Of clsSQLParam)

        If myViewProp.mainGrid.myDS.Tables(0).Rows.Count > 0 Then
            objProc = Me.GenerateIDOutput("PayProp", myUtils.cValTN(myViewProp.mainGrid.myGrid.ActiveRow.Cells("PayProposalID").Value))
            If objProc.Success Then
                If MsgBox("Are You Sure You Want To Delete This PayProposal", MsgBoxStyle.YesNo, myWinApp.Vars("appname")) = MsgBoxResult.No Then Exit Sub
                Params.Add(New clsSQLParam("@PayPropID", myUtils.cValTN(myViewProp.mainGrid.myGrid.ActiveRow.Cells("PayProposalID").Value), GetType(Integer), False))
                Params.Add(New clsSQLParam("@PayProjID", myUtils.cValTN(myViewProp.mainGrid.myGrid.ActiveRow.Cells("PayProjectionID").Value), GetType(Integer), False))
                objProc = Me.GenerateParamsOutput("PayProp", Params)
            Else
                MsgBox(objProc.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
            End If
            refresh()
        End If

    End Sub

    Private Sub btn_Enforce_Click(sender As Object, e As EventArgs) Handles btn_Enforce.Click
        Dim f As New frmGrid, ppID As Integer, Params As New List(Of clsSQLParam)

        myViewProp.ContextRow = myViewProp.mainGrid.ActiveRow
        If Not myViewProp.ContextRow Is Nothing Then
            Params.Add(New clsSQLParam("@dated", Format(myViewProp.ContextRow.CellValue("SDate"), "yyyy-MMM-dd"), GetType(DateTime), False))
            Dim Model As clsViewModel = Me.GenerateParamsModel("pp", Params)
            f.myView.PrepEdit(Model)
            f.Text = "Select Pay Period"

            If f.ShowDialog = DialogResult.OK Then
                ppID = myUtils.cValTN(f.myView.mainGrid.myGrid.ActiveRow.Cells("payperiodid").Value)
                Params.Add(New clsSQLParam("@PayPropID", myUtils.cValTN(myViewProp.ContextRow.CellValue("PayProposalID")), GetType(Integer), False))
                Params.Add(New clsSQLParam("@PPID", ppID, GetType(Integer), False))
                objProc = Me.GenerateParamsOutput("PayPropEn", Params)
                If objProc.Success = False Then
                    MsgBox(objProc.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If
            End If
            refresh()
        End If
    End Sub

    Private Sub btn_UnEnforce_Click(sender As Object, e As EventArgs) Handles btn_UnEnforce.Click
        Dim Params As New List(Of clsSQLParam)

        Params.Add(New clsSQLParam("@PayPropID", myUtils.cValTN(myViewProp.mainGrid.ActiveRow.CellValue("PayProposalID")), GetType(Integer), False))
        objProc = Me.GenerateParamsOutput("PayPropUnEn", Params)
        If objProc.Success = False Then MsgBox(objProc.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        refresh()

    End Sub

    Private Sub refresh()
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@PayProjID", myUtils.cValTN(myViewProp.mainGrid.myGrid.ActiveRow.Cells("PayProjectionID").Value), GetType(Integer), False))
        objProc = Me.GenerateParamsOutput("refresh", Params)
        If objProc.Success Then
            Me.UpdateViewData(myViewProp, objProc)
        Else
            MsgBox(objProc.Message, MsgBoxStyle.YesNo, myWinApp.Vars("appname"))
        End If
    End Sub
End Class
