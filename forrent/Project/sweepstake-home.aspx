<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sweepstake-home.aspx.vb" Inherits="tsma.sweepstake_home" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner1" tagprefix="uc1" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Total Social Media Application</title>
     <script src="../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Content/js/jquery.min.js"></script>
	<script type="text/javascript" src="../Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
	<link rel="stylesheet" type="text/css" href="../Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <script type="text/javascript" src="../Content/js/fancybox/fancybox/video.js"></script>
    <script src="Content/js/redirect-to-home.js" type="text/javascript"></script>
    <style type="text/css">
        #popup_container1 {
	        font-family:'Lucida Grande',arial;
	        margin-left:200px;
	        margin-top:200px;
	        font-weight:bold;
	        text-align:left;
	        font-size: 12px;
	        width: 364px; 
	        height: 70px; 
	        background: #ffffff;
	        border:8px solid #7c7c7c;
	        color: #000;
	
        }
        .inputbutton
        {
	        background-image:url(../images/button_bg.gif);
	        background-repeat:repeat-x;
	        background-position:top;
	        background-color:#5972a7;
	        border:1px solid #29447e;
	        height:22px;
	        padding:0px 5px;
	        color:#FFF;
	
        }
    </style>
    <script type="text/javascript">
	function SaveAlert(mess)
				{
				    $("#spnMessage").html(mess);
					$("#DivSaveSidebar").show("slow");
				}
				function HideSaveAlert() {
				    $("#DivSaveSidebar").hide("slow");
				}
	</script>
           
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="objScriptManager1" runat="server"></asp:ScriptManager>
      <div id="innerpagepagemain">
     <uc1:inner1 ID="inner1" runat="server" />
      <div id="centermain">
      <div id="DivSaveSidebar" style="width:100%; height:100%; text-align:center;  background-image:url(../Content/facebookalert/images/popup_bg.png);  position:absolute; z-index:999999999; text-align:center;  display:none;">
			  <div id="popup_container1" style="width:450px; height:80px;"  >
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  <span id="spnMessage"></span><br/><br/>
                   <input type="button" class="inputbutton" onclick="HideSaveAlert();" value="Close" id="popup_close" />
				</div>
			 </div>
			 </div>
       <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top" ><table width="974" border="0" align="left" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
               <td width="172" align="left" valign="top" class="leftbg">
                
                    <uc3:left ID="left1" runat="server" />
                
                </td>
               
                <td align="left" valign="top" class="contentbody">
				
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
			  <tr>
                  <td align="left" valign="top" style="padding-bottom:5px;">
				  <h6></h6>
				  </td>
				 </tr> 
                 <tr>
                 <td align="center" style="" colspan="2">
                 <asp:Label ID="lblmessage" runat="server" ForeColor="#FF0000" Font-Size="14"></asp:Label></td>
                 </tr>
                <tr>
                  <td align="left" valign="top">
                  
                  <table width="354" border="0" cellspacing="0" cellpadding="0" >
                      <tr>
                        <td height="49" align="center" valign="middle" bgcolor="#5973a8" style="font-size:22px; font-family:arial;  color:#FFF">Watch the Tutorial Video</td>
                      </tr>
                      <tr>
                        <td align="center" valign="top" style="background-image:url(../Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="../Content/images/arrow_down_blue.png" width="58" height="20" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" bgcolor="#edeff4"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="center" valign="top">Learn how to create your own custom tab <br />
                              with these simple steps.</td>
                          </tr>
                          <tr>
                            <td height="50" align="center" valign="middle">
							<a id="btnVideo" runat="server" class="video">WATCH THE VIDEO</a></td>
                          </tr>
                          <tr>
                            <td align="center" valign="top" style="padding:10px;">
                             <div style="border:1px solid #bdc7d8; background-color:#FFF; padding:13px;">
                             <a id="strVideo1" runat="server" class="video">
                             <img id="imgsweepstake" runat="server" border="0" />
                             </a>
                             </div></td>
                          </tr>
                        </table></td>
                      </tr>
                    </table>
                  </td>
                  <td align="center" valign="top">
				  <table width="354" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td height="49" align="center" valign="middle" bgcolor="#5973a8" style="font-size:22px; font-family:arial;  color:#FFF">
						Add sweepstakes
						</td>
                      </tr>
                      <tr>
                        <td align="center" valign="top" style="background-image:url(../Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="../Content/images/arrow_down_blue.png" width="58" height="20" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" bgcolor="#edeff4"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="center" valign="top">
							By adding sweepstakes, you increase your conversion rate of visitors-to-fans.
							</td>
                          </tr>
                          <tr>
                            <td height="50" align="center" valign="middle">
							<img id="img1" width="1" height="1" />
							
							<a href="javascript:;" onclick="showPages();" class="bluetablink">Add sweepstakes</a>
							</td>
                          </tr>
                          <tr>
                            <td align="center" valign="top" style="padding:10px;"> <div style="border:1px solid #bdc7d8; background-color:#FFF; padding:13px;">
							<img src="../Content/images/sweepstakes_like_img.jpg" width="275px" height="370px" />
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
    </table>
    <div id="divSidebarHtml" runat="server" align="left" style="float:left; width:200px; display:none;"></div>
 <div id="Fanpagesdiv1" class="Fanpagesdiv1" style="display:none; left:0px; width:670px; height:250px; border:0px solid #ff0000; position:absolute; z-index: 1000;">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
    	 	<tr>
                  <td align="right" valign="top" class="greypopupbordertop" style="padding-right:30px;">
				  <img src="../Content/images/grey_popup_top.gif" width="31" height="11" />
				  </td>
         	</tr>
          <tr>
                  <td align="left" valign="top" class="greypopupborder" style="padding:13px; padding-bottom:16px; padding-right:0px;">
				  <table cellpadding="0" cellspacing="0" border="0" width="100%">
				  <tr bordercolor="#cccccc;" style="height:25px;">
				  <td valign="middle">
				  <b>To add a Sweepstakes tab, select a Business Page(s)</b>
				  </td>
				  <td align="right" valign="middle">
					 <a href="javascript:;" onclick="ClosePage();">[Close]</a>&nbsp;&nbsp;&nbsp;
				  </td>
				  </tr>
 				<tr>
				  <td colspan="2" valign="top">
   			 <div style="width:650px; height:250px; overflow:auto; background-color:#ffffff;padding:0px; padding-top:0px; border:1px solid #cccccc;">
             <input type="hidden" id="hdnselectedPages" runat="server" name="hdnselectedPages"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesName" runat="server" name="hdnSelectedPagesName"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesImage" runat="server" name="hdnSelectedPagesImage"
                                                                    value="" />
                  <input type="hidden" id="hdnselectedPagesAccessToken" runat="server" name="hdnselectedPagesAccessToken"
                                                                    value="" />
       <asp:PlaceHolder ID="plcData" runat="server">
					<asp:DataList ID="dstFanPages" runat="server" RepeatColumns="3">
                      <ItemTemplate>
                      <table id="NonFanPage" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
							<td colspan="2" style="border-top:0px solid #cccccc;height:20px;">
							</td>
							</tr>
						  <tr>
                          	
							<td width="150" valign="top" align="center">
							<img src='<%#Eval("picture")%>' height="102" width="102" class='imgborder' group="pageimg" pageid='<%#Eval("Id")%>' /></td>
							<td width="10" >&nbsp;</td>
						   </tr>
						  <tr height="30" align="center">
							<td><input class="checkboxpadding" type="checkbox" id="chkPage" name="chkPage" runat="server" pageid='<%#Eval("Id")%>' group="pages" onclick='Pageid(this);'  pageaccess_token='<%#Eval("access_token")%>' pagevalue='<%#Eval("name")%>' pageimage='<%#Eval("picture")%>' />
							<%#Eval("name")%>
                                    <input type="hidden" id="hdnPageId" runat="server" value='<%#Eval("Id")%>' />
                                    <input type="hidden" id="hdnPageName" runat="server" value='<%#Eval("name")%>' />
                                    <input type="hidden" id="hdnAccessToken" runat="server" value='<%#Eval("access_token")%>' />
                                    <input type="hidden" id="hdnImage" runat="server" value='<%#Eval("picture")%>' />
                                    
							</td>
							<td >&nbsp;</td>
						  </tr>
						</table>
                      
                     
                      </ItemTemplate>
                    </asp:DataList>
           </asp:PlaceHolder>
           <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
				   <strong style="color:#990066">  You have no business pages.</strong><br /><br /> <a href="javascript:CreatePage();">Click here</a> to create business page. 
		   </asp:PlaceHolder> 
           <asp:PlaceHolder ID="plcError" runat="server" Visible="false">
                                           <strong style="color:#990066">Facebook is experiencing problems. Please try again later</strong><br /><br />
           </asp:PlaceHolder>
     </div>
    
    </td>
  </tr>
  <tr>
    <td height="20" align="left" valign="middle" style="padding-top:10px;">
    <a id="btnUpload" class="bluetablink" runat="server" onclick="return ValidatePublish();ShowProgress();" title=">Publish sweepstakes">Publish sweepstakes</a>&nbsp;<a id="lnkDownload" class="bluetablink" runat="server" title="Download Sidebar" style="display:none;">Download Sidebar</a></td>
  </tr>
  </table>
  </td>
  </tr>
</table>

    </div>
    
	
			<div align="center" style="display:none; z-index:20000; padding-left:250px; padding-top:400px;" id="imgLoading">
			<img src="../content/images/bigspinner.gif" class="spinner1Class"/>&nbsp;Adding sweepstakes to your page...
			</div>
	       	<div style="display:none;width:350px; height:80px; background-color:#FFFFFF; padding:15px; border:2px solid #000000; position:absolute;" id="dvMessage">
				<table cellpadding="0" cellspacing="0" border="0" width="100%">
				  <tr>
				  <td>
				  <strong>Done</strong>
				  </td>
				  <td align="right" style="height:15px;">
					 <a href="javascript:;" onclick="hideDivPopup('dvMessage');">[Close]</a>&nbsp;&nbsp;&nbsp;
				  </td>
				  </tr>
				  <tr>
				  <td colspan="2" valign="top" style="border-top:1px solid #cccccc;">
				  <br />
				  <span id="spnMsg" style="font-size:16px">
				  Sweepstakes has been successfully added to your fan page.<br />
				  </span>
				  </td>
				  </tr>
				  </table>                     
            </div>
            
     </div></div> <uc2:inner ID="inner2" runat="server" />
    </form>
<div id="divBackGround" class="divBackGround" style="display:none;"></div>
</body>
</html>
<script language="javascript">
 
function showPages()
{
	var pos;
	pos=findPos(document.getElementById('img1'));
	var lft=pos[0]-540+20;
	document.getElementById('Fanpagesdiv1').style.left=lft + 'px';
	lft=pos[1]+10;
	document.getElementById('Fanpagesdiv1').style.top=lft + 'px';
	$('#Fanpagesdiv1').slideDown('slow');
}
function ClosePage()
{
	$('#Fanpagesdiv1').slideUp('slow');
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
function PostSweepStake(obj)
{
	var tmpId;
	tmpId=obj.id.replace('hrefPost','hdnPageName');
	tmpId=confirm('Are You Sure You Want to Add sweepstakes on '+ $('#' + tmpId).val() +'?');
	if(tmpId==true)
	{
		ClosePage();
		var xmlhttp;
		if (window.XMLHttpRequest)
		{// code for IE7+, Firefox, Chrome, Opera, Safari
		    xmlhttp = new XMLHttpRequest();
		  
		}
		else
		{// code for IE6, IE5
			xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
		}
		
		xmlhttp.onreadystatechange=function()
		{
			if (xmlhttp.readyState==4 && xmlhttp.status==200)
			{
				hideDivPopup('divLoading');
				if(xmlhttp.responseText=='')
				{
					$('#divLoading').slideUp('slow');
					showDivPopup('dvMessage');
				}
				else
				{
					document.getElementById('spnMsg').innerHTML=xmlhttp.responseText;
				}
			}
		}
		showDivPopup('divLoading');
		xmlhttp.open("POST", "../ajax/ajax-post-sweepstake.aspx?pid=" + document.getElementById(obj.id.replace('hrefPost', 'hdnPageId')).value + "&pat=" + document.getElementById(obj.id.replace('hrefPost', 'hdnAccessToken')).value + "&pnm=" + document.getElementById(obj.id.replace('hrefPost', 'hdnPageName')).value, true);
		xmlhttp.send();		
	}
}
function AllClose()
{
	
}
function Pageid(_this) {
		
				}
				function selectedpages() {
				
					var pages = '';
                 	var hdnPages = '';
					$('input[group^=pages]').each(
						function () {
							if ($(this).attr("checked") == true) {
								pages = pages + $(this).attr("pageid") + ','
									
							}
						}
					);
					if (pages != '') {
				
                        $('#hdnPageId').val(pages);
                        return true;
					}
					else
					{
						return false;
					}
                   
				}
                	
              
                function selectedpageimage() {
				
                    var pageImage = '';
					var hdnPages = '';
					$('input[group^=pages]').each(
						function () {
							if ($(this).attr("checked") == 'checked') {
								pageImage = pageImage + $(this).attr("pageimage") + ','
							}
						}
					);
					if (pageImage != '') {
                        $('#hdnImage').val(pageImage);
						return true;
					}
					else
					{
						return false;
					}
				}
                function selectedpagesName() {
					var pages = '';
					var hdnPages = '';
					$('input[group^=pages]').each(
						function () {
							if ($(this).attr("checked") == 'checked') {
								var pageid = $(this).attr("pageid")
								pages = pages + $(this).attr("pagevalue") + "<a href='javascript:RemovePage(" + pageid + ")'>&nbsp;&nbsp;<img src='../content/images/remove.gif' width='8' height='8' /></a><br/>"
							}
						}
					);
					if (pages != '') {
						$('#divHtml').show("slow");
						$('#divHtml').html("<strong>Selected Pages:</strong><br/>" + pages );
						return true;
					}
					else
					{
						$('#divHtml').hide("slow");
						$('#divHtml').html('');
						return false;
					}
				}
                
				function RemovePage(pageid)
				{
				   $('input[group^=pages]').each(
						function () {
							if ($(this).attr("checked") == 'checked') {
								var pageid1 = $(this).attr('pageid');
								 if(pageid == pageid1)
								 {
								var id= $(this).attr('id');
								 $("#" + id).removeAttr("checked");
								 selectedpagesName();
								 }
							}
						}
					);	
				
					
				}
				function HideProgress() {
                // parent.document.getElementById("imgLoading").style.display = 'none';
        		SaveAlert('Sweepstakes uploaded successfully');
				hideDivPopup('imgLoading');

				showDivPopup('dvMessage');
                }
            function ShowProgress() {
                        // parent.document.getElementById("imgLoading").style.display = 'block';
                ClosePage();
                //SaveAlert();
						//showDivPopup('imgLoading');
                }

  
                function selectedpagesAccessToken() {
					
                    var pagesaccesstoken = '';
					var hdnPages = '';
					$('input[group^=pages]').each(
						function () {
							if ($(this).attr("checked") == 'checked') {
							      pagesaccesstoken = pagesaccesstoken + $(this).attr("pageaccess_token") + ','
							}
						}
					);
				   
                    if (pagesaccesstoken != '') {
                        $('#hdnAccessToken').val(pagesaccesstoken);
                        return true;
					}
					else
					{
						return false;
					}
				}
				  function ValidatePublish() {
				 
					var Title = "Fill in Following Information\n";
					var fields = "";
					if(selectedpages()==false)
					{
						fields = fields + "\n-- Please select a business page before attempting to post --";
					}
                   
                    selectedpagesAccessToken();
                    selectedpageimage();
                    selectedpagesName();
                  
					if (fields.length > 0) {
						alert(Title + fields);
						 
						return false;
					}
					else {
                    ShowProgress();
						return true;
					}
				}
				function CreatePage() {
    window.open("https://www.facebook.com/pages/create.php?", "Page", "left=20,top=20,menubar=0,resizable=0,width=1000,height=850");
}
</script>
