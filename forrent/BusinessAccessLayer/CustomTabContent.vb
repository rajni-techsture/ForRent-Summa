Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Namespace BusinessLayer
    Public Class CustomTabContent
        Inherits IRecord

        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        Private _ID As Integer
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
        Public Property FBPageURL() As String
            Get
                Return _FBPageURL
            End Get
            Set(value As String)
                _FBPageURL = value
            End Set
        End Property
        Private _FBPageURL As String = String.Empty
        Public Property TSMAUserId() As String
            Get
                Return _TSMAUserId
            End Get
            Set(value As String)
                _TSMAUserId = value
            End Set
        End Property
        Private _TSMAUserId As String = String.Empty

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
        Public Property Phone() As String
            Get
                Return _Phone
            End Get
            Set(value As String)
                _Phone = value
            End Set
        End Property
        Private _Phone As String = String.Empty
        Public Property Message() As String
            Get
                Return _Message
            End Get
            Set(value As String)
                _Message = value
            End Set
        End Property
        Private _Message As String = String.Empty


        Public Sub AddEditCustomTab()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_InsertUpdateCustomTab")
                dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@FBPageName", SqlDbType.VarChar, ParamString(Me.FBPageName))
                dataAccess.AddParam("@FBPageURL", SqlDbType.VarChar, ParamString(Me.FBPageURL))
                dataAccess.AddParam("@Title", SqlDbType.VarChar, ParamString(Me.Title))
                dataAccess.AddParam("@Content", SqlDbType.VarChar, ParamString(Me.Content))
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Custom Tab", True)
                Throw
            Finally
            End Try
        End Sub

        Public Sub GetCustomTabContent()
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCustomTabContent")
            dataAccess.AddParam("@FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
            Dim ds As New DataSet
            ds = dataAccess.GetDataset()
            If ds.Tables(0).Rows.Count > 0 Then
                Me.Title = ds.Tables(0).Rows(0).Item("Title")
                Me.Content = ds.Tables(0).Rows(0).Item("Content")
                Me.FBUserId = ds.Tables(0).Rows(0).Item("FBUserId")
                Me.FBPageId = ds.Tables(0).Rows(0).Item("FBPageId")
                Me.FBPageName = ds.Tables(0).Rows(0).Item("FBPageName")
                Me.FBPageURL = ds.Tables(0).Rows(0).Item("FBPageURL")
            End If
        End Sub

        Public Sub AddCustomTabInfo()
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddCustomTabInfo")
                dataAccess.AddParam("@Name", SqlDbType.VarChar, ParamString(Me.Name))
                dataAccess.AddParam("@Email", SqlDbType.VarChar, ParamString(Me.Email))
                dataAccess.AddParam("@Phone", SqlDbType.VarChar, ParamString(Me.Phone))
                dataAccess.AddParam("@Message", SqlDbType.VarChar, ParamString(Me.Message))
                dataAccess.AddParam("@FBUserId", SqlDbType.VarChar, ParamString(Me.FBUserId))
                dataAccess.AddParam("@TSMAUserId", SqlDbType.VarChar, ParamString(Me.TSMAUserId))
                dataAccess.AddParam("@FBPageId", SqlDbType.VarChar, ParamString(Me.FBPageId))
                dataAccess.AddParam("@FBPageURL", SqlDbType.VarChar, ParamString(Me.FBPageURL))

                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Custom Tab Information", True)
                Throw
            Finally
            End Try
        End Sub

        Public Function GetCustomTabInfo() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                Dim ds As New DataSet
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetCustomTabInfo")


                ds = dataAccess.GetDataset()
                Return ds
            Catch ex As Exception
                Utility.LogError(ex, "Custom Tab Information", True)
                Throw
            Finally
            End Try
        End Function

        Public Function SetGCPost()
            Try
                Dim dataAccess As New DALDataAccess()

                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_SetGCPost")
                dataAccess.AddParam("@ID", SqlDbType.Int, ParamString(Me.ID))

                dataAccess.ExecuteNonQuery()

            Catch ex As Exception
                Utility.LogError(ex, "Custom Tab Information", True)
                Throw
            Finally
            End Try
        End Function

    End Class

End Namespace