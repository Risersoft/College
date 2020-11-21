Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Controllers
Imports risersoft.app.mxform.college
Imports risersoft.shared.web.Controllers
Imports klts.app.mxform.admin
Imports System.Threading.Tasks
''' <summary>
''' ESS Controller
''' </summary>
''' <remarks></remarks>
<RoutePrefix("api/Data")>
Public Class DataController
    Inherits ServerApiController(Of Boolean, HttpStatusCode, ICollegeRepository)

    Public Sub New(repository As ICollegeRepository)
        MyBase.New(repository)
    End Sub
    Protected Overrides Sub Initialize(controllerContext As HttpControllerContext)
        MyBase.Initialize(controllerContext)
        Dim EssAppCode = "nclginfo"
        repository.WebController.CheckInitModel(New clsAppInfo With {.AppCode = EssAppCode},
                                                True)
    End Sub
    <Route("Committee")>
    Public Function GetCommitteeMembers(Code As String) As IHttpActionResult
        Dim result = repository.GetCommitteeMembers(Code)
        Return Ok(result)
    End Function

    <Route("Courses")>
    Public Function GetDegreeCourses(Code As String) As IHttpActionResult
        Dim result = repository.GetDegreeCourses(Code)
        Return Ok(result)
    End Function
    <Route("Subjects")>
    Public Function GetSubjects(CollegeCode As String, CourseCode As String) As IHttpActionResult
        Dim result = repository.GetSubjects(CollegeCode, CourseCode)
        Return Ok(result)
    End Function
    <Route("Deps")>
    Public Function GetDeps(Code As String) As IHttpActionResult
        Dim result = repository.GetDeps(Code)
        Return Ok(result)
    End Function
    <Route("DeptStaff")>
    Public Function GetDeptStaff(CollegeCode As String, DepCode As String) As IHttpActionResult
        Dim result = repository.GetDeptStaff(CollegeCode, DepCode)
        Return Ok(result)
    End Function
    <Route("NonTeachingStaff")>
    Public Function GetNonTeachingStaff(Code As String) As IHttpActionResult
        Dim result = repository.GetNonTeachingStaff(Code)
        Return Ok(result)
    End Function
    <Route("TeachingStaff")>
    Public Function GetTeachingStaff(Code As String) As IHttpActionResult
        Dim result = repository.GetTeachingStaff(Code)
        Return Ok(result)
    End Function
    <Route("Events")>
    Public Function GetEvents(Code As String, EventType As String) As IHttpActionResult
        Dim result = repository.GetEvents(Code, EventType)
        Return Ok(result)
    End Function
    <Route("Event")>
    Public Function GetEvent(Id As Integer) As IHttpActionResult
        Dim result = repository.GetEvent(Id)
        Return Ok(result)
    End Function
    <Route("Activities")>
    Public Function GetActivities(Code As String) As IHttpActionResult
        Dim result = repository.GetActivities(Code)
        Return Ok(result)
    End Function
    <Route("Activity")>
    Public Function GetActivity(Id As Integer) As IHttpActionResult
        Dim result = repository.GetActivity(Id)
        Return Ok(result)
    End Function
    <Route("Alumni")> <HttpGet>
    Public Function GetAlumni(Code As String) As IHttpActionResult
        Dim result = repository.GetAlumni(Code)
        Return Ok(result)
    End Function
    <Route("NAAC")>
    Public Function GetNAAC(Code As String) As IHttpActionResult
        Dim result = repository.GetNAAC(Code)
        Return Ok(result)
    End Function
    <Route("College")>
    Public Function GetCollegeInfo(Code As String) As IHttpActionResult
        Dim result = repository.GetCollegeInfo(Code)
        Return Ok(result)
    End Function
    <Route("Alumni")> <HttpPost>
    Public Async Function PostAlumni(info As AlumniInfo) As Task(Of IHttpActionResult)
        Dim result = Await repository.PostAlumni(info)
        Return Ok(result)
    End Function
    <Route("FY")>
    Public Function GetFinYearsInfo() As IHttpActionResult
        Dim result = repository.GetFinYears()
        Return Ok(result)
    End Function
    <Route("noticeboard")>
    Public Function GetNoticeBoard(Code As String) As IHttpActionResult
        Dim result = repository.GetNoticeBoard(Code)
        Return Ok(result)
    End Function
    <Route("notice")>
    Public Function GetNotice(Id As Integer) As IHttpActionResult
        Dim result = repository.GetNotice(Id)
        Return Ok(result)
    End Function
End Class
'http://stackoverflow.com/questions/24080018/download-file-from-an-asp-net-web-api-method-using-angularjs
