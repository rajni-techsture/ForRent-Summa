Public Class CustomTab
    Public Property algorithm() As String
        Get
            Return _algorithm
        End Get
        Set(value As String)
            _algorithm = value
        End Set
    End Property
    Private _algorithm As String

    Public Property expires() As String
        Get
            Return _expires
        End Get
        Set(value As String)
            _expires = value
        End Set
    End Property
    Private _expires As String

    Public Property issued_at() As String
        Get
            Return _issued_at
        End Get
        Set(value As String)
            _issued_at = value
        End Set
    End Property
    Private _issued_at As String

    Public Property oauth_token() As String
        Get
            Return _oauth_token
        End Get
        Set(value As String)
            _oauth_token = value
        End Set
    End Property
    Private _oauth_token As String

    Public Property page() As cls_page
    Public Class cls_page
        Public Property id() As String
            Get
                Return _id
            End Get
            Set(value As String)
                _id = value
            End Set
        End Property
        Private _id As String

        Public Property liked() As Boolean
            Get
                Return _liked
            End Get
            Set(value As Boolean)
                _liked = value
            End Set
        End Property
        Private _liked As Boolean

        Public Property admin() As Boolean
            Get
                Return _admin
            End Get
            Set(value As Boolean)
                _admin = value
            End Set
        End Property
        Private _admin As Boolean
    End Class

    Public Property user() As cls_user
    Public Class cls_user
        Public Property country() As String
            Get
                Return _country
            End Get
            Set(value As String)
                _country = value
            End Set
        End Property
        Private _country As String
    End Class
    Public Property user_id() As String
        Get
            Return _user_id
        End Get
        Set(value As String)
            _user_id = value
        End Set
    End Property
    Private _user_id As String
End Class
