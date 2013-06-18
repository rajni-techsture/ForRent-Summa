<%@ Page Language="vb" AutoEventWireup="false" Debug="true" validateRequest="false" CodeBehind="publish-custom-tab.aspx.vb" Inherits="tsma.publish_custom_tab" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body {
	    padding:0px;
	    margin:0px 0px 0px 0px;
	    font-family: arial;
	    font-size:12px;
	    background-color:#FFF;
    }
    </style>
	<link  href="<%=ResolveUrl("~/Content/css/site.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Content/js/pagejs/scheduler.js")%>" type="text/javascript"></script>
    <script type="text/javascript" >
	function SaveAlert()
				{
				    $("#DivSaveSidebar").show("slow");
				}
				function HideSaveAlert() {
				    $("#DivSaveSidebar").hide("slow");
				}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DivPublishCustomTab" style="width:100%; height:100%; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:10000000; text-align:center;  display:none;">
			  <div id="popup_container1" >
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  Sidebar Published Succefully<br/><br/>
                   <input type="button" class="inputbutton" onclick="HideSaveAlert();" value="Close" id="popup_close" />
				</div>
			 </div>
			 </div>
    <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 16px; color: #181818; margin:0px;	font-weight:bold;
	line-height:18px; text-align:center">Publish sidebar on Facebook Business pages</div><br />
   <div style="padding-bottom:10px; ">
          <center>
           <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></center>
</div>
           <div id="divSidebarHtml" runat="server" align="left" style="float:left; width:200px; display:none;">
            </div>
            <div align="left" style="float:left; width:550px;">
            
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="33" align="left" valign="middle"><img src="Content/images/quick_start_tutorial_left_arrow_gray.png" width="33" height="101" /></td>
    <td align="left" valign="top" style="background-color:#f0f0f0; padding:10px; padding-bottom:0px">
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top">
    <div style="background-color:#FFF; border:1px solid #bdc7d8; padding:20px; padding-right:0px;">
             <input type="hidden" id="hdnselectedPages" runat="server" name="hdnselectedPages"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesName" runat="server" name="hdnSelectedPagesName"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesImage" runat="server" name="hdnSelectedPagesImage"
                                                                    value="" />
                  <input type="hidden" id="hdnselectedPagesAccessToken" runat="server" name="hdnselectedPagesAccessToken"
                                                                    value="" />
<asp:DataList ID="dstFanPages" runat="server" RepeatColumns="2">
                      <ItemTemplate>
                        <table width="230" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="48" align="left" valign="middle" >
                            <img src='<%#Eval("picture")%>' width="40" height="40" style="margin-bottom:10px;" group="pageimg" pageid='<%#Eval("Id")%>' />

                              </td>
                            <td width="40" align="left" valign="middle" style="padding-right:10px;" ><table border="0" width="170" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="25" align="left" valign="middle">
                                  <input class="checkboxpadding" type="radio" id="chkPage" name="chkPage" runat="server" pageid='<%#Eval("Id")%>' group="pages" onclick='Pageid(this);'  pageaccess_token='<%#Eval("access_token")%>' pagevalue='<%#Eval("name")%>' pageimage='<%#Eval("picture")%>' /></td>
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
     </div>
    
    </td>
  </tr>
  <tr>
    <td height="50" align="left" valign="middle">
    <a id="btnUpload" class="bluetablink" runat="server" onClick="return ValidatePublish();ShowProgress();" title="Publish Business Page">Publish Business Page</a>&nbsp;<a id="lnkDownload" class="bluetablink" runat="server" title="Download Sidebar" style="display:none;">Download Sidebar</a></td>
  </tr>
</table>

    
    
    </td>
  </tr>
  </table>

     
     </div>
      <div style="padding-left:10px;">
                                  <img id="imgLoading" src="<%=ResolveUrl("~/Content/images/uploading.gif")%>" style="display:none;" />
                                  </div>


    <%--<div class="rm-css-edit bg bgtrans bgimg" rel="rm-css-bg bgtrans1" style="width:180px;background-color:#A67C52;">
        <div align="center" id="divWidthHeight1" runat="server" style="width:180px; height:525px; background-image:url(content/sidebar-images/sidebar3_bg_onlypatren.png); background-repeat:no-repeat; background-position:top;padding-top: 1px;" >
        <div style="text-align: center; position: relative; margin: 5px; border: 4px solid rgb(255, 255, 255); width: 155px; height: 92px;" class="rm-css-edit bg bgtrans bgimg thumb bg bgtranstrans" rel="rm-css-bg bgtrans102" ><div  style="height: 86px; background: url(content/sidebar-images/sidebar3_image_or_logo.png) repeat scroll 0% 0% transparent; position: relative; margin: 3px;"  class="rm-css-edit bg bgtrans bgimg thumb bg bgtranstrans" rel="rm-css-bg bgtrans2" ></div></div>
        <div style="margin:3px;; height:50px; font-family:Georgia; font-size:26px; color:#FFF; text-align:center;"><span class="rm-css-edit fg fgtype" rel="rm-css-text1" >HEADLINE</span></div>
        <div style="width:180px; height:64px; font-family:Georgia; font-size:18px; color:#FFF; text-align:center; font-style:italic;  "><span class="rm-css-edit fg fgtype" rel="rm-css-text2" >Your Tag Line<br />Goes Here </span></div>
        <div style="width:168px; height:107px; font-family:Arial; font-size:11px; color:#000000; text-align:left; font-weight:bold; padding-left:10px; font-style:italic;  "><span class="rm-css-edit fg fgtype" rel="rm-css-text3" >Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet</span></div>
        <div style="position:relative;width:180px; height:134px;" align="left">
        <div style="width:180px; height:134px; font-family:Arial; font-size:22px; color:#533e29; text-align:center;" class="hide" ><br>Insert Image <br> Text Disappears after download</div>
        <div style="position:absolute;z-index:100;width:180px; height:134px;top:0px;;" class="rm-css-edit bg bgtrans bgimg" rel="rm-css-bg bgtrans3" >

        </div>
        </div>
        <div style="text-align:center; line-height:26px; width:180px; height:55px;"><span style="font-family:Georgia; font-size:24px; color:#FFF; text-align:center; font-style:italic;" class="rm-css-edit fg fgtype" rel="rm-css-text4">Information</span>
        <span style="font-family:Georgia; font-size:22px; color:#FFF; text-align:center; font-weight:bold; " class="rm-css-edit fg fgtype" rel="rm-css-text5" >website</span></div>
        </div>
     </div>--%>
     
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
            alert(fields);
            return false;
        }
        else {

            return true;
        }

    }
</script>









