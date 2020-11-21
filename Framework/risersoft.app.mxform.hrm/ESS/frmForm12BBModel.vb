Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmForm12BBModel
    Inherits clsFormDataModel

    Dim sql As String

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Item")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        Dim sql As String
        sql = "Select finyearid, descrip from finyears"
        Me.AddLookupField("finyearid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "finyears").TableName)

        Dim vlist As New clsValueList
        vlist.Add(1, "1")
        vlist.Add(2, "2")
        Me.ValueLists.Add("OptionNum", vlist)
        Me.AddLookupField("OptionNum", "OptionNum")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1 As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "select * from Form12BB where Form12BBID = " & prepIDX
        Me.InitData(sql, "EmployeeID", oView, prepMode, prepIDX, strXML)

        dic.Add("Emp", "Select EmployeeID, fullname, Empcode from hrplistemp() where EmployeeID = " & myUtils.cValTN(myRow("EmployeeID")) & " order by fullname")
        Me.AddDataSet("Set", dic)

        If frmMode = EnumfrmMode.acAddM Then
            If myUtils.NullNot(myRow("OptionNum")) Then
                myRow("OptionNum") = 1
            End If
        End If

        Me.BindDataTable(myUtils.cValTN(prepIDX))

        myView.MainGrid.MainConf("formatxml") = "<COL KEY=""Evidence"" CAPTION=""Evidence / Particulars""/><COL KEY=""Description"" CAPTION=""Nature of Claim""/>"
        myView.myCMain("sortcolsasc") = "sortindex"
        myView.MainGrid.BindGridData(Me.dsForm, 1)
        myView.MainGrid.QuickConf("", True, ".2-.2-1-1-1", True)
        str1 = "<BAND INDEX=""1"" TABLE=""Form12BBItem"" IDFIELD=""Form12BBItemID""><COL KEY=""Form12BBID, TableNum, SectionNum, Amount, Evidence ""/></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Private Sub BindDataTable(ByVal Form12BBID As Integer)
        Dim oRet As clsProcOutput = myHRFuncs.CheckPopulateForm12BB(myContext, Form12BBID)
        myUtils.AddTable(Me.dsForm, oRet.Data, "item", 0)
    End Sub

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.NullNot(myRow("Dated")) Then Me.AddError("Dated", "Select Valid Date")
        If myUtils.cValTN(myRow("EmployeeID")) = 0 Then Me.AddError("Employee", "Select Valid Employee")

        Return Me.CanSave

    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then

            Dim r1 As DataRow = myContext.CommonData.FinRow(myRow("Dated"))
            If Not myUtils.NullNot(r1) Then
                myRow("FinYearID") = r1("FinYearID")
            End If

            Dim Form12BBDescrip As String = " Dated:" & myRow("Dated")

            If frmMode = EnumfrmMode.acAddM Then
                Dim sql As String = "select Form12BBID,Employeeid,finyearid from Form12BB where EmployeeID = " & myUtils.cValTN(myRow("EmployeeID")) & " And finyearid = " & myUtils.cValTN(myRow("finyearid")) & ""
                Dim dt1 As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                If dt1.Select.Length > 0 Then Me.AddError("", "Form12BB already exists for this employee in the same financial year")
            End If

            If frmMode = EnumfrmMode.acEditM Then
                Dim sql As String = "select * from Form12BB where Form12BBID = " & frmIDX & " and createdbyid = '" & myContext.Police.UniqueUserID & "'"
                Dim dt1 As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                If dt1.Select.Length = 0 Then Me.AddError("", "Only the user who created the form12bb can edit and save it.")
            End If

            If Me.CanSave Then
                Try
                    myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "Form12BBID", frmIDX)
                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                    frmIDX = myRow("Form12BBID")

                    myView.MainGrid.SaveChanges(, "Form12BBID =" & frmIDX)
                    frmMode = EnumfrmMode.acEditM
                    myContext.Provider.dbConn.CommitTransaction(Form12BBDescrip, frmIDX)
                    VSave = True
                Catch e As Exception
                    myContext.Provider.dbConn.RollBackTransaction(Form12BBDescrip, e.Message)
                    Me.AddException("", e)
                End Try
            End If
        End If

        Return VSave
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "form12bb"
                        Dim sql As String = "Select * from Form12bb where Form12bbID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from Form12bb where Form12bbID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)
                        End If

                End Select
            ElseIf oRet.WarningCount = 0 Then
                oRet.AddWarning("Are you sure ?")
            End If


        Catch ex As Exception
            oRet.AddException(ex)
        End Try


        Return oRet
    End Function

End Class
