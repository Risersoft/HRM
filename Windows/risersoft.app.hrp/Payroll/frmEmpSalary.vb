Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Public Class frmEmpSalary
    Inherits frmMax
    Dim dtEmp As DataTable
    Dim myViewEmpSalRateCalc, myViewEmpSalRateCalcComp, myViewLastCalculated As New clsWinView

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.InitForm()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(btnOk, btnCancel, btnSave)
        myView.SetGrid(Me.UltraGridEmpSalComp)
        myViewEmpSalRateCalc.SetGrid(Me.UltraGridEmpSalRateCalc)
        myViewEmpSalRateCalcComp.SetGrid(Me.UltraGridEmpSalRateCalcComp)
        myViewLastCalculated.SetGrid(Me.UltraGridLastCalculated)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim dsESRCC As DataSet
        Me.FormPrepared = False

        Dim objModel As frmEmpSalaryModel = Me.InitData("frmEmpSalaryModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "SalStructure", "", Me.cmb_SalStructureID)
            myWinSQL.AssignCmb(Me.dsCombo, "SkillText", "", Me.cmb_SkillText)
            If frmMode = EnumfrmMode.acAddM AndAlso cmb_SalStructureID.Rows.Count = 1 Then myRow("SalStructureID") = myUtils.cValTN(cmb_SalStructureID.Rows(0).Cells("SalStructureID").Value)

            If myUtils.cValTN(myRow("PayProposalID")) > 0 Then
                dt_Dated.ReadOnly = True
            End If

            dsESRCC = Me.Model.DatasetCollection("SalRCComp")
            myViewEmpSalRateCalcComp.mainGrid.BindView(dsESRCC, , 0)
            myViewEmpSalRateCalcComp.mainGrid.MainConf("FORMATXML") = "<COL KEY=""ComponentName"" CAPTION=""Component""/><COL KEY=""BenefitName"" CAPTION=""Benefit""/><COL KEY=""Amount"" CAPTION=""Amount""/><COL KEY=""AmountEE"" CAPTION=""Employee Share""/><COL KEY=""AmountER"" CAPTION=""Employer Share""/>"
            myViewEmpSalRateCalcComp.mainGrid.QuickConf("", True, "1-1-1-1-1-1")


            dtEmp = Me.Model.DatasetCollection("Emp").Tables(0)
            Me.txt_Gross.Text = Format(myUtils.cValTN(Me.vBag("pGross")), "#.##")

            If dtEmp.Rows.Count > 0 Then
                Me.lbl_FullName.Text = dtEmp.Rows(0)("FullName")
                Me.lbl_EmpCode.Text = dtEmp.Rows(0)("EmpCode")
                Me.lbl_DepName.Text = dtEmp.Rows(0)("DepName")
                Me.FormPrepared = True
            End If

            'Bydefault sets, if require can be changed by user
            txt_bper.Text = 50
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("EmpSalComp"))
            myViewEmpSalRateCalc.PrepEdit(Me.Model.GridViews("SalRateCalc"))
            myViewLastCalculated.PrepEdit(Me.Model.GridViews("LastCalculated"))
            Return True
        End If
        Return False
    End Function

    Private Function CheckSave(EmpSalaryID As Integer) As clsProcOutput
        Dim oret As clsProcOutput
        Dim ds As DataSet = myView.mainGrid.myDS.Copy
        myUtils.AddTable(ds, myRow.Row.Table, "empsal")
        oret = Me.GenerateDataOutput("checksave", ds, 0)
        If oret.Success Then
            If oret.GetCalcRows("ppsal").Length > 0 AndAlso (Not myUtils.NullNot(Me.dt_Dated.Value)) Then
                If MsgBox("This will lead to salary recalculation. Are you sure you want to change and recalculate the salary", MsgBoxStyle.YesNo, myWinApp.Vars("appname")) = MsgBoxResult.No Then
                    oret.AddError("Cancelled by user")
                End If
            End If
        Else
            MsgBox(oret.Message, vbInformation, myWinApp.Vars("appname"))
        End If
        Return oret
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            Dim oRet = CheckSave(frmIDX)
            If oRet.Success AndAlso Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub grid_EmpSalRateCalc_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGridEmpSalRateCalc.AfterRowActivate
        Dim id1 As Integer
        id1 = myViewEmpSalRateCalc.mainGrid.myGrid.ActiveRow.Cells("EmpSalRateCalcID").Value

        If Not IsNothing(myViewEmpSalRateCalcComp.mainGrid.myDv) Then myViewEmpSalRateCalcComp.mainGrid.myDv.RowFilter = "EmpSalRateCalcID = " & id1
    End Sub

    Private Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click
        Dim Params As New List(Of clsSQLParam), oRet As New clsProcOutput
        Params.Add(New clsSQLParam("@EmpSalaryID", myUtils.cValTN(myRow("EmpSalaryID")), GetType(Integer), False))
        Params.Add(New clsSQLParam("@SalStructureID", myUtils.cValTN(myRow("SalStructureID")), GetType(Integer), False))
        Dim ds As DataSet = myView.mainGrid.myDS
        oRet = Me.GenerateDataParamsOutput("generate", ds, Params)
        If oRet.Success Then
            Me.UpdateViewData(myView, oRet)
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If
    End Sub

    Private Sub btn_Define_Click(sender As Object, e As EventArgs) Handles btn_Define.Click
        Dim rmid As Integer, Params As New List(Of clsSQLParam), oret As clsProcOutput
        cm.EndCurrentEdit()
        If myUtils.cValTN(Me.vBag("ratemasterid")) > 0 Then
            rmid = myUtils.cValTN(Me.vBag("ratemasterid"))
        Else
            Params.Add(New clsSQLParam("@compid", myUtils.cValTN(dtEmp.Rows(0)("CompanyID")), GetType(Integer), False))
            Params.Add(New clsSQLParam("@dated", Format(dt_Dated.Value, "yyyy-MMM-dd"), GetType(Date), False))
            oret = Me.GenerateParamsOutput("RateMaster", Params)
            rmid = oret.ID

        End If

        backCalcSal(frmIDX, rmid, txt_bper.Text, myUtils.cValTN(Me.txt_Gross.Text), Math.Abs(CInt(Me.chk_IgnorePrev.Checked)))

    End Sub

    Private Function backCalcSal(frmidx As Integer, RMID As Integer, basicper As Integer, tarGross As Double, IgnorePrev As Boolean) As Boolean
        Dim Params As New List(Of clsSQLParam), oret As clsProcOutput

        Params.Add(New clsSQLParam("@RMID", RMID, GetType(Integer), False))
        Params.Add(New clsSQLParam("@basicper", basicper, GetType(Integer), False))
        Params.Add(New clsSQLParam("@tarGross", tarGross, GetType(Integer), False))
        Params.Add(New clsSQLParam("@IgnorePrev", IgnorePrev, GetType(Boolean), False))
        Dim ds As DataSet = myView.mainGrid.myDS.Copy
        myUtils.AddTable(ds, myRow.Row.Table, "empsal")
        oret = Me.GenerateDataParamsOutput("backCalcSal", ds, Params)
        If oret.Success Then
            Me.UpdateViewData(myView, oret)
        Else
            MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If

    End Function

End Class
