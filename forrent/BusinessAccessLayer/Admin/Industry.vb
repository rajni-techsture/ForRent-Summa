Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Namespace BusinessLayer

    Public Class BALIndustry
        Inherits IRecord

#Region "Variables"
        Private _strIndustryName As String = String.Empty
        Private _strIndustryIcon As String = String.Empty
        Private _strIndustryStyle As String = String.Empty
        Private _intIndustryId As Integer = 0
        Private _strStatus As Integer = 0



        Private _intUserId As Integer = 0
        Private _intUserId1 As Integer = 0
        Private _isError As Boolean = False
        Private strMessage As String

        Private _strCheckedMenu As String = String.Empty
#End Region

#Region "Properties"
        ''' <summary>
        ''' Gets and sets the <c>Username</c> Password
        ''' </summary>
        ''' <value>The <c>Username</c> Password</value>

        Public Property IndustryName() As String
            Get
                Return _strIndustryName
            End Get
            Set(value As String)
                _strIndustryName = value
            End Set
        End Property


        Public Property IndustryIcon() As String
            Get
                Return _strIndustryIcon
            End Get
            Set(value As String)
                _strIndustryIcon = value
            End Set
        End Property
        Public Property IndustryStyle() As String
            Get
                Return _strIndustryStyle
            End Get
            Set(value As String)
                _strIndustryStyle = value
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

        Public Property IndustryId() As Integer
            Get
                Return _intIndustryId
            End Get
            Set(value As Integer)
                _intIndustryId = value
            End Set
        End Property

        Public Property UserId() As Integer
            Get
                Return _intUserId
            End Get
            Set(value As Integer)
                _intUserId = value
            End Set
        End Property

        Public ReadOnly Property intUserId() As Integer
            Get
                Return _intUserId1
            End Get
        End Property

        Public Property CheckedMenu() As String
            Get
                Return _strCheckedMenu
            End Get
            Set(value As String)
                _strCheckedMenu = value
            End Set
        End Property
        'Public Property isError() As Boolean
        '    Get
        '        Return _isError
        '    End Get
        'End Property


        'Public Property Message() As String
        '    Get
        '        Return strMessage
        '    End Get
        'End Property
#End Region

#Region "CONSTRUCTORS"
        Public Sub New()
        End Sub
#End Region



#Region "Add Industry"
        Public Function AddIndustry() As Integer
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddIndustry")
            dataAccess.AddParam("@i_Name", SqlDbType.NVarChar, ParamString(Me.IndustryName))
            dataAccess.AddParam("@i_Icon", SqlDbType.NVarChar, ParamString(Me.IndustryIcon))
            dataAccess.AddParam("@i_Style", SqlDbType.NVarChar, ParamString(Me.IndustryStyle))
            dataAccess.AddParam("@i_Status", SqlDbType.Int, ParamString(Me.Status))

            ds = dataAccess.GetDataset()
            Dim res As Integer = ds.Tables(0).Rows(0).Item(0)
            Return res
            '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
            '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
            '    'End If
            'End If
            'ds = Nothing
            'Catch ex As Exception
            '    Utility.LogError(ex, "Add Admin", True)
            '    Throw
            'Finally
            'End Try
            'Return _intUserId
        End Function

#End Region

#Region "Update Industry"
        Public Function UpdateIndustry(ByVal IndustryID As Integer) As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateIndustry")
            dataAccess.AddParam("@i_Id", SqlDbType.Int, IndustryID)
            dataAccess.AddParam("@i_Name", SqlDbType.NVarChar, ParamString(Me.IndustryName))
            dataAccess.AddParam("@i_Icon", SqlDbType.NVarChar, ParamString(Me.IndustryIcon))
            dataAccess.AddParam("@i_Style", SqlDbType.NVarChar, ParamString(Me.IndustryStyle))
            dataAccess.AddParam("@i_Status", SqlDbType.Int, ParamString(Me.Status))

            ds = dataAccess.GetDataset()
            Dim res As Integer = ds.Tables(0).Rows(0).Item(0)
            Return res
            '    'If ds.Tables(0).Rows(0).Item("u_Username") = _strUserName And ds.Tables(0).Rows(0).Item("u_Password") = _strPassword Then
            '    '    _intUserId = ds.Tables(0).Rows(0).Item("u_Id")
            '    'End If
            'End If
            'ds = Nothing
            'Catch ex As Exception
            '    Utility.LogError(ex, "Add Admin", True)
            '    Throw
            'Finally
            'End Try
            'Return _intUserId
        End Function

#End Region

#Region "Get Site Industry"
        Public Function GetIndustry(ByVal IndustryID As Integer) As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetIndustry")
            dataAccess.AddParam("@i_Id", SqlDbType.Int, IndustryID)


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Bind Industries"
        Public Function BindIndustries() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ViewIndustries")


                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Bind Industries", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Change Industry Status"
        Public Function ChangeIndustryStatus() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ChangeIndustryStatus")
                dataAccess.AddParam("@IndustryId", SqlDbType.Int, Me.IndustryId)
                dataAccess.AddParam("@Status", SqlDbType.Int, Me.Status)
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Change Industry Status", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "List Menus"
        Public Function ListMenus() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ListAllMenusForIndustry")
                dataAccess.AddParam("@IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))

                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "List Menus", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Update Assign Menu Rights"
        Public Function UpdateAssignMenuRights() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateAssignMenuRightsIndustry")
                dataAccess.AddParam("@IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
                dataAccess.AddParam("@CheckedMenus", SqlDbType.VarChar, ParamString(Me.CheckedMenu))
                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Update", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Get Menu Rights of Industry"
        Public Function GetMenuRights() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetMenuRightsofIndustry")
                dataAccess.AddParam("@industryId", SqlDbType.Int, ParamString(Me.IndustryId))

                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Get Menu Rights of Industry", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region
    End Class
End Namespace