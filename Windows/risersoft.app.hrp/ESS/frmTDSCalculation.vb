Imports risersoft.app.mxent
Imports risersoft.shared.dal

Public Class frmTDSCalculation
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(btnOk, btnCancel, btnSave)
        myView.SetGrid(UltraGridItem)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmTDSCalculationModel = Me.InitData("frmTDSCalculationModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then
            Dim dt As DataTable = Me.Model.DatasetCollection("Set").Tables("Emp")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.txt_EmpCode.Text = myUtils.cStrTN(dt.Rows(0)("EmpCode"))
                Me.txt_Name.Text = myUtils.cStrTN(dt.Rows(0)("FullName"))
            End If
            Me.cmb_RentPlace.ValueList = Me.Model.ValueLists("Place").ComboList
            myWinSQL.AssignCmb(Me.dsCombo, "Form12BB", "", Me.cmb_Form12BBID)

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Item"))
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

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        If Me.VSave() Then
            Dim oRet = Me.GenerateIDOutput("calculate", frmIDX)
            If oRet.Success Then
                myUtils.DeleteRows(myView.mainGrid.myDS.Tables(0).Select)
                Dim sortindex As Integer = 0
                For Each r1 As DataRow In oRet.Data.Tables(0).Select
                    sortindex = sortindex + 1
                    Dim nr = myUtils.CopyOneRow(r1, myView.mainGrid.myDS.Tables(0),, False)
                    nr("sortindex") = sortindex
                Next
            Else
                MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
            End If
        End If
    End Sub



End Class
