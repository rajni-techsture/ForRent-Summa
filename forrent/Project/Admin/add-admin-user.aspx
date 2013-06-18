<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="add-admin-user.aspx.vb" Inherits="tsma.add_admin_user" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
<script language="JavaScript" type="text/JavaScript">
		<!--

    function ValidateUserDetails() {
        var fields
        fields = "";
        if (DoTrim(document.frm.txtUserName.value).length == 0) {
            fields = "\n-- User Name --";
        }
        if (DoTrim(document.frm.txtPassword.value).length == 0) {
            fields = fields + "\n-- Password --";
        }
        if (DoTrim(document.frm.txtFname.value).length == 0) {
            fields = fields + "\n-- First Name --";
        }
        if (DoTrim(document.frm.txtLname.value).length == 0) {
            fields = fields + "\n-- Last Name --";
        }
        var re = new RegExp();
        re = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        var sinput;
        sinput = "";
        if (DoTrim(document.frm.txtEmail.value).length == 0) {
            fields = fields + "\n-- Email Address --";
        }
        else {
            sinput = DoTrim(document.frm.txtEmail.value);
            if (!re.test(sinput)) {
                fields = fields + "\n-- Invalid Email Address --";
                document.frm.txtEmail.value == "";
            }
        }
        if (fields != "") {
            fields = "Please fill in the following details:\n--------------------------------\n" + fields;
            alert(fields);
            return false;
        }
        else {
            return true;
        }
    }
    function DoTrim(strComp) {
        ltrim = /^\s+/
        rtrim = /\s+$/
        strComp = strComp.replace(ltrim, '');
        strComp = strComp.replace(rtrim, '');
        return strComp;
    }
    function reset() {

        document.frm.txtUserName.value = ""
        document.frm.txtPassword.value = ""
        document.frm.txtFname.value = ""
        document.frm.txtLname.value = ""
        document.frm.txtEmail.value = ""

    }

		//-->
		</script>
</head>
<body>
    
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" align="center">
<form id="frm" name="frm" runat="server">
<asp:ScriptManager ID="objScriptManager" runat="server">
    </asp:ScriptManager>
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
              <td align="left" valign="top" bgcolor="#FFFFFF" class="imgborder" style="padding:16px ">
			<asp:UpdatePanel ID="pnlMain" runat="server"><ContentTemplate> 
			  <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr valign="middle" align="center" bgcolor="#ffffff">
                  <td bgcolor="#ffffff"></td>
                </tr>
                <tr>
                  <td height="25" valign="middle" class="title"><%if request("id")=""%>Add New<%else%>Edit<%end if%> Admin User</td>
				    <td height="25" valign="middle" align="right">
					<div style="margin-right:0px;width:74px;height:24px;overflow:hidden">
					<asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0">
					<ProgressTemplate>
						<img src="../Content/adminimages/popuploading.png" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" />
					</ProgressTemplate>
					</asp:UpdateProgress>
					</div>
					</td>
				</tr>
				<tr>
                	<td align="center" colspan="2" style="color:red;font-weight:bold;padding:5px;"><asp:Literal id="ltrMsg" runat="server"></asp:Literal></td>
              	</tr>
				<tr>
					<td height="25" colspan="2" align="right" valign="top"><a href="manage-admin-users.aspx"><b>[ Manage Admin Users ] </b></a></td>
				</tr>
                <tr>
                  <td align="center" colspan="2" class="tdborder">
				  <table width="100%" border="0" cellpadding="2" cellspacing="1">
                                              <tr >
                                                <td width="20%" height="25" align="right" >User Name:&nbsp;</td>
                                                <td height="25" align="left"><input name="txtUserName" runat="server" type="text" class="input" id="txtUserName" size="30"
																			maxlength="25">
                                                <font color="#ff0000">*</font></td>
                                              </tr>
                                              <tr >
                                                <td height="25" align="right">Password:&nbsp;</td>
                                                <td height="25" align="left"><input name="txtPassword" runat="server" type="text" class="input" id="txtPassword" size="30"
																			maxlength="25">
                                                <font color="#ff0000">*</font></td>
                                              </tr>
                                              <tr >
                                                <td height="25" align="right">First Name:&nbsp; </td>
                                                <td height="25" align="left"><input name="txtFname" type="text" runat="server" class="input" id="txtFname" size="30"
																			maxlength="50">
                                                <font color="#ff0000">*</font></td>
                                              </tr>
                                              <tr >
                                                <td height="25" align="right">Last Name:&nbsp; </td>
                                                <td height="25" align="left"><input name="txtLname" type="text" runat="server" class="input" id="txtLname" size="30"
																			maxlength="50">
                                                <font color="#ff0000">*</font></td>
                                              </tr>
                                              <tr >
                                                <td height="25" align="right">Email:&nbsp;</td>
                                                <td height="25" align="left"><input name="txtEmail" type="text" runat="server" class="input" id="txtEmail" size="30"
																			maxlength="60">
                                               <font color="#ff0000">*</font></td>
                                              </tr>
											   <tr>
												  <td align="right" valign="middle">Status:</td>
												  <td ><input type="radio" id="rdoActive" checked runat="Server" name="ActiveInactive" value="1" />
													Active &nbsp;&nbsp;
													<input type="radio" id="rdoInactive" runat="Server" name="ActiveInactive" value="2" />
													Inactive </td>
												</tr>
                                              <tr >
											   <td height="25" align="right">&nbsp;</td>
                                                <td height="30" align="left" >
												<input runat="server" type="submit" class="AdminFormButton" id="btnSave" value="Save" onClick="return ValidateUserDetails();" />&nbsp;
												<input type="reset" class="AdminFormButton" value="Reset" id="reset" onClick="return reset();" />
												</td>
                                              </tr>
                                            </table>
                  </td>
                </tr>
              </table>
			</ContentTemplate></asp:UpdatePanel>
			  </td>
            </tr>
        </table></td>
      </tr>
      <tr align="center" valign="middle">
        <td colspan="2" valign="top" height="25"><uc3:footer ID="Footer1" runat="server" /></td>
        </tr>
    </table>
    </td>
  </tr>
</form>
</table>
</body>
</html>
