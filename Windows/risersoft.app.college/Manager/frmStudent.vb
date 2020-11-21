Imports risersoft.app.mxform.college
Imports System.Collections.Generic

Public Class frmStudent
    Inherits frmMax
    Dim oRet As clsProcOutput = Nothing, myViewStuSub As New clsWinView

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridStuPaper)
        myViewStuSub.SetGrid(Me.UltraGridStuSubject)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmStudentModel = Me.InitData("frmStudentModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "campus", "", Me.cmb_campusid)
            myWinSQL.AssignCmb(Me.dsCombo, "Class", "", Me.cmb_ClassID)
            myWinSQL.AssignCmb(Me.dsCombo, "shift", "", Me.cmb_shiftid)
            Me.cmb_PunchEnabled.ValueList = Me.Model.ValueLists("EnableList").ComboList
            Me.lblName.Text = myUtils.cStrTN(myWinSQL2.ParamValue("@Name", Me.Model.ModelParams))

            Me.cmb_ListNumber.ValueList = Me.Model.ValueLists("ListNumber").ComboList
            myWinSQL.AssignCmb(Me.dsCombo, "AdmittedAs", "", Me.cmb_AdmittedAs)
            myWinSQL.AssignCmb(Me.dsCombo, "AdmissionType", "", Me.cmb_AdmissionType)

            myWinSQL.AssignCmb(Me.dsCombo, "SubGroup", "", Me.cmb_SubjectGroup)


            WinFormUtils.Prep2Form(Me)
            Me.FormPrepared = True
            If TypeOf pView.fParentWin Is frmStuPerson Then Me.btn_Person.Visible = False Else Me.btn_Person.Visible = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("StuPaper"))
            myViewStuSub.PrepEdit(Me.Model.GridViews("StuSubject"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError() : WinFormUtils.InitTabBacks(Me.UltraTabControl1)
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

    Private Sub btn_Person_Click(sender As Object, e As EventArgs) Handles btn_Person.Click
        Dim f As New frmStuPerson
        If f.PrepForm(myView, EnumfrmMode.acEditM, myUtils.cValTN(myRow("personid"))) Then WinFormUtils.CentreForm(f, Me.Owner)
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        If (Not myUtils.NullNot(cmb_ClassID.Value)) Then
            Dim Params As New List(Of clsSQLParam)

            Params.Add(New clsSQLParam("@PaperID", myUtils.MakeCSV(Me.myView.mainGrid.myDv.Table.Select, "PaperID"), GetType(Integer), True))
            Params.Add(New clsSQLParam("@SubjectID", myUtils.MakeCSV(Me.myViewStuSub.mainGrid.myDv.Table.Select, "SubjectID"), GetType(Integer), True))

            Dim rr() As DataRow = Me.AdvancedSelect("paper", Params)
            If Not rr Is Nothing AndAlso rr.Length > 0 Then
                For Each r1 As DataRow In rr
                    Dim r2 As DataRow = myUtils.CopyOneRow(r1, myView.mainGrid.myDv.Table)
                Next
            End If

            If myView.mainGrid.myDv.Table.Select.Length > 0 Then
                EnableControls(True)
            End If
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If Not IsNothing(myView) Then
            myView.mainGrid.ButtonAction("del")
        End If
    End Sub

    Private Sub btnAddSub_Click(sender As Object, e As EventArgs) Handles btnAddSub.Click
        If (Not myUtils.NullNot(cmb_ClassID.Value)) Then
            Dim Params As New List(Of clsSQLParam)

            Params.Add(New clsSQLParam("@ClassID", myUtils.cValTN(cmb_ClassID.Value), GetType(Integer), False))
            Params.Add(New clsSQLParam("@SubjectID", myUtils.MakeCSV(Me.myViewStuSub.mainGrid.myDv.Table.Select, "SubjectID"), GetType(Integer), True))

            Dim rr() As DataRow = Me.AdvancedSelect("subject", Params)
            If Not rr Is Nothing AndAlso rr.Length > 0 Then
                For Each r1 As DataRow In rr
                    Dim r2 As DataRow = myUtils.CopyOneRow(r1, myViewStuSub.mainGrid.myDv.Table)
                Next
            End If

            If myViewStuSub.mainGrid.myDv.Table.Select.Length > 0 Then
                EnableControls(True)
            End If
        End If
    End Sub

    Private Sub btnDelSub_Click(sender As Object, e As EventArgs) Handles btnDelSub.Click
        If Not IsNothing(myView) Then
            myViewStuSub.mainGrid.ButtonAction("del")
        End If
    End Sub

    Private Sub EnableControls(ByVal Bool As Boolean)

    End Sub
End Class

