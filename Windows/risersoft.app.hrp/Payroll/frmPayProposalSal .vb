Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform

Public Class frmPayProposalSal
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmPayProposalSalModel = Me.InitData("frmPayProposalSalModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            If prepMode = EnumfrmMode.acEditM Then

                Me.lblCode.Text = myUtils.cStrTN(oView.ContextRow.CellValue("EmpCode"))
                Me.lblDep.Text = myUtils.cStrTN(oView.ContextRow.CellValue("DepName"))
                Me.lblName.Text = myUtils.cStrTN(oView.ContextRow.CellValue("FullName"))

                Me.lblTarget.Text = "Target Gross Salary As On " & Format(oView.ContextRow.CellValue("targetdate"), "yyyy-MMM-dd")
                Me.txt_Target.Text = Format(myUtils.cValTN(oView.ContextRow.CellValue("targetSal")), "#.##")
                Me.txt_Gross.Text = Format(myUtils.cValTN(oView.ContextRow.CellValue("projectedSal")), "#.##")

                Me.FormPrepared = True
            End If
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            Me.TwoGrids.myView1.PrepEdit(Me.Model.GridViews("OldSMID"))
            Me.TwoGrids.myView2.PrepEdit(Me.Model.GridViews("NewSMID"))
            Return True
        End If

        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            If Me.SaveModel() Then
                Me.DoRefresh = True
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btn_Define_Click(sender As Object, e As EventArgs) Handles btn_Define.Click
        Dim strXML As String, f As New frmEmpSalary
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@RateMasterID", myUtils.cValTN(Me.vBag("Newrmid")), GetType(Integer), False))

        strXML = "<PARAMS OLDSMID=""" & Me.vBag("oldsmid") & """ PAYPROPOSALID=""" & Me.vBag("payproposalid") & """ RATEMASTERID=""" & Me.vBag("newrmid") & """ EMPLOYEEID=""" & Me.vBag("employeeid") & """ PGROSS=""" & myUtils.cValTN(Me.txt_Gross.Text) & """/>"
        If Not (myUtils.NullNot(Me.vBag("newsmid"))) Then

            Me.TwoGrids.myView2.ContextRow = Me.TwoGrids.myView2.mainGrid.ActiveRow

            If f.PrepForm(Me.TwoGrids.myView2, EnumfrmMode.acEditM, Me.vBag("newsmid"), strXML) Then
                If f.ShowDialog(Me) = DialogResult.OK Then
                    Params.Add(New clsSQLParam("@EmpSalaryID", myUtils.cValTN(Me.vBag("Newsmid")), GetType(Integer), False))
                    Dim oRet As clsProcOutput = Me.GenerateParamsOutput("empsalratecalc", Params)
                    If oRet.Success Then
                        Me.UpdateViewData(Me.TwoGrids.myView2, oRet)
                    Else
                        MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                    End If
                End If
            End If

        ElseIf Not myUtils.cBoolTN(Me.vBag("onlyrm")) Then

            If f.PrepForm(Me.TwoGrids.myView2, EnumfrmMode.acAddM, "", strXML) Then
                If f.ShowDialog(Me) = DialogResult.OK Then
                    Me.vBag("newsmid") = f.frmIDX
                    Params.Add(New clsSQLParam("@EmpSalaryID", myUtils.cValTN(Me.vBag("Newsmid")), GetType(Integer), False))
                    Dim oRet2 As clsProcOutput = Me.GenerateParamsOutput("empsalratecalc", Params)
                    If oRet2.Success Then
                        Me.UpdateViewData(Me.TwoGrids.myView2, oRet2)
                    Else
                        MsgBox(oRet2.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                    End If
                End If
            End If
        End If
        f = Nothing
    End Sub
End Class

