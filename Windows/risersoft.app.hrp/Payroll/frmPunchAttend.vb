Imports ug = Infragistics.Win.UltraWinGrid
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports risersoft.app.shared

Public Class frmPunchAttend
    Inherits frmMax
    Dim f As New frmApiTaskStatus

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)

        f.AddtoTab(Me.UltraTabControl1, "status", True)
        f.SetParent(Me)
        AddHandler f.TaskExecuted, AddressOf TaskExecuted

    End Sub

    Public Sub TaskExecuted(sender As Object, TaskId As String)
        WinFormUtils.SetReadOnly(Me.Panel4, True, True)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim ds As DataSet

        Me.FormPrepared = False
        Dim objModel As frmPunchAttendModel = Me.InitData("frmPunchAttendModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "shift", "", Me.cmb_ShiftID)
            myWinSQL.AssignCmb(Me.dsCombo, "att", "", Me.cmb_attendidfh)
            myWinSQL.AssignCmb(Me.dsCombo, "att", "", Me.cmb_attendidsh)
            myWinSQL.AssignCmb(Me.dsCombo, "att", "", Me.cmb_attendidfhs)
            myWinSQL.AssignCmb(Me.dsCombo, "att", "", Me.cmb_attendidshs)
            myWinSQL.AssignCmb(Me.dsCombo, "LocCode", "", Me.cmb_LocationCode)

            ds = Me.Model.DatasetCollection("EmpList")

            Me.lbl_EmpCode.Text = ds.Tables(0).Rows(0)("EmpCode")
            Me.lbl_DepName.Text = ds.Tables(0).Rows(0)("DepName")
            Me.lbl_FullName.Text = ds.Tables(0).Rows(0)("FullName")
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function
    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("PunchData"))
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

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        Dim oret = GetParams("punchattend", "")
        MsgBox(oret.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
    End Sub

    Private Function GetParams(Key As String, UploadType As String)
        WinFormUtils.SetReadOnly(Me.Panel4, True, False)
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@dated", Format(myRow("dated"), "dd-MMM-yyyy"), GetType(DateTime), False))
        Params.Add(New clsSQLParam("@employeeid", myUtils.cValTN(myRow("employeeid")), GetType(Integer), False))
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

End Class

