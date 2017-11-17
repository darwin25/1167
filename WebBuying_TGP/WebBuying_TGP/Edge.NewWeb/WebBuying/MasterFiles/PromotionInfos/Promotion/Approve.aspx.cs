using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Edge.Web.Tools;
using System.Data;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion
{
    public partial class Approval : PageBase
    {
        BuyingNewPromotionController controller = new BuyingNewPromotionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    btnClose.OnClientClick = FineUI.ActiveWindow.GetHidePostBackReference();
                    if (!hasRight)
                    {
                        return;
                    }
                    string ids = Request.Params["ids"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    DataTable dt = new DataTable();
                    dt.Columns.Add("TxnNo", typeof(string));
                    dt.Columns.Add("ApproveCode", typeof(string));
                    dt.Columns.Add("ApprovalMsg", typeof(string));

                    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(ids, ",");

                    bool isSuccess = false;
                    foreach (string id in idList)
                    {
                        Edge.SVA.Model.Promotion_H mode = new Edge.SVA.BLL.Promotion_H().GetModel(id);

                        DataRow dr = dt.NewRow();
                        dr["TxnNo"] = id;
                        dr["ApproveCode"] = controller.ApprovePromotionForApproveCode(mode, out isSuccess);
                        if (isSuccess)
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Approve Promotion " + mode.PromotionCode + " " + Resources.MessageTips.ApproveCode);

                            dr["ApprovalMsg"] = Resources.MessageTips.ApproveCode;
                        }
                        else
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Approve Promotion " + mode.PromotionCode + " " + Resources.MessageTips.ApproveError);

                            dr["ApprovalMsg"] = Resources.MessageTips.ApproveError;
                        }
                        dt.Rows.Add(dr);
                    }
                    this.Grid1.DataSource = dt;
                    this.Grid1.DataBind();
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Approve " + ex);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }
        }
    }
}