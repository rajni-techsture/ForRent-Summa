<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="tsma._Default" %>
<%@ Register Src="~/header.ascx" TagName="Header1" TagPrefix="uc1" %>
<%@ Register src="footer.ascx" tagname="Footer1" tagprefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<title>Total Social Media Application</title>
 <script src="Scripts/jquery-1.6.2.min.js"  type="text/javascript"></script>
 <script type="text/javascript" language="javascript" src="Content/js/pagejs/index.js"></script>
</head>
<body onLoad="MM_preloadImages('Content/images/home_facebook_hover.png')">

 
<!--  <div id="DivBrowser" runat="server" style="width:100%; height:100%; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:10000000; text-align:center; display:none;">
 <div id="popup_container1" >
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">			  
	</div>
    </div>		 
</div> -->
   <table width="100%" height="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr><form id="form2" runat="server" name="form2" >
      <td align="left" valign="top" height="50px;"> <uc1:Header1 ID="header1" runat="server" /></td>
    </tr>
    <tr>
      <td align="left" valign="top" class="mainbg" style="background-position:bottom; background-color:#f4f4f4"><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td class="bannerborder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td align="center" valign="top" class="stepbg">
                <asp:Panel ID="pnlLocal" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="48" align="left" valign="middle" class="arial22white">User Login</td>
                  </tr>
                  <tr>
                    <td align="center" valign="top" style="padding-top:10px;" >&nbsp;</td>
                  </tr>
                  <tr>
                    <td align="left" valign="top"  style="padding-top:10px;" ><table width="100%" border="0" cellspacing="0" cellpadding="2" >
                      <tr>
                        <td width="46%" height="38" align="left" valign="middle" class="arial13white">Sign in to Facebook:</td>
                        <td width="54%" align="left" valign="middle">
                        <a href="javascript:;" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image19','','Content/images/icon_facebook_hover.png',1)"><img src="Content/images/icon_facebook.png" name="Image19" width="34" height="34" border="0" onClick="javascript:MM_openBrWindow(0); " id="Image19" /></a>
                        </td>
                      </tr>
                      </table>
                      <div id="divForgotPwd" title="Recover Your Password" style="display:none;">
<asp:Panel ID="pnlForgotPwd" runat="server">
<table border="0">
       <tr>
        <td align="left" height="40" colspan="2" style="text-align:left; font-size:12px; color:Gray">
        Please insert your Email Address here. your password will send to your email address.
        </td>
       </tr>
       <tr>
        <td align="right" height="30" width="100" valign="middle" style="width:50px;"><strong>Email:</strong> 
        </td>
        <td align="left" height="30" valign="middle">
        <input type="text" runat="server" valign="top" name="txtForget" id="txtForget" Class="input" style=" height:20px;"/>&nbsp;<span style="color:#e80c4d; font-weight:bold;" id="spnForget"></span>
        </td>
       </tr>
       <tr>
        <td colspan="2" align="center">
           <asp:ImageButton ID="imgPassword"  runat="server" ImageUrl="../../content/images/submit.png" OnClientClick="return ForgotPwdValidation();" />
        </td>
       </tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlmsg" runat="server">
<table>
    <tr>
        <td align="left" height="40" colspan="2" style="text-align:left; font-size:12px; color:Gray">
        We Will Send Your Password Soon.
        </td>
    </tr>
</table>
</asp:Panel>
</div>
                      </td>
                  </tr>
                </table>
                </asp:Panel>


                <asp:Panel ID="pnlOnline" runat="server" Visible="false">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="48" valign="middle" class="arial22white">User Login</td>
  </tr>
  <tr>
    <td height="290" align="center" valign="middle"><a href="javascript:;" onClick="javascript:MM_openBrWindow(1);" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image6','','Content/images/home_facebook_hover.png',1)">
    <img src="Content/images/home_facebook.png" name="Image6" width="269" height="109" border="0"></a>
    </td>
  </tr>
</table>

                
                </asp:Panel>




                </td>
                <td width="625" align="left" valign="top" class="bannerimg">
                
                <img src="Content/images/Summa Social Photo for Outside Dashboard.jpg" width="625" height="340" border="0">
                <div id="divFirstStep" class="youselectpopup" style="display:none; position:absolute;"> You Selected <span id="SelectedItem" style="color:#241b00; font-weight:bold">&nbsp;</span> </div>
                </td>
              </tr>
            </table></td>
          </tr>
          <tr style="display:none;">
            <td class="bannerborder">&nbsp;</td>
          </tr>
          <tr>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0" style="display:none">
                <tr>
                  <td height="50" align="left" valign="top">&nbsp;</td>
                </tr>
                <tr>
                  <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="338" align="left" valign="top" ><div class="weeklytipsbg">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td height="45" align="center" valign="top"><h1>Weekly Tips</h1></td>
                              </tr>
                              <tr> 
                                <td height="180" align="left" valign="top" style="padding-left:10px;">
                               <div><a id="strVideo1" runat="server" class="video"><img id="imgWeeklyTips" runat="server" align="left" width="276" height="155" style="border:3px solid #FFF"/><div style="z-index: 10; padding-left: 123px; position: absolute; padding-top: 65px;"><img src="content/images/play_icon.png" style="z-index:10; "></div></a></div></td>
                              </tr>
                              <tr>
                                <td align="left" valign="top">
                                <h1><asp:Literal ID="ltrWeeklyTipsTitle" runat="server" Visible="false"></asp:Literal></h1>
                                  <br />
                                 <asp:Literal ID="ltrWeeklyTipsDescription" runat="server"></asp:Literal></td>
                              </tr>
                            </table>
                          </div></td>
                        <td width="15" align="left" valign="top">&nbsp;</td>
                        <td align="left" valign="top" ><div class="yellowbg">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td width="160" align="left" valign="top"><img runat="server" id="imgFanFriday" width="140" height="422" /></td>
                                <td align="left" valign="top"><div style="padding-bottom:20px;">
                                    <h1><font color="#000000"><asp:Literal ID="ltrFanFridayTitle" runat="server"></asp:Literal></font></h1>
                                  </div>
                                  <p><asp:Literal ID="ltrFanFridayDescription" runat="server"></asp:Literal></p></td>
                              </tr>
                            </table>
                          </div></td>
                      </tr>
                    </table></td>
                </tr>
                <tr>
                  <td align="left" valign="top">&nbsp;</td>
                </tr>
                <tr>
                  <td align="left" valign="top"><div class="divgreyborder">
                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td height="36" align="left" valign="middle" class="tdbackground">Facebook</td>
                        </tr>
                        <tr>
                          <td align="left" valign="top" class="padding20px" style="padding:10px;">
							  <asp:DataList id="dlsFacebookPlugin" runat="server" RepeatColumns="1" CellPadding="10" CellSpacing="0" Width="100%">
							  <alternatingitemstyle BackColor="#f7f7f7" BorderColor="#cccccc" VerticalAlign="middle" />
							   <itemtemplate>							 
									 <span class="tdverdana12"><%#Eval("message")%></span>
								</itemtemplate>
								<alternatingitemtemplate>						 
									 <span class="tdverdana12"><%#Eval("message")%></span>
								</alternatingitemtemplate>
							  </asp:DataList>
                          </td>
                        </tr>
                      </table>
                    </div></td>
                </tr>
                <tr>
                  <td align="left" valign="top">&nbsp;</td>
                </tr>
                <tr style="display:none">
                  <td align="left" valign="top" ><div class="divgreyborder">
                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td height="36" align="left" valign="middle" class="tdbackground">Twitter</td>
                        </tr>
                        <tr>
                          <td align="left" valign="top" class="padding20px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top" ><span class="tdverdana12"> <strong class="arial14darkblue">WBYSM</strong><br />
                                  October 27, 2011 at 9:36am </span> Watch -&gt; *Getting the Dish with Donna* 4 easy ways to measure #socialmedia @FidelityPhoenix RT plz http://t.co/DAJPVPWq <br />
                                  <strong class="arial14darkblue"><br />
                                  WBYSM</strong><br />
                                  October 27, 2011 at 9:36am
                                  Watch -&gt; *Getting the Dish with Donna* 4 easy ways to measure #socialmedia @FidelityPhoenix RT plz http://t.co/DAJPVPWq</td>
                                <td align="left" valign="top" style="padding-left:35px;"><strong class="arial14darkblue">WBYSM</strong><br />
                                  October 27, 2011 at 9:36am
                                  Watch -&gt; *Getting the Dish with Donna* 4 easy ways to measure #socialmedia @FidelityPhoenix RT plz http://t.co/DAJPVPWq<br />
                                  <strong class="arial14darkblue"><br />
                                  WBYSM</strong><br />
                                  October 27, 2011 at 9:36am
                                  Watch -&gt; *Getting the Dish with Donna* 4 easy ways to measure #socialmedia @FidelityPhoenix RT plz http://t.co/DAJPVPWq</td>
                                <td align="left" valign="top" style="padding-left:25px; padding-right:50px;"><strong class="arial14darkblue">WBYSM</strong><br />
                                  October 27, 2011 at 9:36am
                                  Watch -&gt; *Getting the Dish with Donna* 4 easy ways to measure #socialmedia @FidelityPhoenix RT plz http://t.co/DAJPVPWq <br />
                                  <strong class="arial14darkblue"><br />
                                  WBYSM</strong><br />
                                  October 27, 2011 at 9:36am
                                  Watch -&gt; *Getting the Dish with Donna* 4 easy ways to measure #socialmedia @FidelityPhoenix RT plz http://t.co/DAJPVPWq</td>
                              </tr>
                            </table></td>
                        </tr>
                      </table>
                    </div></td>
                </tr>
              </table></td>
          </tr>
        </table></td>
    </tr>
    <tr>
    <td height="20" align="center" valign="middle" style="text-align:center">
     <uc2:Footer1 ID="footer11" runat="server" />
    </td><input type="hidden" id="hdnAccessToken" runat="server" />  </form>
  
      
    </tr>
  </table>
</body>
</html>
