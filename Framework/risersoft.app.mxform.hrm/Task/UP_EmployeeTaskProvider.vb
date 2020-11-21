Imports System.Data.Common
Imports System.Data.SqlClient
Imports risersoft.shared
Imports risersoft.shared.dal

Public Class UP_EmployeeTaskProvider
    Inherits clsTaskProviderBase

    Public Overrides ReadOnly Property IsApiTask As Boolean = False
    'this task downloads employee master from main database and uploads to local punch db
    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub
    Protected Friend Function GetConnector(rTask As DataRow) As clsDBConnector
        Dim dbconn As New clsDBConnector(New clsMSSQLExecutor())
        Dim strConn As String = myUtils.cStrTN(rTask("dbconnstring"))
        dbconn.OpenConnFromString(strConn, "task")
        Return dbconn
    End Function

    Public Overrides Function ExecutePostLocal(rTask As DataRow, input As clsProcOutput) As clsProcOutput
        'save employee data to localdb
        Dim dbconn = Me.GetConnector(rTask)
        Dim sql As String = "Select * from emp_mst"

        Return dbconn.Executor.SaveResults(dbconn.DBConnection, myContext.Police.GiveUserName, myContext.Police.UniqueUserID, "task", input.Data.Tables(0), sql, myContext.App.objAppExtender.RLSField(myContext.App))
    End Function

    Public Overrides Function ExecutePreLocal(rTask As DataRow) As Task(Of clsProcOutput)
        Dim oRet As New clsProgressReport
        Dim dbconn = Me.GetConnector(rTask)
        Dim sql As String = "Select * from emp_mst"
        oRet.Data = dbconn.Executor.ExecuteDataset(dbconn.DBConnection, Nothing, CommandType.Text, sql)
        Return Task.FromResult(Of clsProcOutput)(oRet)
    End Function

    Public Overrides Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim ds = input.Data

        Dim sql As String = "select empcode,cardnum,fullname from hrplistemp() where onrolls=1 and isnull(cardnum,0)>0"
        Dim ds2 As DataSet = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)

        ds.Tables(0).Columns.Add("ispresent", GetType(Boolean))
        myUtils.ChangeAll(ds.Tables(0).Select, "ispresent=0")

        For Each r1 As DataRow In ds2.Tables(0).Select()
            Dim rr() As DataRow = ds.Tables(0).Select("empcode='" & r1("empcode") & "'"), nr As DataRow
            If rr.Length > 0 Then
                nr = rr(0)
            Else
                nr = myUtils.CopyOneRow(r1, ds.Tables(0),, False)
            End If
            nr("cardnum") = r1("cardnum")
            nr("ispresent") = True
            nr("messagetext") = "Welcome " & r1("fullname")
        Next
        myUtils.DeleteRows(ds.Tables(0).Select("ispresent=0"))
        oRet.Data = ds
        Return Task.FromResult(oRet)
    End Function
End Class
