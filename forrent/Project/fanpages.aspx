<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="fanpages.aspx.vb" Inherits="tsma.fanpages" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Total Social Media Application</title>
    <script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <div id="innerpagepagemain">
     <uc1:inner ID="inner1" runat="server" />
      <div id="centermain">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="172" align="left" valign="top" class="leftbg"> 
                    <uc3:left ID="left1" runat="server" />
                </td>
                <td align="left" valign="top" class="contentbody">
                    <asp:DataList id="dstFanPages" runat="server" RepeatColumns="4" >
                                  <itemtemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                      <tr>
                                        <td width="160"><img src='<%#Eval("picture")%>' height="100" width="100" class='imgborder'/></td>
                                        <td width="10" >&nbsp;</td>
                                       </tr>
                                      <tr>
                                        <td height="30">
                                          &nbsp;<%#Eval("name")%>
                                        </td>
                                        <td >&nbsp;</td>
                                      </tr>
                                    </table>
                                  </itemtemplate>
                                </asp:DataList>
                </td>
                </tr>
              </table></td>
          </tr>
          </table></td>
      </tr>
    </table></td>
  </tr>
 </table> 
    </div></div><uc2:inner ID="inner2" runat="server" />
    </form>
</body>
</html>
