Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports System.IO
Imports Facebook
Imports Facebook.FacebookClient

Public Class quickpost
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim accessToken As String = Session("FacebookAccessToken")
            Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
            Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
            Dim url As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,category,access_token&return_ssl_resources=true&access_token={0}"
            Dim request As WebRequest = WebRequest.Create(String.Format(url, accessToken))
            Dim response As WebResponse = request.GetResponse()
            Dim stream As Stream = response.GetResponseStream()
            Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FanPage))

            Dim fPage As New FanPage()
            fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), FanPage)
            response.Close()

            Dim fData As String = "<table><tr>"
            For i As Integer = 1 To fPage.data.Length
                If i Mod 3 <> 0 Then
                    If (i - 1) > 0 And (i - 1) Mod 3 = 0 Then
                        fData = fData & "<tr><td width='170' height='110'><img src='" & fPage.data(i - 1).picture & "' border='0' /><br/><input type='checkbox' group='pages' onclick='Pageid(this);' pageid='" & fPage.data(i - 1).id & "' pagevalue='" & fPage.data(i - 1).name & "' pageimage='" & fPage.data(i - 1).picture & "'/>" & fPage.data(i - 1).name & "<input type='hidden' ID='p_" & fPage.data(i - 1).id & "' value='" & fPage.data(i - 1).id & "' /><input type='hidden' ID='" & fPage.data(i - 1).category & "' value='" & fPage.data(i - 1).category & "' /><input type='hidden' id='" & fPage.data(i - 1).access_token & "' value='" & fPage.data(i - 1).access_token & "' /></td>"
                    Else
                        fData = fData & "<td width='170' height='110'><img src='" & fPage.data(i - 1).picture & "' border='0' /><br/><input type='checkbox' group='pages' onclick='Pageid(this);' pageid='" & fPage.data(i - 1).id & "' pagevalue='" & fPage.data(i - 1).name & "' pageimage='" & fPage.data(i - 1).picture & "'/>" & fPage.data(i - 1).name & "<input type='hidden' ID='p_" & fPage.data(i - 1).id & "' value='" & fPage.data(i - 1).id & "' /><input type='hidden' ID='" & fPage.data(i - 1).category & "' value='" & fPage.data(i - 1).category & "' /><input type='hidden' value='" & fPage.data(i - 1).access_token & "'/></td>"
                    End If
                Else
                    fData = fData & "<td width='170' height='110'><img src='" & fPage.data(i - 1).picture & "' border='0' /><br/><input type='checkbox' group='pages' onclick='Pageid(this);' pageid='" & fPage.data(i - 1).id & "' pagevalue='" & fPage.data(i - 1).name & "' pageimage='" & fPage.data(i - 1).picture & "'/>" & fPage.data(i - 1).name & "<input type='hidden' ID='p_" & fPage.data(i - 1).id & "' value='" & fPage.data(i - 1).id & "' /><input type='hidden' ID='" & fPage.data(i - 1).category & "' value='" & fPage.data(i - 1).category & "' /><input type='hidden' value='" & fPage.data(i - 1).access_token & "'/></td>"
                End If
            Next
            fData = fData & "</tr></table>"
            divQuickPost.InnerHtml = fData
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
        End If
    End Sub

    Private Sub btnPost_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPost.ServerClick
        Dim AccessToken As String = Session("FacebookAccessToken")
        Dim strActivationHours As String = Now.Hour
        Dim strActivationMinutes As String = Now.Minute
        Dim strmessage As String = txtMessage.Value
        Dim strDate As String = Now.Date
        Dim strPageId As String = hdnselectedPages.Value
        Dim strPageName As String = hdnSelectedPagesName.Value
        Dim strPageImage As String = hdnSelectedPagesImage.Value

        Dim args = New Dictionary(Of String, Object)()
        args("message") = strmessage
        'args("picture") = "http://www.techsture.com/images/header.jpg"
        'args("link") = "http://www.youtube.com/watch?v=Hh8mFw8WAv8"
        Dim regex As New Regex(",")
        For Each test As String In regex.Split(strPageId)
            Dim path As String = test & "/feed"
            Response.Write(path)
            Response.End()
            Dim fbapp = New FacebookClient(AccessToken)
            fbapp.Post(path, args)
        Next
        Dim objBAL As New BALSchedulePost
        objBAL.FBUserId = Session("FacebookUserId")
        objBAL.FBPageId = CStr(strPageId)
        objBAL.FBPageAccessToken = Session("FacebookAccessToken")
        objBAL.PostMessage = CStr(Replace(strmessage, Chr(10), "<br/>"))
        objBAL.ActivationDate = Convert.ToDateTime(strDate)
        objBAL.ActivationHours = CStr(strActivationHours)
        objBAL.ActivationMinutes = CStr(strActivationMinutes)
        objBAL.SendMessage = 1
        objBAL.SaveAsDraft = 0
        objBAL.SaveAsTemplate = 0
        objBAL.FBPageImage = CStr(strPageImage)
        objBAL.AddQuickPost()
        lblMessage.Text = "Post Submitted Successfully"
    End Sub
End Class