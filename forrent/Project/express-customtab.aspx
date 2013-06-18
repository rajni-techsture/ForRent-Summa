<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="express-customtab.aspx.vb" Inherits="tsma.express_customtab" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Total Social Media Application</title>
<script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
<link rel="Stylesheet" type="text/css" href="Content/css/carousel.css" />
<link href="Content/css/sidebar_style_2.css" rel="stylesheet" type="text/css" />
<link href="Content/facebox/facebox.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="Content/js/jquery.carousel-1.1.min.js"></script>
<script type="text/javascript" src="Content/js/jquery.mousewheel.min.js"></script>
<script type="text/javascript" src="Content/js/sample01.js"></script>
<script type="text/javascript">
    function ShowHideDiv(Id) {
        $("#sidebar").hide();
         $(".carousel").hide();
        $(".carousel1").show("slow");
        var userId = document.getElementById("hdnUserId").value;
        var FbuserId = document.getElementById("hdnFBUserId").value;
        var CompanyId = document.getElementById("hdnCompanyId").value;
        var IndustryId = document.getElementById("hdnIndustryId").value;
        var ctId = document.getElementById("hdnExpressId").value;
        window.location.href="custom-tab-selection.aspx?ctId=" + ctId + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
		//document.getElementById("Iframe1").src = "custom-tab-selection.aspx?ctId=" + ctId + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
		
    }
	$(document).ready(
		function(){
			 Edit();			
		}
	);
	function Edit()
	{
		var i=1//<%=Request.QueryString("id")%>
		if(i<0)
		{
			i=i*-1;
			$(".carousel").hide("slow");
			 $("#sidebar").hide();
        	$(".carousel1").show("slow");
			document.getElementById("Iframe1").src = "publish-sidebar.aspx?Id=" + i;
		}
		var i=1//<%=Request.QueryString("Id")%>
		if(i>0)
		{   
			ShowHideDiv(i);
		}		
	}
	function Publish()
	{
		
	}
	
</script>
</head>
<body>
<form id="frm" runat="server">
 <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
  <div id="innerpagepagemain">
    <uc1:inner ID="inner1" runat="server" />
    <div id="centermain">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td align="left" valign="top"><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="172" align="left" valign="top" class="leftbg"><uc3:left ID="left1" runat="server" />
                            </td>
                            <td align="left" valign="top" class="contentbody">
                             <table width="100%" style="padding:0px; margin:0px;">
                            <tr>
                            <td align="right" valign="top">
                              <div class="carousel1" id="divContent" align="left" style="display:; text-align:left; ">
                                      <iframe id="Iframe1" name="Iframe1" runat="server" width="830" height="2000" marginwidth="0" marginheight="0" frameborder="0" vspace="0" hspace="0" scrolling="no"></iframe>
                                    </div>
                                    <div style="background-color:#FF0000" align="right"> </div>
                                </td>
                                </tr>
                                </table>
                              </td>
                          </tr>
                        </table>
                        
                        </td>
                    </tr>
                  </table></td>
              </tr>
            </table></td>
        </tr>
      </table>
    </div>
  </div>
  <uc2:inner ID="inner2" runat="server" />
  <input type="hidden" runat="server" id="hdnUserId" />
  <input type="hidden" runat="server" id="hdnFBUserId" />
  <input type="hidden" runat="server" id="hdnCompanyId" />
  <input type="hidden" runat="server" id="hdnIndustryId" />
   <input type="hidden" runat="server" id="hdnExpressId" />
</form>
</body>
</html>
<script type="text/javascript">
    function ShowHidePaging(obj) {
        if (obj == 'all') {
            $("#trPaging").hide("slow");
            $("#trNoPaging").show("slow");
            $("#Rotator").hide("slow");
        }
        if (obj == 'bypage') {
            $("#trNoPaging").hide("slow");
            $("#trPaging").show("slow");
            $("#Rotator").hide("slow");
        }
        if (obj == 'Rotator') {
            $("#trNoPaging").hide("slow");
            $("#trPaging").hide("slow");
            $("#Rotator").show("slow");
        }
    }
    function ShowSidebar(Id) {
        $("#sidebar").hide();
        $(".carousel1").show("slow");
        var userId = document.getElementById("hdnUserId").value;
        var FbuserId = document.getElementById("hdnFBUserId").value;
        var CompanyId = document.getElementById("hdnCompanyId").value;
        var IndustryId = document.getElementById("hdnIndustryId").value;
        window.location.href="sidebar_selection.aspx?sdId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
		//document.getElementById("Iframe1").src = "sidebar_selection.aspx?sdId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
    }
</script>