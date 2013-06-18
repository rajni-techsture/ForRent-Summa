<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sidebar.aspx.vb" Inherits="tsma.sidebar" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Total Social Media Application</title>
<script type="text/javascript" src="Scripts/jquery-1.6.2.js"></script>
<link rel="Stylesheet" type="text/css" href="Content/css/carousel.css" />
<link href="Content/css/sidebar_style_2.css" rel="stylesheet" type="text/css" />
<link href="Content/facebox/facebox.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="Content/js/jquery.carousel-1.1.min.js"></script>
<script type="text/javascript" src="Content/js/jquery.mousewheel.min.js"></script>
<script type="text/javascript" src="Content/js/sample01.js"></script>
<script type="text/javascript">
    function ShowHideDiv(Id3) {
        $("#sidebar").hide();
        $(".carousel").hide();
        $(".carousel1").show("slow");
	    var userId3 = document.getElementById("hdnUserId").value;
        var FbuserId3 = document.getElementById("hdnFBUserId").value;
        var CompanyId3 = document.getElementById("hdnCompanyId").value;  //var CompanyId = 0 
        var IndustryId3 = document.getElementById("hdnIndustryId").value; //var IndustryId = 1 
        window.parent.location =  "sidebar_selection_edit.aspx?sdId=" + Id3 + "&userId=" + userId3 + "&FbuserId=" + FbuserId3 + "&CId=" + CompanyId3 + "&IId=" + IndustryId3;
		
    }
	$(document).ready(function(){
			 Edit();			
		});
	function Edit()
	{
		var i=<%=Request.QueryString("id")%>
		if(i<0)
		{
			i=i*-1;
			$(".carousel").hide("slow");
			$("#sidebar").hide();
        	$(".carousel1").show("slow");
			document.getElementById("Iframe1").src = "publish-sidebar.aspx?Id=" + i;
		}
		var i=<%=Request.QueryString("Id")%>
		if(i>0)
		{   
			ShowHideDiv(i);
		}		
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
                            <td width="172" align="left" valign="top" class="leftbg">
                            <uc3:left ID="left1" runat="server" />
                            </td>
                            <td align="left" valign="top" class="contentbody">
                             <table cellpadding="0" cellspacing="0" border="0" width="100%" id="sidebar">
                             <tr><td>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </td></tr>
                            <tr>
                                  <td height="32" align="right" valign="middle" style="padding-bottom:5px;"><a href="javascript:;" onclick="ShowHidePaging('all');" class="bluetablink">
                                  
                                 View All&nbsp;(<asp:Literal ID="ltrCount" runat="server"></asp:Literal>)</a>&nbsp;&nbsp;<a href="javascript:;" onclick="ShowHidePaging('bypage');" class="bluetablink">View By Page</a >
                                  <a href="javascript:;" onclick="ShowHidePaging('Rotator');" class="bluetablink">Carousel</a >
                                  </td>
                            </tr>
                            <tr><td valign="top" >
                              <div id="divLoading" align="center" style="position:absolute; padding-top:200px; padding-left:300px;">
                                      <asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0">
                                        <ProgressTemplate> <img src="Content/images/popuploading.png" style="border:0px;font-family:Tahoma;font-size:12px;" title="Loading" /> </ProgressTemplate>
                                      </asp:UpdateProgress>
                                    </div>
                             <div style="display:none;" id="trPaging">
                              <asp:UpdatePanel ID="pnlMain" runat="server">
                                      <ContentTemplate>
                                        <table cellpadding="0"  cellspacing="0" border="0" width="100%">
                                          <tr>
                                            <td align="right" valign="middle" height="32px" style="font-family:Tahoma, Geneva, sans-serif; font-size:11px; background-color:#edeff4"><strong>
                                              <asp:PlaceHolder ID="phPaging1" runat="server"></asp:PlaceHolder>
                                              </strong> </td>
                                          </tr>
                                          <tr>
                                            <td align="center" style="border:1px solid #ced5e5; padding-top:29px; padding-bottom:29px;"><asp:DataList ID="rptPaging" runat="server" RepeatColumns="2" RepeatDirection="Vertical">
                                                <ItemTemplate>
                                                  <table align="center">
                                                    <tr>
                                                       <td valign="top">
                                                        <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 14px; color: #181818; font-weight:bold; text-align:center; "><%#Container.DataItem("sdm_Name")%></div><br />
                                                       <a id="lnkSidebar<%#Container.DataItem("sdm_Id") %>" href="javascript:;" onclick='ShowSidebar(<%#Container.DataItem("sdm_Id") %>)'><img  alt="" src='Content/images/sidebar/<%#Container.DataItem("sdm_Image") %>' border="0"/></a>
                                                     
                                                        <%--<a id="lnkSidebar" onclick="ShowHideDiv()" href="sidebar_selection.aspx?sdId=<%#Container.DataItem("sdm_Id") %>&userId=<%#Container.DataItem("sdm_UserId")%>&FbuserId=&CId=<%#Container.DataItem("sdm_CompanyId")%>&IId=<%#Container.DataItem("sdm_IndustryId")%>"><img  alt="" src='Content/images/<%#Container.DataItem("sdm_Image") %>' border="0"/></a>--%>
                                                      </td>
                                                      <td align="left" width="20">&nbsp;</td>
                                                    </tr>
                                                  </table>
                                                </ItemTemplate>
                                              </asp:DataList>
                                            </td>
                                          </tr>
                                          <tr style="display:none">
                                            <td align="left"><a href="javascript:;">View All</a> </td>
                                            <td align="right" height="25"><strong>
                                              <asp:PlaceHolder ID="phPaging" runat="server"  ></asp:PlaceHolder>
                                              </strong></td>
                                          </tr>
                                        </table>
                                      </ContentTemplate>
                                    </asp:UpdatePanel>
                                   </div> 
                            <asp:PlaceHolder id="pnlCarousel" runat="server">
                              <table id="Rotator"  style="display:none;" border="0" width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                  <td align="left">
                                  <div class="carousel" align="center">
<h6>
Scroll Mouse To Rotate Templates
    </h6><br />
                                      <br />
                                      <div class="slides">
                                        <asp:Repeater ID="rptSidebar" runat="server">
                                          <ItemTemplate>
                                            <div style="cursor:pointer;" title='Click here to select this template.' id='<%#Container.DataItem("sdm_Id") %>'>
                                            <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 14px; color: #181818; font-weight:bold; text-align:center; "><%#Container.DataItem("sdm_Name")%></div><br />
											<a id="lnkSidebar2<%#Container.DataItem("sdm_Id") %>" href="javascript:;"><img  alt="" src='Content/images/sidebar/<%#Container.DataItem("sdm_Image") %>' border="0"/>                                            </a>
											</div>
                                          </ItemTemplate>
                                        </asp:Repeater>
                                      </div>
                                    </div>
                                   </td>
                                </tr>
                              </table>
                              </asp:PlaceHolder>
                              
                              
                            
                           
                            
                                    <table id="trNoPaging" width="100%" style="display:;" align="center" border="0" cellpadding="0" cellspacing="0">
                                          <tr>
                                            <td align="right" style="border:1px solid #ced5e5; padding-top:29px; padding-bottom:29px; padding-right:20px;"><asp:DataList ID="rptNoPaging" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                                <ItemTemplate>
                                                  <table align="center">
                                                    <tr>
                                                      <td style="padding-bottom:20px;" valign="top">
                                                       <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 14px; color: #181818; font-weight:bold; text-align:center; "><%#Container.DataItem("sdm_Name")%></div><br />
                                                      <a id="lnkSidebar1<%#Container.DataItem("sdm_Id") %>" href="javascript:;" onclick='ShowSidebar1(<%#Container.DataItem("sdm_Id") %>)'><img  alt="" src='Content/images/sidebar/<%#Container.DataItem("sdm_Image") %>' border="0"/></a><hr />
                                                      <%--<a id="lnkSidebar" href="sidebar_selection.aspx?sdId=<%#Container.DataItem("sdm_Id") %>&userId=<%#Container.DataItem("sdm_UserId")%>&FbuserId=&CId=<%#Container.DataItem("sdm_CompanyId")%>&IId=<%#Container.DataItem("sdm_IndustryId")%>"><img  alt="" src='Content/images/<%#Container.DataItem("sdm_Image") %>'/></a>--%> </td>
                                                      <td align="left" width="30" style="padding-bottom:20px;">&nbsp;</td>
                                                    </tr>
                                                  </table>
                                                </ItemTemplate>
                                              </asp:DataList>
                                            </td>
                                          </tr>
                                        </table>
                                  </td></tr>      
                            </table>
                              <div class="carousel1" id="divContent" align="left" style="display:none; text-align:left; ">
                                      <iframe id="Iframe1" name="Iframe1" runat="server" width="750" height="950" marginwidth="0" marginheight="0" frameborder="0" vspace="0" hspace="0" scrolling="no"></iframe>
                                    </div>
                                    <div style="background-color:#FF0000" align="right"> </div>
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
        document.getElementById("lnkSidebar"  + Id).href= "sidebar_selection.aspx?sdId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
        //document.getElementById("Iframe1").src = "sidebar_selection.aspx?sdId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
    }
	function ShowSidebar1(Id1) {
        $("#customtab").hide();
        $(".carousel1").show("slow");
        var userId1 = document.getElementById("hdnUserId").value;
        var FbuserId1 = document.getElementById("hdnFBUserId").value;
        var CompanyId1 = document.getElementById("hdnCompanyId").value;
        var IndustryId1 = document.getElementById("hdnIndustryId").value;
		window.parent.location="sidebar_selection.aspx?sdId=" + Id1 + "&userId=" + userId1 + "&FbuserId=" + FbuserId1 + "&CId=" + CompanyId1 + "&IId=" + IndustryId1;
		//document.getElementById("lnkSidebar1" + Id1).href = "sidebar_selection.aspx?sdId=" + Id1 + "&userId=" + userId1 + "&FbuserId=" + FbuserId1 + "&CId=" + CompanyId1 + "&IId=" + IndustryId1;
		//alert(document.getElementById("lnkCustomTab").href);
		//document.getElementById("Iframe1").src = "custom-tab-selection.aspx?ctId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
    }
</script>