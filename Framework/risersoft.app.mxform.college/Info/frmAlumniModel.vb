Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports System.Globalization
Imports risersoft.app.mxform.gst
Imports risersoft.app.mxform.college

<DataContract>
Public Class frmAlumniModel
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

        Dim vlist1 As New clsValueList
        vlist1.Add("Business", "Business")
        vlist1.Add("Service", "Service")
        vlist1.Add("Home Maker", "Home Maker")
        vlist1.Add("Others", "Others")
        Me.ValueLists.Add("JobProfile", vlist1)
        Me.AddLookupField("JobProfile", "JobProfile")


        Sql = "Select finyearid, descrip from finyears"
        Me.AddLookupField("finyearid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "finyears").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1 As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        Sql = "select * from Alumni where AlumniID = " & prepIDX
        Me.InitData(Sql, "CompanyID", oView, prepMode, prepIDX, strXML)

        Dim str2 As String = myUtils.CombineWhere(True, myContext.AppModel.strFilterDBAppUser(myContext, Me.fRow, "CompanyID"))
        Sql = "Select deptid, deptname from department " & str2 & " order by deptname"
        Me.AddLookupField("deptid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "dept").TableName)

        Sql = "Select DegreeCourseID, Course from DegreeCourse " & str2
        Me.AddLookupField("DegreeCourseID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "DegreeCourse").TableName)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("Name")).Trim.Length = 0 Then Me.AddError("Name", "Please Enter Name")
        If myUtils.cStrTN(myRow("ContactNo")).Trim.Length = 0 Then Me.AddError("ContactNo", "Please Enter Contact Number")
        'If myUtils.IsInList(myUtils.cStrTN(myRow("Subject1")), "B.A") AndAlso Me.SelectedRow("Subject1") Is Nothing Then Me.AddError("Subject1", "Please Enter First Subject")
        'If myUtils.IsInList(myUtils.cStrTN(myRow("Subject2")), "B.A") AndAlso Me.SelectedRow("Subject2") Is Nothing Then Me.AddError("Subject2", "Please Enter Second Subject")
        'If myUtils.IsInList(myUtils.cStrTN(myRow("Subject3")), "B.A") AndAlso Me.SelectedRow("Subject3") Is Nothing Then Me.AddError("Subject3", "Please Enter Third Subject")

        'If myUtils.cStrTN(myRow("Subject1")).Trim.Length = 0 Then Me.AddError("Subject1", "Please Enter PinCode")
        'If myUtils.cStrTN(myRow("Subject2")).Trim.Length = 0 Then Me.AddError("Subject1", "Please Enter PinCode")
        'If myUtils.cStrTN(myRow("Subject3")).Trim.Length = 0 Then Me.AddError("Subject1", "Please Enter PinCode")
        If Me.SelectedRow("DegreeCourseID") Is Nothing Then Me.AddError("DegreeCourseID", "Please Enter Course")
        'If myUtils.cStrTN(myRow("PinCode")).Trim.Length > 6 Then Me.AddError("PinCode", "Please Enter PinCode of 6 Digits only.")



        Return Me.CanSave
    End Function


    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim AlumniDescrip As String = myUtils.cStrTN(myRow("Name"))

            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "Alumniid", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("Alumniid")

                frmMode = EnumfrmMode.acEditM

                myContext.Provider.dbConn.CommitTransaction(AlumniDescrip, frmIDX)
                myContext.CommonData.Clear()
                VSave = True

            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(AlumniDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        oRet = myCollegeFuncs.GenerateCommonOutput(myContext, dataKey, Params, "alumniId")
        Return oRet
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "alumni"
                        Dim sql As String = "Select * from Alumni Where AlumniID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from Alumni where AlumniID =" & ID
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
