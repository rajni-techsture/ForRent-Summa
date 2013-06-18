<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="header.ascx.vb" Inherits="tsma.headertop" %>
<link  href="Content/css/site.css" rel="stylesheet" type="text/css" />
<link id="lnkTheme" href="Content/css/apartment-style.css" rel="stylesheet" type="text/css" />
<link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
<script src="Content/js/jquery-ui.min.js"></script>
<script src="Content/js/popupmodel.js" type="text/javascript"></script>
<script language="javascript">
	 /*$(document).ready(function () {
	  if (navigator.appName == 'Microsoft Internet Explorer') {
        //jQuery.facebox('<div style="font-size:14px;font-weight:bold">This Tool work best on Following Browsers.</div></br><div><a href="#"><div style="float:left"><img src="content/sidebar-images/firefox_small_logo.png" height=120 /><div align="center" style="font-weight:bold;font-size:14px;font:arial;" >Firefox</div></div></a> <a href="#"><div style="float:left"><img src="content/sidebar-images/chrome_small_logo.png" height=120/><div align="center" style="font-weight:bold;font-size:14px;font:arial;" >Chrome</div></div></a>  <a href="#"><div style="float:left"><img src="content/sidebar-images/safari_small_logo.png" height=120/><div align="center" style="font-weight:bold;font-size:14px;font:arial;" >Safari</div></div></a> <div>');
		//window.setTimeout('window.close();',3000);
		//window.close();
	
				  $("#DivBrowser").show();
				
    }
	 });*/
        function changetheme(id) {
            if (id == 1) {
                $('#lnkTheme').attr("href", 'Content/css/apartment-style.css');
                $('#imgLeft').attr("src", 'Content/images/apartment_banner_img.jpg');
            }
            else {
                $('#lnkTheme').attr("href", 'Content/automotive-style.css');
                $('#imgLeft').attr("src", 'Content/images/automotive_banner_img.jpg');
            }
        }
</script>
<div id="DivBrowser" style="width:100%; height:100%; text-align:center; background-color:#CCCCCC; position:absolute; display:none;">
  <div align="center">
  <div style="font-size:14px;font-weight:bold">This Tool work best on Following Browsers.</div>
  </br>
  <div><a href="#">
    <div style="float:center"><img src="content/sidebar-images/firefox_small_logo.png" height=120 />
      <div align="center" style="font-weight:bold;font-size:14px;font:arial;" >Firefox</div>
    </div>
    </a> <a href="#">
    <div style="float:center"><img src="content/sidebar-images/chrome_small_logo.png" height=120/>
      <div align="center" style="font-weight:bold;font-size:14px;font:arial;" >Chrome</div>
    </div>
    </a> <a href="#">
    <div style="float:center"><img src="content/sidebar-images/safari_small_logo.png" height=120/>
      <div align="center" style="font-weight:bold;font-size:14px;font:arial;" >Safari</div>
    </div>
    </a></div>
    </div>
</div>
<div id="fb-root"></div>
<div class="main_box_hover2" style="position:absolute;z-index:1000;margin:380px 0 0 300px; display:none" id="warning_popup2" >
  <div class="main_box_hover_top2">
    <div class="main_box_hover_top_left"></div>
    <div class="main_box_hover_top_mid2"></div>
    <div class="main_box_hover_top_right"></div>
  </div>
  <div class="main_box_hover_mid2">
    <div class="main_box_hover_mid_left_shadow2">
      <div class="main_box_hover_mid_right_shadow2">
        <div class="main_box_hover_mid_inn2">
          <div class="main_box_hover_mid_inn_hd3" style="font-size:13px; font-family:Verdana, Geneva, sans-serif; width:416px padding-left:8px;">Warning! Please save your work before leaving this page.</div>
          <div class="apply_tut_but" style="margin-left:20px;"> <a href="#" id="already_link" >Already Saved</a> </div>
          <div class="apply_tut_but" style="margin-left:0;"> <a href="#_" onclick="hide('warning_popup2');return false;">Close & Click Save</a> </div>
        </div>
      </div>
    </div>
  </div>
  <div class="main_box_hover_top2">
    <div class="main_box_hover_bot_left"></div>
    <div class="main_box_hover_bot_mid2"></div>
    <div class="main_box_hover_bot_right"></div>
  </div>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="middle" class="headertop">
    <table width="1004" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="110" align="center" valign="middle"><a href='<%=System.Configuration.ConfigurationManager.AppSettings("AppPath")%>'> <img src="Content/images/marketplace_logo1.png" width="508" height="79" hspace="25" border="0" /></a> </td>
          
        </tr>
      </table></td>
  </tr>
</table>
    