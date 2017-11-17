using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_PRODUCTCLASS;
using System.Data;
using System.Configuration;
using Edge.Security.Manager;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_PRODUCTCLASS
{
    public partial class List : PageBase
    {
        BuyingProductClassController controller = new BuyingProductClassController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData();
                SVASessionInfo.BuyingProductClassController = null;
            }
            controller = SVASessionInfo.BuyingProductClassController;
        }
        #region Events

        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            int menuId = Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0]);

        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grid1.SelectedRowIndexArray.Length > 0)
                {
                    foreach (int row in this.Grid1.SelectedRowIndexArray)
                    {
                        string id = Grid1.DataKeys[row][0].ToString();
                        Logger.Instance.WriteOperationLog(this.PageName, "Delete Tree Menu : " + id);

                        int idd = 0;
                        if (int.TryParse(id, out idd))
                        {
                            controller.DelTreeNode(idd);
                            string msg = string.Format(Resources.MessageTips.DeleteSuccess, Grid1.SelectedRowIndexArray.Length);
                            FineUI.Alert.ShowInTop(msg, MessageBoxIcon.Information);

                            BindGrid();
                        }
                        else
                        {
                            Logger.Instance.WriteErrorLog(" DeleteMenu ", " id is not number");
                            ShowError(Resources.MessageTips.UnKnownSystemError);
                        }
                    }
                }
                else
                {
                    Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.WriteErrorLog(" DeleteMenu ", "", ex);
                ShowError(Resources.MessageTips.UnKnownSystemError);
            }

        }

        #endregion

        private void LoadData()
        {
            btnNew.OnClientClick = Window1.GetShowReference("add.aspx", "Add");

            BindGrid();
        }

        private void BindGrid()
        {
            List<BuyingProdClassModel> prodmodel = GetProdModels();
            Grid1.DataSource = prodmodel;
            Grid1.DataBind();
        }

        public List<BuyingProdClassModel> GetProdModels()
        {
            List<BuyingProdClassModel> _prodmodel = new List<BuyingProdClassModel>();

            List<BuyingProdClassModel> newList = new List<BuyingProdClassModel>();

            DataSet ds = controller.GetTreeList("", SVASessionInfo.SiteLanguage.ToString());

            ResolveMenuCollection(ds.Tables[0], newList, 0, 0);

            _prodmodel = newList;

            return _prodmodel;
        }

        private int ResolveMenuCollection(DataTable oldList, List<BuyingProdClassModel> newList, int parentId, int level)
        {
            int count = 0;
            foreach (DataRow row in oldList.Rows)
            {
                if (row["ParentID"].ToString().Trim() == parentId.ToString())
                {
                    count++;

                    BuyingProdClassModel my = new BuyingProdClassModel();
                    newList.Add(my);
                    my.TreeLevel = level;
                    my.Id = ConvertTool.ConverType<int>(row["ProdClassID"].ToString());
                    my.Name = row["Description"].ToString();
                    my.Title = row["Description"].ToString();
                    my.ParentId = ConvertTool.ConverType<int>(row["ParentID"].ToString());
                    my.ProductSizeType = row["ProductSizeTypeName"].ToString();
                    level++;
                    int childCount = ResolveMenuCollection(oldList, newList, my.Id, level);
                    if (childCount == 0)
                    {
                        my.IsTreeLeaf = true;
                    }
                    level--;
                }
            }

            return count;
        }
    }
}