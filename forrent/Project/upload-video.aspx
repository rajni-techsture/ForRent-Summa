<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="upload-video.aspx.vb" Inherits="tsma.upload_video" %>
<%@ Register src="~/footer.ascx" tagname="Footer1" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> Total Social Media Application </title>
    <script src="Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".Fanpagediv1").hide();
            $(".fan_showhide1").show();
            $('.fan_showhide1').click(function () {
                $(".Fanpagediv1").slideToggle();
            });
            $('.fan_close').click(function () {
                $(".Fanpagediv1").slideToggle();
            });
        });
    </script>
</head>
<body>
<form id="form1" runat="server" >
        <uc1:inner ID="inner1" runat="server" />       
           
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top" class="mainbg"><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="255" align="left" valign="top" class="leftbg"> 
                    <uc3:left ID="left1" runat="server" />
                </td>
                <td width="15" align="left" valign="top">
                </td>
                <td align="left" valign="top" class="contentborder">
                    <div style="padding-bottom:20px"><h2>Upload Video</h2></div>
                    <table border="0" cellpadding="2" cellspacing="0">
                    <tr>
                      <td colspan="2" align="center">
                        <asp:label ID="lblMessage" runat="server"></asp:label>
                        <input type="hidden" id="hdnselectedPages" runat="server" name="hdnselectedPages"  value=""/>
                        <input type="hidden" id="hdnSelectedPagesName" runat="server" name="hdnSelectedPagesName" value=""/>
                        <input type="hidden" id="hdnSelectedPagesImage" runat="server" name="hdnSelectedPagesImage"  value=""/>
                        <input type="hidden" id="hdnselectedPagesAccessToken" runat="server" name="hdnselectedPagesAccessToken"  value=""/>
                        </td>
                      </tr>
                    <tr>
                      <td height="25" align="right" valign="top" style="padding-top:5px;">
                        Fan Page:
                        </td>
                      <td>
                        <div class="fan_showhide1" align="left"><strong>Select Fan Pages</strong>&nbsp;</div>
                        <div id="divHtml" style="width:500px; height:auto; padding-top:5px; padding-bottom:5px;"></div>
						<div class="Fanpagediv1" style="display:none; width:500px; z-index:1000;">
                          <div class="pop_up_bx_top_fan_page">
                          <div class="fan_close" align="right" style="padding-right:10px; width:485px; padding-top:5px;" ><a href="javascript:;" style="text-decoration:none; font-size:12px; font-family:@Arial Unicode MS; font-weight:bold; color:#FFF" onClick="selectedpagesName();">Close</a></div>
                          </div>
                          <div class="pop_up_bx_mid_fan_page">
                            <div class="pop_up_bx_mid_inn_fan_page">
                                    <div id="divQuickPost" runat="server"></div>
                            </div>
                            </div>
                          <div class="pop_up_bx_bot_fan_page"></div>
                          </div>
                        </td>
                      </tr>
                    <tr>
                      <td height="25" align="right" valign="top"> 
                        Upload Photo:
                        </td>
                      <td height="25" align="left">
                         <input name="source" type="file" id="photo" runat="server"/><br/><br/>
                         <input id="txtmsg" runat="server"  type="text" /><br/><br/>
                        
                        <input id="btnalbum" type="submit" value="Save" runat="server" onClick="return ValidateAlbum();" />
                        
                        <%--<textarea style="width:400px;" id="txtMessage" runat="server" cols="96" rows="5" name="txtMessage"></textarea>--%>
                        </td>
                      </tr>
                    <tr>
                      <td height="25" align="right">&nbsp;</td>
                      <td height="30" align="left">
                       <input type="button" value="Upload" id="btnupload" runat="server" onClick="return ValidateAlbum();"/><br/>
                 
                      <%--<input type="image" id="btnPost" src="Content/images/post_message.png" width="114" height="27" class="AdminFormButton" value="Post Message" name="btnPost" onclick="return ValidateQuickPost();" runat="server"/>--%>
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
 </table>

    <uc2:Footer1 ID="Footer11" runat="server" />

         
      
       
        </form>
 
</body>
</html>
