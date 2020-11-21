Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmPayProjectionModel
    Inherits clsFormDataModel

    Dim myViewProp As clsViewModel, objPayProp As New clsPayProposalBase(myContext), sql As String
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("ListEmp")
        myViewProp = Me.GetViewModel("PayProp")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        sql = "Select CompanyID, CompName from Company Order by CompName"
        Me.AddLookupField("CompanyID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Company").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim strWhere, strWhere1, str As String, ds As DataSet

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0

        sql = "select * from PayProjection where PayProjectionID = " & prepIDX & ""
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        Dim str1 As String = myFuncs.WValue(pView, "id2casual,dep,isworker")
        strWhere = myUtils.CombineWhere(True, "PayProjectionID=" & frmIDX, str1)

        sql = "select PayProjEmp.PayProjEmpID, PayProjEmp.PayProjectionID, PayProjEmp.EmployeeID, EmpCode, FullName, TargetSal " &
              "from PayProjEmp inner join hrpListEmp() on PayProjEmp.EmployeeID = hrpListEmp.EmployeeID  " & strWhere & " order by EmpCode "
        myView.MainGrid.QuickConf(sql, True, "1-1-1", True)
        strWhere1 = myUtils.CombineWhere(True, str1, "onrolls=1")
        myContext.Data.ReverseTick(myView.MainGrid.myDS.Tables(0), "select employeeid, EmpCode, FullName from hrpListEmp()  " & strWhere1 & " order by empcode asc", "EmployeeID")
        str = "<BAND INDEX=""0"" TABLE=""PayProjEmp"" IDFIELD=""PayProjEmpID""><COL KEY=""PayProjectionID, EmployeeID, TargetSal""/><COL NOEDIT=""TRUE"" KEY=""PayProjEmpID"" /></BAND>"
        myView.MainGrid.PrepEdit(str, EnumEditType.acCommandAndEdit)

        ds = GenerateData("payprop", frmIDX)
        str = "<BAND INDEX=""0"" TABLE=""PayProposal"" IDFIELD=""PayProposalID""><COL KEY=""PayProposalID, PayProjectionID, PayProposalID, CompanyID, PropDate, SMEffDate, EnforceOn, RefPPID, UpdateLastPP, OnlyRM, PropRMID""/><COL NOEDIT=""TRUE"" KEY=""PayProposalID"" /></BAND>"
        myViewProp.MainGrid.MainConf("FORMATXML") = "<COL KEY=""PropDate"" CAPTION=""Proposed Date""/><COL KEY=""RefPPID"" CAPTION=""Refrence PayPeriod""/><COL KEY=""UpdateLastPP"" CAPTION=""Update Last PayPeriod""/><COL KEY=""OnlyRm"" CAPTION=""Only RateMaster""/><COL KEY=""PropRMID"" CAPTION=""Proposed RateMaster"" />"
        myViewProp.MainGrid.QuickConf(sql, True, "0.75-0.75-0.75-0.75-0.75-0.75-1", True, "Pay Proposal")
        myViewProp.MainGrid.PrepEdit(str, EnumEditType.acCommandAndEdit)
        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim PayDescrip As String = " Start Dt: " & myUtils.cDateTN(myRow("StartDate"), DateTime.MinValue) & ", Target Dt: " & myUtils.cDateTN(myRow("TargetDate"), DateTime.MinValue)
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "PayProjectionID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("PayProjectionID")

                If frmIDX > 0 Then
                    Me.myView.MainGrid.SaveChanges(, "PayProjectionID= " & frmIDX)
                    Me.myViewProp.MainGrid.SaveChanges(, "PayProjectionID= " & frmIDX)
                End If

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(PayDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(PayDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim objProc As clsProcOutput = myContext.SQL.ValidateSQLParams(Me.ClientParams), ds As DataSet

        Select Case dataKey.Trim.ToLower
            Case "payprop"
                sql = "select PayProposalID, CompanyID, PayProjectionID, SDate, PropRMID, RefPPID, PropDate, SMEffDate, EnforceOn, " &
                    "RefPayPeriod, UpdateLastPP, OnlyRM, RMDescrip  from hrpListPayProposal() where  PayProposalID = " & ID
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)

                objProc = objPayProp.CheckDelete(ds.Tables(0).Rows(0))
        End Select
        Return objProc
    End Function
    Public Overrides Function GenerateParamsModel(vwState As clsViewState, SelectionKey As String, Params As List(Of clsSQLParam)) As clsViewModel
        Dim Model As New clsViewModel(vwState, myContext), ppids, bmids As String, dated As DateTime
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Select Case SelectionKey.Trim.ToLower
                Case "pp"
                    dated = myContext.SQL.ParamValue("@dated", Params)
                    sql = "select payperiodid,  isfinal, salcalcon, sdate, dbo.fnccalcstrdate(sdate,edate) as Descrip from payperiod where isnull(isfinal,0)=0 and sdate  > '" & Format(dated, "yyyy-MMM-dd") & "' order by sdate"
                    Model.MainGrid.QuickConf(sql, True, "1-3", True, "PayPeriod")
            End Select
        End If
        Return Model
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim objProc As New clsProcOutput, paypropid, ppid, payproj As Integer, dt As DataTable
        objProc = myContext.SQL.ValidateSQLParams(Params)
        If objProc.Success Then
            Select Case dataKey.Trim.ToLower
                Case "paypropen"
                    paypropid = myUtils.cValTN(myContext.SQL.ParamValue("@PayPropID", Params))
                    ppid = myUtils.cValTN(myContext.SQL.ParamValue("@PPID", Params))
                    objProc = objPayProp.Enforce(paypropid, ppid)
                Case "paypropunen"
                    paypropid = myUtils.cValTN(myContext.SQL.ParamValue("@PayPropID", Params))
                    objProc = objPayProp.UnEnforce(paypropid)

                Case "payprop"
                    paypropid = myContext.SQL.ParamValue("@PayPropID", Params)
                    payproj = myContext.SQL.ParamValue("@PayProjID", Params)
                    sql = "select PayProposalID, CompanyID, PayProjectionID, SDate, PropRMID, RefPPID, PropDate, SMEffDate, EnforceOn, " &
                      "RefPayPeriod, UpdateLastPP, OnlyRM, RMDescrip  from hrpListPayProposal() where  PayProposalID = " & paypropid
                    dt = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                    objProc = objPayProp.TryDelete(dt.Rows(0))

                    If objProc.Success = False Then
                        Me.AddError("StartDate", objProc.Message)
                    Else
                        objProc.Data = GenerateData(dataKey.Trim.ToLower, payproj)
                    End If

                Case "refresh"
                    payproj = myContext.SQL.ParamValue("@PayProjID", Params)
                    objProc.Data = GenerateData("refresh", payproj)
            End Select
        End If
        Return objProc
    End Function

    Protected Overrides Function GenerateData(DataKey As String, ID As String) As DataSet
        Dim objProc As New clsProcOutput, sql1 As String, ds As DataSet
        sql = "select PayProposalID, CompanyID, PayProjectionID, SDate, PropRMID, RefPPID, PropDate, SMEffDate, EnforceOn, " &
               "RefPayPeriod, UpdateLastPP, OnlyRM, RMDescrip  from hrpListPayProposal() where  PayProjectionID = " & ID
        ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
        objProc.Data = ds
        Return objProc.Data
    End Function
End Class
