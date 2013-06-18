Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer

Public Class manage_industries
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
            Dim objViewIndustry As New BALIndustry
            Dim ds As DataSet = objViewIndustry.BindIndustries()
            If ds.Tables(0).Rows.Count > 0 Then
                dgrIndustries.DataSource = ds.Tables(0)
                dgrIndustries.DataBind()
                trNote.Visible = True
                ltrMsg.Text = ""
            Else
                dgrIndustries.DataSource = Nothing
                dgrIndustries.DataBind()
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
                Dim objStatusIndustry As New BALIndustry
                objStatusIndustry.IndustryId = CInt(sender.commandName)
                objStatusIndustry.Status = CInt(sender.commandArgument)
                dt = objStatusIndustry.ChangeIndustryStatus()
                If CInt(sender.CommandArgument) < 2 Then
                    BindGrid()
                    ltrMsg.Text = "Industry Status Changed Successfully."
                Else
                    BindGrid()
                    ltrMsg.Text = "Industry Deleted Successfully."
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub dgrIndustries_PageIndexChanged(source As Object, e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrIndustries.PageIndexChanged
        dgrIndustries.CurrentPageIndex = e.NewPageIndex
        'dgrSystemUsers.SelectedIndex = -1
        BindGrid()
    End Sub
End Class