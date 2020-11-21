Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmEmpApplicationModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub
    Private Sub InitForm()
        Dim sql As String
        sql = myFuncsBase.CodeWordSQL("emp", "ApplicationType", "")
        Me.AddLookupField("ApplicationType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "ApplicationType").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select *, 0 as CompanyID from EmpApplication Where EmpApplicationID = " & prepIDX
        Me.InitData(sql, "EmployeeID", oView, prepMode, prepIDX, strXML)

        Dim dic As New clsCollecString(Of String)
        dic.Add("EmployeeID", "select * from hrplistEmp() where employeeid = " & myUtils.cValTN(myRow("EmployeeID")))
        Me.AddDataSet("Emp", dic)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If myUtils.NullNot(Me.SelectedRow("ApplicationType")) Then Me.AddError("ApplicationType", "Choose an Application Type")
        If myUtils.NullNot(myRow("ApplicationDate")) Then Me.AddError("ApplicationDate", "Select an Application Date")
        If myUtils.NullNot(myRow("Reason")) Then Me.AddError("Reason", "Enter a reason")

        If myUtils.cStrTN(myRow("ApplicationType")) = "LO" Then
            If myUtils.NullNot(myRow("DesiredDateLoan")) Then Me.AddError("DesiredDateLoan", "Select Loan Date")
            If myUtils.cValTN(myRow("DesiredAmount")) = 0 Then Me.AddError("DesiredAmount", "Enter Amount for Loan")
            If myUtils.cValTN(myRow("DesiredNumPB")) = 0 Then Me.AddError("DesiredNumPB", "Enter No. of Installments")
            If myUtils.cValTN(myRow("DesiredDatePB")) = 0 Then Me.AddError("DesiredDatePB", "Enter Starting From")

        ElseIf myUtils.cStrTN(myRow("ApplicationType")) = "LE" Then
            If myUtils.cValTN(myRow("DesiredLeaveNum")) = 0 Then Me.AddError("DesiredLeaveNum", "Enter no. of leaves")
        End If

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim oMasterData As New clsMasterDataHRP(myContext), dt As DataTable, rPP As DataRow
        VSave = False
        If Me.Validate Then
            Dim EmpAppDescrip As String = " Type: " & myUtils.cStrTN(myRow("ApplicationType")) & " Dt: " & Format(myRow("ApplicationDate"), "dd-MMM-yyyy")
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "EmpApplicationID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("EmpApplicationID")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(EmpAppDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(EmpAppDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If
        Return VSave
    End Function

    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput, oMasterData As New clsMasterDataHRP(myContext), dt As DataTable, rPP As DataRow
        Select Case dataKey.Trim.ToLower
            Case "empapp"
                Dim dic As New clsCollecString(Of String)
                dic.Add("app", "select * from empapplication where empapplicationid = " & ID)
                dic.Add("pf", "select Sum(AmountEE + AmountER)  as PFBal from PayslipCalc where payslipid in (select PaySlipID from PaySlip where EmployeeID = " & ID & ") " &
                "and SalBenefitID = (select SalBenefitID from SalBenefit where BenefitCode = 'PF')")
                Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)

                If ds.Tables("app").Rows.Count > 0 Then
                    Dim rApp As DataRow = ds.Tables("app").Rows(0)
                    If ds.Tables("pf").Rows.Count > 0 Then rApp("PFBal") = ds.Tables("app").Rows(0)("PFBal")

                    dic.Add("leave", "Select * from leavemaster where sdate <= '" & Format(rApp("Dated"), "yyyy-MMM-dd") & "'  and edate > = '" & Format(rApp("Dated"), "yyyy-MMM-dd") & "'")
                    Dim ds1 As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
                    If ds1.Tables("leave").Rows.Count > 0 Then rApp("LeaveMasterID") = ds1.Tables("leave").Rows(0)("LeaveMasterID")

                    dic.Add("Emp", "select * from hrplistEmp() where employeeid = " & ID)
                    Dim ds2 As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
                    If Not myUtils.NullNot(rApp("Dated")) AndAlso ds2.Tables("Emp").Rows.Count > 0 Then
                        Dim remp As DataRow = ds.Tables("Emp").Rows(0)
                        rPP = oMasterData.rPayPeriod(remp("CompanyID"), rApp("Dated"))
                        If Not IsNothing(rPP) Then rApp("PayperiodID") = rPP("PayperiodID")
                    End If
                    dic.Add("empsal", "select  top 1* from EmpSalRateCalc where EmpSalaryID in (select EmpSalaryID from EmpSalary where EmployeeID = " & ID & " ) " &
                        "and RateMasterID = (select RateMasterID from PayPeriod where SDate < = '" & Format(rApp("Dated"), "yyyy-MMM-dd") & "' and EDate > = '" & Format(rApp("Dated"), "yyyy-MMM-dd") & "')")
                    Dim ds3 As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
                    If ds3.Tables("empsal").Rows.Count > 0 Then rApp("EmpSalRateCalcID") = ds3.Tables("empsal").Rows(0)("EmpSalRateCalcID")

                    myContext.Provider.objSQLHelper.SaveResults(ds.Tables("app"), "select * from empapplication")

                End If
        End Select
        Return oRet
    End Function

End Class
