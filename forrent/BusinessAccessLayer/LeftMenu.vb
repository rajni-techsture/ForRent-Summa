Imports DataAccessLayer.DataAccessLayer
Namespace BusinessLayer
    Public Class BALLeftMenu
        Inherits IRecord
        Public Property UserID() As Integer
            Get
                Return _strUserID
            End Get
            Set(value As Integer)
                _strUserID = value
            End Set
        End Property
        Private _strUserID As String = String.Empty

        Public Property MenuID() As Integer
            Get
                Return _strMenuID
            End Get
            Set(value As Integer)
                _strMenuID = value
            End Set
        End Property
        Private _strMenuID As String = String.Empty

        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(value As String)
                _Title = value
            End Set
        End Property
        Private _Title As String = String.Empty

        Public Property Content() As String
            Get
                Return _Content
            End Get
            Set(value As String)
                _Content = value
            End Set
        End Property
        Private _Content As String = String.Empty

        Public Property FBUserId() As String
            Get
                Return _FBUserId
            End Get
            Set(value As String)
                _FBUserId = value
            End Set
        End Property
        Private _FBUserId As String = String.Empty

        Public Property FBPageId() As String
            Get
                Return _FBPageId
            End Get
            Set(value As String)
                _FBPageId = value
            End Set
        End Property
        Private _FBPageId As String = String.Empty

        Public Property TSMAUserId() As String
            Get
                Return _TSMAUserId
            End Get
            Set(value As String)
                _TSMAUserId = value
            End Set
        End Property
        Private _TSMAUserId As String = String.Empty

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property
        Private _Name As String = String.Empty

        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(value As String)
                _Email = value
            End Set
        End Property
        Private _Email As String = String.Empty

        Public Property CompanyID() As Integer
            Get
                Return _strCompanyID
            End Get
            Set(value As Integer)
                _strCompanyID = value
            End Set
        End Property
        Private _strCompanyID As String = String.Empty
        Public Property IndustryID() As Integer
            Get
                Return _strIndustryID
            End Get
            Set(value As Integer)
                _strIndustryID = value
            End Set
        End Property
        Private _strIndustryID As String = String.Empty

#Region "Get Left Menu Item By Siteuser Id"
        Public Function GetLeftMenuItem() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetLeftMenuByUserID")
                dataAccess.AddParam("@UserID", SqlDbType.NVarChar, ParamString(Me.UserID))
                dataAccess.AddParam("@CompanyID", SqlDbType.NVarChar, ParamString(Me.CompanyID))
                dataAccess.AddParam("@IndustryID", SqlDbType.NVarChar, ParamString(Me.IndustryID))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                ' End If
            Catch ex As Exception
                Utility.LogError(ex, "Left Menu", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Get Left Sub Menu Item By Comp. or Indu. Id"
        Public Function GetLeftSubMenuItem() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetLeftSubMenuByUserID")
                dataAccess.AddParam("@UserID", SqlDbType.NVarChar, ParamString(Me.UserID))
                dataAccess.AddParam("@CompanyID", SqlDbType.NVarChar, ParamString(Me.CompanyID))
                dataAccess.AddParam("@IndustryID", SqlDbType.NVarChar, ParamString(Me.IndustryID))
                dataAccess.AddParam("@MenuID", SqlDbType.NVarChar, ParamString(Me.MenuID))

                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                ' End If
            Catch ex As Exception
                Utility.LogError(ex, "Left Sub Menu", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Get All Left Menus"
        Public Function GetAllLeftMenu() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAllLeftMenu")
                dataAccess.AddParam("@UserID", SqlDbType.NVarChar, ParamString(Me.UserID))
                dataAccess.AddParam("@CompanyID", SqlDbType.NVarChar, ParamString(Me.CompanyID))
                dataAccess.AddParam("@IndustryID", SqlDbType.NVarChar, ParamString(Me.IndustryID))

                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                ' End If
            Catch ex As Exception
                Utility.LogError(ex, "All Menu", True)
                Throw
            Finally
            End Try
        End Function
#End Region
    End Class
End Namespace