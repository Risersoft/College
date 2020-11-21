Imports System.IO
Imports System.Net
Imports klts.app.mxform.admin
Imports risersoft.shared.portable.Model
Imports risersoft.shared.portable.Models
Imports risersoft.shared.cloud.IRepository

Public Interface ICollegeRepository
    Inherits IRepositoryBase(Of Boolean, RSCallerInfo, HttpStatusCode)

    Function GetCommitteeMembers(Code As String) As ResultInfo(Of List(Of CommitteeInfo), HttpStatusCode)
    Function GetFinYears() As ResultInfo(Of List(Of FinYearsInfo), HttpStatusCode)
    Function GetDegreeCourses(Code As String) As ResultInfo(Of List(Of DegreeCourseInfo), HttpStatusCode)
    Function GetSubjects(CollegeCode As String, CourseCode As String) As ResultInfo(Of List(Of SubjectInfo), HttpStatusCode)
    Function GetDeps(Code As String) As ResultInfo(Of List(Of DepartmentInfo), HttpStatusCode)
    Function GetDeptStaff(CollegeCode As String, DepCode As String) As ResultInfo(Of DepartmentInfo, HttpStatusCode)
    Function GetNonTeachingStaff(Code As String) As ResultInfo(Of List(Of PersonInfo), HttpStatusCode)
    Function GetTeachingStaff(Code As String) As ResultInfo(Of List(Of PersonInfo), HttpStatusCode)
    Function GetEvents(Code As String, EventType As String) As ResultInfo(Of List(Of EventInfo), HttpStatusCode)
    Function GetEvent(Id As Integer) As ResultInfo(Of EventInfo, HttpStatusCode)
    Function GetActivities(Code As String) As ResultInfo(Of List(Of ActivityInfo), HttpStatusCode)
    Function GetActivity(Id As Integer) As ResultInfo(Of ActivityInfo, HttpStatusCode)
    Function GetNoticeBoard(Code As String) As ResultInfo(Of List(Of NoticeBoardInfo), HttpStatusCode)
    Function GetNotice(Id As Integer) As ResultInfo(Of NoticeBoardInfo, HttpStatusCode)
    Function GetAlumni(Code As String) As ResultInfo(Of List(Of AlumniInfo), HttpStatusCode)
    Function GetNAAC(Code As String) As ResultInfo(Of List(Of NAACInfo), HttpStatusCode)
    Function GetCollegeInfo(Code As String) As ResultInfo(Of CollegeInfo, HttpStatusCode)

    Function PostAlumni(info As AlumniInfo) As Task(Of ResultInfo(Of Integer, HttpStatusCode))
End Interface
