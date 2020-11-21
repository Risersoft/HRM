Imports System.Text
Imports System.Windows.Forms
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports risersoft.shared.Extensions

Public Class frmCandidatePerson
    Inherits frmMax
    Dim myVueEdu As New clsWinView, myVueFam As New clsWinView, myVueExp As New clsWinView
    Dim hasNewImg As Boolean = False
    Dim dvStatePr, dvStatePm As DataView
    Friend fEmp As frmJobApplication
    Private Sub InitForm()

        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UGridEmp)
        myVueEdu.SetGrid(Me.UGridEdu)
        myVueFam.SetGrid(Me.UGridFam)
        myVueExp.SetGrid(Me.UGridExp)

    End Sub
    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        Dim objModel As frmCandidatePersonModel = Me.InitData("frmCandidatePersonModel", oView, prepMode, prepIDX, strXML)

        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "CO", "", Me.cmb_PrCountry, "<STRWIDTH>0-0-1-3</STRWIDTH>")
            myWinSQL.AssignCmb(Me.dsCombo, "CO", "", Me.cmb_PmCountry, "<STRWIDTH>0-0-1-3</STRWIDTH>")
            dvStatePr = myWinSQL.AssignCmb(Me.dsCombo, "SU", "", Me.cmb_PrState, "<STRWIDTH>0-0-0-1-3</STRWIDTH>", 2)
            dvStatePm = myWinSQL.AssignCmb(Me.dsCombo, "SU", "", Me.cmb_PmState, "<STRWIDTH>0-0-0-1-3</STRWIDTH>", 2)
            Me.cmb_TopQual.ValueList = Me.Model.ValueLists("TopQual").ComboList
            Me.cmb_IsFemale.ValueList = Me.Model.ValueLists("IsFemale").ComboList
            Me.cmb_MarStatus.ValueList = Me.Model.ValueLists("MarStatus").ComboList

            If frmMode = EnumfrmMode.acEditM Then
                Me.Text = myRow("fullname")
                If Not (myUtils.NullNot(myRow("picperson"))) Then
                    WinFormUtils.FillPB(Me.pic_PicPerson, myRow("picperson"))
                    Me.pic_PicPerson.rePicsize(Me.Width - Me.PanelPicSide.Width)
                End If
            End If

            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("ListEmp"))
            myVueEdu.PrepEdit(Me.Model.GridViews("Edu"), Me.btnAddEdu, Me.btnDelEdu)
            myVueFam.PrepEdit(Me.Model.GridViews("Fam"), Me.btnAddFam, Me.btnDelFam)
            myVueExp.PrepEdit(Me.Model.GridViews("Exp"), Me.btnAddExp, Me.btnDelExp)

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Dim BoolNewEmp As Boolean = True
        VSave = False
        Me.InitError() : WinFormUtils.InitTabBacks(Me.UltraTabControl1)

        cm.EndCurrentEdit()
        If BoolNewEmp AndAlso Me.ValidateData() Then
            If hasNewImg Then WinFormUtils.FillDSFromPB(myRow.Row, "picperson", Me.pic_PicPerson)
            If Me.SaveModel() Then
                VSave = True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        If Me.frmMode = EnumfrmMode.acEditM Then
            Dim f As New frmJobApplication
            f.fMat = Me
            If f.PrepForm(myView, EnumfrmMode.acAddM, "", "") Then f.ShowDialog()
        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim f As New frmJobApplication
        f.fMat = Me
        myView.ContextRow = myView.mainGrid.ActiveRow
        If Not myView.ContextRow Is Nothing Then
            If f.PrepForm(Me.myView, EnumfrmMode.acEditM, "") Then f.ShowDialog()
        End If

    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsePic.Click
        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Me.pic_PicPerson.Image = System.Drawing.Image.FromFile(Me.OpenFileDialog1.FileName)
            Me.pic_PicPerson.rePicsize(Me.Width - Me.PanelPicSide.Width)
            hasNewImg = True
        End If
    End Sub

    Private Sub btnSameAs_Click(sender As Object, e As EventArgs) Handles btnCopyPrAdd.Click
        cm.EndCurrentEdit()

        myFuncsBase.CopyAdd(Me.Controller, myRow.Row, myRow.Row, "pr", "pm")

    End Sub

    Private Sub btnLookupGeoPr_Click(sender As Object, e As EventArgs) Handles btnLookupGeoPr.Click
        Dim str1 As String = myUtils.MakeCSV(" ", Me.txt_PrAddress.Text, Me.txt_PrCity.Text, Me.cmb_PrState.Text, Me.cmb_PrCountry.Text)
        str1 = Replace(Convert.ToBase64String(Encoding.UTF8.GetBytes(str1)), "=", "-")
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@address", "'" & str1 & "'", GetType(String), False))
        Dim oRet = Me.GenerateParamsOutput("geopoint", Params)
        If oRet.Success Then Me.txt_PrGeoPoint.Text = oRet.Description
    End Sub

    Private Sub btnLookupGeoPm_Click(sender As Object, e As EventArgs) Handles btnLookupGeoPm.Click
        Dim str1 As String = myUtils.MakeCSV(" ", Me.txt_PmAddress.Text, Me.txt_PmCity.Text, Me.cmb_PmState.Text, Me.cmb_PmCountry.Text)
        str1 = Replace(Convert.ToBase64String(Encoding.UTF8.GetBytes(str1)), "=", "-")
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@address", "'" & str1 & "'", GetType(String), False))
        Dim oRet = Me.GenerateParamsOutput("geopoint", Params)
        If oRet.Success Then Me.txt_PmGeoPoint.Text = oRet.Description

    End Sub

    Private Sub btnSavepic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavepic.Click
        If Me.SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Me.pic_PicPerson.Image.Save(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub cmb_PrCountry_ValueChanged(sender As Object, e As EventArgs) Handles cmb_PrCountry.ValueChanged
        If Me.FormPrepared Then
            Dim str1 As String = ""
            If Not Me.cmb_PrCountry.SelectedRow Is Nothing Then str1 = Me.cmb_PrCountry.SelectedRow.Cells("countrycode").Value
            dvStatePr.RowFilter = "countrycode='" & str1 & "'"
        End If
    End Sub
    Private Sub cmb_PmCountry_ValueChanged(sender As Object, e As EventArgs) Handles cmb_PmCountry.ValueChanged
        If Me.FormPrepared Then
            Dim str1 As String = ""
            If Not Me.cmb_PmCountry.SelectedRow Is Nothing Then str1 = Me.cmb_PmCountry.SelectedRow.Cells("countrycode").Value
            dvStatePm.RowFilter = "countrycode='" & str1 & "'"
        End If
    End Sub

End Class
