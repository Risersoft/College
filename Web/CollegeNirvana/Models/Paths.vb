Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public NotInheritable Class Paths
	Private Sub New()
	End Sub
    ''' <summary>
    ''' AuthorizationServer project should run on this URL
    ''' </summary>
    Public Const AuthorizationServerBaseAddress As String = "http://localhost:11626"

    ''' <summary>
    ''' ResourceServer project should run on this URL
    ''' </summary>
    Public Const ResourceServerBaseAddress As String = "http://localhost:38385"

    ''' <summary>
    ''' ImplicitGrant project should be running on this specific port '38515'
    ''' </summary>
    Public Const ImplicitGrantCallBackPath As String = "http://localhost:38515/Account/LoginToken"

    ''' <summary>
    ''' AuthorizationCodeGrant project should be running on this URL.
    ''' </summary>
    Public Const AuthorizeCodeCallBackPath As String = "http://localhost:38500/"

    Public Const MePath As String = "/api/Me"
End Class
