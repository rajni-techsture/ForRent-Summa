<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="inner-header.ascx.vb" Inherits="tsma.inner_header" %>
<link  href="<%=ResolveUrl("~/Content/css/site.css")%>" rel="stylesheet" type="text/css" />
<link id="lnkInnerTheme" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="<%=ResolveUrl("~/Content/css/jquery.ui.timepicker.css?v=0.2.9")%>" type="text/css" media="all" />
<link rel="stylesheet" href="<%=ResolveUrl("~/Content/css/jquery-ui-1.8.17.custom.css")%>" type="text/css" />
<script src="<%=ResolveUrl("~/Content/js/jquery.ui.timepicker.js?v=0.2.9")%>" type="text/javascript"></script>
<script src="Content/js/jquery-ui.min.js" type="text/javascript"></script>
<script src="Content/js/jquery.bgiframe-2.1.2.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
	    $(document).ready(function () {
       
	        var cssstyle = ''
            if (readCookie('style')) {
                cssstyle = readCookie('style');
            }
            else {
                cssstyle = 'apartment-style.css';
            }
            $('#lnkInnerTheme').attr("href", '../Content/css/' + cssstyle + '');
		});
        function readCookie(name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        }
</script>
<div id="DivSaveBeforeExist" style="width:100%; height:100%; text-align:center;  background-image:url(Content/facebookalert/images/popup_bg.png);  position:absolute; z-index:999999999; display:none;">
			  <div id="popup_container_Save" style="width:450px; height:80px;"  >
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  Warning: You have unsaved changes to your work you are editing.<br/><br/>
                   <input type="button" class="inputbutton" onclick="ChangedPage();" value="Don't Save" id="popup_save" style="cursor:pointer"/>&nbsp;&nbsp;
                   <input type="button" class="inputbutton" onclick="HideLinkAlert();" value="Save" id="popup_close" style="cursor:pointer"/>
				</div>
			 </div>
			 </div>
<div id="homepagemaincenter">
<input type="hidden" id="hdnSaveHeader" value="1" />
<table width="1004" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td height="42" align="left" valign="middle" style="padding-right:25px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="42" align="left" valign="middle"><img src='<%=ResolveUrl("Content/images/for_rent_logo.jpg")%>' width="159" height="29" hspace="20" /></td>
        <td align="right" valign="middle" style="color:#FFF; font-size:18px;"> 
        <a href='<%=ConfigurationManager.AppSettings("AppPath")%>' style="color:#FFFFFF">Home</a>&nbsp;    |&nbsp;  
        <a href='<%=ResolveUrl("express-sidebar")%>' style="color:#FFFFFF; display:none">Express Setup&nbsp; |&nbsp;</a>    
        <a href='<%=ConfigurationManager.AppSettings("AppPath")%>SiteUserLogout.aspx' style="color:#FFFFFF"> Logout </a><%--(<font color="#c4f7ff"><%=Session("SiteUserName")%></font>)--%></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td align="left" valign="top"><img src='<%=ResolveUrl("Content/images/for_rent_apartment_header_new.jpg")%>'/></td>
  </tr>
  <tr>
    <td height="37" align="left" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td align="left" valign="middle" style="font-size:18px; padding-left:25px; vertical-align:middle; padding-top:0px;"><font color="#636363">Welcome</font><span class="selecttitle"><%=tsma.GetSetCookies.GetCookie("SelectedName")%></span></td>
        <td align="right" valign="middle" style=" font-family:Tahoma, Geneva, sans-serif; font-size:12px; padding-right:7px; color:#383838; font-weight:bold">Select a network:</td>
        <td width="20" align="right" valign="middle" style="font-size:18px; padding-right:25px; vertical-align:middle"><img src='<%=ResolveUrl("Content/images/select_a_network.jpg")%>' border="0" align="absmiddle"/></td>
      </tr>
    </table></td>
  </tr>
</table>
</div>
<div align="center">
<%--<div id="toppart">
  <div id="topright"> <a href='<%=ConfigurationManager.AppSettings("AppPath")%>' style="color:#FFFFFF">Home</a>&nbsp;    |&nbsp; <a href='<%=ConfigurationManager.AppSettings("AppPath")%>SiteUserLogout.aspx' style="color:#FFFFFF"> Logout </a>(<font color="#c4f7ff"><%=Session("SiteUserName")%></font>) </div>
</div>
<div id="inheaderimg"></div>--%>
<!--<div id="youselect" >
  <div id="selecte" style="position:absolute">
    <asp:PlaceHolder id="plcIndustry" runat="server" Visible="true"> <span id="spnChooseInd" style="cursor:pointer;"> <strong class="arial14"><font color="#FFFFFF">You Selected:&nbsp;</font></strong><img src='<%=ResolveUrl("Content/images/youselect_arrow_down.png")%>' width="11" height="6" align="absmiddle" group="arrow" border="0px" style=" margin-right:35px;" /> </span> </asp:PlaceHolder>
    <asp:PlaceHolder id="plcCompany" runat="server" Visible="false"> <span id="spnChoose" style="cursor:pointer;"> <strong class="arial14"><font color="#FFFFFF">You Selected:</font></strong> <img src='<%=ResolveUrl("Content/images/youselect_arrow_down.png")%>' width="11" height="6" align="absmiddle" group="arrow" border="0" style="margin-left:10px; margin-right:35px;" /></span> 
    </asp:PlaceHolder>
    <span class="selecttitle" id="spnSelection" runat="server" ></span>
    <div style="border:0px solid #990033; height:20px;"></div>
    <div align="right" style="width:170px; position:absolute; display:none; z-index:11; " id="dvIndustry" >
      <table width="100%" border="0" cellspacing="0" cellpadding="0" >
        <tr>
        
        <td align="left" valign="top" class="menubginner">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
          <tr>
            <td height="38" align="center" style="background-color:#263c77"> <font color="#FFFFFF"> <strong>SELECT INDUSTRY</strong></font></td>
          </tr>
          
          <asp:Repeater ID="rptIndustry" runat="server">
            <ItemTemplate>
              <tr>
                <td height="38" group="industry"  show="0"  onMouseOver="AddClass(this);" onMouseOut="RemoveClass(this)" align="left" valign="middle" class="td456" style="font-family:arial; font-size:14px; color:#FFF; padding-left:15px; padding-right:15px; cursor:pointer;" onClick="GetPositionInd(this);" image='<%# Container.DataItem("i_Icon")%>' cssstyle='<%# Container.DataItem("i_Style")%>' industryid='<%# Container.DataItem("i_id")%>' industryname='<%# Container.DataItem("i_Name")%>'  ><span id="spnIndustry"> <img src="../../Content/images/<%# Container.DataItem("i_Icon")%>" align="absmiddle"/>&nbsp;&nbsp; <%# Container.DataItem("i_Name")%> </span><br />
                </td>
              </tr>
            </ItemTemplate>
          </asp:Repeater>
          <tr>
            <td height="20" align="center">&nbsp;</td>

          </tr>
          <input type="hidden" id="hdnindid" value="-1" />
          <input type="hidden" id="hdnindname" value="" />
          <input type="hidden" id="hdnMapI" value="0" />
          <input type="hidden" id="hdncid" value="-1" />
        </table>
        </td>
        
        </tr>
        
      </table>
    </div>
    <div style="width:210px; position:absolute; display:none; z-index:10;" id="dvCompany">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
        
        <td class="menubginner" valign="top">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
          <input type="hidden" id="hdncname" value="" />
          <input type="hidden" id="hdnimage" value="" />
          <input type="hidden" id="hdnStyle" value="" />
          <input type="hidden" id="hdnMap" value="0" />
          <input type="hidden" id="hdnid" value="0" />
          <tr>
            <td height="38" align="center"  style="background-color:#a0c55c"><font color="#FFFFFF">OR</font></td>
            <td height="38" align="center" style="background-color:#263c77"> <font color="#FFFFFF"> <strong> SELECT COMPANY</strong></font></td>
          
          </tr>
          
          <asp:Repeater ID="rptCompany" runat="server">
            <ItemTemplate>
              </tr>
              
              <tr>
                <td width="26" style="background-color:#639826" align="center"></td>
                <td  height="38" group="company" align="left" valign="middle" show="0" onMouseOver="AddClass(this);" onMouseOut="RemoveClass(this)" style="font-family:arial; font-size:14px; padding-left:15px; padding-right:15px; color:#FFF; cursor:pointer;" bit='<%# Container.DataItem("c_ispasswordRequired")%>' image='<%# Container.DataItem("c_Icon")%>' companyid='<%# Container.DataItem("c_id")%>' onClick="GetPosition(this);" companyname='<%# Container.DataItem("c_Name")%>' cssstyle='<%# Container.DataItem("c_Style")%>'><span id="spnCompany"><img src="../../Content/images/<%# Container.DataItem("c_Icon")%>" align="absmiddle"/>&nbsp;&nbsp; <%# Container.DataItem("c_Name")%> </span><br />
                </td>
              </tr>
            </ItemTemplate>
          </asp:Repeater>
          <tr>
            <td height="20" align="center" style="background-color:#639826">&nbsp;</td>
            <td height="20" align="center">&nbsp;</td>
           </tr>
          <tr>
            <td><div class="passwordpopup" id="divPassword"  style="position:absolute; padding-top:15px;font-size:12px; display:none;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="25" align="left" valign="top"><span class="arial16white" style="font-size:14px">Please enter password for <br />
                      <span id="spnName"></span></span></td>
                  </tr>
                  <tr>
                    <td height="35" align="left" valign="top" style="padding-top:5px;"><label>
                      <input name="txtPwd" type="password" id="txtPwd" class="passwordinput" onKeyDown="ChangeLoginFocus(event)"  />
                      <input type="hidden" id="CompanyId" value="0" />
                      </label>
                    </td>
                  </tr>
                  <tr >
                    <td align="left" valign="top"><span id="spnPwdError" style="color:#FFFFFF; font-weight:bold;" ></span></td>
                  </tr>
                  <tr>
                    <td height="30" align="left" valign="bottom"><img src="Content/images/submit.png" id='btnSubmit' width="67" height="27" border="0" style="cursor:pointer" />
                      <%--<input type="image" src="Content/images/submit.png" id='btnPassword' runat="server" width="67" height="27" border="0" />--%>
                    </td>
                  </tr>
                </table>
              </div></td>
          </tr>
        </table>
        </td>
        
        </tr>
        
      </table>
    </div>
  </div>
  <div id="network"><span class="arial16gray">Select a network:</span><img src="../Content/images/facebook_in_hover.png" width="45" height="44" hspace="4" border="0" align="absmiddle" /><img src="../Content/images/twitter_in.png" width="45" height="44" hspace="4" border="0" align="absmiddle" /><img src="../Content/images/linkedin_in.png" width="45" height="44" hspace="4" border="0" align="absmiddle" /><img src="../Content/images/rssfeed_in.png" width="45" height="44" hspace="4" border="0" align="absmiddle" /></div>
</div> -->
<script type="text/javascript" language="javascript">
$(document).ready(
function(){
		
			var pos = $('#spnChooseInd').position();
			
			
			var pos1 = $('#spnChoose').position();
			
			var x; 
			var y;
			if(pos)
			{	
				pos.left = parseInt(pos.left);
				pos.top = parseInt(pos.top);
				 x = pos.left;
				 y = pos.top;
				 
			}
			if(pos1)
			{	
				pos1.left = parseInt(pos1.left);
				pos1.top = parseInt(pos1.top);
				 x = pos1.left;
				 y = pos1.top;
			}
			//$('#dvIndustry').css('top',y+242+'px')
			$('#dvIndustry').css('left',x-17+'px')
		//	$('#dvCompany').css('top',y+237+'px')
			$('#dvCompany').css('left',x+150+'px')
		
	    
		//var pos1 = $('#spnChoose').position();
		//pos1.left = parseInt(pos1.left);
		//pos1.top = parseInt(pos1.top);
		//var x1 = pos1.left;
		//var y1 = pos1.top;
		//$('#dvCompany').css('top',y1+44+'px')
		
});
  
function AddClass(_this)
{
    $(_this).addClass('menuhoverinner');
}

function RemoveClass(_this)
{
	 var bit = $(_this).attr("show")
	 if(bit==0)
	 { 
	 	$(_this).removeClass('menuhoverinner');
	 }
}
 
function GetPositionInd(_this) {
	$('td[group^=industry]').each(
		function()
		{
			$(this).removeClass("menuhoverinner");	
			$(this).attr("show","0");	
		}
	);
	$(_this).addClass('menuhoverinner');
	$(_this).attr("show","1");
    var pos = $(_this).position();
	var id = $(_this).attr("industryid")
	var name=$(_this).attr("industryname")
	var image=$(_this).attr("image")
	var cssstyle=$(_this).attr("cssstyle")
	$('#hdnindid').val(id);
	//$("#divSelectedIndustry").removeClass('selectbginactive');
	//$("#divSelectedIndustry").removeClass('selectbgnone');
	//$("#divSelectedIndustry").addClass('selectbgactive');
//	$("#divSelectedIndustry").html('<img src="../../Content/images/'+ image + '" align="absbottom"/>&nbsp;&nbsp;' + name);
$("#inner1_spnSelection").html(name);
	$('#SelectedItem').html(name);
	//$("#dvIndustry").slideUp("slow");	
	Hide();
	$('img[group^=arrow]').each(
		function()
		{
			$(this).attr("src","../Content/images/youselect_arrow_down.png");	
	});
	$("#hdnMapI").val('0');
	$('#hdncid').val(0);
	//$("#divSelectedCompany").removeClass('selectbgactive');
	//$("#divSelectedCompany").removeClass('selectbginactive');
	//$("#divSelectedCompany").addClass('selectbgnone');
	//$("#divSelectedCompany").html('');
	$('td[group^=company]').each(
		function()
		{
			$(this).removeClass("menuhoverinner");	
			$(this).attr("show","0");			
		}
	);
	$('#lnkInnerTheme').attr("href", '../../Content/css/'+ cssstyle +'');
	createCookie('style',cssstyle,1);
	SaveSelection('WebService/save-user-selection.aspx/SaveUserSelection', '', GetResult, ErrorMessage);

}
function GetPosition(_this) {
  	$('td[group^=company]').each(
		function()
		{
			$(this).removeClass("menuhoverinner");	
			$(this).attr("show","0");			
		}
	);
    $('#CompanyId').val(0);
    $('#txtPwd').val('');
	$(_this).attr("show","1");
    $(_this).addClass('menuhoverinner');
    var pos = $(_this).position();
    var bit = $(_this).attr("bit")
    var id = $(_this).attr("companyid")
    var name=$(_this).attr("companyname")
    var image=$(_this).attr("image")
    var cssstyle=$(_this).attr("cssstyle")
	$('#hdnid').val(id);
	
	
	$('#spnName').html(name);
    if (bit == 0) {
        $('#divPassword').css("display", 'none');
        $('#SelectedItem').html(name);
       // $("#divSelectedCompany").removeClass('selectbginactive');
        //$("#divSelectedCompany").removeClass('selectbgnone');
        //$("#divSelectedCompany").addClass('selectbgactive');
        $("#inner1_spnSelection").html(name);
        //$("#dvCompany").slideUp("slow");	
		Hide();
        $("#hdnMap").val('0');
        $('#hdnindid').val(0);
		$('#hdncid').val(id);
        //$("#divSelectedIndustry").removeClass('selectbgactive');
        //$("#divSelectedIndustry").removeClass('selectbginactive');
        //$("#divSelectedIndustry").addClass('selectbgnone');
        //$("#divSelectedIndustry").html('');
		$('td[group^=industry]').each(
			function()
			{
				$(this).removeClass("menuhoverinner");	
				$(this).attr("show","0");	
					
			}
		);
		$('img[group^=arrow]').each(
		function()
		{
			$(this).attr("src","../Content/images/youselect_arrow_down.png");	
		});

		$('#lnkInnerTheme').attr("href", '../../Content/css/'+ cssstyle +'');
		createCookie('style',cssstyle,1);	      
		SaveSelection('WebService/save-user-selection.aspx/SaveUserSelection', '', GetResult, ErrorMessage);	
    }
    else {
        $('#txtPwd').removeClass('input-validation-error');
        $('#spnPwdError').html('');
        $('#hdncname').val(name);
        $('#CompanyId').val(id);
        pos.left = parseInt(pos.left);
        pos.top = parseInt(pos.top);
        var x = pos.left;
        var y = pos.top;
        $('#divPassword').css("left", x + 175 + 'px');
        $('#divPassword').css("top", y - 55 + 'px');
        $("#hdnimage").val(image);
		$('#divPassword').slideDown("slow");
        $("#hdnStyle").val(cssstyle);
    }
		 
}

var tmp='1';
var obj;
var Company='';
$(document).ready(function(){
  $("#spnChoose").click(function(){
	$('#divPassword').css("display", 'none');
  	tmp=$("#hdnMap").val();
    if(tmp=='1')
	{
		$("#dvCompany").slideUp("slow");	
		$("#hdnMap").val('0');
		$('img[group^=arrow]').each(
		function()
		{
			$(this).attr("src","../Content/images/youselect_arrow_down.png");	
		});

		
	}
	else
	{
		$("#dvCompany").slideDown("slow");	
		$('img[group^=arrow]').each(
		function()
		{
			$(this).attr("src","../Content/images/youselect_arrow_up.png");	
		});
		
		$("#hdnMap").val('1');
		
	}
	$("#dvIndustry").slideUp("slow");	
	$('img[group^=arrow]').each(
		function()
		{
			$(this).attr("src","../Content/images/youselect_arrow_down.png");	
	});

	$("#hdnMapI").val('0');	
  });
})

  
$(document).ready(function(){
var tmp='1';
var obj;
var Industry='';
	
   $("#spnChooseInd").click(function(){
  	tmp=$("#hdnMapI").val();
    if(tmp=='1')
	{
		//$("#dvIndustry").slideUp("slow");
		//$("#dvCompany").slideUp("slow");	
		Hide();
		}
	else
	{
		//$("#dvIndustry").slideDown("slow");	
		//$("#dvCompany").slideDown("slow");
		Show();
		
		$('img[group^=arrow]').each(
		function()
		{
			$(this).attr("src","../Content/images/youselect_arrow_up.png");
		});

	}	
	//$("#dvCompany").slideUp("slow");	
	$("#hdnMap").val('0');
	
	
  });
})

$(document).ready(function () {
    $('#btnSubmit').bind('click', function (event) {
        MyClickEventHandler();
    });
});

function MyClickEventHandler()
{

    SendRequest('WebService/CompanyPassword.aspx/CompanyPasswordValidation', '', GetSendResult, Error);	
}

function SendRequest(url,args,onSuccess,onFail)
{
	if($('#txtPwd').val()=='')
	{
		$('#txtPwd').addClass('input-validation-error');
		$('#spnPwdError').html('The Password field is required.');
	}
	else
	{
		
	    var args = '"pwd":"' + $('#txtPwd').val() + '","id":"' + $('#CompanyId').val() + '"';
		
	    $.ajax({
			type: "POST",
			url: url,
			data: '{' + args +'}',
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: onSuccess,
			error: onFail
		});
	}
}
	
function Error(errorResponse)
{
	
    $('#spnPwdError').html('Your request not submited. Please try again! ')
   		
}
	
function GetSendResult(result)
{
		var name=$('#hdncname').val();
		var image=$('#hdnimage').val();
		var id=$('#hdnid').val();
		var cssstyle=$('#hdnStyle').val();
		if(result)
		{
	    if (result.d.Message == '')
		{
			$('#SelectedItem').html(name);
			//$("#divSelectedCompany").removeClass('selectbginactive');
			//$("#divSelectedCompany").removeClass('selectbgnone');
		  	//$("#divSelectedCompany").addClass('selectbgactive');
		    $("#inner1_spnSelection").html(name);
			//$("#dvCompany").slideUp("slow");	
			Hide();
			$('img[group^=arrow]').each(
			function()
			{
				$(this).attr("src","../Content/images/youselect_arrow_down.png");	
			});
	
			$("#hdnMap").val('0');
			$('#hdnindid').val(0);
			$('#hdncid').val(id);
			//$("#divSelectedIndustry").removeClass('selectbgactive');
			//$("#divSelectedIndustry").removeClass('selectbginactive');
     		//$("#divSelectedIndustry").addClass('selectbgnone');
	    	//$("#divSelectedIndustry").html('');
			$('td[group^=industry]').each(
			function()
			{
				$(this).removeClass("menuhoverinner");	
				$(this).attr("show","0");	
					
			}
		);
				
			$('#divPassword').css("display", 'none');
			$('#lnkInnerTheme').attr("href", '../../Content/css/'+ cssstyle +'');
			createCookie('style',cssstyle,1);
			SaveSelection('WebService/save-user-selection.aspx/SaveUserSelection', '', GetResult, ErrorMessage);
		
			
		}
		else 
        {
            $('#spnPwdError').html(result.d.Message)
			$('#txtPwd').addClass('input-validation-error');
		}
		
    }
	
}

function ChangeLoginFocus(eve)
{
	var code= eve.keyCode||eve.which;
	if (code == 13)
	{
		$('#btnSubmit').click();
	}
}

// Save User Selection Data


function SaveSelection(url,args,onSuccess,onFail)
{
		var iid=$('#hdnindid').val();
		var cid=$('#hdncid').val();
		
	    var args = '"CompanyID":"' + cid + '","IndustryID":"' + iid + '"';
		//alert(args)
	    $.ajax({
			type: "POST",
			url: url,
			data: '{' + args +'}',
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: onSuccess,
			error: onFail
		});
	
}
	
function ErrorMessage(errorResponse)
{
	
    alert("Error");

}
	
function GetResult(result)
{
		//alert("success");
	
}
function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}
function Show()
{
	$("#dvIndustry").slideDown("slow");	
	$("#dvCompany").slideDown("slow");
	$("#hdnMapI").val('1');
	$('img[group^=arrow]').each(
		function()
		{
			$(this).attr("src","../Content/images/youselect_arrow_up.png");	
		});
}
function Hide()
{
	$("#dvIndustry").slideUp("slow");	
	$("#dvCompany").slideUp("slow");
	$("#hdnMapI").val('0');
	$('img[group^=arrow]').each(
		function()
		{
			$(this).attr("src","../Content/images/youselect_arrow_down.png");	
		});
}

 $(document).click(function(e){
    if($(e.target).is('#selecte, #selecte *'))return;
	Hide();

});
</script>
