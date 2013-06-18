<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cover-photos-home.aspx.vb" Inherits="tsma.cover_photos_home" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Total Social Media Application</title>
    <link rel="stylesheet" type="text/css" href="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <link href="Content/facebookalert/facebookalert_files/facebook.delete.css" rel="stylesheet" type="text/css">
	<script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
	<script type="text/javascript" src="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <script type="text/javascript" src="Content/js/fancybox/fancybox/video.js"></script>
    <script type="text/javascript" src="Content/facebookalert/facebookalert_files/jquery_facebook.delete.js"></script>
	<script type="text/javascript">
	    function DeleteAlert() {
	        jConfirm('Warning: Delete this Cover Photo?', 'Delete Cover Photo',
				    function (r) {
				        if (r == true) {
				            __doPostBack("lnkdelete1", "");
				        }
				    });

	    }
		function DeleteCoverPhoto()
		{
			__doPostBack("lnkdelete1", "");
		}
		function CopyCoverPhoto() {
		    __doPostBack("lnkCopy", "");
		}
		function DeleteAlert1(mess)
				{
					var maskHeight = $(document).height();
					var maskWidth = $(window).width();
					$('#DivSaveCoverPhoto').css({'width':maskWidth,'height':maskHeight});
				    $("#spnMessage").html(mess);
					$("#DivSaveCoverPhoto").show("slow");
				}
				function HideDeleteAlert() {
				    $("#DivSaveCoverPhoto").hide("slow");
				}
		function CopyAlert(mess) {
					var maskHeight = $(document).height();
					var maskWidth = $(window).width();
					$('#DivCopyCoverPhoto').css({'width':maskWidth,'height':maskHeight});
				    $("#spnCopyMessage").html(mess);
				    $("#DivCopyCoverPhoto").show("slow");
		}
		function HideCopyAlert() {
			    $("#DivCopyCoverPhoto").hide("slow");
		}
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DivSaveCoverPhoto" style="width:100%; height:750px;; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:10000000; text-align:center;padding-top:320px; padding-left:170px; display:none;">
			  <div id="popup_container1"  style="width:450px; height:85px">
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  <font color="#FF0000">Warning!  This action will delete the cover photo from facebook business pages associated with it and from all its administrators' accounts</font><br/><br/>
                   <input type="button" class="inputbutton" onclick="DeleteCoverPhoto();" style="cursor:pointer" value="Yes" id="popup_yes" />
                   <input type="button" class="inputbutton" onclick="HideDeleteAlert();" style="cursor:pointer" value="No" id="popup_close" />
				</div>
                
			 </div>
			 </div>
             <div id="DivCopyCoverPhoto" style="width:100%; height:750px;; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:10000000; text-align:center;padding-top:320px; padding-left:170px; display:none;">
			  <div id="popup_container1">
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  <font color="#FF0000"><span id="spnCopyMessage"></span></font><br/><br/>
                   <input type="button" class="inputbutton" onclick="CopyCoverPhoto();" style="cursor:pointer" value="Yes" id="btnCopyYes" />
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
    <td width="172" align="left" valign="top"  class="leftbg"><uc3:left ID="left1" runat="server" /></td>
    <td align="left" width="20" valign="top" style="border-left:1px solid #cccccc;">&nbsp;</td>
    <td align="left" valign="top" style="padding-top:20px;"><table width="242" border="0" cellspacing="0" cellpadding="0" style="display:;">
          <tr>
            <td height="49" align="center" valign="middle" class="facebookboxtitle">Watch the Tutorial Video</td>
          </tr>
          <tr>
            <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
          </tr>
          <tr>
            <td align="left" valign="top" class="facebookboxbg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="50" align="center" valign="top" class="arial13">Learn how to create your Cover Photo <br />
                  with these simple steps.</td>
              </tr>
              <tr>
                <td height="60" align="center" valign="middle"><a id="btnVideo" runat="server" class="video">WATCH THE VIDEO</a></td>
              </tr>
              <tr>
                <td height="367" align="center" valign="top" class="facebookboxwhite"  >
				<a id="strVideo1" runat="server" class="video">
				<img id="imgCoverPhoto" runat="server" src="Content/images/video_img_small.jpg" border="0" width="198" height="123" />
				</a>
				</td>
              </tr>
            </table></td>
          </tr>
        </table></td>
    <td align="left" valign="top">&nbsp;</td>
    <td align="left" valign="top" style="padding-top:20px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="49" align="center" valign="middle" class="facebookboxtitle">Design Your Custom Cover Photo</td>
              </tr>
              <tr>
                <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
              </tr>
              <tr>
                <td align="left" valign="top" class="facebookboxbg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td height="40" align="center" valign="top" class="arial13">Use this library to store and edit Cover Photos you built. <a href="<%=ResolveUrl("create-cover-photo")%>" class="bluetablink">CHOOSE COVER PHOTO</a>                      </td>
                    </tr>
                    
                    <tr>
                      <td height="140" align="center" valign="middle" class="facebookboxwhite"><asp:Panel id="pnlCoverPhoto" runat="server">
                          <a href="<%=ResolveUrl("create-cover-photo")%>"> <img src="" name="imgtop" width="700" height="200" border="0" id="imgtop" runat="server" /> </a> 
                          </asp:Panel>
                          <asp:Label ID="lblNoCoverPhoto1" runat="server" Visible="false" Font-Bold="true">No Cover Photo Templates Available</asp:Label>
                      </td>
                    </tr>
                </table></td>
              </tr>
            </table>
    </td>
  </tr>
  <tr>
    <td align="left" valign="top" style="height:20px;">&nbsp;</td>
  </tr>
  <tr>
    <td align="left" valign="top">
   <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="49" align="center" valign="middle" class="facebookboxtitle">My Saved Cover Photos</td>
          </tr>
          <tr>
            <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif);  background-position:top; background-repeat:repeat-x">
			<img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
          </tr>
          <tr>
            <td align="left" valign="top" class="facebookboxbg">
			
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="40" align="center" valign="top" class="arial13">Use this library to store and edit Cover Photos you built. <a href="javascript:;"  onclick="showPages();" class="bluetablink">CHOOSE COVER PHOTO&nbsp;<img src="Content/images/youselect_arrow_down.png" width="11" height="6" border="0" align="absmiddle" id="img1" /></a></td>
              </tr>
              
              
              <tr>
                <td align="center" valign="top" class="facebookboxwhite"  >
				<asp:UpdatePanel ID="updatepanelCoverPhoto" runat="server" ><ContentTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                  
                 
                    <td width="25" align="left" valign="middle">
                    <asp:ImageButton ID="ibtnPre" runat="server" ImageUrl="Content/images/arrow_gray_left.png" BorderWidth="0" />					</td>
                    <td height="115" align="center" valign="top" style="padding-top:0px;">
                    <div id="div3" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute; ">
                          <asp:UpdateProgress ID="UpdateProgress1" runat="Server" DisplayAfter="0">
                            <ProgressTemplate> <img src="Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" />                            </ProgressTemplate>
                          </asp:UpdateProgress>
                        </div>	
                 <asp:Literal ID="ltrName" runat="server"></asp:Literal><br /><br />
					<a href='javascript:;' onclick="RedirectCustomise();" ><img src="" id="imgMyCoverPhoto" runat="server" width="700" height="200" border="0" /></a>
					<input type="hidden" id="hdnCoverPhoto" runat="server" value="0" />
					<input type="hidden" id="hdnImageName" runat="server" value="0" />
                    <input type="hidden" id="hdnMasterId" runat="server" value="0" />
					<asp:Label ID="lblNoCoverPhoto" runat="server" Visible="false" Font-Bold="true">No Cover Photos Saved Yet</asp:Label>					</td>
                    <td width="25" align="right" valign="middle">
					<asp:ImageButton ID="ibtnNext" runat="server" ImageUrl="Content/images/arrow_gray_right.png" BorderWidth="0" />					</td>
                  </tr>
                </table>
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
				  <asp:LinkButton ID="lnlPublish" runat="server" Text="Publish to Facebook" />				  </td>
                </tr>
                <tr>
                  <td height="25" align="left" valign="middle" style="border-bottom:1px dotted #c5c5c5"> <a href='javascript:;' onclick="RedirectCustomise();" ><img src="Content/images/blue_edit_icon.png" width="15" height="15" align="absmiddle" />&nbsp;&nbsp;
				 <span style="vertical-align:middle;">Edit</span></a>				  </td>
                </tr>
                <tr>
                  <td height="25" align="left" valign="middle" style="border-bottom:1px dotted #c5c5c5"> 
                  <a href="javascript:;" onclick="CopyAlert('Are you sure you want to copy this Cover Photo?');"><img src="Content/images/blue_copy_icon.png" width="15" height="15"  align="absmiddle" />&nbsp;&nbsp;&nbsp;<span style="vertical-align:middle;">Copy</span></a>
                  <a href="#" id="lnkCopy" runat="server" style="display:none"></a>				  </td>
                </tr>
                <tr style="display:none;">
                  <td height="25" align="left" valign="middle" style="border-bottom:1px dotted #c5c5c5"><img src="Content/images/blue_download_icon.png" width="15" height="15" align="absmiddle" />&nbsp;&nbsp;
				  <a href='javascript:;' onclick="DownloadCustomise();" >Download</a>				  </td>
                </tr>
                <tr>
                  <td height="25" align="left" valign="middle">
                  <a href="javascript:;" onclick="DeleteAlert1();"><img src="Content/images/blue_delete_icon.png" width="15" height="15"  align="absmiddle" />&nbsp;&nbsp;&nbsp;<span style="vertical-align:middle;">Delete</span></a>
                  <a href="#" id="lnkdelete1" runat="server" style="display:none"></a>                  </td>
                </tr>
              </table></td>
            </tr>
          </table></td>
        </tr>
      </table>
	</div></td>
              </tr>
            </table>			</td>
			</td>
          </tr>
        </table>
    </td>
  </tr>
</table>
</td>
  </tr>
</table>

    
     </div></div> <uc2:inner ID="inner2" runat="server" />
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
	document.location.href = 'cover-photos.aspx?id=' + $('#hdnMasterId').val();
}
function DownloadCustomise()
{
	if($('#hdnImageName').val()!='')
	{
		document.location.href='download.aspx?Image=' + $('#hdnImageName').val();
	}
}
</script>