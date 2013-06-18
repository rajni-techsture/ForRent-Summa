<%@ Page Language="vb" AutoEventWireup="false" Debug="true" validateRequest="false" CodeBehind="cover-photo-selection.aspx.vb" Inherits="tsma.cover_photo_selection" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="http://www.facebook.com/2008/fbml" >
<!--Update css-->
<head>
<link href="Content/css/sidebar_style_2.css" rel="stylesheet" type="text/css" />
<!--Update End css-->
<script type="text/javascript">
    function GetWidthHeight() {
        var strw = document.getElementById("divWidthHeight").style.width;
        document.getElementById("hdnWidth").value = strw;
        var strh = document.getElementById("divWidthHeight").style.height;
        document.getElementById("hdnHeight").value = strh;
    }
    function HideProgress() {
        parent.document.getElementById("imgLoading").style.display = 'none';
    }

    function ShowProgress() {
        parent.document.getElementById("imgLoading").style.display = 'block';
    }
    function SaveAlert(mess) {
        $("#spnMessage").html(mess);
        $("#DivSaveCoverPhoto").show("slow");
    }
    function HideSaveAlert() {
        $("#DivSaveCoverPhoto").hide("slow");
    }
    function HideCoverPhotoNameAlert() {
        $("#DivCoverPhotoName").hide("slow");
        $('#spinner').fadeIn('slow');
        __doPostBack("lnkSave", "");
    }
</script>
<link type="text/css" href="<%=ResolveUrl("Content/css/sidebar_style.css")%>" rel="stylesheet" media="all" />
<link href="<%=ResolveUrl("content/facebox/facebox.css")%>" media="screen" rel="stylesheet" type="text/css" />
<link href="<%=ResolveUrl("content/facebox/faceplant.css")%>" media="screen" rel="stylesheet" type="text/css" />
<script src="<%=ResolveUrl("content/js/jquery-1.7.1.js")%>"></script>
<script src="<%=ResolveUrl("content/js/jquery.ui.core.js")%>"></script>
<script src="<%=ResolveUrl("content/js/jquery.ui.widget.js")%>"></script>
<script src="<%=ResolveUrl("content/js/jquery.ui.mouse.js")%>"></script>
<script src="<%=ResolveUrl("content/js/jquery.ui.draggable.js")%>"></script>
<script src="Content/js/redirect-to-home.js" type="text/javascript"></script>
<link href="Content/facebookalert/facebookalert_files/facebook.alert.css" rel="stylesheet" type="text/css">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js"></script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.9/jquery-ui.min.js"></script>
<script type="text/javascript" src="scripts1/swfobject.js"></script>
<script type="text/javascript" src="scripts1/jquery.uploadify.v2.1.0.min.js"></script> 
<script src="Content/js/redirect-to-home.js" type="text/javascript"></script>
<script type="text/javascript" src="Content/facebookalert/facebookalert_files/jquery_facebook.alert.js"></script>
	<script type="text/javascript">
	    function FacebookAlert() {
	        jConfirm('Warning: Reset will discard your changes.', 'Reset Cover Photo',
				    function (r) {
				        if (r == true) {
				            __doPostBack("lnkReset", "");
				        }
				    });

	    }
	    function DownloadAlert() {
	        jPrompt('CoverPhoto will be downloaded to download folder on your computer', ' test ', 'Download Cover Photo',
				    function (r) {
				        if (r == true) {
				            __doPostBack("lnkDownload", "");
				        }
				    });

	    }
		</script>
<script type="text/javascript">
    $(init);
    function init() {
        $('.makeMeDraggable').draggable({
            containment: '#content_bg',
            cursor: 'move',
            snap: '#content'
        });
    }
</script>
<script type="text/javascript" src="Content/js/custom-rajni.js"></script>
<script src="Content/facebox/facebox.js" type="text/javascript"></script>
<script type="text/javascript">
    function PopupCenter(pageURL, title, w, h) {
        var left = (screen.width / 2) - (w / 2);
        var top = (screen.height / 2) - (h / 2);
        var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
    } 
</script>
<script type="text/javascript">
    function chkTemplatePage3(mess) {
        var test = $('#hdnIsSaved').val();
        if (test == "1") {
            window.parent.location.href = 'create-cover-photo';
            return true;
        }
        else {
            $("#spnMessage").html(mess);
            $("#DivSaveCoverPhoto").show("slow");
            return false;
        }
    }

    /*if ($('#hdnIsSaved').val() == 0) {
    jConfirm('Warning: It will discard your changes.  Continue?', 'Save Confirm',
    function (r) {
    if (r == true) {
    window.parent.location.href= 'create-cover-photo';

    }
    });
    }
    else {
    window.parent.location.href = 'create-cover-photo';
    }*/
    // window.parent.show('warning_popup3');
    //document.getElementById('warning_popup3').style.display='';


    //return confirm('Warning!  Please save your work before leaving this page.');
    //}
    function SaveCoverPhoto() {
        parent.document.getElementById('hdnSaveHeader').value = "1";
        document.getElementById('hdnIsSaved').value = "1";
        $("span[rel^=rm-css-text]").css("cursor", "default").css("border", "none");
        $("#commtimg").css("display", "none");
        $("#fbcommt").css("display", "inline");
        //$('#spinner').fadeIn('slow');
        $(".urlandtext").css("cursor", "pointer");
        $(".url").css("cursor", "pointer");
        $(".pointer").css("cursor", "pointer");
        $(".hide").css("display", "none");
        $('.rm-css-pan-window').remove();
        $('.rm-css-selected-window').remove();
        $('.rm-css-highlight-window').remove();
        //presentation_html = $('#presentation_html').html();
        $(".hide").css("display", "");
        $("#commtimg").css("display", "inline");
        $("#fbcommt").css("display", "none");
        var test = document.getElementById("divCoverPhotoHtml").innerHTML;
        document.getElementById("hdnCoverPhotoContent").value = test;
        $("#DivCoverPhotoName").show("slow");
        return true; //alert(test);
        //alert(document.getElementById("spnCoverPhoto").innerHTML);

    }
    function PublishCoverPhoto() {
        parent.document.getElementById('hdnSaveHeader').value = "1";
        document.getElementById('hdnIsSaved').value = "1";
        $("span[rel^=rm-css-text]").css("cursor", "default").css("border", "none");
        $("#commtimg").css("display", "none");
        $("#fbcommt").css("display", "inline");
        $('#spinner').fadeIn('slow');
        $(".urlandtext").css("cursor", "pointer");
        $(".url").css("cursor", "pointer");
        $(".pointer").css("cursor", "pointer");
        $(".hide").css("display", "none");
        $('.rm-css-pan-window').remove();
        $('.rm-css-selected-window').remove();
        $('.rm-css-highlight-window').remove();
        //presentation_html = $('#presentation_html').html();
        $(".hide").css("display", "");
        $("#commtimg").css("display", "inline");
        $("#fbcommt").css("display", "none");
        var test = document.getElementById("divCoverPhotoHtml").innerHTML;
        document.getElementById("hdnCoverPhotoContent").value = test;
        return true; //alert(test);
        //alert(document.getElementById("spnCoverPhoto").innerHTML);

    }
    function DownloadCoverPhoto() {
        $("span[rel^=rm-css-text]").css("cursor", "default").css("border", "none");
        $("#commtimg").css("display", "none");
        $("#fbcommt").css("display", "inline");
        //$('#spinner').fadeIn('slow');
        $(".urlandtext").css("cursor", "pointer");
        $(".url").css("cursor", "pointer");
        $(".pointer").css("cursor", "pointer");
        $(".hide").css("display", "none");
        $('.rm-css-pan-window').remove();
        $('.rm-css-selected-window').remove();
        $('.rm-css-highlight-window').remove();
        //presentation_html = $('#presentation_html').html();
        $(".hide").css("display", "");
        $("#commtimg").css("display", "inline");
        $("#fbcommt").css("display", "none");
        var test = document.getElementById("divCoverPhotoHtml").innerHTML;
        document.getElementById("hdnCoverPhotoContent").value = test;
        return true; //alert(test);
        //alert(document.getElementById("spnCoverPhoto").innerHTML);

    }
</script>
<style>
html, body {
	padding:0px;
	margin:0px;
	background-color: transparent;
}
</style>
</head>
<body class="rm-widget disabled" id="body">
<form id="frm1" runat="server">
<asp:ScriptManager ID="objScriptManager1" runat="server"></asp:ScriptManager>
<!-- Content End  here -->
<!--new_html-->
<div id="innerpagepagemain"  >
<uc1:inner ID="inner1" runat="server" />
<div id="centermain" style="height:950px;">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
  <td width="170" align="left" valign="top" class="leftbg"><uc3:left ID="left1" runat="server" />
  </td>
  <td align="left" valign="top" class="contentbody">

<span id="spnCoverPhoto" runat="server" style="display:"> </span>
<input type="hidden" id="hdnCoverPhotoContent" runat="server" />
<input type="hidden" id="hdnWidth" runat="server"/>
<input type="hidden" id="hdnHeight" runat="server" />
<input type="hidden" id="hdnIsSaved" value="1" />
<input type="hidden" id="hdnPublished" runat="server" value="1" />
 <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 16px; color: #181818; margin:0px; font-weight:bold;
	line-height:18px; text-align:center">&nbsp;</div><br />
    <div style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Larger"></asp:Label></div>
<div class="content_div" style="padding-top:20px;">
 <div id="DivSaveCoverPhoto" style="width:100%; height:100%; text-align:center;  background-image:url(Content/facebookalert/images/popup_bg.png);  position:absolute; z-index:999999999; text-align:center;  display:none;">
			  <div id="popup_container1" style="width:450px; height:80px;"  >
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  <span id="spnMessage"></span><br/><br/>
                   <input type="button" class="inputbutton" onclick="HideSaveAlert();" value="Close" id="popup_close" />
				</div>
			 </div>
			 </div>
<div id="DivCoverPhotoName" style="width:100%; height:100%; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:999999999; text-align:center;  display:none;">
			  <div id="popup_container1" style="width:450px; height:80px;" >
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  Cover Photo Name:  <input type="text" runat="server" id="txtCoverPhotoName" width="100" height="20" /><br/><br/>
                   <input type="button" class="inputbutton" onclick="HideCoverPhotoNameAlert();" value="Save" id="popup_save" />
				</div>
			 </div>
			 </div>
        <div class="watch_video_tut_box_cover" style="padding-left:10px;" >
          <div style="height:25px; margin-left:0px; font-size:18px"><b> </b>
            <div id="spinner" align="center" style="display:none;"><img src="Http://www.mysocialmediaagency.com/tsms_beta/images/bigspinner.gif" class="spinner1Class" /></div>
          </div>
          <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 14px; color: #181818; font-weight:bold; text-align:center; width:850px; padding-bottom:10px;"><asp:Label ID="txtname" runat="server"></asp:Label></div> 
          <div style="float:left; " id="presentation_html" align="left" >
            <style type="text/css">
			html,body{padding:0px;margin:0px;background-color: transparent;}.SafariBgFix{background-repeat:no-repeat;}
			</style>
            <div id="divCoverPhotoHtml" runat="server"></div>
            
          </div>
      </div>
</div>
<div class="watch_video_tut_box" style="padding-top:10px; padding-left:150px;">
  
  
<table width="599" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="top"><img src="Content/images/arrow_big_up.png" width="99" height="33" /></td>
  </tr>
  <tr>
    <td align="left" valign="top" style="padding:27px; padding-top:15PX; border-bottom:1px solid #dde2eb; border-right:1px solid #dde2eb; background-color:#f3f4f8"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td align="center"><table border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="90" align="left" valign="middle"><img src="Content/images/quick_start_tutorial_icon.png" width="85" height="61" align="absmiddle" /></td>
            <td style="font-size:22px; color:#3b3b3b; text-align:left; vertical-align:middle">Design Your Cover Photo</td>
            </tr>
          </table></td>
        </tr>
      
      <tr>
        <td align="center" style="vertical-align:middle; line-height:18px; padding-top:10px; padding-bottom:15px;">To edit the text, click the Edit Text button.  To customize the background and color or add an image, click the Edit Color & Images button.  Text may look a little different on download.</td>
        </tr>
      <tr>
        <td height="50" align="center" valign="middle" style="vertical-align:middle; font-weight:bold; line-height:18px;; padding-top:20px; padding-bottom:5px; border-top:1px solid #FFF; display:none">For ideal branding, pair up with the corresponding # for your Cover Photo</td>
        </tr>
      <tr>
        <td align="center" valign="bottom"><img src="Content/images/edit_mode_top.png" width="36" height="7" /></td>
        </tr>
      <tr>
        <td height="41" align="center" style="background-color:#8798b4; font-size:22PX; font-weight:bold; color:#FFF; vertical-align:middle">Edit Mode</td>
        </tr>
      <tr>
        <td style="border:1px solid #bdc7d8; background-color:#FFF; padding-left:20px;">                <div id="editor-nav">
          <div class="editor-nav-panel rc-m">
            <div class="editor-nav-panel-content">
              <a  href="#" class="nav-action-button rc-m rm-css-control-close" title="Watch Video Tutorial" onclick="$('#helptext12').fadeIn();"><img src="Content/images/arrow_round_gray.png" width="15" height="15" align="absmiddle" style="margin-right:7px;"  />Watch Video Tutorial</a> 
              <div id="helptext1" style="background-image:url(http://mysocialmediaagency.com/mysocialmediaagency/images/facebook_frame_coaching2_video_bg.png); background-position:top; background-repeat:no-repeat; width:660px; height:474px; text-align:left;position:absolute;top:-500px;left:-100px;display:none;z-index:90000">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="51" align="left" valign="top">&nbsp;</td>
                    <td align="right" valign="bottom" style="padding-right:28px; padding-top:55px; text-align:right"><a href="#"><img src="http://mysocialmediaagency.com/mysocialmediaagency/images/facebook_transparent_img.png" width="28" height="22" border="0" align="top" onclick="$('#helptext1').fadeOut();" /></a></td>
                    </tr>
                  <tr>
                    <td align="left" valign="top">&nbsp;</td>
                    <td align="left" valign="top" style="text-align:left">
                      <span id="spnVideo" runat="server"></span>
                      </td>
                    </tr>
                  </table>
                </div>
              <a id="rm-content-launch"  href="#launch-content" class="nav-action-button rc-m rm-css-control-close" title="Edit text content"><img src="Content/images/arrow_round_gray.png" width="15" height="15" align="absmiddle" style="margin-right:7px;"  />Edit Text</a> 
              <a id="rm-css-launch" href="#launch-css" class="nav-action-button rc-m " title="Edit Appearance of the Presentation!"><img src="Content/images/arrow_round_gray.png" width="15" height="15" align="absmiddle" style="margin-right:7px;"  />Edit Color & Images</a> 
              <a id="ch_temp"  href="javascript:;" target="_parent" class="nav-action-button rc-m " title="Change Template for this Page." onclick="chkTemplatePage3('Warning! Please Save your work befor leave this page othrewise your changes will be discarded');"><img src="Content/images/arrow_round_gray.png" width="15" height="15" align="absmiddle" style="margin-right:7px;"  />Change Template</a>
              <a href="javascript:;" onclick="FacebookAlert();" class="nav-action-button rc-m " title="Reset selected template"><img src="Content/images/arrow_round_gray.png" width="15" height="15" align="absmiddle" style="margin-right:7px;"  />Reset</a>
              <a href="#" id="lnkReset" runat="server" style="display:none" ></a>
              <a href="#"  class="nav-action-button rc-m " title="Save CoverPhoto" id="lnkSaveName" runat="server" onclick="SaveCoverPhoto();GetWidthHeight();" ><img src="Content/images/arrow_round_gray.png" width="15" height="15" align="absmiddle" style="margin-right:7px;"  />Save</a><a href="#" id="lnkSave" runat="server" style="display:none"></a>
              <a href="#"  class="nav-action-button rc-m " title="Publish CoverPhoto" id="lnkPublish" runat="server" onclick="PublishCoverPhoto();GetWidthHeight();"><img src="Content/images/arrow_round_gray.png" width="15" height="15" align="absmiddle" style="margin-right:7px;"  />Publish Cover Photo</a>
              <a href="#"  class="nav-action-button rc-m " title="Download" onclick="DownloadAlert();DownloadCoverPhoto();GetWidthHeight();" style="display:none"><img src="Content/images/arrow_round_gray.png" width="15" height="15" align="absmiddle" style="margin-right:7px;"  />Download</a>
              <a href="#"  id="lnkDownload" runat="server" style="display:none" ></a>
               <div style="padding-left:200px; padding-top:200px;"><img id="imgLoading" src="Http://www.mysocialmediaagency.com/tsms_beta/images/bigspinner.gif" style="display:none" /> </div>
			   <!--
              <a href="http://www.picnik.com/app" target="_blank" class="nav-action-button rc-m " title="Crop Image" >Crop Image</a> 
                      <a  href="#launch-css" class="nav-action-button rc-m " title="Close full screen" onclick="window.self.close();">Close</a>-->
              </div>
            </div>
          </div></td>
        </tr>
    </table></td>
  </tr>
</table>
  </div>
  </td>
  </tr>
  </table>
  </div>
  </div>
  </form>
<!--End new html-->
<!-- Below are widget codes are written  -->
<div id="fbox" ></div>
<input type="text" name="fix" id="fix" style="display:none" />
<div style="display:none; width:420px; opacity: 1; left: 758px; top: 244px; height: 258px;clear:both; padding-left:30px;" id="rm-appearance-panel" class="">
<div style="background-image:url(content/sidebar-images/widget_box_bg.png); width:392px;height:187px; position:relative; padding:0px; padding-top:9px;display:a;"  id="rm-appearance-type" class="rm-css-subpanel" >
  <div style="position:absolute; left:16px; top:17px;"><img src="content/sidebar-images/widget_top_arrow.png" width="32" height="26" /></div>
  <div style="width:366px; height:20px; background-color:#43bae2; margin-left:9px; font-family:arial; font-size:14px; font-weight:bold; color:#FFF; padding-left:8px; padding-top:5px; text-transform:uppercase; position:relative">TEXT options</div>
  <div style="background-color:#FFF; width:346px; height:125px; position:relative; margin-left:9px; padding:14px;" >
    <div style="height:38px;">
      <div style="display: a;" class="rm-css-controlrow fgtype">
        <style>
div.selector {
    background: none repeat scroll 0 0 #F9F9F9;
    border: 1px solid #CDCDCD;
    border-radius: 5px 5px 5px 5px;
    float: left;
    height: 25px;
    overflow: hidden;
    padding: 0 70px 0 5px;
    position: relative;
}
</style>
        <div style="float:left;font-size:18px;padding:0 70px 0 5px;;width:140px;height:25px;" id="uniform-rm-css-font-family" >
          <select style="opacity: 0;width:140px;cursor:pointer;font-size:16px;" id="rm-css-font-family" class="rm-css-control" name="family">
            <option value="sans-serif-one" style="font:Arial, Helvetica, sans-serif;"><span style="font:Arial, Helvetica, sans-serif;">Helvetica/Arial</span></option>
            <option value="sans-serif-two" style="font:Verdana, Geneva, sans-serif;"><span style="font:Verdana, Geneva, sans-serif;">Verdana</span></option>
            <option value="block-sans" style="font:'Trebuchet MS', Arial, Helvetica, sans-serif;"><span style="font:'Trebuchet MS', Arial, Helvetica, sans-serif;">Impact</span></option>
            <option value="monospace" style="font:'Courier New', Courier, monospace;"><span style="font:'Courier New', Courier, monospace;">CourierNew</span></option>
            <option value="serif-two" style="font:'Times New Roman', Times, serif;"><span style="font:'Times New Roman', Times, serif;">TimesNewRoman</span></option>
            <option value="serif-three" style="font:'Palatino Linotype', 'Book Antiqua', Palatino, serif;"><span style="font:'Palatino Linotype', 'Book Antiqua', Palatino, serif;">Palatino</span></option>
          </select>
        </div>
        <div style="float:right;margin-left:45px;"> <a href="#"  id="rm-css-type-bold">a</a><a href="#" id="rm-css-type-italic">b</a> </div>
      </div>
    </div>
    <div style="height:38px;">
      <div style="font-family:arial; font-size:25px; color:#666666; width:28px; float:left">tT</div>
      <div style="float:left; width:55px;"> <span id="rm-css-type-size-indicator" style="border:1px solid #adadad; background-color:#ddf1fc; padding-left:10px; width:45px; height:22px; font-family:arial; font-size:16px; color:#666666;font-size:20px;padding-right:10px;">12</span> </div>
      <div style="width:100px; float:left; margin-left:15px;"><a href="#" id="rm-css-type-increasesize"><img src="content/sidebar-images/widget_icon_plus.png" width="30" height="26" border="0" /></a>&nbsp;<a href="#" id="rm-css-type-decreasesize"><img src="content/sidebar-images/widget_icon_minus.png" width="30" height="26" hspace="10" border="0" /></a></div>
      <div style="float:left; position:absolute; top:50px; left:230px;"><img src="content/sidebar-images/widget_color.png" width="42" height="37" border="0" /></div>
      <div style="float:left; position:relative; width:68px; left:75px;">
        <div id="rm-css-color-foreground" class="rm-color-select" style="width:70px;height:30px;"></div>
      </div>
    </div>
    <div>
      <div style="float:left; font-family:arial; font-size:16px; color:#666666; width:98px; padding-top:5px;">POSITION</div>
      <div><a href="#" id="rm-css-type-alignleft"><img src="content/sidebar-images/widget_left_align.png" width="30" height="26" border="0" /></a>&nbsp;<a href="#" id="rm-css-type-aligncenter"><img src="content/sidebar-images/widget_center_align.png" width="30" height="26" hspace="9" border="0" /></a>&nbsp;<a href="#" id="rm-css-type-alignright"><img src="content/sidebar-images/widget_right_align.png" width="30" height="26" border="0" /></a></div>
    </div>
    <div style="border-bottom:1px solid #dddddd; height:7px; width:100%;"></div>
    <div style="float:right; margin-top:7px; background-color:#003399"><a href="#" title="Close Visual Editor">
      <!--<img src="content/facebox/closelabel.gif"  border="0" />-->
      </a></div>
  </div>
</div>
<div style="background-image:url(content/sidebar-images/widget_box_bg2.png); width:392px; height:236px; position:relative; padding:0px; padding-top:9px;"  id="rm-appearance-background" class="rm-css-subpanel">
<div style="position:absolute; left:16px; top:16px;"><img src="content/sidebar-images/widget_top_arrow.png" width="32" height="26" /></div>
<div style="width:366px; height:20px; background-color:#43bae2; margin-left:9px; font-family:arial; font-size:14px; font-weight:bold; color:#FFF; padding-left:8px; padding-top:5px; text-transform:uppercase; position:relative">Image options</div>
<div style="background-color:#FFF; width:346px; height:174px; position:relative; margin-left:9px; padding:14px;">
<div style="height:40px;" >
<div style="width:100px; font-family:arial; font-size:16px; color:#666666; float:left; padding-top:4px;">IMAGE</div>
<div style="float:left">
<div id="rm-css-bgimage-control" class="rm-css-bgimage-control" style="z-index:1000">
<form class="rm-widget disabled" id="bgimage-upload" method="post" action="#">
  <input style="display: none;" id="rm-css-bgimage-uploader" name="rm-image" width="119" type="file" height="18">
  <div style="position:absolute;top:0px; z-index:10" >
     <object style="visibility: visible;" id="rm-css-bgimage-uploaderUploader" data="../root4_files/uploadify.swf" type="application/x-shockwave-flash" width="120" height="18">
			  <param value="high" name="quality">
			  <param value="transparent" name="wmode">
			  <param value="always" name="allowScriptAccess">
			  <param value="uploadifyID=rm-css-bgimage-uploader&amp;buttonText=Upload%20new&amp;script=/upload.ashx&amp;folder=uploads&amp;width=119&amp;height=18&amp;wmode=transparent&amp;method=POST&amp;queueSizeLimit=200999&amp;simUploadLimit=1&amp;hideButton=true&amp;fileDesc=jpg, jpeg, png, gif&amp;fileExt=*.jpg;*.jpeg;*.gif;*.png&amp;auto=true&amp;sizeLimit=5000000&amp;fileDataName=Filedata&amp;" name="flashvars">
			</object>
  </div>
  <div id="rm-css-bgimage-uploaderQueue" class="uploadifyQueue" ></div>
</form>
<div class="progress-bar" id="progress-bar"  style="text-align: center; position:absolute; z-index:1; top:0px;  width:200px; left:0px; height:21px; padding-top:3px; border:0px solid #FF0000;">Add </div>
<a style="display: none;" href="#remove-bg-image" id="rm-css-bgimage-remove" class="" title="remove this image?">Remove</a>
</div>

</div>
<span style="font:Arial, Helvetica, sans-serif;font-size:10px;float:right;font-weight:bold;">Width &nbsp;: <span id="bgwidth" style="color:#060"></span><br>
Height : <span id="bgheight" style="color:#060"></span></span>
</div>
<div style="height:41px;">
  <div style="float:left; position:absolute; top:45px; left:18px;"><a href="#"><img src="content/sidebar-images/widget_color.png" width="42" height="37" border="0" /></a></div>
  <div style="font-family:arial; font-size:16px; color:#666666; float:left; position:relative; margin-left:75px; padding-top:4px;">BACKGROUND COLOR</div>
  <div style="width:87px; float:right">
    <div style="background-color: transparent;width:70px;height:30px;" id="rm-css-color-background" class="rm-color-select"></div>
  </div>
</div>
<div style="height:37px;">
  <div style="font-size:16px; font-family:arial; color:#666666; width:84px; float:left; padding-top:4px;">POSITION</div>
  <div style="float:left"><a href="#" id="rm-css-bgposition-left"><img src="content/sidebar-images/widget_position_left.png" width="31" height="26" border="0" /></a>&nbsp;<a href="#" id="rm-css-bgposition-top"><img src="content/sidebar-images/widget_position_top.png" width="30" height="26" hspace="4" border="0" /></a>&nbsp;<a href="#" id="rm-css-bgposition-bottom"><img src="content/sidebar-images/widget_position_bottom.png" width="30" height="26" border="0" /></a>&nbsp;<a href="#" id="rm-css-bgposition-right"><img src="content/sidebar-images/widget_position_right.png" width="30" height="26" hspace="4" border="0" /></a>&nbsp;
    <!--<a href="#" id="rm-css-bgposition-free" style="top:90px;left:233px;"><img src="content/sidebar-images/widget_position_move.png" width="30" height="26" hspace="10" border="0" /></a>-->
    <a  href="#" style="margin-left:92px" onclick="$('#helptext').fadeIn();"><img hspace="10" height="26" border="0"  src="content/sidebar-images/questionmark-48-Icon.png" ></a>
    <div style="clear:both;position:absolute;z-index:5000;display:none" id="helptext">
      <div style="background-image:url(content/sidebar-images/widget_box_bg4.png); width:194px; height:239px; padding-top:10px;">
        <div style="background-image:url(content/sidebar-images/widget_box_text_bg.png); width:173px; height:228px; margin-left:10px;">
          <div style="padding:10px;">
            <div style="font-family:arial; font-size:11px; line-height:14px;">Use the position settings to align your images to left, right, top, or bottom. OR use the move tool to freely position your image by dragging it around.<br />
              <br />
              You can repeat your image horizontally, vertically or click none for no repeat.<br />
              <br />
              To remove your image click the minus buttom at the top left.</div>
            <div style="border-bottom:1px solid #dddddd; height:7px;"></div>
            <div style="float:right; margin-top:5px;"><a href="#" onclick="$('#helptext').fadeOut();"><img src="content/facebox/closelabel.gif"  border="0" /></a></div>
          </div>
        </div>
        <br />
        <br />
      </div>
    </div>
  </div>
</div>
<div style="height:32px;">
  <div style="font-size:16px; font-family:arial; color:#666666; width:84px; float:left; padding-top:4px;">REPEAT</div>
  <div style="float:left"><a href="#" id="rm-css-bgrepeat-x"><img src="content/sidebar-images/widget_repeat_x.png" width="30" height="26" /></a>&nbsp;<a href="#" id="rm-css-bgrepeat-y" ><img src="content/sidebar-images/widget_repeat_y.png" width="30" height="26" hspace="4" /></a>&nbsp;<a href="#" id="rm-css-bg-transparent" style="display:none"><img src="content/sidebar-images/widget_repeat_no.png" width="30" height="26" /></a></div>
</div>
<div style="border-bottom:1px solid #dddddd; height:7px;"></div>
</div>
</div>
<div style="float:left; width:65px; margin-top:7px;"><a style="display: inline-block;position:absolute;margin-left:-158px;margin-top:-40px;font-family:'Times New Roman', Times, serif;font-size:14px;color:grey;" href="#cancel" id="rm-css-control-cancel" title="Undo latest changes for this element?"><strong>Undo Changes</strong></a><a href="#" id="rm-css-control-close" style="position:absolute; margin-left:70px;margin-top:-40px" title="Close Visual Editor"><img src="content/facebox/closelabel1.gif"  border="0" /></a></div>
</div>
<div id="hide"></div>
<form method="post" action="" id="CoverPhotoDownloadCodeForm" target="downloadiframe" >
  <input type="hidden" name="html" id="html2" value=""  />
  <input type="hidden" name="filename" id="filename" value=""  />
  <input type="hidden" name="width" id="width"   value=""  />
  <input type="hidden" name="user_id" value="" />
</form>

<div class="main_box_hover2" style="position:absolute; margin:250px 0 0 50px; z-index:1; display:none" id="warning_popup3" >
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
          <div class="apply_tut_but" style="margin-left:20px;"> <a href="#_" onclick="hide('warning_popup3');window.parent.showsidebartemplate();">Already Saved</a> </div>
          <div class="apply_tut_but" style="margin-left:0;"> <a href="#_" onclick="hide('warning_popup3');return false;">Close & Click Save</a> </div>
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
<script type="text/javascript">
    edit = 0;

    function falert(msg) {
        jQuery.facebox('<b>' + msg + '</b>');
    }

    $("div[rel^=rm-css-bg]").click(function (e) {
        var width = $(this).width();
        var height = $(this).height();
        $("#bgwidth").html(width + 'px');
        $("#bgheight").html(height + 'px');
    });

    /*		
    $(".dotted").mouseenter(function(){
    if(edit){
    width = $(this).width();
    height = $(this).height();

    $('.highlight-window').fadeOut('fast',function(){$('.highlight-window').remove('.highlight-window');});
    $(this).append('<div class="highlight-window" style="position: absolute; border: 1px dotted rgb(0, 0, 0); outline: 1px dotted rgb(255, 255, 255); padding: 5px; cursor: pointer; top: -5px; left: -4px; width: '+width+'px; height: '+height+'px; z-index: 1100; display: none;"></div');
    $('.highlight-window').fadeIn('fast');
    return false;
    }
    });

    $(".dotted").mouseleave(function(){
    if(edit){
    $('.highlight-window').fadeOut('fast',function(){$('.highlight-window').remove('.highlight-window');});
    }
    });

    $(".dotted").click(function(){
    if(edit){
    $('.highlight-window').fadeOut('fast',function(){$('.highlight-window').remove('.highlight-window');});
    }
    });
    */

    $.ajaxSetup({
        url: "/xmlhttp/",
        global: false,
        type: "POST"
    });


    $("#rm-css-launch").click(function () {
        edit = 0;
        $("span[rel^=rm-css-text]").css("cursor", "default").css("border", "none");
        $("div[rel^=video]").css("cursor", "default");
        $(".url").css("cursor", "default");
        $(".pointer").css("cursor", "default");
        $(".urlandtext").css("cursor", "default");
    });

    $("#rm-content-launch").click(function () {
        edit = 1;
        $("span[rel^=rm-css-text]").css("cursor", "pointer").css("border", "thin solid").css("border-style", "dotted");
        $("div[rel^=video]").css("cursor", "pointer");
        $(".url").css("cursor", "pointer");
        $(".pointer").css("cursor", "pointer");
        $(".urlandtext").css("cursor", "pointer");
        $('.rm-css-edit fg fgtype').draggable({
            containment: '#content_bg',
            cursor: 'move',
            snap: '#content'
        });

    });

    $("div[rel^=video]").click(function (e) {

        id = $(this).attr('rel');
        size = $(this).attr('class');

        if (size == 'big') {
            func = 'videobig';
        }
        else if (size == 'small') {
            func = 'videosmall';
        }
        else {
            func = 'videobig';
        }

        form = '<div style="font-size:16px"><b>Enter YouTube URL : </b><br><br> <input type="text" id="videourl" value="http://www.youtube.com/watch?v=bfKBk28ObRs&feature=topvideos"  size="38" style="font-size:16px"/>  <input type="button" value="Upload" onClick="' + func + '(document.getElementById(\'videourl\').value,\'' + id + '\');fboxhide();" /> </div>';

        if (edit) {
            fbook_box(e, form);
            $('#facebox').fadeIn('slow');
        }

    });

    //$(".hide").css("display","block");
    $('<style type="text/css">.hide{ display:block }</style>').appendTo('#hide');

    $(".pointer").css("cursor", "default");
    $(".url").css("cursor", "default");


    $(".url").click(function (e) {

        url = $(this).attr('rel');
        func = 'seturl';
        form = '<div style="font-size:16px"><b>Enter Website URL : </b><br><br> <input type="text" id="url" value="' + url + '"  size="38" style="font-size:16px"/>  <input type="button" value="Update" onClick="' + func + '(document.getElementById(\'url\').value,\'' + $(".url").index(this) + '\');fboxhide();" /> </div>';

        if (edit) {
            fbook_box(e, form);
            $('#facebox').fadeIn('slow');
        }
    });


    $(".urlandtext").click(function (e) {

        id = $(this).attr('id');
        url = $(this).attr('rel');
        func = 'seturl2';
        form = '<div style="font-size:16px"><b>Edit Text : </b><br><br> <input type="text" onkeyup="$(\'#' + id + '\').html(this.value)" value="' + $(this).html() + '"  size="38" style="font-size:16px"/><br><br> </div><div style="font-size:16px"><b>Enter Website URL : </b><br><br> <input type="text" id="url" value="' + url + '"  size="38" style="font-size:16px"/>  <input type="button" value="Update" onClick="' + func + '(document.getElementById(\'url\').value,\'' + $(".urlandtext").index(this) + '\');fboxhide();" /> </div>';

        if (edit) {
            fbook_box(e, form);
            $('#facebox').fadeIn('slow');
        }

    });


    $("#contact").click(function (e) {

        id = $(this).attr('id');
        //email  = $(this).attr('rel');
        func = 'setcontact';
        form = '<div style="font-size:16px"><b>Edit Text : </b><br><br> <input type="text" id="url" onkeyup="$(\'#' + id + '\').html(this.value)" value="' + $(this).html() + '"  size="38" style="font-size:16px"/><br><br> </div><!--<div style="font-size:16px"><b>Enter Email Adress : </b><br><br> <input type="text" id="email" value="' + email + '"  size="38" style="font-size:16px"/>  <input type="button" value="Update" onClick="' + func + '(document.getElementById(\'email\').value);fboxhide();" /> </div>-->';

        if (edit) {
            fbook_box(e, form);
            $('#facebox').fadeIn('slow');
        }

    });


    $(".contact").click(function (e) {

        func = 'setcontact';
        form = '<div style="font-size:16px"><b>Edit Text : </b><br><br> <input type="text" id="url" onkeyup="$(\'.contact\').html(this.value)" value="' + $(this).html() + '"  size="38" style="font-size:16px"/><br><br> </div>';

        if (edit) {
            fbook_box(e, form);
            $('#facebox').fadeIn('slow');
        }

    });

    function setcontact(email) {
        $("#contact").attr('rel', email);
        $("#contact").attr('onclick', 'setLocation(\'mailto:' + email + '\');');
    }

    function seturl(url, index) {
        $(".url:eq(" + index + ")").attr('rel', url);
        $(".url:eq(" + index + ")").attr('onclick', 'setLocation(\'' + url + '\');');
        //alert (url+' : '+index);
    }

    function seturl2(url, index) {
        $(".urlandtext:eq(" + index + ")").attr('rel', url);
        $(".urlandtext:eq(" + index + ")").attr('onclick', 'setLocation(\'' + url + '\');');
        //alert (url+' : '+index);
    }

    function videobig(url, id) {
        //alert('big url : '+ url + ' id : '+id);
        var vid;
        var results;

        results = url.match("[\\?&]v=([^&#]*)");

        vid = (results === null) ? url : results[1];

        $.ajax({
            url: 'ajax.php',
            data: ({ utubevid: vid, ajax: 1, utube: 1, page_id: 0 }),
            success: function (data) {
                $('#' + id).html(data);
                $('#spinner').fadeOut('slow', function () { $('#' + id).css('background-image', "url(http://mysocialmediaagency.com/tsms_beta/playimgbig.php?img=http://mysocialmediaagency.com/tsms_beta/thumb.php?x=370%26y=229%26src=http://img.youtube.com/vi/" + vid + "/0.jpg)"); });
            }
        });

    }

    function videosmall(url, id) {
        //alert('small url : '+ url + ' id : '+id);

        var vid;
        var results;

        results = url.match("[\\?&]v=([^&#]*)");

        vid = (results === null) ? url : results[1];

        $.ajax({
            url: 'ajax.php',
            data: ({ utubevid: vid, ajax: 1, utube: 1, page_id: 0 }),
            success: function (data) {
                $('#' + id).html(data);
                $('#spinner').fadeOut('slow', function () { $("div[rel=" + id + "] img:first").attr("src", "http://mysocialmediaagency.com/tsms_beta/playimgsmall.php?img=http://img.youtube.com/vi/" + vid + "/2.jpg"); });
            }
        });

    }


    $("#rm-css-control-cancel").click(function (e) {
        /*alert(revent_index);
        alert(revent_style);*/
        $(".rm-css-edit:eq(" + revent_index + ")").attr('style', revent_style);
        $(".rm-css-edit:eq(" + revent_index + ")").parent().attr('style', revent_parent_style);
    });

    $(".rm-css-edit").click(function (e) {
        revent_index = $(".rm-css-edit").index(this);
        revent_style = $(this).attr('style');
        revent_parent_style = $(this).parent().attr('style');
    });

    function rmtextcontrolcancel() {
        $("#content_edit_box").val(textrevent_html);
        $("span[rel^=rm-css-text]:eq(" + textrevent_index + ")").html(textrevent_html);
    }

    $("span[rel^=rm-css-text]").click(function (e) {
        textrevent_index = $("span[rel^=rm-css-text]").index(this);
        textrevent_html = $(this).html();
    });

    $("span[rel^=rm-css-text][title!=notextedit]").click(function (e) {

        rel = $(this).attr('rel');
        form = '<div style="font-size:16px"><b>Edit Text : </b><br><br> <textarea style="font-size: 12px;width:400px;height:100px;" id="content_edit_box" onkeyup="$(\'span[rel=' + rel + ']\').html(nl2br(this.value));show(\'rm-text-control-cancel\')"  >' + mtrim(br2nl($(this).html()), '&nbsp;') + '</textarea><br><br><a href="#" id="rm-text-control-cancel" style="display:none" onclick="rmtextcontrolcancel()">Cancel Text changes</a></div>';

        if (edit) {
            fbook_box(e, form);
            $('#facebox').fadeIn('slow');
        }
    });

    $("span[rel^=rm-css-text]").mouseenter(function () { if (edit) $(this).css("cursor", "pointer"); });
    $("span[rel^=rm-css-text]").mouseleave(function () { if (edit) $(this).css("cursor", "default"); });
    $("#commtimg").css("display", "inline");
    $("#fbcommt").css("display", "none");

    function fbook_box(e, html) {
        //e.pageX
        $('#fbox').html('<div style="top: ' + (e.pageY - 30) + 'px; left: ' + 280 + 'px; display: none;z-index:2000000000" id="facebox"><div class="popup"><table><tr><td class="tl"></td><td class="b"></td><td class="tr"></td></tr><tr><td class="b"></td><td class="body"><div style="float: none; display: block;" class="content">' + html + '</div><div class="footer" style="display: block; width:100%;"><a class="close" href="#_" onclick="fboxhide()"><img class="close_image" title="close" src="content/facebox/closelabel1.gif"></a></div></td><td class="b"></td></tr><tr><td class="bl"></td><td class="b"></td><td class="br"></td></tr></table></div></div><div class="facebox_hide facebox_overlayBG" onclick="fboxhide()" id="facebox_overlay" style="display: block; opacity: 0;filter:alpha(opacity=0);"></div>');
    }

    function fboxhide() {
        parent.document.getElementById('hdnSaveHeader').value = "0";
        document.getElementById('hdnIsSaved').value = "0";
        $('#facebox_overlay').hide();
        $('#facebox').fadeOut('slow');
    }

    function share() {
        return true;
    }
    function setLocation(url) {
        return url;
    }

    /*if (navigator.appName == 'Microsoft Internet Explorer') {
    jQuery.facebox('<div style="font-size:14px;font-weight:bold">This Tool work best on Following Browsers.</div></br><div><a href="#"><div style="float:left"><img src="content/sidebar-images/firefox_small_logo.png" height=120 /><div align="center" style="font-weight:bold;font-size:14px;font:arial;" >Firefox</div></div></a> <a href="#"><div style="float:left"><img src="content/sidebar-images/chrome_small_logo.png" height=120/><div align="center" style="font-weight:bold;font-size:14px;font:arial;" >Chrome</div></div></a>  <a href="#"><div style="float:left"><img src="content/sidebar-images/safari_small_logo.png" height=120/><div align="center" style="font-weight:bold;font-size:14px;font:arial;" >Safari</div></div></a> <div>');
    }*/

    function show(id) {
        if (edit) {
            document.getElementById(id).style.display = 'block';
        }
    }

    function hide(id) {
        document.getElementById(id).style.display = 'none';
    }

    function nl2br(str, is_xhtml) {
        // http://kevin.vanzonneveld.net
        // +   original by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
        // +   improved by: Philip Peterson
        // +   improved by: Onno Marsman
        // +   improved by: Atli Þór
        // +   bugfixed by: Onno Marsman
        // +      input by: Brett Zamir (http://brett-zamir.me)
        // +   bugfixed by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
        // +   improved by: Brett Zamir (http://brett-zamir.me)
        // +   improved by: Maximusya
        // *     example 1: nl2br('Kevin\nvan\nZonneveld');
        // *     returns 1: 'Kevin<br />\nvan<br />\nZonneveld'
        // *     example 2: nl2br("\nOne\nTwo\n\nThree\n", false);
        // *     returns 2: '<br>\nOne<br>\nTwo<br>\n<br>\nThree<br>\n'
        // *     example 3: nl2br("\nOne\nTwo\n\nThree\n", true);
        // *     returns 3: '<br />\nOne<br />\nTwo<br />\n<br />\nThree<br />\n'
        var breakTag = (is_xhtml || typeof is_xhtml === 'undefined') ? '<br />' : '<br>';

        brstr = (str + '').replace(/([^>\r\n]?)(\r\n|\n\r|\r|\n)/g, '$1' + breakTag + '$2');

        if (brstr == '') {
            return '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        }
        else {
            return brstr;
        }
    }

    function br2nl(str) {
        return str.replace(/<br\s*\/?>/mg, "\n");
    };

    /**
    *
    *  Javascript trim, ltrim, rtrim
    *  http://www.webtoolkit.info/
    *
    **/

    function trim(str, chars) {
        return ltrim(rtrim(str, chars), chars);
    }

    function ltrim(str, chars) {
        chars = chars || "\\s";
        return str.replace(new RegExp("^[" + chars + "]+", "g"), "");
    }

    function rtrim(str, chars) {
        chars = chars || "\\s";
        return str.replace(new RegExp("[" + chars + "]+$", "g"), "");
    }

    function mtrim(str, chars) {
        chars = chars || "\\s";
        return str.replace(new RegExp("&nbsp;", "g"), "");
    }


</script>
<script type="text/javascript">
    function PopupCenter(pageURL, title, w, h) {
        var left = (screen.width / 2) - (w / 2);
        var top = (screen.height / 2) - (h / 2);
        var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        targetWin.focus();
    } 
</script>
</td>
</tr>
</table>
</div>
</div>
<%--<div id="div3" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute;">
                          <asp:UpdateProgress ID="UpdateProgress1" runat="Server" DisplayAfter="0">
                            <ProgressTemplate> <img src="Http://www.mysocialmediaagency.com/tsms_beta/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                          </asp:UpdateProgress>
                        </div>	--%>
						<br /><br /><br /><br /><br /><br />
<uc2:inner ID="inner2" runat="server" />
<input type="hidden" runat="server" id="hdnUserId" />
<input type="hidden" runat="server" id="hdnFBUserId" />
<input type="hidden" runat="server" id="hdnCompanyId" />
<input type="hidden" runat="server" id="hdnIndustryId" />

</body>
</html>
