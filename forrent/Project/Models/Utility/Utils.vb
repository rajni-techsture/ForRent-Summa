Imports System.Net.Mail
Imports System.Net

Public Class Utils

    'Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
    '    Try
    '        Dim _allowedChars As String = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789"
    '        Dim randNum As New Random()
    '        Dim chars As Char() = New Char(PasswordLength - 1) {}
    '        Dim allowedCharCount As Integer = _allowedChars.Length

    '        For i As Integer = 0 To PasswordLength - 1
    '            chars(i) = _allowedChars(CInt((_allowedChars.Length) * randNum.NextDouble()))
    '        Next
    '        Return New String(chars)
    '    Catch ex As Exception
    '        Return Now
    '    End Try
    'End Function

    Shared Function RandomString(ByVal iLength As Integer) As String
        Dim sRandomString As String = ""
        Try
            Dim iZero, iNine, iA, iZ, iCount, iRandNum As Integer
            Dim rRandom As New Random(System.DateTime.Now.Millisecond)
            iZero = Asc("0")
            iNine = Asc("9")
            iA = Asc("A")
            iZ = Asc("Z")
            sRandomString = ""
            While (iCount < iLength)
                iRandNum = rRandom.Next(iZero, iZ)
                If (((iRandNum >= iZero) And (iRandNum <= iNine) _
               Or (iRandNum >= iA) And (iRandNum <= iZ))) Then
                    sRandomString = sRandomString + Chr(iRandNum)
                    iCount = iCount + 1
                End If
            End While
            RandomString = sRandomString
        Catch ex As Exception
            sRandomString = Right(String.Format("{0:yyyyMMddhhmmss}", Now) & System.DateTime.Now.Millisecond.ToString, iLength)
            sRandomString = String.Format("{0:x5}", Convert.ToInt64(sRandomString))
            Return sRandomString
        End Try
    End Function

    Private Const _FromEmailAddress As String = "info@monsoondeals.com"
    Private Const _DoNotReplyEmailAddress As String = "do-not-reply@monsoondeals.com"
    Private Const _ToEmailAddress As String = "info@monsoondeals.com"

    Shared Sub SetCookie(ByVal Key As String, ByVal Value As String, ByVal intDays As Int16)
        With HttpContext.Current

            Dim aCookie As New HttpCookie(Key)
            aCookie.Value = Value
            aCookie.Expires = DateTime.Now.AddDays(intDays)
            .Response.Cookies.Add(aCookie)
        End With
    End Sub

    Shared Function GetCookie(ByVal Key As String) As String
        With HttpContext.Current
            If Not .Request.Cookies(Key) Is Nothing Then
                Dim aCookie As HttpCookie = .Request.Cookies(Key)
                Return .Server.HtmlEncode(aCookie.Value)
            End If
        End With
        Return ""
    End Function

    Public Shared ReadOnly Property FromEmailAddress() As String
        Get
            Return _FromEmailAddress
        End Get
    End Property

    Public Shared Function WebsiteName() As String
        Return "monsoondeals.com"
    End Function

    Public Shared ReadOnly Property ToEmailAddress() As String
        Get
            Return _ToEmailAddress
        End Get
    End Property

    Public Shared ReadOnly Property DoNotReplyEmailAddress() As String
        Get
            Return _DoNotReplyEmailAddress
        End Get
    End Property

    Public Shared Function ValidateEmail(ByVal email As String) As Boolean
        Return Regex.IsMatch(email, "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
    End Function

    Public Shared Function GetAdminUserId() As String
        Return IIf(IsNumeric(HttpContext.Current.Session("ocAUID")), HttpContext.Current.Session("ocAUID"), 0)
    End Function

    Shared Function GetXmlFilePath(ByVal FileName As String)
        Return HttpContext.Current.Server.MapPath("~" & ConfigurationManager.AppSettings("XmlFilesPath") & FileName)
    End Function

    Shared Function GetIp() As String
        Return HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
    End Function

    Shared Function ApplicationPath() As String
        Return ConfigurationManager.AppSettings("ApplicationPath")
    End Function

    Shared Function ApplicationSSLPath() As String
        Return Utils.GetSSLUrl(ConfigurationManager.AppSettings("ApplicationPath"))
    End Function

    Shared Function CreateImageCode(ByRef imgSecurityCode As HtmlImage)
        Dim imgFile As String
        Dim objConn As New clConn
        imgFile = objConn.QueryScalarSQL("prc_GetTextImages", Nothing)
        imgSecurityCode.Src = Utils.ApplicationSSLPath() & "/textimages/" & imgFile & ".gif"
        Return imgFile
    End Function

    Public Shared Function GetPageBody(ByVal strPath As String) As String
        Try
            Dim writer As New IO.StringWriter()
            HttpContext.Current.Server.Execute(strPath, writer, True)
            Dim strOutput As String = writer.ToString()
            Try
                Dim RegexObj As New Regex(">[\s]*<")
                strOutput = RegexObj.Replace(strOutput, "><")
                Return strOutput
            Catch ex As Exception
                Return strOutput
            End Try
            Return strOutput
        Catch ex As Exception
            Return ""
        End Try
    End Function

#Region "Get Affiliate Page Id"
    Shared Function GetAffiliatePageID()
        Return IIf(IsNumeric(HttpContext.Current.Session("AffiliateRefferalId")) AndAlso HttpContext.Current.Session("AffiliateRefferalId") > 0, HttpContext.Current.Session("AffiliateRefferalId"), IIf(IsNumeric(Utils.GetCookie("AffiliateRefferalId")), Utils.GetCookie("AffiliateRefferalId"), 0))
        'Return IIf(IsNumeric(Utils.GetCookie("AffiliateRefferalId")), Utils.GetCookie("AffiliateRefferalId"), 0)
    End Function
#End Region


#Region "Send External Email"
    Shared Sub SendExternalEmail(ByVal strFrom As String, ByVal strTo As String, ByVal strSubject As String, ByVal strMailBody As String, ByVal strcc As String, ByVal strbcc As String)
        Try
            If ConfigurationManager.AppSettings("SendMail").ToLower = "true" Then
                Dim objMail As Object
                objMail = System.Web.HttpContext.Current.Server.CreateObject("CDO.Message")
                'objMail.To = "rajeshatsi@gmail.com"
                'objMail.To = "kapil.6988@gmail.com"
                objMail.To = CStr(strTo)
                objMail.From = CStr(strFrom)
                objMail.cc = strcc
                objMail.bcc = strbcc
                ' objMail.MailFormat = 0
                ' objMail.BodyFormat = 0
                objMail.Subject = CStr(strSubject)
                objMail.HtmlBody = strMailBody
                'objMail.Body = strMailBody
                objMail.send()
                objMail = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "SSL Setting"
    Shared Function GetSSLUrl(ByVal strURL As String, ByVal strPage As String) As String
        strPage = strPage.Replace("\", "/")
        Dim Pages As New ArrayList
        With Pages
            .Add("login.aspx")
            .Add("member-registration.aspx")
            .Add("merchant-registration.aspx")
            .Add("confirm.aspx")
            .Add("complete-order.aspx")
            .Add("order-receipt.aspx")
            .Add("admin/login.aspx")
        End With

        If strURL.ToLower.IndexOf("http://") <> -1 And Pages.Contains(strPage) Then
            strURL = strURL.Replace("http://", "https://")

        ElseIf strURL.ToLower.IndexOf("https://") <> -1 And Not Pages.Contains(strPage) Then
            strURL = strURL.Replace("https://", "http://")
        End If

        If strURL.ToLower.IndexOf("https://www") = -1 Then
            strURL = strURL.Replace("https://", "https://www.")
        End If

        If strURL.ToLower.IndexOf("http://www") = -1 Then
            strURL = strURL.Replace("http://", "http://www.")
        End If
        Return strURL.Replace("404.aspx?404;http://www.monsoondeals.com:443/", "")
    End Function

    Shared Function GetSSLUrl(ByVal strUrl As String)
        With HttpContext.Current
            If .Request.Url.ToString.IndexOf("https://") >= 0 Then
                Return strUrl.Replace("http://", "https://")
            End If
            Return strUrl
        End With
    End Function
#End Region
#Region "Write CSV"
    Public Shared Sub WriteCSV(ByVal strFileName As String, ByVal tbl As DataTable)
        Try

            '***************  Refer this link for better understanding of CSV *******************'
            'http://www.creativyst.com/Doc/Articles/CSV/CSV01.htm
            '************************************************************************************'

            Dim strResult As New StringBuilder()
            For Each col As DataColumn In tbl.Columns
                strResult.Append("""" + col.ColumnName.Replace("""", """""") + """,")
            Next
            strResult.Append(vbNewLine)
            Dim objConn As New clConn
            For Each row As DataRow In tbl.Rows
                For Each col As DataColumn In tbl.Columns
                    Dim strValue As String = row(col.ColumnName).ToString()
                   
                    strResult.Append("""" + strValue.Replace("""", """""").Replace("Chr(10)", "") + """,")
                Next
                strResult.Append(vbNewLine)
            Next

            HttpContext.Current.Response.Expires = 0
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.ClearHeaders()
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" & strFileName & "")
            HttpContext.Current.Response.AddHeader("Content-type", "text/csv")
            HttpContext.Current.Response.Write(strResult.ToString())
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub DisablePageCaching()
        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1))
        HttpContext.Current.Response.Cache.SetValidUntilExpires(False)
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches)
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        HttpContext.Current.Response.Cache.SetNoStore()
    End Sub
#End Region
End Class
