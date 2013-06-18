<?php
session_start();
include("includes.php");
include_once("header.php");
$user_row = $me ; 
?>
<style type="text/css">
<!--
a:link {
	text-decoration: none;
}
a:visited {
	text-decoration: none;
}
a:hover {
	text-decoration: none;
}
a:active {
	text-decoration: none;
}
.scroll{
height:330px;width:190px;margin-top:10px;overflow:scroll;overflow-x:hidden;
}
-->
</style>
<table width="720" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td align="center" valign="top" style="text-align:center; padding:27px; padding-bottom:0px"><table width="667" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td style="background-image:url(images/facebook_dashboard_small_business.png); background-position:top; background-repeat:no-repeat; height:25px; text-align:left"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="52" height="25" align="left" valign="top">&nbsp;</td>
            <td width="86" align="left" valign="middle" style="text-align:left; font-family:Verdana; font-size:11px; color:#186da1; font-weight:bold"><?php echo $user_row['name'];?></td>
            <td align="left" valign="middle" style="text-align:left; font-family:Verdana; font-size:11px; color:#636363;"><a href="#"><font color="#636363"><!--Log Out</font></a><img src="images/facebook_dashboard_home_dentist_top_gray_arrow.png" width="6" height="9" style="margin-left:4px"/>--></td>
            <td align="left" valign="top">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="200" align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_dentist_logo_img.png); background-position:top; background-repeat:no-repeat; height:200px; text-align:left"><div style="padding-left:230px; padding-top:12px">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="37" align="left" valign="top" style="text-align:left"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="315" align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_dentist_compose_your_message_bg.png); background-position:left; background-repeat:no-repeat; width:310px; height:37px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="252" height="31" align="left" valign="middle" style="text-align:left; font-family:Verdana; font-size:11px; color:#636363; padding-left:11px"><input type="text"  style="border:none" value="Compose Your Message" size="40" /> </td>
                      <td align="left" valign="middle" style="text-align:left; font-family:Verdana; font-size:9px; color:#636363; padding-left:7px">140</td>
                    </tr>
                  </table></td>
                  <td width="122" align="left" valign="bottom" style="text-align:left"><a href="#"><img src="images/facebook_dashboard_home_dentist_post_it_button.png" width="96" height="32" border="0" align="top" /></a></td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="101" align="left" valign="top">&nbsp;</td>
            </tr>
            <tr>
              <td height="50" align="left" valign="top"><div style="background-image:url(images/facebook_dashboard_home_dentist_panel_buttons_bg.png); background-position:left; background-repeat:no-repeat; width:413px; height:45px;">
                <div style="padding-top:9px ; text-align:left"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="8"></td>
                    <td width="26" align="left" valign="top"><a href="#"><img src="images/facebook_dashboard_home_dentist_panel_facebook_icon.png" width="21" height="20" border="0" align="top" /></a></td>
                    <td width="27" align="left" valign="top"><a href="#"><img src="images/facebook_dashboard_home_dentist_panel_twee_icon.png" width="21" height="20" border="0" align="top" /></a></td>
                    <td width="84" align="left" valign="top"><a href="#"><img src="images/facebook_dashboard_home_dentist_trivia_button.png" width="78" height="25" border="0" align="top" /></a></td>
                    <td width="90" align="left" valign="top"><a href="#"><img src="images/facebook_dashboard_home_dentist_holidays_button.png" width="87" height="25" border="0" align="top" /></a></td>
                    <td align="left" valign="top"><a href="#"><img src="images/facebook_dashboard_home_dentist_Industry_news_button.png" width="168" height="25" border="0" align="top" /></a></td>
                    <td align="left" valign="top">&nbsp;</td>
                  </tr>
                </table></div>
              </div></td>
            </tr>
          </table>
        </div></td>
      </tr>
      <tr>
        <td height="442" align="left" valign="top" style="background-image:url(images/facebook_dashboard_home_dentist_center_bg.png); background-position:top; background-repeat:no-repeat; height:442px; text-align:left"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="25" align="left" valign="top">&nbsp;</td>
            <td align="left" valign="top" style=" background-image:url(images/facebook_dashboard_home_dentist_facebook_center_box_bg.png); background-position:top left; background-repeat:no-repeat; width:619px; height:389px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="205" align="left" valign="top"><table width="205" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="34" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="34" height="34" align="right" valign="middle"><a href="#"><img src="images/facebook_dashboard_home_dentist_facebook_blue_icon.png" width="25" height="25" border="0" align="top" /></a></td>
                        <td align="left" valign="middle" style="text-align:left; font-family:Verdana; font-size:12px; color:#ffffff; font-weight:bold; text-transform:uppercase; padding-left:9px" >Pending Posts</td>
                        <td width="34" align="center" valign="middle"><a href="#"><img src="images/facebook_dashboard_home_dentist_refresh_icon.png" width="16" height="13" border="0" align="top" /></a></td>
                      </tr>
                    </table></td>
                  </tr>
                  <tr>
                    <td align="left" valign="top" style="padding-left:10px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top"><div class="scroll"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                                </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                                </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                                </tr>
                              </table></td>
                          </tr>
                          <tr>
                            <td align="left" valign="top" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td align="left" valign="top" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td align="left" valign="top" style="padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                          </table></div></td>
                       
                        </tr>
                      </table></td>
                  </tr>
                </table></td>
                <td width="205" align="left" valign="top"><table width="205" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="34" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="34" height="34" align="right" valign="middle"><a href="#"><img src="images/facebook_dashboard_home_dentist_facebook_blue_icon.png" width="25" height="25" border="0" align="top" /></a></td>
                        <td align="left" valign="middle" style="text-align:left; font-family:Verdana; font-size:12px; color:#ffffff; font-weight:bold; text-transform:uppercase; padding-left:9px" >Sent Posts</td>
                        <td width="34" align="center" valign="middle"><a href="#"><img src="images/facebook_dashboard_home_dentist_refresh_icon.png" width="16" height="13" border="0" align="top" /></a></td>
                      </tr>
                    </table></td>
                  </tr>
                  <tr>
                    <td align="left" valign="top" style="padding-left:10px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top"><div class="scroll"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td align="left" valign="top" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td align="left" valign="top" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td align="left" valign="top" style="padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                        </table> </div></td>
                        
                      </tr>
                    </table></td>
                  </tr>
                </table></td>
                <td align="left" valign="top"><table width="205" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="34" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="34" height="34" align="right" valign="top"><a href="#"><img src="images/facebook_dashboard_home_dentist_library_icon.png" width="25" height="28" border="0" align="top" style="margin-top:4px" /></a></td>
                        <td align="left" valign="middle" style="text-align:left; font-family:Verdana; font-size:12px; color:#ffffff; text-transform:uppercase; padding-left:7px" ><b>LIBRARY</b><span style="text-align:left; font-family:Verdana; font-size:9px; color:#ffffff; padding-left:5px " >(Trivia)</span></td>
                        </tr>
                      </table></td>
                  </tr>
                  <tr>
                    <td align="left" valign="top" style="padding-left:10px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" valign="top"><div class="scroll"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_library_calendar_icon.png" width="12" height="13" border="0" align="top" style="margin-right:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td align="left" valign="top" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-transform:uppercase" >Headline</span><br />
                                  0:00am via Post-N-Leap</td>
                              </tr>
                              <tr>
                                <td align="left" valign="top" style="text-align:left; font-family:Verdana; font-size:11px; color:#000000; padding-bottom:10px" >Your Message Here</td>
                              </tr>
                              <tr>
                                <td height="13" align="right" valign="top" style="text-align:right"><a href="#"><img src="images/facebook_dashboard_home_dentist_library_calendar_icon.png" width="12" height="13" border="0" align="top" style="margin-right:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_edit_icon.png" width="14" height="13" border="0" align="top"/></a><a href="#"><img src="images/facebook_dashboard_home_dentist_delete_icon.png" width="8" height="13" border="0" align="top"  style="margin-right:2px; margin-left:3px" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_filter_icon.png" width="11" height="13" border="0" align="top" /></a><a href="#"><img src="images/facebook_dashboard_home_dentist_repost_icon.png" width="17" height="13" border="0" align="top" style="margin-left:2px" /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td align="left" valign="top" style="border-bottom:1px solid #186da1; padding-bottom:4PX; padding-top:12px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td align="left" valign="top"  style="text-align:left; font-family:Verdana; font-size:9px; color:#464646; padding-bottom:5px " ><span style="text-align:left; font-family:Verdana; font-size:12px; color:#e53f66; font-weight:bold; text-tr