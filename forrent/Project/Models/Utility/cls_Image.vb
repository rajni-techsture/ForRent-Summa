Imports System.IO
Public Class cls_Image

    Shared Function SaveFile(ByVal FilePath As String, ByRef FileName As String, ByVal flFile As HtmlInputFile, ByVal CurrentFile As String, Optional ByVal Extension As String = ".jpg,.gif,.png,.jpeg,.bmp") As String
        Try
            Dim strExt As String = ""
            FilePath = HttpContext.Current.Server.MapPath("~/" & FilePath)
            If Path.GetFileName(flFile.PostedFile.FileName) <> "" AndAlso flFile.PostedFile.ContentLength > 0 Then
                strExt = IO.Path.GetExtension(flFile.PostedFile.FileName).ToLower
                Dim ArrExt = Extension.Split(",")
                If ArrExt.Contains(strExt) Then
                    FileName = FileName & strExt
                    flFile.PostedFile.SaveAs(FilePath & FileName)
                Else
                    FileName = ""
                    Return "File must be " & Extension.Replace(",", " or ")
                End If
            Else
                FileName = CurrentFile
            End If
            Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function DefaultImage() As String
        Return Utils.ApplicationSSLPath & "/images/noimage.png"
    End Function
End Class
