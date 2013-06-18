Imports BusinessAccessLayer.BusinessLayer
Imports System.Runtime.Serialization.Json
Imports System.IO


Public Class sweepstake_content
    Inherits System.Web.UI.Page
    Dim objSweepStake As New BALSweepStake
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet()
        Dim strContent As String = ""
        Dim payload As String = Request.Form("signed_request").Split("."c)(1)
        Dim encoding = New UTF8Encoding()
        Dim decodedJson = payload.Replace("=", String.Empty).Replace("-"c, "+"c).Replace("_"c, "/"c)
        Dim base64JsonArray = Convert.FromBase64String(decodedJson.PadRight(decodedJson.Length + (4 - decodedJson.Length Mod 4) Mod 4, "="c))
        Dim json = encoding.GetString(base64JsonArray)

        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json))
        Dim dataContractJsonSerializer As New DataContractJsonSerializer(GetType(clsSweepStake))
        Dim stake As New clsSweepStake()
        stake = TryCast(dataContractJsonSerializer.ReadObject(stream), clsSweepStake)
        Dim liked = stake.page.liked

        'Response.Write(liked)

        If liked.ToString().Trim().ToLower() = "true" Then
            divLiked.Visible = True
            divUnliked.Visible = False
            objSweepStake.FBPageId = stake.page.id
            ds = objSweepStake.GetSweepStake()
            If ds.Tables(0).Rows.Count > 0 Then
                ' count.Value = ds.Tables(0).Rows.Count
                hdnFBUserId.Value = ds.Tables(0).Rows(0).Item("ss_FBUserId").ToString
                hdnFBPageName.Value = ds.Tables(0).Rows(0).Item("ss_FBPageName").ToString
                hdnFBPageId.Value = ds.Tables(0).Rows(0).Item("ss_FBPageId").ToString
            End If

            Dim strlink As String
            Dim FBAPPID As String
            FBAPPID = System.Configuration.ConfigurationManager.AppSettings("FBAppId").ToString
            'strlink = "http://www.facebook.com/pages/" + hdnFBPageName.Value + "/" + hdnFBPageId.Value + "?sk=app_" + FBAPPID
			strlink = "http://www.facebook.com/" & hdnFBPageId.Value
            linkpage.HRef = strlink
            hdnURL.Value = strlink
            hdnSweepStakeAppId.Value = FBAPPID
        Else
            divLiked.Visible = False
            divUnliked.Visible = True
        End If
        


        ' Catch ex As Exception
        ' End Try
    End Sub


    'Public Function DecodePayload(ByVal payload As String) As Dictionary<string,string>
    '        Dim encoding = New UTF8Encoding()
    '        Dim decodedJson = payload.Replace("=", String.Empty).Replace("-"c, "+"c).Replace("_"c, "/"c)
    '    Dim base64JsonArray =  Convert.FromBase64String(decodedJson.PadRight(decodedJson.Length +(4 - decodedJson.Length % 4) % 4,"="c)) 
    '        Dim json = encoding.GetString(base64JsonArray)
    '        Dim jObject1 = jObject.Parse(json)

    '    Dim parameters As String =  New Dictionary<string,string>() As String
    '    parameters.Add("user_id", CType(jObject("user_id") ?? "", String))
    '    parameters.Add("oauth_token", CType(jObject("oauth_token") ?? "", String))
    '    Dim expires As String = (CType(jObject("expires") ?? 0, long?)) 
    '    parameters.Add("expires", expires > 0 ? expires.ToString() : "")
    '    parameters.Add("profile_id", CType(jObject("profile_id") ?? "", String))
    '    parameters.Add("page", jObject("page").ToString() ?? "")

    '        Return parameters
    '    End Function

  

End Class