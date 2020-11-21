Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmSalBenefitCompModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("SalBenRate")
    End Sub
    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim Sql As String = "select CompanyID, CompName from company"
        Me.AddLookupField("CompanyID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Company").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String, objSalBenComp As New clsSalBenefitCompBase(myContext)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "select * from SalBenefitComp  where SalBenefitCompID = " & prepIDX & " "
        Me.InitData(sql, "CompanyID", oView, prepMode, prepIDX, strXML)

        sql = "select SalBenefitID, BenefitName from SalBenefit where  (salbenefitid=" & myUtils.cValTN(myRow("salbenefitid")) & ") or (SalBenefitID  not in (select SalBenefitID from SalBenefitComp where companyid = " & myUtils.cValTN(myRow.Row("CompanyID")) & "))"
        Me.AddLookupField("SalBenefitID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Benefits").TableName)

        sql = "select SalBenefitRateID, RateMasterID, SalBenefitID, Dated, perEE, perER1, perER2, Limit, perAdminAmount1, perAdminAmount2, perAdminAmount3, RoundingType " &
           "from hrpListSalBenefitRate() where CompanyID = " & myUtils.cValTN(myRow.Row("CompanyID")) & " and SalBenefitID = " & myUtils.cValTN(myRow.Row("SalBenefitID"))
        myView.MainGrid.QuickConf(sql, True, "1.25-1-1-1-1-1.5-1.5-1.5-1", True, "Salary Benefits")
        str1 = "<BAND INDEX = ""0"" TABLE = ""SalBenefitRate"" IDFIELD=""SalBenefitRateID""><COL KEY =""SalBenefitRateID, RateMasterID, SalBenefitID, perEE, perER1, perER2, Limit, perAdminAmount1, perAdminAmount2, perAdminAmount3, RoundingType ""/> </BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        If frmMode = EnumfrmMode.acEditM Then
            Me.ModelParams.Add(New clsSQLParam("@IsFinal", objSalBenComp.IsFinalSB(myRow.Row), GetType(Boolean), False))
        Else
            If Me.dsCombo.Tables("Benefits").Rows.Count = 0 Then Me.AddError("Dated", "No Benefit to add components")
        End If
        Me.FormPrepared = (Me.ErrorList.Count = 0)
        If Me.ErrorList.Count = 0 Then Me.FormPrepared = True

        Return Me.FormPrepared
    End Function
    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If Me.SelectedRow("SalBenefitID") Is Nothing Then Me.AddError("SalBenefitID", "Select Benefit")
        If myUtils.cStrTN(myRow("CompCode")).Trim.Length = 0 Then Me.AddError("CompCode", "Enter Component Code")
        If myUtils.NullNot(myRow("StartDate")) Then Me.AddError("StartDate", "Enter Start Date")

        Return Me.CanSave
    End Function

    Public Overrides Function GenerateDataOutput(dataKey As String, ds As DataSet, frmIDX As Integer) As clsProcOutput
        Dim oRet As clsProcOutput = Nothing, objSalBenComp As New clsSalBenefitCompBase(myContext)
        Dim rSBC As DataRow = ds.Tables("SalBenComp").Rows(0)
        Dim SalBenefitCompID As Integer = myUtils.cValTN(rSBC("SalBenefitCompID"))
        Select Case dataKey
            Case "checksave"
                oRet = objSalBenComp.CheckSave(rSBC, ds.Tables(0))
            Case "generate"
                oRet = objSalBenComp.GenerateSalBenefitRate(rSBC, ds.Tables(0))
                oRet.Data = ds
        End Select
        Return oRet
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objProc As clsProcOutput, objSalBenComp As New clsSalBenefitCompBase(myContext)
        VSave = False

        If Me.Validate Then
            objProc = objSalBenComp.TrySave(myRow.Row, myView.MainGrid.myDS.Tables(0))
            If objProc.Success Then
                frmIDX = myRow("SalBenefitCompID")
                frmMode = EnumfrmMode.acEditM
                VSave = True
            Else
                Me.AddError("", objProc.Message)
            End If
        End If

        Return VSave
    End Function

End Class
