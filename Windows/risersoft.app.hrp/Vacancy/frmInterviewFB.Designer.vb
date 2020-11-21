<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInterviewFB
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridUser = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPanel6 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnEditUser = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_JobApplication = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_InterViewType = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.dt_Dated = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Remark = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Result = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGridUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel6.ClientArea.SuspendLayout()
        Me.UltraPanel6.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.cmb_JobApplication, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_InterViewType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGridUser)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraPanel6)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(545, 253)
        '
        'UltraGridUser
        '
        Me.UltraGridUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridUser.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridUser.Name = "UltraGridUser"
        Me.UltraGridUser.Size = New System.Drawing.Size(545, 223)
        Me.UltraGridUser.TabIndex = 147
        Me.UltraGridUser.Text = "Report"
        '
        'UltraPanel6
        '
        '
        'UltraPanel6.ClientArea
        '
        Me.UltraPanel6.ClientArea.Controls.Add(Me.btnEditUser)
        Me.UltraPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel6.Location = New System.Drawing.Point(0, 223)
        Me.UltraPanel6.Name = "UltraPanel6"
        Me.UltraPanel6.Size = New System.Drawing.Size(545, 30)
        Me.UltraPanel6.TabIndex = 148
        '
        'btnEditUser
        '
        Me.btnEditUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditUser.Location = New System.Drawing.Point(475, 0)
        Me.btnEditUser.Name = "btnEditUser"
        Me.btnEditUser.Size = New System.Drawing.Size(67, 30)
        Me.btnEditUser.TabIndex = 1
        Me.btnEditUser.Text = "Edit"
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label5)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmb_JobApplication)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_InterViewType)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.dt_Dated)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblDate)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Remark)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel5)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Result)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(549, 123)
        Me.UltraPanel1.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 14)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Job Application"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_JobApplication
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.cmb_JobApplication.Appearance = Appearance1
        Me.cmb_JobApplication.Location = New System.Drawing.Point(106, 40)
        Me.cmb_JobApplication.Name = "cmb_JobApplication"
        Me.cmb_JobApplication.ReadOnly = True
        Me.cmb_JobApplication.Size = New System.Drawing.Size(232, 22)
        Me.cmb_JobApplication.TabIndex = 36
        Me.cmb_JobApplication.Text = "UltraCombo5"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(22, 17)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(78, 14)
        Me.UltraLabel2.TabIndex = 33
        Me.UltraLabel2.Text = "Interview Type"
        '
        'txt_InterViewType
        '
        Me.txt_InterViewType.Location = New System.Drawing.Point(106, 13)
        Me.txt_InterViewType.Name = "txt_InterViewType"
        Me.txt_InterViewType.ReadOnly = True
        Me.txt_InterViewType.Size = New System.Drawing.Size(234, 21)
        Me.txt_InterViewType.TabIndex = 34
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
        Me.dt_Dated.Location = New System.Drawing.Point(395, 13)
        Me.dt_Dated.Name = "dt_Dated"
        Me.dt_Dated.NullText = "Not Defined"
        Me.dt_Dated.ReadOnly = True
        Me.dt_Dated.Size = New System.Drawing.Size(128, 21)
        Me.dt_Dated.TabIndex = 30
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(354, 17)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(35, 14)
        Me.lblDate.TabIndex = 29
        Me.lblDate.Text = "Dated"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraLabel1
        '
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(52, 96)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(44, 14)
        Me.UltraLabel1.TabIndex = 22
        Me.UltraLabel1.Text = "Remark"
        '
        'txt_Remark
        '
        Me.txt_Remark.Location = New System.Drawing.Point(106, 96)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.ReadOnly = True
        Me.txt_Remark.Size = New System.Drawing.Size(276, 21)
        Me.txt_Remark.TabIndex = 23
        '
        'UltraLabel5
        '
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(60, 72)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel5.TabIndex = 20
        Me.UltraLabel5.Text = "Result"
        '
        'txt_Result
        '
        Me.txt_Result.Location = New System.Drawing.Point(106, 68)
        Me.txt_Result.Name = "txt_Result"
        Me.txt_Result.ReadOnly = True
        Me.txt_Result.Size = New System.Drawing.Size(276, 21)
        Me.txt_Result.TabIndex = 21
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 402)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(549, 40)
        Me.Panel4.TabIndex = 34
        '
        'btnSave
        '
        Appearance3.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance3
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(285, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 40)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Save"
        '
        'btnCancel
        '
        Appearance4.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance4
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(373, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOK
        '
        Appearance5.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance5
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(461, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 40)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&OK"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 123)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UltraTabControl1.Size = New System.Drawing.Size(549, 279)
        Me.UltraTabControl1.TabIndex = 35
        UltraTab5.TabPage = Me.UltraTabPageControl1
        UltraTab5.Text = "Users"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab5})
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(545, 253)
        '
        'frmInterviewFB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Interview FB"
        Me.ClientSize = New System.Drawing.Size(549, 442)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Name = "frmInterviewFB"
        Me.Text = "Interview FB"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGridUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel6.ClientArea.ResumeLayout(False)
        Me.UltraPanel6.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.cmb_JobApplication, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_InterViewType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Remark As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Result As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_InterViewType As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dt_Dated As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblDate As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents cmb_JobApplication As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraGridUser As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraPanel6 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnEditUser As Infragistics.Win.Misc.UltraButton
End Class
