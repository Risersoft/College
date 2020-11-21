Imports risersoft.app.mxent
Imports risersoft.app.mxform.edu
Imports Infragistics.Win.UltraWinGrid
Imports System.Collections.Generic
Imports risersoft.app.mxform.college

Public Class frmAttendStu
    Inherits frmMax

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridAttend)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmAttendStuModel = Me.InitData("frmAttendStuModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean

        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Att"))

            For Each gRow As UltraGridRow In myView.mainGrid.myGrid.Rows
                If myUtils.cBoolTN(gRow.Cells("isholiday").Value) Then
                    gRow.Appearance.BackColor = Color.LightGray
                End If
            Next

            Return True
        End If
        Return False
    End Function

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        If Me.VSave() Then
            Dim Params As New List(Of clsSQLParam)
            Dim payperiodid As Integer = Me.vBag("PayPeriodId")
            Params.Add(New clsSQLParam("@StudentID", myUtils.cValTN(myRow("StudentID")), GetType(Integer), False))
            Params.Add(New clsSQLParam("@PayPeriodId", myUtils.cValTN(Me.vBag("PayPeriodId")), GetType(Integer), False))
            Dim oRet As clsProcOutput = Me.GenerateParamsOutput("punch", Params)
            If oRet.Success Then
                Me.PrepForm(pView, frmMode, frmIDX, Me.Controller.Data.VarBagXML(Me.vBag))
            Else
                MsgBox(oRet.Message,, myWinApp.Vars("appname"))
            End If
        End If
    End Sub

    Public Overrides Function VSave() As Boolean
        Dim objAttend As New clsAttendanceCalc(Me.Controller)
        Me.InitError()
        VSave = False

        myView.mainGrid.myGrid.UpdateData()
        For Each r1 As DataRow In myView.mainGrid.myDS.Tables(0).Select
            r1("attendidsh") = r1("attendidfh")
            objAttend.SetAttendanceStats(r1)
        Next

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



