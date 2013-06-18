Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer

Public Class manage_weekly_tip
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
            Dim objView As New BALAdminWeeklyTip
            Dim ds As DataSet = objView.BindWeeklyTip()
            If ds.Tables(0).Rows.Count > 0 Then
                dgrWeeklyTip.DataSource = ds.Tables(0)
                dgrWeeklyTip.DataBind()
                trNote.Visible = True
                ltrMsg.Text = ""
            Else
                dgrWeeklyTip.DataSource = Nothing
                dgrWeeklyTip.DataBind()
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
                Dim objStatus As New BALAdminWeeklyTip
                objStatus.WTId = CInt(sender.commandName)
                objStatus.Status = CInt(sender.commandArgument)
                dt = objStatus.ChangeWeeklyTipStatus()
                If CInt(sender.CommandArgument) < 2 Then
                    BindGrid()
                    ltrMsg.Text = "Weekly Tip Status Changed Successfully."
                Else
                    BindGrid()
                    ltrMsg.Text = "Weekly Tip Deleted Successfully."
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Sub SetAsHome(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try

            ' Dim chkShow As CheckBox = CType(sender, CheckBox)

            Dim objSetHome As New BALAdminWeeklyTip
            objSetHome.WTId = CInt(sender.CommandArgument)
            objSetHome.SetHome = 1
            objSetHome.SetWeeklyTipInHome()

            ltrMsg.Text = "Weekly Tip is Set As Home."

            BindGrid()


        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub dgrWeeklyTip_PageIndexChanged(source As Object, e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrWeeklyTip.PageIndexChanged
        dgrWeeklyTip.CurrentPageIndex = e.NewPageIndex
        'dgrSystemUsers.SelectedIndex = -1
        BindGrid()
    End Sub
End Class