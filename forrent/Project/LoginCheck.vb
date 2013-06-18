Imports System.Web.HttpContext
Public Class LoginCheck

#Region "Facebook Access Token Checkup"
    Public Shared Sub LoginSessionCheck()
        If Current.Session("FacebookAccessToken") Is Nothing Then
            Redirect()
        Else
            If Convert.ToString(Current.Session("FacebookAccessToken")) = "" Then
                Redirect()
            End If
        End If
        If Current.Session("FacebookUserId") Is Nothing Then
            Redirect()
        Else
            If Convert.ToString(Current.Session("FacebookUserId")) = "" Then
                Redirect()
            End If
        End If
        If Current.Session("FacebookUserName") Is Nothing Then
            Redirect()
        Else
            If Convert.ToString(Current.Session("FacebookUserName")) = "" Then
                Redirect()
            End If
        End If

        If Current.Session("SiteUserId") Is Nothing Then
            Redirect()
        Else
            If Convert.ToString(Current.Session("SiteUserId")) = "" Then
                Redirect()
            End If
        End If
        'If Current.Session("SiteUserName") Is Nothing Then
        '    Redirect()
        'Else
        '    If Convert.ToString(Current.Session("SiteUserName")) = "" Then
        '        Redirect()
        '    End If
        'End If

        If GetSetCookies.GetCookie("CompanyId") Is Nothing Then
            Redirect()
        Else
            If Convert.ToString(GetSetCookies.GetCookie("CompanyId")) = "" Then
                Redirect()
            End If
        End If
        If GetSetCookies.GetCookie("IndustryId") Is Nothing Then
            Redirect()
        Else
            If Convert.ToString(GetSetCookies.GetCookie("IndustryId")) = "" Then
                Redirect()
            End If
        End If
    End Sub
#End Region

#Region "Redirect"
    Private Shared Sub Redirect()
        HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("AppPath"))
    End Sub
#End Region

#Region "Only Check"
    Public Shared Function LoginSessionCheckOnly() As Boolean
        Dim result As Boolean = True
        If Current.Session("FacebookAccessToken") Is Nothing Then
            result = False
        Else
            If Convert.ToString(Current.Session("FacebookAccessToken")) = "" Then
                result = False
            End If
        End If
        If Current.Session("FacebookUserId") Is Nothing Then
            result = False
        Else
            If Convert.ToString(Current.Session("FacebookUserId")) = "" Then
                result = False
            End If
        End If
        If Current.Session("FacebookUserName") Is Nothing Then
            result = False
        Else
            If Convert.ToString(Current.Session("FacebookUserName")) = "" Then
                result = False
            End If
        End If

        If Current.Session("SiteUserId") Is Nothing Then
            result = False
        Else
            If Convert.ToString(Current.Session("SiteUserId")) = "" Then
                result = False
            End If
        End If
        If Current.Session("SiteUserName") Is Nothing Then
            result = False
        Else
            If Convert.ToString(Current.Session("SiteUserName")) = "" Then
                result = False
            End If
        End If

        If GetSetCookies.GetCookie("CompanyId") Is Nothing Then
            result = False
        Else
            If Convert.ToString(GetSetCookies.GetCookie("CompanyId")) = "" Then
                result = False
            End If
        End If
        If GetSetCookies.GetCookie("IndustryId") Is Nothing Then
            result = False
        Else
            If Convert.ToString(GetSetCookies.GetCookie("IndustryId")) = "" Then
                result = False
            End If
        End If
        Return result
    End Function
#End Region

End Class
