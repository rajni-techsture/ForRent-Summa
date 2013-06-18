Imports Microsoft.VisualBasic
Imports System.Web.Routing
Imports System.Security
Imports System.Web.Compilation
Imports System.Web.UI
Imports System.Data
Public Class WPageHandler
    Implements IRouteHandler

    Public VirtualPath As String
    Public CheckPhysicalUrlAccess As Boolean

    ' Methods
    Public Sub New(ByVal virtualPath As String)
        Me.New(virtualPath, True)
    End Sub

    Public Sub New(ByVal virtualPath As String, ByVal checkPhysicalUrlAccess As Boolean)
        Me.VirtualPath = virtualPath
        Me.CheckPhysicalUrlAccess = checkPhysicalUrlAccess
    End Sub

    Public Function GetHttpHandler(ByVal requestContext As RequestContext) As System.Web.IHttpHandler Implements IRouteHandler.GetHttpHandler
        Me.VirtualPath = Me.VirtualPath
        'HttpContext.Current.Response.Write(Me.VirtualPath)
        Try
            Dim ds As New DataSet

            If ds.Tables.Count > 0 Then
                Dim strCurrentUrl As String = HttpContext.Current.Request.Url.ToString()
                For Each dr As DataRow In ds.Tables(0).Rows
                    If strCurrentUrl = dr.Item("r_oldurl") Then
                        HttpContext.Current.Response.Clear()
                        HttpContext.Current.Response.Status = "301 Moved Permanently"
                        HttpContext.Current.Response.AddHeader("Location", dr.Item("r_newurl"))
                        'HttpContext.Current.Response.Redirect(dr.Item("r_newurl"))
                        HttpContext.Current.Response.End()
                        Exit Function
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
        If (Me.CheckPhysicalUrlAccess AndAlso Not System.Web.Security.UrlAuthorizationModule.CheckUrlAccessForPrincipal(Me.VirtualPath, requestContext.HttpContext.User, requestContext.HttpContext.Request.HttpMethod)) Then
            Throw New SecurityException
        End If

        Dim page As System.Web.IHttpHandler = TryCast(BuildManager.CreateInstanceFromVirtualPath(Me.VirtualPath, GetType(Page)), IHttpHandler)

        If (Not page Is Nothing) Then
            Dim routablePage As IRoutablePage = TryCast(page, IRoutablePage)
            If (Not routablePage Is Nothing) Then
                routablePage.RequestContext = requestContext
            End If
        End If

        Return page

    End Function
End Class
