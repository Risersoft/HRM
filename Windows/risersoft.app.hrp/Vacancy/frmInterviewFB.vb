Imports risersoft.app.mxform
Imports ug = Infragistics.Win.UltraWinGrid

Public Class frmInterviewFB
    Inherits frmMax

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridUser)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmInterviewFBModel = Me.InitData("frmInterviewFBModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            Me.txt_InterViewType.Text = myUtils.cStrTN(myRow("InterviewType"))
            Me.dt_Dated.Value = myUtils.cStrTN(myRow("Dated"))
            Me.cmb_JobApplication.Value = myUtils.cStrTN(myRow("FullName")) + " - " + myUtils.cStrTN(myRow("Dated"))
            Me.txt_Remark.Text = myUtils.cStrTN(myRow("Remark"))
            Me.txt_Result.Text = myUtils.cStrTN(myRow("Result"))


        End If
        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Users"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        cm.EndCurrentEdit()
        If Me.ValidateData() Then
            If Me.CanSave() Then
                If Me.SaveModel() Then
                    Return True
                End If
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btnEditUser_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click
        Dim f As New frmInterviewFBUser
        myView.ContextRow = myView.mainGrid.ActiveRow

        f.PrepForm(Me.myView, EnumfrmMode.acEditM, myUtils.cValTN(myWinUtils.DataRowFromGridRow(myView.mainGrid.ActiveRow.Row)("InterviewID")))
        f.ShowDialog()

    End Sub

End Class