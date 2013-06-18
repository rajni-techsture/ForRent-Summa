Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Xml
Imports System.Net
Imports System.Collections
Imports System.Runtime.Serialization.Json
Imports System.String
Imports System.Text
Imports BusinessAccessLayer.BusinessLayer
Imports System.Configuration
Imports System.Data
Imports Facebook

Public Class gcPost
    Inherits System.Web.UI.Page

    Public req As System.Net.WebRequest
    Public rsp As System.Net.WebResponse
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gcTest()
    End Sub
    Public Sub gcTest()
        '   Dim url As New Uri("https://customeracceptance.forrent.com/external/guestcard/submit.php")
        Dim url As New Uri(System.Configuration.ConfigurationManager.AppSettings("GCPostWebservice").ToString())
        Dim rec As New System.Collections.Hashtable()
        rec.Add("roll", 10)
        Dim obj As New CustomTabContent
        Dim ds As New DataSet
        ds = obj.GetCustomTabInfo()
        If ds.Tables(0).Rows.Count > 0 Then
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1

                ' Processing Data
                rec("username") = "WeBuild"
                rec("password") = "W3Bu1ld"
                rec("version") = "1"
                rec("responseType") = "XML"

                ' Required Guest Card Dat
                rec("siteId") = CInt(ds.Tables(0).Rows(j).Item("SiteId")) '"1004567" '
                Dim name As String = ds.Tables(0).Rows(j).Item("cti_Name").ToString
                If name <> "" Then
                    If (name.IndexOf(" ") = -1) Then
                        rec("firstName") = name
                        rec("lastName") = "NA"

                    Else
                        rec("firstName") = name.Substring(0, name.IndexOf(" ")) '"kirtikumar" '
                        rec("lastName") = name.Substring(name.IndexOf(" ") + 1)
                    End If
                Else
                    rec("firstName") = "NA"
                    rec("lastName") = "NA"
                End If

                ' rec("firstName") = IIf(name.IndexOf(" ") <> -1, name.Substring(0, name.IndexOf(" ")), "No ") '"kirtikumar" '
                '  rec("lastName") = IIf(name.IndexOf(" ") + 1 <> -1, name.Substring(name.IndexOf(" ") + 1), "No ") '""
                rec("emailAddress") = ds.Tables(0).Rows(j).Item("cti_Email").ToString '"kirtikumar.techsture@gmail.com" '
                rec("byEmail") = "1"
                rec("sendEmailConfirmation") = "1"

                ' Optional Guest Card Data
                rec("guestCardDate") = DateTime.Now().ToString("yyyy-MM-dd")
                rec("comments") = ds.Tables(0).Rows(j).Item("cti_Message").ToString '"This is test please ignore it" '
                rec("moveDate") = ""
                ' Dim phone As String = Regex.Replace("dggg54", "[^0-9\-/]", "") 'ds.Tables(0).Rows(j).Item("cti_Phone").ToString
                Dim phone As String = Regex.Replace(ds.Tables(0).Rows(j).Item("cti_Phone").ToString, "[^0-9]", "") 'ds.Tables(0).Rows(j).Item("cti_Phone").ToString

                Dim Originalphone As String
                Dim extension As String
                If phone <> "" Then
                    If phone.First = "1" Or phone.First = "0" Then
                        phone = phone.Remove(0, 1)
                    End If
                    If phone.Length > 10 Then
                        Originalphone = phone.Substring(0, 10)
                        extension = phone.Substring(10)
                    Else
                        Originalphone = phone.Substring(0, phone.Length)
                        extension = ""
                    End If
                Else
                    Originalphone = "0000000000"
                    extension = ""
                End If

                rec("phone") = Originalphone  '"7575551212" '
                rec("extension") = extension
                rec("bedrooms") = ""
                rec("bathrooms") = ""

                'strXML = txtReq.Value
                req = System.Net.HttpWebRequest.Create(url)
                req.Method = "POST"

                'yvette changes start
                'System.Net.NetworkCredential nc = new System.Net.NetworkCredential("WeBuild", "W3Bu1ld");           
                'req.Credentials = nc;
                'CredentialCache MyCrendentialCache = new CredentialCache();
                'MyCrendentialCache.Add(url, "Basic", nc);
                'req.Credentials = MyCrendentialCache;
                'req.ContentType = "text/xml";
                req.ContentType = "application/x-www-form-urlencoded"
                Dim writer As New StreamWriter(req.GetRequestStream())
                Dim mystring As [String] = [String].Join("&", rec.OfType(Of DictionaryEntry)().[Select](Function(de) [String].Format("{0}={1}", HttpUtility.UrlEncode(de.Key.ToString()), HttpUtility.UrlEncode(de.Value.ToString()))).ToArray)


                writer.Write(mystring)
                writer.Close()
                ServicePointManager.ServerCertificateValidationCallback = Function() True

                'yvette changes end
                rsp = req.GetResponse()
                Dim responseStream As Stream = rsp.GetResponseStream()
                Dim reader As New StreamReader(responseStream)

                Dim str As String = reader.ReadToEnd
                ltrResponse.Text += str
                txtArea.InnerText += str

                Dim xmlDoc As New XmlDocument
                xmlDoc.LoadXml(str)

                Dim xmlNode As XmlNode
                xmlNode = xmlDoc.SelectSingleNode("response/command")
                txtArea.InnerText += xmlNode.Attributes("success").Value

                If xmlNode.Attributes("success").Value = "true" Then
                    Dim objUpdate As New CustomTabContent
                    objUpdate.ID = ds.Tables(0).Rows(j).Item("cti_Id")
                    objUpdate.SetGCPost()
                End If
            Next
        End If
    End Sub
End Class