Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports System.IO
Imports Facebook
'Imports Facebook.FacebookClient
Imports System.Threading
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Xml
Imports System.Collections
Imports System.String
Imports System.Text
Imports System.Configuration
Imports System.Data

Public Class Remove_Post
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        removePost("AAACdlKQ8ZAP0BAFaLO9w7TJM3TQx5GbOiJYHvrBzgUqZAWdWVpXhh89uZA6FCfZCgEO43Nyf7PnZCuJnwmuIWRSOhiJT50zlDkPNW9Nx6rruenJZCZCDE8oXrmmKgmZA0uMZD", "103867749667879", "103867749667879_395281887193129")
    End Sub

    '''<summary\>
    ''' Remove post from facebook fanpage wall
    '''</summary\>
    '''<param name="accesstoken"\>user access token</param>
    '''<param name="fanPageId"\>Fan Page Id</param>
    '''<param name="contentId"\>Post or Comment Id </param>
    Public Sub removePost(accesstoken As String, fanPageId As String, contentId As String)
        Dim fb = New FacebookClient()
        Dim args1 = New Dictionary(Of String, Object)()
        args1("access_token") = accesstoken
        args1("uid") = fanPageId
        'args1("link") = ds.Tables(0).Rows(i).Item("apm_VideoLink").ToString
        'Dim parameters As dynamic = New ExpandoObject()
        'parameters.access_token = accesstoken
        'parameters.uid = fanPageId
        'pass the content id you like to remove - pageid_postid format
        If fb.Delete(contentId, args1) Then
            lblDelete.Text = "Delete Success!"
        Else
            lblDelete.Text = "Delete failed!"
        End If
    End Sub

End Class