Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data

Namespace BusinessLayer
    <RecordAttribute("tbl_AdminUsers,tbl_Users", "prc_adminLogin,prc_UserLogin", New [String](0) {"AdminLogin"})> _
    Public Class BALlogin
        Inherits IRecord

#Region "Variables"
        Private _strUserName As String = String.Empty
        Private _strPassword As String = String.Empty
        Private _strAccessToken As String = String.Empty
        Private _strSiteID As String = String.Empty
        Private _strFanPageID As String = String.Empty
        Private _strFanPageURL As String = String.Empty

        Private _intUserId As Integer = 0
        Private _intSiteUserId As Integer = 0
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

        Public Property password() As String
            Get
                Return _strPassword
            End Get
            Set(value As String)
                _strPassword = value
            End Set
        End Property
        Public Property ForRentAccessToken() As String
            Get
                Return _strAccessToken
            End Get
            Set(value As String)
                _strAccessToken = value
            End Set
        End Property
        Public Property SiteID() As String
            Get
                Return _strSiteID
            End Get
            Set(value As String)
                _strSiteID = value
            End Set
        End Property
        Public ReadOnly Property UserId() As String
            Get
                Return _intUserId
            End Get

        End Property
        Public Property SiteUserID() As Integer
            Get
                Return _intSiteUserId
            End Get
            Set(value As Integer)
                _intSiteUserId = value
            End Set
        End Property
        Public Property FanPageID() As String
            Get
                Return _strFanPageID
            End Get
            Set(value As String)
                _strFanPageID = value
            End Set
        End Property
        Public Property FanPageURL() As String
            Get
                Return _strFanPageURL
            End Get
            Set(value As String)
                _strFanPageURL = value
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

#Region "Check Site User Login Data"
        Public Function CheckLogin() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UserLogin")
                dataAccess.AddParam("@user_UserName", SqlDbType.NVarChar, ParamString(Me.UserName))
                dataAccess.AddParam("@user_Password", SqlDbType.NVarChar, ParamString(Utility.Encryption(Me.password)))
                ds = dataAccess.GetDataset()
                Return ds
                'If ds.Tables(0).Rows.Count > 0 Then

                '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
                '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
                '    'End If
                'End If
                'ds = Nothing
            Catch ex As Exception
                Utility.LogError(ex, "User Login", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region

#Region "Add ForRent Data"
        Public Function AddUpdateForRentData() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddForrentData")
                dataAccess.AddParam("@accesstoken", SqlDbType.NVarChar, ParamString(Me.ForRentAccessToken))

                dataAccess.AddParam("@UserName", SqlDbType.NVarChar, ParamString(Me.UserName))

                ds = dataAccess.GetDataset()
                Return ds
                'If ds.Tables(0).Rows.Count > 0 Then

                '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
                '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
                '    'End If
                'End If
                'ds = Nothing
            Catch ex As Exception
                Utility.LogError(ex, "User Login", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region

#Region "Add Referecne Of FanPageID and SiteID"
        Public Sub AddReferenceSiteIdToFanPageId() ' As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddSiteFanpageReference")
                dataAccess.AddParam("@SiteUserId", SqlDbType.Int, ParamString(Me.SiteUserID))
                dataAccess.AddParam("@SiteId", SqlDbType.NVarChar, ParamString(Me.SiteID))
                dataAccess.AddParam("@FanPageId", SqlDbType.NVarChar, ParamString(Me.FanPageID))
                dataAccess.AddParam("@FanPageURL", SqlDbType.NVarChar, ParamString(Me.FanPageURL))
                dataAccess.ExecuteNonQuery()
                ds = dataAccess.GetDataset()
                'Return ds
                'If ds.Tables(0).Rows.Count > 0 Then

                '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
                '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
                '    'End If
                'End If
                'ds = Nothing
            Catch ex As Exception
                Utility.LogError(ex, "User Login", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Sub
#End Region

#Region "Delete Old Web Service"
        Public Function DeleteOldWebService() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteOldWebService")
                dataAccess.AddParam("@SiteUserId", SqlDbType.Int, ParamString(Me.SiteUserID))
           

                ds = dataAccess.GetDataset()
                Return ds
                'If ds.Tables(0).Rows.Count > 0 Then

                '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
                '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
                '    'End If
                'End If
                'ds = Nothing
            Catch ex As Exception
                Utility.LogError(ex, "User Login", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region
#Region "Save Web Service"
        Public Function SaveWebService() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_SaveWebService")
                dataAccess.AddParam("@SiteUserId", SqlDbType.Int, ParamString(Me.SiteUserID))
                dataAccess.AddParam("@SiteId", SqlDbType.NVarChar, ParamString(Me.SiteID))
                dataAccess.AddParam("@FanPageId", SqlDbType.NVarChar, ParamString(Me.FanPageID))

                ds = dataAccess.GetDataset()
                Return ds
                'If ds.Tables(0).Rows.Count > 0 Then

                '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
                '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
                '    'End If
                'End If
                'ds = Nothing
            Catch ex As Exception
                Utility.LogError(ex, "User Login", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region


#Region "Check Admin User Login Data"
        Public Function AdminLoginDetails() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AdminLogin")
                dataAccess.AddParam("@aus_UserName", SqlDbType.NVarChar, ParamString(Me.UserName))
                dataAccess.AddParam("@aus_Password", SqlDbType.NVarChar, Utility.Encryption(ParamString(Me.password)))
                ds = dataAccess.GetDataset()
                Return ds
                'If ds.Tables(0).Rows.Count > 0 Then

                'Else
                '    ds = Nothing
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Admin Login", True)
                Throw
            Finally
            End Try
        End Function
#End Region



#Region "Generate Image"
        Public Function GenereateImage() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_getImageCode")
                'dataAccess.AddParam("@pnl_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                ds = dataAccess.GetDataset()
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds
                End If
            Catch ex As Exception
                Utility.LogError(ex, "Generate Images", True)
                Throw
            Finally
            End Try
        End Function
#End Region
    End Class
End Namespace


