Imports risersoft.app.mxent
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Partial Class frmEmp
	Inherits frmMax

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


        Me.InitForm()
    End Sub

    ' Form overrides dispose to clean up the component list.
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UltraGridEmpSalary As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnAddNew As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_depid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txt_designation As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmb_campusid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_shiftid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_reportstoID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents dt_LeaveDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dt_JoinDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txt_empcode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_CareOf As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_LICNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_CatEmpNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chk_IsForController As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txt_Dispensary As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmb_StatusNum As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents btn_Person As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_RentPaid As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmb_haswage As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmb_isworker As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbid2_iscasual As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnEdit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents labelid2_8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_CardNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_BankAccNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmb_ContractorID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_Relationship As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraGridEmpSalBen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txt_CompanyEmail As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_JobFunc As Infragistics.Win.UltraWinEditors.UltraTextEditor
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
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_BankAccBearerName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnSelect = New Infragistics.Win.Misc.UltraButton()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_PANNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_UIDNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel21 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmb_BankBranchID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmb_paymentthrucode = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.txt_JobFunc = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmb_DivisionID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmb_LeftReasonCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_BankAccNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_CardNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cmbid2_iscasual = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmb_isworker = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmb_haswage = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmb_StatusNum = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_empcode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.dt_LeaveDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dt_JoinDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.labelid2_8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmb_reportstoID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_shiftid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_campusid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_depid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_designation = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btn_CalcleaveBal = New Infragistics.Win.Misc.UltraButton()
        Me.txt_OpenEWDLastLM = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txt_OpenEWDCurrLM = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cmb_PunchEnabled = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmb_LeaveAuth2ID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmb_LeaveAuth1ID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmb_userID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmb_ImprestEnabled = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnCreateVendor = New Infragistics.Win.Misc.UltraButton()
        Me.txt_VendorCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.txt_CompanyEmail = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmb_Relationship = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmb_ContractorID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txt_RentPaid = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_Dispensary = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.chk_IsForController = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_CatEmpNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_LICNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_CareOf = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraGridEmpSalary = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddNew = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraGridEmpSalBen = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.btnDel = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_chngRpt = New Infragistics.Win.Misc.UltraButton()
        Me.btn_Person = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.txt_BankAccBearerName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PANNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_UIDNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_BankBranchID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_paymentthrucode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_JobFunc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_DivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_LeftReasonCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_BankAccNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CardNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbid2_iscasual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_isworker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_haswage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_StatusNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_empcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_LeaveDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_JoinDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_reportstoID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_shiftid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_campusid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_depid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_designation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.txt_OpenEWDLastLM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_OpenEWDCurrLM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_PunchEnabled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_LeaveAuth2ID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_LeaveAuth1ID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_userID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_ImprestEnabled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_VendorCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CompanyEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_Relationship, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_ContractorID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_RentPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Dispensary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_IsForController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CatEmpNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_LICNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CareOf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGridEmpSalary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.UltraTabPageControl4.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.UltraGridEmpSalBen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Label11)
        Me.UltraTabPageControl1.Controls.Add(Me.txt_BankAccBearerName)
        Me.UltraTabPageControl1.Controls.Add(Me.btnSelect)
        Me.UltraTabPageControl1.Controls.Add(Me.Label19)
        Me.UltraTabPageControl1.Controls.Add(Me.txt_PANNum)
        Me.UltraTabPageControl1.Controls.Add(Me.Label18)
        Me.UltraTabPageControl1.Controls.Add(Me.txt_UIDNum)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel21)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_BankBranchID)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_paymentthrucode)
        Me.UltraTabPageControl1.Controls.Add(Me.txt_JobFunc)
        Me.UltraTabPageControl1.Controls.Add(Me.Label27)
        Me.UltraTabPageControl1.Controls.Add(Me.Label17)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_DivisionID)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_LeftReasonCode)
        Me.UltraTabPageControl1.Controls.Add(Me.Label30)
        Me.UltraTabPageControl1.Controls.Add(Me.Label26)
        Me.UltraTabPageControl1.Controls.Add(Me.Label8)
        Me.UltraTabPageControl1.Controls.Add(Me.txt_BankAccNum)
        Me.UltraTabPageControl1.Controls.Add(Me.Label1)
        Me.UltraTabPageControl1.Controls.Add(Me.txt_CardNum)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbid2_iscasual)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_isworker)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_haswage)
        Me.UltraTabPageControl1.Controls.Add(Me.Label24)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_StatusNum)
        Me.UltraTabPageControl1.Controls.Add(Me.Label10)
        Me.UltraTabPageControl1.Controls.Add(Me.txt_empcode)
        Me.UltraTabPageControl1.Controls.Add(Me.dt_LeaveDate)
        Me.UltraTabPageControl1.Controls.Add(Me.Label9)
        Me.UltraTabPageControl1.Controls.Add(Me.dt_JoinDate)
        Me.UltraTabPageControl1.Controls.Add(Me.lblDate)
        Me.UltraTabPageControl1.Controls.Add(Me.labelid2_8)
        Me.UltraTabPageControl1.Controls.Add(Me.Label7)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_reportstoID)
        Me.UltraTabPageControl1.Controls.Add(Me.Label6)
        Me.UltraTabPageControl1.Controls.Add(Me.Label4)
        Me.UltraTabPageControl1.Controls.Add(Me.Label3)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_shiftid)
        Me.UltraTabPageControl1.Controls.Add(Me.Label2)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_campusid)
        Me.UltraTabPageControl1.Controls.Add(Me.Label5)
        Me.UltraTabPageControl1.Controls.Add(Me.cmb_depid)
        Me.UltraTabPageControl1.Controls.Add(Me.Label21)
        Me.UltraTabPageControl1.Controls.Add(Me.txt_designation)
        Me.UltraTabPageControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(744, 356)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(410, 239)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Bearer Name"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_BankAccBearerName
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.txt_BankAccBearerName.Appearance = Appearance1
        Me.txt_BankAccBearerName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_BankAccBearerName.Location = New System.Drawing.Point(483, 238)
        Me.txt_BankAccBearerName.Name = "txt_BankAccBearerName"
        Me.txt_BankAccBearerName.Size = New System.Drawing.Size(240, 17)
        Me.txt_BankAccBearerName.TabIndex = 49
        Me.txt_BankAccBearerName.Text = "UltraTextEditor2"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(631, 212)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(92, 20)
        Me.btnSelect.TabIndex = 47
        Me.btnSelect.Text = "Select"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(428, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 14)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "PANNum"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PANNum
        '
        Appearance2.FontData.BoldAsString = "False"
        Me.txt_PANNum.Appearance = Appearance2
        Me.txt_PANNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PANNum.Location = New System.Drawing.Point(483, 45)
        Me.txt_PANNum.Name = "txt_PANNum"
        Me.txt_PANNum.Size = New System.Drawing.Size(240, 17)
        Me.txt_PANNum.TabIndex = 46
        Me.txt_PANNum.Text = "UltraTextEditor2"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(432, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 14)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "UIDNum"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_UIDNum
        '
        Appearance3.FontData.BoldAsString = "False"
        Me.txt_UIDNum.Appearance = Appearance3
        Me.txt_UIDNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_UIDNum.Location = New System.Drawing.Point(483, 17)
        Me.txt_UIDNum.Name = "txt_UIDNum"
        Me.txt_UIDNum.Size = New System.Drawing.Size(240, 17)
        Me.txt_UIDNum.TabIndex = 44
        Me.txt_UIDNum.Text = "UltraTextEditor2"
        '
        'UltraLabel21
        '
        Appearance4.FontData.SizeInPoints = 8.25!
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel21.Appearance = Appearance4
        Me.UltraLabel21.AutoSize = True
        Me.UltraLabel21.Location = New System.Drawing.Point(407, 186)
        Me.UltraLabel21.Name = "UltraLabel21"
        Me.UltraLabel21.Size = New System.Drawing.Size(69, 14)
        Me.UltraLabel21.TabIndex = 41
        Me.UltraLabel21.Text = "Bank Branch"
        '
        'cmb_BankBranchID
        '
        Me.cmb_BankBranchID.Location = New System.Drawing.Point(483, 183)
        Me.cmb_BankBranchID.Name = "cmb_BankBranchID"
        Me.cmb_BankBranchID.ReadOnly = True
        Me.cmb_BankBranchID.Size = New System.Drawing.Size(240, 22)
        Me.cmb_BankBranchID.TabIndex = 42
        '
        'cmb_paymentthrucode
        '
        Appearance5.FontData.BoldAsString = "False"
        Me.cmb_paymentthrucode.Appearance = Appearance5
        Me.cmb_paymentthrucode.Location = New System.Drawing.Point(483, 269)
        Me.cmb_paymentthrucode.Name = "cmb_paymentthrucode"
        Me.cmb_paymentthrucode.Size = New System.Drawing.Size(240, 22)
        Me.cmb_paymentthrucode.TabIndex = 27
        Me.cmb_paymentthrucode.Text = "UltraCombo5"
        '
        'txt_JobFunc
        '
        Appearance6.FontData.BoldAsString = "False"
        Me.txt_JobFunc.Appearance = Appearance6
        Me.txt_JobFunc.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_JobFunc.Location = New System.Drawing.Point(483, 69)
        Me.txt_JobFunc.Name = "txt_JobFunc"
        Me.txt_JobFunc.Size = New System.Drawing.Size(240, 17)
        Me.txt_JobFunc.TabIndex = 13
        Me.txt_JobFunc.Text = "UltraTextEditor2"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(432, 71)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(48, 14)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Function"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(436, 334)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 14)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "Division"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_DivisionID
        '
        Appearance7.FontData.BoldAsString = "False"
        Me.cmb_DivisionID.Appearance = Appearance7
        Me.cmb_DivisionID.Location = New System.Drawing.Point(483, 330)
        Me.cmb_DivisionID.Name = "cmb_DivisionID"
        Me.cmb_DivisionID.Size = New System.Drawing.Size(240, 22)
        Me.cmb_DivisionID.TabIndex = 35
        Me.cmb_DivisionID.Text = "UltraCombo5"
        '
        'cmb_LeftReasonCode
        '
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmb_LeftReasonCode.DisplayLayout.Appearance = Appearance8
        Me.cmb_LeftReasonCode.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmb_LeftReasonCode.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_LeftReasonCode.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_LeftReasonCode.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.cmb_LeftReasonCode.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmb_LeftReasonCode.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.cmb_LeftReasonCode.DisplayLayout.MaxColScrollRegions = 1
        Me.cmb_LeftReasonCode.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmb_LeftReasonCode.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmb_LeftReasonCode.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.cmb_LeftReasonCode.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmb_LeftReasonCode.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.cmb_LeftReasonCode.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmb_LeftReasonCode.DisplayLayout.Override.CellAppearance = Appearance15
        Me.cmb_LeftReasonCode.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cmb_LeftReasonCode.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.cmb_LeftReasonCode.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.cmb_LeftReasonCode.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.cmb_LeftReasonCode.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmb_LeftReasonCode.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.cmb_LeftReasonCode.DisplayLayout.Override.RowAppearance = Appearance18
        Me.cmb_LeftReasonCode.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_LeftReasonCode.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.cmb_LeftReasonCode.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmb_LeftReasonCode.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmb_LeftReasonCode.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmb_LeftReasonCode.Location = New System.Drawing.Point(120, 312)
        Me.cmb_LeftReasonCode.Name = "cmb_LeftReasonCode"
        Me.cmb_LeftReasonCode.ReadOnly = True
        Me.cmb_LeftReasonCode.Size = New System.Drawing.Size(240, 22)
        Me.cmb_LeftReasonCode.TabIndex = 39
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(13, 316)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(104, 14)
        Me.Label30.TabIndex = 38
        Me.Label30.Text = "Reason For Leaving"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(389, 273)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(91, 14)
        Me.Label26.TabIndex = 26
        Me.Label26.Text = "Payment Through"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(364, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 14)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Bank Account Number"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_BankAccNum
        '
        Appearance20.FontData.BoldAsString = "False"
        Me.txt_BankAccNum.Appearance = Appearance20
        Me.txt_BankAccNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_BankAccNum.Location = New System.Drawing.Point(483, 157)
        Me.txt_BankAccNum.Name = "txt_BankAccNum"
        Me.txt_BankAccNum.Size = New System.Drawing.Size(240, 17)
        Me.txt_BankAccNum.TabIndex = 19
        Me.txt_BankAccNum.Text = "UltraTextEditor2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(410, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Card Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_CardNum
        '
        Appearance21.FontData.BoldAsString = "False"
        Me.txt_CardNum.Appearance = Appearance21
        Me.txt_CardNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CardNum.Location = New System.Drawing.Point(483, 126)
        Me.txt_CardNum.Name = "txt_CardNum"
        Me.txt_CardNum.Size = New System.Drawing.Size(240, 17)
        Me.txt_CardNum.TabIndex = 15
        Me.txt_CardNum.Text = "UltraTextEditor2"
        '
        'cmbid2_iscasual
        '
        ValueListItem1.DataValue = False
        ValueListItem1.DisplayText = "Normal"
        ValueListItem2.DataValue = True
        ValueListItem2.DisplayText = "Casual"
        Me.cmbid2_iscasual.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.cmbid2_iscasual.Location = New System.Drawing.Point(483, 95)
        Me.cmbid2_iscasual.Name = "cmbid2_iscasual"
        Me.cmbid2_iscasual.Size = New System.Drawing.Size(240, 21)
        Me.cmbid2_iscasual.TabIndex = 11
        Me.cmbid2_iscasual.Text = "UltraComboEditor9"
        '
        'cmb_isworker
        '
        ValueListItem3.DataValue = False
        ValueListItem3.DisplayText = "Staff"
        ValueListItem4.DataValue = True
        ValueListItem4.DisplayText = "Worker"
        Me.cmb_isworker.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.cmb_isworker.Location = New System.Drawing.Point(120, 221)
        Me.cmb_isworker.Name = "cmb_isworker"
        Me.cmb_isworker.Size = New System.Drawing.Size(240, 21)
        Me.cmb_isworker.TabIndex = 29
        Me.cmb_isworker.Text = "UltraComboEditor9"
        '
        'cmb_haswage
        '
        ValueListItem5.DataValue = False
        ValueListItem5.DisplayText = "Salary"
        ValueListItem6.DataValue = True
        ValueListItem6.DisplayText = "Wage"
        Me.cmb_haswage.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem5, ValueListItem6})
        Me.cmb_haswage.Location = New System.Drawing.Point(120, 191)
        Me.cmb_haswage.Name = "cmb_haswage"
        Me.cmb_haswage.Size = New System.Drawing.Size(240, 21)
        Me.cmb_haswage.TabIndex = 25
        Me.cmb_haswage.Text = "UltraComboEditor9"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(442, 303)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(38, 14)
        Me.Label24.TabIndex = 30
        Me.Label24.Text = "Status"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_StatusNum
        '
        Appearance22.FontData.BoldAsString = "False"
        Me.cmb_StatusNum.Appearance = Appearance22
        Me.cmb_StatusNum.Location = New System.Drawing.Point(483, 299)
        Me.cmb_StatusNum.Name = "cmb_StatusNum"
        Me.cmb_StatusNum.Size = New System.Drawing.Size(240, 22)
        Me.cmb_StatusNum.TabIndex = 31
        Me.cmb_StatusNum.Text = "UltraCombo5"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(85, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 14)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Code"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_empcode
        '
        Appearance23.FontData.BoldAsString = "False"
        Me.txt_empcode.Appearance = Appearance23
        Me.txt_empcode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_empcode.Location = New System.Drawing.Point(120, 16)
        Me.txt_empcode.Name = "txt_empcode"
        Me.txt_empcode.Size = New System.Drawing.Size(144, 17)
        Me.txt_empcode.TabIndex = 1
        Me.txt_empcode.Text = "UltraTextEditor2"
        '
        'dt_LeaveDate
        '
        Appearance24.FontData.BoldAsString = "False"
        Appearance24.FontData.ItalicAsString = "False"
        Appearance24.FontData.Name = "Arial"
        Appearance24.FontData.SizeInPoints = 8.25!
        Appearance24.FontData.StrikeoutAsString = "False"
        Appearance24.FontData.UnderlineAsString = "False"
        Me.dt_LeaveDate.Appearance = Appearance24
        Me.dt_LeaveDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_LeaveDate.FormatString = "dddd dd MMM yyyy"
        Me.dt_LeaveDate.Location = New System.Drawing.Point(120, 282)
        Me.dt_LeaveDate.Name = "dt_LeaveDate"
        Me.dt_LeaveDate.NullText = "Not Defined"
        Me.dt_LeaveDate.ReadOnly = True
        Me.dt_LeaveDate.Size = New System.Drawing.Size(240, 21)
        Me.dt_LeaveDate.TabIndex = 37
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(58, 285)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 14)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "LeaveDate"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dt_JoinDate
        '
        Appearance25.FontData.BoldAsString = "False"
        Appearance25.FontData.ItalicAsString = "False"
        Appearance25.FontData.Name = "Arial"
        Appearance25.FontData.SizeInPoints = 8.25!
        Appearance25.FontData.StrikeoutAsString = "False"
        Appearance25.FontData.UnderlineAsString = "False"
        Me.dt_JoinDate.Appearance = Appearance25
        Me.dt_JoinDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_JoinDate.FormatString = "dddd dd MMM yyyy"
        Me.dt_JoinDate.Location = New System.Drawing.Point(120, 42)
        Me.dt_JoinDate.Name = "dt_JoinDate"
        Me.dt_JoinDate.NullText = "Not Defined"
        Me.dt_JoinDate.Size = New System.Drawing.Size(240, 21)
        Me.dt_JoinDate.TabIndex = 7
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(69, 46)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(48, 14)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "JoinDate"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelid2_8
        '
        Me.labelid2_8.AutoSize = True
        Me.labelid2_8.Location = New System.Drawing.Point(441, 98)
        Me.labelid2_8.Name = "labelid2_8"
        Me.labelid2_8.Size = New System.Drawing.Size(39, 14)
        Me.labelid2_8.TabIndex = 10
        Me.labelid2_8.Text = "Nature"
        Me.labelid2_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(58, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 14)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Reports To"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_reportstoID
        '
        Appearance26.FontData.BoldAsString = "False"
        Me.cmb_reportstoID.Appearance = Appearance26
        Me.cmb_reportstoID.Location = New System.Drawing.Point(120, 251)
        Me.cmb_reportstoID.Name = "cmb_reportstoID"
        Me.cmb_reportstoID.Size = New System.Drawing.Size(240, 22)
        Me.cmb_reportstoID.TabIndex = 33
        Me.cmb_reportstoID.Text = "UltraCombo5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 14)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Work Force Category"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 14)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Salary Category"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(88, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 14)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Shift"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_shiftid
        '
        Appearance27.FontData.BoldAsString = "False"
        Me.cmb_shiftid.Appearance = Appearance27
        Me.cmb_shiftid.Location = New System.Drawing.Point(120, 160)
        Me.cmb_shiftid.Name = "cmb_shiftid"
        Me.cmb_shiftid.Size = New System.Drawing.Size(240, 22)
        Me.cmb_shiftid.TabIndex = 21
        Me.cmb_shiftid.Text = "UltraCombo5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Campus"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_campusid
        '
        Appearance28.FontData.BoldAsString = "False"
        Me.cmb_campusid.Appearance = Appearance28
        Me.cmb_campusid.Location = New System.Drawing.Point(120, 129)
        Me.cmb_campusid.Name = "cmb_campusid"
        Me.cmb_campusid.Size = New System.Drawing.Size(240, 22)
        Me.cmb_campusid.TabIndex = 17
        Me.cmb_campusid.Text = "UltraCombo5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(55, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Department"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_depid
        '
        Appearance29.FontData.BoldAsString = "False"
        Me.cmb_depid.Appearance = Appearance29
        Me.cmb_depid.Location = New System.Drawing.Point(120, 98)
        Me.cmb_depid.Name = "cmb_depid"
        Me.cmb_depid.Size = New System.Drawing.Size(240, 22)
        Me.cmb_depid.TabIndex = 9
        Me.cmb_depid.Text = "UltraCombo5"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(54, 73)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 14)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Designation"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_designation
        '
        Appearance30.FontData.BoldAsString = "False"
        Me.txt_designation.Appearance = Appearance30
        Me.txt_designation.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_designation.Location = New System.Drawing.Point(120, 72)
        Me.txt_designation.Name = "txt_designation"
        Me.txt_designation.Size = New System.Drawing.Size(240, 17)
        Me.txt_designation.TabIndex = 5
        Me.txt_designation.Text = "UltraTextEditor2"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.btn_CalcleaveBal)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_OpenEWDLastLM)
        Me.UltraTabPageControl3.Controls.Add(Me.Label34)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_OpenEWDCurrLM)
        Me.UltraTabPageControl3.Controls.Add(Me.Label33)
        Me.UltraTabPageControl3.Controls.Add(Me.cmb_PunchEnabled)
        Me.UltraTabPageControl3.Controls.Add(Me.Label32)
        Me.UltraTabPageControl3.Controls.Add(Me.Label31)
        Me.UltraTabPageControl3.Controls.Add(Me.cmb_LeaveAuth2ID)
        Me.UltraTabPageControl3.Controls.Add(Me.Label23)
        Me.UltraTabPageControl3.Controls.Add(Me.cmb_LeaveAuth1ID)
        Me.UltraTabPageControl3.Controls.Add(Me.Label20)
        Me.UltraTabPageControl3.Controls.Add(Me.cmb_userID)
        Me.UltraTabPageControl3.Controls.Add(Me.cmb_ImprestEnabled)
        Me.UltraTabPageControl3.Controls.Add(Me.Label14)
        Me.UltraTabPageControl3.Controls.Add(Me.btnCreateVendor)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_VendorCode)
        Me.UltraTabPageControl3.Controls.Add(Me.lblNum)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_CompanyEmail)
        Me.UltraTabPageControl3.Controls.Add(Me.Label13)
        Me.UltraTabPageControl3.Controls.Add(Me.cmb_Relationship)
        Me.UltraTabPageControl3.Controls.Add(Me.Label29)
        Me.UltraTabPageControl3.Controls.Add(Me.Label28)
        Me.UltraTabPageControl3.Controls.Add(Me.cmb_ContractorID)
        Me.UltraTabPageControl3.Controls.Add(Me.Label25)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_RentPaid)
        Me.UltraTabPageControl3.Controls.Add(Me.Label22)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_Dispensary)
        Me.UltraTabPageControl3.Controls.Add(Me.chk_IsForController)
        Me.UltraTabPageControl3.Controls.Add(Me.Label16)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_CatEmpNum)
        Me.UltraTabPageControl3.Controls.Add(Me.Label15)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_LICNum)
        Me.UltraTabPageControl3.Controls.Add(Me.Label12)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_CareOf)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(744, 356)
        '
        'btn_CalcleaveBal
        '
        Appearance31.FontData.BoldAsString = "True"
        Me.btn_CalcleaveBal.Appearance = Appearance31
        Me.btn_CalcleaveBal.Location = New System.Drawing.Point(358, 297)
        Me.btn_CalcleaveBal.Name = "btn_CalcleaveBal"
        Me.btn_CalcleaveBal.Size = New System.Drawing.Size(103, 39)
        Me.btn_CalcleaveBal.TabIndex = 44
        Me.btn_CalcleaveBal.Text = "Calculate Leave Balance"
        '
        'txt_OpenEWDLastLM
        '
        Appearance32.FontData.BoldAsString = "False"
        Me.txt_OpenEWDLastLM.Appearance = Appearance32
        Me.txt_OpenEWDLastLM.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_OpenEWDLastLM.Location = New System.Drawing.Point(129, 322)
        Me.txt_OpenEWDLastLM.Name = "txt_OpenEWDLastLM"
        Me.txt_OpenEWDLastLM.Size = New System.Drawing.Size(218, 17)
        Me.txt_OpenEWDLastLM.TabIndex = 43
        Me.txt_OpenEWDLastLM.Text = "UltraTextEditor8"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(25, 323)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(92, 14)
        Me.Label34.TabIndex = 42
        Me.Label34.Text = "Last Working Day"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_OpenEWDCurrLM
        '
        Appearance33.FontData.BoldAsString = "False"
        Me.txt_OpenEWDCurrLM.Appearance = Appearance33
        Me.txt_OpenEWDCurrLM.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_OpenEWDCurrLM.Location = New System.Drawing.Point(130, 297)
        Me.txt_OpenEWDCurrLM.Name = "txt_OpenEWDCurrLM"
        Me.txt_OpenEWDCurrLM.Size = New System.Drawing.Size(218, 17)
        Me.txt_OpenEWDCurrLM.TabIndex = 41
        Me.txt_OpenEWDCurrLM.Text = "UltraTextEditor8"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(13, 298)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(107, 14)
        Me.Label33.TabIndex = 40
        Me.Label33.Text = "Current Working Day"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_PunchEnabled
        '
        Me.cmb_PunchEnabled.Location = New System.Drawing.Point(464, 188)
        Me.cmb_PunchEnabled.Name = "cmb_PunchEnabled"
        Me.cmb_PunchEnabled.Size = New System.Drawing.Size(224, 21)
        Me.cmb_PunchEnabled.TabIndex = 39
        Me.cmb_PunchEnabled.Text = "UltraComboEditor9"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(419, 192)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(37, 14)
        Me.Label32.TabIndex = 38
        Me.Label32.Text = "Punch"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(374, 165)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(87, 14)
        Me.Label31.TabIndex = 37
        Me.Label31.Text = "LeaveAuthority2"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_LeaveAuth2ID
        '
        Appearance34.FontData.BoldAsString = "False"
        Me.cmb_LeaveAuth2ID.Appearance = Appearance34
        Me.cmb_LeaveAuth2ID.Location = New System.Drawing.Point(464, 161)
        Me.cmb_LeaveAuth2ID.Name = "cmb_LeaveAuth2ID"
        Me.cmb_LeaveAuth2ID.Size = New System.Drawing.Size(224, 22)
        Me.cmb_LeaveAuth2ID.TabIndex = 36
        Me.cmb_LeaveAuth2ID.Text = "UltraCombo5"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(374, 136)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(87, 14)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "LeaveAuthority1"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_LeaveAuth1ID
        '
        Appearance35.FontData.BoldAsString = "False"
        Me.cmb_LeaveAuth1ID.Appearance = Appearance35
        Me.cmb_LeaveAuth1ID.Location = New System.Drawing.Point(464, 132)
        Me.cmb_LeaveAuth1ID.Name = "cmb_LeaveAuth1ID"
        Me.cmb_LeaveAuth1ID.Size = New System.Drawing.Size(224, 22)
        Me.cmb_LeaveAuth1ID.TabIndex = 35
        Me.cmb_LeaveAuth1ID.Text = "UltraCombo5"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(428, 109)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 14)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "User"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_userID
        '
        Appearance36.FontData.BoldAsString = "False"
        Me.cmb_userID.Appearance = Appearance36
        Me.cmb_userID.Location = New System.Drawing.Point(464, 106)
        Me.cmb_userID.Name = "cmb_userID"
        Me.cmb_userID.Size = New System.Drawing.Size(240, 22)
        Me.cmb_userID.TabIndex = 25
        Me.cmb_userID.Text = "UltraCombo5"
        '
        'cmb_ImprestEnabled
        '
        Me.cmb_ImprestEnabled.Location = New System.Drawing.Point(128, 265)
        Me.cmb_ImprestEnabled.Name = "cmb_ImprestEnabled"
        Me.cmb_ImprestEnabled.Size = New System.Drawing.Size(240, 21)
        Me.cmb_ImprestEnabled.TabIndex = 21
        Me.cmb_ImprestEnabled.Text = "UltraComboEditor9"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(78, 269)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 14)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Imprest"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCreateVendor
        '
        Me.btnCreateVendor.Location = New System.Drawing.Point(371, 238)
        Me.btnCreateVendor.Name = "btnCreateVendor"
        Me.btnCreateVendor.Size = New System.Drawing.Size(92, 20)
        Me.btnCreateVendor.TabIndex = 19
        Me.btnCreateVendor.Text = "Create"
        '
        'txt_VendorCode
        '
        Appearance37.FontData.BoldAsString = "True"
        Appearance37.FontData.SizeInPoints = 9.0!
        Me.txt_VendorCode.Appearance = Appearance37
        Me.txt_VendorCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_VendorCode.Location = New System.Drawing.Point(128, 238)
        Me.txt_VendorCode.Name = "txt_VendorCode"
        Me.txt_VendorCode.ReadOnly = True
        Me.txt_VendorCode.Size = New System.Drawing.Size(240, 18)
        Me.txt_VendorCode.TabIndex = 18
        Me.txt_VendorCode.Text = "UltraTextEditor2"
        '
        'lblNum
        '
        Me.lblNum.AutoSize = True
        Me.lblNum.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNum.Location = New System.Drawing.Point(42, 240)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(79, 15)
        Me.lblNum.TabIndex = 17
        Me.lblNum.Text = "Vendor Code"
        Me.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_CompanyEmail
        '
        Appearance38.FontData.BoldAsString = "False"
        Me.txt_CompanyEmail.Appearance = Appearance38
        Me.txt_CompanyEmail.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CompanyEmail.Location = New System.Drawing.Point(129, 191)
        Me.txt_CompanyEmail.Name = "txt_CompanyEmail"
        Me.txt_CompanyEmail.Size = New System.Drawing.Size(240, 17)
        Me.txt_CompanyEmail.TabIndex = 16
        Me.txt_CompanyEmail.Text = "UltraTextEditor8"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 192)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 14)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Company Email"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Relationship
        '
        Me.cmb_Relationship.Location = New System.Drawing.Point(464, 57)
        Me.cmb_Relationship.Name = "cmb_Relationship"
        Me.cmb_Relationship.Size = New System.Drawing.Size(170, 21)
        Me.cmb_Relationship.TabIndex = 5
        Me.cmb_Relationship.Text = "UltraComboEditor9"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(396, 60)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 14)
        Me.Label29.TabIndex = 4
        Me.Label29.Text = "Relationship"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(65, 29)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(58, 14)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "Contractor"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_ContractorID
        '
        Appearance39.FontData.BoldAsString = "False"
        Me.cmb_ContractorID.Appearance = Appearance39
        Me.cmb_ContractorID.Location = New System.Drawing.Point(128, 26)
        Me.cmb_ContractorID.Name = "cmb_ContractorID"
        Me.cmb_ContractorID.Size = New System.Drawing.Size(506, 22)
        Me.cmb_ContractorID.TabIndex = 1
        Me.cmb_ContractorID.Text = "UltraCombo5"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(69, 84)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(52, 14)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Rent Paid"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_RentPaid
        '
        Appearance40.FontData.BoldAsString = "False"
        Me.txt_RentPaid.Appearance = Appearance40
        Me.txt_RentPaid.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_RentPaid.Location = New System.Drawing.Point(128, 83)
        Me.txt_RentPaid.Name = "txt_RentPaid"
        Me.txt_RentPaid.Size = New System.Drawing.Size(240, 17)
        Me.txt_RentPaid.TabIndex = 7
        Me.txt_RentPaid.Text = "UltraTextEditor3"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(58, 216)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 14)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "Dispensary"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Dispensary
        '
        Appearance41.FontData.BoldAsString = "False"
        Me.txt_Dispensary.Appearance = Appearance41
        Me.txt_Dispensary.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Dispensary.Location = New System.Drawing.Point(128, 214)
        Me.txt_Dispensary.Name = "txt_Dispensary"
        Me.txt_Dispensary.Size = New System.Drawing.Size(506, 17)
        Me.txt_Dispensary.TabIndex = 14
        Me.txt_Dispensary.Text = "UltraTextEditor8"
        '
        'chk_IsForController
        '
        Me.chk_IsForController.Location = New System.Drawing.Point(128, 161)
        Me.chk_IsForController.Name = "chk_IsForController"
        Me.chk_IsForController.Size = New System.Drawing.Size(152, 24)
        Me.chk_IsForController.TabIndex = 12
        Me.chk_IsForController.Text = "Is For Controller"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(35, 136)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 14)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Cat Emp Number"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_CatEmpNum
        '
        Appearance42.FontData.BoldAsString = "False"
        Me.txt_CatEmpNum.Appearance = Appearance42
        Me.txt_CatEmpNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CatEmpNum.Location = New System.Drawing.Point(128, 135)
        Me.txt_CatEmpNum.Name = "txt_CatEmpNum"
        Me.txt_CatEmpNum.Size = New System.Drawing.Size(240, 17)
        Me.txt_CatEmpNum.TabIndex = 11
        Me.txt_CatEmpNum.Text = "UltraTextEditor7"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(60, 110)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 14)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "LIC Number"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_LICNum
        '
        Appearance43.FontData.BoldAsString = "False"
        Me.txt_LICNum.Appearance = Appearance43
        Me.txt_LICNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_LICNum.Location = New System.Drawing.Point(128, 109)
        Me.txt_LICNum.Name = "txt_LICNum"
        Me.txt_LICNum.Size = New System.Drawing.Size(240, 17)
        Me.txt_LICNum.TabIndex = 9
        Me.txt_LICNum.Text = "UltraTextEditor6"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(77, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 14)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Care Of"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_CareOf
        '
        Appearance44.FontData.BoldAsString = "False"
        Me.txt_CareOf.Appearance = Appearance44
        Me.txt_CareOf.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CareOf.Location = New System.Drawing.Point(128, 57)
        Me.txt_CareOf.Name = "txt_CareOf"
        Me.txt_CareOf.Size = New System.Drawing.Size(240, 17)
        Me.txt_CareOf.TabIndex = 3
        Me.txt_CareOf.Text = "UltraTextEditor3"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Panel2)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(744, 356)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraGridEmpSalary)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(744, 356)
        Me.Panel2.TabIndex = 8
        '
        'UltraGridEmpSalary
        '
        Me.UltraGridEmpSalary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridEmpSalary.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridEmpSalary.Name = "UltraGridEmpSalary"
        Me.UltraGridEmpSalary.Size = New System.Drawing.Size(744, 326)
        Me.UltraGridEmpSalary.TabIndex = 0
        Me.UltraGridEmpSalary.Text = "Delivery Schedule"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnEdit)
        Me.Panel3.Controls.Add(Me.btnAddNew)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 326)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(744, 30)
        Me.Panel3.TabIndex = 1
        '
        'btnEdit
        '
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnEdit.Location = New System.Drawing.Point(600, 0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(72, 30)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Text = "Edit"
        '
        'btnAddNew
        '
        Me.btnAddNew.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddNew.Location = New System.Drawing.Point(672, 0)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(72, 30)
        Me.btnAddNew.TabIndex = 1
        Me.btnAddNew.Text = "Add New"
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.UltraPanel1)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraPanel2)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(744, 356)
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraGridEmpSalBen)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(744, 325)
        Me.UltraPanel1.TabIndex = 0
        '
        'UltraGridEmpSalBen
        '
        Appearance45.BackColor = System.Drawing.SystemColors.Window
        Appearance45.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGridEmpSalBen.DisplayLayout.Appearance = Appearance45
        Me.UltraGridEmpSalBen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGridEmpSalBen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance46.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance46.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridEmpSalBen.DisplayLayout.GroupByBox.Appearance = Appearance46
        Appearance47.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridEmpSalBen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance47
        Me.UltraGridEmpSalBen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance48.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance48.BackColor2 = System.Drawing.SystemColors.Control
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance48.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridEmpSalBen.DisplayLayout.GroupByBox.PromptAppearance = Appearance48
        Me.UltraGridEmpSalBen.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGridEmpSalBen.DisplayLayout.MaxRowScrollRegions = 1
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UltraGridEmpSalBen.DisplayLayout.Override.ActiveCellAppearance = Appearance49
        Appearance50.BackColor = System.Drawing.SystemColors.Highlight
        Appearance50.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UltraGridEmpSalBen.DisplayLayout.Override.ActiveRowAppearance = Appearance50
        Me.UltraGridEmpSalBen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGridEmpSalBen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGridEmpSalBen.DisplayLayout.Override.CardAreaAppearance = Appearance51
        Appearance52.BorderColor = System.Drawing.Color.Silver
        Appearance52.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGridEmpSalBen.DisplayLayout.Override.CellAppearance = Appearance52
        Me.UltraGridEmpSalBen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGridEmpSalBen.DisplayLayout.Override.CellPadding = 0
        Appearance53.BackColor = System.Drawing.SystemColors.Control
        Appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance53.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance53.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridEmpSalBen.DisplayLayout.Override.GroupByRowAppearance = Appearance53
        Appearance54.TextHAlignAsString = "Left"
        Me.UltraGridEmpSalBen.DisplayLayout.Override.HeaderAppearance = Appearance54
        Me.UltraGridEmpSalBen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UltraGridEmpSalBen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Appearance55.BorderColor = System.Drawing.Color.Silver
        Me.UltraGridEmpSalBen.DisplayLayout.Override.RowAppearance = Appearance55
        Me.UltraGridEmpSalBen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance56.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGridEmpSalBen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance56
        Me.UltraGridEmpSalBen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGridEmpSalBen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGridEmpSalBen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.UltraGridEmpSalBen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridEmpSalBen.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridEmpSalBen.Name = "UltraGridEmpSalBen"
        Me.UltraGridEmpSalBen.Size = New System.Drawing.Size(744, 325)
        Me.UltraGridEmpSalBen.TabIndex = 0
        Me.UltraGridEmpSalBen.Text = "UltraGrid1"
        '
        'UltraPanel2
        '
        '
        'UltraPanel2.ClientArea
        '
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnAdd)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnDel)
        Me.UltraPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 325)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(744, 31)
        Me.UltraPanel2.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAdd.Location = New System.Drawing.Point(601, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(70, 31)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add New"
        '
        'btnDel
        '
        Me.btnDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDel.Location = New System.Drawing.Point(671, 0)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(73, 31)
        Me.btnDel.TabIndex = 1
        Me.btnDel.Text = "Delete"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 48)
        Me.Panel1.TabIndex = 4
        '
        'lblName
        '
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(0, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(748, 48)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Mr xxx yyy"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_chngRpt)
        Me.Panel4.Controls.Add(Me.btn_Person)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 430)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(748, 39)
        Me.Panel4.TabIndex = 5
        '
        'btn_chngRpt
        '
        Appearance57.FontData.BoldAsString = "True"
        Me.btn_chngRpt.Appearance = Appearance57
        Me.btn_chngRpt.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_chngRpt.Location = New System.Drawing.Point(160, 0)
        Me.btn_chngRpt.Name = "btn_chngRpt"
        Me.btn_chngRpt.Size = New System.Drawing.Size(84, 39)
        Me.btn_chngRpt.TabIndex = 1
        Me.btn_chngRpt.Text = "Change Reporting"
        '
        'btn_Person
        '
        Appearance58.FontData.BoldAsString = "True"
        Me.btn_Person.Appearance = Appearance58
        Me.btn_Person.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Person.Location = New System.Drawing.Point(0, 0)
        Me.btn_Person.Name = "btn_Person"
        Me.btn_Person.Size = New System.Drawing.Size(160, 39)
        Me.btn_Person.TabIndex = 0
        Me.btn_Person.Text = "Open Personal Details"
        '
        'btnSave
        '
        Appearance59.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance59
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(484, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 39)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance60.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance60
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(572, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 39)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance61.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance61
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(660, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 39)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl3)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl4)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 48)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Appearance62.FontData.BoldAsString = "True"
        Me.UltraTabControl1.SelectedTabAppearance = Appearance62
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(748, 382)
        Me.UltraTabControl1.TabIndex = 0
        Me.UltraTabControl1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowAutoSize
        UltraTab1.Key = "Work"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Work"
        UltraTab2.Key = "Details"
        UltraTab2.TabPage = Me.UltraTabPageControl3
        UltraTab2.Text = "Details"
        UltraTab3.Key = "Salary"
        UltraTab3.TabPage = Me.UltraTabPageControl2
        UltraTab3.Text = "Salary"
        UltraTab4.Key = "Benefits"
        UltraTab4.TabPage = Me.UltraTabPageControl4
        UltraTab4.Text = "Benefits"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3, UltraTab4})
        Me.UltraTabControl1.TabsPerRow = 5
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(744, 356)
        '
        'frmEmp
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Employee Details"
        Me.ClientSize = New System.Drawing.Size(748, 469)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmEmp"
        Me.Text = "Employee Details"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.txt_BankAccBearerName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PANNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_UIDNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_BankBranchID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_paymentthrucode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_JobFunc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_DivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_LeftReasonCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_BankAccNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CardNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbid2_iscasual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_isworker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_haswage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_StatusNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_empcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_LeaveDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_JoinDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_reportstoID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_shiftid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_campusid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_depid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_designation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.txt_OpenEWDLastLM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_OpenEWDCurrLM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_PunchEnabled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_LeaveAuth2ID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_LeaveAuth1ID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_userID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_ImprestEnabled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_VendorCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CompanyEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_Relationship, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_ContractorID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_RentPaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Dispensary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_IsForController, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CatEmpNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_LICNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CareOf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.UltraGridEmpSalary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.UltraGridEmpSalBen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_chngRpt As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_LeftReasonCode As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txt_VendorCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblNum As System.Windows.Forms.Label
    Friend WithEvents btnCreateVendor As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_ImprestEnabled As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmb_DivisionID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_paymentthrucode As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel21 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents txt_UIDNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents txt_PANNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents cmb_userID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label31 As Windows.Forms.Label
    Friend WithEvents cmb_LeaveAuth2ID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label23 As Windows.Forms.Label
    Friend WithEvents cmb_LeaveAuth1ID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_PunchEnabled As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label32 As Windows.Forms.Label
    Friend WithEvents txt_OpenEWDCurrLM As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label33 As Windows.Forms.Label
    Friend WithEvents txt_OpenEWDLastLM As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label34 As Windows.Forms.Label
    Friend WithEvents btn_CalcleaveBal As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSelect As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_BankBranchID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents txt_BankAccBearerName As Infragistics.Win.UltraWinEditors.UltraTextEditor

#End Region
End Class

