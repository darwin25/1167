using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCTSTYLE
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
                    Edge.SVA.BLL.BUY_PRODUCTSTYLE bll = new SVA.BLL.BUY_PRODUCTSTYLE();
                    string ids = Request.Params["ids"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning, ActiveWindow.GetHidePostBackReference());
                        return;
                    }
                    string[] idList = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string UnitCode in idList)
                    {
                        string stylecode = UnitCode.Substring(0, UnitCode.IndexOf('-'));
                        string prodcode = UnitCode.Substring(UnitCode.IndexOf('-') + 1);
                        Edge.SVA.Model.BUY_PRODUCTSTYLE mode = bll.GetModel(stylecode, prodcode);
                        if (mode != null)
                        {
                            bll.Delete(stylecode, prodcode);
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