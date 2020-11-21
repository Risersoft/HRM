Public Class frmSalCat
    Inherits frmMax
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        myView.SetGrid(Me.UGridAtt)
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
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents UGridAtt As Infragistics.Win.UltraWinGrid.UltraGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnSave = New Infragistics.Win.Misc.UltraButton
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton
        Me.btnOK = New Infragistics.Win.Misc.UltraButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblName = New System.Windows.Forms.Label
        Me.UGridAtt = New Infragistics.Win.UltraWinGrid.UltraGrid
        CType(Me.dsForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UGridAtt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 389)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(656, 48)
        Me.Panel4.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.Location = New System.Drawing.Point(368, 8)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 32)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.Location = New System.Drawing.Point(464, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.btnOK.Appearance = Appearance3
        Me.btnOK.Location = New System.Drawing.Point(560, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(656, 48)
        Me.Panel1.TabIndex = 6
        '
        'lblName
        '
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(0, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(656, 48)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Mr Rajendra Prasad"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UGridAtt
        '
        Me.UGridAtt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UGridAtt.Location = New System.Drawing.Point(0, 48)
        Me.UGridAtt.Name = "UGridAtt"
        Me.UGridAtt.Size = New System.Drawing.Size(656, 341)
        Me.UGridAtt.TabIndex = 9
        Me.UGridAtt.Text = "Delivery Schedule"
        '
        'frmSalCat
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(656, 437)
        Me.Controls.Add(Me.UGridAtt)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSalCat"
        Me.Text = "Salary Categorization"
        CType(Me.dsForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsCombo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UGridAtt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitForm()
        Dim sql, str As String, dt As DataTable

        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)

    End Sub
    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str As String, vBag As clsConf, ds As DataSet

        If prepMode = EnumfrmMode.acEditM Then
            Me.InitData("", "", oView, prepMode, prepIDX, strXML)

            sql = "select isfinal,salcalcon,descrip from hrplistpayp() where payperiodid=" & frmIDX
            ds = SqlHelper.ExecuteDataset(myApp.dbConn, CommandType.Text, sql)
            Me.lblName.Text = "Salary Categorization for " & ds.Tables(0).Rows(0)("descrip")
            If myUtils.cBoolTN(ds.Tables(0).Rows(0)("isfinal")) Then
                MsgBox("This payperiod has been finalized", MsgBoxStyle.Information, myApp.Vars("appname"))
                PrepForm = False
                Exit Function
            ElseIf myUtils.NullNot(ds.Tables(0).Rows(0)("salcalcon")) Then
                MsgBox("The salary for this payperiod has not been prepared", MsgBoxStyle.Information, myApp.Vars("appname"))
                PrepForm = False
                Exit Function
            End If

            ' sql = "SELECT payslipid, isfinal, Code, [Name], Designation,DepID,CampusID,StatusID,iswage,isworker from hrplistadvtds() " & _
            '   myUtils.CombineWhere(True, "payperiodid=" & frmIDX, myAssy.WValue(pView, "id2casual,dep,isworker")) & " order by [Code] "

            myView.mainGrid.myCMain.QuickConf(sql, True, "1-4-2-2-2-2-1.5-1.5", True)
            str = "<BAND INDEX=""0"" TABLE=""payslip"" IDFIELD=""payslipid"" ><COL KEY=""designation""/><COL KEY=""DEPID"" LOOKUPSQL=""select depid,depname from deps order by depname"" Caption=""Dep""/><COL KEY=""campusid"" LOOKUPSQL=""select campusid,dispname from campus order by campusid"" CAPTION=""Campus""/><COL KEY=""StatusID"" LOOKUPSQL=""Select empstatusid,status from statusemp order by empstatusid"" CAPTION=""Status""/><COL KEY=""isworker"" VLIST=""False;Staff|True;Worker"" CAPTION=""WF Cat""/><COL KEY=""iswage"" VLIST=""False;Salary|True;Wage"" CAPTION=""Sal Cat""/></BAND>"
            myView.mainGrid.PrepEdit(str)


            Me.DoRefresh = True
            PrepForm = True
        End If


    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        Me.InitError()

        myview.mainGrid.CheckValid("designation,depid,campusid,statusid,isworker,iswage")
        If Me.cansave Then
            myView.mainGrid.SaveChanges()
            VSave = True
        End If
        Me.Refresh()

    End Function

End Class
