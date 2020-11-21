Imports Infragistics.Win.UltraWinGrid
Imports risersoft.app.mxform.college
Imports risersoft.app.mxform.edu
Imports risersoft.app2.shared
Imports risersoft.shared.cloud
Imports System.Collections.Generic
Public Class frmPayPeriod
    Inherits frmMax2
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridHolidays)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmPayPeriodModel = Me.InitData("frmPayPeriodModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "rm", "", Me.cmb_RateMasterID)
            myWinSQL.AssignCmb(Me.dsCombo, "PostPeriod", "", Me.cmb_PostPeriodID)

            If myUtils.cStrTN(myRow("PayPeriodName")).Trim.Length = 0 Then myRow("PayPeriodName") = Format(myRow("SDate"), "MMMM") & "-" & Format(myRow("EDate"), "yyyy")
            If myUtils.cBoolTN(myRow("isFinal")) Then
                Me.UltraPanel4.Enabled = False
            End If

            btn_importattend.Visible = EnumfrmMode.acAddM

        End If
        Me.FormPrepared = True
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Holiday"), Me.btnAddHoliday, Me.btnDelHoliday)
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        Dim objProc As clsProcOutput = Nothing
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

    Private Async Sub btn_importattend_Click(sender As Object, e As EventArgs) Handles btn_importattend.Click
        Dim oProc As New clsTaskExecutor(Me.Controller)
        Dim r As DataRow = myCollegeFuncs.rTask(Me.Controller, "UP", "PunchFile")
        If Not IsNothing(r) Then
            Dim oRet = Await oProc.ExecuteSched(r("DBSchedTaskID"), New List(Of clsSQLParam))
        End If
    End Sub

    Private Async Sub btnImportStudent_Click(sender As Object, e As EventArgs) Handles btnImportStudent.Click
        Dim oProc As New clsTaskExecutor(Me.Controller)
        Dim r As DataRow = myCollegeFuncs.rTask(Me.Controller, "UP", "Stu")
        If Not IsNothing(r) Then
            Dim oRet = Await oProc.ExecuteSched(r("DBSchedTaskID"), New List(Of clsSQLParam))
            MsgBox(oRet.Message, MsgBoxStyle.DefaultButton1, myWinApp.Vars("appname"))
        End If
    End Sub
End Class