<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminConfig.aspx.cs" Inherits="Edge.Web.AdminConfig" %>

<%@ Register Assembly="Edge.Web" Namespace="Edge.Web.Controls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统参数设置</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" BodyPadding="5px" runat="server"
        EnableCollapse="false" Title="系统信息" AutoScroll="true">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" Position="Top" runat="server" BoxConfigAlign="Center">
                <Items>
                    <ext:Button ID="btnSave" runat="server" Icon="Disk" Text="保存" OnClick="btnSave_Click" ValidateForms="Form2,Form3,Form4,Form5,Form6,Form7,Form8">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel3" Title="系统基本设置（注意如果你不是专业人员请勿改动，只有开放文件的读写权限才能修改）"
                runat="server"  EnableCollapse="true">
                <Items>
                    <ext:Form ID="Form2" runat="server" ShowBorder="false"
                        ShowHeader="false" LabelAlign="Right">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebName" runat="server" Label="网站标题" MaxLength="50">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebUrl" runat="server" Label="网站域名" MaxLength="100">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebTel" runat="server" Label="办公电话" MaxLength="50">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebFax" runat="server" Label="传真号码" MaxLength="50">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebEmail" runat="server" Label="管理员信箱" MaxLength="50">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebCrod" runat="server" Label="网站备案号" MaxLength="50">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="txtWebKeywords" runat="server" Height="250px" MaxLength="250" Label="网站关健字">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="txtWebDescription" runat="server" Height="50px" MaxLength="250"
                                        Label="网站描述">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="txtWebCopyright" runat="server" Height="50px" MaxLength="250" Label="系统版权信息">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:RadioButtonList ID="rblIsConvertToUpper" runat="server" Width="200" Label="是否转换文本为大写">
                                        <ext:RadioItem Text="No" Value="0" Selected="true"/>
                                        <ext:RadioItem Text="Yes" Value="1" />
                                    </ext:RadioButtonList>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" Title="系统参数设置" runat="server"
                EnableCollapse="True">
                <Items>
                    <ext:Form ID="Form3" runat="server" ShowBorder="false"
                        ShowHeader="false" LabelAlign="Right"  LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebPath" runat="server" Label="虚拟目录" MaxLength="20">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebManagePath" runat="server" Label="后台管理目录" MaxLength="20">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebFilePath" runat="server" Label="文件上传目录" MaxLength="255">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebFileType" runat="server" Label="允许文件上传类型" MaxLength="255">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox ID="txtWebFileSize" runat="server" Label="允许文件上传大小" MaxLength="9">
                                    </ext:NumberBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:RadioButtonList ID="rblWebLogStatus" runat="server" Label="管理日志">
                                        <ext:RadioItem Text="开启" Value="1" Selected="true" />
                                        <ext:RadioItem Text="Close" Value="0" />
                                    </ext:RadioButtonList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="txtWebKillKeywords" runat="server" Height="50px" MaxLength="255"
                                        Label="Translate__Special_121_StartSQL注入过滤Translate__Special_121_End">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtWebImageType" runat="server" Label="允许图片文件上传类型" MaxLength="255" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtCardGradeFileType" runat="server" Label="Translate__Special_121_StartCardGrade文件上传类型Translate__Special_121_End" MaxLength="255" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtCouponTypeFileType" runat="server" Label="Translate__Special_121_StartCouponType文件上传类型Translate__Special_121_End" MaxLength="255" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtDistributeTemplateType" runat="server" Label="Translate__Special_121_StartDistributeTemplate文件上传类型Translate__Special_121_End" MaxLength="255" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtAdvertisementFileType" runat="server" Label="Translate__Special_121_StartAdvertisement文件上传类型Translate__Special_121_End" MaxLength="255" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtMemberInfoFileType" runat="server" Label="Translate__Special_121_StartMemberInfo文件上传类型Translate__Special_121_End" MaxLength="255" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtImporBIFileType" runat="server" Label="Translate__Special_121_StartImporBI文件上传类型Translate__Special_121_End" MaxLength="255" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="txtCouponCreateFileType" runat="server" Label="Translate__Special_121_StartCouponCreate文件上传类型Translate__Special_121_End" MaxLength="255" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel1" Title="分页参数设置" runat="server"
                 EnableCollapse="True">
                <Items>
                    <ext:Form ID="Form4" runat="server" ShowBorder="false"
                        ShowHeader="false" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox ID="txtContentPageNum" runat="server" Label="列表分页数" MaxLength="9">
                                    </ext:NumberBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel4" Title="查询限制设置" runat="server"
                 EnableCollapse="True">
                <Items>
                    <ext:Form ID="Form5" runat="server" ShowBorder="false"
                        ShowHeader="false" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox ID="txtMaxShowNum" runat="server" Label="最大添加数限制" MaxLength="9">
                                    </ext:NumberBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox ID="txtMaxSearchNum" runat="server" Label="最大查询数限制" MaxLength="9">
                                    </ext:NumberBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" Title="优惠券管理设置" runat="server"
                 EnableCollapse="True">
                <Items>
                    <ext:Form ID="Form6" runat="server" ShowBorder="false"
                        ShowHeader="false" LabelAlign="Right" LabelWidth="200">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:CheckBoxList ID="cbgVoidStatus" runat="server" Label="作废优惠券交易 - 优惠券状态">
                                        <ext:CheckItem Text="DORMANT" Value="0" />
                                        <ext:CheckItem Text="ISSUED" Value="1" />
                                        <ext:CheckItem Text="ACTIVE" Value="2" />
                                        <ext:CheckItem Text="REDEEMED" Value="3" />
                                        <ext:CheckItem Text="EXPIRED" Value="4" />
                                    </ext:CheckBoxList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:CheckBoxList ID="cbgChangeStatus" runat="server" Label="修改状态交易 - 优惠券状态">
                                        <ext:CheckItem Text="ISSUED" Value="1" />
                                        <ext:CheckItem Text="ACTIVE" Value="2" />
                                        <ext:CheckItem Text="REDEEMED" Value="3" />
                                        <ext:CheckItem Text="EXPIRED" Value="4" />
                                        <ext:CheckItem Text="VOID" Value="5" />
                                    </ext:CheckBoxList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:CheckBoxList ID="cbgExpiredStatus" runat="server" Label="修改有效期交易 - 优惠券状态">
                                        <ext:CheckItem Text="DORMANT" Value="0" />
                                        <ext:CheckItem Text="ISSUED" Value="1" />
                                        <ext:CheckItem Text="ACTIVE" Value="2" />
                                        <ext:CheckItem Text="REDEEMED" Value="3" />
                                        <ext:CheckItem Text="EXPIRED" Value="4" />
                                        <ext:CheckItem Text="VOID" Value="5" />
                                    </ext:CheckBoxList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:CheckBoxList ID="cbgChangeDenomination" runat="server" Label="修改面额交易 - 优惠券状态">
                                        <ext:CheckItem Text="DORMANT" Value="0" />
                                        <ext:CheckItem Text="ISSUED" Value="1" />
                                        <ext:CheckItem Text="ACTIVE" Value="2" />
                                        <ext:CheckItem Text="REDEEMED" Value="3" />
                                        <ext:CheckItem Text="EXPIRED" Value="4" />
                                        <ext:CheckItem Text="VOID" Value="5" />
                                    </ext:CheckBoxList>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel6" Title="撿貨單設置" runat="server"
                 EnableCollapse="True">
                <Items>
                    <ext:Form ID="Form7" runat="server" ShowBorder="false"
                        ShowHeader="false" LabelAlign="Right">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="ddlCouponOrderPickingAllowSetting" runat="server" Label="設置选项" >
                                        <ext:ListItem Value="1" Text="只允許撿貨數量等於訂單數量"></ext:ListItem>
                                        <ext:ListItem Value="2" Text="只允許撿貨數量小於等於訂單數量"></ext:ListItem>
                                        <ext:ListItem Value="3" Text="只允許撿貨數量大於等於訂單數量"></ext:ListItem>
                                        <ext:ListItem Value="4" Text="撿貨數量不限制"></ext:ListItem>
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel7" Title="優惠券收貨確認開關" runat="server"
                 EnableCollapse="True">
                <Items>
                    <ext:Form ID="Form8" runat="server" ShowBorder="false"
                        ShowHeader="false" LabelAlign="Right">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:RadioButtonList ID="rblCouponShipmentConfirmationSwitch" runat="server" Width="100"
                                        Label="是否手动激活">
                                        <ext:RadioItem Value="1" Text="Yes"></ext:RadioItem>
                                        <ext:RadioItem Value="0" Text="No"></ext:RadioItem>
                                    </ext:RadioButtonList>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel><ext:GroupPanel ID="GroupPanel8" Title="用户密码设置" runat="server"
                 EnableCollapse="True">
                <Items>
                    <ext:Form ID="Form9" runat="server" ShowBorder="false"
                        ShowHeader="false" LabelAlign="Right">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                   <ext:TextBox ID="tbUserDefaultPassword" runat="server" Label="用户默认密码" MaxLength="255">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                   <ext:TextBox ID="txtAttchFileServer" runat="server" Label="Translate__Special_121_Start链接Kiosk地址Translate__Special_121_End" MaxLength="255">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>

