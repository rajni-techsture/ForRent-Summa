<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="tsma.index" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
<title>Forrent.Com</title>
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
</head>
<body>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" align="center">
<form id="frm" name="frm" runat="server">
  <tr>
    <td height="10" valign="top"><uc1:header ID="Header1" runat="server" /></td>
  </tr>
  <tr>
    <td align="left" valign="top" bgcolor="#DAE0F3" style="background-repeat:repeat-x;">
	<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="165" align="left" valign="top" style="padding:9px; "><uc2:left ID="Left1" runat="server" /></td>
        <td align="left" valign="top" style="padding:9px; padding-left:0px; padding-bottom:0px "><table width="100%" height="100%"  border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td align="left" valign="top" bgcolor="#FFFFFF" class="imgborder" style="padding:16px "><table width="100%"  border="0" cellspacing="0" cellpadding="0">
			  	<tr>
                    <td align="center">&nbsp;</td>
                  </tr>
                  <tr>
                    <td class="title" align="center">Welcome to Total Social Media System Admin Section</td>
                  </tr>
                  <tr><td>&nbsp;</td></tr>
              </table></td>
            </tr>
        </table></td>
      </tr>
      <tr align="center" valign="middle">
        <td height="25" colspan="2" valign="top"><uc3:footer ID="Footer1" runat="server" /></td>
        </tr>
    </table></td>
  </tr>
</form>
</table>
</body>
</html>
