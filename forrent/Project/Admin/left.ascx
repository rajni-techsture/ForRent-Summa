<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="left.ascx.vb" Inherits="tsma.left1" %>
<link rel="STYLESHEET" type="text/css" href="../Content/xmlmenu/dhtmlXMenu.css">
<script language="JavaScript" src="../Content/xmlmenu/dhtmlXProtobar.js"></script>
<script language="JavaScript" src="../Content/xmlmenu/dhtmlXMenuBar.js"></script>
<script language="JavaScript" src="../Content/xmlmenu/dhtmlXCommon.js"></script>
<table width="100%"  border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" class="imgborder">
<tr>
	<td align="center" valign="top">
	<div id="Menu"/>
	  <script type="text/javascript" language="javascript">
		aMenuBar3=new dhtmlXMenuBarObject('Menu',160,200,'<%="<b>" & Session("AFullName") & "</b>"%>',1);
		aMenuBar3.setGfxPath("../Content/xmlmenu/img/");
        aMenuBar3.loadXML("../Content/xmlmenu/admin.xml")
//		aMenuBar3.loadXML("../Content/xmlmenu/<%=session("AUserName")%>.xml")
		aMenuBar3.showBar();
	</script>
	</td>
	</tr>
</table>