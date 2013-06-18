Imports System.IO
Imports System.Collections
Imports Microsoft.Win32
Namespace BusinessLayer
    Public Class Criteria
        Public Sub New()
        End Sub

        'Public Enum specialCriteria
        '    TEXTSECTION
        '    TEXTFILETEMPLATE
        '    STANDARDPARAGRAPH
        'End Enum

        Protected _criteria As New Hashtable()
        Protected _whereSQL As String = ""
        'Protected _special As specialCriteria = specialCriteria.TEXTSECTION

        Public Sub AddCriteria(name As String, value As Object)
            _criteria.Add(name, value)
        End Sub

        ''' <summary>
        ''' Gets and sets the <c>CriteriaEx</c> column value
        ''' </summary>
        ''' <value>The <c>CriteriaEx</c> column value</value>
        'Public Property CriteriaEx() As specialCriteria
        '    Get
        '        Return Me._special
        '    End Get
        '    Set(value As specialCriteria)
        '        Me._special = value
        '    End Set
        'End Property

        ''' <summary>
        ''' Gets or sets the <c>GetCriteria</c> column value.
        ''' </summary>
        ''' <value>The <c>GetCriteria</c> column value.</value>
        Public Function GetCriteria(name As String) As Object
            If _criteria(name) IsNot Nothing Then
                Return _criteria(name)
            Else
                Return String.Empty
            End If
        End Function

        ''' <summary>
        ''' Gets or sets the <c>Where</c> column value.
        ''' </summary>
        ''' <value>The <c>Where</c> column value.</value>
        Public Property Where() As String
            Get
                Return Me._whereSQL
            End Get
            Set(value As String)
                Me._whereSQL = value
            End Set
        End Property

        Public Function EqualTo(criteria As Criteria) As Boolean
            If (Me.Where = criteria.Where) Then
                For Each name As String In _criteria.Keys
                    If (Me.GetCriteria(name).ToString() <> criteria.GetCriteria(name).ToString()) Then
                        Return False
                    End If
                Next
            Else
                Return False
            End If
            Return True
        End Function
        ''' <summary>
        ''' ValidateEntry is for replace the single code 
        ''' </summary>
        ''' <param name="val">
        ''' val for which value to replace code
        ''' </param>

        Public Shared Function ValidateEntry(val As String) As String
            Dim retVal As String = val.Replace("'", "''")
            Return retVal
        End Function

        Public Shared Function ValidateJvString(val As String) As String
            Dim retVal As String = val.Replace("'", "&prime;")
            Return retVal
        End Function

        ''' <summary>
        ''' GetAll is for to get all the data records form database
        ''' </summary>

        Public Shared Function GetActiveProspects(strCondition As String) As Criteria
            Dim criteria As New Criteria()
            criteria.Where = strCondition
            Return criteria
        End Function
        Public Shared Function GetActiveUsers(strCondition As String) As Criteria
            Dim criteria As New Criteria()
            criteria.Where = strCondition
            Return criteria
        End Function
        Public Shared Function GetActiveEntity(strCondition As String) As Criteria
            Dim criteria As New Criteria()
            criteria.Where = strCondition
            Return criteria
        End Function
        Public Shared Function GetActiveMembers(strCondition As String) As Criteria
            Dim criteria As New Criteria()
            criteria.Where = strCondition
            Return criteria
        End Function
        Public Shared Function GetAll() As Criteria
            Dim criteria As New Criteria()
            criteria.Where = " 1=1   "
            Return criteria
        End Function

        Public Shared Function GetAllRoleOrderBy(OrdBy As String) As Criteria
            Dim criteria As New Criteria()
            criteria.Where = " 1=1 order by " + ValidateEntry(OrdBy)
            Return criteria
        End Function

        Public Shared Function GetNotAll() As Criteria
            Dim criteria As New Criteria()
            criteria.Where = " 1<>1"
            Return criteria
        End Function

        Public Shared Function AuthenticateUser(userName As String, password As String) As Criteria
            Dim criteria As New Criteria()
            criteria.Where = " UM_LoginName = '" + ValidateEntry(userName) + "' and CAST(UM_Password As Varbinary(20))= CAST('" + ValidateEntry(password) + "' As Varbinary(20))"
            Return criteria
        End Function
        
    End Class
End Namespace
