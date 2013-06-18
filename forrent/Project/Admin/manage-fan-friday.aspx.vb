Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer

Public Class manage_fan_friday
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
            Dim objViewFanFriday As New BALFanFriday
            Dim ds As DataSet = objViewFanFriday.BindFanFriday()
            If ds.Tables(0).Rows.Count > 0 Then
                dgrFanFriday.DataSource = ds.Tables(0)
                dgrFanFriday.DataBind()
                trNote.Visible = True
                ltrMsg.Text = ""
            Else
                dgrFanFriday.DataSource = Nothing
                dgrFanFriday.DataBind()
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
                Dim objStatusFanFriday As New BALFanFriday
                objStatusFanFriday.FFId = CInt(sender.commandName)
                objStatusFanFriday.Status = CInt(sender.commandArgument)
                dt = objStatusFanFriday.ChangeFanFridayStatus()
                If CInt(sender.CommandArgument) < 2 Then
                    BindGrid()
                    ltrMsg.Text = "Fan Friday Status Changed Successfully."
                Else
                    BindGrid()
                    ltrMsg.Text = "Fan Friday Deleted Successfully."
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Sub SetAsHome(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try

            ' Dim chkShow As CheckBox = CType(sender, CheckBox)

            Dim objSetHomeFanFriday As New BALFanFriday
            objSetHomeFanFriday.FFId = CInt(sender.CommandArgument)
            objSetHomeFanFriday.SetHome = 1
            objSetHomeFanFriday.SetFanFridayInHome()

            ltrMsg.Text = "Fan Friday is Set As Home."

            BindGrid()


        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub dgrFanFriday_PageIndexChanged(source As Object, e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrFanFriday.PageIndexChanged
        dgrFanFriday.CurrentPageIndex = e.NewPageIndex
        'dgrSystemUsers.SelectedIndex = -1
        BindGrid()
    End Sub
End Class