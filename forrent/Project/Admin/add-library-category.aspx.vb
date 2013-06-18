Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer

Public Class add_library_category
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                BindCompanies()
                BindIndustries()
                Dim intID As Integer = 0
                If Request("LCId") IsNot Nothing Then
                    If IsNumeric(Request("LCId")) Then
                        intID = CInt(Request("LCId"))
                    End If
                End If
                If intID > 0 Then
                    LoadLibraryCategoryData(intID)
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Sub BindCompanies()
        Dim objcomp As New BALAdminLibrary

        Dim ds As New DataSet
        ds = objcomp.BindCompanies
        If ds.Tables(0).Rows.Count > 0 Then
            drpCompany.DataSource = ds.Tables(0)
            drpCompany.DataTextField = "c_Name"
            drpCompany.DataValueField = "c_Id"
            drpCompany.DataBind()
        Else
            drpCompany.DataSource = Nothing
            drpCompany.DataBind()
        End If
        drpCompany.Items.Insert(0, New ListItem("-- Select Company --", "0"))
    End Sub

    Sub BindIndustries()
        Dim objcomp As New BALAdminLibrary

        Dim ds As New DataSet
        ds = objcomp.BindIndustries()
        If ds.Tables(0).Rows.Count > 0 Then
            drpIndustry.DataSource = ds.Tables(0)
            drpIndustry.DataTextField = "i_Name"
            drpIndustry.DataValueField = "i_Id"
            drpIndustry.DataBind()
        Else
            drpIndustry.DataSource = Nothing
            drpIndustry.DataBind()
        End If
        drpIndustry.Items.Insert(0, New ListItem("-- Select Industry --", "0"))
    End Sub

    Private Sub btnSave_ServerClick(sender As Object, e As System.EventArgs) Handles btnSave.ServerClick
        If Session("AUserName") <> Nothing Then
           

            Dim intID As Integer = 0
            If Request("LCId") IsNot Nothing Then
                If IsNumeric(Request("LCId")) Then
                    intID = CInt(Request("LCId"))
                End If
            End If

            If intID > 0 Then
                UpdateCategory(intID)
            Else
                AddCategory()
            End If

        Else
            Response.Redirect("login.aspx")
        End If

    End Sub

    Private Sub AddCategory()

        Dim intCatID As Integer = 0

        Dim intStatus As Integer = 1
        If rdoActive.Checked Then
            intStatus = 1
        Else
            intStatus = 0
        End If

        'Dim uname As String
        'Dim pwd As String
        'Dim fname As String
        'Dim lname As String
        'Dim email As String

        Dim objLibCat As New BALAdminLibrary

        objLibCat.CategoryName = txtCategoryName.Value
        objLibCat.CompanyId = drpCompany.Value
        objLibCat.IndustryId = drpIndustry.Value
        objLibCat.Status = intStatus


        intCatID = objLibCat.AddLibraryCategory()

        If intCatID = 0 Then
            ltrMsg.Text = "Category already exists, please enter other."
        ElseIf intCatID = 2 Then
            ltrMsg.Text = "Email Address already available, please enter other."
        Else
            'objConn.ExecuteSQL("exec prc_assignMenuaccess " & intUserID)
            ' CreateXMLMenu(intUserID, Replace(Trim(txtUserName.Value), "'", "''"))
            ' ClearData()
            ltrMsg.Text = "Category Added Successfully"
        End If


    End Sub

    Private Sub UpdateCategory(ByVal intID As Integer)
        Try
            Dim intCatID As Integer = 0
            Dim intStatus As Integer = 1
            If rdoActive.Checked Then
                intStatus = 1
            Else
                intStatus = 0
            End If

            Dim objLibCat As New BALAdminLibrary

            objLibCat.CategoryName = txtCategoryName.Value
            objLibCat.CompanyId = drpCompany.Value
            objLibCat.IndustryId = drpIndustry.Value
            objLibCat.Status = intStatus

            intCatID = objLibCat.UpdateLibraryCategory(intID)


            If intCatID = 1 Then
                Response.Redirect("manage-library-categories.aspx?mode=edit")
            ElseIf intCatID = 2 Then
                ltrMsg.Text = "Category already exists, please enter other."
          
            End If

        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub LoadLibraryCategoryData(ByVal intID As Integer)

        Try
            Dim objLibCat As New BALAdminLibrary

            Dim ds As New DataSet
            ds = objLibCat.GetLibraryCategories(intID)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    txtCategoryName.Value = .Item("lc_Title").ToString

                    If .Item("lc_CompanyId").ToString = "0" Then
                        drpIndustry.Value = .Item("lc_IndustryId").ToString
                        drpCompany.Value = .Item("lc_CompanyId").ToString
                        rdoInd.Checked = True
                        rdoComp.Checked = False
                        trcomp.Style.Add("display", "none")
                        trind.Style.Add("display", "")
                    ElseIf .Item("lc_IndustryId").ToString = "0" Then
                        drpCompany.Value = .Item("lc_CompanyId").ToString
                        drpIndustry.Value = .Item("lc_IndustryId").ToString
                        rdoComp.Checked = True
                        rdoInd.Checked = False
                        trcomp.Style.Add("display", "")
                        trind.Style.Add("display", "none")
                    End If
                    '   drpCompany.Value = .Item("lc_CompanyId").ToString
                    '  drpIndustry.Value = .Item("lc_IndustryId").ToString

                    If .Item("lc_Status") = 1 Then
                        rdoActive.Checked = True
                    Else
                        rdoInactive.Checked = True
                    End If
                End With
            Else
                ltrMsg.Text = "No Category Found."
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try


    End Sub
End Class