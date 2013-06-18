Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports BusinessAccessLayer.BusinessLayer
Public Class sidebar
    Inherits System.Web.UI.Page
    Public strPage As String
    Dim objlink As LinkButton
    Dim objlabel As Label
    Dim intStartRecord, intEndRecord As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                hdnFBUserId.Value = Session("FacebookUserId")
                hdnUserId.Value = Session("SiteUserId")
                hdnCompanyId.Value = 0 'GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
                hdnIndustryId.Value = 1 ' GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
                If Not Page.IsPostBack Then
                    ViewState("currentpageindex") = 1
                    BindSidebarByPageIndex()
                    BindSidebar()
                    BindSidebarAll()
                    'BindSidebarById()
                Else
                    GenreateControls()
                End If
                
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub

    Public Function BindSidebar()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BAlsidebar
                objBAL.PageIndex = 0 'ViewState("currentpageindex")
                objBAL.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
                objBAL.IndustryId = 1 ' GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
                ds = objBAL.GetSidebarMasterByCompOrIndustry
                If ds.Tables(0).Rows.Count > 0 Then
                    rptSidebar.DataSource = ds.Tables(0)
                    rptSidebar.DataBind()
                Else
                    lblMessage.Text = "No Sidebar Found"
					pnlCarousel.Visible= "False"
                    rptSidebar.DataSource = Nothing
                    rptSidebar.DataBind()
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Function
    Public Function BindSidebarAll()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BAlsidebar
                objBAL.PageIndex = 0 'ViewState("currentpageindex")
                objBAL.CompanyId = GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
                objBAL.IndustryId = GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
                ds = objBAL.GetSidebarMasterByCompOrIndustry
                If ds.Tables(0).Rows.Count > 0 Then
                    rptNoPaging.DataSource = ds.Tables(0)
                    rptNoPaging.DataBind()
                Else
                    rptNoPaging.DataSource = Nothing
                    rptNoPaging.DataBind()
                End If
                If ds.Tables(0).Rows.Count > 0 Then
                    ltrCount.Text = ds.Tables(0).Rows.Count
                Else
                    ltrCount.Text = 0
                End If
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Function
    Public Function BindSidebarByPageIndex()
        Try
            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
                Dim ds As New DataSet
                Dim objBAL As New BAlsidebar
                objBAL.PageIndex = ViewState("currentpageindex")
                objBAL.CompanyId = GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
                objBAL.IndustryId = GetSetCookies.GetCookie("IndustryId")
                ds = objBAL.GetSidebarMasterByCompOrIndustry
                If ds.Tables(0).Rows.Count > 0 Then
                    rptPaging.DataSource = ds.Tables(0)
                    rptPaging.DataBind()
                Else
                    rptPaging.DataSource = Nothing
                    rptPaging.DataBind()
                End If

                If ds.Tables(1).Rows.Count > 0 Then
                    With ds.Tables(1).Rows(0)
                        ViewState("TotalPage") = .Item("Totalpage").ToString
                        ViewState("TotalRecords") = .Item("TotalRec").ToString
                    End With
                End If
                phPaging.Controls.Clear()
                phPaging1.Controls.Clear()
                GenreateControls()
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
        End Try
    End Function

#Region "Genreate Controls For Paging"
    Sub GenreateControls()
        If (ViewState("TotalPage") > 1) Then
            Dim i As Integer
            If (ViewState("TotalPage") > 1 And ViewState("currentpageindex") <> 1) Then
                ''''Generating previous button''
                objlink = New LinkButton()
                objlink.ID = "Prev"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/images/net-arrow-Previous1.gif""  hspace=""5"" align=""absmiddle"" border=""0"">Previous"
                AddHandler objlink.Click, AddressOf lnkPage_Previous
                phPaging.Controls.Add(objlink)
                phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Prev1"
                objlink.Text = "<img src=""../Content/images/net-arrow-Previous1.gif""  hspace=""5"" align=""absmiddle"" border=""0"">Previous"
                AddHandler objlink.Click, AddressOf lnkPage_Previous
                phPaging1.Controls.Add(objlink)
                phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''
            End If
            If (ViewState("currentpageindex") <= 7) Then
                intStartRecord = 1
                intEndRecord = 8
                If (ViewState("TotalPage") > 8) Then
                    intEndRecord = 8
                Else
                    intEndRecord = ViewState("TotalPage")
                End If
            Else
                If ((ViewState("currentpageindex") / 8).ToString.IndexOf(".") > 0) Then
                    intStartRecord = (ViewState("currentpageindex") / 8).ToString.Substring(0, (ViewState("currentpageindex") / 8).ToString.IndexOf(".")) * 8
                Else
                    intStartRecord = (8 * CInt((ViewState("currentpageindex") / 8)))
                End If
                If (intStartRecord > ViewState("TotalPage")) Then
                    intStartRecord = (8 * (CInt((ViewState("currentpageindex") / 8)) - 1))
                End If
                If (intStartRecord + 8 < ViewState("TotalPage")) Then
                    intEndRecord = intStartRecord + 8
                Else
                    intEndRecord = ViewState("TotalPage")
                End If
            End If

            For i = intStartRecord To intEndRecord
                If (ViewState("currentpageindex") <> i) Then
                    objlink = New LinkButton()
                    objlink.ID = i
                    objlink.Text = i
                    AddHandler objlink.Click, AddressOf lnkPage_click
                    phPaging.Controls.Add(objlink)
                    phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                    ''''''------------------''''''
                    objlink = New LinkButton()
                    objlink.ID = i + ViewState("TotalRecords")
                    objlink.Text = i
                    AddHandler objlink.Click, AddressOf lnkPage_click
                    phPaging1.Controls.Add(objlink)
                    phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                Else
                    objlabel = New Label()
                    objlabel.ID = i
                    objlabel.Text = i
                    phPaging.Controls.Add(objlabel)
                    phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                    objlabel.CssClass = "curpage"
                    ''''''------------------''''''
                    objlabel = New Label()
                    objlabel.ID = i + ViewState("TotalRecords")
                    objlabel.Text = i
                    objlabel.CssClass = "curpage"
                    phPaging1.Controls.Add(objlabel)
                    phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                End If
            Next
            If (ViewState("TotalPage") > 1 And ViewState("currentpageindex") < ViewState("TotalRecords")) Then
                ''''Generating next button '
                objlink = New LinkButton()
                objlink.ID = "Next"
                objlink.Visible = True
                objlink.Text = "Next<img src=""../Content/images/net-arrow-Next1.gif"" hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPage_Next
                phPaging.Controls.Add(objlink)
                phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Next1"
                objlink.Text = "Next<img src=""../Content/images/net-arrow-Next1.gif"" hspace=""5"" align=""absmiddle"" border=""0"">"
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
            ViewState("currentpageindex") = CType(sender, LinkButton).ID - ViewState("TotalRecords")
        Else
            ViewState("currentpageindex") = CType(sender, LinkButton).ID
        End If
        BindSidebarByPageIndex()
    End Sub

    Private Sub lnkPage_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("currentpageindex") <> 1) Then
            ViewState("currentpageindex") = ViewState("currentpageindex") - 1
        End If
        BindSidebarByPageIndex()
    End Sub

    Private Sub lnkPage_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("currentpageindex") < ViewState("TotalPage")) Then
            ViewState("currentpageindex") = ViewState("currentpageindex") + 1
        Else
            ViewState("currentpageindex") = ViewState("currentpageindex")
        End If
        BindSidebarByPageIndex()
    End Sub

    Sub showHidePrevNetxt()
        If (ViewState("currentpageindex") = ViewState("TotalPage")) Then
            If (Not IsNothing(frm.FindControl("Next"))) Then
                frm.FindControl("Next").Visible = False
                frm.FindControl("Next1").Visible = False
            End If
        Else
            If (Not IsNothing(frm.FindControl("Next"))) Then
                frm.FindControl("Next").Visible = True
                frm.FindControl("Next1").Visible = True
            End If
        End If
    End Sub
#End Region
    '#Region "Bind Fan Pages"
    '    Sub BindFanPages()
    '        Try
    '            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
    '                Dim accessToken As String = Session("FacebookAccessToken")
    '                Dim clientId As String = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString()
    '                Dim clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("FBSecretKey").ToString()
    '                Dim url As String = "https://graph.facebook.com/me/accounts?fields=id,name,picture,category,access_token&return_ssl_resources=true&access_token={0}"
    '                Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, accessToken))
    '                Dim fbResponse As WebResponse = fbRequest.GetResponse()
    '                Dim stream As Stream = fbResponse.GetResponseStream()
    '                Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(FanPage))

    '                Dim fPage As New FanPage()
    '                fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), FanPage)
    '                Dim listPages As New List(Of FanPage.m_data)

    '                For Each item As FanPage.m_data In fPage.data
    '                    listPages.Add(item)
    '                Next
    '                If listPages.Count > 0 Then
    '                    dstFanPages.DataSource = listPages
    '                    dstFanPages.DataBind()
    '                    'plcData.Visible = True
    '                    'plcNoData.Visible = False
    '                Else
    '                    dstFanPages.DataSource = Nothing
    '                    dstFanPages.DataBind()
    '                    'plcData.Visible = False
    '                    'plcNoData.Visible = True
    '                End If
    '            Else
    '                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
    '            End If
    '        Catch ex As Exception
    '            lblMessage.Text = "Error: " & ex.Message
    '        End Try
    '    End Sub
    '#End Region

    '#Region "Upload Sidebar"
    '    Private Sub lnkUploadPhoto_ServerClick(sender As Object, e As System.EventArgs) Handles lnkUploadPhoto.ServerClick
    '        Try
    '            If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
    '                Dim AccessToken As String = Session("FacebookAccessToken")
    '                Dim strActivationHours As String = Now.Hour
    '                Dim strActivationMinutes As String = Now.Minute
    '                'Dim strmsg As String = txtMessage.Value
    '                Dim strDate As String = Now.Date
    '                Dim strPageId As String = hdnselectedPages.Value
    '                Dim strPageName As String = hdnSelectedPagesName.Value
    '                Dim strPageImage As String = hdnSelectedPagesImage.Value
    '                Dim strPageAccessToken As String = hdnselectedPagesAccessToken.Value
    '                Dim strExt As String = ""
    '                Dim strPhoto As String = ""

    '                If photo.PostedFile.FileName <> "" Then
    '                    strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
    '                    If Not (strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png") Then
    '                        lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
    '                        Exit Sub
    '                    End If
    '                    Dim strDate1 As Date = "1/1/1900"
    '                    strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strDate1, Now())) & strExt
    '                    photo.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\" & strPhoto))

    '                End If

    '                Dim photopath As String = Server.MapPath("~/" & "Content/uploads/" & strPhoto)

    '                Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenProgressbar", "ShowProgress();", True)
    '                Dim str As String = ""
    '                For Each item As DataListItem In dstFanPages.Items
    '                    Dim myCheckBox As HtmlInputCheckBox
    '                    myCheckBox = CType(item.FindControl("chkPage"), HtmlInputCheckBox)
    '                    If myCheckBox.Checked = True Then
    '                        Dim path As String = CType(item.FindControl("hdnPageId"), HtmlInputHidden).Value & "/photos"
    '                        Dim mediaObject As New FacebookMediaObject() With { _
    '                            .FileName = photopath, _
    '                            .ContentType = "image/jpg" _
    '                    }
    '                        Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
    '                        mediaObject.SetValue(fileBytes)
    '                        Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
    '                        'upload.Add("message", strmsg)
    '                        upload.Add("image", mediaObject)
    '                        Dim fbapp = New FacebookClient(CType(item.FindControl("hdnAccessToken"), HtmlInputHidden).Value)
    '                        fbapp.Post(path, upload)
    '                    End If
    '                Next


    '                lblMessage.Text = "Photo Uploaded Successfully"
    '                Page.ClientScript.RegisterStartupScript(Me.GetType(), "CloseProgressbar", "HideProgress();", True)
    '            Else
    '                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
    '            End If

    '        Catch ex As Exception
    '            lblMessage.Text = "Error: " & ex.Message
    '        End Try
    '    End Sub
    '#End Region

End Class