Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data

Namespace BusinessLayer

    Public Class BALCustomTab
        Inherits IRecord
#Region "Variables"
        Private intPageIndex As Integer = 1
        Private intCustomTabId As Integer = 0
        Private strCustomTabName As String = String.Empty
        Private strCustomTabContent As String = String.Empty
        Private strUserId As String = String.Empty
        Private strFBUserId As String = String.Empty
        Private strFBPageId As String = String.Empty
        Private strFBPageName As String = String.Empty
        Private strFBPageAccessToken As String = String.Empty
        Private intCompanyId As Integer = 0
        Private intIndustryId As Integer = 0
        Private intFreeCustomTabId As Integer = 0
        Private intCid As Integer = 0
        Dim intDirection As Integer = 0

        Private strPage As String = ""
        Private strCustomTabImage As String = ""
        Private _strFBPageImage As String = String.Empty
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
        Public Property CustomTabId() As Integer
            Get
                Return intCustomTabId
            End Get
            Set(value As Integer)
                intCustomTabId = value
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
        Public Property FBPageId() As String
            Get
                Return strFBPageId
            End Get
            Set(value As String)
                strFBPageId = value
            End Set
        End Property
        Public Property FBPageName() As String
            Get
                Return strFBPageName
            End Get
            Set(value As String)
                strFBPageName = value
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
        Public Property CustomTabName() As String
            Get
                Return strCustomTabName
            End Get
            Set(value As String)
                strCustomTabName = value
            End Set
        End Property
        Public Property CustomTabContent() As String
            Get
                Return strCustomTabContent
            End Get
            Set(value As String)
                strCustomTabContent = value
            End Set
        End Property
        Public Property FreeCustomTabId() As Integer
            Get
                Return intFreeCustomTabId
            End Get
            Set(value As Integer)
                intFreeCustomTabId = value
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
        Public Property CustomTabImage() As String
            Get
                Return strCustomTabImage
            End Get
            Set(value As String)
                strCustomTabImage = value
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

#Region "Get Video Tutorial By Custom Tab ID"
        Public Function GetVideoTutorialByID() As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetVideoTutorialByID")
            dataAccess.AddParam("@ctm_CTID", SqlDbType.VarChar, Me.CustomTabId)


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Get Video Tutorial By Custom Tab Master ID"
        Public Function GetVideoTutorialByMasterID() As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetVideoTutorialByMasterID")
            dataAccess.AddParam("@ctm_CTID", SqlDbType.VarChar, Me.CustomTabId)


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Get CustomTab According to the User Id, Company Id or Industry Id"
        Public Function GetCustomTabMaster() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCustomTabMaster")
            objDataAccess.AddParam("@ctm_Id", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, Me.FBUserId)
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

        Public Function GetCustomTabMasterByID() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCustomTabMasterByID")
            objDataAccess.AddParam("@ct_Id", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@ct_FBPageId", SqlDbType.VarChar, Me.FBPageId)
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

        Public Function GetCustomTabMasterTemplates() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCustomTabMasterTemplates")
            objDataAccess.AddParam("@ctm_Id", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, Me.FBUserId)
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

#Region "Get All CustomTab According to the Company Id or Industry Id"
        Public Function GetCustomTabMasterByCompOrIndustry() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCustomTabMasterByCompOrIndustry")
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

#Region "Update CustomTab"
        Public Function UpdateCustomTabContent()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateCustomTab")
            objDataAccess.AddParam("@ct_Id", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@ct_IndustryId", SqlDbType.Int, Me.IndustryId)
            objDataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@ct_Name", SqlDbType.VarChar, Me.CustomTabName)
            'objDataAccess.AddParam("@ct_FBPageId", SqlDbType.VarChar, Me.strFBPageId)
            'objDataAccess.AddParam("@ct_FBPageAccessToken", SqlDbType.VarChar, Me.strFBPageAccessToken)
            objDataAccess.AddParam("@ct_Content", SqlDbType.VarChar, Me.CustomTabContent)
            'objDataAccess.AddParam("@ct_Image", SqlDbType.VarChar, Me.CustomTabImage)
            objDataAccess.ExecuteNonQuery()
        End Function

        Public Function UpdateCustomTabContent1()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateCustomTab1")
            objDataAccess.AddParam("@ct_Id", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@ct_IndustryId", SqlDbType.Int, Me.IndustryId)
            objDataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@ct_Name", SqlDbType.VarChar, Me.CustomTabName)
            objDataAccess.AddParam("@ct_FBPageId", SqlDbType.VarChar, Me.strFBPageId)
            objDataAccess.AddParam("@ct_FBPageAccessToken", SqlDbType.VarChar, Me.strFBPageAccessToken)
            objDataAccess.AddParam("@ct_Content", SqlDbType.VarChar, Me.CustomTabContent)
            objDataAccess.ExecuteNonQuery()
        End Function

        Public Sub UpdateImageName()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateCustomTabImageName")
            objDataAccess.AddParam("@ct_Id", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@ct_Image", SqlDbType.VarChar, Me.CustomTabImage)
            objDataAccess.ExecuteNonQuery()
        End Sub

        Public Sub UpdateIsPublishedCustomTab()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateIsPublishedCustomTab")
            objDataAccess.AddParam("@ct_Id", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_FBPageId", SqlDbType.VarChar, Me.FBPageId)
            objDataAccess.AddParam("@ct_FBPageName", SqlDbType.VarChar, Me.FBPageName)
            objDataAccess.AddParam("@ct_FBPageAccessToken", SqlDbType.VarChar, Me.FBPageAccessToken)
            objDataAccess.ExecuteNonQuery()
        End Sub
#End Region

#Region "Shared Custom tab content"
        Public Function UpdateSharedCustomTabContent()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateSharedCustomTab")
            objDataAccess.AddParam("@ct_Id", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@ct_IndustryId", SqlDbType.Int, Me.IndustryId)
            objDataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@ct_Name", SqlDbType.VarChar, Me.CustomTabName)
            objDataAccess.AddParam("@ct_FBPageId", SqlDbType.VarChar, Me.strFBPageId)
            objDataAccess.AddParam("@ct_FBPageAccessToken", SqlDbType.VarChar, Me.strFBPageAccessToken)
            objDataAccess.AddParam("@ct_Content", SqlDbType.VarChar, Me.CustomTabContent)
            objDataAccess.AddParam("@ct_FBPageName", SqlDbType.VarChar, Me.FBPageName)
            'objDataAccess.AddParam("@ct_Image", SqlDbType.VarChar, Me.CustomTabImage)
            objDataAccess.ExecuteNonQuery()
        End Function
#End Region

#Region "Save New CustomTab"
        Public Function AddNewCustomTabContent() As DataSet
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddNewCustomTab")
            objDataAccess.AddParam("@ct_ctmId", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@ct_IndustryId", SqlDbType.Int, Me.IndustryId)
            objDataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@ct_FBPageId", SqlDbType.VarChar, Me.FBPageId)
            objDataAccess.AddParam("@ct_Name", SqlDbType.VarChar, Me.CustomTabName)
            objDataAccess.AddParam("@ct_FBPageAccessToken", SqlDbType.VarChar, Me.strFBPageAccessToken)
            objDataAccess.AddParam("@ct_Content", SqlDbType.VarChar, Me.CustomTabContent)
            objDataAccess.AddParam("@ct_Image", SqlDbType.VarChar, Me.CustomTabImage)
            ds = objDataAccess.GetDataset()
            Return ds
        End Function


#End Region

#Region "Save New CustomTab"
        Public Function AddShareCustomTabContent() As DataSet
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddShareCustomTab")
            objDataAccess.AddParam("@ct_ctmId", SqlDbType.Int, Me.CustomTabId)
            objDataAccess.AddParam("@ct_UserId", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@ct_IndustryId", SqlDbType.Int, Me.IndustryId)
            objDataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@ct_FBPageId", SqlDbType.VarChar, Me.FBPageId)
            objDataAccess.AddParam("@ct_Name", SqlDbType.VarChar, Me.CustomTabName)
            objDataAccess.AddParam("@ct_FBPageAccessToken", SqlDbType.VarChar, Me.strFBPageAccessToken)
            objDataAccess.AddParam("@ct_Content", SqlDbType.VarChar, Me.CustomTabContent)
            objDataAccess.AddParam("@ct_Image", SqlDbType.VarChar, Me.CustomTabImage)
            ds = objDataAccess.GetDataset()
            Return ds
        End Function
#End Region

#Region "Get Published CustomTab Content Id"
        Public Function GetPublishedCustomTabById() As DataSet
            'Try
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetPublishedCustomTabById")
            objDataAccess.AddParam("@CustomTabId", SqlDbType.Int, Me.CustomTabId)
            ds = objDataAccess.GetDataset()
            Return ds
            '  Catch ex As Exception
            '    Utility.LogError(ex, "Drafts", True)
            '    Throw
            'Finally
            'End Try
        End Function
#End Region

#Region "Get My CustomTabs"
        Public Function GetMyCustomTabs() As DataSet
            Dim ds As New DataSet
            Dim objDataAccess As New DALDataAccess()
            'objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetMyCustomTabMaster")
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetMyCustomTabMasterByFanPageId")
            objDataAccess.AddParam("@ct_userid", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_fbuserid", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@ct_FBPageId", SqlDbType.VarChar, Me.FBPageId)
            objDataAccess.AddParam("@ct_cid", SqlDbType.Int, Me.Cid)
            objDataAccess.AddParam("@ct_direction", SqlDbType.Int, Me.Direction)
            objDataAccess.AddParam("@ct_CompanyId", SqlDbType.Int, Me.CompanyId)
            objDataAccess.AddParam("@ct_IndustryId", SqlDbType.Int, Me.IndustryId)
            ds = objDataAccess.GetDataset()
            Return ds
        End Function
#End Region

#Region "Delete My CustomTabs"
        Public Sub DeleteMyCustomTabs()
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteMyCustomTabMaster")
            'objDataAccess.AddParam("@ct_userid", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_cid", SqlDbType.Int, Me.Cid)
            objDataAccess.ExecuteNonQuery()
        End Sub
#End Region

#Region "Get CutomTabs Fan Page Data"
        Public Function GetCustomTabFanPageData() As DataSet
            Dim objDataAccess As New DALDataAccess()
            Dim ds As New DataSet
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCustomTabFanPageData")
            objDataAccess.AddParam("@ct_userid", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_cid", SqlDbType.Int, Me.Cid)
            ds = objDataAccess.GetDataset()
            Return ds
        End Function
#End Region
#Region "Get Express Left Menus"
        Public Function GetExpressMenus() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetExpressMenus")
                dataAccess.AddParam("@CompanyID", SqlDbType.NVarChar, ParamString(Me.CompanyID))
                dataAccess.AddParam("@IndustryID", SqlDbType.NVarChar, ParamString(Me.IndustryID))


                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                ' End If
            Catch ex As Exception
                Utility.LogError(ex, "Express Menu", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Add CustomTab Fan Pages "
        Public Function AddCustomTabFanPages()
            ' Try
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddCustomTabFanPages")
            dataAccess.AddParam("@ct_CustomTabId", SqlDbType.Int, Me.CustomTabId)
            dataAccess.AddParam("@ct_TSMAUserId", SqlDbType.Int, Me.UserId)
            dataAccess.AddParam("@ct_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
            dataAccess.AddParam("@ct_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
            dataAccess.AddParam("@ct_FBPageName", SqlDbType.VarChar, ParamString(Me.FBPageName))
            dataAccess.AddParam("@ct_FBPageImage", SqlDbType.VarChar, ParamString(Me.FBPageImage))
            dataAccess.AddParam("@ct_FBPageAccessToken", SqlDbType.VarChar, ParamString(Me.FBPageAccessToken))
            dataAccess.ExecuteNonQuery()

            'Catch ex As Exception
            'Utility.LogError(ex, "", True)
            ' Throw
            'Finally
            'End Try
            'Return _intUserId
        End Function
#End Region
#Region "Copy My Custom Tabs"
        Public Function CopyMyCustomTabs() As DataSet
            Dim dsCopy As New DataSet
            Dim objDataAccess As New DALDataAccess()
            objDataAccess.AddCommand(CommandType.StoredProcedure, "prc_CopyMyCustomTabMaster")
            objDataAccess.AddParam("@ct_userid", SqlDbType.Int, Me.UserId)
            objDataAccess.AddParam("@ct_FBUserid", SqlDbType.VarChar, Me.FBUserId)
            objDataAccess.AddParam("@ct_cid", SqlDbType.Int, Me.Cid)
            dsCopy = objDataAccess.GetDataset()
            Return dsCopy
        End Function
#End Region
    End Class
End Namespace

