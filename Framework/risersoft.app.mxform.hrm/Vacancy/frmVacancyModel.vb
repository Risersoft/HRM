Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmVacancyModel
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

        sql = "Select depid, depname, companyid from deps order by depname"
        Me.AddLookupField("depid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "dep").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String, oMasterData As New clsMasterDataHRP(myContext)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from Vacancy where Vacancyid = " & prepIDX
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
        If Me.myRow("VacCode").Trim.Length = 0 Then Me.AddError("VacCode", "Enter Vacancy Code")
        If Me.SelectedRow("depid") Is Nothing Then Me.AddError("depid", "Enter Department")

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
            Dim VacancyDescrip As String = "Vacancies: " & myRow("Vacancy").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "VacancyID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("VacancyID")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(VacancyDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(VacancyDescrip, ex.Message)
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

