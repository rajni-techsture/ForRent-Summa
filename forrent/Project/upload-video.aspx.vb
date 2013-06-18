Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports System.IO
Imports System.Web
Imports Facebook
Imports Facebook.FacebookClient
Public Class upload_video
    Inherits System.Web.UI.Page
    Public str As String

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
                        fData = fData & "<tr><td width='170' height='110'><img src='" & fPage.data(i - 1).picture & "' border='0' /><br/><input type='checkbox' group='pages' onclick='Pageid(this);' pageid='" & fPage.data(i - 1).id & "' pageaccess_token='" & fPage.data(i - 1).access_token & "' pagevalue='" & fPage.data(i - 1).name & "' pageimage='" & fPage.data(i - 1).picture & "'/>" & fPage.data(i - 1).name & "<input type='hidden' ID='p_" & fPage.data(i - 1).id & "' value='" & fPage.data(i - 1).id & "' /><input type='hidden' ID='" & fPage.data(i - 1).category & "' value='" & fPage.data(i - 1).category & "' /><input type='hidden' id='" & fPage.data(i - 1).access_token & "' value='" & fPage.data(i - 1).access_token & "' /></td>"
                    Else
                        fData = fData & "<td width='170' height='110'><img src='" & fPage.data(i - 1).picture & "' border='0' /><br/><input type='checkbox' group='pages' onclick='Pageid(this);' pageid='" & fPage.data(i - 1).id & "' pageaccess_token='" & fPage.data(i - 1).access_token & "' pagevalue='" & fPage.data(i - 1).name & "' pageimage='" & fPage.data(i - 1).picture & "'/>" & fPage.data(i - 1).name & "<input type='hidden' ID='p_" & fPage.data(i - 1).id & "' value='" & fPage.data(i - 1).id & "' /><input type='hidden' ID='" & fPage.data(i - 1).category & "' value='" & fPage.data(i - 1).category & "' /><input type='hidden' id='" & fPage.data(i - 1).access_token & "' value='" & fPage.data(i - 1).access_token & "'/></td>"
                    End If
                Else
                    fData = fData & "<td width='170' height='110'><img src='" & fPage.data(i - 1).picture & "' border='0' /><br/><input type='checkbox' group='pages' onclick='Pageid(this);' pageid='" & fPage.data(i - 1).id & "' pageaccess_token='" & fPage.data(i - 1).access_token & "'  pagevalue='" & fPage.data(i - 1).name & "' pageimage='" & fPage.data(i - 1).picture & "'/>" & fPage.data(i - 1).name & "<input type='hidden' ID='p_" & fPage.data(i - 1).id & "' value='" & fPage.data(i - 1).id & "' /><input type='hidden' ID='" & fPage.data(i - 1).category & "' value='" & fPage.data(i - 1).category & "' /><input type='hidden' id='" & fPage.data(i - 1).access_token & "' value='" & fPage.data(i - 1).access_token & "'/></td>"
                End If
            Next
            fData = fData & "</tr></table>"
            divQuickPost.InnerHtml = fData
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
        End If
    End Sub


   

    Private Sub btnalbum_ServerClick(sender As Object, e As System.EventArgs) Handles btnalbum.ServerClick
        Dim AccessToken As String = Session("FacebookAccessToken")
        'Dim strActivationHours As String = Now.Hour
        'Dim strActivationMinutes As String = Now.Minute
        ' Dim strmessage As String = Replace(txtmsg.Value, Chr(10), "<br>")



        Dim strmsg As String = txtmsg.Value
        'Dim strDate As String = Now.Date
        Dim strPageId As String = hdnselectedPages.Value
        Dim strPageName As String = hdnSelectedPagesName.Value
        Dim strPageImage As String = hdnSelectedPagesImage.Value
        Dim strAccessToken As String = hdnselectedPagesAccessToken.Value
        'Response.Write(strPageId)
        'Response.End()
        Dim args = New Dictionary(Of String, Object)()
        Dim strExt As String
        Dim strVideo As String = ""
        'If photo.PostedFile.FileName <> "" Then
        '    strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
        '    If Not (strExt = ".flv" Or strExt = ".mp4" Or strExt = ".avi") Then
        '        lblMessage.Text = "File must be .flv or .mp4 or .avi"
        '        Exit Sub
        '    End If
        '    Dim strDate As Date = "1/1/1900"
        '    strVideo = "video-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & strExt
        '    photo.PostedFile.SaveAs(Server.MapPath("~/" & "uploads\" & strVideo))

        'End If
        Dim cnt As Integer = 0

        'Dim regex As New Regex(",")
        'For Each id As String In regex.Split(Left(strPageId, strPageId.ToString().Length - 1))

        '    cnt = cnt + 1
        'Next
        'Dim path1(cnt) As String
        'Dim i As Integer = 0
        'For Each id1 As String In regex.Split(Left(strPageId, strPageId.ToString().Length - 1))
        '    path1(i) = id1
        '    i = i + 1
        'Next
        'Dim PageAccessToken(cnt) As String
        'Dim j As Integer = 0
        'For Each token As String In regex.Split(Left(strAccessToken, strAccessToken.ToString().Length - 1))
        '    PageAccessToken(j) = token
        '    j = j + 1
        'Next



        Dim path As String = "229737600429199" & "/feed"
        Dim facebookClient As New FacebookClient("AAAD2ZCc3HZAxABAOdOaWmcCWxwf5p9k5bKDifbPYNH8sPpjZBCVbGGDkBpmA4I9ZCgYIL6BMGN0UmQeWd9TnehsgsvjkDA0vexvbVI3sgYhW0UKKi2Ad")
        '   Dim filepath As String = Server.MapPath(photo.PostedFile.FileName)
        'Dim photopath As String = Server.MapPath("~/" & "uploads/" & strVideo)
        'Dim mediaObject As New FacebookMediaObject() With { _
        '     .FileName = photopath, _
        '     .ContentType = "video/flv" _
        '}
        'Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
        'mediaObject.SetValue(fileBytes)
        Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
        upload.Add("link", "http://www.facebook.com/l.php?u=http%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3D-yh6SriAjdE%26feature%3Dg-logo%26context%3DG2bed3d6FOAAAAAAAAAA&h=vAQHKA42PAQHH_8wMp9aPP-nzrNxqgfr4JsbvgjgSD0uPIA")
        '  upload.Add("video", mediaObject)
        facebookClient.Post(path, upload)

        'For Each test As String In regex.Split(Left(strPageId, strPageId.ToString().Length - 1))
        '    'For Each test As String In regex.Split(strPageId)
        '    Dim path As String = test & "/photos"
        '    Dim facebookClient As New FacebookClient("AAAD2ZCc3HZAxABAOZCze7rZBrh659qqQUgGdlZBWSZCJ9wSS4SOeHd00kFTORcEZCJzUTXwih9CWiHY7Hn8xboMuu3xxZA903V6wBSL0oxs7AANDV8IZBJba5")
        '    '   Dim filepath As String = Server.MapPath(photo.PostedFile.FileName)
        '    Dim photopath As String = Server.MapPath("~/" & "uploads/" & strPhoto)
        '    Dim mediaObject As New FacebookMediaObject() With { _
        '         .FileName = photopath, _
        '         .ContentType = "image/jpg" _
        '    }
        '    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
        '    mediaObject.SetValue(fileBytes)
        '    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
        '    upload.Add("message", strmsg)
        '    upload.Add("image", mediaObject)
        '    facebookClient.Post(path, upload)
        'Next


        'Dim facebookClient As New FacebookClient("AAAD2ZCc3HZAxABAPtaMKzCQKocvsiH0aZCyAFP6gEsmyG1CF0RwpKNUW7JAZBiH7ylNRZCmaGDp4v2IxSNVSdyXXJVbRGigjwXcTJpejsAJppODRG7ykE")
        ''   Dim filepath As String = Server.MapPath(photo.PostedFile.FileName)
        'Dim mediaObject As New FacebookMediaObject() With { _
        '     .FileName = "aflac_header.jpg.", _
        '     .ContentType = "image/jpg" _
        '}
        'Dim fileBytes As Byte() = File.ReadAllBytes(Server.MapPath("~") + mediaObject.FileName)
        'mediaObject.SetValue(fileBytes)
        'Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
        'Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()

        'upload.Add("message", "my message")
        'upload.Add("image", mediaObject)

        'facebookClient.Post("/195470630536254/photos", upload)

        lblMessage.Text = "Image uploaded Successfully"
    End Sub

  

    Private Sub btnupload_ServerClick(sender As Object, e As System.EventArgs) Handles btnupload.ServerClick
        Dim stralbum As String = txtmsg.Value
        Dim strPageId As String = hdnselectedPages.Value
        Dim strPageName As String = hdnSelectedPagesName.Value
        Dim strPageImage As String = hdnSelectedPagesImage.Value
        Dim strAccessToken As String = hdnselectedPagesAccessToken.Value
        'Response.Write("test" & strPageId)
        'Response.Write(strPageName)
        'Response.Write(strAccessToken)
        'Response.End()
        'Dim strDate As String = Now.Date
        ' Dim strPageId As String = hdnselectedPages.Value
        'Dim strPageName As String = hdnSelectedPagesName.Value
        'Dim strPageImage As String = hdnSelectedPagesImage.Value
        Dim args = New Dictionary(Of String, Object)()
        ' args("name") = stralbum
        ''args("message") = strmessage
        ' args("source") = Server.MapPath(photo.PostedFile.FileName)


        ''Dim regex As New Regex(",")
        ''For Each test As String In regex.Split(strPageId)
        'Dim path As String = "https://graph.facebook.com/195470630536254/photos"
        'Dim fbapp = New FacebookClient("AAACEdEose0cBAHSfmZCqOlA9IlZCnZAcM3imZAyyvTo4JvMJTIppWHPTYpXBuCIAOxh7VYxRmOPg1YXrzYWVaPkCClzvAbWrcwnc2uNykJsrr46eWIkq")
        'fbapp.Post(path, args)
        'Next
        ' FacebookMediaObject facebookUploader = new FacebookMediaObject { FileName = "funny-image.jpg", ContentType = "image/jpg" };

        Dim facebookClient As New FacebookClient("AAAD2ZCc3HZAxABAPtaMKzCQKocvsiH0aZCyAFP6gEsmyG1CF0RwpKNUW7JAZBiH7ylNRZCmaGDp4v2IxSNVSdyXXJVbRGigjwXcTJpejsAJppODRG7ykE")
        '   Dim filepath As String = Server.MapPath(photo.PostedFile.FileName)
        Dim mediaObject As New FacebookMediaObject() With { _
             .FileName = "aflac_header.jpg.", _
             .ContentType = "image/jpg" _
        }
        Dim fileBytes As Byte() = File.ReadAllBytes(Server.MapPath("~") + mediaObject.FileName)
        mediaObject.SetValue(fileBytes)
        Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
        ' upload.Add("name", "photo name")
        upload.Add("message", "my message")
        upload.Add("image", mediaObject)
        ' upload1.Add("picture", "http://192.168.19.28/Content/images/header_logo.png")
        ' facebookClient.Post("me/albums", upload)
        facebookClient.Post("/195470630536254/photos", upload)
        ' facebookClient.Post("/195470630536254/picture", upload1)
        lblMessage.Text = "Post Submitted Successfully"
    End Sub

   


End Class