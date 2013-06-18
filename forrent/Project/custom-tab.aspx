<%@ Page Language="vb" AutoEventWireup="false" Debug="true" validateRequest="false" CodeBehind="custom-tab.aspx.vb" Inherits="tsma.custom_tab" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
 <script src="Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
<title>Total Social Media Application</title>
<style >
.imgborderSelected{
	padding:1px;
	border:4px solid #9FC9ED;
}
</style>
</head>
<body>
<form id="form1" runat="server">
 <div id="innerpagepagemain">
  <uc1:inner ID="inner1" runat="server" />
 <div id="centermain">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td align="left" valign="top" ><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="172" align="left" valign="top" class="leftbg" >
                   		<uc3:left ID="left1" runat="server" />
                        </td>
                        <td align="left" class="contentbody" height="500" valign="top">
                        <asp:PlaceHolder id="plcCreateTab" runat="server" Visible="true">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td>Create a custom tab on your fan page.</td>
                            </tr>
                            <tr>
                              <td height="15" align="center" style="color:#990066; font-weight:bold"><asp:Literal id="ltrMessage" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                              <td height="30">
                              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td width="80" align="right" style="padding-right:10px;"><strong>Tab Title&nbsp;:</strong></td>
                                    <td ><input type="text" id="txtTabTitle" runat="server" style="width:250px;" /></td>
                                  </tr>
                                  <tr>
                                    <td height="5" colspan="2"></td>
                                  </tr>
                                   <tr>
                                    <td width="80" valign="top" align="right" style="padding-right:10px;"><strong>Content&nbsp;:</strong></td>
                                    <td><textarea id="txtContent" runat="server" cols="45" rows="8"></textarea>
                                    </td>
                                  </tr>
                                    <tr>
                                    <td height="5" colspan="2"></td>
                                  </tr>
                                </table>
                               </td>
                            </tr>
                             <tr>
                              <td height="30"><a href="javascript:;" onclick="ShowHideDiv();">Select Business Pages</a></td>
                            </tr>
                            <tr>
                              <td >
                              <div id="divPages" style="display:none; ">
                              <asp:PlaceHolder ID="plcData" runat="server">
                               <asp:DataList ID="dstFanPages" runat="server" RepeatColumns="3">
                      <ItemTemplate>
                        <table width="240" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="48" align="left" valign="middle" >
                            <img src='<%#Eval("picture")%>' width="40" height="40" style="margin-bottom:10px;" class='imgborder' group="pageimg"pageid='<%#Eval("Id")%>' /></td>
                            <td width="40" align="left" valign="middle" style="padding-right:10px;" ><table border="0" width="170" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="25" align="left" valign="middle"><input type="checkbox" id="chkPage" runat="server" pageid='<%#Eval("Id")%>' group="page" onchange="Checked(this);" />
                                          &nbsp;<%#Eval("name")%>
                                          <input type="hidden" id="hdnPageId" runat="server" value='<%#Eval("Id")%>' />
                                          <input type="hidden" id="hdnAccessToken" runat="server" value='<%#Eval("access_token")%>' />
                                          <input type="hidden" id="hdnPageName" runat="server" value='<%#Eval("name")%>' />
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
                              <%-- <asp:PlaceHolder ID="plcData" runat="server">
                               <asp:DataList id="dstFanPages" runat="server" RepeatColumns="4" >
                                  <itemtemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                      <tr>
                                        <td width="150"><img src='<%#Eval("picture")%>' height="100" width="100" class='imgborder' group="pageimg" pageid='<%#Eval("Id")%>' /></td>
                                        <td width="10" >&nbsp;</td>
                                       </tr>
                                      <tr height="30">
                                        <td><input type="checkbox" id="chkPage" runat="server" pageid='<%#Eval("Id")%>' group="page" onchange="Checked(this);" />
                                          &nbsp;<%#Eval("name")%>
                                          <input type="hidden" id="hdnPageId" runat="server" value='<%#Eval("Id")%>' />
                                          <input type="hidden" id="hdnAccessToken" runat="server" value='<%#Eval("access_token")%>' />
                                          <input type="hidden" id="hdnPageName" runat="server" value='<%#Eval("name")%>' />
                                        </td>
                                        <td >&nbsp;</td>
                                      </tr>
                                    </table>
                                  </itemtemplate>
                                </asp:DataList>--%>
                                </asp:PlaceHolder>
                                <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                               <strong style="color:#990066">  You have no fan page.</strong><br /><br /> <a href="javascript:CreatePage();">Click here</a> to create fan page. 
                                </asp:PlaceHolder> 
                               </div></td>
                            </tr>
                             <tr>
                              <td height="10"></td>
                            </tr>
                            <tr>
                              <td><input type="submit" id="btnCreate" runat="server" value="Create" onclick="return SelectedPages();" /></td>
                            </tr>
                          </table>
                         </asp:PlaceHolder>
                         <asp:PlaceHolder id="plcEditTab" runat="server" Visible="false">
                         <strong style="color:#990066"> Your custom tab created successfully. </strong><br /><br />
                          <a id="lnkEditTab" runat="server" target="_blank" href="javascript:;"><strong>Click here</strong></a> to view your fan page.
                         </asp:PlaceHolder>
                          </td>
                      </tr>
                    </table>
              </table></td>
          </tr>
        </table></td>
    </tr>
  </table>
  </td>
  </tr>
  </table>
        </div></div><uc2:inner ID="inner2" runat="server" />
</form>
</body>
</html>
<script type="text/javascript" language="javascript">
	function SelectedPages()
	{
		var count=0;
		$('input[group^=page]').each(
			function(){
				if($(this).attr("checked")=="checked")
				{
					count=count+1;
				}
			}
		);
		if(count==0)
		{
			alert("Please select fan page!")
			$("#divPages").slideDown("slow");	
			return false;
		} 
		else
		{
			return true;
		}
	}
	function Checked(_this)
	{
		
		if($(_this).attr("checked")=="checked") 
		{
			$('input[group^=page]').each(
				function(){
					$(this).attr("checked",false)
				}
			);
			$(_this).attr("checked",true);
			$('img[group^=pageimg]').each(
				function(){
					$(this).removeClass("imgborderSelected");
					$(this).addClass("imgborder");
				}
			);
			$('img[group^=pageimg]').each(
				function(){
					if($(this).attr("pageid")==$(_this).attr("pageid"))
					{
						$(this).removeClass("imgborder");
						$(this).addClass("imgborderSelected");
					}
					
				}
			);
			

		}
		else
		{
			$('input[group^=page]').each(
				function(){
					$(this).attr("checked",false)
				}
			);
			$('img[group^=pageimg]').each(
				function(){
					$(this).removeClass("imgborderSelected");
					$(this).addClass("imgborder");
				}
			);
		}
		
	}
	function ShowHideDiv()
	{
		
		if($("#divPages").css("display")=='none')
		{
			$("#divPages").slideDown("slow");	
		}
		else
		{
			$("#divPages").slideUp("slow");	
		}
		
		
	}
	function CreatePage() {
     window.open("https://www.facebook.com/pages/create.php?", "Page", "left=20,top=20,menubar=0,resizable=0,width=1000,height=850");
	}
</script>
