using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json.Linq;
using Edge.Web.Tools;
using Edge.Web.Controllers.Operation.StoreOrderManagement;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.Web.Operation.StoreOrderManagement.SalesPickOrder
{
    /// <summary>
    /// 销售拣货单
    /// 创建人：Lisa
    /// 创建时间：2016-06-02
    /// </summary>
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_SalesPickOrder_H, Edge.SVA.Model.Ord_SalesPickOrder_H>
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
                ControlTool.BindStoreWithType(ddlPickupLocation, 1);

            }
            controller = SVASessionInfo.SalesPickOrderController;
            logger.WriteOperationLog(this.PageName, "Modify");
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
                //if (Common.Utils.isNumberic(Model.PickupLocation, out result))
                //{
                //    this.ddlPickupLocation.SelectedValue = Model.PickupLocation;
                //    StoreName.Text = controller.GetStoreName(Convert.ToInt32(Model.PickupLocation));
                //}
                //else
                //{
                Edge.SVA.Model.BUY_STORE store = null;
                store = storeBLL.GetStoreByCode(Model.PickupLocation);
                if (store != null)
                {
                    this.ddlPickupLocation.SelectedValue = store.StoreID.ToString();
                    StoreName.Text = controller.GetStoreName(store.StoreCode);
                }
                else
                {
                    store = storeBLL.GetModel(Convert.ToInt32(Model.PickupLocation));
                    if (store != null)
                    {
                        this.ddlPickupLocation.SelectedValue = store.StoreID.ToString();
                        StoreName.Text = controller.GetStoreName(Convert.ToInt32(store.StoreID));
                    }
                }
                //}
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

        protected void ddlPickupLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

            string result = controller.CheckStockOnhand(2, Request.Form["hidSalesPickOrderNumber"], ddlPickupLocation.SelectedValue);
            if (result == "-1")
            {
                ShowWarning(Resources.MessageTips.NoOnhandQty);
                return;
            }
            else
            {
                ViewState["DetailResult"] = null;
                this.BindDetail();
            }
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
                    Tools.DataTool.AddBuyingStockOnhandQty(ds, "OnhandQty", "SalesPickOrderNumber", Convert.ToInt32(ddlPickupLocation.SelectedValue));
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
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {

            for (int i = 0, count = Grid1.Rows.Count; i < count; i++)
            {
                int OnhandQty = Convert.ToInt32(Grid1.Rows[i].DataKeys[5]);
                int actualQTY = Convert.ToInt32(Grid1.Rows[i].DataKeys[6]);
                if (OnhandQty == 0)
                {
                    ShowWarning("ProdCode：" + Grid1.Rows[i].DataKeys[1] + Resources.MessageTips.NoOnhandQty);
                    return;
                }
                if (actualQTY > OnhandQty)
                {
                    ShowWarning("ProdCode：" + Grid1.Rows[i].DataKeys[1] + Resources.MessageTips.CheckOnHandQty);
                    return;
                }

            }
            Edge.SVA.Model.Ord_SalesPickOrder_H itemModel = null;
            Edge.SVA.Model.Ord_SalesPickOrder_H dataItem = this.GetDataObject();

            if (dataItem == null)
            {
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            itemModel = this.GetPageObject(dataItem);

            if (itemModel == null)
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Ord_SalesPick Order Form  {0} No Data", itemModel.SalesPickOrderNumber));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }
            if (ddlPickupLocation.SelectedValue != "-1")
            {
                Edge.SVA.Model.BUY_STORE stores = storeBLL.GetModel(Convert.ToInt32(ddlPickupLocation.SelectedValue));
                if (stores != null)
                {
                    itemModel.PickupLocation = stores.StoreCode;
                }
            }
            else
            {
                ShowWarning(Resources.MessageTips.PickingWarehouseNumber);
                return;
            }
            itemModel.UpdatedBy = DALTool.GetCurrentUser().UserID;
            itemModel.UpdatedOn = DateTime.Now;

            if (Tools.DALTool.Update<Edge.SVA.BLL.Ord_SalesPickOrder_H>(itemModel))
            {
                if (this.Grid1.Rows.Count <= 0)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Ord_SalesPickOrder_D no data");
                    ShowWarning(Resources.MessageTips.NoData);
                    return;
                }
                Edge.SVA.BLL.Ord_SalesPickOrder_D bll = new SVA.BLL.Ord_SalesPickOrder_D();
                //删除表中信息然后再新增
                bll.Delete(this.SalesPickOrderNumber.Text.Trim());
                Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();
                for (int i = 0, count = Grid1.Rows.Count; i < count; i++)
                {

                    Edge.SVA.Model.Ord_SalesPickOrder_D item = new SVA.Model.Ord_SalesPickOrder_D();
                    item.SalesPickOrderNumber = Request.Params["id"];
                    item.ProdCode = Grid1.Rows[i].DataKeys[1].ToString();
                    item.StockTypeCode = Grid1.Rows[i].DataKeys[2].ToString();
                    item.OrderQty = Convert.ToInt32(Grid1.Rows[i].DataKeys[3].ToString());
                    item.KeyID = Convert.ToInt32(Grid1.Rows[i].DataKeys[4].ToString());

                    if (modifiedDict.ContainsKey(i))
                    {
                        Dictionary<string, object> rowDict = modifiedDict[i];
                        if (rowDict.ContainsKey("onActualQty"))
                        {
                            if (Convert.ToInt32(rowDict["onActualQty"]) > Convert.ToInt32(Grid1.Rows[i].DataKeys[3]))
                            {
                                ShowWarning("商品：" + Grid1.Rows[i].DataKeys[1] + "换货数量不能大于订单数量");
                                return;
                            }

                            item.ActualQty = Convert.ToInt32(rowDict["onActualQty"].ToString());
                            
                        }
                    }
                    else
                    {
                        item.ActualQty = Convert.ToInt32(Grid1.Rows[i].DataKeys[6].ToString());
                    }
                    try
                    {
                        //Tools.DALTool.Update<Edge.SVA.BLL.Ord_SalesPickOrder_D>(item);
                        Tools.DALTool.Add<Edge.SVA.BLL.Ord_SalesPickOrder_D>(item);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteErrorLog(this.PageName, string.Format("Ord_SalesPickOrder_D {0} Update Failed", item.SalesPickOrderNumber), ex);
                        ShowUpdateFailed();
                        return;
                    }
                }
            }
            Logger.Instance.WriteOperationLog(this.PageName, " Ord_SalesPickOrder_D Update Success");
            CloseAndRefresh();
        }

        protected void btnAllOK_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < Grid1.Rows.Count; i++)
            {
                Edge.SVA.BLL.Ord_SalesPickOrder_D bll = new SVA.BLL.Ord_SalesPickOrder_D();
                Edge.SVA.Model.Ord_SalesPickOrder_D details = bll.GetModel(Convert.ToInt32(Grid1.Rows[i].DataKeys[4]));
                if (details != null)
                {
                    details.ActualQty = Convert.ToInt32(Grid1.Rows[i].DataKeys[3]);
                    bll.Update(details);
                }
            }
            ViewState["DetailResult"] = null;
            BindDetail();
        }
    }
}