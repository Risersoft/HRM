<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewEmp


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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_empcode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_shiftid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_campusid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_depid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.labelid2_8 = New System.Windows.Forms.Label()
        Me.cmbid2_iscasual = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dt_JoinDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_empcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_shiftid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_campusid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_depid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbid2_iscasual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_JoinDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(66, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 14)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Code"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_empcode
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.txt_empcode.Appearance = Appearance1
        Me.txt_empcode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_empcode.Location = New System.Drawing.Point(101, 24)
        Me.txt_empcode.Name = "txt_empcode"
        Me.txt_empcode.Size = New System.Drawing.Size(104, 17)
        Me.txt_empcode.TabIndex = 1
        Me.txt_empcode.Text = "UltraTextEditor2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Shift"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_shiftid
        '
        Appearance2.FontData.BoldAsString = "False"
        Me.cmb_shiftid.Appearance = Appearance2
        Me.cmb_shiftid.Location = New System.Drawing.Point(101, 166)
        Me.cmb_shiftid.Name = "cmb_shiftid"
        Me.cmb_shiftid.Size = New System.Drawing.Size(224, 22)
        Me.cmb_shiftid.TabIndex = 7
        Me.cmb_shiftid.Text = "UltraCombo5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Campus"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_campusid
        '
        Appearance3.FontData.BoldAsString = "False"
        Me.cmb_campusid.Appearance = Appearance3
        Me.cmb_campusid.Location = New System.Drawing.Point(101, 129)
        Me.cmb_campusid.Name = "cmb_campusid"
        Me.cmb_campusid.Size = New System.Drawing.Size(224, 22)
        Me.cmb_campusid.TabIndex = 5
        Me.cmb_campusid.Text = "UltraCombo5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Department"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_depid
        '
        Appearance4.FontData.BoldAsString = "False"
        Me.cmb_depid.Appearance = Appearance4
        Me.cmb_depid.Location = New System.Drawing.Point(101, 92)
        Me.cmb_depid.Name = "cmb_depid"
        Me.cmb_depid.Size = New System.Drawing.Size(224, 22)
        Me.cmb_depid.TabIndex = 3
        Me.cmb_depid.Text = "UltraCombo5"
        '
        'labelid2_8
        '
        Me.labelid2_8.AutoSize = True
        Me.labelid2_8.Location = New System.Drawing.Point(59, 206)
        Me.labelid2_8.Name = "labelid2_8"
        Me.labelid2_8.Size = New System.Drawing.Size(39, 14)
        Me.labelid2_8.TabIndex = 11
        Me.labelid2_8.Text = "Nature"
        Me.labelid2_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbid2_iscasual
        '
        ValueListItem4.DataValue = False
        ValueListItem4.DisplayText = "Normal"
        ValueListItem5.DataValue = True
        ValueListItem5.DisplayText = "Casual"
        Me.cmbid2_iscasual.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5})
        Me.cmbid2_iscasual.Location = New System.Drawing.Point(101, 203)
        Me.cmbid2_iscasual.Name = "cmbid2_iscasual"
        Me.cmbid2_iscasual.Size = New System.Drawing.Size(224, 21)
        Me.cmbid2_iscasual.TabIndex = 12
        Me.cmbid2_iscasual.Text = "UltraComboEditor9"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(50, 59)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(48, 14)
        Me.lblDate.TabIndex = 8
        Me.lblDate.Text = "JoinDate"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dt_JoinDate
        '
        Appearance5.FontData.BoldAsString = "False"
        Appearance5.FontData.ItalicAsString = "False"
        Appearance5.FontData.Name = "Arial"
        Appearance5.FontData.SizeInPoints = 8.25!
        Appearance5.FontData.StrikeoutAsString = "False"
        Appearance5.FontData.UnderlineAsString = "False"
        Me.dt_JoinDate.Appearance = Appearance5
        Me.dt_JoinDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_JoinDate.FormatString = "dddd dd MMM yyyy"
        Me.dt_JoinDate.Location = New System.Drawing.Point(101, 56)
        Me.dt_JoinDate.Name = "dt_JoinDate"
        Me.dt_JoinDate.NullText = "Not Defined"
        Me.dt_JoinDate.Size = New System.Drawing.Size(104, 21)
        Me.dt_JoinDate.TabIndex = 9
        '
        'frmNewEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "New Employee"
        Me.ClientSize = New System.Drawing.Size(359, 264)
        Me.Controls.Add(Me.cmbid2_iscasual)
        Me.Controls.Add(Me.labelid2_8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_empcode)
        Me.Controls.Add(Me.dt_JoinDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_shiftid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_campusid)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmb_depid)
        Me.Name = "frmNewEmp"
        Me.Text = "New Employee"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_empcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_shiftid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_campusid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_depid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbid2_iscasual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_JoinDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents txt_empcode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cmb_shiftid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cmb_campusid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents cmb_depid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents labelid2_8 As Windows.Forms.Label
    Friend WithEvents cmbid2_iscasual As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblDate As Windows.Forms.Label
    Friend WithEvents dt_JoinDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
End Class
