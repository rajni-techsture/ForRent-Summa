<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="upload-sidebar.aspx.vb" Inherits="tsma.upload_sidebar" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner1" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
<%--<meta http-equiv="refresh" content="60">--%>
<link id="lnkInnerTheme" href="<%=ResolveUrl("~/Content/css/chiropractic-style.css")%>" rel="stylesheet" type="text/css" />
<title>Total Social Media Application</title>
<script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
<style>
.error {
	border:1px solid #FF0000;
}
</style>
<style type="text/css">
img {
	border: none;
}
ul {
	margin: 0;
	padding: 0;
	list-style: none;
}
li {
	margin: 0;
	padding: 0;
	list-style: none;
}
.show_hide1 {
	margin: 3px 0 0 0;
	text-align: center;
	overflow: hidden;
}
.show_hide2 {
	margin: 3px 0 0 0;
	text-align: center;
	overflow: hidden;
}
.slidingDiv {
	width: 170px;
	position: absolute;
	margin: 30px 0 0 -382px;
	left: 50%;
	display: inline;
}
.slidingDiv1 {
	width: 170px;
	position: absolute;
	margin: 5px 0 0 -207px;
	left: 23%;
	display: inline;
}
.fan_showhide1 {
	width: 200px;
	margin: 3px 0 0 0;
	text-align: left;
	overflow: hidden;
	cursor: pointer;
}
.fan_close {
	width: 200px;
	margin: 3px 0 0 0;
	text-align: right;
	overflow: hidden;
	cursor: pointer;
}
.Fanpagediv {
	width: 500px;
	position: absolute;
	margin: 30px 0 0 -382px;
	left: 60%;
	display: inline;
	border: 1px solid #044d85;
}
.Fanpagediv1 {
	width: 500px;
	position: absolute;
	margin: 5px 0 0 -260px;
	left: 60%;
	display: inline;
	border: 1px solid #044d85;
}
.slidingDiv2 {
	width: 170px;
	position: absolute;
	margin: 5px 0 0 -33px;
	left: 23%;
	display: inline;
}
.pop_up_bx {
	width: 170px;
	overflow: hidden;
}
.pop_up_bx_top {
	width: 170px;
	height: 15px;
	overflow: hidden;
	background: url(../Content/images/pop_up_t_b.png) no-repeat;
}
.pop_up_bx_mid_inn {
	width: 154px;
	padding: 0 8px;
}
.pop_up_bx_mid_inn ul {
	width: 154px;
	padding: 0 0px;
	float: left;
}
.pop_up_bx_mid_inn ul li {
	width: 154px;
	padding: 0 0px;
	float: left;
}
.pop_up_bx_mid_inn ul li a {
	width: 118px;
	text-decoration: none;
	padding: 5px 18px;
	float: left;
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	font-weight: bold;
	color: #000;
}
.pop_up_bx_mid_inn ul li a:hover, .pop_up_bx_mid_inn .act {
	width: 118px;
	padding: 5px 18px;
	float: left;
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	font-weight: bold;
	color: #fff;
	background: #003399;
}
.pop_up_bx_bot {
	width: 170px;
	height: 15px;
	overflow: hidden;
	background: url(../Content/images/pop_up_t_b.png) no-repeat;
	background-position: 0 -15px;
}
.pop_up_bx_mid {
	width: 170px;
	height: 280px;
	background: url(../Content/images/pop_up_mid.png) repeat-y;
}
.pop_up_bx_top_fan_page {
	width: 500px;
	height: 40px;
	overflow: hidden;
	background-image: url(../Content/images/popup_top.png);
	background-repeat: no-repeat;
	background-position: top;
}
.pop_up_bx_mid_fan_page {
	width: 500px;
	background: url(../Content/images/pop_up_mid.png) repeat-y;
}
.pop_up_bx_mid_inn_fan_page {
	width: 474px;
	padding: 08px;
	background-color: #fff;
	border-left: 5px solid #536ba1;
	border-right: 5px solid #536ba1;
}
.pop_up_bx_bot_fan_page {
	width: 500px;
	height: 50px;
	overflow: hidden;
	background-image: url(../Content/images/popup_bottom.png);
	background-repeat: no-repeat;
	background-position: bottom;
}
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $.fx.speeds._default = 1000;
        $(".Fanpagediv1").hide();
        $(".fan_showhide1").show();
        $('.fan_showhide1').click(function () {
            $(".Fanpagediv1").slideToggle();
        });
        $('.fan_close').click(function () {
            $(".Fanpagediv1").slideToggle();
        });


        $(".Fanpagesdiv1").hide();
        $(".fans_showhide1").show();
        $('.fans_showhide1').click(function () {
            $(".Fanpagesdiv1").show("slow");
            $(".Attachdiv1").hide("slow");
            $(".Calenderdiv1").hide("slow");
        });
        $('.fans_close').click(function () {
            $(".Fanpagesdiv1").hide("slow");

        });
    });

    </script>
<script type="text/javascript">
    $(document).ready(function () {
        $.fx.speeds._default = 1000;
        $('.photo_video').click(function () {
            $(".composediv1").show("slow");
        });
    });

    </script>
</head>
<body>
<form id="form1" runat="server">
  <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
  <div id="innerpagepagemain">
  <uc1:inner1 ID="inner1" runat="server" />
  <div id="centermain">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td align="left" valign="top" class="leftbg"><uc3:left ID="left1" runat="server" /></td>
      <td align="left" valign="top" class="contentbody"><div style="padding-bottom:10px;">
          <center>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
          </center>
        </div>
        <table width="100%" border="0" cellpadding="2" cellspacing="0">
          <tr>
            <td colspan="2" valign="middle"><span class="photo_video"><img src="../Content/images/add_photo_video.gif" width="16" height="14" align="absmiddle" />&nbsp;<strong><a href="javascript:;" class="graylink">Upload Sidebar Image&nbsp;</a></strong></span></td>
          </tr>
          <tr>
            <td colspan="2" align="center"><input type="hidden" id="hdnselectedPages" runat="server" name="hdnselectedPages"
                                                                    value="" />
              <input type="hidden" id="hdnSelectedPagesName" runat="server" name="hdnSelectedPagesName"
                                                                    value="" />
              <input type="hidden" id="hdnSelectedPagesImage" runat="server" name="hdnSelectedPagesImage"
                                                                    value="" />
              <input type="hidden" id="hdnselectedPagesAccessToken" runat="server" name="hdnselectedPagesAccessToken"
                                                                    value="" /></td>
          </tr>
          <tr>
            <td height="25" align="right" valign="top"></td>
            <td height="25" align="left" ><div class="composediv1" style="z-index: 1000;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td align="left" valign="top" class="popupbordertop" style="padding-left:0px;"><img src="../Content/images/popup_border_top.gif" width="15" height="6" /></td>
                  </tr>
                  <tr>
                    <td align="left" valign="top" class="popupborder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td align="left" valign="top" style="padding:20px; font-family:arial;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td><input name="source" type="file" id="photo" runat="server"/> &nbsp; &nbsp;
                                <%--<input name="Upload Video" type="file" id="flVideo" runat="server"/>--%>
                                  <div style="padding-left:10px;"> <img id="imgLoading" src="<%=ResolveUrl("~/Content/images/uploading.gif")%>" style="display:none" /> </div></td>
                              </tr>
                            </table></td>
                        </tr>
                        <tr>
                          <td align="left" valign="middle" class="popupinnerbg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td width="57%" height="31" align="left" valign="middle"><span class="fans_showhide1"><img src="../Content/images/selectfanpage_icon.gif" width="15" height="16" align="top" style="padding-left:12px; padding-right:6px;" /><a href="javascript:;" style="color:#666;">Selected Fan Page</a></span></td>
                              </tr>
                            </table></td>
                          <td align="left" valign="middle" class="popupinnerbg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td width="35%" height="31" align="right" valign="middle" style="padding-right:5px;"><a href="javascript:;" class="bluetablink" runat="server" onclick="return ValidateAlbum();ShowProgress();" id="lnkUploadPhoto">Upload Photo</a>&nbsp;&nbsp;
                                <%--<a href="javascript:;" class="bluetablink" runat="server" onclick="return ValidateVideoUpload();" id="lnkUploadVideo">Upload Video</a></td>--%>
                              </tr>
                            </table></td>
                        </tr>
                      </table></td>
                  </tr>
                </table>
              </div></td>
          </tr>
          <tr>
            <td></td>
          </tr>
          <tr>
            <td height="25" align="right"></td>
            <td height="30" align="left"><div class="Fanpagesdiv1" style="display:none; z-index: 1000; ">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td align="left" valign="top" class="greypopupbordertop"><img src="../Content/images/grey_popup_top.gif" width="31" height="11" /></td>
                  </tr>
                  <tr>
                    <td align="left" valign="top" class="greypopupborder" style="padding:13px; padding-bottom:16px; padding-right:0px;">
                     <asp:DataList ID="dstFanPages" runat="server" RepeatColumns="3">
                      <ItemTemplate>
                        <table width="240" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="48" align="left" valign="middle" >
                            <img src='<%#Eval("picture")%>' width="40" height="40" style="margin-bottom:10px;" group="pageimg"pageid='<%#Eval("Id")%>' />

                              </td>
                            <td width="40" align="left" valign="middle" style="padding-right:10px;" ><table border="0" width="170" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="25" align="left" valign="middle"><input class="checkboxpadding" type="checkbox" id="chkPage" name="chkPage" runat="server" pageid='<%#Eval("Id")%>' group="pages" onclick='Pageid(this);'  pageaccess_token='<%#Eval("access_token")%>' pagevalue='<%#Eval("name")%>' pageimage='<%#Eval("picture")%>' /></td>
                                  <td align="left" width="150" valign="middle"><%#Eval("name")%>
                                    <input type="hidden" id="hdnPageId" runat="server" value='<%#Eval("Id")%>' />
                                    <input type="hidden" id="hdnPageName" runat="server" value='<%#Eval("name")%>' />
                                    <input type="hidden" id="hdnAccessToken" runat="server" value='<%#Eval("access_token")%>' />
                                    <input type="hidden" id="hdnImage" runat="server" value='<%#Eval("picture")%>' />
                                  </td>
                                </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td align="left" height="10" colspan="2">&nbsp; 
                            </td>
                          </tr>
                        </table>
                      </ItemTemplate>
                    </asp:DataList>
                    
                    
                    
                    <%--<asp:DataList ID="dstFanPages" runat="server" RepeatColumns="4">
                        <ItemTemplate>
                          <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="99" align="left" valign="middle"><img src='<%#Eval("picture")%>' width="66" height="66" style="margin-bottom:10px;" group="pageimg"
                                                                                                    pageid='<%#Eval("Id")%>' /><br />
                                <table border="0" width="150" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td width="15" align="left" valign="middle"><input class="checkboxpadding" type="checkbox" id="chkPage" name="chkPage" runat="server" pageid='<%#Eval("Id")%>' group="pages" onclick='Pageid(this);'  pageaccess_token='<%#Eval("access_token")%>' pagevalue='<%#Eval("name")%>' pageimage='<%#Eval("picture")%>' /></td>
                                    <td align="left" width="150" valign="middle"><%#Eval("name")%>
                                      <input type="hidden" id="hdnPageId" runat="server" value='<%#Eval("Id")%>' />
                                      <input type="hidden" id="hdnPageName" runat="server" value='<%#Eval("name")%>' />
                                      <input type="hidden" id="hdnAccessToken" runat="server" value='<%#Eval("access_token")%>' />
                                      <input type="hidden" id="hdnImage" runat="server" value='<%#Eval("picture")%>' />
                                    </td>
                                  </tr>
                                </table></td>
                              <td width="40" align="left" valign="top" class="graylineh">&nbsp;</td>
                            </tr>
                            <tr>
                              <td align="left" height="10" colspan="2">&nbsp;</td>
                            </tr>
                          </table>
                        </ItemTemplate>
                      </asp:DataList>--%>
                    </td>
                  </tr>
                </table>
              </div></td>
          </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
    </div>
    
  </table>
  </td>
  </tr>
  </table>
  </div>
  </div>
  <div> </div>
  <uc2:inner ID="inner2" runat="server" />
</form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function Checked(_this) {

        if ($(_this).attr("checked") == "checked") {
            $('input[group^=page]').each(
				function () {
				    $(this).attr("checked", false)
				}
			);
            $(_this).attr("checked", true);
            $('img[group^=pageimg]').each(
				function () {
				    $(this).removeClass("imgborderSelected");
				    $(this).addClass("imgborder");
				}
			);
            $('img[group^=pageimg]').each(
				function () {
				    if ($(this).attr("pageid") == $(_this).attr("pageid")) {
				        $(this).removeClass("imgborder");
				        $(this).addClass("imgborderSelected");
				    }

				}
			);


        }
        else {
            $('input[group^=page]').each(
				function () {
				    $(this).attr("checked", false)
				}
			);
            $('img[group^=pageimg]').each(
				function () {
				    $(this).removeClass("imgborderSelected");
				    $(this).addClass("imgborder");
				}
			);
        }

    }
    </script>
<script type="text/javascript" language="javascript">
    function ShowInfo(ID) {
        $("tr[Group^=Info]").each(
			function () {
			    $(this).css("display", "none");
			}
		);
        $('#' + ID).css("display", "");

        $("td[Group^=InfoTr]").each(
			function () {
			    $(this).removeClass('activetab');
			    $(this).addClass('inactivetab');
			}
		);
        var lnkID = "lnk" + ID.replace("tr", "");
        $('#' + lnkID).removeClass('inactivetab');
        $('#' + lnkID).addClass('activetab');
    }


    </script>
<script type="text/javascript" language="javascript">
    function HideProgress() {
        parent.document.getElementById("imgLoading").style.display = 'none';

    }
    function ShowProgress() {
        parent.document.getElementById("imgLoading").style.display = 'block';
    }
    function ChangeTab(Id, Tab) {
        $('tr[group^=libtr]').each(
	function () {
	    $(this).css('display', 'none');
	});
        $('#' + Id).css('display', '');
        if (Tab == 1) {
            $('#imgAdminLib').attr('src', "../content/images/company_library_tab.gif");
            $('#imgMyLib').attr('src', "../content/images/my_library_hover_tab.gif");

        }
        else {
            $('#imgAdminLib').attr('src', "../content/images/company_library_hover_tab.gif");
            $('#imgMyLib').attr('src', "../content/images/my_library_tab.gif");
        }

    }
    function ShowLib(Id) {
        $('tr[group^=libcattr]').each(
	function () {
	    $(this).css('display', 'none');

	});

        $('#trLibCat' + Id).slideDown('slow');
    }
    function ShowUserLib(Id) {
        $('tr[group^=userlibcattr]').each(
	function () {
	    $(this).css('display', 'none');

	});

        $('#trUserLibCat' + Id).slideDown('slow');
    }
    function EditLib(Id) {
        $('#txtMessage').val($.trim($('#spnlib' + Id).html()).replace("<br>"));
    }
    function SelectLibCat() {
        $('#trNew').css('display', '');
        $('#trCreateNew').css('display', 'none');
        $('#txtNewLibCat').val('');
        $('#hdnLibCatId').val('0');
        var pos = $('#lnkSaveToMyLib').position();
        pos.left = parseInt(pos.left);
        pos.top = parseInt(pos.top);
        var x = pos.left;
        var y = pos.top;
        $('#divLibCat').css('left', x - 25 + 'px')
        $('#divLibCat').css('top', y + 30 + 'px')

        if ($('#divLibCat').css('display') == 'none') {
            $('#divLibCat').slideDown('slow');
        }
        else {
            $('#divLibCat').slideUp('slow');
        }

    }
    function CreateNewLibCat() {
        $('#trNew').css('display', 'none');
        $('#trCreateNew').css('display', '');
        $('#txtNewLibCat').val('');
        $('#hdnLibCatId').val('-1');

    }
    function ValidateNewLibCat() {
        if ($('#txtNewLibCat').val() == '') {
            $('#txtNewLibCat').addClass("error");
            return false;
        }
        else {

            if ($('#txtMessage').val() == '') {
                $('#txtMessage').addClass('error');
                alert("Plese enter library!")
                return false;
            }
            else {
                $('#txtNewLibCat').removeClass("error");
                $('#divLibCat').slideUp('slow');
                return true;
            }

        }

    }
    function ValidateLib() {
        $('#hdnLibCatId').val('0');
        $('#trNew').css('display', '');
        $('#trCreateNew').css('display', 'none');
        $('#txtNewLibCat').val('');
        if ($('#txtMessage').val() == '') {
            $('#txtMessage').addClass('error');
            alert("Plese enter library!")
            return false;
        }
        else {
            $('#txtMessage').removeClass('error');
            $('#divLibCat').slideUp('slow');
            return true;
        }
    }
    function Promt() {
        return (confirm("Are you sure you want to delete this library?"))
    }
    function ValidateVideo() {

        var Title = "Fill in Following Information\n";
        var fields = "";

        if (selectedpages() == false) {
            fields = fields + "\n-- Fan page(s) --";
        }

        if ($.trim($('#txtvideo').val()) == '') {
            fields = fields + "\n-- Video Link --";
        }

        selectedpagesAccessToken();
        selectedpageimage();
        selectedpagesName();

        if (fields.length > 0) {
            alert(Title + fields);
            return false;
        }
        else {

            return true;
        }

    }
</script>
