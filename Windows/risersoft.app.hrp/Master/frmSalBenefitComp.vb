Imports risersoft.app.mxent
Imports risersoft.app.mxform
Public Class frmSalBenefitComp
    Inherits frmMax

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridSalBenRate)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim objRM As New clsRateMasterBase(Me.Controller)

        Me.FormPrepared = False
        Dim objModel As frmSalBenefitCompModel = Me.InitData("frmSalBenefitCompModel", oView, prepMode, prepIDX, strXML)

        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "Company", "", Me.cmb_CompanyID)
            myWinSQL.AssignCmb(Me.dsCombo, "Benefits", "", Me.cmb_SalBenefitID)

            If frmMode = EnumfrmMode.acEditM Then
                If myUtils.cBoolTN(myWinSQL2.ParamValue("@isfinal", Me.Model.ModelParams)) Then WinFormUtils.SetReadOnly(Me, False)
                Me.txt_CompCode.ReadOnly = False
                Me.dt_EndDate.ReadOnly = False
            End If

            For i = 0 To UltraGridSalBenRate.Rows.Count - 1
                If objRM.IsFinal(myWinUtils.DataRowFromGridRow(UltraGridSalBenRate.Rows(i))) Then UltraGridSalBenRate.Rows(i).Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Next
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("SalBenRate"))
            Return True
        End If

        Return False
    End Function

    Public Overrides Function VSave() As Boolean

        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()

            Dim ds As DataSet = myView.mainGrid.myDS.Copy
            myUtils.AddTable(ds, myRow.Row.Table, "SalBenComp")
            Dim oRet As clsProcOutput = Me.GenerateDataOutput("checksave", ds, 0)
            If oRet.Success Then
                If oRet.GetCalcRows("ppsal").Length > 0 Then
                    If MsgBox("After such changes, salary will be Recalculated. Are you sure you want to change and recalculate the salary", MsgBoxStyle.YesNo, myWinApp.Vars("appname")) = MsgBoxResult.No Then Exit Function
                End If
                If Me.SaveModel() Then
                    Return True
                End If
            Else
                WinFormUtils.AddError(Me.txt_CompCode, oRet.Message)
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

    Private Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click
        Dim oret As clsProcOutput
        Dim ds As DataSet = myView.mainGrid.myDS.Copy
        myUtils.AddTable(ds, myRow.Row.Table, "SalBenComp")
        oret = Me.GenerateDataOutput("generate", ds, 0)
        If oret.Success Then
            Me.UpdateViewData(myView, oret)
        Else
            MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If
    End Sub

End Class
