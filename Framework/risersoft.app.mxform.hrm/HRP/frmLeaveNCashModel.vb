Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmLeaveNCashModel
    Inherits clsFormDataModel
    Dim myVueLveLedger As clsViewModel, objLve As New clsLeaveLedgerBase(myContext), sql As String
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("LveBal")
        myVueLveLedger = Me.GetViewModel("LveLedger")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        sql = "select LeaveMasterID, Descrip from LeaveMaster order by sDate "
        Me.AddLookupField("LeaveMasterID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "LeaveMaster").TableName)

        sql = "select attendtagid, fulltag from attendtagmaster where tagtype=3 and allowencashLM = 1  order by fulltag"
        Me.AddLookupField("attendtagid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "attendtag").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select *, 0 as companyid from LeaveLedger where LeaveLedgerID = " & prepIDX
        Me.InitData(sql, "employeeid", oView, prepMode, prepIDX, strXML)

        Dim dic As New clsCollecString(Of String)
        dic.Add("EmployeeID", "select EmployeeID, CompanyID, isCasual, EmpCode, FullName  from hrpListEmp() where EmployeeID  = " & myUtils.cValTN(myRow("EmployeeID")))
        Me.AddDataSet("Emp", dic)
        myRow("CompanyID") = Me.DatasetCollection("Emp").Tables(0).Rows(0)("CompanyID")

        If frmMode = EnumfrmMode.acEditM Then
            If Not IsDBNull(myRow("EntryType")) Then
                If myRow("EntryType") <> "E" Then
                    Me.AddError("EmpCode", "This Leave Type Cannot be Edited")
                    Exit Function
                End If
            End If
        End If
        getLeaves()

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If myUtils.NullNot(myRow("dated")) Then Me.AddError("dated", "Select date")
        If myUtils.NullNot(Me.SelectedRow("AttendTagID")) Then Me.AddError("AttendTagID", "Choose a leave type")
        If myUtils.cValTN(myRow("LeaveNum")) = 0 Then Me.AddError("LeaveNum", "Enter no. of leaves")

        Return Me.CanSave
    End Function

    Private Sub getLeaves()

        myView.MainGrid.BindGridData(GenerateData("summary", myUtils.cValTN(myRow("leavemasterid")), frmIDX, myUtils.cValTN(myRow("employeeid"))), 0)
        myView.MainGrid.QuickConf("", True, "1-1")

        myVueLveLedger.MainGrid.BindGridData(GenerateData("ledger", myUtils.cValTN(myRow("leavemasterid")), frmIDX, myUtils.cValTN(myRow("employeeid"))), 0)
        myVueLveLedger.MainGrid.QuickConf("", True, "1-1-1")

    End Sub

    Public Overrides Function VSave() As Boolean
        Dim objProc As clsProcOutput
        VSave = False
        myRow("EntryType") = "E"
        If Me.Validate Then
            objProc = objLve.TrySave(myRow.Row)
            If objProc.Success Then
                getLeaves()
                frmIDX = myRow("LeaveLedgerID")
                frmMode = EnumfrmMode.acEditM
                VSave = True
            Else
                Me.AddError("", objProc.Message)
            End If
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Dim LeaveMasterID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@LeaveMasterID", Params))
            Dim EmployeeID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@EmployeeID", Params))
            Dim LeaveLedgerID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@LeaveLedgerID", Params))
            Select Case dataKey.Trim.ToLower
                Case "getsummary"
                    oRet.Data = GenerateData("summary", LeaveMasterID, LeaveLedgerID, EmployeeID)
                Case "getledger"
                    oRet.Data = GenerateData("ledger", LeaveMasterID, LeaveLedgerID, EmployeeID)
            End Select
        End If
        Return oRet
    End Function

    Protected Overloads Function GenerateData(DataKey As String, LeaveMasterID As Integer, LeaveLedgerID As Integer, EmployeeID As Integer) As DataSet
        Dim oRet As New clsProcOutput, ds As DataSet
        Select Case DataKey.Trim.ToLower
            Case "summary"
                Dim oView As New clsViewModel(myContext)
                sql = " select  LeaveMasterID, AttendTagID, FullTag, SUM(Qty) as Balance from hrpListLeaveBal() where " &
                     " LeaveMasterID = " & myUtils.cValTN(LeaveMasterID) & " and allowencashLM = 1 " &
                     " and EmployeeID = " & myUtils.cValTN(EmployeeID) & " and LeaveLedgerID <> " & myUtils.cValTN(LeaveLedgerID) & "" &
                     " group by LeaveMasterID, AttendTagID, FullTag"
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds

            Case "ledger"
                Dim oView As New clsViewModel(myContext)
                sql = " select  AttendTagID, Dated, Descrip, Qty from hrplistleavebal() where " &
              " leavemasterid= " & myUtils.cValTN(LeaveMasterID) & " and allowencashLM = 1  " &
              " and employeeid= " & myUtils.cValTN(EmployeeID) & "  and LeaveLedgerID <> " & myUtils.cValTN(LeaveLedgerID) & " order by Dated"
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds
        End Select
        Return oRet.Data
    End Function
End Class
