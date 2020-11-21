Imports risersoft.shared
Imports Infragistics.Win.UltraWinGrid
Imports risersoft.app.mxent

Public Class myHRFuncs
    Public DoRefresh As Boolean = False
    Public Sub ColorizeVDA(ByVal oview As clsView, ByVal frmidx As String, ByVal e As clsRow)
        Dim gRow As clsRow = e

        If gRow.ColExists("vda") Then
            If myUtils.cValTN(gRow.CellValue("vda")) > 0 Then
                gRow.BackColor = System.Drawing.Color.LightGreen
            End If
        End If

    End Sub
    Public Function PrepOrg(ByRef nodX As clsTreeNodeModel, ByRef dt As DataTable, ByVal ReportsToID As Int64) As Boolean
        Dim cNode As clsTreeNodeModel, filterkey As String
        Dim rr(), r As DataRow

        If ReportsToID = 0 Then rr = dt.Select("reportstoid is null") Else rr = dt.Select("reportstoid =" & ReportsToID)
        For Each r In rr
            cNode = nodX.Add(New clsTreeNodeModel("emp_" & r("employeeid"), r("FullName")))
            cNode.Datakey = "viewpersonemp"
            cNode.Tag = New clsConf
            cNode.Tag("strIDXML") = "<IDX VALUE=""" & r("personid") & """/><FILTER KEY=""person""><VALUE VALUE1=""" & r("personid") & """/></FILTER>"
            PrepOrg(cNode, dt, r("employeeid"))
        Next

    End Function
    Public Sub DivideSal(context As IProviderContext, ByVal pNode As clsTreeNodeModel, ds As DataSet, ByVal strDKey As String, ByVal strTag As String)
        Dim sql, str1, str2 As String, i As Integer
        Dim nodx1, nodx2, nodx3 As clsTreeNodeModel

        Console.WriteLine(pNode.Text)
        sql = ""
        nodx1 = pNode.Add(New clsTreeNodeModel(pNode.Key & "_sal", "Salary"))
        nodx1.Tag = New clsConf
        nodx1.Tag("strIDXML") = strTag & "<FILTER KEY=""iswage""><VALUE VALUE1=""0""/></FILTER>"
        nodx1.Datakey = strDKey

        nodx2 = pNode.Add(New clsTreeNodeModel(pNode.Key & "_wage", "Wage"))
        nodx2.Tag = New clsConf
        nodx2.Tag("strIDXML") = strTag & "<FILTER KEY=""iswage""><VALUE VALUE1=""1""/></FILTER>"
        nodx2.Datakey = strDKey

    End Sub
    Public Sub DivideContractor(context As IProviderContext, ByVal pNode As clsTreeNodeModel, ByVal strDKey As String, ByVal strTag As String)
        Dim nodx1, nodx2, nodx3 As clsTreeNodeModel, sql As String

        Dim Params As New List(Of clsSQLParam)
        Dim dsCon As DataSet = context.Provider.LoadAppData(context.GetAppInfo, "con", Params, False).Result.Data

        nodx1 = pNode.Add(New clsTreeNodeModel(pNode.Key & "_com", "Company Direct"))
        nodx1.Tag = New clsConf
        nodx1.Tag("strIDXML") = strTag & "<FILTER KEY=""contractorid""><VALUE OPERTYPE=""isnull""/></FILTER>"
        nodx1.Datakey = strDKey

        For Each r1 As DataRow In dsCon.Tables(0).Select
            nodx1 = pNode.Add(New clsTreeNodeModel(pNode.Key & "_con" & r1("vendorid"), r1("partyname")))
            nodx1.Tag = New clsConf
            nodx1.Tag("strIDXML") = strTag & "<FILTER KEY=""contractorid""><VALUE VALUE1=""" & r1("vendorid") & """/></FILTER>"
            nodx1.Datakey = strDKey
        Next


    End Sub

    Public Sub DivideNode(context As IProviderContext, ByVal pNode As clsTreeNodeModel, ds As DataSet, ByVal strDKey As String, ByVal strTag As String, OUDep As Integer, ByVal Cat As Boolean, Optional ByVal Skill As Boolean = False)
        Dim sql, str1, str2 As String, i As Integer
        Dim strSkill1 As String() = New String() {"A", "B", "C"}, strSkill2 As String() = New String() {"SKILLED", "SEMI SKILLED", "UN SKILLED"}
        Dim nodx1, nodx2, nodx3 As clsTreeNodeModel

        Console.WriteLine(pNode.Text)
        sql = ""
        If Cat Then
            nodx1 = pNode.Add(New clsTreeNodeModel(pNode.Key & "_st", "Staff"))
            nodx1.Tag = New clsConf
            nodx1.Tag("strIDXML") = strTag & "<FILTER KEY=""isworker""><VALUE VALUE1=""0""/></FILTER>"
            nodx1.Datakey = strDKey

            nodx2 = pNode.Add(New clsTreeNodeModel(pNode.Key & "_wo", "Worker"))
            nodx2.Tag = New clsConf
            nodx2.Tag("strIDXML") = strTag & "<FILTER KEY=""isworker""><VALUE VALUE1=""1""/></FILTER>"
            nodx2.Datakey = strDKey

            DivideContractor(context, pNode, strDKey, strTag)
        End If
        If Skill Then
            For i = 0 To 2
                str1 = strSkill1(i) : str2 = strSkill2(i)
                nodx3 = nodx1.Add(New clsTreeNodeModel(nodx1.Key & "_skill" & str1, str2))
                nodx3.Tag = New clsConf
                nodx3.Tag("strIDXML") = nodx1.Tag("strIDXML") & "<FILTER KEY=""skill""><VALUE VALUE1=""" & str1 & """/></FILTER>"
                nodx3.Datakey = strDKey
            Next
            For i = 0 To 2
                str1 = strSkill1(i) : str2 = strSkill2(i)
                nodx3 = nodx2.Add(New clsTreeNodeModel(nodx2.Key & "_skill" & str1, str2))
                nodx3.Tag = New clsConf
                nodx3.Tag("strIDXML") = nodx2.Tag("strIDXML") & "<FILTER KEY=""skill""><VALUE VALUE1=""" & str1 & """/></FILTER>"
                nodx3.Datakey = strDKey
            Next
        End If


        If OUDep > 0 Then
            Try
                Dim dt1 As DataTable

                If OUDep > 1 Then
                    dt1 = context.Data.SelectDistinct(ds.Tables(0), "depid, depname, isworker,OU", True)
                Else
                    dt1 = context.Data.SelectDistinct(ds.Tables(0), "depid, depname, isworker", True)
                End If
                If Cat Then
                    DivideOUDep(context, nodx1, OUDep, dt1, "isworker=0", nodx1.Datakey, nodx1.Tag("strIDXML"))
                    DivideOUDep(context, nodx2, OUDep, dt1, "isworker=1", nodx2.Datakey, nodx2.Tag("strIDXML"))

                Else
                    DivideOUDep(context, pNode, OUDep, dt1, "", strDKey, strTag)
                End If
            Catch e As SqlClient.SqlException
                'No permission or sql error ... continue
                Debug.WriteLine(e.Message)
            End Try
        End If

    End Sub
    Public Sub DivideOUDep(context As IProviderContext, ByRef pNode As clsTreeNodeModel, OUDep As Integer, dtDeps As DataTable, strf As String, ByVal strDKey As String, ByVal strTag As String)
        Dim nodx As clsTreeNodeModel, r, rr() As DataRow, dAuto As New clsAuto

        dAuto.Init("ou")
        'OUDep=1 => Deps Only, OUDep=2 => OU Only, OUDep=3 => OU + Deps

        Select Case OUDep
            Case 1
                rr = context.Data.SelectDistinct(dtDeps, "depid", , , strf).Select("", "depname")
                'rr = myData.SelectDistinct(dtDeps, "depid", , , strf).Select("", "depname")
                DivideDep(pNode, rr, strDKey, strTag)
            Case Else
                rr = context.Data.SelectDistinct(dtDeps, "ou", , , strf).Select("", "OU,depname")
                For Each r In rr
                    nodx = pNode.Add(New clsTreeNodeModel(pNode.Key & "_" & dAuto.Val, r("OU")))
                    nodx.Tag = New clsConf
                    nodx.Tag("strIDXML") = strTag & "<FILTER KEY=""OU""><VALUE VALUE1=""" & XMLUtils.ReplaceSpecialChars(r("OU")) & """/></FILTER>"
                    nodx.Datakey = strDKey
                    If OUDep = 3 Then DivideDep(nodx, dtDeps.Select(myUtils.CombineWhere(False, strf, "OU='" & r("OU") & "'"), "depname"), strDKey, nodx.Tag("strIDXML"))
                Next

        End Select

    End Sub
    Public Sub DivideDep(ByRef pNode As clsTreeNodeModel, rr() As DataRow, ByVal strDKey As String, ByVal strTag As String)
        Dim nodx As clsTreeNodeModel, r As DataRow, dAuto As New clsAuto

        dAuto.Init("dep")
        For Each r In rr
            nodx = pNode.Add(New clsTreeNodeModel(pNode.Key & "_" & dAuto.Val, r("depname")))
            nodx.Tag = New clsConf
            nodx.Tag("strIDXML") = strTag & "<FILTER KEY=""DEP""><VALUE VALUE1=""" & r("Depid") & """/></FILTER>"
            nodx.Datakey = strDKey
        Next

    End Sub
    Public Sub DivideCampus(context As IProviderContext, ByVal pNode As clsTreeNodeModel, ds As DataSet, ByVal strDKey As String, ByVal strTag As String)
        Dim nodx As clsTreeNodeModel, r As DataRow, cAuto As New clsAuto, sql As String

        Try
            'sql = "select distinct campusid, campus from (" & bSql & ") as t1 order by campus"

            Dim dt1 As DataTable = context.Data.SelectDistinct(ds.Tables(0), "campusid, DispName", True)

            cAuto.Init("campus")
            For Each r In dt1.Select
                'nodx = pNode.Add(new clstreeNodeModel(pNode.Key & "_" & cAuto.Val, r("campus"))
                nodx = pNode.Add(New clsTreeNodeModel(pNode.Key & "_" & cAuto.Val, r("DispName")))
                nodx.Tag = New clsConf

                nodx.Tag("strIDXML") = strTag & "<FILTER KEY=""campus""><VALUE VALUE1=""" & r("campusid") & """/></FILTER>"
                nodx.Datakey = strDKey
            Next
        Catch e As SqlClient.SqlException
            If System.Diagnostics.Debugger.IsAttached Then MsgBox(e.Message)
            'No permission or sql error ... continue
        End Try

    End Sub
    Public Sub DivideDivision(context As IProviderContext, ByVal pNode As clsTreeNodeModel, ds As DataSet, ByVal strDKey As String, ByVal strTag As String)
        Dim nodx As clsTreeNodeModel, r As DataRow, cAuto As New clsAuto, sql As String

        Try
            'sql = "select distinct campusid, campus from (" & bSql & ") as t1 order by campus"

            Dim dt1 As DataTable = context.Data.SelectDistinct(ds.Tables(0), "divisionid, DivisionName", True)

            cAuto.Init("division")
            For Each r In dt1.Select
                'nodx = pNode.Add(new clstreeNodeModel(pNode.Key & "_" & cAuto.Val, r("campus"))
                nodx = pNode.Add(New clsTreeNodeModel(pNode.Key & "_" & cAuto.Val, myUtils.cStrTN(r("DivisionName"))))
                nodx.Tag = New clsConf

                nodx.Tag("strIDXML") = strTag & "<FILTER KEY=""division""><VALUE VALUE1=""" & r("divisionid") & """/></FILTER>"
                nodx.Datakey = strDKey
            Next
        Catch e As SqlClient.SqlException
            If System.Diagnostics.Debugger.IsAttached Then MsgBox(e.Message)
            'No permission or sql error ... continue
        End Try

    End Sub
    Public Sub OrgNodes(context As IProviderContext, ByRef xNode As clsTreeNodeModel, ByVal strPass As String, ByRef VarList As clsConf, Model As clsViewModel, strIDXML As String)
        Dim Params As New List(Of clsSQLParam)
        Dim ds As DataSet = context.App.objAppExtender.LoadAppData(context, "allemp", Params, False).Data
        Me.PrepOrg(xNode, ds.Tables(0), 0)

    End Sub

    Public Sub PPNodes(context As IProviderContext, ByRef xNode As clsTreeNodeModel, ByVal strPass As String, pVarList As clsConf, Model As clsViewModel, strIDXML As String)
        Dim sql As String

        strPass = myUtils.cStrTN(strPass).Trim.ToLower
        If (Not Model.MainGrid Is Nothing) AndAlso (Model.MainGrid.myDS.Tables.Count > 0) Then
            Dim ds As DataSet = Model.MainGrid.myDS
            If myUtils.IsInList(strPass, "", "campus", "division") Then
                DivideNode(context, xNode, ds, xNode.Datakey, strIDXML, 1, True)
                If strPass.ToLower = "campus" Then DivideCampus(context, xNode, ds, xNode.Datakey, strIDXML)
                If strPass.ToLower = "division" Then DivideDivision(context, xNode, ds, xNode.Datakey, strIDXML)
            ElseIf strPass = "ou" OrElse strPass = "oudep" Then
                DivideNode(context, xNode, ds, xNode.Datakey, strIDXML, 3, True)
            ElseIf strPass.ToLower = "last" Then
                DivideNode(context, xNode, ds, xNode.Datakey, strIDXML, 1, True)
            ElseIf strPass.ToLower = "skill" Then
                DivideNode(context, xNode, ds, xNode.Datakey, strIDXML, 1, True, True)
            ElseIf strPass.ToLower = "skillou" Then
                DivideNode(context, xNode, ds, xNode.Datakey, strIDXML, 2, True, True)
            ElseIf strPass.ToLower = "skilloudep" Then
                DivideNode(context, xNode, ds, xNode.Datakey, strIDXML, 3, True, True)
            ElseIf strPass.ToLower = "wage" Then
                DivideSal(context, xNode, ds, xNode.Datakey, strIDXML)
            ElseIf strPass.ToLower = "catonly" Then
                DivideNode(context, xNode, ds, xNode.Datakey, strIDXML, 0, True)
            ElseIf strPass.ToLower = "deponly" Then
                DivideNode(context, xNode, ds, xNode.Datakey, strIDXML, 1, False)
            ElseIf strPass.ToLower = "contractor" Then
                DivideContractor(context, xNode, xNode.Datakey, strIDXML)
            ElseIf strPass.ToLower = "ouonly" Then
                DivideNode(context, xNode, ds, xNode.Datakey, strIDXML, 2, False)
            ElseIf strPass.ToLower = "atd" Then
                Dim Params As New List(Of clsSQLParam)
                Dim ds2 As DataSet = context.Provider.LoadAppData(context.GetAppInfo, "atd", Params, False).Result.Data
                DivideNode(context, xNode, ds2, xNode.Datakey, strIDXML, 1, True)
            ElseIf strPass.ToLower = "atdc" Then
                Dim Params As New List(Of clsSQLParam)
                Dim ds2 As DataSet = context.Provider.LoadAppData(context.GetAppInfo, "atdc", Params, False).Result.Data
                DivideNode(context, xNode, ds2, xNode.Datakey, strIDXML, 1, True)
            End If
        End If

    End Sub
    Public Sub fncPPCalcWOT(context As IProviderContext, ByRef oView As clsView)
        Dim sql, prepIDX, str As String, dt As DataTable

        prepIDX = oView.ContextRow.CellValue("payperiodid")
        sql = "select isfinalwot,haswot from payperiod where payperiodid=" & myUtils.cValTN(prepIDX)
        dt = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
        If dt.Rows.Count > 0 Then
            If myUtils.cBoolTN(dt.Rows(0)("isfinalwot")) Then
                MsgBox("Payperiod Incentive and overtime already finalized", MsgBoxStyle.Information, context.Vars("appname"))
            ElseIf Not myUtils.cBoolTN(dt.Rows(0)("haswot")) Then
                MsgBox("Payperiod does not have incentive and overtime", MsgBoxStyle.Information, context.Vars("appname"))
            Else
                context.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, "sp_paywot " & prepIDX)
                Me.DoRefresh = True
            End If
        End If
    End Sub

    Public Sub fncPPCalcSal(context As IProviderContext, ByRef oView As clsView)
        Dim sql, prepIDX, str As String, dt As DataTable

        prepIDX = oView.ContextRow.CellValue("payperiodid")
        sql = "select isfinal,advanceon from payperiod where payperiodid=" & myUtils.cValTN(prepIDX)
        dt = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
        If dt.Rows.Count > 0 Then
            If myUtils.cBoolTN(dt.Rows(0)("isfinal")) Then
                MsgBox("Payperiod already finalized", MsgBoxStyle.Information, context.Vars("appname"))
            ElseIf myUtils.NullNot(dt.Rows(0)("advanceon")) Then
                MsgBox("Payperiod Advance not given", MsgBoxStyle.Information, context.Vars("appname"))
            Else
                context.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, "sp_paysal " & prepIDX & ",null")
                Me.DoRefresh = True
            End If
        End If
    End Sub


    Public Sub fncFinalPPWOT(context As IProviderContext, ByRef oView As clsView)
        Dim sql, str, prepIDX As String, dt As DataTable

        prepIDX = oView.ContextRow.CellValue("payperiodid")
        sql = "select payperiodid,isfinalwot from payperiod where payperiodid=" & myUtils.cValTN(prepIDX)
        dt = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
        If dt.Rows.Count > 0 Then
            If myUtils.cBoolTN(dt.Rows(0)("isfinalwot")) Then
                MsgBox("Payperiod Incentive and overtime already finalized", MsgBoxStyle.Information, context.Vars("appname"))
            Else
                dt.Rows(0)("isfinalwot") = True
                context.Provider.objSQLHelper.SaveResults(dt, sql)
                Me.DoRefresh = True
            End If
        End If
    End Sub

    Public Shared Function CanSavePolicy(context As IProviderContext, ID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput, sql As String, objATM As New clsAttendTagBase(context)
        sql = "select * from AttendTagMaster where LeavePolicyID = " & ID & ""
        Dim dt = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        For Each r1 As DataRow In dt.Select
            oRet = oRet + objATM.CheckDelete(dt.Rows(0))
        Next

        Return oRet
    End Function

    Public Shared Function CheckPopulateForm12BB(context As IProviderContext, Form12BBID As Integer) As clsProcOutput
        Dim dic As New clsCollecString(Of String), oRet As New clsProcOutput
        Try
            dic.Add("item", String.Format("select Form12BBItemID, Form12BBID, IsParent, IsText, sortindex, TableNum,  SectionNum, Description, Amount, Evidence from essListForm12BBitem() where Form12BBID={0} order by sortindex", Form12BBID))
            dic.Add("section", "select * from taxsectiontext where returntype in ('tds') order by sortindex")
            Dim ds = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
            For Each r1 As DataRow In ds.Tables("section").Select
                Dim str1 = context.SQL.GenerateSQLWhere(r1, "tablenum,sectionnum")
                Dim rr() As DataRow = ds.Tables("item").Select(str1), nr As DataRow
                If rr.Length > 0 Then
                    nr = rr(0)
                Else
                    nr = context.Tables.AddNewRow(ds.Tables("item"))
                    nr("tablenum") = r1("tablenum")
                    nr("sectionnum") = r1("sectionnum")
                End If
                nr("sortindex") = r1("sortindex")
                nr("description") = r1("description")

                nr("isparent") = r1("isparent")
                nr("istext") = r1("istext")
            Next
            oRet.Data = ds
        Catch ex As Exception
            oRet.AddException(ex)
        End Try
        Return oRet
    End Function

End Class
