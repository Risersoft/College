Imports risersoft.app.mxform.college
Imports System.Collections.Generic
Imports System.Configuration

Public Class frmCommittee
    Inherits frmMax
    Dim oSort As clsWinSort

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridMember)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
        oSort = New clsWinSort(myView, Me.btnMoveup, Me.btnMoveDown, btnRenumber, "rank")
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmCommitteeModel = Me.InitData("frmCommitteeModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then
            oSort.renumber()

            Me.CtlRTFDescrip.HTMLText = myUtils.cStrTN(myRow("Descriptionhtml"))

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            Me.cmb_Name.ValueList = Me.Model.ValueLists("Name").ComboList
            myView.PrepEdit(Me.Model.GridViews("Member"),, btnDelMember)


            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        cm.EndCurrentEdit()
        If Me.ValidateData() Then
            myRow("Descriptionhtml") = Me.CtlRTFDescrip.HTMLText
            myRow("Descriptiontext") = Me.CtlRTFDescrip.PlainText
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btnAddMember_Click(sender As Object, e As EventArgs) Handles btnAddMember.Click
        AdvanceSelect()
        oSort.renumber()
    End Sub

    Private Sub AdvanceSelect()
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@CommitteeID", frmIDX, GetType(Integer), False))
        Dim rr() As DataRow = Me.AdvancedSelect("committeemember", Params)
        If (Not rr Is Nothing) AndAlso (rr.Length > 0) Then
            For Each r1 As DataRow In rr
                Dim r2 As DataRow = myUtils.CopyOneRow(r1, myView.mainGrid.myDS.Tables(0))
            Next
        End If
    End Sub

End Class