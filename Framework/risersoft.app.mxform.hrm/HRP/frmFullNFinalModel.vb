Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmFullNFinalModel
    Inherits clsFormDataModel

    Dim myViewLveNCash, myViewSalary, myViewBonus As clsViewModel, sql As String
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("LoanPayBack")
        myViewLveNCash = Me.GetViewModel("lveledger")
        myViewSalary = Me.GetViewModel("Sal")
        myViewBonus = Me.GetViewModel("Bonus")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim vlist As New clsValueList
        vlist.Add(0, "Dont Include Last")
        vlist.Add(1, "Include Last")
        vlist.Add(2, "Dont Include Last+Current")
        Me.ValueLists.Add("FFIncludeLastPP", vlist)
        Me.AddLookupField("FFIncludeLastPP", "FFIncludeLastPP")

        Dim vlst As New clsValueList
        vlst.Add(False, "Dont Include")
        vlst.Add(True, "Include")
        Me.ValueLists.Add("FFIncludeLastBonus", vlst)
        Me.AddLookupField("FFIncludeLastBonus", "FFIncludeLastBonus")

        sql = myFuncsBase.CodeWordSQL("emp", "leavereason", "")
        Me.AddLookupField("LeftReasonCode", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "emp").TableName)

        sql = myFuncsBase.CodeWordSQL("emp", "noticetype", "")
        Me.AddLookupField("NoticePeriodType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "emp1").TableName)
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            sql = "Select * from hrpListEmp() where EmployeeID = " & prepIDX
            Me.InitData(sql, " ", oView, prepMode, prepIDX, strXML)

            fillGrid()

            Dim sql3 As String = "Select paymentid from PaymentHRVouch where vouchtype='FF' and EmployeeID = " & frmIDX
            Dim dt1 As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql3).Tables(0)
            If dt1.Select.Length > 0 AndAlso myUtils.cValTN(dt1.Rows(0)("paymentid")) > 0 Then
                Me.ModelParams.Add(New clsSQLParam("@IsReadOnly", True, GetType(Boolean), False))
            End If

            Me.FormPrepared = True
        End If


        Return Me.FormPrepared
    End Function

    Private Sub fillGrid()
        Dim sql1, sql2 As String, dsCalculatedData As DataSet
        sql = "select Dated, Amount from hrpListLoanPayBack()  where EmployeeID = " & frmIDX & " and InFullFinal = 1"
        myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Dated"" CAPTION=""Date"" />"
        myView.MainGrid.QuickConf(sql, True, "1-1", True)

        sql = " select EmployeeID, InFullFinal, LeaveNum, UseLeaveGroup, AmountNew, AmountPrev from leaveledger as LLed " &
              "inner join AttendTagMaster atm on LLed.AttendTagID =  atm.AttendTagID  where employeeid = " & frmIDX & " and InFullfinal=1"
        myViewLveNCash.MainGrid.MainConf("FORMATXML") = "<COL KEY=""UseLeaveGroup"" CAPTION=""LeaveType"" /><COL KEY=""LeaveNum"" CAPTION=""Count"" />"
        myViewLveNCash.MainGrid.QuickConf(sql, True, "1-1-1", True)

        sql = "select Descrip, NetPaid  from BonusMasterEmp as BME inner join BonusMaster as BM on BME.BonusMasterID = BM.BonusMasterID  " &
              "where EmployeeID = " & frmIDX & " and isnull(infullfinal,0)=1"
        myViewBonus.MainGrid.QuickConf(sql, True, "1-1", True)


        sql2 = "select EmployeeID, PayPeriodID, DepID, CampusID, InFullFinal, PaymentThruCode, LoanPayBackSal, ISFinal, PayPeriodName, DispName, " &
               "DepName, Designation, BankAccNum, TWDay, EWDay, Absent, LeaveAllow,  Arrear, ArrearMan, Advance, TDS, BonusAmountFF, BonusGratFF, TotalBasicPS, TotalAllow, NetPaid from "

        If myRow("isCasual") = True Then
            sql1 = "hrpListPSCas() where EmployeeID = " & frmIDX & " and InFullFinal=1"
        Else
            sql1 = "hrpListPSBasic() where EmployeeID = " & frmIDX & " and InFullFinal=1"
        End If
        sql = sql2 & sql1
        dsCalculatedData = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)

        myViewSalary.MainGrid.BindGridData(dsCalculatedData, 0)
        myViewSalary.MainGrid.MainConf("FORMATXML") = "<COL KEY=""PayPeriodName"" CAPTION=""PayPeriod""/><COL KEY=""BankAccNum"" CAPTION=""Acc.Number""/><COL KEY=""DispName"" CAPTION=""Campus""/><COL KEY=""NetPaid"" CAPTION=""NetAmount""/>"
        myViewSalary.MainGrid.QuickConf("", True, "1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1")

    End Sub

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If myUtils.NullNot(myRow("LeaveDate")) Then
            Me.AddError(("LeaveDate"), "Must Select Leave Date")
        Else
            If myRow("LeaveDate") < myRow("LeftReasonDate") Then Me.AddError("LeaveDate", "Must Select Leave Date After the AcceptDate")
        End If
        If myUtils.NullNot(SelectedRow("NoticePeriodType")) Then Me.AddError("NoticePeriodType", "Must Select Notice Period Type")
        If myUtils.NullNot(SelectedRow("LeftReasonCode")) Then Me.AddError(("LeftReasonCode"), "Must Select Left Reason")
        If myUtils.NullNot(myRow("LeftReasonDate")) Then Me.AddError("LeftReasonDate", "Must Select Left Reason Date")
        If myUtils.IsInList(myUtils.cStrTN(myRow("NoticePeriodType")), "A", "L") AndAlso myUtils.cStrTN(myRow("NoticePeriodMnth")).Trim.Length = 0 Then Me.AddError("NoticePeriodMnth", "Must Enter Notice Period Month")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objProc As clsProcOutput, objfullFinal As New clsFullFinalBase(myContext)
        VSave = False
        If Me.Validate Then

            objProc = objfullFinal.CalculateFullFinal(myRow.Row)
            If objProc.Success Then
                frmIDX = myRow("EmployeeID")
                frmMode = EnumfrmMode.acEditM
                fillGrid()
                VSave = True
            Else
                Me.AddError("", objProc.Message)
            End If

        End If

        Return VSave
    End Function

End Class
