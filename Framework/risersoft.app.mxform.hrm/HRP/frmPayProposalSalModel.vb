Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmPayProposalSalModel
    Inherits clsFormDataModel
    Dim myView1, myView2 As clsViewModel, sql As String
    Protected Overrides Sub InitViews()
        myView1 = Me.GetViewModel("OldSMID")
        myView2 = Me.GetViewModel("NewSMID")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            Me.InitData("", "employeeid,payproposalid,oldsmid,oldrmid,newsmid,newrmid,onlyrm", oView, prepMode, prepIDX, strXML)

            If myUtils.NullNot(Me.vBag("oldsmid")) Then
                Me.AddError("", Nothing, 0, "", "", "No Employee's Salary could be found to compare from")
            Else
                sql = "select EmpSalaryID, Dated, TotalBasic, TotalAllow, TotalPay, TakeHome, Bonus, LeaveNCash, Gratuity, CTC from EmpSalRateCalc where empsalaryid = " & myUtils.cValTN(Me.vBag("oldsmid")) & "  and RateMasterID  = " & myUtils.cValTN(Me.vBag("oldrmid")) & " "
                myView1.MainGrid.MainConf("invertedview") = True
                myView1.MainGrid.QuickConf(sql, True, "1-1-1-1-1-1-1-1-1", True, "Reference Salary", True)

                myView2.MainGrid.BindGridData(GenerateData("empsalratecalc", myUtils.cValTN(Me.vBag("Newsmid")), myUtils.cValTN(Me.vBag("Newrmid"))), 0)
                myView2.MainGrid.MainConf("invertedview") = True
                myView2.MainGrid.QuickConf(sql, True, "1-1-1-1-1-1-1-1-1", True, "Proposed Salary", True)
                Me.FormPrepared = True
            End If

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
            VSave = True
        End If
        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Dim EmpSalaryID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@EmpSalaryID", Params))
            Dim RateMasterID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@RateMasterID", Params))
            Select Case dataKey.Trim.ToLower
                Case "empsalratecalc"
                    oRet.Data = GenerateData("empsalratecalc", EmpSalaryID, RateMasterID)
            End Select
        End If
        Return oRet
    End Function

    Protected Overloads Function GenerateData(DataKey As String, EmpSalaryID As Integer, RateMasterID As Integer) As DataSet
        Dim oRet As New clsProcOutput, ds As DataSet
        Select Case DataKey.Trim.ToLower
            Case "empsalratecalc"
                sql = "select EmpSalaryID, Dated, TotalBasic, TotalAllow, TotalPay, TakeHome, Bonus, LeaveNCash, Gratuity, CTC from EmpSalRateCalc where empsalaryid = " & myUtils.cValTN(EmpSalaryID) & "  and RateMasterID  = " & myUtils.cValTN(RateMasterID) & " "
                ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
                oRet.Data = ds
        End Select
        Return oRet.Data
    End Function

End Class
