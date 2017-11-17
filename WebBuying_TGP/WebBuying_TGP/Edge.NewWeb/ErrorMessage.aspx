<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorMessage.aspx.cs" Inherits="Edge.Web.ErrorMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>错误信息</title>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：错误信息</b>
    </div>
    <div style="padding-bottom: 10px;" />
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtablelist">
        <tr>
            <th align="left">
                错误信息
            </th>
        </tr>
        <tr>
            <td align="center">
                <div id="Message" 
                    style="color: Red; font-weight: bold; text-align: center; height: 97px; font-size:30px;" 
                    runat="server">
                    <br />
                    系统错误，请返回
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div align="center">
                    <input type="button" class="submit" style="text-align: center;" value="返 回" onclick="javascript:window.top.tb_remove();parent.frames['sysMain'].location.href='AdminCenter.aspx';" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
