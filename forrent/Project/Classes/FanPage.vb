Public Class FanPage
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
      
        Public Property access_token As String
            Get
                Return m_access_token
            End Get
            Set(value As String)
                m_access_token = value
            End Set
        End Property
        Private m_access_token As String
        Public Property link() As String
            Get
                Return m_link
            End Get
            Set(value As String)
                m_Link = value
            End Set
        End Property
        Private m_link As String
        Public Property category As String
            Get
                Return m_category
            End Get
            Set(value As String)
                m_category = value
            End Set
        End Property
        Private m_category As String
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
    End Class

    'Public Function CompareDinosByLength( _
    '    ByVal x As String, ByVal y As String) As Integer

    '    If x Is Nothing Then
    '        If y Is Nothing Then
    '            ' If x is Nothing and y is Nothing, they're
    '            ' equal. 
    '            Return 0
    '        Else
    '            ' If x is Nothing and y is not Nothing, y
    '            ' is greater. 
    '            Return -1
    '        End If
    '    Else
    '        ' If x is not Nothing...
    '        '
    '        If y Is Nothing Then
    '            ' ...and y is Nothing, x is greater.
    '            Return 1
    '        Else
    '            ' ...and y is not Nothing, compare the 
    '            ' lengths of the two strings.
    '            '
    '            Dim retval As Integer = _
    '                x.Length.CompareTo(y.Length)

    '            If retval <> 0 Then
    '                ' If the strings are not of equal length,
    '                ' the longer string is greater.
    '                '
    '                Return retval
    '            Else
    '                ' If the strings are of equal length,
    '                ' sort them with ordinary string comparison.
    '                '
    '                Return x.CompareTo(y)
    '            End If
    '        End If
    '    End If


    'End Function
End Class
