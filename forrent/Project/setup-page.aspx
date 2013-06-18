<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setup-page.aspx.vb" Inherits="tsma.setup_page" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner1" tagprefix="uc1" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Total Social Media Application</title>
    <script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
    <%--<link rel="stylesheet" href="Content/js/engine/css/videolightbox.css" type="text/css" />
		<style type="text/css">#videogallery a#videolb{display:none}</style>
      
			<link rel="stylesheet" type="text/css" href="Content/js/engine/css/overlay-minimal.css"/>
			<script src="Content/js/engine/js/jquery.tools.min.js" type="text/javascript"></script>
			<script src="Content/js/engine/js/swfobject.js" type="text/javascript"></script>
			<!-- make all links with the 'rel' attribute open overlays -->
			<script src="Content/js/engine/js/videolightbox.js" type="text/javascript"></script>--%>
            <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
	<script type="text/javascript" src="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
	<link rel="stylesheet" type="text/css" href="Content/js/fancybox/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <script type="text/javascript" src="Content/js/fancybox/fancybox/video.js"></script>
            <script type="text/javascript">

            
                function CreatePage() {
                    window.open("https://www.facebook.com/pages/create.php?", "Page", "left=20,top=20,menubar=0,resizable=0,width=1000,height=850");
                }

</script>
           
</head>
<body>
    <form id="form1" runat="server">
      <div id="innerpagepagemain">
     <uc1:inner1 ID="inner1" runat="server" />
      <div id="centermain">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top" >
    <table width="974" border="0" align="left" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
               <td width="172" align="left" valign="top" class="leftbg">                
                    <uc3:left ID="left1" runat="server" />                
                </td>               
                <td align="left" valign="top" class="contentbody">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left" valign="top" style="padding-bottom:10px;">
				  <h6>Setup a Page</h6>
				  </td>
				 </tr> 
                 <tr>
                 <td align="center" valign="top" style="padding-top:60px;">
                 	<font style="font-family:Arial, Helvetica, sans-serif; font-size:16px; color:#666666; line-height:30px;">If you do not have a Facebook page and would like one setup,<br/>please contact the Marketplace Expert team at 
                    <strong>888-539-1150 ext. 3</strong> or email: <a href="mailto:marketplace@forrent.com">marketplace@forrent.com</a></font>
                 </td>
                 </tr>
				<tr style="display:none">
                  <td align="left" valign="top">
                  
                  <table width="354" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td height="49" align="center" valign="middle" class="facebookboxtitle" style="font-size:20px;">Watch the Tutorial Video</td>
                      </tr>
                      <tr>
                        <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" class="facebookboxbg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="center" valign="top" class="arial13">Learn how to create the page <br />
                              with these simple steps.</td>
                          </tr>
                          <tr>
                            <td height="50" align="center" valign="middle">
							<a id="btnVideo" runat="server" class="video"><span class="bluetablink">Watch The Video</span></a></td>
                          </tr>
                          <tr>
                            <td align="center" valign="top" > <div class="facebookboxwhite" style="height:200px;"><a id="strVideo1" runat="server" class="video">
                    <img id="imgcreatepage" runat="server" border="0" /><span></span></a></div></td>
                          </tr>
                        </table></td>
                      </tr>
                    </table>
                  </td>
                  <td align="left" valign="top">
				  <table width="354" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td height="49" align="center" valign="middle" class="facebookboxtitle" style="font-size:20px;">Setup a Page</td>
                      </tr>
                      <tr>
                        <td align="center" valign="top" style="background-image:url(Content/images/title_down_bg.gif); background-position:top; background-repeat:repeat-x"><img src="Content/images/arrow_down_blue.png" width="58" height="20" /></td>
                      </tr>
                      <tr>
                        <td align="left" valign="top" class="facebookboxbg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="center" valign="top" class="arial13">
							If you already have a page, skip this step. If not you will be directed to Facebook to create a New Page.
							</td>
                          </tr>
                          <tr>
                            <td height="50" align="center" valign="middle">
							<a href="javascript:CreatePage();" class="bluetablink">Setup A Page</a>
							</td>
                          </tr>
                          <tr>
                            <td align="center" valign="top" > <div class="facebookboxwhite" style="height:200px;">
							<a href="javascript:CreatePage();"><img src="Content/images/create-new-page.jpg" width="304" height="201" border="0" /></a>
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
    </table></td>
  </tr>
 </table>
    
     </div></div> <uc2:inner ID="inner2" runat="server" />
    </form>
</body>
</html>

