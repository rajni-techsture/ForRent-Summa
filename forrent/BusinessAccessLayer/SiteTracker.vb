Imports System
Imports System.Data
Imports DataAccessLayer.DataAccessLayer
Imports System.IO

Namespace BusinessLayer
    ''' <summary>
    ''' Summary description for Class1.
    ''' </summary>
    <RecordAttribute("tb_SiteTraker", "sp_get_SiteTracker", "sp_delete", New [String](0) {"ST_MemberCode"})> _
    Public Class SiteTracker
        Inherits IRecord

#Region "Variables"
        Private _intMemberCode As Integer
        Private _intUserCode As Integer
        Private _intSiteTrackerCode As Integer
        Private _dateTimeStamp As DateTime
        Private _strFunctioname As String = String.Empty
        Private _strFunctionDetail As String = String.Empty
        Private _strOldvalue As String = String.Empty
        Private _strNewvalue As String = String.Empty
        Private _strIPAddress As String = String.Empty
#End Region

#Region "Properties"
        ''' <summary>
        ''' Gets and sets the <c>SiteTrackCode</c> column value
        ''' </summary>
        ''' <value>The <c>SiteTrackCode</c> column value</value>
        Public Property SiteTrackCode() As Integer
            Get
                Return _intSiteTrackerCode
            End Get
            Set(value As Integer)
                _intSiteTrackerCode = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the <c>MemberTrackCode</c> column value
        ''' </summary>
        ''' <value>The <c>MemberTrackCode</c> column value</value>
        Public Property MemberTrackCode() As Integer
            Get
                Return _intMemberCode
            End Get
            Set(value As Integer)
                _intMemberCode = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the <c>UserCode</c> column value
        ''' </summary>
        ''' <value>The <c>UserCode</c> column value</value>
        Public Property UserCode() As Integer
            Get
                Return _intUserCode
            End Get
            Set(value As Integer)
                _intUserCode = value
            End Set
        End Property
        Public Property IPAddress() As String
            Get
                Return _strIPAddress
            End Get
            Set(value As String)
                _strIPAddress = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the <c>FunctionDetail</c> column value
        ''' </summary>
        ''' <value>The <c>FunctionDetail</c> column value</value>
        Public Property FunctionDetail() As String
            Get
                Return _strFunctionDetail
            End Get
            Set(value As String)
                _strFunctionDetail = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the <c>OldValue</c> column value
        ''' </summary>
        ''' <value>The <c>OldValue</c> column value</value>

        Public Property OldValue() As String
            Get
                Return _strOldvalue
            End Get
            Set(value As String)
                _strOldvalue = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the <c>FunctionName</c> column value
        ''' </summary>
        ''' <value>The <c>FunctionName</c> column value</value>

        Public Property FunctionName() As String
            Get
                Return _strFunctioname
            End Get
            Set(value As String)
                _strFunctioname = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the <c>NewValue</c> column value
        ''' </summary>
        ''' <value>The <c>NewValue</c> column value</value>

        Public Property NewValue() As String
            Get
                Return _strNewvalue
            End Get
            Set(value As String)
                _strNewvalue = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the <c>TimeStamp</c> column value
        ''' </summary>
        ''' <value>The <c>TimeStamp</c> column value</value>
        Public Property TimeStamp() As DateTime
            Get
                Return _dateTimeStamp
            End Get
            Set(value As DateTime)
                _dateTimeStamp = value
            End Set
        End Property

#End Region


        '
        ' TODO: Add constructor logic here
        '
        Public Sub New()
        End Sub
        ''' <summary>
        ''' Load the record for the selected datarow.
        ''' </summary>
        ''' <param name="criteria"></param>
        ''' <returns>Returns true, if the loading of record is successful</returns>
        Public Overrides Function Load(criteria As Criteria) As Boolean
            MyBase.Load(criteria)
            If Me._table.Rows.Count > 0 Then
                PopulateRecord(Me._table.Rows(0))
                Return True
            Else
                Return False
            End If
        End Function

#Region "DB Operations"
        ''' <summary>
        ''' Insert/Updates the database table 'tb_SiteTracker'.
        ''' </summary>
        Public Sub Save()
            Try

              
            Catch ex As Exception
                Utility.LogError(ex, "SiteTracker.Save", True)
                Throw

            Finally
            End Try
        End Sub
        ''' <summary>
        ''' Assigns the selected datarow record values to the site tracker properties. 
        ''' </summary>
        ''' <param name="row">DataRow based on the criteria</param>
        Public Overrides Sub PopulateRecord(row As DataRow)
            Try

            Catch ex As Exception
                Utility.LogError(ex, "SiteTracker.PopulateRecord", True)
                Throw
            Finally
            End Try

        End Sub
        ''' <summary>
        ''' Delete entity record based on the ST_SiteTrackerCode.
        ''' </summary>
        Public Overrides Sub Delete()
            MyBase._criteria.Where = "ST_SiteTrackerCode = " + _intSiteTrackerCode
            MyBase.Delete()
        End Sub
#End Region

    End Class
End Namespace
