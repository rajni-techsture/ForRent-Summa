Public Class view_video
    Inherits System.Web.UI.Page
    Public strVideo As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Request.QueryString("video").ToString() <> "") Then
            strVideo = Request.QueryString("video").ToString()
        End If
    End Sub

End Class