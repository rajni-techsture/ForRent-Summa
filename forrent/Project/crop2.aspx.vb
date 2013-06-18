Imports System.Drawing
Imports System.Drawing.Drawing2D

Partial Public Class crop2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'End If
        'imgflImage.Src = Request("flImage").ToString.Replace("&D=150x180", "") 'ConfigurationManager.AppSettings("AppPath") & "Content/images/" & Request("flImage")
        'imgflImage.Src = ConfigurationManager.AppSettings("AppPath") & "Content/images/" & Request("flImage")
        'hdnflImage.Value = "Conteont/images/" & Request("flImage")
    End Sub

    Private Sub btnCropImage_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCropImage.ServerClick

        'Response.Write(hdnflImage.Value)
        Dim bm_source As New Bitmap(Server.MapPath("~") & "Content/uploads/resize/" & Session("ResizeImage").ToString)
        Dim bm_dest As New Bitmap(CInt(txtImageW.Value), CInt(txtImageH.Value))
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
        gr_dest.DrawImage(bm_source, 0, 0, _
        bm_dest.Width + 1, _
        bm_dest.Height + 1)
        Dim bmNew As New Bitmap(CInt(txtCropW.Value), CInt(txtCropH.Value))
        bmNew = CropImage(bm_dest, txtCropW.Value, txtCropH.Value)
        Dim strDate12 As Date = "1/1/1900"
        Dim strflImage As String = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now()))
        bmNew.Save(Server.MapPath("~") & "Content/uploads/resize/" & strflImage & ".jpg")
        imgfinalCropImage.Src = ConfigurationManager.AppSettings("AppPath") & "Content/uploads/resize/" & strflImage & ".jpg"
        lnkDownload.HRef = "download.aspx?Image=" & strflImage & ".jpg"


        'Dim bmOrg As New Bitmap(CInt(txtImageW.Value), CInt(txtImageH.Value))
        'bmOrg = Image.FromFile(Server.MapPath("~") & "Content/uploads/resize/" & Session("ResizeImage").ToString)
        'bmOrg.Save(Server.MapPath("~") & "Content/uploads/resize/rajni.jpg")
        ''Dim bmNew As New Bitmap(CInt(txtCropW.Value), CInt(txtCropH.Value))
        'bmNew = CropImage(bmOrg, txtCropW.Value, txtCropH.Value)
        'Dim strDate12 As Date = "1/1/1900"
        'Dim strflImage As String = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now()))
        'bmNew.Save(Server.MapPath("~") & "Content/uploads/resize/" & strflImage & ".jpg")
        'imgfinalCropImage.Src = ConfigurationManager.AppSettings("AppPath") & "Content/uploads/resize/" & strflImage & ".jpg"
        'lnkDownload.HRef = "download.aspx?Image=" & strflImage & ".jpg"

        'Dim bmpImage As New Bitmap(Server.MapPath("~") & "Content/uploads/resize/" & Session("ResizeImage").ToString)
        ''Dim bmpImage As New Bitmap(Server.MapPath("") & "/" & imgflImage.Src)
        ''bmpImage = CropImage(bmpImage, New Point(hdnCordinates.Value.Split("#")(0).ToString(), hdnCordinates.Value.Split("#")(1).ToString()), New Point(hdnCordinates.Value.Split("#")(2).ToString(), hdnCordinates.Value.Split("#")(3).ToString()))
        'bmpImage = CropImage(bmpImage, txtCropW.Value, txtCropH.Value)
        'Dim strDate12 As Date = "1/1/1900"
        'Dim strflImage As String = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now()))
        'bmpImage.Save(Server.MapPath("~") & "Content/uploads/resize/" & strflImage & ".jpg")
        'imgfinalCropImage.Src = ConfigurationManager.AppSettings("AppPath") & "Content/uploads/resize/" & strflImage & ".jpg"
        'lnkDownload.HRef = "download.aspx?Image=" & strflImage & ".jpg"
    End Sub

    Private Function CropImage(ByVal OriginalImage As Bitmap, ByVal TopLeft As Integer, ByVal BottomRight As Integer) As Bitmap
        'Response.Write(BottomRight.X & " " & BottomRight.Y & " " & TopLeft.X & " " & TopLeft.Y & "<br/>")
        Dim btmCropped As New Bitmap(TopLeft, BottomRight)
        Dim grpOriginal As Graphics = Graphics.FromImage(btmCropped)
        ' Response.Write(btmCropped.Width & " " & btmCropped.Height)
        grpOriginal.DrawImage(OriginalImage, New Rectangle(0, 0, CInt(txtCropW.Value), CInt(txtCropH.Value)), _
             CInt(txtCropX.Value), CInt(txtCropY.Value), CInt(txtCropW.Value), CInt(txtCropH.Value), GraphicsUnit.Pixel)
        grpOriginal.Dispose()
        Return btmCropped
    End Function


    Private Sub btnUpload_ServerClick(sender As Object, e As System.EventArgs) Handles btnUpload.ServerClick
        Dim strExt As String = ""
        Dim strPhoto As String = ""
        If flImage.PostedFile.ContentLength > 0 Then
            Dim uploadContent = flImage.PostedFile.ContentLength / 1000
            strExt = IO.Path.GetExtension(flImage.PostedFile.FileName).ToLower
            If strExt = ".jpg" Or strExt = ".gif" Or strExt = ".bmp" Or strExt = ".jpeg" Or strExt = ".png" Then
                Dim strdate As Date = "1/1/1900"
                strPhoto = "picture-" & CStr(DateDiff(DateInterval.Second, strdate, Now())) & strExt
                flImage.PostedFile.SaveAs(Server.MapPath("~/" & "Content\uploads\resize\" & strPhoto))
                Session("ResizeImage") = strPhoto
                imgPhoto.Src = "Content/uploads/resize/" & strPhoto
            Else
                lblMessage.Visible = True
                lblMessage.Text = "File must be .jpg or .gif or .png or .jpeg or .tif or .bmp"
            End If
        End If
        'photopath = Server.MapPath("~/" & "Content/uploads/images/" & strPhoto)

        'imgPhoto.Src = photopath
    End Sub

    Private Sub btnCropResize_ServerClick(sender As Object, e As System.EventArgs) Handles btnCropResize.ServerClick
        'Response.Write(ConfigurationManager.AppSettings("AppPath") & "resize-tabs.ashx?P=Content/uploads/resize/" & Session("ResizeImage").ToString & "&D=" & txtImageW.Value & "x" & txtImageH.Value)
        'Response.End()
        Dim bm_source As New Bitmap(Server.MapPath("~") & "Content/uploads/resize/" & Session("ResizeImage").ToString)
        Dim bmNew As New Bitmap(CInt(txtImageW.Value), CInt(txtImageH.Value))
        bmNew = CropResize(bm_source, txtImageW.Value, txtImageH.Value)
        Dim strDate12 As Date = "1/1/1900"
        Dim strflImage As String = "picture-" & CStr(DateDiff(DateInterval.Second, strDate12, Now()))
        bmNew.Save(Server.MapPath("~") & "Content/uploads/resize/" & strflImage & ".jpg")
        imgfinalCropImage.Src = ConfigurationManager.AppSettings("AppPath") & "Content/uploads/resize/" & strflImage & ".jpg"
        lnkDownload.HRef = "download.aspx?Image=" & strflImage & ".jpg"
        'imgfinalCropImage.Src = ConfigurationManager.AppSettings("AppPath") & "resize.ashx?P=Content/uploads/resize/" & Session("ResizeImage").ToString & "&D=" & txtImageW.Value & "x" & txtImageH.Value
        'lnkDownload.HRef = ""
    End Sub

    Private Function CropResize(ByVal OriginalImage As Bitmap, ByVal TopLeft As Integer, ByVal BottomRight As Integer) As Bitmap
        'Response.Write(BottomRight.X & " " & BottomRight.Y & " " & TopLeft.X & " " & TopLeft.Y & "<br/>")
        Dim btmCropped As New Bitmap(TopLeft, BottomRight)
        Dim grpOriginal As Graphics = Graphics.FromImage(btmCropped)
        ' Response.Write(btmCropped.Width & " " & btmCropped.Height)
        grpOriginal.SmoothingMode = SmoothingMode.AntiAlias
        grpOriginal.InterpolationMode = InterpolationMode.HighQualityBicubic
        grpOriginal.DrawImage(OriginalImage, 0, 0, CInt(txtImageW.Value), CInt(txtImageH.Value))
        grpOriginal.Dispose()
        Return btmCropped
    End Function
End Class