Imports risersoft.shared
Imports System.Runtime.Serialization

<DataContract>
Public Class frmAssetModel
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


        Sql = myFuncs.CodeWordSQL("Assets", "Type", "")
        Me.AddLookupField("Type", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "Type").TableName)

        Dim vlist2 As New clsValueList
        vlist2.Add("Working", "Working")
        vlist2.Add("Not Working", "Not Working")
        vlist2.Add("Disposed", "Disposed")
        Me.ValueLists.Add("Status", vlist2)
        Me.AddLookupField("Status", "Status")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        Sql = "select * from Assets where AssetID = " & prepIDX
        Me.InitData(Sql, "", oView, prepMode, prepIDX, strXML)

        Dim str2 As String = myUtils.CombineWhere(True, myContext.AppModel.strFilterDBAppUser(myContext, Me.fRow, "CompanyID"))
        Sql = "Select deptid, deptname from department " & str2 & " order by deptname"
        Me.AddLookupField("deptid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "dept").TableName)



        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("Item")).Trim.Length = 0 Then Me.AddError("Item", "Please Enter Item")
        If Me.SelectedRow("DeptID") Is Nothing Then Me.AddError("DeptID", "Please Select Department")
        If myUtils.cStrTN(myRow("Quantity")).Trim.Length = 0 Then Me.AddError("Quantity", "Please Enter Quantity")
        If Me.SelectedItem("Status") Is Nothing Then Me.AddError("Semester", "Please Select Status")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim AssetDescrip As String = myUtils.cStrTN(myRow("Item"))

            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "Assetid", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("Assetid")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(AssetDescrip, frmIDX)
                VSave = True

            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(AssetDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "assets"
                        Dim sql As String = "Select * from Assets Where AssetID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from Assets where AssetID =" & ID
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

