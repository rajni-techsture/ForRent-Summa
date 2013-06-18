Imports System.IO
Imports System.Xml
Imports BusinessAccessLayer.BusinessLayer

Public Class all_menus
    Inherits System.Web.UI.Page
    Dim DSAllMenus As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GenerateMenuTree()
        End If
    End Sub


    Sub GenerateMenuTree()
        Try
            Dim intId As Integer = 0
            If IsNumeric(Request("Id")) Then
                intId = Request("Id")
                Dim objTree As New obout_ASPTreeView_2_NET.Tree
                Dim DS As New DataSet
                Dim objmnu As New BALSiteUser
                objmnu.UserId = intId
                DS = objmnu.ListMenus()

                '  Dim strQuery As String = "Exec prc_ListAllMenusForAUser " & intId


                '  DS = objQry.QuerySQL(strQuery)
                If (DS.Tables(1).Rows.Count > 0) Then
                    hdnUserName.Value = DS.Tables(1).Rows(0).Item("u_Username").ToString()
                    hdnAdminUserName.Value = DS.Tables(1).Rows(0).Item("UserName").ToString()
                    objTree.AddRootNode("<b><font class=arial3b>" & DS.Tables(1).Rows(0).Item("UserName").ToString() & "</font></b>", "")
                End If

                If DS.Tables(0).Rows.Count > 0 Then
                    Dim intCnt As Integer
                    For intCnt = 0 To DS.Tables(0).Rows.Count - 1
                        objTree.Add(DS.Tables(0).Rows(intCnt).Item("tm_ParentMenuId").ToString(), DS.Tables(0).Rows(intCnt).Item("tm_MenuId").ToString(), DS.Tables(0).Rows(intCnt).Item("tm_Name").ToString(), False, "")
                    Next
                End If

                DS = Nothing
                objTree.FolderIcons = "tree2/icons"
                objTree.FolderScript = "tree2/Script"
                objTree.FolderStyle = "tree2/Style/Classic"

                objTree.ShowIcons = False
                objTree.SelectedEnable = False
                ltrAllMenus.Text = objTree.HTML()
            End If
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
    End Sub

    Sub CreateMenuXMLNode(ByRef objXMLWriter As XmlTextWriter, ByVal ParentMenuId As Integer, ByVal MenuId As Integer, ByVal MenuName As String, ByVal MenuLink As String, ByVal MenuToolTip As String, ByVal MenuOrder As Integer, ByVal blnEnd As Boolean)
        objXMLWriter.WriteStartElement("MenuItem")
        objXMLWriter.WriteAttributeString("name", MenuName)
        objXMLWriter.WriteAttributeString("id", MenuId)
        objXMLWriter.WriteAttributeString("href", MenuLink)
        objXMLWriter.WriteAttributeString("tooltip", MenuToolTip)
        objXMLWriter.WriteAttributeString("withoutImages", "true")
        objXMLWriter.WriteAttributeString("src", "")
        If blnEnd Then
            objXMLWriter.WriteEndElement()
        End If
        Dim DV As New DataView
        Dim intMenuId, intMenuOrder, intParentMenuId As Integer
        Dim strMenuName, strMenuLink, strToolTip As String
        Dim blnNextEnd As Boolean
        blnNextEnd = True
        DV = DSAllMenus.Tables(0).DefaultView
        DV.RowFilter = "mnu_Pmnuid = " & MenuId
        If DV.Count > 0 Then
            intMenuId = DV.Item(0).Item("mnu_Id")
            intMenuOrder = DV.Item(0).Item("mnu_Order")
            intParentMenuId = DV.Item(0).Item("mnu_Pmnuid")
            strMenuName = DV.Item(0).Item("mnu_Name")
            strMenuLink = DV.Item(0).Item("mnu_Link")
            strToolTip = DV.Item(0).Item("mnu_Tooltip")
            DV = DSAllMenus.Tables(0).DefaultView
            DV.RowFilter = "mnu_Pmnuid = " & intMenuId
            If DV.Count > 0 Then
                blnNextEnd = False
            End If
            CreateMenuXMLNode(objXMLWriter, intParentMenuId, intMenuId, strMenuName, strMenuLink, strToolTip, intMenuOrder, blnNextEnd)
        Else
            DV = DSAllMenus.Tables(0).DefaultView
            DV.RowFilter = "mnu_Id = " & FindParent(objXMLWriter, MenuId, ParentMenuId, MenuOrder)
            If DV.Count > 0 Then
                intMenuId = DV.Item(0).Item("mnu_Id")
                intMenuOrder = DV.Item(0).Item("mnu_Order")
                intParentMenuId = DV.Item(0).Item("mnu_Pmnuid")
                strMenuName = DV.Item(0).Item("mnu_Name")
                strMenuLink = DV.Item(0).Item("mnu_Link")
                strToolTip = DV.Item(0).Item("mnu_Tooltip")
                DV = DSAllMenus.Tables(0).DefaultView
                DV.RowFilter = "mnu_Pmnuid = " & intMenuId
                If DV.Count > 0 Then
                    blnNextEnd = False
                End If
                CreateMenuXMLNode(objXMLWriter, intParentMenuId, intMenuId, strMenuName, strMenuLink, strToolTip, intMenuOrder, blnNextEnd)
            End If
        End If
    End Sub

    Function FindParent(ByRef objXMLWriter As XmlTextWriter, ByVal intMenuId As Integer, ByVal intParentMenuId As Integer, ByVal intMenuOrder As Integer) As Integer
        Dim DV As DataView
        DV = DSAllMenus.Tables(0).DefaultView
        DV.RowFilter = "mnu_Pmnuid = " & intParentMenuId & " and mnu_Order > " & intMenuOrder
        If DV.Count > 0 Then
            Return DV.Item(0).Item("mnu_Id")
        Else
            DV = DSAllMenus.Tables(0).DefaultView
            DV.RowFilter = "mnu_Id = " & intParentMenuId
            If DV.Count > 0 Then
                objXMLWriter.WriteEndElement()
                Return FindParent(objXMLWriter, intParentMenuId, DV.Item(0).Item("mnu_Pmnuid"), DV.Item(0).Item("mnu_Order"))
            Else
                Return 0
            End If
        End If
    End Function

    Private Sub subSaveMenuRightsTop_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles subSaveMenuRightsTop.ServerClick
        SaveMenuRights()
    End Sub
    Sub SaveMenuRights()
        Try
            Dim objSave As New BALSiteUser

            Dim strMenus As String
            '  Dim objQry As New clConn
            If Len(Request("chkMenus")) > 0 Then
                strMenus = Request("chkMenus")
            Else
                strMenus = ""
            End If
            objSave.UserId = CInt(Request("Id"))
            objSave.CheckedMenu = strMenus
            objSave.UpdateAssignMenuRights()
            'strQuery = "Exec prc_UpdateAssignMenuRights " & CInt(Request("Id")) & ",'" & strMenus & "'"
            'objQry.ExecuteSQL(strQuery)

            '-------------------- Write XML menu file start
            Dim objget As New BALSiteUser
            objget.UserId = CInt(Request("Id"))
            DSAllMenus = objget.GetMenuRights()
            'strQuery = "exec prc_GetMenuRightsofUser " & CInt(Request("Id")) & ""
            'DSAllMenus = objQry.QuerySQL(strQuery)
            Dim DV As New DataView
            DV = DSAllMenus.Tables(0).DefaultView
            Dim strCurrentPath As String = Server.MapPath(ConfigurationManager.AppSettings("MenuPath"))
            ' Dim strXMLPath As String = Strings.Left(strCurrentPath, InStrRev(strCurrentPath, "\")) & CStr(hdnUserName.Value) & ".xml"
            Dim strXMLPath As String = strCurrentPath & "/" & CStr(hdnUserName.Value) & ".xml"
            Dim objXMLWriter As XmlTextWriter
            objXMLWriter = New XmlTextWriter(strXMLPath, Nothing)
            objXMLWriter.Formatting = Formatting.Indented
            objXMLWriter.Indentation = 3
            objXMLWriter.WriteStartDocument()
            objXMLWriter.WriteComment("Created on " & Now())
            objXMLWriter.WriteStartElement("menu")
            objXMLWriter.WriteAttributeString("absolutePosition", "auto")
            objXMLWriter.WriteAttributeString("mode", "popup")
            objXMLWriter.WriteAttributeString("maxItems", "25")
            objXMLWriter.WriteAttributeString("menuAlign", "left")
            objXMLWriter.WriteAttributeString("withoutImages", "true")
            If DV.Count > 0 Then
                Dim intMenuId, intMenuOrder, intParentMenuId As Integer
                Dim strMenuName, strMenuLink, strToolTip As String
                Dim blnNextEnd As Boolean
                blnNextEnd = True
                intMenuId = DV.Item(0).Item("mnu_Id")
                intMenuOrder = DV.Item(0).Item("mnu_Order")
                intParentMenuId = DV.Item(0).Item("mnu_Pmnuid")
                strMenuName = DV.Item(0).Item("mnu_Name").ToString()
                strMenuLink = DV.Item(0).Item("mnu_Link").ToString()
                strToolTip = DV.Item(0).Item("mnu_Tooltip").ToString()
                DV = DSAllMenus.Tables(0).DefaultView
                DV.RowFilter = "mnu_Pmnuid = " & intMenuId
                If DV.Count > 0 Then
                    blnNextEnd = False
                End If
                CreateMenuXMLNode(objXMLWriter, intParentMenuId, intMenuId, strMenuName, strMenuLink, strToolTip, intMenuOrder, blnNextEnd)
            End If
            objXMLWriter.WriteEndElement()
            objXMLWriter.Flush()
            objXMLWriter.Close()
            Dim strXMLResult As String
            Dim objSR As StreamReader = File.OpenText(strXMLPath)
            strXMLResult = objSR.ReadToEnd()
            objSR.Close()
            objSR = Nothing
            '-------------------- Write XML menu file end
            ltrMsg.Text = "Menu rights assigned successfully."



            ''------------------ Audit Code
            'Dim objFS As Object
            'objFS = Server.CreateObject("Scripting.FileSystemObject")
            'strCurrentPath = Server.MapPath(ConfigurationManager.AppSettings("AuditPath"))
            'clConn.AddAuditXMLNode(objFS, strCurrentPath, Session("UserID"), Session("AdminUserID"), Session("AdminUserName"), "Updated menu rights for user  - " & hdnAdminUserName.Value & " (" & hdnUserName.Value & ")")
            ''------------------ Audit Code
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message.ToString
        End Try
        GenerateMenuTree()
    End Sub

    Private Sub subSaveMenuRightsBottom_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles subSaveMenuRightsBottom.ServerClick
        SaveMenuRights()
    End Sub
End Class