<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SOD.aspx.cs" Inherits="Edge.Web.Operation.AppOperation.SOD" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SOD</title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" LabelAlign="Right">
        <Items>
            <ext:Label ID="lbNowBusDate" runat="server" Label="当前工作日" Text="">
            </ext:Label>
            <%--<ext:TextBox ID="tbEODTime" Label="自动运行时间：" runat="server" Text="060000" EmptyText="格式为：HHmmss" ShowEmptyLabel="true" Regex="([0-1][0-9]|2[0-3])([0-5][0-9])([0-5][0-9])" RegexMessage="格式为：HHmmss" Width="200px">
            </ext:TextBox>--%>
            <ext:TimePicker ID="tpEODTime" runat="server" Label="自动运行时间" Text="06:00" Increment="120">
            </ext:TimePicker>
            <ext:LinkButton ID="lbSetSODEODTime" runat="server"  ValidateForms="SimpleForm1" Text="Translate__Special_121_Start设置SOD/EODTranslate__Special_121_End" OnClick="lbSetSODEODTime_Click">
            </ext:LinkButton>
        </Items>
    </ext:SimpleForm>

    <%--<div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：<%=this.PageName %></b>
    </div>
    <div style="padding-bottom: 10px;">
        
    </div>
    <div style="text-align:center;padding-top:40px;">
    ：<asp:Label ID="" runat="server" Text=""></asp:Label><br /><br />
       
        <asp:TextBox ID="" TabIndex="1" runat="server" MaxLength="6"
                    CssClass="input "  EnableTheming="false" Width="50px" onfocus="WdatePicker({dateFmt:'HHmmss'})"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
    <span class="btn_bg">    
        <asp:LinkButton ID="" runat="server" onclick="" ></asp:LinkButton>
        </span>
        <br />
        <br />    
    </div>--%>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>

