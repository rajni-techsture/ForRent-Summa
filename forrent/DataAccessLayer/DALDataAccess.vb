Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace DataAccessLayer
    Public Class DALDataAccess

#Region "Variable Declaration"
        Private _sqlCmd As New SqlCommand()
        Private _sqlParam As New SqlParameter()
#End Region

#Region "Properties"

        ''' <summary>
        ''' Gets and sets the <c>SqlCommand</c> column value
        ''' </summary>
        ''' <value>The <c>SqlCommand</c> column value</value>
        Public Property Command() As SqlCommand
            Get
                Return _sqlCmd
            End Get
            Set(value As SqlCommand)
                _sqlCmd = value
            End Set
        End Property

        ''' <summary>
        ''' Gets and sets the <c>SqlParameter</c> column value
        ''' </summary>
        ''' <value>The <c>SqlParameter</c> column value</value>
        Public Property Param() As SqlParameter
            Get
                Return _sqlParam
            End Get
            Set(value As SqlParameter)
                _sqlParam = value
            End Set
        End Property
#End Region

#Region "Constructor"
        Public Sub DALDataAccess()

        End Sub
#End Region

#Region "GetDataset"
        ''' <summary>
        ''' Gets the connection object
        ''' Create dataset and fills the dataset with data and returns the same.
        ''' </summary>
        ''' <returns>returns the Dataset object</returns>
        Public Function GetDataset() As DataSet
            Dim connection As SqlConnection
            connection = DirectCast(DALConnection.GetConnection(), SqlConnection)
            Dim dsDataSet As New DataSet()
            Try
                Dim daDataAdpt As SqlDataAdapter = Nothing
                _sqlCmd.Connection = connection
                _sqlCmd.CommandTimeout = "10000"
                daDataAdpt = New SqlDataAdapter(_sqlCmd)
                daDataAdpt.Fill(dsDataSet)

                If (connection IsNot Nothing) AndAlso (connection.State = ConnectionState.Open) Then
                    connection.Close()

                End If
            Catch ex As SqlException
                Throw
            Catch ex As Exception
                Throw
            Finally
                connection = Nothing
            End Try
            Return (dsDataSet)
        End Function
#End Region

#Region "ExecuteNonQuery"
        ''' <summary>
        ''' Gets the connection object
        ''' Execute the query and returns the number of rows affected.
        ''' </summary>
        ''' <returns>Number of rows affected</returns>
        Public Function ExecuteNonQuery() As Integer
            Dim intRetval As Integer = 0
            Dim connection As SqlConnection
            connection = DirectCast(DALConnection.GetConnection(), SqlConnection)
            Try
                _sqlCmd.Connection = connection
                _sqlCmd.CommandTimeout = "10000"
                _sqlCmd.ExecuteNonQuery()

                If (connection IsNot Nothing) AndAlso (connection.State = ConnectionState.Open) Then
                    connection.Close()
                End If
            Catch ex As SqlException
                Throw
            Catch ex As Exception
                Throw
            Finally
                connection = Nothing
            End Try
            Return ((intRetval))
        End Function
#End Region

#Region "ExecuteScalar"
        ''' <summary>
        ''' Gets the connection object
        ''' Execute the query and returns the number of rows affected.
        ''' </summary>
        ''' <returns>Number of rows affected</returns>
        Public Function ExecuteScalar() As String
            Dim strReturn As String = ""
            Dim connection As SqlConnection
            connection = DirectCast(DALConnection.GetConnection(), SqlConnection)
            Try
                _sqlCmd.Connection = connection
                _sqlCmd.CommandTimeout = "10000"
                strReturn = _sqlCmd.ExecuteScalar()

                If (connection IsNot Nothing) AndAlso (connection.State = ConnectionState.Open) Then
                    connection.Close()
                End If
            Catch ex As SqlException
                Throw
            Catch ex As Exception
                Throw
            Finally
                connection = Nothing
            End Try
            Return strReturn
        End Function
#End Region

#Region "GetDataTable"
        ''' <summary>
        ''' Gets the Connection object
        ''' Create and fill the dataset.
        ''' Gets the datatable from the dataset and returns it.
        ''' </summary>
        ''' <returns>Returns Datatable object</returns>
        Public Function GetDataTable() As DataTable
            Dim connection As SqlConnection
            connection = DirectCast(DALConnection.GetConnection(), SqlConnection)
            Dim dsDataSet As New DataSet()
            Dim dataTable As New DataTable()
            Try
                Dim daDataAdpt As SqlDataAdapter = Nothing
                _sqlCmd.Connection = connection
                _sqlCmd.CommandTimeout = "10000"
                daDataAdpt = New SqlDataAdapter(_sqlCmd)
                daDataAdpt.Fill(dsDataSet)
                dataTable = dsDataSet.Tables(0)

                If (connection IsNot Nothing) AndAlso (connection.State = ConnectionState.Open) Then
                    connection.Close()

                End If
            Catch ex As SqlException
                Throw
            Catch ex As Exception
                Throw
            Finally
                connection = Nothing
            End Try
            Return dataTable
        End Function
#End Region

#Region "Dispose"
        ''' <summary>
        ''' Set command object and parameter objects to null
        ''' </summary>
        Public Sub dispose()
            If _sqlCmd IsNot Nothing Then
                _sqlCmd = Nothing
            End If
            If _sqlParam IsNot Nothing Then
                _sqlParam = Nothing
            End If

        End Sub

#End Region

#Region "AddCommand"
        ''' <summary>
        ''' Assign the command type and command text to the command object.
        ''' </summary>
        ''' <param name="commandType">Command Type object</param>
        ''' <param name="commandText">Command Text</param>
        Public Sub AddCommand(commandType As CommandType, commandText As String)
            Me._sqlCmd.CommandType = commandType
            Me._sqlCmd.CommandText = commandText
        End Sub
#End Region

#Region "AddParam with direction"
        ''' <summary>
        ''' Assign the sql parameter value and direction.
        ''' </summary>
        ''' <param name="paramName">Parameter Name</param>
        ''' <param name="paramType">SQL Parameter Type</param>
        ''' <param name="paramValue">Parameter Value</param>
        ''' <param name="paramDirection">Parameter Direction</param>
        Public Sub AddParam(paramName As String, paramType As SqlDbType, paramValue As Object, paramDirection As ParameterDirection)
            Me._sqlParam = Me._sqlCmd.Parameters.Add(paramName, paramType)
            Me._sqlParam.Value = paramValue
            Me._sqlParam.Direction = paramDirection
        End Sub
#End Region

#Region "AddParam"
        ''' <summary>
        ''' Assigns the Parameter name, value and direction.
        ''' </summary>
        ''' <param name="paramName">Parameter Name</param>
        ''' <param name="paramType">SQL Parameter Type</param>
        ''' <param name="paramValue">Parameter Value</param>
        Public Sub AddParam(paramName As String, paramType As SqlDbType, paramValue As Object)
            Me._sqlParam = Me._sqlCmd.Parameters.Add(paramName, paramType)
            Me._sqlParam.Value = paramValue
            Me._sqlParam.Direction = ParameterDirection.Input
        End Sub
#End Region



    End Class
End Namespace
