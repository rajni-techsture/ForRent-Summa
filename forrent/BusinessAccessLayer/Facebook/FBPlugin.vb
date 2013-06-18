Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Public Class FBPlugin
    Public Property data As fb_data()
    Public Class fb_data
        Public Property message As String
            Get
                Return m_message
            End Get
            Set(value As String)
                m_message = value
            End Set
        End Property
        Private m_message As String

        Public Property updated_date As DateTime
            Get
                Return m_updated_date
            End Get
            Set(value As DateTime)
                m_updated_date = value
            End Set
        End Property
        Private m_updated_date As DateTime
    End Class
End Class
