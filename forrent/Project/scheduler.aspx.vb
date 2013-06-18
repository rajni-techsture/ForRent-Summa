Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports System.IO
Imports Facebook
Imports System.Threading
Public Class scheduler
    Inherits RoutablePage
    Implements IRequiresSessionState
    Dim objLib As New Library
    Public strSelectionType As String = ""
    Public intAutoPostOnOff As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoginCheck.LoginSessionCheck()
        Try
            If Not Page.IsPostBack Then
                ViewState("CurrentSentAutoPostPageIndex") = 1
                ViewState("CurrentPageIndex") = 1
                ViewState("CurrentAutoPostPageIndex") = 1
                ViewState("CurrentPageIndexSent") = 1
                ViewState("CurrentPageIndexScheduled") = 1
                If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                    BindAllAutoPostFanPages()
                    Dim accessToken As String = Session("FacebookAccessToken")
                    Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
                    Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
                    Dim url As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,link,category,access_token&return_ssl_resources=true&access_token={0}"
                    Dim request As WebRequest = WebRequest.Create(String.Format(url, accessToken))
                    Dim response1 As WebResponse = request.GetResponse()
                    Dim stream As Stream = response1.GetResponseStream()
                    Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FanPage))

                    Dim fPage As New FanPage()
                    fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), FanPage)

                    Dim url1 As String = "https://graph.facebook.com/me?fields=id,name,picture,link&return_ssl_resources=true&access_token={0}"
                    Dim request1 As WebRequest = WebRequest.Create(String.Format(url1, accessToken))
                    Dim response2 As WebResponse = request1.GetResponse()
                    Dim stream1 As Stream = response2.GetResponseStream()
                    Dim dataContractJsonSerializer2 As New DataContractJsonSerializer(GetType(FacebookUser))

                    Dim fUser As New FacebookUser()
                    fUser = TryCast(dataContractJsonSerializer2.ReadObject(stream1), FacebookUser)



                    If Session("FinalFanPages") IsNot Nothing Then
                        Dim forrentfanpages As New List(Of String)
                        forrentfanpages = Session("FinalFanPages")


                        Dim dtTable As New DataTable
                        dtTable.Columns.Add(New DataColumn("name", Type.GetType("System.String")))
                        dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.String")))
                        dtTable.Columns.Add(New DataColumn("picture", Type.GetType("System.String")))
                        dtTable.Columns.Add(New DataColumn("access_token", Type.GetType("System.String")))
                        dtTable.Columns.Add(New DataColumn("link", Type.GetType("System.String")))

                        For Each item As FanPage.m_data In fPage.data

                            If Not item.access_token Is Nothing Then
                                If Not item.link Is Nothing Then
                                    'If Not item.picture Is Nothing Then
                                    For j As Integer = 0 To forrentfanpages.Count - 1
                                        If item.link.ToString.ToLower = forrentfanpages.Item(j).ToString.ToLower Then
                                            Dim dtRow1 As DataRow = dtTable.NewRow
                                            dtRow1("name") = item.name.ToString
                                            dtRow1("id") = item.id.ToString
                                            dtRow1("picture") = item.picture.data.url.ToString
                                            dtRow1("access_token") = item.access_token.ToString
                                            dtRow1("link") = item.link.ToString
                                            dtTable.Rows.Add(dtRow1)
                                            'Exit For
                                        ElseIf item.id.ToString.ToLower = forrentfanpages.Item(j).ToString.ToLower Then
                                            Dim dtRow1 As DataRow = dtTable.NewRow
                                            dtRow1("name") = item.name.ToString
                                            dtRow1("id") = item.id.ToString
                                            dtRow1("picture") = item.picture.data.url.ToString
                                            dtRow1("access_token") = item.access_token.ToString
                                            dtRow1("link") = item.link.ToString
                                            dtTable.Rows.Add(dtRow1)
                                            '   NonFanPageTable.Visible = False

                                        End If
                                        'Response.Write("forrent Page url  " & forrentfanpages.Item(j).ToString.ToLower & "<br/>")

                                    Next
                                    'Response.Write("facebook Page url  " & item.link.ToString.ToLower & "<br/>")
                                    'End If
                                End If


                            End If
                        Next
                        'Response.End()
                        dtTable.TableName = "fanpages"
                        Dim dv As DataView = New DataView(dtTable)
                        dv.Sort = "name"

                        If dv.Count > 0 Then
                            dstFanPages.DataSource = dv
                            dstFanPages.DataBind()
                            plcData.Visible = True
                            plcNoData.Visible = False
                            plcError.Visible = False
                        Else
                            Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=2&at=" & Session("hdnToken") & ""
                            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide13;", ";openNewWin('" & strUrl & "');", True)
                            'dstFanPages.DataSource = Nothing
                            'dstFanPages.DataBind()
                            'plcData.Visible = False
                            'plcNoData.Visible = True
                            'plcError.Visible = False
                        End If
                    Else
                        Dim dtTable As New DataTable
                        dtTable.Columns.Add(New DataColumn("name", Type.GetType("System.String")))
                        dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.String")))
                        dtTable.Columns.Add(New DataColumn("picture", Type.GetType("System.String")))
                        dtTable.Columns.Add(New DataColumn("access_token", Type.GetType("System.String")))
                        'dtTable.Columns.Add(New DataColumn("link", Type.GetType("System.String")))

                        Dim dtRow As DataRow = dtTable.NewRow


                        dtRow("name") = fUser.name
                        dtRow("id") = fUser.id
                        dtRow("picture") = fUser.picture.data.url
                        dtRow("access_token") = Session("FacebookAccessToken")
                        'dtRow("link") = fUser.link

                        dtTable.Rows.Add(dtRow)



                        For Each item As FanPage.m_data In fPage.data
                            If Not item.access_token Is Nothing Then
                                If Not item.picture Is Nothing Then
                                    Dim dtRow1 As DataRow = dtTable.NewRow
                                    dtRow1("name") = item.name.ToString
                                    dtRow1("id") = item.id.ToString
                                    dtRow1("picture") = item.picture.data.url.ToString
                                    dtRow1("access_token") = item.access_token.ToString
                                    ' dtRow1("link") = item.link.ToString

                                    dtTable.Rows.Add(dtRow1)
                                End If

                            End If
                        Next
                        dtTable.TableName = "fanpages"
                        Dim dv As DataView = New DataView(dtTable)
                        dv.Sort = "name"

                        If dv.Count > 0 Then
                            dstFanPages.DataSource = dv
                            dstFanPages.DataBind()
                            plcData.Visible = True
                            plcNoData.Visible = False
                        Else
                            Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=2&at=" & Session("hdnToken") & ""
                            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide12;", ";openNewWin('" & strUrl & "');", True)
                            'dstFanPages.DataSource = Nothing
                            'dstFanPages.DataBind()
                            'plcData.Visible = False
                            'plcNoData.Visible = True
                        End If
                    End If

                    BindAllDrafts()
                    BindAllAutoPost()
                    BindAllSentAutoPost()
                    BindAutoPostSchedule()
                    BindAllSentItems()
                    BindAllScheduledPosts()
                    BindAutoPostFanPages()

                    For Each Items As DataListItem In dtlDrafts.Items
                        BindDraftFanPages(CType(Items.FindControl("hdnDraftId"), HtmlInputHidden).Value)
                    Next
                    For Each Items As DataListItem In dtlSentItems.Items
                        BindSentItemsFanPages(CType(Items.FindControl("hdnSentItemId"), HtmlInputHidden).Value)
                    Next
                    For Each Items As DataListItem In dtlScheduledPosts.Items
                        BindScheduledPostsFanPages(CType(Items.FindControl("hdnScheduledPostId"), HtmlInputHidden).Value)
                    Next

                    If RequestContext.RouteData.Values("sm_Id") <> "" Then
                        Dim Id As String
                        Id = RequestContext.RouteData.Values("sm_Id")
                        BindDraftData(Id)
                        BindSentItemData(Id)
                        BindScheduledPostData(Id)
                    End If
                    objLib.FBUserId = Session("FacebookUserId")
                    strSelectionType = objLib.GetUSerSelectionType
                    BindLibraryCategories()
                Else
                    Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
                End If

            Else
                GenreateControls()
                GenreateControlsSent()
                GenreateControlsScheduled()
                GenerateAutoPostControls()
                GenerateSentAutoPostControls()
            End If

        Catch ex As Exception
            If ex.Message.Contains("The remote server returned an error: (400)") Then
                Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=2&at=" & Session("hdnToken") & ""
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide11;", ";openNewWin('" & strUrl & "');", True)
            Else
                lblMessage.Text = "Error: " & ex.Message
            End If
            'plcData.Visible = False
            'plcNoData.Visible = False
            'plcError.Visible = True
        End Try
    End Sub

#Region "Bind Auto Post Fan Pages"

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
            Dim request1 As WebRequest = WebRequest.Create(String.Format(url2, accessToken1))
            Dim response2 As WebResponse = request1.GetResponse()
            Dim stream2 As Stream = response2.GetResponseStream()
            Dim dataContractJsonSerializer2 As New DataContractJsonSerializer(GetType(FacebookUser))

            Dim fUser1 As New FacebookUser()
            fUser1 = TryCast(dataContractJsonSerializer2.ReadObject(stream2), FacebookUser)

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
                                    'Exit For
                                ElseIf item.id.ToString.ToLower = forrentfanpages.Item(j).ToString.ToLower Then
                                    Dim dtRow1 As DataRow = dtTable.NewRow
                                    dtRow1("name") = item.name.ToString
                                    dtRow1("id") = item.id.ToString
                                    dtRow1("picture") = item.picture.data.url.ToString
                                    dtRow1("access_token") = item.access_token.ToString
                                    dtRow1("link") = item.link.ToString
                                    dtTable.Rows.Add(dtRow1)
                                    '   NonFanPageTable.Visible = False
                                End If
                            Next
                        End If
                    End If
                Next
                dtTable.TableName = "fanpages"
                Dim dv As DataView = New DataView(dtTable)
                dv.Sort = "name"

                If dv.Count > 0 Then
                    dstAutoPostFanPages.DataSource = dv
                    dstAutoPostFanPages.DataBind()
                    plcData.Visible = True
                    plcNoData.Visible = False
                    plcAutoError.Visible = False
                Else
                    dstAutoPostFanPages.DataSource = Nothing
                    dstAutoPostFanPages.DataBind()
                    plcAutoData.Visible = False
                    plcNoAutoData.Visible = True
                    plcAutoError.Visible = False
                End If
            Else
                Dim dtTable As New DataTable
                dtTable.Columns.Add(New DataColumn("name", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("picture", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("access_token", Type.GetType("System.String")))
                'dtTable.Columns.Add(New DataColumn("link", Type.GetType("System.String")))

                Dim dtRow As DataRow = dtTable.NewRow


                dtRow("name") = fUser1.name
                dtRow("id") = fUser1.id
                dtRow("picture") = fUser1.picture.data.url
                dtRow("access_token") = Session("FacebookAccessToken")
                'dtRow("link") = fUser1.link

                dtTable.Rows.Add(dtRow)



                For Each item As FanPage.m_data In fPage1.data
                    If Not item.access_token Is Nothing Then
                        If Not item.picture Is Nothing Then
                            Dim dtRow1 As DataRow = dtTable.NewRow
                            dtRow1("name") = item.name.ToString
                            dtRow1("id") = item.id.ToString
                            dtRow1("picture") = item.picture.data.url.ToString
                            dtRow1("access_token") = item.access_token.ToString
                            'dtRow1("link") = item.link.ToString

                            dtTable.Rows.Add(dtRow1)
                        End If
                    End If
                Next
                dtTable.TableName = "fanpages"
                Dim dv As DataView = New DataView(dtTable)
                dv.Sort = "name"

                If dv.Count > 0 Then
                    dstAutoPostFanPages.DataSource = dv
                    dstAutoPostFanPages.DataBind()
                    plcAutoData.Visible = True
                    plcNoAutoData.Visible = False
                    plcAutoError.Visible = False
                Else
                    dstAutoPostFanPages.DataSource = Nothing
                    dstAutoPostFanPages.DataBind()
                    plcAutoData.Visible = False
                    plcNoAutoData.Visible = True
                    plcAutoError.Visible = False
                End If
            End If
            'Dim dtTable As New DataTable
            'dtTable.Columns.Add(New DataColumn("name", Type.GetType("System.String")))
            'dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.String")))
            'dtTable.Columns.Add(New DataColumn("picture", Type.GetType("System.String")))
            'dtTable.Columns.Add(New DataColumn("access_token", Type.GetType("System.String")))
            'dtTable.Columns.Add(New DataColumn("link", Type.GetType("System.String")))

            'Dim dtRow As DataRow = dtTable.NewRow


            'dtRow("name") = fUser1.name
            'dtRow("id") = fUser1.id
            'dtRow("picture") = fUser1.picture.data.url
            'dtRow("access_token") = Session("FacebookAccessToken")
            'dtRow("link") = fUser1.link
            'dtTable.Rows.Add(dtRow)


            'For Each item As FanPage.m_data In fPage1.data

            '    If Not item.access_token Is Nothing Then
            '        Dim dtRow1 As DataRow = dtTable.NewRow
            '        dtRow1("name") = item.name.ToString
            '        dtRow1("id") = item.id.ToString
            '        dtRow1("picture") = item.picture.data.url.ToString
            '        dtRow1("access_token") = item.access_token.ToString
            '        dtRow1("link") = item.link.ToString
            '        dtTable.Rows.Add(dtRow1)
            '    End If
            'Next

            'dtTable.TableName = "fanpages1"
            'Dim dv As DataView = New DataView(dtTable)
            'dv.Sort = "name"

            'If dv.Count > 0 Then
            '    dstAutoPostFanPages.DataSource = dv
            '    dstAutoPostFanPages.DataBind()
            '    plcAutoData.Visible = True
            '    plcNoAutoData.Visible = False
            'Else
            '    dstAutoPostFanPages.DataSource = Nothing
            '    dstAutoPostFanPages.DataBind()
            '    plcAutoData.Visible = False
            '    plcNoAutoData.Visible = True
            'End If

            'If Session("FanPageIDs") IsNot Nothing Then
            '    Dim forrentfanpages As New List(Of String)
            '    forrentfanpages = Session("FanPageIDs")

            '    For Each item123 As DataListItem In dstAutoPostFanPages.Items
            '        Dim myCheckBox As HtmlInputCheckBox
            '        Dim HiddenID As New HtmlInputHidden
            '        Dim HiddenName As New HtmlInputHidden
            '        Dim HiddenLink As New HtmlInputHidden
            '        Dim NonFanPageTable As New HtmlTable
            '        NonFanPageTable = CType(item123.FindControl("NonFanPage"), HtmlTable)
            '        myCheckBox = CType(item123.FindControl("autopostchkPage"), HtmlInputCheckBox)
            '        HiddenID = CType(item123.FindControl("hdnAutoPostPageId"), HtmlInputHidden)
            '        HiddenName = CType(item123.FindControl("hdnAutoPostPageName"), HtmlInputHidden)
            '        HiddenLink = CType(item123.FindControl("hdnAutoPostLink"), HtmlInputHidden)
            '        'Response.Write("Hidden Id : " & HiddenID.Value & "<br/>")
            '        Dim strLink As String = CStr(HiddenLink.Value)
            '        'Response.Write("intFanPageId : " & intFanPageId & "<br/>")
            '        For j As Integer = 0 To forrentfanpages.Count - 1
            '            If strLink = forrentfanpages.Item(j).ToString Then
            '                NonFanPageTable.Visible = True
            '                Exit For
            '            Else
            '                NonFanPageTable.Visible = False
            '            End If
            '        Next
            '    Next
            'End If
        Catch ex As Exception
            plcAutoData.Visible = False
            plcNoAutoData.Visible = False
            plcAutoError.Visible = True
        End Try
    End Sub
#End Region

    Sub BindDraftData(ByVal id As Integer)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim objEditDrafts As New BALSchedulePost
                objEditDrafts.FBUserId = Session("FacebookUserId")
                objEditDrafts.TSMAUserId = Session("SiteUserId")
                Dim ds As DataSet = objEditDrafts.GetDraftsById(id)
                If ds.Tables(0).Rows.Count > 0 Then
                    txtMessage.Value = Replace(ds.Tables(0).Rows(0).Item("sm_Message"), "<br>", Chr(10))
                    txtVideoMessage.Value = Replace(ds.Tables(0).Rows(0).Item("sm_Message"), "<br>", Chr(10))
                    txtLinkMessage.Value = Replace(ds.Tables(0).Rows(0).Item("sm_Message"), "<br>", Chr(10))
                    If ds.Tables(0).Rows(0).Item("sm_image") <> "" Then
                        imgPhoto.Src = ConfigurationManager.AppSettings("AppPath") & "content/uploads/images/" & ds.Tables(0).Rows(0).Item("sm_image")
                        hdnImage1.Value = ds.Tables(0).Rows(0).Item("sm_image")
                        hdnImageChange.Value = ConfigurationManager.AppSettings("AppPath") & "content/uploads/images/" & ds.Tables(0).Rows(0).Item("sm_image")
                        'ElseIf ds.Tables(0).Rows(0).Item("sm_Video") <> "" Then
                        '    lblVideoText.Text = ds.Tables(0).Rows(0).Item("sm_Video")
                        'Else
                        '    lblVideoText.Text = ""
                    End If
                    txtActivationDate.Value = ds.Tables(0).Rows(0).Item("sm_ScheduleDate")
                    selActivationHour.Value = ds.Tables(0).Rows(0).Item("sm_ScheduleHour")
                    selActivationMinute.Value = ds.Tables(0).Rows(0).Item("sm_ScheduleMinute")
                    selAMPM.Value = ds.Tables(0).Rows(0).Item("sm_ScheduleAMPM")
                    ddlTimeZone.SelectedValue = ds.Tables(0).Rows(0).Item("sm_ScheduleTimeZone")
                    txtvideo.Value = ds.Tables(0).Rows(0).Item("sm_VideoLink")
                End If
                If ds.Tables(1).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                        For Each item As DataListItem In dstFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            Dim HiddenID As HtmlInputHidden
                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                            HiddenID = CType(item.FindControl("hdnPageId"), HtmlInputHidden)
                            Dim str As String = CStr(HiddenID.Value)
                            If str = ds.Tables(1).Rows(i).Item("sp_FBPageId").ToString Then
                                myCheckBox.Checked = True
                            End If
                        Next
                    Next
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If

        Catch ex As Exception
            'ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
    End Sub
    Sub BindSentItemData(ByVal id As Integer)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim objBAL As New BALSchedulePost
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.TSMAUserId = Session("SiteUserId")
                Dim ds As DataSet = objBAL.GetSentItemById(id)
                If ds.Tables(0).Rows.Count > 0 Then
                    txtMessage.Value = Replace(ds.Tables(0).Rows(0).Item("sm_Message"), "<br>", Chr(10))
                    txtVideoMessage.Value = Replace(ds.Tables(0).Rows(0).Item("sm_Message"), "<br>", Chr(10))
                    txtLinkMessage.Value = Replace(ds.Tables(0).Rows(0).Item("sm_Message"), "<br>", Chr(10))
                    If ds.Tables(0).Rows(0).Item("sm_image") <> "" Then
                        imgPhoto.Src = ConfigurationManager.AppSettings("AppPath") & "content/uploads/images/" & ds.Tables(0).Rows(0).Item("sm_image")
                        hdnImage1.Value = ds.Tables(0).Rows(0).Item("sm_image")
                        hdnImageChange.Value = ConfigurationManager.AppSettings("AppPath") & "content/uploads/images/" & ds.Tables(0).Rows(0).Item("sm_image")
                        'ElseIf ds.Tables(0).Rows(0).Item("sm_Video") <> "" Then
                        '    lblVideoText.Text = ds.Tables(0).Rows(0).Item("sm_Video")
                        'Else
                        '    lblVideoText.Text = ""
                    End If
                    txtActivationDate.Value = ds.Tables(0).Rows(0).Item("sm_ScheduleDate")
                    selActivationHour.Value = ds.Tables(0).Rows(0).Item("sm_ScheduleHour")
                    selActivationMinute.Value = ds.Tables(0).Rows(0).Item("sm_ScheduleMinute")
                    selAMPM.Value = ds.Tables(0).Rows(0).Item("sm_ScheduleAMPM")
                    ddlTimeZone.SelectedValue = ds.Tables(0).Rows(0).Item("sm_ScheduleTimeZone")
                    txtvideo.Value = ds.Tables(0).Rows(0).Item("sm_VideoLink")
                End If
                If ds.Tables(1).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                        For Each item As DataListItem In dstFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            Dim HiddenID As HtmlInputHidden
                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                            HiddenID = CType(item.FindControl("hdnPageId"), HtmlInputHidden)
                            Dim str As String = CStr(HiddenID.Value)
                            If str = ds.Tables(1).Rows(i).Item("sp_FBPageId").ToString Then
                                myCheckBox.Checked = True
                            End If
                        Next
                    Next
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            'ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
    End Sub
    Sub BindScheduledPostData(ByVal id As Integer)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim objBAL As New BALSchedulePost
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.TSMAUserId = Session("SiteUserId")

                Dim ds As DataSet = objBAL.GetScheduledPostById(id)
                If ds.Tables(0).Rows.Count > 0 Then
                    txtMessage.Value = Replace(ds.Tables(0).Rows(0).Item("sm_Message"), "<br>", Chr(10))
                    txtVideoMessage.Value = Replace(ds.Tables(0).Rows(0).Item("sm_Message"), "<br>", Chr(10))
                    txtLinkMessage.Value = Replace(ds.Tables(0).Rows(0).Item("sm_Message"), "<br>", Chr(10))
                    If ds.Tables(0).Rows(0).Item("sm_image") <> "" Then
                        imgPhoto.Src = ConfigurationManager.AppSettings("AppPath") & "content/uploads/images/" & ds.Tables(0).Rows(0).Item("sm_image")
                        hdnImage1.Value = ds.Tables(0).Rows(0).Item("sm_image")
                        hdnImageChange.Value = ConfigurationManager.AppSettings("AppPath") & "content/uploads/images/" & ds.Tables(0).Rows(0).Item("sm_image")
                        'ElseIf ds.Tables(0).Rows(0).Item("sm_Video") <> "" Then
                        '    lblVideoText.Text = ds.Tables(0).Rows(0).Item("sm_Video")
                        'Else
                        '    lblVideoText.Text = ""
                    End If

                    Dim strDate As DateTime
                    Dim strDateOriginal As DateTime = ds.Tables(0).Rows(0).Item("sm_ScheduleDate") & " " & ds.Tables(0).Rows(0).Item("sm_ScheduleHour") & ":" & ds.Tables(0).Rows(0).Item("sm_ScheduleMinute") & " " & ds.Tables(0).Rows(0).Item("sm_ScheduleAMPM")
                    If ds.Tables(0).Rows(0).Item("sm_ScheduleTimeZone") <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                        Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), ds.Tables(0).Rows(0).Item("sm_ScheduleTimeZone")).ToString()
                        strDate = String.Format("{0:dd MMM yyyy hh:mm tt}", strConvertedDate)
                    Else
                        strDate = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
                    End If
                    txtActivationDate.Value = strDate.Date
                    selActivationHour.Value = Integer.Parse(strDate.ToString("hh")).ToString()
                    selActivationMinute.Value = strDate.Minute
                    selAMPM.Value = strDate.ToString("tt")
                    ddlTimeZone.SelectedValue = ds.Tables(0).Rows(0).Item("sm_ScheduleTimeZone")
                    txtvideo.Value = ds.Tables(0).Rows(0).Item("sm_VideoLink")

                End If
                If ds.Tables(1).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                        For Each item As DataListItem In dstFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            Dim HiddenID As HtmlInputHidden
                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                            HiddenID = CType(item.FindControl("hdnPageId"), HtmlInputHidden)
                            Dim str As String = CStr(HiddenID.Value)
                            If str = ds.Tables(1).Rows(i).Item("sp_FBPageId").ToString Then
                                myCheckBox.Checked = True
                            End If
                        Next
                    Next
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            'ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
    End Sub

    Sub BindAllDrafts()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                ltrDrafts.Text = ""
                Dim ds As New DataSet
                Dim objBAL As New BALSchedulePost
                objBAL.PageIndex = CInt(ViewState("CurrentPageIndex"))
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.TSMAUserId = Session("SiteUserId")
                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                ds = objBAL.GetAllDrafts
                If ds.Tables(0).Rows.Count > 0 Then
                    dtlDrafts.DataSource() = ds.Tables(0)
                    dtlDrafts.DataBind()
                Else
                    dtlDrafts.DataSource() = Nothing
                    dtlDrafts.DataBind()
                    ltrDrafts.Text = "No Drafts Found"
                End If
                If ds.Tables(1).Rows.Count > 0 Then
                    ViewState("TotalPage") = ds.Tables(1).Rows(0).Item("Totalpage").ToString
                    ViewState("TotalRecords") = ds.Tables(1).Rows(0).Item("TotalRec").ToString
                End If

                If ds.Tables(0).Rows.Count > 0 Then
                    ltrDraftTotal.Text = " (" & ds.Tables(1).Rows(0).Item("TotalRec").ToString & ")"
                Else
                    ltrDraftTotal.Text = " (0)"
                End If
                phPaging1.Controls.Clear()
                GenreateControls()
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If

        Catch ex As Exception
            ltrDrafts.Text = "Error :" & ex.Message()
        End Try
    End Sub
    Sub BindAllSentItems()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                'ltrSentItems.Text = ""
                Dim ds As New DataSet
                Dim objBAL As New BALSchedulePost
                objBAL.PageIndex = CInt(ViewState("CurrentPageIndexSent"))
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.TSMAUserId = Session("SiteUserId")
                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 

                ds = objBAL.GetAllSentItems
                If ds.Tables(0).Rows.Count > 0 Then
                    dtlSentItems.DataSource() = ds.Tables(0)
                    dtlSentItems.DataBind()
                Else
                    dtlSentItems.DataSource() = Nothing
                    dtlSentItems.DataBind()
                    ltrSentItems.Text = "No Sent Items Found"
                End If
                If ds.Tables(1).Rows.Count > 0 Then
                    ViewState("TotalPageSent") = ds.Tables(1).Rows(0).Item("Totalpage").ToString
                    ViewState("TotalRecordsSent") = ds.Tables(1).Rows(0).Item("TotalRec").ToString
                End If
                If ds.Tables(0).Rows.Count > 0 Then
                    ltrSentTotal.Text = " (" & ds.Tables(1).Rows(0).Item("TotalRec").ToString & ")"
                Else
                    ltrSentTotal.Text = " (0)"
                End If
                phPagingSent.Controls.Clear()
                GenreateControlsSent()
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            ltrSentItems.Text = "Error :" & ex.Message()
        End Try
    End Sub
    Sub BindAllScheduledPosts()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                ltrScheduledPosts.Text = ""
                Dim ds As New DataSet
                Dim objBAL As New BALSchedulePost
                objBAL.PageIndex = CInt(ViewState("CurrentPageIndexScheduled"))
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.TSMAUserId = Session("SiteUserId")
                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                ds = objBAL.GetAllScheduledPosts
                If ds.Tables(0).Rows.Count > 0 Then
                    dtlScheduledPosts.DataSource() = ds.Tables(0)
                    dtlScheduledPosts.DataBind()
                Else
                    dtlScheduledPosts.DataSource() = Nothing
                    dtlScheduledPosts.DataBind()

                    ltrScheduledPosts.Text = "No Scheduled Posts Found"
                End If
                If ds.Tables(1).Rows.Count > 0 Then
                    ViewState("TotalPageScheduled") = ds.Tables(1).Rows(0).Item("Totalpage").ToString
                    ViewState("TotalRecordsScheduled") = ds.Tables(1).Rows(0).Item("TotalRec").ToString
                End If
                If ds.Tables(0).Rows.Count > 0 Then
                    ltrSchedluledTotal.Text = " (" & ds.Tables(1).Rows(0).Item("TotalRec").ToString & ")"
                Else
                    ltrSchedluledTotal.Text = "(0)"
                End If

                phPagingScheduled.Controls.Clear()
                GenreateControlsScheduled()
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            ltrScheduledPosts.Text = "Error :" & ex.Message()
        End Try
    End Sub

    Function BindDraftFanPages(ByVal id As Integer)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BALSchedulePost
                objBAL.DraftId = id
                ds = objBAL.GetFanPagesByDrafts
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0)
                Else
                    Return "No FanPages Selected"
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error :" & ex.Message()
        End Try
    End Function
    Function BindSentItemsFanPages(ByVal id As Integer)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BALSchedulePost
                objBAL.SentItemId = id
                ds = objBAL.GetFanPagesBySentItem
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0)
                Else
                    Return "No Business Page Selected"
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error :" & ex.Message()
        End Try
    End Function
    Function BindScheduledPostsFanPages(ByVal id As Integer)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BALSchedulePost
                objBAL.ScheduledPostID = id
                ds = objBAL.GetFanPagesByScheduledPost
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0)
                Else
                    Return "No Business Page Selected"
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error :" & ex.Message()
        End Try
    End Function




    Sub DeleteByID(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                If sender.CommandName <> "" Then
                    Dim objDel As New BALSchedulePost
                    objDel.DeleteByID(CInt(sender.CommandName))
                    'lblMessage.Text = "Draft deleted Successfully"
                    BindAllDrafts()
                    BindAllSentItems()
                    BindAllScheduledPosts()
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            'ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
    End Sub

#Region "Custom Paging AutoPost"

    Sub GenerateAutoPostControls()

        Dim objlink As LinkButton
        Dim objlabel As Label
        Dim intStartRecord, intEndRecord As Integer
        If (ViewState("TotalPageAutoPost") > 1) Then
            Dim i As Integer
            ' phPaging.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            phPagingAutoPost.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            If (ViewState("TotalPageAutoPost") > 1 And ViewState("CurrentAutoPostPageIndex") <> 1) Then
                ''''Generating previous button''
                objlink = New LinkButton()
                objlink.ID = "PrevAutoPost"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageAutoPost_Previous
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Prev1AutoPost"
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageAutoPost_Previous
                phPagingAutoPost.Controls.Add(objlink)
                phPagingAutoPost.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''
            End If
            If (ViewState("CurrentAutoPostPageIndex") <= 7) Then
                intStartRecord = 1
                intEndRecord = 8
                If (ViewState("TotalPageAutoPost") > 8) Then
                    intEndRecord = 8
                Else
                    intEndRecord = ViewState("TotalPageAutoPost")
                End If
            Else
                If ((ViewState("CurrentAutoPostPageIndex") / 8).ToString.IndexOf(".") > 0) Then
                    intStartRecord = (ViewState("CurrentAutoPostPageIndex") / 8).ToString.Substring(0, (ViewState("CurrentAutoPostPageIndex") / 8).ToString.IndexOf(".")) * 8
                Else
                    intStartRecord = (8 * CInt((ViewState("CurrentAutoPostPageIndex") / 8)))
                End If
                If (intStartRecord > ViewState("TotalPageAutoPost")) Then
                    intStartRecord = (8 * (CInt((ViewState("CurrentAutoPostPageIndex") / 8)) - 1))
                End If
                If (intStartRecord + 8 < ViewState("TotalPageAutoPost")) Then
                    intEndRecord = intStartRecord + 8
                Else
                    intEndRecord = ViewState("TotalPageAutoPost")
                End If
            End If

            If (ViewState("TotalPageAutoPost") > 1 And ViewState("CurrentAutoPostPageIndex") < ViewState("TotalPageAutoPost")) Then
                ''''Generating next button '
                objlink = New LinkButton()
                objlink.ID = "NextAutoPost"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageAutoPost_Next
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Next1AutoPost"
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageAutoPost_Next
                phPagingAutoPost.Controls.Add(objlink)
                phPagingAutoPost.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''

            End If
        End If
        showHideAutoPostPrevNext()
    End Sub
    Private Sub lnkPageAutoPost_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CInt(CType(sender, LinkButton).ID) > ViewState("TotalRecordsAutoPost")) Then
            ViewState("CurrentAutoPostPageIndex") = CType(sender, LinkButton).ID - ViewState("TotalRecordsAutoPost")
        Else
            ViewState("CurrentAutoPostPageIndex") = CType(sender, LinkButton).ID
        End If
        BindAllAutoPost()

    End Sub
    Private Sub lnkPageAutoPost_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentAutoPostPageIndex") <> 1) Then
            ViewState("CurrentAutoPostPageIndex") = ViewState("CurrentAutoPostPageIndex") - 1
        End If
        BindAllAutoPost()

    End Sub
    Private Sub lnkPageAutoPost_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentAutoPostPageIndex") < ViewState("TotalPageAutoPost")) Then
            ViewState("CurrentAutoPostPageIndex") = ViewState("CurrentAutoPostPageIndex") + 1
        Else
            ViewState("CurrentAutoPostPageIndex") = ViewState("CurrentAutoPostPageIndex")
        End If
        BindAllAutoPost()

    End Sub

    Sub showHideAutoPostPrevNext()
        If (ViewState("CurrentAutoPostPageIndex") = ViewState("TotalPageAutoPost")) Then
            If (Not IsNothing(form1.FindControl("NextAutoPost"))) Then
                form1.FindControl("NextAutoPost").Visible = False
                form1.FindControl("Next1AutoPost").Visible = False
            End If
        Else
            If (Not IsNothing(form1.FindControl("NextAutoPost"))) Then
                form1.FindControl("NextAutoPost").Visible = True
                form1.FindControl("Next1AutoPost").Visible = True
            End If
        End If
    End Sub
#End Region


#Region "Custom Paging Sent AutoPost"

    Sub GenerateSentAutoPostControls()

        Dim objlink As LinkButton
        Dim objlabel As Label
        Dim intStartRecord, intEndRecord As Integer
        If (ViewState("TotalPageSentAutoPost") > 1) Then
            Dim i As Integer
            ' phPaging.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            phPagingSentAutoPost.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            If (ViewState("TotalPageSentAutoPost") > 1 And ViewState("CurrentSentAutoPostPageIndex") <> 1) Then
                ''''Generating previous button''
                objlink = New LinkButton()
                objlink.ID = "PrevSentAutoPost"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageSentAutoPost_Previous
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Prev1SentAutoPost"
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageSentAutoPost_Previous
                phPagingSentAutoPost.Controls.Add(objlink)
                phPagingSentAutoPost.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''
            End If
            If (ViewState("CurrentSentAutoPostPageIndex") <= 7) Then
                intStartRecord = 1
                intEndRecord = 8
                If (ViewState("TotalPageSentAutoPost") > 8) Then
                    intEndRecord = 8
                Else
                    intEndRecord = ViewState("TotalPageSentAutoPost")
                End If
            Else
                If ((ViewState("CurrentSentAutoPostPageIndex") / 8).ToString.IndexOf(".") > 0) Then
                    intStartRecord = (ViewState("CurrentSentAutoPostPageIndex") / 8).ToString.Substring(0, (ViewState("CurrentSentAutoPostPageIndex") / 8).ToString.IndexOf(".")) * 8
                Else
                    intStartRecord = (8 * CInt((ViewState("CurrentSentAutoPostPageIndex") / 8)))
                End If
                If (intStartRecord > ViewState("TotalPageSentAutoPost")) Then
                    intStartRecord = (8 * (CInt((ViewState("CurrentSentAutoPostPageIndex") / 8)) - 1))
                End If
                If (intStartRecord + 8 < ViewState("TotalPageSentAutoPost")) Then
                    intEndRecord = intStartRecord + 8
                Else
                    intEndRecord = ViewState("TotalPageSentAutoPost")
                End If
            End If

            If (ViewState("TotalPageSentAutoPost") > 1 And ViewState("CurrentSentAutoPostPageIndex") < ViewState("TotalPageSentAutoPost")) Then
                ''''Generating next button '
                objlink = New LinkButton()
                objlink.ID = "NextSentAutoPost"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageSentAutoPost_Next
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Next1SentAutoPost"
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageSentAutoPost_Next
                phPagingSentAutoPost.Controls.Add(objlink)
                phPagingSentAutoPost.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''

            End If
        End If
        showHideSentAutoPostPrevNext()
    End Sub
    Private Sub lnkPageSentAutoPost_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CInt(CType(sender, LinkButton).ID) > ViewState("TotalRecordsSentAutoPost")) Then
            ViewState("CurrentSentAutoPostPageIndex") = CType(sender, LinkButton).ID - ViewState("TotalRecordsSentAutoPost")
        Else
            ViewState("CurrentSentAutoPostPageIndex") = CType(sender, LinkButton).ID
        End If
        BindAllSentAutoPost()

    End Sub
    Private Sub lnkPageSentAutoPost_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentSentAutoPostPageIndex") <> 1) Then
            ViewState("CurrentSentAutoPostPageIndex") = ViewState("CurrentSentAutoPostPageIndex") - 1
        End If
        BindAllSentAutoPost()

    End Sub
    Private Sub lnkPageSentAutoPost_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentSentAutoPostPageIndex") < ViewState("TotalPageSentAutoPost")) Then
            ViewState("CurrentSentAutoPostPageIndex") = ViewState("CurrentSentAutoPostPageIndex") + 1
        Else
            ViewState("CurrentSentAutoPostPageIndex") = ViewState("CurrentSentAutoPostPageIndex")
        End If
        BindAllSentAutoPost()

    End Sub

    Sub showHideSentAutoPostPrevNext()
        If (ViewState("CurrentSentAutoPostPageIndex") = ViewState("TotalPageSentAutoPost")) Then
            If (Not IsNothing(form1.FindControl("NextSentAutoPost"))) Then
                form1.FindControl("NextSentAutoPost").Visible = False
                form1.FindControl("Next1SentAutoPost").Visible = False
            End If
        Else
            If (Not IsNothing(form1.FindControl("NextSentAutoPost"))) Then
                form1.FindControl("NextSentAutoPost").Visible = True
                form1.FindControl("Next1SentAutoPost").Visible = True
            End If
        End If
    End Sub
#End Region


#Region "Custom Paging Drafts"

    Sub GenreateControls()

        Dim objlink As LinkButton
        Dim objlabel As Label
        Dim intStartRecord, intEndRecord As Integer
        If (ViewState("TotalPage") > 1) Then
            Dim i As Integer
            ' phPaging.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            phPaging1.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            If (ViewState("TotalPage") > 1 And ViewState("CurrentPageIndex") <> 1) Then
                ''''Generating previous button''
                objlink = New LinkButton()
                objlink.ID = "Prev"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPage_Previous
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Prev1"
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPage_Previous
                phPaging1.Controls.Add(objlink)
                phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''
            End If
            If (ViewState("CurrentPageIndex") <= 7) Then
                intStartRecord = 1
                intEndRecord = 8
                If (ViewState("TotalPage") > 8) Then
                    intEndRecord = 8
                Else
                    intEndRecord = ViewState("TotalPage")
                End If
            Else
                If ((ViewState("CurrentPageIndex") / 8).ToString.IndexOf(".") > 0) Then
                    intStartRecord = (ViewState("CurrentPageIndex") / 8).ToString.Substring(0, (ViewState("CurrentPageIndex") / 8).ToString.IndexOf(".")) * 8
                Else
                    intStartRecord = (8 * CInt((ViewState("CurrentPageIndex") / 8)))
                End If
                If (intStartRecord > ViewState("TotalPage")) Then
                    intStartRecord = (8 * (CInt((ViewState("CurrentPageIndex") / 8)) - 1))
                End If
                If (intStartRecord + 8 < ViewState("TotalPage")) Then
                    intEndRecord = intStartRecord + 8
                Else
                    intEndRecord = ViewState("TotalPage")
                End If
            End If
            'For i = intStartRecord To intEndRecord
            '    If (ViewState("CurrentPageIndex") <> i) Then
            '        objlink = New LinkButton()
            '        objlink.ID = i
            '        objlink.Text = i
            '        AddHandler objlink.Click, AddressOf lnkPage_click
            '        'phPaging.Controls.Add(objlink)
            '        'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))
            '        ''''''------------------''''''
            '        objlink = New LinkButton()
            '        objlink.ID = i + ViewState("TotalRecords")
            '        objlink.Text = i
            '        AddHandler objlink.Click, AddressOf lnkPage_click
            '        phPaging1.Controls.Add(objlink)
            '        phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))
            '    Else
            '        objlabel = New Label()
            '        objlabel.ID = i
            '        objlabel.Text = i
            '        'phPaging.Controls.Add(objlabel)
            '        'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))

            '        ''''''------------------''''''
            '        objlabel = New Label()
            '        objlabel.ID = i + ViewState("TotalRecords")
            '        objlabel.Text = i
            '        objlabel.CssClass = "curpage"
            '        phPaging1.Controls.Add(objlabel)
            '        phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))
            '    End If
            'Next
            If (ViewState("TotalPage") > 1 And ViewState("CurrentPageIndex") < ViewState("TotalPage")) Then
                ''''Generating next button '
                objlink = New LinkButton()
                objlink.ID = "Next"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPage_Next
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Next1"
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPage_Next
                phPaging1.Controls.Add(objlink)
                phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''

            End If
        End If
        showHidePrevNetxt()
    End Sub
    Private Sub lnkPage_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CInt(CType(sender, LinkButton).ID) > ViewState("TotalRecords")) Then
            ViewState("CurrentPageIndex") = CType(sender, LinkButton).ID - ViewState("TotalRecords")
        Else
            ViewState("CurrentPageIndex") = CType(sender, LinkButton).ID
        End If
        BindAllDrafts()

    End Sub
    Private Sub lnkPage_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndex") <> 1) Then
            ViewState("CurrentPageIndex") = ViewState("CurrentPageIndex") - 1
        End If
        BindAllDrafts()

    End Sub
    Private Sub lnkPage_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndex") < ViewState("TotalPage")) Then
            ViewState("CurrentPageIndex") = ViewState("CurrentPageIndex") + 1
        Else
            ViewState("CurrentPageIndex") = ViewState("CurrentPageIndex")
        End If
        BindAllDrafts()

    End Sub

    Sub showHidePrevNetxt()
        If (ViewState("CurrentPageIndex") = ViewState("TotalPage")) Then
            If (Not IsNothing(form1.FindControl("Next"))) Then
                form1.FindControl("Next").Visible = False
                form1.FindControl("Next1").Visible = False
            End If
        Else
            If (Not IsNothing(form1.FindControl("Next"))) Then
                form1.FindControl("Next").Visible = True
                form1.FindControl("Next1").Visible = True
            End If
        End If
    End Sub
#End Region

#Region "Custom Paging Sent Items"

    Sub GenreateControlsSent()
        Dim objlink As LinkButton
        Dim objlabel As Label
        Dim intStartRecord, intEndRecord As Integer
        If (ViewState("TotalPageSent") > 1) Then
            Dim i As Integer
            ' phPaging.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            phPagingSent.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            If (ViewState("TotalPageSent") > 1 And ViewState("CurrentPageIndexSent") <> 1) Then
                ''''Generating previous button''
                objlink = New LinkButton()
                objlink.ID = "PrevSent"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageSent_Previous
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Prev1Sent"
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageSent_Previous
                phPagingSent.Controls.Add(objlink)
                phPagingSent.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''
            End If
            If (ViewState("CurrentPageIndexSent") <= 7) Then
                intStartRecord = 1
                intEndRecord = 8
                If (ViewState("TotalPageSent") > 8) Then
                    intEndRecord = 8
                Else
                    intEndRecord = ViewState("TotalPageSent")
                End If
            Else
                If ((ViewState("CurrentPageIndexSent") / 8).ToString.IndexOf(".") > 0) Then
                    intStartRecord = (ViewState("CurrentPageIndexSent") / 8).ToString.Substring(0, (ViewState("CurrentPageIndexSent") / 8).ToString.IndexOf(".")) * 8
                Else
                    intStartRecord = (8 * CInt((ViewState("CurrentPageIndexSent") / 8)))
                End If
                If (intStartRecord > ViewState("TotalPageSent")) Then
                    intStartRecord = (8 * (CInt((ViewState("CurrentPageIndexSent") / 8)) - 1))
                End If
                If (intStartRecord + 8 < ViewState("TotalPageSent")) Then
                    intEndRecord = intStartRecord + 8
                Else
                    intEndRecord = ViewState("TotalPageSent")
                End If
            End If
            'For i = intStartRecord To intEndRecord
            '    If (ViewState("CurrentPageIndexSent") <> i) Then
            '        objlink = New LinkButton()
            '        objlink.ID = i
            '        objlink.Text = i
            '        AddHandler objlink.Click, AddressOf lnkPageSent_click
            '        'phPaging.Controls.Add(objlink)
            '        'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))
            '        ''''''------------------''''''
            '        objlink = New LinkButton()
            '        objlink.ID = i + ViewState("TotalRecordsSent")
            '        objlink.Text = i
            '        AddHandler objlink.Click, AddressOf lnkPageSent_click
            '        phPagingSent.Controls.Add(objlink)
            '        phPagingSent.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))
            '    Else
            '        objlabel = New Label()
            '        objlabel.ID = i
            '        objlabel.Text = i
            '        'phPaging.Controls.Add(objlabel)
            '        'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))

            '        ''''''------------------''''''
            '        objlabel = New Label()
            '        objlabel.ID = i + ViewState("TotalRecordsSent")
            '        objlabel.Text = i
            '        objlabel.CssClass = "curpage"
            '        phPagingSent.Controls.Add(objlabel)
            '        phPagingSent.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))
            '    End If
            'Next
            If (ViewState("TotalPageSent") > 1 And ViewState("CurrentPageIndexSent") < ViewState("TotalPageSent")) Then
                ''''Generating next button '
                objlink = New LinkButton()
                objlink.ID = "NextSent"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageSent_Next
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Next1Sent"
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageSent_Next
                phPagingSent.Controls.Add(objlink)
                phPagingSent.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''

            End If
        End If
        showHidePrevNetxtSent()
    End Sub
    Private Sub lnkPageSent_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CInt(CType(sender, LinkButton).ID) > ViewState("TotalRecordsSent")) Then
            ViewState("CurrentPageIndexSent") = CType(sender, LinkButton).ID - ViewState("TotalRecordsSent")
        Else
            ViewState("CurrentPageIndexSent") = CType(sender, LinkButton).ID
        End If
        BindAllSentItems()

    End Sub
    Private Sub lnkPageSent_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndexSent") <> 1) Then
            ViewState("CurrentPageIndexSent") = ViewState("CurrentPageIndexSent") - 1
        End If
        BindAllSentItems()

    End Sub
    Private Sub lnkPageSent_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndexSent") < ViewState("TotalPageSent")) Then
            ViewState("CurrentPageIndexSent") = ViewState("CurrentPageIndexSent") + 1
        Else
            ViewState("CurrentPageIndexSent") = ViewState("CurrentPageIndexSent")
        End If
        BindAllSentItems()

    End Sub

    Sub showHidePrevNetxtSent()
        If (ViewState("CurrentPageIndexSent") = ViewState("TotalPageSent")) Then
            If (Not IsNothing(form1.FindControl("NextSent"))) Then
                form1.FindControl("NextSent").Visible = False
                form1.FindControl("Next1Sent").Visible = False
            End If
        Else
            If (Not IsNothing(form1.FindControl("NextSent"))) Then
                form1.FindControl("NextSent").Visible = True
                form1.FindControl("Next1Sent").Visible = True
            End If
        End If
    End Sub
#End Region

#Region "Custom Paging Scheduled Posts"

    Sub GenreateControlsScheduled()
        Dim objlink As LinkButton
        Dim objlabel As Label
        Dim intStartRecord, intEndRecord As Integer
        If (ViewState("TotalPageScheduled") > 1) Then
            Dim i As Integer
            ' phPaging.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            phPagingScheduled.Controls.Add(New LiteralControl("Pages:&nbsp;&nbsp;"))
            If (ViewState("TotalPageScheduled") > 1 And ViewState("CurrentPageIndexScheduled") <> 1) Then
                ''''Generating previous button''
                objlink = New LinkButton()
                objlink.ID = "PrevScheduled"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageScheduled_Previous
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Prev1Scheduled"
                objlink.Text = "<img src=""../Content/images/previous-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageScheduled_Previous
                phPagingScheduled.Controls.Add(objlink)
                phPagingScheduled.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''
            End If
            If (ViewState("CurrentPageIndexScheduled") <= 7) Then
                intStartRecord = 1
                intEndRecord = 8
                If (ViewState("TotalPageScheduled") > 8) Then
                    intEndRecord = 8
                Else
                    intEndRecord = ViewState("TotalPageScheduled")
                End If
            Else
                If ((ViewState("CurrentPageIndexScheduled") / 8).ToString.IndexOf(".") > 0) Then
                    intStartRecord = (ViewState("CurrentPageIndexScheduled") / 8).ToString.Substring(0, (ViewState("CurrentPageIndexScheduled") / 8).ToString.IndexOf(".")) * 8
                Else
                    intStartRecord = (8 * CInt((ViewState("CurrentPageIndexScheduled") / 8)))
                End If
                If (intStartRecord > ViewState("TotalPageScheduled")) Then
                    intStartRecord = (8 * (CInt((ViewState("CurrentPageIndexScheduled") / 8)) - 1))
                End If
                If (intStartRecord + 8 < ViewState("TotalPageScheduled")) Then
                    intEndRecord = intStartRecord + 8
                Else
                    intEndRecord = ViewState("TotalPageScheduled")
                End If
            End If
            'For i = intStartRecord To intEndRecord
            '    If (ViewState("CurrentPageIndexScheduled") <> i) Then
            '        objlink = New LinkButton()
            '        objlink.ID = i
            '        objlink.Text = i
            '        AddHandler objlink.Click, AddressOf lnkPageScheduled_click
            '        'phPaging.Controls.Add(objlink)
            '        'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))
            '        ''''''------------------''''''
            '        objlink = New LinkButton()
            '        objlink.ID = i + ViewState("TotalRecordsScheduled")
            '        objlink.Text = i
            '        AddHandler objlink.Click, AddressOf lnkPageScheduled_click
            '        phPagingScheduled.Controls.Add(objlink)
            '        phPagingScheduled.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))
            '    Else
            '        objlabel = New Label()
            '        objlabel.ID = i
            '        objlabel.Text = i
            '        'phPaging.Controls.Add(objlabel)
            '        'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))

            '        ''''''------------------''''''
            '        objlabel = New Label()
            '        objlabel.ID = i + ViewState("TotalRecordsScheduled")
            '        objlabel.Text = i
            '        objlabel.CssClass = "curpage"
            '        phPagingScheduled.Controls.Add(objlabel)
            '        phPagingScheduled.Controls.Add(New LiteralControl("&nbsp;&nbsp;|&nbsp;&nbsp;"))
            '    End If
            'Next
            If (ViewState("TotalPageScheduled") > 1 And ViewState("CurrentPageIndexScheduled") < ViewState("TotalPageScheduled")) Then
                ''''Generating next button '
                objlink = New LinkButton()
                objlink.ID = "NextScheduled"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageScheduled_Next
                'phPaging.Controls.Add(objlink)
                'phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Next1Scheduled"
                objlink.Text = "<img src=""../Content/images/Next-arrow.gif""  hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPageScheduled_Next
                phPagingScheduled.Controls.Add(objlink)
                phPagingScheduled.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''

            End If
        End If
        showHidePrevNetxtScheduled()
    End Sub
    Private Sub lnkPageScheduled_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CInt(CType(sender, LinkButton).ID) > ViewState("TotalRecordsScheduled")) Then
            ViewState("CurrentPageIndexScheduled") = CType(sender, LinkButton).ID - ViewState("TotalRecordsScheduled")
        Else
            ViewState("CurrentPageIndexScheduled") = CType(sender, LinkButton).ID
        End If
        BindAllScheduledPosts()

    End Sub
    Private Sub lnkPageScheduled_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndexScheduled") <> 1) Then
            ViewState("CurrentPageIndexScheduled") = ViewState("CurrentPageIndexScheduled") - 1
        End If
        BindAllScheduledPosts()

    End Sub
    Private Sub lnkPageScheduled_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndexScheduled") < ViewState("TotalPageScheduled")) Then
            ViewState("CurrentPageIndexScheduled") = ViewState("CurrentPageIndexScheduled") + 1
        Else
            ViewState("CurrentPageIndexScheduled") = ViewState("CurrentPageIndexScheduled")
        End If
        BindAllScheduledPosts()

    End Sub

    Sub showHidePrevNetxtScheduled()
        If (ViewState("CurrentPageIndexScheduled") = ViewState("TotalPageScheduled")) Then
            If (Not IsNothing(form1.FindControl("NextScheduled"))) Then
                form1.FindControl("NextScheduled").Visible = False
                form1.FindControl("Next1Scheduled").Visible = False
            End If
        Else
            If (Not IsNothing(form1.FindControl("NextScheduled"))) Then
                form1.FindControl("NextScheduled").Visible = True
                form1.FindControl("Next1Scheduled").Visible = True
            End If
        End If
    End Sub
#End Region

#Region "Library"
    Sub BindLibraryCategories()
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim ds As DataSet
            objLib.UserId = Session("SiteUserId")
            objLib.FBUserId = Session("FacebookUserId")
            objLib.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
            objLib.IndustryId = 1 ' GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
            ds = objLib.GetLibraryCategories()

            rptAdminLibCat.DataSource = ds.Tables(0)
            rptAdminLibCat.DataBind()

            rptAdminLibCatTitle.DataSource = ds.Tables(0)
            rptAdminLibCatTitle.DataBind()

            rptUserLibCat.DataSource = ds.Tables(1)
            rptUserLibCat.DataBind()

            rptUserLibCatTitle.DataSource = ds.Tables(1)
            rptUserLibCatTitle.DataBind()

            rptLibUserCatList.DataSource = ds.Tables(1)
            rptLibUserCatList.DataBind()
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub
    Function BindAdminLibraries(intCatID As Integer) As DataSet
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim ds As DataSet
            objLib.LibraryCategory = intCatID
            objLib.UserId = -1
            objLib.FBUserId = ""
            objLib.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
            objLib.IndustryId = 1 ' GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
            ds = objLib.GetLIbraries()
            Return ds
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Function
    Function BindUserLibraries(intCatID As Integer) As DataSet
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim ds As DataSet
            objLib.LibraryCategory = intCatID
            objLib.UserId = Session("SiteUserId")
            objLib.FBUserId = Session("FacebookUserId")
            objLib.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
            objLib.IndustryId = 1 ' GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
            ds = objLib.GetLIbraries()
            Return ds
            ClearData()
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Function

    Sub SaveToMyLibrary(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strVideoThumb As String = "", strVideo As String = ""
                Dim strVideoFileNameWithoutExtension As String = ""
                If photo.PostedFile.ContentLength > 0 Then
                    Dim uploadContent As Integer = photo.PostedFile.ContentLength / 1000
                    strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
                    '''''''' When using Video Upload Functionality
                    'If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                    '    strVideoFileNameWithoutExtension = "V-" & String.Format("{0:MMddyyyyhhmmsstt}", Now)
                    '    If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                    '        If strExt <> ".flv" Then
                    '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                    '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                    '            myprocess.StartInfo.UseShellExecute = True
                    '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog.bat")
                    '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                    '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & strExt & " -s -m"
                    '            myprocess.Start()
                    '        Else
                    '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                    '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                    '            myprocess.StartInfo.UseShellExecute = True
                    '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog-flv.bat")
                    '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                    '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & ".flv" & " -s -m"
                    '            myprocess.Start()
                    '        End If
                    '        strVideoThumb = strVideoFileNameWithoutExtension & ".jpg"
                    '        strVideo = strVideoFileNameWithoutExtension & ".flv"
                    '    End If

                    '    Dim photopath As String = Server.MapPath("~/" & "Content/uploads/" & strVideo)
                    '    hdnImage.Value = photopath
                    '    lblVideoText.Visible = True
                    '    imgPhoto.Visible = False
                    '    lblVideoText.Text = hdnImage.Value
                    '    'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                    '    Dim str As String = ""
                    '    lblMessage.Text = "Video Uploaded Successfully"
                    'Else
                    If uploadContent > 10000 Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "ShowErrorPopUp", "OpenDiv();", True)
                        'lblMessage.Text = "you can upload file size of maximum: 1MB "
                        Exit Sub
                    Else
                        If strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png" Then
                            Dim strDate12 As Date = "1/1/1900"
                            strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now())) & strExt
                            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\images\" & strPhoto))
                            Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto)
                            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";SaveAlert('Photo uploaded successfully');", True)
                            'lblMessage.Text = "Photo Uploaded Successfully"
                        Else
                            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";SaveAlert('File must be .jpg or .gif or .png or .jpeg or .tif or .bmp');", True)
                            'lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
                            Exit Sub
                            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
                        End If
                    End If
                ElseIf hdnImage1.Value <> "" Then
                    strPhoto = hdnImage1.Value
                End If
                'End If

                objLib.LibraryCategory = e.CommandArgument
                objLib.UserId = Session("SiteUserId")
                objLib.FBUserId = Session("FacebookUserId")
                objLib.LibCatTitle = txtNewLibCat.Value.Trim
                objLib.Library = txtMessage.Value.Trim.Replace(Chr(10), "<br>")
                objLib.LibImage = strPhoto
                objLib.LibVideo = If(txtvideo.Value <> "", txtvideo.Value, "")
                'objLib.LibVideo = strVideo  //When using uploading
                objLib.LibVideoId = hdnVideoId.Value
                objLib.LibVideoImage = hdnUrl.Value
                objLib.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
                objLib.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
                Dim intCat As Integer = objLib.SaveToMyLibrary()
                'If intCat = -2 Then
                '    ltrLibMsg.Text = "Library Category Allready Exist!"
                '    Exit Sub
                'Else
                'ltrLibMsg.Text = "Library saved successfully!"
                'End If
                BindLibraryCategories()
                ClearData()
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";SaveScheduleAlert('library message is Saved Successfully');", True)
                'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";ShowUserLib(" & intCat & ");SaveAlert('library message is Saved Successfully');", True)
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            ltrLibMsg.Text = "Error: " & ex.Message
        End Try

    End Sub

    Sub DeleteMyLib(ByVal sender As Object, ByVal e As CommandEventArgs)
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            objLib.LibraryId = e.CommandArgument
            objLib.DeleteMyLibrary()
            BindLibraryCategories()
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";ShowUserLib(" & e.CommandName & ");SaveAlert('Library post deleted successfully');", True)

        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    Sub DeleteMyLibCat(ByVal sender As Object, ByVal e As CommandEventArgs)
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            objLib.LibraryCatId = e.CommandArgument
            objLib.DeleteMyLibraryCategory()
            BindLibraryCategories()
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";ShowUserLib(" & e.CommandName & ");SaveAlert('Library post deleted successfully');", True)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

#End Region


    Private Sub lnkSaveDraft_ServerClick(sender As Object, e As System.EventArgs) Handles lnkSaveDraft.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                hdnMakeDateString.Value = txtActivationDate.Value & " " & selActivationHour.Value & ":" & selActivationMinute.Value & ":00 " & selAMPM.Value  'Date.Now.ToString()
                If ddlTimeZone.SelectedIndex > 0 Then
                    If ddlTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                        lblTimeZone.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(hdnMakeDateString.Value, ddlTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
                    Else
                        lblTimeZone.Text = hdnMakeDateString.Value
                    End If
                End If

                Dim strDate1 As DateTime = If((lblTimeZone.Text <> ""), Convert.ToDateTime(lblTimeZone.Text), Date.Now)
                Dim strActivationHours As String = Integer.Parse(strDate1.ToString("hh")).ToString()
                Dim strActivationMinutes As String = strDate1.Minute
                Dim strmessage As String = txtMessage.Value
                Dim strDate As String = strDate1.Date
                Dim strAMPM As String = strDate1.ToString("tt")
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strVideoThumb As String = "", strVideo As String = ""
                Dim strVideoFileNameWithoutExtension As String = ""

                If photo.PostedFile.ContentLength > 0 Then
                    Dim uploadContent = photo.PostedFile.ContentLength / 1000
                    strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
                    'If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                    '    strVideoFileNameWithoutExtension = "V-" & String.Format("{0:MMddyyyyhhmmsstt}", Now)
                    '    If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                    '        If strExt <> ".flv" Then
                    '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                    '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                    '            myprocess.StartInfo.UseShellExecute = True
                    '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog.bat")
                    '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                    '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & strExt & " -s -m"
                    '            myprocess.Start()
                    '        Else
                    '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                    '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                    '            myprocess.StartInfo.UseShellExecute = True
                    '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog-flv.bat")
                    '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                    '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & ".flv" & " -s -m"
                    '            myprocess.Start()
                    '        End If
                    '        strVideoThumb = strVideoFileNameWithoutExtension & ".jpg"
                    '        strVideo = strVideoFileNameWithoutExtension & ".flv"
                    '    End If

                    '    Dim photopath As String = Server.MapPath("~/" & "Content/uploads/" & strVideo)
                    '    hdnImage.Value = photopath
                    '    lblVideoText.Visible = True
                    '    imgPhoto.Visible = False
                    '    lblVideoText.Text = hdnImage.Value
                    '    'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                    '    Dim str As String = ""
                    '    lblMessage.Text = "Video Uploaded Successfully"
                    'Else
                    If uploadContent > 10000 Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "ShowErrorPopUp", "OpenDiv();", True)
                        Exit Sub
                    Else
                        If strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png" Then
                            Dim strDate12 As Date = "1/1/1900"
                            strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now())) & strExt
                            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\images\" & strPhoto))
                            Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto)
                            'lblMessage.Text = "Photo Uploaded Successfully"
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Photo Uploaded Successfully');", True)
                        Else
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('File must be .jpg or .gif or .png or .jpeg or .tif or .bmp');", True)
                            'lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
                            Exit Sub
                        End If
                    End If
                ElseIf hdnImage1.Value <> "" Then
                    strPhoto = hdnImage1.Value
                End If

                'Try

                If RequestContext.RouteData.Values("sm_Id") <> "" Then
                    Dim objBAL As New BALSchedulePost
                    Dim Id As String
                    Id = RequestContext.RouteData.Values("sm_Id")
                    objBAL.DraftId = Id
                    objBAL.TSMAUserId = Session("SiteUserId")
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                    objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 

                    objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                    objBAL.Message = CStr(Replace(txtMessage.Value, Chr(10), "<br>"))
                    objBAL.Image = If(strPhoto <> "", strPhoto, "")
                    objBAL.Video = If(strVideo <> "", strVideo, "")
                    objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                    objBAL.VideoId = hdnVideoId.Value
                    objBAL.VideoImage = hdnUrl.Value
                    objBAL.ScheduleDate = If((strDate <> ""), Convert.ToDateTime(strDate), Date.Now)
                    objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
                    objBAL.ScheduleMinute = If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                    objBAL.ScheduleAMPM = If(strAMPM <> "0", strAMPM, "")
                    objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                    objBAL.IsPosted = 0
                    objBAL.PostType = 2
                    objBAL.UpdatedDate = Date.Now
                    objBAL.UpdateDrafts()


                    objBAL.DeleteFanPages(Id)
                    For Each item As DataListItem In dstFanPages.Items
                        Dim myCheckBox As HtmlInputCheckBox
                        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)

                        If myCheckBox.Checked = True Then
                            objBAL.ScheduleId = Id
                            objBAL.FBUserId = Session("FacebookUserId")
                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                            objBAL.AddQuickPost()
                        End If
                    Next
                    BindAllDrafts()
                    BindAllSentItems()
                    BindAllScheduledPosts()
                    ClearData()
                    'lblMessage.Text = "Drafts Updated successfully"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Draft saved successfully');", True)
                Else
                    Dim objBAL As New BALSchedulePost
                    objBAL.TSMAUserId = Session("SiteUserId")
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                    objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                    objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                    objBAL.Message = CStr(Replace(txtMessage.Value, Chr(10), "<br>"))
                    objBAL.Image = If(strPhoto <> "", strPhoto, "")
                    objBAL.Video = If(strVideo <> "", strVideo, "")
                    objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                    objBAL.VideoId = hdnVideoId.Value
                    objBAL.VideoImage = hdnUrl.Value
                    objBAL.ScheduleDate = If((strDate <> ""), Convert.ToDateTime(strDate), Date.Now)
                    objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
                    objBAL.ScheduleMinute = If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                    objBAL.ScheduleAMPM = If(strAMPM <> "0", strAMPM, "")
                    objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                    objBAL.IsPosted = 0
                    objBAL.PostType = 2
                    objBAL.CreatedDate = Date.Now
                    objBAL.UpdatedDate = Date.Now


                    Dim ds As New DataSet
                    ds = objBAL.AddQuickPostMaster()
                    Dim scheduleID As String = ds.Tables(0).Rows(0).Item(0).ToString()
                    For Each item As DataListItem In dstFanPages.Items
                        Dim myCheckBox As HtmlInputCheckBox
                        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                        If myCheckBox.Checked = True Then
                            objBAL.ScheduleId = CInt(scheduleID)
                            objBAL.FBUserId = Session("FacebookUserId")
                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                            objBAL.AddQuickPost()
                        End If
                    Next
                    'lblMessage.Text = "Drafts Saved successfully"
                    BindAllDrafts()
                    BindAllSentItems()
                    BindAllScheduledPosts()
                    ClearData()
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Draft saved successfully');", True)
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Draft saved successfully');", True)
                End If

            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub lnkPost_ServerClick(sender As Object, e As System.EventArgs) Handles lnkPost.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim objBAL As New BALSchedulePost
                If RequestContext.RouteData.Values("sm_Id") <> "" Then
                    Dim AccessToken As String = Session("FacebookAccessToken")
                    hdnMakeDateString.Value = txtActivationDate.Value & " " & selActivationHour.Value & ":" & selActivationMinute.Value & ":00 " & selAMPM.Value  'Date.Now.ToString()
                    If ddlTimeZone.SelectedIndex > 0 Then
                        If ddlTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                            lblTimeZone.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(hdnMakeDateString.Value, ddlTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
                        Else
                            lblTimeZone.Text = hdnMakeDateString.Value
                        End If
                    End If
                    'If ddlTimeZone.SelectedIndex > 0 Then
                    '    lblTimeZone.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(hdnMakeDateString.Value, ddlTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
                    'End If
                    Dim strDate1 As DateTime = If((lblTimeZone.Text <> ""), Convert.ToDateTime(lblTimeZone.Text), Date.Now)
                    Dim strActivationHours As String = Integer.Parse(strDate1.ToString("hh")).ToString()
                    Dim strActivationMinutes As String = strDate1.Minute
                    Dim strmessage As String = txtMessage.Value
                    Dim strDate As String = strDate1.Date
                    Dim strAMPM As String = strDate1.ToString("tt")
                    Dim strPageId As String = hdnselectedPages.Value
                    Dim strPageName As String = hdnSelectedPagesName.Value
                    Dim strPageImage As String = hdnSelectedPagesImage.Value
                    Dim strPageAccessToken As String = hdnselectedPagesAccessToken.Value

                    Dim strExt As String = ""
                    Dim strPhoto As String = ""
                    Dim strVideoThumb As String = "", strVideo As String = ""
                    Dim strVideoFileNameWithoutExtension As String = ""
                    Dim Id As String
                    Id = RequestContext.RouteData.Values("sm_Id")
                    If photo.PostedFile.ContentLength > 0 Then
                        Dim uploadContent = photo.PostedFile.ContentLength / 1000
                        strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
                        'If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                        '    strVideoFileNameWithoutExtension = "V-" & String.Format("{0:MMddyyyyhhmmsstt}", Now)
                        '    If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                        '        If strExt <> ".flv" Then
                        '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                        '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                        '            myprocess.StartInfo.UseShellExecute = True
                        '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog.bat")
                        '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                        '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & strExt & " -s -m"
                        '            myprocess.Start()
                        '        Else
                        '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                        '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                        '            myprocess.StartInfo.UseShellExecute = True
                        '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog-flv.bat")
                        '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                        '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & ".flv" & " -s -m"
                        '            myprocess.Start()
                        '        End If
                        '        strVideoThumb = strVideoFileNameWithoutExtension & ".jpg"
                        '        strVideo = strVideoFileNameWithoutExtension & ".flv"
                        '    End If

                        '    Dim photopath As String = Server.MapPath("~/" & "Content/uploads/" & strVideo)
                        '    hdnImage.Value = photopath
                        '    lblVideoText.Visible = True
                        '    imgPhoto.Visible = False
                        '    lblVideoText.Text = hdnImage.Value
                        '    'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                        '    Dim str As String = ""
                        '    For Each item As DataListItem In dstFanPages.Items
                        '        Dim myCheckBox As HtmlInputCheckBox
                        '        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                        '        If myCheckBox.Checked = True Then
                        '            Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/videos"
                        '            Dim mediaObject As New FacebookMediaObject() With { _
                        '                .FileName = photopath, _
                        '                .ContentType = "video/3gpp" _
                        '        }
                        '            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                        '            mediaObject.SetValue(fileBytes)
                        '            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                        '            'upload.Add("title", "video title")
                        '            upload.Add("description", txtVideoMessage.Value)
                        '            upload.Add("image", mediaObject)
                        '            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                        '            fbapp.Post(path, upload)
                        '        End If
                        '    Next
                        '    lblMessage.Text = "Video Uploaded Successfully"
                        'Else
                        If uploadContent > 10000 Then
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "ShowErrorPopUp", "OpenDiv();", True)
                            Exit Sub
                        Else
                            If strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png" Then
                                Dim photopath As String
                                Dim strDate12 As Date = "1/1/1900"
                                strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now())) & strExt
                                photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\images\" & strPhoto))
                                photopath = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto)

                                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                                'Dim str As String = ""
                                For Each item As DataListItem In dstFanPages.Items
                                    Dim myCheckBox As HtmlInputCheckBox
                                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                                    If myCheckBox.Checked = True Then

                                        Dim path1 As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums" '"225274570816748/photos"
                                        Dim Albumpath As String = "https://graph.facebook.com/" & CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums?fields=id,name&access_token={0}"
                                        Dim fbapp1 = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                        Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                        Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                        Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value))
                                        Dim response1 As WebResponse = request1.GetResponse()
                                        Dim stream As Stream = response1.GetResponseStream()
                                        Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                                        Dim fAlbums As New Albums()
                                        fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                                        Dim listAlbums As New List(Of Albums.m_data)

                                        For Each item1 As Albums.m_data In fAlbums.data
                                            listAlbums.Add(item1)
                                        Next
                                        Dim cnt As Integer = listAlbums.Count
                                        Dim flag As Integer
                                        Dim aid As String = ""
                                        For i As Integer = 0 To cnt - 1
                                            If listAlbums.Item(i).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                                                aid = listAlbums.Item(i).id
                                                flag = 0
                                                Exit For
                                            Else
                                                flag = 1
                                            End If
                                        Next

                                        If flag = 1 Then
                                            upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                                            Dim album As JsonObject = fbapp1.Post(path1, upload1)

                                            Dim albumID As String = album("id")

                                            Dim path As String = albumID & "/photos" '"225274570816748/photos"
                                            Dim mediaObject As New FacebookMediaObject() With { _
                                                .FileName = photopath, _
                                                .ContentType = "image/jpg" _
                                            }
                                            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                            mediaObject.SetValue(fileBytes)
                                            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                            upload.Add("message", strmessage)
                                            upload.Add("image", mediaObject)
                                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                            fbapp.Post(path, upload)
                                        Else
                                            Dim path As String = aid & "/photos" '"225274570816748/photos"
                                            Dim mediaObject As New FacebookMediaObject() With { _
                                                .FileName = photopath, _
                                                .ContentType = "image/jpg" _
                                            }
                                            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                            mediaObject.SetValue(fileBytes)
                                            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                            upload.Add("message", strmessage)
                                            upload.Add("image", mediaObject)
                                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                            fbapp.Post(path, upload)
                                        End If

                                        '    Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/photos"
                                        '    Dim mediaObject As New FacebookMediaObject() With { _
                                        '        .FileName = photopath, _
                                        '        .ContentType = "image/jpg" _
                                        '}
                                        '    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                        '    mediaObject.SetValue(fileBytes)
                                        '    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                        '    upload.Add("message", strmessage)
                                        '    upload.Add("image", mediaObject)
                                        '    Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                        '    fbapp.Post(path, upload)
                                    End If
                                Next
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Photo Uploaded Successfully');", True)
                                'lblMessage.Text = "Photo Uploaded Successfully"
                            Else
                                'lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('File must be .jpg or .gif or .png or .jpeg or .tif or .bmp ');", True)
                                Exit Sub
                                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
                            End If
                        End If
                        'ElseIf txtvideo.Value <> "" Then
                        '    Dim args = New Dictionary(Of String, Object)()
                        '    args("message") = strmessage
                        '    args("link") = txtvideo.Value
                        '    Dim regex As New Regex(",")
                        '    Dim str As String = ""
                        '    For Each item As DataListItem In dstFanPages.Items
                        '        Dim myCheckBox As HtmlInputCheckBox
                        '        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                        '        If myCheckBox.Checked = True Then
                        '            Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                        '            Dim fbapp = New FacebookClient(AccessToken)
                        '            fbapp.Post(path, args)
                        '        End If
                        '    Next
                    ElseIf hdnImage1.Value <> "" Then 'hdnImageChange.Value <> "Content/images/no_img.jpg" Then
                        strPhoto = hdnImage1.Value
                        Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto) 'hdnImageChange.Value
                        For Each item As DataListItem In dstFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                            If myCheckBox.Checked = True Then

                                Dim path1 As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums" '"225274570816748/photos"
                                Dim Albumpath As String = "https://graph.facebook.com/" & CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums?fields=id,name&access_token={0}"
                                Dim fbapp1 = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value))
                                Dim response1 As WebResponse = request1.GetResponse()
                                Dim stream As Stream = response1.GetResponseStream()
                                Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                                Dim fAlbums As New Albums()
                                fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                                Dim listAlbums As New List(Of Albums.m_data)

                                For Each item1 As Albums.m_data In fAlbums.data
                                    listAlbums.Add(item1)
                                Next
                                Dim cnt As Integer = listAlbums.Count
                                Dim flag As Integer
                                Dim aid As String = ""
                                For i As Integer = 0 To cnt - 1
                                    If listAlbums.Item(i).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                                        aid = listAlbums.Item(i).id
                                        flag = 0
                                        Exit For
                                    Else
                                        flag = 1
                                    End If
                                Next

                                If flag = 1 Then
                                    upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                                    Dim album As JsonObject = fbapp1.Post(path1, upload1)

                                    Dim albumID As String = album("id")

                                    Dim path As String = albumID & "/photos" '"225274570816748/photos"
                                    Dim mediaObject As New FacebookMediaObject() With { _
                                        .FileName = photopath, _
                                        .ContentType = "image/jpg" _
                                    }
                                    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                    mediaObject.SetValue(fileBytes)
                                    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                    upload.Add("message", strmessage)
                                    upload.Add("image", mediaObject)
                                    Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                    fbapp.Post(path, upload)
                                Else
                                    Dim path As String = aid & "/photos" '"225274570816748/photos"
                                    Dim mediaObject As New FacebookMediaObject() With { _
                                        .FileName = photopath, _
                                        .ContentType = "image/jpg" _
                                    }
                                    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                    mediaObject.SetValue(fileBytes)
                                    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                    upload.Add("message", strmessage)
                                    upload.Add("image", mediaObject)
                                    Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                    fbapp.Post(path, upload)
                                End If
                                '    Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/photos"
                                '    Dim mediaObject As New FacebookMediaObject() With { _
                                '        .FileName = photopath, _
                                '        .ContentType = "image/jpg" _
                                '}
                                '    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                '    mediaObject.SetValue(fileBytes)
                                '    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                '    upload.Add("message", strmessage)
                                '    upload.Add("image", mediaObject)
                                '    Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                '    fbapp.Post(path, upload)
                            End If
                        Next
                    ElseIf txtvideo.Value = "" Then
                        Dim args = New Dictionary(Of String, Object)()
                        args("message") = strmessage
                        Dim regex As New Regex(",")
                        Dim str As String = ""
                        For Each item As DataListItem In dstFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                            If myCheckBox.Checked = True Then
                                Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                                Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                fbapp.Post(path, args)
                            End If
                        Next
                    End If

                    If txtvideo.Value <> "" Then
                        Dim args = New Dictionary(Of String, Object)()
                        args("message") = strmessage
                        args("link") = txtvideo.Value
                        Dim regex As New Regex(",")
                        Dim str As String = ""
                        For Each item As DataListItem In dstFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                            If myCheckBox.Checked = True Then
                                Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                                Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                fbapp.Post(path, args)
                            End If
                        Next
                    End If

                    objBAL.DraftId = Id
                    objBAL.TSMAUserId = Session("SiteUserId")
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                    objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                    objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                    objBAL.Message = CStr(Replace(strmessage, Chr(10), "<br>"))
                    objBAL.Image = If(strPhoto <> "", strPhoto, "")
                    objBAL.Video = If(strVideo <> "", strVideo, "")
                    objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                    objBAL.VideoId = hdnVideoId.Value
                    objBAL.VideoImage = hdnUrl.Value
                    objBAL.ScheduleDate = If((strDate <> ""), Convert.ToDateTime(strDate), Date.Now)
                    objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
                    objBAL.ScheduleMinute = If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                    objBAL.ScheduleAMPM = If(strAMPM <> "0", strAMPM, "")
                    objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                    objBAL.IsPosted = 1
                    objBAL.PostType = 0
                    objBAL.UpdatedDate = Date.Now

                    objBAL.UpdateDrafts()
                    objBAL.DeleteFanPages(Id)
                    For Each item As DataListItem In dstFanPages.Items
                        Dim myCheckBox As HtmlInputCheckBox
                        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                        If myCheckBox.Checked = True Then
                            objBAL.ScheduleId = Id
                            objBAL.FBUserId = Session("FacebookUserId")
                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                            objBAL.AddQuickPost()
                        End If
                    Next
                    'lblMessage.Text = "Draft Submitted successfully"
                    BindAllDrafts()
                    BindAllSentItems()
                    BindAllScheduledPosts()
                    ClearData()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Message Is Posted Successfully To Your Selected Business Page(s)');", True)
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Message Is Posted Successfully To Your Selected Business Page(s)');", True)
                Else
                    Dim AccessToken As String = Session("FacebookAccessToken")
                    hdnMakeDateString.Value = txtActivationDate.Value & " " & selActivationHour.Value & ":" & selActivationMinute.Value & ":00 " & selAMPM.Value  'Date.Now.ToString()
                    If ddlTimeZone.SelectedIndex > 0 Then
                        If ddlTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                            lblTimeZone.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(hdnMakeDateString.Value, ddlTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
                        Else
                            lblTimeZone.Text = hdnMakeDateString.Value
                        End If
                    End If
                    Dim strDate1 As DateTime = If((lblTimeZone.Text <> ""), Convert.ToDateTime(lblTimeZone.Text), Date.Now)
                    Dim strActivationHours As String = Integer.Parse(strDate1.ToString("hh")).ToString()
                    Dim strActivationMinutes As String = strDate1.Minute
                    Dim strmessage As String = txtMessage.Value
                    Dim strDate As String = strDate1.Date
                    Dim strAMPM As String = strDate1.ToString("tt")
                    Dim strPageId As String = hdnselectedPages.Value
                    Dim strPageName As String = hdnSelectedPagesName.Value
                    Dim strPageImage As String = hdnSelectedPagesImage.Value
                    Dim strPageAccessToken As String = hdnselectedPagesAccessToken.Value
                    Dim strExt As String = ""
                    Dim strPhoto As String = ""
                    Dim strVideoThumb As String = "", strVideo As String = ""
                    Dim strVideoFileNameWithoutExtension As String = ""

                    If photo.PostedFile.ContentLength > 0 Then
                        Dim uploadContent As Integer = photo.PostedFile.ContentLength / 1000
                        strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
                        'If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                        '    strVideoFileNameWithoutExtension = "V-" & String.Format("{0:MMddyyyyhhmmsstt}", Now)
                        '    If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                        '        If strExt <> ".flv" Then
                        '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                        '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                        '            myprocess.StartInfo.UseShellExecute = True
                        '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog.bat")
                        '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                        '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & strExt & " -s -m"
                        '            myprocess.Start()
                        '        Else
                        '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                        '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                        '            myprocess.StartInfo.UseShellExecute = True
                        '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog-flv.bat")
                        '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                        '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & ".flv" & " -s -m"
                        '            myprocess.Start()
                        '        End If
                        '        strVideoThumb = strVideoFileNameWithoutExtension & ".jpg"
                        '        strVideo = strVideoFileNameWithoutExtension & ".flv"
                        '    End If

                        '    Dim photopath As String = Server.MapPath("~/" & "Content/uploads/" & strVideo)
                        '    hdnImage.Value = photopath
                        '    lblVideoText.Visible = True
                        '    imgPhoto.Visible = False
                        '    lblVideoText.Text = hdnImage.Value
                        '    'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                        '    Dim str As String = ""
                        '    For Each item As DataListItem In dstFanPages.Items
                        '        Dim myCheckBox As HtmlInputCheckBox
                        '        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                        '        If myCheckBox.Checked = True Then
                        '            Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/videos"
                        '            Dim mediaObject As New FacebookMediaObject() With { _
                        '                .FileName = photopath, _
                        '                .ContentType = "video/3gpp" _
                        '        }
                        '            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                        '            mediaObject.SetValue(fileBytes)
                        '            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                        '            'upload.Add("title", "video title")
                        '            upload.Add("description", txtVideoMessage.Value)
                        '            upload.Add("image", mediaObject)
                        '            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                        '            fbapp.Post(path, upload)
                        '        End If
                        '    Next
                        '    lblMessage.Text = "Video Uploaded Successfully"
                        'Else
                        If uploadContent > 10000 Then
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "ShowErrorPopUp", "OpenDiv();", True)
                            Exit Sub
                        Else
                            If strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png" Then
                                Dim photopath As String
                                Dim strDate12 As Date = "1/1/1900"
                                strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now())) & strExt
                                photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\images\" & strPhoto))
                                photopath = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto)
                                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                                'Dim str As String = ""
                                For Each item As DataListItem In dstFanPages.Items
                                    Dim myCheckBox As HtmlInputCheckBox
                                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                                    If myCheckBox.Checked = True Then
                                        Dim path1 As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums" '"225274570816748/photos"
                                        Dim Albumpath As String = "https://graph.facebook.com/" & CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums?fields=id,name&access_token={0}"
                                        Dim fbapp1 = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                        Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                        Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                        Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value))
                                        Dim response1 As WebResponse = request1.GetResponse()
                                        Dim stream As Stream = response1.GetResponseStream()
                                        Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                                        Dim fAlbums As New Albums()
                                        fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                                        Dim listAlbums As New List(Of Albums.m_data)

                                        For Each item1 As Albums.m_data In fAlbums.data
                                            listAlbums.Add(item1)
                                        Next
                                        Dim cnt As Integer = listAlbums.Count
                                        Dim flag As Integer
                                        Dim aid As String = ""
                                        For i As Integer = 0 To cnt - 1
                                            If listAlbums.Item(i).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                                                aid = listAlbums.Item(i).id
                                                flag = 0
                                                Exit For
                                            Else
                                                flag = 1
                                            End If
                                        Next

                                        If flag = 1 Then
                                            upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                                            Dim album As JsonObject = fbapp1.Post(path1, upload1)

                                            Dim albumID As String = album("id")

                                            Dim path As String = albumID & "/photos" '"225274570816748/photos"
                                            Dim mediaObject As New FacebookMediaObject() With { _
                                                .FileName = photopath, _
                                                .ContentType = "image/jpg" _
                                            }
                                            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                            mediaObject.SetValue(fileBytes)
                                            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                            upload.Add("message", strmessage)
                                            upload.Add("image", mediaObject)
                                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                            fbapp.Post(path, upload)
                                        Else
                                            Dim path As String = aid & "/photos" '"225274570816748/photos"
                                            Dim mediaObject As New FacebookMediaObject() With { _
                                                .FileName = photopath, _
                                                .ContentType = "image/jpg" _
                                            }
                                            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                            mediaObject.SetValue(fileBytes)
                                            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                            upload.Add("message", strmessage)
                                            upload.Add("image", mediaObject)
                                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                            fbapp.Post(path, upload)
                                        End If
                                        '    Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/photos"
                                        '    Dim mediaObject As New FacebookMediaObject() With { _
                                        '        .FileName = photopath, _
                                        '        .ContentType = "image/jpg" _
                                        '}
                                        '    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                        '    mediaObject.SetValue(fileBytes)
                                        '    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                        '    upload.Add("message", strmessage)
                                        '    upload.Add("image", mediaObject)
                                        '    Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                        '    fbapp.Post(path, upload)
                                    End If
                                Next
                                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Photo is uploaded successfully ');", True)
                                'lblMessage.Text = "Photo Uploaded Successfully"
                            Else
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('File must be .jpg or .gif or .png or .jpeg or .tif or .bmp ');", True)
                                'lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
                                Exit Sub
                                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
                            End If
                        End If


                        'ElseIf txtvideo.Value <> "" Then
                        '    Dim args = New Dictionary(Of String, Object)()
                        '    args("message") = strmessage
                        '    args("link") = txtvideo.Value
                        '    Dim regex As New Regex(",")
                        '    Dim str As String = ""
                        '    For Each item As DataListItem In dstFanPages.Items
                        '        Dim myCheckBox As HtmlInputCheckBox
                        '        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                        '        If myCheckBox.Checked = True Then
                        '            Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                        '            Dim fbapp = New FacebookClient(AccessToken)
                        '            fbapp.Post(path, args)
                        '        End If
                        '    Next
                    ElseIf hdnImage1.Value <> "" Then
                        strPhoto = hdnImage1.Value
                        Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto) 'hdnImageChange.Value
                        'Response.Write("Without Edit : " & photopath)
                        'Response.End()
                        For Each item As DataListItem In dstFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                            If myCheckBox.Checked = True Then
                                Dim path1 As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums" '"225274570816748/photos"
                                Dim Albumpath As String = "https://graph.facebook.com/" & CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums?fields=id,name&access_token={0}"
                                Dim fbapp1 = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value))
                                Dim response1 As WebResponse = request1.GetResponse()
                                Dim stream As Stream = response1.GetResponseStream()
                                Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                                Dim fAlbums As New Albums()
                                fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                                Dim listAlbums As New List(Of Albums.m_data)

                                For Each item1 As Albums.m_data In fAlbums.data
                                    listAlbums.Add(item1)
                                Next
                                Dim cnt As Integer = listAlbums.Count
                                Dim flag As Integer
                                Dim aid As String = ""
                                For i As Integer = 0 To cnt - 1
                                    If listAlbums.Item(i).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                                        aid = listAlbums.Item(i).id
                                        flag = 0
                                        Exit For
                                    Else
                                        flag = 1
                                    End If
                                Next

                                If flag = 1 Then
                                    upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                                    Dim album As JsonObject = fbapp1.Post(path1, upload1)

                                    Dim albumID As String = album("id")

                                    Dim path As String = albumID & "/photos" '"225274570816748/photos"
                                    Dim mediaObject As New FacebookMediaObject() With { _
                                        .FileName = photopath, _
                                        .ContentType = "image/jpg" _
                                    }
                                    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                    mediaObject.SetValue(fileBytes)
                                    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                    upload.Add("message", strmessage)
                                    upload.Add("image", mediaObject)
                                    Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                    fbapp.Post(path, upload)
                                Else
                                    Dim path As String = aid & "/photos" '"225274570816748/photos"
                                    Dim mediaObject As New FacebookMediaObject() With { _
                                        .FileName = photopath, _
                                        .ContentType = "image/jpg" _
                                    }
                                    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                    mediaObject.SetValue(fileBytes)
                                    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                    upload.Add("message", strmessage)
                                    upload.Add("image", mediaObject)
                                    Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                    fbapp.Post(path, upload)
                                End If
                                '    Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/photos"
                                '    Dim mediaObject As New FacebookMediaObject() With { _
                                '        .FileName = photopath, _
                                '        .ContentType = "image/jpg" _
                                '}
                                '    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                '    mediaObject.SetValue(fileBytes)
                                '    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                '    upload.Add("message", strmessage)
                                '    upload.Add("image", mediaObject)
                                '    Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                '    fbapp.Post(path, upload)
                            End If
                        Next
                        'Else
                    ElseIf txtvideo.Value = "" Then
                        Dim args = New Dictionary(Of String, Object)()
                        args("message") = strmessage
                        Dim regex As New Regex(",")
                        Dim str As String = ""
                        For Each item As DataListItem In dstFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                            If myCheckBox.Checked = True Then
                                Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                                Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                fbapp.Post(path, args)
                            End If
                        Next
                    End If

                    If txtvideo.Value <> "" Then
                        Dim args = New Dictionary(Of String, Object)()
                        args("message") = strmessage
                        args("link") = txtvideo.Value
                        Dim regex As New Regex(",")
                        Dim str As String = ""
                        For Each item As DataListItem In dstFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                            If myCheckBox.Checked = True Then
                                Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                                Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                fbapp.Post(path, args)
                            End If
                        Next
                    End If


                    objBAL.TSMAUserId = Session("SiteUserId")
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                    objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                    objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                    objBAL.Message = CStr(Replace(strmessage, Chr(10), "<br>"))
                    objBAL.Image = If(strPhoto <> "", strPhoto, "")
                    objBAL.Video = If(strVideo <> "", strVideo, "")
                    objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                    objBAL.VideoId = hdnVideoId.Value
                    objBAL.VideoImage = hdnUrl.Value
                    objBAL.ScheduleDate = If((strDate <> ""), Convert.ToDateTime(strDate), Date.Now)
                    objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
                    objBAL.ScheduleMinute = If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                    objBAL.ScheduleAMPM = If(strAMPM <> "0", strAMPM, "")
                    objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                    objBAL.IsPosted = 1
                    objBAL.PostType = 0
                    objBAL.CreatedDate = Date.Now
                    objBAL.UpdatedDate = Date.Now

                    Dim ds As New DataSet
                    ds = objBAL.AddQuickPostMaster()
                    Dim scheduleID As String = ds.Tables(0).Rows(0).Item(0).ToString()
                    For Each item As DataListItem In dstFanPages.Items
                        Dim myCheckBox As HtmlInputCheckBox
                        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                        If myCheckBox.Checked = True Then
                            objBAL.ScheduleId = CInt(scheduleID)
                            objBAL.FBUserId = Session("FacebookUserId")
                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                            objBAL.AddQuickPost()
                        End If
                    Next

                    'lblMessage.Text = "Post Submitted Successfully"
                    BindAllDrafts()
                    BindAllSentItems()
                    BindAllScheduledPosts()
                    ClearData()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Message Is Posted Successfully To Your Selected Business Page(s)');", True)
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Message posted to selected business page(s)successfully');", True)
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub


    Private Sub lnkScheduledPost_ServerClick(sender As Object, e As System.EventArgs) Handles lnkScheduledPost.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                hdnMakeDateString.Value = txtActivationDate.Value & " " & selActivationHour.Value & ":" & selActivationMinute.Value & selAMPM.Value  'Date.Now.ToString()
                If ddlTimeZone.SelectedIndex > 0 Then
                    If ddlTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                        lblTimeZone.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(hdnMakeDateString.Value, ddlTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
                    Else
                        lblTimeZone.Text = hdnMakeDateString.Value
                    End If
                End If
                Dim strDate1 As DateTime = If((lblTimeZone.Text <> ""), Convert.ToDateTime(lblTimeZone.Text), Date.Now)
                Dim strActivationHours As String = Integer.Parse(strDate1.ToString("hh")).ToString()
                Dim strActivationMinutes As String = strDate1.Minute.ToString
                Dim strmessage As String = txtMessage.Value
                Dim strDate As String = strDate1.Date
                Dim strAMPM As String = strDate1.ToString("tt")
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strVideoThumb As String = "", strVideo As String = ""
                Dim strVideoFileNameWithoutExtension As String = ""

                If photo.PostedFile.ContentLength > 0 Then
                    Dim UploadContent As Integer = photo.PostedFile.ContentLength / 1000
                    strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
                    'If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                    '    strVideoFileNameWithoutExtension = "V-" & String.Format("{0:MMddyyyyhhmmsstt}", Now)
                    '    If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
                    '        If strExt <> ".flv" Then
                    '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                    '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                    '            myprocess.StartInfo.UseShellExecute = True
                    '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog.bat")
                    '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                    '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & strExt & " -s -m"
                    '            myprocess.Start()
                    '        Else
                    '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
                    '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
                    '            myprocess.StartInfo.UseShellExecute = True
                    '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog-flv.bat")
                    '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
                    '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & ".flv" & " -s -m"
                    '            myprocess.Start()
                    '        End If
                    '        strVideoThumb = strVideoFileNameWithoutExtension & ".jpg"
                    '        strVideo = strVideoFileNameWithoutExtension & ".flv"
                    '    End If

                    '    Dim photopath As String = Server.MapPath("~/" & "Content/uploads/" & strVideo)
                    '    hdnImage.Value = photopath
                    '    lblVideoText.Visible = True
                    '    imgPhoto.Visible = False
                    '    lblVideoText.Text = hdnImage.Value
                    '    'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                    '    Dim str As String = ""
                    '    lblMessage.Text = "Video Uploaded Successfully"
                    'Else
                    If UploadContent > 10000 Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "ShowErrorPopUp", "OpenDiv();", True)
                        Exit Sub
                    Else
                        If strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png" Then
                            Dim strDate12 As Date = "1/1/1900"
                            strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now())) & strExt
                            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\images\" & strPhoto))
                            Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto)
                            lblVideoText.Visible = False
                            'lblMessage.Text = "Photo Uploaded Successfully"
                            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
                        Else
                            'lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('File must be .jpg or .gif or .png or .jpeg or .tif or .bmp');", True)
                            Exit Sub
                        End If
                    End If
                ElseIf hdnImage1.Value <> "" Then
                    strPhoto = hdnImage1.Value
                End If
                If RequestContext.RouteData.Values("sm_Id") <> "" Then
                    Dim Id As String
                    Id = RequestContext.RouteData.Values("sm_Id")
                    Dim objBAL As New BALSchedulePost
                    objBAL.DraftId = Id
                    objBAL.TSMAUserId = Session("SiteUserId")
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                    objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                    objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                    objBAL.Message = CStr(Replace(strmessage, Chr(10), "<br>"))
                    objBAL.Image = If(strPhoto <> "", strPhoto, "")
                    objBAL.Video = If(strVideo <> "", strVideo, "")
                    objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                    objBAL.VideoId = hdnVideoId.Value
                    objBAL.VideoImage = hdnUrl.Value
                    objBAL.ScheduleDate = If((strDate <> ""), Convert.ToDateTime(strDate), Date.Now)
                    objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
                    objBAL.ScheduleMinute = strActivationMinutes 'If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                    objBAL.ScheduleAMPM = If(strAMPM <> "0", strAMPM, "")
                    objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                    objBAL.IsPosted = 0
                    objBAL.PostType = 1
                    objBAL.UpdatedDate = Date.Now
                    objBAL.UpdateDrafts()
                    objBAL.DeleteFanPages(Id)
                    For Each item As DataListItem In dstFanPages.Items
                        Dim myCheckBox As HtmlInputCheckBox
                        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                        If myCheckBox.Checked = True Then
                            objBAL.ScheduleId = Id
                            objBAL.FBUserId = Session("FacebookUserId")
                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                            objBAL.AddQuickPost()
                        End If
                    Next
                    'blMessage.Text = "Message Scheduled Updated Successfully"

                    BindAllDrafts()
                    BindAllSentItems()
                    BindAllScheduledPosts()
                    ClearData()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Message is updated successfully in schedule post');", True)
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Message is updated successfully in schedule post');", True)
                Else
                    Dim objBAL As New BALSchedulePost
                    objBAL.TSMAUserId = Session("SiteUserId")
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                    objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                    objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                    objBAL.Message = CStr(Replace(strmessage, Chr(10), "<br>"))
                    objBAL.Image = If(strPhoto <> "", strPhoto, "")
                    objBAL.Video = If(strVideo <> "", strVideo, "")
                    objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                    objBAL.VideoId = hdnVideoId.Value
                    objBAL.VideoImage = hdnUrl.Value
                    objBAL.ScheduleDate = If((strDate <> ""), Convert.ToDateTime(strDate), Date.Now)
                    objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
                    objBAL.ScheduleMinute = strActivationMinutes 'If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                    objBAL.ScheduleAMPM = If(strAMPM <> "0", strAMPM, "")
                    objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                    objBAL.IsPosted = 0
                    objBAL.PostType = 1
                    objBAL.CreatedDate = Date.Now
                    objBAL.UpdatedDate = Date.Now
                    Dim ds As New DataSet
                    ds = objBAL.AddQuickPostMaster()
                    Dim scheduleID As String = ds.Tables(0).Rows(0).Item(0).ToString()
                    For Each item As DataListItem In dstFanPages.Items
                        Dim myCheckBox As HtmlInputCheckBox
                        myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                        If myCheckBox.Checked = True Then
                            objBAL.ScheduleId = CInt(scheduleID)
                            objBAL.FBUserId = Session("FacebookUserId")
                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                            objBAL.AddQuickPost()
                        End If
                    Next

                    'lblMessage.Text = "Message is Scheduled"
                    BindAllDrafts()
                    BindAllSentItems()
                    BindAllScheduledPosts()
                    ClearData()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Message scheduled successfully');", True)
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Message scheduled successfully');", True)
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub


    Private Sub dtlScheduledPosts_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dtlScheduledPosts.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.DataItem, DataRowView)("sm_Image") <> "" Then
                CType(e.Item.FindControl("divScheduleImage"), HtmlGenericControl).Style.Add("display", "")
                CType(e.Item.FindControl("imgSchedulePhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "resize-tabs.ashx?P=/Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("sm_Image") & "&D=150x100"
                'CType(e.Item.FindControl("imgScheduleLargePhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("sm_Image")
            Else
                CType(e.Item.FindControl("divScheduleImage"), HtmlGenericControl).Style.Add("display", "none")
            End If

            Dim strDateOriginal As DateTime = CType(e.Item.DataItem, DataRowView)("sm_ScheduleDate") & " " & CType(e.Item.DataItem, DataRowView)("sm_ScheduleHour") & ":" & CType(e.Item.DataItem, DataRowView)("sm_ScheduleMinute") & " " & CType(e.Item.DataItem, DataRowView)("sm_ScheduleAMPM")
            If CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone") <> "" Then
                If CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone") <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                    Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone")).ToString()
                    'Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone")).ToString()
                    CType(e.Item.FindControl("lblScheduleDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strConvertedDate)
                Else
                    CType(e.Item.FindControl("lblScheduleDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
                End If
            Else
                CType(e.Item.FindControl("lblScheduleDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
            End If

        End If



    End Sub

    Private Sub dtlDrafts_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dtlDrafts.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'If Not IsDBNull(CType(e.Item.DataItem, DataRowView)("sm_Image")) Then
            If CType(e.Item.DataItem, DataRowView)("sm_Image") <> "" Then
                CType(e.Item.FindControl("divDraftImage"), HtmlGenericControl).Style.Add("display", "")
                CType(e.Item.FindControl("imgDraftPhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "resize-tabs.ashx?P=/Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("sm_Image") & "&D=150x100"
                'CType(e.Item.FindControl("imgDraftLargePhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("sm_Image")
            Else
                CType(e.Item.FindControl("divDraftImage"), HtmlGenericControl).Style.Add("display", "none")
            End If
            Dim strDateOriginal As DateTime = CType(e.Item.DataItem, DataRowView)("sm_ScheduleDate") & " " & CType(e.Item.DataItem, DataRowView)("sm_ScheduleHour") & ":" & CType(e.Item.DataItem, DataRowView)("sm_ScheduleMinute") & " " & CType(e.Item.DataItem, DataRowView)("sm_ScheduleAMPM")
            If CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone") <> "" Then
                If CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone") <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                    Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone")).ToString()
                    CType(e.Item.FindControl("lblDraftDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strConvertedDate)
                Else
                    CType(e.Item.FindControl("lblDraftDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
                End If
            Else
                CType(e.Item.FindControl("lblDraftDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
            End If
        End If
    End Sub

    Private Sub dtlSentItems_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dtlSentItems.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.DataItem, DataRowView)("sm_Image") <> "" Then
                CType(e.Item.FindControl("divSentImage"), HtmlGenericControl).Style.Add("display", "")
                CType(e.Item.FindControl("imgSentPhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "resize-tabs.ashx?P=/Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("sm_Image") & "&D=150x100"
                'CType(e.Item.FindControl("imgSentLargePhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("sm_Image")
            Else
                CType(e.Item.FindControl("divSentImage"), HtmlGenericControl).Style.Add("display", "none")
            End If

            Dim strDateOriginal As DateTime = CType(e.Item.DataItem, DataRowView)("sm_ScheduleDate") & " " & CType(e.Item.DataItem, DataRowView)("sm_ScheduleHour") & ":" & CType(e.Item.DataItem, DataRowView)("sm_ScheduleMinute") & " " & CType(e.Item.DataItem, DataRowView)("sm_ScheduleAMPM")
            If CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone") <> "" Then
                If CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone") <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                    Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone")).ToString()
                    CType(e.Item.FindControl("lblSentItemDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strConvertedDate)
                Else
                    CType(e.Item.FindControl("lblSentItemDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
                End If
            Else
                CType(e.Item.FindControl("lblSentItemDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
            End If


        End If
    End Sub

    Sub ClearData()
        txtMessage.Value = ""
        txtActivationDate.Value = ""
        txtLinkMessage.Value = ""
        txtvideo.Value = ""
        txtNewLibCat.Value = ""
        txtVideoMessage.Value = ""
        ddlTimeZone.SelectedValue = "0"
        selAMPM.Value = "0"
        selActivationMinute.Value = "Minute"
        selActivationHour.Value = "0"
        hdnVideoId.Value = ""
        hdnImage1.Value = ""
        hdnImageChange.Value = ""
        lblMessage.Text = ""
        imgPhoto.Src = ConfigurationManager.AppSettings("AppPath") & "Content/images/no_img.jpg"
        hdnUrl.Value = ""
        For Each item As DataListItem In dstFanPages.Items
            Dim myCheckBox As HtmlInputCheckBox
            Dim HiddenID As HtmlInputHidden
            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
            HiddenID = CType(item.FindControl("hdnPageId"), HtmlInputHidden)
            myCheckBox.Checked = False
        Next
    End Sub

#Region "Daily Auto Post Functions"

    Sub BindAllAutoPost()
        'Try
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            ltrAutoPostError.Text = ""
            Dim ds As New DataSet
            Dim objBAL As New BALSchedulePost
            objBAL.PageIndex = CInt(ViewState("CurrentAutoPostPageIndex"))
            objBAL.FBUserId = Session("FacebookUserId")
            objBAL.TSMAUserId = Session("SiteUserId")
            objBAL.FBPageId = If(Session("strPageId") <> Nothing, Session("strPageId"), "")
            objBAL.CompanyId = 0
            objBAL.IndustryId = 1
            ds = objBAL.GetAutoPostData()
            If ds.Tables(0).Rows.Count > 0 Then
                ltrAutoPostRpt.Text = ""
                dtlAutoPost.DataSource() = ds.Tables(0)
                dtlAutoPost.DataBind()
                pnlClearAll.Visible = True
            Else
                dtlAutoPost.DataSource() = Nothing
                dtlAutoPost.DataBind()
                ltrAutoPostRpt.Text = "No Auto Post Found"
                pnlClearAll.Visible = False
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                ViewState("TotalPageAutoPost") = ds.Tables(1).Rows(0).Item("TotalPage").ToString
                ViewState("TotalRecordsAutoPost") = ds.Tables(1).Rows(0).Item("TotalRec").ToString
            End If

            If ds.Tables(1).Rows.Count > 0 Then

                'imgOnOff.Src = ConfigurationManager.AppSettings("AppPath") & ds.Tables(1).Rows(0).Item("ImageOnOff").ToString
                'ltrOnOffText.Text = ds.Tables(1).Rows(0).Item("textOnOff").ToString
                ltrAutoPostTotal.Text = " (" & ds.Tables(1).Rows(0).Item("TotalRec").ToString & ")"

            Else

                ltrAutoPostTotal.Text = " (0)"
                ' imgOnOff.Src = ConfigurationManager.AppSettings("AppPath") & "Content/images/Off_bullate.png"
                ' ltrOnOffText.Text = "Off"
            End If
            phPagingAutoPost.Controls.Clear()
            GenerateAutoPostControls()
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If

        'Catch ex As Exception
        '    ltrAutoPostError.Text = "Error :" & ex.Message()
        'End Try
    End Sub

    Sub BindAllSentAutoPost()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                ltrSentAutoPostRpt.Text = ""
                Dim ds As New DataSet
                Dim objBAL As New BALSchedulePost
                objBAL.PageIndex = CInt(ViewState("CurrentSentAutoPostPageIndex"))
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.TSMAUserId = Session("SiteUserId")
                ds = objBAL.GetSentAutoPostData()
                If ds.Tables(0).Rows.Count > 0 Then
                    ltrSentAutoPostRpt.Text = ""
                    dtlSentAutoPost.DataSource() = ds.Tables(0)
                    dtlSentAutoPost.DataBind()
                Else
                    dtlSentAutoPost.DataSource() = Nothing
                    dtlSentAutoPost.DataBind()
                    ltrSentAutoPostRpt.Text = "No Sent Auto Post Found"
                End If
                If ds.Tables(1).Rows.Count > 0 Then
                    ViewState("TotalPageSentAutoPost") = ds.Tables(1).Rows(0).Item("TotalPage").ToString
                    ViewState("TotalRecordsSentAutoPost") = ds.Tables(1).Rows(0).Item("TotalRec").ToString
                End If
                phPagingSentAutoPost.Controls.Clear()
                GenerateSentAutoPostControls()
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If

        Catch ex As Exception
            ltrAutoPostError.Text = "Error :" & ex.Message()
        End Try
    End Sub
    Sub AddLibToAutoPost(ByVal sender As Object, ByVal e As CommandEventArgs)
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim objBAL As New BALSchedulePost
            Dim ds As DataSet
            objBAL.LibCatId = e.CommandArgument
            ds = objBAL.GetLibDetailsForAutoPost()

            objBAL.TSMAUserId = Session("SiteUserId")
            objBAL.FBUserId = Session("FacebookUserId")
            objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
            objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
            objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
            objBAL.Message = ds.Tables(0).Rows(0).Item("lib_Template").ToString.Replace("<br>", Chr(10))
            objBAL.Image = ds.Tables(0).Rows(0).Item("lib_Image").ToString
            objBAL.Video = ds.Tables(0).Rows(0).Item("lib_Video").ToString
            objBAL.VideoLink = ds.Tables(0).Rows(0).Item("lib_Video").ToString
            objBAL.VideoId = ds.Tables(0).Rows(0).Item("lib_VideoId").ToString
            objBAL.VideoImage = ds.Tables(0).Rows(0).Item("lib_VideoImage").ToString
            objBAL.ScheduleDate = Date.Now
            objBAL.ScheduleHour = Date.Now.Hour 'If(selAutoPostActivationHour.Value <> "", CInt(selAutoPostActivationHour.Value), 0)
            objBAL.ScheduleMinute = Date.Now.Minute 'If(selAutoPostActivationHour.Value <> "", CInt(selAutoPostActivationHour.Value), 0)
            objBAL.ScheduleAMPM = Date.Now.ToString("tt") 'If(selAutoPostActivationHour.Value <> "", CInt(selAutoPostActivationHour.Value), 0)
            objBAL.ScheduleTimeZone = If(ddlAutoPostTimeZone.SelectedValue <> "0", ddlAutoPostTimeZone.SelectedValue, "")
            objBAL.AutoPostOnOff = 0 'If(hdnAutoPostOnOff.Value <> "", hdnAutoPostOnOff.Value, "0")
            objBAL.AutoPostShuffle = 1
            objBAL.AutoPostStatus = 1
            objBAL.IsPosted = 0
            objBAL.PostType = 1
            objBAL.CreatedDate = Date.Now
            objBAL.UpdatedDate = Date.Now
            objBAL.AddAutoPostMaster()

            BindAllAutoPost()

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Message added in daily Autopost successfully ');", True)
            'ltrAdminLibMsg.Text = "Message is scheduled in Auto Post"

            'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";ShowUserLib(" & e.CommandName & ");", True)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    Private Sub lnkAutoPost_ServerClick(sender As Object, e As System.EventArgs) Handles lnkAutoPost.ServerClick

        Dim objBAL As New BALSchedulePost
        Dim dtAutoPostDate As DateTime
        Dim strDate1 As DateTime
        Dim strConvertToOriginalDate As DateTime
        Dim strDateWithTimezoneSelected As DateTime
        Dim strShortDate As String
        Dim strActivationHours As String
        Dim strActivationMinutes As String
        Dim strAMPM As String = "0"
        Dim strDate As String = ""
        dtAutoPostDate = Date.Now.ToString("dd/MM/yyyy") & " " & selAutoPostActivationHour.Value & ":" & selAutoPostActivationMinute.Value & ":00 " & selAutoPostAMPM.Value  'Date.Now.ToString() Old Code for getdatetime
        'dtAutoPostDate = Date.Now.ToString("MM/dd/yyyy")

        'Response.Write("Original Date : " & dtAutoPostDate & "<br/>")

        If ddlAutoPostTimeZone.SelectedIndex > 0 Then
            If ddlAutoPostTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                strDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dtAutoPostDate, ddlAutoPostTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
            Else
                strDate = dtAutoPostDate
            End If
        End If

        If strDate < Date.Now Then
            strDate = Date.Now.AddDays(1).ToString("dd/MM/yyyy") & " " & selAutoPostActivationHour.Value & ":" & selAutoPostActivationMinute.Value & ":00 " & selAutoPostAMPM.Value  'Date.Now.ToString()
        Else
            strDate = Date.Now.ToString("dd/MM/yyyy") & " " & selAutoPostActivationHour.Value & ":" & selAutoPostActivationMinute.Value & ":00 " & selAutoPostAMPM.Value  'Date.Now.ToString()
        End If

        'strDateWithTimezoneSelected = Convert.ToDateTime(strDate).ToString("MM/dd/yyyy") & " " & selAutoPostActivationHour.Value & ":" & selAutoPostActivationMinute.Value & ":00 " & selAutoPostAMPM.Value


        'Response.Write("Date and time After Converted   : " & strDateWithTimezoneSelected & "<br/>")

        If ddlAutoPostTimeZone.SelectedIndex > 0 Then
            If ddlAutoPostTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                strConvertToOriginalDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDate, ddlAutoPostTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
            Else
                strConvertToOriginalDate = dtAutoPostDate
            End If
        End If

        'Response.Write("Set AutoPost   : " & strConvertToOriginalDate & "<br/>")
        'If ddlAutoPostTimeZone.SelectedIndex > 0 Then
        '    If ddlAutoPostTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
        '        'strDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dtAutoPostDate, ddlAutoPostTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
        '        strDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dtAutoPostDate, ConfigurationManager.AppSettings("ServerTimeZone"), ddlAutoPostTimeZone.SelectedValue).ToString()
        '    Else
        '        strDate = dtAutoPostDate
        '    End If
        'End If

        'Response.Write("Date After Converted   : " & Convert.ToDateTime(strDate).ToString("MM/dd/yyyy") & "<br/>")

        'strDateWithTimezoneSelected = Convert.ToDateTime(strDate).ToString("MM/dd/yyyy") & " " & selAutoPostActivationHour.Value & ":" & selAutoPostActivationMinute.Value & ":00 " & selAutoPostAMPM.Value


        'Response.Write("Date and time After Converted   : " & strDateWithTimezoneSelected & "<br/>")

        'If ddlAutoPostTimeZone.SelectedIndex > 0 Then
        '    If ddlAutoPostTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
        '        strConvertToOriginalDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateWithTimezoneSelected, ddlAutoPostTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone"))
        '    Else
        '        strConvertToOriginalDate = strDateWithTimezoneSelected
        '    End If
        'End If


        'If strConvertToOriginalDate < Date.Now Then
        '    strConvertToOriginalDate = strConvertToOriginalDate.AddDays(1) 'Date.Now.AddDays(1).ToString("MM/dd/yyyy") & " " & selAutoPostActivationHour.Value & ":" & selAutoPostActivationMinute.Value & ":00 " & selAutoPostAMPM.Value  'Date.Now.ToString()
        'Else
        '    strConvertToOriginalDate = strConvertToOriginalDate 'Date.Now.ToString("MM/dd/yyyy") & " " & selAutoPostActivationHour.Value & ":" & selAutoPostActivationMinute.Value & ":00 " & selAutoPostAMPM.Value  'Date.Now.ToString()
        'End If



        'Response.Write("Set AutoPost   : " & strConvertToOriginalDate & "<br/>")
        'Response.End()
        strDate1 = strConvertToOriginalDate 'If((strConvertToOriginalDate <> ""), Convert.ToDateTime(strConvertToOriginalDate), Date.Now)
        strShortDate = strDate1.Date
        strActivationHours = Integer.Parse(strDate1.ToString("hh")).ToString()
        strActivationMinutes = strDate1.Minute.ToString
        strAMPM = strDate1.ToString("tt")

        Dim objBALDel As New BALSchedulePost
        objBALDel.FBUserId = Session("FacebookUserId")
        objBALDel.TSMAUserId = Session("SiteUserId")
        objBALDel.FBPageId = Session("strPageId")
        objBALDel.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
        objBALDel.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
        objBALDel.DeleteAutoPostFanPages()

        For Each AutoPostitem As DataListItem In dstAutoPostFanPages.Items
            Dim AutoPostCheckBox As HtmlInputCheckBox
            AutoPostCheckBox = CType(AutoPostitem.FindControl("autopostchkPage"), HtmlInputCheckBox)
            If AutoPostCheckBox.Checked = True Then

                objBAL.TSMAUserId = Session("SiteUserId")
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.FBPageId = CType(AutoPostitem.FindControl("hdnAutoPostPageId"), HtmlInputHidden).Value
                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                objBAL.ScheduleDate = strShortDate
                objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
                objBAL.ScheduleMinute = If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                objBAL.ScheduleAMPM = If(strAMPM <> "", CStr(strAMPM), "0")
                objBAL.ScheduleTimeZone = If(ddlAutoPostTimeZone.SelectedValue <> "0", ddlAutoPostTimeZone.SelectedValue, "")
                objBAL.AutoPostOnOff = 0
                objBAL.AddAutoPostScheduleData()

                objBAL.TSMAUserId = Session("SiteUserId")
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                objBAL.FBPageId = CType(AutoPostitem.FindControl("hdnAutoPostPageId"), HtmlInputHidden).Value
                objBAL.FBPageName = CType(AutoPostitem.FindControl("hdnAutoPostPageName"), HtmlInputHidden).Value
                objBAL.FBPageImage = CType(AutoPostitem.FindControl("hdnAutoPostImage"), HtmlInputHidden).Value
                objBAL.FBPageAccessToken = CType(AutoPostitem.FindControl("hdnAutoPostAccessToken"), HtmlInputHidden).Value
                objBAL.AddAutoPostPages()

            End If
        Next

        BindAllAutoPost()
        BindAutoPostFanPages()
        BindAutoPostSchedule()
        BindAllSentAutoPost()

        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Autopost scheduled successfully');", True)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Autopost scheduled successfully');", True)
        'Else
        'ltrAutoPostError.Text = "Current date/time is not valid"

    End Sub
    Private Sub lnkAutoPostOnOff_ServerClick(sender As Object, e As System.EventArgs) Handles lnkAutoPostOnOff.ServerClick
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            'Dim ds As DataSet
            Dim objBAL As New BALSchedulePost
            'objBAL.FBUserId = Session("FacebookUserId")
            'objBAL.TSMAUserId = Session("SiteUserId")
            'objBAL.FBPageId = Session("strPageId")
            'objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
            'objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
            'ds = objBAL.GetAutoPostSchedule()
            'If ds.Tables(0).Rows.Count > 0 Then
            '    If ds.Tables(0).Rows(0).Item("apsm_IsAutoPostSet") = 0 Then
            '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowAutoPostOnOff", "ShowAutoPostOnOff('Please set <strong>Auto Post Schedule Time</strong> before <strong>Turn on Auto Post</strong>');", True)
            '        Exit Sub
            '    End If
            'Else
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowAutoPostOnOff", "ShowAutoPostOnOff('Please set <strong>Auto Post Schedule Time</strong> before <strong>Turn on Auto Post</strong>');", True)
            '    Exit Sub
            'End If

            For Each AutoPostitem As DataListItem In dstAutoPostFanPages.Items
                Dim AutoPostCheckBox As HtmlInputCheckBox
                AutoPostCheckBox = CType(AutoPostitem.FindControl("autopostchkPage"), HtmlInputCheckBox)
                If AutoPostCheckBox.Checked = True Then
                    Dim dsAutoPostOnOf As New DataSet
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.TSMAUserId = Session("SiteUserId")
                    objBAL.FBPageId = CType(AutoPostitem.FindControl("hdnAutoPostPageId"), HtmlInputHidden).Value
                    objBAL.CompanyId = GetSetCookies.GetCookie("CompanyId")
                    objBAL.IndustryId = GetSetCookies.GetCookie("IndustryId")
                    dsAutoPostOnOf = objBAL.AutoPostTurnOnOff()
                End If
                'If dsShuffle.Tables(0).Rows(0).Item("Added") = 0 Then
                '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('All available messages in your company library have already been posted');", True)
                '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('All available messages in your company library have already been posted');", True)
                'Else
                '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('All library posts imported successfully');", True)
                '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('All library posts imported successfully');", True)
                'End If
            Next


            'If dsAutoPostOnOf.Tables(0).Rows(0).Item("apsm_OnOff") = 1 Then
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Daily Autopost turned on successfully ');", True)
            'Else
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Daily Autopost turned off successfully ');", True)
            'End If
            pnlAutoPostOn.Visible = True
            pnlAutoPostOff.Visible = False
            BindAllAutoPost()
            BindAutoPostFanPages()
            BindAutoPostSchedule()
            BindAllSentAutoPost()
            BindAllSentAutoPost()
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub



    Private Sub lnkAutoPostShuffle_ServerClick(sender As Object, e As System.EventArgs) Handles lnkAutoPostShuffle.ServerClick
  
        For Each AutoPostitem As DataListItem In dstAutoPostFanPages.Items
            Dim AutoPostCheckBox As HtmlInputCheckBox
            AutoPostCheckBox = CType(AutoPostitem.FindControl("autopostchkPage"), HtmlInputCheckBox)
            If AutoPostCheckBox.Checked = True Then
                'Response.Write("Fan Pages  " & CType(AutoPostitem.FindControl("hdnAutoPostPageId"), HtmlInputHidden).Value & "<br/>")
                Dim objBAL As New BALSchedulePost
                Dim dsShuffle As New DataSet
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.TSMAUserId = Session("SiteUserId")
                objBAL.FBPageId = CType(AutoPostitem.FindControl("hdnAutoPostPageId"), HtmlInputHidden).Value
                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                dsShuffle = objBAL.ShuffleAutoPostData()
            End If
            'If dsShuffle.Tables(0).Rows(0).Item("Added") = 0 Then
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('All available messages in your company library have already been posted');", True)
            '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('All available messages in your company library have already been posted');", True)
            'Else
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('All library posts imported successfully');", True)
            '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('All library posts imported successfully');", True)
            'End If
        Next


        
        BindAllAutoPost()
        BindAllSentAutoPost()
        BindAutoPostSchedule()


        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('data is shuffled successfully in Daily Autopost');", True)
    End Sub
    Sub BindAutoPostFanPages()
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Try
                ltrAutoPostError.Text = ""
                Dim ds As New DataSet
                Dim objBAL As New BALSchedulePost
                objBAL.PageIndex = CInt(ViewState("CurrentAutoPostPageIndex"))
                objBAL.FBUserId = Session("FacebookUserId")
                objBAL.TSMAUserId = Session("SiteUserId")
                objBAL.FBPageId = Session("strPageId")
                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                ds = objBAL.GetAutoPostFanPages()
                If ds.Tables(0).Rows.Count > 0 Then
                    ltrAutoPostPage.Text = ""
                    rptAutoPostfanpages.DataSource() = ds.Tables(0)
                    rptAutoPostfanpages.DataBind()
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        For Each item As DataListItem In dstAutoPostFanPages.Items
                            Dim myCheckBox As HtmlInputCheckBox
                            Dim HiddenID As HtmlInputHidden
                            myCheckBox = CType(item.FindControl("autopostchkPage"), HtmlInputCheckBox)
                            HiddenID = CType(item.FindControl("hdnAutoPostPageId"), HtmlInputHidden)
                            Dim str As String = CStr(HiddenID.Value)
                            If str = ds.Tables(0).Rows(i).Item("ap_FBPageId").ToString Then
                                myCheckBox.Checked = True
                            End If
                        Next
                    Next

                Else
                    rptAutoPostfanpages.DataSource() = Nothing
                    rptAutoPostfanpages.DataBind()
                    ltrAutoPostPage.Text = "No Business Pages Found"
                End If

            Catch ex As Exception
                ltrAutoPostError.Text = "Error :" & ex.Message()
            End Try
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    Sub BindAutoPostSchedule()
        'Try
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            ltrAutoPostError.Text = ""
            Dim ds As DataSet
            Dim objBAL As New BALSchedulePost
            objBAL.FBUserId = Session("FacebookUserId")
            objBAL.TSMAUserId = Session("SiteUserId")
            objBAL.FBPageId = If(Session("strPageId") <> Nothing, Session("strPageId"), "")
            objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
            objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
            ds = objBAL.GetAutoPostSchedule()
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("apsm_IsAutoPostSet") <> 0 Then
                    pnlAutoPostSet.Visible = False
                    pnlAutoPostUpdate.Visible = True
                    Dim strDate As DateTime
                    Dim strDateOriginal As DateTime = ds.Tables(0).Rows(0).Item("apsm_ScheduleDate") & " " & ds.Tables(0).Rows(0).Item("apsm_ScheduleHour") & ":" & ds.Tables(0).Rows(0).Item("apsm_ScheduleMinute") & " " & ds.Tables(0).Rows(0).Item("apsm_ScheduleAMPM")
                    If ds.Tables(0).Rows(0).Item("apsm_ScheduleTimeZone") <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                        Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), ds.Tables(0).Rows(0).Item("apsm_ScheduleTimeZone")).ToString()
                        strDate = String.Format("{0:dd MMM yyyy hh:mm tt}", strConvertedDate)
                    Else
                        strDate = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
                    End If
                    selAutoPostActivationHour.Value = Integer.Parse(strDate.ToString("hh")).ToString() 'ds.Tables(0).Rows(0).Item("sm_ScheduleHour")
                    selAutoPostActivationMinute.Value = strDate.Minute 'ds.Tables(0).Rows(0).Item("sm_ScheduleMinute")
                    selAutoPostAMPM.Value = strDate.ToString("tt") 'ds.Tables(0).Rows(0).Item("sm_ScheduleAMPM")
                    ddlAutoPostTimeZone.SelectedValue = ds.Tables(0).Rows(0).Item("apsm_ScheduleTimeZone")
                Else
                    pnlAutoPostSet.Visible = True
                    pnlAutoPostUpdate.Visible = False
                End If
                If ds.Tables(0).Rows(0).Item("apsm_OnOff") = 0 Then
                    pnlAutoPostOn.Visible = True
                    pnlAutoPostOff.Visible = False
                    pnlOn.Visible = False
                    pnlOff.Visible = True
                Else
                    pnlAutoPostOff.Visible = True
                    pnlAutoPostOn.Visible = False
                    pnlOn.Visible = True
                    pnlOff.Visible = False
                End If
            End If
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
        'Catch ex As Exception
        '    ltrAutoPostError.Text = "Error :" & ex.Message()
        'End Try
    End Sub



    Private Sub lnkAutoPostOff_ServerClick(sender As Object, e As System.EventArgs) Handles lnkAutoPostOff.ServerClick
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            'Dim ds As DataSet
            Dim objBAL As New BALSchedulePost
            'objBAL.FBUserId = Session("FacebookUserId")
            'objBAL.TSMAUserId = Session("SiteUserId")
            'objBAL.FBPageId = Session("strPageId")
            'objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
            'objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
            'ds = objBAL.GetAutoPostSchedule()
            'If ds.Tables(0).Rows.Count > 0 Then
            '    If ds.Tables(0).Rows(0).Item("apsm_IsAutoPostSet") = 0 Then
            '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowAutoPostOnOff", "ShowAutoPostOnOff('Please set <strong>Auto Post Schedule Time</strong> before <strong>Turn on Auto Post</strong>');", True)
            '        Exit Sub
            '    End If
            'Else
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowAutoPostOnOff", "ShowAutoPostOnOff('Please set <strong>Auto Post Schedule Time</strong> before <strong>Turn on Auto Post</strong>');", True)
            '    Exit Sub
            'End If

            For Each AutoPostitem As DataListItem In dstAutoPostFanPages.Items
                Dim AutoPostCheckBox As HtmlInputCheckBox
                AutoPostCheckBox = CType(AutoPostitem.FindControl("autopostchkPage"), HtmlInputCheckBox)
                If AutoPostCheckBox.Checked = True Then
                    Dim dsAutoPostOnOf As New DataSet
                    objBAL.FBUserId = Session("FacebookUserId")
                    objBAL.TSMAUserId = Session("SiteUserId")
                    objBAL.FBPageId = CType(AutoPostitem.FindControl("hdnAutoPostPageId"), HtmlInputHidden).Value
                    objBAL.CompanyId = GetSetCookies.GetCookie("CompanyId")
                    objBAL.IndustryId = GetSetCookies.GetCookie("IndustryId")
                    dsAutoPostOnOf = objBAL.AutoPostTurnOnOff()
                End If
                'If dsShuffle.Tables(0).Rows(0).Item("Added") = 0 Then
                '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('All available messages in your company library have already been posted');", True)
                '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('All available messages in your company library have already been posted');", True)
                'Else
                '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('All library posts imported successfully');", True)
                '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('All library posts imported successfully');", True)
                'End If
            Next

          
            'If dsAutoPostOnOf.Tables(0).Rows(0).Item("apsm_OnOff") = 1 Then
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Daily Autopost turned on successfully ');", True)
            'Else
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Daily Autopost turned off successfully ');", True)
            'End If
            pnlAutoPostOn.Visible = True
            pnlAutoPostOff.Visible = False
            BindAllAutoPost()
            BindAutoPostFanPages()
            BindAutoPostSchedule()
            BindAllSentAutoPost()
            BindAllSentAutoPost()
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub


    Sub DeleteMyAutoPostOld(ByVal sender As Object, ByVal e As CommandEventArgs)
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            Dim objBAlDel As New BALSchedulePost
            objBAlDel.ScheduleId = e.CommandArgument
            objBAlDel.DeleteMyAutoPost()
            BindAllAutoPost()
            BindAutoPostSchedule()
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";ShowUserLib(" & e.CommandName & ");", True)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub


    Sub DeleteMyAutoPost(ByVal sender As Object, ByVal e As CommandEventArgs)
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            'Response.Write(Session("SiteUserId"))

            Dim objBAlDel As New BALSchedulePost
            objBAlDel.ScheduleId = e.CommandArgument
            objBAlDel.TSMAUserId = CInt(Session("SiteUserId"))
            objBAlDel.FBUserId = Session("FacebookUserId")
            objBAlDel.CompanyId = 0
            objBAlDel.IndustryId = 1
            objBAlDel.DeleteMyAutoPostNew()
            BindAllAutoPost()
            BindAutoPostSchedule()
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";ShowUserLib(" & e.CommandName & ");", True)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    Private Sub dtlAutoPost_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlAutoPost.ItemCommand
        If e.CommandName = "Up" Or e.CommandName = "Down" Then
            Try
                Dim objBAl As New BALSchedulePost
                objBAl.AutoPostId = e.CommandArgument
                objBAl.strAutoPostOrder = e.CommandName
                objBAl.UpdateAutoPostOrder()
                ltrAutoPostError.Text = "Order Changed Succefully"
                BindAllAutoPost()
                BindAutoPostSchedule()
            Catch ex As Exception
                ltrAutoPostError.Text = "Error! " & ex.Message
            End Try
        End If
    End Sub

    Private Sub dtlAutoPost_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dtlAutoPost.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.DataItem, DataRowView)("apm_Image") <> "" Then
                CType(e.Item.FindControl("divAutoPostImage"), HtmlGenericControl).Style.Add("display", "")
                CType(e.Item.FindControl("imgAutoPostPhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "resize-tabs.ashx?P=/Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("apm_Image") & "&D=150x100"
                'CType(e.Item.FindControl("imgScheduleLargePhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("sm_Image")
            Else
                CType(e.Item.FindControl("divAutoPostImage"), HtmlGenericControl).Style.Add("display", "none")
            End If

            Dim strDateOriginal As DateTime = CType(e.Item.DataItem, DataRowView)("apm_ScheduleDate") & " " & CType(e.Item.DataItem, DataRowView)("apm_ScheduleHour") & ":" & CType(e.Item.DataItem, DataRowView)("apm_ScheduleMinute") & " " & CType(e.Item.DataItem, DataRowView)("apm_ScheduleAMPM")
            If CType(e.Item.DataItem, DataRowView)("apm_ScheduleTimeZone") <> "" Then
                If CType(e.Item.DataItem, DataRowView)("apm_ScheduleTimeZone") <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                    Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("apm_ScheduleTimeZone")).ToString()
                    'Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone")).ToString()
                    CType(e.Item.FindControl("lblAutoPostDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strConvertedDate)
                Else
                    CType(e.Item.FindControl("lblAutoPostDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
                End If
            End If
        End If
    End Sub
#End Region

    Private Sub dtlSentAutoPost_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dtlSentAutoPost.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.DataItem, DataRowView)("apm_Image") <> "" Then
                CType(e.Item.FindControl("divSentAutoPostImage"), HtmlGenericControl).Style.Add("display", "")
                CType(e.Item.FindControl("imgSentAutoPostPhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "resize-tabs.ashx?P=/Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("apm_Image") & "&D=150x100"
                'CType(e.Item.FindControl("imgScheduleLargePhoto"), HtmlImage).Src = ConfigurationManager.AppSettings("AppPath") & "Content/uploads/images/" & CType(e.Item.DataItem, DataRowView)("sm_Image")
            Else
                CType(e.Item.FindControl("divSentAutoPostImage"), HtmlGenericControl).Style.Add("display", "none")
            End If

            Dim strDateOriginal As DateTime = CType(e.Item.DataItem, DataRowView)("apm_ScheduleDate") & " " & CType(e.Item.DataItem, DataRowView)("apm_ScheduleHour") & ":" & CType(e.Item.DataItem, DataRowView)("apm_ScheduleMinute") & " " & CType(e.Item.DataItem, DataRowView)("apm_ScheduleAMPM")
            If CType(e.Item.DataItem, DataRowView)("apm_ScheduleTimeZone") <> "" Then
                If CType(e.Item.DataItem, DataRowView)("apm_ScheduleTimeZone") <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                    Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("apm_ScheduleTimeZone")).ToString()
                    'Dim strConvertedDate As DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("sm_ScheduleTimeZone")).ToString()
                    CType(e.Item.FindControl("lblSentAutoPostDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strConvertedDate)
                Else
                    CType(e.Item.FindControl("lblSentAutoPostDate"), HtmlGenericControl).InnerText = String.Format("{0:dd MMM yyyy hh:mm tt}", strDateOriginal)
                End If
            End If

        End If
    End Sub



    Private Sub lnkClearAll_ServerClick(sender As Object, e As System.EventArgs) Handles lnkClearAll.ServerClick
        ltrAutoPostError.Text = ""

        Dim objBAL As New BALSchedulePost
        objBAL.FBUserId = Session("FacebookUserId")
        objBAL.TSMAUserId = Session("SiteUserId")
        objBAL.FBPageId = If(Session("strPageId") <> Nothing, Session("strPageId"), "")
        objBAL.CompanyId = GetSetCookies.GetCookie("CompanyId") '0 '
        objBAL.IndustryId = GetSetCookies.GetCookie("IndustryId") '1 '
        objBAL.ClearAllAutoPostData()
        BindAllAutoPost()
        BindAutoPostFanPages()
        BindAutoPostSchedule()
        ClearAutoPostData()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('All Auto Posts deleted successfully');", True)
    End Sub

    Sub ClearAutoPostData()
        selAutoPostActivationHour.Value = "0"
        selAutoPostActivationMinute.Value = "Minute"
        selAutoPostAMPM.Value = "0"
        ddlAutoPostTimeZone.SelectedValue = "0"
        pnlOn.Visible = False
        pnlOff.Visible = True
        pnlAutoPostOn.Visible = True
        pnlAutoPostSet.Visible = True
        pnlAutoPostUpdate.Visible = False
        pnlAutoPostOff.Visible = False
        For Each item As DataListItem In dstAutoPostFanPages.Items
            Dim myCheckBox As HtmlInputCheckBox
            Dim HiddenID As HtmlInputHidden
            myCheckBox = CType(item.FindControl("autopostchkPage"), HtmlInputCheckBox)
            HiddenID = CType(item.FindControl("hdnPageId"), HtmlInputHidden)
            myCheckBox.Checked = False
        Next
    End Sub


End Class