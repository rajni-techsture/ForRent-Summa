<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="library.aspx.vb" Inherits="tsma.library1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
	function ShowUserLib(Id)
	{
		$('#trAdminLib').css('display','none');
		$('#trMyLib').css('display','');
		$('tr[group^=userlibcattr]').each(
		function(){
			$(this).css('display','none');
			
		});
	
		$('#trUserLibCat'+Id).slideDown('slow');
		
	}
	</script>
    <style>
		.error{
			border:1px solid #FF0000;
		}
	</style>
</head>
<body>
<form id="frm" runat="server">
<asp:ScriptManager ID="src1" runat="server"></asp:ScriptManager>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
	<td>
    	<table width="100%" border="0" cellspacing="0" cellpadding="0">
	  <tr>
        <td width="41%" > <textarea id="txtTemplate" runat="server" cols="80" rows="8"></textarea></td>
        <td width="59%" >&nbsp;</td>
      </tr>
       <tr>
        <td width="41%" align="right" ><a href="javascript:;" style="text-decoration:none; color:#990000;"><strong>Save as Draft</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;<a style="text-decoration:none;color:#990000;" onclick="SelectLibCat();" id="lnkSaveToMyLib" href="javascript:;"><strong>Save In My Library</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;<a style="text-decoration:none;color:#990000;" href="javascript:;"><strong>Post&nbsp;</strong></a></td>
        <td width="59%" >
        <div id="divLibCat" style="display:none; position:absolute; border:1px solid #CC0066; background-color:#FFFFFF; padding:10px; width:160px;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <asp:Repeater id="rptLibUserCatList" runat="server">
        	<itemtemplate>
           <tr>
            <td height="30"><asp:LinkButton OnCommand="SaveToMyLibrary"  CommandArgument='<%#Eval("Id")%>' onclientclick = "return ValidateLib()" id="lnkLibCatSel" runat="server"><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></asp:LinkButton></td>
          </tr>
            </itemtemplate>
        </asp:Repeater>
		<tr id="trNew">
            <td height="30" style="cursor:pointer;" onclick="CreateNewLibCat();">Create New</td>
          </tr>
          <tr id="trCreateNew" style="display:none">
            <td><input type="text" id="txtNewLibCat" runat="server" />&nbsp;
            <asp:LinkButton onclientclick = "return ValidateNewLibCat()" id="lnkCreateNewCat" runat="server" OnCommand="SaveToMyLibrary" CommandArgument="-1" >Create</asp:LinkButton>
            </td>
          </tr>
        </table>
        </div>
        <input type="hidden" id="hdnLibCatId" value="0" runat="server" />
        <input type="hidden" id="hdnLibCatName" value="" runat="server" />
        </td>
      </tr>
    </table>
        
    </td>
</tr>
  <tr>
    <td>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td  colspan="3">&nbsp;
        </td>
       </tr>
      <tr>
        <td width="12%" height="30" style="border-bottom:1px solid #990066; border-top:1px solid #990066"><a href="javascript:;" onclick="ChangeTab('trAdminLib');">
          <%= strSelectionType%> Library</a></td>
        <td width="30%"  style="border-bottom:1px solid #990066; border-top:1px solid #990066 "><a href="javascript:;" onclick="ChangeTab('trMyLib');">My Library</a></td>
        <td width="58%" style="border-bottom:1px solid #990066; border-top:1px solid #990066"><asp:Literal id="ltrLibMsg" runat="server"></asp:Literal></td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
  	<td>&nbsp;</td>
  </tr>
  <tr id="trAdminLib" group="libtr">
  	<td>
       <table width="100%" border="0" cellspacing="0" cellpadding="0">
		<asp:Repeater id="rptAdminLibCat" runat="server">
        	<itemtemplate>
		   <tr >
	           <td>
               	<table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td onclick='ShowLib(<%#Eval("Id")%>);' style='background-color:#CCCCCC; cursor:pointer; padding-left:5px;'><strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong></td>
                  </tr>
                  <tr>
                  	<td height="10"></td>
                  </tr>
                  <tr id='trLibCat<%#Eval("Id")%>' style="display:<%#iif(Eval("Row")=1,"","none")%>" group='libcattr'>
                    <td style="padding-left:15px;">
                    	<table width="100%" border="0" cellspacing="0" cellpadding="0">
                         <asp:Repeater id="rptAdminLib" runat="server" DataSource='<%#BindAdminLibraries(Eval("Id"))%>'>
                         	<itemtemplate>
                          <tr>
                            <td style="border-bottom:1px solid #CCCCCC; padding-bottom:10px;">
                            <span id='spnlib<%#Eval("lib_Id")%>'>
                            	<%#Eval("lib_Template")%></span>&nbsp;&nbsp;<a href="javascript:;" onclick='EditLib(<%#Eval("lib_Id")%>);'>Select</a>
                                
                            </td>
                          </tr>
                          <tr>
                          	<td height="10"></td>
                          </tr>
                            </itemtemplate>
                         </asp:Repeater>
                        </table>
                    </td>
                  </tr>
                </table>
               </td>
          </tr>
         <tr>
            <td>&nbsp;</td>
          </tr>
            </itemtemplate>
        </asp:Repeater>
        </table>
    </td>
  </tr>
  <tr id="trMyLib" style="display:none" group="libtr">
  	<td>
    	<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<asp:Repeater id="rptUserLibCat" runat="server">
        	<itemtemplate>
		   <tr >
	           <td>
               	<table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td onclick='ShowUserLib(<%#Eval("Id")%>);' style='background-color:#CCCCCC; cursor:pointer; padding-left:5px;'><strong><%#Eval("Title").replace("{%Selection%}", strSelectionType)%></strong></td>
                  </tr>
                  <tr>
                  	<td height="10"></td>
                  </tr>
                  <tr id='trUserLibCat<%#Eval("Id")%>' style="display:<%#iif(Eval("Row")=1,"","none")%>" group='userlibcattr'>
                    <td style="padding-left:15px;">
                    	<table width="100%" border="0" cellspacing="0" cellpadding="0">
                         <asp:Repeater id="rptUserLib" runat="server" DataSource='<%#BindUserLibraries(Eval("Id"))%>'>
                         	<itemtemplate>
                          <tr>
                            <td style="border-bottom:1px solid #CCCCCC; padding-bottom:10px;">
                            	<span id='spnlib<%#Eval("lib_Id")%>'>
                            	<%#Eval("lib_Template")%>
                                </span>
                                &nbsp;&nbsp;<a href="javascript:;" onclick='EditLib(<%#Eval("lib_Id")%>);'>Select</a>&nbsp;|&nbsp;<asp:LinkButton OnCommand="DeleteMyLib" onclientclick="return Promt();" CommandArgument='<%#Eval("lib_Id")%>' CommandName='<%#Eval("lib_Category")%>' id="lnkAdminLibDelete" runat="server">Delete</asp:LinkButton>
                                
                            </td>
                          </tr>
                          <tr>
                          	<td height="10"></td>
                          </tr>
                            </itemtemplate>
                         </asp:Repeater>
                        </table>
                    </td>
                  </tr>
                </table>
               </td>
          </tr>
         <tr>
            <td>&nbsp;</td>
          </tr>
            </itemtemplate>
        </asp:Repeater>
        </table>
    </td>
  </tr>
 </table>
</form>
</body>
</html>
<script type="text/javascript" language="javascript">

function ChangeTab(Id)
{
	$('tr[group^=libtr]').each(
	function(){
		$(this).css('display','none');
	});
	$('#'+Id).css('display','');
}
function ShowLib(Id)
{
	$('tr[group^=libcattr]').each(
	function(){
		$(this).css('display','none');
		
	});
	
	$('#trLibCat'+Id).slideDown('slow');
}
function ShowUserLib(Id)
{
	$('tr[group^=userlibcattr]').each(
	function(){
		$(this).css('display','none');
		
	});
	
	$('#trUserLibCat'+Id).slideDown('slow');
}
function EditLib(Id)
{
	$('#txtTemplate').val($.trim($('#spnlib'+Id).html()).replace("<br>"));
}
function SelectLibCat()
{
	$('#trNew').css('display','');
	$('#trCreateNew').css('display','none');
	$('#txtNewLibCat').val('');
	$('#hdnLibCatId').val('0');
	var pos = $('#lnkSaveToMyLib').position();
	pos.left = parseInt(pos.left);
	pos.top = parseInt(pos.top);
	var x = pos.left;
	var y = pos.top;
	$('#divLibCat').css('left',x-25 + 'px')
	$('#divLibCat').css('top',y+20 + 'px')

	if($('#divLibCat').css('display')=='none')
	{
		$('#divLibCat').slideDown('slow');		
	}
	else
	{
		$('#divLibCat').slideUp('slow');		
	}
	
}
function CreateNewLibCat()
{
	$('#trNew').css('display','none');
	$('#trCreateNew').css('display','');
	$('#txtNewLibCat').val('');
	$('#hdnLibCatId').val('-1');
	
}
function ValidateNewLibCat()
{
	if($('#txtNewLibCat').val()=='')
	{
		$('#txtNewLibCat').addClass("error");
		return false;
	}
	else
	{
		$('#txtNewLibCat').removeClass("error");
		$('#divLibCat').slideUp('slow');
		return true;
	}

}
function ValidateLib()
{
	$('#hdnLibCatId').val('0');
	$('#trNew').css('display','');
	$('#trCreateNew').css('display','none');
	$('#txtNewLibCat').val('');
	if ($('#txtTemplate').val()=='')
	{
		$('#txtTemplate').addClass('error');
		return false;
	}
	else
	{
		$('#txtTemplate').removeClass('error');
		$('#divLibCat').slideUp('slow');
		return true;
	}
}
function Promt()
{
	return (confirm("Are you sure you want to delete this library?"))
}
</script>