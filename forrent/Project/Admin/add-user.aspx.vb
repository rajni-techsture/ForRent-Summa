Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer
Public Class add_user
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim intID As Integer = 0
                If Request("UId") IsNot Nothing Then
                    If IsNumeric(Request("UId")) Then
                        intID = CInt(Request("UId"))
                    End If
                End If
                If intID > 0 Then
                    LoadUserData(intID)
                End If
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub btnSave_ServerClick(sender As Object, e As System.EventArgs) Handles btnSave.ServerClick
        If Session("AUserName") <> Nothing Then
       

            Dim intID As Integer = 0
            If Request("UId") IsNot Nothing Then
                If IsNumeric(Request("UId")) Then
                    intID = CInt(Request("UId"))
                End If
            End If

            If intID > 0 Then
                UpdateUser(intID)
            Else
                AddUser()
            End If

        Else
            Response.Redirect("login.aspx")
        End If

    End Sub

    Private Sub AddUser()

        Dim intUserID As Integer = 0

        Dim intStatus As Integer = 1
        If rdoActive.Checked Then
            intStatus = 1
        Else
            intStatus = 0
        End If

        Dim intGender As Integer = 1
        If rdoMale.Checked Then
            intGender = 1
        Else
            intGender = 0
        End If

        'Dim uname As String
        'Dim pwd As String
        'Dim fname As String
        'Dim lname As String
        'Dim email As String

        Dim objAdduser As New BALSiteUser

        objAdduser.UserName = txtUserName.Value
        objAdduser.Password = txtPassword.Value
        objAdduser.FirstName = txtFname.Value
        objAdduser.LastName = txtLname.Value
        objAdduser.Email = txtEmail.Value
        objAdduser.Address1 = txtAddress1.Value
        objAdduser.Address2 = txtAddress2.Value
        objAdduser.City = txtCity.Value
        objAdduser.State = txtState.Value
        objAdduser.Country = txtCountry.Value
        objAdduser.ZipCode = txtZipCode.Value
        objAdduser.Phone = txtPhone.Value
        objAdduser.Country = txtCountry.Value
        objAdduser.BirthDate = CDate(txtBirthDate.Value)
        objAdduser.Gender = intGender
        objAdduser.Status = intStatus


        intUserID = objAdduser.AddUser()

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

    Private Sub UpdateUser(ByVal intID As Integer)
        'Try
        Dim intUserID As Integer = 0

        Dim intStatus As Integer = 1
        If rdoActive.Checked Then
            intStatus = 1
        Else
            intStatus = 0
        End If

        Dim intGender As Integer = 1
        If rdoMale.Checked Then
            intGender = 1
        Else
            intGender = 0
        End If

       
        Dim objUpdateuser As New BALSiteUser

        objUpdateuser.UserName = txtUserName.Value
        objUpdateuser.Password = txtPassword.Value
        objUpdateuser.FirstName = txtFname.Value
        objUpdateuser.LastName = txtLname.Value
        objUpdateuser.Email = txtEmail.Value
        objUpdateuser.Address1 = txtAddress1.Value
        objUpdateuser.Address2 = txtAddress2.Value
        objUpdateuser.City = txtCity.Value
        objUpdateuser.State = txtState.Value
        objUpdateuser.Country = txtCountry.Value
        objUpdateuser.ZipCode = txtZipCode.Value
        objUpdateuser.Phone = txtPhone.Value
        objUpdateuser.Country = txtCountry.Value
        objUpdateuser.BirthDate = CDate(txtBirthDate.Value)
        objUpdateuser.Gender = intGender
        objUpdateuser.Status = intStatus


        intUserID = objUpdateuser.UpdateUser(intID)

        If intUserID = 1 Then
            Response.Redirect("manage-users.aspx?mode=edit")
        ElseIf intUserID = 2 Then
            ltrMsg.Text = "UserName already exists, please enter other."
        ElseIf intUserID = 3 Then
            ltrMsg.Text = "Email Address already available. Please select other."
        End If

      
    End Sub


    Private Sub LoadUserData(ByVal intID As Integer)
        Dim objGetSiteuser As New BALSiteUser
        Dim ds As New DataSet
        ds = objGetSiteuser.GetSiteUser(intID)
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                txtUserName.Value = .Item("u_UserName").ToString
                txtPassword.Value = Utility.Decryption(.Item("u_Password").ToString)
                txtFname.Value = .Item("u_FirstName").ToString
                txtLname.Value = .Item("u_LastName").ToString
                txtEmail.Value = .Item("u_Email").ToString
                txtAddress1.Value = .Item("u_Address1").ToString
                txtAddress2.Value = .Item("u_Address2").ToString
                txtCity.Value = .Item("u_City").ToString
                txtState.Value = .Item("u_State").ToString
                txtCountry.Value = .Item("u_Country").ToString
                txtZipCode.Value = .Item("u_ZipCode").ToString
                txtPhone.Value = .Item("u_Phone").ToString
                txtBirthDate.Value = .Item("u_BirthDate")

                If .Item("u_gender") = 1 Then
                    rdoMale.Checked = True
                Else
                    rdoFemale.Checked = True
                End If

                If .Item("u_Status") = 1 Then
                    rdoActive.Checked = True
                Else
                    rdoInactive.Checked = True
                End If
            End With


        Else
            ltrMsg.Text = "No User Found."
        End If



    End Sub
End Class