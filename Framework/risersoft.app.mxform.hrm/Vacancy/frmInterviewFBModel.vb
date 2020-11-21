Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmInterviewFBModel
    Inherits clsFormDataModel
    Dim dic As New clsCollecString(Of String)

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Users")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from hrpListInterview() where InterviewID = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        sql = "Select InterviewFBID, InterviewID, InterviewerUserID, InterviewerName, Rating, Remark from hrpListInterviewFB() where InterviewID=" & frmIDX
        myView.MainGrid.QuickConf(sql, True, "1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""InterviewFB"" IDFIELD=""InterviewFBID""><COL KEY=""InterviewerUserID"" CAPTION=""Interview User"" LOOKUPSQL = ""Select UserID, UserName from Users""/><COL KEY="" InterviewID, Rating, Remark""/></BAND>"
        myView.MainGrid.PrepEdit("", EnumEditType.acCommandAndEdit)


        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim InterviewFBDescrip As String = myUtils.cStrTN(myRow("InterViewType"))
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "InterviewID", frmIDX)
                frmIDX = myRow("InterviewID")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(InterviewFBDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(InterviewFBDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If
    End Function

End Class
