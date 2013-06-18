Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
Public Class CompanyPassword
    Inherits System.Web.UI.Page
    'Dim objBAL As New BALCompanyIndusty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <WebMethod()> _
    Public Shared Function CompanyPasswordValidation(pwd As String, id As Integer) As cls_CompanyPasswordValidation
        Dim objPassword As New cls_CompanyPasswordValidation
        objPassword.PasswordValidation(pwd, id)
        Return objPassword
    End Function
End Class

