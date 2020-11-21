Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json

<DataContract>
Public Class frmCourseModel
    Inherits clsFormDataModel
    Dim Sql As String

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Class")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        Dim vlist1 As New clsValueList
        vlist1.Add("Government Aided", "Government Aided")
        vlist1.Add("Self Financed", "Self Financed")
        Me.ValueLists.Add("CourseType", vlist1)
        Me.AddLookupField("CourseType", "CourseType")

        Dim vlist2 As New clsValueList
        vlist2.Add(1, "1")
        vlist2.Add(2, "2")
        vlist2.Add(3, "3")
        vlist2.Add(4, "4")
        vlist2.Add(5, "5")
        Me.ValueLists.Add("DurationYear", vlist2)
        Me.AddLookupField("DurationYear", "DurationYear")

        Dim vlist3 As New clsValueList
        vlist3.Add(1, "1")
        vlist3.Add(2, "2")
        vlist3.Add(3, "3")
        vlist3.Add(4, "4")
        vlist3.Add(5, "5")
        vlist3.Add(6, "6")
        Me.ValueLists.Add("DurationMonth", vlist3)
        Me.AddLookupField("DurationMonth", "DurationMonth")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        Sql = "select * from DegreeCourse where DegreeCourseID = " & prepIDX
        Me.InitData(Sql, "CompanyID", oView, prepMode, prepIDX, strXML)


        Me.BindDataTable(myUtils.cValTN(prepIDX))

        myView.MainGrid.BindGridData(Me.dsForm, 1)
        myView.MainGrid.QuickConf("", True, "2-1-1-1", True)
        Dim str1 As String = "<BAND INDEX=""0"" TABLE=""Class"" IDFIELD=""ClassID"" ><COL KEY=""ClassID,CompanyID,DegreeCourseID,Year,Semester""/><COL KEY=""ClassName"" CAPTION=""Class Name""/><COL KEY=""ClassCode"" CAPTION=""Class Code""/></BAND> "
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        Me.FormPrepared = True
        Return Me.FormPrepared
    End Function

    Private Sub BindDataTable(ByVal CourseID As Integer)
        Dim dic As New clsCollecString(Of String)
        dic.Add("Class", "Select ClassID,CompanyID,DegreeCourseID,ClassName, ClassCode,Year, Semester from Class Where DegreeCourseID = " & CourseID)
        Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        myUtils.AddTable(Me.dsForm, ds, "Class", 0)
    End Sub

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("Course")).Trim.Length = 0 Then Me.AddError("Course", "Please Enter Course")
        If myUtils.cStrTN(myRow("MinQual")).Trim.Length = 0 Then Me.AddError("MinQual", "Please Enter Minimum Qualification")
        If myUtils.cStrTN(myRow("Seats")).Trim.Length = 0 Then Me.AddError("Seats", "Please Enter Seats")
        If myUtils.cStrTN(myRow("Fees")).Trim.Length = 0 Then Me.AddError("Fees", "Please Enter Fees Per Annum")
        'If Me.SelectedItem("DurationMonth") Is Nothing Then Me.AddError("DurationMonth", "Please Select Duration Month")
        If Me.SelectedItem("DurationYear") Is Nothing Then Me.AddError("DurationYear", "Please Select Duration Year")
        If Me.SelectedItem("CourseType") Is Nothing Then Me.AddError("CourseType", "Please Select Course Type")

        Return Me.CanSave
    End Function

    Public Overrides Function ValidateFormulaInjection(r1 As DataRow, col As DataColumn) As clsProcOutput
        If myUtils.IsInList(col.ColumnName, "Seats", "fees") Then
            Return New clsProcOutput
        Else
            Return MyBase.ValidateFormulaInjection(r1, col)
        End If
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim CourseDescrip As String = myUtils.cStrTN(myRow("Course"))
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "DegreeCourseID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("DegreeCourseID")

                myUtils.ChangeAll(dsForm.Tables("Class").Select, "DegreeCourseID=" & frmIDX)
                myUtils.ChangeAll(dsForm.Tables("Class").Select, "CompanyID=" & myRow("CompanyID"))
                myContext.Provider.objSQLHelper.SaveResults(dsForm.Tables("Class"), "Select ClassID,CompanyID,DegreeCourseID,ClassName, ClassCode,Year, Semester from Class")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(CourseDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(CourseDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If
        Return VSave
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "degreecourse"
                        Dim sql As String = "Select * from DegreeCourse Where DegreeCourseID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from Class where DegreeCourseID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)

                            Dim sql2 As String = "delete from DegreeCourse where DegreeCourseID =" & ID
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