Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Transactions
Imports tsmaConn
Imports System.Configuration
Imports System.Net
Imports Facebook
Imports Facebook.Schema
Imports Facebook.Utility
Imports Facebook.Session

Public Class clConn
    Private myConn As SqlConnection = Nothing
    Private strKey As String = "jf20y5u34gt3f4l2"
    Private strIV As String = "jf20y5u34gt3f4l2"
    Private CONNECTION_STRING As String = ""
   
    Sub New()
        CONNECTION_STRING = New tsmaConn.tsmaConn().GetConn
    End Sub

    Public Function GetSqlParam(ByVal Name As String, ByVal Type As SqlDbType, ByVal Size As Integer, ByVal Value As String) As SqlClient.SqlParameter
        Dim sqlParam As SqlParameter = Nothing
        If Size = -1 Then
            sqlParam = New SqlParameter(Name, Type)
            sqlParam.Value = Value
            Return sqlParam
        Else
            sqlParam = New SqlParameter(Name, Type, Size)
            sqlParam.Value = Value
            Return sqlParam
        End If
    End Function

    Public Function GetSqlParam(ByVal Name As String, ByVal Type As SqlDbType, ByVal Value As String) As SqlClient.SqlParameter
        Dim sqlParam As SqlParameter = Nothing
        sqlParam = New SqlParameter(Name, Type)
        sqlParam.Value = Value
        Return sqlParam
    End Function

    Public Sub ExecuteSQL(ByVal ProcedureName As String, ByVal ParamArray sqlParamList() As SqlParameter)
        Try
            Using scope As TransactionScope = New TransactionScope()

                Using myConn As New SqlConnection(CONNECTION_STRING)
                    Using cmd As New SqlCommand(ProcedureName, myConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        If sqlParamList IsNot Nothing Then
                            For Each sqlParam As SqlParameter In sqlParamList
                                cmd.Parameters.Add(sqlParam)
                            Next
                        End If
                        myConn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                scope.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function QuerySQL(ByVal ProcedureName As String, ByVal ParamArray sqlParamList() As SqlParameter) As DataSet
        Dim ds As New DataSet
        Try
            Using scope As TransactionScope = New TransactionScope()

                Using myConn As New SqlConnection(CONNECTION_STRING)
                    Using cmd As New SqlCommand(ProcedureName, myConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        If sqlParamList IsNot Nothing Then
                            For Each sqlParam As SqlParameter In sqlParamList
                                cmd.Parameters.Add(sqlParam)
                            Next
                        End If
                        myConn.Open()
                        Dim sqlDA As New SqlDataAdapter(cmd)
                        sqlDA.Fill(ds)
                    End Using
                End Using

                scope.Complete()
            End Using

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function QueryScalarSQL(ByVal ProcedureName As String, ByVal ParamArray sqlParamList() As SqlParameter) As Object
        Dim objResult As Object = Nothing
        Try

            Using scope As TransactionScope = New TransactionScope()

                Using myConn As New SqlConnection(CONNECTION_STRING)
                    Using cmd As New SqlCommand(ProcedureName, myConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        If sqlParamList IsNot Nothing Then
                            For Each sqlParam As SqlParameter In sqlParamList
                                cmd.Parameters.Add(sqlParam)
                            Next
                        End If
                        myConn.Open()
                        objResult = cmd.ExecuteScalar()
                    End Using
                End Using

                scope.Complete()
            End Using

            Return objResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Encryption(ByVal str As String) As String
        If str.Length = 0 Then Return str

        Using objMemoryStream As New MemoryStream()
            Dim btKey As Byte() = System.Text.Encoding.ASCII.GetBytes(strKey)
            Dim btIV As Byte() = System.Text.Encoding.ASCII.GetBytes(strIV)
            Dim objRMCrypto As New RijndaelManaged()

            Using objCryptStream As New CryptoStream(objMemoryStream, objRMCrypto.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write)
                Using objStreamWriter As New StreamWriter(objCryptStream)
                    objStreamWriter.Write(str)
                End Using
            End Using

            Dim strEncrypted As New System.Text.StringBuilder()
            Dim btValue As Byte() = objMemoryStream.ToArray()
            For i As Integer = 0 To btValue.Length - 1
                If i <> btValue.Length - 1 Then
                    strEncrypted.Append(btValue(i) & " ")
                Else
                    strEncrypted.Append(btValue(i))
                End If
            Next

            Return strEncrypted.ToString()
        End Using
    End Function

    Public Function Decryption(ByVal str As String) As String
        If str.Length = 0 Then Return ""

        Dim strDecrypted As String = ""

        Dim btValue As Byte() = stringToByteArray(str)
        Dim btKey As Byte() = System.Text.Encoding.ASCII.GetBytes(strKey)
        Dim btIV As Byte() = System.Text.Encoding.ASCII.GetBytes(strIV)

        Using objMemoryStream As New MemoryStream(btValue)
            Dim objRMCrypto As New RijndaelManaged()

            Using objCryptStream As New CryptoStream(objMemoryStream, objRMCrypto.CreateDecryptor(btKey, btIV), CryptoStreamMode.Read)
                Using objStreamReader As New StreamReader(objCryptStream)
                    strDecrypted = objStreamReader.ReadToEnd()
                End Using
            End Using
        End Using

        Return strDecrypted
    End Function

    Public Function stringToByteArray(ByVal str As String) As Byte()
        Dim strValues As String() = str.Split(" ")
        Dim btArray(strValues.Length - 1) As Byte
        For i As Integer = 0 To strValues.Length - 1
            btArray(i) = Convert.ToByte(strValues(i))
        Next
        Return btArray
    End Function


End Class
