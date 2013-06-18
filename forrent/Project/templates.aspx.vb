Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer
Public Class templates
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
           binddata()
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath") & "login.aspx")
        End If
    End Sub


    Sub binddata()
        Try
            Dim ds As New DataSet
            Dim objBAL As New BALSchedulePost
            objBAL.FBUserId = Session("FacebookUserId")
            ds = objBAL.GetTemplates
            If ds.Tables(0).Rows.Count > 0 Then
                '  rptDrafts.DataSource = ds.Tables(0)
                'rptDrafts.DataBind()
                gvlist.DataSource = ds.Tables(0)
                gvlist.DataBind()
            Else

                '  rptDrafts.DataSource = Nothing
                ' rptDrafts.DataBind()
                gvlist.DataSource = Nothing
                gvlist.DataBind()
                lblMessage.Text = "No Templates Found"
            End If
        Catch ex As Exception
            lblMessage.Text = "Error :" & ex.Message()
        End Try
    End Sub

    Protected Sub gvlist_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        gvlist.PageIndex = e.NewPageIndex
        binddata()
    End Sub

End Class