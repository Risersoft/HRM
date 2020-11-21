Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmCourseModel
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
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String, oMasterData As New clsMasterDataHRP(myContext)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from Course where Courseid = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        sql = "Select SkillID, SkillCode, SkillName from Skill where '(' + skillcode + ')' in (" & myUtils.Coalesce(myUtils.cStrTN(myRow("SkillCSV")), "''") & ")"
        myView.MainGrid.MainConf("FormatXML") = "<COL KEY=""SkillCode"" CAPTION=""Code""/><COL KEY=""SkillName"" CAPTION=""Name""/>"
        myView.MainGrid.QuickConf(sql, True, "1-1", True)
        str1 = "<BAND INDEX=""0""></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If Me.myRow("CourseCode").Trim.Length = 0 Then Me.AddError("CourseCode", "Enter Course Code")
        If Me.myRow("CourseName").Trim.Length = 0 Then Me.AddError("CourseName", "Enter Course Name")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        Dim lst As New List(Of String)
        For Each r1 As DataRow In myView.MainGrid.myDS.Tables(0).Select()
            lst.Add("(" & myUtils.cStrTN(r1("skillcode")) & ")")
        Next
        myRow("skillcsv") = myUtils.MakeCSV2(",", "", True, lst.ToArray)

        If Me.Validate Then
            Dim CourseDescrip As String = "Course: " & myRow("CourseName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "CourseID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("CourseID")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(CourseDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(CourseDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsModel(vwState As clsViewState, SelectionKey As String, Params As List(Of clsSQLParam)) As clsViewModel
        Dim Model As clsViewModel = Nothing
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Select Case SelectionKey.Trim.ToLower
                Case "skill"
                    Dim sql As String = myContext.SQL.PopulateSQLParams("select SkillID, SkillCode, SkillName from skill where SkillCode not in (@skillcsv)", Params)
                    Model = New clsViewModel(vwState, myContext)
                    Model.Mode = EnumViewMode.acSelectM : Model.MultiSelect = True
                    Model.MainGrid.QuickConf(sql, True, "1-1", , "")
                    Dim str1 As String = "<BAND INDEX=""0"">/></BAND>"
                    Model.MainGrid.PrepEdit(str1, EnumEditType.acEditOnly)
            End Select
        End If
        Return Model
    End Function

End Class
