Imports risersoft.app.shared
Imports risersoft.app.mxform
Imports risersoft.shared.Extensions

Public Class frmAttendTagMaster
    Inherits frmMax
    Friend fMat As frmLeavePolicy

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.InitForm()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub InitForm()

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim dt As DataTable

        myWinSQL.AssignCmb(fMat.dsCombo, "TagType", "", Me.cmb_TagType)
        myWinSQL.AssignCmb(fMat.dsCombo, "AccrueType", "", Me.cmb_AccrueType)
        myWinSQL.AssignCmb(fMat.dsCombo, "LvePeriodType", "", Me.cmb_LvePeriodType)

        Me.cmb_CountOnlyWork.ValueList = fMat.Model.ValueLists("CountOnlyWork").ComboList
        Me.cmb_AllowEncashLM.ValueList = fMat.Model.ValueLists("AllowEncash").ComboList
        Me.cmb_AllowEncashFF.ValueList = fMat.Model.ValueLists("AllowEncash").ComboList

        dt = fMat.Model.DatasetCollection("AttTag").Tables(0)
        Me.cmb_LeaveGroup.DataSource = dt

        cmb_LvePeriodType.Enabled = False
        txt_LvePeriodNum.Enabled = False
        txt_LveDue.Enabled = False
        txt_MaxAccrue.Enabled = False

        If Me.GetSoftData(oView, prepMode, prepIDX) Then
            PrepForm = True
        End If
    End Function

    Private Sub cmb_AccrueType_RowSelected(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles cmb_AccrueType.RowSelected

        cmb_LvePeriodType.Enabled = False
        txt_LvePeriodNum.Enabled = False
        txt_LveDue.Enabled = False
        txt_MaxAccrue.Enabled = False
        cmb_CountOnlyWork.Enabled = False

        If cmb_AccrueType.Value = "P" Then
            cmb_LvePeriodType.Enabled = True
            txt_LvePeriodNum.Enabled = True
            txt_LveDue.Enabled = True
            txt_MaxAccrue.Enabled = True

        ElseIf cmb_AccrueType.Value = "B" Then
            txt_MaxAccrue.Enabled = True

        ElseIf cmb_AccrueType.Value = "E" Then
            txt_LvePeriodNum.Enabled = True
            cmb_CountOnlyWork.Enabled = True
        End If

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click, btnCancel.Click
        Me.InitError()

        If myUtils.NullNot(Me.txt_AttendTag.Value) Then WinFormUtils.AddError(Me.txt_AttendTag, "Enter Attend Tag")
        If myUtils.NullNot(Me.txt_FullTag.Value) Then WinFormUtils.AddError(Me.txt_FullTag, "Enter Full Tag")
        If myUtils.NullNot(Me.cmb_TagType.Value) Then WinFormUtils.AddError(Me.cmb_TagType, "Enter Tag Type")

        If myUtils.cValTN(Me.myRow("TagType")) = 3 Then
            If myUtils.NullNot(Me.cmb_AccrueType.Value) Then WinFormUtils.AddError(Me.cmb_AccrueType, "Select Accrue Type")
            If myUtils.cStrTN(myRow("AccrueType")) = "P" AndAlso myUtils.cStrTN(myRow("LvePeriodType")).Trim.Length = 0 Then WinFormUtils.AddError(cmb_LvePeriodType, "Enter Leave Period Type")
            If (myUtils.cStrTN(myRow("LvePeriodNum")).Trim.Length = 0) AndAlso (myUtils.cStrTN(myRow("AccrueType")) = "E") Then WinFormUtils.AddError(txt_LvePeriodNum, "Enter Leave Period")
        End If

        If Me.CanSave Then
            cm.EndCurrentEdit()
            Me.SaveSoftData()
        End If
    End Sub

End Class
