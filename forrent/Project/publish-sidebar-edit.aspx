<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="publish-sidebar-edit.aspx.vb" Inherits="tsma.publish_sidebar_edit" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
    <link href="Content/facebookalert/facebookalert_files/facebook.publish.css" rel="stylesheet" type="text/css">
    <script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Content/js/pagejs/scheduler.js")%>" type="text/javascript"></script>
    <script type="text/javascript">
        function HideProgress() {
            parent.document.getElementById("imgLoading").style.display = 'none';

        }
        function ShowProgress() {
            parent.document.getElementById("imgLoading").style.display = 'block';
        }
        function SaveAlert() {
            $("#DivSaveSidebar").show("slow");
        }
        function HideSaveAlert() {
            $("#DivSaveSidebar").hide("slow");
        }
        function GotoSidebar() {
            window.top.location.href = "sidebar";
        }
		function CreatePage() {
    window.open("http://www.facebook.com/pages/create.php?", "Page", "left=20,top=20,menubar=0,resizable=0,width=1000,height=850");
}
				
</script>
<script type="text/javascript" src="Content/facebookalert/facebookalert_files/jquery_facebook.publish.js"></script>
	<script type="text/javascript">
		
		</script>
    <script src="Content/js/redirect-to-home.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="objScriptManager1" runat="server"></asp:ScriptManager>
     <div id="innerpagepagemain"  >
<uc1:inner ID="inner1" runat="server" />
<div id="centermain" style="height:950px;">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
  <td width="170" align="left" valign="top" class="leftbg"><uc3:left ID="left1" runat="server" />
  </td>
  <td align="left" valign="top" class="contentbody">
    <div id="DivSaveSidebar" style="width:100%; height:100%; text-align:center; background-image:url(Content/facebookalert/images/popup_bg.png); position:absolute; z-index:10000000; text-align:center;  display:none;">
			  <div id="popup_container1" >
			    <div id="popup_content" style="padding-top:10px; padding-left:20px; text-align:left">
                  Sidebar Published To Your Page(s) Successfully<br/><br/>
                   <input type="button" class="inputbutton" onclick="HideSaveAlert();" value="Close" id="popup_close" />
				</div>
			 </div>
			 </div>
    <div style="float:left; padding-left:30px; padding-top:5px;"><a href="javascript:;" onclick="GotoSidebar();" class="bluetablink">Go Back to Sidebar</a></div>
    <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 16px; color: #181818; margin:0px;	font-weight:bold;
	line-height:18px; text-align:center">Publish sidebar on Facebook Business pages</div><br />
   <div style="padding-bottom:10px; ">
          <center>
           <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></center>
</div>
           <div id="divSidebarHtml" runat="server" align="left" style="float:left; width:200px;">
            </div>
            <div align="left" style="float:left; width:550px;">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="33" align="left" valign="middle"><img src="Content/images/quick_start_tutorial_left_arrow_gray.png" width="33" height="101" /></td>
    <td align="left" valign="top" style="background-color:#f0f0f0; padding:10px; padding-bottom:0px">
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
   	
  <tr>
    <td align="left" valign="top">
    <asp:PlaceHolder id="plcData" runat="server">
    <div style="background-color:#FFF; border:1px solid #bdc7d8; height:500px; overflow:auto; overflow-x:hidden; padding:20px; padding-right:0px;">
             <input type="hidden" id="hdnselectedPages" runat="server" name="hdnselectedPages"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesName" runat="server" name="hdnSelectedPagesName"
                                                                    value="" />
                  <input type="hidden" id="hdnSelectedPagesImage" runat="server" name="hdnSelectedPagesImage"
                                                                    value="" />
                  <input type="hidden" id="hdnselectedPagesAccessToken" runat="server" name="hdnselectedPagesAccessToken"
                                                                    value="" />
                    <asp:DataList ID="dstFanPages" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                      <ItemTemplate>
                        <table id="NonFanPage" runat="server" width="230" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="48" align="left" valign="middle" >
                            <img src='<%#Eval("picture")%>' width="40" height="40" style="margin-bottom:10px;" group="pageimg"pageid='<%#Eval("Id")%>' />

                              </td>
                            <td width="40" align="left" valign="middle" style="padding-right:10px;" ><table border="0" width="170" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="25" align="left" valign="middle">
                                  <input class="checkboxpadding" type="radio" id="chkPage" name="chkPage" runat="server" pageid='<%#Eval("Id")%>' group="pages" onclick='Pageid(this);' pageaccess_token='<%#Eval("access_token")%>' pagevalue='<%#Eval("name")%>' pageimage='<%#Eval("picture")%>' /></td>
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
     </asp:PlaceHolder>
       <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
				   <strong style="color:#990066">  You have no business pages.</strong><br /><br /> <a href="javascript:CreatePage();">Click here</a> to create business page. 
		   </asp:PlaceHolder> 
    </td>
  </tr>
   
  
  <tr>
    <td height="50" align="left" valign="middle">
    <a onclick="ValidatePublish();" title="Publish Sidebar" href="javascript:;"  class="bluetablink" >Publish Sidebar&nbsp;&nbsp;</a>
    <a title="Edit Sidebar" href="sidebar_selection_edit.aspx?sdId=<%=Session("SidebarID")%>&userId=<%=Session("SiteUserId")%>&FbuserId=<%=Session("FacebookUserId")%>&CId=0&IId=1"  class="bluetablink" >Go Back to Edit Sidebar&nbsp;</a>
    <a id="lnkDownload" class="bluetablink" runat="server" title="Download Sidebar" style="display:none;">Download Sidebar</a>
    <a id="btnUpload"  runat="server"  style="display:none">Publish Sidebar</a></td>
  </tr>
 

</table>

    
    
    </td>
  </tr>
  </table>

     
     </div>
      <div style="padding-left:10px;">
                                  <img id="imgLoading" src="http://www.mysocialmediaagency.com/tsms_beta/images/bigspinner.gif" style="display:none" />
                                  </div>
<div style="display:none;  padding:15px; padding-top:1100px;  position:absolute; z-index:10000000;" id="divLoading" >
            		<div style="border:2px solid #000000; width:350px; height:80px; background-color:#FFFFFF;">
			<table cellpadding="2" cellspacing="0" border="0" width="100%">
			<tr>
			<td style="font-size:16px;">
			<img src="content/images/demo_wait.gif" align="absmiddle"  />&nbsp;Adding Sidebar to your page...
			</td>
			</tr>
			</table>
			</div>
            </div> 
            </td>
            </tr>
            </table>
            </div>
            </div>
            
</td>
</tr>
</table>
</div>
</div>
     
    </form>

<%--<div id="div3" runat="server" style="margin-right:0px;width:74px;height:40px;overflow:hidden;position:absolute;">
                          <asp:UpdateProgress ID="UpdateProgress1" runat="Server" DisplayAfter="0">
                            <ProgressTemplate> <img src="Http://www.mysocialmediaagency.com/tsms_beta/images/bigspinner.gif" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" /> </ProgressTemplate>
                          </asp:UpdateProgress>
                        </div>	--%>
<uc2:inner ID="inner2" runat="server" />
</body>
</html>

