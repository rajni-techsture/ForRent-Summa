Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer

Public Class ajax_post_sweepstake
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strMsg As String = ""
        Try
            Dim result As String = ""
            Dim AppID = System.Configuration.ConfigurationManager.AppSettings("SweepStakeFBAPI").ToString()
            Dim url As String = "https://graph.facebook.com/{0}/tabs/?app_id={2}&access_token={1}&method=post"
            Dim strPageId As String = Request("pid")
            Dim strPageAccessToken As String = Request("pat")
            ViewState("PageName") = Request("pnm")
            If strPageId <> "" AndAlso strPageAccessToken <> "" Then
                ViewState("PageID") = strPageId
                ViewState("PageAccessToken") = strPageAccessToken
                Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, strPageId, strPageAccessToken, AppID))
                Dim fbResponse As WebResponse = fbRequest.GetResponse()
                Dim stream As Stream = fbResponse.GetResponseStream()
                Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                Dim streamReader As New StreamReader(stream, encode)
                result = streamReader.ReadToEnd()
                streamReader.Close()
            End If

            If result.ToLower = "true" Then
                url = "https://graph.facebook.com/{0}/tabs?app_id={3}&access_token={1}&method=post&custom_name={2}"
                Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, ViewState("PageID"), ViewState("PageAccessToken"), "Sweepstake", AppID))
                Dim fbResponse As WebResponse = fbRequest.GetResponse()
                Dim stream As Stream = fbResponse.GetResponseStream()
                Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                Dim streamReader As New StreamReader(stream, encode)
                result = streamReader.ReadToEnd()
                streamReader.Close()
                'lnkEditTab.HRef = "http://www.facebook.com/pages/" & ViewState("PageName").ToString.Replace(" ", "-") & "/" & ViewState("PageID") & "/?sk=app_" & AppID
            End If
        Catch ex As Exception
            strMsg = "Error: " & ex.Message
        End Try
        Response.Write(strMsg)
        Response.End()
    End Sub

End Class