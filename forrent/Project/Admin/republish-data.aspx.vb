Imports System.Net
Imports System.Runtime.Serialization.Json
Imports BusinessAccessLayer.BusinessLayer
Imports System.IO
Imports Facebook
'Imports Facebook.FacebookClient
Imports System.Collections.Generic
Imports System.Web
Imports System.Xml
Imports System.Collections
Imports System.String
Imports System.Text
Imports System.Configuration
Imports System.Data


Public Class republish_data
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnReCoverPhotos_ServerClick(sender As Object, e As System.EventArgs) Handles btnReCoverPhotos.ServerClick
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
                            Try
                                'Dim path1 As String = dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/albums" '"225274570816748/photos"
                                'Dim Albumpath As String = "https://graph.facebook.com/" & dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/albums?fields=id,name&access_token={0}"
                                'Dim fbapp1 = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString)
                                'Dim upload1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                'Dim get1 As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                'Dim request1 As WebRequest = WebRequest.Create(String.Format(Albumpath, dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString))
                                'Dim response1 As WebResponse = request1.GetResponse()
                                'Dim stream As Stream = response1.GetResponseStream()
                                'Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(Albums))
                                'Dim fAlbums As New Albums()
                                'fAlbums = TryCast(dataContractJsonSerializer.ReadObject(stream), Albums)
                                'Dim listAlbums As New List(Of Albums.m_data)

                                'For Each item1 As Albums.m_data In fAlbums.data
                                '    listAlbums.Add(item1)
                                'Next
                                'Dim cnt As Integer = listAlbums.Count
                                'Dim flag As Integer
                                'Dim aid As String = ""
                                'For k As Integer = 0 To cnt - 1
                                '    If listAlbums.Item(k).name = ConfigurationManager.AppSettings("FBAlbumName") Then
                                '        aid = listAlbums.Item(k).id
                                '        flag = 0
                                '        Exit For
                                '    Else
                                '        flag = 1
                                '    End If
                                'Next

                                'If flag = 1 Then
                                '    upload1.Add("name", ConfigurationManager.AppSettings("FBAlbumName"))

                                '    Dim album As JsonObject = fbapp1.Post(path1, upload1)

                                '    Dim albumID As String = album("id")

                                '    Dim path As String = albumID & "/photos" '"225274570816748/photos"
                                '    Dim mediaObject As New FacebookMediaObject() With { _
                                '        .FileName = photopath, _
                                '        .ContentType = "image/jpeg" _
                                '    }
                                '    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                '    mediaObject.SetValue(fileBytes)
                                '    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                '    upload.Add("message", ds.Tables(0).Rows(i).Item("apm_Message").ToString.Replace("<br>", Chr(10)))
                                '    upload.Add("image", mediaObject)
                                '    Dim fbapp = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString)
                                '    fbapp.Post(path, upload)
                                'Else
                                '    Dim path As String = aid & "/photos" '"225274570816748/photos"
                                '    Dim mediaObject As New FacebookMediaObject() With { _
                                '        .FileName = photopath, _
                                '        .ContentType = "image/jpeg" _
                                '    }
                                '    Dim fileBytes As Byte() = File.ReadAllBytes(mediaObject.FileName)
                                '    mediaObject.SetValue(fileBytes)
                                '    Dim upload As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                                '    upload.Add("message", ds.Tables(0).Rows(i).Item("apm_Message").ToString.Replace("<br>", Chr(10)))
                                '    upload.Add("image", mediaObject)
                                '    Dim fbapp = New FacebookClient(dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString)
                                '    fbapp.Post(path, upload)
                                'End If

                                Dim path As String = dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/photos"
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

                                objBAL.AutoPostId = CInt(strAutoPostId)
                                'objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("apm_TSMAUserId").ToString 'Session("SiteUserId")
                                'objBAL.FBUserId = ds.Tables(0).Rows(i).Item("apm_FBUserId").ToString 'Session("FacebookUserId")
                                objBAL.UpdateAutoPostMasterNew()

                            Catch ex As Exception
                                objBAL.AutoPostId = strAutoPostId
                                objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("apm_TSMAUserId").ToString 'Session("SiteUserId")
                                objBAL.FBUserId = ds.Tables(0).Rows(i).Item("apm_FBUserId").ToString 'Session("FacebookUserId")
                                objBAL.FBPageId = dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageId").ToString '& "/albums" '"225274570816748/photos"
                                objBAL.FBPageAccessToken = dsFanPages1.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString
                                objBAL.ErrorDetails = ex.Message.ToString()
                                objBAL.AutoPostErrorDetails()
                                '    'Dim strHtml As String = "<html><body><p>Dear , Facebook has a new policy that causes Marketplace Network 2.0 credentials to expire every 60 days. Please follow the below instruction for log in to the Marketplace Network 2.0 Dashboard through the For Rent Management Console and reauthorize the application. When prompted to log in to Facebook, click Allow when the Marketplace 2.0 App box appears to reauthorize the App. It will ensure Autopost continues posting to Facebook. Thank you, Your Marketplace Network Team</p><p>Instruction to Login to the forrent Management Console </p><p>After Successfull login from the For Rent Management Console </p><p>1. Click on Facebook Image</p><p><img src='http://www.techsturedevelopment.com/content/images/step1.PNG'></p><p>2. After this Ask for the below Screen. Click on the Log In with Facebook Button</p><p><img src='http://www.techsturedevelopment.com/content/images/Step2.PNG'></p><p>3. Now Click On the Allow button as shown in the below image</p><p><img src='http://www.techsturedevelopment.com/content/images/step3.PNG'></p></body></html>"
                                '    'objBAL.SendExternalEmail("marketplace@no-reply.com", "cecarlsonbledsoe@gmail.com", "Auto-Post Access Token is Expired", strHtml, "", "")
                                '    'objBAL.SendExternalEmail("marketplace@no-reply.com", "Kirtikumar.techsture@gmail.com", "Auto-Post Access Token is Expired", strHtml, "", "")
                                '    'ex.Message.ToString()
                                '    'Response.Write(ex.Message.ToString())
                                '    'Response.End()
                                'Log here the entries in separate table
                            End Try
                        Next
                    End If
                ElseIf ds.Tables(0).Rows(i).Item("apm_Link").ToString = "" Then
                    Dim args1 = New Dictionary(Of String, Object)()
                    args1("message") = strmessage1
                    'args1("link") = ds.Tables(0).Rows(i).Item("apm_VideoLink").ToString
                    objBAL.FBUserId = strFBUserId
                    objBAL.TSMAUserId = CInt(strTSMAUserId)
                    Dim dsFanPages As New DataSet
                    dsFanPages = objBAL.GetAutoPostScheduledDataFanPages()
                    If dsFanPages.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsFanPages.Tables(0).Rows.Count - 1
                            Try
                                ' Response.Write("fanpages Id :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageId").ToString & ",<br/>")
                                '  Response.Write("AccessToken :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString & ",")
                                'Response.End()
                                Dim AccessToken As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString
                                Dim path As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/feed" '"151638698269605/feed" '
                                Dim fbapp = New FacebookClient(AccessToken)
                                fbapp.Post(path, args1)

                                objBAL.AutoPostId = CInt(strAutoPostId)
                                'objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("apm_TSMAUserId").ToString 'Session("SiteUserId")
                                'objBAL.FBUserId = ds.Tables(0).Rows(i).Item("apm_FBUserId").ToString 'Session("FacebookUserId")
                                objBAL.UpdateAutoPostMasterNew()
                            Catch ex As Exception
                                objBAL.AutoPostId = strAutoPostId
                                objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("apm_TSMAUserId").ToString 'Session("SiteUserId")
                                objBAL.FBUserId = ds.Tables(0).Rows(i).Item("apm_FBUserId").ToString 'Session("FacebookUserId")
                                objBAL.FBPageId = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageId").ToString '& "/albums" '"225274570816748/photos"
                                objBAL.FBPageAccessToken = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString
                                objBAL.ErrorDetails = ex.Message.ToString()
                                objBAL.AutoPostErrorDetails()
                                'Dim strHtml As String = "<html><body><p>Dear Kirti Panchal, Facebook has a new policy that causes Marketplace Network 2.0 credentials to expire every 60 days. Please follow the below instruction for log in to the Marketplace Network 2.0 Dashboard through the For Rent Management Console and reauthorize the application. When prompted to log in to Facebook, click Allow when the Marketplace 2.0 App box appears to reauthorize the App. It will ensure Autopost continues posting to Facebook. Thank you, Your Marketplace Network Team</p><p>Instruction to Login to the forrent Management Console </p><p>After Successfull login from the For Rent Management Console </p><p>1. Click on Facebook Image</p><p><img src='http://www.techsturedevelopment.com/content/images/step1.PNG'></p><p>2. After this Ask for the below Screen. Click on the Log In with Facebook Button</p><p><img src='http://www.techsturedevelopment.com/content/images/Step2.PNG'></p><p>3. Now Click On the Allow button as shown in the below image</p><p><img src='http://www.techsturedevelopment.com/content/images/step3.PNG'></p></body></html>"
                                'objBAL.SendExternalEmail("marketplace@no-reply.com", "cecarlsonbledsoe@gmail.com", "Auto-Post Access Token is Expired", strHtml, "", "")
                                'objBAL.SendExternalEmail("marketplace@no-reply.com", "Kirtikumar.techsture@gmail.com", "Auto-Post Access Token is Expired", strHtml, "", "")
                                'Log here the entries
                            End Try

                        Next
                        'Response.Write(dsFanPages.Tables(0).Rows(0).Item("sp_FBPageId").ToString)
                    End If
                End If

                If ds.Tables(0).Rows(i).Item("apm_Link").ToString <> "" Then
                    Dim args1 = New Dictionary(Of String, Object)()
                    args1("message") = strmessage1
                    args1("link") = ds.Tables(0).Rows(i).Item("apm_Link").ToString
                    objBAL.FBUserId = strFBUserId
                    objBAL.TSMAUserId = CInt(strTSMAUserId)
                    Dim dsFanPages As New DataSet
                    dsFanPages = objBAL.GetAutoPostScheduledDataFanPages()
                    If dsFanPages.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsFanPages.Tables(0).Rows.Count - 1
                            Try
                                ' Response.Write("fanpages Id :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageId").ToString & ",<br/>")
                                '  Response.Write("AccessToken :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString & ",")
                                'Response.End()
                                Dim AccessToken As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString
                                Dim path As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/feed" '"151638698269605/feed" '
                                Dim fbapp = New FacebookClient(AccessToken)
                                fbapp.Post(path, args1)

                                objBAL.AutoPostId = CInt(strAutoPostId)
                                'objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("apm_TSMAUserId").ToString 'Session("SiteUserId")
                                'objBAL.FBUserId = ds.Tables(0).Rows(i).Item("apm_FBUserId").ToString 'Session("FacebookUserId")
                                objBAL.UpdateAutoPostMasterNew()
                            Catch ex As FacebookOAuthException
                                objBAL.AutoPostId = strAutoPostId
                                objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("apm_TSMAUserId").ToString 'Session("SiteUserId")
                                objBAL.FBUserId = ds.Tables(0).Rows(i).Item("apm_FBUserId").ToString 'Session("FacebookUserId")
                                objBAL.FBPageId = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageId").ToString '& "/albums" '"225274570816748/photos"
                                objBAL.FBPageAccessToken = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString
                                objBAL.ErrorDetails = ex.Message.ToString()
                                objBAL.AutoPostErrorDetails()
                                'Dim strHtml As String = "<html><body><p>Dear Kirti Panchal, Facebook has a new policy that causes Marketplace Network 2.0 credentials to expire every 60 days. Please follow the below instruction for log in to the Marketplace Network 2.0 Dashboard through the For Rent Management Console and reauthorize the application. When prompted to log in to Facebook, click Allow when the Marketplace 2.0 App box appears to reauthorize the App. It will ensure Autopost continues posting to Facebook. Thank you, Your Marketplace Network Team</p><p>Instruction to Login to the forrent Management Console </p><p>After Successfull login from the For Rent Management Console </p><p>1. Click on Facebook Image</p><p><img src='http://www.techsturedevelopment.com/content/images/step1.PNG'></p><p>2. After this Ask for the below Screen. Click on the Log In with Facebook Button</p><p><img src='http://www.techsturedevelopment.com/content/images/Step2.PNG'></p><p>3. Now Click On the Allow button as shown in the below image</p><p><img src='http://www.techsturedevelopment.com/content/images/step3.PNG'></p></body></html>"
                                'objBAL.SendExternalEmail("marketplace@no-reply.com", "cecarlsonbledsoe@gmail.com", "Auto-Post Access Token is Expired", strHtml, "", "")
                                'objBAL.SendExternalEmail("marketplace@no-reply.com", "Kirtikumar.techsture@gmail.com", "Auto-Post Access Token is Expired", strHtml, "", "")
                                'objBAL.SendExternalEmail("marketplace@no-reply.com", "Kirtikumar.techsture@gmail.com;kirtikumar.panchal@yahoo.com", "Auto-Post Access Token (Text) is Expired", ex.Message.ToString(), "", "")
                                'ex.Message.ToString()
                                'Response.Write(ex.Message.ToString())
                                'Response.End()
                                'Log here the entries
                            End Try

                        Next
                        'Response.Write(dsFanPages.Tables(0).Rows(0).Item("sp_FBPageId").ToString)
                    End If
                    'Response.Redirect(ConfigurationManager.AppSettings("AppPath"))
                End If

                'If ds.Tables(0).Rows(i).Item("apm_VideoLink").ToString <> "" Then
                '    Dim args1 = New Dictionary(Of String, Object)()
                '    args1("message") = strmessage1
                '    args1("link") = ds.Tables(0).Rows(i).Item("apm_VideoLink").ToString
                '    objBAL.FBUserId = strFBUserId
                '    objBAL.TSMAUserId = CInt(strTSMAUserId)
                '    Dim dsFanPages As New DataSet
                '    dsFanPages = objBAL.GetAutoPostScheduledDataFanPages()
                '    If dsFanPages.Tables(0).Rows.Count > 0 Then
                '        For j As Integer = 0 To dsFanPages.Tables(0).Rows.Count - 1
                '            Try
                '                ' Response.Write("fanpages Id :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageId").ToString & ",<br/>")
                '                '  Response.Write("AccessToken :" & dsFanPages.Tables(0).Rows(j).Item("sp_FBPageAccessToken").ToString & ",")
                '                'Response.End()
                '                Dim AccessToken As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageAccessToken").ToString
                '                Dim path As String = dsFanPages.Tables(0).Rows(j).Item("ap_FBPageId").ToString & "/feed" '"151638698269605/feed" '
                '                Dim fbapp = New FacebookClient(AccessToken)
                '                fbapp.Post(path, args1)

                '                objBAL.AutoPostId = CInt(strAutoPostId)
                '                'objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("apm_TSMAUserId").ToString 'Session("SiteUserId")
                '                'objBAL.FBUserId = ds.Tables(0).Rows(i).Item("apm_FBUserId").ToString 'Session("FacebookUserId")
                '                objBAL.UpdateAutoPostMasterNew()
                '            Catch ex As Exception

                '            End Try

                '        Next
                '        'Response.Write(dsFanPages.Tables(0).Rows(0).Item("sp_FBPageId").ToString)
                '    End If
                '    'Response.Redirect(ConfigurationManager.AppSettings("AppPath"))
                'End If


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
End Class