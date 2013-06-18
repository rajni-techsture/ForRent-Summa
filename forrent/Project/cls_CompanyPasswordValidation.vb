Public Class cls_CompanyPasswordValidation
    Private _isError As Boolean = False
    ReadOnly Property isError() As Boolean
        Get
            Return _isError
        End Get
    End Property

    Private strMessage As String = ""
    Public Property Message() As String
        Set(value As String)
            strMessage = value
        End Set
        Get
            Return strMessage
        End Get
    End Property

    Public Sub PasswordValidation(Password As String, CompanyID As Integer)
        If Password = "test" Then
            strMessage = ""
            _isError = False
        Else
            strMessage = "Password does not match."
            _isError = True
        End If
    End Sub
End Class
