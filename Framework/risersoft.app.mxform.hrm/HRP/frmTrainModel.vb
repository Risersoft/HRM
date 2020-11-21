Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmTrainModel
    Inherits clsFormDataModel
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("TrainEmp")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from Training where TrainingID = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        myView.MainGrid.QuickConf("Select trainingempid,depid, trainingid, employeeid, FullName, DepName, Effectiveness from qlylisttrainemp() where trainingid = " & frmIDX, True, "1-1-2", , "Applicability")
        myView.MainGrid.PrepEdit("<BAND INDEX=""0"" IDFIELD=""trainingempid"" TABLE=""trainingemp""><COL KEY=""employeeid,depid,trainingid""/><COL KEY=""effectiveness"" BIGTEXT=""True""/></BAND>", EnumEditType.acCommandAndEdit)
        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function
    Public Overrides Function Validate() As Boolean

        Me.InitError()
        If myUtils.cStrTN(myRow("topic")).Trim.Length = 0 Then Me.AddError("topic", "Enter Topic")
        If myUtils.NullNot(myRow("dated")) Then Me.AddError("dated", "Enter Date")
        If myUtils.cStrTN(myRow("place")).Trim.Length = 0 Then
            myRow("onlypres") = True
        Else
            myRow("onlypres") = False
            If myUtils.cStrTN(myRow("faculty")).Trim.Length = 0 Then Me.AddError("faculty", "Enter Faculty")
            If myUtils.cStrTN(myRow("durations")).Trim.Length = 0 Then Me.AddError("durations", "Enter Durations")
        End If

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            Dim ShiftDescrip As String = " Topic: " & myRow("topic") & ", Dt: " & Format(myRow("dated"), "dd-MMM-yyyy")
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "TrainingID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, "Select * from Training where TrainingID = " & frmIDX)
                frmIDX = myRow("TrainingID")
                Me.myView.MainGrid.SaveChanges(, "TrainingID=" & frmIDX)

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(ShiftDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(ShiftDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

    End Function

End Class
