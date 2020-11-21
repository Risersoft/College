Imports risersoft.app.mxent
Imports risersoft.app.mxform.college

Public Class frmCampus
    Inherits frmMax
    Dim dvType, dvState As DataView

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmCampusModel = Me.InitData("frmCampusModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            If frmMode = EnumfrmMode.acAddM AndAlso dvType.Count = 1 Then myRow("CampusType") = dvType(0)("CodeWord")
            If frmMode = EnumfrmMode.acAddM Then myRow("HasPunches") = 1
            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "CO", "", Me.cmb_SelCountry, "<STRWIDTH>0-0-1-3</STRWIDTH>")
            dvState = myWinSQL.AssignCmb(Me.dsCombo, "SU", "", Me.cmb_SelState, "<STRWIDTH>0-0-0-1-3</STRWIDTH>", 2)
            dvState.RowFilter = ""
            dvType = myWinSQL.AssignCmb(Me.dsCombo, "CampusType", "", Me.cmb_CampusType, , 2)
            myWinSQL.AssignCmb(Me.dsCombo, "TaxAreaCode", "", Me.cmb_TaxAreaID)

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        cm.EndCurrentEdit()
        If Me.ValidateData() Then
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub cmb_SelCountry_ValueChanged(sender As Object, e As EventArgs) Handles cmb_SelCountry.ValueChanged
        If Me.FormPrepared Then
            Dim str1 As String = ""
            If Not Me.cmb_SelCountry.SelectedRow Is Nothing Then str1 = Me.cmb_SelCountry.SelectedRow.Cells("countrycode").Value
            dvState.RowFilter = "CountryCode='" & str1 & "'"
        End If
    End Sub

    Private Sub btnCopyAdd_Click(sender As Object, e As EventArgs) Handles btnCopyAdd.Click
        cm.EndCurrentEdit()
        Dim rCompany As DataRow = Me.Controller.CommonData.rCompany(myUtils.cValTN(myRow("CompanyId")), True)
        myFuncsBase.CopyAdd(Me.Controller, rCompany, myRow.Row)
    End Sub
End Class