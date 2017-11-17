using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H;
using Edge.Web.Tools;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.IO;
using Edge.DBUtility;
using System.Text;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_RPRICE_H, Edge.SVA.Model.BUY_RPRICE_H>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingPriceController controller = new BuyingPriceController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);


                //对详情表的操作
                this.WindowSearch.Title = "Search";
                if (this.AddResultListGrid.RecordCount == 0)
                {
                    this.btnClearAllResultItem.Enabled = false;
                }
                else
                {
                    this.btnClearAllResultItem.Enabled = true;
                }

                InitData();
            }
            controller = SVASessionInfo.BuyingPriceController;
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
                controller.LoadViewModel(Model.RPriceCode);

                if (this.StoreCode.SelectedValue != "-1")
                {
                    this.StoreGroupCode.Enabled = false;
                }
                else
                {
                    this.StoreGroupCode.Enabled = true;
                }
                if (this.StoreGroupCode.SelectedValue != "-1")
                {
                    this.StoreCode.Enabled = false;
                }
                else
                {
                    this.StoreCode.Enabled = true;
                }
                if (controller.ViewModel.SubTable != null)
                {
                    BindResultList(controller.ViewModel.SubTable);
                }
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                
                controller.ViewModel.MainTable.RPriceCode = this.RPriceCode.Text.Trim();
                controller.ViewModel.MainTable.StoreCode = this.StoreCode.SelectedValue == "-1" ? null : this.StoreCode.SelectedValue;
                controller.ViewModel.MainTable.StoreGroupCode = this.StoreGroupCode.SelectedValue == "-1" ? null : this.StoreGroupCode.SelectedValue;
                controller.ViewModel.MainTable.StartDate = Convert.ToDateTime(this.StartDate.Text);
                controller.ViewModel.MainTable.EndDate = Convert.ToDateTime(this.EndDate.Text);
                controller.ViewModel.MainTable.CurrencyCode = this.CurrencyCode.SelectedValue == "-1" ? null : this.CurrencyCode.SelectedValue;
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;
            }

            ExecResult er = controller.Update(); //controller.Update();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Price Success Code:" + controller.ViewModel.MainTable.RPriceCode);
                InsetData();
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Price Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.RPriceCode);
                ShowSaveFailed(er.Message);
            }

        }


        public void InsetData()
        {
            if (!string.IsNullOrEmpty(this.ImportFile.ShortFileName))
            {
                //校验文件类型是否正确
                if (!ValidateFile(this.ImportFile.FileName))
                {
                    return;
                }
                StringBuilder sb = new StringBuilder();
                string pathFile = this.ImportFile.SaveToServer("BUY_RPRICE_D");
                string path = Server.MapPath("~" + pathFile);
                System.Data.DataTable dt = ExcelTool.GetFirstSheet(path);

                sb.AppendFormat(" RPriceCode='{0}' and RPriceTypeCode='2'", this.RPriceCode.Text.Trim());
                sb.Append("  and ProdCode in (");
                dt.Columns.Add("RPriceCode", typeof(string));
                dt.Columns.Add("RPriceTypeCode", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    dr["RPriceCode"] = RPriceCode.Text.Trim();
                    dr["RPriceTypeCode"] = 2;
                    sb.AppendFormat("'{0}'", dr["ProdCode"].ToString());
                    sb.Append(",");
                }
                //截取除最后一位的前面所有字符
                //同一促销编号下面的产品不能重复,先删除表中存在此促销编号的产品，然后新增
                Edge.SVA.BLL.BUY_RPRICE_D blld = new SVA.BLL.BUY_RPRICE_D();
                blld.DeleteStr(sb.ToString().Substring(0, sb.ToString().Length - 1) + " )");
                ExecResult er = controller.InsetData(dt);
                if (er.Success)
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Import BUY_RPRICE_D Success Code:" + controller.ViewModel.MainTable.RPriceCode);
                }
                else
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Import BUY_RPRICE_D  Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.RPriceCode);
                }
            }
        }

        protected void StoreCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreCode.SelectedValue != "-1")
            {
                this.StoreGroupCode.Enabled = false;
            }
            else
            {
                this.StoreGroupCode.Enabled = true;
            }
        }

        protected void StoreGroupCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreGroupCode.SelectedValue != "-1")
            {
                this.StoreCode.Enabled = false;
            }
            else
            {
                this.StoreCode.Enabled = true;
            }
        }


        #region 操作详情表
        protected void btnViewSearch_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("BUY_RPRICE_D/Add.aspx?RPriceCode={0}", this.RPriceCode.Text)));
        }

        protected void btnClearAllResultItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.AddResultListGrid);
            controller.ViewModel.SubTable = null;
        }
        protected void btnDeleteResultItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.SubTable != null)
            {
                DataTable addDT = controller.ViewModel.SubTable;

                foreach (int row in AddResultListGrid.SelectedRowIndexArray)
                {
                    string storecode = AddResultListGrid.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["KeyID"].ToString().Trim() == storecode)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.SubTable = addDT;

                BindResultList(controller.ViewModel.SubTable);

            }
        }

        private void BindResultList(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid.PageIndex + 1, this.AddResultListGrid.PageSize);
                this.AddResultListGrid.DataSource = viewDT;
                this.AddResultListGrid.DataBind();

            }
            else
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.PageIndex = 0;
                this.AddResultListGrid.RecordCount = 0;
                this.AddResultListGrid.DataSource = null;
                this.AddResultListGrid.DataBind();
            }

            this.btnDeleteResultItem.Enabled = btnClearAllResultItem.Enabled = AddResultListGrid.RecordCount > 0 ? true : false;
        }

        protected void AddResultListGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid.PageIndex = e.NewPageIndex;

            BindResultList(controller.ViewModel.SubTable);
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            BindResultList(controller.ViewModel.SubTable);
        }
        #endregion

        protected void InitData()
        {
            controller.BindStore(StoreCode);
            controller.BindStoreGroup(StoreGroupCode);
            controller.BindCurrencyCode(CurrencyCode);
        }
        //校验文件是否为允许类型
        protected bool ValidateFile(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                filename = Path.GetExtension(filename).TrimStart('.');
                if (!webset.ImporBIFileType.ToLower().Split('|').Contains(filename))
                {
                    ShowWarning(Resources.MessageTips.FileUpLoadFailed.Replace("{0}", webset.ImporBIFileType.Replace("|", ",")));
                    return false;
                }
            }
            return true;
        }
    }
}