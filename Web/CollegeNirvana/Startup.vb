Imports System.Net
Imports Microsoft.Owin
Imports Owin

<Assembly: OwinStartup(GetType(CollegeNirvana.Startup))>

Partial Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        ConfigureAuth(app)
        'ServicePointManager.ServerCertificateValidationCallback = Function()
        '                                                              Return True
        '                                                          End Function

    End Sub
End Class
