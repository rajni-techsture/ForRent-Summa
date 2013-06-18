Public Class download
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fileName As String = Request("Image") 'Session("ImageName")
        Dim filePath As String = Server.MapPath("~/" & "Content/uploads/resize/" & fileName)
        Response.Clear()
        Response.AppendHeader("content-disposition", "attachment; filename=" & fileName)
        Response.ContentType = "image/jpg"
        Response.WriteFile(filePath)
        Response.Flush()
        Response.End()
    End Sub

End Class