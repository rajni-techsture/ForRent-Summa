<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="export-import.aspx.vb" Inherits="WhiteLotusLiving.export_import" %>
<%@ Register src="header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="footer.ascx" tagname="footer" tagprefix="uc2" %>
<html>
<head>
<title>Welcome to White Lotus Living!</title>
<link href="style-admin.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
<script type="text/javascript" src="../incs/common.js"></script>
<script type="text/javascript" src="../incs/jquery.js"></script>
<link type="text/css" href="../incs/tabs/themes/base/ui.all.css" rel="stylesheet" />
<script type="text/javascript" src="../incs/tabs/jquery-1.3.2.js"></script>
<script type="text/javascript" src="../incs/tabs/ui/ui.core.js"></script>
<script type="text/javascript" src="../incs/tabs/ui/ui.tabs.js"></script>
<link type="text/css" href="../incs/tabs/demos.css" rel="stylesheet" />
<script type="text/javascript">
$(function() {
$("#tabs").tabs();
});
</script>
<script language="javascript" type="text/javascript">
function settabdata(val)
{
	document.getElementById("hdnTabid").value=val;
}
function setTab()
{
  window.setTimeout("jQuery('#tabs').tabs('select', document.getElementById('hdnTabid').value);",1);
}


</script>
</head>
<body  onLoad="initMenu();">
<iframe width="174"  height="189" name="gToday:normal:agenda.js" id="gToday:normal:agenda.js" src="../calender/ipopeng.htm" scrolling="no" frameborder="0" style="visibility:visible; z-index:999; position:absolute; top:-500px;"></iframe>
<form id="frm" name="frm" runat="server">
  <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
  <table  width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td height="10" align="left" valign="top"><uc1:header ID="header1" runat="server" /></td>
    </tr>
    <tr>
      <td align="left" valign="top"  style="padding-left:16px;padding-right:16px"><table class="imgborder" width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
          <tr>
            <td align="left" valign="top" style="padding:10px"><div id="divLoading" style="position:absolute;">
                <asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0">
                  <ProgressTemplate> <img src="../images/popuploading.png" style="border:0px;font-family:Tahoma;font-size:12px;" title="Loading" /> </ProgressTemplate>
                </asp:UpdateProgress>
              </div>
     			<!--<asp:UpdatePanel ID="pnlMain" runat="server"><ContentTemplate> -->
                  <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                  <td class="title">Export / Import</td>
                </tr>
				 <tr>
				   <td height="20"><input type="hidden" id="hdnTabid" runat="server"></td>
			    </tr>
				 <tr>
                  <td height="30" align="left" valign="top">				  		   
				  <div id="tabs">
	<ul>
		<li><a href="#tabs-1" onClick="settabdata('#tabs-1');">Export</a></li>
		<li><a href="#tabs-2" onClick="settabdata('#tabs-2');">Import</a></li>
	</ul>

	<div id="tabs-1">
 
					  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          
                          <tr>
                            <td height="29" align="left" valign="middle"><strong><img src="../images/export.gif" width="32" height="32" align="absmiddle">&nbsp;&nbsp;Export a data file in CSV or XML format </strong></td>
                          </tr>
                          <tr>
                            <td height="25" align="left" valign="top">Export:
							<asp:RadioButton id="rdoProducts" GroupName="Export" runat="server" Checked="true" AutoPostBack="true"></asp:RadioButton>
							
							Products &nbsp;
							<asp:RadioButton id="rdoCustomers" GroupName="Export" runat="server" AutoPostBack="true"></asp:RadioButton>
							
							Customers &nbsp;
                           
							<asp:RadioButton id="rdoOrders" GroupName="Export" runat="server" AutoPostBack="true"></asp:RadioButton>
							
							Orders&nbsp;</td>
                          </tr>
                          <tr>
                            <td height="8" align="left" valign="middle"></td>
                          </tr>
						  <asp:Panel id="pnlProducts" runat="server">
                          <tr>
                            <td height="25" align="left" valign="top" style="padding:5px;"  class="tdborder" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td width="9%" height="30" align="right" valign="middle">Filter Products:&nbsp;</td>
                                <td width="91%" height="30" align="left" valign="middle"><div style="float:left"><select id="cmbFilterProducts" runat="server" class="input" onChange="HideShowCategories(this);">
							<option value="0">All Products</option>
							<option value="1">By Categories</option>
                            <option value="2">By Vendors</option>                               
						</select></div></td>
                              </tr>
                                <tr id="trCategories" runat="Server" style="display:none">
                                <td height="30" align="right" valign="middle">&nbsp;</td>
                                <td height="30" align="left" valign="middle">
								<div style="border:1px solid #DEDEDE;">
								<table width="100%"  border="0" cellspacing="5" cellpadding="0">
								<tr>
								<td style="font-weight:bold">
								Filter Categories:&nbsp;
								<input type="text" id="txtFilter" onKeyUp="Filter();" runat="server" class="input" size="20"/>								</td>
								</tr>
								<tr>
								<td style="border:1px solid #DEDEDE">
								<div style="background-color:#FEFEF6;padding-top:3px;padding-bottom:3px;border-bottom:1px solid #DEDEDE">
									<input id="chkSelectAll" type="checkbox" runat="server" OnClick="SelectCategories(this);" />&nbsp;<b>Select All</b>								</div>
								<div style="height:200px;overflow:auto">
								<asp:Repeater ID="rptCategories" runat="server">
								<ItemTemplate>
									<div class="CheckBoxDiv" style="background-color:#FFFFFF">
										<asp:CheckBox ID="chkCategory" Text='<%#Eval("cat_Name")%>' runat="server" />
										<input type="hidden" runat="server" id="hdnId" value='<%#Eval("cat_Id")%>' />
									</div>
								</ItemTemplate>
								</asp:Repeater>
								</div>								</td>
								</tr>
								</table>
								</div>								</td>
                              </tr>
                              <tr id="trVendors" runat="Server" style="display:none">
                                <td height="30" align="right" valign="middle">&nbsp;</td>
                                <td height="30" align="left" valign="middle">
								<div style="border:1px solid #DEDEDE;">
								<table width="100%"  border="0" cellspacing="5" cellpadding="0">
								<tr>
								<td style="font-weight:bold">
								Filter Vendors:&nbsp;
								<input type="text" id="txtFilterVendors" onKeyUp="FilterVendors();" runat="server" class="input" size="20"/>								</td>
								</tr>
								<tr>
								<td style="border:1px solid #DEDEDE">
								<div style="background-color:#FEFEF6;padding-top:3px;padding-bottom:3px;border-bottom:1px solid #DEDEDE">
									<input id="chkSelectAllVendors" type="checkbox" runat="server" OnClick="SelectVendors(this);" />&nbsp;<b>Select All</b>								</div>
								<div style="height:200px;overflow:auto">
								<asp:Repeater ID="rptVendors" runat="server">
								<ItemTemplate>
									<div class="CheckBoxDiv" style="background-color:#FFFFFF">
										<asp:CheckBox ID="chkVendors" Text='<%#Eval("vnd_Name")%>' runat="server" />
										<input type="hidden" runat="server" id="hdnId" value='<%#Eval("vnd_Id")%>' />
									</div>
								</ItemTemplate>
								</asp:Repeater>
								</div>								</td>
								</tr>
								</table>
								</div>								</td>
                              </tr>
                              <tr>
                                <td height="30" align="right" valign="middle">File Type:&nbsp; </td>
                                <td height="30" align="left" valign="middle">
								<asp:DropDownList ID="ddlFileType" runat="server" AutoPostBack="false" CssClass="input">
								<asp:ListItem value="1" Selected="true">CSV</asp:ListItem>
								<asp:ListItem value="2">XML</asp:ListItem>
								</asp:DropDownList>								</td>
                              </tr>
                              <tr>
                                <td height="30">&nbsp;</td>
                                <td height="30"><span style="padding-top:5px;">
                                  <input name="submit" type="submit" class="AdminFormButton" id="btnExportProducts" value="Export File" runat="server" />
                                </span></td>
                              </tr>
                            </table></td>
                          </tr>
						  </asp:Panel>
                           <asp:Panel id="pnlCustomers" runat="server">
                          <tr>
                            <td height="25" align="left" valign="top" style="padding:5px;"  class="tdborder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              
                              
                              <tr>
                                <td width="9%" height="30" align="right" valign="middle">File Type:&nbsp; </td>
                                <td width="91%" height="30" align="left" valign="middle"><div style="float:left"><asp:DropDownList ID="ddlFileType1" runat="server" AutoPostBack="false" CssClass="input">
                                    <asp:ListItem value="1" Selected="true">CSV</asp:ListItem>
                                    <asp:ListItem value="2">XML</asp:ListItem>
                                  </asp:DropDownList></div>                                </td>
                              </tr>
                              <tr>
                                <td height="30">&nbsp;</td>
                                <td height="30"><span style="padding-top:5px;">
                                  <input name="btnExportCustomer" type="submit" class="AdminFormButton" id="btnExportCustomer" value="Export File" runat="server" />
                                </span></td>
                              </tr>
                            </table></td>
                          </tr>
						  </asp:Panel>
                          <asp:Panel id="pnlOrders" runat="server">
						    <tr>
                            <td height="25" align="left" valign="top" style="padding:5px;"  class="tdborder"><table width="100%"  border="0" cellpadding="3" cellspacing="0">
  <tr>
    <td align="right" >Order Date:&nbsp;</td>
    <td align="left" >From:&nbsp; 
        <input NAME="txtFromDate" type="text" class="input" id="txtFromDate" size="10" maxlength="10" runat="server" />
      &nbsp;<a href="javascript:void(0)" onClick="if(self.gfPop)gfPop.fPopCalendar(document.getElementById('txtFromDate'));return false;"
						hidefocus><img src="../images/icon-calendar.gif" width="15" height="15" border="0" align="absMiddle"></a>&nbsp; &nbsp;&nbsp;To:
      <input NAME="txtToDate" type="text" class="input" id="txtToDate" size="10" maxlength="10" runat="server"/>
      &nbsp;<a href="javascript:void(0)" onClick="if(self.gfPop)gfPop.fPopCalendar(document.getElementById('txtToDate'));return false;"
																	hidefocus><img src="../images/icon-calendar.gif" width="15" height="15" border="0" align="absMiddle"></a>&nbsp;&nbsp;(mm/dd/yyyy)&nbsp; &nbsp; </span></td>
  </tr>
                                                                    <tr>
                                                                    <td align="right">Order Status:&nbsp;</td>
                                                                    <td align="left">
      <select name="cmbOrderStatus" class="input" id="cmbOrderStatus" runat="server" >
       <option value="-1" selected> All</option>
        <option  value="0"  >New</option>
        <option value="2">Cancelled</option>
        <option value="4">Partially Shipped</option>
        <option value="1">Fully Shipped</option>
        <option value="3"> Failed </option>
        <option value="6">Fraud</option>
        <option value="5">Not Fraud</option>
       
      </select></td>
  </tr>
    <tr>
    <td width="9%" height="30" align="right" valign="middle">File Type:&nbsp; </td>
    <td width="91%" height="30" align="left" valign="middle"><asp:DropDownList ID="ddlFileTypeOrder" runat="server" AutoPostBack="false" CssClass="input">
      <asp:ListItem value="1" Selected="true">CSV</asp:ListItem>
      <asp:ListItem value="2">XML</asp:ListItem>
    </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td height="30">&nbsp;</td>
    <td height="30"><span style="padding-top:5px;">
      <input name="btnExportOrder" type="submit" class="AdminFormButton" id="btnExportOrder" value="Export File" runat="server" />
    </span></td>
  </tr>
  <tr>
    <td align="left" colspan="2">&nbsp;</td>
  </tr>
</table>
</td>
                          </tr>
						  </asp:Panel>
						
                      </table>

		
	</div>
		<div id="tabs-2">
						  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          
                          <tr>
                            <td height="29" align="left" valign="middle"><strong><img src="../images/imports.gif" width="32" height="32" align="absmiddle">&nbsp;&nbsp;Import Products or Customers data into your store from an CSV/XML file </strong></td>
                          </tr>
                          <tr>
                            <td height="25" align="left" valign="top">Import:
							<asp:RadioButton id="rdoProductsImport" GroupName="Import" runat="server" Checked="true"></asp:RadioButton>
							
							Products &nbsp;
							<asp:RadioButton id="rdoCustomersImport" GroupName="Import" runat="server"></asp:RadioButton>
							
							Customers &nbsp;
							<!--<asp:RadioButton id="rdoOrdersImport" GroupName="Import" runat="server"></asp:RadioButton>
							
							Orders&nbsp; --></td>
                          </tr>
                          <tr>
                            <td height="8" align="left" valign="middle"></td>
                          </tr>
                          <tr>
                            <td height="8" align="left" valign="middle"><table cellpadding="0" cellspacing="0" border="0" width="100%">
                              
                              <tr>
                                <td align="left" valign="top"><div style="font-weight:bold;text-align:center;color:#990000;padding:5px;">
                                    <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
                                  </div>
                                    <table width="100%"  border="0" cellspacing="0" cellpadding="3">
                                      <tr id="trProductTemplate" >
                                        <td align="right" >&nbsp;</td>
                                        <td align="right" ><div style="float:right"><asp:LinkButton id="lnkProductCSVTemplate" runat="server"><strong>Download Product CSV Template</strong></asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton id="lnkProductXMLTemplate" runat="server"><strong>Download Product XML Template</strong></asp:LinkButton></div></td>
                                      </tr>
                                       <tr id="trCutomerTemplate"  style="display:none;">
                                        <td align="right" >&nbsp;</td>
                                        <td align="right" ><div style="float:right"><asp:LinkButton id="lnkCustomerCSVTemplate" runat="server"><strong>Download Customer CSV Template</strong></asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton id="lnkCustomerXMLTemplate" runat="server"><strong>Download Customer XML Template</strong></asp:LinkButton></div></td>
                                      </tr>
                                      <tr>
                                        <td width="18%" align="right" >Select CSV / XML File:&nbsp; </td>
                                        <td width="82%" align="left"><input name="file" type="file" class="input" id="flProducts" runat="server" />                                        </td>
                                      </tr>
                                      <tr>
                                        <td align="right">&nbsp;</td>
                                        <td align="left"><input name="checkbox" type="checkbox" id="chkUpdateExisting" runat="server" />
                                          &nbsp;Update Existing Data</td>
                                      </tr>
                                      <tr>
                                        <td align="right">&nbsp;</td>
                                        <td align="left" style="padding-top:5px;"><input name="btnImportFile" type="submit" class="AdminFormButton" id="btnImportFile"  value="Import File" runat="server" /></td>
                                      </tr>
                                      <tr>
                                        <td colspan="2" align="left" valign="top"><table width="100%"  border="0" cellspacing="0" cellpadding="0" id="tblProductError" runat="Server" visible="false">
                                            <tr>
                                              <td class="title" style="padding-top:10px;padding-bottom:10px;">Following products could not be added / updated. Please see Reason column.</td>
                                            </tr>
                                            <tr>
                                              <td align="left" style="border:1px solid #BBCCD9"><asp:DataGrid ID="grdError" runat="server" AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Right"
								Font-Size="8pt" Font-Name="Verdana" CellSpacing="0" CellPadding="2"  ShowFooter="false"
								BorderWidth="0"  AllowPaging="false" Width="100%" GridLines="None" BackColor="#FFFFFF" >
                                                  <HeaderStyle Font-Bold="True" HorizontalAlign="Center"  CssClass="GridTop" ForeColor="#FFFFFF" Height="25"></HeaderStyle>
                                                  <AlternatingItemStyle BackColor="#F7F7F9"></AlternatingItemStyle>
                                                  <Columns>
                                                   <asp:TemplateColumn  HeaderText="No" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" ItemStyle-Width="50" HeaderStyle-Width="50">
                                                  <itemtemplate>
                                                  		<%#Eval("__RowNumber") + 1 %>                                                    </itemtemplate>
                                                  </asp:TemplateColumn>
                                                  <asp:BoundColumn DataField="Title" HeaderText="Title" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"  ItemStyle-Width="230" HeaderStyle-Width="230"></asp:BoundColumn>
                                                  <asp:BoundColumn DataField="SKUCode" HeaderText="SKU Code" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" ItemStyle-Width="60" HeaderStyle-Width="60"></asp:BoundColumn>
                                                  <asp:TemplateColumn HeaderText="Reason" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">
                                                    <ItemTemplate> <font style='color:#990000;font-weight:bold'><%#Eval("Reason") %></font> </ItemTemplate>
                                                  </asp:TemplateColumn>
                                                  </Columns>
                                                </asp:DataGrid>                                              </td>
                                            </tr>
                                        </table></td>
                                      </tr>
									  <tr>
                                        <td colspan="2" align="left">
										<table width="100%"  border="0" cellspacing="0" cellpadding="0" id="tblCustomerError" runat="Server" visible="false">
                                            <tr>
                                              <td class="title" style="padding-top:10px;padding-bottom:10px;">Following Customers could not be added / updated. Please see Reason column.</td>
                                            </tr>
                                            <tr>
                                              <td align="left" style="border:1px solid #BBCCD9">
											  <asp:DataGrid ID="grdErrorCustomer" runat="server" AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Right"
                                                    Font-Size="8pt" Font-Name="Verdana" CellSpacing="0" CellPadding="4"  ShowFooter="false"
                                                    BorderWidth="0"  AllowPaging="false" Width="100%" GridLines="None" BackColor="#FFFFFF" >
                                                  <HeaderStyle Font-Bold="True" HorizontalAlign="Center"  CssClass="GridTop" ForeColor="#FFFFFF" Height="25"></HeaderStyle>
                                                  <AlternatingItemStyle BackColor="#F7F7F9"></AlternatingItemStyle>
                                                  <Columns>
                                                  <asp:TemplateColumn  HeaderText="No" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" ItemStyle-Width="50" HeaderStyle-Width="50">
                                                  <itemtemplate>
                                                  		<%#Eval("__RowNumber") + 1 %>                                                    </itemtemplate>
                                                  </asp:TemplateColumn>
                                                  
                                                  <asp:TemplateColumn HeaderText="Name" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">
                                                  <itemtemplate>
                                                  		<%#Eval("FirstName") %>&nbsp;<%#Eval("LastName") %>&nbsp;(<%#Eval("UserName") %>)                                                    </itemtemplate>
                                                  </asp:TemplateColumn>
                                                   <asp:TemplateColumn HeaderText="Email" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">
                                                  <itemtemplate>
                                                  		<%#Eval("EmailAddress") %>                                                    </itemtemplate>
                                                  </asp:TemplateColumn>
                                                  <asp:TemplateColumn HeaderText="Reason" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"  >
                                                    <ItemTemplate> <font style='color:#990000;font-weight:bold'><%#Eval("Reason") %></font> </ItemTemplate>
                                                  </asp:TemplateColumn>
                                                  </Columns>
                                                </asp:DataGrid>                                              </td>
                                            </tr>
                                        </table></td>
                                      </tr>
                                  </table></td>
                              </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td height="25" align="left" valign="top">&nbsp;</td>
                          </tr>
                      </table>
				

		</div>
							
		</div>
				  </td>
                </tr>
                
              </table>
                </ContentTemplate>
                <Triggers>
                
                <asp:PostBackTrigger ControlID="btnExportOrder" />
                <asp:PostBackTrigger ControlID="lnkProductCSVTemplate" />
                <asp:PostBackTrigger ControlID="lnkCustomerCSVTemplate" />
                <asp:PostBackTrigger ControlID="lnkProductXMLTemplate" />
                <asp:PostBackTrigger ControlID="lnkCustomerXMLTemplate" />
				    <asp:PostBackTrigger ControlID="btnImportFile" />
					   <asp:PostBackTrigger ControlID="btnExportProducts" />
					 <asp:PostBackTrigger ControlID="btnExportCustomer" />
				</Triggers>
              </asp:UpdatePanel>
            </td>
          </tr>
        </table></td>
    </tr>
    <tr>
      <td height="10" align="left" valign="top"><uc2:footer ID="footer1" 
                  runat="server" />
      </td>
    </tr>
  </table>
</form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../incs/loading.js"></script>
<script type="text/javascript">
function DoTrim(strComp)
{
	ltrim = /^\s+/
	rtrim = /\s+$/
	strComp = strComp.replace(ltrim,'');
	strComp = strComp.replace(rtrim,'');
	return strComp;
}
function Filter()
{
	$("div.CheckBoxDiv label").each(function() {
		if ($('#txtFilter').val() != '')
		{
			if (this.innerHTML.toLowerCase().indexOf($('#txtFilter').val().toLowerCase()) >= 0) {
				$(this).parent().css('display','block');
			} else {
				$(this).parent().css('display','none');
			}
		}
		else
		{
			$(this).parent().css('display','block');
		}
	});
	document.getElementById('chkSelectAll').checked = false;
	SelectCategories(document.getElementById('chkSelectAll'));
}

function FilterVendors()
{
	$("div.CheckBoxDiv label").each(function() {
		if ($('#txtFilterVendors').val() != '')
		{
			if (this.innerHTML.toLowerCase().indexOf($('#txtFilterVendors').val().toLowerCase()) >= 0) {
				$(this).parent().css('display','block');
			} else {
				$(this).parent().css('display','none');
			}
		}
		else
		{
			$(this).parent().css('display','block');
		}
	});
	document.getElementById('chkSelectAllVendors').checked = false;
	SelectVendors(document.getElementById('chkSelectAllVendors'));
}

function pageLoad()
{
	BindHoverEffect();
}
$(document).ready(
	BindHoverEffect
);
function BindHoverEffect()
{
	$('div.CheckBoxDiv input').each(
		function() {
			$(this).parent().hover( function () {
					$(this).css('background-color','#E9F2FB');
				},
				function () {
					$(this).css('background-color','#FFFFFF');
				}
			);
		}
	);
}

function SelectCategories(obj)
{
	$("div.CheckBoxDiv input:checkbox").each(function() {
		if (obj.checked == true && this.id.indexOf('chkCategory') > 0 && $(this).parent().css('display') != 'none')
		{
			document.getElementById(this.id).checked = true;
		}
		else
		{
			document.getElementById(this.id).checked = false;
		}
	});
}
function SelectVendors(obj)
{
	$("div.CheckBoxDiv input:checkbox").each(function() {
		if (obj.checked == true && this.id.indexOf('chkVendors') > 0 && $(this).parent().css('display') != 'none')
		{
			document.getElementById(this.id).checked = true;
		}
		else
		{
			document.getElementById(this.id).checked = false;
		}
	});
}

function HideShowCategories(obj)
{
	document.getElementById("trCategories").style.display = "none";
	document.getElementById("trVendors").style.display = "none";
	if(obj.value == "1")
	{
		document.getElementById("trCategories").style.display = "";
	}
	else if(obj.value == "2")
	{
		document.getElementById("trVendors").style.display = "";
	}
}
function SetTemplate(Type)
{
	if (Type==1)
	{
		document.getElementById("trProductTemplate").style.display = "";
		document.getElementById("trCutomerTemplate").style.display = "none";
	}
	else
	{
		document.getElementById("trCutomerTemplate").style.display = "";
		document.getElementById("trProductTemplate").style.display = "none";
	}
	
}

</script>
