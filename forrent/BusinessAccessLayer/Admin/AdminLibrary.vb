Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data

Namespace BusinessLayer

    Public Class BALAdminLibrary
        Inherits IRecord

#Region "Variables"
        Private _strLibraryID As Integer = 0
        Private _strLibraryCategoryID As Integer = 0
        Private _strCategoryName As String = String.Empty
        Private _strIsRequired As Integer = 1
        Private _strPassword As String = String.Empty
        Private _strCompanyIcon As String = String.Empty
        Private _strCompanyStyle As String = String.Empty
        Private _intCompanyId As Integer = 0
        Private _intIndustryId As Integer = 0
        Private _strStatus As Integer = 0




        Private _intUserId As Integer = 0
        Private _intUserId1 As Integer = 0
        Private _isError As Boolean = False
        Private strMessage As String

        Private _strCategoryID As Integer = 0
        Private _strTemplate As String = String.Empty
        Private _strImage As String = String.Empty
        Private _strVideo As String = String.Empty
        Private _strVideoId As String = String.Empty
        Private _strVideoImage As String = String.Empty


        Private _strCheckedMenu As String = String.Empty
#End Region

#Region "Properties"
        ''' <summary>
        ''' Gets and sets the <c>Username</c> Password
        ''' </summary>
        ''' <value>The <c>Username</c> Password</value>
        ''' 
        Public Property Template() As String
            Get
                Return _strTemplate
            End Get
            Set(value As String)
                _strTemplate = value
            End Set
        End Property
        Public Property Image() As String
            Get
                Return _strImage
            End Get
            Set(value As String)
                _strImage = value
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
        Public Property VideoId() As String
            Get
                Return _strVideoId
            End Get
            Set(value As String)
                _strVideoId = value
            End Set
        End Property
        Public Property VideoImage() As String
            Get
                Return _strVideoImage
            End Get
            Set(value As String)
                _strVideoImage = value
            End Set
        End Property

        Public Property LibraryID() As Integer
            Get
                Return _strLibraryID
            End Get
            Set(value As Integer)
                _strLibraryID = value
            End Set
        End Property


        Public Property LibraryCategoryID() As Integer
            Get
                Return _strLibraryCategoryID
            End Get
            Set(value As Integer)
                _strLibraryCategoryID = value
            End Set
        End Property

        Public Property CategoryID() As Integer
            Get
                Return _strCategoryID
            End Get
            Set(value As Integer)
                _strCategoryID = value
            End Set
        End Property
        Public Property CategoryName() As String
            Get
                Return _strCategoryName
            End Get
            Set(value As String)
                _strCategoryName = value
            End Set
        End Property
        Public Property Password() As String
            Get
                Return _strPassword
            End Get
            Set(value As String)
                _strPassword = value
            End Set
        End Property
        Public Property IsRequired() As Integer
            Get
                Return _strIsRequired
            End Get
            Set(value As Integer)
                _strIsRequired = value
            End Set
        End Property

        Public Property CompanyIcon() As String
            Get
                Return _strCompanyIcon
            End Get
            Set(value As String)
                _strCompanyIcon = value
            End Set
        End Property
        Public Property CompanyStyle() As String
            Get
                Return _strCompanyStyle
            End Get
            Set(value As String)
                _strCompanyStyle = value
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

        Public Property CompanyId() As Integer
            Get
                Return _intCompanyId
            End Get
            Set(value As Integer)
                _intCompanyId = value
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

#Region "Bind Category By CID"
        Public Function BindCategoriesByCompanyID() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_BindCategoriesByCompanyID")
            dataAccess.AddParam("@lc_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))

            ds = dataAccess.GetDataset()
            Return ds

        End Function

#End Region
#Region "Bind Category By IID"
        Public Function BindCategoriesByIndustryID() As DataSet
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_BindCategoriesByIndustryID")
            dataAccess.AddParam("@lc_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))

            ds = dataAccess.GetDataset()
            Return ds

        End Function

#End Region

#Region "Add Library Category"
        Public Function AddLibraryCategory() As Integer
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddLibraryCategory")
            dataAccess.AddParam("@lc_Title", SqlDbType.NVarChar, ParamString(Me.CategoryName))
            dataAccess.AddParam("@lc_UserId", SqlDbType.Int, -1)
            dataAccess.AddParam("@lc_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
            dataAccess.AddParam("@lc_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
            dataAccess.AddParam("@lc_Status", SqlDbType.Int, ParamString(Me.Status))

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

#Region "Add Library Data"
        Public Function AddLibraryData() As Integer
            ' Try

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet

            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddLibraryData")
            dataAccess.AddParam("@lib_Category", SqlDbType.Int, ParamString(Me.CategoryID))
            dataAccess.AddParam("@lib_UserId", SqlDbType.Int, -1)
            dataAccess.AddParam("@lib_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
            dataAccess.AddParam("@lib_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
            dataAccess.AddParam("@lib_FBUserId", SqlDbType.NVarChar, "")
            dataAccess.AddParam("@lib_Template", SqlDbType.NVarChar, ParamString(Me.Template))
            dataAccess.AddParam("@lib_Image", SqlDbType.NVarChar, ParamString(Me.Image))
            'dataAccess.AddParam("@lib_ImageName", SqlDbType.NVarChar, ParamString(Me.Image))
            dataAccess.AddParam("@lib_Video", SqlDbType.NVarChar, ParamString(Me.Video))
            dataAccess.AddParam("@lib_VideoId", SqlDbType.NVarChar, ParamString(Me.VideoId))
            dataAccess.AddParam("@lib_VideoImage", SqlDbType.NVarChar, ParamString(Me.VideoImage))
            dataAccess.AddParam("@lib_Status", SqlDbType.Int, ParamString(Me.Status))

            dataAccess.GetDataset()
            'Dim res As Integer = ds.Tables(0).Rows(0).Item(0)
            'Return res
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

#Region "Update Library Category"
        Public Function UpdateLibraryCategory(ByVal CatID As Integer) As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateLibraryCategory")
            dataAccess.AddParam("@lc_Id", SqlDbType.Int, CatID)
            dataAccess.AddParam("@lc_Title", SqlDbType.NVarChar, ParamString(Me.CategoryName))
            dataAccess.AddParam("@lc_UserId", SqlDbType.Int, -1)
            dataAccess.AddParam("@lc_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
            dataAccess.AddParam("@lc_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
            dataAccess.AddParam("@lc_Status", SqlDbType.Int, ParamString(Me.Status))

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

#Region "Update Library Data"
        Public Function UpdateLibraryData(ByVal LibID As Integer) As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateLibraryData")
            dataAccess.AddParam("@lib_Id", SqlDbType.Int, LibID)
            dataAccess.AddParam("@lib_Category", SqlDbType.Int, ParamString(Me.CategoryID))
            dataAccess.AddParam("@lib_UserId", SqlDbType.Int, -1)
            dataAccess.AddParam("@lib_CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
            dataAccess.AddParam("@lib_IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
            dataAccess.AddParam("@lib_FBUserId", SqlDbType.NVarChar, "")
            dataAccess.AddParam("@lib_Template", SqlDbType.NVarChar, ParamString(Me.Template))
            dataAccess.AddParam("@lib_Image", SqlDbType.NVarChar, ParamString(Me.Image))
            dataAccess.AddParam("@lib_Video", SqlDbType.NVarChar, ParamString(Me.Video))
            dataAccess.AddParam("@lib_VideoId", SqlDbType.NVarChar, ParamString(Me.VideoId))
            dataAccess.AddParam("@lib_VideoImage", SqlDbType.NVarChar, ParamString(Me.VideoImage))
            dataAccess.AddParam("@lib_Status", SqlDbType.Int, ParamString(Me.Status))

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

#Region "Get Library Categories"
        Public Function GetLibraryCategories(ByVal CatID As Integer) As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_LibraryCategoriesByID")
            dataAccess.AddParam("@lc_Id", SqlDbType.Int, CatID)


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region
#Region "Get Library Data By ID"
        Public Function GetLibraryDataByID(ByVal CatID As Integer) As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetLibraryData")
            dataAccess.AddParam("@lib_Id", SqlDbType.Int, CatID)


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "View Library Categories"
        Public Function ViewLibraryCategories() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ViewLibraryCategories")


                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "View Library Categories", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region


#Region "Bind Library Data"
        Public Function BindLibraryData() As DataSet

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_BindLibraryData")


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Change Library Data Status"
        Public Function ChangeLibraryDataStatus() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ChangeLibraryDataStatus")
                dataAccess.AddParam("@LibraryID", SqlDbType.Int, Me.LibraryID)
                dataAccess.AddParam("@Status", SqlDbType.Int, Me.Status)
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Change Status", True)
                Throw
            Finally
            End Try
        End Function
#End Region


#Region "Bind Companies"
        Public Function BindCompanies() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_BindCompanies")


                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Bind Companies", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region

#Region "Bind Industries"
        Public Function BindIndustries() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_BindIndustries")


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

#Region "Change Library Category Status"
        Public Function ChangeLibraryCategoryStatus() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ChangeLibraryCategoryStatus")
                dataAccess.AddParam("@LibraryCategoryID", SqlDbType.Int, Me.LibraryCategoryID)
                dataAccess.AddParam("@Status", SqlDbType.Int, Me.Status)
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Change Library Category Status", True)
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
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ListAllMenusForCompany")
                dataAccess.AddParam("@CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))

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
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_UpdateAssignMenuRightsCompany")
                dataAccess.AddParam("@CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
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

#Region "Get Menu Rights of Company"
        Public Function GetMenuRights() As DataSet
            Try
                'Dim objEncDec As New Utility
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetMenuRightsofCompany")
                dataAccess.AddParam("@companyId", SqlDbType.Int, ParamString(Me.CompanyId))

                ds = dataAccess.GetDataset()

                Return ds

            Catch ex As Exception
                Utility.LogError(ex, "Get Menu Rights of Company", True)
                Throw
            Finally
            End Try
            'Return _intUserId
        End Function

#End Region
    End Class
End Namespace