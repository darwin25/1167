<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion.Promotion_Member.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modify</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="200">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:TextBox ID="PromotionCode" runat="server" Label="促销编号" Required="true" ShowRedStar="true"
                Enabled="false" />
            <ext:DropDownList ID="LoyaltyCardTypeID" runat="server" Label="促销指定的会员卡类型" OnSelectedIndexChanged="LoyaltyCardTypeID_SelectedIndexChanged"
                AutoPostBack="true" />
            <ext:DropDownList ID="LoyaltyCardGradeID" runat="server" Label="促销指定的会员卡等级" />
            <ext:TextBox ID="LoyaltyThreshold" runat="server" Label="促销指定的会员忠诚度阀值" />
            <ext:DropDownList ID="LoyaltyBirthdayFlag" runat="server" Label="是否销售当日生日促销">
                <ext:ListItem Text="不是生日促销" Value="0" Selected="true" />
                <ext:ListItem Text="会员生日当日" Value="1" />
                <ext:ListItem Text="会员生日当周" Value="2" />
                <ext:ListItem Text="会员生日当月" Value="3" />
            </ext:DropDownList>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
