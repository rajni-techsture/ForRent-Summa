Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports DataAccessLayer.DataAccessLayer
Imports System.IO
Imports Facebook
Imports System.Threading

Public Class scheduler_new
    Inherits RoutablePage
    Implements IRequiresSessionState
    Dim objLib As New Library
    Public strSelectionType As String = ""
    Public intAutoPostOnOff As Integer
    Dim strExt As String = ""
    Dim strPhoto As String = ""
    Dim strVideoThumb As String = "", strVideo As String = ""
    Dim strVideoFileNameWithoutExtension As String = ""
    Dim strPostid As String = ""
    Dim strmessage As String
    Dim strUnixtimestamp As Long
    Dim scheduleID As String = "0"
   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoginCheck.LoginSessionCheck()
        'Try
        If Not Page.IsPostBack Then
            ViewState("CurrentSentAutoPostPageIndex") = 1
            ViewState("CurrentPageIndex") = 1
            ViewState("CurrentAutoPostPageIndex") = 1
            ViewState("CurrentPageIndexSent") = 1
            ViewState("CurrentPageIndexScheduled") = 1
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
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
                        drpFanPages.DataSource = dv
                        drpFanPages.DataValueField = "id"
                        drpFanPages.DataTextField = "name"
                        drpFanPages.DataBind()
                        plcData.Visible = True
                        plcNoData.Visible = False
                        plcError.Visible = False
                    Else
                        'Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=2&at=" & Session("hdnToken") & ""
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide13;", ";openNewWin('" & strUrl & "');", True)
                        dstFanPages.DataSource = Nothing
                        dstFanPages.DataBind()
                        drpFanPages.DataSource = Nothing
                        drpFanPages.DataBind()
                        plcData.Visible = False
                        plcNoData.Visible = True
                        plcError.Visible = False
                    End If
                    drpFanPages.Items.Insert(0, New ListItem("-- select FanPage --", "0"))
                Else
                    Dim dtTable As New DataTable
                    dtTable.Columns.Add(New DataColumn("name", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("picture", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("access_token", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("link", Type.GetType("System.String")))


                    ' Below Code is for add schedule Post to personal page so put in comment for live server

                    'Dim dtRow As DataRow = dtTable.NewRow
                    'dtRow("name") = fUser.name
                    'dtRow("id") = fUser.id
                    'dtRow("picture") = fUser.picture.data.url
                    'dtRow("access_token") = Session("FacebookAccessToken")
                    'dtRow("link") = fUser.link
                    'dtTable.Rows.Add(dtRow)


                    'comment ends over here

                    For Each item As FanPage.m_data In fPage.data
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
                        dstFanPages.DataSource = dv
                        dstFanPages.DataBind()
                        drpFanPages.DataSource = dv
                        drpFanPages.DataValueField = "id"
                        drpFanPages.DataTextField = "name"
                        drpFanPages.DataBind()
                        plcData.Visible = True
                        plcNoData.Visible = False
                    Else
                        'Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=2&at=" & Session("hdnToken") & ""
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide12;", ";openNewWin('" & strUrl & "');", True)
                        dstFanPages.DataSource = Nothing
                        dstFanPages.DataBind()
                        drpFanPages.DataSource = Nothing
                        drpFanPages.DataBind()
                        plcData.Visible = False
                        plcNoData.Visible = True
                    End If
                    drpFanPages.Items.Insert(0, New ListItem("-- select FanPage --", "0"))
                End If


            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
            BindAllDrafts()
            BindAllSentItems()
            BindAllScheduledPosts()

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
                'BindDraftData(Id)
                'BindSentItemData(Id)
                BindScheduledPostData(Id)
            End If
            objLib.FBUserId = Session("FacebookUserId")
            strSelectionType = objLib.GetUSerSelectionType
            BindLibraryCategories()
        Else
            GenreateControls()
            GenreateControlsSent()
            GenreateControlsScheduled()
        End If

        'Catch ex As Exception
        '    If ex.Message.Contains("The remote server returned an error: (400)") Then
        '        Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=2&at=" & Session("hdnToken") & ""
        '        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide11;", ";openNewWin('" & strUrl & "');", True)
        '    Else
        '        lblMessage.Text = "Error: " & ex.Message
        '    End If
        '    'plcData.Visible = False
        '    'plcNoData.Visible = False
        '    'plcError.Visible = True
        'End Try
    End Sub


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
                    txtvideo.Value = ds.Tables(0).Rows(0).Item("sm_Link")
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
                                myCheckBox.Disabled = False
                            Else
                                myCheckBox.Disabled = True
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
                                myCheckBox.Disabled = False
                            Else
                                myCheckBox.Disabled = True
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
                    hdnPostType.Value = ds.Tables(0).Rows(0).Item("sm_PostType")
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
                                myCheckBox.Disabled = False
                            Else
                                myCheckBox.Disabled = True
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
                objBAL.FBPageId = ViewState("SelectedPage") 'drpFanPages.SelectedValue
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
                objBAL.FBPageId = ViewState("SelectedPage") 'drpFanPages.SelectedValue
                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 

                ds = objBAL.GetAllSentItems
                If ds.Tables(0).Rows.Count > 0 Then
                    ltrSentItems.Text = ""
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
                objBAL.FBPageId = ViewState("SelectedPage") 'drpFanPages.SelectedValue
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
                'If CInt(sender.CommandArgument = 1) Then
                '    hdnSetTab.Value = 2
                '    ltrSchedluledTotal.Text = 2
                'ElseIf CInt(sender.CommandArgument = 2) Then
                '    hdnSetTab.Value = 3
                '    ltrSchedluledTotal.Text = 3
                'ElseIf CInt(sender.CommandArgument = 3) Then
                '    hdnSetTab.Value = 4
                '    ltrSchedluledTotal.Text = 4
                'End If
                If sender.CommandName <> "" Then
                    Dim objDel As New BALSchedulePost
                    objDel.ScheduleId = CInt(sender.CommandName)
                    Dim dsFanPages1 As New DataSet
                    dsFanPages1 = objDel.GetScheduledDataFanPages()

                    If dsFanPages1.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsFanPages1.Tables(0).Rows.Count - 1
                            Try
                                Dim fb = New FacebookClient()
                                Dim args1 = New Dictionary(Of String, Object)()
                                args1("access_token") = dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString
                                args1("uid") = dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageId").ToString
                                fb.Delete(dsFanPages1.Tables(0).Rows(j).Item("sp_PostId").ToString, args1)

                            Catch ex As Exception
                                Dim dataAccess1 As New DALDataAccess()
                                dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                                dataAccess1.AddParam("@e_id", SqlDbType.Int, CInt(sender.CommandName))
                                dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageId").ToString)
                                dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageName").ToString)
                                dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString)
                                dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, ex.Message)
                                dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "deleting post data from FB")
                                dataAccess1.ExecuteNonQuery()
                            End Try
                        Next
                    End If

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
        hdnSetTab.Value = "4"
        BindAllDrafts()

    End Sub
    Private Sub lnkPage_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndex") <> 1) Then
            ViewState("CurrentPageIndex") = ViewState("CurrentPageIndex") - 1
        End If
        hdnSetTab.Value = "4"
        BindAllDrafts()

    End Sub
    Private Sub lnkPage_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndex") < ViewState("TotalPage")) Then
            ViewState("CurrentPageIndex") = ViewState("CurrentPageIndex") + 1
        Else
            ViewState("CurrentPageIndex") = ViewState("CurrentPageIndex")
        End If
        hdnSetTab.Value = "4"
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
        hdnSetTab.Value = "3"
        BindAllSentItems()

    End Sub
    Private Sub lnkPageSent_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndexSent") <> 1) Then
            ViewState("CurrentPageIndexSent") = ViewState("CurrentPageIndexSent") - 1
        End If
        hdnSetTab.Value = "3"
        BindAllSentItems()

    End Sub
    Private Sub lnkPageSent_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndexSent") < ViewState("TotalPageSent")) Then
            ViewState("CurrentPageIndexSent") = ViewState("CurrentPageIndexSent") + 1
        Else
            ViewState("CurrentPageIndexSent") = ViewState("CurrentPageIndexSent")
        End If
        hdnSetTab.Value = "3"
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
        hdnSetTab.Value = "2"
        BindAllScheduledPosts()

    End Sub
    Private Sub lnkPageScheduled_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndexScheduled") <> 1) Then
            ViewState("CurrentPageIndexScheduled") = ViewState("CurrentPageIndexScheduled") - 1
        End If
        hdnSetTab.Value = "2"
        BindAllScheduledPosts()

    End Sub
    Private Sub lnkPageScheduled_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndexScheduled") < ViewState("TotalPageScheduled")) Then
            ViewState("CurrentPageIndexScheduled") = ViewState("CurrentPageIndexScheduled") + 1
        Else
            ViewState("CurrentPageIndexScheduled") = ViewState("CurrentPageIndexScheduled")
        End If
        hdnSetTab.Value = "2"
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


    'Private Sub lnkSaveDraft_ServerClick(sender As Object, e As System.EventArgs) Handles lnkSaveDraft.ServerClick
    '    Try
    '        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
    '            hdnMakeDateString.Value = txtActivationDate.Value & " " & selActivationHour.Value & ":" & selActivationMinute.Value & ":00 " & selAMPM.Value  'Date.Now.ToString()
    '            If ddlTimeZone.SelectedIndex > 0 Then
    '                If ddlTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
    '                    lblTimeZone.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(hdnMakeDateString.Value, ddlTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
    '                Else
    '                    lblTimeZone.Text = hdnMakeDateString.Value
    '                End If
    '            End If

    '            Dim strDate1 As DateTime = If((lblTimeZone.Text <> ""), Convert.ToDateTime(lblTimeZone.Text), Date.Now)
    '            Dim strActivationHours As String = Integer.Parse(strDate1.ToString("hh")).ToString()
    '            Dim strActivationMinutes As String = strDate1.Minute
    '            Dim strmessage As String = txtMessage.Value
    '            Dim strDate As String = strDate1.Date
    '            Dim strAMPM As String = strDate1.ToString("tt")
    '            Dim strExt As String = ""
    '            Dim strPhoto As String = ""
    '            Dim strVideoThumb As String = "", strVideo As String = ""
    '            Dim strVideoFileNameWithoutExtension As String = ""

    '            If photo.PostedFile.ContentLength > 0 Then
    '                Dim uploadContent = photo.PostedFile.ContentLength / 1000
    '                strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
    '                'If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
    '                '    strVideoFileNameWithoutExtension = "V-" & String.Format("{0:MMddyyyyhhmmsstt}", Now)
    '                '    If strExt = ".rm" Or strExt = ".wma" Or strExt = ".mp3" Or strExt = ".mov" Or strExt = ".wav" Or strExt = ".wmv" Or strExt = ".mpg" Or strExt = ".avi" Or strExt = ".flv" Then
    '                '        If strExt <> ".flv" Then
    '                '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
    '                '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
    '                '            myprocess.StartInfo.UseShellExecute = True
    '                '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog.bat")
    '                '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
    '                '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & strExt & " -s -m"
    '                '            myprocess.Start()
    '                '        Else
    '                '            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\") & strVideoFileNameWithoutExtension & ".flv")
    '                '            Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process
    '                '            myprocess.StartInfo.UseShellExecute = True
    '                '            myprocess.StartInfo.FileName = Server.MapPath("~\VideoBlog-flv.bat")
    '                '            myprocess.StartInfo.WorkingDirectory = Server.MapPath("~\")
    '                '            myprocess.StartInfo.Arguments = " " & strVideoFileNameWithoutExtension & ".flv" & " -s -m"
    '                '            myprocess.Start()
    '                '        End If
    '                '        strVideoThumb = strVideoFileNameWithoutExtension & ".jpg"
    '                '        strVideo = strVideoFileNameWithoutExtension & ".flv"
    '                '    End If

    '                '    Dim photopath As String = Server.MapPath("~/" & "Content/uploads/" & strVideo)
    '                '    hdnImage.Value = photopath
    '                '    lblVideoText.Visible = True
    '                '    imgPhoto.Visible = False
    '                '    lblVideoText.Text = hdnImage.Value
    '                '    'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
    '                '    Dim str As String = ""
    '                '    lblMessage.Text = "Video Uploaded Successfully"
    '                'Else
    '                If uploadContent > 10000 Then
    '                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "ShowErrorPopUp", "OpenDiv();", True)
    '                    Exit Sub
    '                Else
    '                    If strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png" Then
    '                        Dim strDate12 As Date = "1/1/1900"
    '                        strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now())) & strExt
    '                        photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\images\" & strPhoto))
    '                        Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto)
    '                        'lblMessage.Text = "Photo Uploaded Successfully"
    '                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Photo Uploaded Successfully');", True)
    '                    Else
    '                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('File must be .jpg or .gif or .png or .jpeg or .tif or .bmp');", True)
    '                        'lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
    '                        Exit Sub
    '                    End If
    '                End If
    '            ElseIf hdnImage1.Value <> "" Then
    '                strPhoto = hdnImage1.Value
    '            End If

    '            'Try

    '            If RequestContext.RouteData.Values("sm_Id") <> "" Then
    '                Dim objBAL As New BALSchedulePost
    '                Dim Id As String
    '                Id = RequestContext.RouteData.Values("sm_Id")
    '                objBAL.DraftId = Id
    '                objBAL.TSMAUserId = Session("SiteUserId")
    '                objBAL.FBUserId = Session("FacebookUserId")
    '                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
    '                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 

    '                objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
    '                objBAL.Message = CStr(Replace(txtMessage.Value, Chr(10), "<br>"))
    '                objBAL.Image = If(strPhoto <> "", strPhoto, "")
    '                objBAL.Video = If(strVideo <> "", strVideo, "")
    '                objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
    '                objBAL.VideoId = hdnVideoId.Value
    '                objBAL.VideoImage = hdnUrl.Value
    '                objBAL.ScheduleDate = If((strDate <> ""), Convert.ToDateTime(strDate), Date.Now)
    '                objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
    '                objBAL.ScheduleMinute = If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
    '                objBAL.ScheduleAMPM = If(strAMPM <> "0", strAMPM, "")
    '                objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
    '                objBAL.IsPosted = 0
    '                objBAL.PostType = 2
    '                objBAL.UpdatedDate = Date.Now
    '                objBAL.UpdateDrafts()


    '                objBAL.DeleteFanPages(Id)
    '                For Each item As DataListItem In dstFanPages.Items
    '                    Dim myCheckBox As HtmlInputCheckBox
    '                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)

    '                    If myCheckBox.Checked = True Then
    '                        objBAL.ScheduleId = Id
    '                        objBAL.FBUserId = Session("FacebookUserId")
    '                        objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
    '                        objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
    '                        objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
    '                        objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
    '                        objBAL.AddQuickPost()
    '                    End If
    '                Next
    '                BindAllDrafts()
    '                BindAllSentItems()
    '                BindAllScheduledPosts()
    '                ClearData()
    '                'lblMessage.Text = "Drafts Updated successfully"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Draft saved successfully');", True)
    '            Else
    '                Dim objBAL As New BALSchedulePost
    '                Dim ds As New DataSet
    '                Dim scheduleID As String
    '                objBAL.TSMAUserId = Session("SiteUserId")
    '                objBAL.FBUserId = Session("FacebookUserId")
    '                objBAL.FBPageId = ""
    '                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
    '                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
    '                objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
    '                objBAL.Message = CStr(Replace(txtMessage.Value, Chr(10), "<br>"))
    '                objBAL.Image = If(strPhoto <> "", strPhoto, "")
    '                objBAL.Video = If(strVideo <> "", strVideo, "")
    '                objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
    '                objBAL.VideoId = hdnVideoId.Value
    '                objBAL.VideoImage = hdnUrl.Value
    '                objBAL.ScheduleDate = If((strDate <> ""), Convert.ToDateTime(strDate), Date.Now)
    '                objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
    '                objBAL.ScheduleMinute = If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
    '                objBAL.ScheduleAMPM = If(strAMPM <> "0", strAMPM, "")
    '                objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
    '                objBAL.IsPosted = 0
    '                objBAL.PostType = 2
    '                objBAL.CreatedDate = Date.Now
    '                objBAL.UpdatedDate = Date.Now



    '                ds = objBAL.AddQuickPostMaster()

    '                scheduleID = ds.Tables(0).Rows(0).Item(0).ToString()

    '                For Each item As DataListItem In dstFanPages.Items
    '                    Dim myCheckBox As HtmlInputCheckBox
    '                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
    '                    If myCheckBox.Checked = True Then

    '                        objBAL.TSMAUserId = Session("SiteUserId")
    '                        objBAL.FBUserId = Session("FacebookUserId")
    '                        objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
    '                        objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
    '                        objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
    '                        objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
    '                        objBAL.Message = CStr(Replace(txtMessage.Value, Chr(10), "<br>"))
    '                        objBAL.Image = If(strPhoto <> "", strPhoto, "")
    '                        objBAL.Video = If(strVideo <> "", strVideo, "")
    '                        objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
    '                        objBAL.VideoId = hdnVideoId.Value
    '                        objBAL.VideoImage = hdnUrl.Value
    '                        objBAL.ScheduleDate = If((strDate <> ""), Convert.ToDateTime(strDate), Date.Now)
    '                        objBAL.ScheduleHour = If(strActivationHours <> "", CInt(strActivationHours), 0)
    '                        objBAL.ScheduleMinute = If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
    '                        objBAL.ScheduleAMPM = If(strAMPM <> "0", strAMPM, "")
    '                        objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
    '                        objBAL.IsPosted = 0
    '                        objBAL.PostType = 2
    '                        objBAL.CreatedDate = Date.Now
    '                        objBAL.UpdatedDate = Date.Now



    '                        ds = objBAL.AddQuickPostMaster()

    '                        scheduleID = ds.Tables(0).Rows(0).Item(0).ToString()

    '                        objBAL.ScheduleId = CInt(scheduleID)
    '                        objBAL.FBUserId = Session("FacebookUserId")
    '                        objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
    '                        objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
    '                        objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
    '                        objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
    '                        objBAL.AddQuickPost()
    '                    End If
    '                Next
    '                'lblMessage.Text = "Drafts Saved successfully"
    '                BindAllDrafts()
    '                BindAllSentItems()
    '                BindAllScheduledPosts()
    '                ClearData()
    '                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Draft saved successfully');", True)
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Draft saved successfully');", True)
    '            End If

    '        Else
    '            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
    '        End If
    '    Catch ex As Exception
    '        lblMessage.Text = "Error: " & ex.Message
    '    End Try
    'End Sub
    Private Sub lnkSaveDraft_ServerClick(sender As Object, e As System.EventArgs) Handles lnkSaveDraft.ServerClick
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            If RequestContext.RouteData.Values("sm_Id") <> "" AndAlso hdnPostType.Value = "drafts" Then
                Dim objBAL As New BALSchedulePost
                objBAL.DeleteDraftsFanPages(RequestContext.RouteData.Values("sm_Id"))
                PostData(3)
            Else
                PostData(3)
            End If
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Draft saved successfully');", True)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

    Private Sub lnkPost_ServerClick(sender As Object, e As System.EventArgs) Handles lnkPost.ServerClick
        'Try
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            PostData(1)
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Message Is Posted Successfully To Your Selected Business Page(s)');", True)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
        'Catch ex As Exception
        '    lblMessage.Text = "Error: " & ex.Message
        'End Try
    End Sub

    Private Sub lnkScheduledPost_ServerClick(sender As Object, e As System.EventArgs) Handles lnkScheduledPost.ServerClick
        'Try
        Dim Id As String
        Id = RequestContext.RouteData.Values("sm_Id")
        Dim objBAL As New BALSchedulePost
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            If RequestContext.RouteData.Values("sm_Id") <> "" AndAlso hdnPostType.Value <> "drafts" Then


                objBAL.ScheduleId = CInt(Id)
                Dim dsFanPages1 As New DataSet
                dsFanPages1 = objBAL.GetScheduledDataFanPages()

                If dsFanPages1.Tables(0).Rows.Count > 0 Then
                    For j As Integer = 0 To dsFanPages1.Tables(0).Rows.Count - 1
                        Try
                            Dim fb = New FacebookClient()
                            Dim args1 = New Dictionary(Of String, Object)()
                            args1("access_token") = dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString
                            args1("uid") = dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageId").ToString
                            fb.Delete(dsFanPages1.Tables(0).Rows(j).Item("sp_PostId").ToString.ToString, args1)

                        Catch ex As Exception
                            Dim dataAccess1 As New DALDataAccess()
                            dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                            dataAccess1.AddParam("@e_id", SqlDbType.Int, Id)
                            dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageId").ToString)
                            dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageName").ToString)
                            dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString)
                            dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, ex.Message)
                            dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "deleting post data from FB")
                            dataAccess1.ExecuteNonQuery()
                        End Try
                    Next
                End If

                objBAL.DeleteFanPages(Id)

                PostData(2)
            ElseIf RequestContext.RouteData.Values("sm_Id") <> "" AndAlso hdnPostType.Value = "drafts" Then
                objBAL.DeleteDraftsFanPages(Id)
                PostData(2)
            Else
                PostData(2)
            End If
            
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Message scheduled successfully');", True)
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
        'Catch ex As Exception
        '    lblMessage.Text = "Error: " & ex.Message
        'End Try
    End Sub

    Private Sub PostData(ByVal intTaskId As Integer)
        Try
            Dim AccessToken As String = Session("FacebookAccessToken")
            Dim objBAL As New BALSchedulePost



            hdnMakeDateString.Value = txtActivationDate.Value & " " & selActivationHour.Value & ":" & selActivationMinute.Value & selAMPM.Value  'Date.Now.ToString()
            If ddlTimeZone.SelectedIndex > 0 Then
                '    If ddlTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                '        lblTimeZone.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(hdnMakeDateString.Value, ddlTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
                lblTimeZone.Text = hdnMakeDateString.Value
            Else
                lblTimeZone.Text = ""
                '    End If
            End If
            Dim strDate1 As DateTime = If((lblTimeZone.Text <> ""), Convert.ToDateTime(lblTimeZone.Text), Date.Now)
            Dim strActivationHours As String = Integer.Parse(strDate1.ToString("hh")).ToString()
            Dim strActivationMinutes As String = strDate1.Minute.ToString
            strmessage = txtMessage.Value
            Dim strDate As String = strDate1.Date

            Dim strAMPM As String = strDate1.ToString("tt")


            Dim dtAutoPostDate As DateTime
            Dim strDateNew As DateTime
            Dim strConvertToOriginalDate As DateTime
            Dim strShortDate As Date
            Dim strActivationHoursNew As String
            Dim strActivationMinutesNew As String
            Dim strAMPMNew As String = "0"
            Dim strDateNew1 As DateTime

            Dim photopath As String

            dtAutoPostDate = strDate1.ToString("MM/dd/yyyy") & " " & strActivationHours & ":" & strActivationMinutes & ":00 " & strAMPM  'Date.Now.ToString() Old Code for getdatetime

            If ddlTimeZone.SelectedIndex > 0 Then
                If ddlTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                    strDateNew = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dtAutoPostDate, ddlTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
                Else
                    strDateNew = dtAutoPostDate
                End If

                If strDateNew.Date = Date.Now.Date Then
                    Dim startTime As DateTime = DateTime.Now
                    Dim endTime As DateTime = strDateNew
                    'Dim span As TimeSpan = endTime.Subtract(startTime)
                    Dim timeDiff As Long = DateDiff(DateInterval.Minute, startTime, endTime)
                    ' If span.Minutes <= 15 Then
                    If timeDiff <= 14 Then
                        'strDateNew = Date.Now.AddDays(1).ToString("MM/dd/yyyy") & " " & strActivationHours & ":" & strActivationMinutes & ":00 " & strAMPM   'Date.Now.ToString()
                        'lblMessage.Text = ""
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ErrorAlert", "ErrorAlert('Please select a schedule time at least 15 minutes from now');", True)
                        Exit Sub
                        'Else
                        '    strDateNew = dtAutoPostDate
                    End If
                ElseIf Convert.ToDateTime(strDateNew) < Date.Now Then
                    'strDateNew = Date.Now.AddDays(1).ToString("MM/dd/yyyy") & " " & strActivationHours & ":" & strActivationMinutes & ":00 " & strAMPM  'Date.Now.ToString()
                    'lblMessage.Text = ""
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ErrorAlert", "ErrorAlert('Date selected is in the past.  Please select a date that is in the future.');", True)
                    Exit Sub
                    'Else
                    '    strDateNew = dtAutoPostDate
                End If
            Else
                strDateNew = dtAutoPostDate
            End If





                'If ddlTimeZone.SelectedIndex > 0 Then
                '    If ddlTimeZone.SelectedValue <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                '        strDateNew = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateNew, ddlTimeZone.SelectedValue, ConfigurationManager.AppSettings("ServerTimeZone"))
                '    Else
                '        strDateNew = Convert.ToDateTime(strDateNew)
                '    End If
                'End If


                strDateNew1 = strDateNew 'If((strConvertToOriginalDate <> ""), Convert.ToDateTime(strConvertToOriginalDate), Date.Now)



                strShortDate = strDateNew1.Date
                strActivationHoursNew = Integer.Parse(strDateNew1.ToString("hh")).ToString()
                strActivationMinutesNew = strDateNew1.Minute.ToString
                strAMPMNew = strDateNew1.ToString("tt")

                If photo.PostedFile.ContentLength > 0 Then
                    Dim uploadContent As Integer = photo.PostedFile.ContentLength / 1000
                    strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
                    If uploadContent > 10000 Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "ShowErrorPopUp", "OpenDiv();", True)
                        Exit Sub
                    Else
                        If strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png" Then
                            Dim strDate12 As Date = "1/1/1900"
                            strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now())) & strExt
                            photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\images\" & strPhoto))
                            photopath = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto)
                            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
                            'Dim str As String = ""

                        Else
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('File must be .jpg or .gif or .png or .jpeg or .tif or .bmp ');", True)
                            Exit Sub
                        End If
                    End If
                ElseIf hdnImage1.Value <> "" Then
                    strPhoto = hdnImage1.Value
                    photopath = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto) 'hdnImageChange.Value
                    'Response.Write("Without Edit : " & photopath)
                    'Response.End()
                End If

            Dim ds As New DataSet
            If hdnPageSelected.Value <> "" Then
                For Each item As DataListItem In dstFanPages.Items
                    Dim myCheckBox As HtmlInputCheckBox
                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                    If myCheckBox.Checked = True Then
                        Try
                            If intTaskId <> 3 Then
                                If (intTaskId = 2 And CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value <> Session("FacebookUserId")) Or intTaskId = 1 Then
                                    If photo.PostedFile.ContentLength > 0 Or hdnImage1.Value <> "" Then
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
                                            If intTaskId = 2 Then
                                                strUnixtimestamp = DateDiff(DateInterval.Second, #1/1/1970#, strDateNew1) '(strDateNew1 - New DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds
                                                upload.Add("scheduled_publish_time", strUnixtimestamp)
                                                upload.Add("published", 0)
                                            End If
                                            'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                            'fbapp.Post(path, upload)
                                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                            Dim obj = TryCast(fbapp.Post(path, upload), IDictionary(Of String, Object))
                                            strPostid = DirectCast(obj("id"), String)

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
                                            If intTaskId = 2 Then
                                                strUnixtimestamp = DateDiff(DateInterval.Second, #1/1/1970#, strDateNew1) '(strDateNew1 - New DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds
                                                upload.Add("scheduled_publish_time", strUnixtimestamp)
                                                upload.Add("published", 0)
                                            End If
                                            'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                            'fbapp.Post(path, upload)
                                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                            Dim obj = TryCast(fbapp.Post(path, upload), IDictionary(Of String, Object))
                                            strPostid = DirectCast(obj("id"), String)
                                        End If


                                    Else
                                        Dim args = New Dictionary(Of String, Object)()
                                        args("message") = strmessage
                                        If txtvideo.Value <> "" Then
                                            args("link") = txtvideo.Value
                                        End If
                                        If intTaskId = 2 Then
                                            strUnixtimestamp = DateDiff(DateInterval.Second, #1/1/1970#, strDateNew1) '(strDateNew1 - New DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds
                                            args("scheduled_publish_time") = strUnixtimestamp
                                            args("published") = 0
                                        End If
                                        Dim regex As New Regex(",")
                                        Dim str As String = ""
                                        Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                                        Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                                        Dim obj = TryCast(fbapp.Post(path, args), IDictionary(Of String, Object))
                                        strPostid = DirectCast(obj("id"), String)
                                    End If
                                End If
                            End If


                            objBAL.TSMAUserId = Session("SiteUserId")
                            objBAL.FBUserId = Session("FacebookUserId")
                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                            'objBAL.PostId = strPostid
                            objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId")
                            objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId")
                            objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                            objBAL.Message = CStr(Replace(strmessage, Chr(10), "<br>"))
                            objBAL.Image = If(strPhoto <> "", strPhoto, "")
                            objBAL.Video = If(strVideo <> "", strVideo, "")
                            objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                            objBAL.VideoId = hdnVideoId.Value
                            objBAL.VideoImage = hdnUrl.Value
                            objBAL.ScheduleDate = strShortDate 'If((strShortDate <> ""), Convert.ToDateTime(strShortDate), Date.Now)
                            objBAL.ScheduleHour = If(strActivationHoursNew <> "", CInt(strActivationHoursNew), 0)
                            objBAL.ScheduleMinute = strActivationMinutesNew 'If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                            objBAL.ScheduleAMPM = If(strAMPMNew <> "0", strAMPMNew, "")
                            objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                            If intTaskId = 2 And CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value = Session("FacebookUserId") Then
                                objBAL.IsPersonalPage = 1
                            Else
                                objBAL.IsPersonalPage = 0
                            End If
                            objBAL.CreatedDate = Date.Now
                            objBAL.UpdatedDate = Date.Now

                            If intTaskId = 1 Then
                                objBAL.IsPosted = 1
                                objBAL.PostType = 0
                                ds = objBAL.AddQuickPostMaster()
                                scheduleID = ds.Tables(0).Rows(0).Item(0).ToString()
                            ElseIf intTaskId = 2 Then
                                If RequestContext.RouteData.Values("sm_id") <> "" AndAlso hdnPostType.Value <> "drafts" Then
                                    scheduleID = RequestContext.RouteData.Values("sm_Id")
                                    objBAL.DraftId = CInt(scheduleID)
                                    objBAL.IsPosted = 0
                                    objBAL.PostType = 1
                                    objBAL.UpdateDrafts()
                                Else
                                    objBAL.IsPosted = 0
                                    objBAL.PostType = 1
                                    ds = objBAL.AddQuickPostMaster()
                                    scheduleID = ds.Tables(0).Rows(0).Item(0).ToString()
                                End If
                            ElseIf intTaskId = 3 Then
                                If RequestContext.RouteData.Values("sm_Id") <> "" Then
                                    scheduleID = RequestContext.RouteData.Values("sm_Id")
                                    'objBAL.DeleteFanPages(CInt(scheduleID))
                                    objBAL.DraftId = CInt(scheduleID)
                                    objBAL.IsPosted = 0
                                    objBAL.PostType = 2
                                    objBAL.UpdateDrafts()
                                Else
                                    objBAL.IsPosted = 0
                                    objBAL.PostType = 2
                                    ds = objBAL.AddQuickPostMaster()
                                    scheduleID = ds.Tables(0).Rows(0).Item(0).ToString()
                                End If
                            End If

                            objBAL.ScheduleId = CInt(scheduleID)
                            objBAL.FBUserId = Session("FacebookUserId")
                            objBAL.PostId = strPostid
                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                            objBAL.AddQuickPost()
                        Catch ex As Exception
                            Dim dataAccess1 As New DALDataAccess()
                            dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                            dataAccess1.AddParam("@e_id", SqlDbType.Int, CInt(scheduleID))
                            dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value)
                            dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value)
                            dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                            dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, ex.Message)
                            dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "Scheduling Data on Facebook")
                            dataAccess1.ExecuteNonQuery()
                        End Try
                    End If
                Next

                If intTaskId = 1 Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Message Is Posted Successfully To Your Selected Business Page(s)');", True)
                ElseIf intTaskId = 2 Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Message scheduled successfully');", True)
                ElseIf intTaskId = 3 Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Draft Saved Successfully');", True)
                End If
            Else
                If intTaskId = 3 Then
                    objBAL.TSMAUserId = Session("SiteUserId")
                    objBAL.FBUserId = Session("FacebookUserId")

                    ' Please Hide Below 4 Lines For PRoduction Server this is for personal page and for pageid
                    objBAL.IsPersonalPage = 0
                    objBAL.FBPageId = ""

                    ' comment ends over here

                    'objBAL.PostId = strPostid
                    objBAL.CompanyId = GetSetCookies.GetCookie("CompanyId")
                    objBAL.IndustryId = GetSetCookies.GetCookie("IndustryId")
                    objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                    objBAL.Message = CStr(Replace(strmessage, Chr(10), "<br>"))
                    objBAL.Image = If(strPhoto <> "", strPhoto, "")
                    objBAL.Video = If(strVideo <> "", strVideo, "")
                    objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                    objBAL.VideoId = hdnVideoId.Value
                    objBAL.VideoImage = hdnUrl.Value
                    objBAL.ScheduleDate = strShortDate 'If((strShortDate <> ""), Convert.ToDateTime(strShortDate), Date.Now)
                    objBAL.ScheduleHour = If(strActivationHoursNew <> "", CInt(strActivationHoursNew), 0)
                    objBAL.ScheduleMinute = strActivationMinutesNew 'If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                    objBAL.ScheduleAMPM = If(strAMPMNew <> "0", strAMPMNew, "")
                    objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                    objBAL.CreatedDate = Date.Now
                    objBAL.UpdatedDate = Date.Now
                    If RequestContext.RouteData.Values("sm_Id") <> "" Then
                        scheduleID = CInt(RequestContext.RouteData.Values("sm_Id"))
                        objBAL.DraftId = scheduleID
                        objBAL.IsPosted = 0
                        objBAL.PostType = 2
                        objBAL.UpdateDrafts()
                        objBAL.DeleteFanPages(scheduleID)
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Draft Updated Successfully');", True)
                    Else
                        objBAL.IsPosted = 0
                        objBAL.PostType = 2
                        ds = objBAL.AddQuickPostMaster()
                        scheduleID = CInt(ds.Tables(0).Rows(0).Item(0).ToString())
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Draft Saved Successfully');", True)
                    End If
                End If
            End If

                BindAllDrafts()
                BindAllSentItems()
                BindAllScheduledPosts()
                ClearData()
                'If intTaskId = 1 Then
                '    Dim ds As New DataSet
                '    For Each item As DataListItem In dstFanPages.Items
                '        Try
                '            Dim myCheckBox As HtmlInputCheckBox
                '            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                '            If myCheckBox.Checked = True Then

                '                objBAL.TSMAUserId = Session("SiteUserId")
                '                objBAL.FBUserId = Session("FacebookUserId")
                '                objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                'objBAL.PostId = strPostid
                '                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                '                objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                '                objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                '                objBAL.Message = CStr(Replace(strmessage, Chr(10), "<br>"))
                '                objBAL.Image = If(strPhoto <> "", strPhoto, "")
                '                objBAL.Video = If(strVideo <> "", strVideo, "")
                '                objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                '                objBAL.VideoId = hdnVideoId.Value
                '                objBAL.VideoImage = hdnUrl.Value
                '                objBAL.ScheduleDate = strShortDate 'If((strShortDate <> ""), Convert.ToDateTime(strShortDate), Date.Now)
                '                objBAL.ScheduleHour = If(strActivationHoursNew <> "", CInt(strActivationHoursNew), 0)
                '                objBAL.ScheduleMinute = strActivationMinutesNew 'If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                '                objBAL.ScheduleAMPM = If(strAMPMNew <> "0", strAMPMNew, "")
                '                objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                '                objBAL.IsPosted = 1
                '                objBAL.PostType = 0
                '                objBAL.CreatedDate = Date.Now
                '                objBAL.UpdatedDate = Date.Now


                '                ds = objBAL.AddQuickPostMaster()
                '                scheduleID = ds.Tables(0).Rows(0).Item(0).ToString()

                '                If photo.PostedFile.ContentLength > 0 Or hdnImage1.Value <> "" Then
                '                    'For Each item As DataListItem In dstFanPages.Items
                '                    '    Dim myCheckBox As HtmlInputCheckBox
                '                    '    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                '                    '    If myCheckBox.Checked = True Then
                '                    Dim path1 As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums" '"225274570816748/photos"
                '                    Dim Albumpath As String = "https://graph.facebook.com/" & CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums?fields=id,name&access_token={0}"
                '                    Dim fbapp1 = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                    Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                    Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                    Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value))
                '                    Dim response1 As WebResponse = request1.GetResponse()
                '                    Dim stream As Stream = response1.GetResponseStream()
                '                    Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                '                    Dim fAlbums As New Albums()
                '                    fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                '                    Dim listAlbums As New List(Of Albums.m_data)

                '                    For Each item1 As Albums.m_data In fAlbums.data
                '                        listAlbums.Add(item1)
                '                    Next
                '                    Dim cnt As Integer = listAlbums.Count
                '                    Dim flag As Integer
                '                    Dim aid As String = ""
                '                    For i As Integer = 0 To cnt - 1
                '                        If listAlbums.Item(i).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                '                            aid = listAlbums.Item(i).id
                '                            flag = 0
                '                            Exit For
                '                        Else
                '                            flag = 1
                '                        End If
                '                    Next

                '                    If flag = 1 Then
                '                        upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                '                        Dim album As JsonObject = fbapp1.Post(path1, upload1)

                '                        Dim albumID As String = album("id")

                '                        Dim path As String = albumID & "/photos" '"225274570816748/photos"
                '                        Dim mediaObject As New FacebookMediaObject() With { _
                '                            .FileName = photopath, _
                '                            .ContentType = "image/jpg" _
                '                        }
                '                        Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                '                        mediaObject.SetValue(fileBytes)
                '                        Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                        upload.Add("message", strmessage)
                '                        upload.Add("image", mediaObject)
                '                        If intTaskId = 2 Then
                '                            upload.Add("scheduled_publish_time", strUnixtimestamp)
                '                            upload.Add("published", 0)
                '                        End If
                '                        'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        'fbapp.Post(path, upload)
                '                        Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        Dim obj = TryCast(fbapp.Post(path, upload), IDictionary(Of String, Object))
                '                        strPostid = DirectCast(obj("id"), String)

                '                        objBAL.ScheduleId = scheduleID
                '                        objBAL.FBUserId = Session("FacebookUserId")
                '                        objBAL.PostId = strPostid
                '                        objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                        objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                '                        objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                '                        objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '                        objBAL.AddQuickPost()
                '                    Else
                '                        Dim path As String = aid & "/photos" '"225274570816748/photos"
                '                        Dim mediaObject As New FacebookMediaObject() With { _
                '                            .FileName = photopath, _
                '                            .ContentType = "image/jpg" _
                '                        }
                '                        Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                '                        mediaObject.SetValue(fileBytes)
                '                        Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                        upload.Add("message", strmessage)
                '                        upload.Add("image", mediaObject)
                '                        If intTaskId = 2 Then
                '                            upload.Add("scheduled_publish_time", strUnixtimestamp)
                '                            upload.Add("published", 0)
                '                        End If
                '                        'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        'fbapp.Post(path, upload)
                '                        Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        Dim obj = TryCast(fbapp.Post(path, upload), IDictionary(Of String, Object))
                '                        strPostid = DirectCast(obj("id"), String)

                '                        objBAL.ScheduleId = scheduleID
                '                        objBAL.FBUserId = Session("FacebookUserId")
                '                        objBAL.PostId = strPostid
                '                        objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                        objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                '                        objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                '                        objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '                        objBAL.AddQuickPost()
                '                    End If

                '                    'End If
                '                    'Next
                '                Else
                '                    Dim args = New Dictionary(Of String, Object)()
                '                    args("message") = strmessage
                '                    If txtvideo.Value <> "" Then
                '                        args("link") = txtvideo.Value
                '                    End If
                '                    If intTaskId = 2 Then
                '                        args("scheduled_publish_time") = strUnixtimestamp
                '                        args("published") = 0
                '                    End If
                '                    Dim regex As New Regex(",")
                '                    Dim str As String = ""
                '                    'For Each item As DataListItem In dstFanPages.Items
                '                    '    Dim myCheckBox As HtmlInputCheckBox
                '                    '    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                '                    'If myCheckBox.Checked = True Then
                '                    Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                '                    'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                    'fbapp.Post(path, args)
                '                    Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                    Dim obj = TryCast(fbapp.Post(path, args), IDictionary(Of String, Object))
                '                    strPostid = DirectCast(obj("id"), String)

                '                    objBAL.ScheduleId = scheduleID
                '                    objBAL.FBUserId = Session("FacebookUserId")
                '                    objBAL.PostId = strPostid
                '                    objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                    objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                '                    objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                '                    objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '                    objBAL.AddQuickPost()
                '                    'End If
                '                    'Next
                '                End If
                '            End If
                '        Catch ex As Exception
                '            Dim dataAccess1 As New DALDataAccess()
                '            dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                '            dataAccess1.AddParam("@e_id", SqlDbType.Int, scheduleID)
                '            dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value)
                '            dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value)
                '            dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '            dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, ex.Message)
                '            dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "Scheduling Data on Facebook")
                '            dataAccess1.ExecuteNonQuery()
                '        End Try

                '    Next
                'Else
                '    If RequestContext.RouteData.Values("sm_Id") <> "" Then
                '        scheduleID = RequestContext.RouteData.Values("sm_Id")

                '        objBAL.DraftId = scheduleID
                '        objBAL.TSMAUserId = Session("SiteUserId")
                '        objBAL.FBUserId = Session("FacebookUserId")
                '        'objBAL.PostId = strPostid
                '        objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                '        objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                '        objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                '        objBAL.Message = CStr(Replace(strmessage, Chr(10), "<br>"))
                '        objBAL.Image = If(strPhoto <> "", strPhoto, "")
                '        objBAL.Video = If(strVideo <> "", strVideo, "")
                '        objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                '        objBAL.VideoId = hdnVideoId.Value
                '        objBAL.VideoImage = hdnUrl.Value
                '        objBAL.ScheduleDate = strShortDate 'If((strShortDate <> ""), Convert.ToDateTime(strShortDate), Date.Now)
                '        objBAL.ScheduleHour = If(strActivationHoursNew <> "", CInt(strActivationHoursNew), 0)
                '        objBAL.ScheduleMinute = strActivationMinutesNew 'If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                '        objBAL.ScheduleAMPM = If(strAMPMNew <> "0", strAMPMNew, "")
                '        objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                '        objBAL.IsPosted = 0
                '        objBAL.PostType = 1
                '        objBAL.UpdatedDate = Date.Now
                '        objBAL.UpdateDrafts()

                '        For Each item As DataListItem In dstFanPages.Items
                '            Try
                '                Dim myCheckBox As HtmlInputCheckBox
                '                myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                '                If myCheckBox.Checked = True Then
                '                    If photo.PostedFile.ContentLength > 0 Or hdnImage1.Value <> "" Then
                '                        'For Each item As DataListItem In dstFanPages.Items
                '                        '    Dim myCheckBox As HtmlInputCheckBox
                '                        '    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                '                        '    If myCheckBox.Checked = True Then
                '                        Dim path1 As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums" '"225274570816748/photos"
                '                        Dim Albumpath As String = "https://graph.facebook.com/" & CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums?fields=id,name&access_token={0}"
                '                        Dim fbapp1 = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                        Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                        Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value))
                '                        Dim response1 As WebResponse = request1.GetResponse()
                '                        Dim stream As Stream = response1.GetResponseStream()
                '                        Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                '                        Dim fAlbums As New Albums()
                '                        fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                '                        Dim listAlbums As New List(Of Albums.m_data)

                '                        For Each item1 As Albums.m_data In fAlbums.data
                '                            listAlbums.Add(item1)
                '                        Next
                '                        Dim cnt As Integer = listAlbums.Count
                '                        Dim flag As Integer
                '                        Dim aid As String = ""
                '                        For i As Integer = 0 To cnt - 1
                '                            If listAlbums.Item(i).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                '                                aid = listAlbums.Item(i).id
                '                                flag = 0
                '                                Exit For
                '                            Else
                '                                flag = 1
                '                            End If
                '                        Next

                '                        If flag = 1 Then
                '                            upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                '                            Dim album As JsonObject = fbapp1.Post(path1, upload1)

                '                            Dim albumID As String = album("id")

                '                            Dim path As String = albumID & "/photos" '"225274570816748/photos"
                '                            Dim mediaObject As New FacebookMediaObject() With { _
                '                                .FileName = photopath, _
                '                                .ContentType = "image/jpg" _
                '                            }
                '                            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                '                            mediaObject.SetValue(fileBytes)
                '                            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                            upload.Add("message", strmessage)
                '                            upload.Add("image", mediaObject)
                '                            If intTaskId = 2 Then
                '                                upload.Add("scheduled_publish_time", strUnixtimestamp)
                '                                upload.Add("published", 0)
                '                            End If
                '                            'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                            'fbapp.Post(path, upload)
                '                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                            Dim obj = TryCast(fbapp.Post(path, upload), IDictionary(Of String, Object))
                '                            strPostid = DirectCast(obj("id"), String)

                '                            objBAL.ScheduleId = scheduleID
                '                            objBAL.FBUserId = Session("FacebookUserId")
                '                            objBAL.PostId = strPostid
                '                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                '                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                '                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '                            objBAL.AddQuickPost()
                '                        Else
                '                            Dim path As String = aid & "/photos" '"225274570816748/photos"
                '                            Dim mediaObject As New FacebookMediaObject() With { _
                '                                .FileName = photopath, _
                '                                .ContentType = "image/jpg" _
                '                            }
                '                            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                '                            mediaObject.SetValue(fileBytes)
                '                            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                            upload.Add("message", strmessage)
                '                            upload.Add("image", mediaObject)
                '                            If intTaskId = 2 Then
                '                                upload.Add("scheduled_publish_time", strUnixtimestamp)
                '                                upload.Add("published", 0)
                '                            End If
                '                            'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                            'fbapp.Post(path, upload)
                '                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                            Dim obj = TryCast(fbapp.Post(path, upload), IDictionary(Of String, Object))
                '                            strPostid = DirectCast(obj("id"), String)

                '                            objBAL.ScheduleId = scheduleID
                '                            objBAL.FBUserId = Session("FacebookUserId")
                '                            objBAL.PostId = strPostid
                '                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                '                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                '                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '                            objBAL.AddQuickPost()
                '                        End If

                '                        'End If
                '                        'Next
                '                    Else
                '                        Dim args = New Dictionary(Of String, Object)()
                '                        args("message") = strmessage
                '                        If txtvideo.Value <> "" Then
                '                            args("link") = txtvideo.Value
                '                        End If
                '                        If intTaskId = 2 Then
                '                            args("scheduled_publish_time") = strUnixtimestamp
                '                            args("published") = 0
                '                        End If
                '                        Dim regex As New Regex(",")
                '                        Dim str As String = ""
                '                        'For Each item As DataListItem In dstFanPages.Items
                '                        '    Dim myCheckBox As HtmlInputCheckBox
                '                        '    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                '                        'If myCheckBox.Checked = True Then
                '                        Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                '                        'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        'fbapp.Post(path, args)
                '                        Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        Dim obj = TryCast(fbapp.Post(path, args), IDictionary(Of String, Object))
                '                        strPostid = DirectCast(obj("id"), String)

                '                        objBAL.ScheduleId = scheduleID
                '                        objBAL.FBUserId = Session("FacebookUserId")
                '                        objBAL.PostId = strPostid
                '                        objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                        objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                '                        objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                '                        objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '                        objBAL.AddQuickPost()
                '                        'End If
                '                        'Next
                '                    End If
                '                End If
                '            Catch ex As Exception
                '                Dim dataAccess1 As New DALDataAccess()
                '                dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                '                dataAccess1.AddParam("@e_id", SqlDbType.Int, scheduleID)
                '                dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value)
                '                dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value)
                '                dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, ex.Message)
                '                dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "Scheduling Data on Facebook")
                '                dataAccess1.ExecuteNonQuery()
                '            End Try
                '        Next
                '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveScheduleAlert('Message is updated successfully in schedule post');", True)
                '        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Message is updated successfully in schedule post');", True)
                '    Else

                '        Dim ds As New DataSet

                '        For Each item As DataListItem In dstFanPages.Items
                '            Try
                '                Dim myCheckBox As HtmlInputCheckBox
                '                myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                '                If myCheckBox.Checked = True Then
                '                    objBAL.TSMAUserId = Session("SiteUserId")
                '                    objBAL.FBUserId = Session("FacebookUserId")
                '                    'objBAL.PostId = strPostid
                '                    objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                    objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 
                '                    objBAL.IndustryId = 1 'GetSetCookies.GetCookie("IndustryId") 
                '                    objBAL.FBApplicationAccessToken = Session("FacebookAccessToken")
                '                    objBAL.Message = CStr(Replace(strmessage, Chr(10), "<br>"))
                '                    objBAL.Image = If(strPhoto <> "", strPhoto, "")
                '                    objBAL.Video = If(strVideo <> "", strVideo, "")
                '                    objBAL.VideoLink = If(txtvideo.Value <> "", txtvideo.Value, "")
                '                    objBAL.VideoId = hdnVideoId.Value
                '                    objBAL.VideoImage = hdnUrl.Value
                '                    objBAL.ScheduleDate = strShortDate 'If((strShortDate <> ""), Convert.ToDateTime(strShortDate), Date.Now)
                '                    objBAL.ScheduleHour = If(strActivationHoursNew <> "", CInt(strActivationHoursNew), 0)
                '                    objBAL.ScheduleMinute = strActivationMinutesNew 'If(strActivationMinutes <> "", CInt(strActivationMinutes), 0)
                '                    objBAL.ScheduleAMPM = If(strAMPMNew <> "0", strAMPMNew, "")
                '                    objBAL.ScheduleTimeZone = If(ddlTimeZone.SelectedValue <> "0", ddlTimeZone.SelectedValue, "")
                '                    objBAL.IsPosted = 0
                '                    objBAL.PostType = 1
                '                    objBAL.CreatedDate = Date.Now
                '                    objBAL.UpdatedDate = Date.Now

                '                    ds = objBAL.AddQuickPostMaster()
                '                    scheduleID = ds.Tables(0).Rows(0).Item(0).ToString()

                '                    If photo.PostedFile.ContentLength > 0 Or hdnImage1.Value <> "" Then
                '                        'For Each item As DataListItem In dstFanPages.Items
                '                        '    Dim myCheckBox As HtmlInputCheckBox
                '                        '    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                '                        '    If myCheckBox.Checked = True Then
                '                        Dim path1 As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums" '"225274570816748/photos"
                '                        Dim Albumpath As String = "https://graph.facebook.com/" & CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/albums?fields=id,name&access_token={0}"
                '                        Dim fbapp1 = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                        Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                        Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value))
                '                        Dim response1 As WebResponse = request1.GetResponse()
                '                        Dim stream As Stream = response1.GetResponseStream()
                '                        Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                '                        Dim fAlbums As New Albums()
                '                        fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                '                        Dim listAlbums As New List(Of Albums.m_data)

                '                        For Each item1 As Albums.m_data In fAlbums.data
                '                            listAlbums.Add(item1)
                '                        Next
                '                        Dim cnt As Integer = listAlbums.Count
                '                        Dim flag As Integer
                '                        Dim aid As String = ""
                '                        For i As Integer = 0 To cnt - 1
                '                            If listAlbums.Item(i).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                '                                aid = listAlbums.Item(i).id
                '                                flag = 0
                '                                Exit For
                '                            Else
                '                                flag = 1
                '                            End If
                '                        Next

                '                        If flag = 1 Then
                '                            upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                '                            Dim album As JsonObject = fbapp1.Post(path1, upload1)

                '                            Dim albumID As String = album("id")

                '                            Dim path As String = albumID & "/photos" '"225274570816748/photos"
                '                            Dim mediaObject As New FacebookMediaObject() With { _
                '                                .FileName = photopath, _
                '                                .ContentType = "image/jpg" _
                '                            }
                '                            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                '                            mediaObject.SetValue(fileBytes)
                '                            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                            upload.Add("message", strmessage)
                '                            upload.Add("image", mediaObject)
                '                            If intTaskId = 2 Then
                '                                upload.Add("scheduled_publish_time", strUnixtimestamp)
                '                                upload.Add("published", 0)
                '                            End If
                '                            'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                            'fbapp.Post(path, upload)
                '                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                            Dim obj = TryCast(fbapp.Post(path, upload), IDictionary(Of String, Object))
                '                            strPostid = DirectCast(obj("id"), String)

                '                            objBAL.ScheduleId = scheduleID
                '                            objBAL.FBUserId = Session("FacebookUserId")
                '                            objBAL.PostId = strPostid
                '                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                '                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                '                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '                            objBAL.AddQuickPost()
                '                        Else
                '                            Dim path As String = aid & "/photos" '"225274570816748/photos"
                '                            Dim mediaObject As New FacebookMediaObject() With { _
                '                                .FileName = photopath, _
                '                                .ContentType = "image/jpg" _
                '                            }
                '                            Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                '                            mediaObject.SetValue(fileBytes)
                '                            Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                '                            upload.Add("message", strmessage)
                '                            upload.Add("image", mediaObject)
                '                            If intTaskId = 2 Then
                '                                upload.Add("scheduled_publish_time", strUnixtimestamp)
                '                                upload.Add("published", 0)
                '                            End If
                '                            'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                            'fbapp.Post(path, upload)
                '                            Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                            Dim obj = TryCast(fbapp.Post(path, upload), IDictionary(Of String, Object))
                '                            strPostid = DirectCast(obj("id"), String)

                '                            objBAL.ScheduleId = scheduleID
                '                            objBAL.FBUserId = Session("FacebookUserId")
                '                            objBAL.PostId = strPostid
                '                            objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                            objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                '                            objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                '                            objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '                            objBAL.AddQuickPost()
                '                        End If

                '                        'End If
                '                        'Next
                '                    Else
                '                        Dim args = New Dictionary(Of String, Object)()
                '                        args("message") = strmessage
                '                        If txtvideo.Value <> "" Then
                '                            args("link") = txtvideo.Value
                '                        End If
                '                        If intTaskId = 2 Then
                '                            args("scheduled_publish_time") = strUnixtimestamp
                '                            args("published") = 0
                '                        End If
                '                        Dim regex As New Regex(",")
                '                        Dim str As String = ""
                '                        'For Each item As DataListItem In dstFanPages.Items
                '                        '    Dim myCheckBox As HtmlInputCheckBox
                '                        '    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
                '                        'If myCheckBox.Checked = True Then
                '                        Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/feed"
                '                        'Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        'fbapp.Post(path, args)
                '                        Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                        Dim obj = TryCast(fbapp.Post(path, args), IDictionary(Of String, Object))
                '                        strPostid = DirectCast(obj("id"), String)

                '                        objBAL.ScheduleId = scheduleID
                '                        objBAL.FBUserId = Session("FacebookUserId")
                '                        objBAL.PostId = strPostid
                '                        objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '                        objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                '                        objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                '                        objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '                        objBAL.AddQuickPost()
                '                        'End If
                '                        'Next
                '                    End If

                '                End If
                '            Catch ex As Exception
                '                Dim dataAccess1 As New DALDataAccess()
                '                dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                '                dataAccess1.AddParam("@e_id", SqlDbType.Int, scheduleID)
                '                dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value)
                '                dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value)
                '                dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
                '                dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, ex.Message)
                '                dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "Scheduling Data on Facebook")
                '                dataAccess1.ExecuteNonQuery()
                '            End Try
                '        Next
                '    End If
                'End If

                'BindAllDrafts()
                'BindAllSentItems()
                'BindAllScheduledPosts()
                'ClearData()
        Catch ex As Exception
            lblMessage.Text = "Error" & ex.Message.ToString
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

    Private Sub drpFanPages_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpFanPages.SelectedIndexChanged
        hdnSetTab.Value = "2"
        ViewState("SelectedPage") = drpFanPages.SelectedValue
        BindAllDrafts()
        BindAllSentItems()
        BindAllScheduledPosts()
    End Sub

   
End Class