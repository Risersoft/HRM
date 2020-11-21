Imports risersoft.app.mxent
Imports risersoft.app.shared
Imports risersoft.app.mxform
Imports risersoft.shared.Extensions

Public Class frmFullNFinal
    Inherits frmMax

    Dim myViewLveNCash, myViewSalary, myViewBonus As New clsWinView

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        myView.SetGrid(Me.UltrGridLoan)
        myViewLveNCash.SetGrid(Me.UltraGridLveNCash)
        myViewSalary.SetGrid(Me.UltraGridSalary)
        myViewBonus.SetGrid(Me.UltraGridBonus)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmFullNFinalModel = Me.InitData("frmFullNFinalModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            Me.cmb_FFIncludeLastPP.ValueList = Me.Model.ValueLists("FFIncludeLastPP").ComboList
            Me.cmb_FFIncludeLastBonus.ValueList = Me.Model.ValueLists("FFIncludeLastBonus").ComboList

            myWinSQL.AssignCmb(Me.dsCombo, "emp", "", Me.cmb_LeftReasonCode)
            myWinSQL.AssignCmb(Me.dsCombo, "emp1", "", Me.cmb_NoticePeriodType)

            CalcData()
            If myViewSalary.mainGrid.myDS.Tables(0).Select("ISFinal = 1 ").Length > 0 OrElse
                myUtils.cBoolTN(myWinSQL2.ParamValue("@isreadonly", Me.Model.ModelParams)) Then
                WinFormUtils.SetReadOnly(Me, True)
                Me.btn_PrintFormat.Enabled = True
            End If

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("LoanPayBack"))
            myViewLveNCash.PrepEdit(Me.Model.GridViews("lveledger"))
            myViewSalary.PrepEdit(Me.Model.GridViews("Sal"))
            myViewBonus.PrepEdit(Me.Model.GridViews("Bonus"))
            Return True
        End If
        Return False
    End Function

    Private Sub CalcData()

        Dim dsCalculatedData As DataSet, str1 As String = "", netPaySal As Double = 0

        txt_Loan.Text = 0
        txt_Bonus.Text = 0
        txt_Lve.Text = 0

        dsCalculatedData = myViewSalary.mainGrid.myDS

        For Each r1 As DataRow In dsCalculatedData.Tables(0).Select()
            If str1 = "" Then
                str1 = r1("PayPeriodName")
            Else
                str1 = str1 & " & " & r1("PayPeriodName")
            End If

            Me.txt_Sal.Text = netPaySal + myUtils.cValTN(r1("NetPaid"))
            txt_Loan.Text = myUtils.cValTN(txt_Loan.Text) + myUtils.cValTN(r1("LoanPayBackSal"))
        Next

        Me.lbl_PayS.Text = "Salary for the Month of " & str1

        For Each r1 As DataRow In myViewBonus.mainGrid.myDS.Tables(0).Select()
            txt_Bonus.Text = myUtils.cValTN(txt_Bonus.Text) + myUtils.cValTN(r1("NetPaid"))
        Next

        For Each r1 As DataRow In myViewLveNCash.mainGrid.myDS.Tables(0).Select()
            txt_Lve.Text = myUtils.cValTN(txt_Lve.Text) + myUtils.cValTN(r1("amountnew")) + myUtils.cValTN(r1("amountprev"))
        Next

    End Sub

    Private Sub btn_PrintFormat_Click(sender As Object, e As EventArgs) Handles btn_PrintFormat.Click
        Me.Controller.PrintingPress.ShowSpecPrint(myView.Model, "crpfullnfinal", "", frmIDX)
    End Sub

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            If Me.SaveModel() Then
                CalcData()
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

    Private Sub cmb_NoticePeriodType_TextChanged(sender As Object, e As EventArgs) Handles cmb_NoticePeriodType.TextChanged
        If cmb_NoticePeriodType.Value = "N" Then
            txt_NoticePeriodMnth.ReadOnly = True
        Else
            txt_NoticePeriodMnth.ReadOnly = False
        End If

    End Sub
End Class

