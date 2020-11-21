Imports risersoft.app.mxent
Imports risersoft.app.shared
Imports risersoft.app.mxform
Imports risersoft.shared.Extensions

Public Class frmEmp
    Inherits frmMax
    Dim myViewEmpSalBen As New clsWinView, oRet As clsProcOutput = Nothing
    Dim dvCamp, dvEmp As DataView

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridEmpSalary)
        myViewEmpSalBen.SetGrid(Me.UltraGridEmpSalBen)
    End Sub
    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmEmpModel = Me.InitData("frmEmpModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "status", "", Me.cmb_StatusNum)
            dvCamp = myWinSQL.AssignCmb(Me.dsCombo, "campus", "", Me.cmb_campusid,, 2)
            myWinSQL.AssignCmb(Me.dsCombo, "dep", "", Me.cmb_depid)
            myWinSQL.AssignCmb(Me.dsCombo, "user", "", Me.cmb_userID)
            dvEmp = myWinSQL.AssignCmb(Me.dsCombo, "rep", "", Me.cmb_reportstoID,, 2)
            myWinSQL.AssignCmb(Me.dsCombo, "party", "", Me.cmb_ContractorID)
            myWinSQL.AssignCmb(Me.dsCombo, "shift", "", Me.cmb_shiftid)
            myWinSQL.AssignCmb(Me.dsCombo, "emp1", "", Me.cmb_paymentthrucode)
            myWinSQL.AssignCmb(Me.dsCombo, "bank", "", Me.cmb_BankBranchID)
            myWinSQL.AssignCmb(Me.dsCombo, "leave1", "", Me.cmb_LeaveAuth1ID)
            myWinSQL.AssignCmb(Me.dsCombo, "leave2", "", Me.cmb_LeaveAuth2ID)

            Me.cmb_haswage.ValueList = Me.Model.ValueLists("haswage").ComboList
            Me.cmb_isworker.ValueList = Me.Model.ValueLists("isworker").ComboList

            Me.cmb_Relationship.ValueList = Me.Model.ValueLists("Relationship").ComboList
            myWinSQL.AssignCmb(Me.dsCombo, "Division", "", Me.cmb_DivisionID)
            Me.cmb_ImprestEnabled.ValueList = Me.Model.ValueLists("EnableList").ComboList
            Me.cmb_PunchEnabled.ValueList = Me.Model.ValueLists("EnableList").ComboList
            myWinSQL.AssignCmb(Me.dsCombo, "emp", "", Me.cmb_LeftReasonCode)

            Me.lblName.Text = myUtils.cStrTN(myWinSQL2.ParamValue("@Name", Me.Model.ModelParams))
            Me.txt_VendorCode.Text = myUtils.cStrTN(myWinSQL2.ParamValue("@VendorCode", Me.Model.ModelParams))
            If myUtils.cValTN(myWinSQL2.ParamValue("@EmpSalCnt", Me.Model.ModelParams)) = 1 Then btnAddNew.Enabled = False

            WinFormUtils.Prep2Form(Me)
            If frmMode = EnumfrmMode.acAddM Then myRow("iscasual") = False

            HandleDate(Now.Date)

            If myUtils.IsInList(myUtils.cStrTN(Me.Controller.Vars("appcode")), "HRP", "NHRM") Then
                If myView.mainGrid.myDS.Tables(0).Select.Length = 0 Then btnEdit.Visible = False Else btnEdit.Visible = True
            Else
                UltraTabControl1.Tabs("Salary").Visible = False
                UltraTabControl1.Tabs("Benefits").Visible = False
            End If
            Me.FormPrepared = True
            If TypeOf pView.fParentWin Is frmHRPerson Then Me.btn_Person.Visible = False Else Me.btn_Person.Visible = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("EmpSal"))
            myViewEmpSalBen.PrepEdit(Me.Model.GridViews("EmpSalBen"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError() : WinFormUtils.InitTabBacks(Me.UltraTabControl1)
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

    Private Sub btn_Person_Click(sender As Object, e As EventArgs) Handles btn_Person.Click
        Dim f As New frmHRPerson
        If f.PrepForm(myView, EnumfrmMode.acEditM, myUtils.cValTN(myRow("personid"))) Then WinFormUtils.CentreForm(f, Me.Owner)
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim dtEmpSal As DataTable
        Dim f As New frmEmpSalary
        f.PrepForm(Me.myView, EnumfrmMode.acAddM, 0, "<PARAMS EmployeeID=""" & frmIDX & """/>")
        f.ShowDialog()

        dtEmpSal = Me.Model.DatasetCollection("empsal").Tables(0)
        If dtEmpSal.Rows.Count > 0 Then btnAddNew.Enabled = False

        Dim oRet As clsProcOutput = Me.GenerateIDOutput("sal", frmIDX)
        If oRet.Success Then
            Me.UpdateViewData(myView, oRet)
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim f As New frmEmpSalary
        myView.ContextRow = myView.mainGrid.ActiveRow

        f.PrepForm(Me.myView, EnumfrmMode.acEditM, myUtils.cValTN(myWinUtils.DataRowFromGridRow(myView.mainGrid.ActiveRow.Row)("EmpSalaryID")))
        f.ShowDialog()

        Dim oRet As clsProcOutput = Me.GenerateIDOutput("sal", frmIDX)
        If oRet.Success Then
            Me.UpdateViewData(myView, oRet)
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If
    End Sub

    Private Sub btn_chngRpt_Click(sender As Object, e As EventArgs) Handles btn_chngRpt.Click
        Dim Params As New List(Of clsSQLParam), Params1 As New List(Of clsSQLParam), oret As clsProcOutput

        Params.Add(New clsSQLParam("@employeeid", frmIDX, GetType(Integer), False))
        Dim rr() As DataRow = Me.AdvancedSelect("emp", Params)

        If (Not rr Is Nothing) AndAlso (rr.Length > 0) Then

            Params.Add(New clsSQLParam("@empid", frmIDX, GetType(Integer), False))
            Params.Add(New clsSQLParam("@idcsv", myUtils.MakeCSV(rr, "employeeid"), GetType(Integer), True))
            Dim rr1() As DataRow = Me.AdvancedSelect("newemp", Params)

            If (Not rr1 Is Nothing) AndAlso (rr1.Length > 0) Then

                Params1.Add(New clsSQLParam("@empid", rr1(0)("employeeid"), GetType(Integer), False))
                Params1.Add(New clsSQLParam("@idcsv", myUtils.MakeCSV(rr, "employeeid"), GetType(Integer), True))
                oret = Me.GenerateParamsOutput("empid", Params1)
                MsgBox(oret.Message)
            End If
        End If
        Me.Refresh()
    End Sub

    Private Sub btnCreateVendor_Click(sender As Object, e As EventArgs) Handles btnCreateVendor.Click
        Dim oret As clsProcOutput = Me.GenerateIDOutput("vendor", frmIDX)

        If oret.Success Then
            Me.txt_VendorCode.Text = myUtils.cStrTN(oret.Data.Tables(0).Rows(0)("VendorCode"))
        Else
            MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AdvanceSelect()
    End Sub

    Private Sub AdvanceSelect()
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@empid", frmIDX, GetType(Integer), False))
        Dim rr() As DataRow = Me.AdvancedSelect("salbenefit", Params)
        If (Not rr Is Nothing) AndAlso (rr.Length > 0) Then
            For Each r1 As DataRow In rr
                Dim r2 As DataRow = myUtils.CopyOneRow(r1, myViewEmpSalBen.mainGrid.myDS.Tables(0))
            Next
        End If

    End Sub

    Private Sub btn_CalcleaveBal_Click(sender As Object, e As EventArgs) Handles btn_CalcleaveBal.Click
        If Me.VSave() Then
            Dim oRet As clsProcOutput = Me.GenerateIDOutput("calcleavebal", frmIDX)
            If oRet.Success Then
                Me.PrepForm(Me.pView, Me.frmMode, Me.frmIDX, Me.Controller.Data.VarBagXML(Me.vBag))
            End If
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@empid", frmIDX, GetType(Integer), False))
        Dim rr() As DataRow = Me.AdvancedSelect("bankbranch", Params)
        If Not rr Is Nothing AndAlso rr.Length > 0 Then
            cmb_BankBranchID.Value = myUtils.cValTN(rr(0)("VendorID"))
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If myViewEmpSalBen.mainGrid.myGrid.ActiveRow IsNot Nothing Then
            If myUtils.cValTN(myViewEmpSalBen.mainGrid.myGrid.ActiveRow.Cells("IsFinal").Value) = 1 Then
                MsgBox("Payperiod is finalized, cannot delete this benefit")
            Else
                myViewEmpSalBen.mainGrid.ButtonAction("del")
            End If
        End If
    End Sub

    Private Sub HandleDate(dated As Date)
        dvCamp.RowFilter = risersoft.app.mxform.myFuncs.FieldFilter(Me.Controller, Me.fRow, dated, "WODate", "CompletedOn", "CampusID")
        dvEmp.RowFilter = risersoft.app.mxform.myFuncs.FilterTimeDependent(dated, "JoinDate", "LeaveDate", 0)
    End Sub
End Class

