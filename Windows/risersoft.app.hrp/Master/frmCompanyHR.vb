Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform

Public Class frmCompanyHR
    Inherits frmMax

    Dim myViewRates, myViewBonus, myViewLeave As New clsWinView, oRet As clsProcOutput = Nothing

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridSalBenComp)
        myViewRates.SetGrid(UltraGridRateMaster)
        myViewBonus.SetGrid(Me.UltraGridBonus)
        myViewLeave.SetGrid(Me.UltraGridLeave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim dtBM As DataTable = Nothing, dtLM As DataTable = Nothing
        Me.FormPrepared = False
        Dim objModel As frmCompanyHRModel = Me.InitData("frmCompanyHRModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "shift", "", Me.cmb_MainShiftID)
            myWinSQL.AssignCmb(Me.dsCombo, "lvepolicy", "", Me.cmb_LeavePolicyID)

            dtBM = Me.Model.DatasetCollection("Master").Tables("BM")
            If dtBM.Rows.Count > 0 Then
                txt_BonusStartMonth.ReadOnly = True
            Else
                btnEditBM.Visible = False
            End If

            dtLM = Me.Model.DatasetCollection("Master").Tables("LM")
            If dtLM.Rows.Count > 0 Then
                txt_LeaveStartMonth.ReadOnly = True
            Else
                btnEditLM.Visible = False
            End If

            If Not IsDBNull(myRow("CompName")) Then txt_CompName.Text = myRow("CompName")
            Me.CtlRTFLoanRules.RTFText = myUtils.cStrTN(myRow("LoanRules"))

            'check from modelparams
            If frmMode = EnumfrmMode.acEditM Then
                If myUtils.cValTN(myWinSQL2.ParamValue("@LeavePolicyID", Me.Model.ModelParams)) Then cmb_LeavePolicyID.ReadOnly = True
            End If

            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Ben"))
            myViewRates.PrepEdit(Me.Model.GridViews("Rate"))
            myViewBonus.PrepEdit(Me.Model.GridViews("Bonus"))
            myViewLeave.PrepEdit(Me.Model.GridViews("Leave"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            myRow("LoanRules") = Me.CtlRTFLoanRules.RTFText
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btn_AddRateMaster_Click(sender As Object, e As EventArgs) Handles btn_AddRateMaster.Click
        Dim f1 As New frmRateMaster
        If f1.PrepForm(Me.myView, EnumfrmMode.acAddM, 0, "<PARAMS CompanyID=""" & frmIDX & """ />") Then
            f1.ShowDialog()
            GenerateOutput("refreshrm", 0)
        End If
    End Sub

    Private Sub btn_EditRateMaster_Click(sender As Object, e As EventArgs) Handles btn_EditRateMaster.Click
        Dim f1 As New frmRateMaster
        If f1.PrepForm(Me.myView, EnumfrmMode.acEditM, myUtils.cValTN(myUtils.DataRowFromGridRow(myViewRates.mainGrid.ActiveRow)("RateMasterID"))) Then
            f1.ShowDialog()
            GenerateOutput("refreshrm", 0)
        End If
    End Sub

    Private Sub GenerateOutput(key As String, EntityID As Integer)
        Dim oRet As New clsProcOutput, Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@CompanyID", myUtils.cValTN(frmIDX), GetType(Integer), False))
        Params.Add(New clsSQLParam("@EntityID", EntityID, GetType(Integer), False))
        Select Case key.Trim.ToLower

            Case "deleterm", "refreshrm"
                oRet = Me.GenerateParamsOutput(key.Trim.ToLower, Params)
                If oRet.Success Then
                    Me.UpdateViewData(myViewRates, oRet)
                Else
                    MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If

            Case "deletesalbencomp", "refreshsalbencomp"
                oRet = Me.GenerateParamsOutput(key.Trim.ToLower, Params)
                If oRet.Success Then
                    Me.UpdateViewData(myView, oRet)
                Else
                    MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If

            Case "bonus"
                oRet = Me.GenerateParamsOutput(key.Trim.ToLower, Params)
                If oRet.Success Then
                    Me.UpdateViewData(myViewBonus, oRet)
                Else
                    MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If

            Case "leave"
                oRet = Me.GenerateParamsOutput(key.Trim.ToLower, Params)
                If oRet.Success Then
                    Me.UpdateViewData(myViewLeave, oRet)
                Else
                    MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If
        End Select
    End Sub

    Private Sub CheckDeleteRM(RateMasterID As Integer)
        Dim objProc As clsProcOutput = Nothing
        objProc = Me.GenerateIDOutput("deleterm", RateMasterID)
        If objProc.Success Then
            If objProc.GetCalcRows("ppsal").Length > 0 Then
                If MsgBox("After Deletetion, Salary will be ReCalculated. Are you sure you want to Delete this RateMaster and recalculate the salary", MsgBoxStyle.YesNo, myWinApp.Vars("appname")) = MsgBoxResult.No Then Exit Sub
            Else
                If MsgBox("Are You Sure You Want To Delete This RateMaster", MsgBoxStyle.YesNo, myWinApp.Vars("appname")) = MsgBoxResult.No Then Exit Sub
            End If
        Else
            MsgBox(objProc.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
            Exit Sub
        End If
        GenerateOutput("deleteRM", RateMasterID)
    End Sub

    Private Sub btn_deleteRateMaster_Click(sender As Object, e As EventArgs) Handles btn_deleteRateMaster.Click
        Dim r1 As DataRow = myUtils.DataRowFromGridRow(myViewRates.mainGrid.ActiveRow)
        If Not r1 Is Nothing Then
            Dim objRMstr As New clsRateMasterBase(Me.Controller)
            CheckDeleteRM(myUtils.cValTN(r1("RateMasterID")))
        End If

    End Sub

    Private Sub btn_AddSalBenefitComp_Click(sender As Object, e As EventArgs) Handles btn_AddSalBenefitComp.Click
        Dim f1 As New frmSalBenefitComp
        If f1.PrepForm(Me.myView, EnumfrmMode.acAddM, 0, "<PARAMS CompanyID=""" & frmIDX & """/>") Then
            f1.ShowDialog()
            GenerateOutput("refreshsalbencomp", 0)
        End If
    End Sub

    Private Sub btn_EditSalBenefitComp_Click(sender As Object, e As EventArgs) Handles btn_EditSalBenefitComp.Click
        Dim f1 As New frmSalBenefitComp
        If f1.PrepForm(Me.myView, EnumfrmMode.acEditM, myUtils.cValTN(myWinUtils.DataRowFromGridRow(myView.mainGrid.ActiveRow.Row)("SalBenefitCompID"))) Then
            f1.ShowDialog()
            GenerateOutput("refreshsalbencomp", 0)
        End If
    End Sub

    Private Sub CheckDeleteSalBenComp(SalBenefitCompID As Integer)
        Dim objProc As clsProcOutput = Nothing
        objProc = Me.GenerateIDOutput("deletesalbencomp", SalBenefitCompID)
        If objProc.Success Then
            If objProc.GetCalcRows("ppsal").Length > 0 Then
                If MsgBox("Salary will be ReCalculated. Are you sure you want to Delete this Benefit and recalculate the salary", MsgBoxStyle.YesNo, myWinApp.Vars("appname")) = MsgBoxResult.No Then Exit Sub
            Else
                If MsgBox("Are You Sure You Want To Delete This Benefit", MsgBoxStyle.YesNo, myWinApp.Vars("appname")) = MsgBoxResult.No Then Exit Sub
            End If
        Else
            MsgBox(objProc.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
            Exit Sub
        End If
        GenerateOutput("deleteSalBenComp", SalBenefitCompID)
    End Sub

    Private Sub btn_DeleteSalBenefitComp_Click(sender As Object, e As EventArgs) Handles btn_DeleteSalBenefitComp.Click
        Dim r1 As DataRow = myUtils.DataRowFromGridRow(myView.mainGrid.ActiveRow)
        If Not r1 Is Nothing Then
            Dim objSalBenComp As New clsSalBenefitCompBase(Me.Controller)
            CheckDeleteSalBenComp(myUtils.cValTN(r1("SalBenefitCompID")))
        End If

    End Sub

    Private Sub btnEditBM_Click(sender As Object, e As EventArgs) Handles btnEditBM.Click
        Dim f1 As New frmBonusMaster
        If f1.PrepForm(Me.myView, EnumfrmMode.acEditM, myUtils.cValTN(myWinUtils.DataRowFromGridRow(myViewBonus.mainGrid.ActiveRow.Row)("BonusMasterID"))) Then
            f1.ShowDialog()
            GenerateOutput("bonus", 0)
        End If
    End Sub

    Private Sub btnEditLM_Click(sender As Object, e As EventArgs) Handles btnEditLM.Click
        Dim f1 As New frmLeaveMaster
        If f1.PrepForm(Me.myView, EnumfrmMode.acEditM, myUtils.cValTN(myWinUtils.DataRowFromGridRow(myViewLeave.mainGrid.ActiveRow.Row)("LeaveMasterID"))) Then
            f1.ShowDialog()
            GenerateOutput("leave", 0)
        End If
    End Sub

End Class
