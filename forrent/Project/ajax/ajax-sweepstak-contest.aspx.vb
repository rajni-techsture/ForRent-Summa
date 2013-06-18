Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports System.IO
Imports Facebook
Imports System.Threading
Imports System.Net.Mail
Public Class ajax_sweepstak_contest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Write("Name" & Request("nm"))
        'Response.Write("Email" & Request("em"))
        'Response.Write(Session("FacebookUserId"))
        'Response.Write(Session("AppUserId"))
        'Response.Write(Session("FBPID"))
        ' SendExternalEmail("postmaster@techsturedevelopment.mailgun.org", Request("em"), Request("fbpagename") & " - Sweepstakes Entry", "Thank you for entering our sweepstakes on our Facebook Business page!  Our sweepstakes platform draws a winner the 15th of every month.  If you did not win, we automatically put you back in the sweepstakes for the next month.  We hope you win! <br><br>Please visit our community frequently and let us know how you are enjoying our product and/or service.<br><br><br>All the best,<br>" & Request("fbpagename"), "", "")
        SendExternalEmail("marketplace@no-reply.com", Request("em"), "Sweepstakes Entry", "Thank you for entering our sweepstakes on our Facebook Business page!  Our sweepstakes platform draws a winner the 15th of every month.<br>  If you did not win, we automatically put you back in the sweepstakes for the next month. <br><br> We hope you win! ", "", "")
        Dim objsweepstakecontest As New BALSweepStake
        objsweepstakecontest.Name = Request("nm")
        objsweepstakecontest.Email = Request("em")
        objsweepstakecontest.FBUserId = Request("fbuid")
        'objsweepstakecontest.TSMAUserId = Request("TSMAUserId")
        objsweepstakecontest.FBPageId = Request("fbpid")

        objsweepstakecontest.AddSweepStakeContest()


    End Sub
    'Public Static Function PostTextAndHtmlAndFiles() As RestResponse

    '    Dim client As New RestClient
    '    client.BaseUrl = "https://api.mailgun.net/v2"
    '    client.Authenticator =
    '            New HttpBasicAuthenticator("api",
    '                                       "key-71t89xvl98hnlt2s3n1n3lcd9n239d23")
    '    RestRequest(Request = New RestRequest())
    '    Request.AddParameter("domain",
    '                         "samples.mailgun.org", ParameterType.UrlSegment)
    '    Request.Resource = "{domain}/messages"
    '    Request.AddParameter("from", "Excited User <me@samples.mailgun.org>")
    '    Request.AddParameter("to", "sergeyo@profista.com")
    '    Request.AddParameter("to", "serobnic@mail.ru")
    '    Request.AddParameter("subject", "Hello")
    '    Request.AddParameter("text", "Testing some Mailgun awesomness!")
    '    Request.AddParameter("html", "<html>HTML version of the body</html>")

    '    Request.Method = Method.POST
    '    Return client.Execute(Request)

    'End Function
#Region "Send External Email"
    Sub SendExternalEmail(ByVal strFrom As String, ByVal strTo As String, ByVal strSubject As String, ByVal strMailBody As String, ByVal strcc As String, ByVal strbcc As String)

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
        'Dim networkCredentials As New System.Net.NetworkCredential("postmaster@techsturedevelopment.mailgun.org", "testmailgun")
        'Dim networkCredentials As New System.Net.NetworkCredential("todd@summasocial.com", "4facebook")
        Dim networkCredentials As New System.Net.NetworkCredential("postmaster@mycompanymail.com.mailgun.org", "8py2a8o3v5t4")
        Dim smtpClient As New SmtpClient("smtp.mailgun.org")
        smtpClient.UseDefaultCredentials = False

        smtpClient.Credentials = networkCredentials
        smtpClient.EnableSsl = True
        smtpClient.Port = 587 '25

        smtpClient.Send(mailMessage)


    End Sub
#End Region

End Class