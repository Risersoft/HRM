Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmAdvanceDepModel
    Inherits clsFormDataModel
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("PSAdv")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String, depid As Integer, r As DataRow, cont As Boolean = False

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            Me.vBag = myContext.Data.VarBag(strXML)
            depid = myUtils.cValTN(Me.vBag("DepID"))
            If depid > 0 Then
                Dim CompanyID As Integer = myContext.CommonData.GetCompanyIDFromDepHR(depid)
                Dim oMasterData As New clsMasterDataHRP(myContext)
                r = oMasterData.PPRow(CompanyID, Now)
                If Not r Is Nothing Then prepIDX = r("payperiodid")

                If myUtils.cValTN(prepIDX) > 0 Then
                    sql = "select *, '' as DepName from hrpListPayPeriod() where PayPeriodID = " & prepIDX
                    Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

                    sql = "select PaySlipAdvID, depid, PayPeriodID, EmployeeID, AdvAttAvgMin, AdvAttAvg, AdvLimitPercent, EmpCode, FullName, AdvReq " &
                          " from hrpListPaySlipAdv() where depid = " & depid & " And PayPeriodID = " & prepIDX
                    myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""FullName"" CAPTION=""Name""/><COL KEY=""AdvReq"" CAPTION=""Requirement""/>"
                    myView.MainGrid.QuickConf(sql, True, "1-2-2")
                    str1 = "<BAND INDEX = ""0"" TABLE = ""PayslipAdv"" IDFIELD=""PayslipAdvID""><COL KEY =""AdvReq""/></BAND>"
                    myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

                    Dim objPayP As New clsPayPeriodBase(myContext)
                    Dim oRet As clsProcOutput = objPayP.CheckAdvanceDayLimit(r, depid)
                    If Not oRet.Success Then Me.AddError("PayperiodID", oRet.Message)
                    myRow("DepName") = oRet.Description

                    If myUtils.cBoolTN(myRow.Row("isfinal")) Then Me.AddError("PayperiodID", "This payperiod has been finalized")
                End If
                Me.FormPrepared = (Me.ErrorList.Count = 0)
                If Me.ErrorList.Count = 0 Then Me.FormPrepared = True

            End If
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        myView.MainGrid.CheckValid("", "advance<>0", "", "<CHECK COND=""last3mnthattavg&gt;=80 and advattavg&gt;=80"" MSG=""Attendance average is less than 80%""/><CHECK COND=""Advance&gt;=0 and Advance&lt;=Limit"" MSG=""Advance falls outside limits""/>")
        myView.MainGrid.CheckValid("", "advance<>0", "", "<CHECK COND=""AdvAttAvg&gt;=AdvAttAvgMin"" MSG=""Attendance average is less than minimum required""/>")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim AdvanceDescrip As String = " Advance for Department: " & myUtils.cStrTN(myRow("DepName")) & " for Month: " & ("PayPeriodName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "PayPeriodID", frmIDX)
                Me.myView.MainGrid.SaveChanges()
                frmMode = EnumfrmMode.acEditM

                myContext.Provider.dbConn.CommitTransaction(AdvanceDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(AdvanceDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function


End Class
