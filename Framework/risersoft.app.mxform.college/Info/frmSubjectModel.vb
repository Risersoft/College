Imports risersoft.shared
Imports System.Runtime.Serialization

<DataContract>
Public Class frmSubjectModel
    Inherits clsFormDataModel
    Dim Sql As String
    Dim myViewTimeTable As clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Paper")
        myViewTimeTable = Me.GetViewModel("TimeTable")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        Dim vlist1 As New clsValueList
        vlist1.Add("Hindi", "Hindi")
        vlist1.Add("English", "English")
        Me.ValueLists.Add("Language", vlist1)
        Me.AddLookupField("Language", "Language")

        Dim vlist4 As New clsValueList
        vlist4.Add("Compulsory Subjects", "Compulsory Subjects")
        vlist4.Add("School Teaching Subjects", "School Teaching Subjects")
        vlist4.Add("Practical", "Practical")
        Me.ValueLists.Add("Category", vlist4)
        Me.AddLookupField("Category", "Category")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        Sql = "select * from Subject where SubjectID = " & prepIDX
        Me.InitData(Sql, "", oView, prepMode, prepIDX, strXML)

        Dim str2 As String = myUtils.CombineWhere(True, myContext.AppModel.strFilterDBAppUser(myContext, Me.fRow, "CompanyID"))
        Sql = "Select deptid, deptname from department " & str2 & " order by deptname"
        Me.AddLookupField("deptid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "dept").TableName)

        Me.BindDataTable(myUtils.cValTN(prepIDX))

        myView.MainGrid.BindGridData(Me.dsForm, 1)
        myView.MainGrid.QuickConf("", True, "1-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""Paper"" IDFIELD=""PaperID"" ><COL KEY=""PaperID, SubjectID""/><COL KEY=""PaperCode"" CAPTION=""Paper Code""/><COL KEY=""PaperName"" CAPTION=""Paper Name""/><COL KEY=""MaxMarks"" CAPTION=""Max Marks""/><COL KEY=""MinMarks"" CAPTION=""Min Marks""/></BAND> "
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        myViewTimeTable.MainGrid.BindGridData(Me.dsForm, 2)
        myViewTimeTable.MainGrid.QuickConf("", True, "2-1-1-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""TimeTable"" IDFIELD=""TimeTableID""><COL KEY=""SubjectID,Days,Period,Time,RoomNo,Section,TeacherPersonID""/><COL KEY=""FullName"" NOEDIT=""TRUE"" CAPTION = ""Teacher""/><COL KEY=""TeacherPersonID"" LOOKUPSQL=""select PersonID,FullName from Persons"" CAPTION=""Teacher Person""/></BAND>"
        myViewTimeTable.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        Dim str3 As String = myUtils.CombineWhere(True, myContext.AppModel.strFilterDBAppUser(myContext, Me.fRow, "CompanyID"))
        Sql = "Select ClassID, ClassName from Class " & str3 & " Order by ClassName"
        Me.AddLookupField("ClassID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "Class").TableName)

        Me.FormPrepared = True
        Return Me.FormPrepared
    End Function

    Private Sub BindDataTable(ByVal SubjectID As Integer)
        Dim dic As New clsCollecString(Of String)
        dic.Add("Paper", "Select PaperID, SubjectID, PaperCode, PaperName, MaxMarks, MinMarks from Paper  Where SubjectID = " & SubjectID)
        dic.Add("TimeTable", "Select TimeTableID,SubjectID,TeacherPersonID,FullName,Days,Period,Time,RoomNo,Section from ClgListTimeTableView where SubjectID = " & SubjectID)

        Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        For Each dt1 As DataTable In ds.Tables
            myUtils.AddTable(Me.dsForm, dt1, dt1.TableName)
        Next
    End Sub

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("SubjectName")).Trim.Length = 0 Then Me.AddError("SubjectName", "Please Enter Subject Name")
        If Me.SelectedRow("DeptID") Is Nothing Then Me.AddError("DeptID", "Please Select Department")
        If Me.SelectedRow("ClassID") Is Nothing Then Me.AddError("ClassID", "Please Select Class")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim SubjectDescrip As String = myUtils.cStrTN(myRow("SubjectName"))

            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "Subjectid", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("Subjectid")

                myUtils.ChangeAll(dsForm.Tables("Paper").Select, "SubjectID=" & frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(dsForm.Tables("Paper"), "Select PaperID, SubjectID, PaperCode,PaperName,MaxMarks, MinMarks from Paper")

                myUtils.ChangeAll(dsForm.Tables("TimeTable").Select, "SubjectID=" & frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(dsForm.Tables("TimeTable"), "Select TimeTableID,SubjectID,TeacherPersonID,Days,Period,Time,RoomNo,Section from TimeTable")

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(SubjectDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(SubjectDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If
    End Function

    Public Overrides Function GenerateParamsModel(vwState As clsViewState, SelectionKey As String, Params As List(Of clsSQLParam)) As clsViewModel
        Dim Model As clsViewModel = Nothing
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Select Case SelectionKey.Trim.ToLower
                Case "timetable"
                    Model = myContext.Provider.GenerateSelectionModel(vwState, "<SYS ID=""PersonID""/>", True)
            End Select
        End If
        Return Model
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "subject"
                        Dim sqlSubject As String = "Select * from TimeTable where SubjectID =" & ID
                        Dim dtSubject As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sqlSubject).Tables(0)

                        If dtSubject.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from TimeTable where SubjectID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)
                        End If

                        Dim sql As String = "Select * from Subject Where SubjectID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from Subject where SubjectID =" & ID
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
