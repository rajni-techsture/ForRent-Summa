Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer

Public Class add_library_data
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                BindType()
                ' BindCompanies()
                'BindIndustries()
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
    Sub BindType()
        drpType.Items.Insert(0, New ListItem("-- Select Type --", "0"))
        drpType.Items.Insert(1, New ListItem("Company", "1"))
        drpType.Items.Insert(2, New ListItem("Industry", "2"))
        drpCompInd.Items.Insert(0, New ListItem("-- Select Company/Industry --", "0"))
        drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))
    End Sub
    Sub BindCompanies()
        Dim objcomp As New BALAdminLibrary

        Dim ds As New DataSet
        ds = objcomp.BindCompanies
        If ds.Tables(0).Rows.Count > 0 Then
            drpCompInd.DataSource = ds.Tables(0)
            drpCompInd.DataTextField = "c_Name"
            drpCompInd.DataValueField = "c_Id"
            drpCompInd.DataBind()
        Else
            drpCompInd.DataSource = Nothing
            drpCompInd.DataBind()
        End If
        drpCompInd.Items.Insert(0, New ListItem("-- Select Company --", "0"))
    End Sub

    Sub BindIndustries()
        Dim objcomp As New BALAdminLibrary

        Dim ds As New DataSet
        ds = objcomp.BindIndustries()
        If ds.Tables(0).Rows.Count > 0 Then
            drpCompInd.DataSource = ds.Tables(0)
            drpCompInd.DataTextField = "i_Name"
            drpCompInd.DataValueField = "i_Id"
            drpCompInd.DataBind()
        Else
            drpCompInd.DataSource = Nothing
            drpCompInd.DataBind()
        End If
        drpCompInd.Items.Insert(0, New ListItem("-- Select Industry --", "0"))
    End Sub

     Sub drpCompany_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpCompany.SelectedIndexChanged
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

    Sub drpIndustry_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpIndustry.SelectedIndexChanged
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
                If .Item("lib_CompanyId").ToString = "0" Then
                    drpType.SelectedValue = "2"
                    BindIndustries()
                    drpCompInd.SelectedValue = .Item("lib_IndustryId").ToString
                    drpCategory.Items.Clear()
                    Dim obj As New BALAdminLibrary
                    obj.IndustryId = drpCompInd.SelectedValue
                    Dim ds2 As New DataSet
                    ds2 = obj.BindCategoriesByIndustryID()
                    If ds2.Tables(0).Rows.Count > 0 Then
                        drpCategory.DataSource = ds2.Tables(0)
                        drpCategory.DataTextField = "lc_Title"
                        drpCategory.DataValueField = "lc_Id"
                        drpCategory.DataBind()
                    Else
                        drpCategory.DataSource = Nothing
                        drpCategory.DataBind()
                    End If
                    drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))
                    ds2 = Nothing
                    drpCategory.SelectedValue = .Item("lib_Category").ToString
                ElseIf .Item("lib_IndustryId").ToString = "0" Then
                    drpType.SelectedValue = "1"
                    BindCompanies()
                    drpCompInd.SelectedValue = .Item("lib_CompanyId").ToString
                    drpCategory.Items.Clear()
                    Dim obj As New BALAdminLibrary
                    obj.CompanyId = drpCompInd.SelectedValue
                    Dim ds2 As New DataSet
                    ds2 = obj.BindCategoriesByCompanyID()
                    If ds2.Tables(0).Rows.Count > 0 Then
                        drpCategory.DataSource = ds2.Tables(0)
                        drpCategory.DataTextField = "lc_Title"
                        drpCategory.DataValueField = "lc_Id"
                        drpCategory.DataBind()
                    Else
                        drpCategory.DataSource = Nothing
                        drpCategory.DataBind()
                    End If
                    drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))
                    ds2 = Nothing
                    drpCategory.SelectedValue = .Item("lib_Category").ToString
                End If



                txtDescription1.Value = .Item("lib_Template").ToString
                txtvideo.Value = .Item("lib_Video").ToString
                hdnUrl.Value = .Item("lib_VideoImage").ToString
                imgThumbnail.Src = .Item("lib_VideoImage").ToString
                hdnVideoId.Value = .Item("lib_VideoId").ToString
                imgPhoto.Src = "../Content/uploads/images/" & .Item("lib_Image").ToString
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
    Private Sub btnSave_ServerClick(sender As Object, e As System.EventArgs) Handles btnSave.ServerClick
        If Session("AUserName") <> Nothing Then


            Dim intID As Integer = 0
            If Request("LDId") IsNot Nothing Then
                If IsNumeric(Request("LDId")) Then
                    intID = CInt(Request("LDId"))
                End If
            End If

            If intID > 0 Then
                UpdateLibraryData(intID)
            Else
                AddLibraryData()
            End If

        Else
            Response.Redirect("login.aspx")
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


            Dim strExt As String = ""
            Dim strPhoto As String = ""
            Dim file_name_s As String = ""
            If photo.PostedFile.ContentLength > 0 Then
                Dim file_img_s As HttpPostedFile = photo.PostedFile
                file_name_s = Path.GetFileName(file_img_s.FileName)
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
                strLogo = "Library-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & strExt

                If Not File.Exists(Server.MapPath("../Content/uploads/images/" & file_name_s)) Then
                    file_img_s.SaveAs(Server.MapPath("../Content/uploads/images/" & file_name_s))
                End If
            End If
            
            Dim objAdd As New BALAdminLibrary
            objAdd.CategoryID = drpCategory.SelectedValue
            If drpType.SelectedValue = "1" Then
                objAdd.CompanyId = drpCompInd.SelectedValue
                objAdd.IndustryId = 0
            ElseIf drpType.SelectedValue = "2" Then
                objAdd.IndustryId = drpCompInd.SelectedValue
                objAdd.CompanyId = 0
            End If
            objAdd.Template = txtDescription1.Value
            objAdd.Image = file_name_s
            'objAdd.Image = txtPhotoName.Value
            objAdd.Video = txtvideo.Value
            objAdd.VideoId = hdnVideoId.Value
            objAdd.VideoImage = hdnUrl.Value
            objAdd.Status = intStatus

            objAdd.AddLibraryData()

            ltrMsg.Text = "Library Added Successfully"
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub UpdateLibraryData(ByVal intID As Integer)
        Try
            Dim intLibID As Integer = 0
            Dim intStatus As Integer = 1
            If rdoActive.Checked Then
                intStatus = 1
            Else
                intStatus = 0
            End If
            Dim file_name_s As String = ""
            Dim strExt As String = ""
            Dim strPhoto As String = ""
            If photo.PostedFile.FileName <> "" Then
                Dim file_img_s As HttpPostedFile = photo.PostedFile
                file_name_s = Path.GetFileName(file_img_s.FileName)
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
                strLogo = "Library-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & strExt

                If Not File.Exists(Server.MapPath("../Content/uploads/images/" & file_name_s)) Then
                    file_img_s.SaveAs(Server.MapPath("../Content/uploads/images/" & file_name_s))
                End If
            End If
            If intID > 0 And photo.PostedFile.FileName = "" Then
                file_name_s = hdnImage.Value
            End If
            Dim objLib As New BALAdminLibrary

            objLib.CategoryID = drpCategory.SelectedValue
            If drpType.SelectedValue = "1" Then
                objLib.CompanyId = drpCompInd.SelectedValue
                objLib.IndustryId = 0
            ElseIf drpType.SelectedValue = "2" Then
                objLib.IndustryId = drpCompInd.SelectedValue
                objLib.CompanyId = 0
            End If
            objLib.Template = txtDescription1.Value
            objLib.Image = file_name_s
            objLib.Video = txtvideo.Value
            objLib.VideoId = hdnVideoId.Value
            objLib.VideoImage = hdnUrl.Value
            objLib.Status = intStatus
            intLibID = objLib.UpdateLibraryData(intID)


            If intLibID = 1 Then
                Response.Redirect("manage-library-data.aspx?mode=edit")
                'ElseIf intLibID = 2 Then
                '    ltrMsg.Text = "Library already exists, please enter other."

            End If

        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Sub drpCompInd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpCompInd.SelectedIndexChanged
        If drpType.SelectedValue = "1" And drpCompInd.SelectedValue <> "0" Then
            drpCategory.Items.Clear()
            Dim obj As New BALAdminLibrary
            obj.CompanyId = drpCompInd.SelectedValue
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
        ElseIf drpType.SelectedValue = "2" And drpCompInd.SelectedValue <> "0" Then
            drpCategory.Items.Clear()
            Dim obj As New BALAdminLibrary
            obj.IndustryId = drpCompInd.SelectedValue
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
        End If


    End Sub
   
    Sub drpType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpType.SelectedIndexChanged
        If drpType.SelectedValue = "1" Then
            BindCompanies()
            drpCategory.Items.Clear()
            drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))
        ElseIf drpType.SelectedValue = "2" Then
            BindIndustries()
            drpCategory.Items.Clear()
            drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))

        ElseIf drpType.SelectedValue = "0" Then
            drpCompInd.Items.Clear()
            drpCategory.Items.Clear()
            drpCompInd.Items.Insert(0, New ListItem("-- Select Company/Industry --", "0"))
            drpCategory.Items.Insert(0, New ListItem("-- Select Category --", "0"))
        End If
    End Sub
End Class