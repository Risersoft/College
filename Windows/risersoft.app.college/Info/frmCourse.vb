Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports risersoft.app.mxform.college
Public Class frmCourse
    Inherits frmMax

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridClass)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmCourseModel = Me.InitData("frmCourseModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then


            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            Me.cmb_CourseType.ValueList = Me.Model.ValueLists("CourseType").ComboList
            Me.cmb_DurationMonth.ValueList = Me.Model.ValueLists("DurationMonth").ComboList
            Me.cmb_DurationYear.ValueList = Me.Model.ValueLists("DurationYear").ComboList

            myView.PrepEdit(Me.Model.GridViews("Class"))
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

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        myView.mainGrid.ButtonAction("add")
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If Not IsNothing(myView) Then
            myView.mainGrid.ButtonAction("del")
        End If
    End Sub
End Class