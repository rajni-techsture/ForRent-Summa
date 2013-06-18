Imports System
Imports System.IO
Imports System.Text
Imports System.Data

Namespace DataAccessLayer
    Public Class DALUtility

#Region "Variables"
        Private Shared _filePath As String
#End Region

#Region "Properties"
        ''' <summary>
        ''' Get or Set file path.
        ''' </summary>
        Public Shared Property FilePath() As String
            Get
                Return _filePath
            End Get
            Set(value As String)
                _filePath = value
            End Set
        End Property
#End Region

#Region "Error Logging Mechanism"
        ''' <summary>
        ''' Method to log error details to log file
        ''' </summary>
        ''' <param name="e">Exception to be logged</param>
        ''' <param name="sErrorMethod">Name of the method where exception generated</param>
        ''' <param name="bLogError">Boolean value indicates error log details.</param>

        Public Shared Sub LogError(e As Exception, sErrorMethod As String, bLogError As Boolean)
            Dim file As StreamWriter = Nothing

            'Try
            '    if bLogError = true and _filePath != "" then
            '        Dim sbError As New StringBuilder()
            '        sbError.Append("***  Error logged at " + DateTime.Now + "  ***\r\n")
            '        sbError.Append("Error In: " + sErrorMethod + "\r\n")
            '        sbError.Append("Source: " + e.Source + "\r\n")
            '        sbError.Append("Method: " + e.TargetSite.Name + "\r\n")
            '        sbError.Append("Error Description: " + e.Message + "\r\n")
            '        if e.InnerException != Nothing 
            '            sbError.Append("Inner Error Description: " + e.InnerException.Message + "\r\n")
            '            sbError.Append("---------------------------------------------------------")
            '            file = New StreamWriter(_filePath, True)
            '            file.WriteLine(sbError.ToString())
            '        End If
            '    End If
            'Catch ex As Exception
            'Finally
            '    If file IsNot Nothing Then
            '        file.Close()
            '    End If
            'End Try
        End Sub
#End Region

    End Class

End Namespace