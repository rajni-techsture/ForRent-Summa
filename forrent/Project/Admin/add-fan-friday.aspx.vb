Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer
Public Class add_fan_friday
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim intID As Integer = 0
                If Request("FFId") IsNot Nothing Then
                    If IsNumeric(Request("FFId")) Then
                        intID = CInt(Request("FFId"))
                    End If
                End If
                If intID > 0 Then
                    LoadFanFridayData(intID)
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub btnSave_ServerClick(sender As Object, e As System.EventArgs) Handles btnSave.ServerClick
        If Session("AUserName") <> Nothing Then


            Dim intID As Integer = 0
            If Request("FFId") IsNot Nothing Then
                If IsNumeric(Request("FFId")) Then
                    intID = CInt(Request("FFId"))
                End If
            End If

            If intID > 0 Then
                UpdateFanFriday(intID)
            Else
                AddFanFriday()
            End If

        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Private Sub LoadFanFridayData(ByVal intID As Integer)
        Dim objGetFF As New BALFanFriday
        Dim ds As New DataSet
        ds = objGetFF.GetFanFriday(intID)
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                txtTitle.Value = .Item("ff_Title").ToString
                txtDescription1.Value = .Item("ff_Description").ToString
                imgPhoto.Src = "../content/adminuploads/" & .Item("ff_Photo").ToString
                hdnImage.Value = .Item("ff_Photo").ToString
                hdnimagevalue.Value = .Item("ff_Photo").ToString
                lblPhoto.Text = .Item("ff_Photo").ToString
               
                If .Item("ff_SetHome") = 1 Then
                    chkHome.Checked = True
                Else
                    chkHome.Checked = False
                End If
                If .Item("ff_Status") = 1 Then
                    rdoActive.Checked = True
                Else
                    rdoInactive.Checked = True
                End If
            End With


        Else
            ltrMsg.Text = "No Fan Friday Found."
        End If
    End Sub
    Private Sub AddFanFriday()

        Try
            Dim intStatus As Integer = 1
            If rdoActive.Checked Then
                intStatus = 1
            Else
                intStatus = 0
            End If
            Dim intSethome As Integer = 0
            If chkHome.Checked Then
                intSethome = 1
            Else
                intSethome = 0
            End If
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
            objAddFanFriday.Description = txtDescription1.Value
            objAddFanFriday.Photo = file_name_s
            objAddFanFriday.SetHome = intSethome
            objAddFanFriday.Status = intStatus

            objAddFanFriday.AddFanFriday()

            ltrMsg.Text = "Fan Friday Added Successfully"
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub UpdateFanFriday(ByVal intID As Integer)
        'Try
        Dim intFFid As Integer

      Dim intStatus As Integer = 1
        If rdoActive.Checked Then
            intStatus = 1
        Else
            intStatus = 0
        End If
        Dim intSethome As Integer = 0
        If chkHome.Checked Then
            intSethome = 1
        Else
            intSethome = 0
        End If
        Dim strExt As String = ""
        Dim strPhoto As String = ""
        Dim file_name_s As String = ""

        Dim file_name_css As String = ""
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
            strLogo = "fanfriday-" & CStr(DateDiff(DateInterval.Second, strDate, Now())) & strExt

            If Not File.Exists(Server.MapPath("../content/adminuploads/" & file_name_s)) Then
                file_img_s.SaveAs(Server.MapPath("../content/adminuploads/" & file_name_s))
            End If
        End If

        If intID > 0 And photo.PostedFile.FileName = "" Then
            file_name_s = hdnImage.Value
        End If
    
        Dim objUpdateFanFriday As New BALFanFriday

        objUpdateFanFriday.Title = txtTitle.Value
        objUpdateFanFriday.Description = txtDescription1.Value
        objUpdateFanFriday.Photo = file_name_s
        objUpdateFanFriday.SetHome = intSethome
        objUpdateFanFriday.Status = intStatus

        intFFid = objUpdateFanFriday.UpdateFanFriday(intID)
        If intFFid = 1 Then
            Response.Redirect("manage-fan-friday.aspx?mode=edit")
        ElseIf intFFid = 2 Then
            ltrMsg.Text = "Fan Friday Name already exists, please enter other."
        End If


    End Sub
End Class