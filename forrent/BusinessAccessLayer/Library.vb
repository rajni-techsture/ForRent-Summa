Imports DataAccessLayer.DataAccessLayer
Namespace BusinessLayer
    Public Class Library
        Inherits IRecord
        Public Property LibraryId() As Integer
            Get
                Return _LibraryId
            End Get
            Set(value As Integer)
                _LibraryId = value
            End Set
        End Property
        Private _LibraryId As Integer = 0
        Public Property LibraryCatId() As Integer
            Get
                Return _LibraryCatId
            End Get
            Set(value As Integer)
                _LibraryCatId = value
            End Set
        End Property
        Private _LibraryCatId As Integer = 0
        Public Property UserId() As Integer
            Get
                Return _UserId
            End Get
            Set(value As Integer)
                _UserId = value
            End Set
        End Property
        Private _UserId As Integer = 0

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
        Private _IndustryId As Integer = 1

        Public Property LibraryCategory() As Integer
            Get
                Return _LibraryCategory
            End Get
            Set(value As Integer)
                _LibraryCategory = value
            End Set
        End Property
        Private _LibraryCategory As Integer = 0


        Public Property FBUserId() As String
            Get
                Return _FBUserId
            End Get
            Set(value As String)
                _FBUserId = value
            End Set
        End Property
        Private _FBUserId As String = String.Empty

        Public Property LibCatTitle() As String
            Get
                Return _LibCatTitle
            End Get
            Set(value As String)
                _LibCatTitle = value
            End Set
        End Property
        Private _LibCatTitle As String = String.Empty

        Public Property LibImage() As String
            Get
                Return _LibImage
            End Get
            Set(value As String)
                _LibImage = value
            End Set
        End Property
        Private _LibImage As String = String.Empty

        Public Property LibVideoImage() As String
            Get
                Return _LibVideoImage
            End Get
            Set(value As String)
                _LibVideoImage = value
            End Set
        End Property
        Private _LibVideoImage As String = String.Empty

        Public Property LibVideoId() As String
            Get
                Return _LibVideoId
            End Get
            Set(value As String)
                _LibVideoId = value
            End Set
        End Property
        Private _LibVideoId As String = String.Empty

        Public Property LibVideo() As String
            Get
                Return _LibVideo
            End Get
            Set(value As String)
                _LibVideo = value
            End Set
        End Property
        Private _LibVideo As String = String.Empty

        Public Property Library() As String
            Get
                Return _Library
            End Get
            Set(value As String)
                _Library = value
            End Set
        End Property
        Private _Library As String = String.Empty

        Public Function GetUSerSelectionType() As String
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetUserSelectionType")
            dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
            Dim ds As New DataSet
            ds = dataAccess.GetDataset()
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item("Selection")
            Else
                Return ""
            End If
        End Function

        Public Function GetLibraryCategories() As DataSet
            Dim dataAccess As New DALDataAccess()
            ''''' Get Library Category Without Company or Industry ID
            'dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetLibraryCategories")
            'dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            'dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
            ''''' end
            ''''' Get Library Category With Company or Industry ID
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetLibraryCategoriesByCompanyOrIndustryId")
            dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
            dataAccess.AddParam("@CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
            dataAccess.AddParam("@IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
            ''''' end
            Dim ds As New DataSet
            ds = dataAccess.GetDataset()
            Return ds
        End Function

        Public Function GetLIbraries() As DataSet
            Dim dataAccess As New DALDataAccess()
            ''''   Get Library Without Company or Industry ID
            'dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetLibraryByCategory")
            'dataAccess.AddParam("@Category", SqlDbType.Int, Me.LibraryCategory)
            'dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            'dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
            '''' End
            ''''' Get Library With Company or Industry Id
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAdminorUserLibraryDataByCompanyOrIndustryId")
            dataAccess.AddParam("@Category", SqlDbType.Int, Me.LibraryCategory)
            dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
            dataAccess.AddParam("@CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
            dataAccess.AddParam("@IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
            ''''' End
            Dim ds As New DataSet
            ds = dataAccess.GetDataset()
            Return ds
        End Function

        Function SaveToMyLibrary() As Integer
            Dim dataAccess As New DALDataAccess()
            ''''' Without Company or Industry Id
            'dataAccess.AddCommand(CommandType.StoredProcedure, "prc_SaveToMyLibrary")
            'dataAccess.AddParam("@Category", SqlDbType.Int, Me.LibraryCategory)
            'dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            'dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
            'dataAccess.AddParam("@Title", SqlDbType.VarChar, ParamString(Me.LibCatTitle))
            'dataAccess.AddParam("@Template", SqlDbType.VarChar, ParamString(Me.Library))
            ''''' End
            '''''' With  Company or Industry Id
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_SaveToMyLibraryByCompanyOrIndustryId")
            dataAccess.AddParam("@Category", SqlDbType.Int, Me.LibraryCategory)
            dataAccess.AddParam("@UserId", SqlDbType.Int, Me.UserId)
            dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
            dataAccess.AddParam("@Title", SqlDbType.VarChar, ParamString(Me.LibCatTitle))
            dataAccess.AddParam("@Template", SqlDbType.VarChar, ParamString(Me.Library))
            dataAccess.AddParam("@lib_Image", SqlDbType.VarChar, ParamString(Me.LibImage))
            dataAccess.AddParam("@lib_Video", SqlDbType.VarChar, ParamString(Me.LibVideo))
            dataAccess.AddParam("@lib_VideoId", SqlDbType.VarChar, ParamString(Me.LibVideoId))
            dataAccess.AddParam("@lib_VideoImage", SqlDbType.VarChar, ParamString(Me.LibVideoImage))
            dataAccess.AddParam("@CompanyId", SqlDbType.Int, ParamString(Me.CompanyId))
            dataAccess.AddParam("@IndustryId", SqlDbType.Int, ParamString(Me.IndustryId))
            ''''' End
            Dim ds As New DataSet
            ds = dataAccess.GetDataset()
            If ds.Tables(0).Rows.Count > 0 Then
                Me.LibraryCategory = ds.Tables(0).Rows(0).Item("Cat")
            Else
                Me.LibraryCategory = 1

            End If
            Return ds.Tables(0).Rows(0).Item("Cat")
        End Function

        Sub DeleteMyLibrary()
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteMyLibrary")
            dataAccess.AddParam("@LibraryId", SqlDbType.Int, Me.LibraryId)
            dataAccess.ExecuteNonQuery()
        End Sub

        Sub DeleteMyLibraryCategory()
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_DeleteMyLibraryCategory")
            dataAccess.AddParam("@LibraryCatId", SqlDbType.Int, Me.LibraryCatId)
            dataAccess.ExecuteNonQuery()
        End Sub
    End Class
End Namespace

