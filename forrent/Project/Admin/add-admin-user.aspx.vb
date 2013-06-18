Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer

Public Class add_admin_user
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim intID As Integer = 0
                If Request("Id") IsNot Nothing Then
                    If IsNumeric(Request("Id")) Then
                        intID = CInt(Request("Id"))
                    End If
                End If
                If intID > 0 Then
                    LoadAdminUserData(intID)
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try

    End Sub

    Private Sub btnSave_ServerClick(sender As Object, e As System.EventArgs) Handles btnSave.ServerClick
        If Session("AUserName") <> Nothing Then
            'Try

            '    Dim ds As New DataSet
            '    Dim objBAL As New BALadmin_user
            '    Dim struname As String = txtUserName.Value
            '    Dim Res As Boolean = objBAL.CheckAdminUser(struname)
            '    If Res = True Then
            '        ltrMsg.Text = "Username already exists, use another name! "
            '    Else
            '        ltrMsg.Text = "Done...."
            '        AddUser()
            '    End If
            '    '    objBAL.FBUserId = "100001311049327" 'Session("FacebookUserId")
            '    '    ds = objBAL.GetDrafts
            '    '    If ds.Tables(0).Rows.Count > 0 Then
            '    '        rptDrafts.DataSource = ds.Tables(0)
            '    '        rptDrafts.DataBind()
            '    '    Else
            '    '        rptDrafts.DataSource = Nothing
            '    '        rptDrafts.DataBind()
            '    '        lblMessage.Text = "No Drafts Found"
            '    '    End If
            'Catch ex As Exception
            '    ltrMsg.Text = "Error :" & ex.Message()
            'End Try

            Dim intID As Integer = 0
            If Request("Id") IsNot Nothing Then
                If IsNumeric(Request("Id")) Then
                    intID = CInt(Request("ID"))
                End If
            End If

            If intID > 0 Then
                UpdateAdminUser(intID)
            Else
                AddAdminUser()
            End If

        Else
            Response.Redirect("login.aspx")
        End If

    End Sub

    Private Sub AddAdminUser()

        Dim intUserID As Integer = 0

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

        Dim objAdduser As New BALadmin_user

        objAdduser.UserName = txtUserName.Value
        objAdduser.Password = txtPassword.Value
        objAdduser.FirstName = txtFname.Value
        objAdduser.LastName = txtLname.Value
        objAdduser.Email = txtEmail.Value
        objAdduser.Status = intStatus


        intUserID = objAdduser.AddAdminUser()

        If intUserID = 0 Then
            ltrMsg.Text = "UserName already exists, please enter other."
        ElseIf intUserID = 2 Then
            ltrMsg.Text = "Email Address already available, please enter other."
        Else
            'objConn.ExecuteSQL("exec prc_assignMenuaccess " & intUserID)
            ' CreateXMLMenu(intUserID, Replace(Trim(txtUserName.Value), "'", "''"))
            ' ClearData()
            ltrMsg.Text = "User Added Successfully"
        End If


    End Sub

    Private Sub UpdateAdminUser(ByVal intID As Integer)
        Try
            Dim intUserID As Integer = 0
            Dim intStatus As Integer = 1
            If rdoActive.Checked Then
                intStatus = 1
            Else
                intStatus = 0
            End If

            Dim objUpdateuser As New BALadmin_user

            objUpdateuser.UserName = txtUserName.Value
            objUpdateuser.Password = txtPassword.Value
            objUpdateuser.FirstName = txtFname.Value
            objUpdateuser.LastName = txtLname.Value
            objUpdateuser.Email = txtEmail.Value
            objUpdateuser.Status = intStatus


            intUserID = objUpdateuser.UpdateAdminUser(intID)


            If intUserID = 1 Then
                Response.Redirect("manage-admin-users.aspx?mode=edit")
            ElseIf intUserID = 2 Then
                ltrMsg.Text = "UserName already exists, please enter other."
            ElseIf intUserID = 3 Then
                ltrMsg.Text = "Email Address already available, please enter other."
            End If

        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub LoadAdminUserData(ByVal intID As Integer)

        Try
            Dim objGetAdminuser As New BALadmin_user

            Dim ds As New DataSet
            ds = objGetAdminuser.GetAdminUser(intID)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    txtUserName.Value = .Item("aus_UserName").ToString
                    txtPassword.Value = Utility.Decryption(.Item("aus_Password").ToString)
                    txtFname.Value = .Item("aus_FName").ToString
                    txtLname.Value = .Item("aus_LName").ToString
                    txtEmail.Value = .Item("aus_Email").ToString

                    If .Item("aus_Status") = 1 Then
                        rdoActive.Checked = True
                    Else
                        rdoInactive.Checked = True
                    End If
                End With
            Else
                ltrMsg.Text = "No User Found."
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try

      
    End Sub
End Class