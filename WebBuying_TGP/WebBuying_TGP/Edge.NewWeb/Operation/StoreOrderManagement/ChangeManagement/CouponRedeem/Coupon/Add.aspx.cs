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
using Edge.Web.Controllers.Operation.CouponManagement.ChangeManagement.CouponRedeem;
using Edge.Web.Controllers;
using System.Text.RegularExpressions;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponRedeem.Coupon
{
    public partial class Add : PageBase
    {
        CouponRedeemController controller;
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
                    Edge.Web.Tools.ControlTool.BindCouponTypeWithoutBrand(CouponTypeID, "CouponTypeID in (" + Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(Request["StoreID"]), 2) + ") order by CouponTypeCode");
                }
                else
                {
                    Edge.Web.Tools.ControlTool.BindCouponType(CouponTypeID, " 1>2");
                }

                Tools.ControlTool.BindBatchID(BatchCouponID);

                RegisterCloseEvent(this.btnCloseSearch);
            }
            controller = SVASessionInfo.CouponRedeemController;
        }

        protected void btnAddSearchItem_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();
            List<string> idList = GetSelectedRowIndexArrayFromHiddenField();

            if (string.IsNullOrEmpty(this.txtActualTxnAmount.Text))
            {
                ShowWarning(Resources.MessageTips.EntryActualTxnAmount);
                return;
            }

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
                    dvSearch.RowFilter = "CouponNumber in (" + ids + ")";
                    dtSearch = dvSearch.ToTable();

                    //foreach (DataRowView drv in dvSearch)
                    //{
                    //    drv.Delete();
                    //}
                    //vsDT.AcceptChanges();

                    //ViewState["SearchResult"] = vsDT;
                    ViewState["SearchResult"] = dtSearch;

                }
                else
                {
                    dtSearch = (DataTable)ViewState["SearchResult"];
                    //ViewState["SearchResult"] = ((DataTable)ViewState["SearchResult"]).Clone();
                    cbSearchAll.Checked = false;
                }

                #region 验证金额
                DataTable dt = ViewState["SearchResult"] as DataTable;
                decimal minCouponAmount = Tools.ConvertTool.ToDecimal(dt.Compute("min(CouponAmount)", "true").ToString());
                decimal inputCouponAmount = 0;
                decimal couponAmount = 0;

                inputCouponAmount = Tools.ConvertTool.ToDecimal(this.txtActualTxnAmount.Text.Trim());
                couponAmount = minCouponAmount;

                if (inputCouponAmount < 0)
                {
                    ShowWarning(Resources.MessageTips.EntryActualTxnAmount);
                    return;
                }
                if (inputCouponAmount > couponAmount)
                {
                    ShowWarning(Resources.MessageTips.EntryActualTxnAmountTooLarge);
                    return;
                }
                #endregion

                DataTable addDT = controller.ViewModel.CouponTable;

                //Add ActualTxnAmount
                for (int i = 0; i <= dtSearch.Rows.Count - 1; i++)
                {
                    decimal inputAmount = Tools.ConvertTool.ConverType<decimal>(this.txtActualTxnAmount.Text.Trim());
                    dtSearch.Rows[i]["ActualTxnAmount"] = inputAmount;
                }
                dtSearch.AcceptChanges();

                DataTable newSearchDT = Edge.Web.Tools.ConvertTool.CombineTheSameDatatable2(addDT, dtSearch, "CouponNumber");

                this.txtActualTxnAmount.Text = string.Empty;
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

            //
            if (!IsContinue(GetSearchDataTable(),false))
            {
                return;
            }
            this.SearchListGrid.PageIndex = 0;

            DataTable dt = GetSearchDataTable();

            //Add new column
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    Tools.DataTool.AddColumn(dt, "ActualTxnAmount", 0.00);
            //    Tools.DataTool.AddColumn(dt, "ForfeitAmount", 0.00);
            //}

            ViewState["SearchResult"] = dt;
            BindCouponGrid();
        }

        protected void BtnScanStart_Click(object sender, EventArgs e)
        {
            ClearGird(this.SearchListGrid);
            ViewState["SearchResult"] = null;

            ChangeControlStatus(true);
            //this.CouponNumber.Focus();
            this.CouponUID.Focus();
        }
        protected void BtnScanStop_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(false);
        }
        private void ChangeControlStatus(bool status)
        {
            this.BtnScanStart.Hidden = status;
            this.BtnScanStop.Hidden = !status;
            this.BtnAddScan.Hidden = !status;

            this.btnSearch.Enabled = !status;
            this.CouponTypeID.Enabled = !status;
            this.BatchCouponID.Enabled = !status;
            this.CouponCount.Enabled = !status;
            //this.CouponUID.Enabled = !status;
            this.CouponTypeID.SelectedIndex = 0;

            this.CouponNumber.Enabled = !status;

            this.CouponUID.Text = string.Empty;
            this.CouponNumber.Text = string.Empty;
        }
        protected void BtnAddScan_Click(object sender, EventArgs e)
        {
            if (this.BtnAddScan.Hidden)
            {
                return;
            }

            //Scan标记
            ViewState["IsScan"] = true;

            string couponUID = this.CouponUID.Text.Trim();
            int top = string.IsNullOrEmpty(this.CouponCount.Text) ? 1 : Convert.ToInt32(this.CouponCount.Text);
            if (string.IsNullOrEmpty(couponUID))
            {
                ShowWarning(Resources.MessageTips.CouponUIDCannotBeEmpty);
                return;
            }

            //校验UID中不能包含字母
            if (Regex.Matches(couponUID, "[a-zA-Z]").Count > 0)
            {
                ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90312"));
                return;
            }

            this.SearchListGrid.PageIndex = 0;
            Edge.SVA.BLL.Coupon bll = new SVA.BLL.Coupon();
            Edge.SVA.BLL.CouponUIDMap bll1 = new Edge.SVA.BLL.CouponUIDMap();
            Edge.SVA.Model.CouponUIDMap model = bll1.GetModel(couponUID);

            //不需要补齐GC所做的逻辑
            int coupontypeid = model == null ? 0 : Convert.ToInt32(model.CouponTypeID);
            Edge.SVA.BLL.CouponType blltype = new SVA.BLL.CouponType();
            Edge.SVA.Model.CouponType modeltype = coupontypeid == 0 ? null : blltype.GetModel(coupontypeid);
            string endcouponuid = (Convert.ToInt64(couponUID) + (top - 1)).ToString();
            if (modeltype == null)
            {
                ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90312"));
                return;
            }
            if (modeltype.UIDCheckDigit == 1)
            {
                endcouponuid = (Convert.ToInt64(couponUID.Substring(0, couponUID.Length - 1)) + (top - 1)).ToString() + "9";
            }

            if (!ValidataStore(model)) return;

            DataTable dt = null;
            DataSet newds = null;
            if (top > 1)
            {
                //newds = bll.GetListForBatchOperation(top, string.Format(@" Coupon.Status in ( {0} )", (int)CouponController.CouponStatus.Activated) + " and CouponUIDMap.CouponUID >='" + couponUID
                //            + "' and Coupon.CouponTypeID =( select top 1 CouponTypeID from Coupon where Coupon.CouponNumber >=( select CouponNumber from CouponUIDMap where CouponUID='" + couponUID + "'))"
                //            , "CouponUIDMap.CouponUID ASC ");
                newds = bll.GetListForBatchOperation(top, string.Format(@" Coupon.Status in ( {0} )", (int)CouponController.CouponStatus.Activated) + " and CouponUIDMap.CouponUID >='" + couponUID
                        + "' and CouponUIDMap.CouponUID <='" + endcouponuid + "' and Coupon.CouponTypeID =" + coupontypeid, "CouponUIDMap.CouponUID ASC ");
            }
            else
            {
                newds = bll.GetListForBatchOperation(top, string.Format(@" Coupon.Status in ( {0} )", (int)CouponController.CouponStatus.Activated) + " and CouponUIDMap.CouponUID ='" + couponUID + "'"
                         , "CouponUIDMap.CouponUID ASC ");
            }

            if (newds.Tables[0].Rows.Count <= 0)
            {
                ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                return;
            }
            Tools.DataTool.AddColumn(newds.Tables[0], "ActualTxnAmount", 0.00);
            Tools.DataTool.AddColumn(newds.Tables[0], "ForfeitAmount", 0.00);

            ViewState["Newds"] = newds.Tables[0];

            if (!IsContinue(newds.Tables[0], true)) return;

            //if (ViewState["SearchResult"] != null)
            //{
            //    dt = ViewState["SearchResult"] as DataTable;
            //    dt = Edge.Web.Tools.ConvertTool.CombineTheSameDatatable2(newds.Tables[0], dt, "CouponUID");
            //}
            //else
            //{
            //    dt = newds.Tables[0];
            //}

            //ViewState["SearchResult"] = dt;

            ShowTable();

            dt = ViewState["SearchResult"] as DataTable;
            //查出数据后要将UID清空
            if (dt != null && dt.Rows.Count > 0)
            {
                this.CouponUID.Text = string.Empty;
            }

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
            //ViewState["Page"] = true;//表示添加过金额列
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
                string strWhere = string.Format(" Coupon.Status in ( {0} )", (int)CouponController.CouponStatus.Activated);
                string filedOrder = " Coupon.CouponNumber ASC ";

                if (couponTypeID == "-1")
                {
                    couponTypeID = Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(Request["StoreID"]), 2);
                }

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

                ViewState["SearchResult"] = ds.Tables[0];

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
                //Add new column(dt.Columns.Count=11表示已添加过下面2列 则不需再次添加)               
                if (dt != null && dt.Rows.Count > 0 && dt.Columns.Count< 11)
                {
                    Tools.DataTool.AddColumn(dt, "ActualTxnAmount", 0.00);
                    Tools.DataTool.AddColumn(dt, "ForfeitAmount", 0.00);                    
                }
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
            //翻页标志置为false
            //ViewState["Page"] = false;

            btnAddSearchItem.Enabled = SearchListGrid.RecordCount > 0 ? true : false;

            //if (ViewState["SearchResult"] != null)
            //{
            //    DataTable dt = ViewState["SearchResult"] as DataTable;
            //    if (dt == null) return;

            //    if (dt.Rows.Count <= 0) return;

            //    int couponTypeID = Tools.ConvertTool.ToInt(dt.Rows[0]["CouponTypeID"].ToString());
            //    Edge.SVA.Model.CouponType couponType = new Edge.SVA.BLL.CouponType().GetModel(couponTypeID);

            //    if (couponType == null) return;
            //}
        }

        protected override void RegisterGrid_OnPageIndexChange(object sender, GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            base.RegisterGrid_OnPageIndexChange(sender, e);

            //ViewState["Page"] = true;//表示添加过金额列
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
            //    string couponTypeids = Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(Request["StoreID"]), 2);
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
            //    string couponTypeids = Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(Request["StoreID"]), 2);
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
        protected bool IsContinue(DataTable dt, bool IsScan)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                Edge.SVA.BLL.CouponType coupontype = new SVA.BLL.CouponType();
                int j = dt.Rows.Count - 1;
                string firstnumber = "";
                string lastnumber = "";
                string coupontypeid = dt.Rows[0]["CouponTypeID"].ToString();
                Edge.SVA.Model.CouponType model = coupontype.GetModel(Convert.ToInt32(coupontypeid));
                int startindex = model.CouponNumPattern == null ? 0 : model.CouponNumPattern.Length;
                int digit = 0;


                if (!IsScan)
                {
                    if (string.IsNullOrEmpty(this.CouponNumber.Text))
                    {
                        firstnumber = dt.Rows[0]["CouponNumber"].ToString();
                    }
                    else
                    {
                        firstnumber = this.CouponNumber.Text.Trim();
                    }
                    lastnumber = dt.Rows[j]["CouponNumber"].ToString();

                    if (model.CouponCheckdigit == true)
                    {
                        digit = 1;
                    }

                }
                else
                {
                    firstnumber = this.CouponUID.Text.Trim();
                    lastnumber = dt.Rows[j]["CouponUID"].ToString();

                    if (model.UIDCheckDigit == 1)
                    {
                        digit = 1;
                    }
                }
                
                long startcoupon = Convert.ToInt64(firstnumber.Substring(startindex, firstnumber.Length - startindex - digit));
                long endcoupon = Convert.ToInt64(lastnumber.Substring(startindex, lastnumber.Length - startindex - digit));
                long couponqty = string.IsNullOrEmpty(this.CouponCount.Text) ? 0 : Convert.ToInt64(this.CouponCount.Text);

                if (endcoupon - startcoupon != j)
                {
                    //ViewState["SearchResult"] = dt;
                    ShowConfirmDialog(Messages.Manager.MessagesTool.instance.GetMessage("10030"), "", MessageBoxIcon.Question, WindowContact.GetShowReference("~/PublicForms/Confirm.aspx"), "");
                    return false;
                }
                if (dt.Rows.Count < couponqty)
                {
                    //ViewState["SearchResult"] = dt;
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
            }
            if (Convert.ToBoolean(ViewState["IsScan"]))
            {
                ShowTable();

                //查出数据后要将UID清空
                this.CouponUID.Text = string.Empty;
            }
            BindCouponGrid();
        }

        protected void WindowEnough_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            if (Convert.ToBoolean(ViewState["IsScan"]))
            {
                ShowTable();
            }
            BindCouponGrid();

            if (Convert.ToBoolean(ViewState["IsScan"]) == true)
            {
                //查出数据后要将UID清空
                this.CouponUID.Text = string.Empty;
            }
        }

        protected bool ValidataStore(Edge.SVA.Model.CouponUIDMap model)
        {
            if (model == null)
            {
                ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                return false;
            }
            Edge.SVA.BLL.CouponTypeStoreCondition bll = new SVA.BLL.CouponTypeStoreCondition();
            DataTable dt = bll.GetList(" CouponTypeID = " + model.CouponTypeID + " and StoreConditionType = 2 and ConditionType = 3 ").Tables[0];

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
            DataTable dtstore = bllstore.GetList(" BrandID in (select ConditionID from CouponTypeStoreCondition where CouponTypeID = " + model.CouponTypeID + " and StoreConditionType = 2 and ConditionType = 1)").Tables[0];
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

            ShowWarning(string.Format(Messages.Manager.MessagesTool.instance.GetMessage("90406"), "CouponNumber"));
            return false;
        }

        public void ShowTable()
        {
            DataTable newdt = ViewState["Newds"] as DataTable;
            DataTable showdt = new DataTable();
            if (ViewState["SearchResult"] != null)
            {
                DataTable dt = ViewState["SearchResult"] as DataTable;
                showdt = Edge.Web.Tools.ConvertTool.CombineTheSameDatatable2(dt, newdt, "CouponUID");
            }
            else
            {
                showdt = newdt;
            }

            ViewState["Newds"] = null;
            ViewState["SearchResult"] = showdt;
        }
    }
}