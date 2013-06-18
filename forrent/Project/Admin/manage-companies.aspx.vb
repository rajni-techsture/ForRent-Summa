Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer

Public Class manage_companies
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
            Dim objViewCompany As New BALCompany
            Dim ds As DataSet = objViewCompany.BindCompanies()
            If ds.Tables(0).Rows.Count > 0 Then
                dgrCompanies.DataSource = ds.Tables(0)
                dgrCompanies.DataBind()
                trNote.Visible = True
                ltrMsg.Text = ""
            Else
                dgrCompanies.DataSource = Nothing
                dgrCompanies.DataBind()
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
                Dim objStatusCompany As New BALCompany
                objStatusCompany.CompanyId = CInt(sender.commandName)
                objStatusCompany.Status = CInt(sender.commandArgument)
                dt = objStatusCompany.ChangeCompanyStatus()
                If CInt(sender.CommandArgument) < 2 Then
                    BindGrid()
                    ltrMsg.Text = "Company Status Changed Successfully."
                Else
                    BindGrid()
                    ltrMsg.Text = "Company Deleted Successfully."
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub dgrCompanies_PageIndexChanged(source As Object, e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrCompanies.PageIndexChanged
        dgrCompanies.CurrentPageIndex = e.NewPageIndex
        'dgrSystemUsers.SelectedIndex = -1
        BindGrid()
    End Sub
End Class