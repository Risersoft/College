Imports risersoft.app.shared

Public Class FrmNewStudent
    Inherits frmMax
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overloads Function BindModel(NewModel As clsFormDataModel) As Boolean
        myWinSQL.AssignCmb(NewModel.dsCombo, "Campus", "", Me.cmb_campusid)
        myWinSQL.AssignCmb(NewModel.dsCombo, "Class", "", Me.cmb_ClassID)
        myWinSQL.AssignCmb(NewModel.dsCombo, "Shift", "", Me.cmb_shiftid)

        Me.cmb_ListNumber.ValueList = NewModel.ValueLists("ListNumber").ComboList
        myWinSQL.AssignCmb(NewModel.dsCombo, "AdmittedAs", "", Me.cmb_AdmittedAs)
        myWinSQL.AssignCmb(NewModel.dsCombo, "AdmissionType", "", Me.cmb_AdmissionType)
        myWinSQL.AssignCmb(NewModel.dsCombo, "SubGroup", "", Me.cmb_SubjectGroup)
        Return True
    End Function

    Public Overrides Function PrepFormRow(ByVal r1 As DataRow) As Boolean
        Me.FormPrepared = False
        If Me.BindData(r1) Then
            If frmMode = EnumfrmMode.acAddM Then If cmb_campusid.Rows.Count = 1 Then myRow("CampusId") = myUtils.cValTN(cmb_campusid.Rows(0).Cells("CampusId").Value)
            If frmMode = EnumfrmMode.acAddM Then If cmb_shiftid.Rows.Count = 1 Then myRow("ShiftId") = myUtils.cValTN(cmb_shiftid.Rows(0).Cells("ShiftId").Value)

            WinFormUtils.Prep2Form(Me)
            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function VSave() As Boolean
        Dim str As String = ""
        Me.InitError()
        VSave = False
        If myUtils.NullNot(Me.cmb_ClassID.Value) Then WinFormUtils.AddError(Me.cmb_ClassID, "Select Class Name")
        If myUtils.NullNot(Me.cmb_campusid.Value) Then WinFormUtils.AddError(Me.cmb_campusid, "Select Campus Name")
        If myUtils.NullNot(Me.cmb_shiftid.Value) Then WinFormUtils.AddError(Me.cmb_shiftid, "Select Shift")

        If myUtils.NullNot(Me.cmb_AdmittedAs.Value) Then WinFormUtils.AddError(Me.cmb_AdmittedAs, "Select Admitted As")
        If myUtils.NullNot(Me.cmb_AdmissionType.Value) Then WinFormUtils.AddError(Me.cmb_AdmissionType, "Select Admission Type")
        If myUtils.NullNot(Me.cmb_SubjectGroup.Value) Then WinFormUtils.AddError(Me.cmb_SubjectGroup, "Select Subject Group")
        If myUtils.NullNot(txt_RegistrationNum.Value) Then WinFormUtils.AddError(txt_RegistrationNum, "Select Registration No.")

        If Me.CanSave Then
            cm.EndCurrentEdit()
            VSave = True
        End If
    End Function
End Class