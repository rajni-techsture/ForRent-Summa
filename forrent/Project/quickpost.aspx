<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="quickpost.aspx.vb" Inherits="tsma.quickpost" %>
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
    <style type="text/css">
	
	 img { border:none; } ul { margin:0; padding:0; list-style:none;} li { margin:0; padding:0; list-style:none;}     
 .show_hide1{margin:3px 0 0 0; text-align:center; overflow:hidden;}
.show_hide2{margin:3px 0 0 0; text-align:center; overflow:hidden;}
.slidingDiv { width:170px; position:absolute; margin:30px 0 0 -382px; left:50%; display:inline;}
.slidingDiv1 { width:170px; position:absolute; margin:5px 0 0 -207px; left:23%; display:inline;}
.fan_showhide1{ width:200px; margin:3px 0 0 0; text-align:left; overflow:hidden; cursor:pointer;}
.fan_close{ width:200px; margin:3px 0 0 0; text-align:right; overflow:hidden; cursor:pointer;}
.Fanpagediv { width:500px; position:absolute; margin:30px 0 0 -382px; left:60%; display:inline; border:1px solid #044d85;}
.Fanpagediv1 { width:500px; position:absolute; margin:5px 0 0 -260px; left:60%; display:inline; border:1px solid #044d85;}
.slidingDiv2 { width:170px; position:absolute; margin:5px 0 0 -33px; left:23%; display:inline; }
.pop_up_bx { width:170px; overflow:hidden;}
.pop_up_bx_top { width:170px; height:15px; overflow:hidden; background:url(../images/pop_up_t_b.png) no-repeat;}

.pop_up_bx_mid_inn{ width:154px; padding:0 8px; }
.pop_up_bx_mid_inn ul{ width:154px; padding:0 0px; float:left; }
.pop_up_bx_mid_inn ul li{ width:154px; padding:0 0px; float:left; }
.pop_up_bx_mid_inn ul li a{ width:118px; text-decoration:none; padding:5px 18px; float:left; font-family:Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; color:#000; }
.pop_up_bx_mid_inn ul li a:hover, .pop_up_bx_mid_inn .act{ width:118px; padding:5px 18px; float:left; font-family:Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; color:#fff; background:#003399; }
.pop_up_bx_bot { width:170px; height:15px; overflow:hidden; background:url(../images/pop_up_t_b.png) no-repeat; background-position:0 -15px;}    
.pop_up_bx_mid{ width:170px; height:280px; background:url(../../images/pop_up_mid.png) repeat-y;}

.pop_up_bx_top_fan_page { width:500px; height:40px; overflow:hidden; background-image:url(Content/images/popup_top.png); background-repeat:no-repeat; background-position:top;}
.pop_up_bx_mid_fan_page { width:500px; background:url(../images/pop_up_mid.png) repeat-y;}
.pop_up_bx_mid_inn_fan_page { width:474px; padding:08px; background-color:#fff; border-left:5px solid #536ba1; border-right:5px solid #536ba1;}
.pop_up_bx_bot_fan_page { width:500px; height:50px; overflow:hidden; background-image:url(Content/images/popup_bottom.png); background-repeat:no-repeat; background-position:bottom;}    
	</style>
</head>
<body>
    <form id="form1" runat="server">
     <uc1:inner ID="inner1" runat="server" />
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top" class="mainbg"><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="255" align="left" valign="top" class="tdgreyborder"> 
                    <uc3:left ID="left1" runat="server" />
                </td>
                <td width="15" align="left" valign="top">
                </td>
                <td align="left" valign="top" class="contentborder">
                    <div style="padding-bottom:20px"><h2>Quick Post (Post Message Immediately)</h2></div>
                    <table border="0" cellpadding="2" cellspacing="0">
                    <tr>
                      <td colspan="2" align="center">
                        <asp:label ID="lblMessage" runat="server"></asp:label>
                        <input type="hidden" id="hdnselectedPages" runat="server" name="hdnselectedPages"  value=""/>
                        <input type="hidden" id="hdnSelectedPagesName" runat="server" name="hdnSelectedPagesName" runat="server" value=""/>
                        <input type="hidden" id="hdnSelectedPagesImage" runat="server" name="hdnSelectedPagesImage" runat="server" value=""/>
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
                        Compose Message:
                        </td>
                      <td height="25" align="left">
                        <textarea style="width:400px;" id="txtMessage" runat="server" cols="96" rows="5" name="txtMessage"></textarea>
                        </td>
                      </tr>
                    <tr>
                      <td height="25" align="right">&nbsp;</td>
                      <td height="30" align="left">
                      <input type="image" id="btnPost" src="Content/images/post_message.png" width="114" height="27" class="AdminFormButton" value="Post Message" name="btnPost" onClick="return ValidateQuickPost();" runat="server"/>
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
