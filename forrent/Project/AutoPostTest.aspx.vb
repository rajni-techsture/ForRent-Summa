Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports System.IO
Imports Facebook
'Imports Facebook.FacebookClient
Imports System.Threading
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Xml
Imports System.Collections
Imports System.String
Imports System.Text
Imports System.Configuration
Imports System.Data

Public Class AutoPostTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SchedulePost()
        AutoPost()
    End Sub

    Private Sub AutoPost()
        'Try
        'Dim AccessToken As String = "AAAD2ZCc3HZAxABAG41OqIjnjvtea6SkNxR9qnxeIQka8IFH2xQZBi4XZB42YZBItWK2U9qqrR8THDYK2dU8V9Kv7zvuI2oykL3AjzMZCR1VgZDZD" ' Session("FacebookAccessToken")
        Dim ds As New DataSet
        Dim objBAL As New BALSchedulePost
        ds = objBAL.GetAutoPostScheduledDataForSheduler()

        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                'If ds.Tables(0).Rows(i).Item("apm_OnOff") = 1 Then
                Dim strAutoPostId As String = ds.Tables(0).Rows(i).Item("apm_id").ToString
                Dim strFBUserId As String = ds.Tables(0).Rows(i).Item("apm_FBUserId").ToString
                Dim strTSMAUserId As String = ds.Tables(0).Rows(i).Item("apm_TSMAUserId").ToString
                Dim strmessage1 As String = ds.Tables(0).Rows(i).Item("apm_Message").ToString.Replace("<br>", Chr(10))
                Dim strDate As String = ds.Tables(0).Rows(i).Item("apm_ScheduleDate").ToString
                Dim strHour As String = ds.Tables(0).Rows(i).Item("apm_ScheduleHour").ToString
                Dim strMinute As String = ds.Tables(0).Rows(i).Item("apm_ScheduleMinute").ToString
                Dim strAMPM As String = ds.Tables(0).Rows(i).Item("apm_ScheduleAMPM").ToString
                Dim strTimeZone As String = ds.Tables(0).Rows(i).Item("apm_ScheduleTimeZone").ToString

                If ds.Tables(0).Rows(i).Item("apm_Image").ToString <> "" Then
                    Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/" & ds.Tables(0).Rows(i).Item("apm_Image").ToString)
                    objBAL.FBUserId = strFBUserId
                    objBAL.TSMAUserId = CInt(strTSMAUserId)
                    Dim dsFanPages1 As New DataSet
                    dsFanPages1 = objBAL.GetAutoPostScheduledDataFanPages()

                    If dsFanPages1.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsFanPages1.Tables(0).Rows.Count - 1
                            Dim path1 As String = dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/albums" '"225274570816748/photos"
                            Dim Albumpath As String = "https://graph.facebook.com/" & dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/albums?fields=id,name&access_token={0}"
                            Dim fbapp1 = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString)
                            Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                            Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                            Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString))
                            Dim response1 As WebResponse = request1.GetResponse()
                            Dim stream As Stream = response1.GetResponseStream()
                            Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                            Dim fAlbums As New Albums()
                            fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                            Dim listAlbums As New List(Of Albums.m_data)

                            For Each item1 As Albums.m_data In fAlbums.data
                                listAlbums.Add(item1)
                            Next
                            Dim cnt As Integer = listAlbums.Count
                            Dim flag As Integer
                            Dim aid As String = ""
                            For k As Integer = 0 To cnt - 1
                                If listAlbums.Item(k).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                                    aid = listAlbums.Item(k).id
                                    flag = 0
                                    Exit For
                                Else
                                    flag = 1
                                End If
                            Next

                            If flag = 1 Then
                                upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                                Dim album As JsonObject = fbapp1.Post(path1, upload1)

                                Dim albumID As String = album("id")

                                Dim path As String = albumID & "/photos" '"225274570816748/photos"
                                Dim mediaObject As New FacebookMediaObject() With { _
                                    .FileName = photopath, _
                                    .ContentType = "image/jpg" _
                                }
                                Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                mediaObject.SetValue(fileBytes)
                                Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                upload.Add("message", ds.Tables(0).Rows(i).Item("apm_Message").ToString.Replace("<br>", Chr(10)))
                                upload.Add("image", mediaObject)
                                Dim fbapp = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString)
                                fbapp.Post(path, upload)
                            Else
                                Dim path As String = aid & "/photos" '"225274570816748/photos"
                                Dim mediaObject As New FacebookMediaObject() With { _
                                    .FileName = photopath, _
                                    .ContentType = "image/jpg" _
                                }
                                Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                mediaObject.SetValue(fileBytes)
                                Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                upload.Add("message", ds.Tables(0).Rows(i).Item("apm_Message").ToString.Replace("<br>", Chr(10)))
                                upload.Add("image", mediaObject)
                                Dim fbapp = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString)
                                fbapp.Post(path, upload)
                            End If
                            '    Dim path As String = dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/photos"
                            '    Dim mediaObject As New FacebookMediaObject() With { _
                            '        .FileName = photopath, _
                            '        .ContentType = "image/jpg" _
                            '}
                            '    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                            '    mediaObject.SetValue(fileBytes)
                            '    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                            '    upload.Add("message", ds.Tables(0).Rows(i).Item("apm_Message").ToString.Replace("<br>", Chr(10)))
                            '    upload.Add("image", mediaObject)
                            '    Dim fbapp = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString)
                            '    fbapp.Post(path, upload)
                        Next
                    End If
                ElseIf ds.Tables(0).Rows(i).Item("apm_VideoLink").ToString = "" Then
                    Dim args1 = New Dictionary(Of String, Object)()
                    args1("message") = strmessage1
                    'args1("link") = ds.Tables(0).Rows(i).Item("apm_VideoLink").ToString
                    objBAL.FBUserId = strFBUserId
                    objBAL.TSMAUserId = CInt(strTSMAUserId)
                    Dim dsFanPages As New DataSet
                    dsFanPages = objBAL.GetAutoPostScheduledDataFanPages()
                    If dsFanPages.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsFanPages.Tables(0).Rows.Count - 1
                            ' Response.Write("fanpages Id :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageId").ToString & ",<br/>")
                            '  Response.Write("AccessToken :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString & ",")
                            'Response.End()
                            Dim AccessToken As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString
                            Dim path As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/feed" '"151638698269605/feed" '
                            Dim fbapp = New FacebookClient(AccessToken)
                            fbapp.Post(path, args1)
                        Next
                        'Response.Write(dsFanPages.Tables(0).Rows(0).Item("sp_FBPageId").ToString)
                    End If
                End If

                If ds.Tables(0).Rows(i).Item("apm_VideoLink").ToString <> "" Then
                    Dim args1 = New Dictionary(Of String, Object)()
                    args1("message") = strmessage1
                    args1("link") = ds.Tables(0).Rows(i).Item("apm_VideoLink").ToString
                    objBAL.FBUserId = strFBUserId
                    objBAL.TSMAUserId = CInt(strTSMAUserId)
                    Dim dsFanPages As New DataSet
                    dsFanPages = objBAL.GetAutoPostScheduledDataFanPages()
                    If dsFanPages.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsFanPages.Tables(0).Rows.Count - 1
                            ' Response.Write("fanpages Id :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageId").ToString & ",<br/>")
                            '  Response.Write("AccessToken :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString & ",")
                            'Response.End()
                            Dim AccessToken As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString
                            Dim path As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/feed" '"151638698269605/feed" '
                            Dim fbapp = New FacebookClient(AccessToken)
                            fbapp.Post(path, args1)
                        Next
                        'Response.Write(dsFanPages.Tables(0).Rows(0).Item("sp_FBPageId").ToString)
                    End If
                    'Response.Redirect(ConfigurationManager.AppSettings("AppPath"))
                End If

                objBAL.AutoPostId = CInt(strAutoPostId)
                objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("apm_TSMAUserId").ToString 'Session("SiteUserId")
                objBAL.FBUserId = ds.Tables(0).Rows(i).Item("apm_FBUserId").ToString 'Session("FacebookUserId")
                objBAL.CompanyId = ds.Tables(0).Rows(i).Item("apm_CompanyId").ToString
                objBAL.IndustryId = ds.Tables(0).Rows(i).Item("apm_IndustryId").ToString
                objBAL.FBApplicationAccessToken = ds.Tables(0).Rows(i).Item("apm_FBApplicationAccessToken").ToString 'Session("FacebookAccessToken")
                objBAL.Message = ds.Tables(0).Rows(i).Item("apm_Message").ToString 'strmessage1
                objBAL.Image = ds.Tables(0).Rows(i).Item("apm_image").ToString
                objBAL.Video = ds.Tables(0).Rows(i).Item("apm_Video").ToString
                objBAL.VideoLink = ds.Tables(0).Rows(i).Item("apm_VideoLink").ToString
                objBAL.VideoId = ds.Tables(0).Rows(i).Item("apm_VideoId").ToString
                objBAL.VideoImage = ds.Tables(0).Rows(i).Item("apm_VideoImage").ToString
                objBAL.ScheduleDate = strDate
                objBAL.ScheduleHour = strHour
                objBAL.ScheduleMinute = strMinute
                objBAL.ScheduleAMPM = strAMPM
                objBAL.ScheduleTimeZone = strTimeZone
                objBAL.AutoPostOnOff = 0 'ds.Tables(0).Rows(i).Item("apm_OnOff")
                objBAL.AutoPostSet = 0 'ds.Tables(0).Rows(i).Item("apm_Is")
                objBAL.IsPosted = 1
                objBAL.PostType = 0
                objBAL.UpdatedDate = Date.Now
                objBAL.UpdateAutoPostMaster()
                'End If
            Next
        End If
        'Catch ex As Exception
        '    Dim IPAddress As String = Request.ServerVariables("REMOTE_ADDR")
        '    Dim GetDate As DateTime = Date.Now
        '    'Response.Write("IPAddress" & IPAddress & "<br/>")
        '    'Response.Write("Schedule Date" & GetDate & "<br/>")
        '    Dim ds1 As New DataSet
        '    Dim objBAL1 As New BALSchedulePost
        '    objBAL1.TestIP = IPAddress
        '    objBAL1.TestDate = GetDate
        '    objBAL1.GetAddFailedSchedule()
        '    ltrErrorMsg.Text = "Error:" & ex.Message
        'End Try

    End Sub

    Private Sub SchedulePost()
        Try
            Dim ds As New DataSet
            Dim objBAL As New BALSchedulePost
            ' objBAL.TSMAUserId = Session("SiteUserId")
            ' objBAL.FBUserId = Session("FacebookUserId")
            ds = objBAL.GetScheduledData()

            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim strid As String = ds.Tables(0).Rows(i).Item("sm_id").ToString
                    Dim strmessage1 As String = ds.Tables(0).Rows(i).Item("sm_Message").ToString.Replace("<br>", Chr(10))
                    Dim strDate As String = ds.Tables(0).Rows(i).Item("sm_ScheduleDate").ToString
                    Dim strHour As String = ds.Tables(0).Rows(i).Item("sm_ScheduleHour").ToString
                    Dim strMinute As String = ds.Tables(0).Rows(i).Item("sm_ScheduleMinute").ToString
                    Dim strAMPM As String = ds.Tables(0).Rows(i).Item("sm_ScheduleAMPM").ToString
                    Dim strTimeZone As String = ds.Tables(0).Rows(i).Item("sm_ScheduleTimeZone").ToString

                    If ds.Tables(0).Rows(i).Item("sm_Image").ToString <> "" Then
                        Dim photopath As String = Server.MapPath("~/" & "Content/uploads/images/" & ds.Tables(0).Rows(i).Item("sm_Image").ToString)
                        objBAL.ScheduleId = CInt(strid)
                        Dim dsFanPages1 As New DataSet
                        dsFanPages1 = objBAL.GetScheduledDataFanPages()

                        If dsFanPages1.Tables(0).Rows.Count > 0 Then
                            For j As Integer = 0 To dsFanPages1.Tables(0).Rows.Count - 1
                                Dim path1 As String = dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageId").ToString & "/albums" '"225274570816748/photos"
                                Dim Albumpath As String = "https://graph.facebook.com/" & dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageId").ToString & "/albums?fields=id,name&access_token={0}"
                                Dim fbapp1 = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString)
                                Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString))
                                Dim response1 As WebResponse = request1.GetResponse()
                                Dim stream As Stream = response1.GetResponseStream()
                                Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                                Dim fAlbums As New Albums()
                                fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                                Dim listAlbums As New List(Of Albums.m_data)

                                For Each item1 As Albums.m_data In fAlbums.data
                                    listAlbums.Add(item1)
                                Next
                                Dim cnt As Integer = listAlbums.Count
                                Dim flag As Integer
                                Dim aid As String = ""
                                For k As Integer = 0 To cnt - 1
                                    If listAlbums.Item(k).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                                        aid = listAlbums.Item(k).id
                                        flag = 0
                                        Exit For
                                    Else
                                        flag = 1
                                    End If
                                Next

                                If flag = 1 Then
                                    upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                                    Dim album As JsonObject = fbapp1.Post(path1, upload1)

                                    Dim albumID As String = album("id")

                                    Dim path As String = albumID & "/photos" '"225274570816748/photos"
                                    Dim mediaObject As New FacebookMediaObject() With { _
                                        .FileName = photopath, _
                                        .ContentType = "image/jpg" _
                                    }
                                    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                    mediaObject.SetValue(fileBytes)
                                    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                    upload.Add("message", ds.Tables(0).Rows(i).Item("sm_Message").ToString.Replace("<br>", Chr(10)))
                                    upload.Add("image", mediaObject)
                                    Dim fbapp = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString)
                                    fbapp.Post(path, upload)
                                Else
                                    Dim path As String = aid & "/photos" '"225274570816748/photos"
                                    Dim mediaObject As New FacebookMediaObject() With { _
                                        .FileName = photopath, _
                                        .ContentType = "image/jpg" _
                                    }
                                    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                    mediaObject.SetValue(fileBytes)
                                    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                    upload.Add("message", ds.Tables(0).Rows(i).Item("sm_Message").ToString.Replace("<br>", Chr(10)))
                                    upload.Add("image", mediaObject)
                                    Dim fbapp = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString)
                                    fbapp.Post(path, upload)
                                End If

                                '    Dim path As String = dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageId").ToString & "/photos"
                                '    Dim mediaObject As New FacebookMediaObject() With { _
                                '        .FileName = photopath, _
                                '        .ContentType = "image/jpg" _
                                '}
                                '    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                '    mediaObject.SetValue(fileBytes)
                                '    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                '    upload.Add("message", ds.Tables(0).Rows(i).Item("sm_Message").ToString.Replace("<br>", Chr(10)))
                                '    upload.Add("image", mediaObject)
                                '    Dim fbapp = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString)
                                '    fbapp.Post(path, upload)
                            Next
                        End If
                    ElseIf ds.Tables(0).Rows(i).Item("sm_VideoLink").ToString = "" Then
                        Dim args1 = New Dictionary(Of String, Object)()
                        args1("message") = strmessage1
                        'args1("link") = ds.Tables(0).Rows(i).Item("sm_VideoLink").ToString
                        objBAL.ScheduleId = CInt(strid)
                        Dim dsFanPages As New DataSet
                        dsFanPages = objBAL.GetScheduledDataFanPages()
                        If dsFanPages.Tables(0).Rows.Count > 0 Then
                            For j As Integer = 0 To dsFanPages.Tables(0).Rows.Count - 1
                                ' Response.Write("fanpages Id :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageId").ToString & ",<br/>")
                                '  Response.Write("AccessToken :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString & ",")
                                'Response.End()
                                Dim AccessToken As String = dsFanPages.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString
                                Dim path As String = dsFanPages.Tables(0).Rows(j).Item("sp_FBPageId").ToString & "/feed" '"151638698269605/feed" '
                                Dim fbapp = New FacebookClient(AccessToken)
                                fbapp.Post(path, args1)
                            Next
                            'Response.Write(dsFanPages.Tables(0).Rows(0).Item("sp_FBPageId").ToString)
                        End If

                    End If

                    If ds.Tables(0).Rows(i).Item("sm_VideoLink").ToString <> "" Then
                        Dim args1 = New Dictionary(Of String, Object)()
                        args1("message") = strmessage1
                        args1("link") = ds.Tables(0).Rows(i).Item("sm_VideoLink").ToString
                        objBAL.ScheduleId = CInt(strid)
                        Dim dsFanPages As New DataSet
                        dsFanPages = objBAL.GetScheduledDataFanPages()
                        If dsFanPages.Tables(0).Rows.Count > 0 Then
                            For j As Integer = 0 To dsFanPages.Tables(0).Rows.Count - 1
                                ' Response.Write("fanpages Id :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageId").ToString & ",<br/>")
                                '  Response.Write("AccessToken :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString & ",")
                                'Response.End()
                                Dim AccessToken As String = dsFanPages.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString
                                Dim path As String = dsFanPages.Tables(0).Rows(j).Item("sp_FBPageId").ToString & "/feed" '"151638698269605/feed" '
                                Dim fbapp = New FacebookClient(AccessToken)
                                fbapp.Post(path, args1)
                            Next
                            'Response.Write(dsFanPages.Tables(0).Rows(0).Item("sp_FBPageId").ToString)
                        End If
                    End If


                    objBAL.DraftId = CInt(strid)
                    objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("sm_TSMAUserId").ToString 'Session("SiteUserId")
                    objBAL.FBUserId = ds.Tables(0).Rows(i).Item("sm_FBUserId").ToString 'Session("FacebookUserId")
                    objBAL.CompanyId = ds.Tables(0).Rows(i).Item("sm_CompanyId").ToString
                    objBAL.IndustryId = ds.Tables(0).Rows(i).Item("sm_IndustryId").ToString
                    objBAL.FBApplicationAccessToken = ds.Tables(0).Rows(i).Item("sm_FBApplicationAccessToken").ToString 'Session("FacebookAccessToken")
                    objBAL.Message = ds.Tables(0).Rows(i).Item("sm_Message").ToString 'strmessage1
                    objBAL.Image = ds.Tables(0).Rows(i).Item("sm_image").ToString
                    objBAL.Video = ds.Tables(0).Rows(i).Item("sm_Video").ToString
                    objBAL.VideoLink = ds.Tables(0).Rows(i).Item("sm_VideoLink").ToString
                    objBAL.VideoId = ds.Tables(0).Rows(i).Item("sm_VideoId").ToString
                    objBAL.VideoImage = ds.Tables(0).Rows(i).Item("sm_VideoImage").ToString
                    objBAL.ScheduleDate = strDate
                    objBAL.ScheduleHour = strHour
                    objBAL.ScheduleMinute = strMinute
                    objBAL.ScheduleAMPM = strAMPM
                    objBAL.ScheduleTimeZone = strTimeZone
                    objBAL.IsPosted = 1
                    objBAL.PostType = 0
                    objBAL.UpdatedDate = Date.Now
                    objBAL.UpdateDrafts()
                    '   lblMessage.Text = "Message Sent"

                Next
            End If
        Catch ex As Exception
            Dim IPAddress As String = Request.ServerVariables("REMOTE_ADDR")
            Dim GetDate As DateTime = Date.Now
            'Response.Write("IPAddress" & IPAddress & "<br/>")
            'Response.Write("Schedule Date" & GetDate & "<br/>")
            Dim ds1 As New DataSet
            Dim objBAL1 As New BALSchedulePost
            objBAL1.TestIP = IPAddress
            objBAL1.TestDate = GetDate
            objBAL1.GetAddFailedSchedule()
            ltrErrorMsg.Text = "Error:" & ex.Message
        End Try
    End Sub

End Class