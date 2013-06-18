Imports System.Xml
Public Class CMS
    Private _intId As String
    Private _PageTitle As String = ""
    Private _MetaTitle As String = "Welcome to Monsoondeals"
    Private _MetaDescription As String = ""
    Private _MetaKeywords As String = ""
    Private _PageContent As String = ""
    Private _trPageTitle As Boolean = False
    Private _pnlMetaFields As Boolean = False

    Dim objConn As New clConn

    Public Property Id() As String
        Get
            Return _intId
        End Get
        Set(ByVal value As String)
            If IsNumeric(value) And value <> "" Then
                _intId = CInt(value)
            Else
                _intId = 0
            End If
        End Set
    End Property

    Public Property PageTitle() As String
        Get
            Return _PageTitle
        End Get
        Set(ByVal value As String)
            _PageTitle = value
        End Set
    End Property

    Public Property MetaTitle() As String
        Get
            Return _MetaTitle
        End Get
        Set(ByVal value As String)
            _MetaTitle = value
        End Set
    End Property

    Public Property MetaDescription() As String
        Get
            Return _MetaDescription
        End Get
        Set(ByVal value As String)
            _MetaDescription = value
        End Set
    End Property

    Public Property MetaKeywords() As String
        Get
            Return _MetaKeywords
        End Get
        Set(ByVal value As String)
            _MetaKeywords = value
        End Set
    End Property

    Public Property PageContent() As String
        Get
            Return _PageContent
        End Get
        Set(ByVal value As String)
            _PageContent = value
        End Set
    End Property

    Public Property pnlMetaFields() As Boolean
        Get
            Return _pnlMetaFields
        End Get
        Set(ByVal value As Boolean)
            _pnlMetaFields = value
        End Set
    End Property
    Public Property trPageTitle() As Boolean
        Get
            Return _trPageTitle
        End Get
        Set(ByVal value As Boolean)
            _trPageTitle = value
        End Set
    End Property

    Sub BindCmsContent()
        Dim XMLDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument()
        XMLDoc.Load(Utils.GetXmlFilePath("SEO.Config"))
        Dim xmlNodes As XmlNode
        xmlNodes = XMLDoc.DocumentElement.SelectSingleNode("SEO[@ID=""" & CInt(Id) & """]")
        If IsNothing(xmlNodes) = False Then
            PageTitle = xmlNodes.Item("PageTitle").InnerText
            MetaTitle = IIf(xmlNodes.Item("MetaTitle").InnerText.Trim <> "", xmlNodes.Item("MetaTitle").InnerText.Trim, MetaTitle)
            MetaDescription = xmlNodes.Item("MetaDescription").InnerText
            MetaKeywords = xmlNodes.Item("MetaKeyWords").InnerText
            PageContent = xmlNodes.Item("Content").InnerText
        End If

        If MetaTitle.Trim.Length = 0 Then
            xmlNodes = XMLDoc.DocumentElement.SelectSingleNode("SEO[@ID=""0""]")
            If IsNothing(xmlNodes) = False Then
                MetaTitle = IIf(xmlNodes.Item("MetaTitle").InnerText.Trim <> "", xmlNodes.Item("MetaTitle").InnerText.Trim, MetaTitle)
                MetaDescription = xmlNodes.Item("MetaDescription").InnerText
                MetaKeywords = xmlNodes.Item("MetaKeyWords").InnerText
            End If
        End If
        XMLDoc = Nothing
    End Sub

    Sub BindGeneralSEO()
        Dim XMLDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument()
        XMLDoc.Load(Utils.GetXmlFilePath("SEO.Config"))
        Dim xmlNodes As XmlNodeList = XMLDoc.DocumentElement.SelectNodes("child::SEO[@ID=""0""]/*")
        For Each xmlNod As XmlNode In xmlNodes
            If xmlNod.Name = "MetaTitle" Then
                MetaTitle = xmlNod.InnerText
            ElseIf xmlNod.Name = "MetaDescription" Then
                MetaDescription = xmlNod.InnerText
            ElseIf xmlNod.Name = "MetaKeyWords" Then
                MetaKeywords = xmlNod.InnerText
            End If
        Next
    End Sub

#Region "Bind CMS Page Load Content"
    Sub BindCMSPageLoadContent()
        Dim DS As DataSet = objConn.QuerySQL("prc_BindCmsPageContentById", _
                                   objConn.GetSqlParam("@PageId", SqlDbType.Int, Me.Id))

        If DS.Tables(0).Rows.Count > 0 Then
            With DS.Tables(0).Rows(0)
                Me.PageTitle = .Item("Page_Title").ToString()
                Me.MetaTitle = .Item("Page_MetaTitle").ToString()
                Me.MetaDescription = .Item("Page_MetaDescription").ToString().Replace("<br/>", Chr(10))
                Me.MetaKeywords = .Item("Page_MetaKeywords").ToString().Replace("<br/>", Chr(10))
                Me.PageContent = .Item("Page_Content").ToString()
                If .Item("Page_Type").ToString() = 1 Then
                    Me.trPageTitle = True
                    Me.pnlMetaFields = True
                ElseIf .Item("Page_Type").ToString() = 2 Then
                    Me.trPageTitle = True
                    Me.pnlMetaFields = False
                ElseIf .Item("Page_Type").ToString() = 3 Then
                    Me.trPageTitle = False
                    Me.pnlMetaFields = False
                End If
            End With
        End If
    End Sub
#End Region

#Region "Update CMS Page Content"
    Sub UpdateCMSPageContent()
        objConn.ExecuteSQL("prc_InsUpdateCMSPageContent", _
                        objConn.GetSqlParam("@PageId", SqlDbType.Int, Me.Id), _
                       objConn.GetSqlParam("@pageTitle", SqlDbType.VarChar, 200, Me.PageTitle), _
                        objConn.GetSqlParam("@Page_Content", SqlDbType.VarChar, -1, Me.PageContent), _
                        objConn.GetSqlParam("@Page_MetaTitle", SqlDbType.VarChar, 1000, Me.MetaTitle), _
                        objConn.GetSqlParam("@Page_MetaKeywords", SqlDbType.VarChar, -1, Me.MetaKeywords), _
                        objConn.GetSqlParam("@Page_MetaDescription", SqlDbType.VarChar, -1, Me.MetaDescription) _
                        )

        Dim xmlDoc As New XmlDocument
        Dim strFile As String = Utils.GetXmlFilePath("SEO.Config")
        xmlDoc.Load(strFile)
        Dim xmlNodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("child::SEO[@ID=""" & Me.Id & """]/*")
        If xmlNodes.Count = 0 Then
            Dim strXmlNewNodechilds As New StringBuilder()
            Dim xmlNewElement As XmlElement
            xmlNewElement = xmlDoc.CreateElement("SEO")
            xmlNewElement.SetAttribute("ID", Me.Id)
            strXmlNewNodechilds.Append("<PageTitle></PageTitle>")
            strXmlNewNodechilds.Append("<MetaTitle></MetaTitle>")
            strXmlNewNodechilds.Append("<MetaDescription></MetaDescription>")
            strXmlNewNodechilds.Append("<MetaKeyWords></MetaKeyWords>")
            strXmlNewNodechilds.Append("<Content></Content>")
            xmlNewElement.InnerXml = strXmlNewNodechilds.ToString()
            xmlNewElement("PageTitle").InnerText = Me.PageTitle
            xmlNewElement("MetaTitle").InnerText = Me.MetaTitle
            xmlNewElement("MetaDescription").InnerText = Me.MetaDescription
            xmlNewElement("MetaKeyWords").InnerText = Me.MetaKeywords
            xmlNewElement("Content").InnerXml = "<![CDATA[" & Me.PageContent & "]]>"
            xmlDoc.DocumentElement.InsertAfter(xmlNewElement, xmlDoc.DocumentElement.FirstChild)
        Else
            For Each xmlNod As XmlNode In xmlNodes
                If xmlNod.Name = "PageTitle" Then
                    xmlNod.InnerText = Me.PageTitle
                ElseIf xmlNod.Name = "MetaTitle" Then
                    xmlNod.InnerText = Me.MetaTitle
                ElseIf xmlNod.Name = "MetaDescription" Then
                    xmlNod.InnerText = Me.MetaDescription
                ElseIf xmlNod.Name = "MetaKeyWords" Then
                    xmlNod.InnerText = Me.MetaKeywords
                ElseIf xmlNod.Name = "Content" Then
                    xmlNod.InnerXml = "<![CDATA[" & Me.PageContent & "]]>"
                End If
            Next
        End If
        xmlDoc.Save(strFile)
    End Sub
#End Region
End Class
