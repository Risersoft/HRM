Imports ug = Infragistics.Win.UltraWinGrid
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Partial Class frmSMWild
	Inherits frmMax
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.TwoGrids.myView1.SetGrid(Me.TwoGrids.UltraGrid1)
        Me.TwoGrids.myView2.SetGrid(Me.TwoGrids.UltraGrid2)
        Me.TwoGrids.PictureBox1.Visible = True
        Me.TwoGrids.Panel1.Visible = False
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
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraButton2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraButton3 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraButton4 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents TwoGrids As AddRemove
    Friend WithEvents CheckMinSal As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmb_Select = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.CheckMinSal = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraButton4 = New Infragistics.Win.Misc.UltraButton()
        Me.UltraButton3 = New Infragistics.Win.Misc.UltraButton()
        Me.UltraButton2 = New Infragistics.Win.Misc.UltraButton()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        Me.TwoGrids = New risersoft.[shared].win.AddRemove()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cmb_Select, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckMinSal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 508)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(784, 42)
        Me.Panel4.TabIndex = 2
        '
        'btnSave
        '
        Appearance1.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(520, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 42)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Calculate And Save"
        '
        'btnCancel
        '
        Appearance9.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance9
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(608, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 42)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance2.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance2
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(696, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 42)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmb_Select)
        Me.Panel1.Controls.Add(Me.CheckMinSal)
        Me.Panel1.Controls.Add(Me.UltraButton4)
        Me.Panel1.Controls.Add(Me.UltraButton3)
        Me.Panel1.Controls.Add(Me.UltraButton2)
        Me.Panel1.Controls.Add(Me.UltraButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 144)
        Me.Panel1.TabIndex = 0
        '
        'cmb_Select
        '
        Me.cmb_Select.Location = New System.Drawing.Point(131, 57)
        Me.cmb_Select.Name = "cmb_Select"
        Me.cmb_Select.Size = New System.Drawing.Size(220, 21)
        Me.cmb_Select.TabIndex = 0
        '
        'CheckMinSal
        '
        Appearance8.TextHAlignAsString = "Left"
        Me.CheckMinSal.Appearance = Appearance8
        Me.CheckMinSal.Location = New System.Drawing.Point(131, 84)
        Me.CheckMinSal.Name = "CheckMinSal"
        Me.CheckMinSal.Size = New System.Drawing.Size(220, 16)
        Me.CheckMinSal.TabIndex = 1
        Me.CheckMinSal.Text = "Listed figures are minimum salary"
        '
        'UltraButton4
        '
        Me.UltraButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.FontData.BoldAsString = "True"
        Me.UltraButton4.Appearance = Appearance4
        Me.UltraButton4.Location = New System.Drawing.Point(640, 48)
        Me.UltraButton4.Name = "UltraButton4"
        Me.UltraButton4.Size = New System.Drawing.Size(136, 40)
        Me.UltraButton4.TabIndex = 3
        Me.UltraButton4.Text = "UnCheck All"
        '
        'UltraButton3
        '
        Me.UltraButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.FontData.BoldAsString = "True"
        Me.UltraButton3.Appearance = Appearance5
        Me.UltraButton3.Location = New System.Drawing.Point(488, 48)
        Me.UltraButton3.Name = "UltraButton3"
        Me.UltraButton3.Size = New System.Drawing.Size(136, 40)
        Me.UltraButton3.TabIndex = 2
        Me.UltraButton3.Text = "Check All"
        '
        'UltraButton2
        '
        Me.UltraButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.FontData.BoldAsString = "True"
        Me.UltraButton2.Appearance = Appearance6
        Me.UltraButton2.Location = New System.Drawing.Point(488, 96)
        Me.UltraButton2.Name = "UltraButton2"
        Me.UltraButton2.Size = New System.Drawing.Size(136, 40)
        Me.UltraButton2.TabIndex = 4
        Me.UltraButton2.Text = "Check Casual Employees"
        '
        'UltraButton1
        '
        Me.UltraButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.FontData.BoldAsString = "True"
        Me.UltraButton1.Appearance = Appearance7
        Me.UltraButton1.Location = New System.Drawing.Point(640, 96)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(136, 40)
        Me.UltraButton1.TabIndex = 5
        Me.UltraButton1.Text = "Uncheck Casual Employees"
        '
        'TwoGrids
        '
        Me.TwoGrids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TwoGrids.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TwoGrids.Location = New System.Drawing.Point(0, 144)
        Me.TwoGrids.Mode = 0
        Me.TwoGrids.Name = "TwoGrids"
        Me.TwoGrids.Size = New System.Drawing.Size(784, 364)
        Me.TwoGrids.TabIndex = 1
        '
        'frmSMWild
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Make Wild Card Salary Changes"
        Me.ClientSize = New System.Drawing.Size(784, 550)
        Me.Controls.Add(Me.TwoGrids)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSMWild"
        Me.Text = "Make Wild Card Salary Changes"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmb_Select, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckMinSal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_Select As Infragistics.Win.UltraWinEditors.UltraComboEditor

#End Region
End Class

