using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using System.Data;
using FineUI;
using Edge.Web.Controllers.Operation.StoreOrderManagement.ShipmentStoreOrder;

namespace Edge.Web.Operation.StoreOrderManagement.ShipmentStoreOrder
{
    public partial class Approve : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (!hasRight)
                    {
                        return;
                    }
                    btnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
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
                        Edge.SVA.Model.Ord_ShipmentOrder_H mode = new Edge.SVA.BLL.Ord_ShipmentOrder_H().GetModel(id);

                        DataRow dr = dt.NewRow();
                        dr["TxnNo"] = id;
                        dr["ApproveCode"] = ShipmentStoreOrderController.Approve(mode, out isSuccess);

                        if (isSuccess)
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Approve Success :" + id);

                            dr["ApprovalMsg"] = Resources.MessageTips.ApproveCode;
                            ExportFile(id);
                        }
                        else
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Approve Failed :" + id);
                            dr["ApprovalMsg"] = Resources.MessageTips.ApproveError;
                        }

                        dt.Rows.Add(dr);
                    }
                    this.Grid1.DataSource = dt;
                    this.Grid1.DataBind();
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Approve Shipment Store Order :" + ex);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }
        }

        private void ExportFile(string id)
        {
            Edge.Web.Controllers.Operation.StoreOrderManagement.ReceiveStoreOrder.ReceiveStoreOrderController controller = new Edge.Web.Controllers.Operation.StoreOrderManagement.ReceiveStoreOrder.ReceiveStoreOrderController();
            DataSet ds = new DataSet();
            ds = controller.ExportStoreReceiveData(id, 1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //string pathToFiles = System.Web.HttpContext.Current.Server.MapPath("/UploadedFiles");
                string pathToFiles = "C:\\TestPaths\\1167\\HQExportFiles\\"; //"C:\\WebBuying\\Exported Files\\";
                string filename = pathToFiles + id + ".428";
                SaveCSV(ds, filename);

                SendReceoveOrderViaEmail(id);
            }
        }


    }
}
