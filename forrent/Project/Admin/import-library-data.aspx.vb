Imports System.Data
Imports System.IO
Imports BusinessAccessLayer.BusinessLayer
Imports DataAccessLayer.DataAccessLayer
Public Class import_library_data
    Inherits System.Web.UI.Page
    Dim strUploadPath As String = Server.MapPath("~" & ConfigurationManager.AppSettings("ImportsPath"))
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lnkLibraryCSVTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLibraryCSVTemplate.Click
        Response.AppendHeader("Content-disposition", "attachment; filename=csv-library-import-template.csv")
        Response.ContentType = "application/csv"
        Response.WriteFile(Server.MapPath("~") & ConfigurationManager.AppSettings("TemplatePath") & "csv-library-import-template.csv")
        Response.End()
    End Sub

    Private Sub lnkCategoryHelpCSVTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCategoryHelpCSVTemplate.Click
        Response.AppendHeader("Content-disposition", "attachment; filename=csv-category-help-template.csv")
        Response.ContentType = "application/csv"
        Response.WriteFile(Server.MapPath("~") & ConfigurationManager.AppSettings("TemplatePath") & "csv-category-help-template.csv")
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
            If row("LibraryTemplate").ToString().Trim.Length > 0 Then
                Dim objConn As New DALDataAccess()
                Try
                    objConn.AddCommand(CommandType.StoredProcedure, "prc_ImportLibraryCSVData")
                    objConn.AddParam("@Category", SqlDbType.Int, Left(row("Category").ToString().Trim(), 3))
                    objConn.AddParam("@LibraryImage", SqlDbType.VarChar, row("LibraryImage").ToString().Trim())
                    objConn.AddParam("@LibraryLink", SqlDbType.VarChar, row("LibraryLink").ToString().Trim())
                    objConn.AddParam("@LibraryTemplate", SqlDbType.VarChar, row("LibraryTemplate").ToString().Trim())
                    Dim strResult As String = objConn.ExecuteScalar()
                    If strResult <> "" Then
                        row("Reason") = strResult
                        strErrorRows = strErrorRows & row("__RowNumber").ToString() & ","
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