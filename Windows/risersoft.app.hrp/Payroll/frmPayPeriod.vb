Imports Infragistics.Win.UltraWinGrid
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports risersoft.app2.shared
Imports risersoft.shared.Extensions
Imports risersoft.app.shared

Public Class frmPayPeriod
    Inherits frmMax2

    Dim myViewPayPeriodBenefit, myViewPayPVouch, myViewPayPCampus As New clsWinView
    Dim f As New frmApiTaskStatus

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridHolidays)
        myViewPayPeriodBenefit.SetGrid(Me.UltraGridPayPeriodCalc)
        myViewPayPVouch.SetGrid(Me.UltraGridPaymentHRVouch)
        myViewPayPCampus.SetGrid(Me.UltraGridPayPeriodCampus)

        f.AddtoTab(Me.UltraTabControl2, "status", True)
        f.SetParent(Me)
        AddHandler f.TaskExecuted, AddressOf TaskExecuted

    End Sub

    Public Sub TaskExecuted(sender As Object, TaskId As String)
        Me.PrepForm(myView, EnumfrmMode.acEditM, frmIDX)
        WinFormUtils.SetReadOnly(Me.UltraPanel1, True, True)
        WinFormUtils.SetReadOnly(Me.UltraPanel3, True, True)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmPayPeriodModel = Me.InitData("frmPayPeriodModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "rm", "", Me.cmb_RateMasterID)
            AssignMasters()

            If myUtils.cStrTN(myRow("PayPeriodName")).Trim.Length = 0 Then myRow("payperiodname") = Format(myRow("sdate"), "MMMM") & "-" & Format(myRow("edate"), "yyyy")
            btn_importattend.Visible = False
        End If

        Me.FormPrepared = True
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Holiday"), Me.btnAddHoliday, Me.btnDelHoliday)
            myViewPayPeriodBenefit.PrepEdit(Me.Model.GridViews("PayPBen"))
            myViewPayPVouch.PrepEdit(Me.Model.GridViews("PayPVouch"))
            myViewPayPCampus.PrepEdit(Me.Model.GridViews("PayPCampus"))

            Dim disabled As Boolean = (myUtils.cBoolTN(myRow("isfinal")) OrElse frmMode = EnumfrmMode.acAddM)
            Me.UltraPanel10.Enabled = Not disabled
            Me.UltraPanel4.Enabled = Not disabled
            Me.UltraPanel11.Enabled = Not disabled
            Dim disabled2 As Boolean = (myUtils.cBoolTN(myRow("isfinalwot")) OrElse frmMode = EnumfrmMode.acAddM)
            Me.UltraPanel12.Enabled = Not disabled2

            Return True
        End If
        Return False
    End Function

    Private Sub AssignMasters()

        myWinSQL.AssignCmb(Me.dsCombo, "lve", "", Me.cmb_LeaveMasterID)
        myWinSQL.AssignCmb(Me.dsCombo, "bonus", "", Me.cmb_BonusMasterID)
        myWinSQL.AssignCmb(Me.dsCombo, "postperiod", "", Me.cmb_PostPeriodID)
    End Sub

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        Dim objProc As clsProcOutput = Nothing
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

    Private Sub btnCreateDep_Click_1(sender As Object, e As EventArgs) Handles btnCreateDep.Click
        Dim oRet = Me.GenerateIDOutput("advancedep", frmIDX)
        MsgBox(oRet.Message,, myWinApp.Vars("appname"))

    End Sub

    Private Sub btnAdvance_Click(sender As Object, e As EventArgs) Handles btnAdvance.Click
        Dim oRet = Me.GenerateIDOutput("advance", frmIDX)
        Me.dt_AdvanceOn.Value = oRet.Dated
        MsgBox(oRet.Message,, myWinApp.Vars("appname"))
    End Sub

    Private Sub btn_importattend_Click(sender As Object, e As EventArgs) Handles btn_importattend.Click

    End Sub

    Private Async Sub btn_CalSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalSalary.Click
        Dim oret = GetParams("calcppsal", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Async Sub btn_Incentive_Click(sender As Object, e As EventArgs) Handles btn_Incentive.Click
        Dim oret = GetParams("calcppinc", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Function GetParams(Key As String, UploadType As String)
        WinFormUtils.SetReadOnly(Me.UltraPanel1, True, False)
        WinFormUtils.SetReadOnly(Me.UltraPanel3, True, False)
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@PayperiodID", myUtils.cValTN(myRow("PayperiodID")), GetType(Integer), False))
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

    Private Sub btnUncalculate_Click(sender As Object, e As EventArgs) Handles btnUncalculate.Click
        Dim oret = GetParams("uncalcppsal", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Async Sub btnCalcSummary_Click(sender As Object, e As EventArgs) Handles btnCalcSummary.Click
        Dim oret = GetParams("calcppsumm", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Async Sub btnIncenSumm_Click(sender As Object, e As EventArgs) Handles btnIncenSumm.Click
        Dim oret = GetParams("calcincsumm", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))

    End Sub

    Private Sub UltraGridHolidays_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles UltraGridHolidays.AfterCellUpdate
        myRow("saldirtyon") = Now
    End Sub

    Private Sub UltraGridHolidays_AfterRowsDeleted(sender As Object, e As EventArgs) Handles UltraGridHolidays.AfterRowsDeleted
        myRow("saldirtyon") = Now
    End Sub

End Class



'Notes :- 

'1. Firstly Advance to be generated then the rows will go on Payslip Table.

