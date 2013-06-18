<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="select-test.aspx.vb" Inherits="tsma.select_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  href="Content/css/site.css" rel="stylesheet" type="text/css" />
<link id="lnkTheme" href="Content/css/apartment-style.css" rel="stylesheet" type="text/css" />

     <script src="Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
</head>
<body>
    <div>
    <table width="100%" cellpadding="0" cellspacing="0" valign="bottom" align="center" bgcolor="#CCCCCC">
                            <tr>
                              <td style="font-size:20px; color:#FFF; padding-right:5px;" align="right">Industry:</td>
                              <td align="left" height="50">
                              <span id="spnChooseInd" style="cursor:pointer;">
                                <div class="selectbginactive" id="divSelectedIndustry"> &nbsp; </div>
                                </span>
                               <div align="right" style="width:210px; position:absolute; display:none; z-index:11; " id="dvIndustry" >
                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                      <td align="left" valign="top"><img src="../../Content/images/menu_top.png" align="absbottom" width="210"/></td>
                                    </tr>
                                    <tr>
                                      <td align="left" valign="top" class="menubg"><table cellpadding="0" cellspacing="0" border="0" width="100%">
                                          <asp:Repeater ID="rptIndustry" runat="server">
                                          <ItemTemplate>
                                          <tr>
                                            <td height="38" group="industry"  show="0"  onMouseOver="AddClass(this);" onMouseOut="RemoveClass(this)" align="left" valign="middle" class="td456" style="font-family:arial; font-size:14px; color:#FFF; padding-left:15px; padding-right:15px; cursor:pointer;" onClick="GetPositionInd(this);" image='<%# Container.DataItem("i_Icon")%>' cssstyle='<%# Container.DataItem("i_Style")%>' industryid='<%# Container.DataItem("i_id")%>' industryname='<%# Container.DataItem("i_Name")%>'  ><span id="spnIndustry"> <img src="../../Content/images/<%# Container.DataItem("i_Icon")%>" align="absmiddle"/>&nbsp;&nbsp; <%# Container.DataItem("i_Name")%> </span><br />
                                            </td>
                                          </tr>
                                          </ItemTemplate>
                                         </asp:Repeater>
                                          <input type="hidden" id="hdnindid" value="-1" />
                                          <input type="hidden" id="hdnindname" value="" />
                                          <input type="hidden" id="hdnMapI" value="0" />
                                        </table></td>
                                    </tr>
                                    <tr>
                                      <td height="11" align="left" valign="top"><img src="../../Content/images/menu_down.png" width="210" height="11" align="top" /></td>
                                    </tr>
                                  </table>
                                </div></td>
                            </tr>
                            <tr>
                              <td style="font-size:20px; color:#FFF; padding-right:5px;" align="right">Company:</td>
                              <td align="left" height="55" valign="bottom"><span id="spnChoose" style="cursor:pointer;">
                                <div class="selectbginactive" id="divSelectedCompany">&nbsp;</div>
                                </span>
                                <div style="width:210px; position:absolute; display:none; z-index:10;" id="dvCompany">
                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                      <td align="left" valign="top"><img src="../../Content/images/menu_top.png" align="absbottom" width="210"/></td>
                                    </tr>
                                    <tr>
                                      <td class="menubg" valign="top"><table cellpadding="0" cellspacing="0" border="0" width="100%">
                                          <input type="hidden" id="hdncid" value="-1" />
                                          <input type="hidden" id="hdncname" value="" />
                                          <input type="hidden" id="hdnimage" value="" />
                                          <input type="hidden" id="hdnStyle" value="" />
                                          <input type="hidden" id="hdnMap" value="0" />
                                          <input type="hidden" id="hdnid" value="0" />
                                           <asp:Repeater ID="rptCompany" runat="server">
                                           <ItemTemplate>
                                          <tr>
                                            <td  height="38" group="company" align="left" valign="middle" show="0" onMouseOver="AddClass(this);" onMouseOut="RemoveClass(this)" style="font-family:arial; font-size:14px; padding-left:15px; padding-right:15px; color:#FFF; cursor:pointer;" bit='<%# Container.DataItem("c_ispasswordRequired")%>' image='<%# Container.DataItem("c_Icon")%>' companyid='<%# Container.DataItem("c_id")%>' onClick="GetPosition(this);" companyname='<%# Container.DataItem("c_Name")%>' cssstyle='<%# Container.DataItem("c_Style")%>'><span id="spnCompany"><img src="../../Content/images/<%# Container.DataItem("c_Icon")%>" align="absmiddle"/>&nbsp;&nbsp; <%# Container.DataItem("c_Name")%> </span><br />
                                            </td>
                                          </tr>
                                          </ItemTemplate>
                                         </asp:Repeater>
                                          <tr>
                                            <td><div class="passwordpopup" id="divPassword"  style="position:absolute; padding-top:15px;font-size:12px; display:none;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                  <tr>
                                                    <td height="25" align="left" valign="top"><span class="arial16white" style="font-size:14px">Please enter password for <br /><span id="spnName"></span></span></td>
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
                                                    <td height="30" align="left" valign="bottom">
                                                    <img src="Content/images/submit.png" id='btnSubmit' width="67" height="27" border="0" style="cursor:pointer" />
                                                    <%--<input type="image" src="Content/images/submit.png" id='btnPassword' runat="server" width="67" height="27" border="0" />--%>
                                                    </td>
                                                  </tr>
                                                </table>
                                              </div></td>
                                          </tr>
                                        </table></td>
                                    </tr>
                                    <tr>
                                      <td height="11" align="left" valign="top"><img src="../../Content/images/menu_down.png" width="210" height="11" align="top" /></td>
                                    </tr>
                                  </table>
                                </div></td>
                            </tr>
                          </table>
    </div>
</body>
</html>

<script type="text/javascript" language="javascript">
$(document).ready(
function(){
	    var pos = $('#spnChooseInd').position();
		pos.left = parseInt(pos.left);
		pos.top = parseInt(pos.top);
		var x = pos.left;
		var y = pos.top;
		$('#dvIndustry').css('top',y+44+'px')
		
		var pos1 = $('#spnChoose').position();
		pos1.left = parseInt(pos1.left);
		pos1.top = parseInt(pos1.top);
		var x1 = pos1.left;
		var y1 = pos1.top;
		$('#dvCompany').css('top',y1+44+'px')
		
});
  
function AddClass(_this)
{
    $(_this).addClass('menuhover');
}

function RemoveClass(_this)
{
	 var bit = $(_this).attr("show")
	 if(bit==0)
	 { 
	 	$(_this).removeClass('menuhover');
	 }
}
 
function GetPositionInd(_this) {
	$('td[group^=industry]').each(
		function()
		{
			$(this).removeClass("menuhover");	
			$(this).attr("show","0");	
		}
	);
	$(_this).addClass('menuhover');
	$(_this).attr("show","1");
    var pos = $(_this).position();
	var id = $(_this).attr("industryid")
	var name=$(_this).attr("industryname")
	var image=$(_this).attr("image")
	var cssstyle=$(_this).attr("cssstyle")
	$('#hdnindid').val(id);
	$("#divSelectedIndustry").removeClass('selectbginactive');
	$("#divSelectedIndustry").removeClass('selectbgnone');
	$("#divSelectedIndustry").addClass('selectbgactive');
	$("#divSelectedIndustry").html('<img src="../../Content/images/'+ image + '" align="absbottom"/>&nbsp;&nbsp;' + name);
	$('#SelectedItem').html(name);
	$("#dvIndustry").slideUp("slow");	
	$("#hdnMapI").val('0');
	$('#hdncid').val(0);
	$("#divSelectedCompany").removeClass('selectbgactive');
	$("#divSelectedCompany").removeClass('selectbginactive');
	$("#divSelectedCompany").addClass('selectbgnone');
	$("#divSelectedCompany").html('');
	$('td[group^=company]').each(
		function()
		{
			$(this).removeClass("menuhover");	
			$(this).attr("show","0");			
		}
	);
	SaveSelection('WebService/save-user-selection.aspx/SaveUserSelection', '', GetResult, ErrorMessage);

}
function GetPosition(_this) {
  	$('td[group^=company]').each(
		function()
		{
			$(this).removeClass("menuhover");	
			$(this).attr("show","0");			
		}
	);
    $('#CompanyId').val(0);
    $('#txtPwd').val('');
	$(_this).attr("show","1");
    $(_this).addClass('menuhover');
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
        $("#divSelectedCompany").removeClass('selectbginactive');
        $("#divSelectedCompany").removeClass('selectbgnone');
        $("#divSelectedCompany").addClass('selectbgactive');
        $("#divSelectedCompany").html('<img src="../../Content/images/'+ image + '" align="absbottom"/>&nbsp;&nbsp;' + name);
        $("#dvCompany").slideUp("slow");	
        $("#hdnMap").val('0');
        $('#hdnindid').val(0);
		$('#hdncid').val(id);
        $("#divSelectedIndustry").removeClass('selectbgactive');
        $("#divSelectedIndustry").removeClass('selectbginactive');
        $("#divSelectedIndustry").addClass('selectbgnone');
        $("#divSelectedIndustry").html('');
		$('td[group^=industry]').each(
			function()
			{
				$(this).removeClass("menuhover");	
				$(this).attr("show","0");	
					
			}
		);
      
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
		
	}
	else
	{
		$("#dvCompany").slideDown("slow");	
		$("#hdnMap").val('1');
		
	}
	$("#dvIndustry").slideUp("slow");	
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
		$("#dvIndustry").slideUp("slow");	
		$("#hdnMapI").val('0');
	}
	else
	{
		$("#dvIndustry").slideDown("slow");	
		$("#hdnMapI").val('1');
	}	
	$("#dvCompany").slideUp("slow");	
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
			$("#divSelectedCompany").removeClass('selectbginactive');
			$("#divSelectedCompany").removeClass('selectbgnone');
		  	$("#divSelectedCompany").addClass('selectbgactive');
		    $("#divSelectedCompany").html('<img src="../../Content/images/'+ image + '" align="absbottom"/>&nbsp;&nbsp;' + name);
			$("#dvCompany").slideUp("slow");	
			$("#hdnMap").val('0');
			$('#hdnindid').val(0);
			$('#hdncid').val(id);
			$("#divSelectedIndustry").removeClass('selectbgactive');
			$("#divSelectedIndustry").removeClass('selectbginactive');
     		$("#divSelectedIndustry").addClass('selectbgnone');
	    	$("#divSelectedIndustry").html('');
			$('td[group^=industry]').each(
			function()
			{
				$(this).removeClass("menuhover");	
				$(this).attr("show","0");	
					
			}
		);
				
			$('#divPassword').css("display", 'none');
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



</script>