Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Public Class checkApp

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
        Public Property image_url As String
            Get
                Return m_image_url
            End Get
            Set(value As String)
                m_image_url = value
            End Set
        End Property
        Private m_image_url As String
        Public Property link() As String
            Get
                Return m_link
            End Get
            Set(value As String)
                m_link = value
            End Set
        End Property
        Private m_link As String
    End Class
End Class

