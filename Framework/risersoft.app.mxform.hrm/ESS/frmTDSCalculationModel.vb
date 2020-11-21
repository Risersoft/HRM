Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.dal

<DataContract>
Public Class frmTDSCalculationModel
    Inherits clsFormDataModel

    Dim sql As String

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Item")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        Dim vlst As New clsValueList
        vlst.Add("Chennai", "Chennai")
        vlst.Add("Delhi", "Delhi")
        vlst.Add("Kolkata", "Kolkata")
        vlst.Add("Mumbai", "Mumbai")
        vlst.Add("Other", "Other")
        Me.ValueLists.Add("Place", vlst)
        Me.AddLookupField("Place", "Place")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1 As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "select * from TDSCalculation where TDSCalculationID = " & prepIDX
        Me.InitData(sql, "EmployeeID", oView, prepMode, prepIDX, strXML)

        dic.Add("Emp", "Select EmployeeID, fullname, Empcode from hrplistemp() where EmployeeID = " & myUtils.cValTN(myRow("EmployeeID")) & " order by fullname")
        Me.AddDataSet("Set", dic)

        sql = "Select Form12BBID, Dated from Form12BB where EmployeeID = " & myUtils.cValTN(myRow("EmployeeID")) & " order by Dated desc"
        Me.AddLookupField("Form12BBID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Form12BB").TableName)

        sql = "Select TDSCalculationItemID, TDSCalculationID, IsManual, sortindex, Code, Description, Input, Calc, Limit, Taken from TDSCalculationItem where TDSCalculationID = " & frmIDX & ""
        myView.MainGrid.QuickConf(sql, True, "1-1-1-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""TDSCalculationItem"" IDFIELD=""TDSCalculationItemID""><COL KEY=""sortindex, TDSCalculationID, Code, Description, Input, Calc, Limit, Taken, IsManual ""/></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function


    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.NullNot(myRow("Dated")) Then Me.AddError("Dated", "Select Valid Date")
        Dim dt1 = Me.dsCombo.Tables("form12bb")
        Dim rr() As DataRow = dt1.Select("dated<='" & Format(myRow("dated"), "dd-MMM-yyyy") & "'", "dated desc")
        If rr.Length > 0 Then
            myRow("form12bbid") = rr(0)("form12bbid")
        Else
            Me.AddError("Dated", "Form12BB Not available for this Date")
        End If
        Dim rFY As DataRow = myContext.CommonData.FinRow(myRow("Dated"))
        If rFY Is Nothing Then
            myRow("NumMonthsEarn") = 0
        Else
            Dim span = DateDiff(DateInterval.Month, rFY("stdate"), DateAdd(DateInterval.Day, 1, myRow("Dated")))
            myRow("NumMonthsEarn") = Math.Abs(span - myUtils.cValTN(myRow("NumMonthsZero")))
        End If
        myRow("NumMonthsRate") = 12 - myUtils.cValTN(myRow("NumMonthsEarn")) - myUtils.cValTN(myRow("NumMonthsZero"))
        Return Me.CanSave

    End Function

    Public Overrides Function VSave() As Boolean
        Dim oRet As clsProcOutput
        VSave = False

        If Me.Validate Then
            VSave = True
            For Each str1 As String In New String() {"totalincome", "totalliab", "tdspaidtotal", "tdspayrate"}
                Dim rInc = Me.FindCodeRow(myView.MainGrid.myDS.Tables(0), str1)
                If Not rInc Is Nothing Then
                    If myUtils.IsInList(str1, "tdspayrate") Then myRow(str1) = rInc("taken") / 12 Else myRow(str1) = rInc("taken")
                End If

            Next

            Dim Form12BBDescrip As String = " Dated:" & myRow("Dated")
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "Form12BBID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("TDSCalculationID")

                myView.MainGrid.SaveChanges(, "TDSCalculationID =" & frmIDX)
                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(Form12BBDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(Form12BBDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If

        Return VSave
    End Function
    Protected Friend Function FindCodeRow(dt As DataTable, code As String) As DataRow
        Dim rr() As DataRow = dt.Select("code='" & code & "'")
        If rr.Length > 0 Then Return rr(0)
    End Function
    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput, dic As New clsCollecString(Of String)
        Select Case dataKey
            Case "calculate"
                Dim sql As String = "select * from hrpListTDSCalculation() where TDSCalculationID = " & ID
                Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                Dim rCalc = dt.Rows(0)
                Dim strFilterES = "dated<='" & Format(rCalc("dated"), "dd-MMM-yyyy") & "'"
                Dim strFilterEmp = "EmployeeID = " & myUtils.cValTN(rCalc("EmployeeID"))

                Dim oMaster As New clsMasterDataHRP(myContext)
                Dim rFY = oMaster.oMasterFICO.rFinYear(rCalc("dated"))
                Dim rFY2 = oMaster.oMasterFICO.rFinYear(DateAdd(DateInterval.Year, -1, rCalc("dated")))
                Dim strFilterPS = myUtils.CombineWhere(False, "sdate>='" & Format(rFY("stdate"), "dd-MMM-yyyy") & "'", "edate<='" & Format(rCalc("dated"), "dd-MMM-yyyy") & "'")
                Dim     strFilterBonus = myUtils.CombineWhere(False, "sdate>='" & Format(rFY2("stdate"), "dd-MMM-yyyy") & "'", "edate<='" & Format(rFY2("endate"), "dd-MMM-yyyy") & "'")
                Dim strFilterLeave = myUtils.CombineWhere(False, "dated>='" & Format(rFY("stdate"), "dd-MMM-yyyy") & "'", "Dated<='" & Format(rFY("endate"), "dd-MMM-yyyy") & "'")

                dic.Add("EMP", "Select EmployeeID, fullname, Birthday from hrplistemp() where " & strFilterEmp & "")
                dic.Add("PARENT", "Select top 1 PersonID, BDate from PersFamily where PersonID = " & myUtils.cValTN(rCalc("PersonID")) & " and Relation in ('Mother','Father') order by BDate desc ")
                dic.Add("CALC", "Select TDSCalculationID, EmployeeID, Form12BBID, Dated, NumMonthsEarn, NumMonthsRate, RentPlace from TDSCalculation where TDSCalculationID = " & myUtils.cValTN(rCalc("TDSCalculationID")) & "")
                dic.Add("FORM12BBBASE", "Select form12bbid,Tablenum,Section,Amount from essListForm12BBitem() where form12bbid=" & myUtils.cValTN(rCalc("form12bbid")))
                dic.Add("BENEFIT", "Select EmployeeID, SalBenefitID, EEDate, BenefitMemNum from hrpListEmpSalBenefit() where " & strFilterEmp & " and BenefitCode = 'PF' and EEDate is not null ")
                dic.Add("ES", "Select top 1 EmployeeID, TotalBasic, TotalAllow from hrpListSalRateCalc() where " & strFilterEmp & " and " & strFilterES & " order by dated desc")
                dic.Add("ESCOMPBASE", "Select EmployeeID, ComponentCode, Amount from hrpListEmpSalRateCalcComp() where empsalratecalcid = (select top 1 empsalratecalcid from hrplistsalratecalc() where " & strFilterEmp & " and " & strFilterES & " order by dated desc)")
                dic.Add("PS", "Select  EmployeeID, sum(TotalBasicPS) as TotalBasic, sum(Totalallow) as TotalAllow, sum(TDS) as TotalTDS from hrplistPSBasic() where " & strFilterEmp & "and " & strFilterPS & " group by EmployeeID")
                dic.Add("PSCOMPBASE", "Select  EmployeeID, ComponentCode, sum(Amount) as Amount from hrpListPSComponent() where " & strFilterEmp & "and " & strFilterPS & " group by EmployeeID,  ComponentCode")
                dic.Add("BONUS", "Select EmployeeID, sum(isnull(TotAmountBonus,0)+isnull(TotAmountGrat,0)) as TotAmountBonus from hrpListBonusMasterEmp() where " & strFilterEmp & " and " & strFilterBonus & " group by EmployeeID")
                dic.Add("LEAVE", "Select EmployeeID, LeaveMasterID, isnull(amountnew,0)+isnull(amountprev,0) as amount from Leaveledger where " & strFilterEmp & " and " & strFilterLeave)
                Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
                Dim oTrans As New clsModelTrans(myContext)
                Dim dt1 As DataTable = oTrans.SimpleCross(ds.Tables("FORM12BBBASE"), "<SCROSS PIVOT=""section"" IDFIELD=""form12bbid"" AGGCOL=""amount"" />")
                myUtils.AddTable(ds, dt1, "FORM12BB")
                Dim dt2 As DataTable = oTrans.SimpleCross(ds.Tables("ESCOMPBASE"), "<SCROSS PIVOT=""componentcode"" IDFIELD=""employeeid"" AGGCOL=""amount"" />")
                myUtils.AddTable(ds, dt2, "ESCOMP")
                Dim dt3 As DataTable = oTrans.SimpleCross(ds.Tables("PSCOMPBASE"), "<SCROSS PIVOT=""componentcode"" IDFIELD=""employeeid"" AGGCOL=""amount"" />")
                myUtils.AddTable(ds, dt3, "PSCOMP")



                Dim importer As New clsSSGImport(myContext)
                importer.OpenStream(myAssy.GetStream(Me.GetType.Assembly.GetName.Name, "TDS_Calculation" & ".xlsx"))
                importer.LoadData("Sheet1", ds, EnumXLDefaultBehaviour.acLoadIfParamNotSet)
                Dim dtCalc = importer.GenerateTableFromRange("taxcalc")
                'importer.SaveAs("C:\tdscalc.xlsx")
                oRet.Data = myUtils.MakeDSfromTable(dtCalc, False)

        End Select
        Return oRet
    End Function

End Class
