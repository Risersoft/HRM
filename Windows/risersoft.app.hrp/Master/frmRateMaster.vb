Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports risersoft.shared.Extensions

Public Class frmRateMaster
    Inherits frmMax

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.InitForm()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub InitForm()
        WinFormUtils.SetButtonConf(btnOk, btnCancel, btnSave)
        myView.SetGrid(UltraGridSalBenRate)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmRateMasterModel = Me.InitData("frmRateMasterModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "CalWeek", "", Me.cmb_WeeklyOff1)
            myWinSQL.AssignCmb(Me.dsCombo, "CalWeek", "", Me.cmb_Weeklyoff2)
            myWinSQL.AssignCmb(Me.dsCombo, "CalWeek", "", Me.cmb_WeekStart)
            myWinSQL.AssignCmb(Me.dsCombo, "WeekOffType", "", Me.cmb_WeeklyOff2Type)
            myWinSQL.AssignCmb(Me.dsCombo, "Company", "", Me.cmb_CompanyID)
            Me.cmb_InclHDaysForAbDays.ValueList = Me.Model.ValueLists("InclHDaysForAbDays").ComboList
            Me.cmb_VDAOnActualBasic.ValueList = Me.Model.ValueLists("VDAOnActualBasic").ComboList

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("SalBenRate"))
            Return True
        End If

        Return False
    End Function

    Private Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click
        Dim oret As clsProcOutput
        Dim ds As DataSet = myView.mainGrid.myDS.Copy
        myUtils.AddTable(ds, myRow.Row.Table, "RateMaster")
        oret = Me.GenerateDataOutput("generate", ds, 0)
        If oret.Success Then
            Me.UpdateViewData(myView, oret)
        Else
            MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If
    End Sub

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            Dim ds As DataSet = myView.mainGrid.myDS.Copy
            myUtils.AddTable(ds, myRow.Row.Table, "RateMaster")
            Dim oRet As clsProcOutput = Me.GenerateDataOutput("checksave", ds, 0)

            If oRet.Success Then
                If oRet.GetCalcRows("ppsal").Length > 0 Then
                    If MsgBox("After such changes, salary will be Recalculated. Are you sure you want to change and recalculate the salary", MsgBoxStyle.YesNo, myWinApp.Vars("appname")) = MsgBoxResult.No Then Exit Function
                End If
                If Me.SaveModel() Then
                    Return True
                End If
            Else
                WinFormUtils.AddError(Me.dt_Dated, oRet.Message)
            End If
        Else
            Me.SetError()
        End If

        Me.Refresh()
    End Function

End Class

