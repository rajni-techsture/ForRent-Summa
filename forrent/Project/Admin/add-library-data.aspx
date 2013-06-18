<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="add-library-data.aspx.vb" Inherits="tsma.add_library_data" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fck" %>
<html>
<head>
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
    function ValidateDataDetails() {
        var fields
        fields = "";
        if (document.frm.drpType.value== 0){
            fields += "\n-- Select Type --";
        }
        if (document.frm.drpCompInd.value == 0) {
            fields += "\n-- Select Company/Industry --";
        }
        if (document.frm.drpCategory.value == 0) {
            fields += "\n-- Select Category --";
        }
       
        if (DoTrim(document.frm.txtDescription1.value).length == 0) {
            fields += "\n-- Description --";
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
    function reset() {

        document.frm.txtCategoryName.value = ""

    }
    function SelectType(objlb) {
        if (objlb.value == "1") {
            document.getElementById("trcomp").style.display = "";
            document.getElementById("trind").style.display = "none";
            document.getElementById("trind").value = "0"
             document.getElementById("drpIndustry").value = "0"
          

        }
        else if (objlb.value == "2") {
            document.getElementById("trind").style.display = "";
            document.getElementById("trcomp").style.display = "none";
            document.getElementById("trcomp").value = "0"
            document.getElementById("drpCompany").value = "0"
          
           
        }

    }
  
		//-->
		</script>
</head>
<body>
<form id="frm" name="frm" runat="server">
<asp:ScriptManager ID="objScriptManager" runat="server">
    </asp:ScriptManager>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" align="center">
 <tr>
    <td height="10" valign="top"><uc1:header ID="Header1" runat="server" /></td>
  </tr>
  <tr>
   <td align="left" valign="top" bgcolor="#DAE0F3" style="background-repeat:repeat-x;">
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="165" align="left" valign="top" style="padding:9px; "><uc2:left ID="Left1" runat="server" /></td>
        <td align="left" valign="top" style="padding:9px; padding-left:0px; padding-bottom:0px "><table width="100%" height="100%"  border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td align="left" valign="top" bgcolor="#FFFFFF" class="imgborder" style="padding:16px ">
			
			  <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr valign="middle" align="center" bgcolor="#ffffff">
                  <td bgcolor="#ffffff"></td>
                </tr>
                <tr>
                  <td height="25" valign="middle" class="title"><%if request("LDId")=""%>Add New<%else%> Edit<%end if%> Library</td>
				    <td height="25" valign="middle" align="right">
					<div style="margin-right:0px;width:74px;height:24px;overflow:hidden">
					<asp:UpdateProgress ID="objUpdateProgress" runat="Server" DisplayAfter="0">
					<ProgressTemplate>
						<img src="../Content/adminimages/popuploading.png" style="border:0px;font-family:Tahoma;font-size:12px;" alt="Loading" />
					</ProgressTemplate>
					</asp:UpdateProgress>
					</div>
					</td>
				</tr>
				<tr>
                	<td align="center" colspan="2" style="color:red;font-weight:bold;padding:5px;"><asp:Literal id="ltrMsg" runat="server"></asp:Literal></td>
              	</tr>
				<tr>
					<td height="25" colspan="2" align="right" valign="top"><a href="manage-library-data.aspx"><b>[ Manage Library ] </b></a></td>
				</tr>
                <tr>
                  <td align="center" colspan="2" class="tdborder">
				  <table width="100%" border="0" cellpadding="2" cellspacing="1">
                  <tr><td>
                                              <asp:UpdatePanel ID="pnlMain" runat="server"><ContentTemplate> 
                                              <table width="100% " border="0" cellpadding="2" cellspacing="1">
                                             <tr style="display:none;">
                                                <td width="20%" height="25" align="right" >Select Type:</td>
                                                <td height="25" align="left" valign="middle">
                                                <input type="hidden" id="hdnIsCompInd" runat="server" />
                                                <input type="radio" id="rdoComp" checked runat="Server" name="CompInd" value="1" onChange="SelectType(this);" />
													Company &nbsp;&nbsp;
													<input type="radio" id="rdoInd" runat="Server" name="CompInd" value="2" onChange="SelectType(this);" />
													Industry
                                                
                                               </td>
                                              </tr>
                                              <tr>
                                                <td width="20%" height="25" align="right" >Select Type:</td>
                                                <td height="25" align="left" valign="middle">
                                                 <asp:DropDownList id="drpType" runat="server" class="input" AutoPostBack="true"
                                                OnSelectedIndexChanged="drpType_SelectedIndexChanged"></asp:DropDownList>
                                                <font color="#ff0000">*</font>
                                                </td>
                                              </tr>
                                               <tr>
                                                <td width="20%" height="25" align="right" >Select Comp/Ind:</td>
                                                <td height="25" align="left" valign="middle">
                                                 <asp:DropDownList id="drpCompInd" runat="server" class="input" AutoPostBack="true"
                                                OnSelectedIndexChanged="drpCompInd_SelectedIndexChanged"></asp:DropDownList>
                                                <font color="#ff0000">*</font>
                                                </td>
                                              </tr>
                                              <tr id="trcomp" runat="server" style="display:none;">
                                                <td width="20%" height="25" align="right" >Company:&nbsp;</td>
                                                <td height="25" align="left" valign="middle">
                                                <asp:DropDownList id="drpCompany" runat="server" class="input" AutoPostBack="true"
                                                OnSelectedIndexChanged="drpCompany_SelectedIndexChanged"></asp:DropDownList>
                                                <font color="#ff0000">*</font>
                                               </td>
                                              </tr>
                                               <tr id="trind" runat="server" style="display:none;">
                                                <td width="20%" height="25" align="right" >Industry:&nbsp;</td>
                                                <td height="25" align="left" valign="middle">
                                                <asp:DropDownList id="drpIndustry" runat="server" class="input" AutoPostBack="true"
                                                OnSelectedIndexChanged="drpIndustry_SelectedIndexChanged"></asp:DropDownList>
                                                <font color="#ff0000">*</font>
                                               </td>
                                              </tr>
                                              <tr id="trcat" runat="server" >
                                                <td width="20%" height="25" align="right" >Library Category:&nbsp;</td>
                                                <td height="25" align="left" valign="middle">
                                                 <asp:DropDownList id="drpCategory" runat="server" class="input"></asp:DropDownList>
                                                 <font color="#ff0000">*</font>
                                               </td>
                                              </tr>
                                        </table>
                                        </ContentTemplate></asp:UpdatePanel>
                                        </td></tr>
                                        <tr><td>
                                        <table width="100%" border="0" cellpadding="2" cellspacing="1">
                                              <tr>
                                                <td width="20%" height="25" align="right">Description:&nbsp;</td>
                                                <td height="25" align="left"> 
                                                <textarea id="txtDescription1" runat="server" style="height:150px; width:400px" class="input"></textarea>
                                                
                                               <font color="#ff0000">*</font></td>
                                              </tr>
                                              <tr >
                                                <td height="25" align="right" valign="top" >Video URL:&nbsp;</td>
                                                <td height="25" align="left"><input name="txtvideo" runat="server" type="text" class="input" id="txtvideo" size="65" onChange="CheckVideo();"/><font color="#ff0000">*</font><br />
                                                 (e.g: www.youtube.com/watch?v=yoGYjtCo350)<br/>
                                                    <img src="../Content/images/no_video.jpg" runat="server" id="imgThumbnail" width="100" style="border:2px dotted #ff0000;" height="100" />
                                                    <input type="hidden" id="hdnUrl" runat="server" value="" />
                                                    <input type="hidden" id="hdnVideoId" runat="server" value="" />
                                                </td>
                                              </tr>
                                               <tr >
                                                <td height="25" align="right" valign="top" style="padding-top:10px;">Upload Photo:&nbsp;</td>
                                                <td height="25" align="left"><input type="file" id="photo" runat="server" onChange="readURL(this);"><span class="SmallText">(jpg, jpeg, bmp, gif files only)</span>&nbsp;<br/>
                                                 <asp:Label id="lblPhoto" runat="server"></asp:Label>
							                    <input type="hidden" ID="hdnimagevalue" runat="server" />
							                    <input type="hidden" id="hdnImage" runat="server" />
                                               </td>
                                              </tr>
                                              <tr>
                                                <td width="10%" height="25" align="right" >Preview Image:&nbsp;</td>
                                                <td height="25" align="left">
                                                <img src="../Content/images/no_img.jpg" runat="server" id="imgPhoto" width="100" style="border:2px dotted #ff0000;" height="100" />
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
												<input runat="server" type="submit" class="AdminFormButton" id="btnSave" value="Save" onClick="return ValidateDataDetails();" />&nbsp;
												<input type="reset" class="AdminFormButton" value="Reset" id="reset" onClick="return reset();" />
												</td>
                                              </tr>
                                          </table>
                                    </td></tr>
                                  </table>
                  </td>
                </tr>
              </table>
			
			  </td>
            </tr>
        </table></td>
      </tr>
      <tr align="center" valign="middle">
        <td colspan="2" valign="top" height="25"><uc3:footer ID="Footer1" runat="server" /></td>
        </tr>
    </table>
    </td>
  </tr>
  </table>
</form>

</body>
</html>

