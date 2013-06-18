Imports System
Imports System.Web
Imports DataAccessLayer.DataAccessLayer
Imports System.Data


Namespace BusinessLayer
    Public Class BALWeeklyTipsFront
        Inherits IRecord

#Region "Get Weekly Tips At Home Page Front"
        Public Function GetweeklyTipsFront() As DataSet
            ' Try
            'Dim objEncDec As New Utility
            Dim dataAccess As New DALDataAccess()
            Dim ds As New DataSet
            dataAccess.AddCommand(CommandType.StoredProcedure, "prc_GetWeeklyTipsFront")
            ds = dataAccess.GetDataset()
            Return ds

        End Function

#End Region
    End Class
End Namespace