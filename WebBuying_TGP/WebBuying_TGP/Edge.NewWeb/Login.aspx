<%@ Page Language="c#" CodeBehind="Login.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Admin.Login"
    EnableTheming="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>:Login</title>
     <link type="text/css" rel="stylesheet" href="~/res/css/default.css" />
</head>
<body>
    <form id="form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Window EnableClose="false" ID="Window1" runat="server" IsModal="true" 
        EnableMaximize="false" WindowPosition="GoldenSection" Icon="Key" Title="edgeBuying System"
        Layout="HBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start" Width="450px"
        Height="335px">
        <Items>
            <ext:Image ID="imageLogin" ImageUrl="images/veilogo.png" runat="server" ImageCssStyle="position: absolute;left: 15px; top: 40px;"
                ImageWidth="98px" ImageHeight="50px" Width="128px">
            </ext:Image>
            <ext:SimpleForm ID="SimpleForm1" LabelAlign="Top" BoxFlex="1" runat="server" LabelWidth="80px"
                BodyPadding="8px" ShowBorder="false" ShowHeader="false">
                <Items>
                    <ext:TextBox ID="txtUsername" Label="User Name" Required="true" runat="server" >
                    </ext:TextBox>
                    <ext:TextBox ID="txtPass" Label="Password" TextMode="Password" Required="true" runat="server">
                    </ext:TextBox>
                    <ext:TextBox ID="CheckCode" Label="Verification code" Required="true" runat="server">
                    </ext:TextBox>
                    <ext:Panel ShowBorder="false" Layout="Column" ShowHeader="false" 
                        runat="server">
                        <Items>
                            <ext:Panel ID="Panel1" ShowBorder="false" ColumnWidth="70%" ShowHeader="false" 
                                runat="server">
                                <Items>
                                    <ext:Image ID="imgCaptcha" runat="server" ShowEmptyLabel="false" ImageUrl="Ashx/ValidateCode.ashx?w=223&h=30">
                                    </ext:Image>
                                </Items>
                            </ext:Panel>
                            <ext:Panel ID="Panel2" ShowBorder="false" ColumnWidth="30%" ShowHeader="false" 
                                runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Button ID="btnRefresh" Text="Refresh？" runat="server" OnClick="btnRefresh_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Panel>
                    <ext:DropDownList ID="ddlLanguage" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged"
                        Label="Language：" runat="server">
                        <ext:ListItem Text="English" Value="en" />
                        <ext:ListItem Text="简体中文" Value="zh_cn" />
                        <ext:ListItem Text="繁體中文" Value="zh_tw" />
                    </ext:DropDownList>
                    <ext:Button ID="btnLogin" Text="Login" Type="Submit" ValidateForms="SimpleForm1" ValidateTarget="Top"
                        Icon="LockOpen" runat="server" OnClick="btnLogin_Click">
                    </ext:Button>
                </Items>
            </ext:SimpleForm>
        </Items>
    </ext:Window>
    </form>
</body>
</html>
