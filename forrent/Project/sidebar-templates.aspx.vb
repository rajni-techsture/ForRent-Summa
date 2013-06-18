Imports System.Data.SqlClient
Imports BusinessAccessLayer.BusinessLayer
Public Class sidebar_templates
    Inherits System.Web.UI.Page
    Dim objlink As LinkButton
    Dim objlabel As Label
    Dim intStartRecord, intEndRecord As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            hdnFBUserId.Value = Session("FacebookUserId")
            hdnUserId.Value = Session("SiteUserId")
            hdnCompanyId.Value = GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
            hdnIndustryId.Value = GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
            
            If Not Page.IsPostBack Then
			ViewState("currentpageindex") = 1
                BindSidebarByPageIndex()
                BindSidebar()
                'BindSidebarById()
            Else
                GenreateControls()
            End If
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
        End If
    End Sub
    Public Function BindSidebar()
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
            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
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
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
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

End Class