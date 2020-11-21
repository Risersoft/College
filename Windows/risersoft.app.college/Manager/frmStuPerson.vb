Imports System.Collections.Generic
Imports System.Text
Imports risersoft.app.mxent
Imports risersoft.app.mxform.college
Imports risersoft.app.mxform.edu

Public Class frmStuPerson
    Inherits frmMax
    Dim myVueFam, myVueEdu As New clsWinView
    Dim dvStatePr, dvStatePm As DataView
    Friend fEmp As FrmNewStudent

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UGridEmp)
        myVueFam.SetGrid(Me.UGridFam)
        myVueEdu.SetGrid(Me.UltraGridEducation)

        fEmp = New FrmNewStudent
        fEmp.AddtoTab(Me.UltraTabControl2, "NStu", True)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmStuPersonModel = Me.InitData("frmStuPersonModel", oView, prepMode, prepIdx, strXML)

        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "CO", "", Me.cmb_PrCountry, "<STRWIDTH>0-0-1-3</STRWIDTH>")
            myWinSQL.AssignCmb(Me.dsCombo, "CO", "", Me.cmb_PmCountry, "<STRWIDTH>0-0-1-3</STRWIDTH>")
            dvStatePr = myWinSQL.AssignCmb(Me.dsCombo, "SU", "", Me.cmb_PrState, "<STRWIDTH>0-0-0-1-3</STRWIDTH>", 2)
            dvStatePm = myWinSQL.AssignCmb(Me.dsCombo, "SU", "", Me.cmb_PmState, "<STRWIDTH>0-0-0-1-3</STRWIDTH>", 2)
            Me.cmb_IsFemale.ValueList = Me.Model.ValueLists("IsFemale").ComboList

            myWinSQL.AssignCmb(Me.dsCombo, "Category", "", Me.cmb_Category)
            myWinSQL.AssignCmb(Me.dsCombo, "Reservation", "", Me.cmb_Reservation)
            myWinSQL.AssignCmb(Me.dsCombo, "user", "", Me.cmb_userID)

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
            myView.PrepEdit(Me.Model.GridViews("ListStu"))
            myVueFam.PrepEdit(Me.Model.GridViews("Fam"), Me.btnAddFam, Me.btnDelFam)
            myVueEdu.PrepEdit(Me.Model.GridViews("Education"), btnAddEdu, btnDelEdu)

            fEmp.BindModel(NewModel)

            If frmMode = EnumfrmMode.acAddM Then
                Me.UltraTabControl2.Tabs(1).Selected = True
                Dim nr As DataRow = myUtils.CopyOneRow(myRow.Row, myView.mainGrid.myDS.Tables(0))
                fEmp.PrepFormRow(nr)
                If myView.mainGrid.myDS.Tables(0).Select.Length > 0 Then btnAddNew.Visible = False Else btnAddNew.Visible = True
            Else
                Me.UltraTabControl2.Tabs(0).Selected = True
            End If

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Dim BoolNewEmp As Boolean = True
        VSave = False
        Me.InitError() : WinFormUtils.InitTabBacks(Me.UltraTabControl1)

        If frmMode = EnumfrmMode.acAddM Then
            BoolNewEmp = fEmp.VSave
        End If
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
        Dim oRet As clsProcOutput = Nothing
        If Me.frmMode = EnumfrmMode.acEditM Then
            Dim f As New frmStudent
            If f.PrepForm(myView, EnumfrmMode.acAddM, "", " <PARAMS PERSONID=""" & frmIDX & """/>") AndAlso f.ShowDialog = DialogResult.OK Then
                oRet = Me.GenerateIDOutput("stu", frmIDX)
                If oRet.Success Then
                    Me.UpdateViewData(myView, oRet)
                Else
                    MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim oRet As clsProcOutput = Nothing
        If Not myView.mainGrid.myGrid.ActiveRow Is Nothing Then
            Dim f As New frmStudent
            If (f.PrepForm(myView, EnumfrmMode.acEditM, myView.mainGrid.myGrid.ActiveRow.Cells("StudentID").Value)) AndAlso (f.ShowDialog = DialogResult.OK) Then
                oRet = Me.GenerateIDOutput("stu", frmIDX)
                If oRet.Success Then
                    Me.UpdateViewData(myView, oRet)
                Else
                    MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If
            End If
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

    Private Sub btnDeleteStuPerson_Click(sender As Object, e As EventArgs) Handles btnDeleteStuPerson.Click
        Dim oRet = Me.DeleteEntity("persons", frmIDX, False)
        If oRet.ErrorCount > 0 Then
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        Else
            If MsgBox(oRet.Message, MsgBoxStyle.YesNo + MsgBoxStyle.Question, myWinApp.Vars("appname")) = MsgBoxResult.Yes Then
                oRet = Me.DeleteEntity("persons", frmIDX, True)
                If oRet.Success Then WinFormUtils.ButtonAction(Me, "btnCancel")
            End If
        End If
    End Sub

End Class