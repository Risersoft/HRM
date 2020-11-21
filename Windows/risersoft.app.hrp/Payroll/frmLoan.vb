Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports risersoft.app.mxform

Public Class frmLoan
    Inherits frmMax

    Dim dtEmp As DataTable, myViewIncen, myViewBonus, myViewAdHoc As New clsWinView

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        myView.SetGrid(UltraGridEmpLoanPBPayPeriod)
        myViewIncen.SetGrid(UltraGridEmpLoanPBIncentive)
        myViewBonus.SetGrid(UltraGridEmpLoanPayBackBonus)
        myViewAdHoc.SetGrid(UltraGridEmpLoanPayBackAdHoc)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim oMasterData As New clsMasterDataHRP(Me.Controller)
        Dim Params As New List(Of clsSQLParam), oret As clsProcOutput

        Me.FormPrepared = False
        Dim objModel As frmLoanModel = Me.InitData("frmLoanModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "DeductFromPM", "", Me.cmb_DeductFromPM)

            dtEmp = Me.Model.DatasetCollection("Emp").Tables(0)
            lbl_FullName.Text = dtEmp.Rows(0)("FullName")
            lbl_EmpCode.Text = dtEmp.Rows(0)("EmpCode")

            If Not (myUtils.NullNot(myRow("PaymentID"))) Then
                dt_dated.ReadOnly = True
                txt_Amount.ReadOnly = True
            Else
                dt_dated.ReadOnly = False
                txt_Amount.ReadOnly = False
            End If

            For Each gr As UltraGridRow In myViewAdHoc.mainGrid.myGrid.Rows
                Dim CompanyId As Integer = Me.Model.DatasetCollection("emp").Tables(0).Rows(0)("CompanyID")
                Dim Dated As Date = Format(gr.Cells("AdHocPayDate").Value, "yyyy-MMM-dd")
                Dim rAH As DataRow = oMasterData.rPayPeriod(CompanyId, Dated)
                If (myUtils.cBoolTN(rAH("IsFinal"))) OrElse (Not myUtils.NullNot(gr.Cells("PaymentID").Value)) Then gr.Activation = Activation.NoEdit
            Next

            For Each gr As UltraGridRow In myViewBonus.mainGrid.myGrid.Rows
                If Not (myUtils.NullNot(gr.Cells("BonusCalcOn").Value)) AndAlso (Not (myUtils.NullNot(gr.Cells("BonusPaidOn").Value))) Then gr.Activation = Activation.NoEdit
            Next

            For Each gr As UltraGridRow In myView.mainGrid.myGrid.Rows
                    If (myUtils.cValTN(gr.Cells("Isfinal").Value) = 1) OrElse (myUtils.cValTN(gr.Cells("PaymentID").Value) > 0) Then gr.Activation = Activation.NoEdit
                Next

                For Each gr As UltraGridRow In myViewIncen.mainGrid.myGrid.Rows
                    If (myUtils.cValTN(gr.Cells("IsFinalWOT").Value) = 1) OrElse (myUtils.cValTN(gr.Cells("PaymentID").Value) > 0) Then gr.Activation = Activation.NoEdit
                Next

                Me.FormPrepared = True
            End If

            Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("LoanPayBack"))
            myViewIncen.PrepEdit(Me.Model.GridViews("LoanPayBackIncen"))
            myViewBonus.PrepEdit(Me.Model.GridViews("Bonus"))
            myViewAdHoc.PrepEdit(Me.Model.GridViews("AdHoc"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            For Each gr As UltraGridRow In myViewAdHoc.mainGrid.myGrid.Rows
                gr.Appearance.BackColor = Nothing
                If myUtils.cBoolTN(gr.Cells("PPIsFinal").Value) Then myViewAdHoc.mainGrid.myGrid.AddError("This Date belongs to finalized PostPeriod", gr)
            Next
            cm.EndCurrentEdit()
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btn_DeleteInstallment_Click(sender As Object, e As EventArgs) Handles btn_DeleteInstallment.Click
        Dim Params As New List(Of clsSQLParam), oret As clsProcOutput
        Dim oMasterData As New clsMasterDataHRP(Me.Controller)
        Select Case Me.UltraTabControl1.SelectedTab.Key.Trim.ToLower

            Case "pp"
                If myView.mainGrid.RowCount > 0 Then
                    Dim PPID As Integer = myView.mainGrid.myGrid.ActiveRow.Cells("PayPeriodID").Value
                    Dim rPP As DataRow = oMasterData.rPayPeriodID(PPID)

                    If myUtils.cBoolTN(rPP("IsFinal")) Then
                        MsgBox("This PayPeriod Is Finalized, this installment cannot be deleted")

                    ElseIf myUtils.cValTN(myView.mainGrid.myGrid.ActiveRow.Cells("PaymentID").Value) > 0 Then
                        MsgBox("Payment already made against this installment")
                    Else
                        myView.mainGrid.ButtonAction("del")
                    End If
                End If

            Case "in"
                If myViewIncen.mainGrid.RowCount > 0 Then
                    Dim PPID As Integer = myViewIncen.mainGrid.myGrid.ActiveRow.Cells("PayPeriodID").Value
                    Dim rPP As DataRow = oMasterData.rPayPeriodID(PPID)

                    If myUtils.cBoolTN(rPP("IsFinalWOT")) Then
                        MsgBox("This PayPeriod Is Finalized, this installment cannot be deleted")

                    ElseIf myUtils.cValTN(myViewIncen.mainGrid.myGrid.ActiveRow.Cells("PaymentID").Value) > 0 Then
                        MsgBox("Payment already made against this installment")
                    Else
                        myViewIncen.mainGrid.ButtonAction("del")
                    End If
                End If

            Case "bs"
                If myViewBonus.mainGrid.RowCount > 0 Then
                    Dim BMID As Integer = myViewBonus.mainGrid.ActiveRow.CellValue("BonusMasterID")
                    Dim rBM As DataRow = oMasterData.rBonusMasterID(BMID)

                    If (Not (myUtils.NullNot(rBM("BonusCalcOn")))) AndAlso (Not (myUtils.NullNot(rBM("BonusPaidOn")))) Then
                        MsgBox("This BonusMaster is finalized, this installment cannot be deleted")
                    Else
                        myViewBonus.mainGrid.ButtonAction("del")
                    End If
                End If

            Case "ah"
                If myViewAdHoc.mainGrid.RowCount > 0 Then
                    If Not (myUtils.NullNot(myViewAdHoc.mainGrid.myGrid.ActiveRow.Cells("AdHocPayDate").Value)) Then
                        If Not (myUtils.NullNot(dtEmp.Rows(0)("CompanyID"))) Then
                            Dim CompanyId As Integer = Me.Model.DatasetCollection("emp").Tables(0).Rows(0)("CompanyID")
                            Dim Dated As Date = Format(myViewAdHoc.mainGrid.myGrid.ActiveRow.Cells("AdHocPayDate").Value, "yyyy-MMM-dd")

                            Dim rAH As DataRow = oMasterData.rPayPeriod(CompanyId, Dated)

                            If myUtils.cBoolTN(rAH("IsFinal")) Then
                                MsgBox("Payperiod corresponding to this date is finalized, so this installment cannot be deleted")
                            ElseIf myUtils.cValTN(myView.mainGrid.myGrid.ActiveRow.Cells("PaymentID").Value) > 0 Then
                                MsgBox("Payment already made against this installment")
                            Else
                                myViewAdHoc.mainGrid.ButtonAction("del")
                            End If
                        Else
                            myViewAdHoc.mainGrid.ButtonAction("del")
                        End If
                    Else
                        myViewAdHoc.mainGrid.ButtonAction("del")
                    End If

                End If
        End Select

    End Sub

    Private Sub btn_LoanInstallment_Click(sender As Object, e As EventArgs) Handles btn_LoanInstallment.Click
        Dim f1 As New frmGrid, rLoan As DataRow = Nothing, Params As New List(Of clsSQLParam), ppids, bmids As String, rrPP(), rrIN(), rrBM() As DataRow

        rrPP = myView.mainGrid.myDS.Tables(0).Select()
        ppids = myUtils.MakeCSV(rrPP, "PayPeriodID")

        rrIN = myViewIncen.mainGrid.myDS.Tables(0).Select()
        ppids = myUtils.MakeCSV(rrIN, "PayPeriodID")

        rrBM = myViewBonus.mainGrid.myDS.Tables(0).Select()
        bmids = myUtils.MakeCSV(rrBM, "BonusMasterID")

        Select Case Me.UltraTabControl1.SelectedTab.Key.Trim.ToLower

            Case "pp"
                Params.Add(New clsSQLParam("@ppcsv", ppids, GetType(Integer), True))
                Params.Add(New clsSQLParam("@dated", Format(myRow("Dated"), "yyyy-MMM-dd"), GetType(DateTime), True))

                Dim Model As clsViewModel = Me.GenerateParamsModel("pp", Params)
                f1.myView.PrepEdit(Model)

                If f1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    rLoan = myUtils.DataRowFromGridRow(f1.myView.ContextRow)
                    myUtils.CopyOneRow(rLoan, myView.mainGrid.myDS.Tables(0))
                End If

            Case "in"
                Params.Add(New clsSQLParam("@ppcsv", ppids, GetType(Integer), True))
                Dim oModel As clsViewModel = Me.GenerateParamsModel("in", Params)
                f1.myView.PrepEdit(oModel)

                If f1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    rLoan = myUtils.DataRowFromGridRow(f1.myView.ContextRow)
                    Dim nr As DataRow = myUtils.CopyOneRow(rLoan, myViewIncen.mainGrid.myDS.Tables(0))
                    nr("DeductFromPP") = "I"
                End If

            Case "bs"
                Params.Add(New clsSQLParam("@bmcsv", bmids, GetType(Integer), True))
                Dim oModel As clsViewModel = Me.GenerateParamsModel("bs", Params)
                f1.myView.PrepEdit(oModel)

                If f1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    rLoan = myUtils.DataRowFromGridRow(f1.myView.ContextRow)
                    myUtils.CopyOneRow(rLoan, myViewBonus.mainGrid.myDS.Tables(0))
                End If

            Case "ah"
                myViewAdHoc.mainGrid.ButtonAction("Add")
                myUtils.CopyOneRow(rLoan, myViewAdHoc.mainGrid.myDS.Tables(0))

        End Select

    End Sub

End Class
