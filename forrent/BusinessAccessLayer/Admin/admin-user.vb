Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data

Namespace BusinessLayer


    Public Class BALadmin_user
        Inherits IRecord

#Region "Variables"
        Private _strUserName As String = String.Empty
        Private _strPassword As String = String.Empty
        Private _strFirstName As String = String.Empty
        Private _strLastName As String = String.Empty
        Private _strEmail As String = String.Empty
        Private _strStatus As Integer = 0
        Private _intUserId As Integer = 0
        Private _intUserId1 As Integer = 0
        Private _isError As Boolean = False
        Private strMessage As String
#End Region

#Region "Properties"
        ''' <summary>
        ''' Gets and sets the <c>Username</c> Password
        ''' </summary>
        ''' <value>The <c>Username</c> Password</value>

        Public Property UserName() As String
            Get
                Return _strUserName
            End Get
            Set(value As String)
                _strUserName = value
            End Set
        End Property

        Public Property Password() As String
            Get
                Return _strPassword
            End Get
            Set(value As String)
                _strPassword = value
            End Set
        End Property
        Public Property FirstName() As String
            Get
                Return _strFirstName
            End Get
            Set(value As String)
                _strFirstName = value
            End Set
        End Property
        Public Property LastName() As String
            Get
                Return _strLastName
            End Get
            Set(value As String)
                _strLastName = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _strEmail
            End Get
            Set(value As String)
                _strEmail = value
            End Set
        End Property
        Public Property Status() As Integer
            Get
                Return _strStatus
            End Get
            Set(value As Integer)
                _strStatus = value
            End Set
        End Property


        Public Property UserId() As Integer
            Get
                Return _intUserId
            End Get
            Set(value As Integer)
                _intUserId = value
            End Set
        End Property

#End Region

#Region "CONSTRUCTORS"
        Public Sub New()
        End Sub
#End Region

#Region "Check Admin User"
        Public Function CheckAdminUser(ByVal txtUsername As String) As Boolean
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_CheckAdminUser")
            ' dataAccess.AddParam("@user_UserName", SqlDbType.NVarChar, ParamString(Me.UserName))

            ds = dataAccess.GetDataset()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count
                    If ds.Tables(0).Rows(i).Item("aus_UserName") = txtUsername Then
                        Return True
                        Exit Function
                    Else
                        Return False
                    End If
                Next

                'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
                '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
                'End If
            End If
            'ds = Nothing
            'Catch ex As Exception
            '    Utility.LogError(ex, "Add Admin", True)
            '    Throw
            'Finally
            'End Try
            'Return _intUserId

        End Function

#End Region

#Region "Add Admin User"
        Public Function AddAdminUser() As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddAdminUser")
            dataAccess.AddParam("@aus_UserName", SqlDbType.NVarChar, ParamString(Me.UserName))
            dataAccess.AddParam("@aus_Password", SqlDbType.NVarChar, Utility.Encryption(ParamString(Me.Password)))
            dataAccess.AddParam("@aus_Fname", SqlDbType.NVarChar, ParamString(Me.FirstName))
            dataAccess.AddParam("@aus_Lname", SqlDbType.NVarChar, ParamString(Me.LastName))
            dataAccess.AddParam("@aus_Email", SqlDbType.NVarChar, ParamString(Me.Email))
            dataAccess.AddParam("@aus_Status", SqlDbType.Int, ParamString(Me.Status))

            ds = dataAccess.GetDataset()
            Dim res As Integer = ds.Tables(0).Rows(0).Item(0)
            Return res
            '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
            '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
            '    'End If
            'End If
            'ds = Nothing
            'Catch ex As Exception
            '    Utility.LogError(ex, "Add Admin", True)
            '    Throw
            'Finally
            'End Try
            'Return _intUserId
        End Function

#End Region

#Region "Update Admin User"
        Public Function UpdateAdminUser(ByVal UserID As Integer) As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateAdminUser")
            dataAccess.AddParam("@aus_Id", SqlDbType.Int, UserID)
            dataAccess.AddParam("@aus_UserName", SqlDbType.NVarChar, ParamString(Me.UserName))
            dataAccess.AddParam("@aus_Password", SqlDbType.NVarChar, Utility.Encryption(ParamString(Me.Password)))
            dataAccess.AddParam("@aus_Fname", SqlDbType.NVarChar, ParamString(Me.FirstName))
            dataAccess.AddParam("@aus_Lname", SqlDbType.NVarChar, ParamString(Me.LastName))
            dataAccess.AddParam("@aus_Email", SqlDbType.NVarChar, ParamString(Me.Email))
            dataAccess.AddParam("@aus_Status", SqlDbType.Int, ParamString(Me.Status))

            ds = dataAccess.GetDataset()
            Dim res As Integer = ds.Tables(0).Rows(0).Item(0)
            Return res
            '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
            '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
            '    'End If
            'End If
            'ds = Nothing
            'Catch ex As Exception
            '    Utility.LogError(ex, "Add Admin", True)
            '    Throw
            'Finally
            'End Try
            'Return _intUserId
        End Function

#End Region

#Region "Get Admin User"
        Public Function GetAdminUser(ByVal UserID As Integer) As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAdminUser")
            dataAccess.AddParam("@aus_Id", SqlDbType.Int, UserID)


            ds = dataAccess.GetDataset()

            Return ds
            '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
            '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
            '    'End If
            'End If
            'ds = Nothing
            'Catch ex As Exception
            '    Utility.LogError(ex, "Add Admin", True)
            '    Throw
            'Finally
            'End Try
            'Return _intUserId
        End Function

#End Region


#Region "Bind Admin Users"
        Public Function BindAdminUsers() As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ViewAdminUsers")


            ds = dataAccess.GetDataset()

            Return ds
            '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
            '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
            '    'End If
            'End If
            'ds = Nothing
            'Catch ex As Exception
            '    Utility.LogError(ex, "Add Admin", True)
            '    Throw
            'Finally
            'End Try
            'Return _intUserId
        End Function

#End Region

#Region "Change Admin Status"
        Public Function ChangeAdminStatus() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ChangeAdminUserStatus")
                dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
                dataAccess.AddParam("@Status", SqlDbType.Int, Me.Status)
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Add Admin", True)
                Throw
            Finally
            End Try
        End Function
#End Region

    End Class
End Namespace