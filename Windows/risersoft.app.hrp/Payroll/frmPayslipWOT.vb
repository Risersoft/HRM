Imports Infragistics.Win.UltraWinGrid
Imports risersoft.app.mxform

Public Class frmPaySlipWOT
    Inherits frmMax

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridPaySlipWOT)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.InitForm()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmPayslipWOTModel = Me.InitData("frmPayslipWOTModel", oView, prepMode, prepIDX, strXML)

        If Me.BindModel(objModel, oView) Then
            Me.lbl_Name.Text = "Incentive Categorization for " & myRow.Row("descrip")
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function
    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("PayslipWOT"))
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

    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        For Each r As DataRow In myView.mainGrid.myDS.Tables(0).Select
            If myUtils.NullNot(r("PersonalExpenseInc")) Then
                r("PersonalExpenseInc") = myUtils.cValTN(Me.txt_Rate.Text) * myUtils.cValTN(r("EWDay"))
            End If
        Next
    End Sub
End Class
