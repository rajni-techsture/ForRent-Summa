Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook

Public Class FriendList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("FacebookAccessToken") = "AAAD2ZCc3HZAxABANKhUmZCLNvnFCkHZBbB4Y1PZBZCyoP9UblZCYhQAZAZCQSRkJ4IZCzqScBVVJK2CJ3QLRF8tBk1HUma9c3TmhsQnwQqIS8ePAZDZD"
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim accessToken As String = Session("FacebookAccessToken")
            Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId")
            Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey")
            Dim url As String = "https://graph.facebook.com/me/friends?fields=id,name,picture&access_token={0}"
            Dim wrequest As WebRequest = WebRequest.Create(String.Format(url, accessToken))
            Dim wresponse As WebResponse = wrequest.GetResponse()
            Dim stream As Stream = wresponse.GetResponseStream()

            Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FaceBookFriendList))

            Dim fList As New FaceBookFriendList()
            fList = TryCast(dataContractJsonSerializer.ReadObject(stream), FaceBookFriendList)


            Dim fData As String = "<table><tr>"
            For i As Integer = 1 To fList.data.Length
                If i Mod 4 <> 0 Then
                    If (i - 1) > 0 And (i - 1) Mod 4 = 0 Then
                        fData = fData & "<tr><td width='170' height='115'><img src='" & fList.data(i - 1).picture & "' class='imgborder'  /><br/><div style='padding-top:7px'>" & fList.data(i - 1).name & "</div><input type='hidden' value='" & fList.data(i - 1).id & "' /></td>"
                    Else
                        fData = fData & "<td width='170' height='115'><img src='" & fList.data(i - 1).picture & "' class='imgborder' /><br/><div style='padding-top:7px'>" & fList.data(i - 1).name & "</div><input type='hidden' value='" & fList.data(i - 1).id & "' /></td>"
                    End If
                Else
                    fData = fData & "<td width='170' height='115'><img src='" & fList.data(i - 1).picture & "' class='imgborder' /><br/><div style='padding-top:7px'>" & fList.data(i - 1).name & "</div><input type='hidden' value='" & fList.data(i - 1).id & "' /></td>"
                End If
            Next
            fData = fData & "</tr></table>"
            divFriend.InnerHtml = fData
            'Response.Close()
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
        End If
    End Sub

End Class