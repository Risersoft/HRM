Imports ug = Infragistics.Win.UltraWinGrid
Public Class frmSMTotal
    Inherits frmMax
    Dim IsFinal As Boolean = False, ds As DataSet
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        myView.SetGrid()
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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDep As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TwoGrids As AddRemove
    Friend WithEvents lblArbit As System.Windows.Forms.Label
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Define As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txt_Gross As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_Skill As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txt_OTHourRate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_OTSalMult As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_TDSNorm As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chk_HasAllow As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chk_IgnorePrev As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dt_Dated As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnSave = New Infragistics.Win.Misc.UltraButton
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton
        Me.btnOK = New Infragistics.Win.Misc.UltraButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_TDSNorm = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_OTSalMult = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_OTHourRate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmb_Skill = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chk_IgnorePrev = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chk_HasAllow = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.btn_Define = New Infragistics.Win.Misc.UltraButton
        Me.txt_Gross = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lblGross = New System.Windows.Forms.Label
        Me.lblDep = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblCode = New System.Windows.Forms.Label
        Me.lblArbit = New System.Windows.Forms.Label
        Me.TwoGrids = New AddRemove
        Me.Label6 = New System.Windows.Forms.Label
        Me.dt_Dated = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        CType(Me.dsForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cmb_Skill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 515)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(592, 48)
        Me.Panel4.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.Location = New System.Drawing.Point(248, 8)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(144, 32)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save and Calculate"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.Location = New System.Drawing.Point(400, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.btnOK.Appearance = Appearance3
        Me.btnOK.Location = New System.Drawing.Point(496, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.dt_Dated)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_TDSNorm)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_OTSalMult)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_OTHourRate)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.cmb_Skill)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.lblDep)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblCode)
        Me.Panel1.Controls.Add(Me.lblArbit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(592, 216)
        Me.Panel1.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Normal TDS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_TDSNorm
        '
        Appearance4.FontData.Bold = Infragistics.Win.DefaultableBoolean.False
        Me.txt_TDSNorm.Appearance = Appearance4
        Me.txt_TDSNorm.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_TDSNorm.Location = New System.Drawing.Point(120, 136)
        Me.txt_TDSNorm.Name = "txt_TDSNorm"
        Me.txt_TDSNorm.Size = New System.Drawing.Size(144, 17)
        Me.txt_TDSNorm.TabIndex = 52
        Me.txt_TDSNorm.Text = "UltraTextEditor1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "OT Salary multiple"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_OTSalMult
        '
        Appearance5.FontData.Bold = Infragistics.Win.DefaultableBoolean.False
        Me.txt_OTSalMult.Appearance = Appearance5
        Me.txt_OTSalMult.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_OTSalMult.Location = New System.Drawing.Point(120, 112)
        Me.txt_OTSalMult.Name = "txt_OTSalMult"
        Me.txt_OTSalMult.Size = New System.Drawing.Size(144, 17)
        Me.txt_OTSalMult.TabIndex = 50
        Me.txt_OTSalMult.Text = "UltraTextEditor1"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "OT Hourly Rate"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_OTHourRate
        '
        Appearance6.FontData.Bold = Infragistics.Win.DefaultableBoolean.False
        Me.txt_OTHourRate.Appearance = Appearance6
        Me.txt_OTHourRate.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_OTHourRate.Location = New System.Drawing.Point(120, 88)
        Me.txt_OTHourRate.Name = "txt_OTHourRate"
        Me.txt_OTHourRate.Size = New System.Drawing.Size(144, 17)
        Me.txt_OTHourRate.TabIndex = 48
        Me.txt_OTHourRate.Text = "UltraTextEditor1"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(8, 160)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 16)
        Me.Label22.TabIndex = 29
        Me.Label22.Text = "Skill"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Skill
        '
        Appearance7.FontData.Bold = Infragistics.Win.DefaultableBoolean.False
        Me.cmb_Skill.Appearance = Appearance7
        Me.cmb_Skill.DisplayMember = ""
        Me.cmb_Skill.Location = New System.Drawing.Point(120, 160)
        Me.cmb_Skill.Name = "cmb_Skill"
        Me.cmb_Skill.Size = New System.Drawing.Size(144, 21)
        Me.cmb_Skill.TabIndex = 28
        Me.cmb_Skill.Text = "UltraCombo5"
        Me.cmb_Skill.ValueMember = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_IgnorePrev)
        Me.GroupBox1.Controls.Add(Me.chk_HasAllow)
        Me.GroupBox1.Controls.Add(Me.btn_Define)
        Me.GroupBox1.Controls.Add(Me.txt_Gross)
        Me.GroupBox1.Controls.Add(Me.lblGross)
        Me.GroupBox1.Location = New System.Drawing.Point(296, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 176)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Back Calculation"
        '
        'chk_IgnorePrev
        '
        Me.chk_IgnorePrev.Location = New System.Drawing.Point(104, 104)
        Me.chk_IgnorePrev.Name = "chk_IgnorePrev"
        Me.chk_IgnorePrev.Size = New System.Drawing.Size(176, 24)
        Me.chk_IgnorePrev.TabIndex = 98
        Me.chk_IgnorePrev.Text = "Ignore Previous Salary value"
        '
        'chk_HasAllow
        '
        Me.chk_HasAllow.Location = New System.Drawing.Point(104, 72)
        Me.chk_HasAllow.Name = "chk_HasAllow"
        Me.chk_HasAllow.Size = New System.Drawing.Size(176, 24)
        Me.chk_HasAllow.TabIndex = 97
        Me.chk_HasAllow.Text = "Has Allowance Components"
        '
        'btn_Define
        '
        Me.btn_Define.Location = New System.Drawing.Point(192, 136)
        Me.btn_Define.Name = "btn_Define"
        Me.btn_Define.Size = New System.Drawing.Size(80, 24)
        Me.btn_Define.TabIndex = 25
        Me.btn_Define.Text = "GO !"
        '
        'txt_Gross
        '
        Appearance8.FontData.Bold = Infragistics.Win.DefaultableBoolean.False
        Appearance8.FontData.Italic = Infragistics.Win.DefaultableBoolean.False
        Appearance8.FontData.Name = "Arial"
        Appearance8.FontData.SizeInPoints = 8.25!
        Appearance8.FontData.Strikeout = Infragistics.Win.DefaultableBoolean.False
        Appearance8.FontData.Underline = Infragistics.Win.DefaultableBoolean.False
        Me.txt_Gross.Appearance = Appearance8
        Me.txt_Gross.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Gross.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Gross.Location = New System.Drawing.Point(128, 40)
        Me.txt_Gross.Name = "txt_Gross"
        Me.txt_Gross.Size = New System.Drawing.Size(152, 17)
        Me.txt_Gross.TabIndex = 24
        Me.txt_Gross.Text = "UltraTextEditor9"
        '
        'lblGross
        '
        Me.lblGross.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGross.Location = New System.Drawing.Point(16, 24)
        Me.lblGross.Name = "lblGross"
        Me.lblGross.Size = New System.Drawing.Size(104, 44)
        Me.lblGross.TabIndex = 23
        Me.lblGross.Text = "Proposed Gross Salary"
        Me.lblGross.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblDep
        '
        Me.lblDep.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDep.Location = New System.Drawing.Point(64, 56)
        Me.lblDep.Name = "lblDep"
        Me.lblDep.Size = New System.Drawing.Size(200, 24)
        Me.lblDep.TabIndex = 5
        Me.lblDep.Text = "Mr Rajendra Prasad"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Dep."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.Location = New System.Drawing.Point(64, 32)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(200, 16)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "Mr Rajendra Prasad"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblCode
        '
        Me.lblCode.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCode.Location = New System.Drawing.Point(64, 8)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(208, 16)
        Me.lblCode.TabIndex = 1
        Me.lblCode.Text = "Mr Rajendra Prasad"
        '
        'lblArbit
        '
        Me.lblArbit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArbit.Location = New System.Drawing.Point(8, 8)
        Me.lblArbit.Name = "lblArbit"
        Me.lblArbit.Size = New System.Drawing.Size(48, 16)
        Me.lblArbit.TabIndex = 0
        Me.lblArbit.Text = "Code"
        Me.lblArbit.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'TwoGrids
        '
        Me.TwoGrids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TwoGrids.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TwoGrids.Location = New System.Drawing.Point(0, 216)
        Me.TwoGrids.Name = "TwoGrids"
        Me.TwoGrids.Size = New System.Drawing.Size(592, 299)
        Me.TwoGrids.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(40, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Effective From"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dt_Dated
        '
        Me.dt_Dated.FormatString = "dddd dd MMM yyyy"
        Me.dt_Dated.Location = New System.Drawing.Point(120, 192)
        Me.dt_Dated.Name = "dt_Dated"
        Me.dt_Dated.NullText = "Not Defined"
        Me.dt_Dated.Size = New System.Drawing.Size(168, 21)
        Me.dt_Dated.TabIndex = 65
        '
        'frmSMTotal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 563)
        Me.Controls.Add(Me.TwoGrids)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSMTotal"
        Me.Text = "Pay Proposal"
        CType(Me.dsForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsCombo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.cmb_Skill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitForm()
        Dim sql, str As String, dt As DataTable

        myWinSQL.AssignCmb(Me.dsCombo, "skill", "select skillcode,skill from hrplistskill()", Me.cmb_Skill)

        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)

    End Sub
    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str As String, dt As DataTable


        If prepMode = EnumfrmMode.acCopyM Then
            If MsgBox("Are you sure you want to create another Salary Master ?", MsgBoxStyle.YesNo, myApp.Vars("appname")) = MsgBoxResult.No Then Exit Function
        End If

        If prepMode = EnumfrmMode.acAddM Or prepMode = EnumfrmMode.acCopyM Then
            Me.InitData("", "oldsmid,payproposalid", oView, EnumfrmMode.acEditM, prepIDX, strXML)
            If prepMode = EnumfrmMode.acCopyM Then Me.vBag("oldsmid") = oView.ContextRow.Cells("salarymasterid").Value

            If myUtils.cValTN(Me.vBag("oldsmid")) <> 0 Then
                sql = "select * from salarymaster where salarymasterid = " & Me.vBag("oldsmid")

                ds = SqlHelper.ExecuteDataset(myApp.dbConn, CommandType.Text, sql)
                dt = ds.Tables(0).Clone
                myUtils.CopyOneRow(ds.Tables(0).Rows(0), dt)

                dt.Rows(0)("dated") = DBNull.Value
                dt.Rows(0)("payproposalid") = DBNull.Value
                If prepMode = EnumfrmMode.acAddM AndAlso myUtils.cValTN(Me.vBag("payproposalid")) > 0 Then dt.Rows(0)("payproposalid") = Me.vBag("payproposalid")

                SqlHelper2.SaveResults(dt, "select * from salarymaster where salarymasterid = 0")
                prepMode = EnumfrmMode.acEditM
                prepIDX = dt.Rows(0)("Salarymasterid")
            End If
        End If

        If prepMode = EnumfrmMode.acEditM Then
            If myUtils.cValTN(prepIDX) = 0 Then prepIDX = oView.ContextRow.Cells("salarymasterid").Value
            sql = "select * from salarymaster where salarymasterid = " & prepIDX
            Me.InitData(sql, "ratemasterid,pGross,", oView, prepMode, prepIDX, strXML)

            Me.txt_Gross.Text = Format(myUtils.cValTN(Me.vBag("pGross")), "#.##")

            ds = SqlHelper.ExecuteDataset(myApp.dbConn, CommandType.Text, "Select * from hrplistemp() where employeeid =" & myRow("employeeid"))
            Me.lblCode.Text = ds.Tables(0).Rows(0)("Code")
            Me.lblDep.Text = ds.Tables(0).Rows(0)("Dep")
            Me.lblName.Text = ds.Tables(0).Rows(0)("Name")

            sql = "Select payperiodid From hrplistsalrate() where isnull(isfinal,0)=1 and salarymasterid=" & prepIDX
            sql = sql & "; Select payperiodid From hrplistsalrate() where salcalcon is not null and isnull(isfinal,0)=0 and salarymasterid=" & prepIDX
            ds = SqlHelper.ExecuteDataset(myApp.dbConn, CommandType.Text, sql)
            If ds.Tables(0).Rows.Count > 0 Then
                MsgBox("This salarymaster has been used in a finalized payperiod and cannot be edited.", MsgBoxStyle.Information, myApp.Vars("appname"))
                IsFinal = True
            End If
            reCalc()
            PrepForm = True

        End If
    End Function

    Public Overrides Function VSave() As Boolean
        Dim gc As ug.UltraGridColumn, gr As ug.UltraGridRow

        VSave = False
        Me.InitError()
        If myUtils.NullNot(Me.dt_Dated.Value) AndAlso myUtils.cValTN(myRow("payproposalid")) = 0 Then myWinForms.AddError(Me.dt_Dated, "Please define a date")
        If Me.CanSave Then
            cm.EndCurrentEdit()

            If IsFinal Then
                MsgBox("This salarymaster cannot be saved as it has been used in a finalized payperiod", MsgBoxStyle.Information, myApp.Vars("appname"))
                'TODO: Salarymaster dated checking.
            Else
                gr = Me.TwoGrids.myView1.mainGrid.myGrid.Rows(0)
                For Each gc In Me.TwoGrids.myView1.mainGrid.myGrid.DisplayLayout.Bands(0).Columns
                    If myRow.Row.Table.Columns.Contains(gc.Key) Then
                        myRow.Row(gc.Key) = gr.Cells(gc).Value
                    End If
                Next

                SqlHelper2.SaveResults(myRow.Row.Table, Me.sqlForm)
                reCalc()

                For Each r As DataRow In ds.Tables(1).Select
                    SqlHelper.ExecuteNonQuery(myApp.dbConn, CommandType.Text, "sp_paysal " & r("payperiodid") & "," & myRow("employeeid"))
                Next
            End If

            VSave = True
        End If
        Me.Refresh()

    End Function


    Private Sub reCalc()
        Dim sql, str As String

        Me.TwoGrids.myView1.mainGrid.myCMain("defaultwidfact") = 1
        sql = "select * from hrpdispsalvar(" & frmIDX & ")"
        Me.TwoGrids.myView1.mainGrid.myCMain("invertedview") = True
        Me.TwoGrids.myView1.mainGrid.myCMain.QuickConf(sql, False, "1", True, "Components", True)

        If Not IsFinal Then
            str = "<BAND INDEX=""0"">" & Me.TwoGrids.myView1.mainGrid.BuildBandEditXML(0, " STYLE='CALC'") & "</BAND>"
            Me.TwoGrids.myView1.mainGrid.PrepEdit(str)
        End If

        Me.TwoGrids.myView2.mainGrid.myCMain("defaultwidfact") = 1
        sql = "select * from hrpdispsalcalc(" & frmIDX & "," & Me.vBag("ratemasterid") & ")"
        Me.TwoGrids.myView2.mainGrid.myCMain("invertedview") = True
        Me.TwoGrids.myView2.mainGrid.myCMain.QuickConf(sql, False, "1", True, "Calculations", True)

    End Sub

    Private Sub btn_Define_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Define.Click
        If Not IsFinal Then
            SqlHelper.ExecuteNonQuery(myApp.dbConn, CommandType.Text, "sp_backcalcsal " & frmIDX & "," & Me.vBag("ratemasterid") & "," & myUtils.cValTN(Me.txt_Gross.Text) & "," & Math.Abs(CInt(Me.chk_HasAllow.Checked)) & "," & Math.Abs(CInt(Me.chk_IgnorePrev.Checked)))
            Me.reCalc()
        End If
    End Sub
End Class
