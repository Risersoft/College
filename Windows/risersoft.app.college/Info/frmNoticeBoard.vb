Imports risersoft.app.mxform.college
Public Class frmNoticeBoard
    Inherits frmMax
    Dim dvDept As DataView

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmNoticeBoardModel = Me.InitData("frmNoticeBoardModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            dvDept = myWinSQL.AssignCmb(Me.dsCombo, "dept", "", Me.cmb_Deptid,, 2)
            myWinSQL.AssignCmb(Me.dsCombo, "company", "", Me.cmb_CompanyID)

            Me.CtlRTFDescrip.HTMLText = myUtils.cStrTN(myRow("DescripHTML"))

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            myRow("DescripHTML") = Me.CtlRTFDescrip.HTMLText
            myRow("DescripText") = Me.CtlRTFDescrip.PlainText
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub cmb_CompanyID_Leave(sender As Object, e As EventArgs) Handles cmb_CompanyID.Leave, cmb_CompanyID.AfterCloseUp
        recalcDepCombo()
    End Sub

    Private Function recalcDepCombo() As Integer
        If Me.cmb_CompanyID.SelectedRow Is Nothing Then
            dvDept.RowFilter = "0=1"
        Else
            dvDept.RowFilter = "CompanyID=" & Me.cmb_CompanyID.SelectedRow.Cells("companyid").Value
        End If
    End Function

End Class
