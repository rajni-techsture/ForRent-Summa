Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
Public Class save_user_selection
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <WebMethod()> _
    Public Shared Function SaveUserSelection(CompanyID As Integer, IndustryID As Integer) As cls_SaveUserSelection
        Dim objSelection As New cls_SaveUserSelection
        objSelection.SaveSelection(HttpContext.Current.Session("FacebookUserId"), CompanyID, IndustryID)
        Return objSelection
    End Function
End Class