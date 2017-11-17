using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using FineUI;
using System.Data;
using Edge.Web.Controllers.Operation.StoreOrderManagement.TransInStoreOrder;
using Newtonsoft.Json.Linq;

namespace Edge.Web.Operation.StoreOrderManagement.TransInOrder
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_TransInOrder_H, Edge.SVA.Model.Ord_TransInOrder_H>
    {
        Edge.SVA.BLL.Ord_TransInOrder_D transInOrderDBLL = new SVA.BLL.Ord_TransInOrder_D();
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
                
            }
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
                this.TransInOrderNumber.Text = Model.TransInOrderNumber;
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
                if (!string.IsNullOrEmpty(Model.CreatedBy.ToString()))
                {
                    this.lblCreatedBy.Text = Tools.DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.ApproveOn.ToString()))
                {
                    this.ApproveOn.Text = ConvertTool.ToStringDateTime(Model.ApproveOn.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.ApproveBy.ToString()))
                {
                    this.lblApproveBy.Text = Tools.DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(FromStoreID.ToString()))
                {
                    this.FromStoreID.Text = DALTool.GetBuyingStoreNameByID(Model.FromStoreID.ToString(), null);
                }
                if (!string.IsNullOrEmpty(StoreID.ToString()))
                {
                    this.StoreID.Text = DALTool.GetBuyingStoreNameByID(Model.StoreID.ToString(), null);
                }
                DataSet ds = transInOrderDBLL.GetList(1, "TransInOrderNumber='" + Request.Params["id"] + "'", "KeyID");
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (System.Data.DataRow row in ds.Tables[0].Rows)
                    {
                        ReasonID.Text = DALTool.GetBuyingReasonDesc(row["ReasonID"].ToString(), null);
                    }
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
                    //string strWhere="";
                    int pagesize = this.Grid1.PageSize;
                    int pageindex = this.Grid1.PageIndex;
                    //System.Data.DataSet ds = new Edge.SVA.BLL.Ord_TransInOrder_D().GetListByPage(string.Format("TransInOrderNumber = '{0}'", Request.Params["id"]) + strWhere, "", pagesize * pageindex + 1, pagesize * (pageindex + 1));
                    System.Data.DataSet ds = new Edge.SVA.BLL.Ord_TransInOrder_D().GetList(string.Format("TransInOrderNumber = '{0}'", Request.Params["id"]));
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
            int onTransOutQTYTotal = 0;
            if (this.Grid1.RecordCount > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    onTransOutQTYTotal += Convert.ToInt32(row["onTransInQTY"]);
                }
                summary.Add("onTransInQTY", onTransOutQTYTotal);
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
            Edge.SVA.BLL.Ord_TransInOrder_D TransInOrderBll = new SVA.BLL.Ord_TransInOrder_D();
            table.Columns.Add(new DataColumn("onTransInQTY", typeof(int)));
            DataRow row = null;
            row = table.NewRow();
            DataSet ds = TransInOrderBll.GetSummary(string.Format("TransInOrderNumber = '{0}'", Request.Params["id"]));
            row[0] = ds.Tables[0].Rows[0]["TransInQTY"];
            table.Rows.Add(row);
            return table;
        }
        #endregion

        protected override SVA.Model.Ord_TransInOrder_H GetPageObject(SVA.Model.Ord_TransInOrder_H obj)
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