Imports System.IO
Imports System.Security.Cryptography
Imports System.Net
Namespace BusinessLayer
    Public Class Utils
        Inherits IRecord
        Private strKey As String = "jf20y5u34gt3f4l2"
        Private strIV As String = "jf20y5u34gt3f4l2"
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
End Namespace