Imports risersoft.app.mxent
Imports risersoft.app.shared
Imports risersoft.app.mxform

Public Class frmBonusMaster
    Inherits frmMax

    Dim myViewFF, myViewPayHRVouch As New clsWinView
    Dim f As New frmApiTaskStatus

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridFY)
        myViewFF.SetGrid(Me.UltraGridFF)
        myViewPayHRVouch.SetGrid(Me.UltraGridPayHRVouch)

        f.AddtoTab(Me.UltraTabControl2, "status", True)
        f.SetParent(Me)
        AddHandler f.TaskExecuted, AddressOf TaskExecuted

        Me.dt_BonusPaidOn.ReadOnly = True

    End Sub

    Public Sub TaskExecuted(sender As Object, TaskId As String)
        Me.PrepForm(myView, EnumfrmMode.acEditM, frmIDX)
        WinFormUtils.SetReadOnly(Me.UltraPanel1, True, True)
        WinFormUtils.SetReadOnly(Me.UltraPanel3, True, True)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmBonusMasterModel = Me.InitData("frmBonusMasterModel", oView, prepMode, prepIDX, strXML)

        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "cutofftype", "", Me.cmb_BonusCutOffType)
            myWinSQL.AssignCmb(Me.dsCombo, "company", "", Me.cmb_CompanyID)
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("FY"))
            myViewFF.PrepEdit(Me.Model.GridViews("FF"))
            myViewPayHRVouch.PrepEdit(Me.Model.GridViews("PayHRVouch"))
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

    Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click
        Dim oret = GetParams("summary", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Sub btn_CalcBonus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalcBonus.Click
        Dim oret = GetParams("generate", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnCalcPayment.Click
        Dim oret = GetParams("payment", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Function GetParams(Key As String, UploadType As String)
        WinFormUtils.SetReadOnly(Me.UltraPanel1, True, False)
        WinFormUtils.SetReadOnly(Me.UltraPanel3, True, False)
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@BonusMasterID", myUtils.cValTN(myRow("BonusMasterID")), GetType(Integer), False))
        Dim oRet = Me.GenerateParamsOutput(Key, Params)
        Dim result As Guid
        If System.Guid.TryParse(oRet.Description, result) Then
            f.AddTask(result.ToString)
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, myApp.Vars("appname"))
            Me.TaskExecuted(Me, "")
        End If
        Return oRet

    End Function

End Class
