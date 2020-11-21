Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmLeavePolicyModel
    Inherits clsFormDataModel

    Dim sql As String

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("AttendTag")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        sql = "select companyid, compname from company order by compname"
        Me.AddLookupField("companyid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Company").TableName)

        sql = myFuncsBase.CodeWordSQL("attend", "TagType", "")
        Me.AddLookupField("TagType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "TagType").TableName)

        sql = myFuncsBase.CodeWordSQL("Leave", "AccrueType", "")
        Me.AddLookupField("AccrueType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "AccrueType").TableName)

        sql = myFuncsBase.CodeWordSQL("calendar", "", "(CodeWord = 'M' or CodeWord = 'Q' )")
        Me.AddLookupField("LvePeriodType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "LvePeriodType").TableName)

        Dim vlist2 As New clsValueList
        vlist2.Add(True, "Yes")
        vlist2.Add(False, "No")
        Me.ValueLists.Add("CountOnlyWork", vlist2)
        Me.AddLookupField("CountOnlyWork", "CountOnlyWork")

        Dim vlst As New clsValueList
        vlst.Add(True, "Yes")
        vlst.Add(False, "No")
        Me.ValueLists.Add("AllowEncash", vlst)
        Me.AddLookupField("AllowEncashFF", "AllowEncash")
        Me.AddLookupField("AllowEncashLM", "AllowEncash")

        Dim dic As New clsCollecString(Of String)
        dic.Add("AttTag", "select distinct(LeaveGroup) from attendtagmaster where leavegroup is not null")
        Me.AddDataSet("AttTag", dic)
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "select * from LeavePolicy where LeavePolicyID = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        sql = "Select AttendTagID, LeavePolicyID, LvePeriodNum, LveDue, CountOnlyWork, CarryForwardLimit, AllowEncashLM, AllowEncashFF, LeaveGroup, AttendTag, TagType, FullTag, AccrueType, MaxAccrue, LvePeriodType from AttendTagMaster where LeavePolicyID = " & frmIDX & ""
        myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""MaxAccrue"" CAPTION=""Maximum Accrue""/><COL KEY=""LvePeriodType"" CAPTION=""LeavePeriod Type""/>"
        myView.MainGrid.QuickConf(sql, True, "1-1-1-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""AttendTagMaster"" IDFIELD=""AttendTagID""><COL KEY=""LeavePolicyID, LvePeriodNum, LveDue, CountOnlyWork, CarryForwardLimit, AllowEncashLM, AllowEncashFF, LeaveGroup, AttendTag, TagType, FullTag, AccrueType, MaxAccrue, LvePeriodType""/></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If (myUtils.cStrTN(myRow("PolicyName")).Trim.Length = 0) Then Me.AddError("PolicyName", "Enter Policy Name")
        If myUtils.NullNot(myRow("Dated")) Then Me.AddError("Dated", "Select Valid Date")

        Return Me.CanSave

    End Function

    Public Overrides Function VSave() As Boolean
        Dim oRet As clsProcOutput
        VSave = False

        If Me.Validate Then
            oRet = myHRFuncs.CanSavePolicy(myContext, frmIDX)
            If myView.MainGrid.myDS.Tables(0).Select.Length > 0 Then
                myRow("TagVList") = myUtils.MakeCSV(myView.MainGrid.myDS.Tables(0).Select(), "AttendTag")
            End If

            If oRet.Success Then
                VSave = True
                Dim LeavePolicyDescrip As String = " PolicyName: " & myRow("PolicyName") & ", Dated:" & myRow("Dated")
                Try
                    myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "LeavePolicyID", frmIDX)
                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                    frmIDX = myRow("LeavePolicyID")

                    myView.MainGrid.SaveChanges(, "LeavePolicyID=" & frmIDX)
                    frmMode = EnumfrmMode.acEditM
                    myContext.Provider.dbConn.CommitTransaction(LeavePolicyDescrip, frmIDX)
                    VSave = True
                Catch e As Exception
                    myContext.Provider.dbConn.RollBackTransaction(LeavePolicyDescrip, e.Message)
                    Me.AddException("", e)
                End Try
            Else
                Me.AddError("", oRet.Message)
            End If
        End If

        Return VSave
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput, objATM As New clsAttendTagBase(myContext)
        Try
            Select Case EntityKey.Trim.ToLower
                Case "attendtag"
                    Dim sql As String = "select * from AttendTagMaster where AttendTagID = " & ID & ""
                    Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                    oRet = objATM.CheckDelete(dt.Rows(0))
                    If oRet.Success Then
                        If AcceptWarning Then
                            Dim sql1 As String = "delete from AttendTagMaster where AttendTagID = " & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)
                        ElseIf oRet.WarningCount = 0 Then
                            oRet.AddWarning("Are you sure ?")
                        End If
                    End If

                Case "lp"
                    oRet = myHRFuncs.CanSavePolicy(myContext, ID)
                    If oRet.Success Then
                        If AcceptWarning Then
                            Dim sql1 As String = "delete from LeavePolicy where LeavePolicyID = " & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)
                        ElseIf oRet.WarningCount = 0 Then
                            oRet.AddWarning("Are you sure ?")
                        End If
                    End If
            End Select
        Catch ex As Exception
            oRet.AddException(ex)
        End Try

        Return oRet
    End Function

End Class
