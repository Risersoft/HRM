Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform

Public Class frmAdvance
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmAdvanceModel = Me.InitData("frmAdvanceModel", oView, prepMode, prepIDX, strXML)

        If Me.BindModel(objModel, oView) Then
            Me.lblName.Text = "Advance for " & myUtils.cStrTN(myRow.Row("descrip"))
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("AdvTDS"))
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


    Private Sub btnAdvReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvReq.Click

        Dim rrPsAdv() As DataRow, dtPSAdv As DataTable = Nothing
        dtPSAdv = Me.Model.DatasetCollection("PSAdv").Tables(0)

        If (Not dtPSAdv Is Nothing) AndAlso (dtPSAdv.Rows.Count > 0) Then
            For Each r As DataRow In myView.mainGrid.myDS.Tables(0).Select
                rrPsAdv = dtPSAdv.Select("EmployeeID = " & r("EmployeeID") & " and PayPeriodID = " & r("PayPeriodID") & " and DepID = " & r("DepID"))
                If rrPsAdv.Length > 0 Then
                    If (myUtils.cValTN(r("advance")) = 0) AndAlso (myUtils.cValTN(rrPsAdv(0)("advreq")) > 0) Then
                        If (myUtils.cValTN(r("last3mnthattavg")) >= r("AdvAttAvgMin")) AndAlso (myUtils.cValTN(r("advattavg")) >= r("AdvAttAvgMin")) Then
                            If myUtils.cValTN(r("limit")) > myUtils.cValTN(rrPsAdv(0)("advreq")) Then
                                r("advance") = rrPsAdv(0)("advreq")
                            Else
                                r("advance") = r("limit")
                            End If
                        End If
                    End If
                End If
            Next
        End If
    End Sub


End Class
