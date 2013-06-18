Imports Microsoft.VisualBasic
Imports System.Web.Routing
Imports System.Web
Imports System.Web.UI

Public Interface IRoutablePage
    ' Properties
    Property RequestContext() As RequestContext
End Interface

Public Class RoutablePage
    Inherits Page
    Implements IRoutablePage
    ' Fields
    Protected _requestContext As RequestContext

    ' Methods
    Public Function ActionLink(ByVal url As String) As String
        Return Me.ActionLink(url, url)
    End Function

    Protected Function ActionLink(ByVal url As String, ByVal [text] As String) As String
        Return String.Format("<a href=""{0}"">{1}</a>", url, [text])
    End Function

    Public Function GetVirtualPath(ByVal values As Object) As String
        Return Me.GetVirtualPath(Nothing, values)
    End Function

    Public Function GetVirtualPath(ByVal routeName As String, ByVal values As Object) As String
        If (Me.RequestContext Is Nothing) Then
            Return Nothing
        End If
        Return RouteTable.Routes.GetVirtualPath(Me.RequestContext, routeName, New RouteValueDictionary(values)).VirtualPath
    End Function

    Protected Function RouteValue(ByVal key As String) As Object
        Return Me.RequestContext.RouteData.Values.Item(key)
    End Function

    ' Properties
    Public ReadOnly Property BaseUrl() As String
        Get
            Return (MyBase.Request.Url.GetLeftPart(1) & System.Web.VirtualPathUtility.ToAbsolute("~/"))
        End Get
    End Property

    Public Property RequestContext() As RequestContext Implements IRoutablePage.RequestContext
        Set(ByVal value As RequestContext)
            _requestContext = value
        End Set
        Get
            Return _requestContext
        End Get
    End Property

#Region "Move viewState at the bottom of the Page"
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter
        Dim htmlWriter As HtmlTextWriter = New HtmlTextWriter(stringWriter)
        MyBase.Render(htmlWriter)
        Dim html As String = stringWriter.ToString
        Dim StartPoint As Integer
        StartPoint = html.IndexOf("<input type=""hidden"" name=""__VIEWSTATE""")
        If (StartPoint >= 0) Then
            Dim EndPoint As Integer = (html.IndexOf("/>", StartPoint) + 2)
            Dim viewstateInput As String
            viewstateInput = html.Substring(StartPoint, (EndPoint - StartPoint))
            html = html.Remove(StartPoint, (EndPoint - StartPoint))
            Dim FormEndStart As Integer = (html.IndexOf("</form>"))
            If (FormEndStart >= 0) Then
                html = html.Insert(FormEndStart, viewstateInput)
            End If
        End If
        writer.Write(html)
    End Sub
#End Region

End Class