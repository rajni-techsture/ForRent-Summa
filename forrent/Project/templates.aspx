<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="templates.aspx.vb" Inherits="tsma.templates" %>
<%@ Register src="~/footer.ascx" tagname="Footer1" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Total Social Media Application</title>
</head>
<body>
    <form id="form1" runat="server">
     <uc1:inner ID="inner1" runat="server" />
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top" class="mainbg"><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="255" align="left" valign="top" class="tdgreyborder"> 
                
                    <uc3:left ID="left1" runat="server" />
                
                </td>
                <td width="15" align="left" valign="top">
                  </td>
                <td align="left" valign="top" class="contentborder">
                    <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                    <td align="center" colspan="3">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                    </tr>
                  <%--  <asp:Repeater ID="rptTemplates" runat="server">
                    <ItemTemplate>
                    <input type="hidden" id="hdnPageId" value=""/>
                    <tr>
                        <td align="left" valign='middle' style="border-bottom:1px dotted #CCC; padding-bottom:20px">
                            <img class='imgborder' id="imgPage" src='<%# Container.DataItem("PageImage")%>' border="0" width="100" height="100" />
                        </td>
                        <td align='left' width="500" valign='middle' style='border-bottom:1px dotted #CCC; padding-bottom:20px; padding-left:20px'>
                        <strong>MSG:  </strong><%# Container.DataItem("Meassage")%>
                        </td>
                        <td align="right" valign="middle" style='border-bottom:1px dotted #CCC; padding-bottom:20px; padding-left:10px; display:none'>
                        <a href="edit-drafts.aspx?id='""'" style="text-decoration:none" ><img src="content/images/b-edit.gif" border="0" width="39" height="20" style="cursor:pointer"/></a>
                        </td>
                    </tr>
                    <tr><td height='20'>&nbsp;</td><td height='20'>&nbsp;</td><td height='20'>&nbsp;</td></tr>
                    
                    </ItemTemplate>
                    </asp:Repeater>--%>
                      <asp:GridView id="gvlist" runat="server"  AllowSorting="True" 
                                                      AutoGenerateColumns="False" Width="100%" CellPadding="5" AllowPaging="true" 
                                                      PageSize="5" GridLines="Horizontal" BorderColor="#ECE9D8">
                                                  <HeaderStyle CssClass="TableHeader" />
                                                  <AlternatingRowStyle CssClass="LoopListingDark"></AlternatingRowStyle>
						                          <RowStyle CssClass="LoopListingLight"></RowStyle>
                                                <Columns>    
                                                     
                                                    <asp:TemplateField HeaderText="Message">
                                                       
                                                        <HeaderStyle Width="90%" HorizontalAlign="left" CssClass="generaltext" />
                                                        <ItemStyle Width="90%" HorizontalAlign="left" CssClass="generaltext" />
                                                        <ItemTemplate>
                                                        <table><tr><td>
                                                         <img class='imgborder' id="imgPage" src='<%#Container.DataItem("PageImage")%>' border="0" width="100" height="100" />
                                                         </td>
                                                         <td valign="top">
                                                           <%# Container.DataItem("Meassage")%>   
                                                           </td></tr></table>                                                 
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                                                            
                                                                                                                
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="cursor_hand" />
                                                        <ItemTemplate>                                                                                                              
                                                             <%-- <a href='editdrafts/<%# Container.DataItem("pnl_Id")%>/<%# Container.DataItem("PageId")%>' style="text-decoration:none" ><img src="content/images/b-edit.gif" border="0" width="39" height="20" style="cursor:pointer"/></a>--%>
                                                        </ItemTemplate>        
                                                    </asp:TemplateField>
                                                                                                                
                                                  </Columns>
                                                  <PagerStyle HorizontalAlign="Right" BackColor="WhiteSmoke" CssClass="smalltext" /> 
                                              </asp:GridView> 
                    </table>
                </td>
                </tr>
              </table></td>
          </tr>
          </table></td>
      </tr>
    </table></td>
  </tr>
 </table>

    <uc2:Footer1 ID="Footer11" runat="server" />
    </form>
</body>
</html>