<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInterviewFBUser
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
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGridFBSkill = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_InterviewerName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Rating = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lbl_inprod = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Remark = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.txt_FullName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGridFBSkill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_InterviewerName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Rating, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.txt_FullName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGridFBSkill
        '
        Me.UltraGridFBSkill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridFBSkill.Location = New System.Drawing.Point(0, 127)
        Me.UltraGridFBSkill.Name = "UltraGridFBSkill"
        Me.UltraGridFBSkill.Size = New System.Drawing.Size(484, 217)
        Me.UltraGridFBSkill.TabIndex = 5
        Me.UltraGridFBSkill.Text = "Report"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_FullName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_InterviewerName)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txt_Rating)
        Me.Panel1.Controls.Add(Me.lbl_inprod)
        Me.Panel1.Controls.Add(Me.UltraLabel5)
        Me.Panel1.Controls.Add(Me.txt_Remark)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 127)
        Me.Panel1.TabIndex = 4
        '
        'txt_InterviewerName
        '
        Me.txt_InterviewerName.Location = New System.Drawing.Point(110, 8)
        Me.txt_InterviewerName.Name = "txt_InterviewerName"
        Me.txt_InterviewerName.ReadOnly = True
        Me.txt_InterviewerName.Size = New System.Drawing.Size(214, 21)
        Me.txt_InterviewerName.TabIndex = 55
        Me.txt_InterviewerName.Text = "UltraTextEditor1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Interviewer Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Rating
        '
        Me.txt_Rating.Location = New System.Drawing.Point(110, 35)
        Me.txt_Rating.Name = "txt_Rating"
        Me.txt_Rating.Size = New System.Drawing.Size(214, 21)
        Me.txt_Rating.TabIndex = 1
        '
        'lbl_inprod
        '
        Appearance16.TextHAlignAsString = "Right"
        Me.lbl_inprod.Appearance = Appearance16
        Me.lbl_inprod.AutoSize = True
        Me.lbl_inprod.Location = New System.Drawing.Point(67, 37)
        Me.lbl_inprod.Name = "lbl_inprod"
        Me.lbl_inprod.Size = New System.Drawing.Size(37, 14)
        Me.lbl_inprod.TabIndex = 0
        Me.lbl_inprod.Text = "Rating"
        '
        'UltraLabel5
        '
        Appearance17.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance17
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(59, 66)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(44, 14)
        Me.UltraLabel5.TabIndex = 2
        Me.UltraLabel5.Text = "Remark"
        '
        'txt_Remark
        '
        Me.txt_Remark.Location = New System.Drawing.Point(110, 62)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(308, 21)
        Me.txt_Remark.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 344)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(484, 40)
        Me.Panel4.TabIndex = 35
        '
        'btnSave
        '
        Appearance18.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance18
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(220, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 40)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Save"
        '
        'btnCancel
        '
        Appearance19.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance19
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(308, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOK
        '
        Appearance20.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance20
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(396, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 40)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&OK"
        '
        'txt_FullName
        '
        Me.txt_FullName.Location = New System.Drawing.Point(110, 89)
        Me.txt_FullName.Name = "txt_FullName"
        Me.txt_FullName.ReadOnly = True
        Me.txt_FullName.Size = New System.Drawing.Size(214, 21)
        Me.txt_FullName.TabIndex = 57
        Me.txt_FullName.Text = "UltraTextEditor1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 14)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Candidate Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmInterviewFBUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Interview FB User"
        Me.ClientSize = New System.Drawing.Size(484, 384)
        Me.Controls.Add(Me.UltraGridFBSkill)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmInterviewFBUser"
        Me.Text = "Interview FB User"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGridFBSkill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txt_InterviewerName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Rating, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.txt_FullName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridFBSkill As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents txt_Rating As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lbl_inprod As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Remark As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txt_InterviewerName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txt_FullName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
