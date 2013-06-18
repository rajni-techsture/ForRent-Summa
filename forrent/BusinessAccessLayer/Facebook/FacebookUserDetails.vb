Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Imports System.Net.Mail


Namespace BusinessLayer
    <RecordAttribute("tbl_PostNLeap", "prc_AddQuickPost", New [String](0) {"Quick Post"})>
    Public Class FacebookUserDetails
        Inherits IRecord

        '#Region "Variables"
        '        Private _strFBUserId As String = String.Empty
        '        Private _strFBUserId As String = String.Empty
        '        Private _strFBUserId As String = String.Empty
        '        Private _strFBUserId As String = String.Empty
        '        Private _strFBUserId As String = String.Empty
        '        Private _strFBUserId As String = String.Empty
        '#End Region

        '#Region "Properties"
        '        ''' <summary>
        '        ''' Schedule Post Fuction 
        '        ''' </summary>
        '        ''' <value>The <c>FBUserId</c> FBPageId <c>FBPageImage</c> FBPageAccessToken</value>
        '        ''' 


        '        Public Property FBUSerId() As String
        '            Get
        '                Return _strFBUserId
        '            End Get
        '            Set(ByVal value As String)
        '                _strFBUserId = value
        '            End Set
        '        End Property


        '#End Region

        '#Region "CONSTRUCTORS"
        '        Public Sub New()
        '        End Sub
        '#End Region

        '#Region "Add Quick Post"

        '        Public Function AddQuickPostMaster()
        '            Try
        '                Dim dataAccess As New DALDataAccess()
        '                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddQuickPostMaster")
        '                dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
        '                dataAccess.AddParam("@sm_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
        '                dataAccess.AddParam("@sm_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
        '                dataAccess.AddParam("@sm_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
        '                dataAccess.AddParam("@sm_FBApplicationAccessToken", SqlDbType.NVarChar, ParamString(Me.FBApplicationAccessToken))
        '                dataAccess.AddParam("@sm_Message", SqlDbType.NVarChar, ParamString(Me.Message))
        '                dataAccess.AddParam("@sm_Image", SqlDbType.VarChar, ParamString(Me.Image))
        '                dataAccess.AddParam("@sm_Video", SqlDbType.VarChar, ParamString(Me.Video))
        '                dataAccess.AddParam("@sm_VideoLink", SqlDbType.VarChar, ParamString(Me.VideoLink))
        '                dataAccess.AddParam("@sm_VideoId", SqlDbType.VarChar, ParamString(Me.VideoId))
        '                dataAccess.AddParam("@sm_VideoImage", SqlDbType.VarChar, ParamString(Me.VideoImage))
        '                dataAccess.AddParam("@sm_ScheduleDate", SqlDbType.DateTime, ParamString(Me.ScheduleDate))
        '                dataAccess.AddParam("@sm_ScheduleHour", SqlDbType.Int, ParamString(Me.ScheduleHour))
        '                dataAccess.AddParam("@sm_ScheduleMinute", SqlDbType.Int, ParamString(Me.ScheduleMinute))
        '                dataAccess.AddParam("@sm_ScheduleAMPM", SqlDbType.VarChar, ParamString(Me.ScheduleAMPM))
        '                dataAccess.AddParam("@sm_ScheduleTimeZone", SqlDbType.VarChar, ParamString(Me.ScheduleTimeZone))
        '                dataAccess.AddParam("@sm_IsPosted", SqlDbType.SmallInt, ParamString(Me.IsPosted))
        '                dataAccess.AddParam("@sm_PostType", SqlDbType.SmallInt, ParamString(Me.PostType))
        '                dataAccess.AddParam("@sm_CreatedDate", SqlDbType.DateTime, ParamString(Me.CreatedDate))
        '                dataAccess.AddParam("@sm_UpdatedDate", SqlDbType.DateTime, ParamString(Me.UpdatedDate))
        '                'dataAccess.AddParam("@sp_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
        '                'dataAccess.AddParam("@sp_FBPageImage", SqlDbType.VarChar, ParamString(Me.FBPageImage))
        '                'dataAccess.AddParam("@sp_FBPageAccessToken", SqlDbType.VarChar, ParamString(Me.FBPageAccessToken))
        '                Dim ds As New DataSet
        '                ds = dataAccess.GetDataset()
        '                ' dataAccess.ExecuteNonQuery()
        '                Return ds
        '            Catch ex As Exception
        '                Utility.LogError(ex, "Schedule Post", True)
        '                Throw
        '            Finally
        '            End Try
        '            'Return _intUserId
        '        End Function

        '#End Region
    End Class

End Namespace
