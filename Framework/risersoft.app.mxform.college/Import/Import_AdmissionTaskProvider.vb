Imports Newtonsoft.Json
Imports risersoft.shared
Imports risersoft.app.mxent
Imports risersoft.shared.dotnetfx

Public Class Import_AdmissionTaskProvider
    Inherits ImportTaskProviderFileBase
    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Property DocType As String = "ADMISSION"

    Public Overrides Property TemplateName As String = "Admission"
    Public Overrides Property TemplateFunctionName As String = ""

    Public Overrides Property DocName As String = "Admission"

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
                    Dim VouchDescrip = "Aadhar No. " & rVouch("Aadhar") & ""
                    Try
                        provider.dbConn.BeginTransaction(myContext, Me.GetType.Name, EnumfrmMode.acAddM, "ID")

                        provider.objSQLHelper.SaveResults(dsDB.Tables("persons"), objGroup.dicSQL("persons"), dicOpInfo("persons"))
                        provider.objSQLHelper.SaveResults(dsDB.Tables("student"), objGroup.dicSQL("student"), dicOpInfo("student"))
                        provider.objSQLHelper.SaveResults(dsDB.Tables("stusubject"), objGroup.dicSQL("stusubject"), dicOpInfo("stusubject"))

                        provider.dbConn.CommitTransaction(VouchDescrip, rVouch("PersonID").ToString)
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
                info.Voucher.AddError(Me.PreValidationErrorCode, oRet.Message)
                Me.UpdateError(objGroup.Rows, info.Voucher)
            End If

        End If

        Return oRet

    End Function

    Public Overrides Function ExecutePreValidation(provider As IAppDataProvider, rPerson As DataRow, dtItems As DataTable, rXL As DataRow, objGroup As clsRowGroup) As clsProcOutput
        Dim oRet As New clsProcOutput
        'Conversion of lookup values

        Try
            rPerson("IsFemale") = If(myUtils.IsInList(myUtils.cStrTN(rXL("IsFemale")), "Female"), 1, 0)

            If Not myUtils.NullNot(rXL("FullName")) Then
                Dim arr() As String = myUtils.cStrTN(rXL("FullName")).Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
                rPerson("FirstName") = myUtils.cStrTN(arr(0))
                rPerson("LastName") = If(arr.Length > 1, myUtils.cStrTN(arr(1)), "")
            Else
                oRet.AddError("Candidate Name not found")
            End If

            'Category
            For Each str1 As String In New String() {"category", "reservation"}
                Dim rrPOS() As DataRow = dsMaster.Tables(str1).Select.Where(Function(r1) myUtils.IsInList(myUtils.RemovePunctuation(myUtils.cStrTN(r1("Descrip"))), myUtils.RemovePunctuation(myUtils.cStrTN(rXL(str1))))).ToArray
                If rrPOS.Length > 0 Then
                    rPerson(str1) = rrPOS(0)("codeword")
                Else
                    rPerson(str1) = DBNull.Value
                End If
            Next


            For Each rStu As DataRow In dtItems.Select
                For Each str1 As String In New String() {"admittedas", "subjectgroup", "admissiontype"}
                    Dim rrPOS() As DataRow = dsMaster.Tables(str1).Select.Where(Function(r1) myUtils.IsInList(myUtils.RemovePunctuation(myUtils.cStrTN(r1("Descrip"))), myUtils.RemovePunctuation(myUtils.cStrTN(rXL(str1))))).ToArray
                    If rrPOS.Length > 0 Then
                        rStu(str1) = rrPOS(0)("codeword")
                    Else
                        oRet.AddError($"{str1} not found")
                        rStu(str1) = DBNull.Value
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
        Dim Aadhar As String = myUtils.cStrTN(rXL("Aadhar")).Replace("'", "")
        Dim strf1 As String = myUtils.CombineWhere(False, "Aadhar='" & Aadhar & "'")
        Dim RegistrationNum As String = myUtils.cStrTN(rXL("RegistrationNum")).Replace("'", "")
        Dim strf2 As String = myUtils.CombineWhere(False, "RegistrationNum='" & RegistrationNum & "'")
        dicSQL.Add("persons", "select * from persons where " & strf1)
        dicSQL.Add("student", "select * from student where " & strf2)
        dicSQL.Add("stusubject", "select * from stusubject where studentid in (select studentid from student where " & strf2 & ")")

        Return dicSQL

    End Function

    Protected Overrides Function HandleGroupData(provider As IAppDataProvider, objGroup As clsRowGroup, objPortion As clsPortionInfo) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim rXL = objGroup.Rows(0)
        objGroup.dicSQL.Clear()
        Dim dic2 = Me.GenerateSQL(provider, objGroup, objPortion)
        dic2.CopyTo(objGroup.dicSQL)

        Dim Aadhar As String = myUtils.cStrTN(rXL("Aadhar")).Replace("'", "")
        Dim RegistrationNum As String = myUtils.cStrTN(rXL("RegistrationNum")).Replace("'", "")
        Dim dsDB = provider.objSQLHelper.ExecuteDataset(CommandType.Text, objGroup.dicSQL)
        Me.CheckAddOpInfo(provider, objGroup.dicSQL)

        myContext.Tables.SetAuto(dsDB.Tables("persons"), dsDB.Tables("student"), "personid")
        myContext.Tables.SetAuto(dsDB.Tables("student"), dsDB.Tables("stusubject"), "studentid")

        'Person Import
        Dim rr1() As DataRow = dsDB.Tables("persons").Select("Aadhar=" & Aadhar & "")
        Dim rr2() As DataRow = dsDB.Tables("student").Select("RegistrationNum='" & RegistrationNum & "'")


        Dim objComp = myContext.GetAppInfo.AppBarValues.Where(Function(x) myUtils.IsInList(x.FieldName, "CompanyID")).FirstOrDefault
        Dim rrCourse, rrClass, rrShift, rrCampus As DataRow()
        If (objComp Is Nothing) OrElse String.IsNullOrEmpty(objComp.FieldValue) Then
            oRet.AddError("Company Not found")
        Else
            Dim strf1 = "course='" & myUtils.cStrTN(rXL("DegreeCourse")) & "'"
            Dim strf2 = "companyid=" & objComp.FieldValue
            rrCourse = dsMaster.Tables("course").Select(myUtils.CombineWhere(False, strf1, strf2))
            If rrCourse.Length = 0 Then
                oRet.AddError("Course not found")
            Else
                Dim strf3 = myContext.SQL.GenerateSQLWhere(rrCourse(0), "degreecourseid")
                rrClass = dsMaster.Tables("Class").Select(strf3, "year,semester")
                If rrClass.Length = 0 Then
                    oRet.AddError("Class not found")
                End If
            End If
            rrCampus = dsMaster.Tables("campus").Select(strf2)
            rrShift = dsMaster.Tables("shift").Select("", "shiftid")
            If rrCampus.Length = 0 Then
                oRet.AddError("Campus not found")
            ElseIf rrShift.Length = 0 Then
                oRet.AddError("Shift not found")
            End If
        End If

        If oRet.Success Then
            Dim rPersons, rStudent, rStuSubject As DataRow
            If rr1.Length > 0 Then
                rPersons = rr1(0)
            Else
                rPersons = myContext.Tables.AddNewRow(dsDB.Tables("persons"))
                rPersons("Aadhar") = rXL("Aadhar")
                Me.CalculateDate(rXL, rPersons, "Birthday")
                rPersons("AgeYears") = rXL("AgeYears")
                rPersons("FatherName") = rXL("FatherName")
                rPersons("MotherName") = rXL("MotherName")
                rPersons("CellNum") = rXL("CellNum")
                rPersons("PrPhone") = rXL("PrPhone")
                rPersons("Email") = rXL("Email")
                rPersons("AadharEnrollment") = rXL("AadharEnrollment")
                rPersons("PrAddress") = rXL("PrAddress")
                rPersons("Category") = rXL("Category")
                rPersons("Reservation") = rXL("Reservation")
                rPersons("EWS") = rXL("EWS")
                rPersons("XthMarksSheetSerial") = rXL("XthMarksSheetSerial")
                rPersons("XthPassYear") = rXL("XthPassYear")
                rPersons("XIIthRollNum") = rXL("XIIthRollNum")
                rPersons("CompanyID") = objComp.FieldValue
                rPersons("isstudent") = True
            End If

            'Student Import
            If rr2.Length > 0 Then
                rStudent = rr2(0)
            Else
                rStudent = myContext.Tables.AddNewRow(dsDB.Tables("student"))
                rStudent("personid") = rPersons("personid")
                rStudent("AdmittedAs") = rXL("AdmittedAs")
                rStudent("AdmissionType") = rXL("AdmissionType")
                rStudent("SubjectGroup") = rXL("SubjectGroup")
                rStudent("ListNumber") = rXL("ListNumber")
                rStudent("RegistrationNum") = rXL("RegistrationNum")
                rStudent("Classid") = rrClass(0)("classid")
                rStudent("campusid") = rrCampus(0)("campusid")
                rStudent("shiftid") = rrShift(0)("shiftid")

            End If



            'StuSubject Import
            For i As Integer = 1 To 3
                If myUtils.cStrTN(rXL("subject" & i)).Trim.Length > 0 Then
                    Dim rrSub() = dsMaster.Tables("subject").Select("subjectname='" & rXL("subject" & i) & "'")
                    If rrSub.Length > 0 Then
                        Dim strf2 = myUtils.CombineWhere(False, "studentid=" & rStudent("studentid"), "subjectid=" & myUtils.cValTN(rrSub(0)("subjectid")))
                        Dim rr3() As DataRow = dsDB.Tables("stusubject").Select(strf2)
                        If rr3.Length > 0 Then
                            rStuSubject = rr3(0)
                        Else
                            rStuSubject = myContext.Tables.AddNewRow(dsDB.Tables("stusubject"))
                            rStuSubject("studentid") = rStudent("studentid")
                            rStuSubject("subjectid") = rrSub(0)("subjectid")
                        End If
                    Else
                        oRet.AddError($"{rXL("subject" & i)} not found, please enter correct subject.")
                    End If
                End If
            Next
        End If
        If Not oRet.Success Then Me.UpdateErrorMsg(rXL, Me.PreValidationErrorCode, oRet.Message)

        oRet.Data = dsDB
        Return Task.FromResult(oRet)
    End Function

    Protected Overrides Function GenerateFilter() As String
        Return "isnull(aadhar,'')<>''"
    End Function

    Protected Overrides Sub PopulateErrorFile(importer As ISSGImport, ds As DataSet, dtErrorFinal As DataTable)
        MyBase.PopulateErrorFile(importer, ds, dtErrorFinal)
        'importer.CopyData("UserAssignment", ds.Tables("UserAssignment"), 1, "dd/MM/yyyy", AddressOf DateFromString)

    End Sub

    Protected Overrides Function UniqueFieldList(DocType As String, TableName As String) As List(Of String)
        Dim lst1 As New List(Of String)
        Select Case DocType.Trim.ToLower
            Case "admission"
                lst1 = New List(Of String)(New String() {"aadhar"})

        End Select
        Return lst1
    End Function

    Public Overrides Sub PopulateMaster()
        oMaster.GetDataset2(False)

        Dim dicSQL As New clsCollecString(Of String)
        dicSQL.Add("course", "select * from degreecourse")
        dicSQL.Add("class", "select * from class")
        dicSQL.Add("campus", "select * from campus")
        dicSQL.Add("shift", "select * from shift")
        dicSQL.Add("subject", "select * from subject")
        dicSQL.Add("category", myFuncsBase.CodeWordSQL("student", "category", ""))
        dicSQL.Add("admittedas", myFuncsBase.CodeWordSQL("student", "category", ""))
        dicSQL.Add("subjectgroup", myFuncsBase.CodeWordSQL("subject", "group", ""))
        dicSQL.Add("admissiontype", myFuncsBase.CodeWordSQL("admission", "type", ""))
        dicSQL.Add("reservation", myFuncsBase.CodeWordSQL("student", "reservation", ""))

        dsMaster = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, dicSQL)

    End Sub

    Public Overrides Sub AddRecord(info As FileImportInfo, objGroup As clsRowGroup)
        info.AddRecord(myUtils.cStrTN(objGroup.Rows(0)("SubjectGroup")), objGroup.Rows.Count, objGroup.Output.Success)

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
