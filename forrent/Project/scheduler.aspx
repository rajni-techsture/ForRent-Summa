<%@ Page Language="vb" AutoEventWireup="false" Debug="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="scheduler.aspx.vb" Inherits="tsma.scheduler" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner1" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
<%--<meta http-equiv="refresh" content="60">--%>
<title>Total Social Media Application</title>
<script src="<%=ResolveUrl("~/Content/css/SpryTabbedPanels.js")%>" type="text/javascript"></script>
<link href="<%=ResolveUrl("~/Content/css/SpryTabbedPanels.css")%>" rel="stylesheet" type="text/css" />
<link href="<%=ResolveUrl("~/Content/facebookalert/facebookalert_files/facebook.alert.css")%>" rel="stylesheet" type="text/css">
<script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
<script src="<%=ResolveUrl("~/Content/js/jquery-ui.min.js") %>" type="text/javascript"></script>
<script src="<%=ResolveUrl("~/content/js/pagejs/scheduler.js") %>" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    {
       /* if (navigator.appName == 'Microsoft Internet Explorer') {
		var reader = new ActiveXObject("Scripting.FileSystemObject");
		}
		else
		{
		var reader = new FileReader();
		}*/
      

		var reader = new FileReader();
        reader.onload = function (e) {
            document.getElementById('imgPhoto').src = e.target.result;
			document.getElementById('lnkFileRemove').style.display="block";
        };
        function readURL(input) {
            if (input.files && input.files[0]) {
			
                reader.readAsDataURL(input.files[0]);
				document.getElementById('lnkFileRemove').style.display="block";
            }
            else {
                document.getElementById('imgPhoto').src = input.value || "No file selected";
				
            }
        }
    }
	
	 function SaveAlert(mess) {
	     var maskHeight1 = $(document).height();
	     var maskWidth1 = $(window).width();
	     $('#DivSaveSidebar').css({ 'width': maskWidth1, 'height': maskHeight1 });
				    $("#spnMessage").html(mess);
					$("#DivSaveSidebar").show("slow");
				}
				function HideSaveAlert() {
				    $("#DivSaveSidebar").hide("slow");
				}
	
	function SaveScheduleAlert(mess) {
	     var maskHeight1 = $(document).height();
	     var maskWidth1 = $(window).width();
	     $('#DivSaveScheduler').css({ 'width': maskWidth1, 'height': maskHeight1 });
		 $("#spnSchduleMessage").html(mess);
		 $("#DivSaveScheduler").show("slow");
		 }
			
    function CheckMessage() {
        $("#txtMessage").change(function () {
            $("#txtVideoMessage").val($(this).val());
            $("#txtLinkMessage").val($(this).val());
        });
    }
    function OpenAutoPostBusinessPageDiv()
    	{
   		   var pos = $('#AutoPostOpener').position();
				pos.left = parseInt(pos.left);
				pos.top = parseInt(pos.top);
				var x = pos.left;
				var y = pos.top;
				$('#divAutoPostFanPages').css('left', x - 350+ 'px')
				$('#divAutoPostFanPages').css('top', y + 30 + 'px')
		
				if ($('#divAutoPostFanPages').css('display') == 'none') {
					$('#divAutoPostFanPages').slideDown('slow');
				}
				else {
					$('#divAutoPostFanPages').slideUp('slow');
				}
  		}	
  
    function HideAutoPostFanPages()
    {
    	$('#divAutoPostFanPages').hide("slow");
    }
    function CheckVideoMessage() {
        $("#txtVideoMessage").change(function () {
            $("#txtMessage").val($(this).val());
            $("#txtLinkMessage").val($(this).val());
        });
    }
    function ShowAutoPostOnOff(mess) {
        var maskHeight = $(document).height();
        var maskWidth = $(window).width();
        $('#DivShowAutoPostOnOff').css({ 'width': maskWidth, 'height': maskHeight });

        $('#spnShuffleMess').html(mess);
		$('#DivShowAutoPostOnOff').show("slow");
    }
    function HideAutoPostOnOff() {
        $('#DivShowAutoPostOnOff').hide("slow");
    }
    function CheckLinkMessage() {
		/*if ($.trim($('#txtvideo').val()) == '') {
            fields = fields + "\n-- Video Link --";
        }
        else {
            if (validateURL() == false) {
                fields = fields + "\n-- Please Enter valid Url --";
            }
        }*/
        $("#txtLinkMessage").change(function () {
            $("#txtMessage").val($(this).val());
            $("#txtVideoMessage").val($(this).val());
        });
    }
	
    function ClearSchedule() {
        document.getElementById('txtActivationDate').value = "";
        document.getElementById('selActivationHour').value = 0;
        document.getElementById('selActivationMinute').value = "Minute";
        document.getElementById('selAMPM').value = "0";
        document.getElementById('ddlTimeZone').value = "0";
    }
    function validateURL() {
        var textval = document.getElementById("txtvideo").value;
        var urlregex = new RegExp(
				"^(http:\/\/www.|https:\/\/www.|ftp:\/\/www.|www.){1}([0-9A-Za-z]+\.)");
        if (urlregex.test(textval)) {
            return true;
        }
        else {
            alert("Please Enter Valid Url");
            return false;
        }
    }
    function OpenDiv() {
        $('#divUploadLimit').dialog({ autoOpen: false, bgiframe: true, modal: true });
        $('#divUploadLimit').dialog('open');
        $('#divUploadLimit').parent().appendTo($("form:first"));
    }
    function ShowUserLib(Id) {
        $('#trAdminLib').css('display', 'none');
        $('#trMyLib').css('display', '');
        $('#imgAdminLib').attr('src', "../content/images/company_library_hover_tab.gif");
        $('#imgMyLib').attr('src', "../content/images/my_library_tab.gif");
        $('tr[group^=userlibcattr]').each(
		function () {
		    $(this).css('display', 'none');

		});
        $('#trUserLibCat' + Id).slideDown('slow');
    }
	
	/*jQuery.fn.nl2br = function(){
	alert("test");
	   return this.each(function(){
		 //jQuery(this).val().replace(/(<br>)|(<br \/>)|(<p>)|(<\/p>)/g, "\r\n");
		 jQuery(this).val().replace("<br>","\r\n");
	   });
	};*/
	function RemoveFileUploadImage() {
	    $('#hdnImageChange').val('../content/images/no_img.jpg');
		$('#hdnImage1').val('');
		$("#imgPhoto").attr('src', '../content/uploads/images/no_img.jpg');
		document.getElementById('photo').value="";
		document.getElementById('lnkFileRemove').style.display="none";
	}
    function EditLib(Id) {
        $(".Fanpagesdiv1").hide("slow");
        $(".composediv1").show("slow");
        $(".photodiv1").hide("slow");
        $(".videodiv").hide("slow");
        $(".Linkdiv").hide("slow");
        $('#divLibCat').hide("slow");
        $('#divSchedule').hide("slow");
		var hdnimageid = $('#hdnlib' + Id).val();
        if (hdnimageid == '') {
            //$('#hdnImage1').val('no_img.jpg');
			$('#hdnImage1').val('');
        }
        else {
            $('#hdnImage1').val($.trim($('#hdnlib' + Id).val()));
			document.getElementById('lnkFileRemove').style.display="block";
        }
        $("#imgPhoto").attr('src', '../content/uploads/images/' + $('#hdnImage1').val());
        $('#hdnImageChange').val($("#imgPhoto").attr('src'));
        $('#txtvideo').val($.trim($('#hdnlibLink' + Id).val()))
        $('#txtMessage').val($.trim($('#spnlib' + Id).html()).replace("<br>","\r\n"));
        $('#txtVideoMessage').val($.trim($('#spnlib' + Id).html()).replace("<br>","\r\n"));
        $('#txtLinkMessage').val($.trim($('#spnlib' + Id).html()).replace("<br>","\r\n"));
    }
    function EditAutoPost(Id) {
        $(".Fanpagesdiv1").hide("slow");
        $(".composediv1").show("slow");
        $(".photodiv1").hide("slow");
        $(".videodiv").hide("slow");
        $(".Linkdiv").hide("slow");
        $('#divLibCat').hide("slow");
        $('#divSchedule').hide("slow");
        var hdnimageid = $('#hdnAutoPost' + Id).val();
        if (hdnimageid == '') {
            $('#hdnImage1').val('');
			//$('#hdnImage1').val('no_img.jpg');
        }
        else {
            $('#hdnImage1').val($.trim($('#hdnAutoPost' + Id).val()));
			document.getElementById('lnkFileRemove').style.display="block";
        }
        $("#imgPhoto").attr('src', '../content/uploads/images/' + $('#hdnImage1').val());
        $('#hdnImageChange').val($("#imgPhoto").attr('src'));
        $('#txtvideo').val($.trim($('#hdnAutoPostLink' + Id).val()))
        $('#txtMessage').val($.trim($('#spnAutoPost' + Id).html()).replace("<br>","\r\n"));
        $('#txtVideoMessage').val($.trim($('#spnAutoPost' + Id).html()).replace("<br>","\r\n"));
        $('#txtLinkMessage').val($.trim($('#spnAutoPost' + Id).html()).replace("<br>","\r\n"));
    }
    function DoTrim(strComp) {
        ltrim = /^\s+/
        rtrim = /\s+$/
        strComp = strComp.replace(ltrim, '');
        strComp = strComp.replace(rtrim, '');
        return strComp;
    }
   function CheckVideo() {
        var obj = document.getElementById('txtvideo');
        if (obj.value != '') {
            var vid;
            var results;
			
			var url = DoTrim(obj.value).toLowerCase();
            //Youtube
            url = DoTrim(obj.value);
			
            results = url.match("[\\?&]v=([^&#]*)");
			var res;
				
        	res = (results === null) ? "" : results[1];
        	vid = res.replace("http://youtu.be/", "");

           // if (results != null) {
               // res = results[1];
			
                if (vid != '') {
					
                    document.getElementById('imgThumbnail').src = "http://img.youtube.com/vi/" + vid + "/2.jpg";
                    document.getElementById('hdnVideoId').value = vid;
                    document.getElementById('hdnUrl').value = "http://img.youtube.com/vi/" + vid + "/2.jpg";
                    return true;
                }
                /*else {
                    alert('Invalid Youtube URL');
                    obj.value = '';
                    return false;
                }*/
          //  }
            /*else {
                alert('Invalid Youtube URL');
                obj.value = '';
                document.getElementById('txtvideo').value = '';
                document.getElementById('imgThumbnail').src = 'http://www.techsturedevelopment.com/content/images/no_img.jpg';
                document.getElementById('hdnVideoId').value = '';
                document.getElementById('hdnUrl').value = '';
                return false;
            }*/
        }
        else {
            obj.value = '';
            document.getElementById('txtvideo').value = '';
            document.getElementById('imgThumbnail').src = '../content/images/no_img.jpg';
            document.getElementById('hdnVideoId').value = '';
            document.getElementById('hdnUrl').value = '';
            return false;
        }
    }
	function FocusOnEnter(e) {
	 
	        if (null == e)
	            e = window.event;
	        if (e.keyCode == 13) {
	            document.getElementById("imgThumbnail").focus();
	            return false;
	        }

	    }
	    function CheckForImage() {
	         if (($('#photo').val() != '')) {
	             alert('Choose either an image or video');
	            $("#txtvideo").val(''); 

	         }
	      
	     }
	     function CheckForVideo() {
	         if (($("#txtvideo").val() != '')) {
	             alert('Choose either an image or video');
	             RemoveFileUploadImage();
	             readURL('');
	         }
	         
	     }
    function ShowDiv(id) {
        $("#" + id).show("slow");
    }
    function HideDiv(id) {
        $("#" + id).hide("slow");
    }
	function ClearPost(){
	
	$("#txtMessage").val('');
	$("#txtActivationDate").val('');
	$("#txtLinkMessage").val('');
	$("#txtvideo").val('');
	$("#txtNewLibCat").val('');
	$("#txtVideoMessage").val('');
	$("#ddlTimeZone").val('0');
	$("#selAMPM").val('0');
	$("#selActivationMinute").val('0');
	$("#selActivationHour").val('0');
	$("#hdnVideoId").val('');
	$("#lblMessage").val('');
	$("#hdnUrl").val('');
	document.getElementById('imgThumbnail').src = '../content/images/no_img.jpg';
	RemoveFileUploadImage();
	var pages = '';
    var hdnPages = '';
		$('input[group^=pages]').each(
				function () {
				if ($(this).attr("checked") == 'checked') {
					var id= $(this).attr('id');
					$("#" + id).removeAttr("checked");
					$("#hdnPageId").val('');
					 selectedpagesName();
				}
				
				}
		);


}
function CreatePage() {
    window.open("https://www.facebook.com/pages/create.php?", "Page", "left=20,top=20,menubar=0,resizable=0,width=1000,height=850");
}


	</script>
<style>
.error {
	border:1px solid #FF0000;
}
</style>
<style type="text/css">
.changeclass {
	background-color:#FF0000;
}
img {
	border: none;
}
ul {
	margin: 0;
	padding: 0;
	list-style: none;
}
li {
	margin: 0;
	padding: 0;
	list-style: none;
}
.show_hide1 {
	margin: 3px 0 0 0;
	text-align: center;
	overflow: hidden;
}
.show_hide2 {
	margin: 3px 0 0 0;
	text-align: center;
	overflow: hidden;
}
.slidingDiv {
	width: 170px;
	position: absolute;
	margin: 30px 0 0 -382px;
	left: 50%;
	display: inline;
}
.slidingDiv1 {
	width: 170px;
	position: absolute;
	margin: 5px 0 0 -207px;
	left: 23%;
	display: inline;
}
.fan_showhide1 {
	width: 200px;
	margin: 3px 0 0 0;
	text-align: left;
	overflow: hidden;
	cursor: pointer;
}
.Fanpagediv {
	width: 500px;
	position: absolute;
	margin: 30px 0 0 -382px;
	left: 60%;
	display: inline;
	border: 1px solid #044d85;
}
.Fanpagediv1 {
	width: 500px;
	position: absolute;
	margin: 5px 0 0 -260px;
	left: 60%;
	display: inline;
	border: 1px solid #044d85;
}
.slidingDiv2 {
	width: 170px;
	position: absolute;
	margin: 5px 0 0 -33px;
	left: 23%;
	display: inline;
}
.pop_up_bx {
	width: 170px;
	overflow: hidden;
}
.pop_up_bx_top {
	width: 170px;
	height: 15px;
	overflow: hidden;
	background: url(../Content/images/pop_up_t_b.png) no-repeat;
}
.pop_up_bx_mid_inn {
	width: 154px;
	padding: 0 8px;
}
.pop_up_bx_mid_inn ul {
	width: 154px;
	padding: 0 0px;
	float: left;
}
.pop_up_bx_mid_inn ul li {
	width: 154px;
	padding: 0 0px;
	float: left;
}
.pop_up_bx_mid_inn ul li a {
	width: 118px;
	text-decoration: none;
	padding: 5px 18px;
	float: left;
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	font-weight: bold;
	color: #000;
}
.pop_up_bx_mid_inn ul li a:hover, .pop_up_bx_mid_inn .act {
	width: 118px;
	padding: 5px 18px;
	float: left;
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	font-weight: bold;
	color: #fff;
	background: #003399;
}
.pop_up_bx_bot {
	width: 170px;
	height: 15px;
	overflow: hidden;
	background: url(../Content/images/pop_up_t_b.png) no-repeat;
	background-position: 0 -15px;
}
.pop_up_bx_mid {
	width: 170px;
	height: 280px;
	background: url(../Content/images/pop_up_mid.png) repeat-y;
}
.pop_up_bx_top_fan_page {
	width: 500px;
	height: 40px;
	overflow: hidden;
	background-image: url(../Content/images/popup_top.png);
	background-repeat: no-repeat;
	background-position: top;
}
.pop_up_bx_mid_fan_page {
	width: 500px;
	background: url(../Content/images/pop_up_mid.png) repeat-y;
}
.pop_up_bx_mid_inn_fan_page {
	width: 474px;
	padding: 08px;
	background-color: #fff;
	border-left: 5px solid #536ba1;
	border-right: 5px solid #536ba1;
}
.pop_up_bx_bot_fan_page {
	width: 500px;
	height: 50px;
	overflow: hidden;
	background-image: url(../Content/images/popup_bottom.png);
	background-repeat: no-repeat;
	background-position: bottom;
}
</style>
<script type="text/javascript">
    $(document).ready(function () {
		$('#tdLibCatTitle1').addClass('tabcheduleact');
        $.fx.speeds._default = 1000;
        $(".Fanpagediv1").hide();
        $(".fan_showhide1").show();
        $('.fan_showhide1').click(function () {
            $(".Fanpagediv1").slideToggle();
        });

        $(".Menudiv1").hide();
        $(".menu_showhide1").show();
        $('.menu_showhide1').click(function () {
            $(".Menudiv1").show("slow"); ;
        });
        $('.menu_close').click(function () {
            $(".Menudiv1").hide("slow");
            $(".Fanpagesdiv1").hide("slow");
            $(".Attachdiv1").hide("slow");
            $(".Calenderdiv1").hide("slow");
        });

        $(".fans_showhide1").show();
        $('.fans_showhide1').click(function () {
            $(".Fanpagesdiv1").show("slow");
            $('#divFanPages').removeClass("divFanPagesAutoPost");
            $('#divFanPages').addClass("divFanPages");
            $(".composediv1").hide("slow");
            $(".photodiv1").hide("slow");
            $(".Linkdiv").hide("slow");
            $('#divLibCat').hide("slow");
            $('#divSchedule').hide("slow");

        });
        $('.fan_close').click(function () {
            $("#divSchedule").slideToggle();

        });
        $('.lib_close').click(function () {
            $("#divLibCat").slideToggle();

        });
        $('.compose_msg').click(function () {
            $(".Fanpagesdiv1").hide("slow");
            $(".composediv1").show("slow");
            $(".photodiv1").hide("slow");
            $(".videodiv").hide("slow");
            $(".Linkdiv").hide("slow");
            $('#divLibCat').hide("slow");
            $('#divSchedule').hide("slow");
        });
        $('.video_div').click(function () {
            $(".Fanpagesdiv1").hide("slow");
            $(".composediv1").hide("slow");
            $(".videodiv").show("slow");
            $(".photodiv1").hide("slow");
            $(".Linkdiv").hide("slow");
            $('#divLibCat').hide("slow");
            $('#divSchedule').hide("slow");
        });

        $('.photo_video').click(function () {
            $(".composediv1").hide("slow");
            $(".photodiv1").show("slow");
            $(".videodiv").hide("slow");
            $(".Fanpagesdiv1").hide("slow");
            $(".Linkdiv").hide("slow");
            $('#divLibCat').hide("slow");
            $('#divSchedule').hide("slow");
        });
        $('.link_video').click(function () {
            $(".composediv1").hide("slow");
            $(".photodiv1").hide("slow");
            $(".videodiv").hide("slow");
            $(".Fanpagesdiv1").hide("slow");
            $(".Linkdiv").show("slow");
            $('#divLibCat').hide("slow");
            $('#divSchedule').hide("slow");
        });
    });
    </script>
</head>
<body onload="CheckMessage();">
<form id="form1" runat="server">
  <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
  <div id="innerpagepagemain">
    <uc1:inner1 ID="inner1" runat="server" />
    <div id="centermain">
    <div id="DivSaveSidebar" style="width:100%; height:1450px; text-align:center; background-image:url(../Content/facebookalert/images/popup_bg.png); position:absolute; z-index:999999999; text-align:center; padding-left:150px;  display:none;">
			  <div id="popup_container1" style="width:450px;">
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                   <span id="spnMessage"></span><br/><br/>
                   <input type="button" class="inputbutton" onclick="HideSaveAlert();" value="Close" style="cursor:pointer;" id="popup_close1" />
				</div>
			 </div>
	</div>
    <div id="DivSaveScheduler" style="width:100%; height:1450px; text-align:center; background-image:url(../Content/facebookalert/images/popup_bg.png); position:absolute; z-index:999999999; text-align:center; padding-left:150px;  display:none;">
			  <div id="popup_container1" style="width:450px;">
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                   <span id="spnSchduleMessage"></span><br/><br/>
                   <a href="../scheduler-main" id="lnkSchduler" class="bluetablink">Close</a>
				</div>
			 </div>
	</div>
    <div id="DivShowAutoPostOnOff" style="width:100%; height:100%; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:999999999; text-align:center; padding-left:150px;  display:none;">
                          <div id="popup_AutoPostContainer" >
                            <div id="popup_AutoPostContent" style="padding-top:10px; padding-left:20px; text-align:left; line-height:17px;"> <span id="spnShuffleMess"></span><br/><br/>
                              <input type="button" class="inputbutton" onclick="HideAutoPostOnOff();" style="cursor:pointer;" value="Close" id="popup_close" />
                            </div>
                          </div>
                        </div>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="170" align="left" valign="top" class="leftbg" style="width:172px;"><uc3:left ID="left1" runat="server"/></td>
          <td align="left" valign="top" class="contentbody" style="padding-left:10px; padding-right:10px;"><div style="padding-bottom:10px;">
              <center>
                <asp:Label ID="lblMessage" ForeColor="#FF0000" Font-Bold="false" Font-Size="12" runat="server"></asp:Label>
              </center>
              <h6> Schedule Post</h6>
              
            </div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td colspan="2" valign="middle"><div style="float:left;"><span class="compose_msg" id="StatusMessage"> <img src="../Content/images/compose_message.gif" width="16" height="15" align="absmiddle" />&nbsp;<strong> <a href="javascript:;" class="graylink" onclick="CheckMessage();">Compose Message</a></strong></span> &nbsp;&nbsp;&nbsp;<font color="#7d869d">|</font> &nbsp;&nbsp;&nbsp;<span class="photo_video"><img src="../Content/images/add_photo_video.gif" width="16" height="14" align="absmiddle" /> &nbsp;<strong><a href="javascript:;" class="graylink" onclick="CheckVideoMessage();">Add Photo &nbsp;</a> </strong></span><span class="video_div" style="display:none"><img src="../Content/images/add_photo_video.gif" width="16" height="14" align="absmiddle" /> &nbsp;<strong><a href="javascript:;" class="graylink" onclick="CheckPhotoMessage();">Add Video &nbsp;</a> </strong></span><font color="#7d869d">|</font>&nbsp;&nbsp;&nbsp;<span class="link_video"><img src="../Content/images/video_icon1.gif" align="absmiddle" />&nbsp; <strong><a href="javascript:;" class="graylink" onclick="CheckLinkMessage();">Add Link&nbsp;</a></strong></span>&nbsp;&nbsp;<font color="#7d869d">|</font>&nbsp;&nbsp;&nbsp; <span class="fans_showhide1"><img src="../Content/images/selectfanpage_icon1.gif" align="absmiddle" />&nbsp;&nbsp;<strong><a href="javascript:;" class="graylink">Select Business Pages</a></strong></span></div><div align="right" style="padding-bottom:5px;"><a href="javascript:;" class="bluetablink" onclick="ClearPost();" >Clear Post</a></div></td>
              </tr>
              <tr>
                <td colspan="2" align="left"><input type="hidden" id="hdnselectedPages" runat="server" name="hdnselectedPages"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesName" runat="server" name="hdnSelectedPagesName"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesImage" runat="server" name="hdnSelectedPagesImage"
                                                                    value="" />
                  <input type="hidden" id="hdnselectedPagesAccessToken" runat="server" name="hdnselectedPagesAccessToken"
                                                                    value="" /></td>
              </tr>
              <tr>
                <td height="15" align="right" valign="top"></td>
                <td align="left" ><div class="composediv1" style="z-index: 1000;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top" class="popupbordertop" style="padding-left:40px;"><img src="../Content/images/popup_border_top.gif" width="15" height="6" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" class="popupborder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td align="left" valign="top" style="padding:5px; font-family:arial;"><textarea style="width: 785px; border:0px" id="txtMessage" runat="server" cols="80" rows="5" name="txtMessage" class="menu_showhide12" ></textarea></td>
                            </tr>
                          </table></td>
                      </tr>
                    </table>
                  </div>
                  <div class="photodiv1" style="display:none; z-index: 1000;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top" class="popupbordertop" style="padding-left:170px;"><img src="../Content/images/popup_border_top.gif" width="15" height="6" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" class="popupborder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td align="left" valign="top" style="padding:7px; font-family:arial;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td align="left" colspan="2" height="50" style="border:1px solid #999999"><textarea style="width: 785px; border:0px" id="txtVideoMessage" runat="server" cols="80" rows="5"
                                                                    name="txtVideoMessage" class="menu_showhide12"></textarea>
                                    </td>
                                  </tr>
                                  <tr>
                                    <td align="left" style="padding-top:10px;"><strong>Select an image file on your computer.</strong><br />
                                      <input name="source" type="file" id="photo" width="200" onchange="readURL(this);" runat="server"/>&nbsp;&nbsp;<a href="javascript:;" id="lnkFileRemove" style="display:none; padding-left:5px;" onclick="RemoveFileUploadImage();">Remove</a>
                                      <div style="padding-left:10px;"><img id="imgLoading" src='<%=ResolveUrl("~/Content/images/uploading.gif")%>' style="display:none" /></div></td>
                                      <td align="left" valign="middle">
                                      <img width="66" height="66" id="imgPhoto" src="Content/images/no_img.jpg" runat="server"/>
                                      <asp:Label ID="lblVideoText" runat="server"></asp:Label>
                                      <input type="hidden" id="hdnImage1" runat="server" />
                                      <input type="hidden" id="hdnImageChange" runat="server" />
                                    </td>
                                  </tr>
                                </table></td>
                            </tr>
                          </table></td>
                      </tr>
                    </table>
                  </div>
                  <div class="videodiv" style="display:none; z-index: 1000;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top" class="popupbordertop" style="padding-left:330px;"><img src="../Content/images/popup_border_top.gif" width="15" height="6" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" class="popupborder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td align="left" valign="top" style="padding:7px; font-family:arial;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td align="left" colspan="2" height="50" style="border:1px solid #999999"><textarea style="width: 785px; border:0px" id="txtPhotoMessage" runat="server" cols="80" rows="5"
                                                                    name="txtPhotoMessage" class="menu_showhide12"></textarea>
                                    </td>
                                  </tr>
                                  <tr>
                                    <td align="left" style="padding-top:10px;"><strong>Add a youtube video url.</strong><br />
                                      <input type="text" id="txtVideoLink" name="txtVideoLink" runat="server" style="width:490px;" onchange="validateURL();" />
                                    </td>
                                    <td align="left" valign="middle">&nbsp;</td>
                                  </tr>
                                </table></td>
                            </tr>
                            <tr>
                              <td align="left" valign="middle" style="display:none">&nbsp;</td>
                            </tr>
                          </table></td>
                      </tr>
                    </table>
                  </div>
                  <div class="Linkdiv" style="display:none; z-index: 1000;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top" class="popupbordertop" style="padding-left:330px;"><img src="../Content/images/popup_border_top.gif" width="15" height="6" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" class="popupborder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td align="left" valign="top" style="padding:7px; font-family:arial;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td align="left" colspan="2" height="50" style="border:1px solid #999999"><textarea style="width: 785px; border:0px" id="txtLinkMessage" runat="server" cols="80" rows="5"
                                                                    name="txtLinkMessage" class="menu_showhide12"></textarea>
                                    </td>
                                  </tr>
                                  <tr>
                                    <td align="left" style="padding-top:10px;"><input type="text" id="txtvideo" runat="server" width="720" style="width:720px; " onchange="CheckVideo();" onkeydown="return FocusOnEnter(event)" />
                                      &nbsp;&nbsp;
                                      <%--<a href="javascript:;" onmouseover="ShowDiv('dvHelp');" onmouseout="HideDiv('dvHelp');"><b>help?</b></a><div style="position:absolute; width:427px; padding-left:200px; display:none;" id="dvHelp">
														 <img src='<%=System.Configuration.ConfigurationManager.AppSettings("AppPath")%>content/images/youtubevideo.png' />
														 </div>
                                      <br/>--%>
                                      <br/>
                                      (e.g: www.youtube.com/watch?v=yoGYjtCo350)<br />
                                      <img src="Content/images/no_img.jpg" runat="server" id="imgThumbnail" width="100" style="border:2px dotted #ff0000;" height="100" />
                                      <input type="hidden" id="hdnUrl" runat="server" value="" />
                                      <input type="hidden" id="hdnVideoId" runat="server" value="" />
                                    </td>
                                    <td style="display:none"></td>
                                  </tr>
                                </table></td>
                            </tr>
                          </table></td>
                      </tr>
                    </table>
                  </div>
                  <div class="Fanpagesdiv1" style="z-index: 1000; display:none">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top" class="popupbordertop" style="padding-left:490px;"><img src="../Content/images/popup_border_top.gif" width="15" height="6" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" class="popupborder" style="border-bottom:0px;"><div style="height:150px; overflow:auto; overflow-x:hidden;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top" style="padding:20px;">
                                <asp:PlaceHolder ID="plcData" runat="server">
                                <asp:DataList ID="dstFanPages" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                  <asp:PlaceHolder ID="plcFanPages" runat="server">
                                      <table id="NonFanPage" runat="server" width="230" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                          <td colspan="2" height="4"></td>
                                        </tr>
                                        <tr>
                                          <td width="48" align="left" valign="middle" style="background-color:#f6f6f6; " ><table border="0" cellspacing="0" cellpadding="0">
                                              <tr>
                                                <td align="center" valign="middle"><img src='<%#Eval("picture")%>' width="40" style=" border: 7px solid #f6f6f6" height="40" align="absmiddle" group="pageimg" pageid='<%#Eval("Id")%>' /> </td>
                                                <td align="center" valign="middle"><table border="0" width="170" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                      <td width="25" align="left" valign="middle" ><input class="checkboxpadding" type="checkbox" id="chkPage" name="chkPage" runat="server" pageid='<%#Eval("Id")%>' group="pages" onclick='PageidScheduler(this);selectedpagesName();'  pageaccess_token='<%#Eval("access_token")%>' pagevalue='<%#Eval("name")%>' pageimage='<%#Eval("picture")%>' /></td>
                                                      <td align="left" width="150" valign="middle"><%#Eval("name")%>
                                                        <input type="hidden" id="hdnPageId" runat="server" value='<%#Eval("Id")%>' />
                                                        <input type="hidden" id="hdnPageName" runat="server" value='<%#Eval("name")%>' />
                                                        <input type="hidden" id="hdnAccessToken" runat="server" value='<%#Eval("access_token")%>' />
                                                        <input type="hidden" id="hdnImage" runat="server" value='<%#Eval("picture")%>' />
                                                        
                                                      </td>
                                                    </tr>
                                                  </table></td>
                                              </tr>
                                            </table></td>
                                          <td width="4" align="left"></td>
                                        </tr>
                                      </table>
                                      </asp:PlaceHolder>
                                    </ItemTemplate>
                                  </asp:DataList>
                                  </asp:PlaceHolder>
                                   <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                                           <strong style="color:#990066">  You have no business pages.</strong><br /><br /> <a href="javascript:CreatePage();">Click here</a> to create business page. 
                                   </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="plcError" runat="server" Visible="false">
                                           <strong style="color:#990066">Facebook is experiencing problems. Please try again later</strong><br /><br />
                                   </asp:PlaceHolder>
                                </td>
                              </tr>
                            </table>
                          </div></td>
                      </tr>
                    </table>
                  </div></td>
              </tr>
              <tr>
                <td align="right"></td>
                <td align="left" valign="middle" class="popupinnerbg" style="border:1px solid #b4bbcd;  border-top:0px; "><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="30%" height="31" align="left" valign="middle"></td>
                      <td width="70%" align="right" valign="middle" style="padding-right:5px;"><a href="javascript:;" class="bluetablink" runat="server" onclick="return ValidateDrafts();" id="lnkSaveDraft">Save as Draft</a>&nbsp;&nbsp;<a href="javascript:;" class="bluetablink" onClick="SelectLibCat();" id="lnkSaveToMyLib">Save in My Library</a>&nbsp;&nbsp;<a href="javascript:;" runat="server" class="bluetablink" onclick="return ValidateQuickPost();" id="lnkPost">Quick Post</a>&nbsp;&nbsp;<a href="javascript:;" class="bluetablink" onClick="SelectScheduleDiv();" id="lnkScheduleDiv">Schedule Post</a></td>
                      <td align="left" valign="top" style="border:1px solid #eaeaea;"><div id="divLibCat" style="display:none; z-index:100; position:absolute; border:1px solid #eaeaea; background-color:#FFFFFF; padding:10px; width:160px;">
                          <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td align="right" valign="top"><a href="javascript:;" class="lib_close"><img src='<%=ResolveUrl("Content/images/delete_icon.png")%>' hspace="7" vspace="7" border="0"/></a></td>
                            </tr>
                            <tr>
                              <td align="left" valign="top" style="padding-left:10px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tbody>
                                    <asp:Repeater id="rptLibUserCatList" runat="server">
                                      <itemtemplate>
                                        <tr>
                                          <td height="30"><asp:LinkButton OnCommand="SaveToMyLibrary"  CommandArgument='<%#Eval("Id")%>' onclientclick = "return ValidateLib()" id="lnkLibCatSel" runat="server"><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></asp:LinkButton></td>
                                        </tr>
                                      </itemtemplate>
                                    </asp:Repeater>
                                    <tr id="trNew">
                                      <td height="30" style="cursor:pointer;" onClick="CreateNewLibCat();">Create New</td>
                                    </tr>
                                    <tr id="trCreateNew" style="display:none">
                                      <td align="left"><input type="text" id="txtNewLibCat" runat="server" width="150" style="width:130px;" />
                                        &nbsp;
                                        <asp:LinkButton onclientclick = "return ValidateNewLibCat()" id="lnkCreateNewCat" runat="server" OnCommand="SaveToMyLibrary" CommandArgument="-1" >Create</asp:LinkButton>
                                      </td>
                                    </tr>
                                  </tbody>
                                </table></td>
                            </tr>
                          </table>
                        </div>
                        <div id="divSchedule" width="350" align="left" valign="top"  style="display:none; z-index:100; position:absolute; border:1px solid #eaeaea; padding:10px; background-color:#FFFFFF; width:350px;">
                          <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td align="right" valign="top"><a href="javascript:;" class="fan_close"><img src='<%=ResolveUrl("Content/images/delete_icon.png")%>' width="12" height="12" hspace="7" vspace="7" border="0"/></a></td>
                            </tr>
                            <tr>
                              <td align="left" valign="top" style="padding-left:10px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                          <td width="170"><input type="text" class="input" id="txtActivationDate" name="txtActivationDate"
                                                                                    runat="server" size="30" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:20px; padding:2px; width:160px;"
                                                                                    maxlength="25">
                                          </td>
                                          <td>&nbsp; <img src="<%=ResolveUrl("~/content/images/calender_icon.png")%>" onClick="OpenCal('txtActivationDate');" width="22" height="23" align="absmiddle" style="cursor: pointer;"/>&nbsp;&nbsp;&nbsp;(mm/dd/yyyy)&nbsp;<font color="#FF0000">*</font></td>
                                        </tr>
                                      </table></td>
                                  </tr>
                                  <tr>
                                    <td align="left" valign="top">&nbsp;</td>
                                  </tr>
                                  <tr>
                                    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                          <td align="left" valign="top"><label>
                                            <select id="selActivationHour" name="selActivationHour" runat="server" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:85px;">
                                              <option value="0">Hour</option>
                                              <option value="1">1</option>
                                              <option value="2">2</option>
                                              <option value="3">3</option>
                                              <option value="4">4</option>
                                              <option value="5">5</option>
                                              <option value="6">6</option>
                                              <option value="7">7</option>
                                              <option value="8">8</option>
                                              <option value="9">9</option>
                                              <option value="10">10</option>
                                              <option value="11">11</option>
                                              <option value="12">12</option>
                                            </select>
                                            &nbsp;<font color="#FF0000">*</font> </label></td>
                                          <td align="left" valign="top"><select id="selActivationMinute" name="selActivationMinute" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:85px;" runat="server">
                                              <option value="Minute">Minute</option>
                                              <option value="00">00</option>
                                              <option value="15">15</option>
                                              <option value="30">30</option>
                                              <option value="45">45</option>
                                            </select>
                                            &nbsp;<font color="#FF0000">*</font> </td>
                                          <td align="left" valign="top"><select id="selAMPM" name="selAMPM" runat="server" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:85px;">
                                              <option value="0">AM/PM</option>
                                              <option value="AM">AM</option>
                                              <option value="PM">PM</option>
                                            </select>
                                            &nbsp;<font color="#FF0000">*</font> </td>
                                        </tr>
                                      </table></td>
                                  </tr>
                                  <tr>
                                    <td align="left" valign="top">&nbsp;</td>
                                  </tr>
                                  <tr>
                                    <td align="left" valign="top"><asp:DropDownList  ID="ddlTimeZone" runat="server" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:291px;">
                                        <asp:ListItem Value="0"> Select a TimeZone </asp:ListItem>
                                        <asp:ListItem Value="Eastern Standard Time">Eastern Timezone (UTC -5.00)</asp:ListItem>
                                        <asp:ListItem Value="Central Standard Time">Central Timezone (UTC -6.00)</asp:ListItem>
                                        <asp:ListItem Value="Mountain Standard Time">Mountain Timezone (UTC -7.00)</asp:ListItem>
                                        <asp:ListItem Value="Pacific Standard Time">Pacific Timezone (UTC -8.00)</asp:ListItem>
                                        <asp:ListItem value="Dateline Standard Time">(UTC-12:00) International Date Line West</asp:ListItem>
                                        <asp:ListItem value="Samoa Standard Time">(UTC-11:00) Midway Island, Samoa</asp:ListItem>
                                        <asp:ListItem value="Hawaiian Standard Time">(UTC-10:00) Hawaii</asp:ListItem>
                                        <asp:ListItem value="Alaskan Standard Time">(UTC-09:00) Alaska</asp:ListItem>
                                        <asp:ListItem value="Pacific Standard Time (Mexico)">(UTC-08:00) Tijuana, Baja California</asp:ListItem>
                                        <asp:ListItem value="US Mountain Standard Time">(UTC-07:00) Arizona</asp:ListItem>
                                        <asp:ListItem value="Mountain Standard Time (Mexico)">(UTC-07:00) Chihuahua, La Paz, Mazatlan</asp:ListItem>
                                        <asp:ListItem value="Central America Standard Time">(UTC-06:00) Central America</asp:ListItem>
                                        <asp:ListItem value="Central Standard Time (Mexico)">(UTC-06:00) Guadalajara, Mexico City, Monterrey</asp:ListItem>
                                        <asp:ListItem value="Canada Central Standard Time">(UTC-06:00) Saskatchewan</asp:ListItem>
                                        <asp:ListItem value="SA Pacific Standard Time">(UTC-05:00) Bogota, Lima, Quito</asp:ListItem>
                                        <asp:ListItem value="US Eastern Standard Time">(UTC-05:00) Indiana (East)</asp:ListItem>
                                        <asp:ListItem value="Venezuela Standard Time">(UTC-04:30) Caracas</asp:ListItem>
                                        <asp:ListItem value="Paraguay Standard Time">(UTC-04:00) Asuncion</asp:ListItem>
                                        <asp:ListItem value="Atlantic Standard Time">(UTC-04:00) Atlantic Time (Canada)</asp:ListItem>
                                        <asp:ListItem value="SA Western Standard Time">(UTC-04:00) Georgetown, La Paz, San Juan</asp:ListItem>
                                        <asp:ListItem value="Central Brazilian Standard Time">(UTC-04:00) Manaus</asp:ListItem>
                                        <asp:ListItem value="Pacific SA Standard Time">(UTC-04:00) Santiago</asp:ListItem>
                                        <asp:ListItem value="Newfoundland Standard Time">(UTC-03:30) Newfoundland</asp:ListItem>
                                        <asp:ListItem value="E. South America Standard Time">(UTC-03:00) Brasilia</asp:ListItem>
                                        <asp:ListItem value="Argentina Standard Time">(UTC-03:00) Buenos Aires</asp:ListItem>
                                        <asp:ListItem value="SA Eastern Standard Time">(UTC-03:00) Cayenne</asp:ListItem>
                                        <asp:ListItem value="Greenland Standard Time">(UTC-03:00) Greenland</asp:ListItem>
                                        <asp:ListItem value="Montevideo Standard Time">(UTC-03:00) Montevideo</asp:ListItem>
                                        <asp:ListItem value="Mid-Atlantic Standard Time">(UTC-02:00) Mid-Atlantic</asp:ListItem>
                                        <asp:ListItem value="Azores Standard Time">(UTC-01:00) Azores</asp:ListItem>
                                        <asp:ListItem value="Cape Verde Standard Time">(UTC-01:00) Cape Verde Is.</asp:ListItem>
                                        <asp:ListItem value="Morocco Standard Time">(UTC) Casablanca</asp:ListItem>
                                        <asp:ListItem value="UTC">(UTC) Coordinated Universal Time</asp:ListItem>
                                        <asp:ListItem value="GMT Standard Time">(UTC) Dublin, Edinburgh, Lisbon, London</asp:ListItem>
                                        <asp:ListItem value="Greenwich Standard Time">(UTC) Monrovia, Reykjavik</asp:ListItem>
                                        <asp:ListItem value="W. Europe Standard Time">(UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna</asp:ListItem>
                                        <asp:ListItem value="Central Europe Standard Time">(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague</asp:ListItem>
                                        <asp:ListItem value="Romance Standard Time">(UTC+01:00) Brussels, Copenhagen, Madrid, Paris</asp:ListItem>
                                        <asp:ListItem value="Central European Standard Time">(UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb</asp:ListItem>
                                        <asp:ListItem value="W. Central Africa Standard Time">(UTC+01:00) West Central Africa</asp:ListItem>
                                        <asp:ListItem value="Jordan Standard Time">(UTC+02:00) Amman</asp:ListItem>
                                        <asp:ListItem value="GTB Standard Time">(UTC+02:00) Athens, Bucharest, Istanbul</asp:ListItem>
                                        <asp:ListItem value="Middle East Standard Time">(UTC+02:00) Beirut</asp:ListItem>
                                        <asp:ListItem value="Egypt Standard Time">(UTC+02:00) Cairo</asp:ListItem>
                                        <asp:ListItem value="South Africa Standard Time">(UTC+02:00) Harare, Pretoria</asp:ListItem>
                                        <asp:ListItem value="FLE Standard Time">(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius</asp:ListItem>
                                        <asp:ListItem value="Israel Standard Time">(UTC+02:00) Jerusalem</asp:ListItem>
                                        <asp:ListItem value="E. Europe Standard Time">(UTC+02:00) Minsk</asp:ListItem>
                                        <asp:ListItem value="Namibia Standard Time">(UTC+02:00) Windhoek</asp:ListItem>
                                        <asp:ListItem value="Arabic Standard Time">(UTC+03:00) Baghdad</asp:ListItem>
                                        <asp:ListItem value="Arab Standard Time">(UTC+03:00) Kuwait, Riyadh</asp:ListItem>
                                        <asp:ListItem value="Russian Standard Time">(UTC+03:00) Moscow, St. Petersburg, Volgograd</asp:ListItem>
                                        <asp:ListItem value="E. Africa Standard Time">(UTC+03:00) Nairobi</asp:ListItem>
                                        <asp:ListItem value="Georgian Standard Time">(UTC+03:00) Tbilisi</asp:ListItem>
                                        <asp:ListItem value="Iran Standard Time">(UTC+03:30) Tehran</asp:ListItem>
                                        <asp:ListItem value="Arabian Standard Time">(UTC+04:00) Abu Dhabi, Muscat</asp:ListItem>
                                        <asp:ListItem value="Azerbaijan Standard Time">(UTC+04:00) Baku</asp:ListItem>
                                        <asp:ListItem value="Mauritius Standard Time">(UTC+04:00) Port Louis</asp:ListItem>
                                        <asp:ListItem value="Caucasus Standard Time">(UTC+04:00) Yerevan</asp:ListItem>
                                        <asp:ListItem value="Afghanistan Standard Time">(UTC+04:30) Kabul</asp:ListItem>
                                        <asp:ListItem value="Ekaterinburg Standard Time">(UTC+05:00) Ekaterinburg</asp:ListItem>
                                        <asp:ListItem value="Pakistan Standard Time">(UTC+05:00) Islamabad, Karachi</asp:ListItem>
                                        <asp:ListItem value="West Asia Standard Time">(UTC+05:00) Tashkent</asp:ListItem>
                                        <asp:ListItem value="India Standard Time">(UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi</asp:ListItem>
                                        <asp:ListItem value="Sri Lanka Standard Time">(UTC+05:30) Sri Jayawardenepura</asp:ListItem>
                                        <asp:ListItem value="Nepal Standard Time">(UTC+05:45) Kathmandu</asp:ListItem>
                                        <asp:ListItem value="N. Central Asia Standard Time">(UTC+06:00) Almaty, Novosibirsk</asp:ListItem>
                                        <asp:ListItem value="Central Asia Standard Time">(UTC+06:00) Astana, Dhaka</asp:ListItem>
                                        <asp:ListItem value="Myanmar Standard Time">(UTC+06:30) Yangon (Rangoon)</asp:ListItem>
                                        <asp:ListItem value="SE Asia Standard Time">(UTC+07:00) Bangkok, Hanoi, Jakarta</asp:ListItem>
                                        <asp:ListItem value="North Asia Standard Time">(UTC+07:00) Krasnoyarsk</asp:ListItem>
                                        <asp:ListItem value="China Standard Time">(UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi</asp:ListItem>
                                        <asp:ListItem value="North Asia East Standard Time">(UTC+08:00) Irkutsk, Ulaan Bataar</asp:ListItem>
                                        <asp:ListItem value="Singapore Standard Time">(UTC+08:00) Kuala Lumpur, Singapore</asp:ListItem>
                                        <asp:ListItem value="W. Australia Standard Time">(UTC+08:00) Perth</asp:ListItem>
                                        <asp:ListItem value="Taipei Standard Time">(UTC+08:00) Taipei</asp:ListItem>
                                        <asp:ListItem value="Tokyo Standard Time">(UTC+09:00) Osaka, Sapporo, Tokyo</asp:ListItem>
                                        <asp:ListItem value="Korea Standard Time">(UTC+09:00) Seoul</asp:ListItem>
                                        <asp:ListItem value="Yakutsk Standard Time">(UTC+09:00) Yakutsk</asp:ListItem>
                                        <asp:ListItem value="Cen. Australia Standard Time">(UTC+09:30) Adelaide</asp:ListItem>
                                        <asp:ListItem value="AUS Central Standard Time">(UTC+09:30) Darwin</asp:ListItem>
                                        <asp:ListItem value="E. Australia Standard Time">(UTC+10:00) Brisbane</asp:ListItem>
                                        <asp:ListItem value="AUS Eastern Standard Time">(UTC+10:00) Canberra, Melbourne, Sydney</asp:ListItem>
                                        <asp:ListItem value="West Pacific Standard Time">(UTC+10:00) Guam, Port Moresby</asp:ListItem>
                                        <asp:ListItem value="Tasmania Standard Time">(UTC+10:00) Hobart</asp:ListItem>
                                        <asp:ListItem value="Vladivostok Standard Time">(UTC+10:00) Vladivostok</asp:ListItem>
                                        <asp:ListItem value="Central Pacific Standard Time">(UTC+11:00) Magadan, Solomon Is., New Caledonia</asp:ListItem>
                                        <asp:ListItem value="New Zealand Standard Time">(UTC+12:00) Auckland, Wellington</asp:ListItem>
                                        <asp:ListItem value="Fiji Standard Time">(UTC+12:00) Fiji, Marshall Is.</asp:ListItem>
                                        <asp:ListItem value="Kamchatka Standard Time">(UTC+12:00) Petropavlovsk-Kamchatsky</asp:ListItem>
                                        <asp:ListItem value="Tonga Standard Time">(UTC+13:00) Nuku&#39;alofa</asp:ListItem>
                                      </asp:DropDownList>
                                      &nbsp;<font color="#FF0000">*</font> </td>
                                  </tr>
                                  <tr>
                                    <td align="left" valign="top">&nbsp;</td>
                                  </tr>
                                  <tr>
                                    <td align="left" valign="top"><a href="javascript:;" class="bluetablink" runat="server" onclick="return ValidatePostNLeapData();" id="lnkScheduledPost">Add Schedule</a> &nbsp;&nbsp; <a href="javascript:;" class="bluetablink" onclick="ClearSchedule();" id="lnkCancel">Reset</a>
                                      <input type="hidden" runat="server" id="hdnMakeDateString" />
                                      <asp:Label ID="lblTimeZone" runat="server" Visible="false"></asp:Label>
                                      <input type="hidden" runat="server" id="hdnTimeZone" /></td>
                                  </tr>
                                </table></td>
                            </tr>
                          </table>
                        </div></td>
                    </tr>
                  </table></td>
              </tr>
              <tr>
                <td height="25" align="right"></td>
                <td height="30" align="left" valign="middle" style="padding-top:10px; padding-bottom:10px;"><div id="divHtml" style="width:300px; display:none; height:auto; border:1px solid #eaeaea; background-color:#f6f6f6; padding:15px; line-height:22px;"> </div></td>
              </tr>
              <tr>
                <td align="left"></td>
              </tr>
              <tr>
                <td height="20"></td>
                <td height="32" align="left" valign="bottom" ><div id="TabbedPanels1" class="TabbedPanels">
                    <ul class="TabbedPanelsTabGroup" style="padding-left:27px;">
                      <li class="TabbedPanelsTab" tabindex="0">Autopost &nbsp;
                        <asp:Literal ID="ltrAutoPostTotal" runat="server"></asp:Literal> &nbsp;
                        <asp:PlaceHolder ID="pnlOff" runat="server" > <img src='<%=ResolveUrl("Content/images/Off_bullate.png") %>' width="10" height="10" hspace="3" border="0" />Off </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pnlOn" runat="server" Visible="false"> <img src='<%=ResolveUrl("Content/images/On_bullate.png") %>' width="10" height="10" hspace="3" border="0" />On </asp:PlaceHolder>
                       <%-- &nbsp;<img id="imgOnOff" runat="server"/>&nbsp;
                        <asp:Literal ID="ltrOnOffText" runat="server"></asp:Literal>--%>
                        <input type="hidden" id="hdnAutoPostOnOff" runat="server" value="0"/>
                      </li>
                      <li class="TabbedPanelsTab" tabindex="1">ForRent.com
                        <asp:Literal ID="ltrLibraryTotal" runat="server"></asp:Literal>
                      </li>
                      <li class="TabbedPanelsTab" tabindex="0">My Library
                        <asp:Literal ID="ltrLibraryTotal1" runat="server"></asp:Literal>
                      </li>
                      <li class="TabbedPanelsTab" tabindex="0">Scheduled Posts
                        <asp:Literal ID="ltrSchedluledTotal" runat="server"></asp:Literal>
                      </li>
                      <li class="TabbedPanelsTab" tabindex="0">Sent Posts
                        <asp:Literal ID="ltrSentTotal" runat="server"></asp:Literal>
                      </li>
                      <li class="TabbedPanelsTab" tabindex="0">Drafts
                        <asp:Literal ID="ltrDraftTotal" runat="server"></asp:Literal>
                      </li>
                    </ul>
                    <div class="TabbedPanelsContentGroup">
                      <div class="TabbedPanelsContent">
                        
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding-top:10px;">
                        <tr>
                        <td>&nbsp;</td>
                        </tr>
                          <tr>
                            <td align="left" valign="top" bgcolor="#f0f0f0" style="padding:15px;"><div align="center" style="text-align:center">
                                <asp:Literal ID="ltrAutoPostError" runat="server"></asp:Literal>
                              </div>
                              <div style="padding-bottom:7px;"><strong>Set Date/Time</strong></div>
                              <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="100" align="left" valign="top"><select id="selAutoPostActivationHour" name="selAutoPostActivationHour" runat="server" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:85px;">
                                      <option value="0">Hour</option>
                                      <option value="1">1</option>
                                      <option value="2">2</option>
                                      <option value="3">3</option>
                                      <option value="4">4</option>
                                      <option value="5">5</option>
                                      <option value="6">6</option>
                                      <option value="7">7</option>
                                      <option value="8">8</option>
                                      <option value="9">9</option>
                                      <option value="10">10</option>
                                      <option value="11">11</option>
                                      <option value="12">12</option>
                                    </select>
                                  </td>
                                  <td width="100" align="left" valign="top"><select id="selAutoPostActivationMinute" name="selAutoPostActivationMinute" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:85px;" runat="server">
                                      <option value="Minute">Minute</option>
                                      <option value="0">00</option>
                                      <option value="15">15</option>
                                      <option value="30">30</option>
                                      <option value="45">45</option>
                                  </select></td>
                                  <td width="100" align="left" valign="top"><select id="selAutoPostAMPM" name="selAutoPostAMPM" runat="server" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:85px;">
                                      <option value="0">AM/PM</option>
                                      <option value="AM">AM</option>
                                      <option value="PM">PM</option>
                                    </select></td>
                                  <td  align="left" valign="top"><asp:DropDownList  ID="ddlAutoPostTimeZone" runat="server" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:255px;">
                                      <asp:ListItem Value="0"> Select a TimeZone </asp:ListItem>
                                      <asp:ListItem Value="Eastern Standard Time">Eastern Timezone (UTC -5.00)</asp:ListItem>
                                      <asp:ListItem Value="Central Standard Time">Central Timezone (UTC -6.00)</asp:ListItem>
                                      <asp:ListItem Value="Mountain Standard Time">Mountain Timezone (UTC -7.00)</asp:ListItem>
                                      <asp:ListItem Value="Pacific Standard Time">Pacific Timezone (UTC -8.00)</asp:ListItem>
                                      <asp:ListItem value="Dateline Standard Time">(UTC-12:00) International Date Line West</asp:ListItem>
                                      <asp:ListItem value="Samoa Standard Time">(UTC-11:00) Midway Island, Samoa</asp:ListItem>
                                      <asp:ListItem value="Hawaiian Standard Time">(UTC-10:00) Hawaii</asp:ListItem>
                                      <asp:ListItem value="Alaskan Standard Time">(UTC-09:00) Alaska</asp:ListItem>
                                      <asp:ListItem value="Pacific Standard Time (Mexico)">(UTC-08:00) Tijuana, Baja California</asp:ListItem>
                                      <asp:ListItem value="US Mountain Standard Time">(UTC-07:00) Arizona</asp:ListItem>
                                      <asp:ListItem value="Mountain Standard Time (Mexico)">(UTC-07:00) Chihuahua, La Paz, Mazatlan</asp:ListItem>
                                      <asp:ListItem value="Central America Standard Time">(UTC-06:00) Central America</asp:ListItem>
                                      <asp:ListItem value="Central Standard Time (Mexico)">(UTC-06:00) Guadalajara, Mexico City, Monterrey</asp:ListItem>
                                      <asp:ListItem value="Canada Central Standard Time">(UTC-06:00) Saskatchewan</asp:ListItem>
                                      <asp:ListItem value="SA Pacific Standard Time">(UTC-05:00) Bogota, Lima, Quito</asp:ListItem>
                                      <asp:ListItem value="US Eastern Standard Time">(UTC-05:00) Indiana (East)</asp:ListItem>
                                      <asp:ListItem value="Venezuela Standard Time">(UTC-04:30) Caracas</asp:ListItem>
                                      <asp:ListItem value="Paraguay Standard Time">(UTC-04:00) Asuncion</asp:ListItem>
                                      <asp:ListItem value="Atlantic Standard Time">(UTC-04:00) Atlantic Time (Canada)</asp:ListItem>
                                      <asp:ListItem value="SA Western Standard Time">(UTC-04:00) Georgetown, La Paz, San Juan</asp:ListItem>
                                      <asp:ListItem value="Central Brazilian Standard Time">(UTC-04:00) Manaus</asp:ListItem>
                                      <asp:ListItem value="Pacific SA Standard Time">(UTC-04:00) Santiago</asp:ListItem>
                                      <asp:ListItem value="Newfoundland Standard Time">(UTC-03:30) Newfoundland</asp:ListItem>
                                      <asp:ListItem value="E. South America Standard Time">(UTC-03:00) Brasilia</asp:ListItem>
                                      <asp:ListItem value="Argentina Standard Time">(UTC-03:00) Buenos Aires</asp:ListItem>
                                      <asp:ListItem value="SA Eastern Standard Time">(UTC-03:00) Cayenne</asp:ListItem>
                                      <asp:ListItem value="Greenland Standard Time">(UTC-03:00) Greenland</asp:ListItem>
                                      <asp:ListItem value="Montevideo Standard Time">(UTC-03:00) Montevideo</asp:ListItem>
                                      <asp:ListItem value="Mid-Atlantic Standard Time">(UTC-02:00) Mid-Atlantic</asp:ListItem>
                                      <asp:ListItem value="Azores Standard Time">(UTC-01:00) Azores</asp:ListItem>
                                      <asp:ListItem value="Cape Verde Standard Time">(UTC-01:00) Cape Verde Is.</asp:ListItem>
                                      <asp:ListItem value="Morocco Standard Time">(UTC) Casablanca</asp:ListItem>
                                      <asp:ListItem value="UTC">(UTC) Coordinated Universal Time</asp:ListItem>
                                      <asp:ListItem value="GMT Standard Time">(UTC) Dublin, Edinburgh, Lisbon, London</asp:ListItem>
                                      <asp:ListItem value="Greenwich Standard Time">(UTC) Monrovia, Reykjavik</asp:ListItem>
                                      <asp:ListItem value="W. Europe Standard Time">(UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna</asp:ListItem>
                                      <asp:ListItem value="Central Europe Standard Time">(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague</asp:ListItem>
                                      <asp:ListItem value="Romance Standard Time">(UTC+01:00) Brussels, Copenhagen, Madrid, Paris</asp:ListItem>
                                      <asp:ListItem value="Central European Standard Time">(UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb</asp:ListItem>
                                      <asp:ListItem value="W. Central Africa Standard Time">(UTC+01:00) West Central Africa</asp:ListItem>
                                      <asp:ListItem value="Jordan Standard Time">(UTC+02:00) Amman</asp:ListItem>
                                      <asp:ListItem value="GTB Standard Time">(UTC+02:00) Athens, Bucharest, Istanbul</asp:ListItem>
                                      <asp:ListItem value="Middle East Standard Time">(UTC+02:00) Beirut</asp:ListItem>
                                      <asp:ListItem value="Egypt Standard Time">(UTC+02:00) Cairo</asp:ListItem>
                                      <asp:ListItem value="South Africa Standard Time">(UTC+02:00) Harare, Pretoria</asp:ListItem>
                                      <asp:ListItem value="FLE Standard Time">(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius</asp:ListItem>
                                      <asp:ListItem value="Israel Standard Time">(UTC+02:00) Jerusalem</asp:ListItem>
                                      <asp:ListItem value="E. Europe Standard Time">(UTC+02:00) Minsk</asp:ListItem>
                                      <asp:ListItem value="Namibia Standard Time">(UTC+02:00) Windhoek</asp:ListItem>
                                      <asp:ListItem value="Arabic Standard Time">(UTC+03:00) Baghdad</asp:ListItem>
                                      <asp:ListItem value="Arab Standard Time">(UTC+03:00) Kuwait, Riyadh</asp:ListItem>
                                      <asp:ListItem value="Russian Standard Time">(UTC+03:00) Moscow, St. Petersburg, Volgograd</asp:ListItem>
                                      <asp:ListItem value="E. Africa Standard Time">(UTC+03:00) Nairobi</asp:ListItem>
                                      <asp:ListItem value="Georgian Standard Time">(UTC+03:00) Tbilisi</asp:ListItem>
                                      <asp:ListItem value="Iran Standard Time">(UTC+03:30) Tehran</asp:ListItem>
                                      <asp:ListItem value="Arabian Standard Time">(UTC+04:00) Abu Dhabi, Muscat</asp:ListItem>
                                      <asp:ListItem value="Azerbaijan Standard Time">(UTC+04:00) Baku</asp:ListItem>
                                      <asp:ListItem value="Mauritius Standard Time">(UTC+04:00) Port Louis</asp:ListItem>
                                      <asp:ListItem value="Caucasus Standard Time">(UTC+04:00) Yerevan</asp:ListItem>
                                      <asp:ListItem value="Afghanistan Standard Time">(UTC+04:30) Kabul</asp:ListItem>
                                      <asp:ListItem value="Ekaterinburg Standard Time">(UTC+05:00) Ekaterinburg</asp:ListItem>
                                      <asp:ListItem value="Pakistan Standard Time">(UTC+05:00) Islamabad, Karachi</asp:ListItem>
                                      <asp:ListItem value="West Asia Standard Time">(UTC+05:00) Tashkent</asp:ListItem>
                                      <asp:ListItem value="India Standard Time">(UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi</asp:ListItem>
                                      <asp:ListItem value="Sri Lanka Standard Time">(UTC+05:30) Sri Jayawardenepura</asp:ListItem>
                                      <asp:ListItem value="Nepal Standard Time">(UTC+05:45) Kathmandu</asp:ListItem>
                                      <asp:ListItem value="N. Central Asia Standard Time">(UTC+06:00) Almaty, Novosibirsk</asp:ListItem>
                                      <asp:ListItem value="Central Asia Standard Time">(UTC+06:00) Astana, Dhaka</asp:ListItem>
                                      <asp:ListItem value="Myanmar Standard Time">(UTC+06:30) Yangon (Rangoon)</asp:ListItem>
                                      <asp:ListItem value="SE Asia Standard Time">(UTC+07:00) Bangkok, Hanoi, Jakarta</asp:ListItem>
                                      <asp:ListItem value="North Asia Standard Time">(UTC+07:00) Krasnoyarsk</asp:ListItem>
                                      <asp:ListItem value="China Standard Time">(UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi</asp:ListItem>
                                      <asp:ListItem value="North Asia East Standard Time">(UTC+08:00) Irkutsk, Ulaan Bataar</asp:ListItem>
                                      <asp:ListItem value="Singapore Standard Time">(UTC+08:00) Kuala Lumpur, Singapore</asp:ListItem>
                                      <asp:ListItem value="W. Australia Standard Time">(UTC+08:00) Perth</asp:ListItem>
                                      <asp:ListItem value="Taipei Standard Time">(UTC+08:00) Taipei</asp:ListItem>
                                      <asp:ListItem value="Tokyo Standard Time">(UTC+09:00) Osaka, Sapporo, Tokyo</asp:ListItem>
                                      <asp:ListItem value="Korea Standard Time">(UTC+09:00) Seoul</asp:ListItem>
                                      <asp:ListItem value="Yakutsk Standard Time">(UTC+09:00) Yakutsk</asp:ListItem>
                                      <asp:ListItem value="Cen. Australia Standard Time">(UTC+09:30) Adelaide</asp:ListItem>
                                      <asp:ListItem value="AUS Central Standard Time">(UTC+09:30) Darwin</asp:ListItem>
                                      <asp:ListItem value="E. Australia Standard Time">(UTC+10:00) Brisbane</asp:ListItem>
                                      <asp:ListItem value="AUS Eastern Standard Time">(UTC+10:00) Canberra, Melbourne, Sydney</asp:ListItem>
                                      <asp:ListItem value="West Pacific Standard Time">(UTC+10:00) Guam, Port Moresby</asp:ListItem>
                                      <asp:ListItem value="Tasmania Standard Time">(UTC+10:00) Hobart</asp:ListItem>
                                      <asp:ListItem value="Vladivostok Standard Time">(UTC+10:00) Vladivostok</asp:ListItem>
                                      <asp:ListItem value="Central Pacific Standard Time">(UTC+11:00) Magadan, Solomon Is., New Caledonia</asp:ListItem>
                                      <asp:ListItem value="New Zealand Standard Time">(UTC+12:00) Auckland, Wellington</asp:ListItem>
                                      <asp:ListItem value="Fiji Standard Time">(UTC+12:00) Fiji, Marshall Is.</asp:ListItem>
                                      <asp:ListItem value="Kamchatka Standard Time">(UTC+12:00) Petropavlovsk-Kamchatsky</asp:ListItem>
                                      <asp:ListItem value="Tonga Standard Time">(UTC+13:00) Nuku&#39;alofa</asp:ListItem>
                                    </asp:DropDownList></td>
                                  
                                </tr>
                            </table></td>
                          </tr>
                          <tr>
                          <td align="right" height="40" valign="top"  bgcolor="#F0F0F0" style="padding-right:15px;">
                          <a href="javascript:;" id="AutoPostOpener" onclick="OpenAutoPostBusinessPageDiv();" runat="server" class="bluetablink">Add Business Page(s):</a>
                          &nbsp;&nbsp;
                          <a class="bluetablink" runat="server" onclick="return ValidateAutoPost();" id="lnkAutoPost">
                                    <asp:PlaceHolder ID="pnlAutoPostSet" runat="server"> Set Autopost </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="pnlAutoPostUpdate" runat="server" Visible="false"> Update Autopost </asp:PlaceHolder>
                                    </a>&nbsp;&nbsp;<asp:PlaceHolder ID="pnlAutoPostOff" runat="server" Visible="false"><a href="javascript:;" class="bluetablink" runat="server" id="lnkAutoPostOff">Turn Autopost <img src='<%=ResolveUrl("Content/images/Off_bullate.png") %>' width="10" height="10" hspace="3" border="0" />Off </a></asp:PlaceHolder> 
                              <asp:PlaceHolder ID="pnlAutoPostOn" runat="server"><a href="javascript:;" class="bluetablink" runat="server" id="lnkAutoPostOnOff" >Turn Autopost <img src='<%=ResolveUrl("Content/images/On_bullate.png") %>' width="10" height="10" hspace="3" border="0" />On </a></asp:PlaceHolder> </td>
                          </tr>
                          <tr>
                            <td align="left" valign="bottom" style="padding-top:10px;"><font style="line-height:20px; font-weight:bold">
                              <asp:Literal ID="ltrAutoPostPage" runat="server"></asp:Literal>
                              </font><br/>
                              
                              <div id="divAutoPostFanPages" style="display:none; z-index:100; width:745px; position:absolute; border:1px solid #CCCCCC; background-color:#f6f6f6;" title="Business Pages">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td align="right" valign="top"></td>
                                  </tr>
                                  <tr>
                                    <td align="left" valign="top" style="padding:20px; ">
                                    <asp:PlaceHolder id="plcAutoData" runat="server">
                                    <div style="height:125px; width:723px; overflow:auto; overflow-x:hidden;">
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
                                      </asp:PlaceHolder>
                                       <asp:PlaceHolder ID="plcNoAutoData" runat="server" Visible="false">
                                           <strong style="color:#990066">  You have no business pages.</strong><br /><br /> <a href="javascript:CreatePage();">Click here</a> to create business page. 
                                   </asp:PlaceHolder>
                                   <asp:PlaceHolder ID="plcAutoError" runat="server" Visible="false">
                                           <strong style="color:#990066">Facebook is experiencing problems. Please try again later</strong><br /><br />
                                   </asp:PlaceHolder>
                                  
                                    </td>
                                  </tr>
                                  <tr><td valign="top" align="right" style="padding-right:30px; padding-bottom:10px;"><a href="javascript:;" class="bluetablink" onclick="HideAutoPostFanPages();">Save</a></td></tr>
                                </table>
                              </div>
                              <asp:Repeater ID="rptAutoPostfanpages" runat="server">
                                <ItemTemplate> &nbsp;&nbsp;<img src='<%# DataBinder.Eval(Container.DataItem, "ap_FBPageImage")%>' width="20" height="20" align="absmiddle" border="0" style="border:1px solid #d3d3d3; padding:1px;" />&nbsp;<font style="font-size:12px; font-family:Arial, Helvetica, sans-serif; line-height:20px;; vertical-align:middle"><%# DataBinder.Eval(Container.DataItem, "ap_FBPageName")%>&nbsp;&nbsp;&nbsp;</font></ItemTemplate>
                              </asp:Repeater>
                              <br/>
                              <br/>
                               <div id="divAutoPostHtml" style="width:300px; display:none; height:auto; border:1px solid #eaeaea; background-color:#f6f6f6; padding:15px; line-height:22px;"> </div>
                            </td>
                          </tr>
                          <tr>
                            <td height="40" align="right" valign="bottom">
                               <a href="javascript:;" class="bluetablink" style="display:none;" id="lnkdisableImport">Loading...</a>
                               &nbsp;<a href="javascript:;" class="bluetablink" runat="server" onclick="return disablelink();" id="lnkAutoPostShuffle">Import Library</a> 
                              <asp:PlaceHolder ID="pnlClearAll" runat="server" Visible="true">
                              
                               <a href="javascript:;" class="bluetablink" runat="server"  style="display:none;" id="lnkdiabledClearAll" >Loading...</a> 
                              <a href="javascript:;" class="bluetablink" runat="server"  onclick="return confirmClear();" id="lnkClearAll">Clear All</a>
                        
                              
                              </asp:PlaceHolder>
                              </td>
                          </tr>
                          <tr>
                            <td align="left" valign="top"><div id="TabbedPanels2" class="TabbedPanels">
                                <ul class="TabbedPanelsTabGroup">
                                  <li class="TabbedPanelsTab1" tabindex="0" style="border-bottom:0px;" >Scheduled</li>
                                  <li class="TabbedPanelsTab1" tabindex="0" style="border-bottom:0px;">Sent</li>
                                </ul>
                                <div class="TabbedPanelsContentGroup1">
                                  <div class="TabbedPanelsContent1">
                                    <div id="div4" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute">
                                      <asp:UpdateProgress ID="UpdateProgressDiv4" runat="Server" DisplayAfter="0">
                                        <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                                      </asp:UpdateProgress>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanelDiv4" runat="server" UpdateMode="Conditional">
                                      <ContentTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                          <tr>
                                            <td align="left" valign="top"><asp:Literal ID="ltrAutoPostRpt" runat="server"></asp:Literal>
                                              <asp:DataList ID="dtlAutoPost" runat="server"  Width="100%" >
                                                <ItemTemplate>
                                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                      <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                          <tr>
                                                            <td align="left" valign="top" width="100" style="display:<%#iif(Eval("apm_Image")<>"" or Eval("apm_VideoId")<>"","","none")%>"><div id="divAutoPostImage" runat="server" style="padding-bottom:10px;"> <img id="imgAutoPostPhoto" runat="server"  border="0" class="grayborder"/> </div>
                                                              <div id="divAutoPostVideo" visible='<%#DataBinder.Eval(Container.DataItem, "apm_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                                <object style="height: 100px; width: 100px">
                                                                  <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                                  <param name="allowFullScreen" value="true">
                                                                  <param name="allowScriptAccess" value="always">
                                                                  <param name="wmode" value="transparent">
                                                                  <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100">
                                                                </object>
                                                              </div></td>
                                                            <td align="left" valign="top" style="padding-left:12px; color:#676767; line-height:17px; text-align:left; word-break: break-all;">
                                                            <span id='spnAutoPost<%#Eval("apm_id")%>'><%#DataBinder.Eval(Container.DataItem, "apm_Message")%></span><br/>
                                                            <div id="divAutoPostLink" visible='<%#DataBinder.Eval(Container.DataItem, "apm_Link")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                            <span id='spnAutoPostLink<%#Eval("apm_id")%>'><%#DataBinder.Eval(Container.DataItem, "apm_Link")%></span>
                                                            </div>
                                                            </td>
                                                          </tr>
                                                        </table></td>
                                                    </tr>
                                                    <tr>
                                                      <td align="left" valign="top" >&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                      <td align="left" valign="top" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                          <tr>
                                                            <td width="70%" align="left" valign="top" class="tahoma12grey" style="font-weight:normal; line-height:17px;" ><strong>Scheduled for</strong><br />
                                                              <label id="lblAutoPostDate" runat="server"></label>
                                                              <%--<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleDate")%> , <%#DataBinder.Eval(Container.DataItem, "apm_ScheduleHour")%>:<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleMinute")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleAMPM")%>--%>
                                                              </td>
                                                            <td  align="right" valign="top" style="padding-top:3px; padding-right:5px;" ><table cellpadding="0" cellspacing="0" align="right" border="0">
                                                                <tr>
                                                                	<td align="right" valign="top">
                                                                    <input type="hidden" id="hdnAutoPost<%#Eval("apm_id")%>" value='<%#Eval("apm_Image")%>' />
                                                              <input type="hidden" id="hdnAutoPostVideo<%#Eval("apm_id")%>" value='<%#Eval("apm_VideoLink")%>' />
                                                              <input type="hidden" id="hdnAutoPostLink<%#Eval("apm_id")%>" value='<%#Eval("apm_Link")%>' />
                                                              <a href="#StatusMessage" onclick='EditAutoPost(<%#Eval("apm_id")%>);' title="Select"><img src="../Content/images/icon_edit.gif" border="0" alt="Select" /></a>
                                                                   </td>
                                                                    <td align="right" valign="top">
                                                                    <asp:LinkButton OnCommand="DeleteMyAutoPost" onclientclick="return Prompt('Are you sure you want to delete this AutoPost?');" CommandArgument='<%#Eval("apm_id")%>' CommandName='<%#Eval("apm_id")%>' id="lnkAutoPostDelete" runat="server" ToolTip="Remove"><img src="../Content/images/icon_delet.gif" border="0" hspace="7" alt="Remove"/></asp:LinkButton></td>
                                                                    <td align="right" valign="middle" style="display:none;"><Span id="spnImageButtonUp" visible='<%#Container.DataItem("apm_OrderImage") = "Up"%>' runat="server">
                                                              <asp:ImageButton id="imgBtnUp" ImageUrl="Content/images/arrow_up.png" ToolTip ="Up" runat="server"  
                                              CommandName="Up" CommandArgument='<%#Container.DataItem("apm_id")%>'></asp:ImageButton>
                                                              </Span> <Span id="spnImageButtonDown" visible='<%#Container.DataItem("apm_OrderImage") = "Down"%>' runat="server" Headerstyle-HorizontalAlign="Center">
                                                              <asp:ImageButton id="imgBtnDown" ImageUrl="Content/images/arrow_down.png" ToolTip ="Down" runat="server" CommandName="Down" CommandArgument='<%#Container.DataItem("apm_id")%>'> </asp:ImageButton>
                                                              </Span> <Span id="spnImageButtonUpDown" visible='<%#Container.DataItem("apm_OrderImage") ="Updown"%>' runat="server" Headerstyle-HorizontalAlign="Center">
                                                              <asp:ImageButton id="imgBtnUp1" ImageUrl="Content/images/arrow_up.png"	ToolTip ="Up" runat="server"  
                                              CommandName="Up" CommandArgument='<%#Container.DataItem("apm_id")%>'></asp:ImageButton>
                                                              &nbsp;
                                                              <asp:ImageButton id="imgBtnDown1" ImageUrl="Content/images/arrow_down.png" 	ToolTip ="Down" runat="server"  CommandName="Down" CommandArgument='<%#Container.DataItem("apm_id")%>'></asp:ImageButton>
                                                              </Span></td>
                                                                </tr>
                                                                </table>
                                                            </td>
                                                          </tr>
                                                        </table></td>
                                                    </tr>
                                                    <tr>
                                                      <td height="40" align="left" valign="top" class="greysolidline">&nbsp;</td>
                                                    </tr>
                                                  </table>
                                                </ItemTemplate>
                                              </asp:DataList>
                                            </td>
                                          </tr>
                                          <tr align="right">
                                            <td style="padding-right:20px;"><asp:PlaceHolder ID="phPagingAutoPost" runat="server" ></asp:PlaceHolder></td>
                                          </tr>
                                        </table>
                                      </ContentTemplate>
                                    </asp:UpdatePanel>
                                  </div>
                                  <div class="TabbedPanelsContent">
                                   <div id="div6" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute">
                                      <asp:UpdateProgress ID="UpdateProgress5" runat="Server" DisplayAfter="0">
                                        <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                                      </asp:UpdateProgress>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                      <ContentTemplate>
                                  <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                  <tr>
                                  <td align="left" valign="top">
                                   <asp:Literal ID="ltrSentAutoPostRpt" runat="server"></asp:Literal>
                                  <asp:DataList ID="dtlSentAutoPost" runat="server"  Width="100%" >
                                      <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                          <tr>
                                            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                  <td align="left" valign="top" width="100" style="display:<%#iif(Eval("apm_Image")<>"" or Eval("apm_VideoId")<>"" ,"","none")%>"><div id="divSentAutoPostImage" runat="server" style="padding-bottom:10px;"> <img id="imgSentAutoPostPhoto" runat="server"  border="0" class="grayborder"/> </div>
                                                    <div id="divSentAutoPostVideo" visible='<%#DataBinder.Eval(Container.DataItem, "apm_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                      <object style="height: 100px; width: 100px">
                                                        <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                        <param name="allowFullScreen" value="true">
                                                        <param name="allowScriptAccess" value="always">
                                                        <param name="wmode" value="transparent">
                                                        <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100">
                                                      </object>
                                                    </div></td>
                                                  <td align="left" valign="top" style="padding-left:5px;  text-align:left; word-break: break-all">
                                                  <span id='spnAutoPost<%#Eval("apm_id")%>'> <%#DataBinder.Eval(Container.DataItem, "apm_Message")%> </span>
                                                  <br/>
                                                            <div id="divSentAutoPostLink" visible='<%#DataBinder.Eval(Container.DataItem, "apm_Link")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                            <span id='spnSentAutoPostLink<%#Eval("apm_id")%>'><%#DataBinder.Eval(Container.DataItem, "apm_Link")%></span>
                                                            </div></td>
                                                </tr>
                                              </table></td>
                                          </tr>
                                          <tr>
                                            <td align="left" valign="top" >&nbsp;</td>
                                          </tr>
                                          <tr>
                                            <td align="left" valign="top" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                  <td align="left" valign="top" class="tahoma12grey" style="display:none;"><strong>Autopost Submitted On
                                                    <label id="lblSentAutoPostDate" runat="server"></label>
                                                    <%--<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleDate")%> , <%#DataBinder.Eval(Container.DataItem, "apm_ScheduleHour")%>:<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleMinute")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleAMPM")%>--%>
                                                    </strong></td>
                                                  <td align="right" valign="top" style="padding-top:5px;">&nbsp;</td>
                                                </tr>
                                              </table></td>
                                          </tr>
                                          <tr>
                                            <td height="40" align="left" valign="top" class="greysolidline">&nbsp;</td>
                                          </tr>
                                        </table>
                                      </ItemTemplate>
                                    </asp:DataList>
                                  </td>
                                  </tr>
                                  <tr align="right">
                                            <td style="padding-right:20px;"><asp:PlaceHolder ID="phPagingSentAutoPost" runat="server" ></asp:PlaceHolder></td>
                                          </tr>
                                  </table>
                                   </ContentTemplate>
                                   </asp:UpdatePanel>
                                    
                                  </div>
                                </div>
                              </div></td>
                          </tr>
                        </table>
                      </div>
                      <div class="TabbedPanelsContent">
                      <div id="div5" runat="server" style="margin-right:0px; width:74px; height:40px;overflow:hidden;position:absolute">
                              <asp:UpdateProgress ID="UpdateProgress4" runat="Server" DisplayAfter="0">
                                <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                              </asp:UpdateProgress>
                            </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanelAdminLibrary" runat="server" UpdateMode="Conditional">
                              <ContentTemplate>--%>
                              <div align="center" style="color:Red;"><asp:Literal ID="ltrAdminLibMsg" runat="server"></asp:Literal> </div>
                        <table width="100%" style="padding-top:15px;">
                          <tr id="trLibrary" runat="server" Group="Info">
                            <td valign="top">
                            
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr id="trAdminLib" group="libtr">
                                  <td>
                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <tr>
                                       <td >
                                       <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <tr>
                                          <asp:Repeater id="rptAdminLibCatTitle" runat="server">
                                            <itemtemplate>
                                               <td id="tdLibCatTitle<%#Eval("Id")%>" onclick='ShowLib(<%#Eval("Id")%>);' class="tabchedule" group='libcattitle' style="cursor:pointer;"><strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong></td>
                                          </itemtemplate>
                                          </asp:Repeater>
                                         </tr>
                                          </table>
                                          </td >
                                       </tr>
                                      <asp:Repeater id="rptAdminLibCat" runat="server">
                                        <itemtemplate>
                                          <tr>
                                            <td ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr style="display:none">
                                                  <td onclick='ShowLib(<%#Eval("Id")%>);' class="tdindustry" style="cursor:pointer;"><img src="../Content/images/folder_icon2.gif" width="16" height="16"  style="padding-right:5px;"/><strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong></td>
                                                </tr>
                                                
                                                <tr id='trLibCat<%#Eval("Id")%>' style="display:<%#iif(Eval("Row")=1,"","none")%>" group='libcattr'>
                                                  <td style="padding-left:15px; padding-top:20px; border:1px solid #d3d3d3;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                      <asp:Repeater id="rptAdminLib" runat="server" DataSource='<%#BindAdminLibraries(Eval("Id"))%>'>
                                                        <itemtemplate>
                                                          <tr>
                                                            <td style="border-bottom:2px solid #d3d3d3; padding-bottom:22px;">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                            	<td align="left" valign="top" width="100" style="display:<%#iif(Eval("lib_Image")<>"" or Eval("lib_VideoId")<>"" ,"","none")%>">
                                                                <asp:PlaceHolder ID="pnlAdminLibImage" runat="server" Visible='<%#Eval("lib_Image")<>""%>'>
                                                                <div id="divAdminLibImage" style="padding-bottom:10px;"> <img id="imgUserLibPhoto" src='<%=System.Configuration.ConfigurationManager.AppSettings("AppPath")%>resize-tabs.ashx?P=/content/uploads/images/<%#Eval("lib_Image")%>&D=150x100' border="0" style=" cursor:pointer" class="grayborder" /> </div>
                                                              </asp:PlaceHolder>
                                                              &nbsp;
                                                              &nbsp;&nbsp;
                                                              <div id="divAdminLibVideo" visible='<%#DataBinder.Eval(Container.DataItem, "lib_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                                <object style="height: 100px; width: 100px">
                                                                  <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                                  <param name="allowFullScreen" value="true">
                                                                  <param name="allowScriptAccess" value="always">
                                                                  <param name="wmode" value="transparent">
                                                                  <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100" />
                                                                </object>
                                                              </div>
                                                                </td>
                                                                <td align="left" valign="top" style="padding-left:12px; color:#676767; text-align:justify; line-height:18px; padding-right:15px; word-break: break-all">
                                                                <span id='spnlib<%#Eval("lib_Id")%>'>
                                                                 <%#Eval("lib_Template")%></span><br/>
                                                                  <span id='spnlibLink<%#Eval("lib_Id")%>'>
                                                                 <%#Eval("lib_Link")%></span>
                                                                 
                                                                  <input type="hidden" id="hdnlib<%#Eval("lib_Id")%>" value='<%#Eval("lib_Image")%>' />
                                                              <input type="hidden" id="hdnlibVideo<%#Eval("lib_Id")%>" value='<%#Eval("lib_Video")%>' />
                                                              <input type="hidden" id="hdnlibLink<%#Eval("lib_Id")%>" value='<%#Eval("lib_Link")%>' />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" valign="top" colspan="2" style="padding-right:15px; padding-top:5px;"> <table cellpadding="0" cellspacing="0" align="right" border="0">
                                                                <tr>
                                                                	<td align="right" valign="top"><a href="#StatusMessage" onclick='EditLib(<%#Eval("lib_Id")%>);' title="Select"><img src="../Content/images/icon_edit.gif" hspace="7" border="0" alt="Select"/></a></td>
                                                                    <td align="right" valign="middle"><asp:LinkButton OnCommand="AddLibToAutoPost" onclientclick="return PromtAddToautoPost();" CommandArgument='<%#Eval("lib_Id")%>' CommandName='<%#Eval("lib_Id")%>' id="lnkAddLibtoAutoPost" CssClass="bluetablink" runat="server"><asp:PlaceHolder ID="plhNotAdded" runat="server">
                                                                    Add To Autopost</asp:PlaceHolder>
                                                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false"> Added To Autopost</asp:PlaceHolder>
                                                                </asp:LinkButton></td>
                                                                </tr>
                                                                </table>

                                                                </td>
                                                            </tr>
                                                            </table>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                            <td height="20"></td>
                                                          </tr>
                                                        </itemtemplate>
                                                      </asp:Repeater>
                                                    </table></td>
                                                </tr>
                                              </table></td>
                                          </tr>
                                        </itemtemplate>
                                      </asp:Repeater>
                                    </table></td>
                                </tr>
                              </table>
                             </td>
                          </tr>
                        </table>
                       <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                      </div>
                      
                      <div class="TabbedPanelsContent">
                           <div id="divLib" runat="server" style="margin-right:0px; width:74px; height:40px;overflow:hidden;position:absolute">
                              <asp:UpdateProgress ID="UpdateProgressLib" runat="Server" DisplayAfter="0">
                                <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                              </asp:UpdateProgress>
                            </div>
                     <asp:UpdatePanel ID="UpdatePanelLib" runat="server" UpdateMode="Conditional">
                              <ContentTemplate>
                      		<table width="100%" border="0" cellspacing="0" cellpadding="0">
                            	<tr id="trMyLib" style="display:" group="libtr">
                                  <td>
                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <tr>
                                       	<td align="center" height="30">
                                        	<font color="red" style="text-align:center; font-size:14px; font-family:Arial, Helvetica, sans-serif">
                                                  <asp:Literal id="ltrLibMsg" runat="server"></asp:Literal>
                                                  </font>
                                        </td>
                                       </tr>
                                       <tr>
                                       <td>
                                       <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <tr>
                                          <asp:Repeater id="rptUserLibCatTitle" runat="server">
                                            <itemtemplate>
                                               <td id="tdUserLibCatTitle<%#Eval("Id")%>" onclick='ShowUserLib(<%#Eval("Id")%>);' class="tabchedule" group='userlibcattitle' style="cursor:pointer;"><strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong>&nbsp;&nbsp;
                                              <asp:PlaceHolder ID="pnlLibCatDel" runat="server" Visible='<%#Eval("lc_UserId")<>-1%>'>
                                                      <asp:LinkButton OnCommand="DeleteMyLibCat" onclientclick="return Prompt('Are you sure you want to delete this library?');" CommandArgument='<%#Eval("Id")%>' CommandName='<%#Eval("Title")%>' id="lnkAdminLibCatDelete" runat="server">&nbsp;<img src='<%=ResolveUrl("Content/images/delete_icon.png")%>' border="0"/>&nbsp;</asp:LinkButton>
                                                    </asp:PlaceHolder>
                                                    </td>
                                          </itemtemplate>
                                          </asp:Repeater>
                                          </tr>
                                          </table>
                                          </td>
                                       </tr>
                                      <asp:Repeater id="rptUserLibCat" runat="server">
                                        <itemtemplate>
                                          <tr >
                                            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr style="display:none;">
                                                  <td onclick='ShowUserLib(<%#Eval("Id")%>);' class="tdindustry" style="cursor:pointer;"><img src="../Content/images/folder_icon2.gif" width="16" height="16"  style="padding-right:5px;"/>
                                                  <strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:PlaceHolder ID="pnlLibCatDel" runat="server" Visible='<%#Eval("lc_UserId")<>-1%>'>
                                                      <asp:LinkButton OnCommand="DeleteMyLibCat" onclientclick="return Prompt('Are you sure you want to delete this library?');" CommandArgument='<%#Eval("Id")%>' CommandName='<%#Eval("Title")%>' id="lnkAdminLibCatDelete12" runat="server">Delete</asp:LinkButton>
                                                    </asp:PlaceHolder>
                                                  </td>
                                                 
                                                </tr>
                                                <tr id='trUserLibCat<%#Eval("Id")%>' style="display:<%#iif(Eval("Row")=1,"","none")%>" group='userlibcattr'>
                                                  <td style="padding-left:15px; padding-top:20px; border:1px solid #d3d3d3;">
                                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                      <asp:Repeater id="rptUserLib" runat="server" DataSource='<%#BindUserLibraries(Eval("Id"))%>'>
                                                        <itemtemplate>
                                                          <tr>
                                                            <td style="border-bottom:2px solid #d3d3d3; padding-bottom:22px;">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                            	<td align="left" valign="top" width="100" style="display:<%#iif(Eval("lib_Image")<>"" or Eval("lib_VideoId")<>"" ,"","none")%>">
                                                                <asp:PlaceHolder ID="pnlUserLibImage" runat="server" Visible='<%#Eval("lib_Image")<>""%>'>
                                                                <div id="divUserLibImage" style="padding-bottom:10px;"> <img id="imgUserLibPhoto" src='<%=System.Configuration.ConfigurationManager.AppSettings("AppPath")%>resize-tabs.ashx?P=/content/uploads/images/<%#Eval("lib_Image")%>&D=150x100' border="0" style=" cursor:pointer" class="grayborder" /> </div>
                                                              </asp:PlaceHolder>
                                                              &nbsp;
                                                              &nbsp;&nbsp;
                                                              <div id="divUserLibVideo" visible='<%#DataBinder.Eval(Container.DataItem, "lib_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                                <object style="height: 100px; width: 100px">

                                                                  <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                                  <param name="allowFullScreen" value="true">
                                                                  <param name="allowScriptAccess" value="always">
                                                                  <param name="wmode" value="transparent">
                                                                  <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100" />
                                                                </object>
                                                              </div>
                                                                </td>
                                                                <td align="left" valign="top" style="padding-left:12px; color:#676767; line-height:18px;  text-align:left; padding-right:15px; word-break: break-all">
                                                                <span id='spnlib<%#Eval("lib_Id")%>'> <%#Eval("lib_Template")%> </span><br/>
                                                                <span id='spnlibLink<%#Eval("lib_Id")%>'> <%#Eval("lib_Link")%> </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" valign="top" colspan="2" style="padding-right:15px; padding-top:5px;"><table cellpadding="0" cellspacing="0" align="right" border="0">
                                                                <tr>
                                                                	<td align="right" valign="top"><a href="#StatusMessage" onclick='EditLib(<%#Eval("lib_Id")%>);' title="Select"><img src="../Content/images/icon_edit.gif" border="0" alt="Select"/></a><input type="hidden" id="hdnlib<%#Eval("lib_Id")%>" value='<%#Eval("lib_Image")%>' />
                                                              <input type="hidden" id="hdnlibVideo<%#Eval("lib_Id")%>" value='<%#Eval("lib_Video")%>' />
                                                              <input type="hidden" id="hdnlibLink<%#Eval("lib_Id")%>" value='<%#Eval("lib_Link")%>' />                                                              </td>
                                                                    <td align="right" valign="top"><asp:LinkButton OnCommand="DeleteMyLib" OnClientClick="return confirm('Are you sure you want to delete this post from the library?');" CommandArgument='<%#Eval("lib_Id")%>' CommandName='<%#Eval("lib_Category")%>' id="lnkAdminLibDelete" runat="server" ToolTip="Remove" ><img src="../Content/images/icon_delet.gif" hspace="7" border="0" alt="Remove" /></asp:LinkButton></td>
                                                                    <td align="right" valign="middle"><asp:LinkButton OnCommand="AddLibToAutoPost" onclientclick="return PromtAddToautoPost();" CommandArgument='<%#Eval("lib_Id")%>' CommandName='<%#Eval("lib_Id")%>' id="lnkAddLibtoAutoPost1" CssClass="bluetablink" runat="server">
                                                                <asp:PlaceHolder ID="plhNotAdded1" runat="server">Add To Autopost</asp:PlaceHolder>
                                                                
                                                                </asp:LinkButton></td>
                                                                </tr>
                                                                </table>
                                                              
                                                                </td>
                                                            </tr>
                                                            </table>
                                                            </td>
                                                          </tr>
                                                          <tr>
                                                            <td  height="20"></td>
                                                          </tr>
                                                        </itemtemplate>
                                                      </asp:Repeater>
                                                    </table></td>
                                                </tr>
                                              </table></td>
                                          </tr>
                                        </itemtemplate>
                                      </asp:Repeater>
                                    </table></td>
                                </tr>
                            </table>
                               </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                 
                      <div class="TabbedPanelsContent">
                        <div id="div3" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute">
                          <asp:UpdateProgress ID="UpdateProgress3" runat="Server" DisplayAfter="0">
                            <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                          </asp:UpdateProgress>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                          <ContentTemplate>
                            <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0" style="padding-top:15px;">
                              <tr>
                                <td align="left" valign="top"><asp:Literal id="ltrScheduledPosts" runat="server"></asp:Literal>
                                  <asp:DataList ID="dtlScheduledPosts" runat="server" Width="100%"  >
                                    <ItemTemplate>
                                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                          <td height="40" align="left" valign="top" style="background-color:#fafafa; padding:8px; border:1px  solid #ecebeb; line-height:30px;"><font color="#0066CC"><strong>Business Page Selected: </strong></font><br />
                                            <asp:Repeater ID="rptScheduledPostsfanpages" runat="server" DataSource='<%# BindScheduledPostsFanPages(DataBinder.Eval(Container.DataItem, "sm_id")) %>'>
                                              <ItemTemplate>
                                                   <img src='<%# DataBinder.Eval(Container.DataItem, "sp_FBPageImage")%>' style="border:1px solid #CCC; padding:1px;" width="20" height="20" align="absmiddle" border="0" />&nbsp;<font style="font-size:12px; font-family:Arial, Helvetica, sans-serif; line-height:20px;; vertical-align:middle"><%# DataBinder.Eval(Container.DataItem, "sp_FBPageName")%>&nbsp;&nbsp;&nbsp;</font>
                                              </ItemTemplate>
                                            </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr>
                                          <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                              <tr>
                                                <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                      <td align="left" valign="top" width="100" style="display:<%#iif(Eval("sm_Image")<>"" or Eval("sm_VideoId")<>"" ,"","none")%>">
                                                      <div id="divScheduleImage" runat="server" style="padding-top:15px; padding-right:15px;"> <img id="imgSchedulePhoto" runat="server"  border="0" class="grayborder" onMouseOver="ShowDiv('divScheduleLargeImage');" onMouseOut="HideDiv('divScheduleLargeImage');"/> </div>
                                                          
                                                        <div id="divSentVideo" visible='<%#DataBinder.Eval(Container.DataItem, "sm_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                          <object style="height:100px; width: 100px">
                                                            <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                            <param name="allowFullScreen" value="true">
                                                            <param name="allowScriptAccess" value="always">
                                                            <param name="wmode" value="transparent">
                                                            <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100">
                                                          </object>
                                                        </div></td>
                                                      <td align="left" valign="top" style="padding:15px 0px; text-align:left; color:#676767; line-height:17px;"><input type="hidden" id="hdnScheduledPostId" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "sm_id")%>'>
                                                        <%#DataBinder.Eval(Container.DataItem, "sm_Message")%><br/>
                                              <a href='http://<%#DataBinder.Eval(Container.DataItem, "sm_VideoLink")%>' target="_blank"><%#DataBinder.Eval(Container.DataItem, "sm_VideoLink")%></a></td>
                                                    </tr>
                                                  </table></td>
                                              </tr>
                                              <tr>
                                                <td align="left" valign="top"  style="border-top: 1px dotted #eaeaea;">&nbsp;</td>
                                              </tr>
                                              <tr>
                                                <td align="left" valign="top" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                      <td align="left" valign="top" style="line-height:18px;" ><strong>Scheduled for<br /></strong>
                                                        <label id="lblScheduleDate" runat="server"></label>
                                                        <div style="display:none"><br />
                                                          <%#DataBinder.Eval(Container.DataItem, "sm_ScheduleDate")%> , <%#DataBinder.Eval(Container.DataItem, "sm_ScheduleHour")%>:<%#DataBinder.Eval(Container.DataItem, "sm_ScheduleMinute")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "sm_ScheduleAMPM")%></div>
                                                        </td>
                                                      <td align="right" valign="top">
                                                      <a href='../scheduler/<%# Container.DataItem("sm_Id")%>' style="text-decoration:none;" title="Edit"><img src="../Content/images/icon_edit.gif" hspace="7" border="0" /></a>
                                                        <asp:ImageButton ImageUrl="Content/images/icon_delet.gif" OnClick="DeleteByID" CommandName='<%#DataBinder.Eval(Container.DataItem, "sm_Id")%>' OnClientClick="return confirm('Are you sure want to delete this Scheduled Post?');"  ID="btndelete" runat="server" ToolTip="Delete" />
                                                        
                                                      </td>
                                                    </tr>
                                                  </table></td>
                                              </tr>
                                            </table></td>
                                        </tr>
                                        <tr>
                                          <td height="40" align="left" valign="top" class="greysolidline">&nbsp;</td>
                                        </tr>
                                      </table>
                                    </ItemTemplate>
                                  </asp:DataList>
                                </td>
                              </tr>
                              <tr align="right">
                                <td style="padding-right:20px;"><asp:PlaceHolder ID="phPagingScheduled" runat="server" ></asp:PlaceHolder></td>
                              </tr>
                            </table>
                          </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                      <div class="TabbedPanelsContent">
                        <div id="div2" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute;">
                          <asp:UpdateProgress ID="UpdateProgress2" runat="Server" DisplayAfter="0" >
                            <ProgressTemplate > <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                          </asp:UpdateProgress>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                          <ContentTemplate>
                            <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0" style="padding-top:15px;">
                              <tr>
                                <td align="left" valign="top"><asp:Literal ID="ltrSentItems" runat="server"></asp:Literal>
                                  <asp:DataList ID="dtlSentItems" runat="server" Width="100%"  >
                                    <ItemTemplate>
                                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                          <td height="40" align="left" valign="top" style="background-color:#fafafa; padding:8px; border:1px  solid #ecebeb; line-height:30px;"><font color="#0066CC"><strong>Business Page Selected: </strong></font><br />
                                           <asp:Repeater ID="rptSentItemsfanpages" runat="server"  DataSource='<%# BindSentItemsFanPages(DataBinder.Eval(Container.DataItem, "sm_id")) %>'>
                                              <ItemTemplate> 
                                              <img src='<%# DataBinder.Eval(Container.DataItem, "sp_FBPageImage")%>' width="20" height="20" align="absmiddle" border="0" style="border:1px solid #CCC; padding:1px;" />&nbsp;<font style="font-size:12px; font-family:Arial, Helvetica, sans-serif; line-height:20px;; vertical-align:middle"><%# DataBinder.Eval(Container.DataItem, "sp_FBPageName")%>&nbsp;&nbsp;&nbsp;</font>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr>
                                          <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                              <tr>
                                                <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                      <td align="left" valign="top" width="100" style="display:<%#iif(Eval("sm_Image")<>"" or Eval("sm_VideoId")<>"" ,"","none")%>"> <div id="divSentImage" runat="server" style="padding-top:15px; padding-right:15px;"> <img id="imgSentPhoto" runat="server"  border="0" class="grayborder"  onmouseover="ShowDiv('divSentLargeImage');" onmouseout="HideDiv('divSentLargeImage');"/> </div>
                                              
                                            <div id="divSentVideo" visible='<%#DataBinder.Eval(Container.DataItem, "sm_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                              <object style="height:100px; width: 100px">
                                                <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                <param name="allowFullScreen" value="true">
                                                <param name="allowScriptAccess" value="always">
                                                <param name="wmode" value="transparent">
                                                <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100">
                                              </object>
                                            </div></td>
                                                      <td align="left" valign="top" style="padding:15px 0px; text-align:left; color:#676767; line-height:17px;"> <input type="hidden" id="hdnSentItemId" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "sm_id")%>'>
                                              <%#DataBinder.Eval(Container.DataItem, "sm_Message")%><br/>
                                              <a href='http://<%#DataBinder.Eval(Container.DataItem, "sm_VideoLink")%>' target="_blank"><%#DataBinder.Eval(Container.DataItem, "sm_VideoLink")%></a></td>
                                                    </tr>
                                                  </table></td>
                                              </tr>
                                              <tr>
                                                <td align="left" valign="top" style="border-top: 1px dotted #eaeaea;">&nbsp;</td>
                                              </tr>
                                              <tr>
                                                <td align="left" valign="top" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                      <td align="left" valign="top" style="line-height:18px; display:none"><strong>Post Submitted on</strong><br/>
                                                        <label id="lblSentItemDate" runat="server"></label>
                                            <%--<%#DataBinder.Eval(Container.DataItem, "sm_ScheduleDate")%> , <%#DataBinder.Eval(Container.DataItem, "sm_ScheduleHour")%>:<%#DataBinder.Eval(Container.DataItem, "sm_ScheduleMinute")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "sm_ScheduleAMPM")%>--%></td>
                                                      <td align="right" valign="top">
                                                      <a href='../scheduler/<%# Container.DataItem("sm_Id")%>' style="text-decoration:none;" title="Edit"><img src="../Content/images/icon_edit.gif"  hspace="7" border="0" /></a>
                                                      <asp:ImageButton ImageUrl="Content/images/icon_delet.gif" OnClick="DeleteByID" CommandName='<%#DataBinder.Eval(Container.DataItem, "sm_Id")%>' OnClientClick="return confirm('Are you sure want to delete this post?');"  ID="btndelete" runat="server" ToolTip="Delete" />
                                              </asp:ImageButton>
                                                      </td>
                                                    </tr>
                                                  </table></td>
                                              </tr>
                                            </table></td>
                                        </tr>
                                        <tr>
                                          <td height="40" align="left" valign="top" class="greysolidline">&nbsp;</td>
                                        </tr>
                                      </table>
                                    </ItemTemplate>
                                  </asp:DataList>
                                </td>
                              </tr>
                              <tr align="right">
                                <td style="padding-right:20px;"><asp:PlaceHolder ID="phPagingSent" runat="server" ></asp:PlaceHolder></td>
                              </tr>
                            </table>
                          </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                      <div class="TabbedPanelsContent">
                        <div id="div1" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute">
                          <asp:UpdateProgress ID="UpdateProgress1" runat="Server" DisplayAfter="0">
                            <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                          </asp:UpdateProgress>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                          <ContentTemplate>
                            <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0" style="padding-top:15px;">
                              <tr>
                                <td align="left" valign="top"><asp:Literal ID="ltrDrafts" runat="server"></asp:Literal>
                                  <asp:DataList ID="dtlDrafts" runat="server" Width="100%"  >
                                    <ItemTemplate>
                                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                          <td height="40" align="left" valign="top" style="background-color:#fafafa; padding:8px; border:1px  solid #ecebeb; line-height:30px;"><font color="#0066CC"><strong>Business Page Selected: </strong></font><br />
                                           <asp:Repeater ID="rptfanpages" runat="server"  DataSource='<%# BindDraftFanPages(DataBinder.Eval(Container.DataItem, "sm_id")) %>'>
                                              <ItemTemplate>
                                              <img src='<%# DataBinder.Eval(Container.DataItem, "sp_FBPageImage")%>' style="border:1px solid #CCC; padding:1px;" width="20" height="20" align="absmiddle" border="0" />&nbsp;<font style="font-size:12px; font-family:Arial, Helvetica, sans-serif; line-height:20px;; vertical-align:middle"><%# DataBinder.Eval(Container.DataItem, "sp_FBPageName")%>&nbsp;&nbsp;&nbsp;</font></ItemTemplate>
                                            </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr>
                                          <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                              <tr>
                                                <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                      <td align="left" valign="top" width="100" style="display:<%#iif(Eval("sm_Image")<>"" or Eval("sm_VideoId")<>"" ,"","none")%>"> <div id="divDraftImage" runat="server" style="padding-top:15px; padding-right:15px;"><img id="imgDraftPhoto" runat="server"  border="0" class="grayborder" onmouseover="ShowDiv('divDraftLargeImage');" onmouseout="HideDiv('divDraftLargeImage');"/> </div>
                                            <div id="divDraftVideo" visible='<%#DataBinder.Eval(Container.DataItem, "sm_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                              <object style="height: 100px; width: 100px">
                                                <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                <param name="allowFullScreen" value="true">
                                                <param name="allowScriptAccess" value="always">
                                                <param name="wmode" value="transparent">
                                                <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100" />
                                              </object>
                                            </div></td>
                                                      <td align="left" valign="top" style="padding:15px 0px; text-align:left; color:#676767; line-height:17px;"> <input type="hidden" id="hdnDraftId" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "sm_id")%>'>
                                              <%#DataBinder.Eval(Container.DataItem, "sm_Message")%><br/>
                                              <a href='http://<%#DataBinder.Eval(Container.DataItem, "sm_VideoLink")%>' target="_blank"><%#DataBinder.Eval(Container.DataItem, "sm_VideoLink")%></a></td>
                                                    </tr>
                                                  </table></td>
                                              </tr>
                                              <tr>
                                                <td align="left" valign="top" style="border-top: 1px dotted #eaeaea;">&nbsp;</td>
                                              </tr>
                                              <tr>
                                                <td align="left" valign="top" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                      <td align="left" valign="top" style="line-height:18px; display:none"><strong>Draft Saved on</strong><br/>
                                                        <label id="lblDraftDate" runat="server"></label>
                                            <%--<%#DataBinder.Eval(Container.DataItem, "sm_ScheduleDate")%> , <%#DataBinder.Eval(Container.DataItem, "sm_ScheduleHour")%>:<%#DataBinder.Eval(Container.DataItem, "sm_ScheduleMinute")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "sm_ScheduleAMPM")%>--%>
                                                        </td>
                                                      <td align="right" valign="top"><a href='../scheduler/<%# Container.DataItem("sm_Id")%>' style="text-decoration:none" title="Edit"><img src="../Content/images/icon_edit.gif"  hspace="7" border="0" /></a><asp:ImageButton ImageUrl="Content/images/icon_delet.gif" OnClick="DeleteByID" CommandName='<%#DataBinder.Eval(Container.DataItem, "sm_Id")%>' OnClientClick="return confirm('Are you sure want to delete this Draft?');"  ID="btndelete" runat="server" ToolTip="Delete" TabIndex="1000" />
                                              </asp:ImageButton>
                                                      </td>
                                                    </tr>
                                                  </table></td>
                                              </tr>
                                            </table></td>
                                        </tr>
                                        <tr>
                                          <td height="40" align="left" valign="top" class="greysolidline">&nbsp;</td>
                                        </tr>
                                      </table>
                                    </ItemTemplate>
                                  </asp:DataList>
                                </td>
                              </tr>
                              <tr align="right">
                                <td style="padding-right:20px;"><asp:PlaceHolder ID="phPaging1" runat="server" ></asp:PlaceHolder></td>
                              </tr>
                            </table>
                          </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                    </div>
                  </div>
                  <script type="text/javascript">
<!--
                      var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
                      var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
//-->
</script>
            </table></td>
        </tr>
      </table>
    </div>
  </div>
  <div> </div>
  <uc2:inner ID="inner2" runat="server" />
  <div id="divUploadLimit" title="Upload Limit Exceeded" style="display:none;">
    <table border="0">
      <tr>
        <td align="left" height="40" colspan="2" style="text-align:left; font-size:12px; color:Gray"><strong>Error:</strong> <br/>
          <br/>
          <font style="font-family:Arial, Helvetica, sans-serif; font-size:14px; color:#CCCCCC;">This file exceeds the 10MB attachment limit. Sorry.</font> </td>
      </tr>
    </table>
  </div>
</form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function Checked(_this) {
        if ($(_this).attr("checked") == "checked") {
            $('input[group^=page]').each(
				function () {
				    $(this).attr("checked", false)
				}
			);
            $(_this).attr("checked", true);
            $('img[group^=pageimg]').each(
				function () {
				    $(this).removeClass("imgborderSelected");
				    $(this).addClass("imgborder");
				}
			);
            $('img[group^=pageimg]').each(
				function () {
				    if ($(this).attr("pageid") == $(_this).attr("pageid")) {
				        $(this).removeClass("imgborder");
				        $(this).addClass("imgborderSelected");
				    }

				}
			);


        }
        else {
            $('input[group^=page]').each(
				function () {
				    $(this).attr("checked", false)
				}
			);
            $('img[group^=pageimg]').each(
				function () {
				    $(this).removeClass("imgborderSelected");
				    $(this).addClass("imgborder");
				}
			);
        }

    }
    </script>
<script type="text/javascript" language="javascript">
    function ShowInfo(ID) {
        $("tr[Group^=Info]").each(
			function () {
			    $(this).css("display", "none");
			}
		);
        $('#' + ID).css("display", "");

        $("td[Group^=InfoTr]").each(
			function () {
			    $(this).removeClass('activetab');
			    $(this).addClass('inactivetab');
			}
		);
        var lnkID = "lnk" + ID.replace("tr", "");
        $('#' + lnkID).removeClass('inactivetab');
        $('#' + lnkID).addClass('activetab');
    }


    </script>
<script type="text/javascript" language="javascript">
    function HideProgress() {
        parent.document.getElementById("imgLoading").style.display = 'none';

    }
    function ShowProgress() {
        parent.document.getElementById("imgLoading").style.display = 'block';
    }
    function ChangeTab(Id, Tab) {
        $('tr[group^=libtr]').each(
	function () {
	    $(this).css('display', 'none');
	});
        $('#' + Id).css('display', '');
        if (Tab == 1) {
            $('#imgAdminLib').attr('src', "../content/images/company_library_tab.gif");
            $('#imgMyLib').attr('src', "../content/images/my_library_hover_tab.gif");

        }
        else {
            $('#imgAdminLib').attr('src', "../content/images/company_library_hover_tab.gif");
            $('#imgMyLib').attr('src', "../content/images/my_library_tab.gif");
        }

    }
    function ShowLib(Id) {
        $('tr[group^=libcattr]').each(
	function () {
	    $(this).css('display', 'none');
	});
	
	$('td[group^=libcattitle]').each(
	function () {
		$(this).removeClass('tabcheduleact');
	    $(this).addClass('tabchedule');
		
	});
	    $('#tdLibCatTitle' + Id).addClass('tabcheduleact');
		$('#tdLibCatTitle' + Id).removeClass('tabchedule');
        $('#trLibCat' + Id).slideDown('slow');
    }
    function ShowUserLib(Id) {
        $('tr[group^=userlibcattr]').each(
	function () {
	    $(this).css('display', 'none');

	});
	$('td[group^=userlibcattitle]').each(
	function () {
		$(this).removeClass('tabcheduleact');
	    $(this).addClass('tabchedule');
		
	});
	    $('#tdUserLibCatTitle' + Id).addClass('tabcheduleact');
		$('#tdUserLibCatTitle' + Id).removeClass('tabchedule');
        $('#trUserLibCat' + Id).slideDown('slow');
    }
    function SelectLibCat() {
        $('#divSchedule').slideUp('slow');
        $('#trNew').css('display', '');
        $('#trCreateNew').css('display', 'none');
        $('#txtNewLibCat').val('');
        $('#hdnLibCatId').val('0');
        var pos = $('#lnkSaveToMyLib').position();
        pos.left = parseInt(pos.left);
        pos.top = parseInt(pos.top);
        var x = pos.left;
        var y = pos.top;
        $('#divLibCat').css('left', x - 25 + 'px')
        $('#divLibCat').css('top', y + 30 + 'px')
        if ($('#divLibCat').css('display') == 'none') {
            $('#divLibCat').slideDown('slow');
        }
        else {
            $('#divLibCat').slideUp('slow');
        }
    }

    function SelectScheduleDiv() {
        $('#divLibCat').slideUp('slow');
        $('#trNew').css('display', '');
        $('#trCreateNew').css('display', 'none');
        $('#txtNewLibCat').val('');
        $('#hdnLibCatId').val('0');
        var pos = $('#lnkSaveToMyLib').position();
        pos.left = parseInt(pos.left);
        pos.top = parseInt(pos.top);
        var x = pos.left;
        var y = pos.top;
        $('#divSchedule').css('left', x - 25 + 'px')
        $('#divSchedule').css('top', y + 30 + 'px')

        if ($('#divSchedule').css('display') == 'none') {
            $('#divSchedule').slideDown('slow');
        }
        else {
            $('#divSchedule').slideUp('slow');
        }

    }

    function CreateNewLibCat() {
        $('#trNew').css('display', 'none');
        $('#trCreateNew').css('display', '');
        $('#txtNewLibCat').val('');
        $('#hdnLibCatId').val('-1');

    }
    function ValidateNewLibCat() {
        if ($('#txtNewLibCat').val() == '') {
            $('#txtNewLibCat').addClass("error");
            return false;
        }
        else {

            if ($('#txtMessage').val() == '') {
                $('#txtMessage').addClass('error');
                alert("Plese enter Library message!")
                return false;
            }
            else {
                $('#txtNewLibCat').removeClass("error");
                $('#divLibCat').slideUp('slow');
                return true;
            }

        }

    }
    function ValidateLib() {
        $('#hdnLibCatId').val('0');
        $('#trNew').css('display', '');
        $('#trCreateNew').css('display', 'none');
        $('#txtNewLibCat').val('');
        if ($('#txtMessage').val() == '') {
            $('#txtMessage').addClass('error');
            alert("Plese enter Compose Message!")
            return false;
        }
        else {
            $('#txtMessage').removeClass('error');
            $('#divLibCat').slideUp('slow');
            return true;
        }
    }
    function Prompt(obj) {
        return (confirm(obj))
    }
    function PromptAddToautoPost() {
        return (confirm("Are you sure you want to delete this library?"))

    }
    function ValidateVideo() {

        var Title = "Fill in Following Information\n";
        var fields = "";
        if ($.trim($('#txtvideo').val()) == '') {
            fields = fields + "\n-- Video Link --";
        }
        /*else {
            if (validateURL() == false) {
                fields = fields + "\n-- Please Enter valid Url --";
            }
        }
*/

        selectedpagesAccessToken();
        selectedpageimage();
        selectedpagesName();

        if (fields.length > 0) {
            alert(Title + fields);
            return false;
        }
        else {

            return true;
        }

    }
	function disablelink()
	{
	var flag=confirm('Are you sure you want to import the entire library?');
		if(flag==true)
		{
			$('#lnkAutoPostShuffle').css('display','none');		
			$('#lnkdisableImport').css('display','');	
		}
	
		return flag;
}

function confirmClear() {
    var flag = confirm('Are you sure you want to delete all the posts in Autopost?');
    if (flag == true) {
        $('#lnkClearAll').css('display', 'none');
        $('#lnkdiabledClearAll').css('display', '');
    }

    return flag;
}
</script>
