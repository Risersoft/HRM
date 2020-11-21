Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmInterviewFBUserModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Skill")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String

        'sql = "Select jobapplicationid, FullName + ' - ' + convert(varchar,Dated,106) as JobApplication from hrpListJobApplication() order by jobapplicationid"
        'Me.AddLookupField("jobapplicationid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "jobapplication").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from hrpListInterview() where Interviewid = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        sql = "Select InterviewFBSkillID, SkillID, InterviewID, SkillCode, SkillName, Rating, Remark from hrpListInterviewFBSkill() where InterviewID=" & frmIDX
        myView.MainGrid.QuickConf(sql, True, "1-1-1-1", True)
        'str1 = "<BAND INDEX=""0"" TABLE=""InterviewFB"" IDFIELD=""InterviewFBID""><COL KEY=""InterviewerUserID"" CAPTION=""Interview User"" LOOKUPSQL = ""Select UserID, UserName from Users""/><COL KEY="" InterviewID, Rating, Remark""/></BAND>"
        myView.MainGrid.PrepEdit("", EnumEditType.acCommandAndEdit)

        dic.Add("InterviewFB", "Select InterviewFBID, InterviewID, InterviewerUserID, InterviewerName, Rating, Remark from hrpListInterviewFB() where InterviewID=" & frmIDX)
        Me.AddDataSet("Set", dic)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        'If Me.myRow("InterViewType").Trim.Length = 0 Then Me.AddError("InterViewType", "Enter InterView Type")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim InterviewDescrip As String = myRow("InterViewType").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "InterviewID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, "Select * from Interview where InterviewID = " & frmIDX)
                frmIDX = myRow("InterviewID")

                myView.MainGrid.SaveChanges(, "InterviewID=" & frmIDX)
                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(InterviewDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(InterviewDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function

End Class
