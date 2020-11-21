Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud

<DataContract>
Public Class frmLeaveMasterModel
    Inherits clsFormDataModel

    Dim myViewFF, myViewLL, myViewFY, myViewPayHRVouch, myViewYr As clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("LveBal")
        myViewFF = Me.GetViewModel("FF")
        myViewLL = Me.GetViewModel("LL")
        myViewFY = Me.GetViewModel("FY")
        myViewPayHRVouch = Me.GetViewModel("PayHRVouch")
        myViewYr = Me.GetViewModel("Yr")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String = "select companyid, compname from company"
        Me.AddLookupField("companyid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "company").TableName)
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        Dim sql As String = "Select * from LeaveMaster where LeaveMasterID = " & prepIDX
        Me.InitData(sql, "companyid", oView, prepMode, prepIDX, strXML)

        fillGrids()
        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function
    Private Sub fillGrids()
        Dim sql, str As String, oPP As New clsPayPeriodBase(myContext)
        If Not IsNothing(frmIDX) Then
            Dim PrevLeaveMasterID As Integer = 0
            Dim rComp As DataRow = myContext.CommonData.rCompany(myRow.Row("companyid"))
            If myRow.Row("sdate") >= rComp("HRStartDate") Then

                Dim rPrevLM As DataRow = oPP.oMasterData.LMRow(myRow.Row("companyid"), DateAdd(DateInterval.Month, -1, myRow.Row("sdate")), False)
                If Not rPrevLM Is Nothing Then PrevLeaveMasterID = rPrevLM("leavemasterid")
            End If

            sql = "Select  EmpCode, FullName, Sum(Qty) As Qty from hrplistleavebal() where (EntryType = 'A' or EntryType = 'B') and LeaveMasterID = " & frmIDX & " group by EmpCode, FullName"
            myView.MainGrid.QuickConf(sql, True, "1-1-1-1-1", True)

            sql = "select  LeaveMasterEmpID, EmployeeID, LeaveMasterID, EmployeeID, EmpCode, FullName, Qty, AmountNew, AmountPrev, PaymentThruCode from hrpListLeaveMasterEmp() where entrytype='LM' and LeaveMasterID = " & PrevLeaveMasterID
            myViewYr.MainGrid.QuickConf(sql, True, "1-1-1-1-1-1")
            str = "<BAND INDEX=""0"" TABLE=""LeaveMasterEmp"" IDFIELD=""LeaveMasterEmpID""><COL KEY=""PaymentThruCode"" caption = ""Payment Thru""" & myFuncs.strGridConfEnd("emp", "PaymentThru", "", 2) & "</BAND>"
            myViewYr.MainGrid.PrepEdit(str, EnumEditType.acCommandAndEdit)

            sql = "select  Payee, PayDueTypeDescrip, TotalAmount  from hrpListPaymentHRVouch()  where vouchtype = 'LM' and LeaveMasterID = " & PrevLeaveMasterID
            myViewPayHRVouch.MainGrid.QuickConf(sql, True, "1-1-1", True)
            str = "<BAND INDEX = ""0"" TABLE = ""PaymentHRVouch"" IDFIELD=""PaymentHRVouchID""><COL KEY ="" PayDueTypeDescrip"" Caption = ""Payment Due""/></BAND>"
            myViewPayHRVouch.MainGrid.PrepEdit(str, EnumEditType.acCommandAndEdit)

            sql = "select EmployeeID, EmpCode, FullName, Descrip, AmountNew, AmountPrev from hrplistleavebal() where isnull(InFullFinal,0)= 1  and LeaveMasterID = " & frmIDX
            myViewFF.MainGrid.QuickConf(sql, True, "1-1-1-1-1", True)

            sql = "select EmployeeID, EmpCode, FullName, Descrip, AmountNew, AmountPrev from hrplistleavebal() where isnull(InFullFinal,0)= 0  and LeaveMasterID = " & frmIDX & " and  EntryType = 'N'"
            myViewLL.MainGrid.QuickConf(sql, True, "1-1-1-1-1", True)

            sql = "select  EmpCode, FullName, DepName, Qty, AmountNew, AmountPrev  from hrpListLeaveMasterEmp() where entrytype='FY' and LeaveMasterID = " & frmIDX
            myViewFY.MainGrid.QuickConf(sql, True, "1-1-1-1-1-1", True)

        End If
    End Sub

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim LeaveDescrip As String = " Leaves for : " & myUtils.cStrTN(myRow("Descrip"))
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "LeaveMasterID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, "select leavemasterid, elminmonths from LeaveMaster")
                myContext.Provider.objSQLHelper.SaveResults(myViewYr.MainGrid.myDS.Tables(0), "Select  PaymentThruCode from LeaveMasterEmp")
                frmIDX = myRow.Row("LeaveMasterID")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(LeaveDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(LeaveDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        Dim LeaveMasterID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@LeaveMasterID", Params))
        Dim ReturnTaskID As String = myContext.SQL.ParamValue("@ApiTaskID", Params)

        If oRet.Success Then
            Dim queueName = myContext.Controller.CalcQueueName
            If myUtils.IsInList(dataKey, "infojson") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet.Description = myContext.Provider.objSQLHelper.ExecuteScalar(CommandType.Text, "SELECT INFOJSON FROM APITASK WHERE APITaskID ='" & ReturnTaskID.ToString & "'").ToString
            ElseIf myUtils.IsInList(dataKey, "payloadstatus") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet = QueueTaskProvider.GetTaskStatus(myContext, ReturnTaskID)
            Else
                Select Case dataKey.Trim.ToLower
                    Case "generateleavebal"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "lm", dataKey, LeaveMasterID, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                    Case "generatefy"
                        Dim dicParams As New Dictionary(Of String, String)
                        oRet = TaskProviderFactory.CheckAddTask(myContext, "lm", dataKey, LeaveMasterID, Params, queueName, dicParams)
                        If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
                End Select
            End If
        End If
        Return oRet
    End Function

End Class


