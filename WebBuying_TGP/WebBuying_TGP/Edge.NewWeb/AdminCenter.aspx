<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCenter.aspx.cs" Inherits="Edge.Web.AdminCenter" %>

<%@ Register Src="Controls/checkright.ascx" TagName="checkright" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理中心首页</title>
</head>
<body >
    <%--<form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <ext:Panel ID="Panel1" BodyPadding="5px" runat="server" 
        EnableCollapse="false" Title="系统信息" >
        <Items>
            <ext:GroupPanel ID="GroupPanel3"  Title="系统基本信息" runat="server"  
                EnableCollapse="true">
                <Items>
                 <ext:Form ID="Form2" runat="server" ShowBorder="false" 
                        ShowHeader="false" LabelAlign="Right" LabelWidth="200px" >
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblWebName" Label="网站名称：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblWebUrl" Label="网站域名：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblWebPath" Label="安装目录：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblWebManagePath" Label="后台目录：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblWebTel" Label="联系电话：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblWebFax" Label="传真号码：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblWebEmail" Label="电子邮箱：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2"  Title="服务器信息" runat="server"
                EnableCollapse="True" >
                <Items>
                    <ext:Form ID="Form3" runat="server" ShowBorder="false" 
                        ShowHeader="false" LabelAlign="Right" LabelWidth="200px">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblMachineName" Label="服务器名称：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblIP" Label="Translate__Special_121_Start服务器IP：Translate__Special_121_End"
                                        runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblVersion" Label="Translate__Special_121_Start NET框架版本：Translate__Special_121_End"
                                        runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblOS" Label="操作系统：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblIIS" Label="Translate__Special_121_StartIIS环境：Translate__Special_121_End"
                                        runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblPort" Label="服务器端口：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblAPPL_PHYSICAL_PATH" Label="虚拟目录绝对路径：" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblHTTPS" Label="Translate__Special_121_StartHTTPS支持：Translate__Special_121_End"
                                        runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblSession" Label="Translate__Special_121_StartSession总数：Translate__Special_121_End"
                                        runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>                  
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    </form>--%>
</body>
</html>
