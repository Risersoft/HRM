Imports risersoft.app.mxent
Imports risersoft.app.shared
Imports risersoft.app.mxform

Public Class frmLeavePolicy
    Inherits frmMax

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.InitForm()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub InitForm()
        WinFormUtils.SetButtonConf(btnOk, btnCancel, btnSave)
        myView.SetGrid(UltraGridAttendTagMaster)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmLeavePolicyModel = Me.InitData("frmLeavePolicyModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("AttendTag"))
            Return True
        End If

        Return False
    End Function

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        Dim f As New frmAttendTagMaster
        f.fMat = Me
        If f.PrepForm(myView, EnumfrmMode.acAddM, "", "") Then f.ShowDialog()
    End Sub

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        Dim f As New frmAttendTagMaster
        f.fMat = Me
        If f.PrepForm(Me.myView, EnumfrmMode.acEditM, "") Then f.ShowDialog()
    End Sub

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        myView.ContextRow = myView.mainGrid.ActiveRow
        If Not myView.ContextRow Is Nothing Then
            If myUtils.cValTN(myView.ContextRow.CellValue("AttendTagID")) = 0 Then
                myView.mainGrid.ButtonAction("del")
            Else
                Dim oRet = Me.DeleteEntity("attendtag", myUtils.cValTN(myView.ContextRow.CellValue("AttendTagID")), True)
                If oRet.Success Then
                    Dim rr As DataRow() = New DataRow() {myWinUtils.DataRowFromGridRow(myView.mainGrid.myGrid.ActiveRow)}
                    myUtils.RemoveRows(rr)
                Else
                    MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If
            End If
        End If
    End Sub

    Private Sub btnDeleteLvePolicy_Click(sender As Object, e As EventArgs) Handles btnDeleteLvePolicy.Click
        Dim oRet = Me.DeleteEntity("lp", frmIDX, False)
        If oRet.ErrorCount > 0 Then
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        Else
            If MsgBox(oRet.Message, MsgBoxStyle.YesNo + MsgBoxStyle.Question, myWinApp.Vars("appname")) = MsgBoxResult.Yes Then
                oRet = Me.DeleteEntity("lp", frmIDX, True)
                If oRet.Success Then WinFormUtils.ButtonAction(Me, "btnCancel")
            End If
        End If
    End Sub

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