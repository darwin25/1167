using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.DisableProduct
{
    /// <summary>
    /// 货品下架/上架审核
    /// 创建人：lisa
    /// 创建时间：2016-08-11
    /// </summary>
    public partial class Approve : PageBase
    {
        Tools.Logger logger = Tools.Logger.Instance;
        ProductModifyTempController controller = new ProductModifyTempController();
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
                    string ids = Request.Params["ids"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning, ActiveWindow.GetHidePostBackReference());
                        return;
                    }
                    logger.WriteOperationLog(this.PageName, "Approve");
                    foreach (string id in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        Edge.SVA.BLL.ProductModifyTemp bll = new SVA.BLL.ProductModifyTemp();
                        //更新状态
                        Edge.SVA.Model.ProductModifyTemp temp = bll.GetModel(id);
                        if (temp != null)
                        {
                            if (temp.Status != 0)
                            {
                                Alert.ShowInTop(Resources.MessageTips.TheStatausNotPending,"", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                                return;
                            }
                            else
                            {
                                temp.Status = 1;
                                temp.ProdCode = id;
                                bll.Update(temp);
                            }
                        }
                        else
                        {
                            Alert.ShowInTop("No Data", "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                            return;
                        }
                        //更新产品表状态
                        Edge.SVA.BLL.BUY_PRODUCT bllProduct = new Edge.SVA.BLL.BUY_PRODUCT();
                        Edge.SVA.Model.BUY_PRODUCT product = bllProduct.GetModel(id);
                        if (product != null)
                        {
                            product.NonSale = 1;
                           bllProduct.Update(product);
                        }
                        
                    }
                    Alert.ShowInTop(Resources.MessageTips.ApproveSuccess, "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                }
                catch (System.Exception ex)
                {
                    logger.WriteErrorLog(this.PageName, "Approve", ex);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }
        }
    }
}