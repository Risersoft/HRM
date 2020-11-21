Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmPayslipDataModel
    Inherits clsFormDataModel
    Dim sql As String
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("PSAdvTDS")
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

            If myUtils.cBoolTN(myRow.Row("isfinal")) Then
                Me.AddError("", Nothing, 0, "", "", "This payperiod has been finalized")
            ElseIf myUtils.NullNot(myRow.Row("salcalcon")) Then
                Me.AddError("", Nothing, 0, "", "", "The salary for this payperiod has not been prepared")
            End If

            strWhere = myUtils.CombineWhere(True, "payperiodid=" & frmIDX, myFuncs.WValue(pView, "id2casual,dep,isworker"))
            sql = "SELECT payslipid, ContractorID, EmployeeID, isfinal, EmpCode, FullName, DepID, DivisionID, CampusID, StatusNUM, iswage, isworker, Designation, TDS, ArrearMan, TDSCess1, ProfTax, PersonalExpense, PaymentThruCode  " &
            "from hrplistpsadvtds() " & strWhere & " order by EmpCode "
            myView.MainGrid.QuickConf(sql, True, "0.75-1.5-1-1.5-1-1-1-1-1-1-1-1-1-1-1", True)
            str1 = "<BAND INDEX=""0"" TABLE=""payslip"" IDFIELD=""payslipid"" ><COL KEY=""designation""/><COL KEY=""TDS""/><COL KEY=""TDSCess1"" Caption = ""TDS Cess""/><COL KEY=""ArrearMan""/><COL KEY=""ProfTax""/><COL KEY=""PersonalExpense""/><COL KEY=""DEPID"" LOOKUPSQL=""select depid,depname from deps order by depname"" Caption=""Dep""/><COL KEY=""DivisionID"" LOOKUPSQL=""select DivisionID, DivisionName from Division order by DivisionName"" Caption=""Division""/><COL KEY=""campusid"" LOOKUPSQL=""select campusid,dispname from campus order by campusid"" CAPTION=""Campus""/><COL KEY=""StatusNum"" LOOKUPSQL=""  Select statusnum, statustext from status  where statustype = 'EMP' order by statusnum"" CAPTION=""Status""/><COL KEY=""isworker"" VLIST=""False;Staff|True;Worker"" CAPTION=""WF Cat""/><COL KEY=""iswage"" VLIST=""False;Salary|True;Wage"" CAPTION=""Sal Cat""/><COL KEY=""PaymentThruCode"" caption = ""Payment Thru""" & myFuncs.strGridConfEnd("emp", "PaymentThru", "", 2) & "</BAND>"
            myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

            Me.FormPrepared = (Me.ErrorList.Count = 0)
            If Me.ErrorList.Count = 0 Then Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        myView.MainGrid.CheckValid("CampusID,DivisionID,iswage,paymentthrucode")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objPayPeriod As New clsPayPeriodBase(myContext), objProc As clsProcOutput
        VSave = False

        If Me.Validate Then
            Dim PayslipDescrip As String = " Payslip Data for the Month Of: " & myRow("PayperiodName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "PayPeriodID", frmIDX)
                Me.myView.MainGrid.SaveChanges()
                objProc = objPayPeriod.DirtyPayPeriodSal(myRow("PayPeriodID"))
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
