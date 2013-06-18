<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="generate-cover-image.aspx.vb" Inherits="tsma.generate_cover_image" %>

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
    <script type="text/javascript">
        function GetWidthHeight() {
            var strw = document.getElementById("divWidthHeight").style.width;
            document.getElementById("hdnWidth").value = strw;
            var strh = document.getElementById("divWidthHeight").style.height;
            document.getElementById("hdnHeight").value = strh;
            //return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="divCoverPhotoHtml" runat="server">
    </div>
    <input type="hidden" id="hdnWidth" runat="server"/>
    <input type="hidden" id="hdnHeight" runat="server" />
   </form>
</body>
</html>
