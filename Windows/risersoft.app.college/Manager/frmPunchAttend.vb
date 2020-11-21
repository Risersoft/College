Imports System.Collections.Generic
Imports risersoft.app.mxform.college
Imports risersoft.app.mxform.edu

Public Class frmPunchAttend
    Inherits frmMax

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Dim ds As DataSet
        Me.FormPrepared = False
        Dim objModel As frmPunchAttendModel = Me.InitData("frmPunchAttendModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "shift", "", Me.cmb_ShiftID)
            myWinSQL.AssignCmb(Me.dsCombo, "att", "", Me.cmb_attendidfh)
            myWinSQL.AssignCmb(Me.dsCombo, "att", "", Me.cmb_attendidsh)
            myWinSQL.AssignCmb(Me.dsCombo, "att", "", Me.cmb_attendidfhs)
            myWinSQL.AssignCmb(Me.dsCombo, "att", "", Me.cmb_attendidshs)

            ds = Me.Model.DatasetCollection("StuList")

            Me.lbl_SerialNo.Text = ds.Tables(0).Rows(0)("SerialNo")
            Me.lbl_ClassName.Text = ds.Tables(0).Rows(0)("ClassName")
            Me.lbl_FullName.Text = ds.Tables(0).Rows(0)("FullName")
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("PunchData"))
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

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        If Me.VSave() Then
            Dim Params As New List(Of clsSQLParam)
            Params.Add(New clsSQLParam("@dated", Format(myRow("dated"), "dd-MMM-yyyy"), GetType(DateTime), False))
            Params.Add(New clsSQLParam("@StudentID", myRow("StudentID"), GetType(Integer), False))
            Dim oRet As clsProcOutput = Me.GenerateParamsOutput("punch", Params)
            If oRet.Success Then
                Me.PrepForm(pView, frmMode, frmIDX, Me.Controller.Data.VarBagXML(Me.vBag))
            Else
                MsgBox(oRet.Message,, myWinApp.Vars("appname"))
            End If
        End If
    End Sub
End Class

