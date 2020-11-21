Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmAdvanceModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("AdvTDS")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, strWhere As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            sql = "select * from hrpListPayPeriod() where PayPeriodID = " & prepIDX & ""
            Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

            strWhere = myUtils.CombineWhere(True, "payperiodid=" & frmIDX, myFuncs.WValue(pView, "id2casual,dep,isworker"))
            sql = "SELECT EmployeeID, DepID, PayPeriodID, PaySlipID, Limit, AdvAttAvgMin, IsFinal, EmpCode, FullName, DepName, Last3MnthAttAvg, " &
                  "AdvAttAvg, AdvReq, Advance, PaymentThruCodeAdv from hrpListPSAdvTDS()" & strWhere & " order by EmpCode "
            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""DepName"" CAPTION=""Department""/><COL KEY=""last3mnthattavg"" CAPTION=""Last 3 Months Att Avg""/><COL KEY=""advattavg"" CAPTION=""15 Day Att Avg""/><COL KEY=""AdvReq"" CAPTION=""Advance Requested""/>"
            myView.MainGrid.QuickConf(sql, True, "1-2-1-1.25-1.25-1.5-1-1.5", True)
            myView.MainGrid.PrepEdit("<BAND INDEX=""0"" TABLE=""payslip"" IDFIELD=""payslipid""><COL KEY=""Advance""/><COL KEY=""PaymentThruCodeAdv"" caption = ""Payment Thru""" & myFuncs.strGridConfEnd("emp", "PaymentThru", "", 2) & "</BAND>", EnumEditType.acCommandAndEdit)

            Dim dic As New clsCollecString(Of String)
            dic.Add("PSAdv", "select * from PayslipAdv where payperiodID = " & frmIDX)
            Me.AddDataSet("PSAdv", dic)

            If Not IsDBNull(myRow("SalCalcOn")) Then Me.AddError("payperiodid", "Salary Already Calculated")
            If myUtils.cBoolTN(myRow.Row("isfinal")) Then Me.AddError("payperiodid", "This payperiod has been finalized")

            Me.FormPrepared = (Me.ErrorList.Count = 0)
            If Me.ErrorList.Count = 0 Then Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function
    Public Overrides Function Validate() As Boolean
        Me.InitError()
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            Dim AdvanceDescrip As String = "Advance for Month: " & myRow("PayPeriodName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "PayPeriodID", frmIDX)
                myView.MainGrid.SaveChanges()

                Dim oProc As New clsPayPeriodBase(myContext)
                Dim oRet = oProc.GenerateAdvanceVouch(frmIDX)
                myContext.Provider.dbConn.CommitTransaction(AdvanceDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(AdvanceDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If

        Return VSave
    End Function

End Class
