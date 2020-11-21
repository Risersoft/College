Imports System.IO
Imports System.Net
Imports AutoMapper
Imports klts.app.mxform.admin
Imports klts.app.mxform.admin.Mxcollegedb
Imports Newtonsoft.Json
Imports risersoft.app.mxform.college
Imports risersoft.shared

''' <summary>
''' ESS Repository
''' </summary>
''' <remarks></remarks>
Public Class CollegeRepository
    Inherits ServerRepositoryBase
    Implements ICollegeRepository

    Dim mapper As IMapper
    ''' <summary>
    ''' Public constructor.
    ''' </summary>
    Public Sub New()
        Dim config = myCollegeFuncs.InitializeMapper()
        mapper = config.CreateMapper()

    End Sub
    Public Function GetCommitteeMembers(CollegeCode As String) As ResultInfo(Of List(Of CommitteeInfo), HttpStatusCode) Implements ICollegeRepository.GetCommitteeMembers
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(CollegeCode)).FirstOrDefault
                Dim _lst = (From _c In _ctx.Committee Where (_c.CompanyId.Equals(_college.CompanyId))).ToList
                Dim _lst2 = (From _c In _ctx.ClgListCommitteeMemberView Where (_c.CompanyId.Equals(_college.CompanyId))).ToList
                Dim result = mapper.Map(Of List(Of CommitteeInfo))(_lst)
                For Each info In result
                    info.Members = mapper.Map(Of List(Of CommitteeMemberInfo))(_lst2.Where(Function(x) x.CommitteeId.Equals(info.CommitteeID)).ToList)
                    For Each member In info.Members
                        member.ImageUrl = myCollegeFuncs.GetDownloadUri(Me.WebController, member.ImageUrl)
                    Next
                Next
                Return Me.BuildResponse(result)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of CommitteeInfo))(ex)
        End Try
    End Function

    Public Function GetDegreeCourses(CollegeCode As String) As ResultInfo(Of List(Of DegreeCourseInfo), HttpStatusCode) Implements ICollegeRepository.GetDegreeCourses
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(CollegeCode)).FirstOrDefault
                Dim _lst = (From _c In _ctx.DegreeCourse Where (_c.CompanyId.Equals(_college.CompanyId))).ToList
                Dim _lst2 = (From _c In _ctx.ClgListSubjectView Where (_c.CompanyId.Equals(_college.CompanyId))).ToList
                Dim result = mapper.Map(Of List(Of DegreeCourseInfo))(_lst)
                'For Each course In result
                '    course.Subjects = mapper.Map(Of List(Of SubjectInfo))(_lst2.Where(Function(x) x.DegreeCourseID.Value = course.DegreeCourseID).ToList)
                'Next
                Return Me.BuildResponse(result)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of DegreeCourseInfo))(ex)
        End Try
    End Function

    Public Function GetSubjects(CollegeCode As String, CourseCode As String) As ResultInfo(Of List(Of SubjectInfo), HttpStatusCode) Implements ICollegeRepository.GetSubjects
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(CollegeCode)).FirstOrDefault
                Dim _lst = (From _c In _ctx.ClgListSubjectView Where (_c.CompanyId.Equals(_college.CompanyId)) And _c.Course.Equals(CourseCode)).ToList
                Return Me.BuildResponse(mapper.Map(Of List(Of SubjectInfo))(_lst))
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of SubjectInfo))(ex)
        End Try
    End Function

    Public Function GetDeps(CollegeCode As String) As ResultInfo(Of List(Of DepartmentInfo), HttpStatusCode) Implements ICollegeRepository.GetDeps
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(CollegeCode)).FirstOrDefault
                Dim _lst = (From _c In _ctx.Department Where (_c.CompanyId.Equals(_college.CompanyId))).ToList
                Return Me.BuildResponse(mapper.Map(Of List(Of DepartmentInfo))(_lst))
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of DepartmentInfo))(ex)
        End Try
    End Function

    Public Function GetDeptStaff(CollegeCode As String, DepCode As String) As ResultInfo(Of DepartmentInfo, HttpStatusCode) Implements ICollegeRepository.GetDeptStaff
        Try
            Using _ctx = Me.GetServerEntity
                Dim _dep = (From _c In _ctx.ClgListDepartmentView Where _c.CompCode.Equals(CollegeCode) And _c.DepCode.Equals(DepCode)).FirstOrDefault
                Dim info = mapper.Map(Of DepartmentInfo)(_dep)
                Dim _lst = (From _c In _ctx.ClgListPersonsView Where (_c.DeptId.Equals(_dep.DeptId))).OrderBy(Function(x) x.DeptRank).ToList
                info.Persons = mapper.Map(Of List(Of PersonInfo))(_lst)
                For Each info2 In info.Persons
                    info2.ImageUrl = myCollegeFuncs.GetDownloadUri(Me.WebController, info2.ImageUrl)
                Next
                Return Me.BuildResponse(info)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of DepartmentInfo)(ex)
        End Try
    End Function

    Public Function GetNonTeachingStaff(CollegeCode As String) As ResultInfo(Of List(Of PersonInfo), HttpStatusCode) Implements ICollegeRepository.GetNonTeachingStaff
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(CollegeCode)).FirstOrDefault
                Dim _lst = (From _c In _ctx.ClgListPersonsView Where (_c.Companyid.Equals(_college.CompanyId) And _c.NonTeacStaff.Equals(True))).OrderBy(Function(x) x.StaffMode).ThenBy(Function(x) x.NonTechStaffRank).ToList


                Dim result = mapper.Map(Of List(Of PersonInfo))(_lst)
                For Each info In result
                    info.ImageUrl = myCollegeFuncs.GetDownloadUri(Me.WebController, info.ImageUrl)
                Next
                Return Me.BuildResponse(result)



            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of PersonInfo))(ex)
        End Try
    End Function
    Public Function GetTeachingStaff(CollegeCode As String) As ResultInfo(Of List(Of PersonInfo), HttpStatusCode) Implements ICollegeRepository.GetTeachingStaff
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(CollegeCode)).FirstOrDefault
                Dim _lst = (From _c In _ctx.ClgListPersonsView Where (_c.Companyid.Equals(_college.CompanyId) And _c.NonTeacStaff.Equals(False))).ToList


                Dim result = mapper.Map(Of List(Of PersonInfo))(_lst)
                For Each info In result
                    info.ImageUrl = myCollegeFuncs.GetDownloadUri(Me.WebController, info.ImageUrl)
                Next
                Return Me.BuildResponse(result)



            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of PersonInfo))(ex)
        End Try
    End Function

    Public Function GetEvents(CollegeCode As String, EventType As String) As ResultInfo(Of List(Of EventInfo), HttpStatusCode) Implements ICollegeRepository.GetEvents
        Try
            Using _ctx = Me.GetServerEntity
                Dim _lst As List(Of ClgListEventDetailView), result As List(Of EventInfo)
                If String.IsNullOrEmpty(EventType) Then
                    _lst = (From _c In _ctx.ClgListEventDetailView Where (_c.CompCode.Equals(CollegeCode))).OrderByDescending(Function(x) x.Sdate).Take(10).ToList
                    result = mapper.Map(Of List(Of EventInfo))(_lst)
                Else
                    _lst = (From _c In _ctx.ClgListEventDetailView Where (_c.CompCode.Equals(CollegeCode) And _c.EventType.Equals(EventType))).OrderByDescending(Function(x) x.Sdate).Take(100).ToList
                    Dim EventIDs = _lst.Select(Function(x) x.EventId).ToList
                    Dim _lst2 = (From _c In _ctx.ClgListMediaDetailView Where (_c.CompCode.Equals(CollegeCode) And EventIDs.Contains(_c.EventId.Value))).ToList

                    result = mapper.Map(Of List(Of EventInfo))(_lst)
                    For Each info In result
                        result(0).Brochure = myCollegeFuncs.GetDownloadUri(Me.WebController, result(0).Brochure)
                        info.Media = mapper.Map(Of List(Of MediaInfo))(_lst2.Where(Function(x) x.EventId.Equals(info.EventID)).Take(5).ToList)
                        For Each infodata In info.Media
                            infodata.Url = myCollegeFuncs.GetDownloadUri(Me.WebController, infodata.Url)
                        Next
                    Next
                End If

                Return Me.BuildResponse(result)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of EventInfo))(ex)
        End Try
    End Function
    Public Function GetEvent(Id As Integer) As ResultInfo(Of EventInfo, HttpStatusCode) Implements ICollegeRepository.GetEvent
        Try
            Using _ctx = Me.GetServerEntity
                Dim _info = (From _c In _ctx.ClgListEventDetailView Where (_c.EventId.Equals(Id))).FirstOrDefault
                Dim _lst2 = (From _c In _ctx.ClgListMediaDetailView Where (_c.EventId.Equals(Id))).ToList

                Dim result = mapper.Map(Of EventInfo)(_info)
                result.Media = mapper.Map(Of List(Of MediaInfo))(_lst2)
                For Each infodata In result.Media
                    infodata.Url = myCollegeFuncs.GetDownloadUri(Me.WebController, infodata.Url)
                Next

                Return Me.BuildResponse(result)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of EventInfo)(ex)
        End Try
    End Function

    Public Function GetActivities(CollegeCode As String) As ResultInfo(Of List(Of ActivityInfo), HttpStatusCode) Implements ICollegeRepository.GetActivities
        Try
            Using _ctx = Me.GetServerEntity
                Dim _lst = (From _c In _ctx.ClgListActivityView Where (_c.CompCode.Equals(CollegeCode))).OrderByDescending(Function(x) x.Dated).Take(100).ToList
                Dim ActivityIDs = _lst.Select(Function(x) x.ActivityID).ToList
                Dim _lst2 = (From _c In _ctx.ClgListMediaDetailView Where (_c.CompCode.Equals(CollegeCode) And ActivityIDs.Contains(_c.ActivityId.Value))).ToList

                Dim result = mapper.Map(Of List(Of ActivityInfo))(_lst)
                For Each info In result
                    info.Media = mapper.Map(Of List(Of MediaInfo))(_lst2.Where(Function(x) x.ActivityId.Equals(info.ActivityID)).Take(5).ToList)
                    For Each infodata In info.Media
                        infodata.Url = myCollegeFuncs.GetDownloadUri(Me.WebController, infodata.Url)
                    Next
                Next

                Return Me.BuildResponse(result)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of ActivityInfo))(ex)
        End Try
    End Function
    Public Function GetActivity(Id As Integer) As ResultInfo(Of ActivityInfo, HttpStatusCode) Implements ICollegeRepository.GetActivity
        Try
            Using _ctx = Me.GetServerEntity
                Dim _info = (From _c In _ctx.ClgListActivityView Where (_c.ActivityId.Equals(Id))).FirstOrDefault
                Dim _lst2 = (From _c In _ctx.ClgListMediaDetailView Where (_c.ActivityId.Value.Equals(Id))).ToList

                Dim result = mapper.Map(Of ActivityInfo)(_info)
                result.Media = mapper.Map(Of List(Of MediaInfo))(_lst2)
                For Each infodata In result.Media
                    infodata.Url = myCollegeFuncs.GetDownloadUri(Me.WebController, infodata.Url)
                Next

                Return Me.BuildResponse(result)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of ActivityInfo)(ex)
        End Try
    End Function

    Public Function GetAlumni(CollegeCode As String) As ResultInfo(Of List(Of AlumniInfo), HttpStatusCode) Implements ICollegeRepository.GetAlumni
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(CollegeCode)).FirstOrDefault
                Dim _lst = (From _c In _ctx.ClgListAlumniView Where (_c.CompanyId.Equals(_college.CompanyId))).ToList
                For Each info In _lst
                    info.PicAlumni = myCollegeFuncs.GetDownloadUri(Me.WebController, info.PicAlumni)
                Next
                Return Me.BuildResponse(mapper.Map(Of List(Of AlumniInfo))(_lst))
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of AlumniInfo))(ex)
        End Try
    End Function

    Public Function GetNAAC(CollegeCode As String) As ResultInfo(Of List(Of NAACInfo), HttpStatusCode) Implements ICollegeRepository.GetNAAC
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(CollegeCode)).FirstOrDefault
                Dim _lst = (From _c In _ctx.ClgListNaaC Where (_c.CompanyId.Equals(_college.CompanyId))).ToList
                Dim result = mapper.Map(Of List(Of NAACInfo))(_lst)
                For Each info In result
                    info.IQAC = myCollegeFuncs.GetDownloadUri(Me.WebController, info.IQAC)
                    info.AQAR = myCollegeFuncs.GetDownloadUri(Me.WebController, info.AQAR)
                    info.SSR = myCollegeFuncs.GetDownloadUri(Me.WebController, info.SSR)
                    info.AgendaMinutes = myCollegeFuncs.GetDownloadUri(Me.WebController, info.AgendaMinutes)
                Next





                Return Me.BuildResponse(result)
                'Return Me.BuildResponse(mapper.Map(Of List(Of NAACInfo))(_lst))
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of NAACInfo))(ex)
        End Try
    End Function

    Public Function GetCollegeInfo(CollegeCode As String) As ResultInfo(Of CollegeInfo, HttpStatusCode) Implements ICollegeRepository.GetCollegeInfo
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(CollegeCode)).FirstOrDefault
                Dim info = mapper.Map(Of CollegeInfo)(_college)
                info.CollegeProsURL = myCollegeFuncs.GetDownloadUri(Me.WebController, info.CollegePros)
                info.AcademicCalendarURL = myCollegeFuncs.GetDownloadUri(Me.WebController, info.AcademicCalender)
                Return Me.BuildResponse(info)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of CollegeInfo)(ex)
        End Try
    End Function

    Public Async Function PostAlumni(info As AlumniInfo) As Task(Of ResultInfo(Of Integer, HttpStatusCode)) Implements ICollegeRepository.PostAlumni
        Try
            Using _ctx = Me.GetServerEntity
                Dim _alumni = mapper.Map(Of Alumni)(info)
                If info.PicAlumni Is Nothing Then
                    Dim client = Me.WebController.App.objAppExtender.FileProviderClient(Me.WebController, myPathUtils.GetContainerName(Me.WebController))
                    Dim ms = New MemoryStream(info.bPicAlumni)
                    Dim BlobName = Await client.UploadStreamAsync(ms, System.Guid.NewGuid.ToString, "alumni")
                    _alumni.PicAlumni = BlobName
                End If
                _ctx.Alumni.Add(_alumni)
                _ctx.SaveChanges()
                Return Me.BuildResponse(mapper.Map(Of Integer)(_alumni.AlumniId))
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of Integer)(ex)
        End Try
    End Function

    Public Function GetFinYears() As ResultInfo(Of List(Of FinYearsInfo), HttpStatusCode) Implements ICollegeRepository.GetFinYears
        Try
            Using _ctx = Me.GetServerEntity
                Dim _lst = (From _c In _ctx.FinYears).ToList
                Dim result = mapper.Map(Of List(Of FinYearsInfo))(_lst)
                Return Me.BuildResponse(result)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of FinYearsInfo))(ex)
        End Try
    End Function

    Public Function GetNoticeBoard(Code As String) As ResultInfo(Of List(Of NoticeBoardInfo), HttpStatusCode) Implements ICollegeRepository.GetNoticeBoard
        Try
            Using _ctx = Me.GetServerEntity
                Dim _college = (From _c In _ctx.Company Where _c.CompCode.Equals(Code)).FirstOrDefault
                Dim _lst = (From _c In _ctx.NoticeBoard Where _c.CompanyId.Equals(_college.CompanyId)).OrderByDescending(Function(x) x.Dated).Take(10).ToList

                Dim result = mapper.Map(Of List(Of NoticeBoardInfo))(_lst)

                Return Me.BuildResponse(result)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of List(Of NoticeBoardInfo))(ex)
        End Try
    End Function

    Public Function GetNotice(Id As Integer) As ResultInfo(Of NoticeBoardInfo, HttpStatusCode) Implements ICollegeRepository.GetNotice
        Try
            Using _ctx = Me.GetServerEntity
                Dim _notice = (From _c In _ctx.NoticeBoard Where _c.NoticeBoardId.Equals(Id)).FirstOrDefault

                Dim result = mapper.Map(Of NoticeBoardInfo)(_notice)

                Return Me.BuildResponse(result)
            End Using

        Catch ex As Exception
            Return BuildExceptionResponse(Of NoticeBoardInfo)(ex)
        End Try
    End Function
End Class
'https://stackoverflow.com/questions/59739568/ef-core-linq-operator-in-vb-net