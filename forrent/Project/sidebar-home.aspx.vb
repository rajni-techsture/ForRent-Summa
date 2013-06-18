Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer
Imports Facebook
Imports System.Threading
Public Class sidebar_home
    Inherits System.Web.UI.Page
    Public strPageId As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim obj As New BAlsidebar
                Dim ds1 As New DataSet
                obj.Page = CStr(HttpContext.Current.Request.Url.AbsolutePath)

                ds1 = obj.GetVideoTutorial()

                If HttpContext.Current.Request.Url.AbsolutePath = ds1.Tables(0).Rows(0).Item("vt_Page").ToString Then
                    'strVideo1.HRef = ds1.Tables(0).Rows(0).Item("vt_Video").ToString & "?fs=1&autoplay=1&rel=0&enablejsapi=1&playerapiid=ytplayer"
                    'strVideo1.Title = ds1.Tables(0).Rows(0).Item("vt_Title").ToString
                    'btnVideo.HRef = ds1.Tables(0).Rows(0).Item("vt_Video").ToString & "?fs=1&autoplay=1&rel=0&enablejsapi=1&playerapiid=ytplayer"
                    'btnVideo.Title = ds1.Tables(0).Rows(0).Item("vt_Title").ToString
                    imgsidebar.Src = ds1.Tables(0).Rows(0).Item("vt_VideoThumbnail").ToString
                End If

                Dim dsimage As New DataSet
                Dim objBALimage As New BAlsidebar
                objBALimage.PageIndex = 0 'ViewState("currentpageindex")
                objBALimage.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
                objBALimage.IndustryId = 1 ' GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
                dsimage = objBALimage.GetSidebarMasterByCompOrIndustry
                If dsimage.Tables(1).Rows.Count > 0 Then
                    imgtop.Src = "Content/images/sidebar/" & dsimage.Tables(1).Rows(0).Item("sdm_image").ToString()
                Else
                    lblNoSidebar1.Visible = True
                    pnlSidebar.Visible = False
                End If

                If Page.IsPostBack = False Then
                    bindTotalFanPage()
                    bind_mySidebars(0)
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            ''  lblMessage.Text = "Error: " & ex.Message
        End Try
        'imgsidebar.Src = "Content/images/video_img.jpg"

        'strVideo1.HRef = "http://www.youtube.com/v/pp_CLpsmjo0"
        'strVideo1.Title = "Watch Sidebar Videos"
    End Sub

    Sub bindTotalFanPage()
        Dim accessToken As String = Session("FacebookAccessToken")
        Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
        Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
        Dim url As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,category,access_token&return_ssl_resources=true&access_token={0}"
        Dim request As WebRequest = WebRequest.Create(String.Format(url, accessToken))
        Dim response1 As WebResponse = request.GetResponse()
        Dim stream As Stream = response1.GetResponseStream()
        Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FanPage))

        Dim fPage As New FanPage()
        fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), FanPage)
        Dim listPages As New List(Of FanPage.m_data)

        For Each item1 As FanPage.m_data In fPage.data
            listPages.Add(item1)
        Next

        Dim cnt As Integer = listPages.Count
        Dim aid As String = ""
        For i As Integer = 0 To cnt - 1
            strPageId = strPageId + listPages.Item(i).id & ","
            Session("strPageId") = strPageId
        Next
    End Sub
    Private Sub bind_mySidebars(ByVal direction As Integer)
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            If Not Session("SiteUserId") Is Nothing Then
                Dim ds As New DataSet
                Dim obj As New BAlsidebar
                obj.UserId = Session("SiteUserId")
                obj.FBUserId = Session("FacebookUserId")
                obj.FBPageId = Session("strPageId") 'strPageId
                obj.Cid = hdnSidebar.Value
                obj.Direction = direction
                'Response.Write(Session("SiteUserId") & "FBUSErId: " & Session("FacebookUserId") & "PageID:" & Session("strPageId") & "sidebarId : " & hdnSidebar.Value & "Direction" & direction)
                ds = obj.GetMySidebars()
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0).Item("sd_Image") = "" Then
                        imgMySidebar.Src = "/content/images/nomysidebar.jpg"
                    Else
                        ltrName.Text = ds.Tables(0).Rows(0).Item("sd_Name").ToString
                        imgMySidebar.Src = "/uploads/" & ds.Tables(0).Rows(0).Item("sd_Image")
                        hdnImageName.Value = ds.Tables(0).Rows(0).Item("sd_Image")

                    End If
                    hdnSidebar.Value = ds.Tables(0).Rows(0).Item("sd_Id")
                    hdnMasterId.Value = ds.Tables(0).Rows(0).Item("sd_Id")
                Else
                    imgMySidebar.Style.Add("display", "none")
                    lblNoSidebar.Visible = True
                    ibtnNext.Visible = False
                    ibtnPre.Visible = False
                End If
            End If
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    Private Sub ibtnNext_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnNext.Click
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            bind_mySidebars(1)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    Private Sub ibtnPre_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnPre.Click
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            bind_mySidebars(0)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    'Private Sub lnlDelete_Click(sender As Object, e As System.EventArgs) Handles lnlDelete.Click
    '    If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
    '        Dim ds As New DataSet
    '        Dim obj As New BAlsidebar
    '        obj.UserId = 1 'Session("SiteUserId")
    '        obj.Cid = hdnSidebar.Value
    '        obj.DeleteMySidebars()
    '        hdnSidebar.Value = 0
    '        bind_mySidebars(1)
    '    Else
    '        Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
    '    End If
    'End Sub

    Private Sub lnlPublish_Click(sender As Object, e As System.EventArgs) Handles lnlPublish.Click
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            If hdnImageName.Value <> "0" Then
                Response.Redirect("sidebar.aspx?id=-" & hdnSidebar.Value)
            End If
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    Private Sub lnkdelete1_ServerClick(sender As Object, e As System.EventArgs) Handles lnkdelete1.ServerClick
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim ds As New DataSet
            Dim obj As New BAlsidebar
            obj.UserId = Session("SiteUserId")
            obj.Cid = hdnSidebar.Value
            obj.DeleteMySidebars()
            hdnSidebar.Value = 0
            bind_mySidebars(1)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    Private Sub lnkCopy_ServerClick(sender As Object, e As System.EventArgs) Handles lnkCopy.ServerClick
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim ds As New DataSet
            Dim obj As New BAlsidebar
            obj.UserId = Session("SiteUserId")
            obj.FBUserId = Session("FacebookUserId")
            obj.Cid = hdnSidebar.Value
            ds = obj.CopyMySidebars()
            If ds.Tables(0).Rows.Count > 0 Then
                Response.Redirect("sidebar.aspx?id=" & ds.Tables(0).Rows(0).Item("CopyId"))
            End If
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub
End Class