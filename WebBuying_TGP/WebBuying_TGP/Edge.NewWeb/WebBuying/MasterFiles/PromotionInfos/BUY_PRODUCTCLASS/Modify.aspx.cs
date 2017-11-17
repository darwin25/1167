using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_PRODUCTCLASS;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_PRODUCTCLASS
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCTCLASS, Edge.SVA.Model.BUY_PRODUCTCLASS>
    {
        BuyingProductClassController controller = new BuyingProductClassController();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //得到现有菜单
                //BindTree();
                BindDDL();
                InitData();
                
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingProductClassController = null;
            }
            controller = SVASessionInfo.BuyingProductClassController;
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
                controller.LoadViewModel(Model.ProdClassID);
            }
        }

        protected void btnSaveClose_Click(object sender, System.EventArgs e)
        {
            //controller.ViewModel.MainTable = this.GetUpdateObject();

            if (controller.ViewModel.MainTable != null)
            {
                if (!string.IsNullOrEmpty(this.ProdClassCode.Text.Trim()))
                {
                    controller.ViewModel.MainTable.ProdClassCode = this.ProdClassCode.Text.Trim();
                }
                if (!string.IsNullOrEmpty(this.ParentID.SelectedValue))
                {
                    controller.ViewModel.MainTable.ParentID = Convert.ToInt32(this.ParentID.SelectedValue);
                }
                else
                {
                    controller.ViewModel.MainTable.ParentID = -1;
                }
                if (!string.IsNullOrEmpty(this.ProductSizeType.SelectedValue))
                {
                    controller.ViewModel.MainTable.ProductSizeType = this.ProductSizeType.SelectedValue;
                }
                if (!string.IsNullOrEmpty(this.ProdClassDesc1.Text.Trim()))
                {
                    controller.ViewModel.MainTable.ProdClassDesc1 = this.ProdClassDesc1.Text;
                }
                if (!string.IsNullOrEmpty(this.ProdClassDesc2.Text.Trim()))
                {
                    controller.ViewModel.MainTable.ProdClassDesc2 = this.ProdClassDesc2.Text;
                }
                if (!string.IsNullOrEmpty(this.ProdClassDesc3.Text.Trim()))
                {
                    controller.ViewModel.MainTable.ProdClassDesc3 = this.ProdClassDesc3.Text;
                }
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;
            }
            ExecResult er = controller.Update();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update ProdClass Success Code:" + controller.ViewModel.MainTable.ProdClassCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update ProdClass Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdClassCode);
                ShowSaveFailed(er.Message);
            }
        }

        //private void BindTree()
        //{
        //    DataTable dt = controller.GetTreeList("", SVASessionInfo.SiteLanguage.ToString()).Tables[0];
        //    this.ParentID.Items.Clear();
        //    //加载树
        //    this.ParentID.Items.Add(new FineUI.ListItem("#", "0"));
        //    DataRow[] drs = dt.Select("ParentID= " + 0);

        //    foreach (DataRow dr in drs)
        //    {
        //        string nodeid = dr["ProdClassID"].ToString();
        //        string text = dr["Description"].ToString();
        //        text = "╋" + text;
        //        this.ParentID.Items.Add(new FineUI.ListItem(text, nodeid));
        //        int sonparentid = int.Parse(nodeid);
        //        string blank = "├";

        //        BindNode(sonparentid, dt, blank);

        //    }
        //    this.ParentID.DataBind();

        //}

        //private void BindNode(int parentid, DataTable dt, string blank)
        //{
        //    DataRow[] drs = dt.Select("ParentID= " + parentid);

        //    foreach (DataRow r in drs)
        //    {
        //        string nodeid = r["ProdClassID"].ToString();
        //        string text = r["Description"].ToString();
        //        text = blank + "『" + text + "』";

        //        this.ParentID.Items.Add(new FineUI.ListItem(text, nodeid));
        //        int sonparentid = int.Parse(nodeid);
        //        string blank2 = blank + "─";

        //        BindNode(sonparentid, dt, blank2);
        //    }
        //}

        private void BindDDL()
        {
            List<CustomPermissionCategory> mys = GetPRODUCTCLASS();

            // 绑定到下拉列表（启用模拟树功能）
            this.ParentID.EnableSimulateTree = true;
            this.ParentID.DataTextField = "Description";
            this.ParentID.DataValueField = "Id";
            this.ParentID.DataSimulateTreeLevelField = "TreeLevel";
            this.ParentID.DataSource = mys;
            this.ParentID.DataBind();

            // 选中根节点
            // ddlParent.SelectedValue = "0";
            this.ParentID.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });
        }


        #region Events

        public List<CustomPermissionCategory> GetPRODUCTCLASS()
        {
            List<CustomPermissionCategory> _customPermissionCategory = new List<CustomPermissionCategory>();

            List<CustomPermissionCategory> newList = new List<CustomPermissionCategory>();

            DataTable dt = controller.GetTreeList("", SVASessionInfo.SiteLanguage.ToString()).Tables[0];

            ResolveMenuCollection(dt, newList, 0, 0);

            _customPermissionCategory = newList;

            return _customPermissionCategory;
        }

        private int ResolveMenuCollection(DataTable oldList, List<CustomPermissionCategory> newList, int parentId, int level)
        {
            int count = 0;
            foreach (DataRow row in oldList.Rows)
            {
                if (row["ParentID"].ToString().Trim() == parentId.ToString())
                {
                    count++;

                    CustomPermissionCategory my = new CustomPermissionCategory();
                    newList.Add(my);
                    my.TreeLevel = level;
                    my.Id = ConvertTool.ConverType<int>(row["ProdClassID"].ToString());
                    my.Name = row["Description"].ToString();
                    my.Title = row["Description"].ToString();
                    my.ParentId = ConvertTool.ConverType<int>(row["ParentID"].ToString());
                    my.Description = row["Description"].ToString();
                    //my.IsModule = menu.IsModule;
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
        #endregion

        protected void InitData()
        {
            controller.BindProductSizeType(this.ProductSizeType);
            //switch (SVASessionInfo.SiteLanguage.ToLower())
            //{
            //    case "en-us":
            //        this.ProdClassDesc1.Hidden = false;
            //        this.ProdClassDesc2.Hidden = true;
            //        this.ProdClassDesc3.Hidden = true;
            //        break;
            //    case "zh-cn":
            //        this.ProdClassDesc1.Hidden = true;
            //        this.ProdClassDesc2.Hidden = false;
            //        this.ProdClassDesc3.Hidden = true;
            //        break;
            //    case "zh-hk":
            //        this.ProdClassDesc1.Hidden = true;
            //        this.ProdClassDesc2.Hidden = true;
            //        this.ProdClassDesc3.Hidden = false;
            //        break;
            //    default:
            //        this.ProdClassDesc1.Hidden = false;
            //        this.ProdClassDesc2.Hidden = true;
            //        this.ProdClassDesc3.Hidden = true;
            //        break;
            //}
        }
    }
}