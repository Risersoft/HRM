Imports System.IO
Imports Infragistics.Documents.Excel

Public Class clsHRPXL

    Public Function fncESIFile(ByRef oView As clsWinView) As Boolean

        Dim prepIdx As Integer = myUtils.cValTN(oView.ContextRow.CellValue("payperiodid"))

        GenerateESIFile(oView.mvwContext, prepIdx)

        Return True
    End Function
    Public Function getRecord(context As IProviderContext, PayPeriodID As Integer, BenefitCode As String) As DataTable
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@payperiodid", PayPeriodID, GetType(Integer), False))
        Params.Add(New clsSQLParam("@benefitcode", "'" & BenefitCode & "'", GetType(String), False))

        Dim oRet = context.Provider.GenerateParamsOutput(context.GetAppInfo, "frmPayPeriodModel", "", "benefit", Params).Result
        Dim dt1 As DataTable = oRet.Data.Tables(0)

        Return dt1
    End Function

    Public Function getRecord1(context As IProviderContext, PayPeriodID As Integer, BenefitCode As String) As DataTable
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@payperiodid", PayPeriodID, GetType(Integer), False))
        Params.Add(New clsSQLParam("@benefitcode", "'" & BenefitCode & "'", GetType(String), False))

        Dim oRet = context.Provider.GenerateParamsOutput(context.GetAppInfo, "frmPayPeriodModel", "", "left", Params).Result
        Dim dt2 As DataTable = oRet.Data.Tables(0)

        Return dt2
    End Function

    Public Sub GenerateESIFile(context As IProviderContext, ByVal PayPeriodID As Integer)

        Dim dt1 As DataTable = getRecord(context, PayPeriodID, "ESI")

        If dt1.Rows.Count > 0 Then

            dt1.Columns.Add("esinumber", GetType(Int64))
            For Each r1 As DataRow In dt1.Select("BenefitCode = 'ESI'")
                r1("esinumber") = myUtils.cValTN(r1("BenefitMemNum"))
            Next

            Dim strFile1 As String = "MC_Template1.xls"
            Dim oXLWB1 = Me.WorkBookFromFile(context, strFile1)
            Dim oXLSht1 = oXLWB1.Worksheets(0)
            Dim i As Integer = 1
            For Each r1 As DataRow In dt1.Select("", "esinumber")

                oXLSht1.Rows(i).Cells(0).Value = r1("BenefitMemNum")
                oXLSht1.Rows(i).Cells(1).Value = r1("fullname")
                oXLSht1.Rows(i).Cells(2).Value = myUtils.cValTN(r1("ewday"))
                oXLSht1.Rows(i).Cells(3).Value = myUtils.cValTN(r1("TotalBasicPS")) + myUtils.cValTN(r1("TotalAllow"))
                If (Not (myUtils.NullNot(r1("leavedate")))) AndAlso r1("leavedate") >= r1("sdate") AndAlso r1("leavedate") <= r1("edate") Then oXLSht1.Rows(i).Cells(5).Value = Format(r1("leavedate"), "dd-MM-yyyy")
                i = i + 1

            Next

            Dim strFile2 As String = "ESI.xls"
            Dim oXLWB2 = Me.WorkBookFromFile(context, strFile2)
            Dim oXLSht2 = oXLWB2.Worksheets(0)
            i = 1
            For Each r1 As DataRow In dt1.Select("", "esinumber")
                If r1("BenefitCode") = "ESI" Then
                    oXLSht2.Rows(i).Cells(0).Value = r1("BenefitMemNum")
                    oXLSht2.Rows(i).Cells(1).Value = r1("fullname")
                    If (Not (myUtils.NullNot(r1("joindate")))) Then oXLSht2.Rows(i).Cells(2).Value = Format(r1("joindate"), "dd-MM-yyyy")
                    If (Not (myUtils.NullNot(r1("birthday")))) Then oXLSht2.Rows(i).Cells(3).Value = Format(r1("birthday"), "dd-MM-yyyy")
                    oXLSht2.Rows(i).Cells(4).Value = Left(myUtils.cStrTN(r1("sex")), 1)
                    i = i + 1
                End If
            Next

            oXLWB1.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & strFile1)
            oXLWB2.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & strFile2)
        End If
    End Sub

    Public Function fncPFFile(ByRef oView As clsWinView) As Boolean
        Dim prepIdx As Integer = oView.ContextRow.CellValue("payperiodid")
        GeneratePFFile(oView.mvwContext, prepIdx)
        Return True
    End Function

    Public Sub GeneratePFFileOld(PayPeriodID As Integer)
        Dim dt1 As DataTable = getRecord(myWinApp.Controller, PayPeriodID, "PF")
        If dt1.Rows.Count > 0 Then
            dt1.Columns.Add("pfnumber", GetType(Int64))
            For Each r1 As DataRow In dt1.Select("BenefitCode = 'PF'")
                r1("pfnumber") = myUtils.cValTN(r1("BenefitMemNum"))
            Next

            Dim strFile1 As String = "ECR_Template.xls"
            Dim oXLWB1 = Me.WorkBookFromFile(myWinApp.Controller, strFile1)
            Dim oXLSht1 = oXLWB1.Worksheets(0)
            Dim i As Integer = 1
            For Each r1 As DataRow In dt1.Select("pfnumber>0", "pfnumber")

                oXLSht1.Rows(i).Cells(0).Value = r1("BenefitMemNum")
                    oXLSht1.Rows(i).Cells(1).Value = r1("fullname")
                    oXLSht1.Rows(i).Cells(2).Value = r1("BenefitEarn")
                    oXLSht1.Rows(i).Cells(3).Value = r1("BenefitEarn")
                    oXLSht1.Rows(i).Cells(4).Value = r1("AmountEE")
                    oXLSht1.Rows(i).Cells(5).Value = r1("AmountEE")
                    oXLSht1.Rows(i).Cells(6).Value = r1("AmountER1")
                    oXLSht1.Rows(i).Cells(7).Value = r1("AmountER1")
                    oXLSht1.Rows(i).Cells(8).Value = r1("AmountEE") - r1("AmountER1")
                    oXLSht1.Rows(i).Cells(9).Value = r1("AmountEE") - r1("AmountER1")

                    For j As Integer = 10 To 15
                        oXLSht1.Rows(i).Cells(j).Value = 0
                    Next

                    Debug.WriteLine(r1("fullname"))
                    If Not IsDBNull(r1("EEDate")) Then
                        If r1("EEDate") >= r1("sdate") AndAlso r1("EEDate") <= r1("edate") Then
                            'joined in this month
                            oXLSht1.Rows(i).Cells(16).Value = r1("careof")
                            oXLSht1.Rows(i).Cells(17).Value = r1("relationship")
                            oXLSht1.Rows(i).Cells(18).Value = r1("birthday")

                            If myUtils.cBoolTN(r1("isfemale")) Then oXLSht1.Rows(i).Cells(19).Value = "F" Else oXLSht1.Rows(i).Cells(19).Value = "M"
                            oXLSht1.Rows(i).Cells(20).Value = r1("EEDate")
                            oXLSht1.Rows(i).Cells(21).Value = r1("EEDate")
                        End If
                    End If

                    If Not (myUtils.NullNot(r1("leavedate"))) Then
                        If r1("leavedate") >= r1("sdate") AndAlso r1("leavedate") <= r1("edate") Then
                        'left in this month
                        oXLSht1.Rows(i).Cells(22).Value = Format(r1("leavedate"), "dd/MM/yyyy")
                        oXLSht1.Rows(i).Cells(23).Value = Format(r1("leavedate"), "dd/MM/yyyy")
                        oXLSht1.Rows(i).Cells(24).Value = r1("LeftReasonCode")
                        End If
                    End If
                    oXLSht1.Rows(i).Cells(25).Value = "l@astcolumn12345"
                    i = i + 1

            Next

            oXLWB1.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & strFile1)

            Dim strCSV As String = CSVFromXLSht(oXLSht1, dt1.Rows.Count, 25)
            Dim strFile2 As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFile1) & ".txt"
            My.Computer.FileSystem.WriteAllText(strFile2, strCSV, False)
            Dim str2 As String = My.Computer.FileSystem.ReadAllText(strFile2).Replace(",l@astcolumn12345", "").Replace(",", "#~#")
            My.Computer.FileSystem.WriteAllText(strFile2, str2, False, System.Text.Encoding.ASCII)
        End If

    End Sub
    Public Sub GeneratePFFile(context As IProviderContext, PayPeriodID As Integer)

        Dim dt1 As DataTable = getRecord(context, PayPeriodID, "PF")
        If dt1.Rows.Count > 0 Then
            dt1.Columns.Add("pfnumber", GetType(Int64))
            For Each r1 As DataRow In dt1.Select("BenefitCode = 'PF'")
                r1("pfnumber") = myUtils.cValTN(r1("BenefitMemNum"))
            Next

            Dim strFile1 As String = "ECR_Template_New.xls"
            Dim oXLWB1 = Me.WorkBookFromFile(context, strFile1)
            Dim oXLSht1 = oXLWB1.Worksheets(0)
            Dim i As Integer = 1
            For Each r1 As DataRow In dt1.Select("pfnumber>0", "pfnumber")

                oXLSht1.Rows(i).Cells(0).Value = r1("BenefitMemNum")
                    oXLSht1.Rows(i).Cells(1).Value = r1("fullname")
                    oXLSht1.Rows(i).Cells(2).Value = r1("totalbasices")
                    oXLSht1.Rows(i).Cells(3).Value = r1("BenefitEarn")
                    oXLSht1.Rows(i).Cells(4).Value = r1("BenefitEarn")
                    oXLSht1.Rows(i).Cells(5).Value = r1("BenefitEarn")
                    oXLSht1.Rows(i).Cells(6).Value = r1("AmountEE")
                    oXLSht1.Rows(i).Cells(7).Value = r1("AmountER2")
                    oXLSht1.Rows(i).Cells(8).Value = r1("AmountER1")
                    oXLSht1.Rows(i).Cells(9).Value = r1("Absent")

                    For j As Integer = 10 To 10
                        oXLSht1.Rows(i).Cells(j).Value = 0
                    Next

                    Debug.WriteLine(r1("fullname"))
                    oXLSht1.Rows(i).Cells(11).Value = "l@astcolumn12345"
                    i = i + 1

            Next

            oXLWB1.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & strFile1)

            Dim strCSV As String = CSVFromXLSht(oXLSht1, dt1.Rows.Count, 11)
            Dim strFile2 As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFile1) & ".txt"
            My.Computer.FileSystem.WriteAllText(strFile2, strCSV, False)
            Dim str2 As String = My.Computer.FileSystem.ReadAllText(strFile2).Replace(",l@astcolumn12345", "").Replace(",", "#~#")
            My.Computer.FileSystem.WriteAllText(strFile2, str2, False, System.Text.Encoding.ASCII)
        End If

    End Sub
    Public Function fncPFFileInfo(ByRef oView As clsWinView) As Boolean
        Dim prepIdx As Integer = oView.ContextRow.CellValue("payperiodid")

        GeneratePFFileInfo(oView.mvwContext, prepIdx)
        Return True
    End Function
    Protected Friend Function WorkBookFromFile(context As IProviderContext, filename As String) As Workbook
        Dim path As String = System.IO.Path.Combine(context.App.AppPath, "PayTemplates.Zip")
        Dim s As Stream = myZipFile.ExtractZipFile(path, filename)
        Dim oXLWB1 = Workbook.Load(s)
        Return oXLWB1
    End Function
    Public Sub GeneratePFFileInfo(context As IProviderContext, payperiodID As Integer)

        Dim dt1 As DataTable = getRecord(context, payperiodID, "PF")

        If dt1.Rows.Count > 0 Then
            dt1.Columns.Add("pfnumber", GetType(Int64))
            For Each r1 As DataRow In dt1.Select("BenefitCode = 'PF'")
                r1("pfnumber") = myUtils.cValTN(r1("BenefitMemNum"))
            Next

            Dim strFile1 As String = "ECR_Info_Template.xls"
            Dim oXLWB1 = Me.WorkBookFromFile(context, strFile1)
            Dim oXLSht1 = oXLWB1.Worksheets(0)
            Dim i As Integer = 1, CellPhoneNumber As Integer

            For Each r1 As DataRow In dt1.Select("pfnumber>0", "pfnumber")

                oXLSht1.Rows(i).Cells(0).Value = r1("BenefitMemNum")
                oXLSht1.Rows(i).Cells(1).Value = r1("fullname")
                    oXLSht1.Rows(i).Cells(2).Value = "N"

                    If myUtils.cStrTN(r1("cellnum")).Trim.Length >= 10 Then CellPhoneNumber = myUtils.cValTN(Right(r1("cellnum"), 10)) Else CellPhoneNumber = 0

                    If CellPhoneNumber > 0 Then oXLSht1.Rows(i).Cells(3).Value = CellPhoneNumber Else oXLSht1.Rows(i).Cells(3).Value = ""
                    oXLSht1.Rows(i).Cells(4).Value = myUtils.cStrTN(r1("email"))

                    Debug.WriteLine(r1("fullname"))
                    oXLSht1.Rows(i).Cells(5).Value = r1("careof")
                    oXLSht1.Rows(i).Cells(6).Value = r1("relationship")
                    oXLSht1.Rows(i).Cells(7).Value = r1("birthday")

                    If myUtils.cBoolTN(r1("isfemale")) Then oXLSht1.Rows(i).Cells(8).Value = "F" Else oXLSht1.Rows(i).Cells(8).Value = "M"
                    oXLSht1.Rows(i).Cells(9).Value = r1("EEDate")
                    oXLSht1.Rows(i).Cells(10).Value = r1("EEDate")

                    If Not (myUtils.NullNot(r1("leavedate"))) Then
                        If r1("leavedate") >= r1("sdate") AndAlso r1("leavedate") <= r1("edate") Then
                            'left in this month
                            oXLSht1.Rows(i).Cells(11).Value = Format(r1("leavedate"), "dd/MM/yyyy")
                            oXLSht1.Rows(i).Cells(12).Value = Format(r1("leavedate"), "dd/MM/yyyy")
                            oXLSht1.Rows(i).Cells(13).Value = myUtils.cStrTN(r1("LeftReasonCode"))
                        End If
                    End If
                    oXLSht1.Rows(i).Cells(14).Value = "l@astcolumn12345"
                    i = i + 1

            Next
            oXLWB1.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & strFile1)

            Dim strCSV As String = CSVFromXLSht(oXLSht1, dt1.Rows.Count, 14)
            Dim strFile2 As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFile1) & ".txt"
            My.Computer.FileSystem.WriteAllText(strFile2, strCSV, False)
            Dim str2 As String = My.Computer.FileSystem.ReadAllText(strFile2).Replace(",l@astcolumn12345", "").Replace(",", "#~#")
            My.Computer.FileSystem.WriteAllText(strFile2, str2, False, System.Text.Encoding.ASCII)

        End If
    End Sub

    Public Function fncPFFileLeft(ByRef oView As clsWinView) As Boolean
        Dim prepIdx As Integer = oView.ContextRow.CellValue("payperiodid")
        GeneratePFFileLeft(oView.mvwContext, prepIdx)
        Return True
    End Function

    Public Sub GeneratePFFileLeft(context As IProviderContext, PayPeriodID As Integer)

        Dim dt1 As DataTable = getRecord1(context, PayPeriodID, "PF")
        If dt1.Rows.Count > 0 Then
            dt1.Columns.Add("pfnumber", GetType(Int64))
            For Each r1 As DataRow In dt1.Select("BenefitCode = 'PF'")
                r1("pfnumber") = myUtils.cValTN(r1("BenefitMemNum"))
            Next

            Dim strFile1 As String = "ECR_Template_Left.xls"
            Dim oXLWB1 = Me.WorkBookFromFile(context, strFile1)
            Dim oXLSht1 = oXLWB1.Worksheets(0)
            Dim i As Integer = 1
            For Each r1 As DataRow In dt1.Select("pfnumber>0", "pfnumber")

                oXLSht1.Rows(i).Cells(0).Value = r1("BenefitMemNum")
                oXLSht1.Rows(i).Cells(1).Value = Format(r1("leavedate"), "dd/MM/yyyy").Replace("-", "/").Replace(".", "/")
                oXLSht1.Rows(i).Cells(2).Value = myUtils.cStrTN(r1("LeftReasonCode"))

                Debug.WriteLine(r1("BenefitMemNum"))
                oXLSht1.Rows(i).Cells(3).Value = "l@astcolumn12345"
                i = i + 1

            Next

            oXLWB1.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & strFile1)

            Dim strCSV As String = CSVFromXLSht(oXLSht1, dt1.Rows.Count, 3)
            Dim strFile2 As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFile1) & ".txt"
            My.Computer.FileSystem.WriteAllText(strFile2, strCSV, False)
            Dim str2 As String = My.Computer.FileSystem.ReadAllText(strFile2).Replace(",l@astcolumn12345", "").Replace(",", "#~#")
            My.Computer.FileSystem.WriteAllText(strFile2, str2, False, System.Text.Encoding.ASCII)
        End If

    End Sub

    Public Function CSVFromXLSht(oXLSht As Worksheet, LastRow As Integer, LastColumn As Integer) As String
        Dim str1 As String = ""
        For i = 1 To LastRow
            Dim str3 As String = ""
            For j As Integer = 0 To LastColumn
                Dim strValue As String = myUtils.cStrTN(oXLSht.Rows(i).Cells(j).Value)
                If IsNumeric(strValue) Then strValue = Format(myUtils.cValTN(strValue), "0")
                str3 = str3 & IIf(str3 = "", "", ",") & strValue
            Next
            str1 = str1 & str3 & vbCrLf
        Next
        Return str1
    End Function

End Class
