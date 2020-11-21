Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud

<DataContract>
Public Class frmAttendEmpModel
    Inherits clsFormDataModel
    Dim myVueLBT, myVueLB, myVueApp As clsViewModel
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Att")
        myVueLBT = Me.GetViewModel("LBT")
        myVueLB = Me.GetViewModel("LB")
        myVueApp = Me.GetViewModel("App")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str As String, rPayP As DataRow, objMstrDataHRP As New clsMasterDataHRP(myContext), objPayPeriod As New clsPayPeriodBase(myContext)
        Dim oMasterData As New clsMasterDataHRP(Me.myContext)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then

            sql = "select * from hrplistemp() where employeeid=" & prepIDX
            Me.InitData(sql, "payperiodid,leaveappid", oView, prepMode, prepIDX, strXML)

            If Not myUtils.NullNot(Me.vBag("leaveappID")) Then
                sql = "select * from leaveapp where leaveappid = " & myUtils.cValTN(Me.vBag("leaveappid"))
                Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    Dim CompanyId As Integer = myRow("CompanyID")
                    Dim Dated As Date = Format(dt.Rows(0)("StartDate"), "yyyy-MMM-dd")
                    Dim rPP As DataRow = oMasterData.rPayPeriod(CompanyId, Dated)
                    Me.vBag("PayPeriodID") = rPP("PayPeriodID")
                End If
            End If

            If Not (myUtils.NullNot(Me.vBag("PayPeriodID"))) AndAlso prepIDX > 0 Then
                rPayP = objMstrDataHRP.rPayPeriodID(myUtils.cValTN(Me.vBag("PayPeriodID")))
                If Not IsNothing(rPayP) Then
                    objPayPeriod.CalculateAbsentDays(rPayP("PayPeriodID"), prepIDX)

                    sql = "Select attendid,TotWorkHours, numpunch,latepenalty,Present, Absent, Leave, ExtraDay, IsHoliday, payperiodid, Employeeid, InAbsentPeriod, Dated, Shiftid, attendidfh, attendidsh, InTime, OutTime, OTHour,Comment, " &
                      "IsManual, UnDeclared, LateInMin,EarlyOutMin, LocationCode from attendance where  payperiodid = " & rPayP("payperiodid") & " AND employeeid = " & myUtils.cValTN(prepIDX) & " order by dated"
                    myView.MainGrid.QuickConf(sql, True, "1.5-1.5-1-1-1-1-1-1-1-1-1-1-1.8", True, "Attendance")
                    str = "<BAND INDEX=""0"" TABLE=""Attendance"" IDFIELD=""Attendid"" ><COL KEY=""Date"" FIELD=""DATED"" NOEDIT=""TRUE""/><COL KEY=""shiftid"" LOOKUPSQL=""select shiftid,shift from shift"" CAPTION=""Shift""/><COL KEY=""attendidfh"" CAPTION=""I Half"" LOOKUPSQL=""select attendtagid,attendtag from attendtagmaster order by tagtype,attendtag""/><COL KEY=""attendidsh"" CAPTION=""II Half"" LOOKUPSQL=""select attendtagid,attendtag from attendtagmaster  order by tagtype,attendtag""/><COL KEY=""employeeid,OTHour,Comment,payperiodid,ismanual,Present, Absent, Leave, ExtraDay, IsHoliday,InAbsentPeriod,lateinmin,earlyoutmin,totworkhours,numpunch,latepenalty""/><COL KEY=""Intime,outtime"" STYLE=""TIME""/><COL KEY=""LocationCode"" LOOKUPSQL=""" & myFuncsBase.CodeWordSQL("Attendance", "LocationCode", "") & """/></BAND> "
                    myView.MainGrid.PrepEdit(str, EnumEditType.acCommandAndEdit)

                    sql = "select sum(Qty) as Balance, UseLeaveGroup  from hrplistleavebal() where " &
                "leavemasterid = " & myUtils.cValTN(rPayP("LeaveMasterID")) & "  and employeeid=" & myUtils.cValTN(prepIDX) & " group by UseLeaveGroup"
                    myVueLBT.MainGrid.MainConf("FORMATXML") = "<COL KEY=""QTY"" FORMAT=""#.#""/><COL KEY=""UseLeaveGroup"" CAPTION=""Leave Group""/>"
                    myVueLBT.MainGrid.QuickConf(sql, True, "1-1", True, "Leave Balance")

                    sql = "select AttendTagID, FullTag, Dated, Descrip, Qty from hrplistleavebal() where " &
                      "leavemasterid=" & myUtils.cValTN(rPayP("LeaveMasterID")) & " and employeeid=" & myUtils.cValTN(prepIDX) & " and Qty<>0 order by Dated"
                    myVueLB.MainGrid.QuickConf(sql, True, "1.5-1.5-0.5", True, "Leave Ledger")

                    sql = "select LeaveAppID, Employeeid, StartDate, EndDate, Reason, Authority1Comments from LeaveApp where StatusText = 'Approved' AND employeeid = " & myUtils.cValTN(prepIDX) & " order by StartDate"
                    myVueApp.MainGrid.QuickConf(sql, True, "1.5-1.5-1-2", True, "Leave Applications")
                    str = "<BAND INDEX=""0"" TABLE=""LeaveApp"" IDFIELD=""LeaveAppid"" ><COL KEY=""Authority1Comments"" CAPTION=""Authority Comments""/><COL KEY=""Employeeid, StartDate, EndDate, Reason""/></BAND> "
                    myVueApp.MainGrid.PrepEdit(str, EnumEditType.acCommandOnly)

                    Me.FormPrepared = True
                End If
            End If
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objProc As clsProcOutput, objLveLedger As New clsPayPeriodBase(myContext)
        VSave = False
        If Me.Validate Then
            objProc = objLveLedger.TrySaveAttendance(Me.vBag("PayperiodID"), myRow.Row, myView.MainGrid.myDS.Tables(0))
            If objProc.Success Then
                VSave = True
            Else
                Me.AddError("", objProc.Message)
            End If
        End If
        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        Dim employeeid As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@employeeid", Params))
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
                    Case "punch"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "attend", dataKey, employeeid, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                End Select
            End If
        End If
        Return oRet
    End Function

End Class
