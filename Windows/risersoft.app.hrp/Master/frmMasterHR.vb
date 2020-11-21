Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports risersoft.app.config

Public Class frmMasterHR
    Inherits frmMax

    Dim myViewSalBenefit, myViewShift, myViewLvePolicy As New clsWinView

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, )
        myView.SetGrid(Me.UltraGridSalComp)
        myViewSalBenefit.SetGrid(Me.UltraGridSalBenefit)
        myViewShift.SetGrid(Me.UltraGridShift)
        myViewLvePolicy.SetGrid(Me.UltraGridLeavePolicy)

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        'Always executes on Add Mode, so no prepidx require

        Me.FormPrepared = False
        Dim objModel As frmMasterHRModel = Me.InitData("frmMasterHRModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("SalComp"))
            myViewSalBenefit.PrepEdit(Me.Model.GridViews("SalBen"))
            myViewShift.PrepEdit(Me.Model.GridViews("Shift"))
            myViewLvePolicy.PrepEdit(Me.Model.GridViews("LvePolicy"))
            Return True
        End If
        Return False
    End Function

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click

        Dim f As frmMax = Nothing, oView As clsWinView = Nothing
        Select Case Me.UltraTabControl1.SelectedTab.Key.Trim.ToLower
            Case "ss"
                f = New frmSalStructure
                oView = myView
            Case "sb"
                f = New frmSalBenefit
                oView = myViewSalBenefit
            Case "sh"
                f = New frmShift
                oView = myViewShift
            Case "lp"
                f = New frmLeavePolicy
                oView = myViewLvePolicy
        End Select

        f.PrepForm(oView, EnumfrmMode.acAddM, 0)
        f.ShowDialog()

        GenerateOutput(Me.UltraTabControl1.SelectedTab.Key.Trim.ToLower)

    End Sub

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click

        Dim f As frmMax = Nothing, oView As clsWinView = Nothing, IDValue As Integer

        Select Case Me.UltraTabControl1.SelectedTab.Key.Trim.ToLower

            Case "ss"
                f = New frmSalStructure
                IDValue = myView.mainGrid.myGrid.ActiveRow.Cells("SalStructureID").Value
                oView = myView
            Case "sb"
                f = New frmSalBenefit
                IDValue = myViewSalBenefit.mainGrid.myGrid.ActiveRow.Cells("SalBenefitID").Value
                oView = myViewSalBenefit
            Case "sh"
                f = New frmShift
                IDValue = myViewShift.mainGrid.myGrid.ActiveRow.Cells("ShiftID").Value
                oView = myViewShift
            Case "lp"
                f = New frmLeavePolicy
                IDValue = myViewLvePolicy.mainGrid.myGrid.ActiveRow.Cells("LeavePolicyID").Value
                oView = myViewLvePolicy
        End Select

        f.PrepForm(oView, EnumfrmMode.acEditM, IDValue)
        f.ShowDialog()
        GenerateOutput(Me.UltraTabControl1.SelectedTab.Key.Trim.ToLower)

    End Sub

    Public Sub GenerateOutput(key As String)
        Dim oView As clsWinView = Nothing, IDValue As Integer, Params As New List(Of clsSQLParam)
        Dim oRet2 As New clsProcOutput(False, "")
        Select Case key.Trim.ToLower

            Case "ss", "sb", "sh", "lp"
                oView = findView(key)
                oRet2 = Me.GenerateParamsOutput(key.Trim.ToLower, Params)
        End Select

        If oRet2.Success Then
            Me.UpdateViewData(oView, oRet2)
        ElseIf Not String.IsNullOrEmpty(oRet2.Message) Then
            MsgBox(oRet2.Message, MsgBoxStyle.YesNo, myWinApp.Vars("appname"))
        End If
    End Sub

    Private Function findView(key) As clsWinView

        Dim oview As clsWinView
        Select Case key
            Case "ss"
                oview = myView
            Case "sb"
                oview = myViewSalBenefit
            Case "sh"
                oview = myViewShift
            Case "lp"
                oview = myViewLvePolicy
        End Select
        Return oview
    End Function


End Class

