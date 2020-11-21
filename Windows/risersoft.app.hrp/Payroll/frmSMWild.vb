Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.mxform
Imports risersoft.shared.Extensions

Public Class frmSMWild
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub
    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmSMWildModel = Me.InitData("frmSMWildModel", oView, prepMode, prepIDX, strXML)

        If Me.BindModel(objModel, oView) Then
            If prepMode = EnumfrmMode.acEditM Then
                Me.cmb_Select.ValueList = Me.Model.ValueLists("Select").ComboList
                Me.FormPrepared = True
            End If
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            Me.TwoGrids.myView1.PrepEdit(Me.Model.GridViews("EmpSalComp1"))

            Dim dt As DataTable = pView.mainGrid.myDS.Tables(pView.ContextRow.BandKey).Copy
            myUtils.RemoveRows(dt.Select("isnull(OldSSID,0) <>" & myUtils.cValTN(Me.TwoGrids.myView1.mainGrid.myDS.Tables(0).Rows(0)("SalStructureID"))))
            Dim objView As clsViewModel = Me.Model.GridViews("EmpSalComp2")
            objView.MainGrid.BindGridData(myUtils.MakeDSfromTable(dt, True))
            objView.MultiSelect = True : objView.Mode = EnumViewMode.acSelectM
            objView.MainGrid.MainConf("fixcols") = 5
            objView.MainGrid.QuickConf("", pView.mainGrid.MainConf("reversedirection"), pView.mainGrid.MainConf("strwidth"), True, "Select")

            Me.TwoGrids.myView2.PrepEdit(objView)
            Return True
        End If

        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            Me.Model.ClientParams.Add(New clsSQLParam("@MinSal", CheckMinSal.Checked, GetType(Boolean), False))
            Me.Model.ClientParams.Add(New clsSQLParam("@Select", cmb_Select.SelectedIndex, GetType(Integer), False))
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

    Private Sub UltraButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton3.Click
        myWinData.TickIncludedCols(Me.TwoGrids.myView2.mainGrid.myDS.Tables(0), Me.TwoGrids.myView2.mainGrid.myDS.Tables(0), "employeeid")
        Me.TwoGrids.myView2.mainGrid.HighlightRows()
    End Sub

    Private Sub UltraButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton2.Click
        For Each r As DataRow In Me.TwoGrids.myView2.mainGrid.myDS.Tables(0).Select("iscasual=1")
            r("sysincl") = True
        Next
        Me.TwoGrids.myView2.mainGrid.HighlightRows()
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        For Each r As DataRow In Me.TwoGrids.myView2.mainGrid.myDS.Tables(0).Select("iscasual=1")
            r("sysincl") = False
        Next
        Me.TwoGrids.myView2.mainGrid.HighlightRows()
    End Sub

    Private Sub UltraButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton4.Click
        For Each r As DataRow In Me.TwoGrids.myView2.mainGrid.myDS.Tables(0).Select()
            r("sysincl") = False
        Next
        Me.TwoGrids.myView2.mainGrid.HighlightRows()

    End Sub


End Class

