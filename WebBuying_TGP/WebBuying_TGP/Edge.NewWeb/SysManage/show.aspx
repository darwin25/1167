<%@ Page language="c#" Codebehind="show.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.SysManage.show" %>
<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<head id="Head1" runat="server">
		<title>Show</title>
	</head>
	<body style="padding:10px;">
    <form id="Form1" method="post" runat="server">	
    <div class="navigation"><b>您当前的位置：显示节点</b></div>
    <div class="spClear"></div>
	<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
	   <tr>
        <td align="left" colspan="2">详细信息，点击修改可以修改当前信息，点击删除可删除当前信息。</td>
       </tr>
		<tr>
			<td width="25%"  align="right">
				<div align="right"><font class="form_requestcolor" >*</font> 编号：</div>
			</td>
			<td width="75%"><asp:Label id="lblID" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr>
			<td align="right">
				* 名称：
			</td>
			<td>
				<asp:Label id="lblName" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr>
			<td align="right">
				*父类：
			</td>
			<td>
				<asp:Label id="lblTarget" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr>
			<td align="right">
				*排序号：
			</td>
			<td><asp:Label id="lblOrderid" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td align="right">
				*路径：
			</td>
			<td>
				<asp:Label id="lblUrl" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr>
			<td align="right">
				Translate__Special_121_Start图标(16x16)：Translate__Special_121_End
			</td>
			<td ><asp:Label id="lblImgUrl" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr>
			<td align="right">权限：
			</td>
			<td><asp:Label id="lblPermission" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr>
			<td align="right">
				说明：
			</td>
			<td >
				<asp:Label id="lblDescription" runat="server" Width="100%"></asp:Label></td>
		</tr>
	</table>
    <div class="spClear"></div>								
	<uc1:CheckRight id="CheckRight1" runat="server"></uc1:CheckRight>
	</form>
	</body>
</HTML>
