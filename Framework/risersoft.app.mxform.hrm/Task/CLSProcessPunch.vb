Imports risersoft.app.mxent
Imports risersoft.shared

Public Class CLSProcessPunch
    Inherits clsProcessPunchBase

    Dim dtPunch As DataTable, objOutput As clsPunchOutput, WeekLateSum As Decimal
    Public Sub New(context As IProviderContext)
        MyBase.New(context)
    End Sub
    Public Function processPunchEmp(ByVal dated As DateTime, ByVal employeeid As Integer) As clsProcOutput
        Return Me.processPunch(dated, "employeeid = " & employeeid)
    End Function
    Public Function processPunchDay(ByVal dated As DateTime) As clsProcOutput
        Return Me.processPunch(dated, " joindate< ='" & Format(dated, "yyyy-MMM-dd") & "' and (leavedate is null or leavedate>='" & Format(dated, "yyyy-MMM-dd") & "')")
    End Function

    Public Overrides Function processPunch(ByVal dated As DateTime, strFilter As String) As clsProcOutput
        Dim oRet As New clsProcOutput

        Try
            Dim sql As String, rRate As DataRow = Nothing

            Dim dtShifts = Me.ShiftsTable(dated)
            Dim str1 As String = myUtils.CombineWhere(False, strFilter, myUtils.CombineWhereOR(False, "isnull(punchenabled,0)=1", "cardNum is not null"))

            sql = "select employeeid,shiftid,campusid,companyid from hrplistemp() where " & str1
            Dim dtEmps = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

            Dim str2 As String = "employeeid in (select employeeid from employees where " & str1 & ")"

            Me.LoadAttendanceData(dated, str2)

            For Each rEmp As DataRow In dtEmps.Select
                Dim rPP As DataRow = oMasterData.rPayPeriod(rEmp("companyid"), dated)
                If (Not rPP Is Nothing) AndAlso myUtils.NullNot(rPP("salcalcon")) Then
                    rRate = Me.oMasterData.rRateMaster(myContext.CommonData.GetCompanyIDFromCampus(rEmp("campusid")), dated)
                    Dim rAttend As DataRow = Me.AttendanceRow(rEmp, dated, False)
                    Dim rAttend2 As DataRow = Me.AttendanceRowExisting(dtAttendance, rEmp("employeeid"), dated.AddDays(1))
                    If (Not rAttend Is Nothing) Then
                        If myUtils.cBoolTN(rAttend("IsManual")) Then
                            'manual row: do nothing
                        Else
                            Me.InitAttendanceRow(rAttend)
                            Dim rShift As DataRow = Me.ShiftRow(dtShifts, rAttend("shiftid"))
                            Dim rShift2 As DataRow = Me.ShiftRow(dtShifts, If(rAttend2 Is Nothing, rEmp("shiftid"), rAttend2("shiftid")))

                            dtPunch = Me.PunchTableFromDateShift(rEmp, rRate, rShift, rShift2)
                            If dtPunch.Rows.Count > 0 Then
                                Me.PreProcessTable(rAttend, dtPunch)
                                objOutput = Me.ProcessRate(rEmp, rAttend, dtPunch, rShift, rRate)
                                SetAttendanceSugg(rAttend, rShift, rRate)

                                myContext.Provider.objSQLHelper.SaveResults(dtPunch, "select * from punchdata")

                            Else
                                Dim AttendID As Integer = Me.AttendIDAbsent
                                rAttend("attendIdFHS") = AttendID
                                rAttend("attendIdSHS") = AttendID
                            End If
                            SetAttendanceStats(rAttend, myUtils.cValTN(rAttend("AttendIDFHS")), myUtils.cValTN(rAttend("AttendIDSHS")))
                        End If
                    End If
                End If
            Next
            If Not IsNothing(dtAttendance) AndAlso dtAttendance.Rows.Count > 0 Then myContext.Provider.objSQLHelper.SaveResults(dtAttendance, "select * from attendance")

        Catch ex As Exception
            oRet.AddException(ex)
        End Try
        Return oRet
    End Function

    Public Function SetAttendanceSugg(rAttend As DataRow, rShift As DataRow, rRate As DataRow)
        SetLateEarlyMin(rAttend, rShift)
        WeekLateSum = objOutput.PrevLateSumWeekAfterPenalty
        rAttend("LatePenalty") = 0
        WeekLateSum = WeekLateSum + myUtils.cValTN(rAttend("lateinMin"))

        If myUtils.cBoolTN(rAttend("isholiday")) Then
            If myUtils.cValTN(rAttend("totworkhours")) <= rShift("whours") / 2 Then
                rAttend("attendIdFHS") = 1
                rAttend("attendIdSHS") = 2
                If myUtils.cValTN(rAttend("totworkhours")) < rShift("whours") / 2 Then rAttend("attconflict") = True
            ElseIf myUtils.cValTN(rAttend("totworkhours")) > rShift("whours") / 2 Then
                rAttend("attendIdFHS") = 1
                rAttend("attendIdSHS") = 1
                If myUtils.cValTN(rAttend("totworkhours")) < rShift("whours") Then rAttend("attconflict") = True
            End If
        Else
            'working day
            If IsDBNull(rAttend("outtime")) Then rAttend("EarlyOutMin") = 0
            If IsDBNull(rAttend("intime")) Then rAttend("LateInMin") = 0
            If (Not IsDBNull(rAttend("outtime"))) AndAlso (Not IsDBNull(rAttend("intime"))) Then
                If myUtils.cValTN(rAttend("totworkhours")) >= rShift("whours") Then
                    rAttend("attendIdFHS") = 1
                    rAttend("attendIdSHS") = 1
                    Me.CheckWeekLateSum(rAttend, myUtils.cValTN(rRate("WeeklyLateAllow")), "FHS")
                ElseIf myUtils.cValTN(rAttend("totworkhours")) >= rShift("whours") / 2 Then
                    If rAttend("intime") > rShift("botime") Then
                        rAttend("attendIdFHS") = 2
                        rAttend("attendIdSHS") = 1
                        Me.CheckWeekLateSum(rAttend, myUtils.cValTN(rRate("WeeklyLateAllow")), "SHS")
                    ElseIf rAttend("intime") > rShift("sdtime") AndAlso rAttend("intime") < rShift("botime") Then
                        rAttend("attendIdFHS") = 2
                        rAttend("attendIdSHS") = 1
                        rAttend("latepenalty") = 1

                    Else
                        rAttend("attendIdFHS") = 1
                        rAttend("attendIdSHS") = 2

                    End If
                    WeekLateSum = WeekLateSum + myUtils.cValTN(rAttend("earlyoutmin"))

                    If rAttend("outtime") < rShift("edtime") AndAlso rAttend("outtime") <= rShift("MaxTimeSH") Then
                        rAttend("attendIdSHS") = 2

                    ElseIf rAttend("outtime") < rShift("edtime") AndAlso rAttend("outtime") > rShift("MaxTimeSH") Then
                        Me.CheckWeekLateSum(rAttend, myUtils.cValTN(rRate("WeeklyLateAllow")), "SHS")
                    End If
                    'This else require where InTime and OutTime is not null but working hours < whrs/2
                Else
                    'Both absent, No LatePenalty and Hence no LateinMin/EarlyOutMin
                    rAttend("LateInMin") = 0
                    rAttend("EarlyOutMin") = 0

                End If

                If myUtils.cValTN(rAttend("lateinMin")) = 0 AndAlso myUtils.cValTN(rAttend("earlyoutMin")) = 0 AndAlso myUtils.cValTN(rAttend("totworkhours")) < rShift("whours") AndAlso rAttend("intime") < rShift("MaxTimeFH") AndAlso rAttend("outtime") > rShift("MaxTimeSH") Then
                    rAttend("attconflict") = True
                End If
                'This else require where InTime or  OutTime is null. In the case of single punch
            End If
        End If

        If dtPunch.Rows.Count Mod 2 = 1 Then rAttend("attconflict") = True
        Return True
    End Function
    Private Function CheckWeekLateSum(rAttend As DataRow, WeekLateSumAllow As Decimal, HalfString As String) As Integer
        If WeekLateSum > WeekLateSumAllow Then
            rAttend("attendId" & HalfString) = 2
            rAttend("LatePenalty") = rAttend("LatePenalty") + 1
        End If
        Return True
    End Function


End Class

