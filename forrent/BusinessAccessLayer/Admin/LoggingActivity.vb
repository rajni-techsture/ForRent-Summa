Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data

Namespace BusinessLayer

    Public Class BALLoggingActivity
        Inherits IRecord

#Region "Variables"
        ' Upper Box Data
        Private _strCompanyName As String = String.Empty
        Private _strCompanyID As Integer = 0
        Private _strIndustryName As String = String.Empty
        Private _strIndustryID As Integer = 0
        Private _strUserName As String = String.Empty
        Private _strUserID As Integer = 0
        Private _strFromDate As String = String.Empty
        Private _strToDate As String = String.Empty
        Private _strPageIndex As Integer = 1
        Private _strSortBy As String = String.Empty
        Private _strOrder As String = String.Empty

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

        Public Property CompanyID() As Integer
            Get
                Return _strCompanyID
            End Get
            Set(value As Integer)
                _strCompanyID = value
            End Set
        End Property

        Public Property IndustryName() As String
            Get
                Return _strIndustryName
            End Get
            Set(value As String)
                _strIndustryName = value
            End Set
        End Property

        Public Property IndustryID() As Integer
            Get
                Return _strIndustryID
            End Get
            Set(value As Integer)
                _strIndustryID = value
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return _strUserName
            End Get
            Set(value As String)
                _strUserName = value
            End Set
        End Property

        Public Property UserID() As Integer
            Get
                Return _strUserID
            End Get
            Set(value As Integer)
                _strUserID = value
            End Set
        End Property

        Public Property FromDate() As String
            Get
                Return _strFromDate
            End Get
            Set(value As String)
                _strFromDate = value
            End Set
        End Property

        Public Property ToDate() As String
            Get
                Return _strToDate
            End Get
            Set(value As String)
                _strToDate = value
            End Set
        End Property
        Public Property PageIndex() As Integer
            Get
                Return _strPageIndex
            End Get
            Set(value As Integer)
                _strPageIndex = value
            End Set
        End Property

        Public Property SortBy() As String
            Get
                Return _strSortBy
            End Get
            Set(value As String)
                _strSortBy = value
            End Set
        End Property
        Public Property Order() As String
            Get
                Return _strOrder
            End Get
            Set(value As String)
                _strOrder = value
            End Set
        End Property


#End Region

#Region "CONSTRUCTORS"
        Public Sub New()
        End Sub
#End Region

        'Header Data
#Region "Bind Search Data"
        Public Function BindSearchData() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_BindSearchData")
            ds = dataAccess.GetDataset()
            Return ds

        End Function

#End Region

        'Bind & DownLoad All 
#Region "Bind AutoPosts"
        Public Function BindAutoPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAdminAutopostMaster")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadAutoPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadAutopostStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region
#Region "Bind QuickPost"
        Public Function BindQuickPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAdminQuickpostMaster")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadQuickPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadQuickpostStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region
#Region "Bind Schedule Post"
        Public Function BindScheduledPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAdminScheduledPostMaster")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadScheduledPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadScheduledPostStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region
#Region "Bind Image Post"
        Public Function BindImagePost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAdminImagePostMaster")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadImagePost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadImagePostStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Bind Video Post"
        Public Function BindVideoPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAdminVideoPostMaster")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadVideoPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadVideoPostStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region
#Region "Bind Text Post"
        Public Function BindTextPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAdminTextPostMaster")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadTextPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadTextPostStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region
#Region "Bind Link Post"
        Public Function BindLinkPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAdminLinkPostMaster")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadLinkPost() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadLinkPostStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Bind Published Sidebars"
        Public Function BindPublishedSidebars() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetPublishedSidebar")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadPublishedSidebars()

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadPublishedSidebarStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region
#Region "Bind Saved Sidebars"
        Public Function BindSavedSidebars() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSavedSidebar")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadSavedSidebars()

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadSavedSidebarStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Bind Published Custom Tabs"
        Public Function BindPublishedCustomTabs() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetPublishedCustomTab")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadPublishedCustomTabs()

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadPublishedCustomTabStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region
#Region "Bind Saved CustomTabs"
        Public Function BindSavedCustomTabs() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSavedCustomTab")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadSavedCustomTabs()

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadSavedCustomTabStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Bind Published Sweepstakes"
        Public Function BindPublishedSweepstakes() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetPublishedSweepstake")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadPublishedSweepstakes()

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownloadPublishedSweepstakeStatistics")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region


#Region "Bind Consolidated Report"
        Public Function BindConsolidatedReport() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetConsolidatedReport")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))
            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))
            ds = dataAccess.GetDataset()
            Return ds

        End Function

        Public Function DownLoadConsolidatedReport() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DownLoadConsolidatedReport")
            dataAccess.AddParam("@CompanyID", SqlDbType.Int, ParamString(Me.CompanyID))
            dataAccess.AddParam("@IndustryID", SqlDbType.Int, ParamString(Me.IndustryID))
            dataAccess.AddParam("@UserID", SqlDbType.Int, ParamString(Me.UserID))

            dataAccess.AddParam("@FromDate", SqlDbType.VarChar, If(Me.FromDate = "", "", Me.FromDate))
            dataAccess.AddParam("@ToDate", SqlDbType.VarChar, If(Me.ToDate = "", "", Me.ToDate))
            '  dataAccess.AddParam("@PageIndex", SqlDbType.Int, ParamString(Me.PageIndex))
            dataAccess.AddParam("@SortBy", SqlDbType.NVarChar, ParamString(Me.SortBy))
            dataAccess.AddParam("@Order", SqlDbType.NVarChar, ParamString(Me.Order))

            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region
    End Class
End Namespace