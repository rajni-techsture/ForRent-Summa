Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Namespace BusinessLayer
    Public Class AutoPostConfig
        Inherits IRecord

        Public Property FBUserID() As String
            Get
                Return _FbUserId
            End Get
            Set(ByVal value As String)
                _FbUserId = value
            End Set
        End Property
        Private _FbUserId As String

        Public Property PageIndex() As Integer
            Get
                Return _strPageIndex
            End Get
            Set(ByVal value As Integer)
                _strPageIndex = value
            End Set
        End Property
        Private _strPageIndex As Integer = 1

        Public Property TSMAUserId() As Integer
            Get
                Return _strTSMAUserId
            End Get
            Set(ByVal value As Integer)
                _strTSMAUserId = value
            End Set
        End Property
        Private _strTSMAUserId As Integer = 0

        Public Property FBPageId() As String
            Get
                Return _strFBPageId
            End Get
            Set(ByVal value As String)
                _strFBPageId = value
            End Set
        End Property
        Private _strFBPageId As String = String.Empty

        Public Property CompanyId() As Integer
            Get
                Return _CompInduId
            End Get
            Set(ByVal value As Integer)
                _CompInduId = value
            End Set
        End Property
        Private _CompInduId As Integer = 0

        Public Property IndustryId() As Integer
            Get
                Return _intIndustryId
            End Get
            Set(ByVal value As Integer)
                _intIndustryId = value
            End Set
        End Property
        Private _intIndustryId As Integer = 0

        Public Function GetAutoPostConfigForUser() As DataSet
            Dim ds As DataSet
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ViewAllAutoPostConfig")
            dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserID))

            ds = dataAccess.GetDataset()
            Return ds
        End Function

        Public Function GetScheduledAutoPosts() As DataSet
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetScheduledAutoPostDataByPageId")
            dataAccess.AddParam("@pageindex", SqlDbType.Int, Me.PageIndex)
            dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
            dataAccess.AddParam("@apm_FbUserId", SqlDbType.NVarChar, ParamString(Me.FBUserID))
            dataAccess.AddParam("@apm_FbPageId", SqlDbType.NVarChar, ParamString(Me.FBPageId))
            dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, Me.CompanyId)
            dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, Me.IndustryId)
            ds = dataAccess.GetDataset()
            Return ds
        End Function

        Public Function GetSentAutoPosts() As DataSet
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSentAutoPostDataByPageId")
            dataAccess.AddParam("@pageindex", SqlDbType.Int, Me.PageIndex)
            dataAccess.AddParam("@apm_TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
            dataAccess.AddParam("@apm_FbUserId", SqlDbType.NVarChar, ParamString(Me.FBUserID))
            dataAccess.AddParam("@apm_FbPageId", SqlDbType.NVarChar, ParamString(Me.FBPageId))
            dataAccess.AddParam("@apm_CompanyId", SqlDbType.Int, Me.CompanyId)
            dataAccess.AddParam("@apm_IndustryId", SqlDbType.Int, Me.IndustryId)
            ds = dataAccess.GetDataset()
            Return ds
        End Function
    End Class
End Namespace

