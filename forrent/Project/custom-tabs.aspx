<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="custom-tabs.aspx.vb" Inherits="tsma.custom_tabs" %>
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
<script type="text/javascript" src="Content/js/jquery.carousel-1.1.min_ct.js"></script>
<script type="text/javascript" src="Content/js/jquery.mousewheel.min.js"></script>
<script type="text/javascript" src="Content/js/sample01.js"></script>
<script type="text/javascript">
    function ShowHideDiv(Id3) {
        //alert('url = ' + document.frames['Iframe1'].location.href);
		//alert(Id3);
        $("#customtab").hide();
        $(".carousel").hide();
        $(".carousel1").show("slow");
        var userId3 = document.getElementById("hdnUserId").value;
        var FbuserId3 = document.getElementById("hdnFBUserId").value;
        var CompanyId3 = document.getElementById("hdnCompanyId").value;  //var CompanyId = 0 
        var IndustryId3 = document.getElementById("hdnIndustryId").value; //var IndustryId = 1 
        window.parent.location="custom-tab-selection-edit.aspx?ctId=" + Id3 + "&userId=" + userId3 + "&FbuserId=" + FbuserId3 + "&CId=" + CompanyId3 + "&IId=" + IndustryId3;
		//document.getElementById("lnkCustomTab4").href = "custom-tab-selection-edit.aspx?ctId=" + Id3 + "&userId=" + userId3 + "&FbuserId=" + FbuserId3 + "&CId=" + CompanyId3 + "&IId=" + IndustryId3;
	   //alert(document.getElementById("lnkCustomTab4").href);
		//document.getElementById("Iframe1").src = "custom-tab-selection-edit.aspx?ctId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
    }
	$(document).ready(
		function(){
			 Edit();			
		}
	);
	function Edit()
	{
		var i=<%=Request.QueryString("id")%>
		if(i<0)
		{
			i=i*-1;
			$(".carousel").hide("slow");
			 $("#customtab").hide();
        	$(".carousel1").show("slow");
			document.getElementById("Iframe1").src = "publish-custom-tab.aspx?Id=" + i;
		}
		var i=<%=Request.QueryString("id")%>
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
  <div id="innerpagepagemain"  >
    <uc1:inner ID="inner1" runat="server" />
    <div id="centermain">
                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="170" align="left" valign="top" class="leftbg">
                            <uc3:left ID="left1" runat="server" />
                            </td>
                            <td align="left" valign="top" class="contentbody">
                            
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" id="customtab">
                            <tr><td>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </td></tr>
                            <tr>
                                  <td height="32" align="right" valign="middle" style="padding-bottom:5px;"><a href="javascript:;" onclick="ShowHidePaging('all');" class="bluetablink">
                                  
                                 View All&nbsp;(<asp:Literal ID="ltrCount" runat="server"></asp:Literal>)</a>&nbsp;&nbsp;<a href="javascript:;" onclick="ShowHidePaging('bypage');" class="bluetablink">View By Page</a >
                                  <a href="javascript:;" onclick="ShowHidePaging('Rotator');" class="bluetablink">Carousel</a >
                                  </td>
                            </tr>
                            <tr><td>
                             <div id="divLoading" align="center" style="position:absolute; padding-top:200px; padding-left:300px;">
                                      <asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0">
                                        <ProgressTemplate> <img src="Content/images/popuploading.png" style="border:0px;font-family:Tahoma;font-size:12px;" title="Loading" /> </ProgressTemplate>
                                      </asp:UpdateProgress>
                                    </div>

                            <div style="display:none;" id="trPaging">
                             <asp:UpdatePanel ID="pnlMain" runat="server">
                                      <ContentTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                          <tr>
                                            <td align="right" valign="middle" height="32px" style="font-family:Tahoma, Geneva, sans-serif; font-size:11px; background-color:#edeff4"><strong>
                                              <asp:PlaceHolder ID="phPaging1" runat="server"></asp:PlaceHolder>
                                              </strong> </td>
                                          </tr>
                                          <tr>
                                            <td align="center" style="border:1px solid #ced5e5; padding-top:29px; padding-bottom:29px;"><asp:DataList ID="rptPaging" runat="server" RepeatColumns="1" RepeatDirection="Vertical">
                                                <ItemTemplate>
                                                  <table align="center">
                                                    <tr>
                                                       <td valign="top">
                                                        <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 14px; color: #181818; font-weight:bold; text-align:center; "><%#Container.DataItem("ctm_Name")%></div><br />
                                                       <a id="lnkCustomTab<%#Container.DataItem("ctm_Id") %>" href="javascript:;" onclick='ShowCustomTab(<%#Container.DataItem("ctm_Id") %>)'><img  alt="" src='Content/images/customtab/<%#Container.DataItem("ctm_Image") %>' border="0"/></a>
                                                     
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
                                 <table id="Rotator" style="display:none;" runat="server" border="0" width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                  <td align="left">
                              <div class="carousel" align="center">
                              <h6>
Scroll Mouse To Rotate Templates
    </h6><br />
    <br />
                                <!-- BEGIN CONTAINER -->
                                <div class="slides">
                                  <!-- BEGIN CAROUSEL -->
                                  <asp:Repeater ID="rptCustomTab" runat="server">
                                    <ItemTemplate>
                                      <%--<a id="lnkSidebar" href="javascript:;" onclick='ShowHideDiv(<%#Container.DataItem("ctm_Id") %>)'><img  alt="" width="1000px" src='Content/images/<%#Container.DataItem("ctm_Image") %>' border="0"/></a>--%>
                                        <%--<a id="lnkSidebar" onclick="ShowHideDiv()" href="sidebar_selection.aspx?sdId=<%#Container.DataItem("sdm_Id") %>&userId=<%#Container.DataItem("sdm_UserId")%>&FbuserId=&CId=<%#Container.DataItem("sdm_CompanyId")%>&IId=<%#Container.DataItem("sdm_IndustryId")%>"><img  alt="" src='Content/images/<%#Container.DataItem("sdm_Image") %>' border="0"/></a>--%>
                                         <div style="cursor:pointer;" title='Click here to select this template.' id='<%#Container.DataItem("ctm_Id") %>'>
                                         <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 14px; color: #181818; font-weight:bold; text-align:center; "><%#Container.DataItem("ctm_Name")%></div><br />
											<a id="lnkCustomTab2<%#Container.DataItem("ctm_Id") %>" href="javascript:;"><img alt="" src='Content/images/customtab/<%#Container.DataItem("ctm_Image") %>' border="0"/>
                                            </a>
										 </div>
                                      
                                    </ItemTemplate>
                                  </asp:Repeater>
                                 
                                </div>
                                <!-- END SLIDES -->
                              </div>
                              <!-- END CAROUSEL -->

                    </td></tr>
                    </table>
                     </asp:PlaceHolder>
                      <table id="trNoPaging" width="100%" style="display:;" align="center" border="0" cellpadding="0" cellspacing="0">
                                          <tr>
                                            <td align="center" style="border:1px solid #ced5e5; padding-top:29px; padding-bottom:29px; padding-right:20px;"><asp:DataList ID="rptNoPaging" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
                                                <ItemTemplate>
                                                  <table align="center">
                                                    <tr>
                                                      <td style="padding-bottom:20px;" valign="top">
                                                       <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 14px; color: #181818; font-weight:bold; text-align:center; "><%#Container.DataItem("ctm_Name")%></div><br />
                                                      <a id="lnkCustomTab1<%#Container.DataItem("ctm_Id") %>" href="javascript:;" onclick='ShowCustomTab1(<%#Container.DataItem("ctm_Id") %>)'><img  alt="" src='Content/images/customtab/<%#Container.DataItem("ctm_Image") %>' border="0"/></a><br />
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
                            <table width="100%" style="padding:0px; margin:0px;">
                            <tr>
                            <td align="right" valign="top">
                              <div class="carousel1" id="divContent" align="left" style="display:none;">
                               <iframe style="float:left;" id="Iframe1" name="Iframe1" runat="server" width="840" height="2000" marginwidth="0" marginheight="0" frameborder="0" vspace="0" hspace="0" scrolling="no"></iframe>
                             
                              </div>
                              <a href="#" id="lnkCustomTab4" style="display:none" ></a>
                              </td>
                              </tr>
                              </table>
                              </td>
                          </tr>
                        </table>
                     </div>
  </div>
    <%--<div id="div3" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute;">
                          <asp:UpdateProgress ID="UpdateProgress1" runat="Server" DisplayAfter="0">
                            <ProgressTemplate> <img src="Http://www.mysocialmediaagency.com/tsms_beta/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                          </asp:UpdateProgress>
                        </div>	--%>
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
    function ShowCustomTab(Id) {
        $("#customtab").hide();
        $(".carousel1").show("slow");
        var userId = document.getElementById("hdnUserId").value;
        var FbuserId = document.getElementById("hdnFBUserId").value;
        var CompanyId = document.getElementById("hdnCompanyId").value;
        var IndustryId = document.getElementById("hdnIndustryId").value;
        document.getElementById("lnkCustomTab"  + Id).href = "custom-tab-selection.aspx?ctId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
		//alert(document.getElementById("lnkCustomTab").href);
		//document.getElementById("Iframe1").src = "custom-tab-selection.aspx?ctId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
    }
	 function ShowCustomTab1(Id1) {
		$("#customtab").hide();
        $(".carousel1").show("slow");
        var userId1 = document.getElementById("hdnUserId").value;
        var FbuserId1 = document.getElementById("hdnFBUserId").value;
        var CompanyId1 = document.getElementById("hdnCompanyId").value;
        var IndustryId1 = document.getElementById("hdnIndustryId").value;
		//document.getElementById("lnkCustomTab1" + Id1).href = "custom-tab-selection.aspx?ctId=" + Id1 + "&userId=" + userId1 + "&FbuserId=" + FbuserId1 + "&CId=" + CompanyId1 + "&IId=" + IndustryId1;
		 window.parent.location=  "custom-tab-selection.aspx?ctId=" + Id1 + "&userId=" + userId1 + "&FbuserId=" + FbuserId1 + "&CId=" + CompanyId1 + "&IId=" + IndustryId1;
		//alert(document.getElementById("lnkCustomTab1" + Id1).href);
		//document.getElementById("Iframe1").src = "custom-tab-selection.aspx?ctId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
    }
</script>

