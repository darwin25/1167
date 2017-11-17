<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="Controls/CheckRight.ascx" %>
<%@ Page language="c#" Codebehind="Top.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Admin.Top" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>Top</title>		
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<%--<body  text="#000000" leftmargin="0" topmargin="0" marginwidth="0"
		marginheight="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="102" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td background='<%=Application[Session["Style"].ToString()+"xtopbj_bgimage"]%>'>
						<table width="778" height="102" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td colspan="3">
								<div style="margin-top:30px; margin-left:20px; position:absolute; font-size:30px; color:#818181 "> </div><img src='<%=Application[Session["Style"].ToString()+"xtop1_bgimage"]%>' width="778" height="71" alt="System"></td>
							</tr>
							<tr>
								<td width="217" background='<%=Application[Session["Style"].ToString()+"xtop2_bgimage"]%>'>
								<table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td height="3" colspan="2"></td>
										</tr>
										<tr>
											<td width="30"><div align="center"><img src="images/bar_00.gif" width="16" height="16"></div>
											</td>
											<td>
												Current user:
												<asp:Label id="lblSignIn" runat="server"></asp:Label></td>
										</tr>
									</table>
								</td>
								<td width="286" background='<%=Application[Session["Style"].ToString()+"xtop3_bgimage"]%>'>
								<table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
								<tr>
											<td width="9%">&nbsp;</td>
											<td valign="middle" >
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
													<td><a href="toindex.aspx" target="_top"><img id="img1" src="images/bar_01.gif"  alt="Home" width="15" height="15" border="0"></a></td>
													</tr>
													
												</table>
												</td>
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
                                                                	<td><a href="#" onclick="javascript:parent.mainFrame.focus();parent.mainFrame.print();"><img id="img2"  alt="Print" src="images/bar_10.gif" width="15" height="15" border="0"></a></td>
													</tr>
												</table>
											</td>
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
                                                                <td><a href="javascript:history.go(-1)"><img id="img3" src="images/bar_02.gif" alt="Back" width="15" height="15" border="0"></a></td>
													</tr>
												</table>
											</td>
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
                                                                  <td><a href="javascript:history.go(1)"><img id="img4" src="images/bar_03.gif" alt="Next" width="15" height="15" border="0"></a></td>
													</tr>
												</table>
											</td>
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0" >
													<tr>
                                                         <td><a href="Relogin.aspx" target="_top" onClick="if (!window.confirm('You sure you want to log off currently logged user?')){return false;}"><img id="img6"  alt="Log Off" src="images/bar_06.gif" width="15" height="15" border="0"></a></td>
													</tr>
												</table>
											</td>										
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td><img id="img" src="images/bar_07.gif" width="15" height="15" onClick="if(parent.topset.rows!='22,*'){parent.topset.rows='22,*';window.scroll(0,93)}else{parent.topset.rows='93,*'};"
																style="CURSOR: hand" title="Click here to shrink the top"></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
								<td width="275"><img src='<%=Application[Session["Style"].ToString()+"xtop5_bgimage"]%>' width="75" height="31"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<uc1:CheckRight id="CheckRight1" runat="server"></uc1:CheckRight>
		</form>
	</body>--%>
	
	<body  text="#000000" leftmargin="0" topmargin="0" marginwidth="0"marginheight="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="102" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td  class="topbj_bgimage">
						<table width="778" height="102" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td colspan="4">
							    <div class="top1_bgimage"></td>
							</tr>
							<tr>
								<td  class="top2_bgimage" >
								<table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td height="3" colspan="2"></td>
										</tr>
										<tr>
											<td width="30"><div align="center"><img src="images/bar_00.gif" width="16" height="16"></div>
											</td>
											<td>
												Current user:
												<asp:Label id="lblSignIn" runat="server"></asp:Label></td>
										</tr>
									</table>
								</td>
								<td class="top3_bgimage" >
								<table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
								<tr>
											<td width="9%">&nbsp;</td>
											<td valign="middle" >
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
													<td><a href="toindex.aspx" target="_top"><img id="img1" src="images/bar_01.gif"  alt="Home" width="15" height="15" border="0"></a></td>
													</tr>
													
												</table>
												</td>
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
                                                                	<td><a href="#" onclick="javascript:parent.mainFrame.focus();parent.mainFrame.print();"><img id="img2"  alt="Print" src="images/bar_10.gif" width="15" height="15" border="0"></a></td>
													</tr>
												</table>
											</td>
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
                                                                <td><a href="javascript:history.go(-1)"><img id="img3" src="images/bar_02.gif" alt="Back" width="15" height="15" border="0"></a></td>
													</tr>
												</table>
											</td>
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
                                                                  <td><a href="javascript:history.go(1)"><img id="img4" src="images/bar_03.gif" alt="Next" width="15" height="15" border="0"></a></td>
													</tr>
												</table>
											</td>
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0" >
													<tr>
                                                         <td><a href="Relogin.aspx" target="_top" onClick="if (!window.confirm('You sure you want to log off currently logged user?')){return false;}"><img id="img6"  alt="Log Off" src="images/bar_06.gif" width="15" height="15" border="0"></a></td>
													</tr>
												</table>
											</td>										
											<td valign="middle">
												<table height="31" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td><img id="img" src="images/bar_07.gif" width="15" height="15" onClick="if(parent.topset.rows!='22,*'){parent.topset.rows='22,*';window.scroll(0,93)}else{parent.topset.rows='93,*'};"
																style="CURSOR: hand" title="Click here to shrink the top"></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
								<td class="top5_bgimage"></td>
								<td width="200"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<uc1:CheckRight id="CheckRight1" runat="server"></uc1:CheckRight>
		</form>
	</body>
</HTML>
