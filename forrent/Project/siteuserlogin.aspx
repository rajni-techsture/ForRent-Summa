<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="siteuserlogin.aspx.vb" Inherits="tsma.siteuserlogin" %>
<%@ Register Src="~/header.ascx" TagName="Header1" TagPrefix="uc1" %>
<%@ Register src="~/footer.ascx" tagname="Footer1" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Total Social Media Application</title>
	 <script language="JavaScript" type="text/javascript">
    <!-- Cookie script - Scott Andrew -->
    <!-- Popup script, Copyright 2005, Sandeep Gangadharan --> 
    <!-- For more free scripts go to http://www.sivamdesign.com/scripts/ -->
    <!--
    function newCookie(name,value,days) {
     var days = 1;   // the number at the left reflects the number of days for the cookie to last
                     // modify it according to your needs
     if (days) {
       var date = new Date();
       date.setTime(date.getTime()+(days*24*60*60*1000));
       var expires = "; expires="+date.toGMTString(); }
       else var expires = "";
       document.cookie = name+"="+value+expires+"; path=/"; }
    
    function readCookie(name) {
    
       var nameSG = name + "=";
       var nuller = '';
      if (document.cookie.indexOf(nameSG) == -1)
        return nuller;
    
       var ca = document.cookie.split(';');
      for(var i=0; i<ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0)==' ') c = c.substring(1,c.length);
      if (c.indexOf(nameSG) == 0) return c.substring(nameSG.length,c.length); }
        return null; }
    
    function eraseCookie(name) {
      newCookie(name,"",1); }
    
    function toMem(a) {
        newCookie('UserName', document.form1.txtUid.value);     // add a new cookie as shown at left for every
        newCookie('Password', document.form1.txtPwd.value);   // field you wish to have the script remember
    }
    
    function delMem(a) {
      eraseCookie('UserName');   // make sure to add the eraseCookie function for every field
      eraseCookie('Password');
    
       document.form1.txtUid.value = '';   // add a line for every field
       document.form1.txtPwd.value = ''; }
    //-->
    </script>

   <script type="text/javascript" language="javascript">
   function ForgotPwdValidation()
      {   
	    	var fields= "";
        	
	    var re = new RegExp();
        re = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        var sinput;
        sinput = "";
		
        if (DoTrim(document.getElementById('txtForget').value).length == 0) {
		
            fields = fields + "\n-- Email Address --";
			
        }
        else {
            sinput = DoTrim(document.getElementById('txtForget').value);
            if (!re.test(sinput)) {
                fields = fields + "\n-- Invalid Email Address --";
                document.getElementById('txtForget').value == "";
            }
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
	   function OpenDiv() {
         //alert("test");
	       $('#divForgotPwd').dialog({ autoOpen: false, bgiframe: true, modal: true });
	       $('#divForgotPwd').dialog('open');
	       $('#divForgotPwd').parent().appendTo($("form:first"));
      }
	   function readCookie(name) {
           var nameEQ = name + "=";
           var ca = document.cookie.split(';');
           for (var i = 0; i < ca.length; i++) {
               var c = ca[i];
               while (c.charAt(0) == ' ') c = c.substring(1, c.length);
               if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
           }
           return null;
       }
	   function ValidatePass() {
	       if ($('#txtForget').val() == '') {
	           $('#txtForget').removeClass('input');
	           $('#txtForget').addClass('input-validation-error');
	           $('#spnForget').html('*');
	       }
	       else {
            $('#txtUid').removeClass('input-validation-error');
            $('#txtUid').addClass('input');
            $('#spnUid').html('');
	       }
    }
    function DoTrim(strComp) {
        ltrim = /^\s+/
        rtrim = /\s+$/
        strComp = strComp.replace(ltrim, '');
        strComp = strComp.replace(rtrim, '');
        return strComp;
    }

    function validatelogin() {
                    var fields = "";
            if (DoTrim(document.getElementById('txtUid').value).length == 0) {
                fields = fields + "\n-- UserName --";
            }
            if (DoTrim(document.getElementById('txtPwd').value).length == 0) {
                fields = fields + "\n-- Password --";
            }

            if (fields != "") {
                fields = "Please fill in the following details\n--------------------------------------\n" + fields;
                alert(fields);
                return false;
            }
            else {
                return true;
            }
    }
    function SiteUserLogin12() {
        var count = 0;
        $('#spnEror').html('');
        if ($('#txtUid').val() == '') {
            $('#txtUid').removeClass('input');
            $('#txtUid').addClass('input-validation-error');
            $('#spnUid').html('*');
           count = count + 1;
        }
        else {
            $('#txtUid').removeClass('input-validation-error');
            $('#txtUid').addClass('input');
            $('#spnUid').html('');
        }
        if ($('#txtPwd').val() == '') {
            $('#txtPwd').removeClass('input');
            $('#txtPwd').addClass('input-validation-error');
            $('#spnPwd').html('*');
            count = count + 1;
        }
        else {
            $('#txtPwd').removeClass('input-validation-error');
            $('#txtPwd').addClass('input');
            $('#spnPwd').html('');
        }
        if (count == 0) {
            return true;
        }
        else {
            return false;
        }
    }
    function ChangeLoginFocus(eve) {
        var code = eve.keyCode || eve.which;
        if (code == 13) {
            $('#imgLogin').click();
        }
    }
    function test() {
        alert(readCookie('test'));
    }
</script>

</head>
<body>
    <form id="form1" runat="server"  name="form1" action=" " method="post" onSubmit="if(this.checker.checked) toMem(this)">
   <uc1:Header1 ID="header1" runat="server" />
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td align="left" valign="top" class="mainbg"><table width="974" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td class="bannerborder">
 <div id="divBackGround1" style="padding-top:150px; z-index:1" align="center">
<div style="background-image:url(Content/images/site_user_login_bg.png); background-position:top; background-repeat:no-repeat; width:392px; height:229px; z-index:1000000 ">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td height="35" align="left" valign="bottom" class="arial16white" style="padding-left:15px"><strong>Site User Login</strong></td>
  </tr>
  <tr>
    <td >
    
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
 
  <tr>
       <td height="25" colspan="2" align="center" valign="bottom" style="padding-left:10px;"><span style="color:#fe9d00; font-weight:bold; font-size:12px;" id="spnEror" runat="server"></span></td>
  </tr>
  <tr>
    <td width="161" height="30" align="right" valign="middle"><font color="#FFFFFF">User Name or Email:
    </font>&nbsp;</td>
    <td width="231" align="left" valign="middle"><input name="txtUid" type="text" id="txtUid" runat="server" class="input" onKeyDown="ChangeLoginFocus(event)" style="height:21px" />&nbsp;<span style="color:#e80c4d; font-weight:bold;" id="spnUid"></span></td>
  </tr>
  <tr>
    <td  height="30" align="right" valign="middle"><font color="#FFFFFF">Password:</font>&nbsp;</td>
    <td align="left" valign="middle"><input name="txtPwd" type="password" id="txtPwd" runat="server" class="input" onKeyDown="ChangeLoginFocus(event)" style="height:21px" />&nbsp;<span style="color:#e80c4d; font-weight:bold;" id="spnPwd"></span></td>
  </tr>
  <tr>
    <td  height="32" align="right" valign="middle"><font color="#FFFFFF">Security Code:</font>&nbsp;</td>
    <td height="35" align="left" valign="middle"><input  name="txtcode1"  type="text"  id="txtcode1" size="5" maxlength="6" runat="server"  style="height:19px" >
									<IMG name="imgcode1" width="91" Border="1" height="29"  align=absmiddle id="imgcode1" runat="server" >
									<input class="input" id="hdncode1" type="hidden" runat="server" width="" NAME="hdncode1" /></td>
  </tr>
  <tr>
    <td  height="32" align="right" valign="middle"><font color="#FFFFFF">Remember Me?:</font>&nbsp;</td>
    <td height="35" align="left" valign="middle">
    	<input type="checkbox" id="checker" name="checker"  runat="server" />
    </td>
  </tr>
  <tr>
    <td  height="32" valign="middle"></td>
    <td height="35" align="left" valign="middle">
    <input  type="image" name="imglogin" runat="server" onClick="return validatelogin();" id="imgLogin" src="Content/images/login.png" alt="Login" >
    </td>
  </tr>
  <tr>
    <td ></td>
    <td align="left" valign="middle"><a href="javascript:;" style="color:White" onclick="OpenDiv();">Forgot Password?</a></td>
  </tr>
</table>
<div id="divForgotPwd" title="Recover Your Password" style="display:none">
<asp:Panel ID="pnlForgotPwd" runat="server">
<table border="0">
       <tr>
        <td align="left" height="40" colspan="2" style="text-align:left; font-size:12px; color:Gray">
        Please insert your UserName here. your password will send to your email address.
        </td>
       </tr>
       <tr>
        <td align="right" height="30" width="100" valign="middle" style="width:50px;"><strong>UserName:  </strong> 
        </td>
        <td align="left" height="30" valign="middle">
        <input type="text" runat="server" valign="top" name="txtForget" id="txtForget" Class="input" style=" height:20px;"/>&nbsp;<span style="color:#e80c4d; font-weight:bold;" id="spnForget"></span>
        </td>
       </tr>
       <tr>
        <td colspan="2" align="center">
           <asp:ImageButton ID="imgPassword"  runat="server" ImageUrl="../../content/images/submit.png" OnClientClick="return ForgotPwdValidation();" />
        </td>
       </tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlmsg" runat="server">
<table>
    <tr>
        <td align="left" height="40" colspan="2" style="text-align:left; font-size:12px; color:Gray">
        We Will Send Your Password Soon.
        </td>
    </tr>
</table>
</asp:Panel>
</div>
    </td>
  </tr>
  <tr>
    <td >&nbsp;</td>
  </tr>
 
</table>

</div>

</div>

        </td>
          </tr>
        </table></td>
    </tr>
  </table>
    
   <uc2:Footer1 ID="footer11" runat="server" />
    <script type="text/javascript" language="javascript">
		<!--
		document.form1.txtUid.value = readCookie("UserName");  // Change the names of the fields at right to match the ones in your form.
		document.form1.txtPwd.value = readCookie("Password");
		//-->
		</script>
    </form>
</body>
</html>
