Imports risersoft.shared
Imports System.Runtime.Serialization

<DataContract>
Public Class frmDepartmentModel
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
        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        Sql = "select * from Department where DeptID = " & prepIDX
        Me.InitData(Sql, "CompanyID", oView, prepMode, prepIDX, strXML)

        Sql = "Select personid, fullname from Persons where CompanyID = " & myUtils.cValTN(myRow("CompanyID")) & " order by fullname"
        Me.AddLookupField("HODPersonID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "HODPersonID").TableName)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("DeptName")).Trim.Length = 0 Then Me.AddError("DeptName", "Please Enter Department Name")
        If myUtils.cStrTN(myRow("DepCode")).Trim.Length = 0 Then Me.AddError("DepCode", "Please Enter Department Code")
        'If myUtils.cStrTN(myRow("EstabYear")).Trim.Length = 0 Then Me.AddError("EstabYear", "Please Enter Established Year")
        'If Me.SelectedRow("HODPersonID") Is Nothing Then Me.AddError("HODPersonID", "Please Select H.O.D Person")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim DeptDescrip As String = myUtils.cStrTN(myRow("DeptName"))

            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "Deptid", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("Deptid")

                frmMode = EnumfrmMode.acEditM

                myContext.Provider.dbConn.CommitTransaction(DeptDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(DeptDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "department"
                        Dim sql As String = "Select * from Department Where DeptID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from Department where DeptID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)
                        End If

                End Select
            ElseIf oRet.WarningCount = 0 Then
                oRet.AddWarning("Are you sure ?")
            End If
        Catch ex As Exception
            oRet.AddException(ex)
        End Try
        Return oRet
    End Function

End Class

