using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using System.Data;
using Newtonsoft.Json.Linq;
using Edge.Web.Controllers.Operation.StoreOrderManagement;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.Web.Operation.StoreOrderManagement.SalesPickOrder
{
    /// <summary>
    /// 销售拣货单
    /// 创建人：Lisa
    /// 创建时间：2016-06-02
    /// </summary>
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_SalesPickOrder_H, Edge.SVA.Model.Ord_SalesPickOrder_H>
    {
        Edge.SVA.BLL.BUY_STORE storeBLL = new SVA.BLL.BUY_STORE();
        SalesPickOrderController controller = new SalesPickOrderController();
        Tools.Logger logger = Tools.Logger.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                this.Grid1.PageSize = webset.ContentPageNum;

                RegisterCloseEvent(btnClose);
                SVASessionInfo.SalesPickOrderController = null;

            }
            controller = SVASessionInfo.SalesPickOrderController;
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
                this.SalesPickOrderNumber.Text = Model.SalesPickOrderNumber;
                if (!string.IsNullOrEmpty(Model.CardNumber.ToString()))
                {
                    MemberCard memberCard = ControlTool.BindMemberNameFromSVA(Model.CardNumber);
                    if (memberCard != null)
                    {
                        MemberName.Text = memberCard.NickName;
                        MemberEmail.Text = memberCard.MemberEmail;
                        MemberMobilePhone.Text = memberCard.MemberMobilePhone;
                    }
                }
                if (!string.IsNullOrEmpty(Model.CreatedBusDate.ToString()))
                {
                    this.CreatedBusDate.Text = ConvertTool.ToStringDate(Model.CreatedBusDate.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.ApproveStatus.ToString()))
                {
                    this.lblApproveStatus.Text = DALTool.GetApproveStatusString(Model.ApproveStatus);
                }
                if (!string.IsNullOrEmpty(Model.CreatedOn.ToString()))
                {
                    this.CreatedOn.Text = ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.ApproveBy.ToString()))
                {
                    this.lblApproveBy.Text = Tools.DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.OrderType.ToString()))
                {
                    if (Model.OrderType == 1)
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": lblOrderType.Text = "Direct delivery orders"; break;
                            case "zh-cn": lblOrderType.Text = "直接产生快递单，拣货单完成"; break;
                            case "zh-hk": lblOrderType.Text = "直接產生快遞單，揀貨單完成"; break;
                        }
                    }
                    else
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": lblOrderType.Text = "Need third party transfer"; break;
                            case "zh-cn": lblOrderType.Text = "需要第三方中转"; break;
                            case "zh-hk": lblOrderType.Text = "需要協力廠商中轉"; break;
                        }
                    }
                }
                Edge.SVA.Model.BUY_STORE store = null;
                store = storeBLL.GetStoreByCode(Model.PickupLocation);
                if (store != null)
                {
                    this.lblPickupLocation.Text = store.StoreCode.ToString();
                    StoreName.Text = controller.GetStoreName(store.StoreCode);
                }
                else
                {
                    store = storeBLL.GetModel(Convert.ToInt32(Model.PickupLocation));
                    if (store != null)
                    {
                        this.lblPickupLocation.Text = store.StoreCode.ToString();
                        StoreName.Text = controller.GetStoreName(Convert.ToInt32(store.StoreID));
                    }
                }
                if (!string.IsNullOrEmpty(Model.PickupStaff))
                {
                    PickupStaff.Text = Model.PickupStaff;
                }
                if (!string.IsNullOrEmpty(Model.LogisticsProviderID.ToString()))
                {
                    //物流公司
                    LogisticsProviderID.Text = DALTool.GetLogisticsProviderName(Convert.ToInt32(Model.LogisticsProviderID), null);
                }
                //送货标志
                if (!string.IsNullOrEmpty(Model.DeliveryFlag.ToString()))
                {
                    if (Model.DeliveryFlag == 1)
                    {
                        lblDeliveryFlag.Text = "门店自提";
                    }
                    else
                    {
                        lblDeliveryFlag.Text = "送货";
                    }
                }
                if (!string.IsNullOrEmpty(Model.DeliveryBy.ToString()))
                {
                    DeliverBy.Text = Tools.DALTool.GetUserName(Convert.ToInt32(Model.DeliveryBy));
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
      
                    int pagesize = this.Grid1.PageSize;
                    int pageindex = this.Grid1.PageIndex;
                    System.Data.DataSet ds = new Edge.SVA.BLL.Ord_SalesPickOrder_D().GetList(string.Format("SalesPickOrderNumber = '{0}'", Request.Params["id"]));
                    if (ds == null || ds.Tables.Count <= 0) return null;

                    Tools.DataTool.AddID(ds, "ID", 0, 0);
                    Tools.DataTool.AddBuyingProdDesc(ds, "ProdDesc", "ProdCode");
                    Tools.DataTool.AddBuyingStockOnhandQty(ds, "OnhandQty", "SalesPickOrderNumber",0);
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
            DataTable dt = GetDataTable();
            JObject summary = new JObject();
            int onOrderQtyTotal = 0;
            int onActualQtyTotal = 0;
            if (this.Grid1.RecordCount > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    onOrderQtyTotal += Convert.ToInt32(row["onOrderQty"]);
                    onActualQtyTotal += Convert.ToInt32(row["onActualQty"]);
                }
                summary.Add("onOrderQty", onOrderQtyTotal);
                summary.Add("onActualQty", onActualQtyTotal);
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
            Edge.SVA.BLL.Ord_SalesPickOrder_D salesPickOrderBll = new SVA.BLL.Ord_SalesPickOrder_D();
            table.Columns.Add(new DataColumn("onOrderQty", typeof(int)));
            table.Columns.Add(new DataColumn("onActualQty", typeof(int)));
            DataRow row = null;
            row = table.NewRow();
            DataSet ds = salesPickOrderBll.GetSummary(string.Format("SalesPickOrderNumber = '{0}'", Request.Params["id"]));
            row[0] = ds.Tables[0].Rows[0]["OrderQty"];
            row[1] = ds.Tables[0].Rows[0]["ActualQty"];
            table.Rows.Add(row);
            return table;
        }
        #endregion

        protected override SVA.Model.Ord_SalesPickOrder_H GetPageObject(SVA.Model.Ord_SalesPickOrder_H obj)
        {
            List<System.Web.UI.Control> list = new List<System.Web.UI.Control>();

            foreach (System.Web.UI.Control con in this.Panel1.Controls)
            {
                if (con is FineUI.GroupPanel)
                {
                    foreach (System.Web.UI.Control c in con.Controls) list.Add(c);
                }
            }
            return base.GetPageObject(obj, list.GetEnumerator());
        }

        protected override void SetObject()
        {
            foreach (System.Web.UI.Control con in this.Panel1.Controls)
            {
                if (con is FineUI.GroupPanel)
                {
                    base.SetObject(Model, con.Controls.GetEnumerator());
                }
            }
        }
    }
}