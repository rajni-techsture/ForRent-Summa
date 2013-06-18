Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Imports System.Net.Mail


Namespace BusinessLayer
    <RecordAttribute("tbl_FBUserDetails", "prc_AddUpdateFBUserDeatils", New [String](0) {"Add Update Facebook user and page details"})>
    Public Class FacebookUserAndPagesDetails
        Inherits IRecord

#Region "Variables"
        Private _strFBUserId As String = String.Empty
        Private _strFBUserEmail As String = String.Empty
        Private _strFBUserFirstName As String = String.Empty
        Private _strFBUserLastName As String = String.Empty
        Private _strFBUserName As String = String.Empty
        Private _strFBUserToken As String = String.Empty
        Private _strFBUserTokenExpirationDate As String = String.Empty
        Private _intTSMAUserId As Integer

        Private _strFBPageId As String = String.Empty
        Private _strFBPageUrl As String = String.Empty
        Private _strFBPageName As String = String.Empty
        Private _strFBPageToken As String = String.Empty
        Private _strFBPageTokenExpirationDate As String = String.Empty

        Private _strErrorUploadedData As String = String.Empty
        Private _strOuthErrorDetails As String = String.Empty
        Private _strOuthErrorCode As String = String.Empty
        Private _strOuthErrorType As String = String.Empty

#End Region

#Region "Properties"
        ''' <summary>
        ''' Schedule Post Fuction 
        ''' </summary>
        ''' <value>The <c>FBUserId</c> FBPageId <c>FBPageImage</c> FBPageAccessToken</value>
        ''' 


        Public Property FBUSerId() As String
            Get
                Return _strFBUserId
            End Get
            Set(ByVal value As String)
                _strFBUserId = value
            End Set
        End Property

        Public Property FBUserEmail() As String
            Get
                Return _strFBUserEmail
            End Get
            Set(ByVal value As String)
                _strFBUserEmail = value
            End Set
        End Property

        Public Property FBUSerFirstName() As String
            Get
                Return _strFBUserFirstName
            End Get
            Set(ByVal value As String)
                _strFBUserFirstName = value
            End Set
        End Property
        Public Property FBUSerLastName() As String
            Get
                Return _strFBUserLastName
            End Get
            Set(ByVal value As String)
                _strFBUserLastName = value
            End Set
        End Property

        Public Property FBUSerName() As String
            Get
                Return _strFBUserName
            End Get
            Set(ByVal value As String)
                _strFBUserName = value
            End Set
        End Property

        Public Property FBUSerToken() As String
            Get
                Return _strFBUserToken
            End Get
            Set(ByVal value As String)
                _strFBUserToken = value
            End Set
        End Property

        Public Property FBUserTokenExpirationDate() As String
            Get
                Return _strFBUserTokenExpirationDate
            End Get
            Set(ByVal value As String)
                _strFBUserTokenExpirationDate = value
            End Set
        End Property

        Public Property TSMAUserId() As Integer
            Get
                Return _intTSMAUserId
            End Get
            Set(ByVal value As Integer)
                _intTSMAUserId = value
            End Set
        End Property


        Public Property FBPageName() As String
            Get
                Return _strFBPageName
            End Get
            Set(ByVal value As String)
                _strFBPageName = value
            End Set
        End Property
        Public Property FBPageURl() As String
            Get
                Return _strFBPageUrl
            End Get
            Set(ByVal value As String)
                _strFBPageUrl = value
            End Set
        End Property

        Public Property FBPageId() As String
            Get
                Return _strFBPageId
            End Get
            Set(ByVal value As String)
                _strFBPageId = value
            End Set
        End Property

        Public Property FBPageToken() As String
            Get
                Return _strFBPageToken
            End Get
            Set(ByVal value As String)
                _strFBPageToken = value
            End Set
        End Property

        Public Property FBPageTokenExpirationDate() As String
            Get
                Return _strFBPageTokenExpirationDate
            End Get
            Set(ByVal value As String)
                _strFBPageTokenExpirationDate = value
            End Set
        End Property

        Public Property ErrorUploadedData() As String
            Get
                Return _strErrorUploadedData
            End Get
            Set(ByVal value As String)
                _strErrorUploadedData = value
            End Set
        End Property

        Public Property OuthErrorDetails() As String
            Get
                Return _strOuthErrorDetails
            End Get
            Set(ByVal value As String)
                _strOuthErrorDetails = value
            End Set
        End Property

        Public Property OuthErrorCode() As String
            Get
                Return _strOuthErrorCode
            End Get
            Set(ByVal value As String)
                _strOuthErrorCode = value
            End Set
        End Property

        Public Property OuthErrorType() As String
            Get
                Return _strOuthErrorType
            End Get
            Set(ByVal value As String)
                _strOuthErrorType = value
            End Set
        End Property
#End Region

#Region "CONSTRUCTORS"
        Public Sub New()
        End Sub
#End Region

#Region "Add Update Facebook User Details"

        Public Function AddUpdateFBUserDetails()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddUpdateFBUserDetails")
                dataAccess.AddParam("@u_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@u_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUSerId))
                dataAccess.AddParam("@u_FBFirstName", SqlDbType.VarChar, ParamString(Me.FBUSerFirstName))
                dataAccess.AddParam("@u_FBLastName", SqlDbType.VarChar, ParamString(Me.FBUSerLastName))
                dataAccess.AddParam("@u_FBUserName", SqlDbType.VarChar, ParamString(Me.FBUSerName))
                dataAccess.AddParam("@u_FBEmail", SqlDbType.VarChar, ParamString(Me.FBUserEmail))
                dataAccess.AddParam("@u_FBUserToken", SqlDbType.VarChar, ParamString(Me.FBUSerToken))
                dataAccess.AddParam("@u_FBUserTokenExpirationDate", SqlDbType.VarChar, ParamString(Me.FBUserTokenExpirationDate))
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Facebook User Details", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Add Update Facebook User Pages Details"

        Public Function AddUpdateFBUserPageDetails()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddUpdateFBUserPagesDetails")
                dataAccess.AddParam("@p_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@p_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUSerId))
                dataAccess.AddParam("@p_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@p_FBPageName", SqlDbType.VarChar, ParamString(Me.FBPageName))
                dataAccess.AddParam("@p_FBPageUrl", SqlDbType.VarChar, ParamString(Me.FBPageURl))
                dataAccess.AddParam("@p_FBPageToken", SqlDbType.VarChar, ParamString(Me.FBPageToken))
                dataAccess.AddParam("@p_FBPageTokenExpirationDate", SqlDbType.VarChar, ParamString(Me.FBPageTokenExpirationDate))
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Facebook User Pages Details", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Add Update Facebook User Pages Details"

        Public Function AddOuthErrorDetails()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddOuthErrorDetails")
                dataAccess.AddParam("@er_UploadedData", SqlDbType.VarChar, ParamString(Me._strErrorUploadedData))
                dataAccess.AddParam("@er_ErrorDetails", SqlDbType.VarChar, ParamString(Me._strOuthErrorDetails))
                dataAccess.AddParam("@er_OuthCode", SqlDbType.VarChar, ParamString(Me._strOuthErrorCode))
                dataAccess.AddParam("@er_OuthType", SqlDbType.VarChar, ParamString(Me._strOuthErrorType))
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Facebook User Pages Details", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region
    End Class

End Namespace
