Imports risersoft.app.mxform.edu
Imports risersoft.app2.shared
Imports risersoft.shared.cloud
Imports risersoft.shared.dotnetfx
Imports risersoft.app.edu
Imports klts.app.mxform.admin
Imports risersoft.app.mxform.college
Imports Newtonsoft.Json

Public Class Utils
    Public Shared Sub Main(args() As String)
        myApp = New clsRSWinCloudApp(New clsExtendAppEdu)
        myWinApp.CheckInitConsole(args)

        Dim fMain As frmMax = AppStarter.StartWinFormApp(args)
        If Not fMain Is Nothing Then
            'TestImportAdmission()
            'TestImportExamDet()
            'MoveBlobs()
            Application.Run(fMain)
        End If
    End Sub
    Private Shared Async Sub MoveBlobs()
        Dim sql As String = "select * from mediadetail"
        Dim dt1 = myApp.Controller.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
        Dim provider As New clsBlobFileProvider(myApp.Controller)
        Await provider.InitContainer("DefaultEndpointsProtocol=https;AccountName=rstest2;AccountKey=QKZSkJudSPxM19Z/MLPQI7bao2VIyf56Og4BROGd5aefGRUldB+QgaRD7F0rqBoZAB4+6qarYoeATQICdZw2Bg==", "content")
        For Each r1 As DataRow In dt1.Select
            Dim oRet = Await provider.MoveBlobAsync(r1("url").ToString, "content", "content-" & r1("tenantid").ToString)
            Trace.WriteLine($"{r1("url").ToString}: {oRet.Message}, {oRet.Success}")
        Next
    End Sub

    'Private Shared Sub TestImportAdmission()
    '    Dim importer As New Import_AdmissionTaskProvider(myApp.Controller)
    '    importer.ExecuteImport("E:\Import Test Files\CollegeNirvana Import Test Files\Admission3(2).xlsx", "info@risersoft.com", Guid.NewGuid.ToString)
    'End Sub

    Private Shared Sub TestImportAdmission()
        Dim importer As New Import_AdmissionTaskProvider(myApp.Controller)
        myApp.Controller.GetAppInfo.AppBarValues = JsonConvert.DeserializeObject(Of List(Of AppBarFilterValue))("[{""VarName"":""cid"",""FieldName"":""companyid"",""FieldValue"":""30"",""dicValues"":{""companyid"":30,""compname"":""Kanohar Lal Post Graduate Girls College"",""pannum"":null}}]")
        importer.ExecuteImport("E:\Import Test Files\CollegeNirvana Import Test Files\Admission3(2).xlsx", "info@risersoft.com", Guid.NewGuid.ToString)
    End Sub

    Private Shared Sub TestImportExamDet()
        Dim importer As New Import_ExamDetTaskProvider(myApp.Controller)
        importer.ExecuteImport("E:\Import Test Files\CollegeNirvana Import Test Files\ExamDet.xlsx", "info@risersoft.com", Guid.NewGuid.ToString)
    End Sub

    Private Shared Sub populateProviderKey()
        Dim sql As String = "select * from users"
        Dim dt1 As DataTable = myApp.Controller.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

        Dim lst = WinAdHelper.GetDomainUsers(Environment.UserDomainName)
        For Each r1 As DataRow In dt1.Select
            Dim user = lst.Where(Function(x)
                                     Return myUtils.IsInList(r1("email"), x.Email)
                                 End Function).FirstOrDefault
            If user IsNot Nothing Then
                r1("providerkey") = user.ObjectId
            End If
        Next
        myApp.Controller.DataProvider.objSQLHelper.SaveResults(dt1, sql)
    End Sub
End Class
