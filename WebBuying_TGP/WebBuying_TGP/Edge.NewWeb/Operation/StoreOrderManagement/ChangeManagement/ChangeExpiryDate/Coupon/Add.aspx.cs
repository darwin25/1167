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
using Edge.Web.Controllers.Operation.CouponManagement.ChangeManagement.ChangeExpiryDate;
using Edge.Web.Controllers;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.ChangeExpiryDate.Coupon
{
    public partial class Add : PageBase
    {
        ChangeExpiryDateController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(Request["StoreID"]))
                {
                    Edge.Web.Tools.ControlTool.BindCouponTypeWithoutBrand(CouponTypeID, "CouponTypeID in (" + Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(Request["StoreID"]), 1) + ") order by CouponTypeCode");
                }
                else
                {
                    Edge.Web.Tools.ControlTool.BindCouponType(CouponTypeID, " 1>2");
                }

                Tools.ControlTool.BindBatchID(BatchCouponID);

                RegisterCloseEvent(this.btnCloseSearch);
            }
            controller = SVASessionInfo.ChangeExpiryDateController;
        }

        protected void btnAddSearchItem_Click(object sender, EventArgs e)
        {
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

                    //foreach (int row in SearchListGrid.SelectedRowIndexArray)
                    //{
                    //    ids += string.Format("{0},", "'" + SearchListGrid.DataKeys[row][0].ToString() + "'");
                    //}
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
                    dvSearch.RowFilter = "CouponNumber in (" + ids + ")";
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
                DataTable newSearchDT = Edge.Web.Tools.ConvertTool.CombineTheSameDatatable2(addDT, dtSearch, "CouponNumber");
                controller.ViewModel.CouponTable = newSearchDT;

                //返回界面时要清空查询记录
                ViewState["SearchResult"] = null;
            }
            CloseAndPostBack();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearGird(this.SearchListGrid);
            if (!ValidaData())
            {
                return;
            }

            Edge.SVA.BLL.CouponUIDMap bll1 = new SVA.BLL.CouponUIDMap();
            Edge.SVA.Model.CouponUIDMap modelmap = null;
            DataSet ds = new DataSet();
            //校验不能在此店铺激活的CouponNumber
            if (this.CouponNumber.Text != "" && this.CouponUID.Text == "")
            {
                ds = bll1.GetList(" CouponNumber = '" + this.CouponNumber.Text + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    modelmap = bll1.GetModel(ds.Tables[0].Rows[0]["CouponUID"].ToString());
                    if (!ValidataStore(modelmap)) return;
                }
            }
            //校验不能在此店铺激活的CouponUID
            if (this.CouponNumber.Text == "" && this.CouponUID.Text != "")
            {
                modelmap = bll1.GetModel(this.CouponUID.Text);

                if (modelmap != null)
                {
                    if (!ValidataStore(modelmap)) return;
                }
            }

            DataTable dt = GetSearchDataTable();
            ViewState["SearchResult"] = dt;

            if (!IsContinue(GetSearchDataTable()))
            {
                return;
            }
            this.SearchListGrid.PageIndex = 0;
            //DataTable dt = GetSearchDataTable();
            //ViewState["SearchResult"] = dt;
            BindCouponGrid();
        }

        protected void CouponTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CouponTypeID.SelectedValue != "-1")
            {
                Tools.ControlTool.BindBatchID(BatchCouponID, Tools.ConvertTool.ConverType<int>(CouponTypeID.SelectedValue));
            }
            else
            {
                Tools.ControlTool.BindBatchID(BatchCouponID);
            }
        }

        protected void SearchListGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            SearchListGrid.PageIndex = e.NewPageIndex;
            BindCouponGrid();
        }

        private DataTable GetSearchDataTable()
        {
            try
            {
                Edge.SVA.BLL.Coupon bll = new Edge.SVA.BLL.Coupon();

                int top = Edge.Web.Tools.ConvertTool.ConverType<int>(CouponCount.Text.Trim());
                int batchCouponID = Edge.Web.Tools.ConvertTool.ConverType<int>(BatchCouponID.Text.Trim());
                string couponNumber = CouponNumber.Text.Trim();
                string couponTypeID = CouponTypeID.SelectedValue;

                string strWhere = string.Empty;
                if (!string.IsNullOrEmpty(webset.CouponExpiryDateStatusEnable))
                {
                    strWhere = string.Format(" Coupon.Status in ( {0} )", webset.CouponExpiryDateStatusEnable);
                }
                else
                {
                    strWhere = string.Format(" Coupon.Status in ( {0} )", "-1");
                }
                string filedOrder = " Coupon.CouponNumber ASC ";

                if (couponTypeID == "-1")
                {
                    couponTypeID = Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(Request["StoreID"]), 1);
                }

                //strWhere = GetCouponSearchStrWhere(top, batchCouponID, couponNumber, couponTypeID, this.CouponUID.Text.Trim(), strWhere);
                if (top > 0 && couponNumber == "" && this.CouponUID.Text != "")
                {
                    Edge.SVA.BLL.CouponUIDMap bll1 = new SVA.BLL.CouponUIDMap();
                    Edge.SVA.Model.CouponUIDMap model = bll1.GetModel(this.CouponUID.Text);
                    couponNumber = model.CouponNumber;
                    couponTypeID = model.CouponTypeID.ToString();
                    strWhere = GetCouponSearchStrWhere(top, batchCouponID, couponNumber, couponTypeID, "", strWhere);
                }
                else if (top > 0 && couponNumber != "" && this.CouponUID.Text != "")
                {
                    strWhere = GetCouponSearchStrWhere(top, batchCouponID, this.CouponNumber.Text, couponTypeID, "", strWhere);
                }
                else
                {
                    if (this.CouponNumber.Text != "" && this.CouponTypeID.SelectedValue == "-1")
                    {
                        Edge.SVA.Model.Coupon model = bll.GetModel(this.CouponNumber.Text);
                        couponTypeID = model == null ? "-1" : model.CouponTypeID.ToString();
                    }
                    strWhere = GetCouponSearchStrWhere(top, batchCouponID, couponNumber, couponTypeID, this.CouponUID.Text.Trim(), strWhere);
                }
                //Display message
                int count = bll.GetCount(strWhere);

                if (count <= 0)
                {
                    ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                    return null;
                }

                if ((top > webset.MaxSearchNum) || ((count > webset.MaxSearchNum) && top <= 0))
                {
                    top = webset.MaxSearchNum;
                    ShowWarning(Resources.MessageTips.IsMaxSearchLimit);
                }

                DataSet ds = bll.GetListForBatchOperation(top, strWhere, filedOrder);

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
                this.SearchListGrid.DataSource = Tools.DALTool.GetCouponViewDataTable(viewDT);
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
            //List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

            //List<int> nextSelectedRowIndexArray = new List<int>();
            //int nextStartPageIndex = SearchListGrid.PageIndex * SearchListGrid.PageSize;
            //for (int i = nextStartPageIndex, count = Math.Min(nextStartPageIndex + SearchListGrid.PageSize, SearchListGrid.RecordCount); i < count; i++)
            //{
            //    string id = SearchListGrid.DataKeys[i][0].ToString();
            //    if (ids.Contains(id))
            //    {
            //        nextSelectedRowIndexArray.Add(i - nextStartPageIndex);
            //    }
            //}
            //SearchListGrid.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();

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
        protected void cbSearchAll_OnCheckedChanged(object sender, System.EventArgs e)
        {
            SetGirdSelectAll(SearchListGrid, cbSearchAll.Checked);
            if (!cbSearchAll.Checked)
            {
                hfSelectedIDS.Text = string.Empty;
            } 
        }

        protected bool ValidaData()
        {
            int top = Edge.Web.Tools.ConvertTool.ConverType<int>(CouponCount.Text.Trim());
            int batchCouponID = Edge.Web.Tools.ConvertTool.ConverType<int>(BatchCouponID.SelectedValue);
            string couponNumber = CouponNumber.Text.Trim();
            string couponTypeID = CouponTypeID.SelectedValue;

            if ((top <= 0) && (batchCouponID <= 0) && string.IsNullOrEmpty(couponNumber) && couponTypeID == "-1" && string.IsNullOrEmpty(this.CouponUID.Text.Trim()))
            {
                ShowWarning(Resources.MessageTips.NoSearchCondition);
                return false;
            }

            if (top > webset.MaxSearchNum)
            {

                ShowWarning(Resources.MessageTips.IsMaxSearchLimit);
                return false;
            }
            if (top > 0 && couponNumber != "" && this.CouponUID.Text != "")
            {
                Edge.SVA.BLL.CouponUIDMap bll1 = new SVA.BLL.CouponUIDMap();
                Edge.SVA.Model.CouponUIDMap model = bll1.GetModel(this.CouponUID.Text);
                if (model == null)
                {
                    ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                    return false;
                }
                else
                {
                    if (couponNumber != model.CouponNumber)
                    {
                        ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                        return false;
                    }
                }
            }
            //if (top > 0 && this.CouponUID.Text != "" && couponTypeID == "-1")
            //{
            //    string couponTypeids = Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(Request["StoreID"]), 1);
            //    List<string> idlist = new List<string>();
            //    foreach (var item in couponTypeids.Split(','))
            //    {
            //        idlist.Add(item);
            //    }

            //    Edge.SVA.BLL.CouponUIDMap bll1 = new SVA.BLL.CouponUIDMap();
            //    Edge.SVA.Model.CouponUIDMap model = bll1.GetModel(this.CouponUID.Text);
            //    if (model == null)
            //    {
            //        return false;
            //    }
            //    int i = 0;
            //    while (idlist.Count > i)
            //    {
            //        if (idlist[i] != model.CouponTypeID.ToString())
            //        {
            //            i++;
            //        }
            //        else
            //        {
            //            return true;
            //        }
            //    }
            //    ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
            //    return false;

            //}
            //if (top > 0 && this.CouponNumber.Text != "" && couponTypeID == "-1")
            //{
            //    string couponTypeids = Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(Request["StoreID"]), 1);
            //    List<string> idlist = new List<string>();
            //    foreach (var item in couponTypeids.Split(','))
            //    {
            //        idlist.Add(item);
            //    }

            //    Edge.SVA.BLL.Coupon bll1 = new SVA.BLL.Coupon();
            //    Edge.SVA.Model.Coupon model = bll1.GetModel(this.CouponNumber.Text);
            //    if (model == null)
            //    {
            //        return false;
            //    }
            //    int i = 0;
            //    while (idlist.Count > i)
            //    {
            //        if (idlist[i] != model.CouponTypeID.ToString())
            //        {
            //            i++;
            //        }
            //        else
            //        {
            //            return true;
            //        }
            //    }
            //    if (model == null)
            //    {
            //        ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
            //        return false;
            //    }
            //}
            if (top > 0 && this.CouponUID.Text != "")
            {
                Edge.SVA.BLL.CouponUIDMap bll1 = new SVA.BLL.CouponUIDMap();
                Edge.SVA.Model.CouponUIDMap model = bll1.GetModel(this.CouponUID.Text);
                if (model == null)
                {
                    ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                    return false;
                }
            }
            if (top > 0 && this.CouponNumber.Text != "")
            {
                Edge.SVA.BLL.Coupon bll1 = new SVA.BLL.Coupon();
                Edge.SVA.Model.Coupon model = bll1.GetModel(this.CouponNumber.Text);
                if (model == null)
                {
                    ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                    return false;
                }
            }
            return true;
        }
        protected bool IsContinue(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                //ViewState["SearchResult"] = dt;

                Edge.SVA.BLL.CouponType coupontype = new SVA.BLL.CouponType();
                int j = dt.Rows.Count - 1;
                string firstnumber = dt.Rows[0]["CouponNumber"].ToString();
                string lastnumber = dt.Rows[j]["CouponNumber"].ToString();
                string coupontypeid = dt.Rows[0]["CouponTypeID"].ToString();
                Edge.SVA.Model.CouponType model = coupontype.GetModel(Convert.ToInt32(coupontypeid));
                int startindex = model.CouponNumPattern == null ? 0 : model.CouponNumPattern.Length;
                int digit = 0;
                if (model.CouponCheckdigit == true)
                {
                    digit = 1;
                }

                long startcoupon = Convert.ToInt64(firstnumber.Substring(startindex, firstnumber.Length - startindex - digit));
                long endcoupon = Convert.ToInt64(lastnumber.Substring(startindex, lastnumber.Length - startindex - digit));

                if (endcoupon - startcoupon != j)
                {
                    ShowConfirmDialog(Messages.Manager.MessagesTool.instance.GetMessage("10030"), "", MessageBoxIcon.Question, WindowContact.GetShowReference("~/PublicForms/Confirm.aspx"), "");
                    return false;
                }

                long couponqty = string.IsNullOrEmpty(this.CouponCount.Text) ? 0 : Convert.ToInt64(this.CouponCount.Text);
                if (dt.Rows.Count < couponqty)
                {
                    ShowConfirmDialog(Messages.Manager.MessagesTool.instance.GetMessage("90444"), "", MessageBoxIcon.Question, WindowEnough.GetShowReference("~/PublicForms/Confirm.aspx"), "");
                    return false;
                }
            }

            return true;
        }

        protected void WindowContact_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["SearchResult"];
            if (dt != null && dt.Rows.Count > 0)
            {
                long couponqty = string.IsNullOrEmpty(this.CouponCount.Text) ? 0 : Convert.ToInt64(this.CouponCount.Text);
                if (dt.Rows.Count < couponqty)
                {
                    ShowConfirmDialog(Messages.Manager.MessagesTool.instance.GetMessage("90444"), "", MessageBoxIcon.Question, WindowEnough.GetShowReference("~/PublicForms/Confirm.aspx"), "");
                    return;
                }
                BindCouponGrid();
            }
        }

        protected void WindowEnough_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindCouponGrid();
        }

        protected bool ValidataStore(Edge.SVA.Model.CouponUIDMap model)
        {
            if (model == null)
            {
                ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                return false;
            }
            Edge.SVA.BLL.CouponTypeStoreCondition bll = new SVA.BLL.CouponTypeStoreCondition();
            DataTable dt = bll.GetList(" CouponTypeID = " + model.CouponTypeID + " and StoreConditionType = 1 and ConditionType = 3 ").Tables[0];

            int i = 0;
            while (dt.Rows.Count > i)
            {
                if (Request["StoreID"].ToString() != dt.Rows[i]["ConditionID"].ToString())
                {
                    i++;
                }
                else
                {
                    return true;
                }
            }
            Edge.SVA.BLL.Store bllstore = new SVA.BLL.Store();
            DataTable dtstore = bllstore.GetList(" BrandID in (select ConditionID from CouponTypeStoreCondition where CouponTypeID = " + model.CouponTypeID + " and StoreConditionType = 1 and ConditionType = 1)").Tables[0];
            i = 0;
            while (dtstore.Rows.Count > i)
            {
                if (Request["StoreID"].ToString() != dtstore.Rows[i]["StoreID"].ToString())
                {
                    i++;
                }
                else
                {
                    return true;
                }
            }

            ShowWarning(string.Format(Messages.Manager.MessagesTool.instance.GetMessage("90404"), "CouponNumber"));
            return false;
        }

    }
}