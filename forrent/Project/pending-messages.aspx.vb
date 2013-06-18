Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer
Public Class pending_messages
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
            ds = objBAL.GetPendingMess
            If ds.Tables(0).Rows.Count > 0 Then
                'rptPendingMess.DataSource = ds.Tables(0)
                'rptPendingMess.DataBind()
                gvlist.DataSource = ds.Tables(0)
                gvlist.DataBind()
            Else
                'rptPendingMess.DataSource = Nothing
                'rptPendingMess.DataBind()
                gvlist.DataSource = Nothing
                gvlist.DataBind()
                lblMessage.Text = "No Pending Messges Found"
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