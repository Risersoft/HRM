Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports Geocoding.Google
Imports System.Text
Imports GoogleMapsApi.Entities.Geocoding.Request
Imports GoogleMapsApi
Imports GoogleMapsGeocoding
Imports risersoft.shared.portable.Model
Imports Newtonsoft.Json
Imports System.Configuration

<DataContract>
Public Class frmHRPersonModel
    Inherits clsFormDataModel

    Dim myVueEdu, myVueFam, myVueExp As clsViewModel
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("ListEmp")
        myVueEdu = Me.GetViewModel("Edu")
        myVueFam = Me.GetViewModel("Fam")
        myVueExp = Me.GetViewModel("Exp")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim lst As New List(Of String)
        lst.Add("None")
        lst.Add("X")
        lst.Add("XII")
        lst.Add("ITI")
        lst.Add("Diploma")
        lst.Add("BA /BSc /BCom")
        lst.Add("MA /MSc /MCom")
        lst.Add("BE / BTech")
        Me.ValueLists.Add("TopQual", myContext.SQL.VListFromList(lst))
        Me.AddLookupField("TopQual", "TopQual")

        Dim vlist As New clsValueList
        vlist.Add(True, "Female")
        vlist.Add(False, "Male")
        Me.ValueLists.Add("IsFemale", vlist)
        Me.AddLookupField("IsFemale", "IsFemale")

        Dim lst1 As New List(Of String)
        lst1.Add("Married")
        lst1.Add("Unmarried")
        lst1.Add("Widowed")
        lst1.Add("Divorced")
        lst1.Add("Separated")
        Me.ValueLists.Add("MarStatus", myContext.SQL.VListFromList(lst1))
        Me.AddLookupField("MarStatus", "MarStatus")

        Dim vlisttag As New clsValueList
        vlisttag.Add(1, "Normal")
        vlisttag.Add(3, "Casual")
        Me.ValueLists.Add("Tnvc", vlisttag)
        Me.AddLookupField("Nature", "Nature", "Tnvc")



        Dim vlistp As New clsValueList
        vlistp.Add(1, "1-Bank Transfer")
        vlistp.Add(2, "2-Cash")
        vlistp.Add(3, "3-Cheque")
        vlistp.Add(4, "4-Electronic Transfer")
        Me.ValueLists.Add("Mnvp", vlistp)
        Me.AddLookupField("Payment", "Payment", "Mnvp")




        Dim vliste As New clsValueList
        vliste.Add(1, "Salary")
        vliste.Add(3, "Wages")
        Me.ValueLists.Add("Mnvh", vliste)
        Me.AddLookupField("SalaryCategory", "SalaryCategory", "Mnvh")

        Dim vlisth As New clsValueList
        vlisth.Add(1, "Staff")
        vlisth.Add(3, "Worker")
        Me.ValueLists.Add("Bnvc", vlisth)
        Me.AddLookupField("WorkCategory", "WorkCategory", "Bnvc")




        Dim vlistlm As New clsValueList
        vlistlm.Add(1, "Temporary")
        vlistlm.Add(3, "Permanant")
        vlistlm.Add(1, "Badli")
        vlistlm.Add(3, "Probationer")
        vlistlm.Add(3, "Apprentince")
        Me.ValueLists.Add("LMnvp", vlistlm)
        Me.AddLookupField("Status", "Status", "LMnvp")

        Dim Sql As String = "select campusid, dispname, WODate, CompletedOn from mmlistCampus() order by dispname"
        Me.AddLookupField("campusid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "campus").TableName)

        Sql = "Select depid, depname, companyid from deps order by depname"
        Me.AddLookupField("depid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "dep").TableName)

        Sql = "select shiftid, shift from shift order by shift"
        Me.AddLookupField("shiftid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "shift").TableName)
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from persons where personid = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        myView.MainGrid.BindGridData(GenerateData("emp", frmIDX), 0)
        myView.MainGrid.QuickConf("", True, "3-2-2-2", True)
        str1 = "<BAND INDEX=""0"" TABLE=""Employees"" IDFIELD=""employeeid"" ><COL KEY=""personid,joindate,Campusid,ShiftId,EmpCode,DepId,iscasual""/></BAND> "
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        myVueEdu.MainGrid.QuickConf("Select perseduid,personid,Qualification,Institution,YearQual,Marks from persedu where personid=" & frmIDX, True, "2-2-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""persedu"" IDFIELD=""perseduid"" ><COL KEY=""Qualification,Institution,YearQual,Marks,personid""/></BAND> "
        myVueEdu.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        myVueFam.MainGrid.QuickConf("Select persFamilyid,personid,MemberName,Relation,BDate,Profession,Other from persFamily where personid=" & frmIDX, True, "2-1-1-2-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""persFamily"" IDFIELD=""persFamilyid"" ><COL KEY=""personid,MemberName,Relation,BDate,Profession,Other""/></BAND> "
        myVueFam.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        myVueExp.MainGrid.QuickConf("Select perspartyid,personid,EstabName,Designation,PeriodService,ExpInMonths,MonthlyPay,ReasonLeft from persparty where personid=" & frmIDX, True, "2.5-1.25-1.25-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""persparty"" IDFIELD=""perspartyid"" ><COL KEY=""personid,EstabName,Designation,PeriodService,ExpInMonths,MonthlyPay,ReasonLeft""/></BAND> "
        myVueExp.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        Dim ds As DataSet = myContext.CommonData.GetDatasetLocode(False).Copy
        Me.AddLookupField("PrCountry", myUtils.AddTable(Me.dsCombo, ds.Tables("CO"), "CO").TableName)
        Me.AddLookupField("PmCountry", "CO")
        Me.AddLookupField("PrState", myUtils.AddTable(Me.dsCombo, ds.Tables("SU"), "SU").TableName)
        Me.AddLookupField("PmState", "SU")

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean

        Me.InitError()
        If (myUtils.cStrTN(myRow("FirstName")).Trim.Length = 0) AndAlso (myUtils.cStrTN(myRow("MidName")).Trim.Length = 0) AndAlso (myUtils.cStrTN(myRow("LastName")).Trim.Length = 0) Then Me.AddError("LastName", "Enter the name")
        If Me.SelectedItem("IsFemale") Is Nothing Then Me.AddError("IsFemale", "Select Gender")
        'If Me.SelectedItem("MarStatus") Is Nothing Then Me.AddError("MarStatus", "Select Marital Status")
        myView.MainGrid.CheckValid("depid,campusid,joindate")
        If myUtils.cStrTN(myRow("prgeopoint")).Trim.Length > 0 AndAlso (Not GeoCoordinate.TryParse(myRow("prgeopoint"), Nothing)) Then Me.AddError("prgeopoint", "Unrecognized format")
        If myUtils.cStrTN(myRow("pmgeopoint")).Trim.Length > 0 AndAlso (Not GeoCoordinate.TryParse(myRow("pmgeopoint"), Nothing)) Then Me.AddError("pmgeopoint", "Unrecognized format")

        'If myUtils.NullNot(myRow("BirthDay")) Then Me.AddError("BirthDay", "Please Select BirthDay")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            For Each r As DataRow In myView.MainGrid.myDS.Tables(0).Select("iscasual=0 or onrolls=1")
                Dim sql As String = "select empcode,employeeid,iscasual,OnRolls from employees where personid <> " & myUtils.cValTN(myRow("personid"))
                Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                Dim rr2() As DataRow = dt.Select("empcode = '" & myUtils.cStrTN(r("empcode")) & "' and (iscasual=0 or onrolls=1)")
                If rr2.Length > 0 Then Me.AddError("", "Empcode already exists")
            Next
            If Me.CanSave Then
                Dim HRPersonDescrip As String = myUtils.cStrTN(myRow("FullName"))
                Try
                    myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "personid", frmIDX)
                    If Me.SelectedRow("PrCountry") Is Nothing Then myRow("prcountrycode") = "" Else myRow("prcountrycode") = Me.SelectedRow("PrCountry")("countrycode")
                    If Me.SelectedRow("PrState") Is Nothing Then myRow("prstatecode") = "" Else myRow("prstatecode") = Me.SelectedRow("PrState")("subdivisioncode")
                    If Me.SelectedRow("PmCountry") Is Nothing Then myRow("pmcountrycode") = "" Else myRow("pmcountrycode") = Me.SelectedRow("PmCountry")("countrycode")
                    If Me.SelectedRow("PmState") Is Nothing Then myRow("pmstatecode") = "" Else myRow("pmstatecode") = Me.SelectedRow("PmState")("subdivisioncode")
                    myRow("prmailingaddress") = myUtils.MakeCSV(vbCrLf, myUtils.cStrTN(myRow("praddress")), myUtils.MakeCSV(", ", myUtils.cStrTN(myRow("prcity")), myUtils.cStrTN(myRow("prstate"))), myUtils.MakeCSV(" - ", myUtils.cStrTN(myRow("prcountry")), myUtils.cStrTN(myRow("prpincode"))))
                    myRow("pmmailingaddress") = myUtils.MakeCSV(vbCrLf, myUtils.cStrTN(myRow("pmaddress")), myUtils.MakeCSV(", ", myUtils.cStrTN(myRow("pmcity")), myUtils.cStrTN(myRow("pmstate"))), myUtils.MakeCSV(" - ", myUtils.cStrTN(myRow("pmcountry")), myUtils.cStrTN(myRow("pmpincode"))))

                    myRow("otherexp") = myVueExp.MainGrid.GetColSum("expinmonths") / 12
                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                    frmIDX = myRow("personid")
                    If frmMode = EnumfrmMode.acAddM Then
                        myView.MainGrid.SaveChanges(, "personid=" & frmIDX)
                    End If

                    myVueEdu.MainGrid.SaveChanges(, "personid=" & frmIDX)
                    myVueFam.MainGrid.SaveChanges(, "personid=" & frmIDX)
                    myVueExp.MainGrid.SaveChanges(, "personid=" & frmIDX)

                    frmMode = EnumfrmMode.acEditM
                    myContext.Provider.dbConn.CommitTransaction(HRPersonDescrip, frmIDX)
                    VSave = True
                Catch ex As Exception
                    myContext.Provider.dbConn.RollBackTransaction(HRPersonDescrip, ex.Message)
                    Me.AddError("", ex.Message)
                End Try
            End If
        End If
        Return VSave
    End Function

    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput
        Select Case dataKey
            Case "emp"
                oRet.Data = GenerateData("emp", myUtils.cValTN(ID))
        End Select
        Return oRet
    End Function

    Protected Overrides Function GenerateData(DataKey As String, ID As String) As DataSet
        Dim oRet As New clsProcOutput
        Select Case DataKey.Trim.ToLower
            Case "emp"
                Dim sql As String = "Select employeeid,personid,Campusid,iscasual,OnRolls,ShiftId,EmpCode,DepId,Designation,JoinDate,LeaveDate,Status from hrplistemp() where personid=" & ID
                oRet.Data = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
        End Select

        Return oRet.Data
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Select Case dataKey.Trim.ToLower
                Case "geopoint"
                    Dim address As String = Encoding.UTF8.GetString(Convert.FromBase64String(Replace(myUtils.cStrTN(myContext.SQL.ParamValue("@address", Params)), "-", "=")))
                    Dim geocoder As New Geocoder(ConfigurationManager.AppSettings("GOOGLE_MAPS_API_KEY"))

                    Dim response = geocoder.Geocode(address)
                    If response.Results.Count > 0 Then
                        Dim loc = response.Results(0).Geometry.Location
                        Dim pnt As New GeoCoordinate(loc.Lat, loc.Lng)
                        oRet.Description = pnt.ToString
                    End If
            End Select
        End If
        Return oRet
    End Function
End Class
