Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Public Class frmEmpApplication
    Inherits frmMax

    Public Sub New()
        '   MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim dtEmp As DataTable
        Me.FormPrepared = False
        Dim objModel As frmEmpApplicationModel = Me.InitData("frmEmpApplicationModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "ApplicationType", "", Me.cmb_ApplicationType)
            dtEmp = Me.Model.DatasetCollection("Emp").Tables(0)

            If dtEmp.Rows.Count > 0 Then
                txt_EmpCode.Text = dtEmp.Rows(0)("EmpCode")
                txt_Name.Text = dtEmp.Rows(0)("FullName")
                If myUtils.cValTN(dtEmp.Rows(0)("iscasual")) = 0 Then Me.FormPrepared = True
            Else
                MsgBox("This Employee does not exists")
            End If

            btnProcessApp.Visible = myUtils.IsInList(myUtils.cStrTN(Me.Controller.Vars("appcode")), "HRP")

        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
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

    Private Sub cmb_ApplicationType_RowSelected(sender As Object, e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles cmb_ApplicationType.RowSelected
        If cmb_ApplicationType.Value = "LO" Then
            UltraTabControl1.Tabs("Loan").Selected = True
            txt_DesiredLeaveNum.Value = DBNull.Value
        Else
            UltraTabControl1.Tabs("Lve").Selected = True
            txt_DesiredAmount.Value = DBNull.Value
        End If
    End Sub

    Private Sub btnProcessApp_Click(sender As Object, e As EventArgs) Handles btnProcessApp.Click
        If Me.CanSave() Then
            Dim oRet As clsProcOutput = GenerateIDOutput("empapp", frmIDX)
            If oRet.Success Then
                Me.PrepForm(pView, frmMode, frmIDX, Me.Controller.Data.VarBagXML(Me.vBag))
            Else
                MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
            End If
        End If
    End Sub
End Class
