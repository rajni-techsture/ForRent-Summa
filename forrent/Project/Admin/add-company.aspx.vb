Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer
Public Class add_company
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim intID As Integer = 0
                If Request("CId") IsNot Nothing Then
                    If IsNumeric(Request("CId")) Then
                        intID = CInt(Request("CId"))
                    End If
                End If
                If intID > 0 Then
                    LoadCompanyData(intID)
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub LoadCompanyData(ByVal intID As Integer)
        Dim objGetCompany As New BALCompany
        Dim ds As New DataSet
        ds = objGetCompany.GetCompany(intID)
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                txtCompanyName.Value = .Item("c_Name").ToString
                If .Item("c_IsPasswordRequired").ToString = "1" Then
                    drpPassword.Value = .Item("c_IsPasswordRequired").ToString
                    trPassword.Style.Add("display", "")
                Else
                    drpPassword.Value = .Item("c_IsPasswordRequired").ToString
                    trPassword.Style.Add("display", "none")
                End If

                If .Item("c_Password").ToString = "" Then
                    txtPassword.Value = .Item("c_Password").ToString
                Else
                    txtPassword.Value = Utility.Decryption(.Item("c_Password").ToString)
                End If

                imgPhoto.Src = "../content/adminuploads/" & .Item("c_Icon").ToString
                hdnImage.Value = .Item("c_Icon").ToString
                hdnimagevalue.Value = .Item("c_Icon").ToString
                lblIcon.Text = .Item("c_Icon").ToString
                lblcss.Text = .Item("c_Style").ToString
                hdncss.Value = .Item("c_Style").ToString
                hdncssvalue.Value = .Item("c_Style").ToString
                If .Item("c_Status") = 1 Then
                    rdoActive.Checked = True
                Else
                    rdoInactive.Checked = True
                End If
            End With


        Else
            ltrMsg.Text = "No Company Found."
        End If
    End Sub
    Private Sub btnSave_ServerClick(sender As Object, e As System.EventArgs) Handles btnSave.ServerClick
        If Session("AUserName") <> Nothing Then


            Dim intID As Integer = 0
            If Request("CId") IsNot Nothing Then
                If IsNumeric(Request("CId")) Then
                    intID = CInt(Request("CId"))
                End If
            End If

            If intID > 0 Then
                UpdateCompany(intID)
            Else
                AddCompany()
            End If

        Else
            Response.Redirect("login.aspx")
        End If

    End Sub

    Private Sub AddCompany()

        Dim intCompanyID As Integer = 0

        Dim intStatus As Integer = 1
        If rdoActive.Checked Then
            intStatus = 1
        Else
            intStatus = 0
        End If

        If Not (imgIcon.PostedFile Is Nothing) And (CType(imgIcon.PostedFile.FileName, String) <> "") Then
            Dim file_img_s As HttpPostedFile = imgIcon.PostedFile
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
            Dim strExt As String
            Dim strLogo As String = ""
            strExt = IO.Path.GetExtension(imgIcon.PostedFile.FileName).ToLower
            Dim strDate As Date = "1/1/1900"
            strLogo = "icon-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & strExt

            If Not File.Exists(Server.MapPath("../content/adminuploads/" & file_name_s)) Then
                file_img_s.SaveAs(Server.MapPath("../content/adminuploads/" & file_name_s))
            End If


            Dim file_css As HttpPostedFile = cssfile.PostedFile
            Dim file_name_css As String = Path.GetFileName(file_css.FileName)


            Dim file_len_css As Integer = file_css.ContentLength
            Dim file_typ_css As String = Path.GetExtension(file_css.FileName).ToLower
            If Not (file_typ_css = ".css") Then
                ltrMsg.Text = "File must be .css "
                Exit Sub
            End If
            'If file_len_css > 8000000 Then
            '    lblMessage.Text = "Image - File Upload Size exceed maximum (2000000 Bytes)"
            '    Exit Sub
            'End If
            'Dim strcssExt As String
            'Dim strcss As String = ""
            'strcssExt = IO.Path.GetExtension(cssfile.PostedFile.FileName).ToLower
            'Dim strcssDate As Date = "1/1/1900"
            'strcss = "icon-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & strExt

            If Not File.Exists(Server.MapPath("../content/css/" & file_name_css)) Then
                file_css.SaveAs(Server.MapPath("../content/css/" & file_name_css))
            End If


            Dim objAddCompany As New BALCompany

            objAddCompany.CompanyName = txtCompanyName.Value
            objAddCompany.IsRequired = drpPassword.Value
            objAddCompany.Password = If(txtPassword.Value <> "", Utility.Encryption(txtPassword.Value).ToString, "")
            objAddCompany.CompanyIcon = file_name_s
            objAddCompany.CompanyStyle = file_name_css
            objAddCompany.Status = intStatus


            intCompanyID = objAddCompany.AddCompany()

            If intCompanyID = 0 Then
                ltrMsg.Text = "Company Name already exists, please enter other."
            ElseIf intCompanyID = 2 Then
                ltrMsg.Text = "Email Address already available, please enter other."
            Else
                'objConn.ExecuteSQL("exec prc_assignMenuaccess " & intUserID)
                ' CreateXMLMenu(intUserID, Replace(Trim(txtUserName.Value), "'", "''"))
                ' ClearData()
                ltrMsg.Text = "Company Added Successfully"

            End If
        Else
            ltrMsg.Text = "Please Choose Image"
        End If

    End Sub

    Private Sub UpdateCompany(ByVal intID As Integer)
        'Try
        Dim intCompanyID As Integer = 0

        Dim intStatus As Integer = 1
        If rdoActive.Checked Then
            intStatus = 1
        Else
            intStatus = 0
        End If


        Dim file_name_s As String = ""
        Dim file_name_css As String = ""
        If imgIcon.PostedFile.FileName <> "" Then
            Dim file_img_s As HttpPostedFile = imgIcon.PostedFile
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
            Dim strExt As String
            Dim strLogo As String = ""
            strExt = IO.Path.GetExtension(imgIcon.PostedFile.FileName).ToLower
            Dim strDate As Date = "1/1/1900"
            strLogo = "icon-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & strExt

            If Not File.Exists(Server.MapPath("../content/adminuploads/" & file_name_s)) Then
                file_img_s.SaveAs(Server.MapPath("../content/adminuploads/" & file_name_s))
            End If
        End If

        If intID > 0 And imgIcon.PostedFile.FileName = "" Then
            file_name_s = hdnImage.Value
        End If

        If cssfile.PostedFile.FileName <> "" Then
            Dim file_css As HttpPostedFile = cssfile.PostedFile
            file_name_css = Path.GetFileName(file_css.FileName)
            Dim file_len_css As Integer = file_css.ContentLength
            Dim file_typ_css As String = Path.GetExtension(file_css.FileName).ToLower
            If Not (file_typ_css = ".css") Then
                ltrMsg.Text = "File must be .css "
                Exit Sub
            End If
            'If file_len_css > 8000000 Then
            '    lblMessage.Text = "Image - File Upload Size exceed maximum (2000000 Bytes)"
            '    Exit Sub
            'End If
            'Dim strcssExt As String
            'Dim strcss As String = ""
            'strcssExt = IO.Path.GetExtension(cssfile.PostedFile.FileName).ToLower
            'Dim strcssDate As Date = "1/1/1900"
            'strcss = "icon-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & strExt

            If Not File.Exists(Server.MapPath("../content/css/" & file_name_css)) Then
                file_css.SaveAs(Server.MapPath("../content/css/" & file_name_css))
            End If
        End If

        If intID > 0 And cssfile.PostedFile.FileName = "" Then
            file_name_css = hdncss.Value
        End If


        Dim objUpdateCompany As New BALCompany

        objUpdateCompany.CompanyName = txtCompanyName.Value
        objUpdateCompany.IsRequired = drpPassword.Value
        objUpdateCompany.Password = If(txtPassword.Value <> "", Utility.Encryption(txtPassword.Value).ToString, "")
        objUpdateCompany.CompanyIcon = file_name_s
        objUpdateCompany.CompanyStyle = file_name_css
        objUpdateCompany.Status = intStatus


        intCompanyID = objUpdateCompany.UpdateCompany(intID)

        If intCompanyID = 1 Then
            Response.Redirect("manage-companies.aspx?mode=edit")
        ElseIf intCompanyID = 2 Then
            ltrMsg.Text = "Company Name already exists, please enter other."
        End If


    End Sub
End Class