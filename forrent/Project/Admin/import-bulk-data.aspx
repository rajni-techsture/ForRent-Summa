<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="import-bulk-data.aspx.vb" Inherits="tsma.import_bulk_data" %>

<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forrent.Com - Import Library Data</title>
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
			<%--<asp:UpdatePanel ID="pnlMain" runat="server"><ContentTemplate> --%>
			  <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr valign="middle" align="center" bgcolor="#ffffff">
                  <td bgcolor="#ffffff"></td>
                </tr>
                
				<tr>
                	<td align="center" colspan="2" style="color:red;font-weight:bold;padding:5px;"><asp:Literal id="ltrMsg" runat="server"></asp:Literal></td>
              	</tr>
				<tr>
					<td height="25" colspan="2" align="right" valign="top"><a href="manage-library-categories.aspx"><b>[ Manage Library Categories ] </b></a></td>
				</tr>
                <tr>
                  <td align="center" colspan="2" class="tdborder">
				  	<table width="100%"  border="0" cellspacing="0" cellpadding="3">
                                      <tr id="trProductTemplate" >
                                        <td align="right" >&nbsp;</td>
                                        <td align="right" ><div style="float:right">
                                        <asp:LinkButton id="lnkLibraryCSVTemplate" runat="server">
                                        <strong>Download bulk Autopost/Sweepstake CSV Template</strong></asp:LinkButton>
                                        <asp:LinkButton id="lnkCategoryHelpCSVTemplate" runat="server"><strong>&nbsp;|&nbsp;Download Timezone Instruction</strong></asp:LinkButton>
                                        </div></td>
                                      </tr>
                                      <tr>
                                        <td width="18%" align="right" >Select CSV / XML File:&nbsp; </td>
                                        <td width="82%" align="left"><input name="file" type="file" class="input" id="flProducts" runat="server" />                                        </td>
                                      </tr>
                                      <tr style="display:none">
                                        <td align="right">&nbsp;</td>
                                        <td align="left"><input name="checkbox" type="checkbox" id="chkUpdateExisting" runat="server" />
                                          &nbsp;Update Existing Data</td>
                                      </tr>
                                      <tr>
                                        <td align="right">&nbsp;</td>
                                        <td align="left" style="padding-top:5px;"><input name="btnImportFile" type="submit" class="AdminFormButton" id="btnImportFile"  value="Import File" runat="server" /></td>
                                      </tr>
                                      <tr>
                                        <td colspan="2" align="left" valign="top"><table width="100%"  border="0" cellspacing="0" cellpadding="0" id="tblProductError" runat="Server" visible="false">
                                            <tr>
                                              <td class="title" style="padding-top:10px;padding-bottom:10px;">Following products could not be added / updated. Please see Reason column.</td>
                                            </tr>
                                            <tr>
                                              <td align="left" style="border:1px solid #BBCCD9">
                                              <asp:DataGrid ID="grdError" runat="server" AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Right"
								Font-Size="8pt" Font-Name="Verdana" CellSpacing="0" CellPadding="2"  ShowFooter="false"
								BorderWidth="0"  AllowPaging="false" Width="100%" GridLines="None" BackColor="#FFFFFF" >
                                                  <HeaderStyle Font-Bold="True" HorizontalAlign="Center"  CssClass="GridTop" ForeColor="#FFFFFF" Height="25"></HeaderStyle>
                                                  <AlternatingItemStyle BackColor="#F7F7F9"></AlternatingItemStyle>
                                                  <Columns>
                                                   <asp:TemplateColumn  HeaderText="No" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" ItemStyle-Width="50" HeaderStyle-Width="50">
                                                  <itemtemplate>
                                                  		<%#Eval("__RowNumber") + 1 %>                                                    </itemtemplate>
                                                  </asp:TemplateColumn>
                                                  <asp:BoundColumn DataField="FBUserEmail" HeaderText="Title" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"  ItemStyle-Width="230" HeaderStyle-Width="230"></asp:BoundColumn>
                                                  <asp:BoundColumn DataField="FBUserName" HeaderText="SKU Code" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" ItemStyle-Width="60" HeaderStyle-Width="60"></asp:BoundColumn>
                                                  <asp:TemplateColumn HeaderText="Reason" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">
                                                    <ItemTemplate> <font style='color:#990000;font-weight:bold'><%#Eval("Reason") %></font> </ItemTemplate>
                                                  </asp:TemplateColumn>
                                                  </Columns>
                                                </asp:DataGrid>                                              </td>
                                            </tr>
                                        </table></td>
                                      </tr>
									  <tr>
                                        <td colspan="2" align="left">
										<table width="100%"  border="0" cellspacing="0" cellpadding="0" id="tblCustomerError" runat="Server" visible="false">
                                            <tr>
                                              <td class="title" style="padding-top:10px;padding-bottom:10px;">Following Customers could not be added / updated. Please see Reason column.</td>
                                            </tr>
                                            <tr>
                                              <td align="left" style="border:1px solid #BBCCD9">
											  <asp:DataGrid ID="grdErrorCustomer" runat="server" AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Right"
                                                    Font-Size="8pt" Font-Name="Verdana" CellSpacing="0" CellPadding="4"  ShowFooter="false"
                                                    BorderWidth="0"  AllowPaging="false" Width="100%" GridLines="None" BackColor="#FFFFFF" >
                                                  <HeaderStyle Font-Bold="True" HorizontalAlign="Center"  CssClass="GridTop" ForeColor="#FFFFFF" Height="25"></HeaderStyle>
                                                  <AlternatingItemStyle BackColor="#F7F7F9"></AlternatingItemStyle>
                                                  <Columns>
                                                  <asp:TemplateColumn  HeaderText="No" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" ItemStyle-Width="50" HeaderStyle-Width="50">
                                                  <itemtemplate>
                                                  		<%#Eval("__RowNumber") + 1 %>                                                    </itemtemplate>
                                                  </asp:TemplateColumn>
                                                  <asp:TemplateColumn HeaderText="FBUserEmail" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">
                                                  <itemtemplate>
                                                  		<%#Eval("FBUserEmail")%>&nbsp;                                                 </itemtemplate>
                                                  </asp:TemplateColumn>
                                                  <asp:TemplateColumn HeaderText="FBUserName" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">
                                                  <itemtemplate>
                                                  		<%#Eval("FBUserName")%>&nbsp;                                                 </itemtemplate>
                                                  </asp:TemplateColumn>
                                                  <asp:TemplateColumn HeaderText="Reason" HeaderStyle-ForeColor="#FFFFFF"  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"  >
                                                    <ItemTemplate> <font style='color:#990000;font-weight:bold'><%#Eval("Reason") %></font> </ItemTemplate>
                                                  </asp:TemplateColumn>
                                                  </Columns>
                                                </asp:DataGrid>                                              </td>
                                            </tr>
                                        </table></td>
                                      </tr>
                                  </table>
                  </td>
                </tr>
              </table>
			</ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lnkLibraryCSVTemplate" />
			    <asp:PostBackTrigger ControlID="btnImportFile" />
				</Triggers>
            </asp:UpdatePanel>
			  </td>
            </tr>
            <tr>
                <td>
                <asp:DropDownList  ID="ddlAutoPostTimeZone" runat="server" style="border:1px solid #CCC; font-family:Arial; display:none; font-size:12px; color:#666; height:24px; padding:2px; width:255px;">
                                      <asp:ListItem Value="0"> Select a TimeZone </asp:ListItem>
                                      <asp:ListItem Value="Eastern Standard Time">Eastern Timezone (UTC -5.00)</asp:ListItem>
                                      <asp:ListItem Value="Central Standard Time">Central Timezone (UTC -6.00)</asp:ListItem>
                                      <asp:ListItem Value="Mountain Standard Time">Mountain Timezone (UTC -7.00)</asp:ListItem>
                                      <asp:ListItem Value="Pacific Standard Time">Pacific Timezone (UTC -8.00)</asp:ListItem>
                                      <asp:ListItem value="Dateline Standard Time">(UTC-12:00) International Date Line West</asp:ListItem>
                                      <asp:ListItem value="Samoa Standard Time">(UTC-11:00) Midway Island, Samoa</asp:ListItem>
                                      <asp:ListItem value="Hawaiian Standard Time">(UTC-10:00) Hawaii</asp:ListItem>
                                      <asp:ListItem value="Alaskan Standard Time">(UTC-09:00) Alaska</asp:ListItem>
                                      <asp:ListItem value="Pacific Standard Time (Mexico)">(UTC-08:00) Tijuana, Baja California</asp:ListItem>
                                      <asp:ListItem value="US Mountain Standard Time">(UTC-07:00) Arizona</asp:ListItem>
                                      <asp:ListItem value="Mountain Standard Time (Mexico)">(UTC-07:00) Chihuahua, La Paz, Mazatlan</asp:ListItem>
                                      <asp:ListItem value="Central America Standard Time">(UTC-06:00) Central America</asp:ListItem>
                                      <asp:ListItem value="Central Standard Time (Mexico)">(UTC-06:00) Guadalajara, Mexico City, Monterrey</asp:ListItem>
                                      <asp:ListItem value="Canada Central Standard Time">(UTC-06:00) Saskatchewan</asp:ListItem>
                                      <asp:ListItem value="SA Pacific Standard Time">(UTC-05:00) Bogota, Lima, Quito</asp:ListItem>
                                      <asp:ListItem value="US Eastern Standard Time">(UTC-05:00) Indiana (East)</asp:ListItem>
                                      <asp:ListItem value="Venezuela Standard Time">(UTC-04:30) Caracas</asp:ListItem>
                                      <asp:ListItem value="Paraguay Standard Time">(UTC-04:00) Asuncion</asp:ListItem>
                                      <asp:ListItem value="Atlantic Standard Time">(UTC-04:00) Atlantic Time (Canada)</asp:ListItem>
                                      <asp:ListItem value="SA Western Standard Time">(UTC-04:00) Georgetown, La Paz, San Juan</asp:ListItem>
                                      <asp:ListItem value="Central Brazilian Standard Time">(UTC-04:00) Manaus</asp:ListItem>
                                      <asp:ListItem value="Pacific SA Standard Time">(UTC-04:00) Santiago</asp:ListItem>
                                      <asp:ListItem value="Newfoundland Standard Time">(UTC-03:30) Newfoundland</asp:ListItem>
                                      <asp:ListItem value="E. South America Standard Time">(UTC-03:00) Brasilia</asp:ListItem>
                                      <asp:ListItem value="Argentina Standard Time">(UTC-03:00) Buenos Aires</asp:ListItem>
                                      <asp:ListItem value="SA Eastern Standard Time">(UTC-03:00) Cayenne</asp:ListItem>
                                      <asp:ListItem value="Greenland Standard Time">(UTC-03:00) Greenland</asp:ListItem>
                                      <asp:ListItem value="Montevideo Standard Time">(UTC-03:00) Montevideo</asp:ListItem>
                                      <asp:ListItem value="Mid-Atlantic Standard Time">(UTC-02:00) Mid-Atlantic</asp:ListItem>
                                      <asp:ListItem value="Azores Standard Time">(UTC-01:00) Azores</asp:ListItem>
                                      <asp:ListItem value="Cape Verde Standard Time">(UTC-01:00) Cape Verde Is.</asp:ListItem>
                                      <asp:ListItem value="Morocco Standard Time">(UTC) Casablanca</asp:ListItem>
                                      <asp:ListItem value="UTC">(UTC) Coordinated Universal Time</asp:ListItem>
                                      <asp:ListItem value="GMT Standard Time">(UTC) Dublin, Edinburgh, Lisbon, London</asp:ListItem>
                                      <asp:ListItem value="Greenwich Standard Time">(UTC) Monrovia, Reykjavik</asp:ListItem>
                                      <asp:ListItem value="W. Europe Standard Time">(UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna</asp:ListItem>
                                      <asp:ListItem value="Central Europe Standard Time">(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague</asp:ListItem>
                                      <asp:ListItem value="Romance Standard Time">(UTC+01:00) Brussels, Copenhagen, Madrid, Paris</asp:ListItem>
                                      <asp:ListItem value="Central European Standard Time">(UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb</asp:ListItem>
                                      <asp:ListItem value="W. Central Africa Standard Time">(UTC+01:00) West Central Africa</asp:ListItem>
                                      <asp:ListItem value="Jordan Standard Time">(UTC+02:00) Amman</asp:ListItem>
                                      <asp:ListItem value="GTB Standard Time">(UTC+02:00) Athens, Bucharest, Istanbul</asp:ListItem>
                                      <asp:ListItem value="Middle East Standard Time">(UTC+02:00) Beirut</asp:ListItem>
                                      <asp:ListItem value="Egypt Standard Time">(UTC+02:00) Cairo</asp:ListItem>
                                      <asp:ListItem value="South Africa Standard Time">(UTC+02:00) Harare, Pretoria</asp:ListItem>
                                      <asp:ListItem value="FLE Standard Time">(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius</asp:ListItem>
                                      <asp:ListItem value="Israel Standard Time">(UTC+02:00) Jerusalem</asp:ListItem>
                                      <asp:ListItem value="E. Europe Standard Time">(UTC+02:00) Minsk</asp:ListItem>
                                      <asp:ListItem value="Namibia Standard Time">(UTC+02:00) Windhoek</asp:ListItem>
                                      <asp:ListItem value="Arabic Standard Time">(UTC+03:00) Baghdad</asp:ListItem>
                                      <asp:ListItem value="Arab Standard Time">(UTC+03:00) Kuwait, Riyadh</asp:ListItem>
                                      <asp:ListItem value="Russian Standard Time">(UTC+03:00) Moscow, St. Petersburg, Volgograd</asp:ListItem>
                                      <asp:ListItem value="E. Africa Standard Time">(UTC+03:00) Nairobi</asp:ListItem>
                                      <asp:ListItem value="Georgian Standard Time">(UTC+03:00) Tbilisi</asp:ListItem>
                                      <asp:ListItem value="Iran Standard Time">(UTC+03:30) Tehran</asp:ListItem>
                                      <asp:ListItem value="Arabian Standard Time">(UTC+04:00) Abu Dhabi, Muscat</asp:ListItem>
                                      <asp:ListItem value="Azerbaijan Standard Time">(UTC+04:00) Baku</asp:ListItem>
                                      <asp:ListItem value="Mauritius Standard Time">(UTC+04:00) Port Louis</asp:ListItem>
                                      <asp:ListItem value="Caucasus Standard Time">(UTC+04:00) Yerevan</asp:ListItem>
                                      <asp:ListItem value="Afghanistan Standard Time">(UTC+04:30) Kabul</asp:ListItem>
                                      <asp:ListItem value="Ekaterinburg Standard Time">(UTC+05:00) Ekaterinburg</asp:ListItem>
                                      <asp:ListItem value="Pakistan Standard Time">(UTC+05:00) Islamabad, Karachi</asp:ListItem>
                                      <asp:ListItem value="West Asia Standard Time">(UTC+05:00) Tashkent</asp:ListItem>
                                      <asp:ListItem value="India Standard Time">(UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi</asp:ListItem>
                                      <asp:ListItem value="Sri Lanka Standard Time">(UTC+05:30) Sri Jayawardenepura</asp:ListItem>
                                      <asp:ListItem value="Nepal Standard Time">(UTC+05:45) Kathmandu</asp:ListItem>
                                      <asp:ListItem value="N. Central Asia Standard Time">(UTC+06:00) Almaty, Novosibirsk</asp:ListItem>
                                      <asp:ListItem value="Central Asia Standard Time">(UTC+06:00) Astana, Dhaka</asp:ListItem>
                                      <asp:ListItem value="Myanmar Standard Time">(UTC+06:30) Yangon (Rangoon)</asp:ListItem>
                                      <asp:ListItem value="SE Asia Standard Time">(UTC+07:00) Bangkok, Hanoi, Jakarta</asp:ListItem>
                                      <asp:ListItem value="North Asia Standard Time">(UTC+07:00) Krasnoyarsk</asp:ListItem>
                                      <asp:ListItem value="China Standard Time">(UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi</asp:ListItem>
                                      <asp:ListItem value="North Asia East Standard Time">(UTC+08:00) Irkutsk, Ulaan Bataar</asp:ListItem>
                                      <asp:ListItem value="Singapore Standard Time">(UTC+08:00) Kuala Lumpur, Singapore</asp:ListItem>
                                      <asp:ListItem value="W. Australia Standard Time">(UTC+08:00) Perth</asp:ListItem>
                                      <asp:ListItem value="Taipei Standard Time">(UTC+08:00) Taipei</asp:ListItem>
                                      <asp:ListItem value="Tokyo Standard Time">(UTC+09:00) Osaka, Sapporo, Tokyo</asp:ListItem>
                                      <asp:ListItem value="Korea Standard Time">(UTC+09:00) Seoul</asp:ListItem>
                                      <asp:ListItem value="Yakutsk Standard Time">(UTC+09:00) Yakutsk</asp:ListItem>
                                      <asp:ListItem value="Cen. Australia Standard Time">(UTC+09:30) Adelaide</asp:ListItem>
                                      <asp:ListItem value="AUS Central Standard Time">(UTC+09:30) Darwin</asp:ListItem>
                                      <asp:ListItem value="E. Australia Standard Time">(UTC+10:00) Brisbane</asp:ListItem>
                                      <asp:ListItem value="AUS Eastern Standard Time">(UTC+10:00) Canberra, Melbourne, Sydney</asp:ListItem>
                                      <asp:ListItem value="West Pacific Standard Time">(UTC+10:00) Guam, Port Moresby</asp:ListItem>
                                      <asp:ListItem value="Tasmania Standard Time">(UTC+10:00) Hobart</asp:ListItem>
                                      <asp:ListItem value="Vladivostok Standard Time">(UTC+10:00) Vladivostok</asp:ListItem>
                                      <asp:ListItem value="Central Pacific Standard Time">(UTC+11:00) Magadan, Solomon Is., New Caledonia</asp:ListItem>
                                      <asp:ListItem value="New Zealand Standard Time">(UTC+12:00) Auckland, Wellington</asp:ListItem>
                                      <asp:ListItem value="Fiji Standard Time">(UTC+12:00) Fiji, Marshall Is.</asp:ListItem>
                                      <asp:ListItem value="Kamchatka Standard Time">(UTC+12:00) Petropavlovsk-Kamchatsky</asp:ListItem>
                                      <asp:ListItem value="Tonga Standard Time">(UTC+13:00) Nuku&#39;alofa</asp:ListItem>
                                    </asp:DropDownList>
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
