<%@ Page Language="c#" CodeBehind="SetPass.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Accounts.SetPass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>SetPass</title>
    <script type="text/javascript" src='<%#GetjQueryPath() %>'></script>
    <script type="text/javascript" src='<%#GetjQueryValidatePath() %>'></script>
    <script type="text/javascript" src='<%#GetJSMultiLanguagePath() %>'></script>
    <script type="text/javascript" src='<%#GetJSFunctionPath()%>'></script>
    <script type="text/javascript">
        $(function () {
            //表单验证JS
            $("#form1").validate({
                rules: {
                    txtPassword: {
                        required: true,
                        minlength: 6
                    },
                    txtPassword1: {
                        required: true,
                        minlength: 6,
                        equalTo: "#txtPassword"
                    }
                },
                //出错时添加的标签
                errorElement: "span",
                success: function (label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });
        });
    </script>
</head>
<body style="padding: 10px;">
    <form id="form1" method="post" runat="server">
    <div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：修改密码</b>
    </div>
    <div style="padding-bottom: 10px;">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <td width="25%" align="right">
                用户名：
            </td>
            <td width="75%">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="input required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                密码：
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                密码确认：
            </td>
            <td>
                <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <div align="center">
                    <asp:Button ID="btnUpdate" runat="server" Text="提交" OnClick="btnUpdate_Click" CssClass="submit">
                    </asp:Button>
                    <asp:Button ID="btnCancel" runat="server" Text="重填" OnClick="btnCancel_Click" CssClass="submit">
                    </asp:Button></div>
            </td>
        </tr>
    </table>
    </form>
    <div style="margin-top: 10px; text-align: center;">
    </div>
</body>
</html>
