Public Class frmPayProp
    Inherits frmMax

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
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents lblTarget As System.Windows.Forms.Label
    Friend WithEvents txt_Target As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_Gross As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btn_Define As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn_Print As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnOK = New Infragistics.Win.Misc.UltraButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_Print = New Infragistics.Win.Misc.UltraButton
        Me.btn_Define = New Infragistics.Win.Misc.UltraButton
        Me.txt_Gross = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txt_Target = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lblGross = New System.Windows.Forms.Label
        Me.lblTarget = New System.Windows.Forms.Label
        Me.lblDep = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblCode = New System.Windows.Forms.Label
        Me.lblArbit = New System.Windows.Forms.Label
        Me.TwoGrids = New AddRemove
        CType(Me.dsCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_Gross, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Target, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 515)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(488, 48)
        Me.Panel4.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance1
        Me.btnOK.Location = New System.Drawing.Point(392, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Print)
        Me.Panel1.Controls.Add(Me.btn_Define)
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
        Me.Panel1.Size = New System.Drawing.Size(488, 128)
        Me.Panel1.TabIndex = 6
        '
        'btn_Print
        '
        Me.btn_Print.Location = New System.Drawing.Point(376, 8)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(80, 24)
        Me.btn_Print.TabIndex = 18
        Me.btn_Print.Text = "Print Form"
        '
        'btn_Define
        '
        Me.btn_Define.Location = New System.Drawing.Point(376, 104)
        Me.btn_Define.Name = "btn_Define"
        Me.btn_Define.Size = New System.Drawing.Size(80, 24)
        Me.btn_Define.TabIndex = 17
        Me.btn_Define.Text = "Define"
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
        Me.txt_Gross.Location = New System.Drawing.Point(304, 56)
        Me.txt_Gross.Name = "txt_Gross"
        Me.txt_Gross.Size = New System.Drawing.Size(152, 17)
        Me.txt_Gross.TabIndex = 16
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
        Me.txt_Target.Location = New System.Drawing.Point(304, 80)
        Me.txt_Target.Name = "txt_Target"
        Me.txt_Target.Size = New System.Drawing.Size(152, 17)
        Me.txt_Target.TabIndex = 15
        Me.txt_Target.Text = "UltraTextEditor9"
        '
        'lblGross
        '
        Me.lblGross.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGross.Location = New System.Drawing.Point(136, 56)
        Me.lblGross.Name = "lblGross"
        Me.lblGross.Size = New System.Drawing.Size(160, 16)
        Me.lblGross.TabIndex = 7
        Me.lblGross.Text = "Proposed Gross Salary"
        Me.lblGross.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblTarget
        '
        Me.lblTarget.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarget.Location = New System.Drawing.Point(8, 80)
        Me.lblTarget.Name = "lblTarget"
        Me.lblTarget.Size = New System.Drawing.Size(288, 16)
        Me.lblTarget.TabIndex = 6
        Me.lblTarget.Text = "Target"
        Me.lblTarget.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblDep
        '
        Me.lblDep.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDep.Location = New System.Drawing.Point(64, 32)
        Me.lblDep.Name = "lblDep"
        Me.lblDep.Size = New System.Drawing.Size(144, 24)
        Me.lblDep.TabIndex = 5
        Me.lblDep.Text = "Mr Rajendra Prasad"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Dep."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.Location = New System.Drawing.Point(64, 8)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(200, 16)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "Mr Rajendra Prasad"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblCode
        '
        Me.lblCode.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCode.Location = New System.Drawing.Point(64, 56)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(64, 16)
        Me.lblCode.TabIndex = 1
        Me.lblCode.Text = "Mr Rajendra Prasad"
        '
        'lblArbit
        '
        Me.lblArbit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArbit.Location = New System.Drawing.Point(8, 56)
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
        Me.TwoGrids.Location = New System.Drawing.Point(0, 128)
        Me.TwoGrids.Mode = 2
        Me.TwoGrids.Name = "TwoGrids"
        Me.TwoGrids.Size = New System.Drawing.Size(488, 387)
        Me.TwoGrids.TabIndex = 7
        '
        'frmPayProp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 563)
        Me.Controls.Add(Me.TwoGrids)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPayProp"
        Me.Text = "Pay Proposal"
        CType(Me.dsCombo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.txt_Gross, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Target, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitForm()
        Dim sql, str As String, dt As DataTable

        WinFormUtils.SetButtonConf(Me.btnOK, Nothing, Nothing)

    End Sub
    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str As String, ds As DataSet

        If prepMode = EnumfrmMode.acEditM Then
            Me.InitData("", "employeeid,payproposalid,oldsmid,oldrmid,newsmid,newrmid,onlyrm", oView, prepMode, prepIDX, strXML)

            Me.lblCode.Text = oView.ContextRow.Cells("Code").Value
            Me.lblDep.Text = oView.ContextRow.Cells("Dep").Value
            Me.lblName.Text = oView.ContextRow.Cells("Name").Value
            If myUtils.NullNot(Me.vBag("oldsmid")) Then
                MsgBox("No Salarymasters could be found to compare from", MsgBoxStyle.Information, myApp.Vars("appname"))
                PrepForm = False
            Else
                Me.TwoGrids.myView1.mainGrid.myCMain("defaultwidfact") = 1
                sql = "select * from hrpdispsalmaster(" & Me.vBag("oldsmid") & "," & Me.vBag("oldrmid") & ")"
                Me.TwoGrids.myView1.mainGrid.myCMain("invertedview") = True
                Me.TwoGrids.myView1.mainGrid.myCMain.QuickConf(sql, False, "1", True, "Reference Salary", True)

                Me.lblTarget.Text = "Target Gross Salary As On " & Format(oView.ContextRow.Cells("targetdate").Value, "dd-MMM-yyyy")
                Me.txt_Target.Text = Format(myUtils.cValTN(oView.ContextRow.Cells("target sal").Value), "#.##")
                Me.txt_Gross.Text = Format(myUtils.cValTN(oView.ContextRow.Cells("projected sal").Value), "#.##")

                recalc()
                PrepForm = True
            End If
        End If


    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        Me.InitError()

        If Me.cansave Then
            Me.DoRefresh = True
            VSave = True
        End If
        Me.Refresh()

    End Function

    'Private Sub btn_Define_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Define.Click
    '    'Dim strXML As String, f As New frmSMTotal

    '    strXML = "<PARAMS OLDSMID=""" & Me.vBag("oldsmid") & """ PAYPROPOSALID=""" & Me.vBag("payproposalid") & """ RATEMASTERID=""" & Me.vBag("newrmid") & """ PGROSS=""" & myUtils.cValTN(Me.txt_Gross.Text) & """/>"
    '    If Not myUtils.NullNot(Me.vBag("newsmid")) Then
    '        If f.PrepForm(Me.myView, EnumfrmMode.acEditM, Me.vBag("newsmid"), strXML) Then
    '            If f.ShowDialog(Me) = DialogResult.OK Then Me.TwoGrids.myView2.RefreshGrid()
    '        End If
    '    ElseIf Not myUtils.cBoolTN(Me.vBag("onlyrm")) Then
    '        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, "", strXML) Then
    '            If f.ShowDialog(Me) = DialogResult.OK Then
    '                Me.vBag("newsmid") = f.frmIDX
    '                recalc()
    '            End If
    '        End If
    '    End If
    '    f = Nothing


    'End Sub
    Private Sub recalc()
        Dim sql As String

        Me.TwoGrids.myView2.mainGrid.myCMain("defaultwidfact") = 1
        sql = "select * from hrpdispsalmaster(" & myUtils.cValTN(Me.vBag("newsmid")) & "," & Me.vBag("newrmid") & ")"
        Me.TwoGrids.myView2.mainGrid.myCMain("invertedview") = True
        Me.TwoGrids.myView2.mainGrid.myCMain.QuickConf(sql, False, "1", True, "Proposed Salary", True)

    End Sub
    Private Sub btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Print.Click


    End Sub
End Class
