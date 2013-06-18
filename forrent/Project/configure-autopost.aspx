<%@ Page Language="vb" AutoEventWireup="false"  EnableEventValidation="false"  CodeBehind="configure-autopost.aspx.vb" Inherits="tsma.config_autopost" %>


<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner1" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
<%--<meta http-equiv="refresh" content="60">--%>
<title>Total Social Media Application</title>
<script src="<%=ResolveUrl("~/Content/css/SpryTabbedPanels.js")%>" type="text/javascript"></script>
<link href="<%=ResolveUrl("~/Content/css/SpryTabbedPanels.css")%>" rel="stylesheet" type="text/css" />
<link href="<%=ResolveUrl("~/Content/facebookalert/facebookalert_files/facebook.alert.css")%>" rel="stylesheet" type="text/css">
<script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
<script src="<%=ResolveUrl("~/Content/js/jquery-ui.min.js") %>" type="text/javascript"></script>
<script src="<%=ResolveUrl("~/content/js/pagejs/scheduler.js") %>" type="text/javascript"></script>
<script type="text/javascript" language="javascript">

    function SaveAlert(mess) {
        var maskHeight1 = $(document).height();
        var maskWidth1 = $(window).width();
        $('#DivSaveSidebar').css({ 'width': maskWidth1, 'height': maskHeight1 });
        $("#spnMessage").html(mess);
        $("#DivSaveSidebar").show("slow");
		
    }
    function HideSaveAlert() {
        $("#DivSaveSidebar").hide("slow");
		window.location.href='configure-autopost';
    }

    function SaveScheduleAlert(mess) {
        var maskHeight1 = $(document).height();
        var maskWidth1 = $(window).width();
        $('#DivSaveScheduler').css({ 'width': maskWidth1, 'height': maskHeight1 });
        $("#spnSchduleMessage").html(mess);
        $("#DivSaveScheduler").show("slow");
    }

    function OpenAutoPostBusinessPageDiv() {
        var pos = $('#AutoPostOpener').position();
        pos.left = parseInt(pos.left);
        pos.top = parseInt(pos.top);
        var x = pos.left;
        var y = pos.top;
        $('#divAutoPostFanPages').css('left', x - 425 + 'px')
        $('#divAutoPostFanPages').css('top', y + 30 + 'px')

        if ($('#divAutoPostFanPages').css('display') == 'none') {
            $('#divAutoPostFanPages').slideDown('slow');
        }
        else {
            $('#divAutoPostFanPages').slideUp('slow');
        }
    }

    function HideAutoPostFanPages() {
        $('#divAutoPostFanPages').hide("slow");
    }
  
    function ShowAutoPostOnOff(mess) {
        var maskHeight = $(document).height();
        var maskWidth = $(window).width();
        $('#DivShowAutoPostOnOff').css({ 'width': maskWidth, 'height': maskHeight });

        $('#spnShuffleMess').html(mess);
        $('#DivShowAutoPostOnOff').show("slow");
    }
    function HideAutoPostOnOff() {
        $('#DivShowAutoPostOnOff').hide("slow");
    }
  
    function ShowUserLib(Id) {
        $('#trAdminLib').css('display', 'none');
        $('#trMyLib').css('display', '');
        $('#imgAdminLib').attr('src', "../content/images/company_library_hover_tab.gif");
        $('#imgMyLib').attr('src', "../content/images/my_library_tab.gif");
        $('tr[group^=userlibcattr]').each(
		function () {
		    $(this).css('display', 'none');

		});
        $('#trUserLibCat' + Id).slideDown('slow');
    }

  
    function ShowDiv(id) {
        $("#" + id).show("slow");
    }
    function HideDiv(id) {
        $("#" + id).hide("slow");
    }
	
	
	    function showFangPageDiv() {
            $('#divFanPageDrp').show();
			 $('#divClearAll').css('display', '');
			
        }
		
		
	</script>
<style>
.error {
	border:1px solid #FF0000;
}
.popupbg{
	width:530px;
	border:8px solid #9c9c9c;
	border-radius: 6px 6px 6px 6px;
	padding:15px;
	background-color:#FFF;
}
</style>

</head>
<body onload="showFangPageDiv();">
<form id="form1" runat="server">
  <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
  <div id="innerpagepagemain">
    <uc1:inner1 ID="inner1" runat="server" />
    <div id="centermain">
    <div id="DivSaveSidebar" style="width:100%; height:1450px; text-align:center; background-image:url(../Content/facebookalert/images/popup_bg.png); position:absolute; z-index:999999999; text-align:center; padding-left:150px;  display:none;">
			  <div id="popup_container1" style="width:450px;">
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                   <span id="spnMessage"></span><br/><br/>
                   <input type="button" class="inputbutton" onclick="HideSaveAlert();" value="Close" style="cursor:pointer;" id="popup_close1" />
				</div>
			 </div>
	</div>
    <div id="DivSaveScheduler" style="width:100%; height:1450px; text-align:center; background-image:url(../Content/facebookalert/images/popup_bg.png); position:absolute; z-index:999999999; text-align:center; padding-left:150px;  display:none;">
			  <div id="popup_container1" style="width:450px;">
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                   <span id="spnSchduleMessage"></span><br/><br/>
                   <a href="../scheduler-main" id="lnkSchduler" class="bluetablink">Close</a>
				</div>
			 </div>
	</div>
    <div id="DivShowAutoPostOnOff" style="width:100%; height:100%; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:999999999; text-align:center; padding-left:150px;  display:none;">
                          <div id="popup_AutoPostContainer" >
                            <div id="popup_AutoPostContent" style="padding-top:10px; padding-left:20px; text-align:left; line-height:17px;"> <span id="spnShuffleMess"></span><br/><br/>
                              <input type="button" class="inputbutton" onclick="HideAutoPostOnOff();" style="cursor:pointer;" value="Close" id="popup_close" />
                            </div>
                          </div>
                        </div>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="170" align="left" valign="top" class="leftbg" style="width:172px;"><uc3:left ID="left1" runat="server"/></td>
          <td align="left" valign="top" class="contentbody" style="padding-left:10px; padding-right:10px;"><div style="padding-bottom:10px;">
              <center>
                <asp:Label ID="lblMessage" ForeColor="#FF0000" Font-Bold="false" Font-Size="12" runat="server"></asp:Label>
              </center>
              <h6> Set Daily Autopost</h6>
              
            </div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td colspan="2" valign="middle">&nbsp;</td>
              </tr>
              <tr>
                <td colspan="2" align="left"><input type="hidden" id="hdnselectedPages" runat="server" name="hdnselectedPages"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesName" runat="server" name="hdnSelectedPagesName"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesImage" runat="server" name="hdnSelectedPagesImage"
                                                                    value="" />
                  <input type="hidden" id="hdnselectedPagesAccessToken" runat="server" name="hdnselectedPagesAccessToken"
                                                                    value="" /></td>
              </tr>
              <tr>
                <td align="left"></td>
              </tr>
              <tr>
                <td height="20"></td>
                <td height="32" align="left" valign="bottom" ><div id="TabbedPanels1" class="TabbedPanels">
                    <ul class="TabbedPanelsTabGroup" style="padding-left:27px; width:725px;" >
                      <li class="TabbedPanelsTab" tabindex="0" >Set Daily Autopost &nbsp;
                        <asp:Literal ID="ltrAutoPostTotal" runat="server" Visible="false"></asp:Literal> 
                        <asp:PlaceHolder ID="pnlOff" runat="server" Visible="false"> <img src='<%=ResolveUrl("Content/images/Off_bullate.png") %>' width="10" height="10" hspace="3" border="0" />Off </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pnlOn" runat="server" Visible="false"> <img src='<%=ResolveUrl("Content/images/On_bullate.png") %>' width="10" height="10" hspace="3" border="0" />On </asp:PlaceHolder>
                       <%-- &nbsp;<img id="imgOnOff" runat="server"/>&nbsp;
                        <asp:Literal ID="ltrOnOffText" runat="server"></asp:Literal>--%>
                        <input type="hidden" id="hdnAutoPostOnOff" runat="server" value="0"/>
                      </li>
                       <li class="TabbedPanelsTab" tabindex="1">View Scheduled Posts
                      </li>
                      <li class="TabbedPanelsTab" tabindex="1">Content Library
                      </li>
                      <li class="TabbedPanelsTab" tabindex="0">Create Your Own
                      </li>
                     
                    </ul>
                    <div class="TabbedPanelsContentGroup"  style="width:725px;">
                      <div class="TabbedPanelsContent">
                        
                        <table width="700" border="0" cellpadding="0" cellspacing="0" style="padding-top:10px;">
                        <tr>
                        <td>&nbsp;</td>
                        </tr>
                          <tr>
                            <td align="left" valign="top" bgcolor="#f0f0f0" style="padding:15px;"><div align="center" style="text-align:center">
                                <asp:Literal ID="ltrAutoPostError" runat="server"></asp:Literal>
                              </div>
                              <div style="padding-bottom:7px;"><strong>1. Set Date/Time</strong></div>
                              <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="100" align="left" valign="top"><select id="selAutoPostActivationHour" name="selAutoPostActivationHour" runat="server" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:85px;">
                                      <option value="0">Hour</option>
                                      <option value="1">1</option>
                                      <option value="2">2</option>
                                      <option value="3">3</option>
                                      <option value="4">4</option>
                                      <option value="5">5</option>
                                      <option value="6">6</option>
                                      <option value="7">7</option>
                                      <option value="8">8</option>
                                      <option value="9">9</option>
                                      <option value="10">10</option>
                                      <option value="11">11</option>
                                      <option value="12">12</option>
                                    </select>                                  </td>
                                  <td width="100" align="left" valign="top"><select id="selAutoPostActivationMinute" name="selAutoPostActivationMinute" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:85px;" runat="server">
                                      <option value="Minute">Minute</option>
                                      <option value="0">00</option>
                                      <option value="15">15</option>
                                      <option value="30">30</option>
                                      <option value="45">45</option>
                                  </select></td>
                                  <td width="100" align="left" valign="top"><select id="selAutoPostAMPM" name="selAutoPostAMPM" runat="server" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:85px;">
                                      <option value="0">AM/PM</option>
                                      <option value="AM">AM</option>
                                      <option value="PM">PM</option>
                                    </select></td>
                                  <td  align="left" valign="top">
                                  <asp:DropDownList  ID="ddlAutoPostTimeZone" runat="server" style="border:1px solid #CCC; font-family:Arial; font-size:12px; color:#666; height:24px; padding:2px; width:255px;">
                                      <asp:ListItem Value="0"> Select a TimeZone </asp:ListItem>
                                      <asp:ListItem Value="Eastern Standard Time">Eastern Timezone (UTC -5.00)</asp:ListItem>
                                      <asp:ListItem Value="Central Standard Time">Central Timezone (UTC -6.00)</asp:ListItem>
                                      <asp:ListItem Value="Mountain Standard Time">Mountain Timezone (UTC -7.00)</asp:ListItem>
                                      <asp:ListItem Value="Pacific Standard Time">Pacific Timezone (UTC -8.00)</asp:ListItem>
                                      <asp:ListItem value="Dateline Standard Time">(UTC-12:00) International Date Line West</asp:ListItem>
                                      <asp:ListItem value="Samoa Standard Time">(UTC-11:00) Midway Island, Samoa</asp:ListItem>
                                      <asp:ListItem value="Hawaiian Standard Time">(UTC-10:00) Hawaii</asp:ListItem>
                                      <asp:ListItem value="Alaskan Standard Time">(UTC-09:00) Alaska</asp:ListItem>
                                      <asp:ListItem value="Pacific Standard Time (Mexico)">(UTC-08:00) Tijuana, Baja California</asp:ListItem>
                                      <asp:ListItem value="US Mountain Standard Time">(UTC-07:00) Arizona</asp:ListItem>
                                      <asp:ListItem value="Mountain Standard Time (Mexico)">(UTC-07:00) Chihuahua, La Paz, Mazatlan</asp:ListItem>
                                      <asp:ListItem value="Central America Standard Time">(UTC-06:00) Central America</asp:ListItem>
                                      <asp:ListItem value="Central Standard Time (Mexico)">(UTC-06:00) Guadalajara, Mexico City, Monterrey</asp:ListItem>
                                      <asp:ListItem value="Canada Central Standard Time">(UTC-06:00) Saskatchewan</asp:ListItem>
                                      <asp:ListItem value="SA Pacific Standard Time">(UTC-05:00) Bogota, Lima, Quito</asp:ListItem>
                                      <asp:ListItem value="US Eastern Standard Time">(UTC-05:00) Indiana (East)</asp:ListItem>
                                      <asp:ListItem value="Venezuela Standard Time">(UTC-04:30) Caracas</asp:ListItem>
                                      <asp:ListItem value="Paraguay Standard Time">(UTC-04:00) Asuncion</asp:ListItem>
                                      <asp:ListItem value="Atlantic Standard Time">(UTC-04:00) Atlantic Time (Canada)</asp:ListItem>
                                      <asp:ListItem value="SA Western Standard Time">(UTC-04:00) Georgetown, La Paz, San Juan</asp:ListItem>
                                      <asp:ListItem value="Central Brazilian Standard Time">(UTC-04:00) Manaus</asp:ListItem>
                                      <asp:ListItem value="Pacific SA Standard Time">(UTC-04:00) Santiago</asp:ListItem>
                                      <asp:ListItem value="Newfoundland Standard Time">(UTC-03:30) Newfoundland</asp:ListItem>
                                      <asp:ListItem value="E. South America Standard Time">(UTC-03:00) Brasilia</asp:ListItem>
                                      <asp:ListItem value="Argentina Standard Time">(UTC-03:00) Buenos Aires</asp:ListItem>
                                      <asp:ListItem value="SA Eastern Standard Time">(UTC-03:00) Cayenne</asp:ListItem>
                                      <asp:ListItem value="Greenland Standard Time">(UTC-03:00) Greenland</asp:ListItem>
                                      <asp:ListItem value="Montevideo Standard Time">(UTC-03:00) Montevideo</asp:ListItem>
                                      <asp:ListItem value="Mid-Atlantic Standard Time">(UTC-02:00) Mid-Atlantic</asp:ListItem>
                                      <asp:ListItem value="Azores Standard Time">(UTC-01:00) Azores</asp:ListItem>
                                      <asp:ListItem value="Cape Verde Standard Time">(UTC-01:00) Cape Verde Is.</asp:ListItem>
                                      <asp:ListItem value="Morocco Standard Time">(UTC) Casablanca</asp:ListItem>
                                      <asp:ListItem value="UTC">(UTC) Coordinated Universal Time</asp:ListItem>
                                      <asp:ListItem value="GMT Standard Time">(UTC) Dublin, Edinburgh, Lisbon, London</asp:ListItem>
                                      <asp:ListItem value="Greenwich Standard Time">(UTC) Monrovia, Reykjavik</asp:ListItem>
                                      <asp:ListItem value="W. Europe Standard Time">(UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna</asp:ListItem>
                                      <asp:ListItem value="Central Europe Standard Time">(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague</asp:ListItem>
                                      <asp:ListItem value="Romance Standard Time">(UTC+01:00) Brussels, Copenhagen, Madrid, Paris</asp:ListItem>
                                      <asp:ListItem value="Central European Standard Time">(UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb</asp:ListItem>
                                      <asp:ListItem value="W. Central Africa Standard Time">(UTC+01:00) West Central Africa</asp:ListItem>
                                      <asp:ListItem value="Jordan Standard Time">(UTC+02:00) Amman</asp:ListItem>
                                      <asp:ListItem value="GTB Standard Time">(UTC+02:00) Athens, Bucharest, Istanbul</asp:ListItem>
                                      <asp:ListItem value="Middle East Standard Time">(UTC+02:00) Beirut</asp:ListItem>
                                      <asp:ListItem value="Egypt Standard Time">(UTC+02:00) Cairo</asp:ListItem>
                                      <asp:ListItem value="South Africa Standard Time">(UTC+02:00) Harare, Pretoria</asp:ListItem>
                                      <asp:ListItem value="FLE Standard Time">(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius</asp:ListItem>
                                      <asp:ListItem value="Israel Standard Time">(UTC+02:00) Jerusalem</asp:ListItem>
                                      <asp:ListItem value="E. Europe Standard Time">(UTC+02:00) Minsk</asp:ListItem>
                                      <asp:ListItem value="Namibia Standard Time">(UTC+02:00) Windhoek</asp:ListItem>
                                      <asp:ListItem value="Arabic Standard Time">(UTC+03:00) Baghdad</asp:ListItem>
                                      <asp:ListItem value="Arab Standard Time">(UTC+03:00) Kuwait, Riyadh</asp:ListItem>
                                      <asp:ListItem value="Russian Standard Time">(UTC+03:00) Moscow, St. Petersburg, Volgograd</asp:ListItem>
                                      <asp:ListItem value="E. Africa Standard Time">(UTC+03:00) Nairobi</asp:ListItem>
                                      <asp:ListItem value="Georgian Standard Time">(UTC+03:00) Tbilisi</asp:ListItem>
                                      <asp:ListItem value="Iran Standard Time">(UTC+03:30) Tehran</asp:ListItem>
                                      <asp:ListItem value="Arabian Standard Time">(UTC+04:00) Abu Dhabi, Muscat</asp:ListItem>
                                      <asp:ListItem value="Azerbaijan Standard Time">(UTC+04:00) Baku</asp:ListItem>
                                      <asp:ListItem value="Mauritius Standard Time">(UTC+04:00) Port Louis</asp:ListItem>
                                      <asp:ListItem value="Caucasus Standard Time">(UTC+04:00) Yerevan</asp:ListItem>
                                      <asp:ListItem value="Afghanistan Standard Time">(UTC+04:30) Kabul</asp:ListItem>
                                      <asp:ListItem value="Ekaterinburg Standard Time">(UTC+05:00) Ekaterinburg</asp:ListItem>
                                      <asp:ListItem value="Pakistan Standard Time">(UTC+05:00) Islamabad, Karachi</asp:ListItem>
                                      <asp:ListItem value="West Asia Standard Time">(UTC+05:00) Tashkent</asp:ListItem>
                                      <asp:ListItem value="India Standard Time">(UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi</asp:ListItem>
                                      <asp:ListItem value="Sri Lanka Standard Time">(UTC+05:30) Sri Jayawardenepura</asp:ListItem>
                                      <asp:ListItem value="Nepal Standard Time">(UTC+05:45) Kathmandu</asp:ListItem>
                                      <asp:ListItem value="N. Central Asia Standard Time">(UTC+06:00) Almaty, Novosibirsk</asp:ListItem>
                                      <asp:ListItem value="Central Asia Standard Time">(UTC+06:00) Astana, Dhaka</asp:ListItem>
                                      <asp:ListItem value="Myanmar Standard Time">(UTC+06:30) Yangon (Rangoon)</asp:ListItem>
                                      <asp:ListItem value="SE Asia Standard Time">(UTC+07:00) Bangkok, Hanoi, Jakarta</asp:ListItem>
                                      <asp:ListItem value="North Asia Standard Time">(UTC+07:00) Krasnoyarsk</asp:ListItem>
                                      <asp:ListItem value="China Standard Time">(UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi</asp:ListItem>
                                      <asp:ListItem value="North Asia East Standard Time">(UTC+08:00) Irkutsk, Ulaan Bataar</asp:ListItem>
                                      <asp:ListItem value="Singapore Standard Time">(UTC+08:00) Kuala Lumpur, Singapore</asp:ListItem>
                                      <asp:ListItem value="W. Australia Standard Time">(UTC+08:00) Perth</asp:ListItem>
                                      <asp:ListItem value="Taipei Standard Time">(UTC+08:00) Taipei</asp:ListItem>
                                      <asp:ListItem value="Tokyo Standard Time">(UTC+09:00) Osaka, Sapporo, Tokyo</asp:ListItem>
                                      <asp:ListItem value="Korea Standard Time">(UTC+09:00) Seoul</asp:ListItem>
                                      <asp:ListItem value="Yakutsk Standard Time">(UTC+09:00) Yakutsk</asp:ListItem>
                                      <asp:ListItem value="Cen. Australia Standard Time">(UTC+09:30) Adelaide</asp:ListItem>
                                      <asp:ListItem value="AUS Central Standard Time">(UTC+09:30) Darwin</asp:ListItem>
                                      <asp:ListItem value="E. Australia Standard Time">(UTC+10:00) Brisbane</asp:ListItem>
                                      <asp:ListItem value="AUS Eastern Standard Time">(UTC+10:00) Canberra, Melbourne, Sydney</asp:ListItem>
                                      <asp:ListItem value="West Pacific Standard Time">(UTC+10:00) Guam, Port Moresby</asp:ListItem>
                                      <asp:ListItem value="Tasmania Standard Time">(UTC+10:00) Hobart</asp:ListItem>
                                      <asp:ListItem value="Vladivostok Standard Time">(UTC+10:00) Vladivostok</asp:ListItem>
                                      <asp:ListItem value="Central Pacific Standard Time">(UTC+11:00) Magadan, Solomon Is., New Caledonia</asp:ListItem>
                                      <asp:ListItem value="New Zealand Standard Time">(UTC+12:00) Auckland, Wellington</asp:ListItem>
                                      <asp:ListItem value="Fiji Standard Time">(UTC+12:00) Fiji, Marshall Is.</asp:ListItem>
                                      <asp:ListItem value="Kamchatka Standard Time">(UTC+12:00) Petropavlovsk-Kamchatsky</asp:ListItem>
                                      <asp:ListItem value="Tonga Standard Time">(UTC+13:00) Nuku&#39;alofa</asp:ListItem>
                                    </asp:DropDownList>
                                  </td>
                                </tr>
                            </table></td>
                          </tr>
                          <tr>
                          <td align="right" height="40" valign="top"  bgcolor="#F0F0F0" style="padding-right:15px;">
                         <a href="javascript:;" id="AutoPostDay" onclick="HideAutoPostFanPages();showDaySelectionDiv();" runat="server" class="bluetablink">1. Select AutoPost Day:</a>
                      &nbsp;&nbsp;<a href="javascript:;" id="AutoPostOpener" onclick="HideAutopostDaySelection(); OpenAutoPostBusinessPageDiv();" runat="server" class="bluetablink">2. Add Business Page(s):</a>
                          &nbsp;&nbsp;
                            <a href="javascript:;" class="bluetablink" style="display:none;" id="lnkdisableImport">Please Wait...</a>
                          <a class="bluetablink" runat="server" onclick="return ValidateAutoPost();" id="lnkAutoPost">
                                    <asp:PlaceHolder ID="pnlAutoPostSet" runat="server">3. Set Autopost </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="pnlAutoPostUpdate" runat="server" Visible="false">3. Update Autopost </asp:PlaceHolder>
                                    </a>&nbsp;&nbsp;<asp:PlaceHolder ID="pnlAutoPostOff" runat="server" Visible="false"><a href="javascript:;" class="bluetablink" runat="server" id="lnkAutoPostOff">Turn Autopost <img src='<%=ResolveUrl("Content/images/Off_bullate.png") %>' width="10" height="10" hspace="3" border="0" />Off </a></asp:PlaceHolder> 
                              <asp:PlaceHolder ID="pnlAutoPostOn" runat="server" Visible="false"><a href="javascript:;" class="bluetablink" runat="server" id="lnkAutoPostOnOff" >Turn Autopost <img src='<%=ResolveUrl("Content/images/On_bullate.png") %>' width="10" height="10" hspace="3" border="0" />On </a></asp:PlaceHolder> </td>
                          </tr>
                          <tr>
                            <td align="left" valign="bottom" style="padding-top:10px;"><font style="line-height:20px; font-weight:bold">
                              <asp:Literal ID="ltrAutoPostPage" runat="server"></asp:Literal>
                              </font><br/>
                              
                              <div id="divAutoPostFanPages" style="display:none; z-index:100; width:745px; position:absolute; border:1px solid #CCCCCC; background-color:#f6f6f6;" title="Business Pages">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td align="right" valign="top"></td>
                                  </tr>
                                  <tr>
                                    <td align="left" valign="top" style="padding:20px; ">
                                    <asp:PlaceHolder id="plcAutoData" runat="server">
                                    <div style="height:125px; width:723px; overflow:auto; overflow-x:hidden;">
                                    <asp:DataList ID="dstAutoPostFanPages" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                        <ItemTemplate>
                                          <table id="NonFanPage" runat="server" width="230" style="overflow-x:scroll" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                              <td colspan="2" height="4"></td>
                                            </tr>
                                            <tr>
                                              <td width="48" align="left" valign="middle" style="background-color:#FFFFFF; border:1px solid #CCCCCC;" >
                                              <table border="0" cellspacing="0" cellpadding="0">
                                                  <tr>
                                                    <td align="center" valign="middle"><img src='<%#Eval("picture")%>' width="40" style=" border: 7px solid #ffffff" height="40" align="absmiddle" group="pageimg1" autopostpageid='<%#Eval("id")%>' /> </td>
                                                    <td align="center" valign="middle"><table border="0" width="170" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                          <td width="25" align="left" valign="middle" >
                                                          <input class="checkboxpadding" type="checkbox" id="autopostchkPage" name="autopostchkPage"
                                                           runat="server" autopostpageid='<%#Eval("id")%>' group="autopostpages" 
                                                           onclick='AutoPostPageid(this);SelectedAutoPostPagesName();'  autopostpageaccess_token='<%#Eval("access_token")%>' autopostpagevalue='<%#Eval("name")%>' autopostpageimage='<%#Eval("picture")%>'/></td>
                                                          <td align="left" width="150" valign="middle"><%#Eval("name")%>
                                                            <input type="hidden" id="hdnAutoPostPageId" runat="server" value='<%#Eval("id")%>' />
                                                            <input type="hidden" id="hdnAutoPostPageName" runat="server" value='<%#Eval("name")%>' />
                                                            <input type="hidden" id="hdnAutoPostAccessToken" runat="server" value='<%#Eval("access_token")%>' />
                                                            <input type="hidden" id="hdnAutoPostImage" runat="server" value='<%#Eval("picture")%>' />                                                          </td>
                                                        </tr>
                                                      </table>                                                      </td>
                                                  </tr>
                                                </table></td>
                                              <td width="4" align="left"></td>
                                            </tr>
                                          </table>
                                        </ItemTemplate>
                                      </asp:DataList>
                                      </div>
                                      </asp:PlaceHolder>
                                       <asp:PlaceHolder ID="plcNoAutoData" runat="server" Visible="false">
                                           <strong style="color:#990066">  You have no business pages.</strong><br /><br /> <a href="javascript:CreatePage();">Click here</a> to create business page.                                   </asp:PlaceHolder>
                                   <asp:PlaceHolder ID="plcAutoError" runat="server" Visible="false">
                                           <strong style="color:#990066">Facebook is experiencing problems. Please try again later</strong><br /><br />
                                   </asp:PlaceHolder>                                    </td>
                                  </tr>
                                  <tr><td valign="top" align="right" style="padding-right:30px; padding-bottom:10px;"><a href="javascript:;" class="bluetablink" onclick="HideAutoPostFanPages();">Save</a></td></tr>
                                </table>
                              </div>
                              
                              
                            
<div id="divAutoPostDaySelection" class="popupbg" style="display: none; position:absolute; z-index: 1000;  width: 535px;">
			  
<table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left" valign="top">
                  
                  
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table cellpadding="0" cellspacing="0" border="0" width="100%">
                      <tr bordercolor="#cccccc;" style="height:25px;">
                        <td height="30" valign="top" class="arial16gray"><b>Select AutoPost Day Schedule</b> </td>
                        <td align="right" valign="top"><a href="javascript:;" onClick="HideAutopostDaySelection();">Close</a>&nbsp;&nbsp;&nbsp; </td>
                      </tr>
                      <tr>
                        <td colspan="2" valign="top"><div style="overflow:auto; background-color:#ffffff; padding:15px; border:1px solid #cccccc;">
                          <table cellpadding="0" cellspacing="2" border="0" width="100%"  align="left">
                     
                          <tr>
                          <td  width="10" align="left" valign="middle" >
                          <input type="radio" id="rd7day" name="autopost7day" runat="server" checked group="autopost7day"  />
                      
                          <td width="65" align="left" valign="middle">7 Days a Week</td>
                          
                        </tr>
                            <tr>
                          <td  width="10" align="left" valign="middle" > 
                          <input type="radio" id="rd5day" name="autopost7day" runat="server"  group="autopost7day"  /></td>
                          <td width="65" align="left" valign="middle">5 Days a Week</td>
                          
                        </tr>
                            <tr>
                          <td  width="10" align="left" valign="middle" > 
                          <input type="radio" id="rd1day" name="autopost7day" runat="server"  group="autopost7day" onclick="showParticularDaySelectionDiv();"  value="2" /></td>
                          <td width="65" align="left" valign="middle">Particular Day Selection</td>
                          
                        </tr>
                    
                    </table>
                        </div></td>
                      </tr>
                      </table></td>
  </tr>
</table>

                  </td>
                </tr>
              </table>
		
</div>

                                                                                                 	
          
                            
<div id="divAutopostParticularDay" class="popupbg" style="display: none; position:absolute; z-index: 1000;  width: 535px;">
			  
<table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left" valign="top">
                  
                  
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table cellpadding="0" cellspacing="0" border="0" width="100%">
                      <tr bordercolor="#cccccc;" style="height:25px;">
                        <td height="30" valign="top" class="arial16gray"><b>Select AutoPost Day Schedule</b> </td>
                        <td align="right" valign="top"><a href="javascript:;" onClick="HideAutopostDaySelection();">Close</a>&nbsp;&nbsp;&nbsp; </td>
                      </tr>
                      <tr>
                        <td colspan="2" valign="top"><div style="overflow:auto; background-color:#ffffff; padding:15px; border:1px solid #cccccc;">
                        <table cellpadding="0" cellspacing="2" border="0" width="100%"  align="left">
                     	  <tr>
                          <td  width="15" align="left" valign="middle" ><input class="checkboxpadding" runat="server" type="checkbox" id="autopostday7" name="chksingleday"   group="chksingleday" value="1"/></td>
                          <td width="65" align="left" valign="middle">Sunday</td>
                          
                        </tr>
                         
                          <tr>
                          <td  width="15" align="left" valign="middle" ><input class="checkboxpadding" runat="server" type="checkbox" id="autopostday1" name="chksingleday" group="chksingleday" value="2"/></td>
                          <td width="65" align="left" valign="middle">Monday</td>
                          
                        </tr>
                        
                          <tr>
                          <td  width="15" align="left" valign="middle" ><input class="checkboxpadding" runat="server" type="checkbox" id="autopostday2" name="chksingleday" group="chksingleday" value="3"/></td>
                          <td width="65" align="left" valign="middle">Tuesday</td>
                          
                        </tr>
                        
                          <tr>
                          <td  width="15" align="left" valign="middle" ><input class="checkboxpadding" runat="server"  type="checkbox" id="autopostday3" name="chksingleday" group="chksingleday" value="4"/></td>
                          <td width="65" align="left" valign="middle">Wedenesday</td>
                          
                        </tr>
                        
                          <tr>
                          <td  width="15" align="left" valign="middle" ><input class="checkboxpadding" runat="server" type="checkbox" id="autopostday4" name="chksingleday" group="chksingleday" value="5"/></td>
                          <td width="65" align="left" valign="middle">Thursday</td>
                          
                        </tr>
                        
                          <tr>
                          <td  width="15" align="left" valign="middle" ><input class="checkboxpadding"  runat="server" type="checkbox" id="autopostday5" name="chksingleday"  group="chksingleday" value="6"/></td>
                          <td width="65" align="left" valign="middle">Friday</td>
                          
                        </tr>
                        
                          <tr>
                          <td  width="15" align="left" valign="middle" ><input class="checkboxpadding" runat="server" type="checkbox" id="autopostday6" name="chksingleday"  group="chksingleday" value="7"/></td>
                          <td width="65" align="left" valign="middle">Saturday</td>
                          
                        </tr>
                        
                      
                    </table>
                        </div></td>
                      </tr>
                      </table></td>
  </tr>
</table>

                  </td>
                </tr>
              </table>
		
       </div> 
                              <asp:Repeater ID="rptAutoPostfanpages" runat="server" Visible="false">
                                <ItemTemplate> &nbsp;&nbsp;<img src='<%# DataBinder.Eval(Container.DataItem, "ap_FBPageImage")%>' width="20" height="20" align="absmiddle" border="0" style="border:1px solid #d3d3d3; padding:1px;" />&nbsp;<font style="font-size:12px; font-family:Arial, Helvetica, sans-serif; line-height:20px;; vertical-align:middle"><%# DataBinder.Eval(Container.DataItem, "ap_FBPageName")%>&nbsp;&nbsp;&nbsp;</font></ItemTemplate>
                              </asp:Repeater>
                              <br/>
                              <br/>
                               <div id="divAutoPostHtml" style="width:300px; display:none; height:auto; border:1px solid #eaeaea; background-color:#f6f6f6; padding:15px; line-height:22px;"> </div>                            </td>
                          </tr>
                          <tr>
                            <td height="40" align="right" valign="bottom">
                              </td>
                          </tr>
                          <tr>
                            <td align="left" valign="top"></td>
                          </tr>
                        </table>
                      </div>
                        <div class="TabbedPanelsContent">
                        
                       <!-- <asp:UpdatePanel ID="UpdatePanelDiv5" runat="server" UpdateMode="Conditional">
                                      <ContentTemplate>-->
                        <div align="left" style="float:left; width:725px; padding-bottom:30px; padding-top:30px;">
                       
                        <div  align="right" style="float:right; ">
                         <a href="javascript:;" class="bluetablink" style="display:none;" id="lnkdisableImport1">Loading...</a>
                               &nbsp;<a href="javascript:;" class="bluetablink" runat="server" onclick="return disablelink();" id="lnkAutoPostShuffle" style="display:none">Import Library</a> 
                              <asp:PlaceHolder ID="pnlClearAll" runat="server" Visible="true">
                              
                               <a href="javascript:;" class="bluetablink" runat="server"  style="display:none;" id="lnkdiabledClearAll1" >Loading...</a> 
                              <div id="divClearAll" style="display:none" > 
                              <a href="javascript:;" class="bluetablink" runat="server" style="display:;"  onclick="return confirmClear();" id="lnkClearAll">Clear All</a>
                              </div>
                              </asp:PlaceHolder>
                         </div>
                        </div>
                       
                        <div id="TabbedPanels2" class="TabbedPanels" style="width:725px;">
                                <ul class="TabbedPanelsTabGroup">
                                  <li class="TabbedPanelsTab1" tabindex="1" style="border-botto`m:0px;" >Scheduled</li>
                                  <li class="TabbedPanelsTab1" tabindex="0" style="border-bottom:0px;">Sent</li>
                                   <li style="float:right; list-style: none;">
                                   
                                     <div id="divFanPageDrp" style="display:none" > <asp:DropDownList ID="drpFanPages" runat="server" AutoPostBack="true" CssClass="inputdropdownsmall">
                         </asp:DropDownList> </div></li>
                                  
                                </ul>
                                
                                 
                        
                                <div class="TabbedPanelsContentGroup1">
                                  <div class="TabbedPanelsContent1">
                                    <div id="div4" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute">
                                      <asp:UpdateProgress ID="UpdateProgressDiv4" runat="Server" DisplayAfter="0">
                                        <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                                      </asp:UpdateProgress>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanelDiv4" runat="server" UpdateMode="Conditional">
                                      <ContentTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                          <tr>
                                            <td align="left" valign="top"><asp:Literal ID="ltrAutoPostRpt" runat="server"></asp:Literal>
                                              <asp:DataList ID="dtlAutoPost" runat="server"  Width="100%">
                                                <ItemTemplate>
                                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                      <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                          <tr>
                                                            <td align="left" valign="top" width="100" style="display:<%#iif(Eval("apm_Image")<>"" or Eval("apm_VideoId")<>"","","none")%>"><div id="divAutoPostImage" runat="server" style="padding-bottom:10px;"> <img id="imgAutoPostPhoto" runat="server"  border="0" class="grayborder"/> </div>
                                                              <div id="divAutoPostVideo" visible='<%#DataBinder.Eval(Container.DataItem, "apm_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                                <object style="height: 100px; width: 100px">
                                                                  <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                                  <param name="allowFullScreen" value="true">
                                                                  <param name="allowScriptAccess" value="always">
                                                                  <param name="wmode" value="transparent">
                                                                  <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100">
                                                                </object>
                                                              </div></td>
                                                            <td align="left" valign="top" style="padding-left:12px; color:#676767; line-height:17px; text-align:left; word-break: break-all;">
                                                            <span id='spnAutoPost<%#Eval("apm_id")%>'><%#DataBinder.Eval(Container.DataItem, "apm_Message")%></span><br/>
                                                            <div id="divAutoPostLink" visible='<%#DataBinder.Eval(Container.DataItem, "apm_Link")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                            <span id='spnAutoPostLink<%#Eval("apm_id")%>'><%#DataBinder.Eval(Container.DataItem, "apm_Link")%></span>                                                            </div>                                                            </td>
                                                          </tr>
                                                        </table></td>
                                                    </tr>
                                                    <tr>
                                                      <td align="left" valign="top" >&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                      <td align="left" valign="top" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                          <tr>
                                                            <td width="70%" align="left" valign="top" class="tahoma12grey" style="font-weight:normal; line-height:17px;" ><strong>Scheduled for</strong><br />
                                                              <label id="lblAutoPostDate" runat="server"></label>
                                                              <%--<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleDate")%> , <%#DataBinder.Eval(Container.DataItem, "apm_ScheduleHour")%>:<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleMinute")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleAMPM")%>--%>                                                              </td>
                                                            <td  align="right" valign="top" style="padding-top:3px; padding-right:5px;" ><table cellpadding="0" cellspacing="0" align="right" border="0">
                                                                <tr>
                                                              <td align="right" valign="top" style="display:none">
                                                              <input type="hidden" id="hdnAutoPost<%#Eval("apm_id")%>" value='<%#Eval("apm_Image")%>' />
                                                              <input type="hidden" id="hdnAutoPostVideo<%#Eval("apm_id")%>" value='<%#Eval("apm_VideoLink")%>' />
                                                              <input type="hidden" id="hdnAutoPostLink<%#Eval("apm_id")%>" value='<%#Eval("apm_Link")%>' />
                                                              <a href="#StatusMessage" onclick='EditAutoPost(<%#Eval("apm_id")%>);' title="Select"><img src="../Content/images/icon_edit.gif" border="0" alt="Select" /></a>                                                                   </td>
                                                                    <td align="right" valign="top" style="display:">
                                                                    <asp:LinkButton OnCommand="DeleteMyAutoPost" onclientclick="return Prompt('Are you sure you want to delete this AutoPost?');" CommandArgument='<%#Eval("apm_id")%>' CommandName='<%#Eval("apm_FBPageId")%>' id="lnkAutoPostDelete" runat="server" ToolTip="Remove"><img src="../Content/images/icon_delet.gif" border="0" hspace="7" alt="Remove"/></asp:LinkButton></td>
                                                                    <td align="right" valign="middle" style="display:none;"><Span id="spnImageButtonUp" visible='<%#Container.DataItem("apm_OrderImage") = "Up"%>' runat="server">
                                                              <asp:ImageButton id="imgBtnUp" ImageUrl="Content/images/arrow_up.png" ToolTip ="Up" runat="server"  
                                              CommandName="Up" CommandArgument='<%#Container.DataItem("apm_id")%>'></asp:ImageButton>
                                                              </Span> <Span id="spnImageButtonDown" visible='<%#Container.DataItem("apm_OrderImage") = "Down"%>' runat="server" Headerstyle-HorizontalAlign="Center">
                                                              <asp:ImageButton id="imgBtnDown" ImageUrl="Content/images/arrow_down.png" ToolTip ="Down" runat="server" CommandName="Down" CommandArgument='<%#Container.DataItem("apm_id")%>'> </asp:ImageButton>
                                                              </Span> <Span id="spnImageButtonUpDown" visible='<%#Container.DataItem("apm_OrderImage") ="Updown"%>' runat="server" Headerstyle-HorizontalAlign="Center">
                                                              <asp:ImageButton id="imgBtnUp1" ImageUrl="Content/images/arrow_up.png"	ToolTip ="Up" runat="server"  
                                              CommandName="Up" CommandArgument='<%#Container.DataItem("apm_id")%>'></asp:ImageButton>
                                                              &nbsp;
                                                              <asp:ImageButton id="imgBtnDown1" ImageUrl="Content/images/arrow_down.png" 	ToolTip ="Down" runat="server"  CommandName="Down" CommandArgument='<%#Container.DataItem("apm_id")%>'></asp:ImageButton>
                                                              </Span></td>
                                                                </tr>
                                                                </table>                                                            </td>
                                                          </tr>
                                                        </table></td>
                                                    </tr>
                                                    <tr>
                                                      <td height="40" align="left" valign="top" class="greysolidline">&nbsp;</td>
                                                    </tr>
                                                  </table>
                                                </ItemTemplate>
                                              </asp:DataList>                                            </td>
                                          </tr>
                                          <tr align="right">
                                            <td style="padding-right:20px;"><asp:PlaceHolder ID="phPagingAutoPost" runat="server" ></asp:PlaceHolder></td>
                                          </tr>
                                        </table>
                                      </ContentTemplate>
                                    </asp:UpdatePanel>
                                  </div>
                                  <div class="TabbedPanelsContent">
                                   <div id="div6" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute">
                                      <asp:UpdateProgress ID="UpdateProgress5" runat="Server" DisplayAfter="0">
                                        <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                                      </asp:UpdateProgress>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                      <ContentTemplate>
                                  <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                  <tr>
                                  <td align="left" valign="top">
                                   <asp:Literal ID="ltrSentAutoPostRpt" runat="server"></asp:Literal>
                                  <asp:DataList ID="dtlSentAutoPost" runat="server"  Width="100%" >
                                      <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                          <tr>
                                            <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                  <td align="left" valign="top" width="100" style="display:<%#iif(Eval("apm_Image")<>"" or Eval("apm_VideoId")<>"" ,"","none")%>"><div id="divSentAutoPostImage" runat="server" style="padding-bottom:10px;"> <img id="imgSentAutoPostPhoto" runat="server"  border="0" class="grayborder"/> </div>
                                                    <div id="divSentAutoPostVideo" visible='<%#DataBinder.Eval(Container.DataItem, "apm_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                      <object style="height: 100px; width: 100px">
                                                        <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                        <param name="allowFullScreen" value="true">
                                                        <param name="allowScriptAccess" value="always">
                                                        <param name="wmode" value="transparent">
                                                        <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100">
                                                      </object>
                                                    </div></td>
                                                  <td align="left" valign="top" style="padding-left:5px;  text-align:left; word-break: break-all">
                                                  <span id='spnAutoPost<%#Eval("apm_id")%>'> <%#DataBinder.Eval(Container.DataItem, "apm_Message")%> </span>
                                                  <br/>
                                                            <div id="divSentAutoPostLink" visible='<%#DataBinder.Eval(Container.DataItem, "apm_Link")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                            <span id='spnSentAutoPostLink<%#Eval("apm_id")%>'><%#DataBinder.Eval(Container.DataItem, "apm_Link")%></span>                                                            </div></td>
                                                </tr>
                                              </table></td>
                                          </tr>
                                          <tr>
                                            <td align="left" valign="top" >&nbsp;</td>
                                          </tr>
                                          <tr>
                                            <td align="left" valign="top" ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                  <td align="left" valign="top" class="tahoma12grey" style="display:;"><strong>Autopost Submitted On
                                                    <label id="lblSentAutoPostDate" runat="server"></label>
                                                    <%--<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleDate")%> , <%#DataBinder.Eval(Container.DataItem, "apm_ScheduleHour")%>:<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleMinute")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "apm_ScheduleAMPM")%>--%>
                                                    </strong></td>
                                                  <td align="right" valign="top" style="padding-top:5px;">&nbsp;</td>
                                                </tr>
                                              </table></td>
                                          </tr>
                                          <tr>
                                            <td height="40" align="left" valign="top" class="greysolidline">&nbsp;</td>
                                          </tr>
                                        </table>
                                      </ItemTemplate>
                                    </asp:DataList>                                  </td>
                                  </tr>
                                  <tr align="right">
                                            <td style="padding-right:20px;"><asp:PlaceHolder ID="phPagingSentAutoPost" runat="server" ></asp:PlaceHolder></td>
                                          </tr>
                                  </table>
                                   </ContentTemplate>
                                   </asp:UpdatePanel>
                                  </div>
                                </div>
                              </div>
                            <!--  </ContentTemplate>
                             </asp:UpdatePanel> -->                           
                        </div>
                      <div class="TabbedPanelsContent">
                      <div id="div5" runat="server" style="margin-right:0px; width:74px; height:40px;overflow:hidden;position:absolute">
                              <asp:UpdateProgress ID="UpdateProgress4" runat="Server" DisplayAfter="0">
                                <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                              </asp:UpdateProgress>
                            </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanelAdminLibrary" runat="server" UpdateMode="Conditional">
                              <ContentTemplate>--%>
                              <div align="center" style="color:Red;"><asp:Literal ID="ltrAdminLibMsg" runat="server"></asp:Literal> </div>
                        <table width="100%" style="padding-top:15px;">
                          <tr id="trLibrary" runat="server" Group="Info">
                            <td valign="top">
                            
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr id="trAdminLib" group="libtr">
                                  <td>
                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <tr>
                                       <td >
                                       <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <tr>
                                          <asp:Repeater id="rptAdminLibCatTitle" runat="server">
                                            <itemtemplate>
                                               <td id="tdLibCatTitle<%#Eval("Id")%>" onclick='ShowLib(<%#Eval("Id")%>);' class="tabchedule" group='libcattitle' style="cursor:pointer;"><strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong></td>
                                          </itemtemplate>
                                          </asp:Repeater>
                                         </tr>
                                          </table>                                          </td >
                                       </tr>
                                      <asp:Repeater id="rptAdminLibCat" runat="server">
                                        <itemtemplate>
                                          <tr>
                                            <td ><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr style="display:none">
                                                  <td onclick='ShowLib(<%#Eval("Id")%>);' class="tdindustry" style="cursor:pointer;"><img src="../Content/images/folder_icon2.gif" width="16" height="16"  style="padding-right:5px;"/><strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong></td>
                                                </tr>
                                                
                                                <tr id='trLibCat<%#Eval("Id")%>' style="display:<%#iif(Eval("Row")=1,"","none")%>" group='libcattr'>
                                                  <td style="padding-left:15px; padding-top:20px; border:1px solid #d3d3d3;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                      <asp:Repeater id="rptAdminLib" runat="server" DataSource='<%#BindAdminLibraries(Eval("Id"))%>'>
                                                        <itemtemplate>
                                                          <tr>
                                                            <td style="border-bottom:2px solid #d3d3d3; padding-bottom:22px;">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                            	<td align="left" valign="top" width="100" style="display:<%#iif(Eval("lib_Image")<>"" or Eval("lib_VideoId")<>"" ,"","none")%>">
                                                                <asp:PlaceHolder ID="pnlAdminLibImage" runat="server" Visible='<%#Eval("lib_Image")<>""%>'>
                                                                <div id="divAdminLibImage" style="padding-bottom:10px;"> <img id="imgUserLibPhoto" src='<%=System.Configuration.ConfigurationManager.AppSettings("AppPath")%>resize-tabs.ashx?P=/content/uploads/images/<%#Eval("lib_Image")%>&D=150x100' border="0" style=" cursor:pointer" class="grayborder" /> </div>
                                                              </asp:PlaceHolder>
                                                              &nbsp;
                                                              &nbsp;&nbsp;
                                                              <div id="divAdminLibVideo" visible='<%#DataBinder.Eval(Container.DataItem, "lib_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                                <object style="height: 100px; width: 100px">
                                                                  <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                                  <param name="allowFullScreen" value="true">
                                                                  <param name="allowScriptAccess" value="always">
                                                                  <param name="wmode" value="transparent">
                                                                  <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100" />
                                                                </object>
                                                              </div>                                                                </td>
                                                                <td align="left" valign="top" style="padding-left:12px; color:#676767; text-align:justify; line-height:18px; padding-right:15px; word-break: break-all">
                                                                <span id='spnlib<%#Eval("lib_Id")%>'>
                                                                 <%#Eval("lib_Template")%></span><br/>
                                                                  <span id='spnlibLink<%#Eval("lib_Id")%>'>
                                                                 <%#Eval("lib_Link")%></span>
                                                                 
                                                                  <input type="hidden" id="hdnlib<%#Eval("lib_Id")%>" value='<%#Eval("lib_Image")%>' />
                                                              <input type="hidden" id="hdnlibVideo<%#Eval("lib_Id")%>" value='<%#Eval("lib_Video")%>' />
                                                              <input type="hidden" id="hdnlibLink<%#Eval("lib_Id")%>" value='<%#Eval("lib_Link")%>' />                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" valign="top" colspan="2" style="padding-right:15px; padding-top:5px;" > <table cellpadding="0" cellspacing="0" align="right" border="0">
                                                                <tr>
                                                                	
                                                                    <td align="right" valign="middle"><asp:LinkButton OnCommand="AddLibToAutoPost" onclientclick="return PromtAddToautoPost();" CommandArgument='<%#Eval("lib_Id")%>' CommandName='<%#Eval("lib_Id")%>' id="lnkAddLibtoAutoPost" CssClass="bluetablink" runat="server" Visible="false"><asp:PlaceHolder ID="plhNotAdded" runat="server" Visible="false">
                                                                    Add To Autopost</asp:PlaceHolder>
                                                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false"> Added To Autopost</asp:PlaceHolder>
                                                                </asp:LinkButton></td>
                                                                </tr>
                                                                </table>                                                                </td>
                                                            </tr>
                                                            </table>                                                              </td>
                                                          </tr>
                                                          <tr>
                                                            <td height="20"></td>
                                                          </tr>
                                                        </itemtemplate>
                                                      </asp:Repeater>
                                                    </table></td>
                                                </tr>
                                              </table></td>
                                          </tr>
                                        </itemtemplate>
                                      </asp:Repeater>
                                    </table></td>
                                </tr>
                              </table>                             </td>
                          </tr>
                        </table>
                       <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                      </div>
                      
                      <div class="TabbedPanelsContent">
                           <div id="divLib" runat="server" style="margin-right:0px; width:74px; height:40px;overflow:hidden;position:absolute">
                              <asp:UpdateProgress ID="UpdateProgressLib" runat="Server" DisplayAfter="0">
                                <ProgressTemplate> <img src="../Content/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                              </asp:UpdateProgress>
                            </div>
                     <asp:UpdatePanel ID="UpdatePanelLib" runat="server" UpdateMode="Conditional">
                              <ContentTemplate>
                      		<table width="100%" border="0" cellspacing="0" cellpadding="0">
                            	<tr id="trMyLib" style="display:" group="libtr">
                                  <td>
                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <tr>
                                       	<td align="center" height="30">
                                        	<font color="red" style="text-align:center; font-size:14px; font-family:Arial, Helvetica, sans-serif">
                                                  <asp:Literal id="ltrLibMsg" runat="server"></asp:Literal>
                                                  </font>                                        </td>
                                       </tr>
                                       <tr>
                                       <td>
                                       <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <tr>
                                          <asp:Repeater id="rptUserLibCatTitle" runat="server">
                                            <itemtemplate>
                                               <td id="tdUserLibCatTitle<%#Eval("Id")%>" onclick='ShowUserLib(<%#Eval("Id")%>);' class="tabchedule" group='userlibcattitle' style="cursor:pointer;"><strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong>&nbsp;&nbsp;
                                              <asp:PlaceHolder ID="pnlLibCatDel" runat="server" Visible='<%#Eval("lc_UserId")<>-1%>'>
                                                      <asp:LinkButton OnCommand="DeleteMyLibCat" onclientclick="return Prompt('Are you sure you want to delete this library?');" CommandArgument='<%#Eval("Id")%>' CommandName='<%#Eval("Title")%>' id="lnkAdminLibCatDelete" runat="server">&nbsp;<img src='<%=ResolveUrl("Content/images/delete_icon.png")%>' border="0"/>&nbsp;</asp:LinkButton>
                                                    </asp:PlaceHolder>                                                    </td>
                                          </itemtemplate>
                                          </asp:Repeater>
                                          </tr>
                                          </table>                                          </td>
                                       </tr>
                                      <asp:Repeater id="rptUserLibCat" runat="server">
                                        <itemtemplate>
                                          <tr >
                                            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr style="display:none;">
                                                  <td onclick='ShowUserLib(<%#Eval("Id")%>);' class="tdindustry" style="cursor:pointer;"><img src="../Content/images/folder_icon2.gif" width="16" height="16"  style="padding-right:5px;"/>
                                                  <strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:PlaceHolder ID="pnlLibCatDel" runat="server" Visible='<%#Eval("lc_UserId")<>-1%>'>
                                                      <asp:LinkButton OnCommand="DeleteMyLibCat" onclientclick="return Prompt('Are you sure you want to delete this library?');" CommandArgument='<%#Eval("Id")%>' CommandName='<%#Eval("Title")%>' id="lnkAdminLibCatDelete12" runat="server">Delete</asp:LinkButton>
                                                    </asp:PlaceHolder>                                                  </td>
                                                </tr>
                                                <tr id='trUserLibCat<%#Eval("Id")%>' style="display:<%#iif(Eval("Row")=1,"","none")%>" group='userlibcattr'>
                                                  <td style="padding-left:15px; padding-top:20px; border:1px solid #d3d3d3;">
                                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                      <asp:Repeater id="rptUserLib" runat="server" DataSource='<%#BindUserLibraries(Eval("Id"))%>'>
                                                        <itemtemplate>
                                                          <tr>
                                                            <td style="border-bottom:2px solid #d3d3d3; padding-bottom:22px;">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                            	<td align="left" valign="top" width="100" style="display:<%#iif(Eval("lib_Image")<>"" or Eval("lib_VideoId")<>"" ,"","none")%>">
                                                                <asp:PlaceHolder ID="pnlUserLibImage" runat="server" Visible='<%#Eval("lib_Image")<>""%>'>
                                                                <div id="divUserLibImage" style="padding-bottom:10px;"> <img id="imgUserLibPhoto" src='<%=System.Configuration.ConfigurationManager.AppSettings("AppPath")%>resize-tabs.ashx?P=/content/uploads/images/<%#Eval("lib_Image")%>&D=150x100' border="0" style=" cursor:pointer" class="grayborder" /> </div>
                                                              </asp:PlaceHolder>
                                                              &nbsp;
                                                              &nbsp;&nbsp;
                                                              <div id="divUserLibVideo" visible='<%#DataBinder.Eval(Container.DataItem, "lib_VideoId")<>""%>' runat="server" style="padding-bottom:10px; padding-right:15px;">
                                                                <object style="height: 100px; width: 100px">

                                                                  <param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>'>
                                                                  <param name="allowFullScreen" value="true">
                                                                  <param name="allowScriptAccess" value="always">
                                                                  <param name="wmode" value="transparent">
                                                                  <embed src='<%#DataBinder.Eval(Container.DataItem, "VideoUrl")%>' type="application/x-shockwave-flash" allowfullscreen="true" allowScriptAccess="always" width="100" height="100" />
                                                                </object>
                                                              </div>                                                                </td>
                                                                <td align="left" valign="top" style="padding-left:12px; color:#676767; line-height:18px;  text-align:left; padding-right:15px; word-break: break-all">
                                                                <span id='spnlib<%#Eval("lib_Id")%>'> <%#Eval("lib_Template")%> </span><br/>
                                                                <span id='spnlibLink<%#Eval("lib_Id")%>'> <%#Eval("lib_Link")%> </span>                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" valign="top" colspan="2" style="padding-right:15px; padding-top:5px;"><table cellpadding="0" cellspacing="0" align="right" border="0">
                                                                <tr>
                                                                	<td align="right" valign="middle"><asp:LinkButton OnCommand="AddLibToAutoPost" onclientclick="return PromtAddToautoPost();" CommandArgument='<%#Eval("lib_Id")%>' CommandName='<%#Eval("lib_Id")%>' id="lnkAddLibtoAutoPost1" CssClass="bluetablink" runat="server">
                                                                <asp:PlaceHolder ID="plhNotAdded1" runat="server">Add To Autopost</asp:PlaceHolder>
                                                                
                                                                </asp:LinkButton></td>
                                                                </tr>
                                                                </table>                                                                </td>
                                                            </tr>
                                                            </table>                                                            </td>
                                                          </tr>
                                                          <tr>
                                                            <td  height="20"></td>
                                                          </tr>
                                                        </itemtemplate>
                                                      </asp:Repeater>
                                                    </table></td>
                                                </tr>
                                              </table></td>
                                          </tr>
                                        </itemtemplate>
                                      </asp:Repeater>
                                    </table></td>
                                </tr>
                            </table>
                               </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                    </div>
                      <input type="hidden" id="hdnSetTab" runat="server" value="0" />
                  </div>
                  <script type="text/javascript">
<!--
                      var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
                      var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
//-->
</script>
          </table></td>
        </tr>
      </table>
    </div>
    </div>
  <div> </div>
  <uc2:inner ID="inner2" runat="server" />
  <div id="divUploadLimit" title="Upload Limit Exceeded" style="display:none;">
    <table border="0">
      <tr>
        <td align="left" height="40" colspan="2" style="text-align:left; font-size:12px; color:Gray"><strong>Error:</strong> <br/>
          <br/>
          <font style="font-family:Arial, Helvetica, sans-serif; font-size:14px; color:#CCCCCC;">This file exceeds the 10MB attachment limit. Sorry.</font> </td>
      </tr>
    </table>
  </div>
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

        $('td[group^=libcattitle]').each(
	function () {
	    $(this).removeClass('tabcheduleact');
	    $(this).addClass('tabchedule');

	});
        $('#tdLibCatTitle' + Id).addClass('tabcheduleact');
        $('#tdLibCatTitle' + Id).removeClass('tabchedule');
        $('#trLibCat' + Id).slideDown('slow');
    }
    function ShowUserLib(Id) {
        $('tr[group^=userlibcattr]').each(
	function () {
	    $(this).css('display', 'none');

	});
        $('td[group^=userlibcattitle]').each(
	function () {
	    $(this).removeClass('tabcheduleact');
	    $(this).addClass('tabchedule');

	});
        $('#tdUserLibCatTitle' + Id).addClass('tabcheduleact');
        $('#tdUserLibCatTitle' + Id).removeClass('tabchedule');
        $('#trUserLibCat' + Id).slideDown('slow');
    }
   
  
    function Prompt(obj) {
        return (confirm(obj))
    }
    function PromptAddToautoPost() {
        return (confirm("Are you sure you want to delete this library?"))

    }
   
    function disablelink() {
      /*  var flag = confirm('Are you sure you want to set the autopos?');
        if (flag == true) {*/
            $('#lnkAutoPost').css('display', 'none');
            $('#lnkdisableImport').css('display', '');
        /*}
        return flag;*/
    }

    function confirmClear() {
        var flag = confirm('Are you sure you want to delete all the posts in Autopost?');
        if (flag == true) {
            $('#lnkClearAll').css('display', 'none');
            $('#lnkdiabledClearAll').css('display', '');
        }

        return flag;
    }
	
	 function showDaySelectionDiv() {
		 $("#divAutoPostDaySelection").show("slow");
    }
    function showParticularDaySelectionDiv() {
        $("#divAutoPostDaySelection").hide("slow");
        $("#divAutopostParticularDay").show("slow");
    }
	
	function HideAutopostDaySelection(){
	 $("#divAutoPostDaySelection").hide("slow");
	  $("#divAutopostParticularDay").hide("slow");
	}
	
</script>
