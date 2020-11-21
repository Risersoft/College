Imports risersoft.shared
Imports System.Runtime.Serialization
Imports System.Text
Imports risersoft.shared.portable.Model
Imports System.Configuration
Imports System.IO
Imports risersoft.shared.cloud

<DataContract>
Public Class frmStuPersonModel
    Inherits clsFormDataModel
    Dim myVueFam, myVueEdu As clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("ListStu")
        myVueFam = Me.GetViewModel("Fam")
        myVueEdu = Me.GetViewModel("Education")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim Sql As String

        Dim vlist As New clsValueList
        vlist.Add(True, "Female")
        vlist.Add(False, "Male")
        Me.ValueLists.Add("IsFemale", vlist)
        Me.AddLookupField("IsFemale", "IsFemale")

        Sql = "Select ShiftId, Shift from Shift order by Shift"
        Me.AddLookupField("ShiftId", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "shift").TableName)

        Sql = myCollegeFuncs.CodeWordSQL("Student", "Category", "", "Tag")
        Me.AddLookupField("Category", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "Category").TableName)

        Sql = myCollegeFuncs.CodeWordSQL("Student", "Reservation", "")
        Me.AddLookupField("Reservation", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "Reservation").TableName)

        Sql = "Select distinct ListNumber from Student where ListNumber is Not Null"
        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        Me.ValueLists.Add("ListNumber", myContext.SQL.VListFromTable(dt))
        Me.AddLookupField("ListNumber", "ListNumber")

        Sql = myCollegeFuncs.CodeWordSQL("Student", "Category", "", "Tag")
        Me.AddLookupField("AdmittedAs", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "AdmittedAs").TableName)

        Sql = myCollegeFuncs.CodeWordSQL("Admission", "Type", "", "Tag")
        Me.AddLookupField("AdmissionType", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "AdmissionType").TableName)

        Sql = myCollegeFuncs.CodeWordSQL("Subject", "Group", "", "Tag")
        Me.AddLookupField("SubjectGroup", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "SubGroup").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1, str2 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from Persons where PersonId = " & prepIDX
        Me.InitData(sql, "CompanyID", oView, prepMode, prepIDX, strXML)

        Dim myuserid = If(myRow("userid") Is DBNull.Value, Guid.Empty, myRow("userid"))
        sql = $"Select userid, username from users where isnull(isdeleted,0)=0 And (userid Not In (Select userid from persons where userid is not null) Or userid='{myuserid}') order by username"
        Me.AddLookupField("userid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "user").TableName)

        myView.MainGrid.BindGridData(GenerateData("stu", frmIDX), 0)
        myView.MainGrid.QuickConf("", True, "3-2-2-2", True)
        str1 = "<BAND INDEX=""0"" TABLE=""Student"" IDFIELD=""StudentID"" ><COL KEY=""PersonId,AdmissionDate,CampusId,ShiftId,RollNum,SerialNo,ClassID,AdmittedAs,AdmissionType,SubjectGroup,ListNumber,RegistrationNum""/></BAND> "
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        myVueFam.MainGrid.QuickConf("Select PersFamilyid,PersonId,MemberName,Relation,BDate,Profession,MemberAddress,Other from PersFamily where PersonId=" & frmIDX, True, "2-1-1.5-2-2-1", True)
        myVueFam.MainGrid.MainConf("FORMATXML") = "<COL KEY=""MemberName"" CAPTION=""Member Name""/><COL KEY=""BDate"" CAPTION=""Birth Date""/><COL KEY=""MemberAddress"" CAPTION=""Member Address""/>"
        str1 = "<BAND INDEX=""0"" TABLE=""persFamily"" IDFIELD=""persFamilyid"" ><COL KEY=""Personid,MemberName,Relation,BDate,Profession,MemberAddress,Other""/></BAND> "
        myVueFam.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        myVueEdu.MainGrid.QuickConf("Select perseduid,personid,Qualification,Institution,Board,YearQual,MarksheetNo,RollNo,Marks,PerMarks from persedu where personid=" & frmIDX, True, "2-2-2-1.5-2-2-2-1.5", True)
        myVueEdu.MainGrid.MainConf("FORMATXML") = "<COL KEY=""YearQual"" CAPTION=""Passing Year""/><COL KEY=""Marks"" CAPTION=""Marks Obtained""/><COL KEY=""PerMarks"" CAPTION=""Percentage""/><COL KEY=""MarksheetNo"" CAPTION=""MarkSheet No.""/><COL KEY=""RollNo"" CAPTION=""Roll No.""/>"
        str2 = "<BAND INDEX=""0"" TABLE=""persedu"" IDFIELD=""perseduid"" ><COL KEY=""Qualification,Institution,Board,YearQual,MarksheetNo,RollNo,Marks,PerMarks,personid""/></BAND> "
        myVueEdu.MainGrid.PrepEdit(str2, EnumEditType.acCommandAndEdit)

        Dim ds As DataSet = myContext.CommonData.GetDatasetLocode(False).Copy
        Me.AddLookupField("PrCountry", myUtils.AddTable(Me.dsCombo, ds.Tables("CO"), "CO").TableName)
        Me.AddLookupField("PmCountry", "CO")
        Me.AddLookupField("PrState", myUtils.AddTable(Me.dsCombo, ds.Tables("SU"), "SU").TableName)
        Me.AddLookupField("PmState", "SU")

        sql = "select CampusID, DispName,CompanyID from Campus where companyid= " & myUtils.cValTN(myRow("CompanyID")) & " order by DispName"
        Me.AddLookupField("CampusID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "campus").TableName)

        Dim str3 As String = myUtils.CombineWhere(True, myContext.AppModel.strFilterDBAppUser(myContext, Me.fRow, "CompanyID"))
        sql = "Select ClassID, ClassName from Class " & str3 & " Order by ClassName"
        Me.AddLookupField("ClassID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Class").TableName)

        Me.FormPrepared = True
        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean

        Me.InitError()
        If (myUtils.cStrTN(myRow("FirstName")).Trim.Length = 0) AndAlso (myUtils.cStrTN(myRow("MidName")).Trim.Length = 0) AndAlso (myUtils.cStrTN(myRow("LastName")).Trim.Length = 0) Then Me.AddError("LastName", "Enter the name")
        If Me.SelectedItem("IsFemale") Is Nothing Then Me.AddError("IsFemale", "Select Gender")

        If myUtils.NullNot(Me.myRow("Birthday")) Then Me.AddError("Birthday", "Select Birthday")
        If (myUtils.cStrTN(myRow("Aadhar")).Trim.Length = 0) Then Me.AddError("Aadhar", "Enter Aadhar")
        If (myUtils.cStrTN(myRow("CellNum")).Trim.Length = 0) Then Me.AddError("CellNum", "Enter Cell Num")
        If Me.SelectedRow("Reservation") Is Nothing Then Me.AddError("Reservation", "Select Reservation")
        If (myUtils.cStrTN(myRow("Email")).Trim.Length = 0) Then Me.AddError("Email", "Please Enter Email")

        myView.MainGrid.CheckValid("ClassID,CampusId")
        'If myUtils.cStrTN(myRow("prgeopoint")).Trim.Length > 0 AndAlso (Not GeoCoordinate.TryParse(myRow("prgeopoint"), Nothing)) Then Me.AddError("prgeopoint", "Unrecognized format")
        'If myUtils.cStrTN(myRow("pmgeopoint")).Trim.Length > 0 AndAlso (Not GeoCoordinate.TryParse(myRow("pmgeopoint"), Nothing)) Then Me.AddError("pmgeopoint", "Unrecognized format")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            For Each r As DataRow In myView.MainGrid.myDS.Tables(0).Select("OnRolls=1")
                Dim sql As String = "select SerialNo,StudentID,OnRolls from Student where personid <> " & myUtils.cValTN(myRow("PersonId"))
                Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                Dim rr2() As DataRow = dt.Select("SerialNo = '" & myUtils.cStrTN(r("SerialNo")) & "' and (OnRolls=1)")
                If rr2.Length > 0 Then Me.AddError("", "SerialNo already exists")
            Next
            If Me.CanSave Then
                Dim HRPersonDescrip As String = myUtils.cStrTN(myRow("FullName"))
                myRow("IsStudent") = 1
                Try
                    myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "personid", frmIDX)
                    If Me.SelectedRow("PrCountry") Is Nothing Then myRow("prcountrycode") = "" Else myRow("prcountrycode") = Me.SelectedRow("PrCountry")("countrycode")
                    If Me.SelectedRow("PrState") Is Nothing Then myRow("prstatecode") = "" Else myRow("prstatecode") = Me.SelectedRow("PrState")("subdivisioncode")
                    If Me.SelectedRow("PmCountry") Is Nothing Then myRow("pmcountrycode") = "" Else myRow("pmcountrycode") = Me.SelectedRow("PmCountry")("countrycode")
                    If Me.SelectedRow("PmState") Is Nothing Then myRow("pmstatecode") = "" Else myRow("pmstatecode") = Me.SelectedRow("PmState")("subdivisioncode")
                    myRow("prmailingaddress") = myUtils.MakeCSV(vbCrLf, myUtils.cStrTN(myRow("praddress")), myUtils.MakeCSV(", ", myUtils.cStrTN(myRow("prcity")), myUtils.cStrTN(myRow("prstate"))), myUtils.MakeCSV(" - ", myUtils.cStrTN(myRow("prcountry")), myUtils.cStrTN(myRow("prpincode"))))
                    myRow("pmmailingaddress") = myUtils.MakeCSV(vbCrLf, myUtils.cStrTN(myRow("pmaddress")), myUtils.MakeCSV(", ", myUtils.cStrTN(myRow("pmcity")), myUtils.cStrTN(myRow("pmstate"))), myUtils.MakeCSV(" - ", myUtils.cStrTN(myRow("pmcountry")), myUtils.cStrTN(myRow("pmpincode"))))

                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                    frmIDX = myRow("personid")
                    If frmMode = EnumfrmMode.acAddM Then
                        myView.MainGrid.SaveChanges(, "personid=" & frmIDX)
                    End If

                    myVueFam.MainGrid.SaveChanges(, "personid=" & frmIDX)
                    myVueEdu.MainGrid.SaveChanges(, "PersonID=" & frmIDX)

                    frmMode = EnumfrmMode.acEditM
                    myContext.Provider.dbConn.CommitTransaction(HRPersonDescrip, frmIDX)
                    VSave = True
                Catch ex As Exception
                    myContext.Provider.dbConn.RollBackTransaction(HRPersonDescrip, ex.Message)
                    Me.AddError("", ex.Message)
                End Try
            End If
        End If
        Return VSave
    End Function

    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput
        Select Case dataKey
            Case "stu"
                oRet.Data = GenerateData("stu", myUtils.cValTN(ID))
        End Select
        Return oRet
    End Function

    Protected Overrides Function GenerateData(DataKey As String, ID As String) As DataSet
        Dim oRet As New clsProcOutput
        Select Case DataKey.Trim.ToLower
            Case "stu"
                Dim sql As String = "Select StudentID,personid,Campusid,OnRolls,ShiftId,SerialNo,RollNum,ClassID,AdmissionDate,LeaveDate,AdmittedAs,AdmissionType,SubjectGroup,ListNumber,RegistrationNum from Student where personid=" & ID
                oRet.Data = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql)
        End Select

        Return oRet.Data
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        oRet = myCollegeFuncs.GenerateCommonOutput(myContext, dataKey, Params, "personId")
        Return oRet
    End Function

    'Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
    '    Dim _NewFileName As String = myUtils.cStrTN(myContext.SQL.ParamValue("@filename", Params))
    '    Dim serverPath As String = Uri.UnescapeDataString(myContext.SQL.ParamValue("@serverPath", Params))
    '    Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)

    '    'If oRet.Success Then
    '    Select Case dataKey.Trim.ToLower
    '        Case "sas"
    '            Dim OrigFileName = Path.GetFileNameWithoutExtension(_NewFileName)
    '            _NewFileName = OrigFileName + "--" + Guid.NewGuid.ToString + Path.GetExtension(_NewFileName)

    '            Dim provider As New clsBlobFileProvider(myContext)
    '            Dim container = myPathUtils.GetContainerName(myContext)
    '            Dim oRet2 = provider.CreateUploadUri(container, _NewFileName, "")
    '            If oRet2.Success Then
    '                oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message, .Data = oRet2.Result.Uri.ToString, .flName = _NewFileName}
    '            Else
    '                oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message} '"Unable to upload file."
    '            End If

    '        Case "download"
    '            Dim provider As New clsBlobFileProvider(myContext)
    '            Dim container = myPathUtils.GetContainerName(myContext)
    '            Dim oRet2 = provider.GetDownloadUri(container, serverPath)
    '            If oRet2.Success Then
    '                oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message, .Data = oRet2.Result.Uri.ToString}
    '            Else
    '                oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message} '"Unable to upload file."
    '            End If

    '        Case "geopoint"
    '            'Dim address As String = Encoding.UTF8.GetString(Convert.FromBase64String(Replace(myUtils.cStrTN(myContext.SQL.ParamValue("@address", Params)), "-", "=")))
    '            'Dim geocoder As New Geocoder(ConfigurationManager.AppSettings("GOOGLE_MAPS_API_KEY"))

    '            'Dim response = geocoder.Geocode(address)
    '            'If response.Results.Count > 0 Then
    '            '    Dim loc = response.Results(0).Geometry.Location
    '            '    Dim pnt As New GeoCoordinate(loc.Lat, loc.Lng)
    '            '    oRet.Description = pnt.ToString
    '            'End If
    '    End Select
    '    'End If
    '    Return oRet
    'End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput, dt1, dt3, dt5, dt6 As DataTable
        Try

            Select Case EntityKey.Trim.ToLower
                Case "persons"
                    Dim sql As String = "Select * from Persons Where PersonID =" & ID
                    Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                    If dt.Rows.Count > 0 Then
                        Dim sql1 As String = "Select * from Punchdata where StudentID in (Select StudentID from Student where PersonID = " & ID & ")"
                        dt1 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql1).Tables(0)
                        Dim sql3 As String = "Select * from Attendance where StudentID in (Select StudentID from Student where PersonID = " & ID & ")"
                        dt3 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql3).Tables(0)
                        Dim sql5 As String = "Select * from StuSubject where StudentID in (Select StudentID from Student where PersonID = " & ID & ")"
                        dt5 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql5).Tables(0)
                        Dim sql6 As String = "Select * from StuPaper where StudentID in (Select StudentID from Student where PersonID = " & ID & ")"
                        dt6 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql6).Tables(0)

                        If dt1.Rows.Count = 0 AndAlso dt3.Rows.Count = 0 AndAlso dt5.Rows.Count = 0 AndAlso dt6.Rows.Count = 0 Then
                            Dim sql2 As String = "delete from Persons where PersonID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql2)
                        End If

                        If dt1.Rows.Count > 0 OrElse dt3.Rows.Count > 0 OrElse dt5.Rows.Count > 0 OrElse dt6.Rows.Count > 0 Then
                            oRet.AddError("Cannot Delete this Person.")
                        End If

                        If oRet.ErrorCount = 0 Then
                            oRet.AddWarning("Are you sure ?")
                        End If

                    End If
            End Select

        Catch ex As Exception
            oRet.AddException(ex)
        End Try
        Return oRet
    End Function
End Class
