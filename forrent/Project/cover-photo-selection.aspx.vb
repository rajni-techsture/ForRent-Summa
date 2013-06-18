Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports System.Drawing.Image
Imports BusinessAccessLayer.BusinessLayer
Imports Facebook
Imports System.Threading

Public Class cover_photo_selection
    Inherits System.Web.UI.Page
    Public strFBUserId As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoginCheck.LoginSessionCheck()
        If Not Page.IsPostBack Then
            Try
                strFBUserId = Session("FacebookUserId").ToString
                hdnFBUserId.Value = Session("FacebookUserId").ToString
                If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                    'hdnIsSaved.Value = "0"
                    Dim obj As New BALCoverPhoto
                    Dim ds1 As New DataSet
                    obj.Page = "/cover-photo"
                    ds1 = obj.GetVideoTutorial()
                    Dim videostring As String
                    videostring = Replace(ds1.Tables(0).Rows(0).Item("vt_Video").ToString, "watch?v=", "v/")
                    spnVideo.InnerHtml = "<object style='height: 335px; width: 555px'><param name='movie' value='" & videostring & "'><param name='allowFullScreen' value='true'><param name='allowScriptAccess' value='always'><param name='wmode' value='transparent'><embed src='" & videostring & "' type='application/x-shockwave-flash' allowfullscreen='true' allowScriptAccess='always' width='555' height='335'></object>"
                    If Request.QueryString("cpId") <> "" And IsNumeric(Request.QueryString("cpId")) Then
                        'BindSavedCoverPhoto()
                        BindCoverPhoto()
                    End If
                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
                End If
            Catch ex As Exception
                If ex.Message.Contains("The remote server returned an error: (400)") Then
                    Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide11;", ";openNewWin('" & strUrl & "');", True)
                Else
                    lblMessage.Text = "Error: " & ex.Message
                End If
            End Try
        End If
    End Sub

    Public Function BindCoverPhoto()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BALCoverPhoto
                objBAL.CoverPhotoId = CInt(Request.QueryString("cpId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetCoverPhotoMasterTemplates
                If ds.Tables(0).Rows.Count > 0 Then
                    txtname.Text = ds.Tables(0).Rows(0).Item("CoverPhotoName")
                    'txtShareCoverPhotoName.Value = ds.Tables(0).Rows(0).Item("CoverPhotoName")
                    'txtCoverPhotoName.Value = ds.Tables(0).Rows(0).Item("CoverPhotoName")
                    divCoverPhotoHtml.InnerHtml = ds.Tables(0).Rows(0).Item("CoverPhotoContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                    Session("CoverPhotoID") = ds.Tables(0).Rows(0).Item("CoverPhotoId")
                End If
                'Dim obj As New BAlCoverPhoto
                'Dim ds1 As New DataSet
                'obj.Page = CStr(HttpContext.Current.Request.Url.AbsolutePath)
                'ds1 = obj.GetVideoTutorial()
                'If HttpContext.Current.Request.Url.AbsolutePath = ds1.Tables(0).Rows(0).Item("vt_Page").ToString Then
                '    strVideo1.HRef = ds1.Tables(0).Rows(0).Item("vt_Video").ToString
                'End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Function

    Public Function BindSavedCoverPhoto()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BALCoverPhoto
                objBAL.CoverPhotoId = CInt(Request.QueryString("cpId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetCoverPhotoMaster
                If ds.Tables(0).Rows.Count > 0 Then
                    txtname.Text = ds.Tables(0).Rows(0).Item("CoverPhotoName")
                    txtShareCoverPhotoName.Value = ds.Tables(0).Rows(0).Item("CoverPhotoName")
                    txtCoverPhotoName.Value = ds.Tables(0).Rows(0).Item("CoverPhotoName")
                    divCoverPhotoHtml.InnerHtml = ds.Tables(0).Rows(0).Item("CoverPhotoContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                    Session("CoverPhotoID") = ds.Tables(0).Rows(0).Item("CoverPhotoId")
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Function

    Public Function BindSavedCoverPhotoByID(ByVal id As Integer)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BALCoverPhoto
                objBAL.CoverPhotoId = id
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetCoverPhotoMasterByID
                If ds.Tables(0).Rows.Count > 0 Then
                    txtname.Text = ds.Tables(1).Rows(0).Item("CoverPhotoName")
                    txtShareCoverPhotoName.Value = ds.Tables(1).Rows(0).Item("CoverPhotoName")
                    txtCoverPhotoName.Value = ds.Tables(1).Rows(0).Item("CoverPhotoName")
                    divCoverPhotoHtml.InnerHtml = ds.Tables(0).Rows(0).Item("CoverPhotoContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                    Session("CoverPhotoID") = ds.Tables(0).Rows(0).Item("CoverPhotoId")
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Function


    Private Sub lnkReset_ServerClick(sender As Object, e As System.EventArgs) Handles lnkReset.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                divCoverPhotoHtml.InnerHtml = ""
                Dim ds As New DataSet
                Dim objBAL As New BALCoverPhoto
                objBAL.CoverPhotoId = CInt(Request.QueryString("cpId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetCoverPhotoMasterTemplates
                If ds.Tables(0).Rows.Count > 0 Then
                    divCoverPhotoHtml.InnerHtml = ds.Tables(0).Rows(0).Item("CoverPhotoContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                End If

            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub lnkSaveName_ServerClick(sender As Object, e As System.EventArgs) Handles lnkSaveName.ServerClick
        'If Not Page.IsPostBack Then
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowProgress", "GetWidthHeight();", True)
                'If hdnPublished.Value = "1" Then
                Dim dsID As New DataSet
                Dim objBAL As New BALCoverPhoto
                objBAL.CoverPhotoId = CInt(Request.QueryString("cpId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CoverPhotoName = If(txtCoverPhotoName.Value <> "", txtCoverPhotoName.Value, "")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                objBAL.CoverPhotoContent = hdnCoverPhotoContent.Value

                ViewState("CoverPhotoID") = CInt(Request.QueryString("cpId"))
                ViewState("FBUserId") = Request.QueryString("FbuserId")

                ' objBAL.CoverPhotoImage = Session("ImageName")
                dsID = objBAL.AddNewCoverPhotoContent()
                BindSavedCoverPhotoByID(CInt(dsID.Tables(0).Rows(0).Item("IDNew").ToString))

                Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate-cover-image.aspx?id=" & Session("CoverPhotoID")
                Dim browserWidth As Integer = Convert.ToInt32(800)
                Dim browserHeight As Integer = Convert.ToInt32(600)
                Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                Dim fullPath As String = Server.MapPath(relativeImagePath)
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strDate As Date = "1/1/1900"
                strPhoto = "CoverPhoto-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                Session("ImageName") = strPhoto
                Dim strD As [String] = strPhoto
                If Not fullPath.EndsWith("\") Then
                    fullPath += "\"
                End If
                Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), fullPath, strD), System.Drawing.Image)
                'Response.Write(ViewState("CoverPhotoID") & " Viewstate <br/>")
                'Response.Write(Session("CoverPhotoID") & "Session <br/>")
                'Response.Write(ViewState("FBUserId") & "<br/>")
                'Response.Write(Session("ImageName") & "<br/>")
                'Response.End()

                objBAL.CoverPhotoId = Session("CoverPhotoID") 'ViewState("CoverPhotoID")
                objBAL.FBUserId = ViewState("FBUserId")
                objBAL.CoverPhotoImage = Session("ImageName")
                objBAL.UpdateImageName()

                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "HideProgress", "HidProgress();", True)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert();", True)
                'lblMessage.Text = "Saved Successfully!"
                'hdnIsSaved.Value = "1"
                hdnPublished.Value = "0"

            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
        'End If
    End Sub

    Private Sub lnkPublish_ServerClick(sender As Object, e As System.EventArgs) Handles lnkPublish.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                'If hdnPublished.Value = "1" Then
                ViewState("CoverPhotoID") = CInt(Request.QueryString("cpId"))
                ViewState("FBUserId") = Request.QueryString("FbuserId")
                Dim dsID As New DataSet
                Dim objBAL As New BALCoverPhoto
                objBAL.CoverPhotoId = CInt(Request.QueryString("cpId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CoverPhotoName = If(txtCoverPhotoName.Value <> "", txtCoverPhotoName.Value, "")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                objBAL.CoverPhotoContent = hdnCoverPhotoContent.Value

                dsID = objBAL.AddNewCoverPhotoContent()
                BindSavedCoverPhotoByID(CInt(dsID.Tables(0).Rows(0).Item("IDNew").ToString))
                'Dim ds As New DataSet
                'objBAL.CoverPhotoId = CInt(dsID.Tables(0).Rows(0).Item("IDNew").ToString)
                'objBAL.UserId = CInt(Request.QueryString("userId"))
                'objBAL.FBUserId = Request.QueryString("FbuserId")
                'objBAL.CompanyId = CInt(Request.QueryString("CId"))
                'objBAL.IndustryId = CInt(Request.QueryString("IId"))
                'ds = objBAL.GetCoverPhotoMasterByID

                'If ds.Tables(0).Rows.Count > 0 Then
                '    txtname.Text = ds.Tables(1).Rows(0).Item("CoverPhotoName")
                '    divCoverPhotoHtml.InnerHtml = ds.Tables(0).Rows(0).Item("CoverPhotoContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                '    Session("CoverPhotoID") = ds.Tables(0).Rows(0).Item("CoverPhotoId")
                'End If
                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate-cover-image.aspx?id=" & Session("CoverPhotoID")
                Dim browserWidth As Integer = Convert.ToInt32(800)
                Dim browserHeight As Integer = Convert.ToInt32(600)
                Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                Dim fullPath As String = Server.MapPath(relativeImagePath)
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strDate As Date = "1/1/1900"
                strPhoto = "CoverPhoto-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                Session("ImageName") = strPhoto
                Dim strD As [String] = strPhoto
                If Not fullPath.EndsWith("\") Then
                    fullPath += "\"
                End If
                Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), fullPath, strD), System.Drawing.Image)

                'Response.Write(ViewState("CoverPhotoID") & "<br/>")
                'Response.Write(ViewState("FBUserId") & "<br/>")
                'Response.Write(Session("ImageName") & "<br/>")
                'Response.End()

                objBAL.CoverPhotoId = Session("CoverPhotoID") 'ViewState("CoverPhotoID")
                objBAL.FBUserId = ViewState("FBUserId")
                objBAL.CoverPhotoImage = Session("ImageName")
                objBAL.UpdateImageName()


                Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
                'End If
                'hdnIsSaved.Value = "1"
                Response.Redirect("publish-cover-photo-edit.aspx?id=" & Session("CoverPhotoID"))
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub lnkDownload_ServerClick(sender As Object, e As System.EventArgs) Handles lnkDownload.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "GetWidthHeight", "GetWidthHeight();", True)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DownloadAlert", "DownloadAlert();", True)
                ViewState("CoverPhotoID") = CInt(Request.QueryString("cpId"))
                ViewState("FBUserId") = Request.QueryString("FbuserId")
                Dim objBAL As New BALCoverPhoto
                objBAL.CoverPhotoId = CInt(Request.QueryString("cpId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CoverPhotoName = If(txtCoverPhotoName.Value <> "", txtCoverPhotoName.Value, "")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                objBAL.CoverPhotoContent = hdnCoverPhotoContent.Value
                objBAL.AddNewCoverPhotoContent()
                BindSavedCoverPhoto()

                Dim ds As New DataSet
                objBAL.CoverPhotoId = CInt(Request.QueryString("cpId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetCoverPhotoMaster

                If ds.Tables(0).Rows.Count > 0 Then
                    divCoverPhotoHtml.InnerHtml = ds.Tables(0).Rows(0).Item("CoverPhotoContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                    Session("CoverPhotoID") = ds.Tables(0).Rows(0).Item("CoverPhotoId")
                End If
                Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate-cover-image.aspx?id=" & Session("CoverPhotoID")
                Dim browserWidth As Integer = Convert.ToInt32(800)
                Dim browserHeight As Integer = Convert.ToInt32(600)
                Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                Dim fullPath As String = Server.MapPath(relativeImagePath)
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strDate As Date = "1/1/1900"
                strPhoto = "CoverPhoto-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                Session("ImageName") = strPhoto
                Dim strD As [String] = strPhoto
                If Not fullPath.EndsWith("\") Then
                    fullPath += "\"
                End If
                Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), fullPath, strD), System.Drawing.Image)

                objBAL.CoverPhotoId = Session("CoverPhotoID") 'ViewState("CoverPhotoID")
                objBAL.FBUserId = ViewState("FBUserId")
                objBAL.CoverPhotoImage = Session("ImageName")
                objBAL.UpdateImageName()

                Response.Redirect("download.aspx?Image=" & Session("ImageName"))
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try

    End Sub

    Private Sub lnkShareName_ServerClick(sender As Object, e As System.EventArgs) Handles lnkShareName.ServerClick
        Dim dsID As New DataSet
        Dim objBAL As New BALCoverPhoto
        objBAL.CoverPhotoId = CInt(Request.QueryString("cpId"))
        objBAL.UserId = CInt(Request.QueryString("userId"))
        objBAL.FBUserId = Request.QueryString("FbuserId")
        objBAL.CoverPhotoName = If(txtShareCoverPhotoName.Value <> "", txtShareCoverPhotoName.Value, "")
        objBAL.CompanyId = CInt(Request.QueryString("CId"))
        objBAL.IndustryId = CInt(Request.QueryString("IId"))
        objBAL.CoverPhotoContent = hdnCoverPhotoContent.Value

        dsID = objBAL.AddNewCoverPhotoContent()
        BindSavedCoverPhotoByID(CInt(dsID.Tables(0).Rows(0).Item("IDNew").ToString))

        'Dim ds As New DataSet
        'objBAL.CoverPhotoId = CInt(dsID.Tables(0).Rows(0).Item("IDNew").ToString)
        'objBAL.UserId = CInt(Request.QueryString("userId"))
        'objBAL.FBUserId = Request.QueryString("FbuserId")
        'objBAL.CompanyId = CInt(Request.QueryString("CId"))
        'objBAL.IndustryId = CInt(Request.QueryString("IId"))
        'ds = objBAL.GetCoverPhotoMasterByID

        'If ds.Tables(0).Rows.Count > 0 Then
        '    txtname.Text = ds.Tables(1).Rows(0).Item("CoverPhotoName")
        '    divCoverPhotoHtml.InnerHtml = ds.Tables(0).Rows(0).Item("CoverPhotoContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
        '    Session("CoverPhotoID") = ds.Tables(0).Rows(0).Item("CoverPhotoId")
        'End If

        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
        Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate-cover-image.aspx?id=" & Session("CoverPhotoID")
        Dim browserWidth As Integer = Convert.ToInt32(800)
        Dim browserHeight As Integer = Convert.ToInt32(600)
        Dim thumbnailWidth As Integer = Convert.ToInt32(800)
        Dim thumbnailHeight As Integer = Convert.ToInt32(600)
        Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
        Dim fullPath As String = Server.MapPath(relativeImagePath)
        Dim strExt As String = ""
        Dim strPhoto As String = ""
        Dim strDate As Date = "1/1/1900"
        strPhoto = "CoverPhoto-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
        Session("ImageName") = strPhoto
        Dim strD As [String] = strPhoto
        If Not fullPath.EndsWith("\") Then
            fullPath += "\"
        End If
        Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), fullPath, strD), System.Drawing.Image)

        'Response.Write(ViewState("CoverPhotoID") & "<br/>")
        'Response.Write(ViewState("FBUserId") & "<br/>")
        'Response.Write(Session("ImageName") & "<br/>")
        'Response.End()

        objBAL.CoverPhotoId = Session("CoverPhotoID") 'ViewState("CoverPhotoID")
        objBAL.FBUserId = Request.QueryString("FbuserId")
        objBAL.CoverPhotoImage = Session("ImageName")
        objBAL.UpdateImageName()

        Response.Redirect("publish-cover-photo-edit.aspx?id=" & Session("CoverPhotoID"))
    End Sub

    Private Sub lnkRedirect_ServerClick(sender As Object, e As System.EventArgs) Handles lnkRedirect.ServerClick
        'cover-photo-selection-edit.aspx?cpId=23&userId=1&FbuserId=100001311049327&CId=0&IId=1
        Response.Redirect("cover-photo-selection-edit.aspx?cpId=" & Session("CoverPhotoID") & "&userId=" & CInt(Request.QueryString("userId")) & "&FbuserId=" & Request.QueryString("FbuserId") & "&CId=0&IId=1")
    End Sub

    Private Sub lnkRedirectShare_ServerClick(sender As Object, e As System.EventArgs) Handles lnkRedirectShare.ServerClick
        Response.Redirect("publish-cover-photo-edit.aspx?id=" & Session("CoverPhotoID"))
    End Sub

    Private Sub lnkRedirectPublish_ServerClick(sender As Object, e As System.EventArgs) Handles lnkRedirectPublish.ServerClick
        Response.Redirect("publish-cover-photo-edit.aspx?id=" & Session("CoverPhotoID"))
    End Sub
End Class