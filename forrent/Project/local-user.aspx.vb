Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer
Public Class local_user
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GenerateImage()
            pnlmsg.Visible = False
            spnEror.InnerText = ""
            Try
                Dim ds As New DataSet
                Dim objBAL As New BALCompanyIndusty
                'objBAL.FBUserId = "100001311049327" 'Session("FacebookUserId")
                ds = objBAL.GetCompnayDetails
                If ds.Tables(0).Rows.Count > 0 Then
                    rptCompany.DataSource = ds.Tables(0)
                    rptCompany.DataBind()
                Else
                    rptCompany.DataSource = Nothing
                    rptCompany.DataBind()
                    'lblMessage.Text = "No Drafts Found"
                End If
                If ds.Tables(1).Rows.Count > 0 Then
                    rptIndustry.DataSource = ds.Tables(1)
                    rptIndustry.DataBind()
                Else
                    rptIndustry.DataSource = Nothing
                    rptIndustry.DataBind()
                    'lblMessage.Text = "No Drafts Found"
                End If
                BindFrontFanFriday()
                BindFrontWeeklyTips()
                BindFacebookPluginData()
            Catch ex As Exception
                'lblMessage.Text = "Error :" & ex.Message()
            End Try
        End If
    End Sub

    Sub BindFacebookPluginData()
        Dim WbysmFBId = "169791343541"
        Dim accessToken As String = "AAAD2ZCc3HZAxABAG41OqIjnjvtea6SkNxR9qnxeIQka8IFH2xQZBi4XZB42YZBItWK2U9qqrR8THDYK2dU8V9Kv7zvuI2oykL3AjzMZCR1VgZDZD" 'Session("FacebookAccessToken")
        Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
        Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
        Dim url As String = "https://graph.facebook.com/{0}/feed?limit=10&fields=message,updated_time&access_token={1}"
        Dim request As WebRequest = WebRequest.Create(String.Format(url, WbysmFBId, accessToken))
        Dim response1 As WebResponse = request.GetResponse()
        Dim stream As Stream = response1.GetResponseStream()

        Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(BusinessAccessLayer.FBPlugin))

        Dim fPage As New BusinessAccessLayer.FBPlugin()
        fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), BusinessAccessLayer.FBPlugin)
        Dim listPages As New List(Of BusinessAccessLayer.FBPlugin.fb_data)

        For Each item As BusinessAccessLayer.FBPlugin.fb_data In fPage.data
            listPages.Add(item)
        Next

        Dim ds As New DataSet
        'ds = listPages

        dlsFacebookPlugin.DataSource = listPages
        dlsFacebookPlugin.DataBind()
        'For Each dlsItems As DataListItem In dlsFacebookPlugin.Items
        '    Dim HiddenID As String
        '    HiddenID = CType(dlsItems.FindControl("hdnDate"), HtmlInputHidden).Value
        '    Dim hsndatetime As New DateTime
        '    hsndatetime = HiddenID

        '    CType(dlsItems.FindControl("spnDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", hsndatetime)
        '    'Dim spnDateconvert As HtmlGenericControl
        '    'spnDateconvert = (CType(dlsItems.FindControl("spnDate"), HtmlGenericControl)).
        'Next
    End Sub
    Sub BindFrontFanFriday()
        Dim ds As DataSet
        Dim objFanFridayFront As New BALFanFridayFront
        ds = objFanFridayFront.GetFanFridayFront()
        If ds.Tables(0).Rows.Count > 0 Then
            ltrFanFridayTitle.Text = ds.Tables(0).Rows(0).Item("ff_Title").ToString
            ltrFanFridayDescription.Text = ds.Tables(0).Rows(0).Item("ff_Description").ToString
            imgFanFriday.Src = ds.Tables(0).Rows(0).Item("ff_Photo").ToString

        End If
    End Sub
    Sub BindFrontWeeklyTips()
        Dim ds As DataSet
        Dim objWeeklyTipsFront As New BALWeeklyTipsFront
        ds = objWeeklyTipsFront.GetweeklyTipsFront()
        If ds.Tables(0).Rows.Count > 0 Then
            ltrWeeklyTipsTitle.Text = ds.Tables(0).Rows(0).Item("wt_Title").ToString
            ltrWeeklyTipsDescription.Text = ds.Tables(0).Rows(0).Item("wt_Description").ToString
            imgWeeklyTips.Src = ds.Tables(0).Rows(0).Item("wt_VideoThumbnail").ToString
            strVideo1.HRef = ds.Tables(0).Rows(0).Item("wt_Video").ToString & "?autoplay=1&rel=0&enablejsapi=1&playerapiid=ytplayer"
            strVideo1.Title = ds.Tables(0).Rows(0).Item("wt_Title").ToString
        End If
    End Sub


#Region "Send External Email"
    Shared Sub SendExternalEmail(ByVal strFrom As String, ByVal strTo As String, ByVal strSubject As String, ByVal strMailBody As String, ByVal strcc As String, ByVal strbcc As String)
        Dim mailMessage As MailMessage = New MailMessage()
        mailMessage.From = New MailAddress(strFrom)
        mailMessage.To.Add(strTo)

        If strcc <> "" Then
            mailMessage.CC.Add(New MailAddress(strcc))
        End If
        If strbcc <> "" Then
            mailMessage.Bcc.Add(New MailAddress(strbcc))
        End If
        mailMessage.Subject = strSubject
        mailMessage.Body = strMailBody
        mailMessage.IsBodyHtml = True


        '   Dim networkCredentials As New System.Net.NetworkCredential("techsture.devlopers@gmail.com", "chrdjbar19")
        '  Dim smtpClient As New SmtpClient("smtp.gmail.com")
        Dim networkCredentials As New System.Net.NetworkCredential("postmaster@techsturedevelopment.mailgun.org", "testmailgun")
        Dim smtpClient As New SmtpClient("smtp.mailgun.org")
        smtpClient.UseDefaultCredentials = False

        smtpClient.Credentials = networkCredentials
        smtpClient.EnableSsl = True
        smtpClient.Port = 587 '25

        smtpClient.Send(mailMessage)
    End Sub

#End Region

#Region "Generate Image"
    Public Function GenerateImage()
        Try
            Dim ds As New DataSet
            Dim objBAL As New BALlogin
            Dim imgFile As String
            ds = objBAL.GenereateImage
            If ds.Tables(0).Rows.Count > 0 Then
                imgFile = ds.Tables(0).Rows(0).Item("im_name").ToString
                hdncode1.Value = imgFile.ToString()
                'hdncode1.Value = Utility.Encryption(imgFile.ToString())
                imgcode1.Src = "../Content/textimages/" & imgFile & ".gif"
                If ConfigurationManager.AppSettings("AppPath") = "http://localhost:5192/" Then
                    txtUid.Value = "techdev"
                    txtPwd.Value = "techdev123"
                    txtcode1.Value = hdncode1.Value
                End If
            End If

        Catch ex As Exception
        End Try
    End Function

#End Region

    Private Sub imgPassword_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgPassword.Click
        Dim objBAL As New BALSchedulePost
        Dim ds As New DataSet
        objBAL.UserEmailForgotpwd = txtForget.Value
        ds = objBAL.GetEmailForgotPassword
        If ds.Tables(0).Rows.Count > 0 Then
            'SendExternalEmail("info@techsturedevelopment.com", txtForget.Value, "Forget Password", "Your Password is: " & ds.Tables(0).Rows(0).Item("u_Password").ToString, "", "")
            SendExternalEmail("postmaster@techsturedevelopment.mailgun.org", txtForget.Value, "Forget Password", "Your Password is: " & ds.Tables(0).Rows(0).Item("u_Password").ToString, "", "")
            spnEror.InnerText = "We Will send Your Password Soon"
        Else
            spnEror.InnerText = "Please enter valid email address."
        End If
    End Sub

    Private Sub imgLogin_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgLogin.Click
        'Response.Write("Testest")
        'Response.Write("testset  " & hdncode1.Value)
        ' ''Response.End()
        If txtcode1.Value = hdncode1.Value Then
            Dim ds As New DataSet
            Dim objBAL As New BALlogin
            Dim objEncry As New Utility
            objBAL.UserName = txtUid.Value
            objBAL.password = txtPwd.Value.ToString() 'Session("FacebookUserId")
            ds = objBAL.CheckLogin
            'dsTet = objBAL.AdminLoginDetails

            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("u_Username") = txtUid.Value AndAlso Utility.Decryption(ds.Tables(0).Rows(0).Item("u_Password").ToString()) = txtPwd.Value.ToString() Then
                    If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                        Session("SiteUserId") = ds.Tables(0).Rows(0).Item("u_Id")
                        Session("SiteUserName") = ds.Tables(0).Rows(0).Item("u_FirstName")
                        Session("FanPageIDs") = Nothing
                        Response.Redirect(ConfigurationManager.AppSettings("AppPath") & "scheduler")
                    Else
                        Session("SiteUserId") = ds.Tables(0).Rows(0).Item("u_Id")
                        Session("SiteUserName") = ds.Tables(0).Rows(0).Item("u_FirstName")
                        Session("FanPageIDs") = Nothing
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ValidateNetwork;", ";MM_openBrWindow(1);", True)
                    End If

                Else
                    spnEror.InnerText = "Invalid Username or Password"
                End If
            Else
                spnEror.InnerText = "Invalid Username or Password"
            End If
        Else
            spnEror.Visible = True
            spnEror.InnerText = "Please enter correct security code!"
        End If
    End Sub

End Class