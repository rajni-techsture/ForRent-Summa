<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="all-menus.aspx.vb" Inherits="tsma.all_menus" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
<html>
        <head id="Head1" runat="server">
<title>Total Social Media System</title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
<link href="../Content/css/admin-style.css" rel="stylesheet" type="text/css">
<link rel="STYLESHEET" type="text/css" href="../Content/xmlmenu/dhtmlXMenu.css">
<script language="JavaScript" src="../Content/xmlmenu/dhtmlXProtobar.js"></script>
<script language="JavaScript" src="../Content/xmlmenu/dhtmlXMenuBar.js"></script>
<script language="JavaScript" src="../Content/xmlmenu/dhtmlXCommon.js"></script>
        </head>
        <body>
<form id="frm" name="frm" runat="server">
          <asp:ScriptManager ID="ScriptManager2" runat="server"> </asp:ScriptManager>
          <input type="hidden" id="hdnUserName" runat="server" />
          <input type="hidden" id="hdnAdminUserName" runat="server" />
          <table width="1004" height="100%" border="0" cellpadding="0" cellspacing="0" align="center">
    <tr>
              <td height="10" valign="top"><uc1:header ID="Header1" runat="server" /></td>
            </tr>
    <tr>
              <td align="left" valign="top" bgcolor="#DAE0F3" style="background-repeat:repeat-x;"><table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                  <td width="165" align="left" valign="top" style="padding:9px; "><uc2:left ID="Left1" runat="server" /></td>
                  <td align="left" valign="top" style="padding:9px; padding-left:0px; padding-bottom:0px "><table width="100%" height="100%"  border="0" cellpadding="0" cellspacing="0">
                      <tr>
                      <td align="left" valign="top" bgcolor="#FFFFFF" class="imgborder" style="padding:16px "> 
					  <asp:UpdatePanel ID="pnlMain" runat="server"><ContentTemplate>
                          <input  name="btnMoveMenuHandler" id="btnMoveMenuHandler" type="button" runat="Server" style="display:none" />
                          <input  name="btnEditMenuHandler" id="btnEditMenuHandler" type="button" runat="Server" style="display:none" />
                          <input  name="btnChangeStatusHandler" id="btnChangeStatusHandler" type="button" runat="Server" style="display:none" />
                          <table width="100%" border="0" cellspacing="0" cellpadding="2">
                          <tr align="left">
                              <td width="39%" height="25" valign="middle" class="title">Assign Menu Rights to Users</td>
                              <td width="61%" height="25" align="right" valign="middle"><div style="margin-right:0px;width:74px;height:24px;overflow:hidden"> <asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0"> <ProgressTemplate> <img src="../content/adminimages/popuploading.png" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate> </asp:UpdateProgress> </div></td>
                            </tr>
                          <tr>
                              <td colspan="2" align="center" height="15" style="color:red;font-weight:bold;"><asp:Literal id="ltrMsg" runat="server"></asp:Literal></td>
                            </tr>
                          <tr>
                              <td colspan="2" align="left" valign="top" class="tdborder"><table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#EAEAEA">
                                  <tr>
                                  <td height="25" bgcolor="#f7f7f7"><table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                      <tr style="display:none;">
                                      <td class="arial1b">&nbsp;</td>
                                      <td width="100" align="center"><a href="#" onClick="MM_openBrWindow('Preview-Menus.aspx','','scrollbars=yes,width=650,height=450,left=5,top=5');"><strong>[ Preview Menu ]</strong></a> </td>
                                    </tr>
                                    </table></td>
                                </tr>
                                  <tr>
                                  <td height="35" bgcolor="#ffffff" sy><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                      <tr>
                                      <td><input class="chk" id="chkCheckUncheckAllTop" onClick="CheckUncheckAll(this)" type="checkbox" value="1" name="chkCheckUncheckAllTop" align="absMiddle">
&nbsp;Click to check all menu items </td>
                                      <td width="180" align="center"><input name="subSaveMenuRightsTop" type="submit" class="AdminFormButton" id="subSaveMenuRightsTop" value="Assign Menu Rights" runat="server">
                                        </td>
                                    </tr>
                                    </table></td>
                                </tr>
                                  <tr>
                                  <td align="left" bgcolor="#ffffff" style="padding:10px;"><ASP:LITERAL id="ltrAllMenus" runat="server" EnableViewState="false"></ASP:LITERAL></td>
                                </tr>
                                  <tr>
                                  <td bgcolor="#ffffff" style="height: 35px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                      <tr>
                                      <td style="height: 24px"><input class="chk" id="chkCheckUncheckAllBottom" onClick="CheckUncheckAll(this)" type="checkbox" value="2" name="chkCheckUncheckAllBottom" align="absMiddle">
&nbsp;Click to check all menu items </td>
                                      <td width="180" align="center" style="height: 24px"><input name="subSaveMenuRightsBottom" type="submit" class="AdminFormButton" id="subSaveMenuRightsBottom" value="Assign Menu Rights" runat="server">
                                        </td>
                                    </tr>
                                    </table></td>
                                </tr>
                                </table></td>
                            </tr>
                        </table>
                          </ContentTemplate></asp:UpdatePanel> </td>
                    </tr>
                    </table></td>
                </tr>
                  <tr align="center" valign="middle">
                  <td colspan="2" valign="top" height="25"><uc3:footer ID="Footer1" runat="server" /></td>
                </tr>
                </table></td>
            </tr>
  </table>
        </form>
</body>
        </html>
<script language="javascript">
		<!--
    function ob_t2_SelectCheckboxes(bType) {
        var arrElements = document.getElementsByTagName("input");
        if (arrElements.length) {
            for (var i = 0; i < arrElements.length; i++) {
                if (arrElements[i].type == "checkbox" && ob_elementBelongsToTree(arrElements[i])) {
                    arrElements[i].checked = bType;
                }
            }
        }
    }
    function CheckUncheckAll(Obj) {
        if (Obj.value == 1) {
            if (document.frm.chkCheckUncheckAllTop.checked) {
                ob_t2_SelectCheckboxes(true);
                document.frm.chkCheckUncheckAllBottom.checked = true;
            }
            else {
                ob_t2_SelectCheckboxes(false);
                document.frm.chkCheckUncheckAllBottom.checked = false;
            }
        }
        else {
            if (document.frm.chkCheckUncheckAllBottom.checked) {
                ob_t2_SelectCheckboxes(true);
                document.frm.chkCheckUncheckAllTop.checked = true;
            }
            else {
                ob_t2_SelectCheckboxes(false);
                document.frm.chkCheckUncheckAllTop.checked = false;
            }
        }
    }
    function MM_openBrWindow(theURL, winName, features) {
        if (theURL) {
            theURL = "Preview-Menus.aspx?Id=" + document.frm.hdnUserName.value + '&name=' + document.frm.hdnAdminUserName.value;
            window.open(theURL, winName, features);
        }
    }
		//-->
		</script>
		