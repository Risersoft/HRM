Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Public Class frmLeaveNCash
    Inherits frmMax

    Dim myVueLveLedger As New clsWinView, objLve As New clsLeaveLedgerBase(Me.Controller)

    Public Sub New()
        '   MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        myView.SetGrid(UltrGridLveBal)
        myVueLveLedger.SetGrid(UltraGridLedger)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim dtEmp As DataTable

        Me.FormPrepared = False
        Dim objModel As frmLeaveNCashModel = Me.InitData("frmLeaveNCashModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "LeaveMaster", "", Me.cmb_LeaveMasterID)
            myWinSQL.AssignCmb(Me.dsCombo, "attendtag", "", Me.cmb_AttendTagID)
            dtEmp = Me.Model.DatasetCollection("Emp").Tables(0)
            If frmMode = EnumfrmMode.acEditM Then
                txt_AmountPrev.Value = myRow("AmountPrev")
                txt_AmountNew.Value = myRow("AmountNew")
            End If

            If dtEmp.Rows.Count > 0 Then
                txt_EmpCode.Text = dtEmp.Rows(0)("EmpCode")
                txt_Name.Text = dtEmp.Rows(0)("FullName")
                If myUtils.cValTN(dtEmp.Rows(0)("iscasual")) = 0 Then Me.FormPrepared = True
            Else
                MsgBox("This Employee does not exists")
            End If
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("LveBal"))
            myVueLveLedger.PrepEdit(Me.Model.GridViews("LveLedger"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            populateLeaveMaster()
            If Me.SaveModel() Then
                txt_AmountPrev.Value = myRow("AmountPrev")
                txt_AmountNew.Value = myRow("AmountNew")
                Me.DoRefresh = True
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

    Private Sub populateLeaveMaster()
        Dim rLveMstr As DataRow = objLve.oMasterData.rLeaveMaster(myRow("CompanyID"), myRow("dated"), True)
        If Not IsNothing(rLveMstr) Then myRow("leavemasterid") = rLveMstr("leavemasterid")
    End Sub

    Private Sub btn_getLeaves_Click(sender As Object, e As EventArgs) Handles btn_getLeaves.Click
        Me.InitError()
        If myUtils.NullNot(Me.dt_dated.Value) Then
            WinFormUtils.AddError(Me.dt_dated, "Select date")
        Else
            cm.EndCurrentEdit()
            populateLeaveMaster()
            Dim Params As New List(Of clsSQLParam)
            Params.Add(New clsSQLParam("@LeaveMasterID", myUtils.cValTN(myRow("LeaveMasterID")), GetType(Integer), False))
            Params.Add(New clsSQLParam("@EmployeeID", myUtils.cValTN(myRow("EmployeeID")), GetType(Integer), False))
            Params.Add(New clsSQLParam("@LeaveLedgerID", myUtils.cValTN(myRow("LeaveLedgerID")), GetType(Integer), False))
            Dim oRet As clsProcOutput = Me.GenerateParamsOutput("getsummary", Params)
            If oRet.Success Then
                Me.UpdateViewData(myView, oRet)
                Dim oRet2 As clsProcOutput = Me.GenerateParamsOutput("getledger", Params)
                If oRet2.Success Then
                    Me.UpdateViewData(myVueLveLedger, oRet2)
                Else
                    MsgBox(oRet2.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If
            Else
                MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
            End If

        End If
    End Sub

End Class

