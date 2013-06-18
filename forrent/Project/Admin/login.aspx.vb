Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer
Public Class _default1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        lblMsg.Text = ""
        'Response.Write(Request.Url.AbsoluteUri & "<br/>")
        'Response.Write(Request.ServerVariables("url") & "<br/>")

        'Response.Write(HttpContext.Current.Request.Url.AbsoluteUri & "<br/>")
        ''http://localhost:1302/TESTERS/Default6.aspx

        'Response.Write(HttpContext.Current.Request.Url.AbsolutePath & "<br/>")
        ''// /TESTERS/Default6.aspx

        'Response.Write(HttpContext.Current.Request.Url.Host & "<br/>")
        'localhost

        If Not IsPostBack Then
            GenerateImage()
            If CInt(Session("AID")) = -1 Then
                lblMsg.Text = "You have successfully logged out.<br><br>"
            ElseIf CInt(Session("AID")) = -2 Then
                lblMsg.Text = "Your session timed out, Please login again.<br>"
            End If
            Session("AID") = Nothing
            Session("AUserName") = Nothing
            Session("AFullName") = Nothing
            'Session.Abandon()
            'Session.Clear()
        End If
        'Catch ex As Exception
        '    lblMsg.Text = "Error: " & ex.Message.ToString()
        'End Try
    End Sub


#Region "Security code"
    Sub hrefTryOtherT1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs)
        GenerateImage()
    End Sub
#End Region

#Region "Generate Image"
    Public Function GenerateImage()
        Try
            Dim ds As New DataSet
            Dim objBAL As New BALlogin
            Dim imgFile As String
            ds = objBAL.GenereateImage
            If ds.Tables(0).Rows.Count > 0 Then
                imgFile = ds.Tables(0).Rows(0).Item("im_name").ToString
                hdncode1.Value = Utility.Encryption(imgFile.ToString())
                imgcode1.Src = "../Content/textimages/" & imgFile & ".gif"
                If Request.Url.AbsoluteUri = "http://192.168.19.28:5061/admin/login.aspx" Then
                    txtcode1.Value = imgFile
                    txtUserName.Text = "admin"
                    txtPassword.Text = "admin"
                End If
            End If
        Catch ex As Exception
        End Try
    End Function

#End Region

    Private Sub imglogin_ServerClick(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imglogin.ServerClick
        Try
            

            If txtcode1.Value = Utility.Decryption(hdncode1.Value) Then
                Dim dsTet As New DataSet
                Dim objBALLogin As New BALlogin
                objBALLogin.UserName = txtUserName.Text
                objBALLogin.password = txtPassword.Text
                dsTet = objBALLogin.AdminLoginDetails
                If dsTet.Tables(0).Rows.Count > 0 Then
                    If dsTet.Tables(0).Rows(0).Item("aus_UserName").ToString = Trim(txtUserName.Text.ToString) And Utility.Decryption(dsTet.Tables(0).Rows(0).Item("aus_Password").ToString) = Trim(txtPassword.Text.ToString) Then
                        Session("AID") = CInt(dsTet.Tables(0).Rows(0).Item("aus_Id"))
                        Session("AFullName") = dsTet.Tables(0).Rows(0).Item("aus_Fname").ToString()
                        Session("AUserName") = dsTet.Tables(0).Rows(0).Item("aus_UserName").ToString()
                        Response.Redirect("index.aspx")
                    Else
                        lblMsg.Text = "Sorry, Invalid UserName or Password"
                    End If
                Else
                    lblMsg.Text = "Sorry, Invalid UserName or Password"
                End If
            Else
                lblMsg.Visible = True
                lblMsg.Text = "Please enter correct security code!"
            End If
            GenerateImage()
        Catch ex As Exception
            lblMsg.Text = "Error: " & ex.Message
        End Try
    End Sub
End Class