<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<style>
body {
width:520px;
overflow:hidden;
margin:0; padding:0; border:0;
}
</style>
<?php
error_reporting(0);
define('APP_ID','299905653367891');
define('APP_SECRET_KEY','716693b1dd94c0b4b79326ec264afca9');
$isfan=isset($_REQUEST['is_fan'])?1:0;
?>
<body>
      <div id="fb-root"></div>
      <script src="https://connect.facebook.net/en_US/all.js"></script>

<?php
$signed_request = $_REQUEST["signed_request"];
$data = parse_signed_request($signed_request, APP_SECRET_KEY);

if ($data['page']['liked'] || $isfan)
{
?>
<script type="text/javascript">
		FB.Canvas.setAutoResize();
		FB.init({ 
            appId:'<?php echo APP_ID;?>', cookie:true, 
            status:true, xfbml:true 
         });
		
		function Post()
		{ 
			 FB.ui({
				  method: "stream.publish",
				  display: "iframe",
				  user_message_prompt: "",
				  message: "",
				  attachment: {
       				 name:'<?php echo addslashes(fbname($data['page']['id']));?>',
        			 href:'http://www.facebook.com/pages/Sweepstakes/<?php echo $data['page']['id'];?>?sk=app_299905653367891',
      	caption:'SWEEPSTAKES: What\'s better than a free new ipad2? I entered and thought you would like to also.  Take a look…',
		description: "NO PURCHASE NECESSARY. See Official Rules",
        media:[{"type":"image","src":"http://www.totalsocialmediaagency.com/sweepstakes/Content/images/stakesfeedimg.png","href":"http://www.facebook.com/pages/Sweepstakes/<?php echo $data['page']['id'];?>?sk=app_299905653367891"}],
					 }
				  /*
				  attachment: {
					 name: "Joe has a gift!",
					 caption: "Joe has tested his skills and did extremely well",
					 description: "Here is a list of Joe's skills:",
					 href: "http://example.com/",
					 media:[{"type":"image","src":"http://example.com/imgs/skills.png","href":"http://example.com/"}],
					 properties:{
					   "1)":{"text":"Reading","href":"http://example.com/skill.php?reading"},
					   "2)":{"text":"Math","href":"http://example.com/skill.php?math"},
					   "3)":{"text":"Farmville","href":"http://example.com/skill.php?farmville"}
					 }
				  }
				 
				  ,
				  action_links: [{ text: 'The Great Discovery puts the 4th Generation of Six Sigma on Facebook.', href: 'http://www.facebook.com/TheGreatDiscovery?sk=app_195039413874656' }] */
				 },
			   function(response) {
				 if (response && response.post_id) {
				   //alert('Post was published.');
				 } else {
				   //alert('Post was not published.');
				 }
			   }
			 );
		}
		
		function invite()
		{
			FB.ui({method: 'apprequests', message: 'Send private invitation message to your friend', data: 'tracking information for the user',href:'http://www.facebook.com/TheGreatDiscovery?sk=app_195039413874656'});
		}
		
		function show_name()
{
val = document.getElementById('name').value;
if(val=='')document.getElementById('name').value='Name';
}
function hide_name()
{
val = document.getElementById('name').value;
if(val=='Name')document.getElementById('name').value='';
}

function show_email()
{
val = document.getElementById('email').value;
if(val=='')document.getElementById('email').value='Email';
}

function hide_email()
{
val = document.getElementById('email').value;
if(val=='Email')document.getElementById('email').value='';
}

function show_phone()
{
val = document.getElementById('phone').value;
if(val=='')document.getElementById('phone').value='Phone No.';
}

function hide_phone()
{
val = document.getElementById('phone').value;

if(val=='Phone No.')document.getElementById('phone').value='';
}
////
function show_msg()
{
val = document.getElementById('message').value;
if(val=='')document.getElementById('message').value='Your Message';
}

function hide_msg()
{
val = document.getElementById('message').value;

if(val=='Your Message')document.getElementById('message').value='';
}
function chk_fields()
{
name = document.getElementById('name').value;
email = document.getElementById('email').value;
phone = document.getElementById('phone').value;
message = document.getElementById('message').value;

if( (name=='' || name=='Name' ) && (email=='' || email=='Email') && (phone=='' || phone=='Phone No.') && message=='' )
{
alert('Please fill in all the fields');
return false;
}
return true;
}

		
		function FormReset()
		{
			document.getElementById('phone').value='Phone No.';
			document.getElementById('email').value='Email';
			document.getElementById('name').value='Name';
			document.getElementById('message').value='';
		}
		</script> 
<link rel="stylesheet" href="general.css" type="text/css" media="screen" />
<script type="text/javascript" language="javascript" src="http://fbapps.webuildyoursocialmedia.com/legacy-corporate/jquery-1.4.4.min.js"></script>
<script type="text/javascript" src="easySlider.packed.js"></script>
<script src="jquery.faded.js" type="text/javascript"></script> 
	<script src="popup.js" type="text/javascript"></script>
<script type="text/javascript">
	function showdiv(pass,mode) { 
	 $("div[Group^=PopUp]").each(
				function() {
					$(this).css("display","none");
				}
				);
	 var Obj = $('#' + pass);
	 if (mode=='true')
				{
					Obj.css("display","");
				}
				else
				{
					Obj.css("display","none");
				}
	 } 
	 
	 $(function(){
	$("#faded").faded({
		speed: 2000,
		crossfade: true,
		bigtarget: false,
		autoplay: 8000,
		autorestart: 2000,
		random: false,
		autopagination:true
	});
});

$(document).ready(function(){	
		$("#slider").easySlider();
	});
	
function isemail(email)
{
return /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/.test(email);
}

	function formsubit()
	{
		if(document.getElementById('user_name').value=='*Full Name' || document.getElementById('user_name').value=='')
		{
			alert('Please Enter Your Name!');
			return false;
		}
		else if(document.getElementById('email').value=='*Email' || document.getElementById('email').value=='' || !isemail(document.getElementById('email').value))
		{
			alert('Please Enter Valid Email Address!');
			return false;
		}
		else if(!document.getElementById('eighteenYrs').checked)
		{
			alert('Please Confirm Your Age!');
			return false;
		}
		else
		{
		 $.post("ajax.php", $("#contactform").serialize(),
		function(data){
		if(data=='1'){Post();showdiv('popup_thank','true');} else alert('You have already entered the sweepstakes.');
		});
		}
	}
	
		function PopupCenter(pageURL, title,w,h) 
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
<div style="width:520px; height:756px; background:url(Content/images/Contest_cover.jpg) no-repeat;">
<a href="#" onClick="return showdiv('popup_form','true')" style="width:230px; height:55px; position:absolute; margin:511px 0 0 50px; "></a>
<a href="#" onclick="PopupCenter('privacy.html', 'Privacy Policy','800','700')" style="width:72px; height:13px; position:absolute; margin:640px 0 0 50px; "></a>
<a href="#" onclick="PopupCenter('official.html', 'Official Rules','800','700')" style="width:69px; height:13px; position:absolute; margin:587px 0 0 420px; "></a>
<div id="popup_form" Group="PopUp" style="display:none; margin:0px 0 0 0; position:absolute; z-index:3000000;">
<div style="width:520px; height:756px; background:url(Content/images/form.png) no-repeat;">
<div style="width:183px; height:193px; position:absolute; margin:325px 0 0 168px; ">
<form id="contactform">

<input type="text" style="width:160px; height:27px; margin:4px 0 0 10px; background:transparent; color:#807f7f; font-family:Arial, Helvetica, sans-serif; font-size:14px; border:0;" name="user_name" id="user_name"
value="*Full Name"
onfocus="if(this.value=='*Full Name')this.value=''"  onblur="if(this.value=='')this.value='*Full Name'"
/>

<input type="text" style="width:160px; height:27px; margin:22px 0 0 10px; background:transparent; border:0; color:#807f7f; font-family:Arial, Helvetica, sans-serif; font-size:14px;" name="email" value="*Email"  id="email"
onfocus="if(this.value=='*Email')this.value=''"  onblur="if(this.value=='')this.value='*Email'"
/>
<input type="hidden" name="page_id" value="<?php echo $data['page']['id'];?>" />

<input type="checkbox" name="eighteenYrs" id="eighteenYrs" style="width:20px; height:22px; margin:15px 0 0 4px; margin:22px 0 0 4px; background:transparent; border:0;" />

<input type="button" onClick="formsubit()" value="" style="width:177px; height:36px; margin:27px 0 0 2px; border:none; background:transparent; cursor:pointer; " />

</form>
</div>
</div>
</div>
<div id="popup_thank" Group="PopUp" style="display:none; margin:0px 0 0 0; position:absolute; z-index:3000000;">
<div style="width:520px; height:756px; background:url(Content/images/thank_you2.png) no-repeat;">
<a href="http://www.facebook.com/pages/Sweepstakes/<?php echo $data['page']['id'];?>?sk=app_88014730052" target="_top"  style="width:83px; height:25px; position:absolute; margin:446px 0 0 215px; "></a>
</div>
</div>
</div>

<?php }else{?>
<div style="width:520px; height:756px; background:url(Content/images/Contest_like.jpg) no-repeat;">
</div>
<?php
}

function parse_signed_request($signed_request, $secret) {
  list($encoded_sig, $payload) = explode('.', $signed_request, 2);

  // decode the data
  $sig = base64_url_decode($encoded_sig);
  $data = json_decode(base64_url_decode($payload), true);

  if (strtoupper($data['algorithm']) !== 'HMAC-SHA256') {
    error_log('Unknown algorithm. Expected HMAC-SHA256');
    return null;
  }

  // check sig
  $expected_sig = hash_hmac('sha256', $payload, $secret, $raw = true);
  if ($sig !== $expected_sig) {
    error_log('Bad Signed JSON signature!');
    return null;
  }

  return $data;
}

function base64_url_decode($input) {
  return base64_decode(strtr($input, '-_', '+/'));
}

function  fbname($id)
{
	$obj = json_decode(file_get_contents('https://graph.facebook.com/'.$id));
	return $obj->name;
}
?>
<iframe src="blank.html" name="my_frame" style="display:none" ></iframe>
</body>
</html>
