
Imports Infragistics.Win.UltraWinGrid

Public Class frmForm12BB
    Inherits frmMax
    Dim oSort As clsWinSort

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(btnOk, btnCancel, btnSave)
        myView.SetGrid(UltraGridItem)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmForm12BBModel = Me.InitData("frmForm12BBModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then
            Dim dt As DataTable = Me.Model.DatasetCollection("Set").Tables("Emp")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.txt_EmpCode.Text = myUtils.cStrTN(dt.Rows(0)("EmpCode"))
                Me.txt_Name.Text = myUtils.cStrTN(dt.Rows(0)("FullName"))
            End If

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Item"))
            myWinSQL.AssignCmb(Me.dsCombo, "finyears", "", Me.cmb_FinYearID)
            Me.cmb_OptionNum.ValueList = Me.Model.ValueLists("OptionNum").ComboList

            oSort = New clsWinSort(myView, Nothing, Nothing, Nothing, "SortIndex")
            oSort.renumber()

            Return True
        End If

        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btnDelete12bb_Click(sender As Object, e As EventArgs) Handles btnDelete12bb.Click
        Dim oRet = Me.DeleteEntity("form12bb", frmIDX, False)
        If oRet.ErrorCount > 0 Then
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        Else
            If MsgBox(oRet.Message, MsgBoxStyle.YesNo + MsgBoxStyle.Question, myWinApp.Vars("appname")) = MsgBoxResult.Yes Then
                oRet = Me.DeleteEntity("form12bb", frmIDX, True)
                If oRet.Success Then WinFormUtils.ButtonAction(Me, "btnCancel")
            End If
        End If
    End Sub

    Private Sub cmb_OptionNum_ValueChanged(sender As Object, e As EventArgs) Handles cmb_OptionNum.ValueChanged
        Dim gr As UltraGridRow
        If Not Me.cmb_OptionNum.SelectedItem Is Nothing AndAlso Me.cmb_OptionNum.Value = 2 Then
            If myView.mainGrid.myDS.Tables(0).Rows.Count > 0 Then
                For Each gr In myView.mainGrid.myGrid.Rows
                    gr.Cells("Amount").Value = DBNull.Value
                    gr.Cells("Evidence").Value = DBNull.Value
                    gr.Activation = Activation.NoEdit
                Next
            End If
        End If

        If Not Me.cmb_OptionNum.SelectedItem Is Nothing AndAlso Me.cmb_OptionNum.Value = 1 Then
            If myView.mainGrid.myDS.Tables(0).Rows.Count > 0 Then
                For Each gr In myView.mainGrid.myGrid.Rows
                    gr.Activation = Activation.AllowEdit
                Next
            End If
        End If

    End Sub

End Class
