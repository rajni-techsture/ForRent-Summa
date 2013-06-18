Imports System.Data
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer
Imports DataAccessLayer.DataAccessLayer
Public Class import_bulk_data
    Inherits System.Web.UI.Page
    Dim strUploadPath As String = Server.MapPath("~" & ConfigurationManager.AppSettings("ImportsPath"))
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Write(Date.Now() & "<br/>")
        'Response.Write(Date.Now().ToString("MM/dd/yyyy"))
    End Sub

    Private Sub lnkLibraryCSVTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLibraryCSVTemplate.Click
        Response.AppendHeader("Content-disposition", "attachment; filename=tsma-bulk-upload.csv")
        Response.ContentType = "application/csv"
        Response.WriteFile(Server.MapPath("~") & ConfigurationManager.AppSettings("TemplatePath") & "tsma-bulk-upload.csv")
        Response.End()
    End Sub

    Private Sub lnkCategoryHelpCSVTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCategoryHelpCSVTemplate.Click
        Response.AppendHeader("Content-disposition", "attachment; filename=csv-timezone-help.csv")
        Response.ContentType = "application/csv"
        Response.WriteFile(Server.MapPath("~") & ConfigurationManager.AppSettings("TemplatePath") & "csv-timezone-help.csv")
        Response.End()
    End Sub

    Private Sub btnImportFile_ServerClick(sender As Object, e As System.EventArgs) Handles btnImportFile.ServerClick
        Dim strExt As String = ""
        If Trim(flProducts.Value) <> "" Then
            strExt = System.IO.Path.GetExtension(flProducts.PostedFile.FileName).ToLower
            If strExt = ".csv" Then
                ImportCSVLibraryData()
            Else
                ltrMsg.Text = "You can only import .CSV file"
            End If
        Else
            ltrMsg.Text = "Please select the file to import"
        End If
    End Sub

#Region "import CSV Customer Data"
    Sub ImportCSVLibraryData()

        Dim strFile As String = CStr(Day(Now)) & CStr(Month(Now)) & CStr(Year(Now)) & CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now)) & ".csv"
        ViewState("strFileName") = strFile
        flProducts.PostedFile.SaveAs(strUploadPath & strFile)

        Dim ds As DataSet = ReadWriteCSV.ReadCSV(strUploadPath & strFile)

        Try
            If IO.File.Exists(strUploadPath & strFile) Then
                IO.File.Delete(strUploadPath & strFile)
            End If
        Catch ex As Exception
        End Try

        Try


            ds.Tables(0).Columns.Add(New DataColumn("Reason", Type.GetType("System.String")))
            ds.Tables(0).Columns.Add(New DataColumn("__RowNumber", Type.GetType("System.Int32")))
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ds.Tables(0).Rows(i).Item("__RowNumber") = i + 1
            Next
            Dim strErrorRows As String = ""
            ImportLibraries(strErrorRows, ds)
            If strErrorRows.Trim.Length > 0 Then
                strErrorRows = strErrorRows + "0"
                Dim dv As DataView = ds.Tables(0).DefaultView
                dv.RowFilter = "__RowNumber in (" + strErrorRows + ")"

                grdErrorCustomer.DataSource = dv
                grdErrorCustomer.DataBind()

                tblCustomerError.Visible = True
                ltrMsg.Text = ""
            Else
                tblCustomerError.Visible = False
                ltrMsg.Text = "Data imported successfully."
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try

    End Sub

    Sub ImportLibraries(ByRef strErrorRows As String, ByRef ds As DataSet)

        For Each row As DataRow In ds.Tables(0).Rows
            If row("FBUserEmail").ToString().Trim.Length > 0 Then
                Dim objConn As New DALDataAccess()
                Try
                    Dim strResult As String
                    If row("Timezone").ToString().Trim() <> "" Then
                        Dim searchString As String = row("Timezone").ToString().Trim()
                        If ddlAutoPostTimeZone.Items.FindByValue(searchString) IsNot Nothing Then
                            Dim objBAL As New BALSchedulePost
                            Dim dtAutoPostDate As DateTime
                            Dim strDate1 As DateTime
                            Dim strConvertToOriginalDate As DateTime
                            Dim strShortDate As String
                            Dim strActivationHours As String
                            Dim strActivationMinutes As String
                            Dim strAMPM As String = "0"
                            Dim strDate As DateTime
                            'Response.Write(Convert.ToDateTime(row("StartDate")).ToString("MM/dd/yyyy"))
                            'dtAutoPostDate = DateTime.Parse("07/30/2012" & " " & row("Hour") & ":" & row("Minute") & ":00 " & row("AMPM"))
                            'dtAutoPostDate = "30/07/2012 1:51:49 PM" 'Date.Now.ToString("MM/dd/yyyy") & " " & row("Hour") & ":" & row("Minute") & ":00 " & row("AMPM")
                            dtAutoPostDate = Convert.ToDateTime(row("StartDate")) & " " & row("Hour") & ":" & row("Minute") & ":00 " & row("AMPM")

                            If row("Timezone").ToString().Trim() <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                                strDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(dtAutoPostDate), row("Timezone").ToString().Trim(), ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
                            Else
                                strDate = dtAutoPostDate
                            End If

                            
                            'Response.Write("Time Difference (seconds): " & span.Seconds & "<br/>")
                            'Response.Write("Time Difference (minutes): " & span.Minutes & "<br/>")
                            'Response.Write("Time Difference (hours): " & span.Hours & "<br/>")
                            'Response.Write("Time Difference (days): " & span.Days & "<br/>")
                            'Response.End()

                            If strDate.Date = Date.Now.Date Then
                                Dim startTime As DateTime = DateTime.Now
                                Dim endTime As DateTime = strDate
                                Dim span As TimeSpan = endTime.Subtract(startTime)
                                If span.Minutes <= 5 Then
                                    strDate = Date.Now.AddDays(1).ToString("MM/dd/yyyy") & " " & row("Hour") & ":" & row("Minute") & ":00 " & row("AMPM")
                                Else
                                    strDate = dtAutoPostDate
                                End If
                            Else
                                If Convert.ToDateTime(strDate) < Date.Now Then
                                    strDate = Date.Now.AddDays(1).ToString("MM/dd/yyyy") & " " & row("Hour") & ":" & row("Minute") & ":00 " & row("AMPM")
                                Else
                                    strDate = dtAutoPostDate
                                End If
                            End If


                            If row("Timezone").ToString().Trim() <> "" Then
                                If row("Timezone").ToString().Trim() <> ConfigurationManager.AppSettings("ServerTimeZone") Then
                                    strConvertToOriginalDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(strDate), row("Timezone").ToString().Trim(), ConfigurationManager.AppSettings("ServerTimeZone")).ToString()
                                Else
                                    strConvertToOriginalDate = strDate
                                End If
                            End If

                            strDate1 = strConvertToOriginalDate 'If((strConvertToOriginalDate <> ""), Convert.ToDateTime(strConvertToOriginalDate), Date.Now)
                            strShortDate = strDate1.Date
                            strActivationHours = Integer.Parse(strDate1.ToString("hh")).ToString()
                            strActivationMinutes = strDate1.Minute.ToString
                            strAMPM = strDate1.ToString("tt")

                            objConn.AddCommand(CommandType.StoredProcedure, "prc_ImportBulkAutopostOrSweepstakeCSVData")
                            objConn.AddParam("@FileName", SqlDbType.VarChar, If(ViewState("strFileName") <> "", ViewState("strFileName"), ""))
                            objConn.AddParam("@FBUserEmail", SqlDbType.VarChar, row("FBUserEmail").ToString().Trim())
                            objConn.AddParam("@FBUserName", SqlDbType.VarChar, row("FBUserName").ToString().Trim())
                            objConn.AddParam("@FBPageLink", SqlDbType.VarChar, row("FBPageLink").ToString().Trim())
                            objConn.AddParam("@StartDate", SqlDbType.Date, strShortDate)
                            objConn.AddParam("@Hour", SqlDbType.Int, Convert.ToInt32(strActivationHours))
                            objConn.AddParam("@Minute", SqlDbType.Int, Convert.ToInt32(strActivationMinutes))
                            objConn.AddParam("@AMPM", SqlDbType.VarChar, strAMPM)
                            objConn.AddParam("@Timezone", SqlDbType.VarChar, row("Timezone").ToString().Trim())
                            objConn.AddParam("@TurnAutopostOn", SqlDbType.VarChar, row("TurnAutopostOn").ToString().Trim())
                            objConn.AddParam("@ReplaceAutopost", SqlDbType.VarChar, row("ReplaceAutopost").ToString().Trim())
                            objConn.AddParam("@TurnAutopostOff", SqlDbType.VarChar, row("TurnAutopostOff").ToString().Trim())
                            objConn.AddParam("@AddSweepstakes", SqlDbType.VarChar, row("AddSweepstakes").ToString().Trim())
                            objConn.AddParam("@RemoveSweepstakes", SqlDbType.VarChar, row("RemoveSweepstakes").ToString().Trim())
                            strResult = objConn.ExecuteScalar()
                            If strResult <> "" AndAlso strResult <> "1" AndAlso strResult <> "0" Then
                                row("Reason") = strResult
                                strErrorRows = strErrorRows & row("__RowNumber").ToString() & ","
                            End If
                        Else
                            strResult = "Incorrect timezone id: " & row("Timezone").ToString().Trim()
                            If strResult <> "" Then
                                row("Reason") = strResult
                                strErrorRows = strErrorRows & row("__RowNumber").ToString() & ","
                            End If
                        End If
                        End If
                Catch ex As Exception
                    row("Reason") = ex.Message
                    strErrorRows = strErrorRows & row("__RowNumber").ToString() & ","
                End Try
            End If
        Next
    End Sub
#End Region

    'Private Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
    '    Response.AppendHeader("Content-disposition", "attachment; filename=rules.pdf")
    '    Response.ContentType = "application/octet-stream"
    '    Response.WriteFile(Server.MapPath("~") & ConfigurationManager.AppSettings("TemplatePath") & "rules.pdf")
    '    Response.End()
    'End Sub
End Class