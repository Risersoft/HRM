<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLeavePolicy
    Inherits risersoft.shared.win.frmMax

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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Remark = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_PolicyName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.dt_Dated = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lbl_date = New Infragistics.Win.Misc.UltraLabel()
        Me.lbl_Company = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnDeleteLvePolicy = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGridAttendTagMaster = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPanel8 = New Infragistics.Win.Misc.UltraPanel()
        Me.btn_Add = New Infragistics.Win.Misc.UltraButton()
        Me.btn_Edit = New Infragistics.Win.Misc.UltraButton()
        Me.btn_Delete = New Infragistics.Win.Misc.UltraButton()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PolicyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        CType(Me.UltraGridAttendTagMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel8.ClientArea.SuspendLayout()
        Me.UltraPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel6)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Remark)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_PolicyName)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.dt_Dated)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lbl_date)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lbl_Company)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(641, 106)
        Me.UltraPanel1.TabIndex = 1
        '
        'UltraLabel6
        '
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(65, 74)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(44, 14)
        Me.UltraLabel6.TabIndex = 22
        Me.UltraLabel6.Text = "Remark"
        '
        'txt_Remark
        '
        Appearance1.TextHAlignAsString = "Left"
        Me.txt_Remark.Appearance = Appearance1
        Me.txt_Remark.Location = New System.Drawing.Point(117, 70)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(361, 21)
        Me.txt_Remark.TabIndex = 23
        '
        'txt_PolicyName
        '
        Me.txt_PolicyName.Location = New System.Drawing.Point(117, 14)
        Me.txt_PolicyName.Name = "txt_PolicyName"
        Me.txt_PolicyName.Size = New System.Drawing.Size(361, 21)
        Me.txt_PolicyName.TabIndex = 5
        '
        'dt_Dated
        '
        Me.dt_Dated.Location = New System.Drawing.Point(118, 41)
        Me.dt_Dated.Name = "dt_Dated"
        Me.dt_Dated.Size = New System.Drawing.Size(165, 21)
        Me.dt_Dated.TabIndex = 3
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Location = New System.Drawing.Point(83, 44)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(28, 14)
        Me.lbl_date.TabIndex = 2
        Me.lbl_date.Text = "Date"
        '
        'lbl_Company
        '
        Me.lbl_Company.AutoSize = True
        Me.lbl_Company.Location = New System.Drawing.Point(44, 18)
        Me.lbl_Company.Name = "lbl_Company"
        Me.lbl_Company.Size = New System.Drawing.Size(68, 14)
        Me.lbl_Company.TabIndex = 0
        Me.lbl_Company.Text = "Policy Name"
        '
        'UltraPanel2
        '
        '
        'UltraPanel2.ClientArea
        '
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnDeleteLvePolicy)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnSave)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnCancel)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnOk)
        Me.UltraPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 370)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(641, 39)
        Me.UltraPanel2.TabIndex = 3
        '
        'btnDeleteLvePolicy
        '
        Appearance2.BackColor = System.Drawing.Color.LightCoral
        Appearance2.FontData.BoldAsString = "True"
        Me.btnDeleteLvePolicy.Appearance = Appearance2
        Me.btnDeleteLvePolicy.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnDeleteLvePolicy.Location = New System.Drawing.Point(0, 0)
        Me.btnDeleteLvePolicy.Name = "btnDeleteLvePolicy"
        Me.btnDeleteLvePolicy.Size = New System.Drawing.Size(88, 39)
        Me.btnDeleteLvePolicy.TabIndex = 13
        Me.btnDeleteLvePolicy.Text = "Delete"
        Me.btnDeleteLvePolicy.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(416, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 39)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(491, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 39)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOk.Location = New System.Drawing.Point(566, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 39)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        '
        'UltraGridAttendTagMaster
        '
        Appearance3.BackColor = System.Drawing.SystemColors.Window
        Appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGridAttendTagMaster.DisplayLayout.Appearance = Appearance3
        Me.UltraGridAttendTagMaster.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGridAttendTagMaster.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridAttendTagMaster.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridAttendTagMaster.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.UltraGridAttendTagMaster.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridAttendTagMaster.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.UltraGridAttendTagMaster.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGridAttendTagMaster.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.CellAppearance = Appearance10
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.RowAppearance = Appearance13
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGridAttendTagMaster.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.UltraGridAttendTagMaster.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGridAttendTagMaster.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGridAttendTagMaster.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.UltraGridAttendTagMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridAttendTagMaster.Location = New System.Drawing.Point(0, 106)
        Me.UltraGridAttendTagMaster.Name = "UltraGridAttendTagMaster"
        Me.UltraGridAttendTagMaster.Size = New System.Drawing.Size(641, 235)
        Me.UltraGridAttendTagMaster.TabIndex = 2
        '
        'UltraPanel8
        '
        '
        'UltraPanel8.ClientArea
        '
        Me.UltraPanel8.ClientArea.Controls.Add(Me.btn_Add)
        Me.UltraPanel8.ClientArea.Controls.Add(Me.btn_Edit)
        Me.UltraPanel8.ClientArea.Controls.Add(Me.btn_Delete)
        Me.UltraPanel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel8.Location = New System.Drawing.Point(0, 341)
        Me.UltraPanel8.Name = "UltraPanel8"
        Me.UltraPanel8.Size = New System.Drawing.Size(641, 29)
        Me.UltraPanel8.TabIndex = 4
        '
        'btn_Add
        '
        Me.btn_Add.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Add.Location = New System.Drawing.Point(422, 0)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(75, 29)
        Me.btn_Add.TabIndex = 0
        Me.btn_Add.Text = "Add"
        '
        'btn_Edit
        '
        Me.btn_Edit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Edit.Location = New System.Drawing.Point(497, 0)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(75, 29)
        Me.btn_Edit.TabIndex = 1
        Me.btn_Edit.Text = "Edit"
        '
        'btn_Delete
        '
        Me.btn_Delete.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Delete.Location = New System.Drawing.Point(572, 0)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(69, 29)
        Me.btn_Delete.TabIndex = 2
        Me.btn_Delete.Text = "Delete"
        '
        'frmLeavePolicy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Leave Policy"
        Me.ClientSize = New System.Drawing.Size(641, 409)
        Me.Controls.Add(Me.UltraGridAttendTagMaster)
        Me.Controls.Add(Me.UltraPanel8)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Name = "frmLeavePolicy"
        Me.Text = "Leave Policy"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PolicyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ResumeLayout(False)
        CType(Me.UltraGridAttendTagMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel8.ClientArea.ResumeLayout(False)
        Me.UltraPanel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents dt_Dated As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lbl_date As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbl_Company As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_PolicyName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGridAttendTagMaster As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Remark As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraPanel8 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btn_Add As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn_Edit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn_Delete As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDeleteLvePolicy As Infragistics.Win.Misc.UltraButton
End Class
