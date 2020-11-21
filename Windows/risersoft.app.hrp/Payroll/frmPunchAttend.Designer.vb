Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.mxent
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Partial Class frmPunchAttend
	Inherits frmMax

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        myView.SetGrid(Me.UGridLoan)
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
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_DepName As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_FullName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_EmpCode As System.Windows.Forms.Label
    Friend WithEvents lblArbit As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents dt_Dated As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UGridLoan As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_Comment As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_EarlyOutMin As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_LateInMin As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmb_attendidfh As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_attendidfhs As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_attendidshs As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_attendidsh As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents chk_IsManual As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chk_Undeclared As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chk_attconflict As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_TotWorkHours As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_OTHour As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_ESILeave As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmb_ShiftID As Infragistics.Win.UltraWinGrid.UltraCombo
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
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UGridLoan = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnProcess = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Comment = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_EarlyOutMin = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_LateInMin = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lbl_DepName = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_FullName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_EmpCode = New System.Windows.Forms.Label()
        Me.lblArbit = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmb_LocationCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.dt_OutTime = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.dt_InTime = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmb_ShiftID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_ESILeave = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_OTHour = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_TotWorkHours = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.chk_attconflict = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chk_Undeclared = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chk_IsManual = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.cmb_attendidshs = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmb_attendidsh = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmb_attendidfhs = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_attendidfh = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.dt_Dated = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UGridLoan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.txt_Comment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_EarlyOutMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_LateInMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.cmb_LocationCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_OutTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_InTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_ShiftID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ESILeave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_OTHour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TotWorkHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_attconflict, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_Undeclared, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_IsManual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_attendidshs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_attendidsh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_attendidfhs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_attendidfh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UGridLoan)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(484, 140)
        '
        'UGridLoan
        '
        Me.UGridLoan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UGridLoan.Location = New System.Drawing.Point(0, 0)
        Me.UGridLoan.Name = "UGridLoan"
        Me.UGridLoan.Size = New System.Drawing.Size(484, 140)
        Me.UGridLoan.TabIndex = 1
        Me.UGridLoan.Text = "Delivery Schedule"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(484, 140)
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnProcess)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 572)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(488, 42)
        Me.Panel4.TabIndex = 2
        '
        'btnProcess
        '
        Appearance1.FontData.BoldAsString = "True"
        Me.btnProcess.Appearance = Appearance1
        Me.btnProcess.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnProcess.Location = New System.Drawing.Point(0, 0)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(88, 42)
        Me.btnProcess.TabIndex = 3
        Me.btnProcess.Text = "Process Punch"
        '
        'btnSave
        '
        Appearance2.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance2
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(224, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 42)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance3.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance3
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(312, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 42)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance4.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance4
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(400, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 42)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(75, 369)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Comment"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Comment
        '
        Appearance5.FontData.BoldAsString = "False"
        Appearance5.FontData.ItalicAsString = "False"
        Appearance5.FontData.Name = "Arial"
        Appearance5.FontData.SizeInPoints = 8.25!
        Appearance5.FontData.StrikeoutAsString = "False"
        Appearance5.FontData.UnderlineAsString = "False"
        Me.txt_Comment.Appearance = Appearance5
        Me.txt_Comment.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Comment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Comment.Location = New System.Drawing.Point(144, 366)
        Me.txt_Comment.Multiline = True
        Me.txt_Comment.Name = "txt_Comment"
        Me.txt_Comment.Size = New System.Drawing.Size(296, 32)
        Me.txt_Comment.TabIndex = 37
        Me.txt_Comment.Text = "UltraTextEditor1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 267)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 14)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Early Out Minutes"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_EarlyOutMin
        '
        Appearance6.FontData.BoldAsString = "False"
        Appearance6.FontData.ItalicAsString = "False"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 8.25!
        Appearance6.FontData.StrikeoutAsString = "False"
        Appearance6.FontData.UnderlineAsString = "False"
        Me.txt_EarlyOutMin.Appearance = Appearance6
        Me.txt_EarlyOutMin.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_EarlyOutMin.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EarlyOutMin.Location = New System.Drawing.Point(144, 264)
        Me.txt_EarlyOutMin.Name = "txt_EarlyOutMin"
        Me.txt_EarlyOutMin.ReadOnly = True
        Me.txt_EarlyOutMin.Size = New System.Drawing.Size(76, 17)
        Me.txt_EarlyOutMin.TabIndex = 25
        Me.txt_EarlyOutMin.Text = "UltraTextEditor1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 243)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 14)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Late In Minutes"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_LateInMin
        '
        Appearance7.FontData.BoldAsString = "False"
        Appearance7.FontData.ItalicAsString = "False"
        Appearance7.FontData.Name = "Arial"
        Appearance7.FontData.SizeInPoints = 8.25!
        Appearance7.FontData.StrikeoutAsString = "False"
        Appearance7.FontData.UnderlineAsString = "False"
        Me.txt_LateInMin.Appearance = Appearance7
        Me.txt_LateInMin.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_LateInMin.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_LateInMin.Location = New System.Drawing.Point(144, 240)
        Me.txt_LateInMin.Name = "txt_LateInMin"
        Me.txt_LateInMin.ReadOnly = True
        Me.txt_LateInMin.Size = New System.Drawing.Size(76, 17)
        Me.txt_LateInMin.TabIndex = 23
        Me.txt_LateInMin.Text = "UltraTextEditor1"
        '
        'lbl_DepName
        '
        Me.lbl_DepName.AutoSize = True
        Me.lbl_DepName.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_DepName.Location = New System.Drawing.Point(152, 64)
        Me.lbl_DepName.Name = "lbl_DepName"
        Me.lbl_DepName.Size = New System.Drawing.Size(146, 16)
        Me.lbl_DepName.TabIndex = 5
        Me.lbl_DepName.Text = "Mr Rajendra Prasad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(104, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Dep."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lbl_FullName
        '
        Me.lbl_FullName.AutoSize = True
        Me.lbl_FullName.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_FullName.Location = New System.Drawing.Point(152, 40)
        Me.lbl_FullName.Name = "lbl_FullName"
        Me.lbl_FullName.Size = New System.Drawing.Size(146, 16)
        Me.lbl_FullName.TabIndex = 3
        Me.lbl_FullName.Text = "Mr Rajendra Prasad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(97, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lbl_EmpCode
        '
        Me.lbl_EmpCode.AutoSize = True
        Me.lbl_EmpCode.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_EmpCode.Location = New System.Drawing.Point(152, 16)
        Me.lbl_EmpCode.Name = "lbl_EmpCode"
        Me.lbl_EmpCode.Size = New System.Drawing.Size(146, 16)
        Me.lbl_EmpCode.TabIndex = 1
        Me.lbl_EmpCode.Text = "Mr Rajendra Prasad"
        '
        'lblArbit
        '
        Me.lblArbit.AutoSize = True
        Me.lblArbit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArbit.Location = New System.Drawing.Point(101, 16)
        Me.lblArbit.Name = "lblArbit"
        Me.lblArbit.Size = New System.Drawing.Size(38, 16)
        Me.lblArbit.TabIndex = 0
        Me.lblArbit.Text = "Code"
        Me.lblArbit.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.cmb_LocationCode)
        Me.Panel1.Controls.Add(Me.dt_OutTime)
        Me.Panel1.Controls.Add(Me.dt_InTime)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.cmb_ShiftID)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txt_ESILeave)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txt_OTHour)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txt_TotWorkHours)
        Me.Panel1.Controls.Add(Me.chk_attconflict)
        Me.Panel1.Controls.Add(Me.chk_Undeclared)
        Me.Panel1.Controls.Add(Me.chk_IsManual)
        Me.Panel1.Controls.Add(Me.cmb_attendidshs)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cmb_attendidsh)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cmb_attendidfhs)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmb_attendidfh)
        Me.Panel1.Controls.Add(Me.dt_Dated)
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_Comment)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_EarlyOutMin)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_LateInMin)
        Me.Panel1.Controls.Add(Me.lbl_DepName)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lbl_FullName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lbl_EmpCode)
        Me.Panel1.Controls.Add(Me.lblArbit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 406)
        Me.Panel1.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(48, 318)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 14)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Location Code"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_LocationCode
        '
        Appearance8.FontData.BoldAsString = "False"
        Me.cmb_LocationCode.Appearance = Appearance8
        Me.cmb_LocationCode.Location = New System.Drawing.Point(144, 315)
        Me.cmb_LocationCode.Name = "cmb_LocationCode"
        Me.cmb_LocationCode.Size = New System.Drawing.Size(104, 22)
        Me.cmb_LocationCode.TabIndex = 41
        Me.cmb_LocationCode.Text = "UltraCombo5"
        '
        'dt_OutTime
        '
        Appearance9.FontData.BoldAsString = "False"
        Appearance9.FontData.ItalicAsString = "False"
        Appearance9.FontData.Name = "Arial"
        Appearance9.FontData.SizeInPoints = 8.25!
        Appearance9.FontData.StrikeoutAsString = "False"
        Appearance9.FontData.UnderlineAsString = "False"
        Me.dt_OutTime.Appearance = Appearance9
        Me.dt_OutTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.dt_OutTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_OutTime.FormatString = "HH:mm"
        Me.dt_OutTime.Location = New System.Drawing.Point(293, 264)
        Me.dt_OutTime.MaskInput = "{LOC}hh:mm"
        Me.dt_OutTime.Name = "dt_OutTime"
        Me.dt_OutTime.NullText = "Not Defined"
        Me.dt_OutTime.Size = New System.Drawing.Size(88, 21)
        Me.dt_OutTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.dt_OutTime.TabIndex = 39
        '
        'dt_InTime
        '
        Appearance10.FontData.BoldAsString = "False"
        Appearance10.FontData.ItalicAsString = "False"
        Appearance10.FontData.Name = "Arial"
        Appearance10.FontData.SizeInPoints = 8.25!
        Appearance10.FontData.StrikeoutAsString = "False"
        Appearance10.FontData.UnderlineAsString = "False"
        Me.dt_InTime.Appearance = Appearance10
        Me.dt_InTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.dt_InTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_InTime.FormatString = "HH:mm"
        Me.dt_InTime.Location = New System.Drawing.Point(293, 239)
        Me.dt_InTime.MaskInput = "{LOC}hh:mm"
        Me.dt_InTime.Name = "dt_InTime"
        Me.dt_InTime.NullText = "Not Defined"
        Me.dt_InTime.Size = New System.Drawing.Size(88, 21)
        Me.dt_InTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.dt_InTime.TabIndex = 38
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(97, 139)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 14)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Shift"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_ShiftID
        '
        Appearance11.FontData.BoldAsString = "False"
        Me.cmb_ShiftID.Appearance = Appearance11
        Me.cmb_ShiftID.Location = New System.Drawing.Point(144, 136)
        Me.cmb_ShiftID.Name = "cmb_ShiftID"
        Me.cmb_ShiftID.Size = New System.Drawing.Size(104, 22)
        Me.cmb_ShiftID.TabIndex = 12
        Me.cmb_ShiftID.Text = "UltraCombo5"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(71, 347)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 14)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "ESI Leave"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_ESILeave
        '
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.ItalicAsString = "False"
        Appearance12.FontData.Name = "Arial"
        Appearance12.FontData.SizeInPoints = 8.25!
        Appearance12.FontData.StrikeoutAsString = "False"
        Appearance12.FontData.UnderlineAsString = "False"
        Me.txt_ESILeave.Appearance = Appearance12
        Me.txt_ESILeave.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_ESILeave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ESILeave.Location = New System.Drawing.Point(144, 344)
        Me.txt_ESILeave.Multiline = True
        Me.txt_ESILeave.Name = "txt_ESILeave"
        Me.txt_ESILeave.Size = New System.Drawing.Size(296, 16)
        Me.txt_ESILeave.TabIndex = 35
        Me.txt_ESILeave.Text = "UltraTextEditor1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(242, 267)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 14)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Out Time"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(247, 242)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 14)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "In Time"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(238, 291)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 14)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "OT Hours"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_OTHour
        '
        Appearance13.FontData.BoldAsString = "False"
        Appearance13.FontData.ItalicAsString = "False"
        Appearance13.FontData.Name = "Arial"
        Appearance13.FontData.SizeInPoints = 8.25!
        Appearance13.FontData.StrikeoutAsString = "False"
        Appearance13.FontData.UnderlineAsString = "False"
        Me.txt_OTHour.Appearance = Appearance13
        Me.txt_OTHour.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_OTHour.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_OTHour.Location = New System.Drawing.Point(293, 291)
        Me.txt_OTHour.Name = "txt_OTHour"
        Me.txt_OTHour.Size = New System.Drawing.Size(88, 17)
        Me.txt_OTHour.TabIndex = 29
        Me.txt_OTHour.Text = "UltraTextEditor2"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(37, 291)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 14)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Total Work Hours"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_TotWorkHours
        '
        Appearance14.FontData.BoldAsString = "False"
        Appearance14.FontData.ItalicAsString = "False"
        Appearance14.FontData.Name = "Arial"
        Appearance14.FontData.SizeInPoints = 8.25!
        Appearance14.FontData.StrikeoutAsString = "False"
        Appearance14.FontData.UnderlineAsString = "False"
        Me.txt_TotWorkHours.Appearance = Appearance14
        Me.txt_TotWorkHours.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_TotWorkHours.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotWorkHours.Location = New System.Drawing.Point(144, 291)
        Me.txt_TotWorkHours.Name = "txt_TotWorkHours"
        Me.txt_TotWorkHours.ReadOnly = True
        Me.txt_TotWorkHours.Size = New System.Drawing.Size(76, 17)
        Me.txt_TotWorkHours.TabIndex = 27
        Me.txt_TotWorkHours.Text = "UltraTextEditor1"
        '
        'chk_attconflict
        '
        Me.chk_attconflict.Enabled = False
        Me.chk_attconflict.Location = New System.Drawing.Point(272, 216)
        Me.chk_attconflict.Name = "chk_attconflict"
        Me.chk_attconflict.Size = New System.Drawing.Size(152, 16)
        Me.chk_attconflict.TabIndex = 21
        Me.chk_attconflict.Text = "Inconsistent Punch Data"
        '
        'chk_Undeclared
        '
        Me.chk_Undeclared.Location = New System.Drawing.Point(384, 160)
        Me.chk_Undeclared.Name = "chk_Undeclared"
        Me.chk_Undeclared.Size = New System.Drawing.Size(88, 40)
        Me.chk_Undeclared.TabIndex = 19
        Me.chk_Undeclared.Text = "UNdeclared Holiday"
        '
        'chk_IsManual
        '
        Me.chk_IsManual.Location = New System.Drawing.Point(144, 216)
        Me.chk_IsManual.Name = "chk_IsManual"
        Me.chk_IsManual.Size = New System.Drawing.Size(120, 16)
        Me.chk_IsManual.TabIndex = 20
        Me.chk_IsManual.Text = "Manually Override"
        '
        'cmb_attendidshs
        '
        Appearance15.FontData.BoldAsString = "False"
        Me.cmb_attendidshs.Appearance = Appearance15
        Me.cmb_attendidshs.Location = New System.Drawing.Point(264, 184)
        Me.cmb_attendidshs.Name = "cmb_attendidshs"
        Me.cmb_attendidshs.ReadOnly = True
        Me.cmb_attendidshs.Size = New System.Drawing.Size(104, 22)
        Me.cmb_attendidshs.TabIndex = 18
        Me.cmb_attendidshs.Text = "UltraCombo5"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(60, 187)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 14)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Second Half"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_attendidsh
        '
        Appearance16.FontData.BoldAsString = "False"
        Me.cmb_attendidsh.Appearance = Appearance16
        Me.cmb_attendidsh.Location = New System.Drawing.Point(144, 184)
        Me.cmb_attendidsh.Name = "cmb_attendidsh"
        Me.cmb_attendidsh.Size = New System.Drawing.Size(104, 22)
        Me.cmb_attendidsh.TabIndex = 17
        Me.cmb_attendidsh.Text = "UltraCombo5"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(264, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Suggested"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb_attendidfhs
        '
        Appearance17.FontData.BoldAsString = "False"
        Me.cmb_attendidfhs.Appearance = Appearance17
        Me.cmb_attendidfhs.Location = New System.Drawing.Point(264, 160)
        Me.cmb_attendidfhs.Name = "cmb_attendidfhs"
        Me.cmb_attendidfhs.ReadOnly = True
        Me.cmb_attendidfhs.Size = New System.Drawing.Size(104, 22)
        Me.cmb_attendidfhs.TabIndex = 15
        Me.cmb_attendidfhs.Text = "UltraCombo5"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(144, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Actual"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Attendance"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(76, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 14)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "First Half"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_attendidfh
        '
        Appearance18.FontData.BoldAsString = "False"
        Me.cmb_attendidfh.Appearance = Appearance18
        Me.cmb_attendidfh.Location = New System.Drawing.Point(144, 160)
        Me.cmb_attendidfh.Name = "cmb_attendidfh"
        Me.cmb_attendidfh.Size = New System.Drawing.Size(104, 22)
        Me.cmb_attendidfh.TabIndex = 14
        Me.cmb_attendidfh.Text = "UltraCombo5"
        '
        'dt_Dated
        '
        Appearance19.FontData.BoldAsString = "False"
        Appearance19.FontData.ItalicAsString = "False"
        Appearance19.FontData.Name = "Arial"
        Appearance19.FontData.SizeInPoints = 8.25!
        Appearance19.FontData.StrikeoutAsString = "False"
        Appearance19.FontData.UnderlineAsString = "False"
        Me.dt_Dated.Appearance = Appearance19
        Me.dt_Dated.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_Dated.FormatString = "dddd dd MMM yyyy"
        Me.dt_Dated.Location = New System.Drawing.Point(155, 88)
        Me.dt_Dated.Name = "dt_Dated"
        Me.dt_Dated.NullText = "Not Defined"
        Me.dt_Dated.ReadOnly = True
        Me.dt_Dated.Size = New System.Drawing.Size(157, 21)
        Me.dt_Dated.TabIndex = 7
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(109, 91)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(29, 14)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "Date"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl3)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 406)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UltraTabControl1.Size = New System.Drawing.Size(488, 166)
        Me.UltraTabControl1.TabIndex = 11
        UltraTab1.Key = "punch"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "PunchData"
        UltraTab3.Key = "status"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Task Status"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab3})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(264, 317)
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(484, 140)
        '
        'frmPunchAttend
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Attendance"
        Me.ClientSize = New System.Drawing.Size(488, 614)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPunchAttend"
        Me.Text = "Attendance"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UGridLoan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.txt_Comment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_EarlyOutMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_LateInMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmb_LocationCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_OutTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_InTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_ShiftID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ESILeave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_OTHour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TotWorkHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_attconflict, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_Undeclared, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_IsManual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_attendidshs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_attendidsh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_attendidfhs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_attendidfh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dt_OutTime As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dt_InTime As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btnProcess As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents cmb_LocationCode As ug.UltraCombo
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage

#End Region
End Class

