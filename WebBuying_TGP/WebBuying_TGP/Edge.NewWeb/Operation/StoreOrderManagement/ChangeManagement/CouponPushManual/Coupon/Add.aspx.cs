using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain;
using Edge.SVA.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Edge.Web.Controllers.Operation.CouponManagement.ChangeManagement.CouponPushManual;
using Edge.Web.Controllers;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponPushManual.Coupon
{
    public partial class Add : PageBase
    {
        CouponPushController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }

                RegisterCloseEvent(this.btnCloseSearch);

                Tools.ControlTool.BindBrand(this.CouponBrandID);

                //SVASessionInfo.CouponPushController = null;
            }
            controller = SVASessionInfo.CouponPushController;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!ValidataSearch()) return;
            ClearGird(this.SearchListGrid);
            this.SearchListGrid.PageIndex = 0;
            DataTable dt = GetSearchDataTable();
            ViewState["SearchResult"] = dt;
            BindCouponGrid();
        }

        protected void btnAddSearchItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CouponQty.Text))
            {
                ShowWarning(Resources.MessageTips.CouponQtyCannotBeEmpty);
                return;
            }
            int couponqty = Convert.ToInt32(this.CouponQty.Text);
            SyncSelectedRowIndexArrayToHiddenField();
            List<string> idList = GetSelectedRowIndexArrayFromHiddenField();

            if (ViewState["SearchResult"] != null)
            {
                if (controller.ViewModel.CouponTable == null)
                {
                    controller.ViewModel.CouponTable = ((DataTable)ViewState["SearchResult"]).Clone();
                }
                DataTable addDTView = controller.ViewModel.CouponTable;
                if (addDTView.DefaultView.Count >= webset.MaxShowNum)
                {
                    ShowWarning(Resources.MessageTips.IsMaximumLimit);
                    return;
                }

                DataTable dtSearch = ((DataTable)ViewState["SearchResult"]).Clone();

                if (!cbSearchAll.Checked)
                {
                    string ids = "";

                    for (int i = 0; i < idList.Count; i++)
                    {
                        ids += string.Format("{0},", "'" + idList[i].ToString() + "'");
                    }

                    ids = ids.TrimEnd(',');

                    if (string.IsNullOrEmpty(ids.Trim()))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    DataTable vsDT = (DataTable)ViewState["SearchResult"];
                    DataView dvSearch = vsDT.DefaultView;
                    dvSearch.RowFilter = " CouponTypeCode in (" + ids + ")";
                    dtSearch = dvSearch.ToTable();
                    foreach (DataRowView drv in dvSearch)
                    {
                        drv.Delete();
                    }
                    vsDT.AcceptChanges();
                    ViewState["SearchResult"] = vsDT;
                }
                else
                {
                    dtSearch = (DataTable)ViewState["SearchResult"];
                    ViewState["SearchResult"] = ((DataTable)ViewState["SearchResult"]).Clone();
                    cbSearchAll.Checked = false;
                }

                DataTable addDT = controller.ViewModel.CouponTable;

                for (int i = 0; i < dtSearch.Rows.Count; i++)
                {
                    dtSearch.Rows[i]["CouponQty"] = couponqty;
                }

                DataTable newSearchDT = Edge.Web.Tools.ConvertTool.CombineTheSameDatatable2(addDT, dtSearch, "CouponTypeCode");
                controller.ViewModel.CouponTable = newSearchDT;

                //返回界面时要清空查询记录
                ViewState["SearchResult"] = null;
            }
            CloseAndPostBack();
        }

        protected void cbSearchAll_OnCheckedChanged(object sender, System.EventArgs e)
        {
            SetGirdSelectAll(SearchListGrid, cbSearchAll.Checked);
            if (!cbSearchAll.Checked)
            {
                hfSelectedIDS.Text = string.Empty;
            }
        }

        protected void CouponBrandID_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCouponTypeByBrand();
        }
        private void InitCouponTypeByBrand()
        {
            if (this.CouponBrandID.SelectedValue != "-1")
            {
                Tools.ControlTool.BindCouponType(this.CouponTypeID, Convert.ToInt32(this.CouponBrandID.SelectedValue));
            }
            else
            {
                this.CouponTypeID.Items.Clear();
            }
        }

        private DataTable GetSearchDataTable()
        {
            try
            {
                Edge.SVA.BLL.CouponType bll = new Edge.SVA.BLL.CouponType();
                int brandid = Convert.ToInt32(this.CouponBrandID.SelectedValue);
                int couponTypeID = this.CouponTypeID.SelectedValue == "-1" ? -1 : Convert.ToInt32(this.CouponTypeID.SelectedValue);
                string strWhere = "";
                if (couponTypeID == -1)
                {
                    strWhere = " BrandID =" + brandid;
                }
                else
                {
                    strWhere = " BrandID =" + brandid + " and CouponTypeID =" + couponTypeID;
                }
                
                //Display message
                int count = bll.GetCount(strWhere);

                if (count <= 0)
                {
                    ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                    return null;
                }

                DataSet ds = bll.GetList(strWhere);

                Tools.DataTool.AddBrandName(ds, "BrandName", "BrandID");
                Tools.DataTool.AddBrandCode(ds, "BrandCode", "BrandID");
                Tools.DataTool.AddCouponTypeName(ds, "CouponTypeName", "CouponTypeID");
                Tools.DataTool.AddColumn(ds.Tables[0], "CouponBrandID", brandid);
                Tools.DataTool.AddColumn(ds.Tables[0], "CouponQty", 0);

                return ds.Tables[0];
            }
            catch
            {
                ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                return null;
            }
        }

        private void BindCouponGrid()
        {
            if (ViewState["SearchResult"] != null)
            {
                this.SearchListGrid.PageSize = webset.ContentPageNum;
                DataTable dt = (DataTable)ViewState["SearchResult"];
                this.SearchListGrid.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.SearchListGrid.PageIndex + 1, this.SearchListGrid.PageSize);
                this.SearchListGrid.DataSource = viewDT;
                this.SearchListGrid.DataBind();
            }
            else
            {
                this.SearchListGrid.PageSize = webset.ContentPageNum;
                this.SearchListGrid.PageIndex = 0;
                this.SearchListGrid.RecordCount = 0;
                this.SearchListGrid.DataSource = null;
                this.SearchListGrid.DataBind();
            }

            btnAddSearchItem.Enabled = SearchListGrid.RecordCount > 0 ? true : false;
        }

        protected override void RegisterGrid_OnPageIndexChange(object sender, GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            base.RegisterGrid_OnPageIndexChange(sender, e);

            BindCouponGrid();

            UpdateSelectedRowIndexArray();
            if (cbSearchAll.Checked)
            {
                SetGirdSelectAll(SearchListGrid, cbSearchAll.Checked);
            }
        }

        #region Events

        private List<string> GetSelectedRowIndexArrayFromHiddenField()
        {
            JArray idsArray = new JArray();

            string currentIDS = hfSelectedIDS.Text.Trim();
            if (!String.IsNullOrEmpty(currentIDS))
            {
                idsArray = JArray.Parse(currentIDS);
            }
            else
            {
                idsArray = new JArray();
            }

            return new List<string>(idsArray.ToObject<string[]>());
        }

        private void SyncSelectedRowIndexArrayToHiddenField()
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

            if (SearchListGrid.SelectedRowIndexArray != null && SearchListGrid.SelectedRowIndexArray.Length > 0)
            {
                List<int> selectedRows = new List<int>(SearchListGrid.SelectedRowIndexArray);
                for (int i = 0, count = Math.Min(SearchListGrid.PageSize, (SearchListGrid.RecordCount - SearchListGrid.PageIndex * SearchListGrid.PageSize)); i < count; i++)
                {
                    string id = SearchListGrid.DataKeys[i][0].ToString();
                    if (selectedRows.Contains(i))
                    {
                        if (!ids.Contains(id))
                        {
                            ids.Add(id);
                        }
                    }
                    else
                    {
                        if (ids.Contains(id))
                        {
                            ids.Remove(id);
                        }
                    }
                }
            }

            hfSelectedIDS.Text = new JArray(ids).ToString(Formatting.None);
        }


        private void UpdateSelectedRowIndexArray()
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

            List<int> nextSelectedRowIndexArray = new List<int>();
            for (int i = 0, count = Math.Min(SearchListGrid.PageSize, (SearchListGrid.RecordCount - SearchListGrid.PageIndex * SearchListGrid.PageSize)); i < count; i++)
            {
                string id = SearchListGrid.DataKeys[i][0].ToString();
                if (ids.Contains(id))
                {
                    nextSelectedRowIndexArray.Add(i);
                }
            }
            SearchListGrid.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
        }

        #endregion

        protected bool ValidataSearch()
        {
            if (this.CouponBrandID.SelectedValue == "-1" && this.CouponTypeID.SelectedValue == "-1")
            {
                ShowWarning(Resources.MessageTips.NoSearchCondition);
                return false;
            }
            return true;
        }

    }
}