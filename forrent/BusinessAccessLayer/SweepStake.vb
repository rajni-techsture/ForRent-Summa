Imports DataAccessLayer.DataAccessLayer
Namespace BusinessLayer
    Public Class BALSweepStake
        Inherits IRecord

        Private _strTestDate As DateTime
        Private _strTestIP As String = String.Empty


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

        Public Property FBPageName() As String
            Get
                Return _FBPageName
            End Get
            Set(value As String)
                _FBPageName = value
            End Set
        End Property
        Private _FBPageName As String = String.Empty
        Public Property FBPageImage() As String
            Get
                Return strFBPageImage
            End Get
            Set(value As String)
                strFBPageImage = value
            End Set
        End Property
        Private strFBPageImage As String = String.Empty
        Public Property FBPageAccessToken() As String
            Get
                Return strFBPageAccessToken
            End Get
            Set(value As String)
                strFBPageAccessToken = value
            End Set
        End Property
        Private strFBPageAccessToken As String = String.Empty
        Public Property SweepstakeId() As Integer
            Get
                Return intSweepstakeId
            End Get
            Set(value As Integer)
                intSweepstakeId = value
            End Set
        End Property
        Private intSweepstakeId As Integer

        Public Property TSMAUserId() As Integer
            Get
                Return _TSMAUserId
            End Get
            Set(value As Integer)
                _TSMAUserId = value
            End Set
        End Property
        Private _TSMAUserId As Integer = 0

        Public Property CompanyId() As Integer
            Get
                Return _CompanyId
            End Get
            Set(value As Integer)
                _CompanyId = value
            End Set
        End Property
        Private _CompanyId As Integer = 0
        Public Property IndustryId() As Integer
            Get
                Return _IndustryId
            End Get
            Set(value As Integer)
                _IndustryId = value
            End Set
        End Property
        Private _IndustryId As Integer = 0

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

        Public Property ErrorDetails() As String
            Get
                Return _strError
            End Get
            Set(ByVal value As String)
                _strError = value
            End Set
        End Property
        Private _strError As String = String.Empty
        Public Property IsPublished() As String
            Get
                Return _intIsPublished
            End Get
            Set(ByVal value As String)
                _intIsPublished = value
            End Set
        End Property
        Private _intIsPublished As Integer = 1

        Public Function AddEditSweepStake() As DataSet
            Try
                Dim ds As New DataSet
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_InsertUpdateSweepStake")
                dataAccess.AddParam("@TSMAUserId", SqlDbType.Int, ParamString(Me.TSMAUserId))
                dataAccess.AddParam("@CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
                dataAccess.AddParam("@IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
                dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@FBPageName", SqlDbType.VarChar, ParamString(Me.FBPageName))
                dataAccess.AddParam("@Title", SqlDbType.VarChar, ParamString(Me.Title))
                dataAccess.AddParam("@Content", SqlDbType.VarChar, ParamString(Me.Content))
                dataAccess.AddParam("@IsPublished", SqlDbType.Int, 1)
                ds = dataAccess.GetDataset()
                Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Sweep Stake", True)
                Throw
            Finally
            End Try
        End Function

        Public Function GetSweepStake() As DataSet
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSweepStake")
            dataAccess.AddParam("@FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
            Dim ds As New DataSet
            ds = dataAccess.GetDataset()
            Return ds
            'If ds.Tables(0).Rows.Count > 0 Then
            '    Me.Title = ds.Tables(0).Rows(0).Item("Title").ToString
            '    Me.Content = ds.Tables(0).Rows(0).Item("Content").ToString
            '    Me.FBUserId = ds.Tables(0).Rows(0).Item("FBUserId").ToString
            '    Me.FBPageId = ds.Tables(0).Rows(0).Item("FBPageId").ToString
            'End If
        End Function

        Public Sub AddSweepStakeContest()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddSweepStakeContest")
                dataAccess.AddParam("@Name", SqlDbType.VarChar, ParamString(Me.Name))
                dataAccess.AddParam("@Email", SqlDbType.VarChar, ParamString(Me.Email))
                dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@TSMAUserId", SqlDbType.VarChar, ParamString(Me.TSMAUserId))
                dataAccess.AddParam("@FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))

                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Sweep Stake Contest", True)
                Throw
            Finally
            End Try
        End Sub

#Region "Add Sweepstakes Fan Pages "
        Public Function AddSweepstakeFanPages()
            ' Try
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddSweepstakesFanPages")
            dataAccess.AddParam("@ssp_SweepstakeId", SqlDbType.Int, Me.SweepstakeId)
            dataAccess.AddParam("@ssp_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
            dataAccess.AddParam("@ssp_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
            dataAccess.AddParam("@ssp_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
            dataAccess.AddParam("@ssp_FBPageName", SqlDbType.VarChar, ParamString(Me.FBPageName))
            dataAccess.AddParam("@ssp_FBPageImage", SqlDbType.VarChar, ParamString(Me.FBPageImage))
            dataAccess.AddParam("@ssp_FBPageAccessToken", SqlDbType.VarChar, ParamString(Me.FBPageAccessToken))
            dataAccess.ExecuteNonQuery()

            'Catch ex As Exception
            'Utility.LogError(ex, "", True)
            ' Throw
            'Finally
            'End Try
            'Return _intUserId
        End Function
#End Region

#Region "Get Schedule Sweepstake Data / fan pages / add error"
        Public Function GetScheduledSweepstakeData() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetScheduledSweepstakeData")

                '  dataAccess.AddParam("@sm_TSMAUserId", SqlDbType.NVarChar, ParamString(Me._strTSMAUserId))
                '  dataAccess.AddParam("@sm_FbUserId", SqlDbType.NVarChar, ParamString(Me._strFBUserId))
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Scheduled Sweepstake Data", True)
                Throw
            Finally
            End Try
        End Function

        Public Function GetAddFailedScheduleSweepstake()
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddFailedScheduledSweepstake")
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

        Public Function GetScheduledSweepstakeDataFanPages() As DataSet
             Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetSweepstakeScheduledDataFanPages")
                dataAccess.AddParam("@ss_TSMAUserId", SqlDbType.Int, Me.TSMAUserId)
                dataAccess.AddParam("@ss_FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@ss_FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
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

        Public Function AddSweepstakeErrorDetails() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_SweepstakeErrorDetails")
                dataAccess.AddParam("@ss_Id", SqlDbType.Int, (Me.SweepstakeId))
                dataAccess.AddParam("@ss_TSMAUserId", SqlDbType.Int, (Me.TSMAUserId))
                dataAccess.AddParam("@ss_FBUserId", SqlDbType.VarChar, Me.FBUserId)
                dataAccess.AddParam("@ss_FBPageId", SqlDbType.VarChar, Me.FBPageId)
                dataAccess.AddParam("@ss_AcessToken", SqlDbType.VarChar, Me.FBPageAccessToken)
                dataAccess.AddParam("@ss_Error", SqlDbType.VarChar, Me.ErrorDetails)
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

#Region "Delete Sweepstake"
        Public Function DeleteSweepstake()
            ' Try
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteSweepstake")
            dataAccess.AddParam("@ss_SweepstakeId", SqlDbType.Int, Me.SweepstakeId)
            dataAccess.ExecuteNonQuery()

            'Catch ex As Exception
            'Utility.LogError(ex, "", True)
            ' Throw
            'Finally
            'End Try
            'Return _intUserId
        End Function
#End Region
       
    End Class
End Namespace