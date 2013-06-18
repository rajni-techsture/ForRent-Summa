Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data

Namespace BusinessLayer

    Public Class BALCompany
        Inherits IRecord

#Region "Variables"
        Private _strCompanyName As String = String.Empty
        Private _strIsRequired As Integer = 1
        Private _strPassword As String = String.Empty
        Private _strCompanyIcon As String = String.Empty
        Private _strCompanyStyle As String = String.Empty
        Private _intCompanyId As Integer = 0
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

        Public Property CompanyName() As String
            Get
                Return _strCompanyName
            End Get
            Set(value As String)
                _strCompanyName = value
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
        Public Property IsRequired() As Integer
            Get
                Return _strIsRequired
            End Get
            Set(value As Integer)
                _strIsRequired = value
            End Set
        End Property

        Public Property CompanyIcon() As String
            Get
                Return _strCompanyIcon
            End Get
            Set(value As String)
                _strCompanyIcon = value
            End Set
        End Property
        Public Property CompanyStyle() As String
            Get
                Return _strCompanyStyle
            End Get
            Set(value As String)
                _strCompanyStyle = value
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

        Public Property CompanyId() As Integer
            Get
                Return _intCompanyId
            End Get
            Set(value As Integer)
                _intCompanyId = value
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



#Region "Add  Company"
        Public Function AddCompany() As Integer
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddCompany")
            dataAccess.AddParam("@c_Name", SqlDbType.NVarChar, ParamString(Me.CompanyName))
            dataAccess.AddParam("@c_IsPasswordRequired", SqlDbType.TinyInt, ParamString(Me.IsRequired))
            dataAccess.AddParam("@c_Password", SqlDbType.NVarChar, ParamString(Me.Password))

            dataAccess.AddParam("@c_Icon", SqlDbType.NVarChar, ParamString(Me.CompanyIcon))
            dataAccess.AddParam("@c_Style", SqlDbType.NVarChar, ParamString(Me.CompanyStyle))
            dataAccess.AddParam("@c_Status", SqlDbType.Int, ParamString(Me.Status))

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

#Region "Update Company"
        Public Function UpdateCompany(ByVal CompanyID As Integer) As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateCompany")
            dataAccess.AddParam("@c_Id", SqlDbType.Int, CompanyID)
            dataAccess.AddParam("@c_Name", SqlDbType.NVarChar, ParamString(Me.CompanyName))
            dataAccess.AddParam("@c_IsPasswordRequired", SqlDbType.TinyInt, ParamString(Me.IsRequired))
            dataAccess.AddParam("@c_Password", SqlDbType.NVarChar, ParamString(Me.Password))
            dataAccess.AddParam("@c_Icon", SqlDbType.NVarChar, ParamString(Me.CompanyIcon))
            dataAccess.AddParam("@c_Style", SqlDbType.NVarChar, ParamString(Me.CompanyStyle))
            dataAccess.AddParam("@c_Status", SqlDbType.Int, ParamString(Me.Status))

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

#Region "Get Site Company"
        Public Function GetCompany(ByVal CompanyID As Integer) As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCompany")
            dataAccess.AddParam("@c_Id", SqlDbType.Int, CompanyID)


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Bind Companies"
        Public Function BindCompanies() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ViewCompanies")


                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Bind Companies", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Change Company Status"
        Public Function ChangeCompanyStatus() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ChangeCompanyStatus")
                dataAccess.AddParam("@CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@Status", SqlDbType.Int, Me.Status)
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Change Company Status", True)
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
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ListAllMenusForCompany")
                dataAccess.AddParam("@CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))

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
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateAssignMenuRightsCompany")
                dataAccess.AddParam("@CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
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

#Region "Get Menu Rights of Company"
        Public Function GetMenuRights() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetMenuRightsofCompany")
                dataAccess.AddParam("@companyId", SqlDbType.Int, ParamString(Me.CompanyId))

                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Get Menu Rights of Company", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region
    End Class
End Namespace