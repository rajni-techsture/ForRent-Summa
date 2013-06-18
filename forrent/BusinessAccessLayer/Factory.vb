Imports System
Imports DataAccessLayer.DataAccessLayer
Imports System.Data
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Reflection
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Win32
Imports System.Web
Imports System.Configuration
Imports System.Threading
Namespace BusinessLayer
    Public Class Factory
#Region "Variables"
        Private Shared _mutex As New Mutex()
        Private Shared _instance As Factory = Nothing
#End Region

#Region "Constructor"
        Protected Sub New()
        End Sub
#End Region

#Region "Get Instance"
        Public Shared Function GetInstance() As Factory
            Try
                _mutex.WaitOne()
                If (_instance Is Nothing) Then
                    _instance = New Factory()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _mutex.ReleaseMutex()
            End Try
            Return _instance
        End Function
#End Region

#Region "Get Record - This function has to be invoked in-order to Fetch a record."
        'Creates a new Record of the type specified, loads it using the criteria specified and returns the same.
        Public Function GetRecord(recordType As RecordType, criteria As Criteria) As IRecord
            Try
                Dim a As Assembly = Assembly.GetExecutingAssembly()
                Dim type__1 As Type = Type.[GetType]("BusinessLayer." + recordType.ToString())
                Dim obj As [Object] = Activator.CreateInstance(type__1)
                Dim mInfo As MethodInfo = type__1.GetMethod("Load")
                mInfo.Invoke(obj, New Criteria(0) {criteria})
                Dim record As IRecord = DirectCast(obj, IRecord)
                Return record
            Catch ex As Exception
                LogError(ex, "Factory.GetRecord", True)
                Return Nothing
            Finally
            End Try
        End Function
#End Region

#Region "Save Record - This function has to be invoked in-order to Save a record."
        'This method has to be invoked in-order to save a record.
        Public Function SaveRecord(record As IRecord) As IRecord
            Try
                'record.Save()
                Return record
            Catch ex As Exception
                LogError(ex, "Factory.SaveRecord", True)
                Return Nothing
            Finally
            End Try
        End Function
#End Region

#Region "Delete Record - This function has to be invoked in-order to Delete a record"
        'This method has to be invoked in-order to delete a record.
        Public Function DeleteRecord(record As IRecord) As Boolean
            Try
                record.Delete()
                If record.IsDeleted = True Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                LogError(ex, "Factory.DeleteRecord", True)
                Return False
            Finally
            End Try
        End Function
#End Region

#Region "Site Tracking"
        Private Sub MemberSiteTrackingload(memId As Integer)
            Try

                Dim st As New SiteTracker()
                st.IsNew = True
                st.MemberTrackCode = memId
                st.FunctionName = "Logined"

                st = DirectCast(SaveRecord(st), SiteTracker)
            Catch ex As Exception
                Factory.LogError(ex, "Factory-MemberSiteTrackingload()", True)
                Throw
            Finally
            End Try
        End Sub
        Public Sub SiteTrackingUser(MemId As Integer, name As String, NewValues As Hashtable, oldValues As Hashtable)
            Try
                Dim st As New SiteTracker()
                st.IsNew = True
                Dim myEnumerator As IDictionaryEnumerator = NewValues.GetEnumerator()
                Dim myEnumeratorold As IDictionaryEnumerator = oldValues.GetEnumerator()
                While myEnumerator.MoveNext()
                    st.UserCode = MemId
                    st.FunctionName = name
                    st.FunctionDetail = myEnumerator.Key.ToString()
                    st.NewValue = Convert.ToString(myEnumerator.Value)
                    If myEnumeratorold.MoveNext() Then
                        st.OldValue = Convert.ToString(myEnumeratorold.Value)
                    End If

                    st = DirectCast(SaveRecord(st), SiteTracker)

                End While
            Catch ex As Exception
                Factory.LogError(ex, "Factory-SitetrackingUser()", True)

                Throw
            Finally
            End Try
        End Sub
        Public Sub SiteTrackingMember(MemId As Integer, name As String, NewValues As Hashtable, oldValues As Hashtable)
            Try
                Dim st As New SiteTracker()
                st.IsNew = True
                Dim myEnumerator As IDictionaryEnumerator = NewValues.GetEnumerator()
                Dim myEnumeratorold As IDictionaryEnumerator = oldValues.GetEnumerator()
                While myEnumerator.MoveNext()
                    st.MemberTrackCode = MemId
                    st.FunctionName = name
                    st.FunctionDetail = myEnumerator.Key.ToString()
                    st.NewValue = Convert.ToString(myEnumerator.Value)
                    If myEnumeratorold.MoveNext() Then
                        st.OldValue = Convert.ToString(myEnumeratorold.Value)
                    End If

                    st = DirectCast(SaveRecord(st), SiteTracker)

                End While
            Catch ex As Exception
                Factory.LogError(ex, "Factory-SitetrackingMember()", True)

                Throw
            Finally
            End Try
        End Sub
        Public Sub SiteTrackingNewUser(MemId As Integer, name As String, NewValues As Hashtable)
            Try

                Dim st As New SiteTracker()
                st.IsNew = True

                Dim myEnumerator As IDictionaryEnumerator = NewValues.GetEnumerator()
                While myEnumerator.MoveNext()
                    st.UserCode = MemId
                    st.FunctionName = name
                    st.FunctionDetail = myEnumerator.Key.ToString()
                    st.NewValue = Convert.ToString(myEnumerator.Value)
                    st = DirectCast(SaveRecord(st), SiteTracker)

                End While
            Catch ex As Exception
                Factory.LogError(ex, "Factory-SiteTrackingNewUser()", True)

                Throw
            Finally
            End Try
        End Sub
        Public Sub SiteTrackingNewMember(MemId As Integer, name As String, NewValues As Hashtable)
            Try

                Dim st As New SiteTracker()
                st.IsNew = True
                Dim myEnumerator As IDictionaryEnumerator = NewValues.GetEnumerator()
                While myEnumerator.MoveNext()
                    st.MemberTrackCode = MemId
                    st.FunctionName = name
                    st.FunctionDetail = myEnumerator.Key.ToString()
                    st.NewValue = Convert.ToString(myEnumerator.Value)
                    st = DirectCast(SaveRecord(st), SiteTracker)

                End While
            Catch ex As Exception
                Factory.LogError(ex, "Factory-SiteTrackingNewMember()", True)

                Throw
            Finally
            End Try
        End Sub
        Public Sub SiteTrackingUserCommon(usercode As Integer, functionname As String, IP As String)
            Dim st As New SiteTracker()
            st.IsNew = True
            st.UserCode = usercode
            st.FunctionName = functionname
            st.IPAddress = IP
            st = DirectCast(SaveRecord(st), SiteTracker)

        End Sub
        Public Sub SiteTrackingMemberCommon(usercode As Integer, functionname As String, IP As String)
            Dim st As New SiteTracker()
            st.IsNew = True
            st.MemberTrackCode = usercode
            st.FunctionName = functionname
            st.IPAddress = IP
            st = DirectCast(SaveRecord(st), SiteTracker)
        End Sub
#End Region

#Region "Update Member Status"
        Public Sub UpdateMemberStatus(membercode As Integer, status As Integer)
            Try
                Dim dataAccess As New DALDataAccess()

                dataAccess.AddCommand(CommandType.StoredProcedure, "sp_Update_MemberStatus1")
                dataAccess.AddParam("@MM_MemberCode", SqlDbType.Int, membercode)
                dataAccess.AddParam("@status", SqlDbType.Int, status)


                dataAccess.ExecuteNonQuery()
            Catch ex As Exception

                Factory.LogError(ex, "Factory.UpdateMemberStatus", True)
            Finally
            End Try
        End Sub
#End Region

#Region "Encrypt/Decrypt"
        Public Shared Function Encrypt(input As String, key As String) As String

            Dim des As TripleDESCryptoServiceProvider = Nothing
            Dim hashmd5 As MD5CryptoServiceProvider
            Dim pwdhash As Byte(), buff As Byte()
            Try
                Dim result As String
                hashmd5 = New MD5CryptoServiceProvider()
                pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key))
                hashmd5 = Nothing
                des = New TripleDESCryptoServiceProvider()
                des.Key = pwdhash
                des.Mode = CipherMode.ECB
                'CBC, CFB
                buff = ASCIIEncoding.ASCII.GetBytes(input)
                result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length))
                Return result
            Finally
                If des IsNot Nothing Then
                    des.Clear()
                    des = Nothing
                End If
            End Try
        End Function

        Public Shared Function Decrypt(input As String, key As String) As String

            Dim des As TripleDESCryptoServiceProvider = Nothing
            Dim hashmd5 As MD5CryptoServiceProvider
            Dim pwdhash As Byte(), buff As Byte()
            Try
                Dim result As String
                hashmd5 = New MD5CryptoServiceProvider()
                pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key))
                hashmd5 = Nothing
                des = New TripleDESCryptoServiceProvider()
                des.Key = pwdhash
                des.Mode = CipherMode.ECB
                'CBC, CFB
                buff = Convert.FromBase64String(input)
                result = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length))
                Return result
            Finally
                If des IsNot Nothing Then
                    des.Clear()
                    des = Nothing
                End If
            End Try
        End Function
#End Region

#Region "Error Logging"

        Public Shared Sub LogError(e As Exception, strErrorMethod As String, bolLogError As Boolean)
            DALUtility.LogError(e, strErrorMethod, bolLogError)
        End Sub

        Public Shared Sub SetErrorLogPath(strPath As String)
            DALUtility.FilePath = strPath
        End Sub
#End Region

    End Class
End Namespace
