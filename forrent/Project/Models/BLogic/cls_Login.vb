Public Class cls_login
    Private _Mode As String = "member"
    Private _UserName As String = ""
    Private _Password As String = ""
    Private _Result As Boolean = False
    Dim objConn As New clConn
    Friend Property Mode() As String
        Get
            Return _Mode.Trim.ToLower
        End Get
        Set(ByVal value As String)
            _Mode = value
        End Set
    End Property

    Friend Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                _UserName = value
            Else
                _UserName = ""
            End If
        End Set
    End Property

    Friend Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                _Password = value
            Else
                _Password = ""
            End If
        End Set
    End Property

    Friend Property Result() As Boolean
        Get
            Return _Result
        End Get
        Set(ByVal value As Boolean)
            _Result = value
        End Set
    End Property

#Region "Login"
    Friend Sub Login()
        Dim ds As DataSet = objConn.QuerySQL("prc_GetLoginDetail", _
                                            objConn.GetSqlParam("@Login_UserName", SqlDbType.VarChar, 100, Me.UserName.Trim), _
                                            objConn.GetSqlParam("@Login_Password", SqlDbType.VarChar, 250, objConn.Encryption(Me.Password.Trim)), _
                                            objConn.GetSqlParam("@Login_Mode", SqlDbType.VarChar, 20, Me.Mode))
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                If .Item("UserName").ToString.Trim = Me.UserName.Trim And objConn.Decryption(.Item("Password").ToString.Trim) = Me.Password.Trim Then
                    If Me.Mode = "member" Then
                        HttpContext.Current.Session("MemberID") = .Item("UserId").ToString()
                        HttpContext.Current.Session("MemberName") = .Item("FullName").ToString()
                        HttpContext.Current.Session("MemberUserName") = .Item("UserName").ToString()
                    ElseIf Me.Mode = "affiliate" Then
                        HttpContext.Current.Session("AffiliateID") = .Item("UserId").ToString()
                        HttpContext.Current.Session("AffiliateName") = .Item("FullName").ToString()
                        HttpContext.Current.Session("AffiliateUserName") = .Item("UserName").ToString()
                    ElseIf Me.Mode = "merchant" Then
                        HttpContext.Current.Session("MerchantID") = .Item("UserId").ToString()
                        HttpContext.Current.Session("MerchantName") = .Item("FullName").ToString()
                        HttpContext.Current.Session("MerchantUserName") = .Item("UserName").ToString()
                    End If
                    Me.Result = True
                End If
            End With
        End If
    End Sub
#End Region

#Region " Clear Session"
    Shared Sub ClearSession(Optional ByVal strMode As String = "")
        With HttpContext.Current
            If strMode = "member" Then
                .Session("MemberID") = Nothing
                .Session("MemberName") = Nothing
                .Session("MemberUserName") = Nothing
            ElseIf strMode = "affiliate" Then
                .Session("AffiliateID") = Nothing
                .Session("AffiliateName") = Nothing
                .Session("AffiliateUserName") = Nothing
            ElseIf strMode = "merchant" Then
                .Session("MerchantID") = Nothing
                .Session("MerchantName") = Nothing
                .Session("MerchantUserName") = Nothing
            Else
                .Session("MemberID") = Nothing
                .Session("MemberName") = Nothing
                .Session("MemberUserName") = Nothing
                .Session("AffiliateID") = Nothing
                .Session("AffiliateName") = Nothing
                .Session("AffiliateUserName") = Nothing
                .Session("MerchantID") = Nothing
                .Session("MerchantName") = Nothing
                .Session("MerchantUserName") = Nothing
            End If
        End With
    End Sub
#End Region

#Region "Forget Password"
    Sub ForgetPassword(ByVal strMode As String)
        Dim ds As DataSet = objConn.QuerySQL("prc_ForgotPassword", _
                                             objConn.GetSqlParam("@UserName", SqlDbType.VarChar, 100, Me.UserName.Trim), _
                                             objConn.GetSqlParam("@Mode", SqlDbType.VarChar, 20, Me.Mode))
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                Me.Password = .Item("Passwrd")
                If Me.Mode = "member" Then
                    Utils.SendExternalEmail(Utils.FromEmailAddress, .Item("Email").ToString, "Your login information at " & Utils.WebsiteName(), GetMailBody(.Item("Email").ToString, objConn.Decryption(.Item("Passwrd").ToString), strMode), "", "")
                ElseIf Me.Mode = "affiliate" Then
                    Utils.SendExternalEmail(Utils.FromEmailAddress, .Item("Email").ToString, "Your login information at " & Utils.WebsiteName(), GetMailBody(.Item("Email").ToString, objConn.Decryption(.Item("Passwrd").ToString), strMode), "", "")
                ElseIf Me.Mode = "merchant" Then
                    Utils.SendExternalEmail(Utils.FromEmailAddress, .Item("Email").ToString, "Your login information at " & Utils.WebsiteName(), GetMailBody(.Item("Email").ToString, objConn.Decryption(.Item("Passwrd").ToString), strMode), "", "")
                End If
                Me.Result = True
            End With
        End If

    End Sub
#End Region

#Region "Mail Body"
    Public Function GetMailBody(ByVal strEmail As String, ByVal strPwd As String, ByVal stringMode As String)
        Dim strMailBody As String = "Your login information was found at " & Utils.WebsiteName() & " as " & stringMode & " is as per bellow:<br><br><b>Email:</b> " & strEmail.Trim & "<br><b>Password:</b> " & objConn.Decryption(Me.Password) & "<br><br>Kindly use the above to gain access to your account at <SPAN style=""COLOR: black""><a href=" & Utils.WebsiteName() & "/login.aspx?mode=" & stringMode & ">" & Utils.WebsiteName & "</a></SPAN>"
        Return strMailBody
    End Function
#End Region

End Class
