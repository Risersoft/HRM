﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCourse
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
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
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
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridSkill = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPanel4 = New Infragistics.Win.Misc.UltraPanel()
        Me.btn_AddSkill = New Infragistics.Win.Misc.UltraButton()
        Me.btn_DeleteSkill = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_CourseName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_CourseCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGridSkill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel4.ClientArea.SuspendLayout()
        Me.UltraPanel4.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.txt_CourseName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CourseCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 71)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(521, 274)
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
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(517, 248)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGridSkill)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(517, 248)
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
        Me.UltraGridSkill.Size = New System.Drawing.Size(517, 248)
        Me.UltraGridSkill.TabIndex = 0
        Me.UltraGridSkill.Text = "UltraGrid1"
        '
        'UltraPanel4
        '
        '
        'UltraPanel4.ClientArea
        '
        Me.UltraPanel4.ClientArea.Controls.Add(Me.btn_AddSkill)
        Me.UltraPanel4.ClientArea.Controls.Add(Me.btn_DeleteSkill)
        Me.UltraPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel4.Location = New System.Drawing.Point(0, 345)
        Me.UltraPanel4.Name = "UltraPanel4"
        Me.UltraPanel4.Size = New System.Drawing.Size(521, 27)
        Me.UltraPanel4.TabIndex = 12
        '
        'btn_AddSkill
        '
        Me.btn_AddSkill.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_AddSkill.Location = New System.Drawing.Point(374, 0)
        Me.btn_AddSkill.Name = "btn_AddSkill"
        Me.btn_AddSkill.Size = New System.Drawing.Size(77, 27)
        Me.btn_AddSkill.TabIndex = 2
        Me.btn_AddSkill.Tag = "Add"
        Me.btn_AddSkill.Text = "Add"
        '
        'btn_DeleteSkill
        '
        Me.btn_DeleteSkill.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_DeleteSkill.Location = New System.Drawing.Point(451, 0)
        Me.btn_DeleteSkill.Name = "btn_DeleteSkill"
        Me.btn_DeleteSkill.Size = New System.Drawing.Size(70, 27)
        Me.btn_DeleteSkill.TabIndex = 0
        Me.btn_DeleteSkill.Text = "Delete"
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_CourseName)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label10)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_CourseCode)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(521, 71)
        Me.UltraPanel1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Course Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_CourseName
        '
        Appearance13.FontData.BoldAsString = "False"
        Me.txt_CourseName.Appearance = Appearance13
        Me.txt_CourseName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CourseName.Location = New System.Drawing.Point(110, 40)
        Me.txt_CourseName.Name = "txt_CourseName"
        Me.txt_CourseName.Size = New System.Drawing.Size(172, 17)
        Me.txt_CourseName.TabIndex = 5
        Me.txt_CourseName.Text = "UltraTextEditor2"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Course Code"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_CourseCode
        '
        Appearance14.FontData.BoldAsString = "False"
        Me.txt_CourseCode.Appearance = Appearance14
        Me.txt_CourseCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CourseCode.Location = New System.Drawing.Point(110, 13)
        Me.txt_CourseCode.Name = "txt_CourseCode"
        Me.txt_CourseCode.Size = New System.Drawing.Size(172, 17)
        Me.txt_CourseCode.TabIndex = 3
        Me.txt_CourseCode.Text = "UltraTextEditor2"
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
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 372)
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
        'frmCourse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 410)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.UltraPanel4)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Name = "frmCourse"
        Me.Text = "Course"
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGridSkill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel4.ClientArea.ResumeLayout(False)
        Me.UltraPanel4.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.txt_CourseName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CourseCode, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txt_CourseName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents txt_CourseCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
End Class
