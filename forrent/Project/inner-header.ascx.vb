Imports BusinessAccessLayer.BusinessLayer
Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Public Class inner_header
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("FacebookAccessToken") <> Nothing AndAlso Session("FacebookAccessToken") <> "" Then
            'Dim objBALCompInd As New BALCompanyIndusty
            'objBALCompInd.FBUserId = Session("FacebookUserId")
            'Dim ds As DataSet = objBALCompInd.GetCompnayIndustryName
            'If ds.Tables(0).Rows.Count > 0 Then
            'spnSelection.InnerText = ds.Tables(0).Rows(0).Item("Name").ToString
            Dim intIndustryId = 1 'ds.Tables(0).Rows(0).Item("IndustryId")
            Dim intCompanyId = 0 'ds.Tables(0).Rows(0).Item("CompanyId")
            'If intIndustryId.ToString = "0" Then
            '    plcIndustry.Visible = False
            '    plcCompany.Visible = True
            'Else
            '    plcIndustry.Visible = True
            '    plcCompany.Visible = False
            'End If
            'Else
            'spnSelection.InnerText = ""
            'End If
            'If Not Page.IsPostBack Then
            '    Try
            '        Dim ds1 As New DataSet
            '        Dim objBAL As New BALCompanyIndusty
            '        'objBAL.FBUserId = "100001311049327" 'Session("FacebookUserId")
            '        ds1 = objBAL.GetCompnayDetails
            '        If ds1.Tables(0).Rows.Count > 0 Then
            '            rptCompany.DataSource = ds1.Tables(0)
            '            rptCompany.DataBind()
            '        Else
            '            rptCompany.DataSource = Nothing
            '            rptCompany.DataBind()
            '        End If
            '        If ds1.Tables(1).Rows.Count > 0 Then
            '            rptIndustry.DataSource = ds1.Tables(1)
            '            rptIndustry.DataBind()
            '        Else
            '            rptIndustry.DataSource = Nothing
            '            rptIndustry.DataBind()
            '        End If

            '    Catch ex As Exception
            '        'lblMessage.Text = "Error :" & ex.Message()
            '    End Try
            'End If
        Else
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
        End If
    End Sub

End Class