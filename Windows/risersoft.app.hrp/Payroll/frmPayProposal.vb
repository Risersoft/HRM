Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports risersoft.shared.Extensions

Public Class frmPayProposal
    Inherits frmMax

    Private Sub InitForm()
        myView.SetGrid(UltraGridEmpSal)
        WinFormUtils.SetButtonConf(btnOK, btnCancel, btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmPayProposalModel = Me.InitData("frmPayProposalModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "PayPeriod", "", Me.cmb_RefPPID)
            myWinSQL.AssignCmb(Me.dsCombo, "RateMaster", "", Me.cmb_PropRMID)
            myWinSQL.AssignCmb(Me.dsCombo, "Company", "", Me.cmb_CompanyID)
            Me.cmb_OnlyRM.ValueList = Me.Model.ValueLists("OnlyRM").ComboList
            Me.cmb_UpdateLastPP.ValueList = Me.Model.ValueLists("UpdateLastPP").ComboList

            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("EmpSal"))
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

    Private Sub cmb_OnlyRM_Leave(sender As Object, e As EventArgs) Handles cmb_OnlyRM.Leave

        If cmb_OnlyRM.Value = False Then
            cmb_PropRMID.ReadOnly = True
        Else
            cmb_PropRMID.ReadOnly = False
        End If
    End Sub

End Class
