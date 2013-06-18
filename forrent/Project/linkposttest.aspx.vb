Imports Facebook
Imports System.IO

Public Class linkposttest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/02b3d919dc29f57.jpg")
        Dim mediaObject As New FacebookMediaObject() With { _
                               .FileName = photopath, _
                               .ContentType = "image/jpg" _
                       }
        Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
        mediaObject.SetValue(fileBytes)
        'Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
        'upload.Add("message", "Rajni Test 1")
        'upload.Add("image", mediaObject)
        Dim fbapp = New FacebookClient("AAAD2ZCc3HZAxABAILGDytaGg4uDL6rkGvzy2mGPix8dc0Bi3o1KV7Pwz2VXffOjEXsLKlqv1B5vdYuCeDTxKEtd6r2mm98DAZAuzHV1gwZDZD")
        Dim path As String = "299429956741930/photos"
        Dim path2 As String = "299429956741930/feed"
        'fbapp.Post(Path, upload)
        Dim args1 = New Dictionary(Of String, Object)()
        args1("message") = "Rajni Test 2"
        args1("link") = "http://www.youtube.com/watch?v=tNov4VVyBrU&feature=g-logo"
        args1("image") = mediaObject
        fbapp.Post(path, args1)
    End Sub

End Class