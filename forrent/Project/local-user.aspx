<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="local-user.aspx.vb" Inherits="tsma.local_user" %>
<%@ Register Src="~/header.ascx" TagName="Header1" TagPrefix="uc1" %>
<%@ Register src="footer.ascx" tagname="Footer1" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.6.2.min.js"  type="text/javascript"></script>
 <script type="text/javascript" language="javascript" src="Content/js/pagejs/index.js"></script>
  <script type="text/javascript" src="Content/js/jquery1.4.min.js"></script>
	<script type="text/javascript" src="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
	<link rel="stylesheet" type="text/css" href="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <script type="text/javascript" src="Content/js/fancybox/fancybox/video.js"></script><script language="JavaScript" type="text/javascript">
    <!-- Cookie script - Scott Andrew -->
    <!-- Popup script, Copyright 2005, Sandeep Gangadharan --> 
    <!-- For more free scripts go to http://www.sivamdesign.com/scripts/ -->
    <!--
    function newCookie(name,value,days) {
     var days = 1;   // the number at the left reflects the number of days for the cookie to last
                     // modify it according to your needs
     if (days) {
       var date = new Date();
       date.setTime(date.getTime()+(days*24*60*60*1000));
       var expires = "; expires="+date.toGMTString(); 
       }
       else var expires = "";
       document.cookie = name+"="+value+expires+"; path=/"; 
    }
    
    function readCookie(name){
        var strCookie='';
        strCookie=readActualCookie(name);
        if(strCookie=='undefined')
        strCookie='';
        return strCookie;
    }
    function readActualCookie(name) 
    {    
        var nameSG = name + "=";
        var nuller = '';
        if (document.cookie.indexOf(nameSG) == -1)
            return nuller;
    
        var ca = document.cookie.split(';');
        for(var i=0; i<ca.length; i++) 
        {
            var c = ca[i];
            while (c.charAt(0)==' ') c = c.substring(1,c.length);
            if (c.indexOf(nameSG) == 0) 
            return c.substring(nameSG.length,c.length); 
        }
        return null; 
    }
    
    function eraseCookie(name) {
      newCookie(name,"",1); }
    
    function toMem(a) {
        newCookie('UserName', document.form1.txtUid.value);     // add a new cookie as shown at left for every
        newCookie('Password', document.form1.txtPwd.value);   // field you wish to have the script remember
		
    }
    
    function delMem(a) {
      eraseCookie('UserName');   // make sure to add the eraseCookie function for every field
      eraseCookie('Password');
       document.form1.txtUid.value = '';   // add a line for every field
       document.form1.txtPwd.value = ''; }
    //-->
    </script>

   <script type="text/javascript" language="javascript">
       function ForgotPwdValidation() {
           var fields = "";

           var re = new RegExp();
           re = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
           var sinput;
           sinput = "";

           if (DoTrim(document.getElementById('txtForget').value).length == 0) {
               fields = fields + "\n-- Email Address --";
           }
           else {
               sinput = DoTrim(document.getElementById('txtForget').value);
               if (!re.test(sinput)) {
                   fields = fields + "\n-- Invalid Email Address --";
                   document.getElementById('txtForget').value == "";
               }
           }
           if (fields != "") {
               fields = "Please fill in the following details:\n--------------------------------\n" + fields;
               alert(fields);
               return false;
           }
           else {
               return true;
           }
       }
       function OpenDiv() {
           // alert("test");
           $('#divForgotPwd').dialog({ autoOpen: false, bgiframe: true, modal: true });
           $('#divForgotPwd').dialog('open');
           $('#divForgotPwd').parent().appendTo($("form:first"));
           // $('#divForgotPwd').attr("style","display:block;");

       }
       function readCookie1(name) {
           var nameEQ = name + "=";
           var ca = document.cookie.split(';');
           for (var i = 0; i < ca.length; i++) {
               var c = ca[i];
               while (c.charAt(0) == ' ') c = c.substring(1, c.length);
               if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
           }
           return null;
       }
       function ValidatePass() {
           if ($('#txtForget').val() == '') {
               $('#txtForget').removeClass('input');
               $('#txtForget').addClass('input-validation-error');
               $('#spnForget').html('*');
           }
           else {
               $('#txtUid').removeClass('input-validation-error');
               $('#txtUid').addClass('input');
               $('#spnUid').html('');
           }
       }
       function DoTrim(strComp) {
           ltrim = /^\s+/
           rtrim = /\s+$/
           strComp = strComp.replace(ltrim, '');
           strComp = strComp.replace(rtrim, '');
           return strComp;
       }

       function validatelogin1() {
           var fields = "";
           if (DoTrim(document.getElementById('txtUid').value).length == 0) {
               fields = fields + "\n-- UserName --";
           }
           if (DoTrim(document.getElementById('txtPwd').value).length == 0) {
               fields = fields + "\n-- Password --";
           }

           if (fields != "") {
               fields = "Please fill in the following details\n--------------------------------------\n" + fields;
               alert(fields);
               return false;
           }
           else {
               return true;
               //__doPostBack("imgLogin", "");
           }
       }
       function SiteUserLogin12() {
           var count = 0;
           $('#spnEror').html('');
           if ($('#txtUid').val() == '') {
               $('#txtUid').removeClass('input');
               $('#txtUid').addClass('input-validation-error');
               $('#spnUid').html('*');
               count = count + 1;
           }
           else {
               $('#txtUid').removeClass('input-validation-error');
               $('#txtUid').addClass('input');
               $('#spnUid').html('');
           }
           if ($('#txtPwd').val() == '') {
               $('#txtPwd').removeClass('input');
               $('#txtPwd').addClass('input-validation-error');
               $('#spnPwd').html('*');
               count = count + 1;
           }
           else {
               $('#txtPwd').removeClass('input-validation-error');
               $('#txtPwd').addClass('input');
               $('#spnPwd').html('');
           }
           if (count == 0) {
               return true;
           }
           else {
               return false;
           }
       }
       function ChangeLoginFocus(eve) {
           var code = eve.keyCode || eve.which;
           if (code == 13) {
               $('#imgLogin').click();
           }
       }
       
</script>       
</head>
<body onload="MM_preloadImages('../../Content/images/facebook_icon_hover.png','Content/images/icon_facebook_hover.png')">
    <form id="form1" runat="server">
    <input type="hidden" id="hdnAccessToken" runat="server" value=""/>
   <uc1:Header1 ID="header1" runat="server" />
    <div id="DivBrowser" runat="server" style="width:100%; height:100%; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:10000000; text-align:center; display:none;">
 <div id="popup_container1" >
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">			  

	</div>
    </div>		 
</div>
   <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td align="left" valign="top" class="mainbg" style="height:450px;">
      <table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td class="bannerborder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td align="left" valign="top" class="stepbg">
                <asp:Panel ID="pnlLocal" runat="server" >
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="48" align="left" valign="middle" class="arial22white">User Login</td>
                  </tr>
                  <tr>
                    <td align="center" valign="top" style="padding-top:10px;" >&nbsp;<span style="color:#ffeb66; font-weight:bold; font-size:12px;" id="spnEror" runat="server"></span></td>
                  </tr>
                  <tr>
                    <td align="left" valign="top"  style="padding-top:10px;" ><table width="100%" border="0" cellspacing="0" cellpadding="2" >
                      <tr>
                        <td width="43%" height="38" align="left" valign="middle" class="arial13white">Sign in to Facebook:</td>
                        <td width="57%" align="left" valign="middle"><a href="javascript:;" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image19','','Content/images/icon_facebook_hover.png',1)"><img src="Content/images/icon_facebook.png" name="Image19" width="34" height="34" border="0" onclick="javascript:MM_openBrWindow(0); " id="Image19" /></a></td>
                      </tr>
                      <tr>
                        <td height="38" align="left" valign="middle" class="arial13white">Company User Name:</td>
                        <td align="left" valign="middle">
                          <label>
                            <input name="txtUid" type="text" id="txtUid" runat="server"  onKeyDown="ChangeLoginFocus(event)" class="inputhome"  size="26"/>&nbsp;<span style="color:#e80c4d; font-weight:bold;" id="spnUid"></span>
                            </label>
                          </td>
                      </tr>
                      <tr>
                        <td align="left" valign="middle" class="arial13white">Password:</td>
                        <td align="left" valign="middle"><input  name="txtPwd" type="password" id="txtPwd" runat="server" onKeyDown="ChangeLoginFocus(event)" class="inputhome" size="26"/>&nbsp;<span style="color:#e80c4d; font-weight:bold;" id="spnPwd"></span></td>
                      </tr>
                      <tr>
                        <td height="38" align="left" valign="middle" class="arial13white">Security Code:</td>
                        <td align="left" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="75" align="left" valign="middle"><input name="txtcode1"  type="text"  id="txtcode1"  maxlength="6" runat="server" class="inputhome" size="7"/></td>
                            <td width="60" align="left" valign="middle"><IMG name="imgcode1" width="93" Border="1" height="31"  align="absmiddle" id="imgcode1" runat="server" >
                              <input class="input" id="hdncode1" type="hidden" runat="server" width="" NAME="hdncode1" /></td>
                            <td align="left" valign="middle">&nbsp;</td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td height="45" align="left" valign="middle">&nbsp;</td>
                        <td align="left" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="24" align="left" valign="middle">
                              <label>
                               <input type="checkbox" id="checker" name="checker"  runat="server" onChange="if(this.checked) toMem(this)" />
                                </label>
                             </td>
                            <td width="90" align="left" valign="middle" class="arial13white">Remember Me</td>
                            <td align="left" valign="middle">
                            <asp:ImageButton ID="imgLogin" runat="server" OnClientClick="return validatelogin1();" ImageUrl="Content/images/home_login_button.png" />
                          </td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td height="30" align="left" valign="middle">&nbsp;</td>
                        <td align="left" valign="middle" class="arial13white"><a href="javascript:;" style="color:White" onClick="OpenDiv();"><font color="#ffffff">Forgot your password?</font></a></td>
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
                </td>
                <td width="625" align="left" valign="top" class="bannerimg">
                <img src="Content/images/Summa Social Photo for Outside Dashboard.jpg" width="625" height="340" border="0">
                <div id="divFirstStep" class="youselectpopup" style="display:none; position:absolute;"> You Selected <span id="SelectedItem" style="color:#241b00; font-weight:bold">&nbsp;</span> </div></td>
              </tr>
            </table></td>
          </tr>
          <tr style="display:none;">
            <td class="bannerborder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left" valign="top" class="stepbg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td height="185" align="center" valign="bottom"><table width="100%" cellpadding="0" cellspacing="0" valign="bottom" align="center">
                            <tr>
                              <td style="font-size:20px; color:#FFF; padding-right:5px;" align="right">Industry:</td>
                              <td align="left" height="50"><span id="spnChooseInd" style="cursor:pointer;">
                                <div class="selectbginactive" id="divSelectedIndustry"> &nbsp; </div>
                                </span>
                                <div align="right" style="width:210px; position:absolute; display:none; z-index:11; " id="dvIndustry" >
                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                      <td align="left" valign="top"><img src="../../Content/images/menu_top.png" align="absbottom" width="210"/></td>
                                    </tr>
                                    <tr>
                                      <td align="left" valign="top" class="menubg"><table cellpadding="0" cellspacing="0" border="0" width="100%">
                                          <asp:Repeater ID="rptIndustry" runat="server">
                                          <ItemTemplate>
                                          <tr>
                                            <td height="38" group="industry"  show="0"  onMouseOver="AddClass(this);" onMouseOut="RemoveClass(this)" align="left" valign="middle" class="td456" style="font-family:arial; font-size:14px; color:#FFF; padding-left:15px; padding-right:15px; cursor:pointer;" onClick="GetPositionInd(this);" image='<%# Container.DataItem("i_Icon")%>' cssstyle='<%# Container.DataItem("i_Style")%>' industryid='<%# Container.DataItem("i_id")%>' industryname='<%# Container.DataItem("i_Name")%>'  ><span id="spnIndustry"> <img src="../../Content/images/<%# Container.DataItem("i_Icon")%>" align="absmiddle"/>&nbsp;&nbsp; <%# Container.DataItem("i_Name")%> </span><br />
                                            </td>
                                          </tr>
                                          </ItemTemplate>
                                         </asp:Repeater>
                                          <input type="hidden" id="hdnindid" value="-1" />
                                          <input type="hidden" id="hdnindname" value="" />
                                          <input type="hidden" id="hdnMapI" value="0" />
                                        </table></td>
                                    </tr>
                                    <tr>
                                      <td height="11" align="left" valign="top"><img src="../../Content/images/menu_down.png" width="210" height="11" align="top" /></td>
                                    </tr>
                                  </table>
                                </div></td>
                            </tr>
                            <tr>
                              <td style="font-size:20px; color:#FFF; padding-right:5px;" align="right">Company:</td>
                              <td align="left" height="55" valign="bottom"><span id="spnChoose" style="cursor:pointer;">
                                <div class="selectbginactive" id="divSelectedCompany">&nbsp;</div>
                                </span>
                                <div style="width:210px; position:absolute; display:none; z-index:10;" id="dvCompany">
                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                      <td align="left" valign="top"><img src="../../Content/images/menu_top.png" align="absbottom" width="210"/></td>
                                    </tr>
                                    <tr>
                                      <td class="menubg" valign="top"><table cellpadding="0" cellspacing="0" border="0" width="100%">
                                          <input type="hidden" id="hdncid" value="-1" />
                                          <input type="hidden" id="hdncname" value="" />
                                          <input type="hidden" id="hdnimage" value="" />
                                          <input type="hidden" id="hdnStyle" value="" />
                                          <input type="hidden" id="hdnMap" value="0" />
                                          <input type="hidden" id="hdnid" value="0" />
                                           <asp:Repeater ID="rptCompany" runat="server">
                                           <ItemTemplate>
                                          <tr>
                                            <td  height="38" group="company" align="left" valign="middle" show="0" onMouseOver="AddClass(this);" onMouseOut="RemoveClass(this)" style="font-family:arial; font-size:14px; padding-left:15px; padding-right:15px; color:#FFF; cursor:pointer;" bit='<%# Container.DataItem("c_ispasswordRequired")%>' image='<%# Container.DataItem("c_Icon")%>' companyid='<%# Container.DataItem("c_id")%>' onClick="GetPosition(this);" companyname='<%# Container.DataItem("c_Name")%>' cssstyle='<%# Container.DataItem("c_Style")%>'><span id="spnCompany"><img src="../../Content/images/<%# Container.DataItem("c_Icon")%>" align="absmiddle"/>&nbsp;&nbsp; <%# Container.DataItem("c_Name")%> </span><br />
                                            </td>
                                          </tr>
                                          </ItemTemplate>
                                         </asp:Repeater>
                                          <tr>
                                            <td><div class="passwordpopup" id="divPassword"  style="position:absolute; padding-top:15px;font-size:12px; display:none;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                  <tr>
                                                    <td height="25" align="left" valign="top"><span class="arial16white" style="font-size:14px">Please enter password for <br /><span id="spnName"></span></span></td>
                                                  </tr>
                                                  <tr>
                                                    <td height="35" align="left" valign="top" style="padding-top:5px;"><label>
                                                      <input name="txtPwd1" type="password" id="txtPwd1" class="passwordinput" onKeyDown="ChangeLoginFocus(event)"  />
                                                      <input type="hidden" id="CompanyId" value="0" />
                                                      </label>
                                                    </td>
                                                  </tr>
                                                  <tr >
                                                    <td align="left" valign="top"><span id="spnPwdError" style="color:#FFFFFF; font-weight:bold;" ></span></td>
                                                  </tr>
                                                  <tr>
                                                    <td height="30" align="left" valign="bottom">
                                                    <img src="Content/images/submit.png" id='btnSubmit' width="67" height="27" border="0" style="cursor:pointer" />
                                                    <%--<input type="image" src="Content/images/submit.png" id='btnPassword' runat="server" width="67" height="27" border="0" />--%>
                                                    </td>
                                                  </tr>
                                                </table>
                                              </div></td>
                                          </tr>
                                        </table></td>
                                    </tr>
                                    <tr>
                                      <td height="11" align="left" valign="top"><img src="../../Content/images/menu_down.png" width="210" height="11" align="top" /></td>
                                    </tr>
                                  </table>
                                </div></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td height="80" align="left" valign="top">&nbsp;</td>
                      </tr>
                      <tr>
                        <td height="61" align="center" valign="middle"><a href="#">
                        </a><a href="javascript:;" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image15','','../../Content/images/facebook_icon_hover.png',1)"><img src="../../Content/images/facebook_icon.png" name="Image15" onClick="javascript:MM_openBrWindow(0); " width="40" height="40" hspace="10" border="0" id="Image15" /></a><a href="javascript:;" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image16','','../../Content/images/twitter_icon_hover.png',1)"><img src="../../Content/images/twitter_icon.png" name="Image16" width="40" height="40" hspace="10" border="0" id="Image16" /></a><a href="javascript:;" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image17','','../../Content/images/linkedin_icon_hover.png',1)"><img src="../../Content/images/linkedin_icon.png" name="Image17" width="40" height="40" hspace="10" border="0" id="Image17" /></a><a href="javascript:;" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image18','','../../Content/images/rssfeed_icon_hover.png',1)"><img src="../../Content/images/rssfeed_icon.png" name="Image18" width="40" height="40" hspace="10" border="0" id="Image18" /></a></td>
                      </tr>
                    </table></td>
                  <td width="551" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top" >&nbsp;
                        
                         </td>
                      </tr>
                    </table></td>
                </tr>
              </table></td>
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
    <td align="center" valign="top" style="text-align:center">
     <uc2:Footer1 ID="footer11" runat="server" />
    </td>
    </tr>
  </table>
   
    <script type="text/javascript" language="javascript">
		<!--
        document.form1.txtUid.value = readCookie("UserName");  // Change the names of the fields at right to match the ones in your form.
        document.form1.txtPwd.value = readCookie("Password");
		//-->
		</script>
        </form>
</body>
</html>
