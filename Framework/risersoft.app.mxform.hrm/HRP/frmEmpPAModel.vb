Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmEmpPAModel
    Inherits clsFormDataModel
    Protected Overrides Sub InitViews()

    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        Dim lst As New List(Of String)
        lst.Add("A1")
        lst.Add("A2")
        lst.Add("A3")
        lst.Add("A4")
        lst.Add("A5")
        lst.Add("B1")
        lst.Add("B2")
        lst.Add("B3")
        lst.Add("B4")
        lst.Add("B5")
        lst.Add("C1")
        lst.Add("C2")
        lst.Add("C3")
        lst.Add("C4")
        lst.Add("C5")
        Me.ValueLists.Add("Grade", myContext.SQL.VListFromList(lst))
        Me.AddLookupField("Grade", "Grade")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select employeeid, grade, remark from employees where employeeid = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        Dim dic As New clsCollecString(Of String)
        dic.Add("EmpRow", "Select * from hrplistemp() where employeeid =" & myRow("employeeid"))
        Me.AddDataSet("EmpRow", dic)

        If prepMode = EnumfrmMode.acEditM Then Me.FormPrepared = True
        Return Me.FormPrepared
    End Function
    Public Overrides Function Validate() As Boolean
        Me.InitError()
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            Dim ds As DataSet = DatasetCollection("EmpRow")
            Dim EmpDescrip As String = " Name: " & myUtils.cStrTN(ds.Tables("EmpRow").Rows(0)("FullName")) & ", Grade: " & myUtils.cStrTN(myRow("Grade"))
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "employeeid", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("employeeid")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(EmpDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(EmpDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function

End Class
