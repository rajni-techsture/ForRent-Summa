<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="left.ascx.vb" Inherits="tsma.headerleft" %>
<script language="javascript" type="text/javascript">
  	 function SubMenu(obj) {
		$('#hdnLinkval').val(obj);
		var SaveData = $('#hdnSaveHeader').val();
		if (SaveData == "1")
		{	
			$('#divsubmenu').slideDown();
			return true;
		}
		else
		{
			SaveBeforeExistLeftAlert();
			return false;
		}
     }
   function SaveBeforeExistLeftAlert()
		{
				  var maskHeight = $(document).height();
				  var maskWidth = $(window).width();
				  $('#DivSaveBeforeExist').css({'width':maskWidth,'height':maskHeight});
				  $("#DivSaveBeforeExist").show("slow");
				}
				function HideLinkAlert() {
				    $("#DivSaveBeforeExist").hide("slow");
				}
				function ChangedPage()
				{	
					//alert("test");
					//alert($('#lnkMenu').attr('href'));
					//alert($('#hdnLinkval').val());
					window.parent.location= $('#hdnLinkval').val();
					return true;
	}
	function OpenSubMenu(obj) {
	    $('#' + obj).slideDown();
	}
	function OpenSubMenu2() {
	    $('#divsubmenustatic2').slideDown();
	}

  </script>

<input type="hidden" id="hdnLinkval" value="" />
<div style="padding-top:15px; padding-bottom:15px;">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr style="display:none">
            <td width="10" align="left" valign="middle" class="leftline"><span style="line-height:22px;"><img src="../Content/images/arrow-gray.gif" width="4" height="7" style="margin-left:7px; margin-right:5px;" border="0"/></span></td>
            <td width="95%" height="40" align="left" valign="middle" class="leftline"><a href='<%=ResolveUrl("setup-page")%>' onclick="return SubMenu(this);" class="leftlink">Setup a Page</a> </td>
          </tr>
          <tr>
            <td width="10" align="left" valign="middle" class="leftline"><span style="line-height:22px;"><img src="../Content/images/arrow-gray.gif" width="4" height="7" style="margin-left:7px; margin-right:5px;" border="0"/></span></td>
            <td width="95%" height="40" align="left" valign="middle" class="leftline"><a onclick="return OpenSubMenu('divPostnLeap');" href='javascript:;'  class="leftlink">Engage</a> </td>
          </tr>
           <tr>
            <td  colspan="2" align="left" valign="middle" style="padding-left:10px; padding-top:5px; ">
            <div id="divPostnLeap" style="display:none;">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                  <tr>
                    <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:5px;">
                    <img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; 
                    <a onclick="return OpenSubMenu('divEnagageSubMenu');" href='javascript:;'  class="leftlink">Post N' Leap</a> 
                   </td>
                  </tr>
                  <tr>
                    <td  colspan="2" align="left" valign="middle" style="padding-left:10px; padding-top:5px; ">
                    <div id="divEnagageSubMenu" style="display:;">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                          <tr>
                            <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:2px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; 
                            <a onclick="return SubMenu(this);" href='<%=ResolveUrl("scheduler-main")%>'>Quick Post & Scheduler</a> </td>
                          </tr>
                          <tr>
                            <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:2px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a onclick="return SubMenu(this);" href='<%=ResolveUrl("view-autopost")%>'>Autopost Admin View</a> </td>
                          </tr>                  
                          <tr>
                            <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:2px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a onclick="return SubMenu(this);" href='<%=ResolveUrl("configure-autopost")%>'>Set Daily Autopost</a> </td>
                          </tr>
        
                        </table>
                      </div></td>
                  </tr>
                </table>
                </div>
              </td>
          </tr>
          
          
          <tr style="display:none">
            <td width="10" align="left" valign="middle" class="leftline" ><img src="../Content/images/arrow-gray.gif" width="4" height="7" style="margin-left:7px; margin-right:5px;" border="0"/></td>
            <td width="95%" height="40" align="left" valign="middle" class="leftline" ><a onclick="return OpenSubMenu('divsubmenustatic');" href='javascript:;'  class="leftlink">Design</a> </td>
          </tr>
          <tr>
            <td  colspan="2" align="left" valign="middle" style="padding-left:10px; padding-top:5px; "><div id="divsubmenustatic" style="display:none;">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                  <tr style="display:none">
                    <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; padding-left:5px;"><img border="0" src="../content/images/light_gray_arrow.png" />&nbsp; <a onclick="return OpenSubMenu2();" href='javascript:;'>Express Setup</a> </td>
                  </tr>
                  <tr style="display:none">
                    <td colspan="2" align="left" valign="middle" style="padding-left:13px; padding-top:5px; "><div id="divsubmenustatic2" style="display:none;">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                          <tr>
                            <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:5px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a  onclick="return SubMenu(this);" href='<%=ResolveUrl("express-sidebar")%>'>Express Sidebar</a> </td>
                          </tr>
                          <tr>
                            <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:5px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a onclick="return SubMenu(this);" href='<%=ResolveUrl("express-customtab")%>'>Express Custom Tab</a> </td>
                          </tr>
                        </table>
                      </div></td>
                  </tr>
                  <tr>
                    <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:5px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a onclick="return SubMenu(this);" href='<%=ResolveUrl("cover-photo")%>'>Cover Photos</a> </td>
                  </tr>
                  <%-- <tr>
		                <td height="40" style="line-height:20px; font-size:12px; vertical-align:middle; border-bottom:1px  solid #cccccc; padding-left:5px;">
           		         <img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a onclick="return SubMenu(this);" href='<%=ResolveUrl("sidebar")%>'>Sidebars</a>
		                </td>
		            </tr>--%>
                  <tr>
                    <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:5px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a onclick="return SubMenu(this);" href='<%=ResolveUrl("custom-tab")%>'>Custom Tabs</a> </td>
                  </tr>
                </table>
              </div></td>
          </tr>
          <tr>
            <td width="10" align="left" valign="middle" class="leftline" ><img src="../Content/images/arrow-gray.gif" width="4" height="7" style="margin-left:7px; margin-right:5px;" border="0"/></td>
            <td width="95%" height="40" align="left" valign="middle" class="leftline" ><a onclick="return OpenSubMenu('divgrowth');" href='javascript:;'  class="leftlink">Growth</a> </td>
          </tr>
          <tr>
            <td colspan="2" align="left" valign="middle" style="padding-left:10px; padding-top:5px; ">
            <div id="divgrowth" style="display:none;">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                   <tr>
                    <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:5px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a onclick="return SubMenu(this);" href='<%=ResolveUrl("cover-photo")%>'>Design Cover Photos</a> </td>
                  </tr>
                  <tr>
                    <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:5px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a onclick="return SubMenu(this);" href='<%=ResolveUrl("custom-tab")%>'>Design Custom Tabs</a> </td>
                  </tr>
                  <tr>
                    <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; vertical-align:middle; padding-left:5px;"><img border="0" src="../content/images/light_gray_arrow.png" align="absmiddle"/>&nbsp; <a onclick="return SubMenu(this);" href='<%=ResolveUrl("sweepstakes")%>'>Sweepstakes</a> </td>
                  </tr>
                </table>
              </div></td>
          </tr>
          <tr style="display:none">
            <td width="10" align="left" valign="middle" class="leftline"><span style="line-height:22px;"> <img border="0" src="../Content/images/arrow-gray.gif" width="4" height="7" style="margin-left:7px; margin-right:5px;" /></span></td>
            <td width="95%" height="40" align="left" valign="middle" class="leftline"><a onclick="return SubMenu(this);" href='<%=ResolveUrl("training")%>'  class="leftlink">Training</a> </td>
          </tr>
          <tr style="display:none">
            <td width="10" align="left" valign="middle" class="leftline"><span style="line-height:22px;"> <img border="0" src="../Content/images/arrow-gray.gif" width="4" height="7" style="margin-left:7px; margin-right:5px;" /></span></td>
            <td width="95%" height="40" align="left" valign="middle" class="leftline"><a onclick="return SubMenu(this);" href='<%=ResolveUrl("support")%>'  class="leftlink">Support</a> </td>
          </tr>
        </table>
        <%--<asp:Repeater runat="server" ID="rptLeftMenu">
        <itemtemplate>
        	<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr style="display:none;">
				<td width="10" align="left" valign="middle" class="leftline"><span style="line-height:22px;"> <img border="0" src="../Content/images/arrow-gray.gif" width="4" height="7" style="margin-left:7px; margin-right:5px;" /></span></td>
				<td width="95%" height="40" align="left" valign="left" class="leftline">
                    <input type="hidden" id="hdnid" runat="server" value='<%#Container.DataItem("mnu_id")%>' />
                   <a id="lnkMenu" onclick="return SubMenu(this);" href='<%#Container.DataItem("mnu_link")%>'  class="leftlink"><%#Container.DataItem("mnu_Name")%></a>
                    
             </td>
			</tr>
             <tr>
      <td  colspan="2" align="left" valign="middle" style="padding-left:10px; padding-top:5px; ">
	  <input type="hidden" id="hdnMap" value="0" />
     <div id="divsubmenu" style="display:none;">
      <asp:Repeater runat="server" ID="rptLeftSubMenu" DataSource='<%# GetSubMenu(DataBinder.Eval(Container.DataItem, "mnu_Id")) %>' >
        <itemtemplate>
         
          <table cellpadding="0" cellspacing="0" border="0" width="100%" >
		  <tr>
		  <td height="40" style="line-height:20px; font-size:12px; border-bottom:1px  solid #cccccc; padding-left:5px;">
           <input type="hidden" id="hdnpid" runat="server" value='<%#Container.DataItem("mnu_Pmnuid")%>' />
		   <img border="0" src="../content/images/light_gray_arrow.png" />&nbsp; <a onclick="return SubMenu(this);" href='<%#Container.DataItem("mnu_link")%>'><%#Container.DataItem("mnu_Name")%></a>
		  </td>
		  </tr>
		  </table>
          
        </itemtemplate>
        </asp:Repeater>
        </div>
	 </td>
    </tr>		
			</table>
          </itemtemplate>
        </asp:Repeater>--%>
      </td>
    </tr>
    <tr>
      <td align="left" valign="top" style="padding-top:20px; padding-left:7px;"><a href="https://www.facebook.com/twitter/?setup=1" target="_blank"> <img src="../Content/images/facebook_twitter.png" border="0" align="left" /></a> </td>
    </tr>
    <%--
    <tr>
		  <td style="line-height:22px;">
		   <img border="0" src="content/images/light_gray_arrow.png" />&nbsp;<a href="<%=ResolveUrl("scheduler")%>">Schedule Post</a>
		  </td>
		  </tr>
		  <tr>
		  <td style="line-height:22px;">
		   <img border="0" src="content/images/light_gray_arrow.png" />&nbsp;<a href="<%=ResolveUrl("drafts")%>">View Drafts <asp:Literal ID="ltrdrafts" runat="server"></asp:Literal></a>
		  </td>
		  </tr>
		  <tr>
		  <td style="line-height:22px;">
		   <img border="0" src="content/images/light_gray_arrow.png" />&nbsp;<a href="<%=ResolveUrl("templates")%>">View Templates <asp:Literal ID="ltrtemplates" runat="server"></asp:Literal></a>
		  </td>
		  </tr>
		  <tr>
		  <td style="line-height:22px;">
		   <img border="0" src="content/images/light_gray_arrow.png" />&nbsp;<a href="<%=ResolveUrl("sent-messages")%>">View Sent Messages</a>
		  </td>
		  </tr>
          <tr>
		  <td style="line-height:22px;">
		   <img border="0" src="content/images/light_gray_arrow.png" />&nbsp;<a href="<%=ResolveUrl("pending-messages")%>">View Pending Messages <asp:Literal ID="ltrpending" runat="server"></asp:Literal></a>
		  </td>
		  </tr>
		 <tr>
		  <td style="line-height:22px;">
		   <img border="0" src="content/images/light_gray_arrow.png" />&nbsp;<a href="scheduler/scheduledmessage">View Sheduled Messages</a>
		  </td>
		  </tr>--%>
  </table>
</div>
<script language="javascript" type="text/javascript">
    $("#lnkPostNLeapStatic").click(function () {
  //  alert('test');
//        if (hdnid.value == hdnpid.value) {
//            alert('test');
//            $("#menuPostScheduler1").slideDown("slow");
//        }
    });
    
//    $("#lnkPostNLeapStatic").click(function () {
//        if (hdnid.value == hdnpid.value) {
//            alert('test');
//            $("#menuPostScheduler1").slideDown("slow");
//        }
//    });
//    var url = window.location;
//    var p = /.+\/([^\/]+)/;
//    var match = p.exec(url)
//    if (match[1] == 'sidebar' || match[1] == 'custom-tab' || match[1] == 'sidebar-templates' || match[1] == 'create-sidebar' || match[1] == 'sent-messages' || match[1] == 'pending-messages' || match[1] == 'SaveAsTemplate' || match[1] == 'sweepstake' || match[1] == 'quickpost') {
//        $("#menuPostScheduler1").slideDown("slow");
//    }
 </script>
