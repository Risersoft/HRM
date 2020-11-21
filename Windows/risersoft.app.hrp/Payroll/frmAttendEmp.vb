Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports System.ComponentModel
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing

Public Class frmAttendEmp
    Inherits frmMax
    Dim myVueLB As New clsWinView, myVueLBT, myVueApp As New clsWinView
    Dim f As New frmApiTaskStatus

    Private Sub InitForm()

        myView.SetGrid(Me.UltraGridAttend)
        myVueLB.SetGrid(Me.UGridLve)
        myVueLBT.SetGrid(Me.UGridLveT)
        myVueApp.SetGrid(Me.UltraGridApp)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)

        f.AddtoTab(Me.UltraTabControl1, "status", True)
        f.SetParent(Me)
        AddHandler f.TaskExecuted, AddressOf TaskExecuted

    End Sub

    Public Sub TaskExecuted(sender As Object, TaskId As String)
        WinFormUtils.SetReadOnly(Me.Panel4, True, True)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmAttendEmpModel = Me.InitData("frmAttendEmpModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Att"))
            myVueLBT.PrepEdit(Me.Model.GridViews("LBT"))
            myVueLB.PrepEdit(Me.Model.GridViews("LB"))
            myVueApp.PrepEdit(Me.Model.GridViews("App"))

            For Each gRow As UltraGridRow In myView.mainGrid.myGrid.Rows
                If myUtils.cBoolTN(gRow.Cells("isholiday").Value) Then
                    gRow.Appearance.BackColor = Color.LightGray
                End If
            Next

            Return True
        End If
        Return False
    End Function

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        Dim oret = GetParams("punch", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Function GetParams(Key As String, UploadType As String)
        WinFormUtils.SetReadOnly(Me.Panel4, True, False)
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@employeeid", myUtils.cValTN(myRow("employeeid")), GetType(Integer), False))
        Params.Add(New clsSQLParam("@payperiodid", myUtils.cValTN(Me.vBag("payperiodid")), GetType(Integer), False))
        Dim oRet = Me.GenerateParamsOutput(Key, Params)
        Dim result As Guid
        If System.Guid.TryParse(oRet.Description, result) Then
            f.AddTask(result.ToString)
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, myApp.Vars("appname"))
            Me.TaskExecuted(Me, "")
        End If
        Return oRet

    End Function

    Public Overrides Function VSave() As Boolean
        Dim objAttend As New clsAttendanceCalc(Me.Controller), cntLve As Double = 0, rrLveAcc(), rrLveChk() As DataRow, oRet As New clsProcOutput
        Me.InitError()
        VSave = False
        myView.mainGrid.myGrid.UpdateData()
        For Each r1 As DataRow In myView.mainGrid.myDS.Tables(0).Select
            objAttend.SetAttendanceStats(r1)
        Next

        For Each r1 As DataRow In myView.mainGrid.myDS.Tables(0).Select("AttendIDFH<>1 and AttendIDSH<>1 and AttendIDFH<>2 and AttendIDSH<>2")
            rrLveAcc = myVueLB.mainGrid.myDS.Tables(0).Select("AttendTagID = " & r1("AttendIDFH") & " or AttendTagID = " & r1("AttendIDSH") & "")
            If rrLveAcc.Length = 0 Then
                oRet.AddWarning("This leave type cannot be set, leaves balance is less")
                Exit For
            Else
                rrLveChk = myView.mainGrid.myDS.Tables(0).Select("AttendIDFH = " & rrLveAcc(0)("AttendTagID") & " or AttendIDSH = " & rrLveAcc(0)("AttendTagID") & " ")
                For Each r2 As DataRow In rrLveChk
                    If myUtils.cValTN(r2("AttendIDFH")) = myUtils.cValTN(rrLveAcc(0)("AttendTagID")) Then cntLve = cntLve + 1
                    If myUtils.cValTN(r2("AttendIDSH")) = myUtils.cValTN(rrLveAcc(0)("AttendTagID")) Then cntLve = cntLve + 1
                Next
                If (cntLve / 2) > rrLveAcc(0)("Qty") Then
                    oRet.AddWarning(rrLveAcc(0)("FullTag") & "  sets more than the balance of leaves")
                    Exit For
                End If
            End If
            cntLve = 0
        Next
        If oRet.Message.Length > 0 Then
            If MsgBox("" & oRet.Message & "... Are You Sure", MsgBoxStyle.YesNo, myWinApp.Vars("appname")) = MsgBoxResult.No Then
                Exit Function
            End If
        End If

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

    'Private Function UpdateLeaveLedger()

    'End Function
End Class



