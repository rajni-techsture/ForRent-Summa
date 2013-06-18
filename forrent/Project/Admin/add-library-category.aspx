<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="add-library-category.aspx.vb" Inherits="tsma.add_library_category" %>
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

    function ValidateCategoryDetails() {
        var fields
        fields = "";
        if (DoTrim(document.frm.txtCategoryName.value).length == 0) {
            fields = "\n-- Category Name --";
        }
        if (document.frm.drpCompany.value == 0 && document.getElementById("trind").style.display == "none") {
            fields = "\n-- Select Company --";
        }
        if (document.frm.drpIndustry.value == 0 && document.getElementById("trcomp").style.display == "none") {
            fields = "\n-- Select Industry --";
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

        document.frm.txtCategoryName.value = ""
       
    }
    function SelectType(objlb) {
        if (objlb.value == "1") {
            document.getElementById("trcomp").style.display = "";
            document.getElementById("trind").style.display = "none";
            document.getElementById("trind").value = "0"
            document.getElementById("drpIndustry").value = "0"

        }
        else if (objlb.value == "2") {
            document.getElementById("trind").style.display = "";
            document.getElementById("trcomp").style.display = "none";
            document.getElementById("trcomp").value = "0"
            document.getElementById("drpCompany").value = "0"
            
        }

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
                  <td height="25" valign="middle" class="title"><%if request("id")=""%>Add New<%else%>Edit<%end if%> Library Category</td>
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
					<td height="25" colspan="2" align="right" valign="top"><a href="manage-library-categories.aspx"><b>[ Manage Library Categories ] </b></a></td>
				</tr>
                <tr>
                  <td align="center" colspan="2" class="tdborder">
				  <table width="100%" border="0" cellpadding="2" cellspacing="1">
                                              <tr >
                                                <td width="20%" height="25" align="right" >Category Name:&nbsp;</td>
                                                <td height="25" align="left"><input name="txtCategoryName" runat="server" type="text" class="input" id="txtCategoryName" size="30"
																			maxlength="25">
                                                <font color="#ff0000">*</font></td>
                                              </tr>
                                             <tr >
                                                <td width="20%" height="25" align="right" ></td>
                                                <td height="25" align="left" valign="middle">
                                                <input type="radio" id="rdoComp" checked runat="Server" name="CompInd" value="1" onChange="SelectType(this);" />
													Company &nbsp;&nbsp;
													<input type="radio" id="rdoInd" runat="Server" name="CompInd" value="2" onChange="SelectType(this);" />
													Industry
                                                
                                               </td>
                                              </tr>
                                              <tr id="trcomp" runat="server">
                                                <td width="20%" height="25" align="right" >Company:&nbsp;</td>
                                                <td height="25" align="left" valign="middle">
                                                <select name="drpCompany" runat="server" class="input" id="drpCompany">
                                                <option value="0" selected>-- Select Company --</option>
                                                </select>
                                               <font color="#ff0000">*</font>
                                               </td>
                                              </tr>
                                               <tr id="trind" runat="server" style="display:none;">
                                                <td width="20%" height="25" align="right" >Industry:&nbsp;</td>
                                                <td height="25" align="left" valign="middle">
                                                <select name="drpIndustry" runat="server" class="input" id="drpIndustry">
                                                <option value="0" selected>-- Select Industry --</option>
                                                </select>
                                                 <font color="#ff0000">*</font>
                                               </td>
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
												<input runat="server" type="submit" class="AdminFormButton" id="btnSave" value="Save" onClick="return ValidateCategoryDetails();" />&nbsp;
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
