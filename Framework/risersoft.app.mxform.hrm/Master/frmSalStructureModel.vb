Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmSalStructureModel
    Inherits clsFormDataModel
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("SalComp")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "select * from SalStructure where SalStructureID = " & prepIDX
        Me.InitData(sql, "EmployeeID", oView, prepMode, prepIDX, strXML)

        sql = "Select SalComponentId, SalStructureID,SortIndex, ComponentCode, ComponentName, Behave, CompType, AllowType from SalComponent where SalStructureID = " & prepIDX & ""
        myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""ComponentCode"" CAPTION=""Code""/><COL KEY=""ComponentName"" CAPTION=""Name""/><COL KEY=""CompType"" CAPTION=""Type""/>"
        myView.MainGrid.QuickConf(sql, True, "1-1-1-1-1", True, "Salary Components")
        str1 = "<BAND INDEX = ""0"" TABLE = ""SalComponent"" IDFIELD=""SalComponentID""><COL KEY ="" SalComponentId, SalStructureID, ComponentCode, ComponentName ""/>" & "<COL KEY=""Behave""" & myFuncs.strGridConfEnd("sal", "compbehave", "", 2) & "<COL KEY=""CompType""" & myFuncs.strGridConfEnd("sal", "comptype", "", 2) & "<COL KEY=""AllowType""" & myFuncs.strGridConfEnd("sal", "AllowType", "", 2) & "</BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function
    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If myUtils.cStrTN(myRow("StructureName")).Trim.Length = 0 Then Me.AddError("StructureName", "Enter Structure Name")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objProc As clsProcOutput, objSalStruct As New clsSalStructureBase(myContext)
        VSave = False

        If Me.Validate Then
            myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, "Select * from SalStructure where SalStructureID = " & frmIDX)
            objProc = objSalStruct.TrySave(myRow.Row, myView.MainGrid.myDS.Tables(0))
            If objProc.Success Then
                frmIDX = myRow("SalStructureID")
                frmMode = EnumfrmMode.acEditM
                VSave = True
            Else
                Me.AddError("", objProc.Message)
            End If
        End If

        Return VSave
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput, objSS As New clsSalStructureBase(myContext)
        Try
            Select Case EntityKey.Trim.ToLower
                Case "salstructure"
                    Dim sql As String = "select * from SalStructure where SalStructureID = " & ID & ""
                    Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                    oRet = objSS.CheckDelete(dt.Rows(0))
                    If oRet.Success Then
                        If AcceptWarning Then
                            Dim sql1 As String = "delete from SalStructure where SalStructureID = " & ID
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
