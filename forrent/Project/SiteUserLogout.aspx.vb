Public Class logout1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SiteUserId") = Nothing
        Session("SiteUserName") = Nothing
        Session("FacebookAccessToken") = Nothing
        Session("FacebookUserId") = Nothing
        Session("CompanyId") = Nothing
        Session("IndustryId") = Nothing
        'Session.Clear()
        Session.Abandon()

        ' Response.Redirect(ConfigurationManager.AppSettings("AppPath") & "local-user")
        Response.Redirect("http://www.forrent.com/admin")
    End Sub

End Class