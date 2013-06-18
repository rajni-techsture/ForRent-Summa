Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer
Public Class manage_admin_users
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                BindGrid()
            Catch ex As Exception
                ltrMsg.Text = "Error: " & ex.Message.ToString
            End Try
        End If
    End Sub

    Sub BindGrid()
        Try
            Dim objViewAdminUsers As New BALadmin_user
            Dim ds As DataSet = objViewAdminUsers.BindAdminUsers()
            If ds.Tables(0).Rows.Count > 0 Then
                dgrSystemUsers.DataSource = ds.Tables(0)
                dgrSystemUsers.DataBind()
                trNote.Visible = True
                ltrMsg.Text = ""
            Else
                dgrSystemUsers.DataSource = Nothing
                dgrSystemUsers.DataBind()
                ltrMsg.Text = "No record found."
                trNote.Visible = False
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
    End Sub

    Sub ChangeStatus(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            If sender.commandName <> "" And sender.commandArgument <> "" Then
                Dim dt As New DataSet
                Dim objStatusAdminUsers As New BALadmin_user
                objStatusAdminUsers.UserId = CInt(sender.commandName)
                objStatusAdminUsers.Status = CInt(sender.commandArgument)
                dt = objStatusAdminUsers.ChangeAdminStatus
                If CInt(sender.CommandArgument) < 2 Then
                    BindGrid()
                    ltrMsg.Text = "Admin Status Changed Successfully."
                Else
                    BindGrid()
                    ltrMsg.Text = "Admin Deleted Successfully."
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub dgrSystemUsers_PageIndexChanged(source As Object, e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrSystemUsers.PageIndexChanged
        dgrSystemUsers.CurrentPageIndex = e.NewPageIndex
        'dgrSystemUsers.SelectedIndex = -1
        BindGrid()
    End Sub
End Class