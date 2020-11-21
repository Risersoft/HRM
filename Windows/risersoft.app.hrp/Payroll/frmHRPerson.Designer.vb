Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Partial Class frmHRPerson
	Inherits frmMax
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txt_NickName As Infragistics.Win.UltraWinEditors.UltraTextEditor

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
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents dt_Anniversary As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dt_BirthDay As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txt_Remark As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_Profile As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_Education As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_PrCity As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_PrAddress As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txt_OfficePhone As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_OfficeArea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_OfficeCountry As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_Web As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_Email As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_CellNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txt_PrPinCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PrPhone As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PrPhArea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PrPhCountry As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PmPinCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PmPhone As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PmPhArea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PmPhCountry As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PmCity As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PmAddress As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmb_MarStatus As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_IsFemale As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_LastName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_MidName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_FirstName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_Salutation As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblNum As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnEdit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddNew As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UGridEmp As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl7 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents UGridEdu As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UGridFam As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UGridExp As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnDelEdu As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddEdu As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDelFam As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddFam As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDelExp As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddExp As Infragistics.Win.Misc.UltraButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pic_PicPerson As System.Windows.Forms.PictureBox
    Friend WithEvents PanelPicSide As System.Windows.Forms.Panel
    Friend WithEvents btnBrowsePic As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmb_TopQual As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnSavepic As Infragistics.Win.Misc.UltraButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab8 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab9 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab10 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControl9 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UGridEmp = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddNew = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl8 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.UltraTabControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_CellNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Email = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_Web = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txt_OfficePhone = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_OfficeArea = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_OfficeCountry = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnLookupGeoPr = New Infragistics.Win.Misc.UltraButton()
        Me.txt_PrGeoPoint = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnCopyPrAdd = New Infragistics.Win.Misc.UltraButton()
        Me.cmb_PrCountry = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmb_PrState = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_PrPinCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_PrPhone = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_PrPhArea = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_PrPhCountry = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_PrCity = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_PrAddress = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnLookupGeoPm = New Infragistics.Win.Misc.UltraButton()
        Me.txt_PmGeoPoint = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmb_PmCountry = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmb_PmState = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_PmPinCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_PmPhone = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_PmPhArea = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txt_PmPhCountry = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txt_PmCity = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txt_PmAddress = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_LastName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_MidName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_FirstName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_Salutation = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txt_NickName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cmb_TopQual = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmb_MarStatus = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmb_IsFemale = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dt_Anniversary = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dt_BirthDay = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txt_Remark = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Profile = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Education = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.UGridEdu = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnDelEdu = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddEdu = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.UGridFam = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnDelFam = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddFam = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.UGridExp = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.btnDelExp = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddExp = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl7 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelPicSide = New System.Windows.Forms.Panel()
        Me.btnSavepic = New Infragistics.Win.Misc.UltraButton()
        Me.btnBrowsePic = New Infragistics.Win.Misc.UltraButton()
        Me.pic_PicPerson = New System.Windows.Forms.PictureBox()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl9.SuspendLayout()
        CType(Me.UGridEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.UltraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl2.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.txt_CellNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Email, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Web, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_OfficePhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_OfficeArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_OfficeCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.txt_PrGeoPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_PrCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_PrState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PrPinCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PrPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PrPhArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PrPhCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PrCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PrAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.txt_PmGeoPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_PmCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_PmState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PmPinCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PmPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PmPhArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PmPhCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PmCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PmAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_LastName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_MidName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FirstName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Salutation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.txt_NickName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_TopQual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_MarStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_IsFemale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Anniversary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_BirthDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Profile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Education, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.UGridEdu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.UltraTabPageControl5.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.UGridFam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.UltraTabPageControl6.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.UGridExp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        Me.UltraTabPageControl7.SuspendLayout()
        Me.PanelPicSide.SuspendLayout()
        CType(Me.pic_PicPerson, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.UltraTabSharedControlsPage1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl9
        '
        Me.UltraTabPageControl9.Controls.Add(Me.UGridEmp)
        Me.UltraTabPageControl9.Controls.Add(Me.Panel6)
        Me.UltraTabPageControl9.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabPageControl9.Name = "UltraTabPageControl9"
        Me.UltraTabPageControl9.Size = New System.Drawing.Size(640, 419)
        '
        'UGridEmp
        '
        Me.UGridEmp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UGridEmp.Location = New System.Drawing.Point(0, 0)
        Me.UGridEmp.Name = "UGridEmp"
        Me.UGridEmp.Size = New System.Drawing.Size(640, 377)
        Me.UGridEmp.TabIndex = 0
        Me.UGridEmp.Text = "Selectable Parties"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnEdit)
        Me.Panel6.Controls.Add(Me.btnAddNew)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 377)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(640, 42)
        Me.Panel6.TabIndex = 1
        '
        'btnEdit
        '
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnEdit.Location = New System.Drawing.Point(368, 0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(128, 42)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Text = "Edit Employee Details"
        '
        'btnAddNew
        '
        Me.btnAddNew.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddNew.Location = New System.Drawing.Point(496, 0)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(144, 42)
        Me.btnAddNew.TabIndex = 1
        Me.btnAddNew.Text = "Add As New Employee"
        '
        'UltraTabPageControl8
        '
        Me.UltraTabPageControl8.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl8.Name = "UltraTabPageControl8"
        Me.UltraTabPageControl8.Size = New System.Drawing.Size(640, 419)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel5)
        Me.UltraTabPageControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(640, 419)
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.UltraTabControl2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(640, 419)
        Me.Panel5.TabIndex = 17
        '
        'UltraTabControl2
        '
        Me.UltraTabControl2.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.UltraTabControl2.Controls.Add(Me.UltraTabPageControl8)
        Me.UltraTabControl2.Controls.Add(Me.UltraTabPageControl9)
        Me.UltraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl2.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl2.Name = "UltraTabControl2"
        Me.UltraTabControl2.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UltraTabControl2.Size = New System.Drawing.Size(640, 419)
        Me.UltraTabControl2.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard
        Me.UltraTabControl2.TabIndex = 0
        UltraTab2.Key = "ED"
        UltraTab2.TabPage = Me.UltraTabPageControl9
        UltraTab2.Text = "Employee Details"
        UltraTab1.Key = "NEmp"
        UltraTab1.TabPage = Me.UltraTabPageControl8
        UltraTab1.Text = "New Employee"
        Me.UltraTabControl2.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2, UltraTab1})
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(640, 419)
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.Label3)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_CellNum)
        Me.UltraTabPageControl3.Controls.Add(Me.Label8)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_Email)
        Me.UltraTabPageControl3.Controls.Add(Me.Label19)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_Web)
        Me.UltraTabPageControl3.Controls.Add(Me.Label31)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_OfficePhone)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_OfficeArea)
        Me.UltraTabPageControl3.Controls.Add(Me.Label16)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_OfficeCountry)
        Me.UltraTabPageControl3.Controls.Add(Me.Panel2)
        Me.UltraTabPageControl3.Controls.Add(Me.Panel3)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(640, 419)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(345, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Mobile"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_CellNum
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.txt_CellNum.Appearance = Appearance1
        Me.txt_CellNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CellNum.Location = New System.Drawing.Point(392, 88)
        Me.txt_CellNum.Name = "txt_CellNum"
        Me.txt_CellNum.Size = New System.Drawing.Size(200, 17)
        Me.txt_CellNum.TabIndex = 5
        Me.txt_CellNum.Text = "UltraTextEditor1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(43, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 14)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Email"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Email
        '
        Appearance2.FontData.BoldAsString = "False"
        Me.txt_Email.Appearance = Appearance2
        Me.txt_Email.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Email.Location = New System.Drawing.Point(80, 112)
        Me.txt_Email.Name = "txt_Email"
        Me.txt_Email.Size = New System.Drawing.Size(200, 17)
        Me.txt_Email.TabIndex = 7
        Me.txt_Email.Text = "UltraTextEditor12"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(322, 115)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 14)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Home page"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Web
        '
        Appearance3.FontData.BoldAsString = "False"
        Me.txt_Web.Appearance = Appearance3
        Me.txt_Web.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Web.Location = New System.Drawing.Point(392, 112)
        Me.txt_Web.Name = "txt_Web"
        Me.txt_Web.Size = New System.Drawing.Size(248, 17)
        Me.txt_Web.TabIndex = 9
        Me.txt_Web.Text = "UltraTextEditor4"
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(8, 136)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(120, 16)
        Me.Label31.TabIndex = 10
        Me.Label31.Text = "Present Address"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_OfficePhone
        '
        Appearance4.FontData.BoldAsString = "False"
        Me.txt_OfficePhone.Appearance = Appearance4
        Me.txt_OfficePhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_OfficePhone.Location = New System.Drawing.Point(160, 88)
        Me.txt_OfficePhone.Name = "txt_OfficePhone"
        Me.txt_OfficePhone.Size = New System.Drawing.Size(152, 17)
        Me.txt_OfficePhone.TabIndex = 3
        Me.txt_OfficePhone.Text = "UltraTextEditor9"
        '
        'txt_OfficeArea
        '
        Appearance5.FontData.BoldAsString = "False"
        Me.txt_OfficeArea.Appearance = Appearance5
        Me.txt_OfficeArea.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_OfficeArea.Location = New System.Drawing.Point(120, 88)
        Me.txt_OfficeArea.Name = "txt_OfficeArea"
        Me.txt_OfficeArea.Size = New System.Drawing.Size(32, 17)
        Me.txt_OfficeArea.TabIndex = 2
        Me.txt_OfficeArea.Text = "UltraTextEditor10"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 91)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 14)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Office Phone"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_OfficeCountry
        '
        Appearance6.FontData.BoldAsString = "False"
        Me.txt_OfficeCountry.Appearance = Appearance6
        Me.txt_OfficeCountry.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_OfficeCountry.Location = New System.Drawing.Point(80, 88)
        Me.txt_OfficeCountry.Name = "txt_OfficeCountry"
        Me.txt_OfficeCountry.Size = New System.Drawing.Size(32, 17)
        Me.txt_OfficeCountry.TabIndex = 1
        Me.txt_OfficeCountry.Text = "UltraTextEditor11"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnLookupGeoPr)
        Me.Panel2.Controls.Add(Me.txt_PrGeoPoint)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.btnCopyPrAdd)
        Me.Panel2.Controls.Add(Me.cmb_PrCountry)
        Me.Panel2.Controls.Add(Me.cmb_PrState)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_PrPinCode)
        Me.Panel2.Controls.Add(Me.txt_PrPhone)
        Me.Panel2.Controls.Add(Me.txt_PrPhArea)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txt_PrPhCountry)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.txt_PrCity)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.txt_PrAddress)
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 155)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(640, 136)
        Me.Panel2.TabIndex = 12
        '
        'btnLookupGeoPr
        '
        Me.btnLookupGeoPr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.FontData.BoldAsString = "True"
        Me.btnLookupGeoPr.Appearance = Appearance7
        Me.btnLookupGeoPr.Location = New System.Drawing.Point(558, 83)
        Me.btnLookupGeoPr.Name = "btnLookupGeoPr"
        Me.btnLookupGeoPr.Size = New System.Drawing.Size(79, 21)
        Me.btnLookupGeoPr.TabIndex = 18
        Me.btnLookupGeoPr.Text = "Lookup"
        '
        'txt_PrGeoPoint
        '
        Appearance8.FontData.BoldAsString = "False"
        Me.txt_PrGeoPoint.Appearance = Appearance8
        Me.txt_PrGeoPoint.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PrGeoPoint.Location = New System.Drawing.Point(440, 85)
        Me.txt_PrGeoPoint.Name = "txt_PrGeoPoint"
        Me.txt_PrGeoPoint.Size = New System.Drawing.Size(112, 17)
        Me.txt_PrGeoPoint.TabIndex = 17
        Me.txt_PrGeoPoint.Text = "UltraTextEditor5"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(379, 87)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 14)
        Me.Label23.TabIndex = 16
        Me.Label23.Text = "Geo Point"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCopyPrAdd
        '
        Me.btnCopyPrAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance9.FontData.BoldAsString = "True"
        Me.btnCopyPrAdd.Appearance = Appearance9
        Me.btnCopyPrAdd.Location = New System.Drawing.Point(516, 108)
        Me.btnCopyPrAdd.Name = "btnCopyPrAdd"
        Me.btnCopyPrAdd.Size = New System.Drawing.Size(121, 25)
        Me.btnCopyPrAdd.TabIndex = 14
        Me.btnCopyPrAdd.Text = "Copy Address"
        '
        'cmb_PrCountry
        '
        Appearance10.FontData.BoldAsString = "False"
        Me.cmb_PrCountry.Appearance = Appearance10
        Me.cmb_PrCountry.Location = New System.Drawing.Point(152, 55)
        Me.cmb_PrCountry.Name = "cmb_PrCountry"
        Me.cmb_PrCountry.Size = New System.Drawing.Size(190, 22)
        Me.cmb_PrCountry.TabIndex = 9
        Me.cmb_PrCountry.Text = "UltraCombo5"
        '
        'cmb_PrState
        '
        Appearance11.FontData.BoldAsString = "False"
        Me.cmb_PrState.Appearance = Appearance11
        Me.cmb_PrState.Location = New System.Drawing.Point(152, 80)
        Me.cmb_PrState.Name = "cmb_PrState"
        Me.cmb_PrState.Size = New System.Drawing.Size(190, 22)
        Me.cmb_PrState.TabIndex = 11
        Me.cmb_PrState.Text = "UltraCombo5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(111, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 14)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "State"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(98, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Country"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PrPinCode
        '
        Appearance12.FontData.BoldAsString = "False"
        Me.txt_PrPinCode.Appearance = Appearance12
        Me.txt_PrPinCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PrPinCode.Location = New System.Drawing.Point(440, 63)
        Me.txt_PrPinCode.Name = "txt_PrPinCode"
        Me.txt_PrPinCode.Size = New System.Drawing.Size(112, 17)
        Me.txt_PrPinCode.TabIndex = 13
        Me.txt_PrPinCode.Text = "UltraTextEditor5"
        '
        'txt_PrPhone
        '
        Appearance13.FontData.BoldAsString = "False"
        Me.txt_PrPhone.Appearance = Appearance13
        Me.txt_PrPhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PrPhone.Location = New System.Drawing.Point(440, 32)
        Me.txt_PrPhone.Name = "txt_PrPhone"
        Me.txt_PrPhone.Size = New System.Drawing.Size(176, 17)
        Me.txt_PrPhone.TabIndex = 7
        Me.txt_PrPhone.Text = "UltraTextEditor8"
        '
        'txt_PrPhArea
        '
        Appearance14.FontData.BoldAsString = "False"
        Me.txt_PrPhArea.Appearance = Appearance14
        Me.txt_PrPhArea.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PrPhArea.Location = New System.Drawing.Point(400, 32)
        Me.txt_PrPhArea.Name = "txt_PrPhArea"
        Me.txt_PrPhArea.Size = New System.Drawing.Size(32, 17)
        Me.txt_PrPhArea.TabIndex = 6
        Me.txt_PrPhArea.Text = "UltraTextEditor7"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(312, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 14)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Phone"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PrPhCountry
        '
        Appearance15.FontData.BoldAsString = "False"
        Me.txt_PrPhCountry.Appearance = Appearance15
        Me.txt_PrPhCountry.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PrPhCountry.Location = New System.Drawing.Point(360, 32)
        Me.txt_PrPhCountry.Name = "txt_PrPhCountry"
        Me.txt_PrPhCountry.Size = New System.Drawing.Size(32, 17)
        Me.txt_PrPhCountry.TabIndex = 5
        Me.txt_PrPhCountry.Text = "UltraTextEditor6"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(387, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 14)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Pincode"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(118, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(25, 14)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "City"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PrCity
        '
        Appearance16.FontData.BoldAsString = "False"
        Me.txt_PrCity.Appearance = Appearance16
        Me.txt_PrCity.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PrCity.Location = New System.Drawing.Point(152, 32)
        Me.txt_PrCity.Name = "txt_PrCity"
        Me.txt_PrCity.Size = New System.Drawing.Size(120, 17)
        Me.txt_PrCity.TabIndex = 3
        Me.txt_PrCity.Text = "UltraTextEditor3"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(94, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(49, 14)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Address"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PrAddress
        '
        Appearance17.FontData.BoldAsString = "False"
        Me.txt_PrAddress.Appearance = Appearance17
        Me.txt_PrAddress.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PrAddress.Location = New System.Drawing.Point(152, 8)
        Me.txt_PrAddress.Name = "txt_PrAddress"
        Me.txt_PrAddress.Size = New System.Drawing.Size(456, 17)
        Me.txt_PrAddress.TabIndex = 1
        Me.txt_PrAddress.Text = "UltraTextEditor2"
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(8, 120)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(152, 16)
        Me.Label32.TabIndex = 15
        Me.Label32.Text = "Permanent Address"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnLookupGeoPm)
        Me.Panel3.Controls.Add(Me.txt_PmGeoPoint)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Controls.Add(Me.cmb_PmCountry)
        Me.Panel3.Controls.Add(Me.cmb_PmState)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.txt_PmPinCode)
        Me.Panel3.Controls.Add(Me.txt_PmPhone)
        Me.Panel3.Controls.Add(Me.txt_PmPhArea)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.txt_PmPhCountry)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.txt_PmCity)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.txt_PmAddress)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 291)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(640, 128)
        Me.Panel3.TabIndex = 13
        '
        'btnLookupGeoPm
        '
        Me.btnLookupGeoPm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance18.FontData.BoldAsString = "True"
        Me.btnLookupGeoPm.Appearance = Appearance18
        Me.btnLookupGeoPm.Location = New System.Drawing.Point(554, 79)
        Me.btnLookupGeoPm.Name = "btnLookupGeoPm"
        Me.btnLookupGeoPm.Size = New System.Drawing.Size(79, 21)
        Me.btnLookupGeoPm.TabIndex = 20
        Me.btnLookupGeoPm.Text = "Lookup"
        '
        'txt_PmGeoPoint
        '
        Appearance19.FontData.BoldAsString = "False"
        Me.txt_PmGeoPoint.Appearance = Appearance19
        Me.txt_PmGeoPoint.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PmGeoPoint.Location = New System.Drawing.Point(440, 82)
        Me.txt_PmGeoPoint.Name = "txt_PmGeoPoint"
        Me.txt_PmGeoPoint.Size = New System.Drawing.Size(112, 17)
        Me.txt_PmGeoPoint.TabIndex = 19
        Me.txt_PmGeoPoint.Text = "UltraTextEditor5"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(379, 84)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 14)
        Me.Label24.TabIndex = 18
        Me.Label24.Text = "Geo Point"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb_PmCountry
        '
        Appearance20.FontData.BoldAsString = "False"
        Me.cmb_PmCountry.Appearance = Appearance20
        Me.cmb_PmCountry.Location = New System.Drawing.Point(152, 55)
        Me.cmb_PmCountry.Name = "cmb_PmCountry"
        Me.cmb_PmCountry.Size = New System.Drawing.Size(190, 22)
        Me.cmb_PmCountry.TabIndex = 9
        Me.cmb_PmCountry.Text = "UltraCombo5"
        '
        'cmb_PmState
        '
        Appearance21.FontData.BoldAsString = "False"
        Me.cmb_PmState.Appearance = Appearance21
        Me.cmb_PmState.Location = New System.Drawing.Point(152, 80)
        Me.cmb_PmState.Name = "cmb_PmState"
        Me.cmb_PmState.Size = New System.Drawing.Size(190, 22)
        Me.cmb_PmState.TabIndex = 11
        Me.cmb_PmState.Text = "UltraCombo5"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(104, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 14)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "State"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(91, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 14)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "Country"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PmPinCode
        '
        Appearance22.FontData.BoldAsString = "False"
        Me.txt_PmPinCode.Appearance = Appearance22
        Me.txt_PmPinCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PmPinCode.Location = New System.Drawing.Point(440, 57)
        Me.txt_PmPinCode.Name = "txt_PmPinCode"
        Me.txt_PmPinCode.Size = New System.Drawing.Size(112, 17)
        Me.txt_PmPinCode.TabIndex = 13
        Me.txt_PmPinCode.Text = "UltraTextEditor5"
        '
        'txt_PmPhone
        '
        Appearance23.FontData.BoldAsString = "False"
        Me.txt_PmPhone.Appearance = Appearance23
        Me.txt_PmPhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PmPhone.Location = New System.Drawing.Point(440, 32)
        Me.txt_PmPhone.Name = "txt_PmPhone"
        Me.txt_PmPhone.Size = New System.Drawing.Size(176, 17)
        Me.txt_PmPhone.TabIndex = 7
        Me.txt_PmPhone.Text = "UltraTextEditor8"
        '
        'txt_PmPhArea
        '
        Appearance24.FontData.BoldAsString = "False"
        Me.txt_PmPhArea.Appearance = Appearance24
        Me.txt_PmPhArea.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PmPhArea.Location = New System.Drawing.Point(400, 32)
        Me.txt_PmPhArea.Name = "txt_PmPhArea"
        Me.txt_PmPhArea.Size = New System.Drawing.Size(32, 17)
        Me.txt_PmPhArea.TabIndex = 6
        Me.txt_PmPhArea.Text = "UltraTextEditor7"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(308, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(37, 14)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "Phone"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PmPhCountry
        '
        Appearance25.FontData.BoldAsString = "False"
        Me.txt_PmPhCountry.Appearance = Appearance25
        Me.txt_PmPhCountry.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PmPhCountry.Location = New System.Drawing.Point(360, 32)
        Me.txt_PmPhCountry.Name = "txt_PmPhCountry"
        Me.txt_PmPhCountry.Size = New System.Drawing.Size(32, 17)
        Me.txt_PmPhCountry.TabIndex = 5
        Me.txt_PmPhCountry.Text = "UltraTextEditor6"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(387, 59)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(45, 14)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Pincode"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(111, 35)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(25, 14)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "City"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PmCity
        '
        Appearance26.FontData.BoldAsString = "False"
        Me.txt_PmCity.Appearance = Appearance26
        Me.txt_PmCity.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PmCity.Location = New System.Drawing.Point(152, 32)
        Me.txt_PmCity.Name = "txt_PmCity"
        Me.txt_PmCity.Size = New System.Drawing.Size(120, 17)
        Me.txt_PmCity.TabIndex = 3
        Me.txt_PmCity.Text = "UltraTextEditor3"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(87, 11)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(49, 14)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Address"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PmAddress
        '
        Appearance27.FontData.BoldAsString = "False"
        Me.txt_PmAddress.Appearance = Appearance27
        Me.txt_PmAddress.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PmAddress.Location = New System.Drawing.Point(152, 8)
        Me.txt_PmAddress.Name = "txt_PmAddress"
        Me.txt_PmAddress.Size = New System.Drawing.Size(456, 17)
        Me.txt_PmAddress.TabIndex = 1
        Me.txt_PmAddress.Text = "UltraTextEditor2"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txt_LastName)
        Me.Panel1.Controls.Add(Me.txt_MidName)
        Me.Panel1.Controls.Add(Me.txt_FirstName)
        Me.Panel1.Controls.Add(Me.txt_Salutation)
        Me.Panel1.Controls.Add(Me.lblNum)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 80)
        Me.Panel1.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(48, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Sal"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(456, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Last Name"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(272, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Mid Name"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_LastName
        '
        Appearance28.FontData.BoldAsString = "False"
        Appearance28.FontData.ItalicAsString = "False"
        Appearance28.FontData.Name = "Arial"
        Appearance28.FontData.SizeInPoints = 8.25!
        Appearance28.FontData.StrikeoutAsString = "False"
        Appearance28.FontData.UnderlineAsString = "False"
        Me.txt_LastName.Appearance = Appearance28
        Me.txt_LastName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_LastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_LastName.Location = New System.Drawing.Point(456, 40)
        Me.txt_LastName.Name = "txt_LastName"
        Me.txt_LastName.Size = New System.Drawing.Size(168, 17)
        Me.txt_LastName.TabIndex = 7
        Me.txt_LastName.Text = "UltraTextEditor11"
        '
        'txt_MidName
        '
        Appearance29.FontData.BoldAsString = "False"
        Appearance29.FontData.ItalicAsString = "False"
        Appearance29.FontData.Name = "Arial"
        Appearance29.FontData.SizeInPoints = 8.25!
        Appearance29.FontData.StrikeoutAsString = "False"
        Appearance29.FontData.UnderlineAsString = "False"
        Me.txt_MidName.Appearance = Appearance29
        Me.txt_MidName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_MidName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MidName.Location = New System.Drawing.Point(272, 40)
        Me.txt_MidName.Name = "txt_MidName"
        Me.txt_MidName.Size = New System.Drawing.Size(176, 17)
        Me.txt_MidName.TabIndex = 5
        Me.txt_MidName.Text = "UltraTextEditor10"
        '
        'txt_FirstName
        '
        Appearance30.FontData.BoldAsString = "False"
        Appearance30.FontData.ItalicAsString = "False"
        Appearance30.FontData.Name = "Arial"
        Appearance30.FontData.SizeInPoints = 8.25!
        Appearance30.FontData.StrikeoutAsString = "False"
        Appearance30.FontData.UnderlineAsString = "False"
        Me.txt_FirstName.Appearance = Appearance30
        Me.txt_FirstName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_FirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FirstName.Location = New System.Drawing.Point(112, 40)
        Me.txt_FirstName.Name = "txt_FirstName"
        Me.txt_FirstName.Size = New System.Drawing.Size(152, 17)
        Me.txt_FirstName.TabIndex = 3
        Me.txt_FirstName.Text = "UltraTextEditor9"
        '
        'txt_Salutation
        '
        Appearance31.FontData.BoldAsString = "False"
        Appearance31.FontData.ItalicAsString = "False"
        Appearance31.FontData.Name = "Arial"
        Appearance31.FontData.SizeInPoints = 8.25!
        Appearance31.FontData.StrikeoutAsString = "False"
        Appearance31.FontData.UnderlineAsString = "False"
        Me.txt_Salutation.Appearance = Appearance31
        Me.txt_Salutation.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Salutation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Salutation.Location = New System.Drawing.Point(48, 40)
        Me.txt_Salutation.Name = "txt_Salutation"
        Me.txt_Salutation.Size = New System.Drawing.Size(56, 17)
        Me.txt_Salutation.TabIndex = 1
        Me.txt_Salutation.Text = "UltraTextEditor2"
        '
        'lblNum
        '
        Me.lblNum.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNum.Location = New System.Drawing.Point(112, 16)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(96, 16)
        Me.lblNum.TabIndex = 2
        Me.lblNum.Text = "First Name"
        Me.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Label28)
        Me.UltraTabPageControl2.Controls.Add(Me.txt_NickName)
        Me.UltraTabPageControl2.Controls.Add(Me.cmb_TopQual)
        Me.UltraTabPageControl2.Controls.Add(Me.Label13)
        Me.UltraTabPageControl2.Controls.Add(Me.cmb_MarStatus)
        Me.UltraTabPageControl2.Controls.Add(Me.Label12)
        Me.UltraTabPageControl2.Controls.Add(Me.cmb_IsFemale)
        Me.UltraTabPageControl2.Controls.Add(Me.Label15)
        Me.UltraTabPageControl2.Controls.Add(Me.Label6)
        Me.UltraTabPageControl2.Controls.Add(Me.dt_Anniversary)
        Me.UltraTabPageControl2.Controls.Add(Me.Label7)
        Me.UltraTabPageControl2.Controls.Add(Me.dt_BirthDay)
        Me.UltraTabPageControl2.Controls.Add(Me.lblDate)
        Me.UltraTabPageControl2.Controls.Add(Me.txt_Remark)
        Me.UltraTabPageControl2.Controls.Add(Me.Label1)
        Me.UltraTabPageControl2.Controls.Add(Me.txt_Profile)
        Me.UltraTabPageControl2.Controls.Add(Me.Label2)
        Me.UltraTabPageControl2.Controls.Add(Me.txt_Education)
        Me.UltraTabPageControl2.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(640, 419)
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(90, 196)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 14)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "Display Name"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_NickName
        '
        Appearance32.FontData.BoldAsString = "False"
        Me.txt_NickName.Appearance = Appearance32
        Me.txt_NickName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_NickName.Location = New System.Drawing.Point(192, 193)
        Me.txt_NickName.Name = "txt_NickName"
        Me.txt_NickName.Size = New System.Drawing.Size(240, 17)
        Me.txt_NickName.TabIndex = 7
        Me.txt_NickName.Text = "UltraTextEditor2"
        '
        'cmb_TopQual
        '
        Me.cmb_TopQual.Location = New System.Drawing.Point(192, 160)
        Me.cmb_TopQual.Name = "cmb_TopQual"
        Me.cmb_TopQual.Size = New System.Drawing.Size(272, 21)
        Me.cmb_TopQual.TabIndex = 5
        Me.cmb_TopQual.Text = "UltraComboEditor1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(76, 163)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 14)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Top Qualification"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_MarStatus
        '
        ValueListItem1.DataValue = "Married"
        ValueListItem2.DataValue = "Unmarried"
        ValueListItem3.DataValue = "Widowed"
        ValueListItem4.DataValue = "Divorced"
        ValueListItem5.DataValue = "Separated"
        Me.cmb_MarStatus.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem4, ValueListItem5})
        Me.cmb_MarStatus.Location = New System.Drawing.Point(192, 128)
        Me.cmb_MarStatus.Name = "cmb_MarStatus"
        Me.cmb_MarStatus.Size = New System.Drawing.Size(128, 21)
        Me.cmb_MarStatus.TabIndex = 3
        Me.cmb_MarStatus.Text = "UltraComboEditor9"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(90, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 14)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Marital Status"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_IsFemale
        '
        ValueListItem6.DataValue = False
        ValueListItem6.DisplayText = "Male"
        ValueListItem7.DataValue = True
        ValueListItem7.DisplayText = "Female"
        Me.cmb_IsFemale.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem6, ValueListItem7})
        Me.cmb_IsFemale.Location = New System.Drawing.Point(192, 96)
        Me.cmb_IsFemale.Name = "cmb_IsFemale"
        Me.cmb_IsFemale.Size = New System.Drawing.Size(80, 21)
        Me.cmb_IsFemale.TabIndex = 1
        Me.cmb_IsFemale.Text = "UltraComboEditor9"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(119, 99)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 14)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Gender"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(119, 349)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 14)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Remark"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dt_Anniversary
        '
        Appearance33.FontData.BoldAsString = "False"
        Appearance33.FontData.ItalicAsString = "False"
        Appearance33.FontData.Name = "Arial"
        Appearance33.FontData.SizeInPoints = 8.25!
        Appearance33.FontData.StrikeoutAsString = "False"
        Appearance33.FontData.UnderlineAsString = "False"
        Me.dt_Anniversary.Appearance = Appearance33
        Me.dt_Anniversary.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_Anniversary.FormatString = "dddd dd MMM yyyy"
        Me.dt_Anniversary.Location = New System.Drawing.Point(192, 250)
        Me.dt_Anniversary.Name = "dt_Anniversary"
        Me.dt_Anniversary.NullText = "Not Defined"
        Me.dt_Anniversary.Size = New System.Drawing.Size(232, 21)
        Me.dt_Anniversary.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(95, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 14)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Anniversary"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dt_BirthDay
        '
        Appearance34.FontData.BoldAsString = "False"
        Appearance34.FontData.ItalicAsString = "False"
        Appearance34.FontData.Name = "Arial"
        Appearance34.FontData.SizeInPoints = 8.25!
        Appearance34.FontData.StrikeoutAsString = "False"
        Appearance34.FontData.UnderlineAsString = "False"
        Me.dt_BirthDay.Appearance = Appearance34
        Me.dt_BirthDay.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_BirthDay.FormatString = "dddd dd MMM yyyy"
        Me.dt_BirthDay.Location = New System.Drawing.Point(192, 218)
        Me.dt_BirthDay.Name = "dt_BirthDay"
        Me.dt_BirthDay.NullText = "Not Defined"
        Me.dt_BirthDay.Size = New System.Drawing.Size(232, 21)
        Me.dt_BirthDay.TabIndex = 9
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(115, 221)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(47, 14)
        Me.lblDate.TabIndex = 8
        Me.lblDate.Text = "Birthday"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Remark
        '
        Appearance35.FontData.BoldAsString = "False"
        Me.txt_Remark.Appearance = Appearance35
        Me.txt_Remark.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Remark.Location = New System.Drawing.Point(192, 346)
        Me.txt_Remark.Multiline = True
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(424, 48)
        Me.txt_Remark.TabIndex = 17
        Me.txt_Remark.Text = "UltraTextEditor7"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 317)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 14)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Profile"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Profile
        '
        Appearance36.FontData.BoldAsString = "False"
        Me.txt_Profile.Appearance = Appearance36
        Me.txt_Profile.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Profile.Location = New System.Drawing.Point(192, 314)
        Me.txt_Profile.Name = "txt_Profile"
        Me.txt_Profile.Size = New System.Drawing.Size(408, 17)
        Me.txt_Profile.TabIndex = 15
        Me.txt_Profile.Text = "UltraTextEditor1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(108, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Education"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Education
        '
        Appearance37.FontData.BoldAsString = "False"
        Me.txt_Education.Appearance = Appearance37
        Me.txt_Education.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Education.Location = New System.Drawing.Point(192, 282)
        Me.txt_Education.Name = "txt_Education"
        Me.txt_Education.Size = New System.Drawing.Size(408, 17)
        Me.txt_Education.TabIndex = 13
        Me.txt_Education.Text = "UltraTextEditor4"
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.Panel7)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(640, 419)
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.UGridEdu)
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(640, 419)
        Me.Panel7.TabIndex = 16
        '
        'UGridEdu
        '
        Me.UGridEdu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UGridEdu.Location = New System.Drawing.Point(0, 0)
        Me.UGridEdu.Name = "UGridEdu"
        Me.UGridEdu.Size = New System.Drawing.Size(640, 377)
        Me.UGridEdu.TabIndex = 0
        Me.UGridEdu.Text = "Delivery Schedule"
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.btnDelEdu)
        Me.Panel8.Controls.Add(Me.btnAddEdu)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 377)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(640, 42)
        Me.Panel8.TabIndex = 1
        '
        'btnDelEdu
        '
        Me.btnDelEdu.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelEdu.Location = New System.Drawing.Point(498, 0)
        Me.btnDelEdu.Name = "btnDelEdu"
        Me.btnDelEdu.Size = New System.Drawing.Size(70, 42)
        Me.btnDelEdu.TabIndex = 0
        Me.btnDelEdu.Text = "Delete"
        '
        'btnAddEdu
        '
        Me.btnAddEdu.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddEdu.Location = New System.Drawing.Point(568, 0)
        Me.btnAddEdu.Name = "btnAddEdu"
        Me.btnAddEdu.Size = New System.Drawing.Size(72, 42)
        Me.btnAddEdu.TabIndex = 1
        Me.btnAddEdu.Text = "Add New"
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.Panel9)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(640, 419)
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.UGridFam)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(640, 419)
        Me.Panel9.TabIndex = 16
        '
        'UGridFam
        '
        Me.UGridFam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UGridFam.Location = New System.Drawing.Point(0, 0)
        Me.UGridFam.Name = "UGridFam"
        Me.UGridFam.Size = New System.Drawing.Size(640, 377)
        Me.UGridFam.TabIndex = 0
        Me.UGridFam.Text = "Delivery Schedule"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.btnDelFam)
        Me.Panel10.Controls.Add(Me.btnAddFam)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 377)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(640, 42)
        Me.Panel10.TabIndex = 1
        '
        'btnDelFam
        '
        Me.btnDelFam.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelFam.Location = New System.Drawing.Point(498, 0)
        Me.btnDelFam.Name = "btnDelFam"
        Me.btnDelFam.Size = New System.Drawing.Size(70, 42)
        Me.btnDelFam.TabIndex = 0
        Me.btnDelFam.Text = "Delete"
        '
        'btnAddFam
        '
        Me.btnAddFam.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddFam.Location = New System.Drawing.Point(568, 0)
        Me.btnAddFam.Name = "btnAddFam"
        Me.btnAddFam.Size = New System.Drawing.Size(72, 42)
        Me.btnAddFam.TabIndex = 1
        Me.btnAddFam.Text = "Add New"
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.Panel11)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(640, 419)
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.UGridExp)
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(640, 419)
        Me.Panel11.TabIndex = 16
        '
        'UGridExp
        '
        Me.UGridExp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UGridExp.Location = New System.Drawing.Point(0, 0)
        Me.UGridExp.Name = "UGridExp"
        Me.UGridExp.Size = New System.Drawing.Size(640, 377)
        Me.UGridExp.TabIndex = 0
        Me.UGridExp.Text = "Delivery Schedule"
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.btnDelExp)
        Me.Panel12.Controls.Add(Me.btnAddExp)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel12.Location = New System.Drawing.Point(0, 377)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(640, 42)
        Me.Panel12.TabIndex = 1
        '
        'btnDelExp
        '
        Me.btnDelExp.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelExp.Location = New System.Drawing.Point(498, 0)
        Me.btnDelExp.Name = "btnDelExp"
        Me.btnDelExp.Size = New System.Drawing.Size(70, 42)
        Me.btnDelExp.TabIndex = 0
        Me.btnDelExp.Text = "Delete"
        '
        'btnAddExp
        '
        Me.btnAddExp.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddExp.Location = New System.Drawing.Point(568, 0)
        Me.btnAddExp.Name = "btnAddExp"
        Me.btnAddExp.Size = New System.Drawing.Size(72, 42)
        Me.btnAddExp.TabIndex = 1
        Me.btnAddExp.Text = "Add New"
        '
        'UltraTabPageControl7
        '
        Me.UltraTabPageControl7.Controls.Add(Me.PanelPicSide)
        Me.UltraTabPageControl7.Controls.Add(Me.pic_PicPerson)
        Me.UltraTabPageControl7.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl7.Name = "UltraTabPageControl7"
        Me.UltraTabPageControl7.Size = New System.Drawing.Size(640, 419)
        '
        'PanelPicSide
        '
        Me.PanelPicSide.Controls.Add(Me.btnSavepic)
        Me.PanelPicSide.Controls.Add(Me.btnBrowsePic)
        Me.PanelPicSide.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelPicSide.Location = New System.Drawing.Point(472, 0)
        Me.PanelPicSide.Name = "PanelPicSide"
        Me.PanelPicSide.Size = New System.Drawing.Size(168, 419)
        Me.PanelPicSide.TabIndex = 1
        '
        'btnSavepic
        '
        Me.btnSavepic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance38.FontData.BoldAsString = "True"
        Me.btnSavepic.Appearance = Appearance38
        Me.btnSavepic.Location = New System.Drawing.Point(72, 383)
        Me.btnSavepic.Name = "btnSavepic"
        Me.btnSavepic.Size = New System.Drawing.Size(89, 32)
        Me.btnSavepic.TabIndex = 1
        Me.btnSavepic.Text = "Save As ..."
        '
        'btnBrowsePic
        '
        Me.btnBrowsePic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance39.FontData.BoldAsString = "True"
        Me.btnBrowsePic.Appearance = Appearance39
        Me.btnBrowsePic.Location = New System.Drawing.Point(72, 343)
        Me.btnBrowsePic.Name = "btnBrowsePic"
        Me.btnBrowsePic.Size = New System.Drawing.Size(89, 32)
        Me.btnBrowsePic.TabIndex = 0
        Me.btnBrowsePic.Text = "Browse ..."
        '
        'pic_PicPerson
        '
        Me.pic_PicPerson.Location = New System.Drawing.Point(0, 80)
        Me.pic_PicPerson.Name = "pic_PicPerson"
        Me.pic_PicPerson.Size = New System.Drawing.Size(478, 336)
        Me.pic_PicPerson.TabIndex = 18
        Me.pic_PicPerson.TabStop = False
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl3)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl4)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl5)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl6)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl7)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Appearance40.FontData.BoldAsString = "True"
        Me.UltraTabControl1.SelectedTabAppearance = Appearance40
        Me.UltraTabControl1.SharedControls.AddRange(New System.Windows.Forms.Control() {Me.Panel1})
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(644, 445)
        Me.UltraTabControl1.TabIndex = 0
        Me.UltraTabControl1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowAutoSize
        UltraTab8.TabPage = Me.UltraTabPageControl1
        UltraTab8.Text = "Basic"
        UltraTab9.TabPage = Me.UltraTabPageControl3
        UltraTab9.Text = "Address"
        UltraTab10.TabPage = Me.UltraTabPageControl2
        UltraTab10.Text = "Info"
        UltraTab4.TabPage = Me.UltraTabPageControl4
        UltraTab4.Text = "Education"
        UltraTab5.TabPage = Me.UltraTabPageControl5
        UltraTab5.Text = "Family"
        UltraTab6.TabPage = Me.UltraTabPageControl6
        UltraTab6.Text = "Experience"
        UltraTab7.TabPage = Me.UltraTabPageControl7
        UltraTab7.Text = "Picture"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab8, UltraTab9, UltraTab10, UltraTab4, UltraTab5, UltraTab6, UltraTab7})
        Me.UltraTabControl1.TabsPerRow = 5
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Controls.Add(Me.Panel1)
        Me.UltraTabSharedControlsPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(640, 419)
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 445)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(644, 49)
        Me.Panel4.TabIndex = 1
        '
        'btnSave
        '
        Appearance41.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance41
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(380, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 49)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance42.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance42
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(468, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 49)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance43.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance43
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(556, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 49)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "JPG Files|*.jpg|GIF Files|*.gif|BMP Files|*.bmp"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "JPG Files|*.jpg|GIF Files|*.gif|BMP Files|*.bmp"
        '
        'frmHRPerson
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Person"
        Me.ClientSize = New System.Drawing.Size(644, 494)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmHRPerson"
        Me.Text = "Person"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl9.ResumeLayout(False)
        CType(Me.UGridEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.UltraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl2.ResumeLayout(False)
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.txt_CellNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Email, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Web, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_OfficePhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_OfficeArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_OfficeCountry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txt_PrGeoPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_PrCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_PrState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PrPinCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PrPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PrPhArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PrPhCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PrCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PrAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.txt_PmGeoPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_PmCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_PmState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PmPinCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PmPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PmPhArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PmPhCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PmCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PmAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txt_LastName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_MidName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FirstName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Salutation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.txt_NickName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_TopQual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_MarStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_IsFemale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Anniversary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_BirthDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Remark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Profile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Education, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.UGridEdu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        CType(Me.UGridFam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.UltraTabPageControl6.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        CType(Me.UGridExp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        Me.UltraTabPageControl7.ResumeLayout(False)
        Me.PanelPicSide.ResumeLayout(False)
        CType(Me.pic_PicPerson, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.UltraTabSharedControlsPage1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmb_PrCountry As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_PrState As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_PmCountry As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_PmState As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnCopyPrAdd As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabControl2 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl8 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl9 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txt_PrGeoPoint As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label23 As Label
    Friend WithEvents txt_PmGeoPoint As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label24 As Label
    Friend WithEvents btnLookupGeoPr As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnLookupGeoPm As Infragistics.Win.Misc.UltraButton

#End Region
End Class

