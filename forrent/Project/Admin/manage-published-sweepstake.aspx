<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="manage-published-sweepstake.aspx.vb" Inherits="tsma.manage_published_sweepstake" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"   Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
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

		</script>
</head>
<body>
<iframe width="174"  height="189" name="gToday:normal:agenda.js" id="gToday:normal:agenda.js" src="calender/ipopeng.htm" scrolling="no" frameborder="0" style="visibility:visible; z-index:999; position:absolute; top:-500px;"></iframe> 
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
				  
			 <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
            <tr>
              <td align="left" valign="top" class="tdborder1" style="padding:10px">

			
             <div id="divLoading" style="position:absolute;" >
					<asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0">
					<ProgressTemplate>
						<img src="../Content/adminimages/popuploading.png" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" />					</ProgressTemplate>
					</asp:UpdateProgress>
					</div>		
<asp:UpdatePanel ID="pnlMain1" runat="server"><ContentTemplate> 
			  <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                 <td height="25" valign="middle" class="title"><span class="arial4heading">Manage Sweepstakes Published</span></td>
				</tr>
				
				<tr>
                  <td align="left" colspan="2" class="tdborder">Company: 
                    <select name="selCompany" class="input" id="selCompany" runat="server">
                    </select>&nbsp;&nbsp;
                    Industry:
                    <select name="selIndustry" class="input" id="selIndustry" runat="server">
                    </select>
                     User:
                    <select name="selUser" class="input" id="selUser" runat="server">
                    </select>
                    <br/><br />
                   Date From:
                    <input NAME="txtFromDate" type="text" class="input" id="txtFromDate" style="width:60px;" size="10" maxlength="10" runat="server" />
                    <a href="javascript:void(0)" onClick="if(self.gfPop)gfPop.fPopCalendar(document.getElementById('txtFromDate'));return false;"
						hidefocus title="Calendar (mm/dd/yyyy)"><img src="../content/adminimages/calender.gif" width="32" height="32" border="0" align="absMiddle"></a>&nbsp;To:
                    <input NAME="txtToDate" type="text" class="input" style="width:60px;" id="txtToDate" size="10" maxlength="10" runat="server"/>       			
                    <a href="javascript:void(0)" onClick="if(self.gfPop)gfPop.fPopCalendar(document.getElementById('txtToDate'));return false;"
																	hidefocus title="Calendar (mm/dd/yyyy)"><img src="../content/adminimages/calender.gif" width="32" height="32" border="0" align="absMiddle"></a>&nbsp;&nbsp;SortBy:&nbsp;
						<select name="selSortBy" class="input" id="selSortBy" runat="server" style="width:70px;">
                          <option value="tmp_Date" selected>Date</option>
                          <option value="tmp_CID" >Company</option>
                          <option value="tmp_IID">Industry</option>
                           <option value="tmp_UID">User</option>
                        </select>&nbsp;
				    <select name="selOrder" class="input" id="selOrder" runat="server" style="width:100px;">
                      <option value="desc" selected>Descending</option>
                      <option value="asc" >Ascending</option>
                    </select>&nbsp;&nbsp;
                  <input type="submit" id="btnSearch" runat="Server" class="AdminFormButton" value="Search" />&nbsp;&nbsp;
                  <input type="submit" id="btnDownload" runat="Server" class="AdminFormButton" value="Download" alt="Click here to download" name="btnDownload"/>
                  </td>
                </tr>
				<tr>
                  <td align="center" colspan="2" height="15" valign="middle" style="font-weight:bold;color:#990000;">
				  	 <asp:Literal Id="ltrMsg" runat="server"></asp:Literal>				  </td>
                </tr>
                <tr>
				<td align="center"  colspan="2" valign="top">
					<table cellpadding="0" cellspacing="0" width="100%">
					<tr id="trTopPaging" runat="server">
				  <td height="25"  align="right" valign="top"><%--<div style="float:left" align="left"><input type="submit" runat="server" id="btnDeleteSelectedTop" value="Delete Selected" class="AdminFormButton" onClick="return DeleteSelected()" ></div>--%>
                  <div style="float:right" align="right"><b><asp:PlaceHolder ID="phPaging" runat="server"></asp:PlaceHolder></b></div></td>
				  </tr>
                <tr>
                  <td align="center"  style="border:1px solid #bbccd9;">				   
				  <asp:GridView ID="grdSweepstake" BorderColor="#EAEAEA" runat="server" Font-Size="9pt" Width="100%" AutoGenerateColumns="false" CellSpacing="0" CellPadding="3" GridLines="None">
		  	        <EmptyDataTemplate>
					<center><font style="color:Red;font-weight:bold">No Sweepstake Found.</font></center>
					</EmptyDataTemplate>
					<HeaderStyle  Font-Bold="True"  HorizontalAlign="left" BackColor="#3366ff" ForeColor="#FFFFFF" Height="25"></HeaderStyle>
					<RowStyle Height="25" />
					<AlternatingRowStyle BackColor="#F7F7F9"></AlternatingRowStyle>
					<Columns>
					<%--<asp:TemplateField ItemStyle-width="20"  HeaderText='<input type="checkbox" ID="chkAddAll" onClick="checkall(this);">' ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" >
					<ItemTemplate>
						<asp:CheckBox ID="chkDelete" value='<%#Eval("apm_Id")%>'  runat="server"  ></asp:CheckBox>
                    </ItemTemplate>
					</asp:TemplateField>     --%>               
					<asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" ItemStyle-Width="110" >
					<ItemTemplate>
						<%#Eval("ss_TSMAUserId")%>
                    </ItemTemplate>
					</asp:TemplateField>                    
                    <asp:TemplateField HeaderText="FB User ID" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" ItemStyle-Width="110">
					<ItemTemplate>
						<%#Eval("ss_FBUserId")%>
                    </ItemTemplate>
					</asp:TemplateField>
                    <asp:TemplateField HeaderText="FB Page ID" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" ItemStyle-Width="110">
					<ItemTemplate>
						<%#Eval("ss_FBPageId")%>
                    </ItemTemplate>
					</asp:TemplateField>
                    <asp:TemplateField HeaderText="FB PageName" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" ItemStyle-Width="110">
					<ItemTemplate>
						<%#Eval("ss_FBPageName")%>
                    </ItemTemplate>
					</asp:TemplateField>
                      <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" ItemStyle-Width="110">
					<ItemTemplate>
						<%#Eval("ss_UpdatedDate")%> 
                    </ItemTemplate>
					</asp:TemplateField>
                    
					<%--<asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" ItemStyle-Width="70" HeaderStyle-Width="70">
					<ItemTemplate>
						<asp:LinkButton id="lnkDelete" onCommand="DeleteUrl" runat="server" CommandName='<%#Eval("apm_Id")%>' CommandArgument='2' CssClass="lnkAdminFormButton" Text="Delete" OnClientClick="return confirm('Are you sure that you want to delete this Autopost?');"></asp:LinkButton>
					</ItemTemplate>
					</asp:TemplateField>--%>
					</Columns>
					</asp:GridView>				  </td>
                </tr>
                <tr id="trBottomPaging" runat="server">
                  <td height="25" align="right" valign="bottom">
                  <%--<div style="float:left" align="left">
                  <input type="submit" runat="server" id="btnDeleteSelectedBottom" value="Delete Selected" class="AdminFormButton" onClick="return DeleteSelected()" ></div>--%>
                  <div style="float:right" align="right"><b><asp:PlaceHolder ID="phPaging1" runat="server"></asp:PlaceHolder></b></div></td>
               		  </tr>
					</table>				  </td>
				</tr>
              </table>
			</ContentTemplate>
			<Triggers>
			<asp:PostBackTrigger ControlID="btnDownload" />
			</Triggers>
			</asp:UpdatePanel>
            
						  </td>
            </tr>
          </table>
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