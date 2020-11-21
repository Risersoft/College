Imports System.Collections.Generic
Imports risersoft.app.mxform.college
Public Class frmSubject
    Inherits frmMax
    Dim myViewTimeTable As New clsWinView

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridPaper)
        myViewTimeTable.SetGrid(Me.UltraGridTimeTable)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmSubjectModel = Me.InitData("frmSubjectModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            Me.cmb_Language.ValueList = Me.Model.ValueLists("Language").ComboList
            Me.cmb_Category.ValueList = Me.Model.ValueLists("Category").ComboList
            myWinSQL.AssignCmb(Me.dsCombo, "dept", "", Me.cmb_DeptID)
            myWinSQL.AssignCmb(Me.dsCombo, "Class", "", Me.cmb_ClassID)

            myView.PrepEdit(Me.Model.GridViews("Paper"))
            myViewTimeTable.PrepEdit(Me.Model.GridViews("TimeTable"))
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

    Private Sub btnAddTimeTable_Click(sender As Object, e As EventArgs) Handles btnAddTimeTable.Click
        Dim Params As New List(Of clsSQLParam)
        Dim rr() As DataRow = Me.AdvancedSelect("timetable", Params)
        If (Not rr Is Nothing) AndAlso (rr.Length > 0) Then
            For Each r1 As DataRow In rr
                Dim r2 As DataRow = myUtils.CopyOneRow(r1, myViewTimeTable.mainGrid.myDv.Table)
                r2("TeacherPersonID") = r1("PersonID")
            Next
        End If
    End Sub

    Private Sub btnDelTimeTable_Click(sender As Object, e As EventArgs) Handles btnDelTimeTable.Click
        If Not IsNothing(myView) Then
            myViewTimeTable.mainGrid.ButtonAction("del")
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        myView.mainGrid.ButtonAction("add")
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If Not IsNothing(myView) Then
            myView.mainGrid.ButtonAction("del")
        End If
    End Sub
End Class