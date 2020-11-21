Imports risersoft.app.mxform
Imports risersoft.shared.Extensions

Public Class frmEmpPA
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub
    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim dt As DataTable
        Me.FormPrepared = False
        Dim objModel As frmEmpPAModel = Me.InitData("frmEmpPAModel", oView, prepMode, prepIDX, strXML)

        If Me.BindModel(objModel, oView) Then
            Me.cmb_Grade.ValueList = Me.Model.ValueLists("Grade").ComboList

            dt = Me.Model.DatasetCollection("EmpRow").Tables(0)
            Me.lblCode.Text = dt.Rows(0)("EmpCode")
            Me.lblDep.Text = dt.Rows(0)("DepName")
            Me.lblName.Text = dt.Rows(0)("FullName")

            If prepMode = EnumfrmMode.acEditM Then Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
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
End Class
