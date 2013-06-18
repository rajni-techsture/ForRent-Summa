<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="test-add-library-data.aspx.vb" Inherits="tsma.test_add_library_data" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fck" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/css/admin-style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="frm" name="frm" runat="server">
<asp:ScriptManager ID="objScriptManager" runat="server">
    </asp:ScriptManager>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" align="center">
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
                  <td height="25" valign="middle" class="title"><%if request("LDId")=""%>Add New<%else%>Edit<%end if%>Library Category</td>
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
					<td height="25" colspan="2" align="right" valign="top"><a href="manage-library-data.aspx"><b>[ Manage Library ] </b></a></td>
				</tr>
                <tr>
                  <td align="center" colspan="2" class="tdborder">
				  <table width="100%" border="0" cellpadding="2" cellspacing="1">
                                             <tr>
                                                <td width="20%" height="25" align="right" >Select Type:</td>
                                                <td height="25" align="left" valign="middle">
                                                <input type="hidden" id="hdnIsCompInd" runat="server" />
                                                <input type="radio" id="rdoComp" checked runat="Server" name="CompInd" value="1" onChange="SelectType(this);" />
													Company &nbsp;&nbsp;
													<input type="radio" id="rdoInd" runat="Server" name="CompInd" value="2" onChange="SelectType(this);" />
													Industry
                                                
                                               </td>
                                              </tr>
                                              <tr id="trcomp" runat="server">
                                                <td width="20%" height="25" align="right" >Company:&nbsp;</td>
                                                <td height="25" align="left" valign="middle">
                                                <asp:DropDownList id="drpCompany" runat="server" class="input" AutoPostBack="true"></asp:DropDownList>
                                                <font color="#ff0000">*</font>
                                               </td>
                                              </tr>
                                               <tr id="trind" runat="server" style="display:none;">
                                                <td width="20%" height="25" align="right" >Industry:&nbsp;</td>
                                                <td height="25" align="left" valign="middle">
                                                <asp:DropDownList id="drpIndustry" runat="server" class="input" AutoPostBack="true"></asp:DropDownList>
                                                <font color="#ff0000">*</font>
                                               </td>
                                              </tr>
                                              <tr id="trcat" runat="server" >
                                                <td width="20%" height="25" align="right" >Library Category:&nbsp;</td>
                                                <td height="25" align="left" valign="middle">
                                                 <asp:DropDownList id="drpCategory" runat="server" class="input"></asp:DropDownList>
                                                 <font color="#ff0000">*</font>
                                               </td>
                                              </tr>
                                              <tr >
                                                <td height="25" align="right">Description:&nbsp;</td>
                                                <td height="25" align="left"> 
                                               <font color="#ff0000">*</font></td>
                                              </tr>
                                              <tr >
                                                <td height="25" align="right" >Video URL:&nbsp;</td>
                                                <td height="25" align="left"><input name="txtVideo" runat="server" type="text" class="input" id="txtTitle" size="65" />
                                                <font color="#ff0000">*</font></td>
                                              </tr>
                                               <tr >
                                                <td height="25" align="right">Upload Photo:&nbsp;</td>
                                                <td height="25" align="left">
                                                <input type="file" id="photo" runat="server"><span class="SmallText">(jpg, jpeg, bmp, gif files only)</span>&nbsp;<br/>
                                                 <asp:Label id="lblPhoto" runat="server"></asp:Label>
							                    <input type="hidden" ID="hdnimagevalue" runat="server" />
							                    <input type="hidden" id="hdnImage" runat="server" />
                                               </td>
                                              </tr>
                                              <tr>
                                                <td width="10%" height="25" align="right" >Preview Image:&nbsp;</td>
                                                <td height="25" align="left">
                                                <img src="../content/adminimages/noimage.png" width="150" height="150"  id="imgPhoto" runat="server" />
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
												<input runat="server" type="submit" class="AdminFormButton" id="btnSave" value="Save" onClick="return ValidateDataDetails();" />&nbsp;
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
  </table>
</form>
</body>
</html>
