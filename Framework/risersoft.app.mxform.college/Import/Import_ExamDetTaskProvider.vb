Imports Newtonsoft.Json
Imports risersoft.shared
Imports risersoft.app.mxent
Imports risersoft.shared.dotnetfx

Public Class Import_ExamDetTaskProvider
       Inherits ImportTaskProviderFileBase
    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Property DocType As String = "EXAMDET"

    Public Overrides Property TemplateName As String = "ExamDet"
    Public Overrides Property TemplateFunctionName As String = ""

    Public Overrides Property DocName As String = "ExamDet"

    Public Overrides Async Function TryImportRowGroup(provider As IAppDataProvider, objGroup As clsRowGroup, objPortion As clsPortionInfo) As Task(Of clsProcOutput)
        Dim dic As New clsCollecString(Of DataRow)
        Dim oRet = Await Me.HandleGroupData(provider, objGroup, objPortion)
        Dim info As New ImportErrorInfo()
        If oRet.WarningCount > 0 Then info.Voucher.AddWarning(Me.DocumentExistsErrorCode, oRet.WarningMessage)

        If objGroup.Rows.Count > 1 Then
            oRet.AddError("Multiple Records found from Same Student")
            info.Voucher.AddError(Me.PreValidationErrorCode, "Multiple Records found from Same Student")
            Me.UpdateError(objGroup.Rows, info.Voucher)
        ElseIf oRet.Success AndAlso oRet.Data.Tables(0).Rows.Count > 0 Then
            'Have a new dataset ready for data to be saved from database and copy level 1 and level 2 rows into it
            Dim dsDB = oRet.Data
            Dim rVouch = dsDB.Tables(0).Select()(0)
            'Do the pre-operations, like getting IDs
            oRet = Me.ExecutePreValidation(provider, rVouch, dsDB.Tables("student"), objGroup.Rows(0), objGroup)
            If oRet.Success Then

                Me.RunValidator(info, objGroup.Rows, rVouch, dsDB, "", Sub(obj, rItem)
                                                                           If rItem Is Nothing Then
                                                                               For Each kvp In dic
                                                                                   obj.AddOrUpdateRow(kvp.Value, kvp.Key)
                                                                               Next
                                                                           End If
                                                                       End Sub)
                If info.Errorcount = 0 Then
                    'If all OK, go ahead and save. If not OK, add validation errors obtained to a new error datatable with same schema as ds, but with Validation and Warning columns.
                    Dim VouchDescrip = "Registration No. " & rVouch("RegistrationNum") & ""
                    Try
                        provider.dbConn.BeginTransaction(myContext, Me.GetType.Name, EnumfrmMode.acAddM, "ID")

                        provider.objSQLHelper.SaveResults(dsDB.Tables("persons"), objGroup.dicSQL("persons"), dicOpInfo("persons"))
                        provider.objSQLHelper.SaveResults(dsDB.Tables("stupaper"), objGroup.dicSQL("stupaper"), dicOpInfo("stupaper"))
                        provider.objSQLHelper.SaveResults(dsDB.Tables("stusubject"), objGroup.dicSQL("stusubject"), dicOpInfo("stusubject"))

                        provider.dbConn.CommitTransaction(VouchDescrip, rVouch("RegistrationNum").ToString)
                    Catch ex As Exception
                        oRet.AddException(ex)
                        provider.dbConn.RollBackTransaction(VouchDescrip, ex.Message, False)
                        Dim obj = info.Voucher.AddException(Me.DatabaseTransactionErrorCode, ex)
                        Me.UpdateError(objGroup.Rows, info.Voucher)
                    End Try

                Else
                    If Not Me.ImportFileID = Guid.Empty Then
                        Dim nr = Me.CreateFileVouchRow(objPortion, rVouch, dsDB, objGroup, info, Sub(x)
                                                                                                     x("vouchnum") = rVouch("Aadhar")
                                                                                                 End Sub)
                    End If
                    oRet.AddError(info.ErrorDescripTot)
                End If

            Else
                oRet.AddError("Unforeseen error in pre validation")
                info.Voucher.AddError(Me.PreValidationErrorCode, "Unforeseen error in pre validation")
                Me.UpdateError(objGroup.Rows, info.Voucher)
            End If

        End If

        Return oRet

    End Function

    Public Overrides Function ExecutePreValidation(provider As IAppDataProvider, rVouch As DataRow, dtItems As DataTable, rXL As DataRow, objGroup As clsRowGroup) As clsProcOutput
        Dim oRet As New clsProcOutput
        'Conversion of lookup values

        Try

            'Studenttype
            For Each rStuPap As DataRow In dtItems.DataSet.Tables("stupaper").Select
                For Each str1 As String In New String() {"studenttype"}
                    Dim rrPOS() As DataRow = dsMaster.Tables(str1).Select("Descrip='" & myUtils.cStrTN(rXL(str1)) & "'")
                    If rrPOS.Length > 0 Then
                        rStuPap(str1) = rrPOS(0)("codeword")
                    Else
                        rStuPap(str1) = DBNull.Value
                    End If
                Next
            Next

        Catch ex As Exception
            oRet.AddException(ex)

        End Try
        Return oRet
    End Function

    Public Overrides Async Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim Params = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(myUtils.cStrTN(rTask("infojson")))
        Dim path = Await myFuncs.DownloadIfReqd(myContext, rTask, Params("path"))
        Dim oRet = Await Me.ExecuteImport(path, myUtils.cStrTN(rTask("username")), myUtils.cStrTN(rTask("importfileid")))
        Return oRet
    End Function

    Protected Overrides Function GenerateSQL(provider As IAppDataProvider, objGroup As clsRowGroup, objPortion As clsPortionInfo) As clsCollecString(Of String)
        Dim dicSQL As New clsCollecString(Of String)
        Dim rXL = objGroup.Rows(0)
        Dim RegistrationNum As String = myUtils.cStrTN(rXL("RegistrationNum")).Replace("'", "")
        Dim strf1 As String = myUtils.CombineWhere(False, "RegistrationNum='" & RegistrationNum & "'")

        dicSQL.Add("student", "select * from student where " & strf1 & "")
        dicSQL.Add("persons", "select * from persons where personid in (select personid from student where " & strf1 & ")")
        dicSQL.Add("stusubject", "select * from stusubject where studentid in (select studentid from student where " & strf1 & ")")
        dicSQL.Add("stupaper", "select * from stupaper where studentid in (select studentid from student where " & strf1 & ")")

        Return dicSQL

    End Function

    Protected Overrides Function HandleGroupData(provider As IAppDataProvider, objGroup As clsRowGroup, objPortion As clsPortionInfo) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim rXL = objGroup.Rows(0)
        objGroup.dicSQL.Clear()
        Dim dic2 = Me.GenerateSQL(provider, objGroup, objPortion)
        dic2.CopyTo(objGroup.dicSQL)

        Dim RegistrationNum As String = myUtils.cStrTN(rXL("RegistrationNum")).Replace("'", "")
        Dim dsDB = provider.objSQLHelper.ExecuteDataset(CommandType.Text, objGroup.dicSQL)
        Me.CheckAddOpInfo(provider, objGroup.dicSQL)

        Dim rr1() As DataRow = dsDB.Tables("Student").Select("RegistrationNum='" & RegistrationNum & "'")
        Dim rr2() As DataRow = dsDB.Tables("Persons").Select()


        Dim rStudent, rPersons, rStuSubject, rStuPaper As DataRow
        'Student Import
        If rr1.Length > 0 Then
            rStudent = rr1(0)
        Else
            oRet.AddError("Student not found")
        End If

        'Person Import
        If rr2.Length > 0 Then
            rPersons = rr2(0)
            rr2(0)("EnrollmentNum") = rXL("EnrollmentNum")
        Else
            oRet.AddError("Person not found")
        End If

        If oRet.Success Then
            'StuSubject Import
            For i As Integer = 1 To 5
                If myUtils.cStrTN(rXL("subject" & i)).Trim.Length > 0 Then
                    Dim rrSub() = dsMaster.Tables("subject").Select("subjectname='" & rXL("subject" & i) & "'")
                    If rrSub.Length > 0 Then
                        Dim strf2 = myUtils.CombineWhere(False, "studentid=" & rr1(0)("studentid"), "subjectid=" & myUtils.cValTN(rrSub(0)("subjectid")))
                        Dim rr3() As DataRow = dsDB.Tables("stusubject").Select(strf2)
                        If rr3.Length > 0 Then
                            rStuSubject = rr3(0)
                        Else
                            rStuSubject = myContext.Tables.AddNewRow(dsDB.Tables("stusubject"))
                            rStuSubject("studentid") = rr1(0)("studentid")
                            rStuSubject("subjectid") = rrSub(0)("subjectid")
                        End If
                    End If
                End If
            Next
        Else
            Me.UpdateErrorMsg(rXL, Me.PreValidationErrorCode, oRet.Message)
        End If

        If oRet.Success Then
            'StuPaper Import
            For i As Integer = 1 To 11
                If myUtils.cStrTN(rXL("paper" & i)).Trim.Length > 0 Then
                    Dim rrPap() = dsMaster.Tables("paper").Select("papercode='" & rXL("paper" & i) & "'")
                    If rrPap.Length > 0 Then
                        Dim strf2 = myUtils.CombineWhere(False, "studentid=" & rr1(0)("studentid"), "paperid=" & myUtils.cValTN(rrPap(0)("paperid")))
                        Dim rr4() As DataRow = dsDB.Tables("stupaper").Select(strf2)
                        If rr4.Length > 0 Then
                            rStuPaper = rr4(0)
                        Else
                            rStuPaper = myContext.Tables.AddNewRow(dsDB.Tables("StuPaper"))
                            rStuPaper("Studentid") = rr1(0)("studentid")
                            rStuPaper("Paperid") = rrPap(0)("paperid")
                            rStuPaper("FormNum") = rXL("FormNum")
                            rStuPaper("ExamRollNum") = rXL("ExamRollNum")
                            'rStuPaper("StudentType") = rXL("StudentType")


                        End If
                    End If
                End If
            Next
        Else
            Me.UpdateErrorMsg(rXL, Me.PreValidationErrorCode, oRet.Message)
        End If


        oRet.Data = dsDB
        Return Task.FromResult(oRet)
    End Function

    Protected Overrides Function GenerateFilter() As String
        Return "isnull(registrationnum,'')<>''"
    End Function

    Protected Overrides Sub PopulateErrorFile(importer As ISSGImport, ds As DataSet, dtErrorFinal As DataTable)
        MyBase.PopulateErrorFile(importer, ds, dtErrorFinal)
        'importer.CopyData("UserAssignment", ds.Tables("UserAssignment"), 1, "dd/MM/yyyy", AddressOf DateFromString)

    End Sub

    Protected Overrides Function UniqueFieldList(DocType As String, TableName As String) As List(Of String)
        Dim lst1 As New List(Of String)
        Select Case DocType.Trim.ToLower
            Case "examdet"
                lst1 = New List(Of String)(New String() {"registrationnum"})

        End Select
        Return lst1
    End Function

    Public Overrides Sub PopulateMaster()
        oMaster.GetDataset2(False)

        Dim dicSQL As New clsCollecString(Of String)
        dicSQL.Add("subject", "select * from subject")
        dicSQL.Add("paper", "select * from paper")
        dicSQL.Add("studenttype", myFuncsBase.CodeWordSQL("student", "studenttype", ""))

        dsMaster = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, dicSQL)

    End Sub

    Public Overrides Sub AddRecord(info As FileImportInfo, objGroup As clsRowGroup)
        info.AddRecord(myUtils.cStrTN(objGroup.Rows(0)("StudentType")), objGroup.Rows.Count, objGroup.Output.Success)

    End Sub



    'Public Overrides Function PostProcessError(oRet As clsProcOutput, dtErrorList As List(Of DataTable), filePath As String, userName As String, ImpInfo As FileImportInfo) As Task
    '    oRet.Data = New DataSet
    '    For Each dt1 In dtErrorList
    '        myUtils.AddTable(oRet.Data, dt1, dt1.TableName)
    '    Next
    '    oRet.Description = JsonConvert.SerializeObject(ImpInfo)
    '    Return Task.CompletedTask
    'End Function

    Protected Overrides Function CreateData(provider As IAppDataProvider, Groups As List(Of clsRowGroup), objPortion As clsPortionInfo) As Task(Of Boolean)
        Throw New NotImplementedException()
    End Function
End Class
