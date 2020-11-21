Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud

<DataContract>
Public Class frmPunchAttendModel
    Inherits clsFormDataModel
    Dim sql As String
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("PunchData")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        sql = "select shiftid,shift from shift"
        Me.AddLookupField("shiftid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "shift").TableName)

        sql = "select attendtagid,attendtag from attendtagmaster where (TagType = 1 or TagType = 2)"
        Me.AddLookupField("attendidfh", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "att").TableName)

        Me.AddLookupField("attendidsh", "att")
        Me.AddLookupField("attendidfhs", "att")
        Me.AddLookupField("attendidshs", "att")

        sql = myFuncsBase.CodeWordSQL("Attendance", "LocationCode", "")
        Me.AddLookupField("LocationCode", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "LocCode").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim rPP As DataRow
        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            sql = "select * from attendance where attendid = " & prepIDX
            Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

            Dim oMasterData As New clsMasterDataHRP(myContext)
            rPP = oMasterData.rPayPeriodID(myUtils.cValTN(myRow("payperiodid")))
            If myUtils.cBoolTN(rPP("isfinal")) Then Me.AddError("Dated", "This payperiod has been finalized")

            sql = "select punchid, PunchIndex, PunchDate, PunchTime, Geopoint, Location, DispName as Campus, Distance, DeviceId from PunchData
                   left join campus on PunchData.campusid = campus.CampusID where attendid = " & frmIDX & " order by Punchindex"
            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Distance"" CAPTION=""Distance(meters)""/>"
            myView.MainGrid.QuickConf(sql, True, "0.5-1-1-2-2-2-1-1", True, "Punches")

            Dim dic As New clsCollecString(Of String)
            dic.Add("Emp", "Select * from hrplistemp() where employeeid =" & myUtils.cStrTN(myRow("employeeid")))
            dic.Add("Punch", "Select * from punchdata where 0=1")
            Me.AddDataSet("EmpList", dic)

            Me.FormPrepared = (Me.ErrorList.Count = 0)
            If Me.ErrorList.Count = 0 Then Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If myUtils.NullNot(myRow("Dated")) Then Me.AddError("Dated", "Enter the date")
        If Me.SelectedRow("attendidfh") Is Nothing Then Me.AddError("attendidfh", "Enter Attendance")
        If Me.SelectedRow("attendidsh") Is Nothing Then Me.AddError("attendidsh", "Enter Attendance")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objAttend As New clsProcessPunchBase(myContext)

        VSave = False
        If Me.Validate Then
            Dim ds As DataSet = DatasetCollection("EmpList")
            Dim PunchDescrip As String = " Code: " & myUtils.cStrTN(ds.Tables("Emp").Rows(0)("EmpCode")) & ", Name: " & myUtils.cStrTN(ds.Tables("Emp").Rows(0)("FullName")) & ", Dt: " & Format(myRow("Dated"), "dd-MMM-yyyy")
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "attendid", frmIDX)

                objAttend.SetAttendanceStats(myRow.Row)
                objAttend.ProcessManual(myRow.Row, ds.Tables("emp").Rows(0), ds.Tables("punch"))
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(PunchDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(PunchDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        Dim dated As DateTime = myUtils.cDateTN(Replace(myContext.SQL.ParamValue("@dated", Params), "'", ""), Now)
        Dim employeeid As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@employeeid", Params))
        Dim ReturnTaskID As String = myContext.SQL.ParamValue("@ApiTaskID", Params)

        If oRet.Success Then
            Dim queueName = myContext.Controller.CalcQueueName
            If myUtils.IsInList(dataKey, "infojson") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet.Description = myContext.Provider.objSQLHelper.ExecuteScalar(CommandType.Text, "SELECT INFOJSON FROM APITASK WHERE APITaskID ='" & ReturnTaskID.ToString & "'").ToString
            ElseIf myUtils.IsInList(dataKey, "payloadstatus") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet = QueueTaskProvider.GetTaskStatus(myContext, ReturnTaskID)
            Else
                Select Case dataKey.Trim.ToLower
                    Case "punchattend"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "attend", dataKey, employeeid, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                End Select
            End If
        End If
        Return oRet
    End Function

End Class

