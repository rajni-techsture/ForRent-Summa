Imports BusinessAccessLayer.BusinessLayer
Imports System.Runtime.Serialization.Json
Imports System.IO
Public Class tab
    Inherits System.Web.UI.Page

    Dim objCustomTab As New CustomTabContent
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strContent As String = ""
            Dim payload As String = Request.Form("signed_request").Split("."c)(1)
            Dim encoding = New UTF8Encoding()
            Dim decodedJson = payload.Replace("=", String.Empty).Replace("-"c, "+"c).Replace("_"c, "/"c)
            Dim base64JsonArray = Convert.FromBase64String(decodedJson.PadRight(decodedJson.Length + (4 - decodedJson.Length Mod 4) Mod 4, "="c))
            Dim json = encoding.GetString(base64JsonArray)
            Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json))
            Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(CustomTab))
            Dim cTab As New CustomTab()
            cTab = TryCast(dataContractJsonSerializer.ReadObject(stream), CustomTab)
            objCustomTab.FBPageId = cTab.page.id
            objCustomTab.GetCustomTabContent()
            divContent.InnerHtml = objCustomTab.Content.Replace("<br/>", "").Replace("notextedit", "").Replace("setLocation", "")
            hdnFBUserId.Value = objCustomTab.FBUserId
            hdnFBPageName.Value = objCustomTab.FBPageName
            hdnFBPageId.Value = objCustomTab.FBPageId
            hdnFBPageURL.Value = objCustomTab.FBPageURL
        Catch ex As Exception
        End Try
    End Sub
End Class