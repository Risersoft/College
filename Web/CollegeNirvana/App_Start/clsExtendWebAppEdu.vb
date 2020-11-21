Imports System.Threading
Imports System.Threading.Tasks
Imports klts.app.mxform.admin
Imports risersoft.app
Imports risersoft.app.mxent
Imports risersoft.app.mxform
Imports risersoft.app.mxform.college
Imports risersoft.app.mxform.edu
Imports risersoft.shared
Imports risersoft.shared.agent
'Imports risersoft.shared.agent
Imports risersoft.shared.cloud
Imports risersoft.shared.dotnetfx
Imports risersoft.shared.portable.Models.Nav
Imports risersoft.shared.web
Imports risersoft.shared.web.mvc

Public Class clsExtendWebAppEdu
    Inherits clsExtendWebAppBase


    Public Overrides Function NewDBName() As String
        Return "mxcollegedb"
    End Function

    Public Overrides Function ProgramCode() As String
        Return "mxedu"
    End Function

    Public Overrides Function ProgramName() As String
        Return "CollegeNirvana"
    End Function

    Public Overrides Function StartupAppCode() As String
        Return ""
    End Function

    Public Overrides Function dicFormModelTypes() As clsCollecString(Of Type)
        If dicFormModel Is Nothing Then
            dicFormModel = New clsCollecString(Of Type)
            Me.AddTypeAssembly(dicFormModel, GetType(frmCompanyModel).Assembly, GetType(clsFormDataModel))
            Me.AddTypeAssembly(dicFormModel, GetType(frmPayPeriodModel).Assembly, GetType(clsFormDataModel))
            Me.AddTypeAssembly(dicFormModel, GetType(frmCommentModel).Assembly, GetType(clsFormDataModel))
        End If
        Return dicFormModel
    End Function
    Public Overrides Function dicReportProviderTypes(myContext As clsAppController) As clsCollecString(Of Type)
        If dicReportModelProvider Is Nothing Then
            dicReportModelProvider = New clsCollecString(Of Type)
            'Me.AddTypeAssembly(dicReportModelProvider, GetType(reports.erp.hrpReportDataProvider).Assembly, GetType(clsReportDataProviderBase))
        End If
        Return dicReportModelProvider
    End Function

    Public Overrides Function HelpSite() As String
        'Throw New NotImplementedException()
        Return "http://docs.collegenirvana.in"
    End Function

    Public Overrides Function dicTaskProviderTypes() As clsCollecString(Of Type)
        If dicTaskProvider Is Nothing Then
            dicTaskProvider = New clsCollecString(Of Type)
            Me.AddTypeAssembly(dicTaskProvider, GetType(EVTaskProvider).Assembly, GetType(clsTaskProviderBase))
            Me.AddTypeAssembly(dicTaskProvider, GetType(Import_AdmissionTaskProvider).Assembly, GetType(clsTaskProviderBase))
            Me.AddTypeAssembly(dicTaskProvider, GetType(PDFTaskProvider).Assembly, GetType(clsTaskProviderBase))
        End If
        Return dicTaskProvider
    End Function

    Public Overrides Function AppBarFieldList() As IDictionary(Of String, String)
        Dim dic As New Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
        dic.Add("companyid", "cid")
        Return dic
    End Function
    Public Overrides Function LoadAppData(context As IProviderContext, dataKey As String, Params As List(Of clsSQLParam), forcefresh As Boolean) As clsProcOutput
        Return myCollegeFuncs.LoadAppData(context, dataKey, Params, forcefresh, Function()
                                                                                    Return MyBase.LoadAppData(context, dataKey, Params, forcefresh)
                                                                                End Function)
    End Function
End Class


