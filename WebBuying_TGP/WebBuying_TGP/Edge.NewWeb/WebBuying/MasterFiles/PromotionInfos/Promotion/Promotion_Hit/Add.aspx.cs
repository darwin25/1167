using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebBuying.BasicViewModel;
using System.Data;
using System.IO;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Text;
using Edge.Security;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion.Promotion_Hit
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Promotion_Hit, PromotionHitViewModel>
    {
        BuyingNewPromotionController controller = new BuyingNewPromotionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(this.btnClose);

                InitData();

            }
            controller = SVASessionInfo.BuyingNewPromotionController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            PromotionHitViewModel item = this.GetAddObject();
            if (item != null)
            {
                item.OprFlag = "Add";
                item.HitOPName = this.HitOP.SelectedText;
                item.LogicalOprName = DALTool.GetLogicalOprName(this.HitLogicalOpr.SelectedValue);
                item.HitTypeName = this.HitType.SelectedText;
                item.HitItemName = this.HitItem.SelectedText;
                item.HitPluTable = controller.ViewModel.HitPluTable;
                if (!controller.ValidateHitIsExists(item))
                {
                    controller.AddPromotionHitViewModel(SVASessionInfo.SiteLanguage, item);
                    InsetDataHit();

                    CloseAndPostBack();
                }
                else
                {
                    ShowError("Data Duplicated");
                }
            }
            else
            {
                ShowError(Resources.MessageTips.UnKnownSystemError);
            }            
        }

        protected void InitData()
        {
            this.PromotionCode.Text = Request.Params["PromotionCode"].ToString();
        }

        #region 操作PLU表
        protected void btnHitPLUAdd_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("Promotion_Hit_PLU/Add.aspx?PromotionCode={0}", this.PromotionCode.Text)));
        }
        protected void btnClearAllHitPLUItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.Grid1);
            controller.ViewModel.HitPluTable = null;
        }
        protected void btnDeleteHitPLUItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.HitPluTable != null)
            {
                DataTable addDT = controller.ViewModel.HitPluTable;

                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    string EntityType = Grid1.DataKeys[row][0].ToString();
                    string EntityNum = Grid1.DataKeys[row][1].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["EntityType"].ToString().Trim() == EntityType && addDT.Rows[j]["EntityNum"].ToString().Trim() == EntityNum)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.HitPluTable = addDT;
                BindHitPLUList(controller.ViewModel.HitPluTable);
            }
        }
        private void BindHitPLUList(DataTable dt)
        {
            if (dt != null)
            {

                this.Grid1.PageSize = webset.ContentPageNum;
                this.Grid1.RecordCount = dt.Rows.Count;

                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.Grid1.PageIndex + 1, this.Grid1.PageSize);
                this.Grid1.DataSource = viewDT;
                this.Grid1.DataBind();

            }
            else
            {
                this.Grid1.PageSize = webset.ContentPageNum;
                this.Grid1.PageIndex = 0;
                this.Grid1.RecordCount = 0;
                this.Grid1.DataSource = null;
                this.Grid1.DataBind();
            }

            this.btnDeleteHitPLUItem.Enabled = btnClearAllHitPLUItem.Enabled = Grid1.RecordCount > 0 ? true : false;
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            BindHitPLUList(controller.ViewModel.HitPluTable);
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            BindHitPLUList(controller.ViewModel.HitPluTable);
        }

        protected void HitItem_SelectedChanged(object sender, EventArgs e)
        {
            string item = this.HitItem.SelectedValue;
            switch (item)
            {
                case "0":
                    btnHitPLUAdd.Enabled = btnDeleteHitPLUItem.Enabled = btnClearAllHitPLUItem.Enabled = false;
                    this.Grid1.Enabled = false;
                    ClearGird(Grid1);
                    break;
                default:
                    btnHitPLUAdd.Enabled = btnDeleteHitPLUItem.Enabled = btnClearAllHitPLUItem.Enabled = true;
                    this.Grid1.Enabled = true;
                    this.Form2.Hidden = false;
                    break;
            }
        }
        #endregion

        public void InsetDataHit()
        {
            if (!string.IsNullOrEmpty(this.ImportFile.ShortFileName))
            {
                //校验文件类型是否正确
                if (!ValidateFile(this.ImportFile.FileName))
                {
                    return;
                }
                StringBuilder sb = new StringBuilder();
                string pathFile = this.ImportFile.SaveToServer("Promotion_Hit_PLU");
                string path = Server.MapPath("~" + pathFile);
                System.Data.DataTable dt = ExcelTool.GetFirstSheet_New(path);
                #region 新增字段
                if (dt != null)
                {

                    sb.AppendFormat(" PromotionCode='{0}' and EntityType='1'", this.PromotionCode.Text.Trim());
                    sb.Append("  and EntityNum in (");
                    dt.Columns.Add("PromotionCode", typeof(string));
                    dt.Columns.Add("HitSeq", typeof(int));
                    dt.Columns.Add("EntityNum", typeof(string));
                    dt.Columns.Add("EntityType", typeof(int));
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["PromotionCode"] = PromotionCode.Text.Trim();
                        dr["HitSeq"] = HitSeq.Text.Trim();
                        //0：所有货品。EntityNum中为空1：EntityNum内容为 prodcode。 销售EntityNum中指定货品时，可以生效
                        //2：EntityNum内容为 DepartCode。。 销售EntityNum中指定部门的货品时，可以生效
                        //3：EntityNum内容为 TenderCode。 使用EntityNum中指定货币支付时，可以生效
                        dr["EntityType"] = "1";
                        sb.AppendFormat("'{0}'", dr["ProdCode"].ToString());
                        sb.Append(",");

                    }

                }
                #endregion
                //截取除最后一位的前面所有字符
                //同一促销编号下面的产品不能重复,先删除表中存在此促销编号的产品，然后新增
                Edge.SVA.BLL.Promotion_Hit_PLU bllhitplu = new SVA.BLL.Promotion_Hit_PLU();
                bllhitplu.Delete(sb.ToString().Substring(0, sb.ToString().Length - 1)+" )");
                ExecResult er = controller.InsetHitData(dt);
                if (er.Success)
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Import Promotion_Hit_PLU Success Code:" + controller.ViewModel.MainTable.PromotionCode);
                }
                else
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Import Promotion_Hit_PLU  Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.PromotionCode);
                }
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