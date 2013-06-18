<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="manage-weekly-tip.aspx.vb" Inherits="tsma.manage_weekly_tip" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"   Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fck" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
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
<script language="javascript">
		<!--
    function ConfirmMsg() {
        var x = confirm('Are you sure you want to delete this Weekly Tip?');
        if (x == true) {
            document.frm.submit();
        }
        else {
            return false;
        }
    }
		//-->
		</script>
</head>
<body>
<form id="frm" name="frm" runat="server">
    <asp:ScriptManager id="objScriptManager" runat="server">
    </asp:ScriptManager>

<table width="1004" height="100%" border="0" cellpadding="0" cellspacing="0" align="center">
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
                  <td height="25" valign="middle" class="title"><span class="arial4heading"> Manage Weekly Tip</span></td>
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
					<td colspan="2"  align="right" valign="top"><a href="add-weekly-Tip.aspx"><b>[ Add New Weekly Tip ] </b></a></td>
				</tr>
				<tr>
                	<td align="center" height="15" colspan="2" style="color:red;font-weight:bold;"><asp:Literal id="ltrMsg" runat="server"></asp:Literal></td>
              	</tr>
                <tr>
                  <td align="center" colspan="2" style="border:1px solid #E0E0E0;padding:1px;">
				  <asp:DataGrid ID="dgrWeeklyTip" runat="server" AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Right"
													PagerStyle-PrevPageText="Prev" PagerStyle-NextPageText="Next" PagerStyle-Mode="NumericPages"
													Font-Size="8pt" Font-Name="Verdana" CellSpacing="0" CellPadding="3" ShowFooter="false" PageSize="20"
													BorderWidth="0" BorderColor="#EAEAEA" AllowPaging="true" Width="100%" GridLines="None" >
                      <HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#7D9BB0" ForeColor="#FFFFFF" Height="25"></HeaderStyle>
					  <AlternatingItemStyle BackColor="#F5F5F5"></AlternatingItemStyle>
                         <Columns>
											
                        <asp:BoundColumn DataField="wt_Id" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="wt_Title" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-HorizontalAlign="left" HeaderStyle-Width="120" HeaderText="Title"></asp:BoundColumn>
                         <asp:TemplateColumn HeaderText="Set In Home Page" ItemStyle-Width="60" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-HorizontalAlign="center"  >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                          <ItemTemplate>
                          <asp:PlaceHolder id="plcSet" runat="server" Visible='<%#eval("wt_SetHome")=0%>'>
                          <asp:ImageButton id="btnSetAsDefault" runat="server" ImageUrl="../Content/adminimages/ico-inactive1.gif" OnClientClick="return confirm('Are you sure to set as Home?');" OnCommand="SetAsHome" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "wt_Id")%>' ToolTip="Click Here To Set In Home"></asp:ImageButton><%--<asp:CheckBox ID="chkHomePage" AutoPostBack="true"  OnCheckedChanged="SetAsHome" Checked='<%#DataBinder.Eval(Container.DataItem, "ff_SetHome")%>' FanFridayID='<%#DataBinder.Eval(Container.DataItem, "ff_Id")%>'  runat="server" />--%>
                          </asp:PlaceHolder>
                                                    <asp:PlaceHolder id="plcDefault" runat="server" Visible='<%#eval("wt_SetHome")=1%>'>
                                                    <span style="color:#990000">SET</span>
                                                    </asp:PlaceHolder>
                          </ItemTemplate>
                       </asp:TemplateColumn> 
                       <asp:TemplateColumn HeaderText="Photo" ItemStyle-Width="60" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-HorizontalAlign="center"  >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                          <ItemTemplate><img alt="Weekly Tip Video" height="150px" width="150px" src="<%#DataBinder.Eval(Container.DataItem, "wt_VideoThumbnail") %>" border="0"> </ItemTemplate>
                       </asp:TemplateColumn> 
                        <asp:BoundColumn DataField="wt_CreatedDate" HeaderText="Created Date" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="center">
                          <ItemStyle HorizontalAlign="center" Width="80"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="wt_UpdatedDate" HeaderText="Updated Date" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="center">
                          <ItemStyle HorizontalAlign="Center" Width="80"></ItemStyle>
                        </asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Edit" ItemStyle-Width="60" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-HorizontalAlign="center"  >
                          <ItemStyle HorizontalAlign="Center"></ItemStyle>
                          <ItemTemplate> <a href='add-weekly-tip.aspx?WTId=<%#DataBinder.Eval(Container.DataItem, "wt_Id") %>'> <img alt="Edit Weekly Tip" src="../Content/adminimages/b-edit.gif" border="0"></a> </ItemTemplate>
                        </asp:TemplateColumn>
                         <asp:TemplateColumn HeaderText="Status" HeaderStyle-ForeColor="#FFFFFF" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50" HeaderStyle-Width="50">
                        <itemtemplate>
                          <asp:ImageButton runat="server" OnClick="ChangeStatus" CommandName='<%#DataBinder.Eval(Container.DataItem, "wt_Id")%>'  CommandArgument='<%#DataBinder.Eval(Container.DataItem, "cStatus")%> ' BorderWidth="0" ImageUrl='<%# Container.DataItem("imgStatus")%>' ID="imgStatus" ></asp:ImageButton>
                        </itemtemplate>
                      </asp:TemplateColumn>
                      <asp:TemplateColumn HeaderText="Delete" HeaderStyle-ForeColor="#FFFFFF" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60" HeaderStyle-Width="60">
                        <itemtemplate>
                          <asp:ImageButton runat="server" OnClick="ChangeStatus" CommandName='<%#DataBinder.Eval(Container.DataItem, "wt_Id")%>'  CommandArgument="2"  BorderWidth="0" AlternateText='Click here to delete' OnClientClick="return confirm('Are you sure you want to delete this Weekly Tip?');" ImageUrl="../Content/adminimages/b-delete.gif" ID="imgDelete" ></asp:ImageButton>
                        </itemtemplate>
                      </asp:TemplateColumn>
                     </Columns>
                    </asp:DataGrid>
                  </td>
                </tr>
                <tr id="trNote" runat="server" valign="middle" align="left" style="padding-top:10px;">
                  <td valign="middle" colspan="2" align="left">Note: <img src="../Content/adminimages/b-active.gif" align="absmiddle">&nbsp;denotes enabled Weekly Tip and&nbsp; <img src="../Content/adminimages/b-inactive.gif" align="absmiddle"> denotes disabled Weekly Tip. </td>
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

