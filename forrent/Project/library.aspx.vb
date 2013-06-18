Imports BusinessAccessLayer.BusinessLayer
Public Class library1
    Inherits System.Web.UI.Page
    Dim objLib As New Library
    Public strSelectionType As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            objLib.FBUserId = Session("FacebookUserId")
            strSelectionType = objLib.GetUSerSelectionType
            BindLibraryCategories()
        End If
    End Sub

    Sub BindLibraryCategories()
        Dim ds As DataSet
        objLib.UserId = Session("SiteUserId")
        objLib.FBUserId = Session("FacebookUserId")
        ds = objLib.GetLibraryCategories()

        rptAdminLibCat.DataSource = ds.Tables(0)
        rptAdminLibCat.DataBind()

        rptUserLibCat.DataSource = ds.Tables(1)
        rptUserLibCat.DataBind()

        rptLibUserCatList.DataSource = ds.Tables(1)
        rptLibUserCatList.DataBind()

    End Sub
    Function BindAdminLibraries(intCatID As Integer) As DataSet
        Dim ds As DataSet
        objLib.LibraryCategory = intCatID
        objLib.UserId = -1
        objLib.FBUserId = ""
        ds = objLib.GetLIbraries()
        Return ds
    End Function
    Function BindUserLibraries(intCatID As Integer) As DataSet
        Dim ds As DataSet
        objLib.LibraryCategory = intCatID
        objLib.UserId = Session("SiteUserId")
        objLib.FBUserId = Session("FacebookUserId")
        ds = objLib.GetLIbraries()
        Return ds
    End Function

    Sub SaveToMyLibrary(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try
            objLib.LibraryCategory = e.CommandArgument
            objLib.UserId = Session("SiteUserId")
            objLib.FBUserId = Session("FacebookUserId")
            objLib.LibCatTitle = txtNewLibCat.Value.Trim
            objLib.Library = txtTemplate.Value.Trim.Replace(Chr(10), "<br>")
            objLib.SaveToMyLibrary()
            ltrLibMsg.Text = "Library saved successfully!"
            BindLibraryCategories()
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";ShowUserLib(" & objLib.LibraryCategory & ");", True)
        Catch ex As Exception
            ltrLibMsg.Text = "Error: " & ex.Message
        End Try
        
    End Sub

    Sub DeleteMyLib(ByVal sender As Object, ByVal e As CommandEventArgs)
        objLib.LibraryId = e.CommandArgument
        objLib.DeleteMyLibrary()
        BindLibraryCategories()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide;", ";ShowUserLib(" & e.CommandName & ");", True)
    End Sub
End Class