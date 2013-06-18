Imports System.Runtime.Serialization
Public Class PostData
    Public Property data As m_data()
    Public Class m_data
        Public Property id As String
            Get
                Return m_id
            End Get
            Set(value As String)
                m_id = value
            End Set
        End Property
        Private m_id As String

        Public Property from As m_from
        Public Class m_from
            Public Property name As String
                Get
                    Return m_name
                End Get
                Set(value As String)
                    m_name = value
                End Set
            End Property
            Private m_name As String
        End Class

        Public Property message As String
            Get
                Return m_message
            End Get
            Set(value As String)
                m_message = value
            End Set
        End Property
        Private m_message As String

        Public Property application As m_application
        Public Class m_application
            Public Property name As String
                Get
                    Return m_name
                End Get
                Set(value As String)
                    m_name = value
                End Set
            End Property
            Private m_name As String

            Public Property [namespace] As String
                Get
                    Return m_namespace
                End Get
                Set(value As String)
                    m_namespace = value
                End Set
            End Property
            Private m_namespace As String

            Public Property id As String
                Get
                    Return m_id
                End Get
                Set(value As String)
                    m_id = value
                End Set
            End Property
            Private m_id As String
        End Class

        Public Property created_time As String
            Get
                Return m_created_time
            End Get
            Set(value As String)
                m_created_time = value
            End Set
        End Property
        Private m_created_time As String

        Public Property updated_time As String
            Get
                Return m_updated_time
            End Get
            Set(value As String)
                m_updated_time = value
            End Set
        End Property
        Private m_updated_time As String
    End Class
    Public Property [error]() As m_error
    Public Class m_error
        Public Property message() As Long
            Get
                Return m_message
            End Get
            Set(value As Long)
                m_message = value
            End Set
        End Property
        Private m_message As Long

        Public Property type() As String
            Get
                Return m_type
            End Get
            Set(value As String)
                m_type = value
            End Set
        End Property
        Private m_type As String

        Public Property code As String
            Get
                Return m_code
            End Get
            Set(value As String)
                m_code = value
            End Set
        End Property
        Private m_code As String
    End Class


End Class
