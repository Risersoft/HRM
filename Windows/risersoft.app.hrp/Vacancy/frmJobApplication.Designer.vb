<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobApplication
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
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_HRAgencyID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Remark = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Result = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_VacancyID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.dt_Dated = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmb_PersonID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.cmb_HRAgencyID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Result, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_VacancyID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_PersonID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmb_HRAgencyID)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Remark)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel5)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Result)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmb_VacancyID)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.dt_Dated)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblDate)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label7)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmb_PersonID)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(371, 213)
        Me.UltraPanel1.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 14)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "HR Agency"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_HRAgencyID
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.cmb_HRAgencyID.Appearance = Appearance1
        Me.cmb_HRAgencyID.DataMember = "att"
        Me.cmb_HRAgencyID.DisplayMember = "descrip"
        Me.cmb_HRAgencyID.Location = New System.Drawing.Point(96, 112)
        Me.cmb_HRAgencyID.Name = "cmb_HRAgencyID"
        Me.cmb_HRAgencyID.Size = New System.Drawing.Size(227, 22)
        Me.cmb_HRAgencyID.TabIndex = 25
        Me.cmb_HRAgencyID.ValueMember = "employeeid"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(13, 182)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(44, 14)
        Me.UltraLabel1.TabIndex = 22
        Me.UltraLabel1.Text = "Remark"
        '
        'txt_Remark
        '
        Me.txt_Remark.Location = New System.Drawing.Point(62, 179)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(276, 21)
        Me.txt_Remark.TabIndex = 23
        '
        'UltraLabel5
        '
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(21, 150)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel5.TabIndex = 20
        Me.UltraLabel5.Text = "Result"
        '
        'txt_Result
        '
        Me.txt_Result.Location = New System.Drawing.Point(63, 146)
        Me.txt_Result.Name = "txt_Result"
        Me.txt_Result.Size = New System.Drawing.Size(276, 21)
        Me.txt_Result.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Vacancy Details"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_VacancyID
        '
        Appearance2.FontData.BoldAsString = "False"
        Me.cmb_VacancyID.Appearance = Appearance2
        Me.cmb_VacancyID.DataMember = "att"
        Me.cmb_VacancyID.DisplayMember = "descrip"
        Me.cmb_VacancyID.Location = New System.Drawing.Point(97, 79)
        Me.cmb_VacancyID.Name = "cmb_VacancyID"
        Me.cmb_VacancyID.Size = New System.Drawing.Size(227, 22)
        Me.cmb_VacancyID.TabIndex = 11
        Me.cmb_VacancyID.ValueMember = "employeeid"
        '
        'dt_Dated
        '
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.FontData.ItalicAsString = "False"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 8.25!
        Appearance3.FontData.StrikeoutAsString = "False"
        Appearance3.FontData.UnderlineAsString = "False"
        Me.dt_Dated.Appearance = Appearance3
        Me.dt_Dated.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_Dated.FormatString = "dddd dd MMM yyyy"
        Me.dt_Dated.Location = New System.Drawing.Point(97, 48)
        Me.dt_Dated.Name = "dt_Dated"
        Me.dt_Dated.NullText = "Not Defined"
        Me.dt_Dated.Size = New System.Drawing.Size(227, 21)
        Me.dt_Dated.TabIndex = 9
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(56, 52)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(35, 14)
        Me.lblDate.TabIndex = 8
        Me.lblDate.Text = "Dated"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 14)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Person Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_PersonID
        '
        Appearance4.FontData.BoldAsString = "False"
        Me.cmb_PersonID.Appearance = Appearance4
        Me.cmb_PersonID.DataMember = "att"
        Me.cmb_PersonID.DisplayMember = "descrip"
        Me.cmb_PersonID.Location = New System.Drawing.Point(97, 16)
        Me.cmb_PersonID.Name = "cmb_PersonID"
        Me.cmb_PersonID.Size = New System.Drawing.Size(227, 22)
        Me.cmb_PersonID.TabIndex = 7
        Me.cmb_PersonID.ValueMember = "employeeid"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 213)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(371, 52)
        Me.Panel4.TabIndex = 57
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance5
        Me.btnCancel.Location = New System.Drawing.Point(172, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 34)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance6
        Me.btnOK.Location = New System.Drawing.Point(268, 9)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 34)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'frmJobApplication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Job Application"
        Me.ClientSize = New System.Drawing.Size(371, 265)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "frmJobApplication"
        Me.Text = "Job Application"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.cmb_HRAgencyID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Result, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_VacancyID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_PersonID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents cmb_PersonID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents dt_Dated As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblDate As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cmb_VacancyID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Remark As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Result As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cmb_HRAgencyID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
End Class
