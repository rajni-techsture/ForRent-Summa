Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Namespace BusinessLayer
    Public Class BALServiceTest
        Private _strName As String

        Private _strDate As DateTime

        Public Property TestName() As String
            Get
                Return _strName
            End Get
            Set(ByVal value As String)
                _strName = value
            End Set
        End Property

        Public Property ScheduleDate() As DateTime
            Get
                Return _strDate
            End Get
            Set(ByVal value As DateTime)
                _strDate = value
            End Set
        End Property

#Region "Insert Records"
        Public Function InsertRecords()
            ' Try
            Dim dataAccess As New DALDataAccess()
            'Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_InsertRecords")
            dataAccess.AddParam("@Name", SqlDbType.VarChar, (Me.TestName))
            dataAccess.AddParam("@ScheduleDate", SqlDbType.DateTime, Me.ScheduleDate)

            dataAccess.ExecuteNonQuery()
            'ds = dataAccess.GetDataset()
            'If ds.Tables(0).Rows.Count > 0 Then
            '    Return ds
            'End If

            ' Catch ex As Exception
            ' Utility.LogError(ex, "Insert Test", True)
            ' Throw
            ' Finally
            ' End Try
        End Function
#End Region
    End Class
End Namespace
