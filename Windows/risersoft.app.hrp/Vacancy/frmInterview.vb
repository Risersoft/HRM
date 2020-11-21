
Public Class frmInterview
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridFB)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmInterviewModel = Me.InitData("frmInterviewModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "jobapplication", "", Me.cmb_JobApplicationID)

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("InterviewFB"), btnAddInterviewFB, btnDelInterviewFB)
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
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

    'Private Sub btnAddInterviewFB_Click(sender As Object, e As EventArgs) Handles btnAddInterviewFB.Click
    '    Dim Params As New List(Of clsSQLParam)
    '    Dim str1 As String = myUtils.MakeCSV(myView.mainGrid.myDS.Tables(0).Select, "UserID", ",", "'00000000-0000-0000-0000-000000000000'", True)
    '    Params.Add(New clsSQLParam("@UserIDcsv", str1, GetType(Guid), True))
    '    Dim rr() As DataRow = Me.AdvancedSelect("userset", Params)

    '    If Not IsNothing(rr) Then
    '        For Each r2 As DataRow In rr
    '            Dim r3 As DataRow = myUtils.CopyOneRow(r2, myView.mainGrid.myDS.Tables(0))
    '        Next
    '    End If

    'End Sub

    'Private Sub btnAddInterviewFB_Click(sender As Object, e As EventArgs) Handles btnAddInterviewFB.Click
    '    Dim Params As New List(Of clsSQLParam)
    '    Dim str1 As String = myUtils.MakeCSV(myView.mainGrid.myDS.Tables(0).Select, "Skillcode", ",", "''", True)
    '    Params.Add(New clsSQLParam("@SkillCSV", str1, GetType(String), True))

    '    Dim Model As clsViewModel = Me.GenerateParamsModel("skill", Params)
    '    Dim fG As New frmGrid
    '    fG.myView.PrepEdit(Model)
    '    If fG.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        Dim rr() As DataRow = fG.myView.mainGrid.myDS.Tables(0).Select("sysincl=1")
    '        Me.Controller.Data.CopySelectedRows(myView.mainGrid.myDS.Tables(0), rr, "Skillcode", True)
    '    End If
    'End Sub

End Class