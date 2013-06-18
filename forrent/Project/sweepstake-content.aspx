<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sweepstake-content.aspx.vb" Inherits="tsma.sweepstake_content" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css"> img#share_button {cursor: pointer;} </style>

	<script src="../Content/js/jquery-1.7.1.min.js" type="text/javascript"></script>
	<script src="../content/js/popupmodel.js" type="text/javascript"></script>
	<style type="text/css" media="screen">
	body {
	width:520px;
	overflow:hidden;
	margin:0; padding:0; border:0;
	}
    #divBackGround 
    {
        position:absolute;
        background-color:#ffffff;
		 filter:alpha(opacity=70);
        opacity: 0.70;
        -moz-opacity:0.70;
      
    }
	
</style>
</head>
<body>
<script>
        //techsturedevelopment.com
    window.fbAsyncInit = function () {
        FB.init({
            //appId: '270023716379041', //'174376286006666',//'292789867419830',
			appId: '174376286006666', //tsmaapplicatin,
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true // parse XFBML
        });
    };

    //training.tsmaapplication.com
   // window.fbAsyncInit = function () {
//        FB.init({
//                appId: '265821080167427', //'174376286006666',//'292789867419830',
//            status: true, // check login status
//            cookie: true, // enable cookies to allow the server to access the session
//            xfbml: true // parse XFBML
//        });
//    };

    //tsmaapplication.com
       /* window.fbAsyncInit = function () {
            FB.init({
                appId: '174376286006666', //'174376286006666',//'292789867419830',
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true // parse XFBML
            });
        };
*/

   

    (function () {
        var e = document.createElement('script');
        e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
        e.async = true;
        //document.getElementById('fb-root').appendChild(e);
    }());
</script>
<script type="text/javascript">
    $(document).ready(function () {
	var fbpagename=$('#hdnFBPageName').val();
	var fburl=$('#hdnURL').val();
	FB.Canvas.setAutoResize();
	//FB.Canvas.setAutoGrow();
	//General
	/* $('#share_button').live('click', function (e) {
            e.preventDefault();
            FB.ui(
            {
                method: 'feed',
                name: 'Sweepstakes',
                link: '',
                picture: 'http://www.tsmaapplication.com/content/images/Sweepstakes_Icon.gif',
                caption: '',
                description: 'I just entered a sweepstakes at my apartment community',
                message: ''
            });
        });*/
		
        //techsturedevelopment.com
       /* $('#share_button').live('click', function (e) {
            e.preventDefault();
            FB.ui(
            {
                method: 'feed',
                name: 'Total Social Media System',
                link: 'http://www.techsturedevelopment.com',
                picture: 'http://www.techsturedevelopment.com/Content/images/we_build_img.jpg',
                caption: 'TSMA-BETA',
                description: 'You can share your reviews on Facebook',
                message: ''
            });
        });*/
        //tsmaapplication.com
                $('#share_button').live('click', function (e) {
                    e.preventDefault();
                    FB.ui(
                    {
                       method: 'feed',
                        name: 'ForRent.com',      
                        link: 'https://www.tsmaapplication.com/',
                        picture: 'http://www.tsmaapplication.com/Content/images/for_rent_logo.jpg',
                        caption: 'ForRent.com',
                        description: 'You can share your reviews on Facebook',
                        message: ''
                    });
                        });

        //training.tsmaapplication.com
        //                $('#share_button').live('click', function (e) {
//                            e.preventDefault();
//                            FB.ui(
//                            {
//                               method: 'feed',
//                                name: 'ForRent.com',      
//                                link: 'https://www.training.tsmaapplication.com/',
//                                picture: 'https://www.training.tsmaapplication.com/Content/images/for_rent_logo.jpg',
//                                caption: 'ForRent.com',
//                                description: 'You can share your reviews on Facebook',
//                                message: ''
//                            });
//                        });

                //so.techsturedevelopment.com
//	        $('#share_button').live('click', function (e) {
//	            e.preventDefault();
//	            FB.ui(
//	            {
//	                method: 'feed',
//	                name: 'Social Outbreak',
//	                link: 'http://www.so.techsturedevelopment.com',
//	                picture: 'http://www.so.techsturedevelopment.com/Content/images/we_build_img.jpg',
//	                caption: 'TSMA-Social Outbreak',
//	                description: 'You can share your reviews on Facebook',
//	                message: ''
//	            });
//	        });
   
    });
	
	function PopupCenter(pageURL,title,w,h) 
		{
			var left = (screen.width/2)-(w/2);
			var top = (screen.height/2)-(h/2);
			if(navigator.appName=='Microsoft Internet Explorer')
			{
			newwin =	window.open (pageURL);
			}
			else
			{
			newwin = window.open (pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width='+w+', height='+h+', top='+top+', left='+left);
			}
			newwin.focus();
		} 
</script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js" type="text/javascript"></script>
  <div id='fb-root'></div>
    <script src='https://connect.facebook.net/en_US/all.js'></script>
	<div id="divBackGround" class="divBackGround" style="display:none; width:520px;"></div>
<div id="divForm" style="width:100%; height:100%; text-align:center; background-image:url(../Content/facebookalert/images/popup_bg.png); position:absolute; z-index:999999999; text-align:center;  display:none;">
			    <div id="popup_content" style="padding-top:200px; padding-left:150px; text-align:left">
                  <table width="230" height="260" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td bgcolor="#395992" style="border:5px solid #a5e0ff; padding:2px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="right" valign="top"><a href="javascript:;" onclick="$('#divForm').hide();"><img src="../Content/images/popup_close.gif" width="13" height="13" /></a></td>
          </tr>
          <tr>
            <td align="center" valign="top"><table width="177" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td align="left" valign="top" style="font-family:Arial; font-size:13px; color:#FFF; font-weight:bold; line-height:17px;">Enter your contact<br />
                  information to sign up.</td>
              </tr>
              <tr>
                <td align="left" valign="top">&nbsp;</td>
              </tr>
              <tr>
                <td align="left" valign="top"><label>
                  <input name="txtFullName" type="text" id="txtFullName" style="background-image:url(../Content/images/popup_input_bg.jpg); width:172px; height:34px; border:0px; padding-left:5px; padding-right:5px; font-size:13px; font-family:Arial; color:#676969;" value="*Full Name" />
                </label></td>
              </tr>
              <tr>
                <td align="left" valign="top">&nbsp;</td>
              </tr>
              <tr>
                <td align="left" valign="top"><label>
                  <input name="txtEmail" type="text" id="txtEmail" style="background-image:url(../Content/images/popup_input_bg.jpg); width:172px; height:34px; border:0px; padding-left:5px; padding-right:5px; font-size:13px; font-family:Arial; color:#676969;" value="*Email Address" />
                </label></td>
              </tr>
              <tr>
                <td align="left" valign="top">&nbsp;</td>
              </tr>
              <tr>
                <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="30" align="left" valign="top" style="background-image:url(../Content/images/popup_rediyo_button.jpg); background-repeat:no-repeat;"><label>
                      <input type="checkbox" name="chkOverOld" id="chkOverOld" />
                    </label></td>
                    <td align="left" valign="top" style="font-family:Arial; font-size:13px; color:#FFF; font-weight:bold; line-height:17px;">I am Over <br />
                      18 years old.</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td align="left" valign="top">&nbsp;</td>
              </tr>
              <tr>
                <td align="left" valign="top"><input type="image" src="../Content/images/popup_enter_button.jpg" width="177" height="37" id="btnSubmit" /></td>
              </tr>
              <tr>
                <td align="left" valign="top">&nbsp;</td>
              </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
    </table>
			 </div>
	</div>
	<div id="divMessage" style="width:100%; height:100%; text-align:center; background-image:url(../Content/facebookalert/images/popup_bg.png); position:absolute; z-index:999999999; text-align:center;  display:none;">
			    <div id="popup_content" style="padding-top:200px; padding-left:150px; text-align:left">
           <table width="232" height="260" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td align="center" valign="top" style="background-image:url(../Content/images/Popup_bg.jpg); background-repeat:no-repeat; width:230px; height:307px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="30" align="right" valign="top"><a href="javascript:;" onclick="$('#divMessage').hide();"><img src="../Content/images/popup_close1.gif" width="13" height="13" hspace="4" vspace="4" /></a></td>
          </tr>
          <tr>
            <td align="center"><img src="../Content/images/popup_thank_you.jpg" width="183" height="49" /></td>
          </tr>
          <tr>
            <td align="center" height="80"><img src ="../Content/images/sharebtn.png" id = "share_button"></td>
          </tr>
          <tr style="display:none">
            <td height="40" align="center" style="color:#32579b; font-weight:bold;">VIEW MY BUSINESS</td>
          </tr>
          <tr style="display:none">
            <td align="center" style="color:#da1c0a;"><a id="linkpage" runat="server" target="_blank" >Click Here</a></td>
          </tr>
          </table></td>
        </tr>
      </table>
			 </div>
	</div>
     <div style="width:520px;" id="divLiked" runat="server" Visible="false">
    <table cellpadding="2" cellspacing="1" border="0" style="width:520px">
    <tr>
    <td>
    <img src="../Content/images/sweepstakes_like_img.jpg" width="521" height="481" />
    </td>
    </tr>
    <tr>
    <td align="center">
    <img src="../Content/images/sweepstakes_like_enter_now.png" width="231" height="59" vspace="33" border="0" alt="Enter Now" onclick="ShowForm();" style="cursor:pointer;"/>

    </td>
    </tr>
    <tr>
    <td align="center"><table width="430" border="0" cellspacing="0" cellpadding="0" style="display:">
      <tr>
        <td style="font:Helvetica; font-size:11px; font-weight:normal; text-align:justify;"><font face="Helvetica">Official Rules: No purchase or payment of any kind is necessary to enter or win
this sweepstakes. A purchase will not increase your chances of winning. This promotion is in no way sponsored, endorsed or administered by, or
associated with, Apple, Inc., Facebook and/or Twitter. <font color="#5784d2"><a style="cursor:pointer;" onclick="PopupCenter('../rules.pdf', 'Privacy Policy','800','700')">See official rules</a></font>.
          </font><asp:Label ID="lblmsg" runat="server"></asp:Label></td>
      </tr>
    </table>      <br />

    </td>
    </tr>
	<tr>
	<td height="50">
	</td>
	</tr>
    </table>
    </div>
	
    <div style="width:500px; height:756px; background:url(../Content/images/sweepstakes_like_img.jpg) no-repeat;" id="divUnliked" runat="server" Visible="true">
    </div>
  <input type="hidden" id="hdnFBUserId" runat="server" name="hdnFBUserId"  />
  <input type="hidden" id="hdnTSMAUserId" runat="server" name="hdnTSMAUserId" />
  <input type="hidden" id="hdnFBPageId" runat="server" name="hdnFBPageId"  />
  <input type="hidden" id="hdnFBPageName" runat="server" name="hdnFBPageName"  />
   <input type="hidden" id="hdnSweepStakeAppId" runat="server" name="hdnSweepStakeAppId"  />
   <input type="hidden" id="hdnURL" runat="server" name="hdnURL"  />
      
   
</body>
</html>
<script language="javascript">
function ShowForm()
{
	 $('#divForm').show();
	 //showDivPopup12('divForm');
}
function Validate()
{
var fields
fields = "";
if (DoTrim(document.getElementById('txtFullName').value).length == 0 || DoTrim(document.getElementById('txtFullName').value)=='*Full Name' ) {
	fields = "\n-- Full Name --";
}

var re = new RegExp();
re = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
var sinput;
sinput = "";
if (DoTrim(document.getElementById('txtEmail').value).length == 0 || DoTrim(document.getElementById('txtEmail').value)=='*Email Address' ) {
	fields = fields + "\n-- Email Address --";
}
else {
	sinput = DoTrim(document.getElementById('txtEmail').value);
	if (!re.test(sinput)) {
		fields = fields + "\n-- Invalid Email Address --";
		document.getElementById('txtEmail').value == "";
	}
}
if (document.getElementById('chkOverOld').checked == false) {
	fields = fields + "\n-- Confirm Your Age --";
}
if (fields != "") {
	fields = "Please fill in the following details:\n--------------------------------" + fields;
	alert(fields);
	return false;
}
else {
	return true;
}
}
function DoTrim(strComp) {
ltrim = /^\s+/
rtrim = /\s+$/
strComp = strComp.replace(ltrim, '');
strComp = strComp.replace(rtrim, '');
return strComp;
}
$(document).ready(function(){
  $("#txtFullName").focus(function(){
    $("#txtFullName").val($("#txtFullName").val().replace('*Full Name',''));
  });
  
  $("#txtFullName").blur(function(){
    if($("#txtFullName").val()=='')
	{
		$("#txtFullName").val('*Full Name');
	}
  });
  
  $("#txtEmail").focus(function(){
    $("#txtEmail").val($("#txtEmail").val().replace('*Email Address',''));
  });
  
  $("#txtEmail").blur(function(){
    if($("#txtEmail").val()=='')
	{
		$("#txtEmail").val('*Email Address');
	}
  });
  
  	$("#btnSubmit").click(function()
  	{
  		if(Validate())
  		{
			//alert('ajax/ajax-sweepstak-contest.aspx?nm='+ $("#txtFullName").val() +'&em='+ $("#txtEmail").val() +'&fbuid='+ $("#hdnFBUserId").val() +'&tsmauid='+ $("#hdnTSMAUserId").val() +'&fbpid='+ $("#count").val() +'');
  		    $.ajax({ url: '../ajax/ajax-sweepstak-contest.aspx?nm=' + $("#txtFullName").val() + '&em=' + $("#txtEmail").val() + '&fbuid=' + $("#hdnFBUserId").val() + '&tsmauid=' + $("#hdnTSMAUserId").val() + '&fbpid=' + $("#hdnFBPageId").val() + '&fbpagename=' + $("#hdnFBPageName").val(), success: function (result)
			{
			//alert(result);
			//hideDivPopup('divForm');
			$('#divForm').hide();
			$('#divMessage').show();
			//showDivPopup12('divMessage');			
			}
			});			
		}
		else
		{
  			return false;
		}		
	});
});
</script>