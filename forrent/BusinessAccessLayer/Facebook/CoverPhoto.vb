Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data

Namespace BusinessLayer
    Public Class BALCoverPhoto
        Inherits IRecord

#Region "Variables"
        Private intPageIndex As Integer = 1
        Private intCoverPhotoId As Integer = 0
        Private strCoverPhotoName As String = String.Empty
        Private strCoverPhotoContent As String = String.Empty
        Private strUserId As String = String.Empty
        Private strFBUserId As String = String.Empty
        'Private strCoverPhotoName As String = String.Empty
        Private strFBPageId As String = String.Empty
        Private strFBPageAccessToken As String = String.Empty
        Private intCompanyId As Integer = 0
        Private intIndustryId As Integer = 0
        Private intFreeCoverPhotoId As Integer = 0
        Private intCid As Integer = 0
        Dim intDirection As Integer = 0


        Private strPage As String = ""
        Private strCoverPhotoImage As String = ""
        Private _strFBPageImage As String = String.Empty
        Private _strSelectedPageName As String = String.Empty
#End Region

#Region "Properties"
        Public Property PageIndex() As Integer
            Get
                Return intPageIndex
            End Get
            Set(value As Integer)
                intPageIndex = value
            End Set
        End Property
        Public Property CoverPhotoId() As Integer
            Get
                Return intCoverPhotoId
            End Get
            Set(value As Integer)
                intCoverPhotoId = value
            End Set
        End Property
        Public Property CompanyId() As Integer
            Get
                Return intCompanyId
            End Get
            Set(value As Integer)
                intCompanyId = value
            End Set
        End Property
        Public Property IndustryId() As Integer
            Get
                Return intIndustryId
            End Get
            Set(value As Integer)
                intIndustryId = value
            End Set
        End Property
        Public Property UserId() As String
            Get
                Return strUserId
            End Get
            Set(value As String)
                strUserId = value
            End Set
        End Property
        Public Property FBUserId() As String
            Get
                Return strFBUserId
            End Get
            Set(value As String)
                strFBUserId = value
            End Set
        End Property
        Public Property CoverPhotoName() As String
            Get
                Return strCoverPhotoName
            End Get
            Set(value As String)
                strCoverPhotoName = value
            End Set
        End Property
        Public Property CoverPhotoImage() As String
            Get
                Return strCoverPhotoImage
            End Get
            Set(value As String)
                strCoverPhotoImage = value
            End Set
        End Property
        Public Property FBPageId() As String
            Get
                Return strFBPageId
            End Get
            Set(value As String)
                strFBPageId = value
            End Set
        End Property
        Public Property FBPageAccessToken() As String
            Get
                Return strFBPageAccessToken
            End Get
            Set(value As String)
                strFBPageAccessToken = value
            End Set
        End Property
        Public Property CoverPhotoContent() As String
            Get
                Return strCoverPhotoContent
            End Get
            Set(value As String)
                strCoverPhotoContent = value
            End Set
        End Property
        Public Property FreeCoverPhotoId() As Integer
            Get
                Return intFreeCoverPhotoId
            End Get
            Set(value As Integer)
                intFreeCoverPhotoId = value
            End Set
        End Property

        Public Property Page() As String
            Get
                Return strPage
            End Get
            Set(value As String)
                strPage = value
            End Set
        End Property
        Public Property Cid() As Integer
            Get
                Return intCid
            End Get
            Set(value As Integer)
                intCid = value
            End Set
        End Property
        Public Property Direction() As Integer
            Get
                Return intDirection
            End Get
            Set(value As Integer)
                intDirection = value
            End Set
        End Property

        Public Property FBPageName() As String
            Get
                Return _strSelectedPageName
            End Get
            Set(ByVal value As String)
                _strSelectedPageName = value
            End Set
        End Property

        Public Property FBPageImage() As String
            Get
                Return _strFBPageImage
            End Get
            Set(ByVal value As String)
                _strFBPageImage = value
            End Set
        End Property
#End Region

#Region "Get Video Tutorial"
        Public Function GetVideoTutorial() As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetVideoTutorial")
            dataAccess.AddParam("@vt_Page", SqlDbType.VarChar, Me.Page)


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Get CoverPhoto According to the User Id, Company Id or Industry Id"
        Public Function GetCoverPhotoMaster() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCoverPhotoMaster")
            objDataAccess.AddParam("@cpm_Id", SqlDbType.Int, Me.CoverPhotoId)
            objDataAccess.AddParam("@cp_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@cp_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@IndustryId", SqlDbType.Int, Me.IndustryId)
            ds = objDataAccess.GetDataset()
            Return ds
            '  Catch ex As Exception
            '    Utility.LogError(ex, "Drafts", True)
            '    Throw
            'Finally
            'End Try
        End Function

        Public Function GetCoverPhotoMasterByID() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCoverPhotoMasterByID")
            objDataAccess.AddParam("@cp_Id", SqlDbType.Int, Me.CoverPhotoId)
            objDataAccess.AddParam("@cp_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@cp_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@cp_FBPageId", SqlDbType.VarChar, Me.FBPageId)
            objDataAccess.AddParam("@CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@IndustryId", SqlDbType.Int, Me.IndustryId)
            ds = objDataAccess.GetDataset()
            Return ds
            '  Catch ex As Exception
            '    Utility.LogError(ex, "Drafts", True)
            '    Throw
            'Finally
            'End Try
        End Function

        Public Function GetCoverPhotoMasterTemplates() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCoverPhotoMasterTemplates")
            objDataAccess.AddParam("@cpm_Id", SqlDbType.Int, Me.CoverPhotoId)
            objDataAccess.AddParam("@cp_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@cp_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@IndustryId", SqlDbType.Int, Me.IndustryId)
            ds = objDataAccess.GetDataset()
            Return ds
            '  Catch ex As Exception
            '    Utility.LogError(ex, "Drafts", True)
            '    Throw
            'Finally
            'End Try
        End Function
#End Region

#Region "Get All CoverPhoto According to the Company Id or Industry Id"
        Public Function GetCoverPhotoMasterByCompOrIndustry() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCoverPhotosMasterByCompOrIndustry")
            objDataAccess.AddParam("@pageindex", SqlDbType.Int, Me.PageIndex)
            objDataAccess.AddParam("@CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@IndustryId", SqlDbType.Int, Me.IndustryId)
            ds = objDataAccess.GetDataset()
            Return ds
            '  Catch ex As Exception
            '    Utility.LogError(ex, "Drafts", True)
            '    Throw
            'Finally
            'End Try
        End Function
#End Region

#Region "Update CoverPhoto"
        Public Sub UpdateCoverPhotoContent()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateCoverPhoto")
            objDataAccess.AddParam("@cp_Id", SqlDbType.Int, Me.CoverPhotoId)
            objDataAccess.AddParam("@cp_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@cp_CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@cp_IndustryId", SqlDbType.Int, Me.IndustryId)
            objDataAccess.AddParam("@cp_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@cp_Name", SqlDbType.VarChar, Me.CoverPhotoName)
            objDataAccess.AddParam("@cp_Content", SqlDbType.VarChar, Me.CoverPhotoContent)
            objDataAccess.ExecuteNonQuery()
        End Sub

        Public Sub UpdateImageName()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateCoverPhotoImageName")
            objDataAccess.AddParam("@cp_Id", SqlDbType.Int, Me.CoverPhotoId)
            objDataAccess.AddParam("@cp_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@cp_Image", SqlDbType.VarChar, Me.CoverPhotoImage)
            objDataAccess.ExecuteNonQuery()
        End Sub

        Public Sub UpdateIsPublishedCoverPhoto()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateIsPublishedCoverPhoto")
            objDataAccess.AddParam("@cp_Id", SqlDbType.Int, Me.CoverPhotoId)
            objDataAccess.AddParam("@cp_FBPageId", SqlDbType.VarChar, Me.FBPageId)
            objDataAccess.AddParam("@cp_FBPageName", SqlDbType.VarChar, Me.FBPageName)
            objDataAccess.ExecuteNonQuery()
        End Sub

        Public Sub UpdateSharedCoverPhoto()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateSharedCoverPhoto")
            objDataAccess.AddParam("@cp_Id", SqlDbType.Int, Me.CoverPhotoId)
            objDataAccess.AddParam("@cp_FBPageId", SqlDbType.VarChar, Me.FBPageId)
            objDataAccess.AddParam("@cp_FBPageName", SqlDbType.VarChar, Me.FBPageName)
            objDataAccess.AddParam("@cp_FBPageAccessToken", SqlDbType.VarChar, Me.FBPageAccessToken)
            objDataAccess.ExecuteNonQuery()
        End Sub
#End Region

#Region "New Save CoverPhoto"
        Public Function AddNewCoverPhotoContent() As DataSet
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddNewCoverPhoto")
            objDataAccess.AddParam("@cp_cpmId", SqlDbType.Int, Me.CoverPhotoId)
            objDataAccess.AddParam("@cp_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@cp_CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@cp_IndustryId", SqlDbType.Int, Me.IndustryId)
            objDataAccess.AddParam("@cp_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@cp_Name", SqlDbType.VarChar, Me.CoverPhotoName)
            'objDataAccess.AddParam("@cp_FBPageId", SqlDbType.VarChar, Me.FBPageId)
            'objDataAccess.AddParam("@cp_FBPageAccessToken", SqlDbType.VarChar, Me.strFBPageAccessToken)
            objDataAccess.AddParam("@cp_Content", SqlDbType.VarChar, Me.CoverPhotoContent)
            'objDataAccess.AddParam("@cp_Image", SqlDbType.VarChar, Me.CoverPhotoImage)
            ds = objDataAccess.GetDataset()
            Return ds
        End Function
#End Region

#Region "Get Publiched CoverPhoto Content Id"
        Public Function GetPublishedCoverPhotoById() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetPublishedCoverPhotoById")
            objDataAccess.AddParam("@CoverPhotoId", SqlDbType.Int, Me.CoverPhotoId)
            ds = objDataAccess.GetDataset()
            Return ds
            '  Catch ex As Exception
            '    Utility.LogError(ex, "Drafts", True)
            '    Throw
            'Finally
            'End Try
        End Function
#End Region

#Region "Get My CoverPhotos"
        Public Function GetMyCoverPhotos() As DataSet
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            'objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetMyCoverPhotoMaster")
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetMyCoverPhotoMasterByFanPageId")
            'objDataAccess.AddCommand(CommandType.StoredProcedure, "temp_getMyCoverPhotos")
            objDataAccess.AddParam("@cp_userid", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@cp_fbuserid", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@cp_FBPageId", SqlDbType.VarChar, Me.FBPageId)
            objDataAccess.AddParam("@cp_cid", SqlDbType.Int, Me.Cid)
            objDataAccess.AddParam("@cp_direction", SqlDbType.Int, Me.Direction)
            ds = objDataAccess.GetDataset()
            Return ds
        End Function
#End Region

#Region "Delete My CoverPhotos"
        Public Sub DeleteMyCoverPhotos()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteMyCoverPhotoMaster")
            'objDataAccess.AddParam("@cp_userid", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@cp_cid", SqlDbType.Int, Me.Cid)
            objDataAccess.ExecuteNonQuery()
        End Sub
#End Region

#Region "Delete Unnecessary Fan Pages"
        Public Function DeleteCoverPhotoFanPages(ByVal id As Integer)
            Try
                Dim dataAccess As New DALDataAccess()
                'Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteCoverPhotoFanPages")
                dataAccess.AddParam("@cp_id", SqlDbType.Int, id)
                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Delete CoverPhoto FanPages", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Add CoverPhoto Fan Pages "
        Public Function AddCoverPhotoFanPages()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddCoverPhotoFanPages")
                dataAccess.AddParam("@cp_CoverPhotoId", SqlDbType.Int, Me.CoverPhotoId)
                dataAccess.AddParam("@cp_TSMAUserId", SqlDbType.Int, Me.UserId)
                dataAccess.AddParam("@cp_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@cp_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@cp_FBPageName", SqlDbType.VarChar, ParamString(Me.FBPageName))
                dataAccess.AddParam("@cp_FBPageImage", SqlDbType.VarChar, ParamString(Me.FBPageImage))
                dataAccess.AddParam("@cp_FBPageAccessToken", SqlDbType.VarChar, ParamString(Me.FBPageAccessToken))
                dataAccess.ExecuteNonQuery()

            Catch ex As Exception
                Utility.LogError(ex, "Schedule Post", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region
#Region "Copy My CoverPhotos"
        Public Function CopyMyCoverPhotos() As DataSet
            Dim dsCopy As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_CopyMyCoverPhotoMaster")
            objDataAccess.AddParam("@cp_userid", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@cp_FBUserid", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@cp_cid", SqlDbType.Int, Me.Cid)
            dsCopy = objDataAccess.GetDataset()
            Return dsCopy
        End Function
#End Region
    End Class
End Namespace
