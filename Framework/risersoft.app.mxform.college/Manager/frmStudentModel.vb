Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmStudentModel
    Inherits clsFormDataModel
    Dim myViewStuSub As clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("StuPaper")
        myViewStuSub = Me.GetViewModel("StuSubject")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String

        sql = "select ShiftId, Shift from Shift order by Shift"
        Me.AddLookupField("ShiftId", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Shift").TableName)

        Dim vlist As New clsValueList
        vlist.Add(False, "Disabled")
        vlist.Add(True, "Enabled")
        Me.ValueLists.Add("EnableList", vlist)
        Me.AddLookupField("PunchEnabled", "EnableList")

        sql = "Select distinct ListNumber from Student where ListNumber is Not Null"
        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
        Me.ValueLists.Add("ListNumber", myContext.SQL.VListFromTable(dt))
        Me.AddLookupField("ListNumber", "ListNumber")

        sql = myCollegeFuncs.CodeWordSQL("Student", "Category", "", "Tag")
        Me.AddLookupField("AdmittedAs", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "AdmittedAs").TableName)

        sql = myCollegeFuncs.CodeWordSQL("Admission", "Type", "", "Tag")
        Me.AddLookupField("AdmissionType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "AdmissionType").TableName)

        sql = myCollegeFuncs.CodeWordSQL("Student", "StudentType", "", "Tag")
        Me.AddLookupField("StudentType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "StudentType").TableName)

        sql = myCollegeFuncs.CodeWordSQL("Subject", "Group", "", "Tag")
        Me.AddLookupField("SubjectGroup", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "SubGroup").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql As String, oMasterData As New clsMasterDataHRP(myContext)
        Dim ds As DataSet

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select *, 0 as CompanyID from Student where StudentID = " & prepIDX
        Me.InitData(sql, "PersonId", oView, prepMode, prepIDX, strXML)

        Dim dic As New clsCollecString(Of String)
        dic.Add("FullName", "select Fullname, CompanyID from Persons where PersonId =" & myUtils.cValTN(myRow("PersonId")))
        dic.Add("StudentID", "select StudentID From Student where LeaveDate is null and PersonId = " & myUtils.cValTN(myRow("PersonId")))
        ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        If ds.Tables(0).Rows.Count = 0 Then Me.AddError("SerialNo", "Person not found") Else Me.ModelParams.Add(New clsSQLParam("@Name", "" & ds.Tables(0).Rows(0)("FullName") & "", GetType(String), False))
        If (ds.Tables(1).Rows.Count > 0) AndAlso (frmMode = EnumfrmMode.acAddM) Then Me.AddError("SerialNo", "This person is already added as an Student")

        Me.BindDataTable(myUtils.cValTN(prepIDX))

        myView.MainGrid.BindGridData(Me.dsForm, 1)
        myView.MainGrid.QuickConf("", True, "1.3-1.3-1.3-2-1-1.2-1.2-1.2-.8-.8-.8-.8", True)
        sql = "Select CodeWord, DescripShort from CodeWords where CodeClass = 'Student' and CodeType = 'StudentType' order by Tag"
        Dim str1 As String = "<BAND INDEX=""0"" TABLE=""StuPaper"" IDFIELD=""StuPaperID"" ><COL KEY=""PaperID, SubjectID, StudentID, Division, IsBack, IsAbsent""/><COL KEY=""StudentType"" CAPTION=""Student Type"" LOOKUPSQL=""" & sql & """/><COL KEY=""IsPassed"" CAPTION=""Result"" VLIST=""False;Failed|True;Passed""/><COL KEY=""FormNum"" CAPTION=""Form No""/><COL KEY=""ExamRollNum"" CAPTION=""Exam Roll No""/><COL KEY=""MaxMarks"" NOEDIT=""TRUE"" CAPTION=""Max Marks""/><COL KEY=""MinMarks"" NOEDIT=""TRUE"" CAPTION=""Min Marks""/><COL KEY=""MarksObtained"" CAPTION=""Marks Obtained""/><COL KEY=""SubjectName"" NOEDIT=""TRUE"" CAPTION=""Subject Name""/><COL KEY=""PaperCode"" NOEDIT=""TRUE"" CAPTION=""Paper Code""/></BAND> "
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        myViewStuSub.MainGrid.BindGridData(Me.dsForm, 2)
        myViewStuSub.MainGrid.QuickConf("", True, "2-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""StuSubject"" IDFIELD=""StuSubjectID"" ><COL KEY=""StuSubjectID, SubjectID, StudentID, Section""/><COL KEY=""SubjectName"" CAPTION=""Subject Name""/></BAND> "
        myViewStuSub.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        sql = $"select CampusID, DispName from Campus where CompanyID = {ds.Tables(0).Rows(0)("CompanyId")} order by DispName"
        Me.AddLookupField("CampusID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "campus").TableName)

        Dim str3 As String = myUtils.CombineWhere(True, myContext.AppModel.strFilterDBAppUser(myContext, Me.fRow, "CompanyID"))
        sql = "Select ClassID, ClassName from Class " & str3 & " Order by ClassName"
        Me.AddLookupField("ClassID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Class").TableName)

        Me.FormPrepared = True
        Return Me.FormPrepared
    End Function

    Private Sub BindDataTable(ByVal StudentID As Integer)
        Dim dic As New clsCollecString(Of String)
        dic.Add("StuPaper", "Select StuPaperID, PaperID, SubjectID, StudentID, FormNum, ExamRollNum, StudentType, SubjectName, PaperCode, MaxMarks, MinMarks, MarksObtained, Division, IsBack, IsAbsent, IsPassed  from clgListStuPaperView Where StudentID = " & StudentID)
        dic.Add("StuSubject", "Select StuSubjectID, SubjectID, StudentID, SubjectName, Section  from clgListStuSubjectView Where StudentID = " & StudentID)

        Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        For Each dt1 As DataTable In ds.Tables
            myUtils.AddTable(Me.dsForm, dt1, dt1.TableName)
        Next
    End Sub

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If Me.SelectedRow("CampusId") Is Nothing Then Me.AddError("CampusId", "Select Campus")
        If Me.SelectedRow("shiftid") Is Nothing Then Me.AddError("shiftid", "Select Shift")
        If Me.SelectedRow("ClassID") Is Nothing Then Me.AddError("ClassID", "Select Class")

        If (myUtils.cStrTN(myRow("RollNum")).Trim.Length = 0) Then Me.AddError("RollNum", "Enter Roll Number")
        If (myUtils.cStrTN(myRow("RegistrationNum")).Trim.Length = 0) Then Me.AddError("RegistrationNum", "Enter Registration No.")
        If Me.SelectedRow("AdmittedAs") Is Nothing Then Me.AddError("AdmittedAs", "Select Admitted As")
        If Me.SelectedRow("AdmissionType") Is Nothing Then Me.AddError("AdmissionType", "Select Admission Type")
        If Me.SelectedRow("SubjectGroup") Is Nothing Then Me.AddError("SubjectGroup", "Select Subject Group")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim oMasterData As New clsMasterDataHRP(myContext), objLM As New clsLeaveBase(myContext), objProc As New clsProcOutput
        VSave = False

        If Me.Validate Then
            Dim sql As String = "select * from Student where PersonId  <>  " & myUtils.cValTN(myRow("PersonId")) & " and SerialNo = '" & myUtils.cStrTN(myRow("SerialNo")) & "' and (onrolls=1)"
            Dim dt1 As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
            If dt1.Select.Length > 0 Then Me.AddError("", "Serial No. already exists")

            sql = "select StudentID,AdmissionDate,LeaveDate from Student where StudentID = " & frmIDX
            dt1 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
            If (dt1.Rows.Count > 0) AndAlso myUtils.cStrTN(myRow("AdmissionDate")) <> myUtils.cStrTN(dt1.Rows(0)("AdmissionDate")) Then

                If myRow("ClassID") > 0 Then
                    Dim CompanyID As Integer = myCollegeFuncs.GetInstitutionIDFromClass(myContext, myUtils.cValTN(myRow("ClassID")))
                    Dim r As DataRow = If(myUtils.NullNot(myRow("AdmissionDate")), Nothing, myCollegeFuncs.PPRow(myContext, CompanyID, myRow("AdmissionDate")))
                    Dim r1 As DataRow = If(myUtils.NullNot(dt1.Rows(0)("AdmissionDate")), Nothing, myCollegeFuncs.PPRow(myContext, CompanyID, dt1.Rows(0)("AdmissionDate")))

                    If (r IsNot Nothing AndAlso myUtils.cValTN(r("IsFinal")) = 1) OrElse (r1 IsNot Nothing AndAlso myUtils.cValTN(r1("IsFinal")) = 1) Then
                        Me.AddError("", "Admission Date Cannot be changed as Payperiod is already finalized")
                    End If
                End If
            End If

            If Me.CanSave Then
                Dim Sql1 As String = "Select PersonID, FullName from Persons where PersonID = " & myUtils.cValTN(myRow("PersonID"))
                Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql1)
                myRow("SortIndex") = myUtils.cValTN(myRow("RollNum"))
                Dim StuDescrip As String = " SerialNo: " & myRow("SerialNo").ToString & ", Name: " & myUtils.cStrTN(ds.Tables(0).Rows(0)("FullName"))
                Try
                    myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "StudentID", frmIDX)
                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                    frmIDX = myRow("StudentID")

                    myUtils.ChangeAll(dsForm.Tables("StuPaper").Select, "StudentID=" & frmIDX)
                    myContext.Provider.objSQLHelper.SaveResults(dsForm.Tables("StuPaper"), "Select StuPaperID, PaperID, StudentID, FormNum, ExamRollNum, StudentType, MarksObtained, Division, IsBack, IsAbsent, IsPassed from StuPaper")

                    myUtils.ChangeAll(dsForm.Tables("StuSubject").Select, "StudentID=" & frmIDX)
                    myContext.Provider.objSQLHelper.SaveResults(dsForm.Tables("StuSubject"), "Select StuSubjectID, SubjectID, StudentID, Section from StuSubject")

                    frmMode = EnumfrmMode.acEditM
                    myContext.Provider.dbConn.CommitTransaction(StuDescrip, frmIDX)
                    VSave = True
                Catch e As Exception
                    myContext.Provider.dbConn.RollBackTransaction(StuDescrip, e.Message)
                    Me.AddException("", e)
                End Try
            End If
        End If
        Return VSave
    End Function

    Public Overrides Function GenerateParamsModel(vwState As clsViewState, SelectionKey As String, Params As List(Of clsSQLParam)) As clsViewModel
        Dim Model As clsViewModel = Nothing
        Model = New clsViewModel(vwState, myContext)
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Select Case SelectionKey.Trim.ToLower
                Case "paper"
                    Model.Mode = EnumViewMode.acSelectM : Model.MultiSelect = True
                    Dim sql1 As String = myContext.SQL.PopulateSQLParams("SubjectID in (@SubjectID) and PaperID Not in (@PaperID)", Params)
                    Dim Sql As String = "SELECT PaperID, SubjectName, PaperCode, MaxMarks, MinMarks  From clgListPaperView where " & sql1 & " Order by PaperCode"
                    Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql)
                    Model.MainGrid.BindGridData(ds, 0)
                    Model.MainGrid.QuickConf("", True, "2-1-1-1")
                Case "subject"
                    Model.Mode = EnumViewMode.acSelectM : Model.MultiSelect = True
                    Dim sql1 As String = myContext.SQL.PopulateSQLParams("ClassID = (@ClassID) and SubjectID Not in (@SubjectID) ", Params)
                    Dim Sql As String = "SELECT SubjectID, SubjectName  From Subject where " & sql1 & " Order by SubjectName"
                    Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql)
                    Model.MainGrid.BindGridData(ds, 0)
                    Model.MainGrid.QuickConf("", True, "1")
            End Select
        End If
        Return Model
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "student"
                        Dim sql As String = "Select * from Student Where StudentID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from Student where StudentID =" & ID
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
