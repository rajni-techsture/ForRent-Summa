<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="header.ascx.vb" Inherits="tsma.header1" %>
<table width="100%"  border="0" cellpadding="0" cellspacing="0" background="../Content/adminimages/ProjectsHeader.jpg">
      <tr>
        <td height="68" align="right" valign="centwr"><table width="100%" border="0" cellspacing="0" cellpadding="0">
		
            <tr>
              <td width="200" valign="middle" onClick="gotourl('index.aspx')" style="cursor:pointer"><img src="../Content/adminimages/admin-logo.gif"  hspace="15"></td>
              <td height="55" align="left" valign="top" style="padding-right:10px; padding-top:10px; "><table width="100%" height="100%"  border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td align="right" valign="top">
	<font color="#FFFFFF"><strong><a href="index.aspx" class="white"  title="Home">Home</a> | 
	<a href="logout.aspx" onclick="return confirm('Are you sure you want to logout?');" class="white" title="Logout">Logout</a>
	</strong></font>
	
</td>
  </tr>
  <tr>
    <td align="right" valign="bottom"><font color="#FFFFFF"><strong>
              <asp:Literal ID="ltrUserName" runat="server"></asp:Literal></strong></font>&nbsp;&nbsp;</td>
  </tr>
</table>
</td>
            </tr>
          </table></td>
      </tr>
</table>
<script language="javascript">
<!--
    function gotourl(pageurl) {
        location.href = pageurl;
    }
//-->
</script>