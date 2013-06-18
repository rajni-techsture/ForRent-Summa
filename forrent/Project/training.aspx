<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="training.aspx.vb" Inherits="tsma.training" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Total Social Media Application</title>
<link href="Content/css/inner.css" rel="stylesheet" type="text/css" />
    <script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
<script type="text/javascript">
function ShowVideoDiv(id,title)
	{
	    //document.getElementById('traning_vid2').style.display='none';	
		document.getElementById('youtubevideo2').src='';
		document.getElementById('youtubevideo2').src=id;
		document.getElementById('videotitle').innerHTML=title;
		//document.getElementById('myebook').style.display='none';	
		document.getElementById('videodiv2').style.display='';	
	}
</script>
</head>
<body>
<form id="frm" runat="server">
  <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
  <div id="innerpagepagemain"  >
    <uc1:inner ID="inner1" runat="server" />
    <div id="centermain">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="170" align="left" valign="top" class="leftbg"><uc3:left ID="left1" runat="server" />
          </td>
          <td align="left" valign="top" class="contentbody"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="30" align="left" valign="top"><h6>Your Online Training Center</h6></td>
              </tr>
              <tr>
                <td>Helping professionals launch smart Social Media Marketing <br />
                  so your business goals are accomplished</td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="581" align="left" valign="top"><div id="videodiv2">
                          <div id="videotitle" style=" font-family:Arial, Helvetica, sans-serif; font-weight:bold; padding-bottom:10px; font-size:12px; color:#000000;"></div>
                          <iframe src="http://issuu.com/wbysm/docs/_1_tsma_welcome_to_facebook?mode=embed&amp;viewMode=presentation&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true" id="youtubevideo2" allowtransparency="1" frameborder="0" scrolling="no" width="581" height="370" style="padding-top:5px;" ></iframe>
                        </div></td>
                      <td width="20" align="left" valign="top">&nbsp;</td>
                      <td align="left" valign="top" class="blueboxbg" style="padding:0px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="middle" class="blueboxtitle" >Facebook</td>
                          </tr>
                          <tr>
                            <td align="left" valign="top" style="padding-left:15px; padding-right:15px;"><div style="height:330px; overflow:auto; overflow-x:hidden">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/_1_tsma_welcome_to_facebook?mode=embed&amp;viewMode=presentation&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','Welcome')" class="graylink">Welcome</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/2_tsma_getting_started_-_fb_final?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','Getting Started')" class="graylink">Getting Started</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/3_tsma_three_facebook_pages?mode=embed&amp;viewMode=presentation&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','3 Types of Pages')" class="graylink">3 Types of Pages</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/Q_1JidCQsgY?feature=player_embedded','Request Friends')" class="graylink">Request Friends</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/fg0ahtWBwLM?feature=player_embedded','Confirm Friend')" class="graylink">Confirm Friend</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/hfNMwUFAIh8?feature=player_embedded','UnFriend')"  class="graylink">UnFriend</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/tsma_five_steps_to_launch_fan_page?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','5 Steps to Launch')"  class="graylink">5 Steps to Launch</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/zoykPVoqNrw?feature=player_embedded','Publish Page')"  class="graylink">Publish Page</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/tsma_establish_a_clear_brand_message?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','Brand Msg')"  class="graylink">Brand Msg</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/tsma_seo_power_of_name?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','SEO behind Name')" class="graylink">SEO behind Name</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/1svvyGnFkyk?rel=0','Settings')" class="graylink">Settings</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/tsma_posting_protocol?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','Posting Rules')" class="graylink">Posting Rules</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/tsma_first_wall_post_?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','Wall Posts')" class="graylink">Wall Posts</a></td>
                                  </tr>
                                  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/3ZVQG-PPC_c?rel=0','Beg Daily System')" class="graylink">Beg Daily System</a></td>
                                  </tr>
								  
								  
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/PlNK7RQzZhw?rel=0','Get More Fans')" class="graylink">Get More Fans</a></td>
                                  </tr>
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/_JcUSZPRfQs?rel=0','Optimize Image')" class="graylink">Optimize Image</a></td>
                                  </tr>
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/tsma_upload_a_photo_album?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','Upload Photos')" class="graylink">Upload Photos</a></td>
                                  </tr>
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/tsma_90-day_-_small_biz?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','90-Day Strategy')" class="graylink">90-Day Strategy</a></td>
                                  </tr>
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/b4XNOnljPF0?rel=0','Tag Videos')" class="graylink">Tag Videos</a></td>
                                  </tr>
								  
								  
								  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/tsma_promote_your_page?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','Promote Page')" class="graylink">Promote Page</a></td>
                                  </tr>
								  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/o1OzzGYOZgY?rel=0','Getting Seen!')" class="graylink">Getting Seen!</a></td>
                                  </tr>
								  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/A84YiyQfSUA?rel=0','Etiquette Tips')" class="graylink">Etiquette Tips</a></td>
                                  </tr>
								  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/bYvyqrT58aw?rel=0','Comment Mktg')" class="graylink">Comment Mktg</a></td>
                                  </tr>
								  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://issuu.com/wbysm/docs/tsma_daily_system?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true','Daily System')" class="graylink">Daily System</a></td>
                                  </tr>
								  
								  
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/Yug4MGk4nxo?rel=0','4 Metrics')" class="graylink">4 Metrics</a></td>
                                  </tr>
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/VJOPn41oQ0U?rel=0','Help Feature')" class="graylink">Help Feature</a></td>
                                  </tr>
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/RfLk00zduYM?rel=0','Engagement Ads')" class="graylink">Engagement Ads</a></td>
                                  </tr>
								  
								  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/IlOSRtcq5gs?rel=0','Quick Review')" class="graylink">Quick Review</a></td>
                                  </tr>
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/-RUdQxrc-LA?rel=0','Follow Up')" class="graylink">Follow Up</a></td>
                                  </tr>
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/fHwCpysBH3I?rel=0','QR Codes')" class="graylink">QR Codes</a></td>
                                  </tr>
								  <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/QBuScAN8hbI?rel=0','Live Event')" class="graylink">Live Event</a></td>
                                  </tr>
								   <tr>
                                    <td height="32" class="whiteborderdown"><a href="javascript:ShowVideoDiv('http://www.youtube.com/embed/64F-4OEU00U?rel=0','Plan a Wedding W/a page')" class="graylink">Plan a Wedding W/a page</a></td>
                                  </tr>
                                </table>
                              </div></td>
                          </tr>
                        </table></td>
                    </tr>
                  </table></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
            </table></td>
        </tr>
      </table>
    </div>
  </div>
  <uc2:inner ID="inner2" runat="server" />
</form>
</body>
</html>
