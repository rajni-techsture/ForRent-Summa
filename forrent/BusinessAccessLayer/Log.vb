Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Namespace BusinessLayer
    Public Class cls_Log
        Inherits IRecord

        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
            End Set
        End Property
        Private _UserName As String = String.Empty

        Public Property UserId() As Integer
            Get
                Return _UserID
            End Get
            Set(ByVal value As Integer)
                _UserID = value
            End Set
        End Property
        Private _UserID As Integer = 0

        Public Property SessionId() As String
            Get
                Return _SessionId
            End Get
            Set(ByVal value As String)
                _SessionId = value
            End Set
        End Property
        Private _SessionId As String = String.Empty

        Public Property FRPageId() As String
            Get
                Return _FRPageId
            End Get
            Set(ByVal value As String)
                _FRPageId = value
            End Set
        End Property
        Private _FRPageId As String = String.Empty

        Public Property FRPageURL() As String
            Get
                Return _FRPageURL
            End Get
            Set(ByVal value As String)
                _FRPageURL = value
            End Set
        End Property
        Private _FRPageURL As String = String.Empty

        Public Property FRPageName() As String
            Get
                Return _FRPageName
            End Get
            Set(ByVal value As String)
                _FRPageName = value
            End Set
        End Property
        Private _FRPageName As String = String.Empty

        Public Property FRSiteID() As String
            Get
                Return _FRSiteID
            End Get
            Set(ByVal value As String)
                _FRSiteID = value
            End Set
        End Property
        Private _FRSiteID As String = String.Empty

        Public Property FBPageID() As String
            Get
                Return _FBPageID
            End Get
            Set(ByVal value As String)
                _FBPageID = value
            End Set
        End Property
        Private _FBPageID As String = String.Empty

        Public Property FBPageName() As String
            Get
                Return _FBPageName
            End Get
            Set(ByVal value As String)
                _FBPageName = value
            End Set
        End Property
        Private _FBPageName As String = String.Empty

        Public Property FBPageURL() As String
            Get
                Return _FBPageURL
            End Get
            Set(ByVal value As String)
                _FBPageURL = value
            End Set
        End Property
        Private _FBPageURL As String = String.Empty

        Public Property FBAccessToken() As String
            Get
                Return _FBAccessToken
            End Get
            Set(ByVal value As String)
                _FBAccessToken = value
            End Set
        End Property
        Private _FBAccessToken As String = String.Empty

        Public Property ErrorMsg() As String
            Get
                Return _Error
            End Get
            Set(ByVal value As String)
                _Error = value
            End Set
        End Property
        Private _Error As String = String.Empty

        Public Property Remarks() As String
            Get
                Return _Remarks
            End Get
            Set(ByVal value As String)
                _Remarks = value
            End Set
        End Property
        Private _Remarks As String = String.Empty

        Public Property FBUserID() As String
            Get
                Return _FBUserID
            End Get
            Set(ByVal value As String)
                _FBUserID = value
            End Set
        End Property
        Private _FBUserID As String = String.Empty

        Public Property FBImage() As String
            Get
                Return _FBImage
            End Get
            Set(ByVal value As String)
                _FBImage = value
            End Set
        End Property
        Private _FBImage As String = String.Empty

        Public Property HandshakeURL() As String
            Get
                Return _HandshakeURL
            End Get
            Set(ByVal value As String)
                _HandshakeURL = value
            End Set
        End Property
        Private _HandshakeURL As String = String.Empty

        Public Property HandshakeCode() As String
            Get
                Return _HandshakeCode
            End Get
            Set(ByVal value As String)
                _HandshakeCode = value
            End Set
        End Property
        Private _HandshakeCode As String = String.Empty



        Public Sub ForrentPageLog()
            Dim ds As New DataSet
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ForrentPageLog")
            dataAccess.AddParam("@SessionId", SqlDbType.VarChar, ParamString(Me.SessionId))
            dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            dataAccess.AddParam("@UserName", SqlDbType.VarChar, ParamString(Me.UserName))
            dataAccess.AddParam("@FRPageId", SqlDbType.VarChar, ParamString(Me.FRPageId))
            dataAccess.AddParam("@FRPageURL", SqlDbType.VarChar, ParamString(Me.FRPageURL))
            dataAccess.AddParam("@FRPageName", SqlDbType.VarChar, ParamString(Me.FRPageName))
            dataAccess.AddParam("@FRSiteID", SqlDbType.VarChar, ParamString(Me.FRSiteID))
            dataAccess.ExecuteNonQuery()
        End Sub

        Public Sub FaceBookPageLog()
            Dim ds As New DataSet
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_FBPageLog")
            dataAccess.AddParam("@SessionId", SqlDbType.VarChar, ParamString(Me.SessionId))
            dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            dataAccess.AddParam("@UserName", SqlDbType.VarChar, ParamString(Me.UserName))
            dataAccess.AddParam("@FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageID))
            dataAccess.AddParam("@FBPageURL", SqlDbType.VarChar, ParamString(Me.FBPageURL))
            dataAccess.AddParam("@FBPageName", SqlDbType.VarChar, ParamString(Me.FBPageName))
            dataAccess.AddParam("@FBAccessToken", SqlDbType.VarChar, ParamString(Me.FBAccessToken))
            dataAccess.ExecuteNonQuery()
        End Sub

        Public Sub ErrorLog()
            Dim ds As New DataSet
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ErrorLog")
            dataAccess.AddParam("@SessionId", SqlDbType.VarChar, ParamString(Me.SessionId))
            dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            dataAccess.AddParam("@UserName", SqlDbType.VarChar, ParamString(Me.UserName))
            dataAccess.AddParam("@Error", SqlDbType.VarChar, ParamString(Me.ErrorMsg))
            dataAccess.AddParam("@Remarks", SqlDbType.VarChar, ParamString(Me.Remarks))
            dataAccess.ExecuteNonQuery()
        End Sub

        Public Sub TokenUpdateLog()
            Dim ds As New DataSet
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_TokenUpdateLog")
            dataAccess.AddParam("@SessionId", SqlDbType.VarChar, ParamString(Me.SessionId))
            dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            dataAccess.AddParam("@UserName", SqlDbType.VarChar, ParamString(Me.UserName))
            dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserID))
            dataAccess.AddParam("@FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageID))
            dataAccess.AddParam("@FBToken", SqlDbType.VarChar, ParamString(Me.FBAccessToken))
            dataAccess.AddParam("@FBImage", SqlDbType.VarChar, ParamString(Me.FBImage))
            dataAccess.ExecuteNonQuery()
        End Sub

        Sub HandShakeLog()
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_HandShakeLog")
            dataAccess.AddParam("@SessionId", SqlDbType.VarChar, ParamString(Me.SessionId))
            dataAccess.AddParam("@Code", SqlDbType.VarChar, ParamString(Me.HandshakeCode))
            dataAccess.AddParam("@URL", SqlDbType.VarChar, ParamString(Me.HandshakeURL))
            dataAccess.ExecuteNonQuery()
        End Sub
    End Class
End Namespace

