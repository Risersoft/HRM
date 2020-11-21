<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Partial Class frmTrain
	Inherits frmMax

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_descrip As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_durations As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_place As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dt_dated As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_faculty As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLable4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_topic As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents CtlUpLoad1 As ctlUpLoad
    Friend WithEvents btnDelEmp As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnAddEmp As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
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
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.CtlUpLoad1 = New risersoft.[shared].win.ctlUpLoad()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_descrip = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_durations = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_place = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.dt_dated = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_faculty = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLable4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_topic = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnDelEmp = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddEmp = New Infragistics.Win.Misc.UltraButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_descrip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_durations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_place, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_dated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_faculty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_topic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 438)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(672, 48)
        Me.Panel4.TabIndex = 2
        '
        'btnSave
        '
        Appearance1.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(408, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 48)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance2.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(496, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 48)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance3.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance3
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(584, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 48)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraLabel5)
        Me.Panel1.Controls.Add(Me.CtlUpLoad1)
        Me.Panel1.Controls.Add(Me.UltraLabel4)
        Me.Panel1.Controls.Add(Me.txt_descrip)
        Me.Panel1.Controls.Add(Me.txt_durations)
        Me.Panel1.Controls.Add(Me.UltraLabel3)
        Me.Panel1.Controls.Add(Me.txt_place)
        Me.Panel1.Controls.Add(Me.dt_dated)
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Controls.Add(Me.txt_faculty)
        Me.Panel1.Controls.Add(Me.UltraLabel2)
        Me.Panel1.Controls.Add(Me.UltraLabel6)
        Me.Panel1.Controls.Add(Me.UltraLable4)
        Me.Panel1.Controls.Add(Me.txt_topic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(672, 211)
        Me.Panel1.TabIndex = 0
        '
        'UltraLabel5
        '
        Appearance4.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance4
        Me.UltraLabel5.Location = New System.Drawing.Point(112, 107)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(189, 31)
        Me.UltraLabel5.TabIndex = 8
        Me.UltraLabel5.Text = "If this is a content only training, please leave the ""Place"" field blank"
        '
        'CtlUpLoad1
        '
        Me.CtlUpLoad1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CtlUpLoad1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CtlUpLoad1.Location = New System.Drawing.Point(0, 144)
        Me.CtlUpLoad1.Name = "CtlUpLoad1"
        Me.CtlUpLoad1.Size = New System.Drawing.Size(672, 67)
        Me.CtlUpLoad1.TabIndex = 13
        '
        'UltraLabel4
        '
        Appearance5.TextHAlignAsString = "Left"
        Me.UltraLabel4.Appearance = Appearance5
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(355, 38)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(61, 14)
        Me.UltraLabel4.TabIndex = 11
        Me.UltraLabel4.Text = "Description"
        '
        'txt_descrip
        '
        Appearance6.FontData.BoldAsString = "False"
        Appearance6.FontData.ItalicAsString = "False"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 8.25!
        Appearance6.FontData.StrikeoutAsString = "False"
        Appearance6.FontData.UnderlineAsString = "False"
        Me.txt_descrip.Appearance = Appearance6
        Me.txt_descrip.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_descrip.Location = New System.Drawing.Point(352, 56)
        Me.txt_descrip.Multiline = True
        Me.txt_descrip.Name = "txt_descrip"
        Me.txt_descrip.Size = New System.Drawing.Size(256, 48)
        Me.txt_descrip.TabIndex = 12
        '
        'txt_durations
        '
        Appearance7.FontData.BoldAsString = "False"
        Appearance7.FontData.ItalicAsString = "False"
        Appearance7.FontData.Name = "Arial"
        Appearance7.FontData.SizeInPoints = 8.25!
        Appearance7.FontData.StrikeoutAsString = "False"
        Appearance7.FontData.UnderlineAsString = "False"
        Me.txt_durations.Appearance = Appearance7
        Me.txt_durations.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_durations.Location = New System.Drawing.Point(440, 8)
        Me.txt_durations.Name = "txt_durations"
        Me.txt_durations.Size = New System.Drawing.Size(144, 21)
        Me.txt_durations.TabIndex = 10
        '
        'UltraLabel3
        '
        Appearance8.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance8
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(67, 83)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(33, 14)
        Me.UltraLabel3.TabIndex = 6
        Me.UltraLabel3.Text = "Place"
        '
        'txt_place
        '
        Appearance9.FontData.BoldAsString = "False"
        Appearance9.FontData.ItalicAsString = "False"
        Appearance9.FontData.Name = "Arial"
        Appearance9.FontData.SizeInPoints = 8.25!
        Appearance9.FontData.StrikeoutAsString = "False"
        Appearance9.FontData.UnderlineAsString = "False"
        Me.txt_place.Appearance = Appearance9
        Me.txt_place.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_place.Location = New System.Drawing.Point(112, 80)
        Me.txt_place.Name = "txt_place"
        Me.txt_place.Size = New System.Drawing.Size(232, 21)
        Me.txt_place.TabIndex = 7
        '
        'dt_dated
        '
        Appearance10.FontData.BoldAsString = "False"
        Appearance10.FontData.ItalicAsString = "False"
        Appearance10.FontData.Name = "Arial"
        Appearance10.FontData.SizeInPoints = 8.25!
        Appearance10.FontData.StrikeoutAsString = "False"
        Appearance10.FontData.UnderlineAsString = "False"
        Me.dt_dated.Appearance = Appearance10
        Me.dt_dated.FormatString = "dddd dd MMM yyyy"
        Me.dt_dated.Location = New System.Drawing.Point(112, 8)
        Me.dt_dated.Name = "dt_dated"
        Me.dt_dated.NullText = "Not Defined"
        Me.dt_dated.Size = New System.Drawing.Size(232, 21)
        Me.dt_dated.TabIndex = 1
        '
        'UltraLabel1
        '
        Appearance11.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance11
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(375, 11)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(53, 14)
        Me.UltraLabel1.TabIndex = 9
        Me.UltraLabel1.Text = "Durations"
        '
        'txt_faculty
        '
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.ItalicAsString = "False"
        Appearance12.FontData.Name = "Arial"
        Appearance12.FontData.SizeInPoints = 8.25!
        Appearance12.FontData.StrikeoutAsString = "False"
        Appearance12.FontData.UnderlineAsString = "False"
        Me.txt_faculty.Appearance = Appearance12
        Me.txt_faculty.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_faculty.Location = New System.Drawing.Point(112, 32)
        Me.txt_faculty.Name = "txt_faculty"
        Me.txt_faculty.Size = New System.Drawing.Size(232, 21)
        Me.txt_faculty.TabIndex = 3
        '
        'UltraLabel2
        '
        Appearance13.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance13
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(72, 11)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(28, 14)
        Me.UltraLabel2.TabIndex = 0
        Me.UltraLabel2.Text = "Date"
        '
        'UltraLabel6
        '
        Appearance14.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance14
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(68, 59)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(32, 14)
        Me.UltraLabel6.TabIndex = 4
        Me.UltraLabel6.Text = "Topic"
        '
        'UltraLable4
        '
        Appearance15.TextHAlignAsString = "Right"
        Me.UltraLable4.Appearance = Appearance15
        Me.UltraLable4.AutoSize = True
        Me.UltraLable4.Location = New System.Drawing.Point(59, 35)
        Me.UltraLable4.Name = "UltraLable4"
        Me.UltraLable4.Size = New System.Drawing.Size(41, 14)
        Me.UltraLable4.TabIndex = 2
        Me.UltraLable4.Text = "Faculty"
        '
        'txt_topic
        '
        Appearance16.FontData.BoldAsString = "False"
        Appearance16.FontData.ItalicAsString = "False"
        Appearance16.FontData.Name = "Arial"
        Appearance16.FontData.SizeInPoints = 8.25!
        Appearance16.FontData.StrikeoutAsString = "False"
        Appearance16.FontData.UnderlineAsString = "False"
        Me.txt_topic.Appearance = Appearance16
        Me.txt_topic.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_topic.Location = New System.Drawing.Point(112, 56)
        Me.txt_topic.Name = "txt_topic"
        Me.txt_topic.Size = New System.Drawing.Size(232, 21)
        Me.txt_topic.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraGrid2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 217)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(672, 184)
        Me.Panel2.TabIndex = 88
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid2.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(672, 184)
        Me.UltraGrid2.TabIndex = 0
        '
        'btnDelEmp
        '
        Me.btnDelEmp.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelEmp.Location = New System.Drawing.Point(600, 0)
        Me.btnDelEmp.Name = "btnDelEmp"
        Me.btnDelEmp.Size = New System.Drawing.Size(72, 37)
        Me.btnDelEmp.TabIndex = 1
        Me.btnDelEmp.Text = "Delete"
        '
        'btnAddEmp
        '
        Me.btnAddEmp.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddEmp.Location = New System.Drawing.Point(528, 0)
        Me.btnAddEmp.Name = "btnAddEmp"
        Me.btnAddEmp.Size = New System.Drawing.Size(72, 37)
        Me.btnAddEmp.TabIndex = 0
        Me.btnAddEmp.Text = "Add"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnAddEmp)
        Me.Panel3.Controls.Add(Me.btnDelEmp)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 401)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(672, 37)
        Me.Panel3.TabIndex = 1
        '
        'frmTrain
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Training"
        Me.ClientSize = New System.Drawing.Size(672, 486)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTrain"
        Me.Text = "Training"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txt_descrip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_durations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_place, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_dated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_faculty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_topic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel

#End Region
End Class

