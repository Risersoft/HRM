Imports risersoft.app.shared
Imports risersoft.app.mxent

Public Class frmJobApplication
    Inherits frmMax
    Friend fMat As frmCandidatePerson

    Private Sub InitForm()
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        myWinSQL.AssignCmb(fMat.dsCombo, "Person", "", Me.cmb_PersonID)
        myWinSQL.AssignCmb(fMat.dsCombo, "Vacancy", "", Me.cmb_VacancyID)
        myWinSQL.AssignCmb(fMat.dsCombo, "HRAgency", "", Me.cmb_HRAgencyID)
        If Me.GetSoftData(oView, prepMode, prepIDX) Then
            PrepForm = True
        End If
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnCancel.Click

        Me.InitError()
        If myUtils.NullNot(Me.cmb_VacancyID.Value) Then WinFormUtils.AddError(Me.cmb_VacancyID, "Select a Vacancy Type")
        If Me.CanSave Then
            cm.EndCurrentEdit()
        End If

        Me.SaveSoftData()

    End Sub

End Class
