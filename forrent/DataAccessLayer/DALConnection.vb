Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Xml
Imports System.Threading

Namespace DataAccessLayer
    Public Class DALConnection

#Region "Variables"
        Private Shared _mutex As New Mutex()
        Private Shared _connString As String = String.Empty
#End Region

#Region "GetConnection"
        ''' <summary>
        ''' Creates the SqlConnection object and returns the same.
        ''' </summary>
        ''' <returns>SqlConnection object.</returns>
        Public Shared Function GetConnection() As SqlConnection
            Dim connection As SqlConnection
            Try
                _mutex.WaitOne()
                If _connString = String.Empty Then
                    ReadConfig()
                End If
                connection = New SqlConnection()
                connection.ConnectionString = _connString
                connection.Open()
            Catch ex As SqlException
                'DALUtility.LogError(ex, "DataAccessLibrary-DALConnection-GetConnection()", True)
                Throw
            Catch ex As Exception
                'DALUtility.LogError(ex, "DataAccessLibrary-DALConnection-GetConnection()", True)
                Throw
            Finally
                _mutex.ReleaseMutex()
            End Try
            Return connection
        End Function
#End Region

#Region "Read Configuration file."
        ''' <summary>
        ''' Load the XML document.
        ''' Biulds the connection string.
        ''' </summary>
        Private Shared Sub ReadConfig()
            'Read from Config
            _connString = "Server=ace;Database=tsmaDB2;UID=sa;PWD=rx6fb;"
            '_connString = "Server=techsturedevelopment.com;Database=tsmaDB;UID=tsma_app_user;PWD=t5m@pr0d!;"
            '_connString = "Server=107.20.109.6;Database=tsmaDB;UID=tsma_app_user;PWD=t5m@pr0d!;"
            '_connString = "Server=107.20.109.6;Database=tsmatrainingDB;UID=tsma_app_user;PWD=t5m@pr0d!;"
            '_connString = "Server=techsturedevelopment.com;Database=tsmaDB2;UID=tsma_app_user;PWD=t5m@pr0d!;"
        End Sub

#End Region

      

    End Class
End Namespace