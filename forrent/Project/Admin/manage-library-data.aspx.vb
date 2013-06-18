Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer

Public Class manage_library_data
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
            Dim objView As New BALAdminLibrary
            Dim ds As DataSet = objView.BindLibraryData()
            If ds.Tables(0).Rows.Count > 0 Then
                dgrLibData.DataSource = ds.Tables(0)
                dgrLibData.DataBind()
                trNote.Visible = True
                ltrMsg.Text = ""
            Else
                dgrLibData.DataSource = Nothing
                dgrLibData.DataBind()
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
                Dim objStatus As New BALAdminLibrary
                objStatus.LibraryID = CInt(sender.commandName)
                objStatus.Status = CInt(sender.commandArgument)
                dt = objStatus.ChangeLibraryDataStatus()
                If CInt(sender.CommandArgument) < 2 Then
                    BindGrid()
                    ltrMsg.Text = "Library Status Changed Successfully."
                Else
                    BindGrid()
                    ltrMsg.Text = "Library Deleted Successfully."
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub dgrLibData_PageIndexChanged(source As Object, e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrLibData.PageIndexChanged
        dgrLibData.CurrentPageIndex = e.NewPageIndex
        'dgrSystemUsers.SelectedIndex = -1
        BindGrid()
    End Sub
End Class