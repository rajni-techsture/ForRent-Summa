Imports Microsoft.VisualBasic
Imports DataAccessLayer.DataAccessLayer
Imports BusinessAccessLayer.BusinessLayer
Imports System.IO
Imports System.Web
Imports Facebook
Imports System.Dynamic
Module Module1

    Dim objBAL As New BALSchedulePost
    'Dim objLog As New Log
    Public strFailedFanPageId As String = ""

    Sub Main()
        'Dim intTotal As Integer = 0
        'Dim intSuccessFull As Integer = 0
        'Dim intFailed As Integer = 0
        'objLog.WritePlainLog(FormatDateTime(Now.Date, DateFormat.ShortDate))
        'objLog.WritePlainLog("==========================================")
        'objLog.WriteLog("START")
        'AutoPost(intTotal, intSuccessFull, intFailed)
        SchedulePost()
        'objLog.WriteLog("END  ")
        'objLog.WritePlainLog("------------------------------------------")
        'objLog.WritePlainLog("Total Records : " & intTotal)
        'objLog.WritePlainLog("Successfull   : " & intSuccessFull)
        'objLog.WritePlainLog("Failed        : " & intFailed)
        'objLog.WritePlainLog("--------------Failed Autopost Fan Page ID Start -----------")
        'objLog.WritePlainLog("Failed Autopost Fan Page Id        : " & strFailedFanPageId)
        'objLog.WritePlainLog("--------------Failed Autopost Fan Page ID End -----------")
        'objLog.WritePlainLog("------------------------------------------")
        'objLog.WritePlainLog("")
    End Sub

#Region "Auto Post"
    'Sub AutoPost(ByRef intTotal As Integer, ByRef intSuccessFull As Integer, ByRef intFailed As Integer)
    Sub SchedulePost()
        Dim dataAccess As New DALDataAccess()
        Dim ds As New DataSet
        dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetScheduledDataForPersonalPage")
        ds = dataAccess.GetDataset()
        'intTotal = ds.Tables(0).Rows.Count
        For Each dtRow As DataRow In ds.Tables(0).Rows
            If dtRow("sp_FBPageAccessToken") <> "" Then
                Try
                    Dim path As String = ""
                    Dim fbApp = New FacebookClient(dtRow("sp_FBPageAccessToken").ToString)
                    Dim postData = New Dictionary(Of String, Object)()

                    If dtRow("sm_Image") <> "" Then
                        Try
                            'Dim imagePath As String = "https://www.tsmaapplication.com/content/uploads/images/" & dtRow("sm_Image").ToString
                            'Dim imagePath As String = "https://www.summasocialapp.com/content/uploads/images/" & dtRow("sm_Image").ToString 'Convert.ToString(My.Application.Info.DirectoryPath & "\images\" & dtRow("sm_Image").ToString).Replace("\bin\Debug", "")
                            'Dim imagePath As String = "http://so2.techsturedevelopment.com/content/uploads/images/" & dtRow("sm_Image").ToString 'Convert.ToString(My.Application.Info.DirectoryPath & "\images\" & dtRow("sm_Image").ToString).Replace("\bin\Debug", "")
                            Dim imagePath As String = "http://tsma2.techsturedevelopment.com/content/uploads/images/" & dtRow("sm_Image").ToString()
                            'Dim imagePath As String = Convert.ToString(My.Application.Info.DirectoryPath & "\images\" & dtRow("sm_Image").ToString).Replace("\bin\Debug", "")
                            'Dim imagePath As String = "C:\inetpub\wwwroot\release\forrent_20120216220109\Content\uploads\images\" & dtRow("sm_Image").ToString ''forrent.com production server
                            'Dim mediaObject As New FacebookMediaObject() With { _
                            '    .FileName = imagePath, _
                            '    .ContentType = "image/jpg" _
                            '}
                            'Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                            'mediaObject.SetValue(fileBytes)
                            'postData.Clear()
                            'postData.Add("message", dtRow("sm_Message").ToString.Replace("<br>", Chr(10)))
                            'postData.Add("image", mediaObject)


                            postData.Clear()
                            postData.Add("message", dtRow("sm_Message").ToString.Replace("<br>", Chr(10)))
                            postData.Add("url", imagePath)


                            ''' for posting as a picture
                            'postData.Add("picture", imagePath)
                            'postData.Add("link", "")
                            'path = dtRow("FBPageId").ToString & "/feed" '& "/photos"
                            ''''' end
                            path = dtRow("FBPageId").ToString & "/photos"
                            fbApp.Post(path, postData)
                        Catch ex As Exception
                            InsertErrorLog(dtRow("sm_Id"), dtRow("TSMAUserId"), dtRow("FBUserID"), dtRow("FBPageId"), dtRow("sp_FBPageAccessToken"), ex.Message.ToString())
                        End Try

                    Else
                        Try
                            postData.Add("message", dtRow("sm_Message").ToString.Replace("<br>", Chr(10)))
                            If dtRow("Link") <> "" Then
                                postData.Add("link", dtRow("Link").ToString)
                            End If
                            path = dtRow("FBPageId").ToString & "/feed"
                            fbApp.Post(path, postData)
                        Catch ex As Exception
                            InsertErrorLog(dtRow("sm_Id"), dtRow("TSMAUserId"), dtRow("FBUserID"), dtRow("FBPageId"), dtRow("sp_FBPageAccessToken"), ex.Message.ToString())
                        End Try
                    End If

                    objBAL.ScheduleId = dtRow("sm_Id")
                    objBAL.UpdateSchdulePostData()

                    'intSuccessFull = intSuccessFull + 1
                Catch ex As FacebookOAuthException
                    InsertErrorLog(dtRow("sm_Id"), dtRow("TSMAUserId"), dtRow("FBUserID"), dtRow("FBPageId"), dtRow("sp_FBPageAccessToken"), ex.Message.ToString())
                    'intFailed = intFailed + 1
                    ' strFailedFanPageId = dtRow("FBPageId")
                    'strFailedFanPageId = strFailedFanPageId & dtRow("FBPageId") & ","
                End Try
            Else
                InsertErrorLog(dtRow("sm_Id"), dtRow("TSMAUserId"), dtRow("FBUserID"), dtRow("FBPageId"), dtRow("sp_FBPageAccessToken"), "Access token does not exists!")
                'intFailed = intFailed + 1
                'strFailedFanPageId = dtRow("FBPageId")
                'strFailedFanPageId = strFailedFanPageId & dtRow("FBPageId") & ","
            End If
        Next
        'Catch ex As Exception
        '    InsertErrorLog(0, 0, 0, "", "", ex.Message.ToString & "  : At start of getting data ")
        'End Try

    End Sub
#End Region

#Region "Error Log"
    Sub InsertErrorLog(AutoPostId As Integer, TSMAUserId As Integer, FBUserID As String, FBPageId As String, AccessToken As String, ErrorDetails As String)
        Try
            Dim dataAccess As New DALDataAccess()
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_AddSchedulePostErrorDetails")
            dataAccess.AddParam("@sper_AutoPostId", SqlDbType.Int, AutoPostId)
            dataAccess.AddParam("@sper_TSMAUserId", SqlDbType.Int, TSMAUserId)
            dataAccess.AddParam("@sper_FBUserId", SqlDbType.VarChar, FBUserID)
            dataAccess.AddParam("@sper_FBPageId", SqlDbType.VarChar, FBPageId)
            dataAccess.AddParam("@sper_AcessToken", SqlDbType.VarChar, AccessToken)
            dataAccess.AddParam("@sper_Error", SqlDbType.VarChar, ErrorDetails)
            dataAccess.ExecuteNonQuery()
        Catch ex As Exception
            InsertErrorLog(0, 0, "", "", "", ex.Message.ToString & "  : At the time of inserting records in tbl_autoposterrorlog table ")
        End Try
    End Sub
#End Region


End Module
