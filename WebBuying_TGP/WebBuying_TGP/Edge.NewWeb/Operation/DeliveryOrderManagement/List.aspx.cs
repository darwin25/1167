using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Edge.Web.Controllers.Operation.DeliveryOrderManagement;
using Edge.Web.Tools;
using Edge.Messages.Manager;

namespace Edge.Web.Operation.DeliveryOrderManagement
{
    /// <summary>
    /// 送货单管理列表
    /// 创建人：王丽
    /// 创建时间：2015-12-21
    /// </summary>
    public partial class List : PageBase
    {
        #region 公用业务逻辑类
        DeliveryOrderController Controller = new DeliveryOrderController();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.Grid1.PageSize = webset.ContentPageNum;
                //导出
                //btnExport.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                //打印
                //btnPrint.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                RptBind("", "TransNum");
                
            }
            string url = this.Request.Url.AbsolutePath.Substring(0, this.Request.Url.AbsolutePath.LastIndexOf("/") + 1);
        }

        #region 数据列表绑定

        private int RecordCount
        {
            get
            {
                if (ViewState["RecordCount"] == null || string.IsNullOrEmpty(ViewState["RecordCount"].ToString())) return -1;
                int count = 0;
                return int.TryParse(ViewState["RecordCount"].ToString(), out count) ? count : -1;
            }
            set
            {
                if (value < 0) return;
                if (value > 0)
                {
                    //this.btnExport.Enabled = true;
                    //this.btnPrint.Enabled = true;
                }
                else
                {
                    //this.btnExport.Enabled = false;
                    //this.btnPrint.Enabled = false;
                }
                this.Grid1.RecordCount = value;
                ViewState["RecordCount"] = value;
            }
        }

        private void RptBind(string strWhere, string orderby)
        {
            try
            {
                StringBuilder sb = new StringBuilder(strWhere);
                sb.Append(" 1=1 and Status>3 ");
                #region for search
                if (SearchFlag.Text == "1")
                {
                    string code = this.Code.Text.Trim();
                    string status = this.Status.SelectedValue.Trim();
                    string CStatrtDate = this.CreateStartDate.Text;
                    string CEndDate = this.CreateEndDate.Text;
                    string StartBusDate = this.StartBusDate.Text;
                    string EndBusDate = this.EndBusDate.Text;
                    //交易编号
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" TransNum like '%");
                        sb.Append(code);
                        sb.Append("%'");
                    }
                    //状态
                    if (!string.IsNullOrEmpty(status)&& status!="-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "status";
                        sb.Append(descLan);
                        sb.Append(" ='");
                        sb.Append(status);
                        sb.Append("'");
                    }
                    //创建日期从
                    if (!string.IsNullOrEmpty(CStatrtDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "CreatedOn";
                        sb.Append(descLan);
                        sb.Append(" >= Cast('");
                        sb.Append(CStatrtDate);
                        sb.Append("' as DateTime)");
                    }
                    //创建日期到
                    if (!string.IsNullOrEmpty(CEndDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "CreatedOn";
                        sb.Append(descLan);
                        sb.Append(" < Cast('");
                        sb.Append(CEndDate);
                        sb.Append("' as DateTime) + 1");
                    }
                    //开始日期从
                    if (!string.IsNullOrEmpty(StartBusDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "BusDate";
                        sb.Append(descLan);
                        sb.Append(" >= Cast('");
                        sb.Append(StartBusDate);
                        sb.Append("' as DateTime)");
                    }
                    //开始日期到
                    if (!string.IsNullOrEmpty(EndBusDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "BusDate";
                        sb.Append(descLan);
                        sb.Append(" < Cast('");
                        sb.Append(EndBusDate);
                        sb.Append("' as DateTime) + 1");
                    }
                   
                }
                #endregion
                //记录查询条件用于排序
                strWhere = sb.ToString();
                ViewState["strWhere"] = strWhere;
                int recodeCount = 0;
                DataSet ds = Controller.GetTransactionList(strWhere, Grid1.PageSize, Grid1.PageIndex, out recodeCount, orderby);
                this.Grid1.RecordCount = recodeCount;
                this.Grid1.DataSource = ds.Tables[0].DefaultView;
                this.Grid1.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog("Sales_H", "Load Faild", ex);
            }
        }

        //排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            int count = 0;
            Edge.SVA.BLL.Sales_H SH = new SVA.BLL.Sales_H();
            DataSet ds = SH.GetList(ViewState["strWhere"].ToString());
            this.RecordCount = count;

            DataTable table = ds.Tables[0];

            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

            Grid1.DataSource = view1;
            Grid1.DataBind();
        }
      
        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            BindGridWithSort(e.SortField, e.SortDirection);
        }
        #endregion

        #region Event

        //分页
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            RptBind("", "TransNum");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "TransNum");
        }
        //查询
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            RptBind("", "TransNum");
        }
        //导出
        protected void btnExport_Click(object sender, EventArgs e)
        {

            NewExportTxns2(Grid1, Window2);
        }
        //打印
        protected void btnTest_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }
            string okScript = Window2.GetShowReference("Test.aspx?ids=" + sb1.ToString().TrimEnd(','), Resources.MessageTips.Export);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Export, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        #endregion
    }
}