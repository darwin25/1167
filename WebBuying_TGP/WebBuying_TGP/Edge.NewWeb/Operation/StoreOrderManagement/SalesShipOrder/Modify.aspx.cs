using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.Operation.StoreOrderManagement;
using Edge.Web.Tools;
using System.Data;
using Newtonsoft.Json.Linq;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.Web.Operation.StoreOrderManagement.SalesShipOrder
{
    /// <summary>
    /// 销售拣货单
    /// 创建人：Lisa
    /// 创建时间：2016-06-12
    /// </summary>
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_SalesShipOrder_H, Edge.SVA.Model.Ord_SalesShipOrder_H>
    {
        SalesShipOrderController controller = new SalesShipOrderController();
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
                //绑定物流供应商
                ControlTool.BindLogisticsProvider(LogisticsProviderID, "");
                SVASessionInfo.SalesShipOrderController = null;

            }
            controller = SVASessionInfo.SalesShipOrderController;
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
                this.SalesShipOrderNumber.Text = Model.SalesShipOrderNumber;
                MemberCard memberCard = ControlTool.BindMemberNameFromSVA(Model.CardNumber);
                if (memberCard != null)
                {
                    MemberName.Text = memberCard.NickName;
                    MemberEmail.Text = memberCard.MemberEmail;
                    MemberMobilePhone.Text = memberCard.MemberMobilePhone;
                }
                if (!string.IsNullOrEmpty(Model.CreatedOn.ToString()))
                {
                    this.CreatedOn.Text = ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());
                }
                if (Model.OrderType == 1)
                {
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": lblOrderType.Text = "Need third party transfer"; break;
                        case "zh-cn": lblOrderType.Text = "需要第三方中转"; break;
                        case "zh-hk": lblOrderType.Text = "需要協力廠商中轉"; break;
                    }
                }
                else
                {
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": lblOrderType.Text = "Direct delivery, express delivery completed"; break;
                        case "zh-cn": lblOrderType.Text = "直接产生送货单，交付快递就算完成"; break;
                        case "zh-hk": lblOrderType.Text = "直接產生送貨單，交付快遞就算完成"; break;
                    }
                }
                //物流公司
                //LogisticsProviderID.Text = DALTool.GetLogisticsProviderName(Convert.ToInt32(Model.LogisticsProviderID), null);
                //送货标志
                if (Model.DeliveryFlag == 0)
                {
                    lblDeliveryFlag.Text = "自提，不送货";
                }
                else
                {
                    lblDeliveryFlag.Text = "送货";
                }
                DeliverBy.Text = Tools.DALTool.GetUserName(Convert.ToInt32(Model.DeliveryBy));
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
                    System.Data.DataSet ds = new Edge.SVA.BLL.Ord_SalesShipOrder_D().GetList(string.Format("SalesShipOrderNumber = '{0}'", Request.Params["id"]));
                    if (ds == null || ds.Tables.Count <= 0) return null;

                    Tools.DataTool.AddID(ds, "ID", 0, 0);
                    Tools.DataTool.AddBuyingProdDesc(ds, "ProdDesc", "ProdCode");

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
            if (this.Grid1.RecordCount > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    onOrderQtyTotal += Convert.ToInt32(row["onOrderQty"]);
                }
                summary.Add("onOrderQty", onOrderQtyTotal);
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
            Edge.SVA.BLL.Ord_SalesShipOrder_D salesPickOrderBll = new SVA.BLL.Ord_SalesShipOrder_D();
            table.Columns.Add(new DataColumn("onOrderQty", typeof(int)));
            DataRow row = null;
            row = table.NewRow();
            DataSet ds = salesPickOrderBll.GetSummary(string.Format("SalesShipOrderNumber = '{0}'", Request.Params["id"]));
            row[0] = ds.Tables[0].Rows[0]["OrderQty"];
            table.Rows.Add(row);
            return table;
        }
        #endregion

        protected override SVA.Model.Ord_SalesShipOrder_H GetPageObject(SVA.Model.Ord_SalesShipOrder_H obj)
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
            Edge.SVA.Model.Ord_SalesShipOrder_H item = null;
            Edge.SVA.Model.Ord_SalesShipOrder_H dataItem = this.GetDataObject();

            if (dataItem == null)
            {
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            item = this.GetPageObject(dataItem);
            if (this.Detail.Rows.Count <= 0)
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShip  Order {0} Detail No Data", item.SalesShipOrderNumber));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            if (item == null)
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShip   {0} No Data", item.SalesShipOrderNumber));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            item.UpdatedBy = DALTool.GetCurrentUser().UserID;
            item.UpdatedOn = DateTime.Now;
            //item.Status = 1;

            if (Tools.DALTool.Update<Edge.SVA.BLL.Ord_SalesShipOrder_H>(item))
            {
                Edge.SVA.BLL.Ord_SalesShipOrder_D bll = new SVA.BLL.Ord_SalesShipOrder_D();
                bll.Delete(this.SalesShipOrderNumber.Text.Trim());
                try
                {
                    DatabaseUtil.Factory.SetConnecctionString(DBUtility.PubConstant.ConnectionString);
                    DatabaseUtil.Interface.IDatabase database = DatabaseUtil.Factory.CreateIDatabase();
                    database.SetExecuteTimeout(6000);
                    System.Data.DataTable sourceTable = database.GetTableSchema("Ord_SalesShipOrder_D");
                    DatabaseUtil.Interface.IExecStatus es = null;
                    foreach (System.Data.DataRow detail in this.Detail.Rows)
                    {
                        System.Data.DataRow row = sourceTable.NewRow();
                        row["SalesShipOrderNumber"] = item.SalesShipOrderNumber;
                        row["ProdCode"] = detail["ProdCode"];
                        row["OrderQty"] = detail["OrderQty"];
                        row["Remark"] = detail["Remark"];
                        sourceTable.Rows.Add(row);
                    }
                    es = database.InsertBigData(sourceTable, "Ord_SalesShipOrder_D");
                    if (es.Success)
                    {
                        sourceTable.Rows.Clear();
                    }
                    else
                    {
                        throw es.Ex;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteErrorLog(this.PageName, string.Format("SalesShip  Order {0} Update Success But Detail Failed", item.SalesShipOrderNumber), ex);
                    ShowAddFailed();
                    return;
                }
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShip  Order {0} Update Success", item.SalesShipOrderNumber));
                CloseAndRefresh();
            }
        }
    }
}