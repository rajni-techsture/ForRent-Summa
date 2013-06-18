<%@ Page Language="vb" AutoEventWireup="false"  CodeBehind="custom-tab-home.aspx.vb" Inherits="tsma.custom_tab_home" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Total Social Media Application</title>
    <script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
	<script type="text/javascript" src="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
	<link rel="stylesheet" type="text/css" href="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <script type="text/javascript" src="Content/js/fancybox/fancybox/video.js"></script>
    <link href="Content/facebookalert/facebookalert_files/facebook.alert.css" rel="stylesheet" type="text/css">
	<script type="text/javascript">
		function DeleteCustomTab()
		{
			__doPostBack("lnkdelete1", "");
		}
		
		function DeleteAlert()
				{
				    //$("#spnMessage").html(mess);
					var maskHeight = $(document).height();
					var maskWidth = $(window).width();
					$('#DivSaveSidebar').css({'width':maskWidth,'height':maskHeight});
					$("#DivSaveSidebar").show("slow");
				}
				function HideDeleteAlert() {
				    $("#DivSaveSidebar").hide("slow");
				}
				function CopyCustomTab() {
				    __doPostBack("lnkCopy", "");
				}
				function CopyAlert(mess) {
					var maskHeight = $(document).height();
					var maskWidth = $(window).width();
					$('#DivCopyCustomTab').css({'width':maskWidth,'height':maskHeight});
				    $("#spnCopyMessage").html(mess);
				    $("#DivCopyCustomTab").show("slow");
				}
				function HideCopyAlert() {
				    $("#DivCopyCustomTab").hide("slow");
				}
		</script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div id="DivSaveSidebar" style="width:100%; height:750px;; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:10000000; text-align:center;padding-top:200px; padding-left:170px; display:none;">
			  <div id="popup_container1" style="width:450px; height:85px">
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  <font color="#FF0000">Warning!  This action will delete the custom tab from facebook business pages associated with it and from all its administrators' accounts</font><br/><br/>
                   <input type="button" class="inputbutton" onclick="DeleteCustomTab();" style="cursor:pointer" value="Yes" id="popup_yes" />
                   <input type="button" class="inputbutton" onclick="HideDeleteAlert();" style="cursor:pointer" value="No" id="popup_close" />
				</div>
			 </div>
			 </div>
             <div id="DivCopyCustomTab" style="width:100%; height:750px;; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:10000000; text-align:center;padding-top:200px; padding-left:170px; display:none;">
			  <div id="popup_container1">
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  <font color="#FF0000"><span id="spnCopyMessage"></span></font><br/><br/>
                   <input type="button" class="inputbutton" onclick="CopyCustomTab();" style="cursor:pointer" value="Yes" id="btnCopyYes" />
                   <input type="button" class="inputbutton" onclick="HideCopyAlert();" style="cursor:pointer" value="No" id="btnCopyNo" />
				</div>
	          </div>
	</div>
    <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
     <div id="innerpagepagemain">
     <uc1:inner ID="inner1" runat="server" />
      <div id="centermain">
      
       <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top" ><table width="974" border="0" align="left" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
               <td width="172" align="left" valign="top"  class="leftbg">
                
                    <uc3:left ID="left1" runat="server" />
                
                </td>
               
                <td align="left" valign="top" class="contentbody">
              
			  <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td align="left" valign="top"><table width="242" border="0" cellspacing="0" cellpadding="0" style="display:;">
          <tr>
            <td height="49" align="center" valign="middle" class="facebookboxtitle">Watch the Tutorial Video</td>
          </tr>
          <tr>
            <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
          </tr>
          <tr>
            <td align="left" valign="top" class="facebookboxbg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="50" align="center" valign="top" class="arial13">Learn how to create your Business Page <br />
                  with these simple steps.</td>
              </tr>
              <tr>
                <td height="50" align="center" valign="middle">
                <a id="btnVideo" runat="server" class="video">WATCH THE VIDEO</a>
                </td>
              </tr>
              <tr>
                <td height="330" align="center" valign="top" class="facebookboxwhite"  >
				<a id="strVideo1" runat="server" class="video">
                    <img id="imgcustomtab" src="Content/images/video_img_small.jpg" border="0" width="198" height="123"  runat="server"  />
                </a>
				</td>
              </tr>
            </table></td>
          </tr>
        </table></td>
        <td align="center" valign="top"><table width="242" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="49" align="center" valign="middle" class="facebookboxtitle" >Design a Custom Tab</td>
          </tr>
          <tr>
            <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
          </tr>
          <tr>
            <td align="left" valign="top" class="facebookboxbg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="50" align="center" valign="top" class="arial13">Use this library to store and edit Custom Tabs you built.</td>
              </tr>
              <tr>
                <td height="50" align="center" valign="middle"><a href="<%=ResolveUrl("create-custom-tab")%>" class="bluetablink">DESIGN A CUSTOM TAB</a></td>
              </tr>
              <tr>
                <td height="330" align="center" valign="middle" class="facebookboxwhite"  ><a href="<%=ResolveUrl("create-custom-tab")%>"><img id="imgtop" runat="server" src="Content/images/customtab/template1_Apartment.png" width="150" height="300" border="0" /></a></td>
              </tr>
            </table></td>
          </tr>
        </table>
        </td>
        <td align="right" valign="top">
        <table width="242" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="49" align="center" valign="middle" class="facebookboxtitle">My Saved Custom Tabs</td>
          </tr>
          <tr>
            <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif);  background-position:top; background-repeat:repeat-x">
			<img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
          </tr>
          <tr>
            <td align="left" valign="top" class="facebookboxbg">
			
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="50" align="center" valign="top" class="arial13">You will be guided through a<br />
                  process that will allow you to review <br />
                  and select from unique templates</td>
              </tr>
              <tr>
                <td height="50" align="center" valign="middle"><a href="javascript:;"  onclick="showPages();" class="bluetablink">CHOOSE CUSTOM TAB&nbsp;<img src="Content/images/youselect_arrow_down.png" width="11" height="6" border="0" align="absmiddle" id="img1" /></a></td>
              </tr>
              
              <tr>
                <td align="center" height="330" valign="top" class="facebookboxwhite"  >
                <asp:UpdatePanel ID="updatepanelcustomtab" runat="server" ><ContentTemplate>	
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                  
                 
                    <td width="25" align="left" valign="middle">
                    <asp:ImageButton ID="ibtnPre" runat="server" ImageUrl="Content/images/arrow_gray_left.png" BorderWidth="0" />
					</td>
                    <td height="302" align="center" valign="top" style="padding-top:0px;">
                    <asp:Literal ID="ltrName" runat="server"></asp:Literal><br /><br />
					<a href='javascript:;' onclick="RedirectCustomise();" ><img src="" id="imgMyCustomTab" runat="server" width="150" height="300" border="0" /></a> 
					<input type="hidden" id="hdnCustomTab" runat="server" value="0" />
					<input type="hidden" id="hdnImageName" runat="server" value="0" />
                   <input type="hidden" id="hdnMasterId" runat="server" value="0" />
					<asp:Label ID="lblNoSidebar" runat="server" Visible="false" Font-Bold="true">No Custom Tab Saved Yet</asp:Label>
					</td>
                    <td width="25" align="right" valign="middle">
					<asp:ImageButton ID="ibtnNext" runat="server" ImageUrl="Content/images/arrow_gray_right.png" BorderWidth="0" />
					</td>
                   
                  </tr>
                </table>
                 <div id="div3" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute;">
                          <asp:UpdateProgress ID="UpdateProgress1" runat="Server" DisplayAfter="0">
                            <ProgressTemplate>  </ProgressTemplate>
                          </asp:UpdateProgress>
                        </div>	
               </ContentTemplate> </asp:UpdatePanel> 
				<div style="position:absolute; display:none;" id="dvMenu">
	<table width="179" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td align="right" valign="top"><img src="Content/images/blue_arrow_up.png" width="13" height="7" hspace="22" /></td>
        </tr>
        <tr>
          <td align="left" valign="top" bgcolor="#5973a8" style="border:1px solid #1a356e; padding:9px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="37" align="center" valign="top" class="arial14"><strong><font color="#FFFFFF">What you would <br />
                like to do?</font></strong></td>
            </tr>
            <tr>
              <td align="left" valign="top" bgcolor="#FFFFFF" style="border:1px solid #1a356e; padding:9px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="25" align="left" valign="middle" style="border-bottom:1px dotted #c5c5c5; display:none">
				  <img src="Content/images/publish_to_facebook_icon.png" width="15" height="15" align="absmiddle"/>&nbsp;&nbsp;
				  <asp:LinkButton ID="lnlPublish" runat="server" Text="Publish to Facebook" />
				  </td>
                </tr>
                <tr>
                  <td height="25" align="left" valign="middle" style="border-bottom:1px dotted #c5c5c5"><img src="Content/images/blue_edit_icon.png" width="15" height="15" align="absmiddle" />&nbsp;&nbsp;
				  <a href='javascript:;' onclick="RedirectCustomise();" >Edit</a>
				  </td>
                </tr>
                  <tr>
                  <td height="25" align="left" valign="middle" style="border-bottom:1px dotted #c5c5c5"> 
                  <a href="javascript:;" onclick="CopyAlert('Are you sure you want to copy this Custom Tab?');"><img src="Content/images/blue_copy_icon.png" width="15" height="15"  align="absmiddle" />&nbsp;&nbsp;&nbsp;<span style="vertical-align:middle;">Copy</span></a>
                  <a href="#" id="lnkCopy" runat="server" style="display:none"></a>
				  </td>
                </tr>
               <%-- <tr>
                  <td height="25" align="left" valign="middle" style="border-bottom:1px dotted #c5c5c5"><img src="Content/images/blue_download_icon.png" width="15" height="15" align="absmiddle" />&nbsp;&nbsp;
				  <a href='javascript:;' onclick="DownloadCustomise();" >Download</a>
				  </td>
                </tr>--%>
                <tr>
                  <td height="25" align="left" valign="middle">
				  <%--<asp:LinkButton ID="lnlDelete" OnClientClick="return confirm('Are you sure you want to delete this custom tab from your saved library?')" runat="server" Text="Delete" />--%>
                  <a href="javascript:;" onclick="DeleteAlert();"><img src="Content/images/blue_delete_icon.png" width="15" height="15"  align="absmiddle" />&nbsp;&nbsp;&nbsp;<span style="vertical-align:middle;">Delete</span></a>
                  <a href="#" id="lnkdelete1" runat="server" style="display:none"></a>
				  </td>
                </tr>
              </table></td>
            </tr>
          </table></td>
        </tr>
      </table>
	</div></td>
              </tr>
            </table>
			
			</td>
			
                    
			
			
			
			</td>
          </tr>
        </table></td>
      </tr>
    </table>
			  
              <br />
			  
               </table>
                   
                </td>
                </tr>
              </table></td>
          </tr>
          </table></td>
      </tr>
    </table>
  <%--    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top" ><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
               <td width="172" align="left" valign="top" class="leftbg">
                
                    <uc3:left ID="left1" runat="server" />
                
                </td>
               
                <td align="left" valign="top" class="contentbody">
                
                
                
                
              <br />
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left" valign="top">
                  
                  <table width="354" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td height="49" align="center" valign="middle" bgcolor="#5973a8" style="font-size:22px; font-family:arial;  color:#FFF">Watch the Tutorial Video</td>
                      </tr>
                      <tr>
                        <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" bgcolor="#edeff4"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="center" valign="top">Learn how to create your own custom tab <br />
                              with these simple steps.</td>
                          </tr>
                          <tr>
                            <td height="50" align="center" valign="middle">
							<a id="btnVideo" runat="server" class="video"><span class="bluetablink">Watch The Video</span></a></td>
                          </tr>
                          <tr>
                            <td align="center" valign="top" style="padding:10px;"> <div style="border:1px solid #bdc7d8; background-color:#FFF; padding:13px;"><a id="strVideo1" runat="server" class="video">
                    <img id="imgcustomtab" runat="server" border="0" /><span></span></a></div></td>
                          </tr>
                        </table></td>
                      </tr>
                    </table>
                  </td>
                  <td align="left" valign="top">
				  <table width="354" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td height="49" align="center" valign="middle" bgcolor="#5973a8" style="font-size:22px; font-family:arial;  color:#FFF">Design a Custom Business Page</td>
                      </tr>
                      <tr>
                        <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" bgcolor="#edeff4"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="center" valign="top" style="padding:5px;">
							You will be guided through a process that will allow you to review and select from unique templates.
							</td>
                          </tr>
                          <tr>
                            <td height="50" align="center" valign="middle">
							<a href="<%=ResolveUrl("create-custom-tab")%>" class="bluetablink">Design a Custom Tab</a>
							</td>
                          </tr>
                          <tr>
                            <td align="center" valign="top" style="padding:10px;"> <div style="border:1px solid #bdc7d8; background-color:#FFF; padding:13px;">
							<img src="Content/images/1-Realty.jpg" width="275px" height="450px" />
							</div></td>
                          </tr>
                        </table></td>
                      </tr>
                    </table></td>
                </tr>
              </table>
              <br />
			  
               </table>
                   
                </td>
                </tr>
              </table></td>
          </tr>
          </table></td>
      </tr>
    </table>--%>


   <%-- <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="172" align="left" valign="top"> 
                    <uc3:left ID="left1" runat="server" />
                </td>
                <td align="left" valign="top" class="contentbody">
                   <table>
                   <tr>
                   <td width="50%" align="center" valign="top" style="padding-right:25px;">
                   <h2>Watch the Tutorial Video</h2>                   
                   <h4>Learn howto create your own custom tab with these simple steps</h4>
                     <a id="btnVideo" runat="server" class="video">Watch The Video</a><br />
                    <a id="strVideo1" runat="server" class="video">
                    <img id="imgcustomtab" runat="server" width="250" height="155" border="0" /></a>
                   
                   </td>
                   <td width="50%" align="center" style="padding-left:25px;">
                   <h2>Design Your Custom Sidebar</h2>
                   <h4>You will be guided through a process that will allow you to review and select from unique templates</h4>
                   <a href="<%=ResolveUrl("create-custom-tab")%>"><img src="Content/images/update_btn.jpg" /></a><br />
                   <img src="Content/images/1-Realty.jpg" width="275px" height="450px" />
                   </td>
                   </tr>
                   </table>
                </td>
                </tr>
              </table></td>
          </tr>
          </table></td>
      </tr>
    </table></td>
  </tr>
 </table> --%>
    </div></div><uc2:inner ID="inner2" runat="server" />
    </form>
</body>
</html>

<script language="javascript">
var id='0';
function showPages()
{
	var pos;
	pos=findPos(document.getElementById('img1'));
	var lft=pos[0]-143;
	document.getElementById('dvMenu').style.left=lft + 'px';
	lft=pos[1]+10;
	document.getElementById('dvMenu').style.top=lft + 'px';
	if(id=='0')
	{
		$('#dvMenu').slideToggle('slow');
	}
	else
	{
		$('#dvMenu').slideUp('slow');
	}
}
function ClosePage()
{
	$('#dvMenu').slideUp('slow');
}
function findPos(obj) 
{
	   var curleft = curtop = 0;
	   if (obj.offsetParent) 
	   {
			  while (obj.offsetParent) 
			  {
				 curleft += obj.offsetLeft;
				 curtop += obj.offsetTop;
				 obj  = obj.offsetParent;
			  }
	   }
	   return [curleft,curtop];
	
}
function RedirectCustomise()
{
    document.location.href = 'custom-tabs.aspx?id=' + $('#hdnMasterId').val();
}
function DownloadCustomise() 
{
	if($('#hdnImageName').val()!='')
	{
		document.location.href='download.aspx?Image=' + $('#hdnImageName').val();
	}
}
</script>