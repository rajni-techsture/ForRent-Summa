Imports BusinessAccessLayer.BusinessLayer
Public Class select_test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ds As New DataSet
            Dim objBAL As New BALCompanyIndusty
            'objBAL.FBUserId = "100001311049327" 'Session("FacebookUserId")
            ds = objBAL.GetCompnayDetails
            If ds.Tables(0).Rows.Count > 0 Then
                rptCompany.DataSource = ds.Tables(0)
                rptCompany.DataBind()
            Else
                rptCompany.DataSource = Nothing
                rptCompany.DataBind()
                'lblMessage.Text = "No Drafts Found"
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                rptIndustry.DataSource = ds.Tables(1)
                rptIndustry.DataBind()
            Else
                rptIndustry.DataSource = Nothing
                rptIndustry.DataBind()
                'lblMessage.Text = "No Drafts Found"
            End If
        Catch ex As Exception
            'lblMessage.Text = "Error :" & ex.Message()
        End Try

    End Sub

End Class