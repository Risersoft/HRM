Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud

<DataContract>
Public Class frmBonusMasterModel
    Inherits clsFormDataModel

    Dim myViewFF, myViewPayHRVouch As clsViewModel, sql As String
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("FY")
        myViewFF = Me.GetViewModel("FF")
        myViewPayHRVouch = Me.GetViewModel("PayHRVouch")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        sql = myFuncsBase.CodeWordSQL("bonus", "cutofftype", "")
        Me.AddLookupField("BonusCutOff", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "cutofftype").TableName)

        sql = "select companyid, compname from company"
        Me.AddLookupField("CompanyID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "company").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from BonusMaster where BonusMasterID = " & prepIDX
        Me.InitData(sql, "companyid", oView, prepMode, prepIDX, strXML)
        fillGrids()

        Me.FormPrepared = True
        Return Me.FormPrepared

    End Function

    Private Sub fillGrids()
        Dim str1 As String
        If Not IsNothing(frmIDX) Then

            sql = "select BonusMasterEmpID, BonusMasterID, EmployeeID, EmpCode, FullName, TotAmountBonus, TotAmountGrat, LoanDeduction, NetPaid, PaymentThrucode from hrpListBonusMasterEmp() " &
                  "where BonusMasterid = " & frmIDX & " and entrytype='BM'"
            myView.MainGrid.QuickConf(sql, True, "1-1.5-0.5-0.5-0.5-0.5-1", True)
            str1 = "<BAND INDEX=""0"" TABLE=""BonusMasterEmp"" IDFIELD=""BonusMasterEmpID"" ><COL KEY=""PaymentThruCode"" caption = ""Payment Thru""" & myFuncs.strGridConfEnd("emp", "PaymentThru", "", 2) & "</BAND>"
            myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

            sql = "select BonusMasterEmpID, BonusMasterID, EmployeeID, EmpCode, FullName, TotAmountBonus, TotAmountGrat,LoanDeduction,NetPaid from hrpListBonusMasterEmp() " &
                  "where BonusMasterid = " & frmIDX & " and entrytype='FF'"
            myViewFF.MainGrid.QuickConf(sql, True, "1-3-1-1-1-1", True)

            sql = "select  Payee, PayDueTypeDescrip, TotalAmount  from hrpListPaymentHRVouch()  where vouchtype = 'BM'  and bonusmasterid = " & frmIDX
            myViewPayHRVouch.MainGrid.QuickConf(sql, True, "1-1-1", True)

        End If
    End Sub

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            Dim BonusDescrip As String = "Bonus for Year: " & myRow("Descrip").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "BonusMasterID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow.Row("BonusMasterID")
                Me.myView.MainGrid.SaveChanges(, "BonusMasterID = " & frmIDX)

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(BonusDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(BonusDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        Dim BonusMasterID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@BonusMasterID", Params))
        Dim ReturnTaskID As String = myContext.SQL.ParamValue("@ApiTaskID", Params)

        If oRet.Success Then
            Dim queueName = myContext.Controller.CalcQueueName
            If myUtils.IsInList(dataKey, "infojson") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet.Description = myContext.Provider.objSQLHelper.ExecuteScalar(CommandType.Text, "SELECT INFOJSON FROM APITASK WHERE APITaskID ='" & ReturnTaskID.ToString & "'").ToString
            ElseIf myUtils.IsInList(dataKey, "payloadstatus") AndAlso Not String.IsNullOrWhiteSpace(ReturnTaskID) Then
                oRet = QueueTaskProvider.GetTaskStatus(myContext, ReturnTaskID)
            Else
                Dim dicParams As New Dictionary(Of String, String)
                oRet = TaskProviderFactory.CheckAddTask(myContext, "bm", dataKey, BonusMasterID, Params, queueName, dicParams)
                If oRet.Success Then oRet.Description = oRet.GetCalcRows("task")(0)("apitaskid").ToString
            End If
        End If
        Return oRet
    End Function

End Class
