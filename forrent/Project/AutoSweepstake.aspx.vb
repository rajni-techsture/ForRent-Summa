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
Public Class AutoSweepstake
    Inherits System.Web.UI.Page
    Dim objBAL As New BALSweepStake
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AutoSweepstake()
    End Sub

    Private Sub AutoSweepstake()
        'Try
        Dim ds As New DataSet

        ' objBAL.TSMAUserId = Session("SiteUserId")
        ' objBAL.FBUserId = Session("FacebookUserId")
        ds = objBAL.GetScheduledSweepstakeData()

        Dim result As String = ""
        Dim AppID = System.Configuration.ConfigurationManager.AppSettings("SweepStakeFBAPI").ToString()
        Dim url As String = "https://graph.facebook.com/{0}/tabs/?app_id={2}&access_token={1}&method=post"

        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                'If ds.Tables(0).Rows(i).Item("apm_OnOff") = 1 Then
                Dim strSweepstakeId As String = ds.Tables(0).Rows(i).Item("ss_id").ToString
                Dim strFBUserId As String = ds.Tables(0).Rows(i).Item("ss_FBUserId").ToString
                Dim strFBPageId As String = ds.Tables(0).Rows(i).Item("ss_FBPageId").ToString
                Dim strFBPageName As String = ds.Tables(0).Rows(i).Item("ss_FBPageName").ToString
                Dim strTSMAUserId As String = ds.Tables(0).Rows(i).Item("ss_TSMAUserId").ToString
                Dim strDate As String = ds.Tables(0).Rows(i).Item("ss_ScheduleDate").ToString
                Dim strHour As String = ds.Tables(0).Rows(i).Item("ss_ScheduleHour").ToString
                Dim strMinute As String = ds.Tables(0).Rows(i).Item("ss_ScheduleMinute").ToString
                Dim strAMPM As String = ds.Tables(0).Rows(i).Item("ss_ScheduleAMPM").ToString
                Dim strTimeZone As String = ds.Tables(0).Rows(i).Item("ss_ScheduleTimeZone").ToString

                objBAL.FBUserId = strFBUserId
                objBAL.TSMAUserId = CInt(strTSMAUserId)
                objBAL.FBPageId = strFBPageId
                Dim dsFanPages1 As New DataSet
                dsFanPages1 = objBAL.GetScheduledSweepstakeDataFanPages

                
                If ds.Tables(0).Rows(i).Item("ss_IsAddSweepstake").ToString = "1" Then

                    If dsFanPages1.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsFanPages1.Tables(0).Rows.Count - 1
                            Try
                                Dim strPageId As String = dsFanPages1.Tables(0).Rows(j).Item("p_FBPageId")
                                Dim strPageAccessToken As String = dsFanPages1.Tables(j).Rows(0).Item("p_FBPageToken")
                                If strPageId <> "" AndAlso strPageAccessToken <> "" Then
                                    ViewState("PageID") = strPageId
                                    ViewState("PageAccessToken") = strPageAccessToken
                                    Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url, strPageId, strPageAccessToken, AppID))
                                    Dim fbResponse As WebResponse = fbRequest.GetResponse()
                                    Dim stream As Stream = fbResponse.GetResponseStream()
                                    Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                                    Dim streamReader As New StreamReader(stream, encode)
                                    result = streamReader.ReadToEnd()
                                    streamReader.Close()

                                    Dim objSweepStake As New BALSweepStake

                                    objSweepStake.TSMAUserId = strTSMAUserId
                                    objSweepStake.CompanyId = 0 'GetSetCookies.GetCookie("CompanyId") 'Session("CompanyId")
                                    objSweepStake.IndustryId = 1 ' GetSetCookies.GetCookie("IndustryId") 'Session("IndustryId")
                                    objSweepStake.FBUserId = strFBUserId
                                    objSweepStake.FBPageId = strPageId
                                    objSweepStake.FBPageName = ViewState("PageName")
                                    objSweepStake.Title = ""
                                    objSweepStake.Content = ""
                                    objSweepStake.IsPublished = 1

                                    objSweepStake.AddEditSweepStake()

                                    objBAL.TSMAUserId = strTSMAUserId 'Session("SiteUserId")
                                    objBAL.FBUserId = strFBUserId 'Session("FacebookUserId")
                                    objBAL.SweepstakeId = strSweepstakeId 'Session("SweepstakeID")
                                    objBAL.FBPageId = strPageId
                                    objBAL.FBPageName = strFBPageName
                                    objBAL.FBPageImage = ""
                                    objBAL.FBPageAccessToken = strPageAccessToken
                                    objBAL.AddSweepstakeFanPages()
                                End If

                            Catch ex As Exception
                                objBAL.SweepstakeId = strSweepstakeId
                                objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("ss_TSMAUserId").ToString 'Session("SiteUserId")
                                objBAL.FBUserId = ds.Tables(0).Rows(i).Item("ss_FBUserId").ToString 'Session("FacebookUserId")
                                objBAL.FBPageId = dsFanPages1.Tables(0).Rows(j).Item("p_FBPageId").ToString & "/albums" '"225274570816748/photos"
                                objBAL.FBPageAccessToken = dsFanPages1.Tables(0).Rows(j).Item("p_FBPageToken").ToString
                                objBAL.ErrorDetails = ex.Message.ToString()
                                objBAL.AddSweepstakeErrorDetails()
                            End Try
                        Next
                    End If
                ElseIf ds.Tables(0).Rows(i).Item("ss_IsAddSweepstake").ToString = "2" Then
                    If dsFanPages1.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsFanPages1.Tables(0).Rows.Count - 1
                            Try
                                Dim strPageId As String = dsFanPages1.Tables(0).Rows(0).Item("p_FBPageId")
                                Dim strPageAccessToken As String = dsFanPages1.Tables(0).Rows(0).Item("p_FBPageToken")
                                If strPageId <> "" AndAlso strPageAccessToken <> "" Then
                                    Dim url1 As String = "https://graph.facebook.com/{0}/tabs/{2}?access_token={1}"
                                    Dim fbRequest As WebRequest = WebRequest.Create(String.Format(url1, strPageId, strPageAccessToken, AppID))
                                    Dim fbResponse As WebResponse = fbRequest.GetResponse()
                                    Dim stream As Stream = fbResponse.GetResponseStream()
                                    Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(checkApp))
                                    Dim fPage As New checkApp()
                                    fPage = TryCast(dataContractJsonSerializer.ReadObject(stream), checkApp)
                                    Dim listAlbums As New List(Of checkApp.m_data)

                                    For Each item1 As checkApp.m_data In fPage.data
                                        listAlbums.Add(item1)
                                    Next
                                    'Response.Write(listAlbums.Count & "   teste")
                                    'Response.End()

                                    If listAlbums.Count > 0 Then
                                        'strPageId = ViewState("ct_FBPageId") '"103823149672939"
                                        'Dim strPageAccessToken As String = ViewState("ct_FBPageAccessToken") '"AAAD2ZCc3HZAxABAIDxzyAwOqZCgzSRFVkLHqiLl88muU7QIRYTE1ZBEnPM7GTL7yZCbs7REZA0cVul1DsSWs2ntOKZB4boRTDPDZB8htHZBcn3C5Jlnlnqw4R"

                                        Dim urlSwp As String = "https://graph.facebook.com/{0}/tabs?app_id={3}&access_token={1}&method=delete&custom_name={2}"
                                        Dim fbRequest1 As WebRequest = WebRequest.Create(String.Format(urlSwp, strPageId, strPageAccessToken, "", AppID))
                                        Dim fbResponse1 As WebResponse = fbRequest1.GetResponse()
                                        Dim stream1 As Stream = fbResponse1.GetResponseStream()
                                        Dim encode1 As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                                        Dim streamReader1 As New StreamReader(stream1, encode1)
                                        result = streamReader1.ReadToEnd()
                                        streamReader1.Close()

                                        Dim objSweepStake As New BALSweepStake
                                        objSweepStake.SweepstakeId = strSweepstakeId
                                        objSweepStake.DeleteSweepstake()
                                    End If
                                End If




                            Catch ex As Exception
                                objBAL.SweepstakeId = strSweepstakeId
                                objBAL.TSMAUserId = ds.Tables(0).Rows(i).Item("ss_TSMAUserId").ToString 'Session("SiteUserId")
                                objBAL.FBUserId = ds.Tables(0).Rows(i).Item("ss_FBUserId").ToString 'Session("FacebookUserId")
                                objBAL.FBPageId = dsFanPages1.Tables(0).Rows(j).Item("p_FBPageId").ToString & "/albums" '"225274570816748/photos"
                                objBAL.FBPageAccessToken = dsFanPages1.Tables(0).Rows(j).Item("p_FBPageToken").ToString
                                objBAL.ErrorDetails = ex.Message.ToString()
                                objBAL.AddSweepstakeErrorDetails()

                            End Try
                        Next
                    End If
                End If


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