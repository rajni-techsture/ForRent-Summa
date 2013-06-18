<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="custom-tab-templates.aspx.vb" Inherits="tsma.custom_tab_templates" %>
<%@ Register src="left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="inner-header.ascx" tagname="inner1" tagprefix="uc1" %>
<%@ Register src="inner-footer.ascx" tagname="inner" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Feature Social System</title>
<script src="<%=ResolveUrl("~/Scripts/jquery-1.6.2.min.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    function ShowHidePaging(obj) {
        if (obj == 'show') {
            $("#trPaging").hide("slow");
            $("#trNoPaging").show("slow");
        }
        if (obj == 'hide') {
            $("#trNoPaging").hide("slow");
            $("#trPaging").show("slow");
        }
    }
    function ShowSidebar(Id) {
        $("#sidebar").hide("slow");
        $("#sidebar-selection").show("slow");
        var userId = document.getElementById("hdnUserId").value;
        var FbuserId = document.getElementById("hdnFBUserId").value;
        var CompanyId = document.getElementById("hdnCompanyId").value;
        var IndustryId = document.getElementById("hdnIndustryId").value;
        document.getElementById("Iframe1").src = "sidebar_selection.aspx?sdId=" + Id + "&userId=" + userId + "&FbuserId=" + FbuserId + "&CId=" + CompanyId + "&IId=" + IndustryId;
    }
</script>
</head>
<body>
<form id="frm" runat="server">
  <asp:ScriptManager ID="objScriptManager" runat="server"></asp:ScriptManager>
  <div id="innerpagepagemain">
    <uc1:inner1 ID="inner1" runat="server" />
    <div id="centermain">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td align="left" valign="top" ><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="172" align="left" valign="top" class="leftbg"><uc3:left ID="left1" runat="server" />
                            </td>
                            <td align="left" valign="top" class="contentbody">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" id="sidebar">
                            	<tr>
                                	<td align="center" valign="middle">
                                    <div style="font-family: Tahoma, Geneva, sans-serifthaoma; font-size: 16px; color: #181818; margin:0px;	font-weight:bold;
	line-height:18px; text-align:center">Click on image to choose your desired custom tab </div><br />
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold=true Font-Size="Larger"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                  <td height="32" align="right" valign="middle" style="padding-bottom:5px;"><a href="javascript:;" onclick="ShowHidePaging('show');" class="bluetablink">View All</a>&nbsp;&nbsp;<a href="javascript:;" onclick="ShowHidePaging('hide');" class="bluetablink">View By Page</a ></td>
                                </tr>
                                <tr>
                                  <td valign="top" ><div id="divLoading" align="center" style="position:absolute; padding-top:200px; padding-left:300px;">
                                      <asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0">
                                        <ProgressTemplate> <img src="Content/images/popuploading.png" style="border:0px;font-family:Tahoma;font-size:12px;" title="Loading" /> </ProgressTemplate>
                                      </asp:UpdateProgress>
                                    </div>
                                   <%-- <asp:UpdatePanel ID="pnlMain" runat="server">
                                      <ContentTemplate>--%>
                                        <table cellpadding="0" id="trPaging" cellspacing="0" border="0" width="100%">
                                          <tr>
                                            <td align="right" valign="middle" height="32px" style="font-family:Tahoma, Geneva, sans-serif; font-size:11px; background-color:#edeff4"><strong>
                                              <asp:PlaceHolder ID="phPaging" runat="server"></asp:PlaceHolder>
                                              </strong> </td>
                                          </tr>
                                          <tr>
                                            <td align="center" style="border:1px solid #ced5e5; padding-top:29px; padding-bottom:29px;"><asp:DataList ID="rptPaging" runat="server" RepeatColumns="3" RepeatDirection="Vertical">
                                                <ItemTemplate>
                                                  <table align="center">
                                                    <tr>
                                                      <td><a id="lnkSidebar" href="javascript:;" onclick='ShowSidebar(<%#Container.DataItem("sdm_Id") %>)'><img  alt="" src='Content/images/<%#Container.DataItem("sdm_Image") %>' border="0"/></a>
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
                                              <asp:PlaceHolder ID="phPaging1" runat="server"  ></asp:PlaceHolder>
                                              </strong></td>
                                          </tr>
                                        </table>
                                      </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <table id="trNoPaging" width="100%" style="display:none;" align="center" border="0" cellpadding="0" cellspacing="0">
                                          <tr>
                                            <td align="right" style="border:1px solid #ced5e5; padding-top:29px; padding-bottom:29px; padding-right:20px;"><asp:DataList ID="rptNoPaging" runat="server" RepeatColumns="3" RepeatDirection="Vertical">
                                                <ItemTemplate>
                                                  <table align="center">
                                                    <tr>
                                                      <td style="padding-bottom:20px;">
                                                      <a id="lnkSidebar1" href="javascript:;" onclick='ShowSidebar(<%#Container.DataItem("sdm_Id") %>)'><img  alt="" src='Content/images/<%#Container.DataItem("sdm_Image") %>' border="0"/></a>
                                                      <%--<a id="lnkSidebar" href="sidebar_selection.aspx?sdId=<%#Container.DataItem("sdm_Id") %>&userId=<%#Container.DataItem("sdm_UserId")%>&FbuserId=&CId=<%#Container.DataItem("sdm_CompanyId")%>&IId=<%#Container.DataItem("sdm_IndustryId")%>"><img  alt="" src='Content/images/<%#Container.DataItem("sdm_Image") %>'/></a>--%> </td>
                                                      <td align="left" width="30" style="padding-bottom:20px;">&nbsp;</td>
                                                    </tr>
                                                  </table>
                                                </ItemTemplate>
                                              </asp:DataList>
                                            </td>
                                          </tr>
                                        </table>
                                  </td>
                                </tr>
                              </table>
                              <table id="sidebar-selection" style="display:none" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left">
                                        <iframe id="Iframe1" name="Iframe1" runat="server" width="750" height="800" marginwidth="0" marginheight="0" frameborder="0" vspace="0" hspace="0" scrolling="no"></iframe> 
                                    </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table></td>
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

