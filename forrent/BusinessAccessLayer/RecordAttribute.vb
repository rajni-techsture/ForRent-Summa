Imports System
Imports System.Collections

Namespace BusinessLayer
    ''' <summary>
    ''' Summary description for RecordAttribute.
    ''' </summary>
    <AttributeUsage(AttributeTargets.[Class])> _
    Public Class RecordAttribute
        Inherits Attribute
        Private _tableName As String = String.Empty
        Private _storedProcLoad As String = String.Empty
        Private _storedProcDelete As String = String.Empty
        Private _pKeys As New ArrayList()

        Public Sub New(tableName As String, storedProcLoad As String, keys As String())
            Me._tableName = tableName
            Me._storedProcLoad = storedProcLoad
            For Each str As String In keys
                _pKeys.Add(str)
            Next
        End Sub

        Public Sub New(tableName As String, storedProcLoad As String)
            Me._tableName = tableName
            Me._storedProcLoad = storedProcLoad
        End Sub

        Public Sub New(tableName As String, storedProcLoad As String, storedProcDelete As String, keys As String())
            Me._tableName = tableName
            Me._storedProcLoad = storedProcLoad
            Me._storedProcDelete = storedProcDelete
            For Each str As String In keys
                _pKeys.Add(str)
            Next
        End Sub
        Public ReadOnly Property TableName() As String
            Get
                Return Me._tableName
            End Get
        End Property
        Public ReadOnly Property StoredProcLoad() As String
            Get
                Return Me._storedProcLoad
            End Get
        End Property
        Public ReadOnly Property StoredProcDelete() As String
            Get
                Return Me._storedProcDelete
            End Get
        End Property
        Public ReadOnly Property PrimaryKeys() As ArrayList
            Get
                Return Me._pKeys
            End Get
        End Property
    End Class
End Namespace
