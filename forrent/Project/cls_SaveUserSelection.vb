Imports BusinessAccessLayer.BusinessLayer
Public Class cls_SaveUserSelection
    Dim objBAL As New BALCompanyIndusty
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
    Public Sub SaveSelection(FBUserID As String, CompanyID As Integer, IndustryID As Integer)
        If IndustryID <> Nothing AndAlso IsNumeric(IndustryID) AndAlso IndustryID <> -1 Then
            objBAL.FBUserId = FBUserID
            objBAL.CompanyId = IndustryID
            objBAL.GetIndustryUserDetails()
        End If
        If CompanyID <> Nothing AndAlso IsNumeric(CompanyID) AndAlso CompanyID <> -1 Then

            objBAL.FBUserId = FBUserID
            objBAL.CompanyId = CompanyID
            objBAL.GetCompnayUserDetails()
        End If
        ' If Password = "test" Then
        strMessage = ""
        _isError = False
        '  Else
        'strMessage = "Password does not match."
        '_isError = True
        ' End If
    End Sub
End Class
