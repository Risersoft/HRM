Imports risersoft.app.shared

Public Class frmNewEmp
    Inherits frmMax
    Dim dvCamp As DataView
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overloads Function BindModel(NewModel As clsFormDataModel) As Boolean
        dvCamp = myWinSQL.AssignCmb(NewModel.dsCombo, "Campus", "", Me.cmb_campusid,, 2)
        myWinSQL.AssignCmb(NewModel.dsCombo, "dep", "", Me.cmb_depid)
        myWinSQL.AssignCmb(NewModel.dsCombo, "Shift", "", Me.cmb_shiftid)
        Return True
    End Function

    Public Overrides Function PrepFormRow(ByVal r1 As DataRow) As Boolean
        Me.FormPrepared = False
        If Me.BindData(r1) Then
            WinFormUtils.Prep2Form(Me)
            If frmMode = EnumfrmMode.acAddM Then myRow("iscasual") = False

            HandleDate(myUtils.cDateTN(myRow("JoinDate"), DateTime.MinValue))
            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function VSave() As Boolean
        Dim str As String = ""
        Me.InitError()
        VSave = False
        If myUtils.NullNot(Me.txt_empcode.Value) Then WinFormUtils.AddError(Me.txt_empcode, "Enter Employee Code")
        If myUtils.NullNot(Me.cmb_depid.Value) Then WinFormUtils.AddError(Me.cmb_depid, "Select Department Name")
        If myUtils.NullNot(Me.cmb_campusid.Value) Then WinFormUtils.AddError(Me.cmb_campusid, "Select Campus Name")
        If myUtils.NullNot(Me.cmb_shiftid.Value) Then WinFormUtils.AddError(Me.cmb_shiftid, "Select Shift")
        If myUtils.NullNot(Me.dt_JoinDate.Value) Then WinFormUtils.AddError(Me.dt_JoinDate, "Select JoinDate")

        If Me.CanSave Then
            cm.EndCurrentEdit()
            VSave = True
        End If
    End Function

    Private Sub dt_JoinDate_Leave(sender As Object, e As EventArgs) Handles dt_JoinDate.Leave, dt_JoinDate.AfterCloseUp
        HandleDate(dt_JoinDate.Value)
    End Sub

    Private Sub HandleDate(dated As Date)
        dvCamp.RowFilter = risersoft.app.mxform.myFuncs.FieldFilter(Me.Controller, Me.fRow, dated, "WODate", "CompletedOn", "CampusID")
    End Sub
End Class