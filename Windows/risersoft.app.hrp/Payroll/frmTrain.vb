Imports risersoft.app.mxform
Public Class frmTrain
    Inherits frmMax

    Dim eConf As New clsConf

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Dim objModel As frmTrainModel = Me.InitData("frmTrainModel", oView, prepMode, prepIDX, strXML)
        Me.FormPrepared = False

        If Me.BindModel(objModel, oView) Then
            myView.mainGrid.PrepEntSelect("<SYS ID=""EMPLOYEEID""/>", Me.btnDelEmp, Me.btnAddEmp)
            Me.InitUpLoad()
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("TrainEmp"))
            Return True
        End If

        Return False
    End Function

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGrid2)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function VSave() As Boolean

        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            myRow("pdfownerpass") = Me.CtlUpLoad1.EncryptPassword
            myRow("pdfsource") = Me.CtlUpLoad1.FilePath
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub InitUpLoad()
        Try
            Me.CtlUpLoad1.InitExt(frmMode, "trn_" & myRow("trainingid") & "." & "pdf", myUtils.cStrTN(myRow("pdfsource")), myUtils.cStrTN(myRow("pdfownerpass")), "/trn", "pdf", "hrms")
        Catch
            Me.CtlUpLoad1.Visible = False
        End Try
    End Sub

End Class

