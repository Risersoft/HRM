Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud

<DataContract>
Public Class frmAttendDayModel
    Inherits clsFormDataModel
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Att")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1, strWhere As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            Me.InitData("", "dated,PayPeriodID", oView, prepMode, prepIDX, strXML)
            Dim date1 As Date = Me.vBag("dated")

            Me.ModelParams.Add(New clsSQLParam("@Dated", Me.vBag("dated"), GetType(Date), False))

            strWhere = myUtils.CombineWhere(True, "PayPeriodID = " & prepIDX & "", "Dated = '" & Format(date1, "dd-MMM-yyyy") & "'", myFuncs.WValue(pView, "id2casual,dep,isworker,contractorid"))
            sql = "select attendid, Present, Absent, Leave, ExtraDay, IsHoliday,InAbsentPeriod,LateInMin, payperiodid, DepID, EmployeeID, Dated,ShiftID, EmpCode, FullName, DepName,  AttendIDfh, AttendIDsh, InTime, OutTime, " &
                      "OTHour, Comment, UnDeclared, IsManual, LocationCode  from hrpListAttendance()  " & strWhere & " "

            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Dated"" CAPTION=""PunchingDate""/><COL KEY=""EmpCode"" CAPTION=""Employee Code""/><COL KEY=""FullName"" CAPTION=""Name""/><COL KEY=""DepName"" CAPTION=""Department""/>"
            myView.MainGrid.QuickConf(sql, True, "1-2-2-1-1-1-1-1-4-1-1-1.5", True)
            str1 = "<BAND INDEX=""0"" TABLE=""Attendance"" IDFIELD=""Attendid"" ><COL KEY=""Dated"" FIELD=""DATED""/><COL KEY=""shiftid"" LOOKUPSQL=""select shiftid,shift from shift"" CAPTION=""Shift""/><COL KEY=""attendidfh"" CAPTION=""I Half"" LOOKUPSQL=""select attendtagid,attendtag from attendtagmaster""/><COL KEY=""attendidsh"" CAPTION=""II Half"" LOOKUPSQL=""select attendtagid,attendtag from attendtagmaster""/><COL KEY=""employeeid,OTHour,Comment,payperiodid,IsManual, Present, Absent, Leave, ExtraDay, IsHoliday,InAbsentPeriod""/><COL KEY=""Undec"" FIELD=""Undeclared""/><COL KEY=""Intime,outtime"" STYLE=""TIME""/><COL KEY=""LocationCode"" LOOKUPSQL=""" & myFuncsBase.CodeWordSQL("Attendance", "LocationCode", "") & """/></BAND> "
            myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)
            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objAttend As New clsAttendanceCalc(myContext)
        VSave = False
        For Each r1 As DataRow In myView.MainGrid.myDS.Tables(0).Select
            objAttend.SetAttendanceStats(r1)
        Next
        If Me.Validate Then
            Dim AttendanceDescrip As String = "Attendance for : " & Me.vBag("Dated")
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "PayPeriodID", frmIDX)
                Me.myView.MainGrid.SaveChanges()
                myContext.Provider.dbConn.CommitTransaction(AttendanceDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(AttendanceDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If
        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        Dim dated As DateTime = myUtils.cDateTN(Replace(myContext.SQL.ParamValue("@dated", Params), "'", ""), Now)
        Dim payperiodid As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@payperiodid", Params))
        Dim ReturnTaskID As String = myContext.SQL.ParamValue("@ApiTaskID", Params)

        If oRet.Success Then
            Dim queueName = myContext.Controller.CalcQueueName
            If myUtils.IsInList(dataKey, "infojson") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet.Description = myContext.Provider.objSQLHelper.ExecuteScalar(CommandType.Text, "SELECT INFOJSON FROM APITASK WHERE APITaskID ='" & ReturnTaskID.ToString & "'").ToString
            ElseIf myUtils.IsInList(dataKey, "payloadstatus") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet = QueueTaskProvider.GetTaskStatus(myContext, ReturnTaskID)
            Else
                Select Case dataKey.Trim.ToLower
                    Case "punchday"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "attend", dataKey, PayPeriodID, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                End Select
            End If
        End If
        Return oRet
    End Function

End Class
