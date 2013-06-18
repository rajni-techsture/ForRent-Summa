Public Class training
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("FacebookAccessToken") = Nothing AndAlso Session("FacebookAccessToken") = "" Then
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
            End If
        Catch ex As Exception
            'lblmessage.Text = "Error: " & ex.Message
        End Try
    End Sub

End Class