Imports System
Imports System.Web
Imports System.IO

Public Class Upload1
    Implements IHttpHandler
    Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
        'HttpContext.Current.Response.End()
        'Dim oFile As HttpPostedFile = context.Request.Files("Filedata")
        'Dim sDirectory As String = HttpContext.Current.Server.MapPath("/uploads/")
        'HttpContext.Current.Response.Write("<script>alert('asdf');</script>")
        'oFile.SaveAs(sDirectory + "rajni.jpg")
        'If Not Directory.Exists(sDirectory) Then
        '    Directory.CreateDirectory(sDirectory)
        'End If
        context.Response.Write("1")
    End Sub
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class
