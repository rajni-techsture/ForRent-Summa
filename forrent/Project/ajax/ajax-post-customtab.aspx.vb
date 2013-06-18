Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer
Public Class ajax_post_customtab
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindCustomTab(Request("id"))
        Dim strMsg As String = ""
        Try
            Dim result As String = ""
            Dim AppID = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
            Dim url As String = "https://graph.facebook.com/{0}/tabs/?app_id={2}&access_token={1}&method=post"
            'For Each item As DataListItem In dstFanPages.Items
            '    Dim myCheckBox As HtmlInputCheckBox
            '    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
            '    If myCheckBox.Checked = True Then
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
            '    End If
            'Next
            If result.ToLower = "true" Then
                Dim objCustomTab As New CustomTabContent
                objCustomTab.FBPageId = ViewState("PageID")
                objCustomTab.FBUserId = Session("FacebookUserId")
                '   objCustomTab.Title = txtTabTitle.Value
                objCustomTab.Content = divSidebarHtml.InnerHtml.Replace("notextedit", "")
                ' Response.Write(divSidebarHtml.InnerHtml)
                'Response.End()
                objCustomTab.AddEditCustomTab()


                url = "https://graph.facebook.com/{0}/tabs?app_id={3}&access_token={1}&method=post&custom_name={2}"
                Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, ViewState("PageID"), ViewState("PageAccessToken"), "*WelCome*", AppID))
                Dim fbResponse As WebResponse = fbRequest.GetResponse()
                Dim stream As Stream = fbResponse.GetResponseStream()
                Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                Dim streamReader As New StreamReader(stream, encode)
                result = streamReader.ReadToEnd()
                streamReader.Close()
                ' lblMessage.Text = "Business Page Uploaded Successfully"
            End If
        Catch ex As Exception
            strMsg = "Error: " & ex.Message
        End Try
        Response.Write(strMsg)
        Response.End()
    End Sub

#Region "Bind Custom Tab Content"
    Public Function BindCustomTab(ByVal intId As Integer)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BALCustomTab
                objBAL.CustomTabId = intId

                ds = objBAL.GetPublishedCustomTabById
                If ds.Tables(0).Rows.Count > 0 Then
                    divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("ct_Content").Replace("notextedit", "")
                End If

            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
            End If
        Catch ex As Exception
            '  ltrMessage.Text = "Error: " & ex.Message
        End Try
    End Function
#End Region
End Class