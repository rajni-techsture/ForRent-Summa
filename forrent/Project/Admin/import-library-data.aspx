<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="import-library-data.aspx.vb" Inherits="tsma.import_library_data" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forrent.Com - Import Library Data</title>
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
			<%--<asp:UpdatePanel ID="pnlMain" runat="server"><ContentTemplate> --%>
			  <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr valign="middle" align="center" bgcolor="#ffffff">
                  <td bgcolor="#ffffff"></td>
                </tr>
                
				<tr>
                	<td align="center" colspan="2" style="color:red;font-weight:bold;padding:5px;"><asp:Literal id="ltrMsg" runat="server"></asp:Literal></td>
              	</tr>
				<tr>
					<td height="25" colspan="2" align="right" valign="top"><a href="manage-library-categories.aspx"><b>[ Manage Library Categories ] </b></a></td>
				</tr>
                <tr>
                  <td align="center" colspan="2" class="tdborder">
				  	<table width="100%"  border="0" cellspacing="0" cellpadding="3">
                                      <tr id="trProductTemplate" >
                                        <td align="right" >&nbsp;</td>
                                        <td align="right" ><div style="float:right">
                                        <asp:LinkButton id="lnkLibraryCSVTemplate" runat="server">
                                        <strong>Download Library CSV Template</strong></asp:LinkButton>&nbsp;|&nbsp;
                                        <asp:LinkButton id="lnkCategoryHelpCSVTemplate" runat="server"><strong>Download Category Instruction</strong></asp:LinkButton>
                                        </div></td>
                                      </tr>
                                      <tr>
                                        <td width="18%" align="right" >Select CSV / XML File:&nbsp; </td>
                                        <td width="82%" align="left"><input name="file" type="file" class="input" id="flProducts" runat="server" />                                        </td>
                                      </tr>
                                      <tr style="display:none">
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
                                              <td align="left" style="border:1px solid #BBCCD9">
                                              <asp:DataGrid ID="grdError" runat="server" AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Right"
								Font-Size="8pt" Font-Name="Verdana" CellSpacing="0" CellPadding="2"  ShowFooter="false"
								BorderWidth="0"  AllowPaging="false" Width="100%" GridLines="None" BackColor="#FFFFFF" >
                                                  <HeaderStyle Font-Bold="True" HorizontalAlign="Center"  CssClass="GridTop" ForeColor="#FFFFFF" Height="25"></HeaderStyle>
                                                  <AlternatingItemStyle BackColor="#F7F7F9"></AlternatingItemStyle>
                                                  <Columns>
                                                   <asp:TemplateColumn  HeaderText="No" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" ItemStyle-Width="50" HeaderStyle-Width="50">
                                                  <itemtemplate>
                                                  		<%#Eval("__RowNumber") + 1 %>                                                    </itemtemplate>
                                                  </asp:TemplateColumn>
                                                  <asp:BoundColumn DataField="Category" HeaderText="Title" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"  ItemStyle-Width="230" HeaderStyle-Width="230"></asp:BoundColumn>
                                                  <asp:BoundColumn DataField="LibraryImage" HeaderText="SKU Code" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" ItemStyle-Width="60" HeaderStyle-Width="60"></asp:BoundColumn>
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
                                                  
                                                  <asp:TemplateColumn HeaderText="Library" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">
                                                  <itemtemplate>
                                                  		<%#Eval("Category")%>&nbsp;                                                 </itemtemplate>
                                                  </asp:TemplateColumn>
                                                  <asp:TemplateColumn HeaderText="Reason" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"  >
                                                    <ItemTemplate> <font style='color:#990000;font-weight:bold'><%#Eval("Reason") %></font> </ItemTemplate>
                                                  </asp:TemplateColumn>
                                                  </Columns>
                                                </asp:DataGrid>                                              </td>
                                            </tr>
                                        </table></td>
                                      </tr>
                                  </table>
                  </td>
                </tr>
              </table>
			</ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lnkLibraryCSVTemplate" />
			    <asp:PostBackTrigger ControlID="btnImportFile" />
				</Triggers>
            </asp:UpdatePanel>
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
