Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports Facebook

Public Class handshake
    Inherits System.Web.UI.Page
    Dim objFBUserPagesDetails As New FacebookUserAndPagesDetails
    Public strPageId As String = ""
    Dim objLog As New cls_Log
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            hdnId.Value = Session("OpenWindow")
            Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId")
            Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey")
            Dim url As String = "https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}"
            Dim redirectUri As String = HttpUtility.UrlEncode(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "handshake.aspx")

            '' LOG ----------------------------
            objLog.SessionId = Session.SessionID
            objLog.HandshakeCode = Request.QueryString("code")
            objLog.HandshakeURL = String.Format(url, clientId, redirectUri, clientSecret, Request.QueryString("code"))
            objLog.HandShakeLog()


            Dim request1 As WebRequest = WebRequest.Create(String.Format(url, clientId, redirectUri, clientSecret, Request.QueryString("code")))
            Dim response1 As WebResponse = request1.GetResponse()
            Dim stream As Stream = response1.GetResponseStream()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            Dim streamReader As New StreamReader(stream, encode)

            Dim accessToken As String = streamReader.ReadToEnd().Replace("access_token=", "")
            streamReader.Close()
            Session("FacebookAccessToken") = accessToken

            'if you do not add offline access permision then access token return with expiration time otherwise it cannot conatain expiration time
            'Response.Write("Token  " & Session("FacebookAccessToken") & "  access  " & accessToken)
            'lblAccessToken.Text = Session("FacebookAccessToken")

            url = "https://graph.facebook.com/me?access_token={0}"
            request1 = WebRequest.Create(String.Format(url, accessToken))
            response1 = request1.GetResponse()
            stream = response1.GetResponseStream()
            Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FacebookUser))

            Dim user As New FacebookUser()
            user = TryCast(dataContractJsonSerializer.ReadObject(stream), FacebookUser)
            Session("FacebookUserId") = user.id
            Session("FacebookUserName") = user.name

            If user.outherror IsNot Nothing Then
                If user.outherror.type = "OAuthException" Then
                    objFBUserPagesDetails.ErrorUploadedData = "Error At Login In Application"
                    objFBUserPagesDetails.OuthErrorDetails = user.outherror.message
                    objFBUserPagesDetails.OuthErrorCode = user.outherror.code
                    objFBUserPagesDetails.OuthErrorType = user.outherror.type
                    objFBUserPagesDetails.AddOuthErrorDetails()

                    Dim Url1 As String = "https://graph.facebook.com/oauth/authorize?type=web_server&client_id={0}&redirect_uri={1}&scope=offline_access,manage_pages,publish_stream,user_photos,user_photo_video_tags,photo_upload,user_videos,read_stream,email&display=popup"
                    Response.Redirect(String.Format(Url1, clientId, redirectUri))
                Else
                    objFBUserPagesDetails.ErrorUploadedData = "Error At Login In Application"
                    objFBUserPagesDetails.OuthErrorDetails = "Other Error Occurs"
                    objFBUserPagesDetails.OuthErrorCode = ""
                    objFBUserPagesDetails.OuthErrorType = "Other Error"
                    objFBUserPagesDetails.AddOuthErrorDetails()

                    Dim Url1 As String = "https://graph.facebook.com/oauth/authorize?type=web_server&client_id={0}&redirect_uri={1}&scope=offline_access,manage_pages,publish_stream,user_photos,user_photo_video_tags,photo_upload,user_videos,read_stream,email&display=popup"
                    Response.Redirect(String.Format(Url1, clientId, redirectUri))
                End If
            Else
                objFBUserPagesDetails.FBUSerId = user.id
                objFBUserPagesDetails.TSMAUserId = Session("SiteUserId")
                objFBUserPagesDetails.FBUSerFirstName = user.first_name
                objFBUserPagesDetails.FBUSerLastName = user.last_name
                objFBUserPagesDetails.FBUSerName = user.username
                objFBUserPagesDetails.FBUSerToken = Session("FacebookAccessToken")
                objFBUserPagesDetails.FBUserEmail = user.email
                objFBUserPagesDetails.FBUserTokenExpirationDate = "Never"
                objFBUserPagesDetails.AddUpdateFBUserDetails()

                Dim strUserId As String = user.id.ToString
                Dim objBAL As New BALCompanyIndusty

                If Session("Industry") <> Nothing AndAlso IsNumeric(Session("Industry")) AndAlso Session("Industry") <> -1 Then
                    Dim ds As New DataSet
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.CompanyId = Session("Industry")
                    objBAL.GetIndustryUserDetails()

                End If
                If Session("Company") <> Nothing AndAlso IsNumeric(Session("Company")) AndAlso Session("Company") <> -1 Then
                    Dim ds As New DataSet
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.CompanyId = Session("Company")
                    objBAL.GetCompnayUserDetails()
                End If
                Session("Company") = 0
                Session("Industry") = 0

                Dim dsCompInd As New DataSet
                Dim objBALCompInd As New BALCompanyIndusty
                objBALCompInd.FBUserId = Session("FacebookUserId")
                dsCompInd = objBALCompInd.GetCompnayIndustryName

                If dsCompInd.Tables(0).Rows.Count > 0 Then
                    Dim intIndustryId As Integer = 1
                    Dim intCompanyId As Integer = 0
                    Dim strName As String = Session("FacebookUserName")
                    GetSetCookies.SetCookie("SelectedName", strName, 1)
                    GetSetCookies.SetCookie("IndustryId", intIndustryId, 1)
                    GetSetCookies.SetCookie("CompanyId", intCompanyId, 1)
                End If

                Dim Token As String = Session("hdnToken").ToString
                Try
                    If Session("hdnToken") <> Nothing AndAlso Session("hdnToken") <> "" And IsPostBack = False Then
                        Dim objServiceFanpages As New ForrentAuthontication.FacebookPagesClient()
                        Dim Result As ForrentAuthontication.SitePageInfo() = objServiceFanpages.GetFacebookPages(Session("hdnToken").ToString)

                        Dim fpageid As New List(Of String)
                        For i As Integer = 0 To Result.Count - 1
                            fpageid.Add((StrReverse(StrReverse(Result(i).FacebookPageUrl).Split("/")(0))))
                        Next
                        Session("FanPageIDs") = fpageid

                        Dim fpageURL As New List(Of String)
                        For i As Integer = 0 To Result.Count - 1
                            fpageURL.Add(Result(i).FacebookPageUrl)
                        Next
                        Session("FanPageURLs") = fpageURL
                        Dim fpageFinalID As New List(Of String)
                        For x As Integer = 0 To Result.Count - 1
                            If IsNumeric(fpageid.Item(x)) Then
                                fpageFinalID.Add(fpageid.Item(x))
                            Else
                                fpageFinalID.Add(fpageURL.Item(x))
                            End If
                        Next
                        Session("FinalFanPages") = fpageFinalID

                        Dim siteid As New List(Of String)
                        For i As Integer = 0 To Result.Count - 1
                            siteid.Add(Result(i).ForrentSiteId)
                        Next
                        Session("ForRentSiteID") = siteid

                        If Result.Count = 0 Then
                            AddForrentData()
                        Else
                            AddForrentData()
                            Dim obj As New BALlogin
                            Dim k As Integer = 0
                            While (k < siteid.Count)
                                obj.SiteUserID = Session("SiteUserId")
                                obj.SiteID = siteid.Item(k).ToString
                                If IsNumeric(fpageid.Item(k)) Then
                                    obj.FanPageID = fpageid.Item(k).ToString
                                Else
                                    obj.FanPageID = ""
                                End If
                                obj.FanPageURL = fpageURL.Item(k).ToString

                                obj.AddReferenceSiteIdToFanPageId()
                                k = k + 1
                            End While
                        End If

                        ''-------------- Forrent Page Log ---------------

                        For i As Integer = 0 To Result.Length - 1
                            objLog.SessionId = Session.SessionID
                            objLog.UserId = Session("SiteUserId")
                            objLog.UserName = Session("FacebookUserName")
                            objLog.FRPageId = (StrReverse(StrReverse(Result(i).FacebookPageUrl).Split("/")(0)))
                            objLog.FRPageName = Result(i).PropertyName
                            objLog.FRPageURL = Result(i).FacebookPageUrl
                            objLog.FRSiteID = Result(i).ForrentSiteId
                            objLog.ForrentPageLog()
                        Next
                    End If
                Catch ex As Exception
                    objLog.SessionId = Session.SessionID
                    objLog.UserId = Session("SiteUserId")
                    objLog.UserName = Session("FacebookUserName")
                    objLog.ErrorMsg = ex.Message.ToString
                    objLog.Remarks = "ForRent Webservice Call"
                    objLog.ErrorLog()
                End Try
                BindAllAutoPostFanPages()
            End If
        Catch ex As Exception
            Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId")
            Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey")
            Dim url As String = "https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}"
            Dim redirectUri As String = HttpUtility.UrlEncode(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "handshake.aspx")
            Dim rURL As String = String.Format(url, clientId, redirectUri, clientSecret, Request.QueryString("code"))
            objLog.SessionId = Session.SessionID
            objLog.UserId = Session("SiteUserId")
            objLog.UserName = Session("FacebookUserName")
            objLog.ErrorMsg = ex.Message.ToString & " ||  " & rURL & " || " & Session("FacebookAccessToken").ToString
            objLog.Remarks = "Page Load"
            objLog.ErrorLog()
            Session("SiteUserId") = Nothing
            Session("FacebookUserName") = Nothing
            If ex.Message.Contains("The remote server returned an error: (400)") Then
                Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide11;", ";openNewWin('" & strUrl & "');", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", "$('#diverr').css('display','block');", True)
            End If
        End Try
    End Sub

    Sub BindAllAutoPostFanPages()
        Try
            Dim accessToken1 As String = Session("FacebookAccessToken")
            Dim clientId1 As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
            Dim clientSecret1 As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
            Dim url1 As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,link,category,access_token&return_ssl_resources=true&access_token={0}"
            Dim fbRequest1 As WebRequest = WebRequest.Create(String.Format(url1, accessToken1))
            Dim fbResponse1 As WebResponse = fbRequest1.GetResponse()
            Dim stream1 As Stream = fbResponse1.GetResponseStream()
            Dim dataContractJsonSerializer1 As New DataContractJsonSerializer(GetType(FanPage))

            Dim fPage1 As New FanPage()
            fPage1 = TryCast(dataContractJsonSerializer1.ReadObject(stream1), FanPage)


            Dim url2 As String = "https://graph.facebook.com/me?fields=id,name,picture,link&return_ssl_resources=true&access_token={0}"
            Dim fbrequest2 As WebRequest = WebRequest.Create(String.Format(url2, accessToken1))
            Dim fbresponse2 As WebResponse = fbrequest2.GetResponse()
            Dim stream2 As Stream = fbresponse2.GetResponseStream()
            Dim dataContractJsonSerializer2 As New DataContractJsonSerializer(GetType(FacebookUser))

            Dim fUser1 As New FacebookUser()
            fUser1 = TryCast(dataContractJsonSerializer2.ReadObject(stream2), FacebookUser)

            'UpdateAccessTokenOnLogin(fUser1.id, Session("FacebookAccessToken"), fUser1.picture.data.url)

            'For Each item As FanPage.m_data In fPage1.data
            '    UpdateAccessTokenOnLogin(item.id, item.access_token, item.picture.data.url.ToString)
            'Next

            ''-------------- FB Page Log ---------------

            'For Each item As FanPage.m_data In fPage1.data
            '    objLog.SessionId = Session.SessionID
            '    objLog.UserId = Session("SiteUserId")
            '    objLog.UserName = Session("FacebookUserName")
            '    objLog.FBPageID = item.id
            '    objLog.FBPageName = item.name
            '    objLog.FBPageURL = item.link
            '    objLog.FBAccessToken = item.access_token
            '    objLog.FaceBookPageLog()
            'Next


            If Session("FinalFanPages") IsNot Nothing Then
                Dim forrentfanpages As New List(Of String)
                forrentfanpages = Session("FinalFanPages")

                Dim dtTable As New DataTable
                dtTable.Columns.Add(New DataColumn("name", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("picture", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("access_token", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("link", Type.GetType("System.String")))

                For Each item As FanPage.m_data In fPage1.data
                    If Not item.access_token Is Nothing Then
                        If Not item.link Is Nothing Then
                            For j As Integer = 0 To forrentfanpages.Count - 1
                                If item.link.ToString.ToLower = forrentfanpages.Item(j).ToString.ToLower Then
                                    Dim dtRow1 As DataRow = dtTable.NewRow
                                    dtRow1("name") = item.name.ToString
                                    dtRow1("id") = item.id.ToString
                                    dtRow1("picture") = item.picture.data.url.ToString
                                    dtRow1("access_token") = item.access_token.ToString
                                    dtRow1("link") = item.link.ToString
                                    dtTable.Rows.Add(dtRow1)
                                ElseIf item.id.ToString.ToLower = forrentfanpages.Item(j).ToString.ToLower Then
                                    Dim dtRow1 As DataRow = dtTable.NewRow
                                    dtRow1("name") = item.name.ToString
                                    dtRow1("id") = item.id.ToString
                                    dtRow1("picture") = item.picture.data.url.ToString
                                    dtRow1("access_token") = item.access_token.ToString
                                    dtRow1("link") = item.link.ToString
                                    dtTable.Rows.Add(dtRow1)
                                End If
                            Next
                        End If
                    End If
                Next

                dtTable.TableName = "fanpages"
                Dim dv As DataView = New DataView(dtTable)
                dv.Sort = "name"

                If dv.Count > 0 Then
                    Dim myros As DataRowView
                    For Each myros In dv
                        Dim objPagesDetails As New FacebookUserAndPagesDetails
                        objPagesDetails.FBUSerId = Session("FacebookUserId")
                        objPagesDetails.TSMAUserId = Session("SiteUserId")
                        objPagesDetails.FBPageId = myros("id")
                        objPagesDetails.FBPageName = myros("name")
                        objPagesDetails.FBPageURl = myros("link")
                        objPagesDetails.FBPageToken = myros("access_token")
                        objPagesDetails.FBPageTokenExpirationDate = "Never"
                        objPagesDetails.AddUpdateFBUserPageDetails()
                        UpdateAccessTokenOnLogin(myros("id"), myros("access_token"), myros("picture"))
                        strPageId = strPageId + myros("id") & ","
                    Next
                End If

            Else
                Dim dtTable As New DataTable
                dtTable.Columns.Add(New DataColumn("name", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("picture", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("access_token", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("link", Type.GetType("System.String")))

                Dim dtRow As DataRow = dtTable.NewRow
                dtRow("name") = fUser1.name
                dtRow("id") = fUser1.id
                dtRow("picture") = fUser1.picture.data.url
                dtRow("access_token") = Session("FacebookAccessToken")
                dtRow("link") = fUser1.link
                dtTable.Rows.Add(dtRow)

                For Each item As FanPage.m_data In fPage1.data
                    If Not item.access_token Is Nothing Then
                        If Not item.link Is Nothing Then
                            If Not item.picture Is Nothing Then
                                Dim dtRow1 As DataRow = dtTable.NewRow
                                dtRow1("name") = item.name.ToString
                                dtRow1("id") = item.id.ToString
                                dtRow1("picture") = item.picture.data.url.ToString
                                dtRow1("access_token") = item.access_token.ToString
                                dtRow1("link") = item.link.ToString
                                dtTable.Rows.Add(dtRow1)
                            End If
                        End If
                    End If
                Next

                dtTable.TableName = "fanpages"
                Dim dv As DataView = New DataView(dtTable)
                dv.Sort = "name"

                If dv.Count > 0 Then
                    Dim myros As DataRowView
                    For Each myros In dv
                        Dim objPagesDetails As New FacebookUserAndPagesDetails
                        objPagesDetails.FBUSerId = Session("FacebookUserId")
                        objPagesDetails.TSMAUserId = Session("SiteUserId")
                        objPagesDetails.FBPageId = myros("id")
                        objPagesDetails.FBPageName = myros("name")
                        objPagesDetails.FBPageURl = myros("link")
                        objPagesDetails.FBPageToken = myros("access_token")
                        objPagesDetails.FBPageTokenExpirationDate = "Never"
                        objPagesDetails.AddUpdateFBUserPageDetails()
                        UpdateAccessTokenOnLogin(myros("id"), myros("access_token"), myros("picture"))
                        strPageId = strPageId + myros("id") & ","
                    Next
                End If
            End If
            Session("strPageId") = strPageId
        Catch ex As Exception
            objLog.SessionId = Session.SessionID
            objLog.UserId = Session("SiteUserId")
            objLog.UserName = Session("FacebookUserName")
            objLog.ErrorMsg = ex.Message.ToString
            objLog.Remarks = "FaceBook Page Request"
            objLog.ErrorLog()
        End Try
    End Sub

   
    Sub UpdateAccessTokenOnLogin(ByVal strPageId As String, ByVal strToken As String, ByVal strImage As String)
        Try
            Dim objLogin As New BALSchedulePost
            objLogin.FBUserId = Session("FacebookUserId")
            objLogin.FBPageId = strPageId
            objLogin.FBPageAccessToken = strToken
            objLogin.FBPageImage = strImage
            objLogin.UpdateAccessTokenOnLogin()
        Catch ex As Exception
            objLog.SessionId = Session.SessionID
            objLog.UserId = Session("SiteUserId")
            objLog.UserName = Session("FacebookUserName")
            objLog.ErrorMsg = ex.Message.ToString
            objLog.Remarks = "Update Access Token: PageID: " & strPageId & " || " & "Token: " & strToken & " || " & "Image: " & strImage
            objLog.ErrorLog()
        Finally
            'objLog.SessionId = Session.SessionID
            'objLog.UserId = Session("SiteUserId")
            'objLog.UserName = Session("FacebookUserName")
            'objLog.FBUserID = Session("FacebookUserId")
            'objLog.FBPageID = strPageId
            'objLog.FBAccessToken = strToken
            'objLog.FBImage = strImage
            'objLog.TokenUpdateLog()
        End Try
    End Sub

    Sub AddForrentData()
        Dim obj As New BALlogin
        Dim ds As New DataSet
        obj.ForRentAccessToken = Session("hdnToken").ToString
        obj.UserName = Session("FacebookUserName")
        ds = obj.AddUpdateForRentData()
        If ds.Tables(0).Rows.Count > 0 Then
            Session("SiteUserId") = ds.Tables(0).Rows(0).Item("userID")
        End If
    End Sub


End Class