Imports risersoft.app.mxent
Imports risersoft.app.shared
Imports risersoft.app.mxform
Imports risersoft.app2.shared

Public Class frmLeaveMaster
    Inherits frmMax2

    Dim myViewFF, myViewLL, myViewFY, myViewPayHRVouch, myViewYr As New clsWinView
    Dim f As New frmApiTaskStatus

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridBal)
        myViewYr.SetGrid(Me.UltraGridYr)
        myViewPayHRVouch.SetGrid(Me.UltraGridPHRVouch)
        myViewFF.SetGrid(Me.UltraGridFF)
        myViewLL.SetGrid(Me.UltraGridLL)
        myViewFY.SetGrid(Me.UltraGridFY)

        f.AddtoTab(Me.UltraTabControl2, "status", True)
        f.SetParent(Me)
        AddHandler f.TaskExecuted, AddressOf TaskExecuted

    End Sub

    Public Sub TaskExecuted(sender As Object, TaskId As String)
        Me.PrepForm(myView, EnumfrmMode.acEditM, frmIDX)
        WinFormUtils.SetReadOnly(Me.UltraPanel1, True, True)
        WinFormUtils.SetReadOnly(Me.UltraPanel3, True, False)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmLeaveMasterModel = Me.InitData("frmLeaveMasterModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "company", "", Me.cmb_CompanyID)
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("LveBal"))
            myViewFF.PrepEdit(Me.Model.GridViews("FF"))
            myViewLL.PrepEdit(Me.Model.GridViews("LL"))
            myViewFY.PrepEdit(Me.Model.GridViews("FY"))
            myViewPayHRVouch.PrepEdit(Me.Model.GridViews("PayHRVouch"))
            myViewYr.PrepEdit(Me.Model.GridViews("Yr"))
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

    Private Async Sub btn_CalcLeaves_Click(sender As Object, e As EventArgs) Handles btn_CalcLeaves.Click
        Dim oret = GetParams("generateleavebal", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Async Sub btn_calcFY_Click(sender As Object, e As EventArgs) Handles btn_calcFY.Click
        Dim oret = GetParams("generatefy", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Function GetParams(Key As String, UploadType As String)
        WinFormUtils.SetReadOnly(Me.UltraPanel1, True, False)
        WinFormUtils.SetReadOnly(Me.UltraPanel3, True, False)
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@LeaveMasterID", myUtils.cValTN(myRow("LeaveMasterID")), GetType(Integer), False))
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

