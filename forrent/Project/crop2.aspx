<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="crop2.aspx.vb" Inherits="tsma.crop2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Resizer - Total Social Media System</title>
    

    
<script type="text/javascript" src="Content/js/jrac/jquery-1.7.1.js"></script>
    <!-- jQuery-Ui -->
    <link rel="stylesheet" type="text/css" href="Content/js/jrac/jquery-ui.css" />
    <script type="text/javascript" src="Content/js/jrac/jquery-ui.js"></script>
    <!-- jrac - jQuery Resize And Crop -->
    <link rel="stylesheet" type="text/css" href="Content/js/jrac/style.jrac.css" />
    <link href="<%=ResolveUrl("content/facebox/facebox.css")%>" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Content/js/jrac/jquery.jrac.js"></script>
    <!-- This page business -->
    <link rel="stylesheet" type="text/css" href="Content/css/style_jrac.css" />
    <script type="text/javascript">
      <!--//--><![CDATA[//><!--
	     $(document).ready(function() {
            // Apply jrac on some image.
            $('.pane img').jrac({
                'crop_width': 250,
                'crop_height': 170,
                'crop_x': 100,
                'crop_y': 100,
                'viewport_onload': function() {
                    var $viewport = this;
                    var inputs = $viewport.$container.parent('.pane').find('.coords input:text');
                    var events = ['crop_x', 'crop_y', 'crop_width', 'crop_height', 'image_width', 'image_height'];
                    for (var i = 0; i < events.length; i++) {
                        var event_name = events[i];
                        // Register an event with an element.
                        $viewport.observator.register(event_name, inputs.eq(i));
                        // Attach a handler to that event for the element.
                        inputs.eq(i).bind(event_name, function(event, $viewport, value) {
                            $(this).val(value);
                        })
                        // Attach a handler for the built-in jQuery change event, handler
                        // which read user input and apply it to relevent viewport object.
	
              .change(event_name, function(event) {
                  var event_name = event.data;
                  $viewport.$image.scale_proportion_locked = $viewport.$container.parent('.pane').find('.coords input:checkbox').is(':checked');
                  //alert($(this).val());
                  $viewport.observator.set_property(event_name, $(this).val());
              });
                    }
                    $viewport.$container.append('<div style="padding-top:10px;" align="center"><b>Slide to Resize</b><br>Original Size:'
              + $viewport.$image.originalWidth + ' x '
              + $viewport.$image.originalHeight + '<br><div id="tmpD"></div></div>')
                }
            })
            // React on all viewport events.
        .bind('viewport_events', function(event, $viewport) {

			var inputs = $(this).parents('.pane').find('.coords input');
            inputs.css('background-color', ($viewport.observator.crop_consistent()) ? 'chartreuse' : 'salmon');
        });	
        });
    //--><!]]>
    </script>
    <script type="text/javascript">
	function CheckPhoto()
	{
		if($('#flImage').val()=='')
		{
			alert("Please Upload Image");
			return false;
		}
		/*else
		{
			$('#DivCropArea').show();
			return true;
		}*/
	}
	function ShowCropDiv()
	{
		$('#divCropImage').show();
	}
	
	</script>
</head>
<body>
    <form id="form1" runat="server">
   <!-- <asp:ScriptManager ID="objScriptMang" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="uplMain" runat="server">
    <ContentTemplate>-->
         <table border="0" align="left" cellpadding="0" cellspacing="0" style="padding-left:20px;">
                  	<tr>
                  	  <td align="left" valign="top">&nbsp;</td>
                  	  <td align="left" height="30"><asp:Literal ID="lblMessage" runat="server" Visible="false"></asp:Literal></td>
       	   </tr>
                  	<tr>
                  	  <td width="32" align="left" valign="top"><img src="Content/images/step_1crop.png" width="24" height="24" /></td>
                    	<td align="left" height="30" style="padding-bottom:20px;">Please select image from your computer to edit image : <input type="file" id="flImage" runat="server"/>  &nbsp; &nbsp; &nbsp;<br/>                        </td>
                    </tr>
                    <tr>
                      <td align="left" valign="top" style="padding-bottom:20px;"><img src="Content/images/step_2crop.png" width="24" height="24" /></td>
                      <td align="left" style="padding-bottom:20px;">Click on Upload button to load this image <input type="button" id="btnUpload" runat="server" value="upload" onclick="CheckPhoto();" class="bluetablink"/></td>
                    </tr>
                    <tr>
                      <td align="left" valign="top" style="padding-bottom:20px;"><img src="Content/images/step_3crop.png" width="24" height="24" /></td>
                    	<td align="left" style="padding-bottom:20px;"> Expand or contract Yellow box to select image you wish to crop<br/>
                        	<div class="pane clearfix" id="divCropArea" style="text-align:center; display:" align="center">
                            <br />
                              <img id="imgPhoto" runat="server" src=""/>
                              <table class="coords" style="display:none;">
                                <tr><td>crop x</td><td><input type="text" id="txtCropX" runat="server" /></td></tr>
                                <tr><td>crop y</td><td><input type="text" id="txtCropY" runat="server"/></td></tr>
                                <tr><td>crop width</td><td><input type="text" id="txtCropW" runat="server"/></td></tr>
                                <tr><td>crop height</td><td><input type="text" id="txtCropH" runat="server"/></td></tr>
                                <tr><td>image width</td><td><input type="text" id="txtImageW" runat="server"/></td></tr>
                                <tr><td>image height</td><td><input type="text" id="txtImageH" runat="server"/></td></tr>
                                <tr><td>lock proportion</td><td><input type="checkbox" checked="checked" /></td></tr>
                              </table>
                            </div>                      </td>
                    </tr>
                    <tr>
                      <td align="left" valign="top"><img src="Content/images/step_4crop.png" width="24" height="24" /></td>
                    	<td align="left" height="50">To crop the selected area (yellow box) of the image click <input type="submit" runat="server" id="btnCropImage" value="Crop Selected" onclick="ShowCropDiv();" class="bluetablink"/>
                    	<br />OR<br />
						You can resize the image and Save <input type="submit" runat="server" id="btnCropResize" value="Save Resized Image" class="bluetablink"/>                      </td>
                    </tr>
                    <tr>
                      <td align="left" valign="top" style="padding-top:10px;">&nbsp;</td>
                    	<td align="left" valign="top" style="padding-top:10px;">
                        
							<!--<div id="divCropImage" style="display:; width:100%; height:100%">
                                <div align="left" style="float:left">
                                <input type="hidden" id="hdnX" runat="server" />
                                <input type="hidden" id="hdnY" runat="server" />
                                <input type="hidden" id="hdnCropX" runat="server" />
                                <input type="hidden" id="hdnCropY" runat="server" />
                                <input type="hidden" id="hdnImageW" runat="server" />
                                <input type="hidden" id="hdnImageH" runat="server" />-->
                                <img id="imgfinalCropImage"  runat="Server" border="0"/>
                              <!--  </div>
                                <div align="left" style="float:left; padding-top:20px;">
                                
                                </div>
                            </div>-->                        </td>
                    </tr>
                    <tr>
                      <td align="left" valign="top" ><img src="Content/images/step_5crop.png" width="24" height="24" /></td>
                    	<td align="left"  valign="top">Download and save this image on your local computer. 
                         <a id="lnkDownload" runat="server" class="bluetablink">Download Image</a><br/><br/>
                         
                         Please use this image to upload to sidebar/custom tab designs whereever you want to.                      </td>
                    </tr>
                    </table>
<!--           </ContentTemplate>
        </asp:UpdatePanel>-->
                   </form>
                   
			   
  <%-- </ContentTemplate>
   </asp:UpdatePanel>--%>

</body>
</html>
