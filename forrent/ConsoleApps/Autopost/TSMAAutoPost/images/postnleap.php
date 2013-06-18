<?php
include_once("includes.php");
include_once("header.php");
$client_type = 'Mortgages' ;
$user_row = $me ; 
$start = isset($_REQUEST['start'])?$_REQUEST['start']:0;
$pages =  pages($user_id) ;  
?>
<script>

function setPostValues(message,videourl,url,image)
{
	ele('message').focus();		
	setValue('message',message);setValue('videourl',videourl);setValue('url',url);setValue('image',image);		
}

function commentspopup(url)
{
	newwindow=window.open(url,'Facebook','location=0,scrollbars=0,height=550,width=485');
	if (window.focus) {newwindow.focus()}
}

function post()
{
 	hide('url_form');hide('video_form');hide('image_form');hide('optionbar');
	
	if(getValue('message')=='' || getValue('message')=='Compose Your Message')
	{
		falert('Please Compose Message');
	} 
	else 
	{
		if(validimage() && youTubeId(getValue('videourl')))
		{
			document.getElementById('PostForm').submit();
			show('spinner');
			setValue('message','Compose Your Message');
		}
	}
}


function refreshPending()
{
	done=null;ajax('ajax.php?delSent=0&type=Pending','PostForm','PendingPost');
}

function setSchedule()
{
	done='Schedule has been set.';
	if(getValue('message')=='' || getValue('message')=='Compose Your Message')
	{
		falert('Please Compose Message');
	} 
	else 
	{
		ajax('ajax.php?setSchedule','PostForm','PendingPost');
		setValue('message','Compose Your Message');
		hide('callender');
		callenderReset();
	}
}


function setSchedule2()
{
	setValue('schedule',1);
 	hide('url_form');hide('video_form');hide('image_form');hide('optionbar');
	
	if(getValue('message')=='' || getValue('message')=='Compose Your Message')
	{
		falert('Please Compose Message');
	} 
	else 
	{
		if(validimage() && youTubeId(getValue('videourl')))
		{
			document.getElementById('PostForm').submit();
			show('spinner');
			setValue('message','Compose Your Message');
		}
	}
}
				  
</script>
<form method="post" action="post.php" target="iframe" name="PostForm" id="PostForm" enctype="multipart/form-data">
<table width="689" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="82" align="left" valign="top" rel="background-image:url(images/facebook_dashboard_msma_post_n_leap_centerbox_top.png); background-repeat:no-repeat; background-position:top; height:136px;">
		
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="41" align="left" valign="top"><img src="images/facebook_mysma_postnleap_post_n_leap_user.png" width="298" height="32" /></td>
          </tr>
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td align="left" valign="top"><a href="#" onclick="youtubeVideo('VUONlhaQ05E')"  ><img src="images/facebook_mysma_design_tutorial_video.png" width="170" height="48" border="0" /></a></td>
                </tr>
              <tr>
                <td height="36" align="left" valign="top"><img src="images/facebook_mysma_design_tutorial_video_shadow.png" width="170" height="25" /></td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <td align="left" valign="top"><table width="687" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="13"><img src="images/facebook_mysma_postnleap_compose_your_message_top.png" width="687" height="13" /></td>
              </tr>
              <tr>
                <td style="background-image: url(images/facebook_mysma_postnleap_compose_your_message_bg.png); background-position:top; background-repeat:repeat-y;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="26">&nbsp;</td>
                    <td width="601" height="23" valign="top" style="font-family:Verdana, Geneva, sans-serif; font-size:11px; color:#505050"><textarea  
                    style="border:none;width:100%;height:40px;text-align:left; font-family:Verdana; font-size:11px; color:#636363;" value="Compose Your Message" size="40" onfocus="show('optionbar');if(this.value=='Compose Your Message')this.value='';" onblur="if(this.value=='')this.value='Compose Your Message';"  onkeyup="ChLenghtLimit('message',420);" id="message" name="message" >Compose Your Message</textarea></td>
                    <td width="60" height="23" valign="top" style=" "><div style="background-image:url(images/facebook_mysma_postnleap_compos_messagesmall_box_bg.png); width:44px; height:25px; background-position:left; background-repeat:no-repeat;; "><div style="padding-left:10px; padding-top:5px; font-family:Verdana, Geneva, sans-serif; font-size:9px; color:#505050" id="count">420</div></div><input type="hidden" name="user_id" value="<?php echo $user_id ;?>" /><input type="hidden" name="vid" value="0" id="vid" /><input type="hidden" name="image" value="" id="image" /></td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td height="18"><img src="images/facebook_mysma_postnleap_compose_your_message_down.png" width="687" height="18" /></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td align="left" valign="top" height="45">
           <div id="optionbar" style="display:none;">
			  <div  style="background-image:url(images/facebook_mysma_postnleap_green_strip_bg.png); background-position:left; background-repeat:no-repeat; width:412px; height:38px;">
                <div style="padding-top:5px; padding-left:12px; text-align:left"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
  <td width="29" align="left" valign="middle" style="text-align:left">
  <img  src="images/facebook_mysma_postnleap_post_now.png" width="61" height="30" style="position:absolute;margin-left:-22px;margin-top:-25px;display:none" id="tooltip_post" />
  <a href="#" onclick="toggle('postdiv');hide('attachment');hide('draft');hide('callender')"><img src="images/facebook_mysma_postnleap_post_now_icon.png" width="20" height="22" border="0" align="top"  onmouseover="show('tooltip_post')" onmouseout="hide('tooltip_post')" /></a></td>
    <td width="33" align="left" valign="middle" style="text-align:left">
	<img src="images/facebook_dashboard_home_dentist_schedule.png" width="66" height="29" style="position:absolute;margin-left:-22px;margin-top:-25px;display:none" id="tooltip_calc" />
	<a href="#" onclick="hide('postdiv');hide('attachment');hide('draft');toggle('callender')">	
	<img src="images/facebook_dashboard_home_dentist_calendar_icon.png" width="20" height="21" border="0" align="top"  onmouseover="show('tooltip_calc')" onmouseout="hide('tooltip_calc')"/></a></td>
    <td width="32" align="left" valign="middle" style="text-align:left">
	<img src="images/facebook_dashboard_home_dentist_attachment.png" width="66" height="29" style="position:absolute;margin-top:-25px;margin-left:-19px;;display:none"  id="toottip_attach" />
	<a href="#" onclick="hide('postdiv');hide('callender');hide('draft');toggle('attachment');"><img src="images/facebook_dashboard_home_dentist_attachment_icon.png" width="22" height="21" border="0" align="top" onmouseover="show('toottip_attach')" onmouseout="hide('toottip_attach')" /></a></td>
    <td width="26" align="left" valign="middle" style="text-align:left">
	<img src="images/facebook_dashboard_home_dentist_save.png" width="48" height="29" style="position:absolute;margin-top:-25px;margin-left:-13px;display:none" id="toottip_save" />
	<a href="#" onclick="done='Draft Saved.';if(getValue('message')=='' || getValue('message')=='Compose Your Message'){falert('Please Compose Message');} else {ajax('ajax.php?savedarft','PostForm','draftlist');setValue('message','Compose Your Message')}"><img src="images/facebook_dashboard_home_dentist_save_icon.png" width="18" height="19" border="0" align="top" onclick="hide('postdiv');hide('callender');hide('attachment');hide('draft')"  onmouseover="show('toottip_save')" onmouseout="hide('toottip_save')" /></a></td>
    <td width="250" align="left" valign="middle" style="text-align:left">
	<img src="images/facebook_dashboard_home_dentist_draft.png" width="77" height="29" style="position:absolute;margin-top:-24px;margin-left:-26px;display:none" id="toottip_draft" />
	<a href="#"><img src="images/facebook_dashboard_home_dentist_draft_icon.png" width="20" height="23" border="0" align="top" onmouseover="show('toottip_draft')" onmouseout="hide('toottip_draft')" onclick="hide('postdiv');hide('callender');hide('attachment');toggle('draft')"  /></a></td>
    <td width="28" align="left" valign="middle" style="text-align:left"><a href="#" onclick="hide('optionbar');hide('callender');hide('attachment');hide('draft')"><img src="images/facebook_dashboard_home_dentist_close_icon.png" width="9" height="9" border="0" align="top" /></a></td>
  </tr>
</table>
</div>
              </div>
			  <div id="postdiv" style="position:absolute;z-index:100;display:none;">
              <table width="410" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="410" height="10" align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_celender_top.png); width:411px; height:10px; background-repeat:no-repeat; background-position:top;"><img src="images/t.png" width="9" height="9" /></td>
      </tr>
      <tr>
        <td align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_celender_bg.png); width:381px; background-repeat:repeat-y; background-position:top; padding-left:15px; padding-right:15px; padding-top:13px; padding-bottom:13px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="24" align="left" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td align="left" valign="top" style="padding-left:10px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="110" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="30" align="center" valign="top" style="font-family:Verdana; font-size:10px; text-align:center">Select Your<br />
                    Social Media</td>
                </tr>
                <tr>
                  <td align="center" valign="top" style="text-align:center">&nbsp;</td>
                </tr>
              </table></td>
              <td align="left" valign="top" style="padding-left:5px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left" valign="top" style="text-align:left">	
                  <div style="width:280px;max-height:220px;overflow:scroll;overflow-x:hidden;">						 							
                  <a href="#_" onclick="chk2fanpage('wall')" title="Facebook Wall" ><div style="background:url(images/facebook-icon-35x35.jpg) no-repeat;width:40px;height:40px;float:left">
							   <img src="images/CheckMark_20x20.png" style="vertical-align:top;float:left" width="15" id="mark2wall"/>
							   
							 </div></a>

                    <script>
							
							  
							  function chk2fanpage(id){
	
								chk=document.getElementById('chk'+id).value;
									if(chk!='0')
									{
										document.getElementById('mark2'+id).src ="images/t.png"; 
										setValue('chk'+id,0); 
									}
									else
									{
										document.getElementById('mark2'+id).src ="images/CheckMark_20x20.png";
										setValue('chk'+id,id);
									}	
									
									if('chkwall'!='chk'+id )
							 		{
								 		document.getElementById('mark2wall').src ="images/t.png";
										setValue('chkwall',0); 
							 		}
	
<?php
							 
							 foreach($pages as $val)
							 {
							 ?>
							 		if('chk<?php echo $val[id];?>'!='chk'+id )
									{
										document.getElementById('mark2<?php echo $val[id];?>').src ="images/t.png";
										setValue('chk<?php echo $val[id];?>',0);
									}
							 <?php
							 }
							 ?>
							  }		
							  
							  </script>

							 
							 <?php
							 foreach($pages as $val)
							 {
							 ?>
							 <a href="#_" onclick="chk2fanpage('<?php echo $val[id];?>')" title="<?php echo $val[name];?>"> 
							 <div style="background:url(crop.php?filename=http://graph.facebook.com/<?php echo $val[id];?>/picture?type=square&&size=35) no-repeat;width:40px;height:40px;float:left" >
							   <img src="images/t.png" style="vertical-align:top;float:left" width="15" id="mark2<?php echo $val[id];?>"/>
							 	
							 </div>
							 </a>
							 <?php
							 }
							 ?>
                             </div>
                             </td>
                </tr>
                <tr>
                  <td height="22" align="left" valign="middle" style="font-family:Verdana; font-size:9px; text-align:left">Click Above Icon(s) to choose which to post to.</td>
                </tr>
              </table></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td height="10"></td>
        </tr>
        <tr>
          <td align="right" valign="top" style="padding-right:10px"><a href="#" onclick="post();"><img src="images/facebook_mysma_postnleap_post_message_now.png" width="169" height="30" border="0" align="top" /></a></td>
        </tr>
      </table>
        </td>
      </tr>
      <tr>
        <td height="10" align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_celender_down.png); width:411px; height:10px; background-repeat:no-repeat; background-position:top;"><img src="images/t.png" width="9" height="9" /></td>
      </tr>
    </table>
			  </div>
              <div id="callender" style="position:absolute;z-index:100;display:none;margin-left:30px;">
			  <table width="411" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="10" align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_celender_top.png); width:411px; height:10px; background-repeat:no-repeat; background-position:top;"><img src="images/t.png" width="9" height="9" /></td>
                </tr>
                <tr>
                  <td align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_celender_bg.png); width:381px; background-repeat:repeat-y; background-position:top; padding-left:15px; padding-right:15px; padding-top:13px; padding-bottom:13px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td width="190" align="left" valign="top"><div id="datepicker" style="font-size:10px;"></div></td>
                          <td width="15" align="left" valign="top">&nbsp;</td>
                          <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td height="29" align="left" valign="middle" style="font-family:Georgia; font-size:14px; color:#186da1; font-weight:bold; text-align:left">Schedule Your Post</td>
                            </tr>
                            <tr>
                              <td height="32" align="left" valign="top" style="text-align:left"><input id="actualDate" name="date" type="text"  style="width:165px; font-family:Verdana; padding-left:3px; font-size:10px; height:18px; border:1px solid #9f9f9f;" value=""  /></td>
                            </tr>
                            <tr>
                              <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="62%" style="text-align:left">
								  <select name="hr" style="font-family:Verdana; font-size:10px; height:21px; border:1px solid #9f9f9f;">
								  <?php
								  $hours = range(1,12);
								  $strtime = time();
								  foreach($hours as $hr)
								  {
									if($hr<10)$hr="0$hr";
									if($strtime!='' && date("g",$strtime)==$hr)$selected='selected';else $selected='';
									echo "<option value='$hr' $selected >$hr</option>";
								  }
								  ?>
								</select>
								    :
                                    <select name="select3" style="font-family:Verdana; font-size:10px; height:21px; border:1px solid #9f9f9f;" id="select4">
                                      <option>00</option>
                                    </select></td>
                                  <td width="16%" align="center" style="font-family:Verdana; font-size:10px; text-align:center"><input type="radio" name="ampm" value="am" <?php echo date("a",$strtime)=='am'?'checked':'';?> />
                                    <br />
                                    AM</td>
                                  <td width="22%" align="center" style="font-family:Verdana; font-size:10px; text-align:center"><input type="radio" name="ampm" value="pm" <?php echo date("a",$strtime)=='pm'?'checked':'';?> />
                                    <br />
                                    PM</td>
                                </tr>
                              </table></td>
                            </tr>
                            <tr>
                              <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="26" style="text-align:left">
								  <input type="checkbox" name="notify" id="notify" value="1" />
								  <input type="hidden" name="schedule" id="schedule" value="0" />
								  </td>
                                  <td height="45" style="text-align:left"><span style="font-family:Verdana; font-size:10px;">Notify me by email that message has been sent.</span></td>
                                </tr>
                              </table></td>
                            </tr>
                            <tr>
                              <td align="left" valign="top" style="text-align:left"><a href="#"  onclick="setSchedule2();"><img src="images/facebook_dashboard_home_dentist_schedule_it_now.png" width="167" height="25" border="0" align="top" /></a></td>
                            </tr>
                          </table></td>
                        </tr>
                      </table></td>
                    </tr>
                    <tr>
                      <td height="25" align="left" valign="top">&nbsp;</td>
                    </tr>
                    <tr>
                      <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td width="95" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td height="30" align="center" valign="top" style="font-family:Verdana; font-size:10px; text-align:center">Select Your<br />
                                Social Media</td>
                            </tr>
                            <tr>
                              <td align="center" valign="top" style="text-align:center"><!--<a href="#_" onclick="chkall()"><img src="images/facebook_dashboard_home_dentist_select_all.png" width="78" height="26" border="0" align="top" /></a>--></td>
                            </tr>
                          </table></td>
                          <td align="left" valign="top" style="padding-left:5px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td align="left" valign="top" style="text-align:left">
							  
							  <div style="width:280px;max-height:220px;overflow:scroll;overflow-x:hidden;">
							   <a href="#_" onclick="chkfanpage('wall')" title="Facebook Wall" ><div style="background:url(images/facebook-icon-35x35.jpg) no-repeat;width:40px;height:40px;float:left">
							   <img src="images/CheckMark_20x20.png" style="vertical-align:top;float:left" width="15" id="markwall"/>
							   <input type="hidden" name="fbwall" id="chkwall" value="fbwall" />
							 </div></a>
							 
							<!--twitter Publishing --> 
							 <!-- <a href="#"><img src="images/facebook_dashboard_home_dentist_icon2.png" width="35" height="36" hspace="5" border="0" align="top" /></a>-->
							 
							 
							 							  <script>
							
							  
							  function chkfanpage(id){
	
								chk=document.getElementById('chk'+id).value;
									if(chk!='0')
									{
										document.getElementById('mark'+id).src ="images/t.png"; 
										setValue('chk'+id,0); 
									}
									else
									{
										document.getElementById('mark'+id).src ="images/CheckMark_20x20.png";
										setValue('chk'+id,id);
									}	
									
									if('chkwall'!='chk'+id )
							 		{
								 		document.getElementById('markwall').src ="images/t.png";
										setValue('chkwall',0); 
							 		}
	
<?php
							 
							 foreach($pages as $val)
							 {
							 ?>
							 		if('chk<?php echo $val[id];?>'!='chk'+id )
									{
										document.getElementById('mark<?php echo $val[id];?>').src ="images/t.png";
										setValue('chk<?php echo $val[id];?>',0);
									}
							 <?php
							 }
							 ?>
							  }		
							  
							  </script>

							 
							 <?php
							 foreach($pages as $val)
							 {
							 ?>
							 <a href="#_" onclick="chkfanpage('<?php echo $val[id];?>')" title="<?php echo $val[name];?>"> 
							 <div style="background:url(crop.php?filename=http://graph.facebook.com/<?php echo $val[id];?>/picture?type=square&&size=35) no-repeat;width:40px;height:40px;float:left" >
							   <img src="images/t.png" style="vertical-align:top;float:left" width="15" id="mark<?php echo $val[id];?>"/>
							 	<input type="hidden" name="pages[]" id="chk<?php echo $val[id];?>" value="0" />
							 </div>
							 </a>
							 <?php
							 }
							 ?>
							  
							  </div>
							  </td>
                            </tr>
                            <tr>
                              <td height="22" align="left" valign="middle" style="font-family:Verdana; font-size:8px; text-align:left">Click Above Icon(s) to choose which to post to.</td>
                            </tr>
                          </table></td>
                        </tr>
                      </table></td>
                    </tr>
                  </table></td>
                </tr>
                <tr>
                  <td height="10" align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_celender_down.png); width:411px; height:10px; background-repeat:no-repeat; background-position:top;"><img src="images/t.png" width="9" height="9" /></td>
                </tr>
              </table>
			  </div>
			  
			  <div id="attachment" style="display:none;position:absolute;margin-left:25px; background-image:url(images/attachment_image.png); background-position:left; background-repeat:no-repeat; width:110px; height:34px;"><div style="padding-top:10px; padding-left:6px; text-align:left">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                   <td width="23" align="left" valign="top" style="text-align:left"><a href="#_" onclick="hide('image_form');hide('video_form');show('url_form');"><img src="images/t.png" width="30" height="20" border="0" align="top" /></a></td>
                    <td width="23" align="left" valign="top" style="text-align:left"><a href="#_" onclick="hide('url_form');hide('video_form');show('image_form')"><img src="images/t.png" width="30" height="20" border="0" align="top" /></a></td>
                    <td width="29" align="left" valign="middle" style="text-align:left"><a href="#_" onclick="hide('image_form');hide('url_form');show('video_form');"><img src="images/t.png" width="30" height="20" border="0" align="top" /></a></td>
                  </tr>
                </table>
              </div></div>
			  
			  <div id="draft" style="position:absolute;z-index:100;display:none;margin-left:28px;">
			  <table width="411" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="10" align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_message_center_top.png); width:411px; height:10px; background-repeat:no-repeat; background-position:top;"><img src="images/t.png" width="9" height="9" /></td>
                </tr>
                <tr>
                  <td align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_celender_bg.png); width:381px; background-repeat:repeat-y; background-position:top; padding-left:15px; padding-right:15px; padding-top:8px; padding-bottom:10px;"><div id="draftlist" style="text-align:left; font-family:Verdana; font-size:9px; color:#898989; font-weight:bold">
<?php				
$sql = "select * from draft where user_id='$user_id'";
$res = mysql_query($sql) or die($sql.mysql_error());
if(mysql_num_rows($res)>0)
{
?>
<table cellpadding="0" cellspacing="0">
<?php

	while($rows = mysql_fetch_assoc($res)){
	echo '<tr><td width=350 style="cursor:pointer" onclick="setValue(\'message\',\''.htmlentities($rows['message']).'\')">'.htmlentities($rows['message']).'</td><td><span style="cursor:pointer;color:red;" onclick="done = \'Draft Deleted.\';ajax(\'ajax.php?id='.$rows['id'].'&deldarft\',\'PostForm\',\'draftlist\')">Delete</span></td></tr>';
	}
?>
</table>
<?php
}
else
{
	echo 'No Draft Found!';
}
?>
				
				</div>
					
					</td>
                </tr>
                <tr>
                  <td height="10" align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_celender_down.png); width:411px; height:10px; background-repeat:no-repeat; background-position:top;"><img src="images/t.png" width="9" height="9" /></td>
                </tr>
              </table>
			  </div>
			  </div>
            </td>
          </tr>
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="245" align="left" valign="top"><a href="#" onclick="toggle('msg_cat_popup2')"><img src="images/facebook_mysma_postnleap_pre_written.png" width="235" height="29" border="0" align="top" /></a>
<div id="msg_cat_popup2" style="display:none;background-image:url(images/facebook_dashboard_msma_white_drop_down_bg.png); background-position:top; background-repeat:no-repeat; width:223px; height:118px; text-align:left; position:absolute; ">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="20"></td>
      </tr>
      <tr>
        <td height="75" align="left" valign="top" style="padding-left:14px; text-align:left; font-family:Verdana, Geneva, sans-serif; font-size:12px; color:#186da0; line-height:23px"><a href="#" onclick="show('trivia_div');hide('holidays_div');hide('industry_div');$('#client_text').html('Trivia');hide('msg_cat_popup')"><font color="#186da0">Trivia</font></a><br />
          <a href="#" onclick="hide('trivia_div');show('holidays_div');hide('industry_div');$('#client_text').html('Holidays');hide('msg_cat_popup')"><font color="#186da0">Holidays</font></a><br />
          <a href="#" onclick="hide('trivia_div');hide('holidays_div');show('industry_div');$('#client_text').html('Industry News');hide('msg_cat_popup')"><font color="#186da0">Industry News</font></a></td>
      </tr>
      <tr>
        <td align="right" valign="top" style="text-align:right; padding-right:17px"><a href="#" onclick="hide('msg_cat_popup')"><img src="images/facebook_dashboard_home_dentist_close_icon.png" width="9" height="9" border="0" align="top" /></a></td>
      </tr>
    </table>
  </div>  
                </td>
                <td height="27" align="left" valign="top" style="text-align:left; padding-right:21px;"><a href="#"><img src="images/facebook_mysma_facebook_icon.png" width="21" height="20" border="0" align="top" /></a>&nbsp;<a href="#"><img src="images/facebook_mysma_twitter_icon.png" width="21" height="20" border="0" align="top" /></a></td>
                </tr>
              </table></td>
          </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td height="435" align="left" valign="top" style="background-image:url(images/facebook_dashboard_msma_post_n_leap_centerbox_downch.png); background-repeat:no-repeat; background-position:top; height:468px; text-align:center"><table width="100%" height="430" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td align="left" valign="top" style="text-align:left"><table width="100%" height="387" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td width="220" height="387" align="left" valign="top" style="text-align:left"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="34" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="34" height="34" align="right" valign="top"><a href="#"><img src="images/facebook_dashboard_home_dentist_library_icon.png" width="25" height="28" border="0" align="top" style="margin-top:4px" /></a></td>
                        <td align="left" valign="middle" style="text-align:left; font-family:Verdana; font-size:12px; color:#ffffff; text-transform:capitalize; padding-left:7px" ><b>LIBRARY</b><span style="text-align:left; font-family:Verdana; font-size:9px; color:#ffffff; padding-left:5px " >(<span id="client_text">Trivia</span>)</span></td>
                      </tr>
                    </table></td>
                  </tr>
                  <tr>
                    <td align="left" valign="top" style="padding-left:15px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top" colspan="2">
						<div class="scroll" id="client_type">
						
						<div id="trivia_div">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <?php
						  
						  $sql = "select * from  $client_type where  type='Trivia' and status='1' order by date desc";	
						  $res = mysql_query($sql) or die($sql.mysql_error());
						  
						  if(mysql_num_rows($res)>0)
						  {
						  	while($rows = mysql_fetch_assoc($res))
						 	{
						 	 ?>
						  <tr>
                            <td align="left" valign="top" class="filter3" rel="<?php echo htmlentities($rows['message']);?>" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px">
							<?PHP
							make_post_library_div($rows);
							/*	
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><!--<span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />-->
                                  9:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" ><?php echo htmlentities($rows['message']);?></td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><img src="images/facebook_dashboard_home_dentist_schedule_blue.png" id="cal_hover<?php echo $rows['id'];?>" width="63" height="28" border="0" align="top"  style="display:none;position:absolute;margin-left:-22px;margin-top:-23px;"/>
								<img src="images/facebook_dashboard_home_dentist_filter.png" id="filter_hover<?php echo $rows['id'];?>" width="53" height="28" align="top" style="display:none;position:absolute;margin-left:-6px;margin-top:-23px;" />
								<img src="images/facebook_dashboard_home_dentist_repost.png" id="repost_hover<?php echo $rows['id'];?>" width="54" height="28" align="top" style="display:none;position:absolute;margin-left:10px;margin-top:-23px;" /> <a href="#_" onmouseover="show('cal_hover<?php echo $rows['id'];?>')" onmouseout="hide('cal_hover<?php echo $rows['id'];?>')" onclick="show('optionbar');show('callender');setValue('message','<?php echo htmlentities($rows['message']);?>')"><img src="images/facebook_dashboard_home_dentist_library_calendar_icon.png" width="12" height="13" border="0" align="top" style="margin-right:3px" /></a><a href="#_" onmouseover="show('filter_hover<?php echo $rows['id'];?>')" onmouseout="hide('filter_hover<?php echo $rows['id'];?>')" onclick="show('srch3')"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#" onmouseover="show('repost_hover<?php echo $rows['id'];?>')" onmouseout="hide('repost_hover<?php echo $rows['id'];?>')" onclick="setValue('message','<?php echo htmlentities($rows['message']);?>');ele('message').focus();"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table>
							*/
							?>
							</td>
                          </tr>
						 	<?php
							}
						 }
						 else
						 {
						 echo '<div align="center"  style="font-family:Verdana, Geneva, sans-serif;font-size:12px;color:#093;">No Feed Found!</div>';
						 }
						 ?>	
                        </table>
						</div>
						
						<div id="holidays_div" style="display:none">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <?php
						  
						  $sql = "select * from  $client_type where  type='Holidays' and status='1' order by date desc";	
						  $res = mysql_query($sql) or die($sql.mysql_error());
						  
						  if(mysql_num_rows($res)>0)
						  {
						  	while($rows = mysql_fetch_assoc($res))
						 	{
						 	 ?>
						  <tr>
                            <td align="left" valign="top" class="filter3" rel="<?php echo htmlentities($rows['message']);?>" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px">
							<?PHP
							make_post_library_div($rows);
							/*	
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><!--<span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />-->
                                  9:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" ><?php echo htmlentities($rows['message']);?></td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><img src="images/facebook_dashboard_home_dentist_schedule_blue.png" id="cal_hover<?php echo $rows['id'];?>" width="63" height="28" border="0" align="top"  style="display:none;position:absolute;margin-left:-22px;margin-top:-23px;"/>
								<img src="images/facebook_dashboard_home_dentist_filter.png" id="filter_hover<?php echo $rows['id'];?>" width="53" height="28" align="top" style="display:none;position:absolute;margin-left:-6px;margin-top:-23px;" />
								<img src="images/facebook_dashboard_home_dentist_repost.png" id="repost_hover<?php echo $rows['id'];?>" width="54" height="28" align="top" style="display:none;position:absolute;margin-left:10px;margin-top:-23px;" /> <a href="#_" onmouseover="show('cal_hover<?php echo $rows['id'];?>')" onmouseout="hide('cal_hover<?php echo $rows['id'];?>')" onclick="show('optionbar');show('callender');setValue('message','<?php echo htmlentities($rows['message']);?>')"><img src="images/facebook_dashboard_home_dentist_library_calendar_icon.png" width="12" height="13" border="0" align="top" style="margin-right:3px" /></a><a href="#_" onmouseover="show('filter_hover<?php echo $rows['id'];?>')" onmouseout="hide('filter_hover<?php echo $rows['id'];?>')" onclick="show('srch3')"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#" onmouseover="show('repost_hover<?php echo $rows['id'];?>')" onmouseout="hide('repost_hover<?php echo $rows['id'];?>')" onclick="setValue('message','<?php echo htmlentities($rows['message']);?>');ele('message').focus();"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table>
							*/
							?>
							
							</td>
                          </tr>
						 	<?php
							}
						 }
						 else
						 {
						 echo '<div align="center"  style="font-family:Verdana, Geneva, sans-serif;font-size:12px;color:#093;">No Feed Found!</div>';
						 }
						 ?>	
                        </table>
						</div>
						
						<div id="industry_div" style="display:none">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <?php
						  
						  $sql = "select * from  $client_type where  type='Industry' and status='1' order by date desc";	
						  $res = mysql_query($sql) or die($sql.mysql_error());
						  
						  if(mysql_num_rows($res)>0)
						  {
						  	while($rows = mysql_fetch_assoc($res))
						 	{
						 	 ?>
						  <tr>
                            <td align="left" valign="top" class="filter3" rel="<?php echo htmlentities($rows['message']);?>" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px">
							<?PHP
							make_post_library_div($rows);
							/*	
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><!--<span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />-->
                                  9:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" ><?php echo htmlentities($rows['message']);?></td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><img src="images/facebook_dashboard_home_dentist_schedule_blue.png" id="cal_hover<?php echo $rows['id'];?>" width="63" height="28" border="0" align="top"  style="display:none;position:absolute;margin-left:-22px;margin-top:-23px;"/>
								<img src="images/facebook_dashboard_home_dentist_filter.png" id="filter_hover<?php echo $rows['id'];?>" width="53" height="28" align="top" style="display:none;position:absolute;margin-left:-6px;margin-top:-23px;" />
								<img src="images/facebook_dashboard_home_dentist_repost.png" id="repost_hover<?php echo $rows['id'];?>" width="54" height="28" align="top" style="display:none;position:absolute;margin-left:10px;margin-top:-23px;" /> <a href="#_" onmouseover="show('cal_hover<?php echo $rows['