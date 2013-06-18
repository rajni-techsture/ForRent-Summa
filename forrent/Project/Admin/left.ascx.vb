Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer
Public Class left1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        '    Dim ds As New DataSet
        '    Dim objBAL As New BALSchedulePost
        '    objBAL.FBUserId = Session("FacebookUserId")
        '    ds = objBAL.GetAllDrafts
        '    Dim cnt As String
        '    If ds.Tables(1).Rows.Count > 0 Then
        '        ' ltrdrafts.Text = ds.Tables(1).Rows.Count
        '    Else
        '        '  ltrdrafts.Text = ""
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

End Class