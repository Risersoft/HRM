Imports Infragistics.Win
Imports uwg = Infragistics.Win.UltraWinGrid
Imports ug = Infragistics.Win.UltraWinGrid

Public Class frmInterviewFBUser
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridFBSkill)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmInterviewFBUserModel = Me.InitData("frmInterviewFBUserModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            Dim dt1 As DataTable = Me.Model.DatasetCollection("Set").Tables("InterviewFB")
            If dt1.Rows.Count > 0 Then
                Me.txt_InterviewerName.Text = myUtils.cStrTN(dt1.Rows(0)("InterviewerName"))
            End If

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Skill"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
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

End Class
