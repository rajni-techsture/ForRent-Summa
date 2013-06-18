Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer

Public Class sweepstake
    Inherits System.Web.UI.Page

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            ViewState("PageID") = ""
            ViewState("PageAccessToken") = ""
            ViewState("PageName") = ""
            BindFanPages()
        End If
    End Sub
#End Region

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
                    plcData.Visible = True
                    plcNoData.Visible = False
                Else
                    dstFanPages.DataSource = Nothing
                    dstFanPages.DataBind()
                    plcData.Visible = False
                    plcNoData.Visible = True
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
            End If
        Catch ex As Exception
            ltrMessage.Text = "Facebook is experiencing problems at this time. Please save your work and try to publish later."
        End Try
    End Sub
#End Region

#Region "Create Sweep Stake"
    Private Sub btnCreate_ServerClick(sender As Object, e As System.EventArgs) Handles btnCreate.ServerClick
        Try
            Dim result As String = ""
            Dim AppID = System.Configuration.ConfigurationManager.AppSettings("SweepStakeFBAPI").ToString()
            Dim url As String = "https://graph.facebook.com/{0}/tabs/?app_id={2}&access_token={1}&method=post"
            For Each item As DataListItem In dstFanPages.Items
                Dim myCheckBox As HtmlInputCheckBox
                myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
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
                Dim objSweepStake As New BALSweepStake
                objSweepStake.FBPageId = ViewState("PageID")
                objSweepStake.FBUserId = Session("FacebookUserId")
                objSweepStake.Title = txtTabTitle.Value
                objSweepStake.Content = txtContent.Value.Replace(Chr(10), "<br/>")
                objSweepStake.AddEditSweepStake()

                If txtTabTitle.Value.Trim <> "" Then
                    url = "https://graph.facebook.com/{0}/tabs?app_id={3}&access_token={1}&method=post&custom_name={2}"
                    Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, ViewState("PageID"), ViewState("PageAccessToken"), txtTabTitle.Value, AppID))
                    Dim fbResponse As WebResponse = fbRequest.GetResponse()
                    Dim stream As Stream = fbResponse.GetResponseStream()
                    Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                    Dim streamReader As New StreamReader(stream, encode)
                    result = streamReader.ReadToEnd()
                    streamReader.Close()
                End If
                plcCreateTab.Visible = False
                plcEditTab.Visible = True
                'lnkEditTab.HRef = "http://www.facebook.com/" & ViewState("PageID")
                lnkEditTab.HRef = "http://www.facebook.com/pages/" & ViewState("PageName").ToString.Replace(" ", "-") & "/" & ViewState("PageID") & "/?sk=app_" & AppID
            Else
                ltrMessage.Text = result
                plcCreateTab.Visible = True
                plcEditTab.Visible = False
            End If
        Catch ex As Exception
            ltrMessage.Text = "Facebook is experiencing problems at this time. Please save your work and try to publish later."
        End Try
    End Sub
#End Region
End Class