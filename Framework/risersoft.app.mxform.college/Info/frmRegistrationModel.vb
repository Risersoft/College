Imports risersoft.app.mxengg
Imports risersoft.shared
Imports System.Runtime.Serialization

<DataContract>
Public Class frmRegistrationModel
    Inherits clsFormDataModel
    Dim Sql As String

    Protected Overrides Sub InitViews()
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then
            prepIDX = 0
            Me.vBag = Me.PrepVBag(strXML, oView.ContextRow, "EventID,ActivityID")
            Sql = "Select * from RegisterDetail where StudentID = " & myContext.AppModel.MyEmpID & " and EventID = " & myUtils.cValTN(Me.vBag("EventID")) & " or ActivityID = " & myUtils.cValTN(Me.vBag("ActivityID")) & ""
        Else
            Sql = "Select * from RegisterDetail where RegisterDetailID = " & prepIDX

        End If
        Me.InitData(Sql, "EventID,ActivityID", oView, prepMode, prepIDX, strXML, "", "", True)

        dic.Add("Student", "Select * from ClglistStudentView where StudentID = " & myContext.AppModel.MyEmpID & "")
        dic.Add("Event", "Select EventName from EventDetail where EventID = " & myUtils.cValTN(myRow("EventID")) & "")
        dic.Add("Activity", "Select Name from Activity where ActivityID = " & myUtils.cValTN(myRow("ActivityID")) & "")
        Me.AddDataSet("Set", dic)

        myRow("Dated") = Now.Date
        myRow("StudentID") = myContext.AppModel.MyEmpID

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then

            Dim RegistrationDescrip As String = myUtils.cStrTN(myRow("Dated"))

            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "RegisterDetailID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("RegisterDetailID")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(RegistrationDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(RegistrationDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If
        Return VSave
    End Function

End Class
