Imports System.Data.Common
Imports System.Data.SqlClient
Imports risersoft.app.mxent
Imports risersoft.shared
Imports risersoft.shared.dal

Public Class UP_PunchFileTaskProvider
    Inherits clsTaskProviderBase
    'Upload Punch
    Dim conn As DbConnection, objExec As clsSQLiteExecutor
    Public Overrides ReadOnly Property IsApiTask As Boolean = False

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Function ExecutePostLocal(rTask As DataRow, input As clsProcOutput) As clsProcOutput
        'TODO: Delete punches more than 1 month old
        Dim oRet As New clsProcOutput
        Return oRet
    End Function

    Public Overrides Function ExecutePreLocal(rTask As DataRow) As Task(Of clsProcOutput)
        Dim dbconn As New clsDBConnector(New clsSQLiteExecutor())
        Dim strConn As String = myUtils.cStrTN(rTask("dbconnstring"))
        conn = dbconn.OpenConnFromString(strConn, "task")

        Dim strf1 As String = myUtils.CombineWhere(False, "punch_time <= datetime('" & Format(Now.Date.AddDays(1), "yyyy-MM-dd HH:mm:ss") & "')",
                                                   "punch_time >=datetime('" & Format(Now.Date.AddDays(-2), "yyyy-MM-dd HH:mm:ss") & "')")
        Dim oRet As New clsProcOutput
        Dim dic As New clsCollecString(Of String)
        dic.Add("punch", "Select * from att_punches  where " & strf1)
        dic.Add("machine", "select * from att_terminal")
        dic.Add("emp", "select * from hr_employee")
        oRet.Data = dbconn.Executor.ExecuteDataset(conn, Nothing, CommandType.Text, dic)
        Return Task.FromResult(oRet)
    End Function

    Public Overrides Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim ds = input.Data
        Dim dic As New clsCollecString(Of String)
        dic.Add("punch", "Select * from punchdata where 0=1")
        dic.Add("emp", "Select employeeid, SUBSTRING(empcode, PATINDEX('%[^0]%', empcode+'.'), LEN(empcode)) as empcode,cardnum From employees where onrolls=1")
        dic.Add("campus", "select * from campus")
        Dim ds2 As DataSet = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        Dim dsTarget As DataSet = ds2.Clone
        ds.Tables("punch").Columns.Add("Upload", GetType(String))
        For Each r1 As DataRow In ds.Tables(0).Select("", "employee_id,punch_time")
            For Each rFileEmp As DataRow In ds.Tables("emp").Select("id=" & r1("employee_id"))
                Dim nr As DataRow
                Try
                    Dim rrEmp() As DataRow = ds2.Tables("emp").Select(String.Format("empcode='{0}'", myUtils.cStrTN(rFileEmp("emp_pin"))))
                    Dim rrMc() As DataRow = ds.Tables("machine").Select("id=" & myUtils.cValTN(r1("terminal_id")) & "")
                    If rrEmp.Length > 0 AndAlso rrMc.Length > 0 Then
                        Dim arr() As String = Split(myUtils.cStrTN(rrMc(0)("terminal_location")), ":")
                        Dim rrCampus() As DataRow = ds2.Tables("campus").Select("campuscode='" & arr(0) & "'")
                        If rrCampus.Length > 0 Then
                            nr = myUtils.CopyOneRow(r1, dsTarget.Tables(0))
                            nr("employeeid") = myUtils.cValTN(rrEmp(0)("employeeid"))
                            nr("campusid") = myUtils.cValTN(rrCampus(0)("campusid"))
                            nr("location") = If(arr.Length > 1, arr(1), "")
                            nr("punchdate") = CDate(r1("punch_time")).Date
                            nr("punchtime") = Format(r1("punch_time"), "HH:mm")
                            myContext.DataProvider.objSQLHelper.SaveResults(dsTarget.Tables(0), "SELECT EmployeeID,PUNCHDATE,PUNCHTIME ,INOUT,campusid,location FROM PunchData")
                            r1("upload") = "Y"
                        End If
                    End If
                Catch ex As SqlException
                    If ex.Number = 2601 OrElse ex.Number = 2627 Then
                        r1("upload") = "Y"
                    Else
                        Dim str1 = ex.Message & vbCrLf & myUtils.RowValuesText(r1)
                        Trace.WriteLine(str1)
                        oRet.AddError(str1)
                    End If
                    If Not nr Is Nothing Then nr.Delete()
                Catch ex2 As Exception
                    If Not nr Is Nothing Then nr.Delete()
                    Dim str1 = ex2.Message & vbCrLf & myUtils.RowValuesText(r1)
                    Trace.WriteLine(str1)
                    oRet.AddError(str1)
                End Try

            Next
        Next
        Dim oProc As New CLSProcessPunch(myContext)
        For Each r1 As DataRow In myContext.Data.SelectDistinct(dsTarget.Tables(0), "punchdate").Select
            Dim EmployeeIDCSV As String = myUtils.MakeCSV(dsTarget.Tables(0).Select("punchdate='" & Format(r1("punchdate"), "dd-MMM-yyyy") & "'"), "employeeid")
            Dim strf1 As String = "EmployeeID in (" & EmployeeIDCSV & ")"
            oProc.processPunch(r1("punchdate"), strf1)
            oProc.processPunch(DateAdd(DateInterval.Day, -1, r1("punchdate")), strf1)
        Next
        oRet.Data = ds
        Return Task.FromResult(oRet)
    End Function
End Class






