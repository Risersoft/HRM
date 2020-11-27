﻿Imports risersoft.app.shared
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports uwg = Infragistics.Win.UltraWinGrid

Public Class frmPayslipData
    Inherits frmMax

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridPaySlip)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.InitForm()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmPayslipDataModel = Me.InitData("frmPayslipDataModel", oView, prepMode, prepIDX, strXML)

        If Me.BindModel(objModel, oView) Then
            Me.lbl_Name.Text = "Salary Categorization and TDS for " & myRow.Row("descrip")
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function
    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("PSAdvTDS"))

            Return True
        End If

        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

End Class