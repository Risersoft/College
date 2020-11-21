Imports risersoft.shared
Imports System.Runtime.Serialization

Public Class frmUserModel
    Inherits clsFormDataModel
    Dim myVueGroup As New clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Account")
        myVueGroup = Me.GetViewModel("Group")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String

        sql = "Select ID, Name from AuthenticationProvider"
        Me.AddLookupField("AuthenticationProviderID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Authentication").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql As String, str2 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = Guid.Empty.ToString
        sql = "Select * from Users Where ID = '" & prepIDX & "'"
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        If prepMode = EnumfrmMode.acAddM Then
            myRow("CreatedDate") = Now.Date
        End If

        sql = " Select ID,UserID,AccountID,UserTypeID,MembershipActivated,ActivationDate,DeActivationDate,ActivationKey from UserAccount Where UserId = '" & frmIDX & "'"
        myView.MainGrid.QuickConf(sql, True, "1-1-1-1-1-1", True)
        str2 = "<BAND INDEX = ""0"" TABLE = ""UserAccount"" IDFIELD=""ID""><COL KEY =""UserID,ActivationDate,DeActivationDate,ActivationKey""/><COL KEY=""AccountID"" LOOKUPSQL=""select ID, AccountName from Account order by AccountName"" CAPTION=""Account Name""/><COL KEY=""UserTypeId"" LOOKUPSQL=""select ID, Type from UserType order by Type"" CAPTION=""User Type""/><COL KEY=""MembershipActivated"" CAPTION=""Membership Activated"" VLIST=""0;False|1;True""/></BAND>"
        myView.MainGrid.PrepEdit(str2, EnumEditType.acCommandAndEdit)

        sql = " Select ID,UserID,GroupID,IsActive,ActivationDate from GroupMembership Where UserId = '" & frmIDX & "'"
        myVueGroup.MainGrid.QuickConf(sql, True, "1-1-1", True)
        str2 = "<BAND INDEX = ""0"" TABLE = ""GroupMembership"" IDFIELD=""ID""><COL KEY =""ActivationDate""/><COL KEY=""UserID"" LOOKUPSQL=""select ID, FullName from Users order by FullName"" CAPTION=""User Name""/><COL KEY=""IsActive"" CAPTION=""Active"" VLIST=""0;False|1;True""/><COL KEY=""GroupID"" LOOKUPSQL=""select ID, Name from Groups order by Name"" CAPTION=""Group Name""/></BAND>"
        myVueGroup.MainGrid.PrepEdit(str2, EnumEditType.acCommandAndEdit)

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
            If Me.CanSave Then
                Dim UserDescrip As String = myRow("FullName").ToString
                Try
                    If frmMode = EnumfrmMode.acAddM Then myRow("ID") = System.Guid.NewGuid.ToString
                    myContext.Provider.dbConn.BeginTransaction(myContext)
                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                    frmIDX = myRow("id").ToString

                    Me.myView.MainGrid.SaveChanges(, "userid=" & frmIDX)
                    Me.myVueGroup.MainGrid.SaveChanges(, "userid=" & frmIDX)
                    frmMode = EnumfrmMode.acEditM
                    myContext.Provider.dbConn.CommitTransaction(UserDescrip, frmIDX)
                    VSave = True

                Catch e As Exception
                    myContext.Provider.dbConn.RollBackTransaction(UserDescrip, e.Message)
                    Me.AddException("", e)

                End Try
            End If
        End If
    End Function

End Class
