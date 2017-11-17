<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BRAND.Show" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Show</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                Hidden="false">
                <Rows>
                    <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreBrandCode" runat="server" Label="Brand Code">
                            </ext:Label>
                            <ext:Label ID="StoreBrandName1" runat="server" Label="Brand Name 1">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreBrandName2" runat="server" Label="品牌名称2">
                            </ext:Label>
                            <ext:Label ID="StoreBrandName3" runat="server" Label="品牌名称3">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow16" runat="server" ColumnWidths="100%">
                        <Items>
                            <ext:Label ID="StoreBrandDesc1" runat="server" Label="品牌描述1" EncodeText="false">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow17" runat="server" ColumnWidths="100%">
                        <Items>
                            <ext:Label ID="StoreBrandDesc2" runat="server" Label="品牌描述2" EncodeText="false">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="100%">
                        <Items>
                            <ext:Label ID="StoreBrandDesc3" runat="server" Label="品牌描述3" EncodeText="false">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:Form ID="Form2" ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow2" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath" Hidden="true" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label1" Text="" runat="server" Label="小图文件路径名">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server">
                        <Items>
                            <ext:Form ID="Form4" ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow4" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath1" Hidden="true" Text="" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label2" Text="" runat="server" Label="中图文件路径名">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview1" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server">
                        <Items>
                            <ext:Form ID="Form5" ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow6" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath2" Hidden="true" Text="" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label3" Text="" runat="server" Label="大图文件路径名">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview2" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow9" runat="server">
                        <Items>
                            <ext:Label ID="CardIssuerID" runat="server" Label="货品发行方">
                            </ext:Label>
                            <ext:Label ID="IndustryID" runat="server" Label="外键">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server">
                        <Items>
                            <ext:Label ID="CreatedOn" runat="server" Label="Created Date Time">
                            </ext:Label>
                            <ext:Label ID="CreatedBy" runat="server" Label="Created By">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server">
                        <Items>
                            <ext:Label ID="UpdatedOn" runat="server" Label="Last Modified Date Time">
                            </ext:Label>
                            <ext:Label ID="UpdatedBy" runat="server" Label="Last Modified By">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="WindowPic" Title="Image" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
