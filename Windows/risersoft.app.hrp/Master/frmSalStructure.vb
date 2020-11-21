Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxform

Public Class frmSalStructure

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridSalComp)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmSalStructureModel = Me.InitData("frmSalStructureModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("SalComp"), btn_AddSalComp, btn_DelSalComp)
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

    Private Sub btnDeleteSalStructure_Click(sender As Object, e As EventArgs) Handles btnDeleteSalStructure.Click
        Dim oRet = Me.DeleteEntity("salstructure", frmIDX, False)
        If oRet.ErrorCount > 0 Then
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        Else
            If MsgBox(oRet.Message, MsgBoxStyle.YesNo + MsgBoxStyle.Question, myWinApp.Vars("appname")) = MsgBoxResult.Yes Then
                oRet = Me.DeleteEntity("salstructure", frmIDX, True)
                If oRet.Success Then WinFormUtils.ButtonAction(Me, "btnCancel")
            End If
        End If

    End Sub

End Class
