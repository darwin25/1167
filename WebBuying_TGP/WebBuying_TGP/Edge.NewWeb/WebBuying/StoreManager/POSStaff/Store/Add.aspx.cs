using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.POSStaff;
using System.Data;
using Edge.Web.Tools;
using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Edge.Web.WebBuying.StoreManager.POSStaff.Store
{
    public partial class Add : PageBase
    {
        POSStaffController controller = new POSStaffController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(this.btnCloseSearch);

                controller.GetStoreList();
                ViewState["SearchResult"] = controller.ViewModel.StoreTable;
                BindSearchTable();
            }
            controller = SVASessionInfo.POSStaffController;
        }

        protected void BindSearchTable()
        {
            if (ViewState["SearchResult"] != null)//(controller.ViewModel.StoreTable != null)
            {
                DataTable dt = ViewState["SearchResult"] as DataTable;
                this.SearchListGrid.PageSize = webset.ContentPageNum;
                this.SearchListGrid.RecordCount = dt.Rows.Count; //controller.ViewModel.StoreTable.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.SearchListGrid.PageIndex + 1, this.SearchListGrid.PageSize);
                this.SearchListGrid.DataSource = viewDT;
                this.SearchListGrid.DataBind();
            }
            else
            {
                this.SearchListGrid.Reset();
            }
        }

        protected void btnAddSearchItem_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();
            List<string> idList = GetSelectedRowIndexArrayFromHiddenField();
            if (ViewState["SearchResult"] != null)
            {
                if (controller.ViewModel.StoreTable == null)
                {
                    controller.ViewModel.StoreTable = ((DataTable)ViewState["SearchResult"]).Clone();
                }
                DataTable addDTView = controller.ViewModel.StoreTable;
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
                    dvSearch.RowFilter = "StoreCode in (" + ids + ")";
                    dtSearch = dvSearch.ToTable();
                    //foreach (DataRowView drv in dvSearch)
                    //{
                    //    drv.Delete();
                    //}
                    //vsDT.AcceptChanges();
                    ViewState["SearchResult"] = vsDT;
                }
                else
                {
                    dtSearch = (DataTable)ViewState["SearchResult"];
                    ViewState["SearchResult"] = ((DataTable)ViewState["SearchResult"]).Clone();
                    cbSearchAll.Checked = false;
                }

                DataTable addDT = controller.ViewModel.StoreTable;
                DataTable newSearchDT = Edge.Web.Tools.ConvertTool.CombineTheSameDatatable2(addDT, dtSearch, "StoreCode");
                controller.ViewModel.StoreTable = newSearchDT;

                //返回界面时要清空查询记录
                ViewState["SearchResult"] = null;
            }
            CloseAndPostBack();
        }

        protected override void RegisterGrid_OnPageIndexChange(object sender, GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            base.RegisterGrid_OnPageIndexChange(sender, e);

            BindSearchTable();

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
    }
}