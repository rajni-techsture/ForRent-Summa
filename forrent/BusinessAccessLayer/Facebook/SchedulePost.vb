Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Imports System.Net.Mail


Namespace BusinessLayer
    <RecordAttribute("tbl_PostNLeap", "prc_AddQuickPost", New [String](0) {"Quick Post"})>
    Public Class BALSchedulePost
        Inherits IRecord

#Region "Variables"
        Private _strPageIndex As Integer

        Private _strTSMAUserId As Integer = 0
        Private _strFBUserId As String = String.Empty
        Private _strPostId As String = String.Empty
        Private _isPersonal As Integer = 0
        Private _strFBApplicationAccessToken As String = String.Empty
        Private _strMessage As String = String.Empty
        Private _strImage As String = String.Empty
        Private _strVideo As String = String.Empty
        Private _strVideoLink As String = String.Empty
        Private _strVideoId As String = String.Empty
        Private _strVideoImage As String = String.Empty
        Private _strAttachment As String = String.Empty
        Private _strScheduleDate As DateTime
        Private _strScheduleHour As Integer = 0
        Private _strScheduleMinute As Integer = 0
        Private _strScheduleAMPM As String = String.Empty
        Private _strScheduleTimeZone As String = String.Empty
        Private _strIsPosted As Integer
        Private _strPostType As Integer
        Private _strCreatedDate As DateTime

        Private _strUpdatedDate As DateTime
        Private _strScheduleId As Integer
        Private _strFBPageId As String = String.Empty
        Private _strFBPageImage As String = String.Empty
        Private _strFBPageAccessToken As String = String.Empty
        Private _strDraftId As Integer
        Private _strSentItemId As Integer
        Private _strScheduledPostID As Integer

        Private _strSelectedPageId As String = String.Empty
        Private _strSelectedPageName As String = String.Empty

        Private _strUserId As String = String.Empty
        ' Private _strFBPageAccessToken As String = String.Empty
        Private _strPostMessage As String = String.Empty
        Private _dtActivationDateValue As DateTime
        Private _strActivationHours As String = String.Empty
        Private _strActivationMinutes As String = String.Empty
        Private _strFBPagePicture As String = String.Empty
        Private _intSendMessage As Integer = 0
        Private _intSaveAsDraft As Integer = 0
        Private _intSaveAsTemplate As Integer = 0
        Private _CompInduId As Integer = 0
        Private _userEmail As String = String.Empty


        Private _strTestDate As DateTime
        Private _strTestIP As String = String.Empty

        Private _strAutoPostId As Integer
        Private _intCompanyId As Integer = 0
        Private _intLibCatId As Integer = 0
        Private _intIndustryId As Integer = 0
        Private _intAutoPostOnOff As Integer = 0
        Private _intAutoPostShuffle As Integer = 0
        Private _intAutoPostStatus As Integer = 1
        Private _intAutoPostSet As Integer = 0
        Private _intAutoPostOrder As Integer = 0
        Private _strAutoPostOrder As String = String.Empty
        Private _strError As String = String.Empty

        Private _intAutopostScheduleType As Integer
        Private _strAutopostScheduleTypeString As String = String.Empty
#End Region

#Region "Properties"
        ''' <summary>
        ''' Schedule Post Fuction 
        ''' </summary>
        ''' <value>The <c>FBUserId</c> FBPageId <c>FBPageImage</c> FBPageAccessToken</value>
        ''' 
        Public Property PageIndex() As Integer
            Get
                Return _strPageIndex
            End Get
            Set(ByVal value As Integer)
                _strPageIndex = value
            End Set
        End Property

        Public Property IsPersonalPage() As Integer
            Get
                Return _isPersonal
            End Get
            Set(ByVal value As Integer)
                _isPersonal = value
            End Set
        End Property
        Public Property TSMAUserId() As Integer
            Get
                Return _strTSMAUserId
            End Get
            Set(ByVal value As Integer)
                _strTSMAUserId = value
            End Set
        End Property

        Public Property FBUserId() As String
            Get
                Return _strFBUserId
            End Get
            Set(value As String)
                _strFBUserId = value
            End Set
        End Property
        Public Property PostId() As String
            Get
                Return _strPostId
            End Get
            Set(value As String)
                _strPostId = value
            End Set
        End Property
        Public Property ErrorDetails() As String
            Get
                Return _strError
            End Get
            Set(ByVal value As String)
                _strError = value
            End Set
        End Property

        Public Property FBApplicationAccessToken() As String
            Get
                Return _strFBApplicationAccessToken
            End Get
            Set(ByVal value As String)
                _strFBApplicationAccessToken = value
            End Set
        End Property

        Public Property Message() As String
            Get
                Return _strMessage
            End Get
            Set(ByVal value As String)
                _strMessage = value
            End Set
        End Property

        Public Property Image() As String
            Get
                Return _strImage
            End Get
            Set(ByVal value As String)
                _strImage = value
            End Set
        End Property

        Public Property Video() As String
            Get
                Return _strVideo
            End Get
            Set(ByVal value As String)
                _strVideo = value
            End Set
        End Property

        Public Property VideoLink() As String
            Get
                Return _strVideoLink
            End Get
            Set(ByVal value As String)
                _strVideoLink = value
            End Set
        End Property

        Public Property VideoId() As String
            Get
                Return _strVideoId
            End Get
            Set(ByVal value As String)
                _strVideoId = value
            End Set
        End Property

        Public Property VideoImage() As String
            Get
                Return _strVideoImage
            End Get
            Set(ByVal value As String)
                _strVideoImage = value
            End Set
        End Property

        Public Property Attachment() As String
            Get
                Return _strAttachment
            End Get
            Set(ByVal value As String)
                _strAttachment = value
            End Set
        End Property

        Public Property ScheduleAMPM() As String
            Get
                Return _strScheduleAMPM
            End Get
            Set(ByVal value As String)
                _strScheduleAMPM = value
            End Set
        End Property

        Public Property ScheduleTimeZone() As String
            Get
                Return _strScheduleTimeZone
            End Get
            Set(ByVal value As String)
                _strScheduleTimeZone = value
            End Set
        End Property
        Public Property ScheduleDate() As DateTime
            Get
                Return _strScheduleDate
            End Get
            Set(value As DateTime)
                _strScheduleDate = value
            End Set
        End Property

        Public Property ScheduleHour() As Integer
            Get
                Return _strScheduleHour
            End Get
            Set(value As Integer)
                _strScheduleHour = value
            End Set
        End Property

        Public Property ScheduleMinute() As Integer
            Get
                Return _strScheduleMinute
            End Get
            Set(value As Integer)
                _strScheduleMinute = value
            End Set
        End Property

        Public Property IsPosted() As Integer
            Get
                Return _strIsPosted
            End Get
            Set(value As Integer)
                _strIsPosted = value
            End Set
        End Property

        Public Property PostType() As Integer
            Get
                Return _strPostType
            End Get
            Set(value As Integer)
                _strPostType = value
            End Set
        End Property

        Public Property AutoPostScheduleType() As Integer
            Get
                Return _intAutopostScheduleType
            End Get
            Set(value As Integer)
                _intAutopostScheduleType = value
            End Set
        End Property

        Public Property AutoPostScheduleTypeString() As String
            Get
                Return _strAutopostScheduleTypeString
            End Get
            Set(value As String)
                _strAutopostScheduleTypeString = value
            End Set
        End Property

        Public Property CreatedDate() As DateTime
            Get
                Return _strCreatedDate
            End Get
            Set(value As DateTime)
                _strCreatedDate = value
            End Set
        End Property

        Public Property UpdatedDate() As DateTime
            Get
                Return _strUpdatedDate
            End Get
            Set(value As DateTime)
                _strUpdatedDate = value
            End Set
        End Property


        Public Property ScheduleId() As Integer
            Get
                Return _strScheduleId
            End Get
            Set(ByVal value As Integer)
                _strScheduleId = value
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

        Public Property UserId() As String
            Get
                Return _strUserId
            End Get
            Set(ByVal value As String)
                _strUserId = value
            End Set
        End Property
        Public Property UserEmailForgotpwd() As String
            Get
                Return _userEmail
            End Get
            Set(ByVal value As String)
                _userEmail = value
            End Set
        End Property

        Public Property FBPageId() As String
            Get
                Return _strSelectedPageId
            End Get
            Set(ByVal value As String)
                _strSelectedPageId = value
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

        Public Property FBPageAccessToken() As String
            Get
                Return _strFBPageAccessToken
            End Get
            Set(value As String)
                _strFBPageAccessToken = value
            End Set
        End Property

        Public Property PostMessage() As String
            Get
                Return _strPostMessage
            End Get
            Set(value As String)
                _strPostMessage = value
            End Set
        End Property

        Public Property ActivationDate() As String
            Get
                Return _dtActivationDateValue
            End Get
            Set(ByVal value As String)
                _dtActivationDateValue = value
            End Set
        End Property

        Public Property ActivationHours() As String
            Get
                Return _strActivationHours
            End Get
            Set(ByVal value As String)
                _strActivationHours = value
            End Set
        End Property

        Public Property ActivationMinutes() As String
            Get
                Return _strActivationMinutes
            End Get
            Set(ByVal value As String)
                _strActivationMinutes = value
            End Set
        End Property

        'Public Property FBPageImage() As String
        '    Get
        '        Return _strFBPagePicture
        '    End Get
        '    Set(value As String)
        '        _strFBPagePicture = value
        '    End Set
        'End Property

        Public Property SendMessage() As Integer
            Get
                Return _intSendMessage
            End Get
            Set(ByVal value As Integer)
                _intSendMessage = value
            End Set
        End Property

        Public Property SaveAsDraft() As Integer
            Get
                Return _intSaveAsDraft
            End Get
            Set(ByVal value As Integer)
                _intSaveAsDraft = value
            End Set
        End Property

        Public Property SaveAsTemplate() As Integer
            Get
                Return _intSaveAsTemplate
            End Get
            Set(ByVal value As Integer)
                _intSaveAsTemplate = value
            End Set
        End Property

        Public Property DraftId() As Integer
            Get
                Return _strDraftId
            End Get
            Set(ByVal value As Integer)
                _strDraftId = value
            End Set
        End Property

        Public Property SentItemId() As Integer
            Get
                Return _strSentItemId

            End Get
            Set(ByVal value As Integer)
                _strSentItemId = value
            End Set
        End Property

        Public Property ScheduledPostID() As Integer
            Get
                Return _strScheduledPostID

            End Get
            Set(ByVal value As Integer)
                _strScheduledPostID = value
            End Set
        End Property

        Public Property TestIP() As String
            Get
                Return _strTestIP
            End Get
            Set(ByVal value As String)
                _strTestIP = value
            End Set
        End Property

        Public Property TestDate() As DateTime
            Get
                Return _strTestDate
            End Get
            Set(value As DateTime)
                _strTestDate = value
            End Set
        End Property

        Public Property AutoPostId() As Integer
            Get
                Return _strAutoPostId
            End Get
            Set(ByVal value As Integer)
                _strAutoPostId = value
            End Set
        End Property

        Public Property CompanyId() As Integer
            Get
                Return _intCompanyId
            End Get
            Set(ByVal value As Integer)
                _intCompanyId = value
            End Set
        End Property

        Public Property IndustryId() As Integer
            Get
                Return _intIndustryId
            End Get
            Set(ByVal value As Integer)
                _intIndustryId = value
            End Set
        End Property

        Public Property AutoPostOnOff() As Integer
            Get
                Return _intAutoPostOnOff
            End Get
            Set(ByVal value As Integer)
                _intAutoPostOnOff = value
            End Set
        End Property

        Public Property AutoPostShuffle() As Integer
            Get
                Return _intAutoPostShuffle
            End Get
            Set(ByVal value As Integer)
                _intAutoPostShuffle = value
            End Set
        End Property

        Public Property AutoPostStatus() As Integer
            Get
                Return _intAutoPostStatus
            End Get
            Set(ByVal value As Integer)
                _intAutoPostStatus = value
            End Set
        End Property

        Public Property AutoPostSet() As Integer
            Get
                Return _intAutoPostSet
            End Get
            Set(ByVal value As Integer)
                _intAutoPostSet = value
            End Set
        End Property
        Public Property AutoPostOrder() As Integer
            Get
                Return _intAutoPostOrder
            End Get
            Set(ByVal value As Integer)
                _intAutoPostOrder = value
            End Set
        End Property

        Public Property LibCatId() As Integer
            Get
                Return _intLibCatId
            End Get
            Set(ByVal value As Integer)
                _intLibCatId = value
            End Set
        End Property

        Public Property strAutoPostOrder() As String
            Get
                Return _strAutoPostOrder
            End Get
            Set(value As String)
                _strAutoPostOrder = value
            End Set
        End Property
#End Region

#Region "CONSTRUCTORS"
        Public Sub New()
        End Sub
#End Region

#Region "Add Quick Post"

        Public Function AddQuickPostMaster()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddQuickPostMaster")
                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                'dataAccess.AddParam("@sm_PostId", SqlDbType.VarChar, ParamString(Me.postid))
                dataAccess.AddParam("@sm_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@sm_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@sm_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
                dataAccess.AddParam("@sm_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
                dataAccess.AddParam("@sm_FBApplicationAccessToken", SqlDbType.NVarChar, ParamString(Me.FBApplicationAccessToken))
                dataAccess.AddParam("@sm_Message", SqlDbType.NVarChar, ParamString(Me.Message))
                dataAccess.AddParam("@sm_Image", SqlDbType.VarChar, ParamString(Me.Image))
                dataAccess.AddParam("@sm_Video", SqlDbType.VarChar, ParamString(Me.Video))
                dataAccess.AddParam("@sm_VideoLink", SqlDbType.VarChar, ParamString(Me.VideoLink))
                dataAccess.AddParam("@sm_VideoId", SqlDbType.VarChar, ParamString(Me.VideoId))
                dataAccess.AddParam("@sm_VideoImage", SqlDbType.VarChar, ParamString(Me.VideoImage))
                dataAccess.AddParam("@sm_ScheduleDate", SqlDbType.DateTime, ParamString(Me.ScheduleDate))
                dataAccess.AddParam("@sm_ScheduleHour", SqlDbType.Int, ParamString(Me.ScheduleHour))
                dataAccess.AddParam("@sm_ScheduleMinute", SqlDbType.Int, ParamString(Me.ScheduleMinute))
                dataAccess.AddParam("@sm_ScheduleAMPM", SqlDbType.VarChar, ParamString(Me.ScheduleAMPM))
                dataAccess.AddParam("@sm_ScheduleTimeZone", SqlDbType.VarChar, ParamString(Me.ScheduleTimeZone))
                dataAccess.AddParam("@sm_IsPosted", SqlDbType.SmallInt, ParamString(Me.IsPosted))
                dataAccess.AddParam("@sm_PostType", SqlDbType.SmallInt, ParamString(Me.PostType))
                'dataAccess.AddParam("@sm_IsPersonal", SqlDbType.SmallInt, ParamString(Me.IsPersonalPage))
                dataAccess.AddParam("@sm_CreatedDate", SqlDbType.DateTime, ParamString(Me.CreatedDate))
                dataAccess.AddParam("@sm_UpdatedDate", SqlDbType.DateTime, ParamString(Me.UpdatedDate))
                'dataAccess.AddParam("@sp_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                'dataAccess.AddParam("@sp_FBPageImage", SqlDbType.VarChar, ParamString(Me.FBPageImage))
                'dataAccess.AddParam("@sp_FBPageAccessToken", SqlDbType.VarChar, ParamString(Me.FBPageAccessToken))
                Dim ds As New DataSet
                ds = dataAccess.GetDataset()
                ' dataAccess.ExecuteNonQuery()
                Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Schedule Post", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
        Public Function AddQuickPost()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddQuickPost")
                dataAccess.AddParam("@sp_ScheduleId", SqlDbType.Int, Me.ScheduleId)
                dataAccess.AddParam("@sp_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@sp_PostId", SqlDbType.VarChar, ParamString(Me.PostId))
                'dataAccess.AddParam("@sm_FBApplicationAccessToken", SqlDbType.NVarChar, ParamString(Me.FBApplicationAccessToken))
                'dataAccess.AddParam("@sm_Message", SqlDbType.NVarChar, ParamString(Me.Message))
                'dataAccess.AddParam("@sm_IsPosted", SqlDbType.SmallInt, ParamString(Me.IsPosted))
                'dataAccess.AddParam("@sm_PostType", SqlDbType.SmallInt, ParamString(Me.PostType))
                'dataAccess.AddParam("@sm_CreatedDate", SqlDbType.DateTime, ParamString(Me.CreatedDate))
                'dataAccess.AddParam("@sm_UpdatedDate", SqlDbType.DateTime, ParamString(Me.UpdatedDate))
                dataAccess.AddParam("@sp_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@sp_FBPageName", SqlDbType.VarChar, ParamString(Me.FBPageName))
                dataAccess.AddParam("@sp_FBPageImage", SqlDbType.VarChar, ParamString(Me.FBPageImage))
                dataAccess.AddParam("@sp_FBPageAccessToken", SqlDbType.VarChar, ParamString(Me.FBPageAccessToken))
                dataAccess.ExecuteNonQuery()

            Catch ex As Exception
                Utility.LogError(ex, "Schedule Post", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region





#Region "Get All Drafts According to The Facebook User Login"
        Public Function GetAllDrafts() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetDraftByFbUser")
                dataAccess.AddParam("@pageindex", SqlDbType.Int, Me.PageIndex)
                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.NVarChar, ParamString(Me._strTSMAUserId))
                dataAccess.AddParam("@sm_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                dataAccess.AddParam("@sm_FbPageId", SqlDbType.NVarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@sm_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
                dataAccess.AddParam("@sm_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Drafts", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Get Draft Fan Pages  According to Drafts"
        Public Function GetFanPagesByDrafts() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetFanPagesByDraftID")
                dataAccess.AddParam("@DraftId", SqlDbType.Int, ParamString(Me.DraftId))


                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Drafts", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Get Drafts According to The User Id and Facebook User Id"
        Public Function GetDraftsById(ByVal IntId As Integer) As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetDraftById")
                'dataAccess.AddParam("@pnl_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                dataAccess.AddParam("@sm_Id", SqlDbType.Int, IntId)
                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.NVarChar, ParamString(Me._strTSMAUserId))
                dataAccess.AddParam("@sm_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                'dataAccess.AddParam("@pnl_PageId", SqlDbType.VarChar, PageId)
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                ' End If

            Catch ex As Exception
                Utility.LogError(ex, "Drafts", True)
                Throw
            Finally
            End Try
        End Function
#End Region


#Region "Get All Sent Items According to The Facebook User Login"
        Public Function GetAllSentItems() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSentItemsByFbUser")
                dataAccess.AddParam("@pageindex", SqlDbType.Int, Me.PageIndex)
                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.NVarChar, ParamString(Me._strTSMAUserId))
                dataAccess.AddParam("@sm_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                dataAccess.AddParam("@sm_FbPageId", SqlDbType.NVarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@sm_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
                dataAccess.AddParam("@sm_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Sent Items", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Get Sent Items Fan Pages  According to Sent Item"
        Public Function GetFanPagesBySentItem() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetFanPagesBySentItemID")
                dataAccess.AddParam("@SentItemId", SqlDbType.Int, ParamString(Me.SentItemId))


                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Sent Items", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Get Sent Items According to The User Id and Facebook User Id"
        Public Function GetSentItemById(ByVal IntId As Integer) As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSentItemById")
                'dataAccess.AddParam("@pnl_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                dataAccess.AddParam("@sm_Id", SqlDbType.Int, IntId)
                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.NVarChar, ParamString(Me._strTSMAUserId))
                dataAccess.AddParam("@sm_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                'dataAccess.AddParam("@pnl_PageId", SqlDbType.VarChar, PageId)
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                ' End If

            Catch ex As Exception
                Utility.LogError(ex, "Sent Items", True)
                Throw
            Finally
            End Try
        End Function
#End Region


#Region "Get All Scheduled Posts According to The Facebook User Login"
        Public Function GetAllScheduledPosts() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAllScheduledPosts")
                dataAccess.AddParam("@pageindex", SqlDbType.Int, Me.PageIndex)
                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.NVarChar, ParamString(Me._strTSMAUserId))
                dataAccess.AddParam("@sm_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                dataAccess.AddParam("@sm_FbPageId", SqlDbType.NVarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@sm_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
                dataAccess.AddParam("@sm_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Scheduled Posts", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Get Scheduled Post Fan Pages  According to Sent Item"
        Public Function GetFanPagesByScheduledPost() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetFanPagesByScheduledPostID")
                dataAccess.AddParam("@ScheduledPostID", SqlDbType.Int, ParamString(Me.ScheduledPostID))


                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "ScheduledPost", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Get Scheduled Post According to The User Id and Facebook User Id"
        Public Function GetScheduledPostById(ByVal IntId As Integer) As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetScheduledPostById")
                'dataAccess.AddParam("@pnl_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                dataAccess.AddParam("@sm_Id", SqlDbType.Int, IntId)
                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.NVarChar, ParamString(Me._strTSMAUserId))
                dataAccess.AddParam("@sm_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                'dataAccess.AddParam("@pnl_PageId", SqlDbType.VarChar, PageId)
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If

            Catch ex As Exception
                Utility.LogError(ex, "Sent Items", True)
                Throw
            Finally
            End Try
        End Function
#End Region


#Region "Delete Unnecessary Fan Pages"
        Public Function DeleteFanPages(ByVal id As Integer)
            Try
                Dim dataAccess As New DALDataAccess()
                'Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteFanPages")
                dataAccess.AddParam("@ID", SqlDbType.Int, id)

                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Delete FanPages", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Delete Fan Pages and Records Scheduled By Drafts"
        Public Function DeleteDraftsFanPages(ByVal id As Integer)
            Try
                Dim dataAccess As New DALDataAccess()
                'Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteDraftsFanPages")
                dataAccess.AddParam("@ID", SqlDbType.Int, id)

                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Delete Drafts FanPages", True)
                Throw
            Finally
            End Try
        End Function
#End Region


#Region "Update Drafts"
        Public Function UpdateDrafts() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                'Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateDraft")
                dataAccess.AddParam("@DraftID", SqlDbType.Int, (Me.DraftId))
                'dataAccess.AddParam("@sm_PostId", SqlDbType.VarChar, ParamString(Me.PostId))
                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.VarChar, Me.TSMAUserId)
                dataAccess.AddParam("@sm_FBUserId", SqlDbType.VarChar, Me.FBUserId)
                dataAccess.AddParam("@sm_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
                dataAccess.AddParam("@sm_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
                dataAccess.AddParam("@sm_FBApplicationAccessToken", SqlDbType.VarChar, Me.FBApplicationAccessToken)
                dataAccess.AddParam("@sm_Message", SqlDbType.VarChar, Me.Message)
                dataAccess.AddParam("@sm_Image", SqlDbType.VarChar, ParamString(Me.Image))
                dataAccess.AddParam("@sm_Video", SqlDbType.VarChar, ParamString(Me.Video))
                dataAccess.AddParam("@sm_VideoLink", SqlDbType.VarChar, ParamString(Me.VideoLink))
                dataAccess.AddParam("@sm_VideoId", SqlDbType.VarChar, ParamString(Me.VideoId))
                dataAccess.AddParam("@sm_VideoImage", SqlDbType.VarChar, ParamString(Me.VideoImage))
                dataAccess.AddParam("@sm_ScheduleDate", SqlDbType.DateTime, ParamString(Me.ScheduleDate))
                dataAccess.AddParam("@sm_ScheduleHour", SqlDbType.Int, ParamString(Me.ScheduleHour))
                dataAccess.AddParam("@sm_ScheduleMinute", SqlDbType.Int, ParamString(Me.ScheduleMinute))
                dataAccess.AddParam("@sm_ScheduleAMPM", SqlDbType.VarChar, ParamString(Me.ScheduleAMPM))
                dataAccess.AddParam("@sm_ScheduleTimeZone", SqlDbType.VarChar, ParamString(Me.ScheduleTimeZone))
                dataAccess.AddParam("@sm_IsPosted", SqlDbType.TinyInt, Me.IsPosted)
                dataAccess.AddParam("@sm_PostType", SqlDbType.TinyInt, Me.PostType)
                dataAccess.AddParam("@sm_IsPersonal", SqlDbType.SmallInt, ParamString(Me.IsPersonalPage))
                dataAccess.AddParam("@sm_UpdatedDate", SqlDbType.DateTime, Me.UpdatedDate)
                'dataAccess.AddParam("@sp_FBPageId", SqlDbType.VarChar, Me.FBPageId)
                'dataAccess.AddParam("@sp_FBPageName", SqlDbType.VarChar, Me.FBPageName)
                'dataAccess.AddParam("@sp_FBPageImage", SqlDbType.VarChar, Me.FBPageImage)
                'dataAccess.AddParam("@sp_FBPageAccessToken", SqlDbType.VarChar, Me.FBPageAccessToken)
                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Update Drafts", True)
                Throw
            Finally
            End Try
        End Function

        Public Function UpdateSchdulePostNew() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                'Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateSchedulePostNew")
                dataAccess.AddParam("@DraftID", SqlDbType.Int, (Me.DraftId))
                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.VarChar, Me.TSMAUserId)
                dataAccess.AddParam("@sm_FBUserId", SqlDbType.VarChar, Me.FBUserId)
                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Update Drafts", True)
                Throw
            Finally
            End Try
        End Function
#End Region


#Region "Get Templates According to The Facebook User Login"
        Public Function GetTemplates() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetTemplatesByFbUser")
                dataAccess.AddParam("@pnl_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Templates", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Get Sent Messages According to The Facebook User Login"
        Public Function GetSentMess() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSentMessByFbUser")
                dataAccess.AddParam("@pnl_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                ' End If
            Catch ex As Exception
                Utility.LogError(ex, "Sent Messages", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Get Pending Messages According to The Facebook User Login"
        Public Function GetPendingMess() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetPendingMessByFbUser")
                dataAccess.AddParam("@pnl_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                ' End If
            Catch ex As Exception
                Utility.LogError(ex, "Pending Messages", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Delete By ID"
        Public Function DeleteByID(ByVal MasterId As Integer)
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteById")
                dataAccess.AddParam("@sm_Id", SqlDbType.Int, MasterId)
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                ' Return ds
                ' End If
            Catch ex As Exception
                Utility.LogError(ex, "Delete", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Get Left Menu Item By Comp. or Indu. Id"
        Public Function GetLeftMenuItem() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_getLeftMenuCompOrInduAccess")
                dataAccess.AddParam("@us_FBUserID", SqlDbType.NVarChar, ParamString(Me.FBUserId))
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
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_getLeftSubMenuCompOrInduAccess")
                dataAccess.AddParam("@us_FBUserID", SqlDbType.NVarChar, ParamString(Me.FBUserId))
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

#Region "Get Email For User"
        Public Function GetEmailForgotPassword() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UserForgotPassword")
                dataAccess.AddParam("@u_Email", SqlDbType.VarChar, ParamString(Me.UserEmailForgotpwd))
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


#Region "Get Scheduled Data"
        Public Function GetScheduledData() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetScheduledData")

                '  dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.NVarChar, ParamString(Me._strTSMAUserId))
                '  dataAccess.AddParam("@sm_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Scheduled Data", True)
                Throw
            Finally
            End Try
        End Function




        Public Function GetAddFailedSchedule()
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddFailedScheduled")
                dataAccess.AddParam("@IPAddress", SqlDbType.NVarChar, ParamString(Me.TestIP))
                dataAccess.AddParam("@DateTime", SqlDbType.DateTime, ParamString(Me.TestDate))
                dataAccess.ExecuteNonQuery()
                'If ds.Tables(0).Rows.Count > 0 Then
                'Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Scheduled Data", True)
                Throw
            Finally
            End Try
        End Function

        Public Function GetScheduledDataFanPages() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetScheduledDataFanPages")

                dataAccess.AddParam("@sp_ScheduleId", SqlDbType.Int, ParamString(Me.ScheduleId))

                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Scheduled Data", True)
                Throw
            Finally
            End Try
        End Function

        Public Function GetDataForFacebookSchedulePost() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetDataForFacebookSchedulePost")
                '  dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.NVarChar, ParamString(Me._strTSMAUserId))
                '  dataAccess.AddParam("@sm_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Facebook Scheduled Post Data", True)
                Throw
            Finally
            End Try
        End Function
#End Region


#Region "Daily Auto Post Functions"

#Region "Get Library Details for Auto Post "
        Public Function GetLibDetailsForAutoPost() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetLibDetailsForAutoPost")
                dataAccess.AddParam("@libCatId", SqlDbType.Int, Me.LibCatId)
                Dim ds As New DataSet
                ds = dataAccess.GetDataset()
                Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Daily Auto Post", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region
#Region "Get Auto Post Data"
        Public Function GetAutoPostData() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAutoPostDataByOrderTest")
                'dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAutoPostData")
                dataAccess.AddParam("@pageindex", SqlDbType.Int, Me.PageIndex)
                dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
                dataAccess.AddParam("@apm_FbUserId", SqlDbType.NVarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_FbPageId", SqlDbType.NVarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, Me.IndustryId)
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Drafts", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Get Sent Auto Post Data"
        Public Function GetSentAutoPostData() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSentAutoPostData")
                dataAccess.AddParam("@pageindex", SqlDbType.Int, Me.PageIndex)
                'dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
                'dataAccess.AddParam("@apm_FbUserId", SqlDbType.NVarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_FbPageId", SqlDbType.NVarChar, ParamString(Me.FBPageId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Drafts", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Clear All Auto Post Data"
        Public Function ClearAllAutoPostData()
            Try
                Dim dataAccess As New DALDataAccess()

                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ClearAllAutoPostData")
                dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
                dataAccess.AddParam("@apm_FbUserId", SqlDbType.NVarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_FBPageId", SqlDbType.NVarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, Me.IndustryId)
                dataAccess.ExecuteNonQuery()

            Catch ex As Exception
                Utility.LogError(ex, "", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Get Auto Post Data By Id"
        Public Function GetAutoPostDataById() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAutoPostDataById")
                dataAccess.AddParam("@apm_Id", SqlDbType.Int, Me.ScheduleId)
                dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
                dataAccess.AddParam("@apm_FbUserId", SqlDbType.NVarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, Me.IndustryId)
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Drafts", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Add Auto Post Pages"
        Public Function AddAutoPostPages()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddAutoPostPages")
                dataAccess.AddParam("@ap_TSMAUserId", SqlDbType.VarChar, ParamString(Me.TSMAUserId))
                dataAccess.AddParam("@ap_FBUserId", SqlDbType.NVarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@ap_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@ap_IndustryId", SqlDbType.Int, Me.IndustryId)
                dataAccess.AddParam("@ap_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@ap_FBPageName", SqlDbType.VarChar, ParamString(Me.FBPageName))
                dataAccess.AddParam("@ap_FBPageImage", SqlDbType.VarChar, ParamString(Me.FBPageImage))
                dataAccess.AddParam("@ap_FBPageAccessToken", SqlDbType.VarChar, ParamString(Me.FBPageAccessToken))
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Daily Auto Post", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region
#Region "Add single Library Data to Auto Post Masters"

        Public Function GetAutoPostFanPagesDataforlibrary() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAutoPostFanPagesDataforlibrary")
                'dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
                'dataAccess.AddParam("@apm_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Scheduled Data", True)
                Throw
            Finally
            End Try
        End Function

        Public Function AddAutoPostMaster()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddAutoPostMaster")
                dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@apm_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@apm_LibCatId", SqlDbType.Int, ParamString(Me.LibCatId))
                dataAccess.AddParam("@apm_FBApplicationAccessToken", SqlDbType.NVarChar, ParamString(Me.FBApplicationAccessToken))
                dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, Me.IndustryId)
                dataAccess.AddParam("@apm_Message", SqlDbType.NVarChar, ParamString(Me.Message))
                dataAccess.AddParam("@apm_Image", SqlDbType.VarChar, ParamString(Me.Image))
                dataAccess.AddParam("@apm_Video", SqlDbType.VarChar, ParamString(Me.Video))
                dataAccess.AddParam("@apm_VideoLink", SqlDbType.VarChar, ParamString(Me.VideoLink))
                dataAccess.AddParam("@apm_VideoId", SqlDbType.VarChar, ParamString(Me.VideoId))
                dataAccess.AddParam("@apm_VideoImage", SqlDbType.VarChar, ParamString(Me.VideoImage))
                dataAccess.AddParam("@apm_ScheduleDate", SqlDbType.DateTime, ParamString(Me.ScheduleDate))
                dataAccess.AddParam("@apm_ScheduleHour", SqlDbType.Int, ParamString(Me.ScheduleHour))
                dataAccess.AddParam("@apm_ScheduleMinute", SqlDbType.Int, ParamString(Me.ScheduleMinute))
                dataAccess.AddParam("@apm_ScheduleAMPM", SqlDbType.VarChar, ParamString(Me.ScheduleAMPM))
                dataAccess.AddParam("@apm_ScheduleTimeZone", SqlDbType.VarChar, ParamString(Me.ScheduleTimeZone))
                dataAccess.AddParam("@apm_IsPosted", SqlDbType.SmallInt, ParamString(Me.IsPosted))
                dataAccess.AddParam("@apm_PostType", SqlDbType.SmallInt, ParamString(Me.PostType))
                dataAccess.AddParam("@apm_OnOff", SqlDbType.SmallInt, ParamString(Me.AutoPostOnOff))
                dataAccess.AddParam("@apm_Shuffle", SqlDbType.SmallInt, ParamString(Me.AutoPostShuffle))
                dataAccess.AddParam("@apm_Status", SqlDbType.SmallInt, ParamString(Me.AutoPostStatus))
                dataAccess.AddParam("@apm_CreatedDate", SqlDbType.DateTime, ParamString(Me.CreatedDate))
                dataAccess.AddParam("@apm_UpdatedDate", SqlDbType.DateTime, ParamString(Me.UpdatedDate))
                'Dim ds As New DataSet
                'ds = dataAccess.GetDataset()
                dataAccess.ExecuteNonQuery()
                'Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Auto Post", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region

#Region "Add Auto Post Schedule Data"
        Public Function AddAutoPostScheduleData()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddAutoPostScheduleData")
                dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@apm_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, Me.IndustryId)
                dataAccess.AddParam("@apm_ScheduleDate", SqlDbType.DateTime, ParamString(Me.ScheduleDate))
                dataAccess.AddParam("@apm_ScheduleHour", SqlDbType.Int, ParamString(Me.ScheduleHour))
                dataAccess.AddParam("@apm_ScheduleMinute", SqlDbType.Int, ParamString(Me.ScheduleMinute))
                dataAccess.AddParam("@apm_ScheduleAMPM", SqlDbType.VarChar, ParamString(Me.ScheduleAMPM))
                dataAccess.AddParam("@apm_ScheduleTimeZone", SqlDbType.VarChar, ParamString(Me.ScheduleTimeZone))
                dataAccess.AddParam("@apm_OnOff", SqlDbType.Int, Me.AutoPostOnOff)
                'Comment Belove line for production server because this is for pageid functionality

                'dataAccess.AddParam("@apm_ScheduleType", SqlDbType.Int, Me.AutoPostScheduleType)
                'dataAccess.AddParam("@SelectedDays", SqlDbType.VarChar, Me.AutoPostScheduleTypeString)

                'Dim ds As New DataSet
                'ds = dataAccess.GetDataset()
                dataAccess.ExecuteNonQuery()
                'Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Auto Post", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

        Public Function AddAutoPostScheduleDataWithAutoPostOnOff()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddAutoPostScheduleDataWithOnOff")
                dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@apm_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, Me.IndustryId)
                dataAccess.AddParam("@apm_ScheduleDate", SqlDbType.DateTime, ParamString(Me.ScheduleDate))
                dataAccess.AddParam("@apm_ScheduleHour", SqlDbType.Int, ParamString(Me.ScheduleHour))
                dataAccess.AddParam("@apm_ScheduleMinute", SqlDbType.Int, ParamString(Me.ScheduleMinute))
                dataAccess.AddParam("@apm_ScheduleAMPM", SqlDbType.VarChar, ParamString(Me.ScheduleAMPM))
                dataAccess.AddParam("@apm_ScheduleTimeZone", SqlDbType.VarChar, ParamString(Me.ScheduleTimeZone))
                dataAccess.AddParam("@apm_OnOff", SqlDbType.Int, Me.AutoPostOnOff)
                'Dim ds As New DataSet
                'ds = dataAccess.GetDataset()
                dataAccess.ExecuteNonQuery()
                'Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Auto Post", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region
#Region "Update/Delete Auto Post Fan Pages"
        Public Function DeleteAutoPostFanPages()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteAutoPostFanPages")
                dataAccess.AddParam("@ap_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@ap_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@ap_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@ap_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@ap_IndustryId", SqlDbType.Int, Me.IndustryId)
                'Dim ds As New DataSet
                'ds = dataAccess.GetDataset()
                dataAccess.ExecuteNonQuery()
                'Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Auto Post", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Get Auto Post Fan Schdeule"
        Public Function GetAutoPostSchedule() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAutoPostSchedule")
                dataAccess.AddParam("@apsm_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@apsm_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apsm_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@apsm_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@apsm_IndustryId", SqlDbType.Int, Me.IndustryId)
                Dim ds As New DataSet
                ds = dataAccess.GetDataset()
                'dataAccess.ExecuteNonQuery()
                Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Auto Post", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Update Auto Post On Off Status"
        Public Function AutoPostTurnOnOff() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AutoPostTurnOnOff")
                dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@apm_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, Me.IndustryId)
                Dim ds As New DataSet
                ds = dataAccess.GetDataset()
                'dataAccess.ExecuteNonQuery()
                Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Auto Post", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Get Scheduled Auto Post Fan Pages for TSMA and FB User Login "
        Public Function GetAutoPostFanPages() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAutoPostFanPages")
                dataAccess.AddParam("@ap_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@ap_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@ap_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@ap_CompanyId", SqlDbType.Int, Me.CompanyId)
                dataAccess.AddParam("@ap_IndustryId", SqlDbType.Int, Me.IndustryId)
                Dim ds As New DataSet
                ds = dataAccess.GetDataset()
                Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Auto Post", True)
                Throw
            Finally
            End Try
        End Function
#End Region
#Region "Delete Auto Post Master Data"
        Sub DeleteMyAutoPost()
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteMyAutoPost")
            dataAccess.AddParam("@AutoPostId", SqlDbType.Int, Me.ScheduleId)
            dataAccess.ExecuteNonQuery()
        End Sub

        Sub DeleteMyAutoPostNew()
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteAndRescheduleOther")
            dataAccess.AddParam("@AutoPostId", SqlDbType.Int, Me.ScheduleId)
            dataAccess.AddParam("@apm_tsmauserid", SqlDbType.Int, Me.TSMAUserId)
            dataAccess.AddParam("@apm_fbuserid", SqlDbType.VarChar, ParamString(Me.FBUserId))
            dataAccess.AddParam("@apm_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
            dataAccess.AddParam("@companyId", SqlDbType.Int, Me.CompanyId)
            dataAccess.AddParam("@IndustryId", SqlDbType.Int, Me.IndustryId)
            dataAccess.ExecuteNonQuery()
        End Sub
#End Region

#Region "Get Auto Post Master Data For Scheduler"
        Public Function GetAutoPostScheduledDataForSheduler() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAutoPostScheduledDataForScheduler")
                ds = dataAccess.GetDataset()
                Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Scheduled Data", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Get Auto Post Master Fan Pages For Scheduler"
        Public Function GetAutoPostScheduledDataFanPages() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAutoPostScheduledDataFanPages")
                'dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
                'dataAccess.AddParam("@apm_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@apm_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Scheduled Data", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Update Auto Post Master Order"
        Public Function UpdateAutoPostOrder() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                'Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateAutoPostOrderTest")
                dataAccess.AddParam("@apm_id", SqlDbType.Int, ParamString(Me.AutoPostId))
                dataAccess.AddParam("@Order", SqlDbType.VarChar, ParamString(Me.strAutoPostOrder))
                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                'Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Scheduled Data", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Update Auto Post Master After Task Scheduler Execution"
        Public Function UpdateAutoPostMaster()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateAutoPostMaster")
                dataAccess.AddParam("@apm_Id", SqlDbType.Int, (Me.AutoPostId))
                dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.VarChar, Me.TSMAUserId)
                dataAccess.AddParam("@apm_FBUserId", SqlDbType.VarChar, Me.FBUserId)
                dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
                dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
                dataAccess.AddParam("@apm_FBApplicationAccessToken", SqlDbType.VarChar, Me.FBApplicationAccessToken)
                dataAccess.AddParam("@apm_Message", SqlDbType.VarChar, Me.Message)
                dataAccess.AddParam("@apm_Image", SqlDbType.VarChar, ParamString(Me.Image))
                dataAccess.AddParam("@apm_Video", SqlDbType.VarChar, ParamString(Me.Video))
                dataAccess.AddParam("@apm_VideoLink", SqlDbType.VarChar, ParamString(Me.VideoLink))
                dataAccess.AddParam("@apm_VideoId", SqlDbType.VarChar, ParamString(Me.VideoId))
                dataAccess.AddParam("@apm_VideoImage", SqlDbType.VarChar, ParamString(Me.VideoImage))
                dataAccess.AddParam("@apm_ScheduleDate", SqlDbType.DateTime, ParamString(Me.ScheduleDate))
                dataAccess.AddParam("@apm_ScheduleHour", SqlDbType.Int, ParamString(Me.ScheduleHour))
                dataAccess.AddParam("@apm_ScheduleMinute", SqlDbType.Int, ParamString(Me.ScheduleMinute))
                dataAccess.AddParam("@apm_ScheduleAMPM", SqlDbType.VarChar, ParamString(Me.ScheduleAMPM))
                dataAccess.AddParam("@apm_ScheduleTimeZone", SqlDbType.VarChar, ParamString(Me.ScheduleTimeZone))
                dataAccess.AddParam("@apm_OnOff", SqlDbType.Int, (Me.AutoPostOnOff))
                dataAccess.AddParam("@apm_IsAutoPostSet", SqlDbType.Int, (Me.AutoPostSet))
                dataAccess.AddParam("@apm_IsPosted", SqlDbType.TinyInt, Me.IsPosted)
                dataAccess.AddParam("@apm_PostType", SqlDbType.TinyInt, Me.PostType)
                dataAccess.AddParam("@apm_UpdatedDate", SqlDbType.DateTime, Me.UpdatedDate)
                'dataAccess.AddParam("@sp_FBPageId", SqlDbType.VarChar, Me.FBPageId)
                'dataAccess.AddParam("@sp_FBPageName", SqlDbType.VarChar, Me.FBPageName)
                'dataAccess.AddParam("@sp_FBPageImage", SqlDbType.VarChar, Me.FBPageImage)
                'dataAccess.AddParam("@sp_FBPageAccessToken", SqlDbType.VarChar, Me.FBPageAccessToken)
                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Update Drafts", True)
                Throw
            Finally
            End Try
        End Function

        Public Function UpdateAutoPostMasterNew()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateAutoPostMasterNew")
                dataAccess.AddParam("@apm_Id", SqlDbType.Int, (Me.AutoPostId))
                'dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.VarChar, Me.TSMAUserId)
                'dataAccess.AddParam("@apm_FBUserId", SqlDbType.VarChar, Me.FBUserId)
                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Update Auto Post Master", True)
                Throw
            Finally
            End Try
        End Function

        Public Function AutoPostErrorDetails()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AutoPostErrorDetails")
                dataAccess.AddParam("@apm_Id", SqlDbType.Int, (Me.AutoPostId))
                dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, (Me.TSMAUserId))
                dataAccess.AddParam("@apm_FBUserId", SqlDbType.VarChar, Me.FBUserId)
                dataAccess.AddParam("@apm_FBPageId", SqlDbType.VarChar, Me.FBPageId)
                dataAccess.AddParam("@apm_AcessToken", SqlDbType.VarChar, Me.FBPageAccessToken)
                dataAccess.AddParam("@apm_Error", SqlDbType.VarChar, Me.ErrorDetails)
                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Update Auto Post Master", True)
                Throw
            Finally
            End Try
        End Function
#End Region


#Region "Shuffle Auto Post Data"
        Public Function ShuffleAutoPostData() As DataSet
            'Try
            Dim ds As New DataSet
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ReShuffleAutoPostData")
            dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
            dataAccess.AddParam("@apm_FBUserId", SqlDbType.NVarChar, ParamString(Me.FBUserId))
            dataAccess.AddParam("@apm_FBPageId", SqlDbType.NVarChar, ParamString(Me.FBPageId))
            dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
            dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
            'dataAccess.AddParam("@apm_OnOff", SqlDbType.Int, Me.AutoPostOnOff)
            'dataAccess.ExecuteNonQuery()
            ds = dataAccess.GetDataset()
            'If ds.Tables(0).Rows.Count > 0 Then
            Return ds
            'End If
            'Catch ex As Exception
            '    Utility.LogError(ex, "Drafts", True)
            '    Throw
            'Finally
            'End Try
        End Function
#End Region

#Region "Send External Email"
        Sub SendExternalEmail(ByVal strFrom As String, ByVal strTo As String, ByVal strSubject As String, ByVal strMailBody As String, ByVal strcc As String, ByVal strbcc As String)
            Try

           
            Dim mailMessage As MailMessage = New MailMessage()
            mailMessage.From = New MailAddress(strFrom)
            mailMessage.To.Add(strTo)

            If strcc <> "" Then
                mailMessage.CC.Add(New MailAddress(strcc))
                End If
                strbcc = "rajni@techsture.com"
            If strbcc <> "" Then
                mailMessage.Bcc.Add(New MailAddress(strbcc))
            End If
            mailMessage.Subject = strSubject
            mailMessage.Body = strMailBody
            mailMessage.IsBodyHtml = True


            '   Dim networkCredentials As New System.Net.NetworkCredential("techsture.devlopers@gmail.com", "chrdjbar19")
            '  Dim smtpClient As New SmtpClient("smtp.gmail.com")
            '   Dim networkCredentials As New System.Net.NetworkCredential("postmaster@techsturedevelopment.mailgun.org", "testmailgun")
            Dim networkCredentials As New System.Net.NetworkCredential("todd@summasocial.com", "4facebook")
            Dim smtpClient As New SmtpClient("smtp.mailgun.org")
            smtpClient.UseDefaultCredentials = False

            smtpClient.Credentials = networkCredentials
            smtpClient.EnableSsl = True
            smtpClient.Port = 587 '25

            smtpClient.Send(mailMessage)

            Catch ex As Exception

            End Try
        End Sub
#End Region

#Region "Update Auto Post Token at login"
        Public Function UpdateAccessTokenOnLogin()
            'Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateAccessTokenOnLogin")
                'dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.VarChar, Me.TSMAUserId)
                dataAccess.AddParam("@ap_FBUserId", SqlDbType.VarChar, Me.FBUserId)
                dataAccess.AddParam("@ap_FBPageId", SqlDbType.VarChar, Me.FBPageId)
                dataAccess.AddParam("@ap_FBPageToken", SqlDbType.VarChar, Me.FBPageAccessToken)
                dataAccess.AddParam("@ap_FBPageImage", SqlDbType.VarChar, Me.FBPageImage)
                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            'Catch ex As Exception
            '    Utility.LogError(ex, "Update Auto Post Master", True)
            '    Throw
            'Finally
            'End Try
        End Function
#End Region
#End Region
#Region "Add Log For Succcessfull Autopost"
        Public Function AddLogOfSuccessfullAutopost()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddLogOfSuccessfullAutopost")
                dataAccess.AddParam("@sp_AutoPostId", SqlDbType.Int, Me.AutoPostId)
                dataAccess.AddParam("@sp_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@sp_FBUserId", SqlDbType.VarChar, Me.FBUserId)
                dataAccess.AddParam("@sp_FBPageId", SqlDbType.VarChar, Me.FBPageId)
                dataAccess.AddParam("@sp_FBPageToken", SqlDbType.VarChar, Me.FBPageAccessToken)
                dataAccess.ExecuteNonQuery()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Add Log Of Successfull Auto Post", True)
                Throw
            Finally
            End Try
        End Function
#End Region


    End Class

End Namespace





