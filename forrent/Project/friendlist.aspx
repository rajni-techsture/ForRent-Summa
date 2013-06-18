<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="friendlist.aspx.vb" Inherits="tsma.FriendList" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner1" tagprefix="uc1" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Total Social Media Application</title>
    <script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
      <div id="innerpagepagemain">
     <uc1:inner1 ID="inner1" runat="server" />
      <div id="centermain">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top" ><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
               <td width="172" align="left" valign="top" class="leftbg">
                                    <uc3:left ID="left1" runat="server" />
                
                </td>
               
                <td align="left" valign="top" class="contentbody"><table>
                    <div id="divFriend" runat="server" style="display:none"></div>
                </table></td>
                </tr>
              </table></td>
          </tr>
          </table></td>
      </tr>
    </table></td>
  </tr>
 </table>
    
     </div></div> <uc2:inner ID="inner2" runat="server" />
    </form>
</body>
</html>
