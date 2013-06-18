Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data


Namespace BusinessLayer
    Public Class BALFanFridayFront
        Inherits IRecord

#Region "Variables"
        Private _strTitle As String = String.Empty
        Private _strDescription As String = String.Empty
        Private _strPhoto As String = String.Empty
        Private _strSethome As Integer = 0
        Private _strStatus As Integer = 0
        Private _intFFId As Integer = 0

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
        Public Property Photo() As String
            Get
                Return _strPhoto
            End Get
            Set(value As String)
                _strPhoto = value
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


        Public Property FFId() As Integer
            Get
                Return _intFFId
            End Get
            Set(value As Integer)
                _intFFId = value
            End Set
        End Property

#End Region

#Region "CONSTRUCTORS"
        Public Sub New()
        End Sub
#End Region

#Region "Get Fan Friday At Home Page Front"
        Public Function GetFanFridayFront() As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetFanFridayFront")


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region




#Region "Add Fan Friday"
        Public Function AddFanFriday() As Integer
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddFanFriday")
            dataAccess.AddParam("@ff_Title", SqlDbType.NVarChar, ParamString(Me.Title))
            dataAccess.AddParam("@ff_Description", SqlDbType.NVarChar, ParamString(Me.Description))
            dataAccess.AddParam("@ff_Photo", SqlDbType.NVarChar, ParamString(Me.Photo))
            dataAccess.AddParam("@ff_SetHome", SqlDbType.TinyInt, ParamString(Me.SetHome))
            dataAccess.AddParam("@ff_Status", SqlDbType.TinyInt, ParamString(Me.Status))


            dataAccess.GetDataset()

        End Function

#End Region


#Region "Get Fan Friday"
        Public Function GetFanFriday(ByVal FanFridayID As Integer) As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetFanFriday")
            dataAccess.AddParam("@ff_Id", SqlDbType.Int, FanFridayID)


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region


#Region "Bind Fan Friday"
        Public Function BindFanFriday() As DataSet

            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ViewFanFriday")


            ds = dataAccess.GetDataset()

            Return ds

        End Function

#End Region

#Region "Change Fan Friday Status"
        Public Function ChangeFanFridayStatus() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_ChangeFanFridayStatus")
                dataAccess.AddParam("@ff_Id", SqlDbType.Int, Me.FFId)
                dataAccess.AddParam("@ff_Status", SqlDbType.Int, Me.Status)
                dataAccess.ExecuteNonQuery()
            Catch ex As Exception
                Utility.LogError(ex, "Change Status", True)
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Set Fan Friday In Home"
        Public Function SetFanFridayInHome() As DataSet
            Try
                Dim dataAccess As New DALDataAccess()
                dataAccess.AddCommand(CommandType.StoredProcedure, "prc_SetFanFridayInHome")
                dataAccess.AddParam("@ff_Id", SqlDbType.Int, Me.FFId)
                dataAccess.AddParam("@ff_SetHome", SqlDbType.Int, Me.SetHome)
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
