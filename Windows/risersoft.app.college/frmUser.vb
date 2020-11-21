Imports risersoft.app.mxform.college
Imports risersoft.app.mxform.edu

Public Class frmUser
    Inherits frmMax
    Dim myVueGroup As New clsWinView

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridUserAccount)
        myVueGroup.SetGrid(Me.UltraGridGroup)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmUserModel = Me.InitData("frmUserModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Account"), Me.btnAddAcc, Me.btnDelAcc)
            myVueGroup.PrepEdit(Me.Model.GridViews("Group"), Me.btnAddGroup, Me.btnDelGroup)
            myWinSQL.AssignCmb(Me.dsCombo, "Authentication", "", Me.cmb_AuthenticationProviderId)
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
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
End Class