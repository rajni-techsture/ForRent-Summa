Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports System.IO
Imports Facebook
Imports System.Threading
Imports System.Net.Mail

Public Class ajax_custom_tab_info
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SendExternalEmail("postmaster@techsturedevelopment.mailgun.org", Request("em"), Request("fbpagename") & " - Special Offer", "Thank you for entering in Special Offer on our Facebook Business page! <br><br><br> Our Special Offer platform draws a winner the 15th of every month. <br><br><br>All the best,<br>" & Request("fbpagename"), "", "")
        Dim objcustontabinfo As New CustomTabContent
        objcustontabinfo.Name = Request("nm")
        objcustontabinfo.Email = Request("em")
        objcustontabinfo.Phone = If(Request("ph") = "undefined", "", Request("ph"))
        objcustontabinfo.Message = If(Request("msg") = "undefined", "", Request("msg"))
        objcustontabinfo.FBUserId = Request("fbuid")
        'objcustontabinfo.TSMAUserId = Request("TSMAUserId")
        objcustontabinfo.FBPageId = Request("fbpid")
        objcustontabinfo.FBPageURL = Request("fbpageurl")
        objcustontabinfo.AddCustomTabInfo()
    End Sub

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


        '  Dim networkCredentials As New System.Net.NetworkCredential("techsture.devlopers@gmail.com", "chrdjbar19")
        '  Dim smtpClient As New SmtpClient("smtp.gmail.com")
        Dim networkCredentials As New System.Net.NetworkCredential("todd@summasocial.com", "4facebook")
        Dim smtpClient As New SmtpClient("smtp.mailgun.org")
        smtpClient.UseDefaultCredentials = False

        smtpClient.Credentials = networkCredentials
        smtpClient.EnableSsl = True
        smtpClient.Port = 587 '25

        smtpClient.Send(mailMessage)


    End Sub
#End Region
End Class