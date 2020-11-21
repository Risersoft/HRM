Imports System.Data.Common
Imports System.Data.SqlClient
Imports risersoft.app.mxent
Imports risersoft.shared
Imports risersoft.shared.dal

Public Class UP_PunchTaskProvider
    Inherits clsTaskProviderBase
    'Upload Punch
    Dim conn As DbConnection, dbConn As clsDBConnector
    Public Overrides ReadOnly Property IsApiTask As Boolean = False

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Function ExecutePostLocal(rTask As DataRow, input As clsProcOutput) As clsProcOutput
        Dim ds = input.Data
        Dim sql As String = "Select punchid,upload from punchdata where upload is null"
        Return dbConn.Executor.SaveResults(conn, myContext.Police.GiveUserName, myContext.Police.UniqueUserID, "task", ds.Tables(0), sql, myContext.App.objAppExtender.RLSField(myContext.App))
    End Function

    Public Overrides Function ExecutePreLocal(rTask As DataRow) As Task(Of clsProcOutput)
        dbConn = New clsDBConnector(New clsMSSQLExecutor())
        Dim strConn As String = myUtils.cStrTN(rTask("dbconnstring"))
        conn = dbConn.OpenConnFromString(strConn, "task")
        Dim oRet As New clsProcOutput
        Dim dic As New clsCollecString(Of String)
        dic.Add("punch", "Select top 25000 * from punchdata where upload is null and punchdate<dateadd(m,1,getdate())")
        dic.Add("machine", "select * from machineinfo")
        oRet.Data = dbConn.Executor.ExecuteDataset(conn, Nothing, CommandType.Text, dic)
        Return Task.FromResult(oRet)
    End Function

    Public Overrides Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim ds = input.Data
        Dim dic As New clsCollecString(Of String)
        dic.Add("emp", "Select employeeid, empcode,cardnum From employees where onrolls=1")
        dic.Add("campus", "select * from campus")
        Dim ds2 As DataSet = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)

        Dim dsTarget As DataSet = ds.Clone
        dsTarget.Tables(0).Columns.Add("EMPLOYEEID", GetType(Integer))
        dsTarget.Tables(0).Columns.Add("campusid", GetType(Integer))
        dsTarget.Tables(0).Columns.Add("location", GetType(String))
        Dim cnt As Integer = ds.Tables(0).Select.Length, i As Integer = 0
        For Each r1 As DataRow In ds.Tables(0).Select("", "empcode,punchdate,punchtime")
            i = i + 1
            Trace.WriteLine("Processing record " & i & " of " & cnt)
            Dim nr As DataRow
            Try
                Dim rrEmp() As DataRow = ds2.Tables("emp").Select(String.Format("empcode='{0}' or cardnum='{0}'", myUtils.cStrTN(r1("empcode"))))
                Dim rrMc() As DataRow = ds.Tables("machine").Select("srno=" & myUtils.cValTN(r1("machineid")) & "")
                Dim rrCampus() As DataRow = ds2.Tables("campus").Select("campuscode='" & If(rrMc.Length > 0, myUtils.cStrTN(rrMc(0)("campuscode")), "00") & "'")

                If rrEmp.Length > 0 AndAlso rrCampus.Length > 0 AndAlso rrMc.Length > 0 Then
                    nr = myUtils.CopyOneRow(r1, dsTarget.Tables(0))
                    nr("employeeid") = myUtils.cValTN(rrEmp(0)("employeeid"))
                    nr("campusid") = myUtils.cValTN(rrCampus(0)("campusid"))
                    nr("location") = myUtils.cStrTN(rrMc(0)("location"))
                    myContext.DataProvider.objSQLHelper.SaveResults(dsTarget.Tables(0), "SELECT EmployeeID,PUNCHDATE,PUNCHTIME ,INOUT,campusid,location FROM PunchData")
                    r1("upload") = "Y"
                End If
            Catch ex As SqlException
                If ex.Number = 2601 OrElse ex.Number = 2627 Then
                    Trace.WriteLine("Already uploaded ..  updating status")
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






'Public Overrides Function ExecuteServer(rTask As DataRow, ds As DataSet, ID As Integer) As clsProcOutput
'    Dim oRet As New clsProcOutput
'    Dim dsTarget As DataSet = ds.Clone
'    For Each r1 As DataRow In ds.Tables(0).Select
'        Dim nr As DataRow = myUtils.CopyOneRow(r1, dsTarget.Tables(0))
'        Try
'            controller.DataProvider.objSQLHelper.SaveResults(dsTarget.Tables(0), Sql)
'            r1("upload") = "Y"
'        Catch ex As Exception
'            oRet.AddError(ex.Message & vbCrLf & myUtils.RowValuesText(r1))
'        End Try
'    Next
'    Dim oProc As clsProcessPunchBase = TryCast(myAssy.GetClass("risersoft.app.mxform", "clsprocesspunch", New Object() {controller}), clsProcessPunchBase)
'    For Each r1 As DataRow In controller.Data.SelectDistinct(dsTarget.Tables(0), "punchdate").Select
'        oProc.processPunch(r1("punchdate"))
'    Next
'    oRet.Data = ds
'    Return oRet
'End Function


