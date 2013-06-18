Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer
Imports Facebook
Imports System.Threading
Public Class setup_page
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim obj As New BAlsidebar
                Dim ds1 As New DataSet
                obj.Page = CStr(HttpContext.Current.Request.Url.AbsolutePath)

                ds1 = obj.GetVideoTutorial()

                If HttpContext.Current.Request.Url.AbsolutePath = ds1.Tables(0).Rows(0).Item("vt_Page").ToString Then

                    strVideo1.HRef = ds1.Tables(0).Rows(0).Item("vt_Video").ToString & "?fs=1&autoplay=1&rel=0&enablejsapi=1&playerapiid=ytplayer"
                    strVideo1.Title = ds1.Tables(0).Rows(0).Item("vt_Title").ToString
                    btnVideo.HRef = ds1.Tables(0).Rows(0).Item("vt_Video").ToString & "?fs=1&autoplay=1&rel=0&enablejsapi=1&playerapiid=ytplayer"
                    btnVideo.Title = ds1.Tables(0).Rows(0).Item("vt_Title").ToString
                    imgcreatepage.Src = ds1.Tables(0).Rows(0).Item("vt_VideoThumbnail").ToString
                End If

            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            '  lblMessage.Text = "Error: " & ex.Message
        End Try
        'imgsidebar.Src = "Content/images/video_img.jpg"

        'strVideo1.HRef = "http://www.youtube.com/v/pp_CLpsmjo0"
        'strVideo1.Title = "Watch Sidebar Videos"
        'imgcreatepage.Src = "Content/images/video_img.jpg"

        'strVideo1.HRef = "http://www.youtube.com/v/yz-bJQtSAx0?fs=1&autoplay=1&rel=0&enablejsapi=1&playerapiid=ytplayer"
        'strVideo1.Title = "Setup A New Page"

    End Sub

End Class