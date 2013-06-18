Imports System.Runtime.Serialization
Public Class FacebookUser
    Public Property id() As Long
        Get
            Return m_id
        End Get
        Set(value As Long)
            m_id = value
        End Set
    End Property
    Private m_id As Long

    Public Property first_name() As String
        Get
            Return m_first_name
        End Get
        Set(value As String)
            m_first_name = value
        End Set
    End Property
    Private m_first_name As String

    Public Property username() As String
        Get
            Return m_username
        End Get
        Set(value As String)
            m_username = value
        End Set
    End Property
    Private m_username As String

    Public Property link() As String
        Get
            Return m_link
        End Get
        Set(value As String)
            m_Link = value
        End Set
    End Property
    Private m_link As String
    Public Property last_name() As String
        Get
            Return m_last_name
        End Get
        Set(value As String)
            m_last_name = value
        End Set
    End Property
    Private m_last_name As String

    Public Property name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property
    Private m_name As String

    Public Property email() As String
        Get
            Return m_email
        End Get
        Set(value As String)
            m_email = value
        End Set
    End Property
    Private m_email As String

    Public Property location() As m_Location
    Public Class m_Location
        Public Property id() As Long
            Get
                Return m_id
            End Get
            Set(value As Long)
                m_id = value
            End Set
        End Property
        Private m_id As Long

        Public Property name() As String
            Get
                Return m_name
            End Get
            Set(value As String)
                m_name = value
            End Set
        End Property
        Private m_name As String

        Public Property picture As String
            Get
                Return m_picture
            End Get
            Set(value As String)
                m_picture = value
            End Set
        End Property
        Private m_picture As String

    End Class
    Public Property picture() As m_picture
    Public Class m_picture
        Public Property data() As m_data1
        Public Class m_data1
            Public Property url As String
                Get
                    Return m_url
                End Get
                Set(value As String)
                    m_url = value
                End Set
            End Property
            Private m_url As String
        End Class
    End Class
    Public Property hometown As m_hometown
    Public Class m_hometown
        Public Property id() As Long
            Get
                Return m_id
            End Get
            Set(value As Long)
                m_id = value
            End Set
        End Property
        Private m_id As Long

        Public Property name() As String
            Get
                Return m_name
            End Get
            Set(value As String)
                m_name = value
            End Set
        End Property
        Private m_name As String
    End Class

    Public Property sports As m_sports()
    Public Class m_sports
        Public Property id() As Long
            Get
                Return m_id
            End Get
            Set(value As Long)
                m_id = value
            End Set
        End Property
        Private m_id As Long

        Public Property name() As String
            Get
                Return m_name
            End Get
            Set(value As String)
                m_name = value
            End Set
        End Property
        Private m_name As String
    End Class

    Public Property work As m_work()
    Public Class m_work
        Public Property employer As m_employer
        Public Class m_employer
            Public Property id() As Long
                Get
                    Return m_id
                End Get
                Set(value As Long)
                    m_id = value
                End Set
            End Property
            Private m_id As Long

            Public Property name() As String
                Get
                    Return m_name
                End Get
                Set(value As String)
                    m_name = value
                End Set
            End Property
            Private m_name As String
        End Class
    End Class

    Public Property education As m_education()
    Public Class m_education
        Public Property type() As String
            Get
                Return m_type
            End Get
            Set(value As String)
                m_type = value
            End Set
        End Property
        Private m_type As String

        Public Property school As m_school
        Public Class m_school
            Public Property id() As Long
                Get
                    Return m_id
                End Get
                Set(value As Long)
                    m_id = value
                End Set
            End Property
            Private m_id As Long

            Public Property name() As String
                Get
                    Return m_name
                End Get
                Set(value As String)
                    m_name = value
                End Set
            End Property
            Private m_name As String
        End Class
    End Class

    Public Property data As m_data()
    Public Class m_data
        Public Property name As String
            Get
                Return m_name
            End Get
            Set(value As String)
                m_name = value
            End Set
        End Property
        Private m_name As String

        Public Property id As String
            Get
                Return m_id
            End Get
            Set(value As String)
                m_id = value
            End Set
        End Property
        Private m_id As String
        Public Property picture As String
            Get
                Return m_picture
            End Get
            Set(value As String)
                m_picture = value
            End Set
        End Property
        Private m_picture As String
        Public Property access_token As String
            Get
                Return m_access_token
            End Get
            Set(value As String)
                m_access_token = value
            End Set
        End Property
        Private m_access_token As String
        Public Property category As String
            Get
                Return m_category
            End Get
            Set(value As String)
                m_category = value
            End Set
        End Property
        Private m_category As String
    End Class
    Public Property outherror() As m_error
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
