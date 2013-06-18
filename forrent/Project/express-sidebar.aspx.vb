Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports BusinessAccessLayer.BusinessLayer

Public Class express_sidebar
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
                hdnCompanyId.Value = GetSetCookies.GetCookie("CompanyId") '0 '
                hdnIndustryId.Value = GetSetCookies.GetCookie("IndustryId") '1 '
                Dim obj As New BAlsidebar
                Dim ds As New DataSet
                obj.CompanyId = GetSetCookies.GetCookie("CompanyId")
                obj.IndustryId = GetSetCookies.GetCookie("IndustryId")
                ds = obj.GetExpressMenus()
                If ds.Tables(0).Rows.Count > 0 Then
                    hdnExpressId.Value = ds.Tables(0).Rows(0).Item("sdm_Id").ToString
                End If

                'If Not Page.IsPostBack Then
                '    ViewState("currentpageindex") = 1
                '    BindSidebarByPageIndex()
                '    BindSidebar()
                '    BindSidebarAll()
                '    'BindSidebarById()
                'Else
                '    GenreateControls()
                'End If

            Else
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            'lblMessage.Text = "Error: " & ex.Message
        End Try
    End Sub


End Class