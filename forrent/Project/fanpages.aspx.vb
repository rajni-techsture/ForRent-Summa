Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook

Public Class fanpages
    Inherits System.Web.UI.Page

    'Dim objConn As New clConn
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim accessToken As String = Session("FacebookAccessToken")
            Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId")
            Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey")
            Dim url As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,category,access_token&return_ssl_resources=true&access_token={0}"
            Dim request As WebRequest = WebRequest.Create(String.Format(url, accessToken))
            Dim response As WebResponse = request.GetResponse()
            Dim stream As Stream = response.GetResponseStream()
            Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FanPage))
            Dim fPage As New FanPage()
            fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), FanPage)
            Dim listPages As New List(Of FanPage.m_data)

                For Each item As FanPage.m_data In fPage.data
                    listPages.Add(item)
                Next
                dstFanPages.DataSource = listPages
                dstFanPages.DataBind()
            'PostScheduler()
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
        End If
    End Sub

End Class