Imports System.IO

Public Class Log
    'Private ApplicationPath As String = Convert.ToString(My.Application.Info.DirectoryPath & "\uploads\").Replace("\bin\Debug", "")
    'Private ApplicationPath As String = "C:\HostingSpaces\webuild\tsma2.techsturedevelopment.com\wwwroot\uploads\"
    'Private ApplicationPath As String = "C:\inetpub\wwwroot\release\forrent_20120216220109\uploads\" 'forrent.com production server
    'Private ApplicationPath As String = "C:\inetpub\wwwroot\release\summasocial_20120418\uploads\" 'summa production server
    Private ApplicationPath As String = "C:\inetpub\wwwroot\release\socialoutbreak_20120310010000\uploads\" 'so.tsma production server
    'Private LogFileName As String = "schedulepost_log.txt"
    Private LogFileName As String = "facebook_schedule_post_summa_log_" & String.Format("{0:MMddyyyyhhmmsstt}", Now) & ".txt"
    Sub New()
        Dim strFileName As String = Me.ApplicationPath & LogFileName
        If Not File.Exists(strFileName) Then
            Dim ofile As System.IO.FileStream
            ofile = File.Create(strFileName)
            ofile.Close()
        End If
    End Sub
    Sub WriteLog(ByVal strMessage As String)
        Dim oWrite As System.IO.StreamWriter
        Dim strFileName As String = Me.ApplicationPath & LogFileName
        oWrite = New StreamWriter(strFileName, True)
        oWrite.WriteLine(strMessage & " : {0:dd-MMMM-yyyy - hh:mm:sstt}", Now())
        oWrite.Close()
    End Sub

    Sub WritePlainLog(ByVal strMessage As String)
        Dim oWrite As System.IO.StreamWriter
        Dim strFileName As String = Me.ApplicationPath & LogFileName
        oWrite = New StreamWriter(strFileName, True)
        oWrite.WriteLine(strMessage)
        oWrite.Close()
    End Sub
End Class
