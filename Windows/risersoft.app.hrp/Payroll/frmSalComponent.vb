Public Class frmSalComponent
    Inherits frmMax
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.InitForm()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub InitForm()

        WinFormUtils.SetButtonConf(btn_Ok, btn_cancel, btn_Save)
        Me.cmb_behave.Items.Add("F")
        Me.cmb_behave.Items.Add("V")

    End Sub


    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Dim sql As String
        If prepMode = EnumfrmMode.acAddM Then
            prepIDX = 0

            sql = "select * from salcomponent where SalComponentId = " & prepIDX
            Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)


            If frmMode = EnumfrmMode.acEditM Then
                Me.Text = myRow("SalComponentId")

            End If
        End If
        PrepForm = True

    End Function


    Public Overrides Function VSave() As Boolean
        VSave = False

        Me.InitError()
        If Me.txt_componentCode.Text Is String.Empty Then myWinForms.AddError(Me.txt_componentCode, "ComponentCode")

        If Me.txt_componentName.Text Is String.Empty Then myWinForms.AddError(Me.txt_componentName, "ComponentName")

        If Me.cmb_behave.SelectedIndex < 0 Then myWinForms.AddError(Me.cmb_behave, "Behave")

        ' Me.myView.mainGrid.CheckValid("salbenefitrateid")
        If Me.CanSave Then
            cm.EndCurrentEdit()
            SQLHelper2.SaveResults(myRow.Row.Table, Me.sqlForm)
            frmMode = EnumfrmMode.acEditM
            frmIDX = myRow("SalComponentID")

            VSave = True


        End If
        Me.Refresh()
    End Function
End Class