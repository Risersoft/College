Imports risersoft.app.mxform.college
Public Class frmRegistration
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(,, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmRegistrationModel = Me.InitData("frmRegistrationModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            Dim dt As DataTable = Me.Model.DatasetCollection("Set").Tables("Student")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.txt_FatherName.Text = myUtils.cStrTN(dt.Rows(0)("FatherName"))
                Me.txt_FullName.Text = myUtils.cStrTN(dt.Rows(0)("FullName"))
                Me.txt_SubjectGroup.Text = myUtils.cStrTN(dt.Rows(0)("SubjectGroup"))
                Me.txt_Course.Text = myUtils.cStrTN(dt.Rows(0)("Course"))
            End If

            Dim dt1 As DataTable = Me.Model.DatasetCollection("Set").Tables("Event")
            If Not dt1 Is Nothing AndAlso dt1.Rows.Count > 0 Then
                Me.txt_EventName.Text = myUtils.cStrTN(dt1.Rows(0)("EventName"))
                txt_Name.Visible = False
            End If

            Dim dt2 As DataTable = Me.Model.DatasetCollection("Set").Tables("Activity")
            If Not dt2 Is Nothing AndAlso dt2.Rows.Count > 0 Then
                Me.txt_Name.Text = myUtils.cStrTN(dt2.Rows(0)("Name"))
                txt_EventName.Visible = False
            End If

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

End Class