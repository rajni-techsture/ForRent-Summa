<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="handshake.aspx.vb" Inherits="tsma.handshake" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script src="Scripts/jquery-1.6.2.min.js"  type="text/javascript"></script>
<head runat="server">
    <title>Total Social Media Application</title>
    <script language="javascript" type="text/javascript" src="Content/js/pagejs/handshake.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="hidden" id="hdnId" runat="server"/>
     <div id="diverr" style="display:none; font:'Courier New', Courier, monospace; font-style:normal; color:#FF0000">Facebook is experiencing problems. Error in connecting to Facebook, Please Try Again...</div>

     <div style="height:125px; width:723px; overflow:auto; overflow-x:hidden; display:none">
                                    <asp:DataList ID="dstAutoPostFanPages" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                        <ItemTemplate>
                                          <table id="NonFanPage" runat="server" width="230" style="overflow-x:scroll" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                              <td colspan="2" height="4"></td>
                                            </tr>
                                            <tr>
                                              <td width="48" align="left" valign="middle" style="background-color:#FFFFFF; border:1px solid #CCCCCC;" >
                                              <table border="0" cellspacing="0" cellpadding="0">
                                                  <tr>
                                                    <td align="center" valign="middle"><img src='<%#Eval("picture")%>' width="40" style=" border: 7px solid #ffffff" height="40" align="absmiddle" group="pageimg1" autopostpageid='<%#Eval("id")%>' /> </td>
                                                    <td align="center" valign="middle"><table border="0" width="170" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                          <td width="25" align="left" valign="middle" ><input class="checkboxpadding" type="checkbox" id="autopostchkPage" name="autopostchkPage" runat="server" autopostpageid='<%#Eval("id")%>' group="autopostpages" onclick='AutoPostPageid(this);SelectedAutoPostPagesName();'  autopostpageaccess_token='<%#Eval("access_token")%>' autopostpagevalue='<%#Eval("name")%>' autopostpageimage='<%#Eval("picture")%>'/></td>
                                                          <td align="left" width="150" valign="middle"><%#Eval("name")%>
                                                            <input type="hidden" id="hdnAutoPostPageId" runat="server" value='<%#Eval("id")%>' />
                                                            <input type="hidden" id="hdnAutoPostPageName" runat="server" value='<%#Eval("name")%>' />
                                                            <input type="hidden" id="hdnAutoPostAccessToken" runat="server" value='<%#Eval("access_token")%>' />
                                                            <input type="hidden" id="hdnAutoPostImage" runat="server" value='<%#Eval("picture")%>' />
                                                           
                                                          </td>
                                                        </tr>
                                                      </table>
                                                      
                                                      </td>
                                                  </tr>
                                                </table></td>
                                              <td width="4" align="left"></td>
                                            </tr>
                                            
                                          </table>
                                        </ItemTemplate>
                                      </asp:DataList>
                                      </div>
    </div>
    </form>
</body>
</html>
