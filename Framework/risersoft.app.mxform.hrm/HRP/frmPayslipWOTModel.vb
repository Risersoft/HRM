Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmPayslipWOTModel
    Inherits clsFormDataModel
    Dim sql As String
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("PayslipWOT")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1, strWhere As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then

            sql = "select * from hrplistpayperiod() where payperiodid=" & prepIDX
            Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

            If myUtils.cBoolTN(myRow.Row("isfinalWOT")) Then
                Me.AddError("", Nothing, 0, "", "", "This payperiod has been finalized")
            End If

            strWhere = myUtils.CombineWhere(True, "payperiodid=" & frmIDX, myFuncs.WValue(pView, "id2casual,dep,isworker"),
                                            "employeeid in (select employeeid from payslipwot where payperiodid = " & frmIDX & ")")
            sql = "SELECT payslipid, EmployeeID, DepID, EmpCode, FullName, DepName, EWDay, PaymentThruCodeInc, PersonalExpenseInc " &
            "from hrpListIncentive() " & strWhere & " order by EmpCode "
            myView.MainGrid.QuickConf(sql, True, ".5-1.5-1-.5-1-1", True)
            str1 = "<BAND INDEX=""0"" TABLE=""payslip"" IDFIELD=""payslipid"" ><COL KEY=""PersonalExpenseInc"" CAPTION=""PersonalExpense""/><COL KEY=""DEPID"" LOOKUPSQL=""select depid,depname from deps order by depname"" Caption=""Dep""/><COL KEY=""PaymentThruCodeInc"" caption = ""Payment Thru""" & myFuncs.strGridConfEnd("emp", "PaymentThru", "", 2) & "</BAND>"
            myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

            Me.FormPrepared = (Me.ErrorList.Count = 0)
            If Me.ErrorList.Count = 0 Then Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        myView.MainGrid.CheckValid("paymentthrucodeinc")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objPayPeriod As New clsPayPeriodBase(myContext), objProc As clsProcOutput
        VSave = False

        If Me.Validate Then
            Dim PayslipDescrip As String = " Incentive Categorization For Month: " & myRow("PayperiodName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "PayPeriodID", frmIDX)
                Me.myView.MainGrid.SaveChanges()
                objProc = objPayPeriod.DirtyPayPeriodIncen(myRow("PayPeriodID"))
                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(PayslipDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(PayslipDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If

        Return VSave
    End Function

End Class