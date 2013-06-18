Call CallTSMAPost()
Sub CallTSMAPost()

        'Force the script to finish on an error.
        On Error Resume Next

        'Declare variables
        Dim objRequest
        Dim URL

        Set objRequest = CreateObject("Microsoft.XMLHTTP")

        'Put together the URL link appending the Variables.
        URL = "https://www.tsmaapplication.com/AutoSweepstake.aspx"

        'Open the HTTP request and pass the URL to the objRequest object
        objRequest.open "POST", URL , False 

        'Send the HTML Request
        objRequest.Send

        'Set the object to nothing
        Set objRequest = Nothing
End Sub
