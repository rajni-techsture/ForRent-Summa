<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="add-weekly-tip.aspx.vb" Inherits="tsma.add_weekly_tip" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fck" %>
<html>
<link id="lnkInnerTheme" href="../Content/css/apartment-style.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" href="../Content/css/jquery.ui.timepicker.css?v=0.2.9" type="text/css" media="all" />
    <link rel="stylesheet" href="../Content/css/jquery-ui-1.8.14.custom.css" type="text/css" />
    <script src="../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../Content/js/jquery.ui.timepicker.js?v=0.2.9" type="text/javascript"></script>
    <script src="Content/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Content/js/jquery.bgiframe-2.1.2.js" type="text/javascript"></script> 
    <script src="../Content/js/pagejs/scheduler.js" type="text/javascript"></script>
<head id="Head1" runat="server">
<script type="text/javascript">

   $(document).ready(function() {
                         $("#txtBirthDate").datepicker(
							{ minYear: 1900, maxDate: null, 
                                changeMonth: true,
							    changeYear: true, 
							}
						);
                        })	
                        function OpenCal(Id) {
                        document.getElementById(Id).focus();
                    }
</script>
<title>Forrent.Com</title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
<link href="../Content/css/admin-style.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript">
		<!--
    var reader = new FileReader();
    reader.onload = function (e) {
        document.getElementById('imgPhoto').src = e.target.result;

    };
    function readURL(input) {

        if (input.files && input.files[0]) {
            reader.readAsDataURL(input.files[0]);
            document.getElementById('hdnimagevalue').value = input.value;
            // alert(document.getElementById('hdnimagevalue').value);
        }
        else {
            document.getElementById('imgPhoto').src = input.value || "No file selected";

        }
    }

    function CheckVideo() {
        var obj = document.getElementById('txtvideo');
        if (obj.value != '') {
            
            var vid;
            var results;
            var url = DoTrim(obj.value).toLowerCase();
            //Youtube
            url = DoTrim(obj.value);
            results = url.match("[\\?&]v=([^&#]*)");
            if (results != null) {
                vid = results[1];
                if (vid != '') {
                    document.getElementById('imgThumbnail').src = "http://img.youtube.com/vi/" + vid + "/2.jpg";
                    document.getElementById('hdnVideoId').value = vid;
                    document.getElementById('hdnUrl').value = "http://img.youtube.com/vi/" + vid + "/2.jpg";
                    //alert(document.getElementById('hdnUrl').value);
                    //alert(document.getElementById('hdnVideoId').value);
                    return true;
                }
                else {
                    alert('Invalid Youtube URL');
                    obj.value = '';
                    return false;
                }
            }
            else {
                alert('Invalid Youtube URL');
                obj.value = '';
                document.getElementById('txtvideo').value = '';
                document.getElementById('imgThumbnail').src = '../content/images/no_img.jpg';
                document.getElementById('hdnVideoId').value = '';
                document.getElementById('hdnUrl').value = '';
                return false;
            }
        }
        else {
            obj.value = '';

            document.getElementById('txtvideo').value = '';
            document.getElementById('imgThumbnail').src = '../content/images/no_img.jpg';
            document.getElementById('hdnVideoId').value = '';
            document.getElementById('hdnUrl').value = '';
            return false;
        }
    }
    function ValidateWeeklyTip() {
        var fields
        fields = "";
        if (DoTrim(document.frm.txtTitle.value).length == 0) {
            fields = "\n-- Title --";
        }
       
        if (DoTrim(document.frm.txtvideo.value).length == 0) {
            fields += "\n-- Video URL --";
        }

       
        if (fields != "") {
            fields = "Please fill in the following details:\n--------------------------------\n" + fields;
            alert(fields);
            return false;
        }
        else {
            return true;
        }
    }
    function DoTrim(strComp) {
        ltrim = /^\s+/
        rtrim = /\s+$/
        strComp = strComp.replace(ltrim, '');
        strComp = strComp.replace(rtrim, '');
        return strComp;
    }
        
		//-->
		</script>
</head>
<body>
    
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" align="center">
<form id="frm" name="frm" runat="server">
<asp:ScriptManager ID="objScriptManager" runat="server">
    </asp:ScriptManager>
 
  <tr>
    <td height="10" valign="top">
    
        <uc1:header ID="header2" runat="server" />
    
    </td>
  </tr>
  <tr>
   <td align="left" valign="top" bgcolor="#DAE0F3" style="background-repeat:repeat-x;">
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="165" align="left" valign="top" style="padding:9px;"><uc2:left ID="Left1" runat="server" /></td>
        <td align="left" valign="top" style="padding:9px; padding-left:0px; padding-bottom:0px "><table width="100%" height="100%"  border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td align="left" valign="top" bgcolor="#FFFFFF" class="imgborder" style="padding:16px ">
			  <asp:UpdatePanel ID="pnlMain" runat="server"><ContentTemplate>
			  <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr valign="middle" align="center" bgcolor="#ffffff">
                  <td bgcolor="#ffffff"></td>
                </tr>
                <tr>
                  <td height="25" valign="middle" class="title"><%If Request("WTId") = "" Then%>Add New<%else%>Edit<%end if%> Weekly Tip</td>
				    <td height="25" valign="middle" align="right">
					<div style="margin-right:0px;width:74px;height:24px;overflow:hidden">
					<asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0">
					<ProgressTemplate>
						<img src="images/popuploading.png" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" />
					</ProgressTemplate>
					</asp:UpdateProgress>
					</div>
					</td>
				</tr>
				<tr>
                	<td align="center" colspan="2" style="color:red;font-weight:bold;padding:5px;"><asp:Literal id="ltrMsg" runat="server"></asp:Literal></td>
              	</tr>
				<tr>
					<td height="25" colspan="2" align="right" valign="top"><a href="manage-weekly-tip.aspx"><b>[ Manage Weekly Tip ] </b></a></td>
				</tr>
                <tr>
                  <td align="center" colspan="2" class="tdborder">
				  <table width="100%" border="0" cellpadding="2" cellspacing="1">
                                              <tr >
                                                <td height="25" align="right" >Name:&nbsp;</td>
                                                <td height="25" align="left"><input name="txtTitle" runat="server" type="text" class="input" id="txtTitle" size="30"
																			maxlength="25">
                                                <font color="#ff0000">*</font></td>
                                              </tr>
                                              
                                              <tr >
                                                <td height="25" align="right" valign="top">Description:&nbsp;</td>
                                                <td height="25" align="left"> <fck:FCKeditor ID="txtDescription1" runat="server" BasePath="../FCKeditor/" Height="350px" Width="625px"></fck:FCKeditor> 
                                               <font color="#ff0000">*</font></td>
                                              </tr>
                                              <tr >
                                                <td height="25" align="right" valign="top" >Video URL:&nbsp;</td>
                                                <td height="25" align="left"><input type="text" id="txtvideo" runat="server" width="620" style="width:620px; " onChange="CheckVideo();"/>
                                      &nbsp;&nbsp;
                                      <%--<a href="javascript:;" onmouseover="ShowDiv('dvHelp');" onmouseout="HideDiv('dvHelp');"><b>help?</b></a><div style="position:absolute; width:427px; padding-left:200px; display:none;" id="dvHelp">
														 <img src='<%=System.Configuration.ConfigurationManager.AppSettings("AppPath")%>content/images/youtubevideo.png' />
														 </div>
                                      <br/>--%>
                                      <br />(e.g: www.youtube.com/watch?v=yoGYjtCo350)<br/>
                                      <img src="../Content/images/no_img.jpg" runat="server" id="imgThumbnail" width="100" style="border:2px dotted #ff0000;" height="100" />
                                      <input type="hidden" id="hdnUrl" runat="server" value="" />
                                      <input type="hidden" id="hdnVideoId" runat="server" value="" />
                                      <input type="hidden" ID="hdnimagevalue" runat="server" />
							                    <input type="hidden" id="hdnImage" runat="server" />
                                        </td>
                                              </tr>
                                               <%--<tr >
                                                <td height="25" align="right">Upload Photo:&nbsp;</td>
                                                <td height="25" align="left"><input type="file" id="photo" runat="server" onchange="readURL(this);"><span class="SmallText">(jpg, jpeg, bmp, gif files only)</span>&nbsp;<br/>
                                                 <asp:Label id="lblPhoto" runat="server"></asp:Label>
							                    <input type="hidden" ID="hdnimagevalue" runat="server" />
							                    <input type="hidden" id="hdnImage" runat="server" />
                                               </td>
                                              </tr>
                                              <tr>
                                                <td width="10%" height="25" align="right" >Preview Image:&nbsp;</td>
                                                <td height="25" align="left">
                                                <img src="../content/adminimages/noimage.png" width="150" height="150"  id="imgPhoto" runat="server" />
                                                </td>
                                            </tr>--%>
                                              <tr style="display:none;" >
                                                <td height="25" align="right">Set In Home Page:&nbsp;</td>
                                                <td height="25" align="left"><input type="checkbox" id="chkHome" style="display:none;" runat="server">
                                               </td>
                                              </tr>
                                              <tr>
												  <td align="right" valign="middle">Status:</td>
												  <td ><input type="radio" id="rdoActive" checked runat="Server" name="ActiveInactive" value="1" />
													Active &nbsp;&nbsp;
													<input type="radio" id="rdoInactive" runat="Server" name="ActiveInactive" value="2" />
													Inactive </td>
												</tr>
                                               

                                              <tr >
											   <td height="25" align="right">&nbsp;</td>
                                                <td height="30" align="left" >
												<input runat="server" type="submit" class="AdminFormButton" id="btnSave" value="Save" onClick="return ValidateWeeklyTip();" />&nbsp;
												<input type="reset" class="AdminFormButton" value="Reset" id="reset" />
												</td>
                                              </tr>
                                            </table>
                  </td>
                </tr>
              </table>
			</ContentTemplate></asp:UpdatePanel>
			  </td>
            </tr>
        </table></td>
      </tr>
      <tr align="center" valign="middle">
        <td colspan="2" valign="top" height="25">
            <uc3:footer ID="footer2" runat="server" />
          </td>
        </tr>
    </table>
    </td>
  </tr>
</form>
</table>
</body>
</html>
