<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="tsma._default1" %>

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
<link href="../Content/css/admin-style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="frm" runat="server">
 <asp:ScriptManager ID="objScriptManager" runat="server">
    </asp:ScriptManager>
<table width="100%" height="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="68" align="left" valign="middle" background="../Content/adminimages/ProjectsHeader.jpg" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
	 <tr>
        <td valign="middle"><img src="../Content/adminimages/admin-logo.gif" hspace="15" /></td>
        <td align="right" style="padding-top:8px">&nbsp;</td>
      </tr>
         </table></td>
  </tr>
  <tr>
    <td align="left" valign="top" bgcolor="#DAE0F3" style="background-repeat:repeat-x "><table width="100%" height="100%"  border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td align="left" valign="top" style="padding:10px;">
		<table width="100%" height="100%"  border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td align="center" valign="middle" bgcolor="#FFFFFF" class="imgborder" style="padding:16px;">
           <div id="divLoading" style="position:absolute; padding-left:350px;" >
			<asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0">
			<ProgressTemplate>
				<div class="loadingbg"><img src="../content/adminimages/ajax-loader.gif" width="32" height="32" vspace="22" /><div class="loadingtext">Loading...</div></div>
			</ProgressTemplate>
			</asp:UpdateProgress>
			</div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ><ContentTemplate>
            <table width="500" height="193" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr valign="top">
                  <td><img src="../Content/adminimages/OZ-login-left.jpg" width="193" height="195"  border="0" usemap="#MapMap" /></td>
                  <td width="100%"><table width="88%"  border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top"><img src="../Content/adminimages/OZ-login-righttop.gif" width="278" height="21"/></td>
                      </tr>
                      <tr>
                        <td><table width="100%"  border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td height="174" align="left" valign="top" background="../Content/adminimages/OZ-login-rightdown.gif">
							  <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1">
                                   <tr>
                                    <td colspan="2" height="30" ><span class="arial1bred">
                                      <asp:Label ID="lblMsg" runat="server" ForeColor="Red" ></asp:Label>
                                    </span></td>
                                  </tr>
                                 
                                   <tr>
                                    <td width="98" align="right" valign="middle" class="arial1b"><strong>Username:</strong></td>
                                    <td width="169" align="left" valign="middle"><asp:TextBox ID="txtUserName" runat="server" name="txtUserName" CssClass="input" MaxLength="19"></asp:TextBox></td>
                                  </tr>
                                   <tr>
                                    <td align="right" valign="middle" class="arial1b"><strong>Password:</strong></td>
                                    <td align="left" valign="middle"><asp:textbox id="txtPassword" runat="server" name="txtPassword" CssClass="input" maxLength="14"
																									TextMode="Password"></asp:textbox></td>
                                  </tr>
                                   <tr>
                                    <td align="right" valign="middle"><strong>Security Code:</strong></td>
                                    <td align="left" valign="middle">
									<input  name="txtcode1"  type="text"  class="input" id="txtcode1" size="5" maxlength="6" runat="server" >
									<IMG name="imgcode1" width="91" Border="1" height="29"  align=absmiddle id="imgcode1" runat="server" >
									<input class="input" id="hdncode1" type="hidden" runat="server" width="" NAME="hdncode1" />
									</td>
                                  </tr>
                                   <tr>
                                    <td align="center">&nbsp;</td>
                                    <td align="left" valign="middle">
									<a style="cursor:pointer"  id="hrefTryOtherT1" onserverclick="hrefTryOtherT1_ServerClick" runat="server" ><strong>Try Other!</strong></a>
									</td>
                                  </tr>
								   <tr>
                                    <td align="center">&nbsp;</td>
                                    <td align="left" valign="middle">
                                    <input id="imglogin" type="image" runat="server" onClick="return validatelogin();" name="imglogin" src="../Content/adminimages/b-login1.gif" alt="Login" width="71" height="25" >
                                    </td>
                                  </tr>
                              </table>
							  </td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                </tr>
              </table>
              </ContentTemplate>
              </asp:UpdatePanel>
              </td>
          </tr>
        </table></td>
      </tr>
      <tr align="center" valign="middle">
        <td height="25" valign="top">Copyright: © TSMA, Inc., 2008 All Rights Reserved.</td>
        </tr>
    </table></td>
  </tr>
</table>
</form>
</body>
</html>

<script type="text/javascript">
<!--
    function DoTrim(strComp) {
        ltrim = /^\s+/
        rtrim = /\s+$/
        strComp = strComp.replace(ltrim, '');
        strComp = strComp.replace(rtrim, '');
        return strComp;
    }

    function validatelogin() {
        var fields = "";
        if (DoTrim(document.getElementById('txtUserName').value).length == 0) {
            fields = fields + "\n-- UserName --";
        }
        if (DoTrim(document.getElementById('txtPassword').value).length == 0) {
            fields = fields + "\n-- Password --";
        }
        if (DoTrim(document.getElementById('txtcode1').value).length == 0) {
            fields = fields + "\n-- Security Code --";
        }

        if (fields != "") {
            fields = "Please fill in the following details\n--------------------------------------\n" + fields;
            alert(fields);
            return false;
        }
        else {
            return true;
        }

    }
-->
</script>
