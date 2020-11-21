Imports risersoft.app.mxent
Imports risersoft.shared
Imports klts.app.mxform.admin.Mxcollegedb
Imports System.Data.Common
Imports System.Data.SqlClient
Imports risersoft.shared.dal
Imports AutoMapper
Imports risersoft.shared.cloud
Imports System.IO
Imports Newtonsoft.Json
Imports klts.app.mxform.admin

Public Class myCollegeFuncs
    Inherits myFuncsBase

    Public Sub ColorizeAttDayWise(ByVal oview As clsView, ByVal frmidx As String, ByVal e As clsRow)
        Dim gRow As clsRow = e
        If gRow.Columns.Contains("IsHoliday") Then
            If myUtils.cBoolTN(gRow.CellValue("IsHoliday")) Then
                gRow.BackColor = System.Drawing.Color.LightGray
            End If
        End If
    End Sub

    Public Shared Function GetInstitutionIDFromClass(context As IProviderContext, ClassID As Integer) As Integer
        Dim CompanyID As Integer
        Dim Sql As String = "Select CompanyID from Class where  ClassID = " & myUtils.cValTN(ClassID)
        Dim dt As DataTable = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If dt.Rows.Count > 0 Then CompanyID = myUtils.cValTN(dt.Rows(0)("CompanyID"))

        Return CompanyID
    End Function

    Public Shared Function GetInstitutionIDFromCampus(context As IProviderContext, CampusID As Integer) As Integer
        Dim CompanyID As Integer
        Dim Sql As String = "Select CompanyID from Campus where  CampusID = " & myUtils.cValTN(CampusID)
        Dim dt As DataTable = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If dt.Rows.Count > 0 Then CompanyID = myUtils.cValTN(dt.Rows(0)("CompanyID"))

        Return CompanyID
    End Function

    Public Shared Function rInstitute(context As IProviderContext, CompanyID As Integer) As DataRow
        Dim r1 As DataRow = Nothing
        Dim Sql As String = "Select * from Company where  CompanyID = " & myUtils.cValTN(CompanyID)
        Dim dt As DataTable = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If dt.Rows.Count > 0 Then r1 = dt.Rows(0)

        Return r1
    End Function

    Public Shared Function PPRow(context As IProviderContext, CompanyID As Integer, xDate As Date) As DataRow
        Dim r1 As DataRow = Nothing
        Dim Sql As String = "Select * from PayPeriod Inner Join RateMaster on PayPeriod.RateMasterID = RateMaster.RateMasterID where  PayPeriod.CompanyID = " & myUtils.cValTN(CompanyID) & " and SDate < = '" & Format(xDate, "yyyy-MMM-dd") & "' and EDate > = '" & Format(xDate, "yyyy-MMM-dd") & "'"
        Dim dt As DataTable = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If dt.Rows.Count > 0 Then r1 = dt.Rows(0)

        Return r1
    End Function

    Public Shared Function rRateMaster(context As IProviderContext, CompanyID As Integer, Dated As Date) As DataRow
        Dim r1 As DataRow = Nothing
        Dim Sql As String = "Select Top 1 * from RateMaster where  CompanyID = " & myUtils.cValTN(CompanyID) & " and Dated < = '" & Format(Dated, "yyyy-MMM-dd") & "' Order By Dated Desc"
        Dim dt As DataTable = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If dt.Rows.Count > 0 Then r1 = dt.Rows(0)

        Return r1
    End Function

    Public Shared Function rFinYear(context As IProviderContext, Dated As Date) As DataRow
        Dim r1 As DataRow = Nothing
        Dim Sql As String = "Select * from FinYears where StDate < = '" & Format(Dated, "yyyy-MMM-dd") & "' and EnDate > = '" & Format(Dated, "yyyy-MMM-dd") & "'"
        Dim dt As DataTable = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If dt.Rows.Count > 0 Then r1 = dt.Rows(0)

        Return r1
    End Function

    Public Shared Function rPayPeriodID(context As IProviderContext, PayPeriodID As Integer) As DataRow
        Dim r1 As DataRow = Nothing
        Dim Sql As String = "Select * from PayPeriod where  PayPeriodID = " & myUtils.cValTN(PayPeriodID)
        Dim dt As DataTable = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If dt.Rows.Count > 0 Then r1 = dt.Rows(0)

        Return r1
    End Function

    Public Shared Function rRateMasterID(context As IProviderContext, RateMasterID As Integer) As DataRow
        Dim r1 As DataRow = Nothing
        Dim Sql As String = "Select * from RateMaster where  RateMasterID = " & myUtils.cValTN(RateMasterID)
        Dim dt As DataTable = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If dt.Rows.Count > 0 Then r1 = dt.Rows(0)

        Return r1
    End Function

    Public Shared Sub AssignMasters(context As IProviderContext, rPP As DataRow)
        rPP("ratemasterid") = DBNull.Value

        Dim rFY As DataRow = RowMaster(context, "FY", rPP)
        Dim rPostPeriod As DataRow = RowMaster(context, "PP", rPP)
        Dim rRateMstr As DataRow = RowMaster(context, "RM", rPP)

        If Not myUtils.NullNot(rPostPeriod) Then rPP("PostPeriodID") = rPostPeriod("PostPeriodID")
        If Not myUtils.NullNot(rRateMstr) Then rPP("ratemasterid") = rRateMstr("ratemasterid")
    End Sub

    Private Shared Function RowMaster(context As IProviderContext, MasterType As String, rPP As DataRow) As DataRow
        Dim CompanyID As Integer = CInt(myUtils.cValTN(rPP("CompanyID")))
        Dim nr As DataRow = Nothing
        Dim oMasterData As New clsMasterDataFICO(context)

        Select Case MasterType.Trim.ToUpper
            Case "RM"
                nr = rRateMaster(context, CompanyID, rPP("SDate"))
            Case "PP"
                nr = oMasterData.rPostPeriod(rPP("sdate"), "HRStartDate")
            Case "FY"
                nr = rFinYear(context, rPP("sdate"))
        End Select
        Return nr
    End Function

    Public Shared Function TrySaveAttendance(context As IProviderContext, PayPeriodID As Integer, rStu As DataRow, dtAtt As DataTable) As clsProcOutput
        'Check Finalized Payperiods
        'Check Leave Balance
        'Save and recalculate salary
        Dim oProc As New clsPayPeriodStu(context)
        Dim oRet As New clsProcOutput
        Dim oMasterData As New clsMasterDataHRP(context)

        Dim rPP As DataRow = rPayPeriodID(context, PayPeriodID)
        If myUtils.cBoolTN(rPP("isfinal")) Then
            oRet.AddError("Payperiod finalized")
        Else
            Dim dic As New clsCollecString(Of String)
            dic.Add("punch", "select * from punchdata where 0=1")
            Dim ds As DataSet = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)

            For Each rAttend As DataRow In dtAtt.Select
                oProc.ProcessManual(rAttend, rStu, ds.Tables("punch"))
            Next

            'For Each rATM As DataRow In oMasterData.dtAttendTagMaster.Select("tagtype=3")
            '    For Each rAttend As DataRow In dtAtt.Select("attendidfh=" & rATM("attendtagid"))
            '        Dim nr As DataRow = oProc.AddAttendRowLL(rAttend, ds, "attendidfh")
            '    Next

            '    For Each rAttend As DataRow In dtAtt.Select("attendidsh=" & rATM("attendtagid"))
            '        Dim nr As DataRow = oProc.AddAttendRowLL(rAttend, ds, "attendidsh")
            '    Next
            'Next


            'If oRet.Success Then
            Dim AttendDescrip As String = " Code: " & rStu("SerialNo").ToString & " Name: " & rStu("FullName").ToString & ", PP: " & rPP("Payperiodname")
            Try
                context.Provider.dbConn.BeginTransaction(context, "frmAttendStuModel", EnumfrmMode.acEditM, "payperiodid", PayPeriodID)
                'Save

                Dim strCols As String = context.Data.GenColList(context.Data.SelectCols(dtAtt, "", "*"), "")
                context.Provider.objSQLHelper.SaveResults(dtAtt, "SELECT " & strCols & " from attendance where 0=1")

                context.Provider.dbConn.CommitTransaction(AttendDescrip, PayPeriodID)
                oRet = New clsProcOutput(True, "Updated")
            Catch ex As Exception
                context.Provider.dbConn.RollBackTransaction(AttendDescrip, ex.Message)
                oRet.AddError(ex.Message)
            End Try
        End If
        'End If
        Return oRet
    End Function

    Public Shared Function GenerateClass(context As IProviderContext, r1 As DataRow) As Integer
        Dim ClassID As Integer, rClass As DataRow
        Dim dsClass As DataSet = GetClass(context)
        Dim dsTarget As DataSet = dsClass.Clone

        Dim rr1() As DataRow = dsClass.Tables(0).Select("ClassCode = '" & myUtils.cStrTN(r1("DepartmentSName")) & "'")
        If rr1.Length = 0 Then
            rClass = myUtils.CopyOneRow(r1, dsTarget.Tables(0))
            rClass("ClassName") = myUtils.cStrTN(r1("DepartmentFName"))
            rClass("ClassCode") = myUtils.cStrTN(r1("DepartmentSName"))
            rClass("CompanyID") = 1
            context.Provider.objSQLHelper.SaveResults(dsTarget.Tables(0), "SELECT *  FROM Class")


            Dim dsNew As DataSet = GetClass(context)
            Dim rr2() As DataRow = dsNew.Tables(0).Select("ClassCode = '" & myUtils.cStrTN(r1("DepartmentSName")) & "'")
            If rr2.Length > 0 Then
                ClassID = myUtils.cValTN(rr2(0)("ClassID"))
            End If
        Else
            ClassID = myUtils.cValTN(rr1(0)("ClassID"))
        End If
        Return ClassID
    End Function

    Public Shared Function GetClass(context As IProviderContext) As DataSet
        Dim ds As DataSet
        Dim dic As New clsCollecString(Of String)
        dic.Add("Class", "Select * from Class")
        ds = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        Return ds
    End Function

    Public Shared Function rTask(context As IProviderContext, ActionType As String, ActionSubType As String) As DataRow
        Dim r1 As DataRow = Nothing
        Dim Sql As String = "Select * from DBSchedTask where ActionType = '" & myUtils.cStrTN(ActionType) & "' and ActionSubType = '" & myUtils.cStrTN(ActionSubType) & "'"
        Dim dt As DataTable = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If dt.Rows.Count > 0 Then r1 = dt.Rows(0)
        Return r1
    End Function
    Public Shared Function InitializeMapper() As IConfigurationProvider
        Dim config = New MapperConfiguration(Sub(cfg)
                                                 cfg.CreateMap(Of Committee, CommitteeInfo)()
                                                 cfg.CreateMap(Of ClgListCommitteeMemberView, CommitteeInfo)()
                                                 cfg.CreateMap(Of DegreeCourse, DegreeCourseInfo)()
                                                 cfg.CreateMap(Of ClgListDepartmentView, DepartmentInfo)()
                                                 cfg.CreateMap(Of ClgListEventDetailView, EventInfo)()
                                                 cfg.CreateMap(Of ClgListActivityView, ActivityInfo)()
                                                 cfg.CreateMap(Of Company, CollegeInfo)()
                                                 cfg.CreateMap(Of MediaDetail, MediaInfo)()
                                                 cfg.CreateMap(Of clgListNaaC, NAACInfo)()
                                                 cfg.CreateMap(Of ClgListPersonsView, PersonInfo)()
                                                 cfg.CreateMap(Of Subject, SubjectInfo)()
                                                 cfg.CreateMap(Of ClgListAlumniView, AlumniInfo)()
                                                 cfg.CreateMap(Of AlumniInfo, Alumni)()
                                                 cfg.CreateMap(Of Alumni, AlumniInfo)()
                                                 cfg.CreateMap(Of ClgListMediaDetailView, MediaInfo)()
                                                 cfg.CreateMap(Of ClgListCommitteeMemberView, CommitteeMemberInfo)()
                                                 cfg.CreateMap(Of FinYears, FinYearsInfo)()
                                                 cfg.CreateMap(Of NoticeBoard, NoticeBoardInfo)()
                                             End Sub)
        Return config
    End Function
    Public Shared Function LoadAppData(context As IProviderContext, dataKey As String, Params As List(Of clsSQLParam), forcefresh As Boolean, fncBase As Func(Of clsProcOutput)) As clsProcOutput
        Dim dic As New clsCollecString(Of String), oRet As New clsProcOutput, ds As New DataSet

        Try
            Select Case dataKey.Trim.ToLower
                Case "comcampus"
                    dic.Add("Campus", "select * from clglistcampus")
                Case "clsmasterdatahrp"
                    dic.Add("Inst", "select * from Company")
                    dic.Add("payp", "select * from payperiod")
                    dic.Add("atm", "select * from attendtagmaster")
                    dic.Add("shift", "select * from shift")
                Case "com1"
                    dic.Add("finyrs", "select * from finyears")
                    dic.Add("company", "select * from Company")
                Case "clsmasterdatafico"
                    dic.Add("postp", "select * from postperiod")
                Case "postperiodid"
                    Dim str1 As String = context.SQL.ParamValue("@vouchdate", Params)
                    Dim VouchDate As DateTime = If(String.IsNullOrEmpty(str1), Now.Date, DateTime.Parse(str1))
                    Dim oMaster As New clsMasterDataFICO(context)
                    Dim r1 As DataRow = oMaster.rPostPeriod(VouchDate, "HRStartDate")
                    If Not r1 Is Nothing Then oRet.ID = r1("PostPeriodId")
                Case Else
                    ds = fncBase().Data
            End Select
            If dic.Count > 0 AndAlso ds.Tables.Count = 0 Then
                'Pure SQL datasets
                ds = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
            End If
        Catch ex As Exception
            Trace.WriteLine(ex.Message & " while executing " & dataKey)
        End Try
        oRet.Data = ds
        Return oRet
    End Function

    Public Shared Function GenerateCommonOutput(context As IProviderContext, DataKey As String, Params As List(Of clsSQLParam), IDField As String) As clsProcOutput
        Dim oRet As New clsProcOutput
        Dim serverPath As String = Uri.UnescapeDataString(context.SQL.ParamValue("@serverPath", Params))
        Dim _NewFileName As String = myUtils.cStrTN(context.SQL.ParamValue("@filename", Params))

        Select Case DataKey.Trim.ToLower
            Case "sas"
                Dim frmid As String = myUtils.cStrTN(context.SQL.ParamValue($"@{IDField}", Params))
                _NewFileName = Guid.NewGuid.ToString() + "_" + frmid + "" + Path.GetExtension(_NewFileName)

                Dim provider As New clsBlobFileProvider(context)
                Dim container = myPathUtils.GetContainerName(context)
                Dim oRet2 = provider.CreateUploadUri(container, _NewFileName, "")
                If oRet2.Success Then
                    oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message, .Data = oRet2.Result.Uri.ToString, .flName = _NewFileName}
                Else
                    oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message} '"Unable to upload file."
                End If

            Case "download"
                Dim provider As New clsBlobFileProvider(context)
                Dim container = myPathUtils.GetContainerName(context)
                Dim oRet2 = provider.GetDownloadUri(container, myUtils.Coalesce(serverPath, _NewFileName))
                If oRet2.Success Then
                    oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message, .Data = oRet2.Result.Uri.ToString}
                Else
                    oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message} '"Unable to upload file."
                End If
        End Select
        Return oRet
    End Function
    Public Shared Function GetDownloadUri(context As IProviderContext, infoJson As String) As String
        If myUtils.StartsWith(infoJson, "[") Then
            Dim lst = JsonConvert.DeserializeObject(Of List(Of ClsBlobFileInfo))(infoJson)
            If lst.Count > 0 AndAlso Not String.IsNullOrEmpty(lst(0).Blobname) Then
                Return myCollegeFuncs.GetDownloadUriBlob(context, lst(0).Blobname)
            End If
        Else
            'direct file name
            Return myCollegeFuncs.GetDownloadUriBlob(context, infoJson)
        End If
    End Function
    Public Shared Function GetDownloadUriBlob(context As IProviderContext, BlobName As String) As String
        Dim provider As New clsBlobFileProvider(context)
        Dim container = myPathUtils.GetContainerName(context)
        Dim oRet2 = provider.GetDownloadUri(container, BlobName)
        If oRet2.Success Then
            Return oRet2.Result.ToString
        End If
    End Function
End Class