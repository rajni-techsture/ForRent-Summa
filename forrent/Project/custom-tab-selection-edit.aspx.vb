﻿Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer
Imports Facebook
Imports System.Threading

Public Class custom_tab_selection_edit
    Inherits System.Web.UI.Page
    Public strFBUserId As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoginCheck.LoginSessionCheck()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                strFBUserId = Session("FacebookUserId").ToString
                hdnFBUserId.Value = Session("FacebookUserId").ToString
                lblMessage.Text = ""
                If Not Page.IsPostBack Then
                    Dim obj As New BALCustomTab
                    Dim ds1 As New DataSet
                    'obj.Page = "/custom-tab"
                    'ds1 = obj.GetVideoTutorial()
                    obj.CustomTabId = Request.QueryString("ctId")
                    ds1 = obj.GetVideoTutorialByMasterID()
                    Dim videostring As String
                    If ds1.Tables(0).Rows.Count > 0 Then
                        videostring = Replace(ds1.Tables(0).Rows(0).Item("ctm_Video").ToString, "watch?v=", "v/")
                        spnVideo.InnerHtml = "<object style='height: 335px; width: 555px'><param name='movie' value='" & videostring & "'><param name='allowFullScreen' value='true'><param name='allowScriptAccess' value='always'><param name='wmode' value='transparent'><embed src='" & videostring & "' type='application/x-shockwave-flash' allowfullscreen='true' allowScriptAccess='always' width='555' height='335'></object>"
                    End If
                    If Request.QueryString("ctId") <> "" And IsNumeric(Request.QueryString("ctId")) Then
                        BindFanPages()
                        BindSavedCustomTab()
                    End If
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            If ex.Message.Contains("The remote server returned an error: (400)") Then
                Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide13;", ";openNewWin('" & strUrl & "');", True)
            Else
                lblMessage.Text = "Error: " & ex.Message
            End If
        End Try
    End Sub
#Region "Bind Fan Pages"
    Sub BindFanPages()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim accessToken As String = Session("FacebookAccessToken")
                Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
                Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
                Dim url As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,link,category,access_token&return_ssl_resources=true&access_token={0}"
                Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, accessToken))
                Dim fbResponse As WebResponse = fbRequest.GetResponse()
                Dim stream As Stream = fbResponse.GetResponseStream()
                Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FanPage))

                Dim fPage As New FanPage()
                fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), FanPage)

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
                                If Not item.picture Is Nothing Then
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
                                            '   NonFanPageTable.Visible = False
                                        End If
                                    Next
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
                        dstShareFanPages.DataSource = dv
                        dstShareFanPages.DataBind()
                        plcShareData.Visible = True
                        plcShareNoData.Visible = False
                        plcData.Visible = True
                        plcNoData.Visible = False
                        plcError.Visible = False
                        plcShareError.Visible = False
                    Else
                        dstFanPages.DataSource = Nothing
                        dstFanPages.DataBind()
                        dstShareFanPages.DataSource = Nothing
                        dstShareFanPages.DataBind()
                        plcShareData.Visible = False
                        plcShareNoData.Visible = True
                        plcData.Visible = False
                        plcNoData.Visible = True
                        plcError.Visible = False
                        plcShareError.Visible = False
                        'Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide11;", ";openNewWin('" & strUrl & "');", True)
                    End If
                Else
                    Dim dtTable As New DataTable
                    dtTable.Columns.Add(New DataColumn("name", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("picture", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("access_token", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("link", Type.GetType("System.String")))

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
                        dstShareFanPages.DataSource = dv
                        dstShareFanPages.DataBind()
                        plcShareData.Visible = True
                        plcShareNoData.Visible = False
                        plcData.Visible = True
                        plcNoData.Visible = False
                    Else
                        dstFanPages.DataSource = Nothing
                        dstFanPages.DataBind()
                        dstShareFanPages.DataSource = Nothing
                        dstShareFanPages.DataBind()
                        plcShareData.Visible = False
                        plcShareNoData.Visible = True
                        plcData.Visible = False
                        plcNoData.Visible = True
                        'Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide13;", ";openNewWin('" & strUrl & "');", True)
                    End If
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            'plcShareData.Visible = False
            'plcShareNoData.Visible = False
            'plcData.Visible = False
            'plcNoData.Visible = False
            'plcError.Visible = True
            'plcShareError.Visible = True
            'lblMessage.Text = "Facebook is experiencing problems at this time. Please save your work and try to publish later."
            If ex.Message.Contains("The remote server returned an error: (400)") Then
                Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide12;", ";openNewWin('" & strUrl & "');", True)
            Else
                lblMessage.Text = "Error: " & ex.Message
            End If
        End Try
    End Sub
#End Region

#Region "Bind Selected Fan Pages"
    Sub BindSelectedFanPages(ByVal strFanPageId As String)
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim accessToken As String = Session("FacebookAccessToken")
                Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
                Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
                Dim url As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,link,category,access_token&return_ssl_resources=true&access_token={0}"
                Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, accessToken))
                Dim fbResponse As WebResponse = fbRequest.GetResponse()
                Dim stream As Stream = fbResponse.GetResponseStream()
                Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FanPage))

                Dim fPage As New FanPage()
                fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), FanPage)

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
                                If Not item.picture Is Nothing Then
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
                        End If
                    Next
                    dtTable.TableName = "fanpages"
                    Dim dv As DataView = New DataView(dtTable)
                    dv.Sort = "name"

                    If dv.Count > 0 Then
                        dstFanPages.DataSource = dv
                        dstFanPages.DataBind()
                        dstShareFanPages.DataSource = dv
                        dstShareFanPages.DataBind()
                        plcShareData.Visible = True
                        plcShareNoData.Visible = False
                        plcData.Visible = True
                        plcNoData.Visible = False
                        plcError.Visible = False
                        plcShareError.Visible = False
                    Else
                        dstFanPages.DataSource = Nothing
                        dstFanPages.DataBind()
                        dstShareFanPages.DataSource = Nothing
                        dstShareFanPages.DataBind()
                        plcShareData.Visible = False
                        plcShareNoData.Visible = True
                        plcData.Visible = False
                        plcNoData.Visible = True
                        plcError.Visible = False
                        plcShareError.Visible = False
                        'Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide14;", ";openNewWin('" & strUrl & "');", True)
                    End If
                Else
                    Dim dtTable As New DataTable
                    dtTable.Columns.Add(New DataColumn("name", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("picture", Type.GetType("System.String")))
                    dtTable.Columns.Add(New DataColumn("access_token", Type.GetType("System.String")))
                    'dtTable.Columns.Add(New DataColumn("link", Type.GetType("System.String")))

                    For Each item As FanPage.m_data In fPage.data
                        If Not item.access_token Is Nothing Then
                            If Not item.link Is Nothing Then
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
                        End If
                    Next
                    dtTable.TableName = "fanpages"
                    Dim dv As DataView = New DataView(dtTable)
                    dv.Sort = "name"

                    If dv.Count > 0 Then
                        dstFanPages.DataSource = dv
                        dstFanPages.DataBind()
                        dstShareFanPages.DataSource = dv
                        dstShareFanPages.DataBind()
                        plcShareData.Visible = True
                        plcShareNoData.Visible = False
                        plcData.Visible = True
                        plcNoData.Visible = False
                    Else
                        dstFanPages.DataSource = Nothing
                        dstFanPages.DataBind()
                        dstShareFanPages.DataSource = Nothing
                        dstShareFanPages.DataBind()
                        plcShareData.Visible = False
                        plcShareNoData.Visible = True
                        plcData.Visible = False
                        plcNoData.Visible = True
                        'Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide14;", ";openNewWin('" & strUrl & "');", True)
                    End If
                End If
                For Each item As DataListItem In dstFanPages.Items
                    Dim myCheckBox As HtmlInputRadioButton
                    Dim HiddenID As New HtmlInputHidden
                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputRadioButton)
                    HiddenID = CType(item.FindControl("hdnPageId"), HtmlInputHidden)
                    Dim str As String = CStr(HiddenID.Value)
                    If str = strFanPageId Then
                        myCheckBox.Checked = True
                    Else
                        myCheckBox.Disabled = True
                    End If
                Next

                For Each Shareitem As DataListItem In dstShareFanPages.Items
                    Dim myShareCheckBox As HtmlInputRadioButton
                    Dim HiddenShareID As New HtmlInputHidden
                    myShareCheckBox = CType(Shareitem.FindControl("chkPage"), HtmlInputRadioButton)
                    HiddenShareID = CType(Shareitem.FindControl("hdnPageId"), HtmlInputHidden)
                    Dim strShare As String = CStr(HiddenShareID.Value)
                    If strShare = strFanPageId Then
                        myShareCheckBox.Checked = True
                    Else
                        myShareCheckBox.Disabled = True
                    End If
                Next
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            If ex.Message.Contains("The remote server returned an error: (400)") Then
                Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide11;", ";openNewWin('" & strUrl & "');", True)
            Else
                lblMessage.Text = "Error: " & ex.Message
            End If
            'plcShareData.Visible = False
            'plcShareNoData.Visible = False
            'plcData.Visible = False
            'plcNoData.Visible = False
            'plcError.Visible = True
            'plcShareError.Visible = True
            'lblMessage.Text = "Facebook is experiencing problems at this time. Please save your work and try to publish later."
        End Try
    End Sub
#End Region

    Public Function BindSavedCustomTab()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BALCustomTab
                objBAL.CustomTabId = CInt(Request.QueryString("ctId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.FBPageId = If(Session("strPageId") <> Nothing, Session("strPageId"), "")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetCustomTabMasterByID
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        txtname.Text = ds.Tables(1).Rows(0).Item("CustomTabName")
                        txtCustomTabName.Value = ds.Tables(1).Rows(0).Item("CustomTabName")
                        txtShareTabName.Value = ds.Tables(1).Rows(0).Item("CustomTabName")
                        divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("CustomTabContent").Replace("{%domain%}/", ConfigurationManager.AppSettings("AppPath"))
                        Session("CustomTabID") = ds.Tables(0).Rows(0).Item("CustomTabId")
                        Session("FanPageSelected") = ds.Tables(0).Rows(0).Item("ct_FBPageId").ToString
                        Session("FanPageName") = ds.Tables(0).Rows(0).Item("ct_FBPageName").ToString
                        hdnCTID.Value = Session("CustomTabID")
                        If Not IsDBNull(ds.Tables(0).Rows(0).Item("ct_IsPublished")) AndAlso ds.Tables(0).Rows(0).Item("ct_IsPublished") = 1 Then
                            BindSelectedFanPages(Session("FanPageSelected"))
                        ElseIf Session("FanPageSelected") <> "" AndAlso Not IsDBNull(Session("FanPageSelected")) Then
                            For Each item As DataListItem In dstFanPages.Items
                                Dim myCheckBox As HtmlInputRadioButton
                                Dim HiddenID As New HtmlInputHidden
                                myCheckBox = CType(item.FindControl("chkPage"), HtmlInputRadioButton)
                                HiddenID = CType(item.FindControl("hdnPageId"), HtmlInputHidden)
                                Dim str As String = CStr(HiddenID.Value)
                                ' Response.Write(str & " ---- ")
                                If str = ds.Tables(0).Rows(0).Item("ct_FBPageId").ToString Then
                                    myCheckBox.Checked = True
                                Else
                                    myCheckBox.Disabled = True
                                End If
                            Next
                            For Each Shareitem As DataListItem In dstShareFanPages.Items
                                Dim myShareCheckBox As HtmlInputRadioButton
                                Dim HiddenShareID As New HtmlInputHidden
                                myShareCheckBox = CType(Shareitem.FindControl("chkPage"), HtmlInputRadioButton)
                                HiddenShareID = CType(Shareitem.FindControl("hdnPageId"), HtmlInputHidden)
                                Dim strShare As String = CStr(HiddenShareID.Value)
                                ' Response.Write(str & " ---- ")
                                If strShare = ds.Tables(0).Rows(0).Item("ct_FBPageId").ToString Then
                                    myShareCheckBox.Checked = True
                                Else
                                    myShareCheckBox.Disabled = True
                                End If
                            Next
                        End If
                    End If
                    If Session("FanPageSelected") <> "" AndAlso Not IsDBNull(Session("FanPageSelected")) Then
                        If ds.Tables(2).Rows(0).Item("mainadmin") = 1 Then
                            pnlEdit.Visible = True
                            pnlMessage.Visible = False
                        Else
                            pnlEdit.Visible = False
                            pnlMessage.Visible = True
                            spnAssigned.InnerHtml = "An administrator of business page <b>" & ds.Tables(0).Rows(0).Item("ct_FBPageName") & "</b> has shared this Custom tab with you for viewing purposes only. To edit, please create a copy in '<b><a href='custom-tab' title='My Saved Custom tabs'>My Saved Custom tabs</a></b>' and edit that copy"
                        End If
                    ElseIf ds.Tables(0).Rows(0).Item("ct_IsShared") = 2 Then
                        pnlEdit.Visible = True
                        pnlEdit.Visible = True
                        pnlMessage.Visible = False
                    Else
                        pnlEdit.Visible = False
                        pnlMessage.Visible = True
                        spnAssigned.InnerHtml = "An administrator of business page <b>" & ds.Tables(0).Rows(0).Item("ct_FBPageName") & "</b> has shared this Custom tab with you for viewing purposes only. To edit, please create a copy in '<b><a href='custom-tab'>My Saved Custom tabs</a></b>' and edit that copy"
                    End If
                    'If ds.Tables(2).Rows(0).Item("mainadmin") = 1 Or ds.Tables(0).Rows(0).Item("ct_IsShared") = 2 Then
                    '    pnlEdit.Visible = True
                    '    pnlMessage.Visible = False
                    'Else
                    '    pnlEdit.Visible = False
                    '    pnlMessage.Visible = True
                    '    spnAssigned.InnerHtml = "An administrator of business page <b>" & ds.Tables(0).Rows(0).Item("ct_FBPageName") & "</b> has shared this Custom tab with you for viewing purposes only. To edit, please create a copy in '<b><a href='custom-tab'>My Saved Custom tabs</a></b>' and edit that copy"
                    'End If
                Else
                    lblMessage.Text = "This Custom Tab is deleted"
                    pnlEdit.Visible = False
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            'lblMessage.Text = "Error: " & ex.Message
            If ex.Message.Contains("The remote server returned an error: (400)") Then
                Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=1&at=" & Session("hdnToken") & ""
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide11;", ";openNewWin('" & strUrl & "');", True)
            Else
                lblMessage.Text = "Error: " & ex.Message
            End If
            
        End Try
    End Function

    Private Sub lnkReset_ServerClick(sender As Object, e As System.EventArgs) Handles lnkReset.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                divSidebarHtml.InnerHtml = ""
                Dim ds As New DataSet
                Dim objBAL As New BALCustomTab
                objBAL.CustomTabId = CInt(Request.QueryString("ctId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                ds = objBAL.GetCustomTabMaster
                If ds.Tables(0).Rows.Count > 0 Then
                    divSidebarHtml.InnerHtml = ds.Tables(0).Rows(0).Item("CustomTabContent")
                End If

            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub lnkSave_ServerClick(sender As Object, e As System.EventArgs) Handles lnkSave.ServerClick

        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then

                Dim objBAL As New BALCustomTab
                objBAL.CustomTabId = CInt(Request.QueryString("ctId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CustomTabName = If(txtCustomTabName.Value <> "", txtCustomTabName.Value, "")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                objBAL.CustomTabContent = hdnSidebarContent.Value

                ViewState("CustomTabID") = CInt(Request.QueryString("ctId"))
                ViewState("FBUserId") = Request.QueryString("FbuserId")

                objBAL.UpdateCustomTabContent()

                BindSavedCustomTab()

                Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate-ct-image.aspx?id=" & Session("CustomTabID")
                Dim browserWidth As Integer = Convert.ToInt32(800)
                Dim browserHeight As Integer = Convert.ToInt32(600)
                Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                Dim fullPath As String = Server.MapPath(relativeImagePath)
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strDate As Date = "1/1/1900"
                strPhoto = "customtab-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                Session("ImageName") = strPhoto

                Dim strD As [String] = strPhoto
                If Not fullPath.EndsWith("\") Then
                    fullPath += "\"
                End If

                Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, 520, 1000, 320, 740, fullPath, strD), System.Drawing.Image)

                objBAL.CustomTabId = ViewState("CustomTabID")
                objBAL.FBUserId = ViewState("FBUserId")
                objBAL.CustomTabImage = Session("ImageName")
                objBAL.UpdateImageName()
                hdnPublished.Value = "0"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Your work has been saved');", True)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try

    End Sub

    Private Sub btnSave_ServerClick(sender As Object, e As System.EventArgs) Handles btnSave.ServerClick

        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                'If hdnPublished.Value = "1" Then
                'Dim strPageId As String = ""
                'Dim strPageAccessToken As String = ""
                'For Each item As DataListItem In dstFanPages.Items
                '    Dim myCheckBox As HtmlInputRadioButton
                '    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputRadioButton)
                '    If myCheckBox.Checked = True Then
                '        strPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                '        strPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                '    End If
                'Next

                Dim objBAL As New BALCustomTab
                objBAL.CustomTabId = CInt(Request.QueryString("ctId"))
                objBAL.UserId = CInt(Request.QueryString("userId"))
                objBAL.FBUserId = Request.QueryString("FbuserId")
                objBAL.CustomTabName = If(txtCustomTabName.Value <> "", txtCustomTabName.Value, "")
                objBAL.CompanyId = CInt(Request.QueryString("CId"))
                objBAL.IndustryId = CInt(Request.QueryString("IId"))
                objBAL.CustomTabContent = hdnSidebarContent.Value
                'objBAL.FBPageId = strPageId
                'objBAL.FBPageAccessToken = strPageAccessToken
                ViewState("CustomTabID") = CInt(Request.QueryString("ctId"))
                ViewState("FBUserId") = Request.QueryString("FbuserId")

                objBAL.UpdateCustomTabContent()
                BindSavedCustomTab()


                Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate-ct-image.aspx?id=" & Session("CustomTabID")
                Dim browserWidth As Integer = Convert.ToInt32(800)
                Dim browserHeight As Integer = Convert.ToInt32(600)
                Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                Dim fullPath As String = Server.MapPath(relativeImagePath)
                Dim strExt As String = ""
                Dim strPhoto As String = ""
                Dim strDate As Date = "1/1/1900"
                strPhoto = "customtab-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                Session("ImageName") = strPhoto

                Dim strD As [String] = strPhoto
                If Not fullPath.EndsWith("\") Then
                    fullPath += "\"
                End If

                Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, 520, 1000, 320, 740, fullPath, strD), System.Drawing.Image)

                objBAL.CustomTabId = ViewState("CustomTabID")
                objBAL.FBUserId = ViewState("FBUserId")
                objBAL.CustomTabImage = Session("ImageName")
                objBAL.UpdateImageName()
                'End If
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "PublishAlert();", True)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub btnUpload_ServerClick(sender As Object, e As System.EventArgs) Handles btnUpload.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim result As String = ""
                Dim strPageId As String = ""
                Dim AppID = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
                Dim url As String = "https://graph.facebook.com/{0}/tabs/?app_id={2}&access_token={1}&method=post"
                'Response.Write("testasdfdsf")
                For Each item As DataListItem In dstFanPages.Items
                    Dim myCheckBox As HtmlInputRadioButton
                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputRadioButton)
                    If myCheckBox.Checked = True Then
                        strPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                        Dim strPageAccessToken As String = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                        ViewState("PageName") = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                        'ViewState("PageURL") = CType(item.FindControl("hdnPageLink"), HtmlInputHidden).Value
                        'Response.Write(strPageId & "   aceess toekn   : " & strPageAccessToken)
                        'Response.End()
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

                        Dim objCustomTab As New CustomTabContent
                        objCustomTab.FBPageId = ViewState("PageID")
                        objCustomTab.FBPageName = ViewState("PageName")
                        objCustomTab.FBPageURL = "" 'ViewState("PageURL")
                        objCustomTab.FBUserId = Session("FacebookUserId")
                        objCustomTab.Content = divSidebarHtml.InnerHtml
                        objCustomTab.AddEditCustomTab()

                        Dim objBAL As New BALCustomTab
                        objBAL.UserId = Session("SiteUserId")
                        objBAL.FBUserId = Session("FacebookUserId")
                        objBAL.CustomTabId = Session("CustomTabID")
                        objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                        objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                        objBAL.FBPageImage = CType(item.FindControl("hdnImage"), HtmlInputHidden).Value
                        objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                        objBAL.AddCustomTabFanPages()

                        Dim obj As New BALCustomTab
                        obj.CustomTabId = Session("CustomTabID")
                        obj.FBPageId = ViewState("PageID") 'strPageId 'CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                        obj.FBPageName = ViewState("PageName") 'CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value
                        obj.FBPageAccessToken = ViewState("PageAccessToken")
                        obj.UpdateIsPublishedCustomTab()
                    End If
                Next
                If result.ToLower = "true" Then
                    url = "https://graph.facebook.com/{0}/tabs?app_id={3}&access_token={1}&method=post&custom_name={2}"
                    Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, ViewState("PageID"), ViewState("PageAccessToken"), "", AppID))
                    Dim fbResponse As WebResponse = fbRequest.GetResponse()
                    Dim stream As Stream = fbResponse.GetResponseStream()
                    Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                    Dim streamReader As New StreamReader(stream, encode)
                    result = streamReader.ReadToEnd()
                    streamReader.Close()
                Else
                    lblMessage.Text = "Facebook is experiencing problems at this time. Please save your work and try to publish later."
                End If
                ClearData()
                BindSelectedFanPages(ViewState("PageID"))
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Custom Tab published to your Page(s) successfully');", True)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            'lblMessage.Text = "Error: " & ex.Message
            lblMessage.Text = "Facebook is experiencing problems at this time. Please save your work and try to publish later."
        End Try
    End Sub


    Sub ClearData()
        For Each item As DataListItem In dstFanPages.Items
            Dim myCheckBox As HtmlInputRadioButton
            Dim HiddenID As HtmlInputHidden
            myCheckBox = CType(item.FindControl("chkPage"), HtmlInputRadioButton)
            HiddenID = CType(item.FindControl("hdnPageId"), HtmlInputHidden)
            myCheckBox.Checked = False
        Next
    End Sub

    Private Sub lnkShareName_ServerClick(sender As Object, e As System.EventArgs) Handles lnkShareName.ServerClick
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim dsShareId As New DataSet
                Dim objBAL As New BALCustomTab
                For Each item As DataListItem In dstShareFanPages.Items
                    Dim myCheckBox As HtmlInputRadioButton
                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputRadioButton)
                    If myCheckBox.Checked = True Then
                        'ViewState("PageURL") = CType(item.FindControl("hdnPageLink"), HtmlInputHidden).Value
                        objBAL.CustomTabId = CInt(Request.QueryString("ctId"))
                        objBAL.UserId = CInt(Request.QueryString("userId"))
                        objBAL.FBUserId = Request.QueryString("FbuserId")
                        objBAL.CustomTabName = If(txtShareTabName.Value <> "", txtShareTabName.Value, "")
                        objBAL.CompanyId = CInt(Request.QueryString("CId"))
                        objBAL.IndustryId = CInt(Request.QueryString("IId"))
                        objBAL.CustomTabContent = hdnSidebarContent.Value
                        objBAL.FBPageId = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value
                        objBAL.FBPageAccessToken = CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value
                        objBAL.FBPageName = CType(item.FindControl("hdnPageName"), HtmlInputHidden).Value

                        objBAL.UpdateSharedCustomTabContent()
                        BindSavedCustomTab()


                        Dim siteUrl As String = ConfigurationManager.AppSettings("AppPath") & "generate-ct-image.aspx?id=" & Session("CustomTabID")
                        Dim browserWidth As Integer = Convert.ToInt32(800)
                        Dim browserHeight As Integer = Convert.ToInt32(600)
                        Dim thumbnailWidth As Integer = Convert.ToInt32(800)
                        Dim thumbnailHeight As Integer = Convert.ToInt32(600)
                        Dim relativeImagePath As String = ConfigurationManager.AppSettings("uploadpath")
                        Dim fullPath As String = Server.MapPath(relativeImagePath)
                        Dim strExt As String = ""
                        Dim strPhoto As String = ""
                        Dim strDate As Date = "1/1/1900"
                        strPhoto = "customtab-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & ".jpg"
                        Session("ImageName") = strPhoto

                        Dim strD As [String] = strPhoto
                        If Not fullPath.EndsWith("\") Then
                            fullPath += "\"
                        End If

                        Dim img As System.Drawing.Image = DirectCast(PAB.WebControls.WebSiteThumbnail.GetSiteThumbnail(siteUrl, 520, 1000, 320, 740, fullPath, strD), System.Drawing.Image)

                        objBAL.CustomTabId = ViewState("CustomTabID")
                        objBAL.FBUserId = Request.QueryString("FbuserId")
                        objBAL.CustomTabImage = Session("ImageName")
                        objBAL.UpdateImageName()
                        'End If
                    End If
                Next
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SaveAlert", "SaveAlert('Custom Tab Shared Successfully');", True)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "GotoHome", "RedirectToHome();", True)
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub
End Class