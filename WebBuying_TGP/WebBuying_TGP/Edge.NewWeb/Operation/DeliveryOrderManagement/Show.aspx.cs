using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers.Operation.DeliveryOrderManagement;
using System.Data;
using Newtonsoft.Json.Linq;

namespace Edge.Web.Operation.DeliveryOrderManagement
{
    /// <summary>
    /// 销售单查询
    /// </summary>
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Sales_H, Edge.SVA.Model.Sales_H>
    {
        DeliveryOrderController controller=new DeliveryOrderController();
        Tools.Logger logger = Tools.Logger.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.DeliveryOrderController = null;

            }
            controller = SVASessionInfo.DeliveryOrderController;
            logger.WriteOperationLog(this.PageName, "Show");
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.TransNum);
                if (controller.ViewModel.MainTable != null)
                {
                    //交易号
                    TxnNo.Text = controller.ViewModel.MainTable.TransNum;
                    //订单类型
                    lblTxnType.Text = Edge.Web.Tools.DALTool.GetTransTypeName(Convert.ToInt32(controller.ViewModel.MainTable.TransType));
                    //状态
                    lblStatus.Text = Edge.Web.Tools.DALTool.GetStatusName(Convert.ToInt32(controller.ViewModel.MainTable.Status));
                    //交易日期
                    BusDate.Text = ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.BusDate.GetValueOrDefault());
                    //店铺编号
                    StoreCode.Text = controller.ViewModel.MainTable.StoreCode;
                    //根据店铺编号得到Store Name
                    StoreName.Text = DALTool.GetBuyingStoreNameByStoreCode(controller.ViewModel.MainTable.StoreCode.ToString(), null);
                    //送货单号
                    DeliveryNumber.Text = controller.ViewModel.MainTable.DeliveryNumber;
                    //物流公司
                    LogisticsProviderID.Text = DALTool.GetLogisticsProviderName(Convert.ToInt32(controller.ViewModel.MainTable.LogisticsProviderID), null);
                    //送货员
                    DeliverBy.Text = Tools.DALTool.GetUserName(controller.ViewModel.MainTable.DeliveryBy.GetValueOrDefault());
                    //送货完整地址
                    DeliveryFullAddress.Text = controller.ViewModel.MainTable.DeliveryFullAddress;
                    //送货详细地址
                    DeliveryAddressDetail.Text = controller.ViewModel.MainTable.DeliveryAddressDetail;
                    //收货人
                    Contact.Text = controller.ViewModel.MainTable.Contact;
                    //联系电话
                    ContactPhone.Text = controller.ViewModel.MainTable.ContactPhone;
                    //创建日期
                    CreatedOn.Text = ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.CreatedOn.GetValueOrDefault());
                    //创建人
                    lblCreatedBy.Text = Tools.DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());
                    //备注
                    Remark.Text = controller.ViewModel.MainTable.Remark;
                    //送货标志
                    if (controller.ViewModel.MainTable.DeliveryFlag == 0)
                    {
                        lblDeliveryFlag.Text = "自提，不送货";
                    }
                    else
                    {
                        lblDeliveryFlag.Text = "送货";
                    }
                    //收到货的日期
                    SettlementDate.Text = ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.SettlementDate.GetValueOrDefault());
                    //提货最后确认人
                    SettlementStaffID.Text = Tools.DALTool.GetUserName(controller.ViewModel.MainTable.SettlementStaffID.GetValueOrDefault());
                    //退货方式
                    if (controller.ViewModel.MainTable.PickupType == 1)
                    {
                        lblPickupType.Text = "门店自提";
                    }
                    else
                    {
                        lblPickupType.Text = "送货上门";
                    }
                    //快递送货到达的店铺编号
                    PickupStoreCode.Text = controller.ViewModel.MainTable.PickupStoreCode;
                    //退还支付最后完成日期
                    PaySettleDate.Text = ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.PaySettleDate.GetValueOrDefault());
                    //交易单最终完成日期
                    CompleteDate.Text = ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.CompleteDate.GetValueOrDefault());



                }
                this.BindDetail();
                OutputSummaryData();

            }
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            this.BindDetail();
        }

        private System.Data.DataTable Detail
        {
            get
            {
                if (ViewState["DetailResult"] == null)
                {
                    string strWhere = "";
                    int pagesize = this.Grid1.PageSize;
                    int pageindex = this.Grid1.PageIndex;
                    System.Data.DataSet ds = new Edge.SVA.BLL.Sales_D().GetListByPage(string.Format("TransNum = '{0}'", Request.Params["id"]) + strWhere, "", pagesize * pageindex + 1, pagesize * (pageindex + 1));

                    if (ds == null || ds.Tables.Count <= 0) return null;

                    ViewState["DetailResult"] = ds.Tables[0];
                }
                return ViewState["DetailResult"] as System.Data.DataTable;
            }
        }

        private void BindDetail()
        {
            this.Grid1.RecordCount = this.Detail.Rows.Count;
            this.Grid1.DataSource = DataTool.GetPaggingTable(this.Grid1.PageIndex, this.Grid1.PageSize, this.Detail);
            this.Grid1.DataBind();
        }
        private void OutputSummaryData()
        {
            DataTable source = GetDataTable();
            JObject summary = new JObject();
            decimal QtyTotal = 0;
            if (this.Grid1.RecordCount > 0)
            {
                foreach (DataRow row in source.Rows)
                {
                    QtyTotal += Convert.ToDecimal(row["onQty"]);
                }

                summary.Add("onQty", QtyTotal.ToString("F2"));
            }
            Grid1.SummaryData = summary;

        }

        #region GetDataTable

        /// <summary>
        /// 获取模拟表格
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            Edge.SVA.BLL.Sales_D salesDBll = new SVA.BLL.Sales_D();
            table.Columns.Add(new DataColumn("onQty", typeof(int)));
            DataRow row = null;
            row = table.NewRow();
            DataSet ds = salesDBll.GetSummary(string.Format("TransNum = '{0}'", Request.Params["id"]));
            row[0] = ds.Tables[0].Rows[0]["Qty"];
            table.Rows.Add(row);
            return table;
        }
        #endregion
    }
}