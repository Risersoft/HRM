<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVacancy
    Inherits frmMax

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.InitForm()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridSkill = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraPanel4 = New Infragistics.Win.Misc.UltraPanel()
        Me.btn_AddSkill = New Infragistics.Win.Misc.UltraButton()
        Me.btn_DeleteSkill = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Remark = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.chk_IsCompleted = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_NumPers = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.dt_Dated = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_depid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Vacancy = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_VacCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGridSkill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.UltraPanel4.ClientArea.SuspendLayout()
        Me.UltraPanel4.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_IsCompleted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NumPers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_depid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Vacancy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_VacCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGridSkill)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(517, 183)
        '
        'UltraGridSkill
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGridSkill.DisplayLayout.Appearance = Appearance1
        Me.UltraGridSkill.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGridSkill.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridSkill.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridSkill.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.UltraGridSkill.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridSkill.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.UltraGridSkill.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGridSkill.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UltraGridSkill.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UltraGridSkill.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.UltraGridSkill.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGridSkill.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGridSkill.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGridSkill.DisplayLayout.Override.CellAppearance = Appearance8
        Me.UltraGridSkill.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGridSkill.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridSkill.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.UltraGridSkill.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.UltraGridSkill.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UltraGridSkill.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.UltraGridSkill.DisplayLayout.Override.RowAppearance = Appearance11
        Me.UltraGridSkill.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGridSkill.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.UltraGridSkill.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGridSkill.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGridSkill.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.UltraGridSkill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridSkill.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridSkill.Name = "UltraGridSkill"
        Me.UltraGridSkill.Size = New System.Drawing.Size(517, 183)
        Me.UltraGridSkill.TabIndex = 0
        Me.UltraGridSkill.Text = "UltraGrid1"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 176)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(521, 209)
        Me.UltraTabControl1.TabIndex = 11
        UltraTab1.Key = "PP"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Skills"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(517, 183)
        '
        'UltraPanel4
        '
        '
        'UltraPanel4.ClientArea
        '
        Me.UltraPanel4.ClientArea.Controls.Add(Me.btn_AddSkill)
        Me.UltraPanel4.ClientArea.Controls.Add(Me.btn_DeleteSkill)
        Me.UltraPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel4.Location = New System.Drawing.Point(0, 385)
        Me.UltraPanel4.Name = "UltraPanel4"
        Me.UltraPanel4.Size = New System.Drawing.Size(521, 29)
        Me.UltraPanel4.TabIndex = 12
        '
        'btn_AddSkill
        '
        Me.btn_AddSkill.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_AddSkill.Location = New System.Drawing.Point(374, 0)
        Me.btn_AddSkill.Name = "btn_AddSkill"
        Me.btn_AddSkill.Size = New System.Drawing.Size(77, 29)
        Me.btn_AddSkill.TabIndex = 2
        Me.btn_AddSkill.Tag = "Add"
        Me.btn_AddSkill.Text = "Add"
        '
        'btn_DeleteSkill
        '
        Me.btn_DeleteSkill.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_DeleteSkill.Location = New System.Drawing.Point(451, 0)
        Me.btn_DeleteSkill.Name = "btn_DeleteSkill"
        Me.btn_DeleteSkill.Size = New System.Drawing.Size(70, 29)
        Me.btn_DeleteSkill.TabIndex = 0
        Me.btn_DeleteSkill.Text = "Delete"
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel5)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Remark)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.chk_IsCompleted)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_NumPers)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.dt_Dated)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblDate)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label5)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmb_depid)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Vacancy)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label10)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_VacCode)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(521, 176)
        Me.UltraPanel1.TabIndex = 9
        '
        'UltraLabel5
        '
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(60, 146)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(44, 14)
        Me.UltraLabel5.TabIndex = 18
        Me.UltraLabel5.Text = "Remark"
        '
        'txt_Remark
        '
        Me.txt_Remark.Location = New System.Drawing.Point(108, 143)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(395, 21)
        Me.txt_Remark.TabIndex = 19
        '
        'chk_IsCompleted
        '
        Me.chk_IsCompleted.AutoSize = True
        Me.chk_IsCompleted.Location = New System.Drawing.Point(297, 119)
        Me.chk_IsCompleted.Name = "chk_IsCompleted"
        Me.chk_IsCompleted.Size = New System.Drawing.Size(88, 17)
        Me.chk_IsCompleted.TabIndex = 17
        Me.chk_IsCompleted.Text = "Is Completed"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 14)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Number of Persons"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_NumPers
        '
        Appearance13.FontData.BoldAsString = "False"
        Me.txt_NumPers.Appearance = Appearance13
        Me.txt_NumPers.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_NumPers.Location = New System.Drawing.Point(109, 118)
        Me.txt_NumPers.Name = "txt_NumPers"
        Me.txt_NumPers.Size = New System.Drawing.Size(172, 17)
        Me.txt_NumPers.TabIndex = 15
        Me.txt_NumPers.Text = "UltraTextEditor2"
        '
        'dt_Dated
        '
        Appearance14.FontData.BoldAsString = "False"
        Appearance14.FontData.ItalicAsString = "False"
        Appearance14.FontData.Name = "Arial"
        Appearance14.FontData.SizeInPoints = 8.25!
        Appearance14.FontData.StrikeoutAsString = "False"
        Appearance14.FontData.UnderlineAsString = "False"
        Me.dt_Dated.Appearance = Appearance14
        Me.dt_Dated.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_Dated.FormatString = "dddd dd MMM yyyy"
        Me.dt_Dated.Location = New System.Drawing.Point(109, 90)
        Me.dt_Dated.Name = "dt_Dated"
        Me.dt_Dated.NullText = "Not Defined"
        Me.dt_Dated.Size = New System.Drawing.Size(240, 21)
        Me.dt_Dated.TabIndex = 13
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(69, 94)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(35, 14)
        Me.lblDate.TabIndex = 12
        Me.lblDate.Text = "Dated"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Department"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_depid
        '
        Appearance15.FontData.BoldAsString = "False"
        Me.cmb_depid.Appearance = Appearance15
        Me.cmb_depid.Location = New System.Drawing.Point(109, 61)
        Me.cmb_depid.Name = "cmb_depid"
        Me.cmb_depid.Size = New System.Drawing.Size(240, 22)
        Me.cmb_depid.TabIndex = 11
        Me.cmb_depid.Text = "UltraCombo5"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Vacancy"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Vacancy
        '
        Appearance16.FontData.BoldAsString = "False"
        Me.txt_Vacancy.Appearance = Appearance16
        Me.txt_Vacancy.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Vacancy.Location = New System.Drawing.Point(110, 38)
        Me.txt_Vacancy.Name = "txt_Vacancy"
        Me.txt_Vacancy.Size = New System.Drawing.Size(172, 17)
        Me.txt_Vacancy.TabIndex = 5
        Me.txt_Vacancy.Text = "UltraTextEditor2"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(28, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 14)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Vacancy Code"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_VacCode
        '
        Appearance17.FontData.BoldAsString = "False"
        Me.txt_VacCode.Appearance = Appearance17
        Me.txt_VacCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_VacCode.Location = New System.Drawing.Point(110, 14)
        Me.txt_VacCode.Name = "txt_VacCode"
        Me.txt_VacCode.Size = New System.Drawing.Size(172, 17)
        Me.txt_VacCode.TabIndex = 3
        Me.txt_VacCode.Text = "UltraTextEditor2"
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
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 414)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(521, 38)
        Me.UltraPanel2.TabIndex = 10
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(272, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 38)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(355, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 38)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOk.Location = New System.Drawing.Point(438, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(83, 38)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        '
        'frmVacancy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Vacancy Details"
        Me.ClientSize = New System.Drawing.Size(521, 452)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.UltraPanel4)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Name = "frmVacancy"
        Me.Text = "Vacancy Details"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGridSkill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.UltraPanel4.ClientArea.ResumeLayout(False)
        Me.UltraPanel4.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_IsCompleted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NumPers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_depid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Vacancy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_VacCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGridSkill As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraPanel4 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btn_AddSkill As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn_DeleteSkill As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Remark As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chk_IsCompleted As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txt_NumPers As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dt_Dated As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblDate As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents cmb_depid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txt_Vacancy As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents txt_VacCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
End Class
