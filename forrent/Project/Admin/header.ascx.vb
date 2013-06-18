Public Class header1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AID") Is Nothing Then
            Session("AID") = -2
            Response.Redirect("login.aspx")
        End If
        If CInt(Session("AID")) <= 0 Then
            Session("AID") = -2
            Response.Redirect("login.aspx")
        End If
        'If Not Page.IsPostBack Then
        '    ltrUserName.Text = Session("ocAUserName")
        'End If

    End Sub

End Class