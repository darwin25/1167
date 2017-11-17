namespace Edge.Report
{
    /// <summary>
    /// Summary description for SectionReport1.
    /// </summary>
    partial class SectionReport1
    {
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GrapeCity.ActiveReports.Data.SqlDBDataSource sqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SectionReport1));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtPOCode = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.lblApproveSatus = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblVendorName = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblProCode = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblProDesc = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblQty = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtPOCode1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtApproveStatus1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtVendorName11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtProdCode1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtProdDesc11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtProdDesc12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblApproveSatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVendorName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApproveStatus1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendorName11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdDesc11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdDesc12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox1,
            this.txtPOCode,
            this.lblApproveSatus,
            this.lblVendorName,
            this.lblProCode,
            this.lblProDesc,
            this.lblQty});
            this.pageHeader.Height = 1.552083F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.txtPOCode1,
            this.txtApproveStatus1,
            this.txtVendorName11,
            this.txtProdCode1,
            this.txtProdDesc11,
            this.txtProdDesc12});
            this.detail.Height = 3.031F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Name = "pageFooter";
            // 
            // TextBox1
            // 
            this.TextBox1.Height = 0.367F;
            this.TextBox1.Left = 3.506F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-size: 20pt; text-align: center";
            this.TextBox1.Text = "供应商订单";
            this.TextBox1.Top = 0.103F;
            this.TextBox1.Width = 2.052F;
            // 
            // txtPOCode
            // 
            this.txtPOCode.Height = 0.2F;
            this.txtPOCode.Left = 0.339F;
            this.txtPOCode.Name = "txtPOCode";
            this.txtPOCode.Style = "text-align: center";
            this.txtPOCode.Text = "订单号";
            this.txtPOCode.Top = 0.666F;
            this.txtPOCode.Width = 1F;
            // 
            // lblApproveSatus
            // 
            this.lblApproveSatus.Height = 0.2F;
            this.lblApproveSatus.HyperLink = null;
            this.lblApproveSatus.Left = 1.954F;
            this.lblApproveSatus.Name = "lblApproveSatus";
            this.lblApproveSatus.Style = "text-align: center";
            this.lblApproveSatus.Text = "状态";
            this.lblApproveSatus.Top = 0.666F;
            this.lblApproveSatus.Width = 1F;
            // 
            // lblVendorName
            // 
            this.lblVendorName.Height = 0.2F;
            this.lblVendorName.HyperLink = null;
            this.lblVendorName.Left = 3.453F;
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Style = "text-align: center";
            this.lblVendorName.Text = "供应商";
            this.lblVendorName.Top = 0.666F;
            this.lblVendorName.Width = 1F;
            // 
            // lblProCode
            // 
            this.lblProCode.Height = 0.2F;
            this.lblProCode.HyperLink = null;
            this.lblProCode.Left = 5.078F;
            this.lblProCode.Name = "lblProCode";
            this.lblProCode.Style = "text-align: center";
            this.lblProCode.Text = "货品";
            this.lblProCode.Top = 0.666F;
            this.lblProCode.Width = 1F;
            // 
            // lblProDesc
            // 
            this.lblProDesc.Height = 0.2F;
            this.lblProDesc.HyperLink = null;
            this.lblProDesc.Left = 6.693F;
            this.lblProDesc.Name = "lblProDesc";
            this.lblProDesc.Style = "text-align: center";
            this.lblProDesc.Text = "货品名称";
            this.lblProDesc.Top = 0.666F;
            this.lblProDesc.Width = 1F;
            // 
            // lblQty
            // 
            this.lblQty.Height = 0.2F;
            this.lblQty.HyperLink = null;
            this.lblQty.Left = 8.729F;
            this.lblQty.Name = "lblQty";
            this.lblQty.Style = "text-align: center";
            this.lblQty.Text = "数量";
            this.lblQty.Top = 0.666F;
            this.lblQty.Width = 1F;
            // 
            // txtPOCode1
            // 
            this.txtPOCode1.DataField = "POCode";
            this.txtPOCode1.Height = 0.2F;
            this.txtPOCode1.Left = 0F;
            this.txtPOCode1.Name = "txtPOCode1";
            this.txtPOCode1.Text = "txtPOCode1";
            this.txtPOCode1.Top = 0.333F;
            this.txtPOCode1.Width = 1.662F;
            // 
            // txtApproveStatus1
            // 
            this.txtApproveStatus1.DataField = "ApproveStatus";
            this.txtApproveStatus1.Height = 0.2F;
            this.txtApproveStatus1.Left = 2.141F;
            this.txtApproveStatus1.Name = "txtApproveStatus1";
            this.txtApproveStatus1.Text = "txtApproveStatus1";
            this.txtApproveStatus1.Top = 0.333F;
            this.txtApproveStatus1.Width = 1F;
            // 
            // txtVendorName11
            // 
            this.txtVendorName11.DataField = "VendorName1";
            this.txtVendorName11.Height = 0.2F;
            this.txtVendorName11.Left = 3.557F;
            this.txtVendorName11.Name = "txtVendorName11";
            this.txtVendorName11.Text = "txtVendorName11";
            this.txtVendorName11.Top = 0.333F;
            this.txtVendorName11.Width = 1F;
            // 
            // txtProdCode1
            // 
            this.txtProdCode1.DataField = "ProdCode";
            this.txtProdCode1.Height = 0.2F;
            this.txtProdCode1.Left = 5.078F;
            this.txtProdCode1.Name = "txtProdCode1";
            this.txtProdCode1.Text = "txtProdCode1";
            this.txtProdCode1.Top = 0.333F;
            this.txtProdCode1.Width = 1F;
            // 
            // txtProdDesc11
            // 
            this.txtProdDesc11.DataField = "ProdDesc1";
            this.txtProdDesc11.Height = 0.2F;
            this.txtProdDesc11.Left = 6.802001F;
            this.txtProdDesc11.Name = "txtProdDesc11";
            this.txtProdDesc11.Text = "txtProdDesc11";
            this.txtProdDesc11.Top = 0.3330001F;
            this.txtProdDesc11.Width = 1F;
            // 
            // txtProdDesc12
            // 
            this.txtProdDesc12.DataField = "ProdDesc1";
            this.txtProdDesc12.Height = 0.2F;
            this.txtProdDesc12.Left = 8.729F;
            this.txtProdDesc12.Name = "txtProdDesc12";
            this.txtProdDesc12.Text = "txtProdDesc12";
            this.txtProdDesc12.Top = 0.3330001F;
            this.txtProdDesc12.Width = 1F;
            // 
            // SectionReport1
            // 
            this.MasterReport = false;
            sqlDBDataSource1.CommandTimeout = 100;
            sqlDBDataSource1.ConnectionString = "data source=172.16.64.25;initial catalog=WebBuyingUAT;password=123qwE;persist sec" +
    "urity info=True;user id=sa";
            sqlDBDataSource1.SQL = resources.GetString("sqlDBDataSource1.SQL");
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 10.55208F;
            this.Script = resources.GetString("$this.Script");
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblApproveSatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVendorName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApproveStatus1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendorName11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdDesc11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdDesc12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtPOCode;
        private GrapeCity.ActiveReports.SectionReportModel.Label lblApproveSatus;
        private GrapeCity.ActiveReports.SectionReportModel.Label lblVendorName;
        private GrapeCity.ActiveReports.SectionReportModel.Label lblProCode;
        private GrapeCity.ActiveReports.SectionReportModel.Label lblProDesc;
        private GrapeCity.ActiveReports.SectionReportModel.Label lblQty;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtPOCode1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtApproveStatus1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtVendorName11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtProdCode1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtProdDesc11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtProdDesc12;
    }
}
