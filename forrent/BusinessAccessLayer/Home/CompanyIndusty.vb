Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data

Namespace BusinessLayer
    <RecordAttribute("tbl_Industries,tbl_Companies", "prc_GetAllIndustry,prc_GetAllCompany,prc_GetCompanyIndustryName", New [String](0) {"Home Login"})>
    Public Class BALCompanyIndusty
        Inherits IRecord

#Region "Variables"
        Private _PasswordValue As String = String.Empty
        Private _CompanyValue As String = String.Empty
        Private _isError As Boolean = False
        Private _FBUserId As String = String.Empty
        Private _strMessage As String = String.Empty
#End Region

#Region "Properties"
        ''' <summary>
        ''' Gets and sets the <c>Username</c> Password
        ''' </summary>
        ''' <value>The <c>Username</c> Password</value>

        Public Property FBUserId() As String
            Get
                Return _FBUserId
            End Get
            Set(ByVal value As String)
                _FBUserId = value
            End Set
        End Property
        Public Property Password() As String
            Get
                Return _PasswordValue
            End Get
            Set(ByVal value As String)
                _PasswordValue = value
            End Set
        End Property
        Public Property CompanyId() As String
            Get
                Return _CompanyValue
            End Get
            Set(ByVal value As String)
                _CompanyValue = value
            End Set
        End Property

        ReadOnly Property isError() As Boolean
            Get
                Return _isError
            End Get
        End Property


        ReadOnly Property Message() As String
            Get
                Return _strMessage
            End Get
        End Property

#End Region

#Region "CONSTRUCTORS"
        Public Sub New()
        End Sub
#End Region


#Region "Get Company/Industry Details"
        Public Function GetCompnayDetails() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAllCompanyIndutry")
                'dataAccess.AddParam(Nothing)
                'dataAccess.AddParam()
                ds = dataAccess.GetDataset()
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds
                End If
                'ds = Nothing
            Catch ex As Exception
                Utility.LogError(ex, "Compnay Details", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region

#Region "Get Company User Details"
        Public Function GetCompnayUserDetails()
            Try
                Dim dataAccess As New DALDataAccess()
                'Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAddEditCompanyUser")
                dataAccess.AddParam("@FBUserId", SqlDbType.NVarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@CompanyId", SqlDbType.Int, ParamInt(Me.CompanyId))
                dataAccess.ExecuteNonQuery()
                'dataAccess.AddParam()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
                'ds = Nothing
            Catch ex As Exception
                Utility.LogError(ex, "Compnay User Details", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region

#Region "Get Industry User Details"
        Public Function GetIndustryUserDetails()
            Try
                Dim dataAccess As New DALDataAccess()
                'Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAddEditIndustryUser")
                dataAccess.AddParam("@FBUserId", SqlDbType.NVarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@IndustryId", SqlDbType.Int, ParamInt(Me.CompanyId))
                dataAccess.ExecuteNonQuery()
                'dataAccess.AddParam()
                'ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Return ds
                'End If
            Catch ex As Exception
                Utility.LogError(ex, "Industry User Details", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region

#Region "Get CompnaIndustry User Details"
        Public Function GetCompnayIndustryName() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCompanyIndustryName")
                dataAccess.AddParam("@FBUserID", SqlDbType.NVarChar, ParamString(Me.FBUserId))
                'dataAccess.AddParam()
                ds = dataAccess.GetDataset()
                'If ds.Tables(0).Rows.Count > 0 Then
                Return ds
                'End If
                'ds = Nothing
            Catch ex As Exception
                Utility.LogError(ex, "Industry User Details", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function
#End Region

#Region "Compnay Password Validation"
        Public Function PasswordValidation() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_CompanyPassValidation")
                dataAccess.AddParam("@Password", SqlDbType.NVarChar, ParamString(Me.Password))
                dataAccess.AddParam("@CompnayId", SqlDbType.Int, ParamString(Me.CompanyId))
                ds = dataAccess.GetDataset()
                If ds.Tables(0).Rows.Count > 0 Then
                    'If ds.Tables(0).Rows(0).Item("aus_UserName") = _strUserName And ds.Tables(0).Rows(0).Item("aus_Password") = _strPassword Then
                    '    _intUserId = ds.Tables(0).Rows(0).Item("aus_id")
                    'End If
                    Return ds
                End If
                'ds = Nothing
            Catch ex As Exception
                Utility.LogError(ex, "Company Password Validation", True)
                Throw
            Finally
            End Try
        End Function
#End Region

        
    End Class

End Namespace







