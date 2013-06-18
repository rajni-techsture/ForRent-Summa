Imports System.Web

Public Class GetSetCookies
    Shared Sub SetCookie(ByVal Key As String, ByVal Value As String, ByVal intDays As Int16)
        With HttpContext.Current
            Dim aCookie As New HttpCookie(Key)
            aCookie.Value = Value
            aCookie.Expires = DateTime.Now.AddDays(intDays)
            .Response.Cookies.Add(aCookie)
        End With
    End Sub
    'Shared Sub SetCookie1(ByVal Key As String, ByVal Value As Integer, ByVal intDays As Int16)
    '    With HttpContext.Current
    '        Dim aCookie As New HttpCookie(Key)
    '        aCookie.Value = Value
    '        aCookie.Expires = DateTime.Now.AddDays(intDays)
    '        .Response.Cookies.Add(aCookie)
    '    End With
    'End Sub

    Shared Function GetCookie(ByVal Key As String) As String
        With HttpContext.Current
            If Not .Request.Cookies(Key) Is Nothing Then
                Dim aCookie As HttpCookie = .Request.Cookies(Key)
                Return .Server.HtmlEncode(aCookie.Value)
                'Return .Server.HtmlEncode(Convert.ToInt32(aCookie.Value))
            End If
        End With
        Return ""
    End Function

    'Shared Function GetCookie1(ByVal Key As String) As String
    '    With HttpContext.Current
    '        If Not .Request.Cookies(Key) Is Nothing Then
    '            Dim aCookie As HttpCookie = .Request.Cookies(Key)
    '            Return .Server.HtmlEncode(aCookie.Value)
    '        End If
    '    End With
    '    Return ""
    'End Function
    Shared Function GetCookies(p1 As String) As Object
        Throw New NotImplementedException
    End Function

End Class
