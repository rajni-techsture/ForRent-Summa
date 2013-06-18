Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data


Namespace BusinessLayer
    Public Class BALAdminWeeklyTip
        Inherits IRecord

#Region "Variables"
        Private _strTitle As String = String.Empty
        Private _strDescription As String = String.Empty
        Private _strVideoThumbnail As String = String.Empty
        Private _strVideo As String = String.Empty
        Private _strSethome As Integer = 0
        Private _strStatus As Integer = 0
        Private _intWTId As Integer = 0

        Private _isError As Boolean = False
        Private strMessage As String
#End Region

#Region "Properties"
        ''' <summary>
        ''' Gets and sets the <c>Username</c> Password
        ''' </summary>
        ''' <value>The <c>Username</c> Password</value>

        Public Property Title() As String
            Get
                Return _strTitle
            End Get
            Set(value As String)
                _strTitle = value
            End Set
        End Property


        Public Property Description() As String
            Get
                Return _strDescription
            End Get
            Set(value As String)
                _strDescription = value
            End Set
        End Property
        Public Property Video() As String
            Get
                Return _strVideo
            End Get
            Set(value As String)
                _strVideo = value
            End Set
        End Property
        Public Property VideoThumbnail() As String
            Get
                Return _strVideoThumbnail
            End Get
            Set(value As String)
                _strVideoThumbnail = value
            End Set
        End Property
        Public Property SetHome() As Integer
            Get
                Return _strSethome
            End Get
            Set(value As Integer)
                _strSethome = value
            End Set
        End Property


        Public Property Status() As Integer
            Get
                Return _strStatus
            End Get
            Set(value As Integer)
                _strStatus = value
            End Set
        End Property


        Public Property WTId() As Integer
            Get
                Return _intWTId
            End Get
            Set(value As Integer)
                _intWTId = value
            End Set
        End Property

#End Region

#Region "CONSTRUCTORS"
        Public Sub New()
        End Sub
#End Region

#Region "Add Weekly Tip"
        Public Function AddWeeklyTip() As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddWeeklyTip")
            dataAccess.AddParam("@wt_Title", SqlDbType.NVarChar, ParamString(Me.Title))
            dataAccess.AddParam("@wt_Description", SqlDbType.NVarChar, ParamString(Me.Description))
            dataAccess.AddParam("@wt_Video", SqlDbType.NVarChar, ParamString(Me.Video))
            dataAccess.AddParam("@wt_VideoThumbnail", SqlDbType.NVarChar, ParamString(Me.VideoThumbnail))
            dataAccess.AddParam("@wt_SetHome", SqlDbType.TinyInt, ParamString(Me.SetHome))
            dataAccess.AddParam("@wt_Status", SqlDbType.TinyInt, ParamString(Me.Status))

            dataAccess.GetDataset()
            
        End Function

#End Region

#Region "Update Weekly Tip"
        Public Function UpdateFanFriday(ByVal WTID As Integer) As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateWeeklyTip")
            dataAccess.AddParam("@wt_Id", SqlDbType.NVarChar, WTID)
            dataAccess.AddParam("@wt_Title", SqlDbType.NVarChar, ParamString(Me.Title))
            dataAccess.AddParam("@wt_Description", SqlDbType.NVarChar, ParamString(Me.Description))
            dataAccess.AddParam("@wt_Video", SqlDbType.NVarChar, ParamString(Me.Video))
            dataAccess.AddParam("@wt_VideoThumbnail", SqlDbType.NVarChar, ParamString(Me.VideoThumbnail))
            dataAccess.AddParam("@wt_SetHome", SqlDbType.TinyInt, ParamString(Me.SetHome))
            dataAccess.AddParam("@wt_Status", SqlDbType.TinyInt, ParamString(Me.Status))

            ds = dataAccess.GetDataset()
            Dim res As Integer = ds.Tables(0).Rows(0).Item(0)
            Return res


        End Function

#End Region


#Region "Get Weekly Tip"
        Public Function GetWeeklyTip(ByVal WeeklyTipID As Integer) As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetWeeklyTip")
            dataAccess.AddParam("@wt_Id", SqlDbType.Int, WeeklyTipID)


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region


#Region "Bind WeeklyTip"
        Public Function BindWeeklyTip() As DataSet

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ViewWeeklyTip")


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Change Weekly Tip Status"
        Public Function ChangeWeeklyTipStatus() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ChangeWeeklyTipStatus")
                dataAccess.AddParam("@wt_Id", SqlDbType.Int, Me.WTId)
                dataAccess.AddParam("@wt_Status", SqlDbType.Int, Me.Status)
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Change Status", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Set Weekly Tip In Home"
        Public Function SetWeeklyTipInHome()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_SetWeeklyTipInHome")
                dataAccess.AddParam("@wt_Id", SqlDbType.Int, Me.WTId)
                dataAccess.AddParam("@wt_SetHome", SqlDbType.Int, Me.SetHome)
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Set Home", True)
                Throw
            Finally
            End Try
        End Function
#End Region

    End Class
End Namespace
