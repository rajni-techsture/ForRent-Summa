Imports System.IO
Imports System.Net
Imports Facebook
Imports System.Runtime.Serialization.Json
Imports DataAccessLayer.DataAccessLayer
Imports tsma.PostData.m_data

Public Class page_post_data
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Write(Date.Now)
        'Response.Write(FormatDateTime(DateTime.Parse("2012-08-20T18:45:02+0000"), DateFormat.ShortDate) = FormatDateTime(DateTime.Parse("20/08/2012 6:22:25 PM"), DateFormat.ShortDate))
    End Sub

    Private Sub btnGet_Click(sender As Object, e As System.EventArgs) Handles btnGet.Click
        Dim AutoPostID As String = 0
        Dim ds As DataSet
        Dim dataAccess As New DALDataAccess()
        dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetAllFBPagesForRemovePost")
        ds = dataAccess.GetDataset
        For Each dtRow As DataRow In ds.Tables(0).Rows
            Try
                Dim url As String = ""
                Dim objRequest As WebRequest
                Dim objResponse As WebResponse
                Dim objStream As Stream
                AutoPostID = dtRow("id")
                Dim pageID As String = dtRow("PageID")
                Dim accessToken As String = dtRow("Token")

                url = "https://graph.facebook.com/{0}/posts?access_token={1}"
                objRequest = WebRequest.Create(String.Format(url, pageID, accessToken))
                objResponse = objRequest.GetResponse()
                objStream = objResponse.GetResponseStream()
                
                Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(PostData))

                Dim post As New PostData
                post = TryCast(dataContractJsonSerializer.ReadObject(objStream), PostData)
                Dim postData As PostData.m_data()
                postData = post.data

                If post.[error] IsNot Nothing Then
                    'If post.outherror.type = "OAuthException" Then
                    Dim dataAccess1 As New DALDataAccess()
                    dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                    dataAccess1.AddParam("@e_id", SqlDbType.Int, AutoPostID)
                    dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, pageID)
                    dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, dtRow("pagename"))
                    dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, accessToken)
                    dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, post.[error].message)
                    dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "Submitting post data into DB")
                    dataAccess1.ExecuteNonQuery()

                Else
                    For Each item As PostData.m_data In postData
                        Try
                            'Response.Write(FormatDateTime(DateTime.Parse(item.created_time), DateFormat.ShortDate))
                            'If FormatDateTime(DateTime.Parse(item.created_time), DateFormat.ShortDate) = "17/08/2012" Or FormatDateTime(DateTime.Parse(item.created_time), DateFormat.ShortDate) = "18/08/2012" Or FormatDateTime(DateTime.Parse(item.created_time), DateFormat.ShortDate) = "19/08/2012" Then
                            Dim strAppName As String = ""
                            Dim strAppNameSpace As String = ""
                            Dim strAppId As String = ""
                            If IsNothing(item.application) = False Then
                                strAppName = item.application.name
                                strAppNameSpace = item.application.namespace
                                strAppId = item.application.id
                            Else
                                strAppName = ""
                                strAppNameSpace = ""
                                strAppId = ""
                            End If
                            'If strAppName = "Marketplace Network 2.0" Then
                            Dim dataAccess1 As New DALDataAccess()
                            dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostData")
                            dataAccess1.AddParam("@pd_PostId", SqlDbType.VarChar, item.id)
                            dataAccess1.AddParam("@pd_PageId", SqlDbType.VarChar, pageID)
                            dataAccess1.AddParam("@pd_Token", SqlDbType.VarChar, accessToken)
                            dataAccess1.AddParam("@pd_PageName", SqlDbType.VarChar, item.from.name)
                            dataAccess1.AddParam("@pd_Message", SqlDbType.VarChar, IIf(item.message <> Nothing, item.message, ""))
                            dataAccess1.AddParam("@pd_Application", SqlDbType.VarChar, strAppName)
                            dataAccess1.AddParam("@pd_ApplicationNameSpace", SqlDbType.VarChar, strAppNameSpace)
                            dataAccess1.AddParam("@pd_ApplicationId", SqlDbType.VarChar, strAppId)
                            dataAccess1.AddParam("@pd_CreatedTime", SqlDbType.VarChar, DateTime.Parse(item.created_time))
                            dataAccess1.AddParam("@pd_UpdatedTime", SqlDbType.VarChar, DateTime.Parse(item.updated_time))
                            dataAccess1.ExecuteNonQuery()
                            'End If
                            'End If
                        Catch ex As Exception
                            Dim dataAccess1 As New DALDataAccess()
                            dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                            dataAccess1.AddParam("@e_id", SqlDbType.Int, AutoPostID)
                            dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, pageID)
                            dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, dtRow("pagename"))
                            dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, accessToken)
                            dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, ex.Message)
                            dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "Submitting post data into DB")
                            dataAccess1.ExecuteNonQuery()
                        End Try
                    Next
                End If

                
            Catch ex As Exception
                Dim dataAccess1 As New DALDataAccess()
                dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                dataAccess1.AddParam("@e_id", SqlDbType.Int, AutoPostID)
                dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, dtRow("pageId"))
                dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, dtRow("pagename"))
                dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, dtRow("token"))
                dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, ex.Message)
                dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "Requesting post data from FB")
                dataAccess1.ExecuteNonQuery()
            End Try
        Next
        ltrMessage.Text = "Success!"
    End Sub

    Private Sub btnDeletePost_Click(sender As Object, e As System.EventArgs) Handles btnDeletePost.Click
        Dim ds As DataSet
        Dim dataAccess As New DALDataAccess()
        dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetFBPagesForDeletingPost")
        ds = dataAccess.GetDataset
        For Each dtRow As DataRow In ds.Tables(0).Rows
            Try
                Dim fb = New FacebookClient()
                Dim args1 = New Dictionary(Of String, Object)()
                args1("access_token") = dtRow("access_token")
                args1("uid") = dtRow("source_id")
                fb.Delete(dtRow("post_id"), args1)
                'ltrMessage.Text = "Delete Success!"
                'Else
                'ltrMessage.Text = "Delete failed!"
                'End If
            Catch ex As Exception
                Dim dataAccess1 As New DALDataAccess()
                dataAccess1.AddCommand(CommandType.StoredProcedure, "prc_AddPostDataTempErrorLog")
                dataAccess1.AddParam("@e_id", SqlDbType.Int, 0)
                dataAccess1.AddParam("@e_PageId", SqlDbType.VarChar, dtRow("source_id"))
                dataAccess1.AddParam("@e_PageName", SqlDbType.VarChar, "")
                dataAccess1.AddParam("@e_Token", SqlDbType.VarChar, dtRow("access_token"))
                dataAccess1.AddParam("@e_Error", SqlDbType.VarChar, ex.Message)
                dataAccess1.AddParam("@e_ErrorFrom", SqlDbType.VarChar, "deleting post data from FB")
                dataAccess1.ExecuteNonQuery()
            End Try
        Next
        ltrMessage.Text = "Delete Success!"
    End Sub
End Class