Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmSalBenefitModel
    Inherits clsFormDataModel
    Dim sql As String
    Protected Overrides Sub InitViews()

    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        sql = myFuncsBase.CodeWordSQL("sal", "benbehave", "")
        Me.AddLookupField("Behave", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "BenBehave").TableName)

        sql = myFuncsBase.CodeWordSQL("sal", "comptype", "")
        Me.AddLookupField("ApplyCompType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "CompType").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from SalBenefit where SalBenefitID = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)
        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function
    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If myUtils.cStrTN(myRow("BenefitCode")).Trim.Length = 0 Then Me.AddError("BenefitCode", "Enter Benefit Code")
        If myUtils.cStrTN(myRow("BenefitName")).Trim.Length = 0 Then Me.AddError("BenefitName", "Enter Benefit Name")
        If Me.SelectedRow("Behave") Is Nothing Then Me.AddError("Behave", "Select Benefit Behave")
        If Me.SelectedRow("ApplyCompType") Is Nothing Then Me.AddError("ApplyCompType", "Select ApplyCompType")
        
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objProc As clsProcOutput, objSalBen As New clsSalBenefitBase(myContext)
        VSave = False

        If Me.Validate Then
            objProc = objSalBen.TrySave(myRow.Row, Nothing)
            If objProc.Success Then
                frmIDX = myRow("SalBenefitID")
                frmMode = EnumfrmMode.acEditM
                VSave = True
            Else
                Me.AddError("", objProc.Message)
            End If
        End If

        Return VSave
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput, objSalBen As New clsSalBenefitBase(myContext)
        Try
            Select Case EntityKey.Trim.ToLower
                Case "salbenefit"
                    Dim sql As String = "select * from SalBenefit where SalBenefitID = " & ID & ""
                    Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                    oRet = objSalBen.CheckDelete(dt.Rows(0))

                    If oRet.Success Then
                        If AcceptWarning Then
                            Dim sql1 As String = "delete from SalBenefit where SalBenefitID = " & ID
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
