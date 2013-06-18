<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="view-autopost.aspx.vb" Inherits="tsma.view_autopost" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner1" tagprefix="uc1" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Total Social Media Application</title>
<script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
<script type="text/javascript" src="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
<link rel="stylesheet" type="text/css" href="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
<script type="text/javascript" src="Content/js/fancybox/fancybox/video.js"></script>
<script type="text/javascript">
   function CreatePage() {
                    window.open("https://www.facebook.com/pages/create.php?", "Page", "left=20,top=20,menubar=0,resizable=0,width=1000,height=850");
                }
	function OpenWindow()
	{
		window.location.href = 'configure-autopost';
	}
</script>
</head>
<body>
<form id="form1" runat="server">
  <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
  <div id="innerpagepagemain">
    <uc1:inner1 ID="inner1" runat="server" />
    <div id="centermain">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td align="left" valign="top" ><table width="974" border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="172" align="left" valign="top" class="leftbg"><uc3:left ID="left1" runat="server" />
                            </td>
                            <td align="left" valign="top" class="contentbody"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                
                                  <td align="left" valign="top" style="padding-bottom:10px;"><h6>View All Auto Posts</h6></td>
                                </tr>
                                 <tr>
                                  <td align="center" height="20" valign="middle" style="color:#FF0000; font-weight:bold"><asp:Literal id="ltrMsg" runat="server"></asp:Literal>
                                   <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
				                           <strong style="color:#990066">  You have no business pages.</strong><br /><br /> <a href="javascript:CreatePage();">Click here</a> to create business page. 
		                           </asp:PlaceHolder> 
                                  </td>
                                </tr>
                                <asp:PlaceHolder id="plcData" runat="server">
                                <tr>
                                  <td align="center" valign="top" style="border: 1px solid #E9E9E9;">
                                    <div id="div4" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute">
                                      <asp:UpdateProgress ID="UpdateProgressDiv4" runat="Server" DisplayAfter="0">
                                        <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                                      </asp:UpdateProgress>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanelDiv4" runat="server" UpdateMode="Conditional">
                                      <ContentTemplate>
                                  <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                      <asp:Repeater ID="rptPages" runat="server">
                                        <headertemplate>
                                          <tr  style="font-weight:bold;background-color:#DCE6F1;"  align="Center"  Font-Bold="true" >
                                            <td align="left" style="color:#000000;" height="30" >Page Name</td>
                                            <td align="center" width="70" style="color:#000000;" >Start Date</td>
                                            <td align="left" style="color:#000000;" >Time</td>
                                            <td align="center" width="70" style="color:#000000;" >Updated On</td>
                                            <td align="left" width="100" style="color:#000000;" >Updated By</td>
                                            <td align="center" width="60" style="color:#000000;" >Status</td>
                                            <td align="center" width="90" style="color:#000000;" >Notifications</td>
                                            <td align="center" width="70" style="color:#000000;" >View Posts</td>
                                          </tr>
                                        </headertemplate>
                                        <itemtemplate>
                                          <tr align="left" valign="middle" onMouseOver="javascript:this.style.backgroundColor='#ECECEC'"  onMouseOut="javascript:this.style.backgroundColor='#FFFFFF'"  >
                                            <td align="left" height="35" width="120"><%#Eval("PageName")%></td>
                                            <td align="center" ><label id="lblAutoPostDate" runat="server"></label></td>
                                            <td align="left" width="120"><label id="lblAutoPostTime" runat="server"></label><br /><%#Eval("Timezone")%></td>
                                            <td align="center" ><%#Eval("UpdatedDate")%></td>
                                            <td align="left" ><%#Eval("UpdatedBy")%></td>
                                            <td align="center" width="100" >
											<asp:PlaceHolder ID="pnlAutoPostOff" runat="server" Visible='<%#Eval("Status")=0%>'>
                                            <asp:LinkButton id="lnkOff" runat="server" CssClass="bluetablink" OnCommand="TurnOnnOffAutoPost" CommandName='<%#Eval("Pageid")%>' ToolTip="Click here to turn On"><img src='<%=ResolveUrl("Content/images/Off_bullate.png") %>' width="10" height="10" hspace="3" border="0" />Off</asp:LinkButton>
                                            </asp:PlaceHolder> 
                              				<asp:PlaceHolder ID="pnlAutoPostOn" runat="server"  Visible='<%#Eval("Status")=1%>'>
                                            <asp:LinkButton id="lnkOn" runat="server" CssClass="bluetablink" OnCommand="TurnOnnOffAutoPost" CommandName='<%#Eval("Pageid")%>' ToolTip="Click here to turn Off"><img src='<%=ResolveUrl("Content/images/On_bullate.png") %>' width="10" height="10" hspace="3" border="0" />On</asp:LinkButton>
                                            </asp:PlaceHolder> 
                                            <asp:PlaceHolder ID="pnlAutoPostNull" runat="server"  Visible='<%#Eval("Status")=-1%>'>
                                            --
                                            </asp:PlaceHolder>
											</td>
                                            <td align="center" ><asp:PlaceHolder id="plcConfigured" runat="server" Visible='<%#IIF(Eval("Notification")=1,"true","false")%>'>
                                            --
                                            </asp:PlaceHolder>
                                            <asp:PlaceHolder id="plcNotConfigured" runat="server" Visible='<%#IIF(Eval("Notification")=0,"true","false")%>'>
                                            <!--<asp:LinkButton id="lnkConfigure" runat="server" OnCommand="ConfigureAutoPost" CommandName='<%#Eval("Pageid")%>' ToolTip="Click here to configure">Not Configured</asp:LinkButton>
                                            <a href="configure-autopost?confid=<%#Eval("Pageid")%>" ToolTip="Click here to configure">Not Configured</a>-->
                                            --
                                            </asp:PlaceHolder></td>
                                            <td align="center" width="200" >
                                             <asp:PlaceHolder id="plcView" runat="server" Visible='<%#IIF(Eval("Notification")=1,"true","false")%>'>
                                            <a href="configure-autopost?pid=<%#Eval("Pageid")%>" class="bluetablink">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;View Posts&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </a>
                                            </asp:PlaceHolder>
                                            <asp:PlaceHolder id="plcNoView" runat="server" Visible='<%#IIF(Eval("Notification")=0,"true","false")%>'>
                                            <a href="configure-autopost?confid=<%#Eval("Pageid")%>" class="bluetablink" ToolTip="Click here to set daily autopost">Set Daily Autopost</a>
                                            </asp:PlaceHolder>
                                            </td>
                                            
                                          </tr>
                                          
                                        </itemtemplate>
                                         <alternatingitemtemplate>
                                          <tr align="left" valign="middle" style="background-color:#F7F7F9;" onMouseOver="javascript:this.style.backgroundColor='#ECECEC'" onMouseOut="javascript:this.style.backgroundColor='#F7F7F9'">
                                            <td align="left" height="35" width="120"><%#Eval("PageName")%></td>
                                            <td align="center" ><label id="lblAutoPostDate" runat="server"></label></td>
                                            <td align="left" width="120"><label id="lblAutoPostTime" runat="server"></label><br /><%#Eval("Timezone")%></td>
                                            <td align="center" ><%#Eval("UpdatedDate")%></td>
                                            <td align="left" ><%#Eval("UpdatedBy")%></td>
                                            <td align="center" width="100" ><asp:PlaceHolder ID="pnlAutoPostOff" runat="server" Visible='<%#Eval("Status")=0%>'>
                                            <asp:LinkButton id="lnkOff" runat="server" CssClass="bluetablink" OnCommand="TurnOnnOffAutoPost" CommandName='<%#Eval("Pageid")%>' ToolTip="Click here to turn On"><img src='<%=ResolveUrl("Content/images/Off_bullate.png") %>' width="10" height="10" hspace="3" border="0" />Off</asp:LinkButton>
                                            </asp:PlaceHolder> 
                              				<asp:PlaceHolder ID="pnlAutoPostOn" runat="server"  Visible='<%#Eval("Status")=1%>'>
                                            <asp:LinkButton id="lnkOn" runat="server" CssClass="bluetablink" OnCommand="TurnOnnOffAutoPost" CommandName='<%#Eval("Pageid")%>' ToolTip="Click here to turn Off"><img src='<%=ResolveUrl("Content/images/On_bullate.png") %>' width="10" height="10" hspace="3" border="0" />On</asp:LinkButton>
                                            </asp:PlaceHolder>
                                            <asp:PlaceHolder ID="pnlAutoPostNull" runat="server"  Visible='<%#Eval("Status")=-1%>'>
                                            --
                                            </asp:PlaceHolder>

                                            </td>
                                            <td align="center" ><asp:PlaceHolder id="plcConfigured" runat="server" Visible='<%#IIF(Eval("Notification")=1,"true","false")%>'>
                                            --
                                            </asp:PlaceHolder>
                                            <asp:PlaceHolder id="plcNotConfigured" runat="server" Visible='<%#IIF(Eval("Notification")=0,"true","false")%>'>
                                            <!--<asp:LinkButton id="lnkConfigure" runat="server" OnCommand="ConfigureAutoPost" CommandName='<%#Eval("Pageid")%>' ToolTip="Click here to configure">Not Configured</asp:LinkButton>
                                           <a href="configure-autopost?confid=<%#Eval("Pageid")%>" ToolTip="Click here to configure">Not Configured</a>-->
                                            --
                                            </asp:PlaceHolder></td>
                                            
                                            <td align="center" width="200" >
                                            <asp:PlaceHolder id="plcView" runat="server" Visible='<%#IIF(Eval("Notification")=1,"true","false")%>'>
                                            <a href="configure-autopost?pid=<%#Eval("Pageid")%>" class="bluetablink">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;View Posts&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </a>
                                            </asp:PlaceHolder>
                                            <asp:PlaceHolder id="plcNoView" runat="server" Visible='<%#IIF(Eval("Notification")=0,"true","false")%>'>
                                            <a href="configure-autopost?confid=<%#Eval("Pageid")%>" ToolTip="Click here to set daily autopost" class="bluetablink">Set Daily Autopost</a>
                                            </asp:PlaceHolder>
                                            </td>
                                            
                                          </tr>
                                          
                                        </alternatingitemtemplate>
                                      </asp:Repeater>
                                    </table>
                                     </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </td>
                                </tr>
                                </asp:PlaceHolder>
                              </table>
                             
                        </table></td>
                    </tr>
                  </table></td>
              </tr>
            </table></td>
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
<script language="javascript" type="text/javascript">
    function Dotrim(strComp) {
        ltrim = /^\s+/
        rtrim = /\s+$/
        strComp = strComp.replace(ltrim, '');
        strComp = strComp.replace(rtrim, '');
        return strComp;
    }

    function Closewindow() {
        document.getElementById('divPopup').style.display = 'none';

    }

    function ShowHideFeedbackDeatail(popupId) {

        if (document.getElementById(popupId).style.display == "none") {
            document.getElementById(popupId).style.display = "";
        }
        else {
            document.getElementById(popupId).style.display = "none";
        }
    }

    function Prompt() {
        return confirm('Are you sure you want to delete this posting?');
    }	

</script>