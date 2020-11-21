<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalComponent
    Inherits risersoft.shared.win.frmMax

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
        Me.components = New System.ComponentModel.Container()
        Me.lbl_componentCode = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.lbl_componentName = New Infragistics.Win.Misc.UltraLabel()
        Me.lbl_Behave = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_componentCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_componentName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btn_Save = New Infragistics.Win.Misc.UltraButton()
        Me.cmb_behave = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.btn_Ok = New Infragistics.Win.Misc.UltraButton()
        Me.btn_cancel = New Infragistics.Win.Misc.UltraButton()
        CType(Me.dsForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_componentCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_componentName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_behave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_componentCode
        '
        Me.lbl_componentCode.Location = New System.Drawing.Point(70, 27)
        Me.lbl_componentCode.Name = "lbl_componentCode"
        Me.lbl_componentCode.Size = New System.Drawing.Size(100, 25)
        Me.lbl_componentCode.TabIndex = 0
        Me.lbl_componentCode.Text = "Component Code"
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'lbl_componentName
        '
        Me.lbl_componentName.Location = New System.Drawing.Point(70, 58)
        Me.lbl_componentName.Name = "lbl_componentName"
        Me.lbl_componentName.Size = New System.Drawing.Size(100, 25)
        Me.lbl_componentName.TabIndex = 1
        Me.lbl_componentName.Text = "Component Name"
        '
        'lbl_Behave
        '
        Me.lbl_Behave.Location = New System.Drawing.Point(70, 99)
        Me.lbl_Behave.Name = "lbl_Behave"
        Me.lbl_Behave.Size = New System.Drawing.Size(100, 22)
        Me.lbl_Behave.TabIndex = 2
        Me.lbl_Behave.Text = "Behave"
        '
        'txt_componentCode
        '
        Me.txt_componentCode.Location = New System.Drawing.Point(176, 23)
        Me.txt_componentCode.Name = "txt_componentCode"
        Me.txt_componentCode.Size = New System.Drawing.Size(113, 21)
        Me.txt_componentCode.TabIndex = 3
        '
        'txt_componentName
        '
        Me.txt_componentName.Location = New System.Drawing.Point(176, 60)
        Me.txt_componentName.Name = "txt_componentName"
        Me.txt_componentName.Size = New System.Drawing.Size(113, 21)
        Me.txt_componentName.TabIndex = 4
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(290, 168)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(75, 25)
        Me.btn_Save.TabIndex = 6
        Me.btn_Save.Text = "Save"
        '
        'cmb_behave
        '
        Me.cmb_behave.Location = New System.Drawing.Point(176, 100)
        Me.cmb_behave.Name = "cmb_behave"
        Me.cmb_behave.Size = New System.Drawing.Size(113, 21)
        Me.cmb_behave.TabIndex = 7
        Me.cmb_behave.Text = "Select"
        '
        'btn_Ok
        '
        Me.btn_Ok.Location = New System.Drawing.Point(116, 168)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(75, 25)
        Me.btn_Ok.TabIndex = 8
        Me.btn_Ok.Text = "OK"
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(197, 168)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 25)
        Me.btn_cancel.TabIndex = 9
        Me.btn_cancel.Text = "Cancel"
        '
        'frmSalComponent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "frmSalComponent"
        Me.ClientSize = New System.Drawing.Size(425, 206)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_Ok)
        Me.Controls.Add(Me.cmb_behave)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.txt_componentName)
        Me.Controls.Add(Me.txt_componentCode)
        Me.Controls.Add(Me.lbl_Behave)
        Me.Controls.Add(Me.lbl_componentName)
        Me.Controls.Add(Me.lbl_componentCode)
        Me.Name = "frmSalComponent"
        Me.Text = "frmSalComponent"
        CType(Me.dsForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsCombo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_componentCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_componentName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_behave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_componentCode As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents btn_Save As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txt_componentName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_componentCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lbl_Behave As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbl_componentName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmb_behave As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btn_cancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn_Ok As Infragistics.Win.Misc.UltraButton
End Class
