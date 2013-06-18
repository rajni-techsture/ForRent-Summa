Imports System.IO
Imports BusinessAccessLayer.BusinessLayer
Public Class test_add_library_data
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                BindCompanies()
                BindIndustries()
                Dim intID As Integer = 0
                If Request("LDId") IsNot Nothing Then
                    If IsNumeric(Request("LDId")) Then
                        intID = CInt(Request("LDId"))
                    End If
                End If
                If intID > 0 Then
                    LoadLibraryData(intID)
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Sub BindCompanies()
        Dim objcomp As New BALAdminLibrary

        Dim ds As New DataSet
        ds = objcomp.BindCompanies
        If ds.Tables(0).Rows.Count > 0 Then
            drpCompany.DataSource = ds.Tables(0)
            drpCompany.DataTextField = "c_Name"
            drpCompany.DataValueField = "c_Id"
            drpCompany.DataBind()
        Else
            drpCompany.DataSource = Nothing
            drpCompany.DataBind()
        End If
        drpCompany.Items.Insert(0, New ListItem("-- Select Company --", "0"))
    End Sub

    Sub BindIndustries()
        Dim objcomp As New BALAdminLibrary

        Dim ds As New DataSet
        ds = objcomp.BindIndustries()
        If ds.Tables(0).Rows.Count > 0 Then
            drpIndustry.DataSource = ds.Tables(0)
            drpIndustry.DataTextField = "i_Name"
            drpIndustry.DataValueField = "i_Id"
            drpIndustry.DataBind()
        Else
            drpIndustry.DataSource = Nothing
            drpIndustry.DataBind()
        End If
        drpIndustry.Items.Insert(0, New ListItem("-- Select Industry --", "0"))
    End Sub

    Sub CategoriesByCID()
        Dim objcomp As New BALAdminLibrary

        Dim ds As New DataSet
        ds = objcomp.BindCategoriesByCompanyID()
        If ds.Tables(0).Rows.Count > 0 Then
            drpCategory.DataSource = ds.Tables(0)
            drpCategory.DataTextField = "lc_Title"
            drpCategory.DataValueField = "lc_Id"
            drpCategory.DataBind()
        Else
            drpCategory.DataSource = Nothing
            drpCategory.DataBind()
        End If
        drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))
    End Sub

    Sub CategoriesByIID()
        Dim objcomp As New BALAdminLibrary
        Dim ds As New DataSet
        ds = objcomp.BindCategoriesByIndustryID()
        If ds.Tables(0).Rows.Count > 0 Then
            drpCategory.DataSource = ds.Tables(0)
            drpCategory.DataTextField = "lc_Title"
            drpCategory.DataValueField = "lc_Id"
            drpCategory.DataBind()
        Else
            drpCategory.DataSource = Nothing
            drpCategory.DataBind()
        End If
        drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))
    End Sub


    Private Sub drpCompany_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpCompany.SelectedIndexChanged
        Dim obj As New BALAdminLibrary
        obj.CompanyId = drpCompany.SelectedValue
        Dim ds As New DataSet
        ds = obj.BindCategoriesByCompanyID()
        If ds.Tables(0).Rows.Count > 0 Then
            drpCategory.DataSource = ds.Tables(0)
            drpCategory.DataTextField = "lc_Title"
            drpCategory.DataValueField = "lc_Id"
            drpCategory.DataBind()
        Else
            drpCategory.DataSource = Nothing
            drpCategory.DataBind()
        End If
        drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))
        ds = Nothing
    End Sub

    Private Sub drpIndustry_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpIndustry.SelectedIndexChanged
        Dim obj As New BALAdminLibrary
        obj.IndustryId = drpIndustry.SelectedValue
        Dim ds As New DataSet
        ds = obj.BindCategoriesByIndustryID()
        If ds.Tables(0).Rows.Count > 0 Then
            drpCategory.DataSource = ds.Tables(0)
            drpCategory.DataTextField = "lc_Title"
            drpCategory.DataValueField = "lc_Id"
            drpCategory.DataBind()
        Else
            drpCategory.DataSource = Nothing
            drpCategory.DataBind()
        End If
        drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))
        ds = Nothing
    End Sub

    Private Sub LoadLibraryData(ByVal intID As Integer)
        Dim objGet As New BALAdminLibrary
        Dim ds As New DataSet
        ds = objGet.GetLibraryDataByID(intID)
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                ' txtTitle.Value = .Item("lib_").ToString
                'txtDescription.Value = .Item("lib_Template").ToString
                imgPhoto.Src = "../content/adminuploads/" & .Item("lib_Image").ToString
                hdnImage.Value = .Item("lib_Image").ToString
                hdnimagevalue.Value = .Item("lib_Image").ToString
                lblPhoto.Text = .Item("lib_Image").ToString


                If .Item("lib_Status") = 1 Then
                    rdoActive.Checked = True
                Else
                    rdoInactive.Checked = True
                End If
            End With


        Else
            ltrMsg.Text = "No Library Found."
        End If
    End Sub

    Private Sub AddLibraryData()

        Try
            Dim intStatus As Integer = 1
            If rdoActive.Checked Then
                intStatus = 1
            Else
                intStatus = 0
            End If
            Dim intSethome As Integer = 0

            Dim strExt As String = ""
            Dim strPhoto As String = ""
            Dim file_img_s As HttpPostedFile = photo.PostedFile
            Dim file_name_s As String = Path.GetFileName(file_img_s.FileName)
            Dim file_len_s As Integer = file_img_s.ContentLength
            Dim file_typ_s As String = Path.GetExtension(file_img_s.FileName).ToLower
            If Not (file_typ_s = ".jpg" Or file_typ_s = ".gif" Or file_typ_s = ".bmp" Or file_typ_s = ".jpeg" Or file_typ_s = ".png") Then
                ltrMsg.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
                Exit Sub
            End If
            'If file_len_s > 8000000 Then
            '    lblMessage.Text = "Image - File Upload Size exceed maximum (2000000 Bytes)"
            '    Exit Sub
            'End If

            Dim strLogo As String = ""
            strExt = IO.Path.GetExtension(photo.PostedFile.FileName).ToLower
            Dim strDate As Date = "1/1/1900"
            strLogo = "fanfriday-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & strExt

            If Not File.Exists(Server.MapPath("../content/adminuploads/" & file_name_s)) Then
                file_img_s.SaveAs(Server.MapPath("../content/adminuploads/" & file_name_s))
            End If

            Dim objAddFanFriday As New BALFanFriday
            objAddFanFriday.Title = txtTitle.Value
            'objAddFanFriday.Description = txtDescription.Value
            objAddFanFriday.Photo = file_name_s
            objAddFanFriday.SetHome = intSethome
            objAddFanFriday.Status = intStatus

            objAddFanFriday.AddFanFriday()

            ltrMsg.Text = "Fan Friday Added Successfully"
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
    End Sub

End Class