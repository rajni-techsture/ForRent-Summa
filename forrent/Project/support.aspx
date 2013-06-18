<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="support.aspx.vb" Inherits="tsma.support" %>

<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Total Social Media Application</title>
<link href="Content/css/inner.css" rel="stylesheet" type="text/css" />
    <script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
</head>
<body>
<form id="frm" runat="server">
 <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
  <div id="innerpagepagemain"  >
    <uc1:inner ID="inner1" runat="server" />
    <div id="centermain">
                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="170" align="left" valign="top" class="leftbg">
                            <uc3:left ID="left1" runat="server" />
                            </td>
                            <td align="left" valign="top" class="contentbody">
                            		
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td align="left" valign="middle" class="blueboxtitle" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="32"><img src="Content/images/icon_faq.png" width="32" height="30" /></td>
                    <td class="blueboxtitle" style="padding-top:5px; padding-bottom:5px;">FAQs</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td align="left" valign="top" class="blueboxbg" style="padding:20px; padding-left:30px;"><br/>FAQ's Contents Coming soon... <br /><br />
                 </td>
              </tr>
            </table></td>
            <td width="20" align="left" valign="top">&nbsp;</td>
            <td  align="left" valign="top">
            <a href="https://www.facebook.com/wbysm" target="_blank"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td align="left" valign="middle" class="blueboxtitle" >
                
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="32"><img src="Content/images/icon_communities.png" width="33" height="29" /></td>
                    <td class="blueboxtitle" style="padding-top:5px; padding-bottom:5px;">Communities</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td align="left" valign="top" class="blueboxbg" style="padding:20px; padding-left:30px;">Share tips and solutions <br />
                  with other Virtual Social <br />
                  Media Agency users</td>
              </tr>
            </table>
            </a></td>
            <td width="20" align="left" valign="top">&nbsp;</td>
            <td align="left" valign="top"><a href="https://www.facebook.com/wbysm" target="_blank">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td align="left" valign="middle" class="blueboxtitle" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="26"><img src="Content/images/icon_contact.png" width="26" height="31" /></td>
                    <td class="blueboxtitle" style="padding-top:5px; padding-bottom:5px;">Contact</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td align="left" valign="top" class="blueboxbg" style="padding:20px; padding-left:30px;">Connect with us when you <br />
                  can't find what you're looking <br />
                  for or give us some feedback</td>
              </tr>
            </table>
            </a>
            </td>
            </tr>
          </table>
                              </td>
                          </tr>
                        </table>
                     </div>
  </div>
  <uc2:inner ID="inner2" runat="server" />
 </form>
</body>
</html>

