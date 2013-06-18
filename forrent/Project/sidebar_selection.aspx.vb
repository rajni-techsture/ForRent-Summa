Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports System.Drawing.Image
Imports BusinessAccessLayer.BusinessLayer
Imports Facebook
Imports System.Threading
Public Class sidebar_selection
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                'hdnIsSaved.Value = "0"
                Dim obj As New BAlsidebar
                Dim ds1 As New DataSet
                obj.Page = "/sidebar"
                ds1 = obj.GetVideoTutorial()
                Dim videostring As String
                videostring = Replace(ds1.Tables(0).Rows(0).Item("vt_Video").ToString, "watch?v=", "v/")
                spnVideo.InnerHtml = "<object style='height: 335px; width: 555px'><param name='movie' value='" & videostring & "'><param name='allowFullScreen' value='true'><param name='allowScriptAccess' value='always'><param name='wmode' value='transparent'><embed src='" & videostring & "' type='application/x-shockwave-flash' allowfullscreen='true' allowScriptAccess='always' width='555' height='335'></object>"
                If Request.QueryString("sdId") <> "" And IsNumeric(Request.QueryString("sdId")) Then
                    BindSavedSidebar()
                    BindSidebar()
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If

        End If
    End Sub

    Public Function BindSidebar()
        'Try
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim ds As New DataSet
            Dim objBAL As New BAlsidebar
            objBAL.SidebarId = CInt(Request.QueryString("sdId"))
            objBAL.UserId = CInt(Request.QueryString("userId"))
            objBAL.FBUserId = Request.QueryString("FbuserId")
            objBAL.CompanyId = CInt(Request.QueryString("CId"))
            objBAL.IndustryId = CInt(Request.QueryString("IId"))
            ds = objBAL.GetSidebarMasterTemplates
            If ds.Tables(0).Rows.Count > 0 Then
                txtname.Text = ds.Tables(0).Rows(0).Item("SidebarName")
                divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("SidebarContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                Session("SidebarID") = ds.Tables(0).Rows(0).Item("SidebarId")
            End If
            'Dim obj As New BAlsidebar
            'Dim ds1 As New DataSet
            'obj.Page = CStr(HttpContext.Current.Request.Url.AbsolutePath)
            'ds1 = obj.GetVideoTutorial()
            'If HttpContext.Current.Request.Url.AbsolutePath = ds1.Tables(0).Rows(0).Item("vt_Page").ToString Then
            '    strVideo1.HRef = ds1.Tables(0).Rows(0).Item("vt_Video").ToString
            'End If
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
        End If
        'Catch ex As Exception
        '    lblMessage.Text = "Error: " & ex.Message
        'End Try
    End Function

    Public Function BindSavedSidebar()
        'Try
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim ds As New DataSet
            Dim objBAL As New BAlsidebar
            objBAL.SidebarId = CInt(Request.QueryString("sdId"))
            objBAL.UserId = CInt(Request.QueryString("userId"))
            objBAL.FBUserId = Request.QueryString("FbuserId")
            objBAL.CompanyId = CInt(Request.QueryString("CId"))
            objBAL.IndustryId = CInt(Request.QueryString("IId"))
            ds = objBAL.GetSidebarMaster
            If ds.Tables(0).Rows.Count > 0 Then
                txtname.Text = ds.Tables(0).Rows(0).Item("SidebarName")
                divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("SidebarContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                Session("SidebarID") = ds.Tables(0).Rows(0).Item("SidebarId")
            End If
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
        End If
        'Catch ex As Exception
        '    lblMessage.Text = "Error: " & ex.Message
        'End Try
    End Function

    Public Function BindSavedSidebarByID(ByVal id As Integer)
        'Try
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim ds As New DataSet
            Dim objBAL As New BAlsidebar
            objBAL.SidebarId = id
            objBAL.UserId = CInt(Request.QueryString("userId"))
            objBAL.FBUserId = Request.QueryString("FbuserId")
            objBAL.CompanyId = CInt(Request.QueryString("CId"))
            objBAL.IndustryId = CInt(Request.QueryString("IId"))
            ds = objBAL.GetSidebarMasterByID
            If ds.Tables(0).Rows.Count > 0 Then
                txtname.Text = ds.Tables(1).Rows(0).Item("SidebarName")
                txtSidebarName.Value = ds.Tables(1).Rows(0).Item("SidebarName")
                divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("SidebarContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                Session("SidebarID") = ds.Tables(0).Rows(0).Item("SidebarId")
            End If
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
        End If
        'Catch ex As Exception
        '    lblMessage.Text = "Error: " & ex.Message
        'End Try
    End Function
    Private Sub lnkReset_ServerClick(sender As Object, e As System.EventArgs) Handles lnkReset.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                divSidebarHtml.InnerHtml = ""
                Dim ds As New DataSet
                Dim objBAL As New BAlsidebar
                objBAL.SidebarId = CInt(Request.QueryString("sdId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetSidebarMasterTemplates
                If ds.Tables(0).Rows.Count > 0 Then
                    divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("SidebarContent")
                End If
                
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub lnkSave_ServerClick(sender As Object, e As System.EventArgs) Handles lnkSave.ServerClick
        'If Not Page.IsPostBack Then
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowProgress", "GetWidthHeight();", True)
                'If hdnPublished.Value = "1" Then
                Dim dsID As New DataSet
                Dim objBAL As New BAlsidebar
                objBAL.SidebarId = CInt(Request.QueryString("sdId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.SidebarName = If(txtSidebarName.Value <> "", txtSidebarName.Value, "")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                objBAL.SidebarContent = hdnSidebarContent.Value

                ViewState("SideBarID") = CInt(Request.QueryString("sdId"))
                ViewState("FBUserId") = Request.QueryString("FbuserId")

                ' objBAL.SideBarImage = Session("ImageName")
                dsID = objBAL.AddNewSidebarContent()
                BindSavedSidebarByID(CInt(dsID.Tables(0).Rows(0).Item("IDNew").ToString))

                Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate_image.aspx?id=" & Session("SidebarID")
                Dim browserWidth As Integer = Convert.ToInt32(800)
                Dim browserHeight As Integer = Convert.ToInt32(600)
                Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                Dim fullPath As String = Server.MapPath(relativeImagePath)
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strDate As Date = "1/1/1900"
                strPhoto = "sidebar-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                Session("ImageName") = strPhoto
                Dim strD As [String] = strPhoto
                If Not fullPath.EndsWith("\") Then
                    fullPath += "\"
                End If
                Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), fullPath, strD), System.Drawing.Image)
                'Response.Write(ViewState("SideBarID") & " Viewstate <br/>")
                'Response.Write(Session("SidebarID") & "Session <br/>")
                'Response.Write(ViewState("FBUserId") & "<br/>")
                'Response.Write(Session("ImageName") & "<br/>")
                'Response.End()

                objBAL.SidebarId = Session("SidebarID") 'ViewState("SideBarID")
                objBAL.FBUserId = ViewState("FBUserId")
                objBAL.SideBarImage = Session("ImageName")
                objBAL.UpdateImageName()

                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "HideProgress", "HidProgress();", True)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Your work has been saved');", True)
                'lblMessage.Text = "Saved Successfully!"
                'hdnIsSaved.Value = "1"
                hdnPublished.Value = "0"
                'Else
                '    Dim objBAL As New BAlsidebar
                '    objBAL.SidebarId = CInt(Request.QueryString("sdId"))
                '    objBAL.UserId = CInt(Request.QueryString("userId"))
                '    objBAL.FBUserId = Request.QueryString("FbuserId")
                '    objBAL.CompanyId = CInt(Request.QueryString("CId"))
                '    objBAL.IndustryId = CInt(Request.QueryString("IId"))
                '    objBAL.SidebarContent = hdnSidebarContent.Value

                '    ViewState("SideBarID") = CInt(Request.QueryString("sdId"))
                '    ViewState("FBUserId") = Request.QueryString("FbuserId")

                '    ' objBAL.SideBarImage = Session("ImageName")
                '    objBAL.UpdateSidebarContent()
                '    BindSavedSidebar()

                '    Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate_image.aspx?id=" & Session("SidebarID")
                '    Dim browserWidth As Integer = Convert.ToInt32(800)
                '    Dim browserHeight As Integer = Convert.ToInt32(600)
                '    Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                '    Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                '    Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                '    Dim fullPath As String = Server.MapPath(relativeImagePath)
                '    Dim strExt As String = ""
                '    Dim strPhoto As String = ""
                '    Dim strDate As Date = "1/1/1900"
                '    strPhoto = "sidebar-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                '    Session("ImageName") = strPhoto
                '    Dim strD As [String] = strPhoto
                '    If Not fullPath.EndsWith("\") Then
                '        fullPath += "\"
                '    End If
                '    Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), fullPath, strD), System.Drawing.Image)

                '    objBAL.SidebarId = ViewState("SideBarID")
                '    objBAL.FBUserId = ViewState("FBUserId")
                '    objBAL.SideBarImage = Session("ImageName")
                '    objBAL.UpdateImageName()
                'End If

            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
        'End If
    End Sub

    Private Sub lnkPublish_ServerClick(sender As Object, e As System.EventArgs) Handles lnkPublish.ServerClick
        'Try
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            If hdnPublished.Value = "1" Then
                ViewState("SideBarID") = CInt(Request.QueryString("sdId"))
                ViewState("FBUserId") = Request.QueryString("FbuserId")
                Dim dsID As New DataSet
                Dim objBAL As New BAlsidebar
                objBAL.SidebarId = CInt(Request.QueryString("sdId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.SidebarName = If(txtSidebarName.Value <> "", txtSidebarName.Value, "")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                objBAL.SidebarContent = hdnSidebarContent.Value

                dsID = objBAL.AddNewSidebarContent()

                Dim ds As New DataSet
                objBAL.SidebarId = CInt(dsID.Tables(0).Rows(0).Item("IDNew").ToString)
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetSidebarMasterByID

                If ds.Tables(0).Rows.Count > 0 Then
                    txtname.Text = ds.Tables(1).Rows(0).Item("SidebarName")
                    divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("SidebarContent")
                    Session("SidebarID") = ds.Tables(0).Rows(0).Item("SidebarId")
                End If
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate_image.aspx?id=" & Session("SidebarID")
                Dim browserWidth As Integer = Convert.ToInt32(800)
                Dim browserHeight As Integer = Convert.ToInt32(600)
                Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                Dim fullPath As String = Server.MapPath(relativeImagePath)
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strDate As Date = "1/1/1900"
                strPhoto = "sidebar-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                Session("ImageName") = strPhoto
                Dim strD As [String] = strPhoto
                If Not fullPath.EndsWith("\") Then
                    fullPath += "\"
                End If
                Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), fullPath, strD), System.Drawing.Image)

                'Response.Write(ViewState("SideBarID") & "<br/>")
                'Response.Write(ViewState("FBUserId") & "<br/>")
                'Response.Write(Session("ImageName") & "<br/>")
                'Response.End()

                objBAL.SidebarId = Session("SidebarID") 'ViewState("SideBarID")
                objBAL.FBUserId = ViewState("FBUserId")
                objBAL.SideBarImage = Session("ImageName")
                objBAL.UpdateImageName()


                Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
            End If
            'hdnIsSaved.Value = "1"
            Response.Redirect("publish-sidebar.aspx?id=" & Session("SidebarID"))
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
        End If
        'Catch ex As Exception
        '    lblMessage.Text = "Error: " & ex.Message
        'End Try
    End Sub

    Private Sub lnkDownload_ServerClick(sender As Object, e As System.EventArgs) Handles lnkDownload.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "GetWidthHeight", "GetWidthHeight();", True)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DownloadAlert", "DownloadAlert();", True)
                ViewState("SideBarID") = CInt(Request.QueryString("sdId"))
                ViewState("FBUserId") = Request.QueryString("FbuserId")
                Dim objBAL As New BAlsidebar
                objBAL.SidebarId = CInt(Request.QueryString("sdId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.SidebarName = If(txtSidebarName.Value <> "", txtSidebarName.Value, "")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                objBAL.SidebarContent = hdnSidebarContent.Value
                objBAL.AddNewSidebarContent()
                BindSavedSidebar()

                Dim ds As New DataSet
                objBAL.SidebarId = CInt(Request.QueryString("sdId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetSidebarMaster

                If ds.Tables(0).Rows.Count > 0 Then
                    divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("SidebarContent")
                    Session("SidebarID") = ds.Tables(0).Rows(0).Item("SidebarId")
                End If
                Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate_image.aspx?id=" & Session("SidebarID")
                Dim browserWidth As Integer = Convert.ToInt32(800)
                Dim browserHeight As Integer = Convert.ToInt32(600)
                Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                Dim fullPath As String = Server.MapPath(relativeImagePath)
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strDate As Date = "1/1/1900"
                strPhoto = "sidebar-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                Session("ImageName") = strPhoto
                Dim strD As [String] = strPhoto
                If Not fullPath.EndsWith("\") Then
                    fullPath += "\"
                End If
                Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), hdnWidth.Value.Replace("px", ""), hdnHeight.Value.Replace("px", ""), fullPath, strD), System.Drawing.Image)

                objBAL.SidebarId = Session("SidebarID") 'ViewState("SideBarID")
                objBAL.FBUserId = ViewState("FBUserId")
                objBAL.SideBarImage = Session("ImageName")
                objBAL.UpdateImageName()

                Response.Redirect("download.aspx?Image=" & Session("ImageName"))
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try

    End Sub

    
End Class