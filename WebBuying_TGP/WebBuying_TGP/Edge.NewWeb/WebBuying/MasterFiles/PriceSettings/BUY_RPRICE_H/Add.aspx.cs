using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H;
using System.IO;
using System.Data;
using Edge.DBUtility;
using System.Text;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_RPRICE_H, Edge.SVA.Model.BUY_RPRICE_H>
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

                SVASessionInfo.BuyingPriceController = null;

                InitData();
            }
            controller = SVASessionInfo.BuyingPriceController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();

            if (controller.ViewModel.MainTable != null)
            {
               
                controller.ViewModel.MainTable.RPriceCode = this.RPriceCode.Text.Trim();
                controller.ViewModel.MainTable.StoreCode = this.StoreCode.SelectedValue == "-1" ? null : this.StoreCode.SelectedValue;
                controller.ViewModel.MainTable.StoreGroupCode = this.StoreGroupCode.SelectedValue == "-1" ? null : this.StoreGroupCode.SelectedValue;
                controller.ViewModel.MainTable.StartDate = Convert.ToDateTime(this.StartDate.Text);
                controller.ViewModel.MainTable.EndDate = Convert.ToDateTime(this.EndDate.Text);
                controller.ViewModel.MainTable.CurrencyCode = this.CurrencyCode.SelectedValue == "-1" ? null : this.CurrencyCode.SelectedValue;
                controller.ViewModel.MainTable.CreatedBusDate = DateTime.Now;
                controller.ViewModel.MainTable.ApproveStatus = "P";
                controller.ViewModel.MainTable.CreatedOn = DateTime.Now;
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;

            }

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add RPrice Success Code:" + controller.ViewModel.MainTable.RPriceCode);
                InsetData();
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add RPrice Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.RPriceCode);
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
                    dr["RPriceCode"] = this.RPriceCode.Text.Trim();
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

        protected void InitData()
        {
            this.RPriceCode.Text = DALTool.GetREFNOCode("RPC");
            controller.BindStore(StoreCode);
            controller.BindStoreGroup(StoreGroupCode);
            controller.BindCurrencyCode(CurrencyCode);
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