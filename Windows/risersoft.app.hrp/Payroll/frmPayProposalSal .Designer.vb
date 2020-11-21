Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPayProposalSal
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_Gross As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_Target As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents lblTarget As System.Windows.Forms.Label
    Friend WithEvents lblDep As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblArbit As System.Windows.Forms.Label
    Friend WithEvents TwoGrids As risersoft.shared.win.AddRemove
    Friend WithEvents btn_Print As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_Define = New Infragistics.Win.Misc.UltraButton()
        Me.btn_Print = New Infragistics.Win.Misc.UltraButton()
        Me.txt_Gross = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_Target = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblGross = New System.Windows.Forms.Label()
        Me.lblTarget = New System.Windows.Forms.Label()
        Me.lblDep = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblArbit = New System.Windows.Forms.Label()
        Me.TwoGrids = New risersoft.[shared].win.AddRemove()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_Gross, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Target, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 538)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(546, 44)
        Me.Panel4.TabIndex = 2
        '
        'btnSave
        '
        Appearance1.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(282, 0)
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
        Me.btnCancel.Location = New System.Drawing.Point(370, 0)
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
        Me.btnOK.Location = New System.Drawing.Point(458, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 44)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Define)
        Me.Panel1.Controls.Add(Me.btn_Print)
        Me.Panel1.Controls.Add(Me.txt_Gross)
        Me.Panel1.Controls.Add(Me.txt_Target)
        Me.Panel1.Controls.Add(Me.lblGross)
        Me.Panel1.Controls.Add(Me.lblTarget)
        Me.Panel1.Controls.Add(Me.lblDep)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblCode)
        Me.Panel1.Controls.Add(Me.lblArbit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 128)
        Me.Panel1.TabIndex = 0
        '
        'btn_Define
        '
        Me.btn_Define.Location = New System.Drawing.Point(454, 101)
        Me.btn_Define.Name = "btn_Define"
        Me.btn_Define.Size = New System.Drawing.Size(80, 24)
        Me.btn_Define.TabIndex = 10
        Me.btn_Define.Text = "Define"
        '
        'btn_Print
        '
        Me.btn_Print.Location = New System.Drawing.Point(456, 8)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(80, 24)
        Me.btn_Print.TabIndex = 11
        Me.btn_Print.Text = "Print Form"
        '
        'txt_Gross
        '
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.FontData.ItalicAsString = "False"
        Appearance2.FontData.Name = "Arial"
        Appearance2.FontData.SizeInPoints = 8.25!
        Appearance2.FontData.StrikeoutAsString = "False"
        Appearance2.FontData.UnderlineAsString = "False"
        Me.txt_Gross.Appearance = Appearance2
        Me.txt_Gross.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Gross.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Gross.Location = New System.Drawing.Point(384, 56)
        Me.txt_Gross.Name = "txt_Gross"
        Me.txt_Gross.Size = New System.Drawing.Size(152, 17)
        Me.txt_Gross.TabIndex = 7
        Me.txt_Gross.Text = "UltraTextEditor9"
        '
        'txt_Target
        '
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.FontData.ItalicAsString = "False"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 8.25!
        Appearance3.FontData.StrikeoutAsString = "False"
        Appearance3.FontData.UnderlineAsString = "False"
        Me.txt_Target.Appearance = Appearance3
        Me.txt_Target.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Target.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Target.Location = New System.Drawing.Point(384, 80)
        Me.txt_Target.Name = "txt_Target"
        Me.txt_Target.Size = New System.Drawing.Size(152, 17)
        Me.txt_Target.TabIndex = 9
        Me.txt_Target.Text = "UltraTextEditor9"
        '
        'lblGross
        '
        Me.lblGross.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGross.Location = New System.Drawing.Point(211, 57)
        Me.lblGross.Name = "lblGross"
        Me.lblGross.Size = New System.Drawing.Size(160, 16)
        Me.lblGross.TabIndex = 6
        Me.lblGross.Text = "Proposed Gross Salary"
        Me.lblGross.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblTarget
        '
        Me.lblTarget.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarget.Location = New System.Drawing.Point(83, 80)
        Me.lblTarget.Name = "lblTarget"
        Me.lblTarget.Size = New System.Drawing.Size(288, 16)
        Me.lblTarget.TabIndex = 8
        Me.lblTarget.Text = "Target"
        Me.lblTarget.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblDep
        '
        Me.lblDep.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDep.Location = New System.Drawing.Point(64, 32)
        Me.lblDep.Name = "lblDep"
        Me.lblDep.Size = New System.Drawing.Size(144, 16)
        Me.lblDep.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Dep."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.Location = New System.Drawing.Point(64, 8)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(200, 16)
        Me.lblName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblCode
        '
        Me.lblCode.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCode.Location = New System.Drawing.Point(64, 56)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(141, 16)
        Me.lblCode.TabIndex = 5
        '
        'lblArbit
        '
        Me.lblArbit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArbit.Location = New System.Drawing.Point(8, 56)
        Me.lblArbit.Name = "lblArbit"
        Me.lblArbit.Size = New System.Drawing.Size(48, 16)
        Me.lblArbit.TabIndex = 4
        Me.lblArbit.Text = "Code"
        Me.lblArbit.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'TwoGrids
        '
        Me.TwoGrids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TwoGrids.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TwoGrids.Location = New System.Drawing.Point(0, 128)
        Me.TwoGrids.Mode = 2
        Me.TwoGrids.Name = "TwoGrids"
        Me.TwoGrids.Size = New System.Drawing.Size(546, 410)
        Me.TwoGrids.TabIndex = 1
        '
        'frmPayProposalSal
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Pay Proposal"
        Me.ClientSize = New System.Drawing.Size(546, 582)
        Me.Controls.Add(Me.TwoGrids)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPayProposalSal"
        Me.Text = "Pay Proposal"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txt_Gross, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Target, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Define As Infragistics.Win.Misc.UltraButton

#End Region
End Class

