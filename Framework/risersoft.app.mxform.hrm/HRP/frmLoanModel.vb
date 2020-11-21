Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmLoanModel
    Inherits clsFormDataModel
    Dim myViewIncen, myViewBonus, myViewAdHoc As clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("LoanPayBack")
        myViewIncen = Me.GetViewModel("LoanPayBackIncen")
        myViewBonus = Me.GetViewModel("Bonus")
        myViewAdHoc = Me.GetViewModel("AdHoc")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        Dim sql As String = myFuncsBase.CodeWordSQL("emp", "LoanPayBack", "")
        Me.AddLookupField("DeductFromPM", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "DeductFromPM").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1, sql As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from EmpLoan Where emploanid = " & prepIDX
        Me.InitData(sql, "EmployeeID", oView, prepMode, prepIDX, strXML)

        Dim dic As New clsCollecString(Of String)
        dic.Add("EmployeeID", "select * from hrplistEmp() where employeeid = " & myUtils.cValTN(myRow("EmployeeID")))
        Me.AddDataSet("Emp", dic)

        sql = "select EmpLoanPayBacKID, EmpLoanID,CompanyID, PayPeriodID, PaymentID,SalCalcOn, IsFinal, PayPeriodName,  Amount, Remark, DeductFromPP from hrpListLoanPayBack() where  EmpLoanID = " & frmIDX & " and PayPeriodID is not null and AdHocPayDate is null and DeductfromPP <> 'I' "
        myView.MainGrid.QuickConf(sql, True, "1-1-1-1")
        str1 = "<BAND INDEX=""0"" TABLE=""EmpLoanPayBack"" IDFIELD=""EmpLoanPayBacKID""><COL KEY=""Amount, Remark""/><COL NOEDIT=""TRUE"" KEY=""EmpLoanID"" /><COL NOEDIT=""TRUE"" KEY=""PayPeriodID"" CAPTION=""PayPeriod""/>" & "<COL KEY=""DeductFromPP""" & myFuncs.strGridConfEnd("emp", "LoanPayBack", "CodeWord not in ('I')", 2) & " </BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        sql = "select EmpLoanPayBacKID, EmpLoanID,CompanyID, PayPeriodID, PaymentID,WOTCalcOn, IsFinalWOT, DeductFromPP, PayPeriodName,  Amount, Remark from hrpListLoanPayBack() where  EmpLoanID = " & frmIDX & " and PayPeriodID is not null and AdHocPayDate is null and DeductfromPP = 'I' "
        myViewIncen.MainGrid.QuickConf(sql, True, "1-1-1")
        str1 = "<BAND INDEX=""0"" TABLE=""EmpLoanPayBack"" IDFIELD=""EmpLoanPayBacKID""><COL KEY=""Amount, Remark""/><COL NOEDIT=""TRUE"" KEY=""EmpLoanID"" /><COL NOEDIT=""TRUE"" KEY=""PayPeriodID"" CAPTION=""PayPeriod""/>" & "<COL KEY=""DeductFromPP""" & myFuncs.strGridConfEnd("emp", "LoanPayBack", "", 2) & " </BAND>"
        myViewIncen.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        sql = "select EmpLoanPayBacKID, EmpLoanID, BonusMasterID, IsFinal, BonusCalcOn, BonusPaidOn, Descrip, Amount, Remark from hrpListLoanPayBack() where  EmpLoanID = " & frmIDX & " and BonusMasterid is not null"
        myViewBonus.MainGrid.QuickConf(sql, True, "1-1-1")
        str1 = "<BAND INDEX=""0"" TABLE=""EmpLoanPayBack"" IDFIELD=""EmpLoanPayBacKID""><COL KEY=""BonusMasterID, Amount, Remark""/><COL NOEDIT=""TRUE"" KEY=""EmpLoanID"" /></BAND>"
        myViewBonus.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        sql = "select EmpLoanPayBacKID, EmpLoanID,PayPeriodID, 0 as PPIsFinal, PaymentID, IsFinal, AdHocPayDate, Amount, Remark from hrpListLoanPayBack() where AdHocPayDate is not null and  EmpLoanID = " & frmIDX & ""
        myViewAdHoc.MainGrid.QuickConf(sql, True, "1-1-1")
        str1 = "<BAND INDEX=""0"" TABLE=""EmpLoanPayBack"" IDFIELD=""EmpLoanPayBacKID""><COL KEY="" AdHocPayDate, Amount, Remark""/><COL NOEDIT=""TRUE"" KEY=""EmpLoanID,PayPeriodID"" /></BAND>"
        myViewAdHoc.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        If myUtils.cStrTN(Me.DatasetCollection("emp").Tables(0).Rows(0)("ContractorID")).Length > 0 Then Me.AddError("Dated", "Loan entry is not possible for contractor's employee")

        Me.FormPrepared = (Me.ErrorList.Count = 0)
        If Me.ErrorList.Count = 0 Then Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If myUtils.NullNot(myRow("dated")) Then Me.AddError("dated", "Select a Starting Date of Loan")
        If myUtils.NullNot(myRow("Amount")) Then Me.AddError("Amount", "Must Enter Loan Amount")
        If myUtils.NullNot(myRow("DeductAmountPM")) Then Me.AddError("DeductAmountPM", "Must Enter Installment Amount")
        If myUtils.NullNot(myRow("DeductStartFrom")) Then Me.AddError("DeductStartFrom", "Must Select Deduct Start Month")
        If Me.SelectedRow("DeductFromPM") Is Nothing Then Me.AddError("DeductFromPM", "Must Select, from loan deducts")
        myView.MainGrid.CheckValid("DeductFromPP")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objEmpLoan As New clsEmpLoanBase(myContext), rPayP As DataRow
        VSave = False

        If Me.Validate Then

            rPayP = objEmpLoan.oMasterData.rPayPeriod(Me.DatasetCollection("emp").Tables(0).Rows(0)("CompanyID"), myUtils.cDateTN(myRow("dated"), Now.Date))
            If rPayP Is Nothing Then Me.AddError("", "Pay Period not found")

            Dim dt1 As DataTable = objEmpLoan.LoadVouch(frmIDX)
            rPayP = objEmpLoan.oMasterData.rPayPeriod(Me.DatasetCollection("emp").Tables(0).Rows(0)("CompanyID"), myRow("dated"))
            If (myUtils.cBoolTN(rPayP("IsFinal"))) AndAlso (myUtils.NullNot(myRow("EmploanID"))) Then Me.AddError(myRow("dated"), "Select Valid Date, PostPeriod Corresponding to this date is Finalized")

            For Each r1 As DataRow In myViewAdHoc.MainGrid.myDS.Tables(0).Select()
                If myUtils.NullNot(r1("EmpLoanPayBackID")) Then
                    rPayP = objEmpLoan.oMasterData.rPayPeriod(Me.DatasetCollection("emp").Tables(0).Rows(0)("CompanyID"), r1("AdHocPayDate"))
                    r1("PayperiodID") = rPayP("PayperiodID")
                    If Not IsNothing(rPayP) Then
                        r1("PPIsFinal") = myUtils.cBoolTN(rPayP("IsFinal"))
                        If r1("PPIsFinal") = 1 Then Me.AddError("", Nothing, 0, "", "", "PayPeriod Corresponding to AdHocPayDate " & r1("AdHocPayDate") & " is Finalized")
                    End If
                    End If
            Next

            If Me.CanSave Then
                Dim LoanDescrip As String = " Loan for: " & Me.DatasetCollection("emp").Tables(0).Rows(0)("EmpCode") & ", Name: " & Me.DatasetCollection("emp").Tables(0).Rows(0)("FullName")

                Try
                    myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "EmpLoanID", frmIDX)

                    Dim pb As Decimal = 0, edate As DateTime = DateTime.MinValue
                    For Each oView As clsViewModel In New clsViewModel() {myView, myViewIncen, myViewBonus, myViewAdHoc}
                        For Each r1 As DataRow In oView.MainGrid.myDS.Tables(0).Select
                            pb = pb + myUtils.cValTN(r1("amount"))
                            If r1.Table.Columns.Contains("payperiodid") Then
                                Dim rPP As DataRow = objEmpLoan.oMasterData.rPayPeriodID(myUtils.cValTN(r1("PayPeriodID")))
                                If rPP("edate") > edate Then edate = rPP("edate")
                            ElseIf r1.Table.Columns.Contains("bonusmasterid") Then
                                Dim rBM As DataRow = objEmpLoan.oMasterData.rBonusMasterID(myUtils.cValTN(r1("BonusMasterID")))
                                If rBM("edate") > edate Then edate = rBM("edate")
                            End If
                        Next
                    Next
                    If pb >= myUtils.cValTN(myRow("amount")) Then
                        myRow("completedon") = edate
                    Else
                        myRow("completedon") = DBNull.Value
                    End If
                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                    frmIDX = myRow("EmpLoanID")

                    Me.myView.MainGrid.SaveChanges(, "EmpLoanID=" & frmIDX)
                    Me.myViewIncen.MainGrid.SaveChanges(, "EmpLoanID=" & frmIDX)
                    Me.myViewBonus.MainGrid.SaveChanges(, "EmpLoanID=" & frmIDX)
                    Me.myViewAdHoc.MainGrid.SaveChanges(, "EmpLoanID=" & frmIDX)

                    objEmpLoan.UpdateBalance(Me.DatasetCollection("emp").Tables(0).Rows(0), myView.MainGrid.myDS.Tables(0), myViewIncen.MainGrid.myDS.Tables(0), myViewBonus.MainGrid.myDS.Tables(0), myViewAdHoc.MainGrid.myDS.Tables(0))


                    frmMode = EnumfrmMode.acEditM
                    myContext.Provider.dbConn.CommitTransaction(LoanDescrip, frmIDX)
                    VSave = True

                Catch ex As Exception
                    myContext.Provider.dbConn.RollBackTransaction(LoanDescrip, ex.Message)
                    Me.AddError("", ex.Message)

                End Try
            End If
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsModel(vwState As clsViewState, SelectionKey As String, Params As List(Of clsSQLParam)) As clsViewModel
        Dim Model As New clsViewModel(vwState, myContext), ppids, bmids As String, dated As DateTime, sql As String
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)

        If oRet.Success Then

            Select Case SelectionKey.Trim.ToLower
                Case "pp"
                    ppids = myContext.SQL.ParamValue("@ppcsv", Params)
                    dated = myContext.SQL.ParamValue("@dated", Params)
                    sql = "select  PayPeriodID,salcalcon,isfinal, sdate, edate, PayPeriodName from PayPeriod where isfinal=0 and Payperiodid not in (" & ppids & ") and edate > '" & Format(dated, "yyyy-MMM-dd") & "' order by PayPeriodID desc "
                    Model.MainGrid.QuickConf(sql, True, "1-1-1", True, "PayPeriod")

                Case "in"
                    ppids = myContext.SQL.ParamValue("@ppcsv", Params)
                    sql = "select  PayPeriodID,wotcalcon,isfinalwot, sdate, edate, PayPeriodName from hrpListPayPeriod() where isfinalwot=0 and Payperiodid not in (" & ppids & ") and sdate >= hrstartdate order by PayPeriodID desc "
                    Model.MainGrid.QuickConf(sql, True, "1-1-1", True, "PayPeriod")

                Case "bs"
                    bmids = myContext.SQL.ParamValue("@bmcsv", Params)
                    sql = "select BonusMasterID, BonusCalcOn, BonusPaidOn, Descrip from BonusMaster where BonusCalcOn is not null and BonusPaidOn is null and " &
                          "BonusMasterID  not in (" & bmids & ")"
                    Model.MainGrid.QuickConf(sql, True, "1-1-1", True, "Bonus Master")
            End Select
        End If
        Return Model
    End Function
End Class
