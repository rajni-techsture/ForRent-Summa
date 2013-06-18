Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data

Namespace BusinessLayer

    Public Class BALSiteUser
        Inherits IRecord

#Region "Variables"
        Private _strUserName As String = String.Empty
        Private _strPassword As String = String.Empty
        Private _strFirstName As String = String.Empty
        Private _strLastName As String = String.Empty
        Private _strEmail As String = String.Empty
        Private _strAddress1 As String = String.Empty
        Private _strAddress2 As String = String.Empty
        Private _strCity As String = String.Empty
        Private _strState As String = String.Empty
        Private _strCountry As String = String.Empty
        Private _strZipCode As String = String.Empty
        Private _strPhone As String = String.Empty
        Private _strBirthDate As Date = Date.Now

        Private _strGender As Integer = 1
        Private _strStatus As Integer = 0
        Private _intUserId As Integer = 0
        Private _intUserId1 As Integer = 0
        Private _isError As Boolean = False
        Private strMessage As String

        Private _strCheckedMenu As String = String.Empty
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
        Public Property Address1() As String
            Get
                Return _strAddress1
            End Get
            Set(value As String)
                _strAddress1 = value
            End Set
        End Property
        Public Property Address2() As String
            Get
                Return _strAddress2
            End Get
            Set(value As String)
                _strAddress2 = value
            End Set
        End Property
        Public Property City() As String
            Get
                Return _strCity
            End Get
            Set(value As String)
                _strCity = value
            End Set
        End Property
        Public Property State() As String
            Get
                Return _strState
            End Get
            Set(value As String)
                _strState = value
            End Set
        End Property
        Public Property Country() As String
            Get
                Return _strCountry
            End Get
            Set(value As String)
                _strCountry = value
            End Set
        End Property
        Public Property ZipCode() As String
            Get
                Return _strZipCode
            End Get
            Set(value As String)
                _strZipCode = value
            End Set
        End Property
        Public Property Phone() As String
            Get
                Return _strPhone
            End Get
            Set(value As String)
                _strPhone = value
            End Set
        End Property
        Public Property Gender() As Integer
            Get
                Return _strGender
            End Get
            Set(value As Integer)
                _strGender = value
            End Set
        End Property
        Public Property BirthDate() As Date
            Get
                Return _strBirthDate
            End Get
            Set(value As Date)
                _strBirthDate = value
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

        Public ReadOnly Property intUserId() As Integer
            Get
                Return _intUserId1
            End Get
        End Property

        Public Property CheckedMenu() As String
            Get
                Return _strCheckedMenu
            End Get
            Set(value As String)
                _strCheckedMenu = value
            End Set
        End Property
        'Public Property isError() As Boolean
        '    Get
        '        Return _isError
        '    End Get
        'End Property


        'Public Property Message() As String
        '    Get
        '        Return strMessage
        '    End Get
        'End Property
#End Region

#Region "CONSTRUCTORS"
        Public Sub New()
        End Sub
#End Region



#Region "Add  User"
        Public Function AddUser() As Integer
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddSiteUser")
            dataAccess.AddParam("@u_UserName", SqlDbType.NVarChar, ParamString(Me.UserName))
            dataAccess.AddParam("@u_Password", SqlDbType.NVarChar, Utility.Encryption(ParamString(Me.Password)))
            dataAccess.AddParam("@u_FirstName", SqlDbType.NVarChar, ParamString(Me.FirstName))
            dataAccess.AddParam("@u_LastName", SqlDbType.NVarChar, ParamString(Me.LastName))
            dataAccess.AddParam("@u_Email", SqlDbType.NVarChar, ParamString(Me.Email))
            dataAccess.AddParam("@u_Address1", SqlDbType.NVarChar, ParamString(Me.Address1))
            dataAccess.AddParam("@u_Address2", SqlDbType.NVarChar, ParamString(Me.Address2))
            dataAccess.AddParam("@u_City", SqlDbType.NVarChar, ParamString(Me.City))
            dataAccess.AddParam("@u_State", SqlDbType.NVarChar, ParamString(Me.State))
            dataAccess.AddParam("@u_Country", SqlDbType.NVarChar, ParamString(Me.Country))
            dataAccess.AddParam("@u_ZipCode", SqlDbType.NVarChar, ParamString(Me.ZipCode))
            dataAccess.AddParam("@u_Phone", SqlDbType.NVarChar, ParamString(Me.Phone))
            dataAccess.AddParam("@u_Gender", SqlDbType.Int, ParamString(Me.Gender))
            dataAccess.AddParam("@u_BirthDate", SqlDbType.Date, ParamString(Me.BirthDate))


            dataAccess.AddParam("@u_Status", SqlDbType.Int, ParamString(Me.Status))

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

#Region "Update User"
        Public Function UpdateUser(ByVal UserID As Integer) As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateSiteUser")
            dataAccess.AddParam("@u_Id", SqlDbType.Int, UserID)
            dataAccess.AddParam("@u_UserName", SqlDbType.NVarChar, ParamString(Me.UserName))
            dataAccess.AddParam("@u_Password", SqlDbType.NVarChar, Utility.Encryption(ParamString(Me.Password)))
            dataAccess.AddParam("@u_FirstName", SqlDbType.NVarChar, ParamString(Me.FirstName))
            dataAccess.AddParam("@u_LastName", SqlDbType.NVarChar, ParamString(Me.LastName))
            dataAccess.AddParam("@u_Email", SqlDbType.NVarChar, ParamString(Me.Email))
            dataAccess.AddParam("@u_Address1", SqlDbType.NVarChar, ParamString(Me.Address1))
            dataAccess.AddParam("@u_Address2", SqlDbType.NVarChar, ParamString(Me.Address2))
            dataAccess.AddParam("@u_City", SqlDbType.NVarChar, ParamString(Me.City))
            dataAccess.AddParam("@u_State", SqlDbType.NVarChar, ParamString(Me.State))
            dataAccess.AddParam("@u_Country", SqlDbType.NVarChar, ParamString(Me.Country))
            dataAccess.AddParam("@u_ZipCode", SqlDbType.NVarChar, ParamString(Me.ZipCode))
            dataAccess.AddParam("@u_Phone", SqlDbType.NVarChar, ParamString(Me.Phone))
            dataAccess.AddParam("@u_Gender", SqlDbType.Int, ParamString(Me.Gender))
            dataAccess.AddParam("@u_BirthDate", SqlDbType.Date, ParamString(Me.BirthDate))

            dataAccess.AddParam("@u_Status", SqlDbType.Int, ParamString(Me.Status))

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

#Region "Get Site User"
        Public Function GetSiteUser(ByVal UserID As Integer) As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSiteUser")
            dataAccess.AddParam("@u_Id", SqlDbType.Int, UserID)


            ds = dataAccess.GetDataset()

            Return ds
           
        End Function

#End Region

#Region "Bind Users"
        Public Function BindUsers() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ViewUsers")


                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Bind Users", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Change Admin Status"
        Public Function ChangeSiteUserStatus() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ChangeSiteUserStatus")
                dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
                dataAccess.AddParam("@Status", SqlDbType.Int, Me.Status)
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Manage User", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "List Menus"
        Public Function ListMenus() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ListAllMenusForSiteUser")
                dataAccess.AddParam("@UserId", SqlDbType.Int, ParamString(Me.UserId))

                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "List Menus", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Update Assign Menu Rights"
        Public Function UpdateAssignMenuRights() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateAssignMenuRights")
                dataAccess.AddParam("@UserId", SqlDbType.Int, ParamString(Me.UserId))
                dataAccess.AddParam("@CheckedMenus", SqlDbType.VarChar, ParamString(Me.CheckedMenu))
                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Update", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Get Menu Rights of User"
        Public Function GetMenuRights() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetMenuRightsofUser")
                dataAccess.AddParam("@userId", SqlDbType.Int, ParamString(Me.UserId))

                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Get Menu Rights of User", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

    End Class
End Namespace