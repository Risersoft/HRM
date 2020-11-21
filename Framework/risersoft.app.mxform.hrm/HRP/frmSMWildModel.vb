Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmSMWildModel
    Inherits clsFormDataModel
    Dim myView1, myView2 As clsViewModel
    Protected Overrides Sub InitViews()
        myView1 = Me.GetViewModel("EmpSalComp1")
        myView2 = Me.GetViewModel("EmpSalComp2")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim vlist As New clsValueList
        vlist.Add(1, "Already Defined")
        vlist.Add(2, "Not Defined")
        Me.ValueLists.Add("Select", vlist)
        Me.AddLookupField("Select", "Select")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String, payproposalid As Integer

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            prepIDX = myUtils.cValTN(oView.ContextRow.CellValue("oldsmid"))
            payproposalid = myUtils.cValTN(oView.ContextRow.CellValue("payproposalid"))
            If myUtils.NullNot(oView.ContextRow.CellValue("oldsmid")) Then
                Me.AddError("", Nothing, 0, "", "", "Select a row which contains salary")
            ElseIf myUtils.NullNot(oView.ContextRow.CellValue("enforceon")) Then

                Me.InitData("", "", oView, EnumfrmMode.acEditM, prepIDX, strXML)

                myView1.MainGrid.MainConf("defaultwidfact") = 1
                sql = "select SalStructureID, EmpSalComp.SalComponentID, ComponentName, Amount  from EmpSalComp inner join SalComponent on " &
                       "EmpSalComp.SalComponentID = SalComponent.SalComponentID  where EmpSalaryID = " & myUtils.cValTN(oView.ContextRow.CellValue("oldsmid"))
                myView1.MainGrid.QuickConf(sql, False, "0-0-1-1", True, "CHANGE IN COMPONENTS", True)

                For Each r As DataRow In myView1.MainGrid.myDS.Tables(0).Select()
                    r("Amount") = 0
                Next
                str1 = "<BAND INDEX=""0"" TABLE=""EmpSalComp"" IDFIELD=""EmpSalCompID""><COL NOEDIT=""TRUE"" KEY=""ComponentName"" /><COL KEY=""Amount"" STYLE =  ""CALC"" /></BAND>"
                myView1.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)
            Else
                Me.AddError("Select", "This Pay Proposal has already been enforced.")
            End If
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
        Dim sqlOld, sqlNew, strSMOld, strSMNew As String, dtSMOld, dtSMNew As DataTable, ds As DataSet, dtMod As DataTable, MinSal As Boolean, selIndex As Integer
        VSave = False

        If Me.Validate Then
            For Each r As DataRow In myView2.MainGrid.myDS.Tables(0).Select("sysincl=1")
                If myUtils.cValTN(r("oldsmid")) <> 0 Then
                    If myUtils.cValTN(r("newsmid")) = 0 Then
                        strSMOld = strSMOld & IIf(strSMOld = "", "", ",") & r("oldsmid")
                    Else
                        strSMNew = strSMNew & IIf(strSMNew = "", "", ",") & r("newsmid")
                    End If
                End If
            Next

            sqlOld = "select * from EmpSalComp where EmpSalaryID in (" & IIf(strSMOld = "", 0, strSMOld) & ")"
            sqlNew = "select * from EmpSalComp where EmpSalaryID in (" & IIf(strSMNew = "", 0, strSMNew) & ")"
            ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sqlOld & ";" & sqlNew)
            dtSMOld = ds.Tables(0) : dtSMNew = ds.Tables(1)

            'dtSMNew already contains paypropsalid and needs to be edited only

            MinSal = myContext.SQL.ParamValue("@MinSal", ClientParams)
            selIndex = myContext.SQL.ParamValue("@Select", ClientParams)
            For Each r As DataRow In myView1.MainGrid.myDS.Tables(0).Select()

                If selIndex = 0 Then dtMod = dtSMNew Else dtMod = dtSMOld
                MinSal = myContext.SQL.ParamValue("@MinSal", ClientParams)

                If dtMod.Columns.Contains("Amount") Then
                    For Each r1 As DataRow In dtMod.Select("SalComponentID = " & myUtils.cValTN(r("SalComponentID")) & "")
                        If MinSal Then
                            If myUtils.cValTN(r("Amount")) > 0 Then
                                If r1("Amount") < myUtils.cValTN(r("Amount")) Then r1("Amount") = myUtils.cValTN(r("Amount"))
                            End If
                        Else
                            If myUtils.cValTN(r1("Amount")) + myUtils.cValTN(r("Amount")) > 0 Then
                                r1("Amount") = myUtils.cValTN(r1("Amount")) + myUtils.cValTN(r("Amount"))
                            Else
                                r("Amount") = 0
                            End If
                        End If
                    Next
                End If
            Next

            Dim SMWildDescrip As String = "Wild Card Salary Master Changes"

            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, "Wild Card Salary Changes")
                If Not selIndex = 0 Then

                    myContext.Provider.objSQLHelper.SaveResults(dtSMOld, "select * from EmpSalComp where EmpSalaryID = 0")
                Else
                    myContext.Provider.objSQLHelper.SaveResults(dtSMNew, "select * from EmpSalComp where EmpSalaryID = 0")
                End If

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(SMWildDescrip, frmIDX)
                myContext.Provider.dbConn.CommitTransaction()
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(SMWildDescrip, e.Message)
                myContext.Provider.dbConn.RollBackTransaction()
                Me.AddException("", e)
            End Try
        End If
        Return VSave
    End Function

End Class
