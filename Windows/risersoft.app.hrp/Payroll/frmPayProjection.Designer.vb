Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Partial Class frmPayProjection
	Inherits frmMax

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        myView.SetGrid(Me.UGridPayProj)
        Me.InitForm()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UGridPayProj As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dt_targetdate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dt_startdate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txt_IncFreq As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmb_CompanyID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UGridPayProj = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridProposal = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_UnEnforce = New Infragistics.Win.Misc.UltraButton()
        Me.btn_Enforce = New Infragistics.Win.Misc.UltraButton()
        Me.btn_Delete = New Infragistics.Win.Misc.UltraButton()
        Me.btn_Edit = New Infragistics.Win.Misc.UltraButton()
        Me.btn_Add = New Infragistics.Win.Misc.UltraButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmb_CompanyID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.txt_IncFreq = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.dt_startdate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.dt_targetdate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UGridPayProj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGridProposal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cmb_CompanyID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_IncFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_startdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_targetdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UGridPayProj)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(665, 421)
        '
        'UGridPayProj
        '
        Me.UGridPayProj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UGridPayProj.Location = New System.Drawing.Point(0, 0)
        Me.UGridPayProj.Name = "UGridPayProj"
        Me.UGridPayProj.Size = New System.Drawing.Size(665, 421)
        Me.UGridPayProj.TabIndex = 0
        Me.UGridPayProj.Text = "Pay Projection Employee"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGridProposal)
        Me.UltraTabPageControl2.Controls.Add(Me.Panel3)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(665, 421)
        '
        'UltraGridProposal
        '
        Me.UltraGridProposal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridProposal.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridProposal.Name = "UltraGridProposal"
        Me.UltraGridProposal.Size = New System.Drawing.Size(665, 387)
        Me.UltraGridProposal.TabIndex = 0
        Me.UltraGridProposal.Text = "Pay Proposal"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btn_UnEnforce)
        Me.Panel3.Controls.Add(Me.btn_Enforce)
        Me.Panel3.Controls.Add(Me.btn_Delete)
        Me.Panel3.Controls.Add(Me.btn_Edit)
        Me.Panel3.Controls.Add(Me.btn_Add)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 387)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(665, 34)
        Me.Panel3.TabIndex = 9
        '
        'btn_UnEnforce
        '
        Appearance49.FontData.BoldAsString = "True"
        Me.btn_UnEnforce.Appearance = Appearance49
        Me.btn_UnEnforce.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_UnEnforce.Location = New System.Drawing.Point(61, 0)
        Me.btn_UnEnforce.Name = "btn_UnEnforce"
        Me.btn_UnEnforce.Size = New System.Drawing.Size(72, 34)
        Me.btn_UnEnforce.TabIndex = 1
        Me.btn_UnEnforce.Text = "UnEnforce"
        '
        'btn_Enforce
        '
        Appearance16.FontData.BoldAsString = "True"
        Me.btn_Enforce.Appearance = Appearance16
        Me.btn_Enforce.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Enforce.Location = New System.Drawing.Point(0, 0)
        Me.btn_Enforce.Name = "btn_Enforce"
        Me.btn_Enforce.Size = New System.Drawing.Size(61, 34)
        Me.btn_Enforce.TabIndex = 0
        Me.btn_Enforce.Text = "Enforce"
        '
        'btn_Delete
        '
        Appearance17.FontData.BoldAsString = "True"
        Me.btn_Delete.Appearance = Appearance17
        Me.btn_Delete.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Delete.Location = New System.Drawing.Point(497, 0)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(56, 34)
        Me.btn_Delete.TabIndex = 2
        Me.btn_Delete.Text = "Delete"
        '
        'btn_Edit
        '
        Appearance50.FontData.BoldAsString = "True"
        Me.btn_Edit.Appearance = Appearance50
        Me.btn_Edit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Edit.Location = New System.Drawing.Point(553, 0)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(56, 34)
        Me.btn_Edit.TabIndex = 3
        Me.btn_Edit.Text = "Edit"
        '
        'btn_Add
        '
        Appearance51.FontData.BoldAsString = "True"
        Me.btn_Add.Appearance = Appearance51
        Me.btn_Add.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Add.Location = New System.Drawing.Point(609, 0)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(56, 34)
        Me.btn_Add.TabIndex = 4
        Me.btn_Add.Text = "Add"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 538)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(669, 44)
        Me.Panel4.TabIndex = 1
        '
        'btnSave
        '
        Appearance13.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance13
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(405, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 44)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance14.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance14
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(493, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 44)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance15.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance15
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(581, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 44)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmb_CompanyID)
        Me.Panel1.Controls.Add(Me.txt_IncFreq)
        Me.Panel1.Controls.Add(Me.UltraLabel3)
        Me.Panel1.Controls.Add(Me.UltraLabel2)
        Me.Panel1.Controls.Add(Me.dt_startdate)
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Controls.Add(Me.dt_targetdate)
        Me.Panel1.Controls.Add(Me.UltraLabel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(669, 91)
        Me.Panel1.TabIndex = 0
        '
        'cmb_CompanyID
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmb_CompanyID.DisplayLayout.Appearance = Appearance1
        Me.cmb_CompanyID.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmb_CompanyID.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_CompanyID.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_CompanyID.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.cmb_CompanyID.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_CompanyID.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.cmb_CompanyID.DisplayLayout.MaxColScrollRegions = 1
        Me.cmb_CompanyID.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmb_CompanyID.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmb_CompanyID.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.cmb_CompanyID.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmb_CompanyID.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.cmb_CompanyID.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmb_CompanyID.DisplayLayout.Override.CellAppearance = Appearance8
        Me.cmb_CompanyID.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cmb_CompanyID.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_CompanyID.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.cmb_CompanyID.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.cmb_CompanyID.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmb_CompanyID.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.cmb_CompanyID.DisplayLayout.Override.RowAppearance = Appearance11
        Me.cmb_CompanyID.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_CompanyID.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.cmb_CompanyID.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmb_CompanyID.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmb_CompanyID.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmb_CompanyID.Location = New System.Drawing.Point(104, 8)
        Me.cmb_CompanyID.Name = "cmb_CompanyID"
        Me.cmb_CompanyID.Size = New System.Drawing.Size(220, 22)
        Me.cmb_CompanyID.TabIndex = 1
        Me.cmb_CompanyID.Text = "UltraCombo1"
        '
        'txt_IncFreq
        '
        Me.txt_IncFreq.Location = New System.Drawing.Point(468, 8)
        Me.txt_IncFreq.Name = "txt_IncFreq"
        Me.txt_IncFreq.Size = New System.Drawing.Size(189, 21)
        Me.txt_IncFreq.TabIndex = 7
        '
        'UltraLabel3
        '
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(342, 11)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(111, 14)
        Me.UltraLabel3.TabIndex = 6
        Me.UltraLabel3.Text = "Increment Frequency"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(34, 68)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(55, 14)
        Me.UltraLabel2.TabIndex = 4
        Me.UltraLabel2.Text = "Start Date"
        '
        'dt_startdate
        '
        Me.dt_startdate.Location = New System.Drawing.Point(104, 65)
        Me.dt_startdate.Name = "dt_startdate"
        Me.dt_startdate.Size = New System.Drawing.Size(220, 21)
        Me.dt_startdate.TabIndex = 5
        '
        'UltraLabel1
        '
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(25, 41)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(64, 14)
        Me.UltraLabel1.TabIndex = 2
        Me.UltraLabel1.Text = "Target Date"
        '
        'dt_targetdate
        '
        Me.dt_targetdate.Location = New System.Drawing.Point(104, 38)
        Me.dt_targetdate.Name = "dt_targetdate"
        Me.dt_targetdate.Size = New System.Drawing.Size(220, 21)
        Me.dt_targetdate.TabIndex = 3
        '
        'UltraLabel4
        '
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(36, 11)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(53, 14)
        Me.UltraLabel4.TabIndex = 0
        Me.UltraLabel4.Text = "Company"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(669, 447)
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Employees"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Proposal"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(665, 421)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraTabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 91)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(669, 447)
        Me.Panel2.TabIndex = 17
        '
        'frmPayProjection
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Pay Projection"
        Me.ClientSize = New System.Drawing.Size(669, 582)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPayProjection"
        Me.Text = "Pay Projection"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UGridPayProj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGridProposal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmb_CompanyID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_IncFreq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_startdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_targetdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGridProposal As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btn_Delete As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn_Edit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn_Add As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn_UnEnforce As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn_Enforce As Infragistics.Win.Misc.UltraButton

#End Region
End Class

