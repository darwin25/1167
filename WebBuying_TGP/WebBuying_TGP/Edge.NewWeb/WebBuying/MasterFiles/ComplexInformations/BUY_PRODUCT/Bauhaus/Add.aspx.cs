using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using System.IO;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus
{
    /// <summary>
    /// bauhuas货品添加
    /// 创建人：Lisa
    /// 创建时间：2016-02-25
    /// </summary>
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT, Edge.SVA.Model.BUY_PRODUCT>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        int LanguageId = 0;
        #region 公用业务逻辑类全局变量
        BuyingProductController controller = new BuyingProductController();
        BUY_PRODUCT_ADD_BAUController bauhausController = new BUY_PRODUCT_ADD_BAUController();
        Edge.SVA.BLL.BUY_PRODUCT_CLASSIFY _classFyBLL = new SVA.BLL.BUY_PRODUCT_CLASSIFY();
        Edge.SVA.BLL.BUY_Product_Particulars _particularsBLL = new SVA.BLL.BUY_Product_Particulars();
        Edge.SVA.BLL.BUY_SUPPROD _SUPPRODBLL = new SVA.BLL.BUY_SUPPROD();
        Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU _BauhausProduct = new SVA.BLL.BUY_PRODUCT_ADD_BAU();
        Edge.SVA.BLL.SEASON _SeaSonBLL = new SVA.BLL.SEASON();
        Edge.SVA.BLL.Gender _GenderBLL = new SVA.BLL.Gender();
        Edge.SVA.BLL.MATERIAL_IN _MATERIAL_INBLL = new SVA.BLL.MATERIAL_IN();
        Edge.SVA.BLL.MATERIAL_OUT _MATERIAL_OUTBLL = new SVA.BLL.MATERIAL_OUT();
        Edge.SVA.BLL.LanguageMap _mapBLL = new SVA.BLL.LanguageMap();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingProductController = null;

                InitData();
            }
            controller = SVASessionInfo.BuyingProductController;
        }


        protected void StoreBrandCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.StoreBrandCode.SelectedValue) || this.StoreBrandCode.SelectedValue == "-1")
            {
                controller.BindDepart(this.DepartCode);
                controller.BindStore(this.StoreCode);
            }
            else
            {
                ControlTool.BindBrandStoreDepart(this.DepartCode, "StoreBrandCode='" + this.StoreBrandCode.SelectedValue + "'");
                ControlTool.BindBrandStore(this.StoreCode, "StoreBrandCode='" + this.StoreBrandCode.SelectedValue + "'");
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();
            if (controller.ViewModel.MainTable != null)
            {
                //货品编号
                controller.ViewModel.MainTable.ProdCode = this.ProdCode.Text;
                //品牌编号
                controller.ViewModel.MainTable.BrandCode = this.BrandCode.SelectedValue;
                //店铺品牌
                controller.ViewModel.MainTable.StoreBrandCode = this.StoreBrandCode.SelectedValue;
                //货品颜色
                controller.ViewModel.MainTable.ColorCode = this.ColorCode.SelectedText;
                //货品尺寸
                controller.ViewModel.MainTable.ProductSizeCode = this.ProductSizeCode.SelectedText;
                //校验图片类型是否正确
                if (!ValidateImg(this.ProdPicFile.FileName))
                {
                    return;
                }
                //货品图片
                controller.ViewModel.MainTable.ProdPicFile = this.ProdPicFile.SaveToServer("ProdPic");
                //货品名称1
                controller.ViewModel.MainTable.ProdDesc1 = this.ProdDesc1.Text;
                //货品名称2
                controller.ViewModel.MainTable.ProdDesc2 = this.ProdDesc2.Text;
                //货品名称3
                controller.ViewModel.MainTable.ProdDesc3 = this.ProdDesc3.Text;
                //下架
                controller.ViewModel.MainTable.NonSale = Convert.ToInt32(this.RETIRED.SelectedValue);
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
                //新增BauHaus货品
                bauhausController.ViewModel.MainTable.ProdCode = this.ProdCode.Text;
                //公司名称
                bauhausController.ViewModel.MainTable.CompanyCode = this.CompanyID.SelectedText;
                //模型
                bauhausController.ViewModel.MainTable.MODEL = this.MODEL.Text;
                //年份
                if (!string.IsNullOrEmpty(this.Year.Text))
                {
                    bauhausController.ViewModel.MainTable.YEAR = Convert.ToInt32(this.Year.Text);
                }
                //点货点水平
                bauhausController.ViewModel.MainTable.REORDER_LEVEL = Convert.ToInt32(this.REORDER_LEVEL.Text);
                //下架日期
                if (!string.IsNullOrEmpty(this.RETIRE_DATE.Text))
                {
                    bauhausController.ViewModel.MainTable.RETIRE_DATE = Convert.ToDateTime(this.RETIRE_DATE.Text);
                }
                //SKU
                bauhausController.ViewModel.MainTable.SKU=this.SKU.Text ;
                //标准价格
                bauhausController.ViewModel.MainTable.Standard_Cost = Convert.ToDecimal(this.STANDARD_COST.Text);
                //出口价格
                bauhausController.ViewModel.MainTable.Export_Cost = Convert.ToDecimal(this.EXPORT_COST.Text);
                //平均价格
                bauhausController.ViewModel.MainTable.AVG_Cost = Convert.ToDecimal(this.AVG_Cost.Text);
                //尺寸范围
                bauhausController.ViewModel.MainTable.SIZE_RANGE = this.SIZE_RANGE.Text;
                //海关编码
                bauhausController.ViewModel.MainTable.HS_CODE = this.HS_CODE.Text;
                //首席运营官
                bauhausController.ViewModel.MainTable.COO = this.COO.Text;
                //设计师
                bauhausController.ViewModel.MainTable.DESIGNER = this.DESIGNER.Text;
                //买主
                bauhausController.ViewModel.MainTable.BUYER = this.BUYER.Text;
                //零售商
                bauhausController.ViewModel.MainTable.MERCHANDISER = this.MERCHANDISER.Text;
                //尺寸1
                bauhausController.ViewModel.MainTable.SizeM1 = Convert.ToDecimal(this.SizeM1.Text);
                //尺寸2
                bauhausController.ViewModel.MainTable.SizeM2 = Convert.ToDecimal(this.SizeM2.Text);
                //尺寸3
                bauhausController.ViewModel.MainTable.SizeM3 = Convert.ToDecimal(this.SizeM3.Text);
                //尺寸4
                bauhausController.ViewModel.MainTable.SizeM4 = Convert.ToDecimal(this.SizeM4.Text);
                //尺寸5
                bauhausController.ViewModel.MainTable.SizeM5 = Convert.ToDecimal(this.SizeM5.Text);
                //尺寸6
                bauhausController.ViewModel.MainTable.SizeM6 = Convert.ToDecimal(this.SizeM6.Text);
                //尺寸7
                bauhausController.ViewModel.MainTable.SizeM7 = Convert.ToDecimal(this.SizeM7.Text);
                //尺寸8
                bauhausController.ViewModel.MainTable.SizeM8 = Convert.ToDecimal(this.SizeM8.Text);

            }

            ExecResult er = controller.bauHausAdd();
            ExecResult er2 = bauhausController.Add();
            bool result1 = false;
            bool result2 = false;
            bool result3 = false;
            bool result4 = false;
            bool result5 = false;
            bool result6 = false;
            bool result7 = false;
            //季节
            Edge.SVA.Model.BUY_PRODUCT_CLASSIFY ClassifySeason = new SVA.Model.BUY_PRODUCT_CLASSIFY();
            ClassifySeason.ForeignkeyID = Convert.ToInt32(this.SEASON.SelectedValue);
            ClassifySeason.ForeignTable = "SEASON";
            ClassifySeason.ProdCode = this.ProdCode.Text;
            ClassifySeason.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
            ClassifySeason.CreatedOn = System.DateTime.Now;
            result1 = _classFyBLL.Add(ClassifySeason);

            //性别
            Edge.SVA.Model.BUY_PRODUCT_CLASSIFY ClassifyGender = new SVA.Model.BUY_PRODUCT_CLASSIFY();
            ClassifyGender.ForeignkeyID = Convert.ToInt32(this.SEX.SelectedValue);
            ClassifyGender.ForeignTable = "Gender";
            ClassifyGender.ProdCode = this.ProdCode.Text;
            ClassifyGender.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
            ClassifyGender.CreatedOn = System.DateTime.Now;
            result2 = _classFyBLL.Add(ClassifyGender);
            //InnerLayerMaterials
            if (!string.IsNullOrEmpty(this.MATERIAL_2.SelectedValue) && this.MATERIAL_2.SelectedValue!="-1")
            {
                Edge.SVA.Model.BUY_PRODUCT_CLASSIFY classfyMATERIALIN = new SVA.Model.BUY_PRODUCT_CLASSIFY();
                classfyMATERIALIN.ForeignkeyID = Convert.ToInt32(this.MATERIAL_2.SelectedValue);
                classfyMATERIALIN.ProdCode = this.ProdCode.Text;
                classfyMATERIALIN.ForeignTable = "MATERIAL_IN";
                classfyMATERIALIN.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                classfyMATERIALIN.CreatedOn = System.DateTime.Now;
                result3 = _classFyBLL.Add(classfyMATERIALIN);
            }
            //OuterLayerMaterials
            if (!string.IsNullOrEmpty(this.MATERIAL_1.SelectedValue) && this.MATERIAL_1.SelectedValue!="-1")
            {
                Edge.SVA.Model.BUY_PRODUCT_CLASSIFY classfyMATERIALOUT = new SVA.Model.BUY_PRODUCT_CLASSIFY();
                classfyMATERIALOUT.ForeignkeyID = Convert.ToInt32(this.MATERIAL_1.SelectedValue);
                classfyMATERIALOUT.ProdCode = this.ProdCode.Text;
                classfyMATERIALOUT.ForeignTable = "MATERIAL_OUT";
                classfyMATERIALOUT.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                classfyMATERIALOUT.CreatedOn = System.DateTime.Now;
                result4 = _classFyBLL.Add(classfyMATERIALOUT);
            }

            //产品描述，详细描述
            Edge.SVA.Model.BUY_Product_Particulars particulars = new SVA.Model.BUY_Product_Particulars();
            Edge.SVA.Model.LanguageMap map = new SVA.Model.LanguageMap();
            //描述1
            if (!string.IsNullOrEmpty(this.ShortDescription1.Text) && !string.IsNullOrEmpty(this.DetailedDescription1.Text))
            {
                map = _mapBLL.GetEntityByLanguageDesc("en-us");
                if (map != null)
                {
                    LanguageId = map.KeyID;
                }
                particulars.ProdCode = this.ProdCode.Text;
                particulars.LanguageID = LanguageId;
                particulars.MemoTitle1 = this.ShortDescription1.Text;
                particulars.Memo1 = this.DetailedDescription1.Text;
                result5 = _particularsBLL.Add(particulars);
            }
            //描述2
            if (!string.IsNullOrEmpty(this.ShortDescription2.Text) && !string.IsNullOrEmpty(this.DetailedDescription2.Text))
            {

                map = _mapBLL.GetEntityByLanguageDesc("zh-cn");
                if (map != null)
                {
                    LanguageId = map.KeyID;
                }
                particulars.ProdCode = this.ProdCode.Text;
                particulars.LanguageID = LanguageId;
                particulars.MemoTitle1 = this.ShortDescription2.Text;
                particulars.Memo1 = this.DetailedDescription2.Text;
                result6 = _particularsBLL.Add(particulars);
            }
            //描述3
            if (!string.IsNullOrEmpty(this.ShortDescription3.Text) && !string.IsNullOrEmpty(this.DetailedDescription3.Text))
            {
                map = _mapBLL.GetEntityByLanguageDesc("zh-hk");
                if (map != null)
                {
                    LanguageId = map.KeyID;
                }
                particulars.ProdCode = this.ProdCode.Text;
                particulars.LanguageID = LanguageId;
                particulars.MemoTitle1 = this.ShortDescription3.Text;
                particulars.Memo1 = this.DetailedDescription3.Text;
                result7 = _particularsBLL.Add(particulars);
            }


            if (er.Success && er2.Success )
            {
                Tools.Logger.Instance.WriteOperationLog("Add", "Add Product Success Code:" + controller.ViewModel.MainTable.ProdCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog("Add", "Add Product Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowSaveFailed(er.Message);
            }

        }

        protected void InitData()
        {
            controller.BindColor(this.ColorCode);
            controller.BindProSize(this.ProductSizeCode);
            //ControlTool.BindYear(this.Year);
            //绑定公司
            ControlTool.BindCompany(this.CompanyID);
            ControlTool.BindMATERIAL_IN(this.MATERIAL_1);
            ControlTool.BindMATERIAL_OUT(this.MATERIAL_2);
            //绑定季节
            ControlTool.BindSEASON(this.SEASON);
            //绑定店铺品牌
            ControlTool.BindStoreBrand(this.StoreBrandCode);
        }


        //校验图片文件是否为允许类型
        protected bool ValidateImg(string imgname)
        {
            if (!string.IsNullOrEmpty(imgname))
            {
                imgname = Path.GetExtension(imgname).TrimStart('.').ToLower();
                if (!webset.WebImageType.ToLower().Split('|').Contains(imgname))
                {
                    ShowWarning(Resources.MessageTips.ImgUpLoadFaild.Replace("{0}", webset.WebImageType.Replace("|", ",")));
                    return false;
                }
            }
            return true;
        }

        #region 操作价格
        protected void btnViewSearch2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ProdCode.Text))
            {
                return;
            }
            ExecuteJS(WindowSearch.GetShowReference(string.Format("BUY_RPRICE_M/Add.aspx?ProdCode={0}", this.ProdCode.Text)));
        }
        private void BindResultList2(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid2.PageSize = webset.ContentPageNum;
                this.AddResultListGrid2.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid2.PageIndex + 1, this.AddResultListGrid2.PageSize);
                this.AddResultListGrid2.DataSource = viewDT;
                this.AddResultListGrid2.DataBind();

            }
            else
            {
                this.AddResultListGrid2.PageSize = webset.ContentPageNum;
                this.AddResultListGrid2.PageIndex = 0;
                this.AddResultListGrid2.RecordCount = 0;
                this.AddResultListGrid2.DataSource = null;
                this.AddResultListGrid2.DataBind();
            }

            this.btnDeleteResultItem2.Enabled = btnClearAllResultItem2.Enabled = AddResultListGrid2.RecordCount > 0 ? true : false;
        }
        protected void AddResultListGrid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid2.PageIndex = e.NewPageIndex;

            BindResultList2(controller.ViewModel.dtRprice);
        }
        protected void btnClearAllResultItem2_Click(object sender, EventArgs e)
        {
            ClearGird(this.AddResultListGrid2);
            controller.ViewModel.dtRprice = null;
        }
        protected void btnDeleteResultItem2_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.dtRprice != null)
            {
                DataTable addDT = controller.ViewModel.dtRprice;

                foreach (int row in AddResultListGrid2.SelectedRowIndexArray)
                {
                    string storecode = AddResultListGrid2.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["KeyID"].ToString().Trim() == storecode)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.dtRprice = addDT;

                BindResultList2(controller.ViewModel.dtRprice);

            }
        }
        #endregion
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            BindResultList2(controller.ViewModel.dtRprice);
        }
    }
}