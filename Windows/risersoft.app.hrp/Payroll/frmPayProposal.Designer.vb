Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Partial Class frmPayProposal
	Inherits frmMax

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


        'Me.TwoGrids.myView1.SetGrid(Me.TwoGrids.UltraGrid1)
        'Me.TwoGrids.myView2.SetGrid(Me.TwoGrids.UltraGrid2)
        'Me.TwoGrids.PictureBox1.Visible = True
        'Me.TwoGrids.Panel1.Visible = False
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblArbit As System.Windows.Forms.Label
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmb_UpdateLastPP = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmb_OnlyRM = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmb_CompanyID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_PropRMID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_RefPPID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.dt_EnforceOn = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dt_PropDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblArbit = New System.Windows.Forms.Label()
        Me.UltraGridEmpSal = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cmb_UpdateLastPP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_OnlyRM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_CompanyID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_PropRMID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_RefPPID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_EnforceOn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_PropDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGridEmpSal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 409)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(551, 44)
        Me.Panel4.TabIndex = 2
        '
        'btnSave
        '
        Appearance1.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(287, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 44)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance4.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance4
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(375, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 44)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance5.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance5
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(463, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 44)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmb_UpdateLastPP)
        Me.Panel1.Controls.Add(Me.cmb_OnlyRM)
        Me.Panel1.Controls.Add(Me.cmb_CompanyID)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmb_PropRMID)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmb_RefPPID)
        Me.Panel1.Controls.Add(Me.dt_EnforceOn)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dt_PropDate)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblArbit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(551, 215)
        Me.Panel1.TabIndex = 0
        '
        'cmb_UpdateLastPP
        '
        Me.cmb_UpdateLastPP.Location = New System.Drawing.Point(150, 156)
        Me.cmb_UpdateLastPP.Name = "cmb_UpdateLastPP"
        Me.cmb_UpdateLastPP.Size = New System.Drawing.Size(225, 21)
        Me.cmb_UpdateLastPP.TabIndex = 11
        '
        'cmb_OnlyRM
        '
        Me.cmb_OnlyRM.Location = New System.Drawing.Point(150, 73)
        Me.cmb_OnlyRM.Name = "cmb_OnlyRM"
        Me.cmb_OnlyRM.Size = New System.Drawing.Size(225, 21)
        Me.cmb_OnlyRM.TabIndex = 5
        '
        'cmb_CompanyID
        '
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmb_CompanyID.DisplayLayout.Appearance = Appearance2
        Me.cmb_CompanyID.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmb_CompanyID.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_CompanyID.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_CompanyID.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.cmb_CompanyID.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_CompanyID.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.cmb_CompanyID.DisplayLayout.MaxColScrollRegions = 1
        Me.cmb_CompanyID.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmb_CompanyID.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmb_CompanyID.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.cmb_CompanyID.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmb_CompanyID.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Me.cmb_CompanyID.DisplayLayout.Override.CardAreaAppearance = Appearance37
        Appearance38.BorderColor = System.Drawing.Color.Silver
        Appearance38.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmb_CompanyID.DisplayLayout.Override.CellAppearance = Appearance38
        Me.cmb_CompanyID.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cmb_CompanyID.DisplayLayout.Override.CellPadding = 0
        Appearance39.BackColor = System.Drawing.SystemColors.Control
        Appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance39.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance39.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_CompanyID.DisplayLayout.Override.GroupByRowAppearance = Appearance39
        Appearance40.TextHAlignAsString = "Left"
        Me.cmb_CompanyID.DisplayLayout.Override.HeaderAppearance = Appearance40
        Me.cmb_CompanyID.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmb_CompanyID.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.BorderColor = System.Drawing.Color.Silver
        Me.cmb_CompanyID.DisplayLayout.Override.RowAppearance = Appearance41
        Me.cmb_CompanyID.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance42.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_CompanyID.DisplayLayout.Override.TemplateAddRowAppearance = Appearance42
        Me.cmb_CompanyID.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmb_CompanyID.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmb_CompanyID.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmb_CompanyID.Location = New System.Drawing.Point(150, 16)
        Me.cmb_CompanyID.Name = "cmb_CompanyID"
        Me.cmb_CompanyID.ReadOnly = True
        Me.cmb_CompanyID.Size = New System.Drawing.Size(225, 22)
        Me.cmb_CompanyID.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(74, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Company"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cmb_PropRMID
        '
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmb_PropRMID.DisplayLayout.Appearance = Appearance49
        Me.cmb_PropRMID.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmb_PropRMID.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance50.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_PropRMID.DisplayLayout.GroupByBox.Appearance = Appearance50
        Appearance52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_PropRMID.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance52
        Me.cmb_PropRMID.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance51.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance51.BackColor2 = System.Drawing.SystemColors.Control
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_PropRMID.DisplayLayout.GroupByBox.PromptAppearance = Appearance51
        Me.cmb_PropRMID.DisplayLayout.MaxColScrollRegions = 1
        Me.cmb_PropRMID.DisplayLayout.MaxRowScrollRegions = 1
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Appearance55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmb_PropRMID.DisplayLayout.Override.ActiveCellAppearance = Appearance55
        Appearance58.BackColor = System.Drawing.SystemColors.Highlight
        Appearance58.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmb_PropRMID.DisplayLayout.Override.ActiveRowAppearance = Appearance58
        Me.cmb_PropRMID.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmb_PropRMID.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance60.BackColor = System.Drawing.SystemColors.Window
        Me.cmb_PropRMID.DisplayLayout.Override.CardAreaAppearance = Appearance60
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Appearance56.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmb_PropRMID.DisplayLayout.Override.CellAppearance = Appearance56
        Me.cmb_PropRMID.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cmb_PropRMID.DisplayLayout.Override.CellPadding = 0
        Appearance54.BackColor = System.Drawing.SystemColors.Control
        Appearance54.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance54.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance54.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_PropRMID.DisplayLayout.Override.GroupByRowAppearance = Appearance54
        Appearance53.TextHAlignAsString = "Left"
        Me.cmb_PropRMID.DisplayLayout.Override.HeaderAppearance = Appearance53
        Me.cmb_PropRMID.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmb_PropRMID.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance59.BackColor = System.Drawing.SystemColors.Window
        Appearance59.BorderColor = System.Drawing.Color.Silver
        Me.cmb_PropRMID.DisplayLayout.Override.RowAppearance = Appearance59
        Me.cmb_PropRMID.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance57.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_PropRMID.DisplayLayout.Override.TemplateAddRowAppearance = Appearance57
        Me.cmb_PropRMID.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmb_PropRMID.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmb_PropRMID.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmb_PropRMID.Location = New System.Drawing.Point(150, 184)
        Me.cmb_PropRMID.Name = "cmb_PropRMID"
        Me.cmb_PropRMID.Size = New System.Drawing.Size(225, 22)
        Me.cmb_PropRMID.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Proposed RateMaster"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Last PayPeriod"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cmb_RefPPID
        '
        Appearance44.BackColor = System.Drawing.SystemColors.Window
        Appearance44.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmb_RefPPID.DisplayLayout.Appearance = Appearance44
        Me.cmb_RefPPID.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmb_RefPPID.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance45.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance45.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_RefPPID.DisplayLayout.GroupByBox.Appearance = Appearance45
        Appearance46.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_RefPPID.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance46
        Me.cmb_RefPPID.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance47.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance47.BackColor2 = System.Drawing.SystemColors.Control
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance47.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_RefPPID.DisplayLayout.GroupByBox.PromptAppearance = Appearance47
        Me.cmb_RefPPID.DisplayLayout.MaxColScrollRegions = 1
        Me.cmb_RefPPID.DisplayLayout.MaxRowScrollRegions = 1
        Appearance48.BackColor = System.Drawing.SystemColors.Window
        Appearance48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmb_RefPPID.DisplayLayout.Override.ActiveCellAppearance = Appearance48
        Appearance61.BackColor = System.Drawing.SystemColors.Highlight
        Appearance61.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmb_RefPPID.DisplayLayout.Override.ActiveRowAppearance = Appearance61
        Me.cmb_RefPPID.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmb_RefPPID.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance62.BackColor = System.Drawing.SystemColors.Window
        Me.cmb_RefPPID.DisplayLayout.Override.CardAreaAppearance = Appearance62
        Appearance63.BorderColor = System.Drawing.Color.Silver
        Appearance63.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmb_RefPPID.DisplayLayout.Override.CellAppearance = Appearance63
        Me.cmb_RefPPID.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cmb_RefPPID.DisplayLayout.Override.CellPadding = 0
        Appearance64.BackColor = System.Drawing.SystemColors.Control
        Appearance64.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance64.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance64.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_RefPPID.DisplayLayout.Override.GroupByRowAppearance = Appearance64
        Appearance65.TextHAlignAsString = "Left"
        Me.cmb_RefPPID.DisplayLayout.Override.HeaderAppearance = Appearance65
        Me.cmb_RefPPID.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmb_RefPPID.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance66.BackColor = System.Drawing.SystemColors.Window
        Appearance66.BorderColor = System.Drawing.Color.Silver
        Me.cmb_RefPPID.DisplayLayout.Override.RowAppearance = Appearance66
        Me.cmb_RefPPID.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance67.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_RefPPID.DisplayLayout.Override.TemplateAddRowAppearance = Appearance67
        Me.cmb_RefPPID.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmb_RefPPID.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmb_RefPPID.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmb_RefPPID.Location = New System.Drawing.Point(150, 128)
        Me.cmb_RefPPID.Name = "cmb_RefPPID"
        Me.cmb_RefPPID.Size = New System.Drawing.Size(225, 22)
        Me.cmb_RefPPID.TabIndex = 9
        '
        'dt_EnforceOn
        '
        Me.dt_EnforceOn.Location = New System.Drawing.Point(150, 101)
        Me.dt_EnforceOn.Name = "dt_EnforceOn"
        Me.dt_EnforceOn.ReadOnly = True
        Me.dt_EnforceOn.Size = New System.Drawing.Size(225, 21)
        Me.dt_EnforceOn.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Enforce On"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'dt_PropDate
        '
        Me.dt_PropDate.Location = New System.Drawing.Point(150, 46)
        Me.dt_PropDate.Name = "dt_PropDate"
        Me.dt_PropDate.Size = New System.Drawing.Size(225, 21)
        Me.dt_PropDate.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(102, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Type"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(102, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblArbit
        '
        Me.lblArbit.AutoSize = True
        Me.lblArbit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArbit.Location = New System.Drawing.Point(14, 131)
        Me.lblArbit.Name = "lblArbit"
        Me.lblArbit.Size = New System.Drawing.Size(123, 16)
        Me.lblArbit.TabIndex = 8
        Me.lblArbit.Text = "Refrence PayPeriod"
        Me.lblArbit.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'UltraGridEmpSal
        '
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGridEmpSal.DisplayLayout.Appearance = Appearance25
        Me.UltraGridEmpSal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGridEmpSal.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridEmpSal.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridEmpSal.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.UltraGridEmpSal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridEmpSal.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.UltraGridEmpSal.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGridEmpSal.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UltraGridEmpSal.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UltraGridEmpSal.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.UltraGridEmpSal.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGridEmpSal.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGridEmpSal.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGridEmpSal.DisplayLayout.Override.CellAppearance = Appearance32
        Me.UltraGridEmpSal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGridEmpSal.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridEmpSal.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.UltraGridEmpSal.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.UltraGridEmpSal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UltraGridEmpSal.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.UltraGridEmpSal.DisplayLayout.Override.RowAppearance = Appearance35
        Me.UltraGridEmpSal.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGridEmpSal.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.UltraGridEmpSal.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGridEmpSal.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGridEmpSal.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.UltraGridEmpSal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridEmpSal.Location = New System.Drawing.Point(0, 215)
        Me.UltraGridEmpSal.Margin = New System.Windows.Forms.Padding(0)
        Me.UltraGridEmpSal.Name = "UltraGridEmpSal"
        Me.UltraGridEmpSal.Size = New System.Drawing.Size(551, 194)
        Me.UltraGridEmpSal.TabIndex = 1
        Me.UltraGridEmpSal.Text = "UltraGrid1"
        '
        'frmPayProposal
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Pay Proposal"
        Me.ClientSize = New System.Drawing.Size(551, 453)
        Me.Controls.Add(Me.UltraGridEmpSal)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPayProposal"
        Me.Text = "Pay Proposal"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmb_UpdateLastPP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_OnlyRM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_CompanyID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_PropRMID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_RefPPID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_EnforceOn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_PropDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGridEmpSal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dt_PropDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmb_PropRMID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_RefPPID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents dt_EnforceOn As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_CompanyID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb_OnlyRM As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmb_UpdateLastPP As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraGridEmpSal As Infragistics.Win.UltraWinGrid.UltraGrid

#End Region
End Class

