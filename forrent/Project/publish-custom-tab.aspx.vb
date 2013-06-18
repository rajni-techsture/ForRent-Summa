Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer
Imports Facebook
Imports System.Threading

Public Class publish_custom_tab
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            ViewState("PageID") = ""
            ViewState("PageAccessToken") = ""
            ViewState("PageName") = ""
            BindFanPages()
            BindCustomTab(Request("id"))
        End If
    End Sub


#Region "Bind Fan Pages"
    Sub BindFanPages()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim accessToken As String = Session("FacebookAccessToken")
                Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
                Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
                Dim url As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,category,access_token&return_ssl_resources=true&access_token={0}"
                Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, accessToken))
                Dim fbResponse As WebResponse = fbRequest.GetResponse()
                Dim stream As Stream = fbResponse.GetResponseStream()
                Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FanPage))

                Dim fPage As New FanPage()
                fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), FanPage)
                Dim listPages As New List(Of FanPage.m_data)

                For Each item As FanPage.m_data In fPage.data
                    listPages.Add(item)
                Next
                If listPages.Count > 0 Then
                    dstFanPages.DataSource = listPages
                    dstFanPages.DataBind()
                    '  plcData.Visible = True
                    '  plcNoData.Visible = False
                Else
                    dstFanPages.DataSource = Nothing
                    dstFanPages.DataBind()
                    '  plcData.Visible = False
                    '  plcNoData.Visible = True
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
            End If
        Catch ex As Exception
            '  ltrMessage.Text = "Error: " & ex.Message
        End Try
    End Sub
#End Region

#Region "Bind Custom Tab Content"
    Public Function BindCustomTab(ByVal intId As Integer)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BALCustomTab
                objBAL.CustomTabId = intId

                ds = objBAL.GetPublishedCustomTabById
                If ds.Tables(0).Rows.Count > 0 Then
                    divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("ct_Content")
                End If
                
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
            End If
        Catch ex As Exception
            '  ltrMessage.Text = "Error: " & ex.Message
        End Try
    End Function
#End Region


    Private Sub btnUpload_ServerClick(sender As Object, e As System.EventArgs) Handles btnUpload.ServerClick
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)

        Try
            Dim result As String = ""
            Dim AppID = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
            Dim url As String = "https://graph.facebook.com/{0}/tabs/?app_id={2}&access_token={1}&method=post"
            For Each item As DataListItem In dstFanPages.Items
                Dim myCheckBox As HtmlInputRadioButton
                myCheckBox = CType(item.FindControl("chkPage"), HtmlInputRadioButton)
                If myCheckBox.Checked = True Then
                    Dim strPageId As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                    Dim strPageAccessToken As String = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                    ViewState("PageName") = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
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
                End If
            Next
            If result.ToLower = "true" Then
                Dim objCustomTab As New CustomTabContent
                objCustomTab.FBPageId = ViewState("PageID")
                objCustomTab.FBUserId = Session("FacebookUserId")
                '   objCustomTab.Title = txtTabTitle.Value
                objCustomTab.Content = divSidebarHtml.InnerHtml
                objCustomTab.AddEditCustomTab()


                url = "https://graph.facebook.com/{0}/tabs?app_id={3}&access_token={1}&method=post&custom_name={2}"
                Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, ViewState("PageID"), ViewState("PageAccessToken"), "", AppID))
                Dim fbResponse As WebResponse = fbRequest.GetResponse()
                Dim stream As Stream = fbResponse.GetResponseStream()
                Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                Dim streamReader As New StreamReader(stream, encode)
                result = streamReader.ReadToEnd()
                streamReader.Close()
                lblMessage.Text = "Business Page Uploaded Successfully"
            End If
			
			 ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert();", True)
        Catch ex As Exception
            '  ltrMessage.Text = "Error: " & ex.Message
        End Try
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
    End Sub
End Class