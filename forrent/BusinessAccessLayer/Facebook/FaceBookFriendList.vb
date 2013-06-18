Public Class FaceBookFriendList
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
    End Class
End Class
