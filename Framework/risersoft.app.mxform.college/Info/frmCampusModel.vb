Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization
Imports System.Text.RegularExpressions
Imports risersoft.app.mxform.college
Imports risersoft.app.mxengg

<DataContract>
Public Class frmCampusModel
    Inherits clsFormDataModel
    Dim dicSQL As New clsCollecString(Of String)

    Protected Overrides Sub InitViews()
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim ds As DataSet = myContext.CommonData.GetDatasetLocode(False).Copy
        Me.AddLookupField("SelCountry", myUtils.AddTable(Me.dsCombo, ds.Tables("CO"), "CO").TableName)
        Me.AddLookupField("SelState", myUtils.AddTable(Me.dsCombo, ds.Tables("SU"), "SU").TableName)

        Dim Sql As String = myFuncs.CodeWordSQL("Company", "CampusType", "")
        Me.AddLookupField("CampusType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "CampusType").TableName)

        Sql = "select TaxAreaID, Descrip, TaxAreaCode, TaxAreaCode2 from TaxArea Order by Descrip"
        Me.AddLookupField("TaxAreaID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "TaxAreaCode").TableName)
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim Sql As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        dicSQL.Add("Campus", "Select * from Campus where CampusID  = %frmIDX%")
        dicSQL.Add("Party", "Select * from party where PartyId in (Select PartyId from Campus where CampusID  = %frmIDX%)")
        Me.InitData(dicSQL, "CompanyId", oView, prepMode, prepIDX, strXML)

        Me.FormPrepared = True
        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("DispName")).Trim.Length = 0 Then Me.AddError("DispName", "Please Enter Display Name")
        If myUtils.cStrTN(myRow("SelAddress")).Trim.Length = 0 Then Me.AddError("SelAddress", "Please Enter Address")
        If Me.SelectedRow("SelCountry") Is Nothing Then Me.AddError("SelCountry", "Please Select Country")
        If Me.SelectedRow("SelState") Is Nothing Then Me.AddError("SelState", "Please Select State")
        If Me.SelectedRow("CampusType") Is Nothing Then Me.AddError("CampusType", "Please Select Campus Type")

        Return Me.CanSave
    End Function

    Private Function CheckGridColumn(dt As DataTable, ColumnName As String, Value As String, CheckValue As Boolean) As Boolean
        If CheckValue = True Then If myUtils.IsInList(Value, "") Then Return False
        Dim rr() As DataRow = dt.Select(ColumnName & " = '" & Value & "'")
        If rr.Length = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim ObjVouch As New clsVoucherNum(myContext)
            ObjVouch.GetNewSerialNo("PartyID", "A", myRow.Row)
            myRow("campuscode") = myRow("partycode")

            Dim rCompany As DataRow = myContext.CommonData.rCompany(myUtils.cValTN(myRow("CompanyId")), True)
            myRow("MainPartyID") = rCompany("MainPartyID")
            Dim CampusDescrip As String = " Code: " & myRow("CampusCode") & ", Name:" & myRow("DispName")

            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "CampusID", frmIDX)
                myRow("SelEmail") = "fromcampus"

                myFuncs.SetPartyNameAddress(rCompany, myRow.Row.Table, False)
                myContext.Data.SaveMulti(dicSQL, myRow.Row, frmIDX)
                frmIDX = myRow("CampusID")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(CampusDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(CampusDescrip, e.Message)
                Throw (e)
            End Try
        End If
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "campus"
                        Dim sql As String = "Select * from Campus Where CampusID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from Party where PartyID =" & dt.Rows(0)("PartyID").ToString()
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)

                            Dim sql2 As String = "delete from Campus where CampusID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql2)
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
