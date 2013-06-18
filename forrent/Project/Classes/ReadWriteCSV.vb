Imports System.Data.OleDb
Imports DataAccessLayer.DataAccessLayer
Imports BusinessAccessLayer.BusinessLayer
Public Class ReadWriteCSV
    Public Shared Sub WriteCSV(ByVal strFileName As String, ByVal tbl As DataTable)
        Try

            '***************  Refer this link for better understanding of CSV *******************'
            'http://www.creativyst.com/Doc/Articles/CSV/CSV01.htm
            '************************************************************************************'

            Dim strResult As New StringBuilder()
            For Each col As DataColumn In tbl.Columns
                strResult.Append("""" + col.ColumnName.Replace("""", """""") + """,")
            Next
            strResult.Append(vbNewLine)
            'Dim objConn As New clsDAL
            For Each row As DataRow In tbl.Rows
                For Each col As DataColumn In tbl.Columns
                    Dim strValue As String = row(col.ColumnName).ToString()
                    If col.ColumnName.ToLower.Trim = "password" Then
                        strValue = Utility.Decryption(strValue)
                    End If
                    strResult.Append("""" + strValue.Replace("""", """""").Replace("Chr(10)", "") + """,")
                Next
                strResult.Append(vbNewLine)
            Next

            HttpContext.Current.Response.Expires = 0
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.ClearHeaders()
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" & strFileName & "")
            HttpContext.Current.Response.AddHeader("Content-type", "text/csv")
            HttpContext.Current.Response.Write(strResult.ToString())
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function ReadCSV(ByVal strFilePath As String) As DataSet

        '***************  Refer this link for better understanding of CSV *******************'
        'http://www.creativyst.com/Doc/Articles/CSV/CSV01.htm
        '************************************************************************************'

        Dim objXConn As OleDbConnection = Nothing
        Try
            Dim fi As New IO.FileInfo(strFilePath)

            ' Refer this site for Connection String for Ole Db textfile http://www.connectionstrings.com/
            Dim strExcelConn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                          "Data Source=" & fi.DirectoryName & ";" & _
                              "Extended Properties=""text;HDR=YES;FMT=TabDelimited"";"
            objXConn = New OleDbConnection(strExcelConn)
            objXConn.Open()
            Dim objCommand As New OleDbCommand("SELECT * FROM [" & fi.Name & "]", objXConn)
            Dim objDataAdapter As New OleDbDataAdapter()
            objDataAdapter.SelectCommand = objCommand
            Dim objDataSet As New DataSet()
            objDataAdapter.Fill(objDataSet)
            Return objDataSet
        Catch ex As Exception
            Throw ex
        Finally
            If objXConn IsNot Nothing Then
                If objXConn.State = ConnectionState.Open Then
                    objXConn.Close()
                End If
            End If
        End Try
    End Function
End Class
