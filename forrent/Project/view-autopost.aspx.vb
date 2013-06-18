Imports BusinessAccessLayer.BusinessLayer
Public Class view_autopost
    Inherits System.Web.UI.Page
    Dim objAPConfig As New AutoPostConfig
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoginCheck.LoginSessionCheck()
        If Not Page.IsPostBack Then
            GetAutoPostConfig()
        End If
    End Sub

    Sub GetAutoPostConfig()
        objAPConfig.FBUserID = FBUserID()
        Dim ds As DataSet
        ds = objAPConfig.GetAutoPostConfigForUser()
        If ds.Tables(0).Rows.Count > 0 Then


            If Session("FinalFanPages") IsNot Nothing Then
                Dim forrentfanpages As New List(Of String)
                forrentfanpages = Session("FinalFanPages")

                Dim dtTable As New DataTable
                dtTable.Columns.Add(New DataColumn("id", Type.GetType("System.Int32")))
                dtTable.Columns.Add(New DataColumn("PageId", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("PageName", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("PageUrl", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("UpdatedBy", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("Notification", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("Status", Type.GetType("System.Int32")))
                dtTable.Columns.Add(New DataColumn("StartDate", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("time", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("timezone", Type.GetType("System.String")))
                dtTable.Columns.Add(New DataColumn("UpdatedDate", Type.GetType("System.String")))

                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For j As Integer = 0 To forrentfanpages.Count - 1
                        If ds.Tables(0).Rows(i).Item("PageUrl").ToString().ToLower = forrentfanpages.Item(j).ToString.ToLower Then
                            Dim dtRow1 As DataRow = dtTable.NewRow
                            dtRow1("id") = ds.Tables(0).Rows(i).Item("id")
                            dtRow1("PageId") = ds.Tables(0).Rows(i).Item("PageId").ToString
                            dtRow1("PageName") = ds.Tables(0).Rows(i).Item("PageName").ToString
                            dtRow1("PageUrl") = ds.Tables(0).Rows(i).Item("PageUrl").ToString
                            dtRow1("UpdatedBy") = ds.Tables(0).Rows(i).Item("UpdatedBy").ToString
                            dtRow1("Notification") = ds.Tables(0).Rows(i).Item("Notification")
                            dtRow1("Status") = ds.Tables(0).Rows(i).Item("Status")
                            dtRow1("StartDate") = ds.Tables(0).Rows(i).Item("StartDate").ToString
                            dtRow1("time") = ds.Tables(0).Rows(i).Item("time").ToString
                            dtRow1("timezone") = ds.Tables(0).Rows(i).Item("timezone").ToString
                            dtRow1("UpdatedDate") = ds.Tables(0).Rows(i).Item("UpdatedDate").ToString
                            dtTable.Rows.Add(dtRow1)
                            'Exit For
                        ElseIf ds.Tables(0).Rows(i).Item("PageId").ToString().ToLower = forrentfanpages.Item(j).ToString.ToLower Then
                            Dim dtRow1 As DataRow = dtTable.NewRow
                            dtRow1("id") = ds.Tables(0).Rows(i).Item("id")
                            dtRow1("PageId") = ds.Tables(0).Rows(i).Item("PageId").ToString
                            dtRow1("PageName") = ds.Tables(0).Rows(i).Item("PageName").ToString
                            dtRow1("PageUrl") = ds.Tables(0).Rows(i).Item("PageUrl").ToString
                            dtRow1("UpdatedBy") = ds.Tables(0).Rows(i).Item("UpdatedBy").ToString
                            dtRow1("Notification") = ds.Tables(0).Rows(i).Item("Notification")
                            dtRow1("Status") = ds.Tables(0).Rows(i).Item("Status")
                            dtRow1("StartDate") = ds.Tables(0).Rows(i).Item("StartDate").ToString
                            dtRow1("time") = ds.Tables(0).Rows(i).Item("time").ToString
                            dtRow1("timezone") = ds.Tables(0).Rows(i).Item("timezone").ToString
                            dtRow1("UpdatedDate") = ds.Tables(0).Rows(i).Item("UpdatedDate").ToString
                            dtTable.Rows.Add(dtRow1)
                        End If
                    Next
                Next

                
                'Response.End()
                dtTable.TableName = "fanpages"
                Dim dv As DataView = New DataView(dtTable)
                dv.Sort = "PageName"

                If dv.Count > 0 Then
                    rptPages.DataSource = dv
                    rptPages.DataBind()
                    plcNoData.Visible = False
                    plcData.Visible = True
                    'Else
                    '    Dim strUrl As String = "Login.aspx?i=" & Session("Industry") & "&c=" & Session("company") & "&u=2&at=" & Session("hdnToken") & ""
                    '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";ShowHide13;", ";openNewWin('" & strUrl & "');", True)
                Else
                    rptPages.DataSource = Nothing
                    rptPages.DataBind()
                    'ltrMsg.Text = "No business Pages Found!"
                    plcData.Visible = False
                    plcNoData.Visible = True
                End If
            Else
                rptPages.DataSource = ds.Tables(0)
                rptPages.DataBind()
            End If
        Else
            rptPages.DataSource = Nothing
            rptPages.DataBind()
            plcData.Visible = False
            plcNoData.Visible = True
        End If
    End Sub

    Function FBUserID() As String
        Return IIf(Session("FacebookUserId") <> Nothing, Session("FacebookUserId"), "")
    End Function

    Sub TurnOnnOffAutoPost(sender As Object, e As CommandEventArgs)
        Dim objBAL As New BALSchedulePost
        Dim dsAutoPostOnOf As New DataSet
        objBAL.FBUserId = Session("FacebookUserId")
        objBAL.TSMAUserId = Session("SiteUserId")
        objBAL.FBPageId = e.CommandName
        objBAL.CompanyId = GetSetCookies.GetCookie("CompanyId")
        objBAL.IndustryId = GetSetCookies.GetCookie("IndustryId")
        dsAutoPostOnOf = objBAL.AutoPostTurnOnOff()
        ltrMsg.Text = "Auto Post Status Changed Successfully."
        GetAutoPostConfig()
    End Sub

    Sub ConfigureAutoPost(sender As Object, e As CommandEventArgs)
        Session("PageIds") = e.CommandName
        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, ";TransferPage;", ";OpenWindow();", True)
        Response.Redirect("configure-autopost")
    End Sub

    Private Sub rptPages_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptPages.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.DataItem, DataRowView)("timeZone") <> "" AndAlso CType(e.Item.DataItem, DataRowView)("timeZone") <> "--" Then

                Dim strDateOriginal As DateTime = CType(e.Item.DataItem, DataRowView)("StartDate") & " " & CType(e.Item.DataItem, DataRowView)("Time")

                Dim strDate1 As DateTime
                Dim strConvertToOriginalDate As DateTime
                Dim strShortDate As String
                Dim strActivationHours As String
                Dim strActivationMinutes As String
                Dim strAMPM As String = "0"
                Dim strDate As String = ""

                If CType(e.Item.DataItem, DataRowView)("timeZone") <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                    If CType(e.Item.DataItem, DataRowView)("PageId") = "117027194989273" Or CType(e.Item.DataItem, DataRowView)("PageId") = "138276769599341" Then
                        strConvertToOriginalDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal.AddHours(1), ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("timeZone")).ToString()
                    Else
                        strConvertToOriginalDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(strDateOriginal, ConfigurationManager.AppSettings("ServerTimeZone"), CType(e.Item.DataItem, DataRowView)("timeZone")).ToString()
                    End If
                Else
                    strConvertToOriginalDate = strDateOriginal
                End If

                strDate1 = strConvertToOriginalDate 'If((strConvertToOriginalDate <> ""), Convert.ToDateTime(strConvertToOriginalDate), Date.Now)
                strShortDate = strDate1.Date
                strActivationHours = Integer.Parse(strDate1.ToString("hh")).ToString()
                strActivationMinutes = strDate1.Minute.ToString
                If strActivationMinutes = "0" Then
                    strActivationMinutes = "00"
                Else
                    strActivationMinutes = strActivationMinutes
                End If
                strAMPM = strDate1.ToString("tt")
                CType(e.Item.FindControl("lblAutoPostDate"), HtmlGenericControl).InnerText = strShortDate
                CType(e.Item.FindControl("lblAutoPostTime"), HtmlGenericControl).InnerText = strActivationHours & ":" & strActivationMinutes & " " & strAMPM
            Else
                CType(e.Item.FindControl("lblAutoPostDate"), HtmlGenericControl).InnerText = "--"
                CType(e.Item.FindControl("lblAutoPostTime"), HtmlGenericControl).InnerText = "--"
            End If
        End If
    End Sub
End Class