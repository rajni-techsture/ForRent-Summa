Public Class html_toImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       

    End Sub

    Private Sub btn_ServerClick(sender As Object, e As System.EventArgs) Handles btn.ServerClick
        Dim siteUrl As String = "test_banner.aspx"
        Dim browserWidth As Integer = Convert.ToInt32(800)
        Dim browserHeight As Integer = Convert.ToInt32(600)
        Dim thumbnailWidth As Integer = Convert.ToInt32(800)
        Dim thumbnailHeight As Integer = Convert.ToInt32(600)
        Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
        Dim fullPath As String = Server.MapPath(relativeImagePath)
        Dim strDate As DateTime
        strDate = System.DateTime.Now
        Dim strD As [String] = strDate.ToString().Replace(" ", "-").Replace("/", "-") + ".jpg"
        If Not fullPath.EndsWith("\") Then
            fullPath += "\"
        End If
        Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, 220, 650, 220, 640, fullPath, strD), System.Drawing.Image)
    End Sub
End Class