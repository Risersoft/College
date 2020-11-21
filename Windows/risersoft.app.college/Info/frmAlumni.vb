Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports risersoft.app.mxform.college
Public Class frmAlumni
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmAlumniModel = Me.InitData("frmAlumniModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            If frmMode = EnumfrmMode.acEditM Then
                If Not myUtils.NullNot(myRow("PicAlumni")) Then
                    WinFormUtils.FillPB(Me.pic_Logo, myRow("PicAlumni"))
                    Me.pic_Logo.rePicsize(0)
                End If
            End If

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "DegreeCourse", "", Me.cmb_DegreeCourseID)
            myWinSQL.AssignCmb(Me.dsCombo, "dep", "", Me.cmb_DepID)
            myWinSQL.AssignCmb(Me.dsCombo, "finyears", "", Me.cmb_FinYearID)
            Me.cmb_JobProfile.ValueList = Me.Model.ValueLists("JobProfile").ComboList

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        cm.EndCurrentEdit()
        If Me.ValidateData() Then
            If hasNewImg Then
                WinFormUtils.FillDSFromPB(myRow.Row, "tclogo", Me.pic_Logo)
                'WinFormUtils.FillDSFromPB(myRow.Row, "tpcertlogo1", Me.pic_TPCert)
            End If
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btnBrowsePic_Click(sender As Object, e As EventArgs) Handles btnBrowsePic.Click
        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Me.pic_Logo.Image = System.Drawing.Image.FromFile(Me.OpenFileDialog1.FileName)
            Me.pic_Logo.rePicsize(0)
            hasNewImg = True
        End If
    End Sub

    Private Sub btnSavepic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavepic.Click
        If Me.SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Me.pic_Logo.Image.Save(Me.SaveFileDialog1.FileName)
        End If
    End Sub

    'Private Sub btnBrowseTP_Click(sender As Object, e As EventArgs) Handles btnBrowseTP.Click
    '    If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
    '        Me.pic_TPCert.Image = System.Drawing.Image.FromFile(Me.OpenFileDialog1.FileName)
    '        Me.rePicsize(Me.pic_TPCert, 0)
    '        hasNewImg = True
    '    End If
    'End Sub

    '    Private Sub btnSaveTP_Click(sender As Object, e As EventArgs) Handles btnSaveTP.Click
    '        If Me.SaveFileDialog1.ShowDialog = DialogResult.OK Then
    '            Me.pic_TPCert.Image.Save(Me.SaveFileDialog1.FileName)
    '        End If
    '    End Sub

End Class