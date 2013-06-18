Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer
Imports Facebook
Imports System.Threading
Public Class upload_sidebar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            ViewState("PageID") = ""
            ViewState("PageAccessToken") = ""
            ViewState("PageName") = ""
            BindFanPages()
        End If
    End Sub

#Region "Bind Fan Pages"
    Sub BindFanPages()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim accessToken As String = Session("FacebookAccessToken")
                Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
                Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
                Dim url As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,category,access_token&return_ssl_resources=true&access_token={0}"
                Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, accessToken))
                Dim fbResponse As WebResponse = fbRequest.GetResponse()
                Dim stream As Stream = fbResponse.GetResponseStream()
                Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FanPage))

                Dim fPage As New FanPage()
                fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), FanPage)
                Dim listPages As New List(Of FanPage.m_data)

                For Each item As FanPage.m_data In fPage.data
                    listPages.Add(item)
                Next
                If listPages.Count > 0 Then
                    dstFanPages.DataSource = listPages
                    dstFanPages.DataBind()
                    'plcData.Visible = True
                    'plcNoData.Visible = False
                Else
                    dstFanPages.DataSource = Nothing
                    dstFanPages.DataBind()
                    'plcData.Visible = False
                    'plcNoData.Visible = True
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub
#End Region

#Region "Upload Sidebar"
    Private Sub lnkUploadPhoto_ServerClick(sender As Object, e As System.EventArgs) Handles lnkUploadPhoto.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim AccessToken As String = Session("FacebookAccessToken")
                Dim strActivationHours As String = Now.Hour
                Dim strActivationMinutes As String = Now.Minute
                'Dim strmsg As String = txtMessage.Value
                Dim strDate As String = Now.Date
                Dim strPageId As String = hdnselectedPages.Value
                Dim strPageName As String = hdnSelectedPagesName.Value
                Dim strPageImage As String = hdnSelectedPagesImage.Value
                Dim strPageAccessToken As String = hdnselectedPagesAccessToken.Value
                Dim strExt As String = ""
                Dim strPhoto As String = ""

                If photo.PostedFile.FileName <> "" Then
                    strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
                    If Not (strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png") Then
                        lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
                        Exit Sub
                    End If
                    Dim strDate1 As Date = "1/1/1900"
                    strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate1, Now())) & strExt
                    photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\" & strPhoto))
                End If

                Dim photopath As String = Server.MapPath("~/" & "Content/uploads/" & strPhoto)

                Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                Dim str As String = ""
                For Each item As DataListItem In dstFanPages.Items
                    Dim myCheckBox As HtmlInputCheckBox
                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                    If myCheckBox.Checked = True Then
                        Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/photos"
                        Dim mediaObject As New FacebookMediaObject() With { _
                            .FileName = photopath, _
                            .ContentType = "image/jpg" _
                    }
                        Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                        mediaObject.SetValue(fileBytes)
                        Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                        'upload.Add("message", strmsg)
                        upload.Add("image", mediaObject)
                        Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                        fbapp.Post(path, upload)
                    End If
                Next


                lblMessage.Text = "Photo Uploaded Successfully"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If

        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub
#End Region

    'Private Sub lnkUploadVideo_ServerClick(sender As Object, e As System.EventArgs) Handles lnkUploadVideo.ServerClick
    '    Try
    '        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
    '            Dim AccessToken As String = Session("FacebookAccessToken")
    '            Dim strActivationHours As String = Now.Hour
    '            Dim strActivationMinutes As String = Now.Minute
    '            'Dim strmsg As String = txtMessage.Value
    '            Dim strDate As String = Now.Date
    '            Dim strPageId As String = hdnselectedPages.Value
    '            Dim strPageName As String = hdnSelectedPagesName.Value
    '            Dim strPageImage As String = hdnSelectedPagesImage.Value
    '            Dim strPageAccessToken As String = hdnselectedPagesAccessToken.Value
    '            Dim strExt As String = ""
    '            Dim strPhoto As String = ""
    '            Dim strVideoThumb As String = "", strVideo As String = ""
    '            Dim strVideoFileNameWithoutExtension As String = ""

    '            If flVideo.PostedFile.ContentLength > 0 Then
    '                strExt = IO.Path.GetExtension(flVideo.PostedFile.FileName).ToLower
    '                If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
    '                    strVideoFileNameWithoutExtension = "V-" & String.Format("{0:MMddyyyyhhmmsstt}", Now)
    '                    If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
    '                        If strExt <> ".flv" Then
    '                            flVideo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
    '                            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
    '                            myprocess.StartInfo.UseShellExecute = True
    '                            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog.bat")
    '                            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
    '                            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & strExt & " -s -m"
    '                            myprocess.Start()
    '                        Else
    '                            flVideo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
    '                            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
    '                            myprocess.StartInfo.UseShellExecute = True
    '                            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog-flv.bat")
    '                            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
    '                            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & ".flv" & " -s -m"
    '                            myprocess.Start()
    '                        End If
    '                        strVideoThumb = strVideoFileNameWithoutExtension & ".jpg"
    '                        strVideo = strVideoFileNameWithoutExtension & ".flv"
    '                    End If

    '                    Dim photopath As String = Server.MapPath("~/" & "Content/uploads/" & strVideo)

    '                    'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
    '                    Dim str As String = ""
    '                    For Each item As DataListItem In dstFanPages.Items
    '                        Dim myCheckBox As HtmlInputCheckBox
    '                        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
    '                        If myCheckBox.Checked = True Then
    '                            Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/videos"
    '                            Dim mediaObject As New FacebookMediaObject() With { _
    '                                .FileName = photopath, _
    '                                .ContentType = "video/3gpp" _
    '                        }
    '                            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
    '                            mediaObject.SetValue(fileBytes)
    '                            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
    '                            upload.Add("title", "video title")
    '                            upload.Add("description", "video description")
    '                            upload.Add("image", mediaObject)
    '                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
    '                            fbapp.Post(path, upload)
    '                        End If
    '                    Next
    '                    lblMessage.Text = "Video Uploaded Successfully"
    '                Else
    '                    If strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png" Then
    '                        If flVideo.PostedFile.FileName <> "" Then
    '                            'strExt = IO.Path.GetExtension(flVideo.PostedFile.FileName).ToLower
    '                            If Not (strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png") Then
    '                                lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
    '                                Exit Sub
    '                            End If
    '                            Dim strDate1 As Date = "1/1/1900"
    '                            strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate1, Now())) & strExt
    '                            flVideo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\images\" & strPhoto))
    '                        End If

    '                        Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto)

    '                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
    '                        Dim str As String = ""
    '                        For Each item As DataListItem In dstFanPages.Items
    '                            Dim myCheckBox As HtmlInputCheckBox
    '                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
    '                            If myCheckBox.Checked = True Then
    '                                Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/photos"
    '                                Dim mediaObject As New FacebookMediaObject() With { _
    '                                    .FileName = photopath, _
    '                                    .ContentType = "image/jpg" _
    '                            }
    '                                Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
    '                                mediaObject.SetValue(fileBytes)
    '                                Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
    '                                'upload.Add("message", strmsg)
    '                                upload.Add("image", mediaObject)
    '                                Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
    '                                fbapp.Post(path, upload)
    '                            End If
    '                        Next

    '                        lblMessage.Text = "Photo Uploaded Successfully"
    '                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
    '                    End If
    '                End If
    '            End If
    '        Else
    '            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
    '        End If

    '    Catch ex As Exception
    '        lblMessage.Text = "Error: " & ex.Message
    '    End Try
    'End Sub
End Class