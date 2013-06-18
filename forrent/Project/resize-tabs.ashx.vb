Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Web
Imports System.Web.Services

Public Class resize_tabs
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        ' Try
        With context.Request
            Dim strPath As String = .QueryString("P")
            Dim strData As String()
            strData = .QueryString("D").ToLower.Split("x")
            Dim strWidth As String = strData(0)
            Dim strHeight As String = strData(1)

            Dim intResizeType As String = "1"
            If strData.Length > 2 Then
                intResizeType = strData(2)
            End If
            Dim strFilePath As String = context.Server.MapPath("~\" & strPath)

            context.Response.Clear()
            context.Response.ContentType = "image/jpeg"
            ResizeImageFile(strFilePath, CInt(strHeight), CInt(strWidth), Convert.ToSingle(intResizeType)).WriteTo(context.Response.OutputStream)
            'ResizeImageFile(strFilePath, Convert.ToSingle(intResizeType)).WriteTo(context.Response.OutputStream)
            context.Response.End()
        End With
        'Catch ex As Exception

        'End Try

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Private Function ResizeImageFile(ByVal strFileName As String, ByVal height As Integer, ByVal width As Integer, ByVal intResizeType As Single) As MemoryStream
        Using oldImage As Image = System.Drawing.Image.FromFile(strFileName)
            Dim oldwidth As Single = oldImage.Width
            Dim oldheight As Single = oldImage.Height

            Dim thumbHeight As Integer = height
            Dim thumbWidth As Integer = width

            If (intResizeType = 1) Then
                If (oldwidth > width) Then
                    Dim def As Double = width
                    Dim imgwidth As Double = Convert.ToDouble(oldwidth)
                    Dim diff As Double = (def / imgwidth)
                    thumbWidth = Convert.ToInt16(Math.Round(diff * oldwidth))
                    thumbHeight = Convert.ToInt16(Math.Round(diff * oldheight))
                Else
                    thumbWidth = oldwidth
                    thumbHeight = oldheight
                End If

                If (thumbHeight > height) Then
                    Dim def As Double = height
                    Dim imgheight As Double = Convert.ToDouble(thumbHeight)
                    Dim diff As Double = (def / imgheight)
                    thumbWidth = Convert.ToInt16(Math.Round(diff * thumbWidth))
                    thumbHeight = height
                End If
            End If

            Dim newSize As New Size(thumbWidth, thumbHeight)
            Using newImage As New Bitmap(newSize.Width - 3, newSize.Height - 3, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                Using canvas As Graphics = Graphics.FromImage(newImage)
                    canvas.Clear(Color.Transparent)
                    canvas.SmoothingMode = SmoothingMode.AntiAlias
                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
                    canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
                    canvas.DrawImage(oldImage, New Rectangle(New Point(-1, -1), newSize))
                    Dim m As New MemoryStream()
                    newImage.Save(m, System.Drawing.Imaging.ImageFormat.Png)
                    Return m
                End Using
            End Using
        End Using
    End Function
    Private Function ResizeImageFile_Old(ByVal strFileName As String, ByVal intResizeType As Single) As MemoryStream
        Using oldImage As Image = System.Drawing.Image.FromFile(strFileName)
            Dim oldwidth As Single = oldImage.Width
            Dim oldheight As Single = oldImage.Height

            'Dim thumbHeight As Integer = height
            'Dim thumbWidth As Integer = width

            'If (intResizeType = 1) Then
            '    If (oldwidth > width) Then
            '        'Dim def As Double = width
            '        'Dim imgwidth As Double = Convert.ToDouble(oldwidth)
            '        'Dim diff As Double = (def / imgwidth)
            '        'thumbWidth = Convert.ToInt16(Math.Round(diff * oldwidth))
            '        'thumbHeight = Convert.ToInt16(Math.Round(diff * oldheight))
            '    Else
            '        thumbWidth = oldwidth
            '        thumbHeight = oldheight
            '    End If

            '    If (thumbHeight > height) Then
            '        'Dim def As Double = height
            '        'Dim imgheight As Double = Convert.ToDouble(thumbHeight)
            '        'Dim diff As Double = (def / imgheight)
            '        'thumbWidth = Convert.ToInt16(Math.Round(diff * thumbWidth))
            '        ''context.Response.Write("thumbnail width " & thumbWidth & "<br/>")
            '        ''context.Response.Write("thumbnail height " & thumbHeight & "<br/>")
            '        ''HttpContext.Current.Response.End()
            '        ''context.Response.End()
            '    End If
            'End If
            Dim newSize As New Size(oldwidth + 3, oldheight + 3)
            Using newImage As New Bitmap(newSize.Width - 3, newSize.Height - 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                Using canvas As Graphics = Graphics.FromImage(newImage)
                    canvas.SmoothingMode = SmoothingMode.AntiAlias
                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
                    canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
                    canvas.DrawImage(oldImage, New Rectangle(New Point(-1, -1), newSize))
                    Dim m As New MemoryStream()
                    newImage.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Return m
                End Using
            End Using
        End Using
    End Function
End Class