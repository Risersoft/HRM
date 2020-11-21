<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInterview
    Inherits frmMax

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


        Me.InitForm()
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_InterViewType = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_JobApplicationID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Remark = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Result = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.dt_Dated = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGridFB = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPanel6 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnAddInterviewFB = New Infragistics.Win.Misc.UltraButton()
        Me.btnDelInterviewFB = New Infragistics.Win.Misc.UltraButton()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.txt_InterViewType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_JobApplicationID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Result, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        CType(Me.UltraGridFB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel6.ClientArea.SuspendLayout()
        Me.UltraPanel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_InterViewType)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label5)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmb_JobApplicationID)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Remark)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel5)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Result)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.dt_Dated)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblDate)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(515, 133)
        Me.UltraPanel1.TabIndex = 11
        '
        'UltraLabel2
        '
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(10, 44)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(78, 14)
        Me.UltraLabel2.TabIndex = 27
        Me.UltraLabel2.Text = "Interview Type"
        '
        'txt_InterViewType
        '
        Me.txt_InterViewType.Location = New System.Drawing.Point(94, 40)
        Me.txt_InterViewType.Name = "txt_InterViewType"
        Me.txt_InterViewType.Size = New System.Drawing.Size(234, 21)
        Me.txt_InterViewType.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 14)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Job Application"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_JobApplicationID
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.cmb_JobApplicationID.Appearance = Appearance1
        Me.cmb_JobApplicationID.Location = New System.Drawing.Point(94, 12)
        Me.cmb_JobApplicationID.Name = "cmb_JobApplicationID"
        Me.cmb_JobApplicationID.Size = New System.Drawing.Size(225, 22)
        Me.cmb_JobApplicationID.TabIndex = 26
        Me.cmb_JobApplicationID.Text = "UltraCombo5"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(44, 99)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(44, 14)
        Me.UltraLabel1.TabIndex = 22
        Me.UltraLabel1.Text = "Remark"
        '
        'txt_Remark
        '
        Me.txt_Remark.Location = New System.Drawing.Point(94, 95)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(276, 21)
        Me.txt_Remark.TabIndex = 23
        '
        'UltraLabel5
        '
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(52, 71)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel5.TabIndex = 20
        Me.UltraLabel5.Text = "Result"
        '
        'txt_Result
        '
        Me.txt_Result.Location = New System.Drawing.Point(94, 67)
        Me.txt_Result.Name = "txt_Result"
        Me.txt_Result.Size = New System.Drawing.Size(276, 21)
        Me.txt_Result.TabIndex = 21
        '
        'dt_Dated
        '
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.FontData.ItalicAsString = "False"
        Appearance2.FontData.Name = "Arial"
        Appearance2.FontData.SizeInPoints = 8.25!
        Appearance2.FontData.StrikeoutAsString = "False"
        Appearance2.FontData.UnderlineAsString = "False"
        Me.dt_Dated.Appearance = Appearance2
        Me.dt_Dated.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_Dated.FormatString = "dddd dd MMM yyyy"
        Me.dt_Dated.Location = New System.Drawing.Point(375, 13)
        Me.dt_Dated.Name = "dt_Dated"
        Me.dt_Dated.NullText = "Not Defined"
        Me.dt_Dated.Size = New System.Drawing.Size(128, 21)
        Me.dt_Dated.TabIndex = 9
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(334, 17)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(35, 14)
        Me.lblDate.TabIndex = 8
        Me.lblDate.Text = "Dated"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraPanel2
        '
        '
        'UltraPanel2.ClientArea
        '
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnSave)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnCancel)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnOk)
        Me.UltraPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 421)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(515, 35)
        Me.UltraPanel2.TabIndex = 12
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(266, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 35)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(349, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 35)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOk.Location = New System.Drawing.Point(432, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(83, 35)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        '
        'UltraGridFB
        '
        Me.UltraGridFB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridFB.Location = New System.Drawing.Point(0, 133)
        Me.UltraGridFB.Name = "UltraGridFB"
        Me.UltraGridFB.Size = New System.Drawing.Size(515, 258)
        Me.UltraGridFB.TabIndex = 14
        Me.UltraGridFB.Text = "Report"
        '
        'UltraPanel6
        '
        '
        'UltraPanel6.ClientArea
        '
        Me.UltraPanel6.ClientArea.Controls.Add(Me.btnAddInterviewFB)
        Me.UltraPanel6.ClientArea.Controls.Add(Me.btnDelInterviewFB)
        Me.UltraPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel6.Location = New System.Drawing.Point(0, 391)
        Me.UltraPanel6.Name = "UltraPanel6"
        Me.UltraPanel6.Size = New System.Drawing.Size(515, 30)
        Me.UltraPanel6.TabIndex = 146
        '
        'btnAddInterviewFB
        '
        Me.btnAddInterviewFB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddInterviewFB.Location = New System.Drawing.Point(378, 0)
        Me.btnAddInterviewFB.Name = "btnAddInterviewFB"
        Me.btnAddInterviewFB.Size = New System.Drawing.Size(67, 30)
        Me.btnAddInterviewFB.TabIndex = 0
        Me.btnAddInterviewFB.Text = "Add"
        '
        'btnDelInterviewFB
        '
        Me.btnDelInterviewFB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelInterviewFB.Location = New System.Drawing.Point(445, 0)
        Me.btnDelInterviewFB.Name = "btnDelInterviewFB"
        Me.btnDelInterviewFB.Size = New System.Drawing.Size(67, 30)
        Me.btnDelInterviewFB.TabIndex = 1
        Me.btnDelInterviewFB.Text = "Delete"
        '
        'frmInterview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Interview"
        Me.ClientSize = New System.Drawing.Size(515, 456)
        Me.Controls.Add(Me.UltraGridFB)
        Me.Controls.Add(Me.UltraPanel6)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Name = "frmInterview"
        Me.Text = "Interview"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.txt_InterViewType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_JobApplicationID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Result, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ResumeLayout(False)
        CType(Me.UltraGridFB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel6.ClientArea.ResumeLayout(False)
        Me.UltraPanel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Remark As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Result As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dt_Dated As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblDate As Windows.Forms.Label
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGridFB As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_InterViewType As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents cmb_JobApplicationID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPanel6 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnAddInterviewFB As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDelInterviewFB As Infragistics.Win.Misc.UltraButton
End Class
