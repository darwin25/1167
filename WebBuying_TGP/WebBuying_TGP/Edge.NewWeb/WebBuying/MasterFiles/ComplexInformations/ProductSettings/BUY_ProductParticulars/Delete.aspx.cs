using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_ProductParticulars
{
    public partial class Delete : PageBase
    {
        Tools.Logger logger = Tools.Logger.Instance;
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
                    logger.WriteOperationLog(this.PageName, "Delete");
                    Edge.SVA.BLL.BUY_ProductParticulars bll = new SVA.BLL.BUY_ProductParticulars();
                    string ids = Request.Params["ids"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning, ActiveWindow.GetHidePostBackReference());
                        return;
                    }
                    string[] idList = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string UnitCode in idList)
                    {
                        string prodcode = UnitCode.Substring(0, UnitCode.IndexOf('-'));
                        int lanID = Convert.ToInt32(UnitCode.Substring(UnitCode.IndexOf('-') + 1));
                        Edge.SVA.Model.BUY_ProductParticulars mode = bll.GetModel(prodcode, lanID);
                        if (mode != null)
                        {
                            bll.Delete(prodcode, lanID);
                        }
                        else
                        {
                            ShowWarning(Resources.MessageTips.NoData);
                            return;
                        }
                    }
                    Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                }
                catch (System.Exception ex)
                {
                    logger.WriteErrorLog(this.PageName, "Delete", ex);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }
        }
    }
}