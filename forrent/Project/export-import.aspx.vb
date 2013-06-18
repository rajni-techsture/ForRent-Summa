Imports System.IO
Imports System.Xml

Partial Public Class export_import
    Inherits System.Web.UI.Page
    Dim objConn As New clsDAL
    Dim strUploadPath As String = Server.MapPath("~" & ConfigurationManager.AppSettings("ImportsPath"))
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            pnlProducts.Visible = True
            pnlCustomers.Visible = False
            pnlOrders.Visible = False
            BindCategories()
            BindAllVendors()
            ltrMsg.Text = ""
        Else
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "setTab", ";$(function() {$('#tabs').tabs();});setTab();", True)
        End If
        rdoProductsImport.Attributes.Add("onClick", "SetTemplate(1);")
        rdoCustomersImport.Attributes.Add("onClick", "SetTemplate(2);")
    End Sub

    Private Sub BindCategories()
        Dim Parameters(3, 0) As String
        Dim ds As DataSet = objConn.QuerySQL("prc_GetAllActiveCategories", Parameters)
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                rptCategories.DataSource = ds.Tables(0)
                rptCategories.DataBind()
            Else
                rptCategories.DataSource = Nothing
                rptCategories.DataBind()
            End If
        End If
    End Sub

    Private Sub BindAllVendors()
        Dim Parameters(3, 0) As String
        Dim ds As DataSet = objConn.QuerySQL("prc_GetAllActiveVendors", Parameters)
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                rptVendors.DataSource = ds.Tables(0)
                rptVendors.DataBind()
            Else
                rptVendors.DataSource = Nothing
                rptVendors.DataBind()
            End If
        End If
    End Sub

    Private Sub rdoProducts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoProducts.CheckedChanged
        pnlProducts.Visible = True
        pnlCustomers.Visible = False
        pnlOrders.Visible = False
    End Sub

    Private Sub rdoOrders_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoOrders.CheckedChanged
        pnlProducts.Visible = False
        pnlCustomers.Visible = False
        pnlOrders.Visible = True
    End Sub

    Private Sub rdoCustomers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoCustomers.CheckedChanged
        pnlProducts.Visible = False
        pnlCustomers.Visible = True
        pnlOrders.Visible = False
    End Sub

    Private Sub export_import_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        trCategories.Style.Add("display", "none")
        trVendors.Style.Add("display", "none")
        If cmbFilterProducts.Value = "1" Then
            trCategories.Style.Add("display", "")
        ElseIf cmbFilterProducts.Value = "2" Then
            trVendors.Style.Add("display", "")
        Else
            trCategories.Style.Add("display", "none")
        End If
    End Sub

#Region "Export Product CSV/XML File"
    Private Sub btnExportProducts_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportProducts.ServerClick
        Dim strCategories, strVendors As String
        strCategories = ""
        strVendors = ""
        If cmbFilterProducts.Value = "1" Then
            For Each item As RepeaterItem In rptCategories.Items
                If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
                    If DirectCast(item.FindControl("chkCategory"), CheckBox).Checked Then
                        strCategories = strCategories + DirectCast(item.FindControl("hdnId"), HtmlInputHidden).Value + ","
                    End If
                End If
            Next
        ElseIf cmbFilterProducts.Value = "2" Then
            For Each item As RepeaterItem In rptVendors.Items
                If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
                    If DirectCast(item.FindControl("chkVendors"), CheckBox).Checked Then
                        strVendors = strVendors + DirectCast(item.FindControl("hdnId"), HtmlInputHidden).Value + ","
                    End If
                End If
            Next
        End If
        Dim Parameters(3, 2) As String
        Parameters(0, 0) = "@prd_CategoryList"
        Parameters(1, 0) = "varchar"
        Parameters(2, 0) = "-1"
        Parameters(3, 0) = strCategories

        Parameters(0, 1) = "@prd_VendorsList"
        Parameters(1, 1) = "varchar"
        Parameters(2, 1) = "-1"
        Parameters(3, 1) = strVendors

        Parameters(0, 2) = "@PhotoPath"
        Parameters(1, 2) = "varchar"
        Parameters(2, 2) = "100"
        Parameters(3, 2) = ConfigurationManager.AppSettings("ProductImagesPath")

        Dim strFileName As String = "Products-" & CStr(Day(Now)) & CStr(Month(Now)) & CStr(Year(Now)) & CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now))

        If ddlFileType.SelectedValue = "1" Then
            '--------Export CSV----------------
            Dim ds As DataSet = objConn.QuerySQL("prc_ExportProductCSVData", Parameters)
            Utils.WriteCSV(strFileName & ".csv", ds.Tables(0))
        Else
            '--------Export XML----------------
            Dim ds As DataSet = objConn.QuerySQL("prc_ExportProductXMLData", Parameters)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim xml As New System.Xml.XmlDocument()
                xml.LoadXml("<?xml version=""1.0"" encoding=""Windows-1252"" ?>" & ds.Tables(0).Rows(0).Item(0).ToString())
                xml.Save(strUploadPath & strFileName & ".xml")
                Response.AppendHeader("Content-disposition", "attachment; filename=" & strFileName & ".xml")
                Response.ContentType = "application/download"
                Response.WriteFile(strUploadPath & strFileName & ".xml")
                Response.End()
            End If
        End If
    End Sub
#End Region

#Region "Export Customer CSV/XML File"
    Private Sub btnExportCustomer_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportCustomer.ServerClick
        Dim Parameters(3, 0) As String
        Dim strFileName As String = "Customers-" & CStr(Day(Now)) & CStr(Month(Now)) & CStr(Year(Now)) & CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now))
        If ddlFileType1.SelectedValue = "1" Then
            '--------Export CSV----------------
            Dim ds As DataSet = objConn.QuerySQL("prc_ExportMemberCSVData", Parameters)
            Utils.WriteCSV(strFileName & ".csv", ds.Tables(0))
        Else
            '--------Export XML----------------
            Dim ds As DataSet = objConn.QuerySQL("prc_ExportMemberXMLData", Parameters)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim xml As New System.Xml.XmlDocument()
                xml.LoadXml("<?xml version=""1.0"" encoding=""Windows-1252"" ?>" & ds.Tables(0).Rows(0).Item(0).ToString())
                Dim strPassword As String = ""
                Dim xmlNewPasswordElement As XmlElement
                For Each xmlPasswordElement As XmlElement In xml.DocumentElement.SelectNodes("Customer/Password")
                    strPassword = objConn.Decryption(xmlPasswordElement.InnerXml)
                    xmlNewPasswordElement = xml.CreateElement("Password")
                    xmlNewPasswordElement.InnerXml = strPassword
                    xmlPasswordElement.ParentNode.ReplaceChild(xmlNewPasswordElement, xmlPasswordElement)
                Next
                xml.Save(strUploadPath & strFileName & ".xml")
                Response.AppendHeader("Content-disposition", "attachment; filename=" & strFileName & ".xml")
                Response.ContentType = "application/download"
                Response.WriteFile(strUploadPath & strFileName & ".xml")
                Response.End()
            End If
        End If
    End Sub
#End Region

#Region "Export Orders CSV/XML File"
    Private Sub btnExportOrder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportOrder.ServerClick
        Dim Parameters(3, 2) As String

        Parameters(0, 0) = "@FromDate"
        Parameters(1, 0) = "varchar"
        Parameters(2, 0) = "10"
        If IsDate(txtFromDate.Value) Then
            Parameters(3, 0) = txtFromDate.Value.Trim
        Else
            Parameters(3, 0) = ""
        End If

        Parameters(0, 1) = "@ToDate"
        Parameters(1, 1) = "varchar"
        Parameters(2, 1) = "10"
        If IsDate(txtToDate.Value) Then
            Parameters(3, 1) = txtToDate.Value.Trim
        Else
            Parameters(3, 1) = ""
        End If


        Parameters(0, 2) = "@OrderStatus"
        Parameters(1, 2) = "int"
        Parameters(2, 2) = "4"
        Parameters(3, 2) = cmbOrderStatus.Value
        Dim strFileName As String = "Orders-" & CStr(Day(Now)) & CStr(Month(Now)) & CStr(Year(Now)) & CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now))
        If ddlFileTypeOrder.SelectedValue = "1" Then
            '--------Export CSV----------------
            Dim ds As DataSet = objConn.QuerySQL("prc_ExportOrdersCSVData", Parameters)
            Utils.WriteCSV(strFileName & ".csv", ds.Tables(0))
        Else
            '--------Export XML----------------
            Dim ds As DataSet = objConn.QuerySQL("prc_ExportOrdersXMLData", Parameters)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim xml As New System.Xml.XmlDocument()
                xml.LoadXml("<?xml version=""1.0"" encoding=""Windows-1252"" ?>" & ds.Tables(0).Rows(0).Item(0).ToString())
                xml.Save(strUploadPath & strFileName & ".xml")

                Response.AppendHeader("Content-disposition", "attachment; filename=" & strFileName & ".xml")
                Response.ContentType = "application/download"
                Response.WriteFile(strUploadPath & strFileName & ".xml")
                Response.End()
            End If
        End If
    End Sub
    

#End Region

#Region "import CSV Customer Data"
    Sub ImportCSVCustomerData()

        Dim strFile As String = CStr(Day(Now)) & CStr(Month(Now)) & CStr(Year(Now)) & CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now)) & ".csv"

        flProducts.PostedFile.SaveAs(strUploadPath & strFile)

        Dim ds As DataSet = Utils.ReadCSV(strUploadPath & strFile)

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
            ImportCustomers(strErrorRows, ds)
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

    Sub ImportCustomers(ByRef strErrorRows As String, ByRef ds As DataSet)

        For Each row As DataRow In ds.Tables(0).Rows
            If row("FirstName").ToString().Trim.Length > 0 Then

                Try

                    Dim Parameters(3, 16) As String
                    Parameters(0, 0) = "@mem_FirstName"
                    Parameters(1, 0) = "varchar"
                    Parameters(2, 0) = "50"
                    Parameters(3, 0) = Left(row("FirstName").ToString().Trim(), 50)

                    Parameters(0, 1) = "@mem_LastName"
                    Parameters(1, 1) = "varchar"
                    Parameters(2, 1) = "50"
                    Parameters(3, 1) = Left(row("LastName").ToString().Trim(), 50)

                    Parameters(0, 2) = "@mem_UserName"
                    Parameters(1, 2) = "varchar"
                    Parameters(2, 2) = "30"
                    Parameters(3, 2) = Left(row("UserName").ToString().Trim(), 30)

                    Parameters(0, 3) = "@mem_Password"
                    Parameters(1, 3) = "varchar"
                    Parameters(2, 3) = "255"
                    Parameters(3, 3) = objConn.Encryption(row("Password").ToString().Trim())

                    Parameters(0, 4) = "@mem_Address"
                    Parameters(1, 4) = "varchar"
                    Parameters(2, 4) = "100"
                    Parameters(3, 4) = Left(row("Address").ToString().Trim(), 100)

                    Parameters(0, 5) = "@mem_EmailAddress"
                    Parameters(1, 5) = "varchar"
                    Parameters(2, 5) = "100"
                    Parameters(3, 5) = Left(row("EmailAddress").ToString().Trim(), 100)

                    Parameters(0, 6) = "@mem_Country"
                    Parameters(1, 6) = "varchar"
                    Parameters(2, 6) = "5"
                    Parameters(3, 6) = Left(row("Country").ToString().Trim(), 5)

                    Parameters(0, 7) = "@mem_State"
                    Parameters(1, 7) = "varchar"
                    Parameters(2, 7) = "50"
                    Parameters(3, 7) = Left(row("State").ToString().Trim(), 50)

                    Parameters(0, 8) = "@mem_City"
                    Parameters(1, 8) = "varchar"
                    Parameters(2, 8) = "50"
                    Parameters(3, 8) = Left(row("City").ToString().Trim(), 50)

                    Parameters(0, 9) = "@mem_Zip"
                    Parameters(1, 9) = "varchar"
                    Parameters(2, 9) = "50"
                    Parameters(3, 9) = Left(row("Zip").ToString().Trim(), 50)

                    Parameters(0, 10) = "@mem_Phone"
                    Parameters(1, 10) = "varchar"
                    Parameters(2, 10) = "20"
                    Parameters(3, 10) = Left(row("Phone").ToString().Trim(), 20)

                    Parameters(0, 11) = "@mem_IP"
                    Parameters(1, 11) = "varchar"
                    Parameters(2, 11) = "20"
                    Parameters(3, 11) = Left(row("IP").ToString().Trim(), 20)

                    Parameters(0, 12) = "@nls_Subscribe"
                    Parameters(1, 12) = "tinyint"
                    Parameters(2, 12) = "1"
                    Parameters(3, 12) = row("SubscribeNewsletter").ToString().Trim()

                    Parameters(0, 13) = "@nls_HtmlText"
                    Parameters(1, 13) = "tinyint"
                    Parameters(2, 13) = "1"
                    Parameters(3, 13) = row("HtmlOrText").ToString().Trim()

                    Parameters(0, 14) = "@mem_DateOfBirth"
                    Parameters(1, 14) = "smalldatetime"
                    Parameters(2, 14) = "8"
                    Parameters(3, 14) = row("DateOfBirth").ToString().Trim()

                    Parameters(0, 15) = "@mem_Status"
                    Parameters(1, 15) = "tinyint"
                    Parameters(2, 15) = "1"
                    Parameters(3, 15) = row("Status").ToString().Trim()


                    Parameters(0, 16) = "@Update"
                    Parameters(1, 16) = "tinyint"
                    Parameters(2, 16) = "1"
                    Parameters(3, 16) = IIf(chkUpdateExisting.Checked, 1, 0)

                    Dim strResult As String = objConn.QueryScalarSQL("prc_ImportMemberCSVData", Parameters)
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

#Region "import XML Customer Data"
    Sub ImportXMLCustomerData()
        tblCustomerError.Visible = False
        '-----Upload  XML File

        Dim strFile As String = CStr(Day(Now)) & CStr(Month(Now)) & CStr(Year(Now)) & CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now)) & ".xml"
        flProducts.PostedFile.SaveAs(strUploadPath & strFile)

        '-----Read XML file and store Data in String
        Dim fp As StreamReader
        Dim xmlData As String
        fp = File.OpenText(strUploadPath & strFile)
        xmlData = fp.ReadToEnd()
        fp.Close()

        '-----Import XML String DAta in the database
        Dim ds As New DataSet
        Dim Parameters(3, 1) As String
        Parameters(0, 0) = "@xmlData"
        Parameters(1, 0) = "varchar"
        Parameters(2, 0) = "-1"
        Parameters(3, 0) = xmlData.ToString()

        Parameters(0, 1) = "@Update"
        Parameters(1, 1) = "tinyint"
        Parameters(2, 1) = "1"
        Parameters(3, 1) = IIf(chkUpdateExisting.Checked, 1, 0)

        ds = objConn.QuerySQL("prc_ImportMemberXMLData", Parameters)
        If ds.Tables(0).Rows.Count > 0 Then
            ltrMsg.Text = ds.Tables(0).Rows(0).Item("result").ToString()
        End If
    End Sub
#End Region

#Region "import XML Product Data"
    Sub ImportXMLProductData()
        '-----Upload  XML File

        Dim strFile As String = CStr(Day(Now)) & CStr(Month(Now)) & CStr(Year(Now)) & CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now)) & ".xml"
        flProducts.PostedFile.SaveAs(strUploadPath & strFile)

        '-----Read XML file and store Data in String
        Dim fp As StreamReader
        Dim xmlData As String
        fp = File.OpenText(strUploadPath & strFile)
        xmlData = fp.ReadToEnd()
        fp.Close()

        '-----Import XML String DAta in the database
        Try


            Dim Parameters(3, 2) As String
            Parameters(0, 0) = "@xmlData"
            Parameters(1, 0) = "varchar"
            Parameters(2, 0) = "-1"
            Parameters(3, 0) = xmlData.ToString()

            Parameters(0, 1) = "@ImagePath"
            Parameters(1, 1) = "varchar"
            Parameters(2, 1) = "200"
            Parameters(3, 1) = ConfigurationManager.AppSettings("ProductImagesPath")

            Parameters(0, 2) = "@Update"
            Parameters(1, 2) = "tinyint"
            Parameters(2, 2) = "1"
            Parameters(3, 2) = IIf(chkUpdateExisting.Checked, 1, 0)


            Dim ds As New DataSet
            ds = objConn.QuerySQL("prc_ImportProductXMLData", Parameters)
            If ds.Tables(0).Rows.Count > 0 Then
                ltrMsg.Text = ds.Tables(0).Rows(0).Item("result").ToString()
            End If
        Catch ex As Exception
            ltrMsg.Text = ex.Message
        End Try
    End Sub
#End Region

#Region "Import CSV Product Data"
    Sub ImportCSVProductData()
        Dim strFile As String = CStr(Day(Now)) & CStr(Month(Now)) & CStr(Year(Now)) & CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now)) & ".csv"
        flProducts.PostedFile.SaveAs(strUploadPath & strFile)
        Dim ds As DataSet = Utils.ReadCSV(strUploadPath & strFile)

        Try
            If IO.File.Exists(strUploadPath & strFile) Then
                IO.File.Delete(strUploadPath & strFile)
            End If
        Catch ex As Exception
        End Try

        ds.Tables(0).Columns.Add(New DataColumn("Reason", Type.GetType("System.String")))
        ds.Tables(0).Columns.Add(New DataColumn("__RowNumber", Type.GetType("System.Int32")))

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            ds.Tables(0).Rows(i).Item("__RowNumber") = i + 1
            ds.Tables(0).Rows(i)("LargeDescription") = ds.Tables(0).Rows(i)("LargeDescription").ToString() + ds.Tables(0).Rows(i)("LargeDescription1").ToString() + ds.Tables(0).Rows(i)("LargeDescription2").ToString() + ds.Tables(0).Rows(i)("LargeDescription3").ToString() + ds.Tables(0).Rows(i)("LargeDescription4").ToString() + ds.Tables(0).Rows(i)("LargeDescription5").ToString()

        Next
        Dim strErrorRows As String = ""

        For Each row As DataRow In ds.Tables(0).Rows
            If row("Title").ToString().Trim.Length > 0 Then
                Try
                    Dim dblPrice As Double = 0
                    If IsNumeric(row("Price")) Then
                        dblPrice = Convert.ToDouble(row("Price"))
                    End If

                    Dim dblDiscountPrice As Double = 0
                    If IsNumeric(row("DiscountPrice")) Then
                        dblDiscountPrice = Convert.ToDouble(row("DiscountPrice"))
                    End If

                    Dim dblWeightLB As Double = 0
                    If IsNumeric(row("WeightLB")) Then
                        dblWeightLB = Convert.ToDouble(row("WeightLB"))
                    End If

                    Dim dblWeightOZ As Double = 0
                    If IsNumeric(row("WeightOZ")) Then
                        dblWeightOZ = Convert.ToDouble(row("WeightOZ"))
                    End If

                    Dim Parameters(3, 49) As String

                    Parameters(0, 0) = "@pr_SkuCode"
                    Parameters(1, 0) = "varchar"
                    Parameters(2, 0) = "50"
                    Parameters(3, 0) = Left(row("SkuCode").ToString().Trim(), 50)

                    Parameters(0, 1) = "@pr_Title"
                    Parameters(1, 1) = "varchar"
                    Parameters(2, 1) = "100"
                    Parameters(3, 1) = Left(row("Title").ToString().Trim(), 100)

                    Parameters(0, 2) = "@pr_SmallDescription"
                    Parameters(1, 2) = "varchar"
                    Parameters(2, 2) = "-1"
                    Parameters(3, 2) = row("SmallDescription").ToString().Trim()

                    Parameters(0, 3) = "@pr_LargeDescription"
                    Parameters(1, 3) = "varchar"
                    Parameters(2, 3) = "-1"
                    Parameters(3, 3) = row("LargeDescription").ToString().Trim()

                    Parameters(0, 4) = "@pr_Ingredients"
                    Parameters(1, 4) = "varchar"
                    Parameters(2, 4) = "-1"
                    Parameters(3, 4) = row("Ingredients").ToString().Trim()

                    Parameters(0, 5) = "@pr_Price"
                    Parameters(1, 5) = "money"
                    Parameters(2, 5) = "8"
                    Parameters(3, 5) = dblPrice

                    Parameters(0, 6) = "@pr_IsDiscount"
                    Parameters(1, 6) = "tinyint"
                    Parameters(2, 6) = "1"
                    Parameters(3, 6) = row("IsDiscount").ToString().Trim()

                    Parameters(0, 7) = "@pr_DiscountPrice"
                    Parameters(1, 7) = "money"
                    Parameters(2, 7) = "8"
                    Parameters(3, 7) = dblDiscountPrice

                    Parameters(0, 8) = "@pr_Quantity"
                    Parameters(1, 8) = "int"
                    Parameters(2, 8) = "4"
                    Parameters(3, 8) = row("TotalInventory").ToString().Trim()

                    Parameters(0, 9) = "@pr_MinQuantity"
                    Parameters(1, 9) = "int"
                    Parameters(2, 9) = "4"
                    Parameters(3, 9) = row("MinimumInventory").ToString().Trim()

                    Parameters(0, 10) = "@pr_IsVolumeDiscount"
                    Parameters(1, 10) = "tinyint"
                    Parameters(2, 10) = "1"
                    Parameters(3, 10) = row("IsVolumeDiscount").ToString().Trim()

                    Parameters(0, 11) = "@pr_VolumeDiscountPrice"
                    Parameters(1, 11) = "money"
                    Parameters(2, 11) = "8"
                    Parameters(3, 11) = row("VolumeDiscountPrice").ToString().Trim()

                    Parameters(0, 12) = "@pr_VolumeQuantity"
                    Parameters(1, 12) = "int"
                    Parameters(2, 12) = "4"
                    Parameters(3, 12) = row("VolumeDiscountQuantity").ToString().Trim()

                    Parameters(0, 13) = "@pr_WeightLB"
                    Parameters(1, 13) = "float"
                    Parameters(2, 13) = "8"
                    Parameters(3, 13) = dblWeightLB

                    Parameters(0, 14) = "@pr_WeightOZ"
                    Parameters(1, 14) = "float"
                    Parameters(2, 14) = "8"
                    Parameters(3, 14) = dblWeightOZ

                    Parameters(0, 15) = "@pr_FriendlyUrl"
                    Parameters(1, 15) = "varchar"
                    Parameters(2, 15) = "200"
                    Parameters(3, 15) = Left(row("FriendlyUrl").ToString().Trim(), 200)

                    Parameters(0, 16) = "@pr_Show"
                    Parameters(1, 16) = "tinyint"
                    Parameters(2, 16) = "1"
                    Parameters(3, 16) = row("BelowInventoryLevel").ToString().Trim()

                    Parameters(0, 17) = "@pr_ImageAlt"
                    Parameters(1, 17) = "varchar"
                    Parameters(2, 17) = "100"
                    Parameters(3, 17) = Left(row("ImageAlt").ToString().Trim(), 100)

                    Parameters(0, 18) = "@pr_ImageTitle"
                    Parameters(1, 18) = "varchar"
                    Parameters(2, 18) = "100"
                    Parameters(3, 18) = Left(row("ImageTitle").ToString().Trim(), 100)

                    Parameters(0, 19) = "@pr_Image"
                    Parameters(1, 19) = "varchar"
                    Parameters(2, 19) = "200"
                    Parameters(3, 19) = Left(row("Image").ToString().Trim(), 200)

                    Parameters(0, 20) = "@OtherImages"
                    Parameters(1, 20) = "varchar"
                    Parameters(2, 20) = "-1"
                    Parameters(3, 20) = row("OtherImages").ToString().Trim()

                    Parameters(0, 21) = "@pr_MetaTitle"
                    Parameters(1, 21) = "varchar"
                    Parameters(2, 21) = "500"
                    Parameters(3, 21) = Left(row("MetaTitle").ToString().Trim(), 500)

                    Parameters(0, 22) = "@pr_MetaDesc"
                    Parameters(1, 22) = "varchar"
                    Parameters(2, 22) = "1000"
                    Parameters(3, 22) = Left(row("MetaDescription").ToString().Trim(), 1000)

                    Parameters(0, 23) = "@pr_MetaKeywords"
                    Parameters(1, 23) = "varchar"
                    Parameters(2, 23) = "1000"
                    Parameters(3, 23) = Left(row("MetaKeywords").ToString().Trim(), 1000)

                    Parameters(0, 24) = "@pa_attr1NameText"
                    Parameters(1, 24) = "varchar"
                    Parameters(2, 24) = "50"
                    Parameters(3, 24) = Left(row("Attribute1").ToString().Trim(), 50)

                    Parameters(0, 25) = "@pa_attr1Value"
                    Parameters(1, 25) = "varchar"
                    Parameters(2, 25) = "100"
                    Parameters(3, 25) = Left(row("Value1").ToString().Trim(), 100)

                    Parameters(0, 26) = "@pa_attr2NameText"
                    Parameters(1, 26) = "varchar"
                    Parameters(2, 26) = "50"
                    Parameters(3, 26) = Left(row("Attribute2").ToString().Trim(), 50)

                    Parameters(0, 27) = "@pa_attr2Value"
                    Parameters(1, 27) = "varchar"
                    Parameters(2, 27) = "100"
                    Parameters(3, 27) = Left(row("Value2").ToString().Trim(), 100)

                    Parameters(0, 28) = "@pa_attr3NameText"
                    Parameters(1, 28) = "varchar"
                    Parameters(2, 28) = "50"
                    Parameters(3, 28) = Left(row("Attribute3").ToString().Trim(), 50)

                    Parameters(0, 29) = "@pa_attr3Value"
                    Parameters(1, 29) = "varchar"
                    Parameters(2, 29) = "100"
                    Parameters(3, 29) = Left(row("Value3").ToString().Trim(), 100)

                    Parameters(0, 30) = "@pa_attr4NameText"
                    Parameters(1, 30) = "varchar"
                    Parameters(2, 30) = "50"
                    Parameters(3, 30) = Left(row("Attribute4").ToString().Trim(), 50)

                    Parameters(0, 31) = "@pa_attr4Value"
                    Parameters(1, 31) = "varchar"
                    Parameters(2, 31) = "100"
                    Parameters(3, 31) = Left(row("Value4").ToString().Trim(), 100)

                    Parameters(0, 32) = "@pa_attr5NameText"
                    Parameters(1, 32) = "varchar"
                    Parameters(2, 32) = "50"
                    Parameters(3, 32) = Left(row("Attribute5").ToString().Trim(), 50)

                    Parameters(0, 33) = "@pa_attr5Value"
                    Parameters(1, 33) = "varchar"
                    Parameters(2, 33) = "100"
                    Parameters(3, 33) = Left(row("Value5").ToString().Trim(), 100)

                    Parameters(0, 34) = "@pa_attr6NameText"
                    Parameters(1, 34) = "varchar"
                    Parameters(2, 34) = "50"
                    Parameters(3, 34) = Left(row("Attribute6").ToString().Trim(), 50)

                    Parameters(0, 35) = "@pa_attr6Value"
                    Parameters(1, 35) = "varchar"
                    Parameters(2, 35) = "100"
                    Parameters(3, 35) = Left(row("Value6").ToString().Trim(), 100)

                    Parameters(0, 36) = "@pr_Featured"
                    Parameters(1, 36) = "tinyint"
                    Parameters(2, 36) = "1"
                    Parameters(3, 36) = row("IsFeatured").ToString().Trim()

                    Parameters(0, 37) = "@pr_IsFreeShipping"
                    Parameters(1, 37) = "tinyint"
                    Parameters(2, 37) = "1"
                    Parameters(3, 37) = row("IsFreeShipping").ToString().Trim()

                    Parameters(0, 38) = "@pr_AdditionalShipCharges"
                    Parameters(1, 38) = "money"
                    Parameters(2, 38) = "8"
                    Parameters(3, 38) = row("AdditionalShippingCharges").ToString().Trim()

                    Parameters(0, 39) = "@pr_Status"
                    Parameters(1, 39) = "tinyint"
                    Parameters(2, 39) = "1"
                    Parameters(3, 39) = row("Status").ToString().Trim()

                    Parameters(0, 40) = "@pr_ListOrder"
                    Parameters(1, 40) = "int"
                    Parameters(2, 40) = "4"
                    Parameters(3, 40) = row("ListOrder").ToString().Trim()

                    Parameters(0, 41) = "@pr_NewArrival"
                    Parameters(1, 41) = "tinyint"
                    Parameters(2, 41) = "1"
                    Parameters(3, 41) = row("IsNewArrival").ToString().Trim()

                    Parameters(0, 42) = "@pr_EWGRating"
                    Parameters(1, 42) = "varchar"
                    Parameters(2, 42) = "50"
                    Parameters(3, 42) = row("EWGRating").ToString().Trim()

                    Parameters(0, 43) = "@pr_RelatedProducts"
                    Parameters(1, 43) = "varchar"
                    Parameters(2, 43) = "-1"
                    Parameters(3, 43) = row("RelatedProducts").ToString().Trim()

                    Parameters(0, 44) = "@pr_UpsellProducts"
                    Parameters(1, 44) = "varchar"
                    Parameters(2, 44) = "-1"
                    Parameters(3, 44) = row("UpsellProducts").ToString().Trim()

                    Parameters(0, 45) = "@pr_CategoryList"
                    Parameters(1, 45) = "varchar"
                    Parameters(2, 45) = "-1"
                    Parameters(3, 45) = row("Categories").ToString().Trim()

                    Parameters(0, 46) = "@pr_Vendor"
                    Parameters(1, 46) = "varchar"
                    Parameters(2, 46) = "-1"
                    Parameters(3, 46) = row("Vendor").ToString().Trim()

                    Parameters(0, 47) = "@ImagePath"
                    Parameters(1, 47) = "varchar"
                    Parameters(2, 47) = "200"
                    Parameters(3, 47) = ConfigurationManager.AppSettings("ProductImagesPath")

                    Parameters(0, 48) = "@Update"
                    Parameters(1, 48) = "tinyint"
                    Parameters(2, 48) = "1"
                    Parameters(3, 48) = IIf(chkUpdateExisting.Checked, 1, 0)

                    Parameters(0, 49) = "@IsBulky"
                    Parameters(1, 49) = "tinyint"
                    Parameters(2, 49) = "1"
                    Parameters(3, 49) = Convert.ToInt16(row("IsBulky").ToString().Trim())

                    Dim intResult As Integer = objConn.QueryScalarSQL("prc_ImportProductCSVData", Parameters)
                    'Response.Write(intResult & " - " & Convert.ToInt16(row("IsBulky").ToString().Trim()) & "<br/>")
                Catch ex As Exception
                    row("Reason") = ex.Message
                    strErrorRows = strErrorRows + row("__RowNumber").ToString() + ","
                End Try

            End If
        Next
        'Response.End()
        If strErrorRows.Trim.Length > 0 Then
            strErrorRows = strErrorRows + "0"
            Dim dv As DataView = ds.Tables(0).DefaultView
            dv.RowFilter = "__RowNumber in (" + strErrorRows + ")"
            grdError.DataSource = dv
            grdError.DataBind()
            tblProductError.Visible = True
            ltrMsg.Text = ""
        Else
            tblProductError.Visible = False
            ltrMsg.Text = "Product imported successfully."
        End If
    End Sub
#End Region

    Private Sub btnImportFile_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImportFile.ServerClick
        Dim strExt As String = ""
        If Trim(flProducts.Value) <> "" Then
            strExt = System.IO.Path.GetExtension(flProducts.PostedFile.FileName).ToLower
            If strExt = ".csv" Or strExt = ".xml" Then
                '-------Import Prodct Data-----------
                If rdoProductsImport.Checked = True Then
                    If strExt = ".csv" Then
                        ImportCSVProductData()
                    End If
                    If strExt = ".xml" Then
                        importXMLProductData()
                    End If
                End If
                '-------Import Customer Data-----------
                If rdoCustomersImport.Checked = True Then
                    If strExt = ".csv" Then
                        importCSVCustomerData()
                    End If
                    If strExt = ".xml" Then
                        importXMLCustomerData()
                    End If
                End If
            Else
                ltrMsg.Text = "You can only import .CSV or .XML file"
            End If
        Else
            ltrMsg.Text = "Please select the file to inport"
        End If
    End Sub

    Private Sub lnkCustomerCSVTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCustomerCSVTemplate.Click
        Response.AppendHeader("Content-disposition", "attachment; filename=csv-customers-import-template.csv")
        Response.ContentType = "application/csv"
        Response.WriteFile(Server.MapPath("~") & ConfigurationManager.AppSettings("TemplatePath") & "csv-customers-import-template.csv")
        Response.End()
    End Sub

    Private Sub lnkCustomerXMLTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCustomerXMLTemplate.Click
        Response.AppendHeader("Content-disposition", "attachment; filename=xml-customers-import-template.xml")
        Response.ContentType = "application/download"
        Response.WriteFile(Server.MapPath("~") & ConfigurationManager.AppSettings("TemplatePath") & "xml-customers-import-template.xml")
        Response.End()
    End Sub

    Private Sub lnkProductCSVTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProductCSVTemplate.Click
        Response.AppendHeader("Content-disposition", "attachment; filename=csv-products-import-template.csv")
        Response.ContentType = "application/csv"
        Response.WriteFile(Server.MapPath("~") & ConfigurationManager.AppSettings("TemplatePath") & "csv-products-import-template.csv")
        Response.End()
    End Sub

    Private Sub lnkProductXMLTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProductXMLTemplate.Click
        Response.AppendHeader("Content-disposition", "attachment; filename=xml-products-import-template.xml")
        Response.ContentType = "application/download"
        Response.WriteFile(Server.MapPath("~") & ConfigurationManager.AppSettings("TemplatePath") & "xml-products-import-template.xml")
        Response.End()
    End Sub
End Class