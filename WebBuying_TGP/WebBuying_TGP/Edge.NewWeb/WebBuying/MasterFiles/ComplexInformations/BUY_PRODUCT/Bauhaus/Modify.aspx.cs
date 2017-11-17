using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using System.IO;
using Edge.Web.Tools;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus
{
    /// <summary>
    /// Bauhaus货品
    /// 创建时间：2016-02-26
    /// 创建人：Lisa
    /// </summary>
    public partial class Modify : PageBase
    {

        Tools.Logger logger = Tools.Logger.Instance;
        int LanguageId = 0;
        #region 公用业务逻辑类全局变量
        BuyingProductController productController = new BuyingProductController();
        BuyingProductPendingController controller = new BuyingProductPendingController();
        BUY_PRODUCT_ADD_BAU_PedingController bauhausController = new BUY_PRODUCT_ADD_BAU_PedingController();
        BUY_PRODUCT_ADD_BAUController bauhausProductController = new BUY_PRODUCT_ADD_BAUController();


        Edge.SVA.BLL.BUY_PRODUCT_Pending _productPending = new SVA.BLL.BUY_PRODUCT_Pending();
        Edge.SVA.BLL.BUY_PRODUCT_CLASSIFY_Pending _classFyBLL = new SVA.BLL.BUY_PRODUCT_CLASSIFY_Pending();
        Edge.SVA.BLL.BUY_PRODUCT_CLASSIFY _classProductFyBLL = new SVA.BLL.BUY_PRODUCT_CLASSIFY();
        Edge.SVA.BLL.BUY_Product_Particulars_Pending _particularsBLL = new SVA.BLL.BUY_Product_Particulars_Pending();
        Edge.SVA.BLL.BUY_Product_Particulars _particularsProductBLL = new SVA.BLL.BUY_Product_Particulars();
        Edge.SVA.BLL.BUY_SUPPROD _SUPPRODBLL = new SVA.BLL.BUY_SUPPROD();
        Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending _BauhausProduct = new SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending();
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


                //对详情表的操作
                this.WindowSearch.Title = "Edit";
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
            controller = SVASessionInfo.BuyingProductPendingController;
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

                string prodCode = Request.Params["id"];
                hidProdCode.Text = prodCode;
                controller.LoadViewModel(prodCode);

                if (controller.ViewModel.MainTable != null)
                {

                    //货品编号
                    this.ProdCode.Text = controller.ViewModel.MainTable.ProdCode;
                    //品牌编号
                    this.BrandCode.SelectedValue = controller.ViewModel.MainTable.BrandCode;
                    //部门编号
                    this.DepartCode.SelectedValue = controller.ViewModel.MainTable.DepartCode;
                    //季节
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending ClassifySeason = _classFyBLL.GetPRODUCT_CLASSIFY(prodCode, "SEASON");
                    if (ClassifySeason != null)
                    {
                        //Edge.SVA.Model.SEASON season = _SeaSonBLL.GetModel(ClassifySeason.ForeignkeyID);
                        //if (season != null)
                        //{

                        this.SEASON.SelectedValue = ClassifySeason.ForeignkeyID.ToString();

                        //}

                    }
                    //性别
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending ClassifySex = _classFyBLL.GetPRODUCT_CLASSIFY(prodCode, "Gender");
                    if (ClassifySex != null)
                    {
                        this.SEX.SelectedValue = ClassifySex.ForeignkeyID.ToString();

                    }


                    //InnerLayerMaterials
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending classfyMATERIALIN = _classFyBLL.GetPRODUCT_CLASSIFY(prodCode, "MATERIAL_IN");
                    if (classfyMATERIALIN != null)
                    {
                        Edge.SVA.Model.MATERIAL_IN MATERIAL_IN = _MATERIAL_INBLL.GetModel(classfyMATERIALIN.ForeignkeyID);
                        if (MATERIAL_IN != null)
                        {

                            this.MATERIAL_2.SelectedValue = MATERIAL_IN.MATERIALID.ToString();
                        }
                    }
                    //OuterLayerMaterials
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending classfyMATERIALOUT = _classFyBLL.GetPRODUCT_CLASSIFY(prodCode, "MATERIAL_OUT");
                    if (classfyMATERIALOUT != null)
                    {
                        Edge.SVA.Model.MATERIAL_OUT MATERIAL_OUT = _MATERIAL_OUTBLL.GetModel(classfyMATERIALOUT.ForeignkeyID);
                        if (MATERIAL_OUT != null)
                        {

                            this.MATERIAL_1.SelectedValue = MATERIAL_OUT.MATERIALID.ToString();
                        }
                    }
                    //货品颜色
                    this.ColorCode.SelectedItem.Text = controller.ViewModel.MainTable.ColorCode;
                    //货品尺寸
                    this.ProductSizeCode.SelectedItem.Text = controller.ViewModel.MainTable.ProductSizeCode;
                    //产品图片
                    if (!string.IsNullOrEmpty(controller.ViewModel.MainTable.ProdPicFile))
                    {
                        this.FormLoad.Hidden = true;
                        this.FormReLoad.Hidden = false;
                        this.btnBack.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad.Hidden = false;
                        this.FormReLoad.Hidden = true;
                        this.btnBack.Hidden = true;
                    }
                    this.uploadFilePath.Text = controller.ViewModel.MainTable.ProdPicFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");


                    //条形码
                    if (controller.ViewModel.dtBarCode != null)
                    {
                        BindResultList(controller.ViewModel.dtBarCode);

                    }
                    //操作价格
                    if (controller.ViewModel.dtRprice != null && controller.ViewModel.dtRprice.Rows.Count > 0)
                    {
                        BindResultList2(controller.ViewModel.dtRprice);
                    }
                    //供应商产品
                    if (controller.ViewModel.dtSUPPROD != null && controller.ViewModel.dtSUPPROD.Rows.Count > 0)
                    {
                        BindResultList3(controller.ViewModel.dtSUPPROD);

                    }
                    //货品名称1
                    this.ProdDesc1.Text = controller.ViewModel.MainTable.ProdDesc1;
                    //货品名称2
                    this.ProdDesc2.Text = controller.ViewModel.MainTable.ProdDesc2;
                    //货品名称3
                    this.ProdDesc3.Text = controller.ViewModel.MainTable.ProdDesc3;
                    //描述，详细信息
                    DataSet ds = _particularsBLL.GetList(" ProdCode='" + prodCode + "'");
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                        {
                            LanguageId = Convert.ToInt32(item["LanguageID"]);
                            if (LanguageId == 1)
                            {
                                this.ShortDescription1.Text = item["MemoTitle1"].ToString();
                                this.DetailedDescription1.Text = item["Memo1"].ToString();
                            }
                            else if (LanguageId == 2)
                            {
                                this.ShortDescription2.Text = item["MemoTitle1"].ToString();
                                this.DetailedDescription2.Text = item["Memo1"].ToString();
                            }
                            else
                            {
                                this.ShortDescription3.Text = item["MemoTitle1"].ToString();
                                this.DetailedDescription3.Text = item["Memo1"].ToString();
                            }
                        }
                    }

                    //下架
                    if (controller.ViewModel.MainTable.NonSale == 0)
                    {
                        this.RETIRED.SelectedValue = "0";
                    }
                    else
                    {
                        this.RETIRED.SelectedValue = "1";
                    }

                    //修改时间
                    this.UpdatedOn.Text = ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.UpdatedOn.GetValueOrDefault());
                    //修改人
                    this.lblUpdatedBy.Text = Tools.DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    //审核时间
                    this.ApprovedOn.Text = ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.ApprovedOn.GetValueOrDefault());
                    //审核人
                    this.lblApprovedBy.Text = Tools.DALTool.GetUserName(controller.ViewModel.MainTable.ApprovedBy.GetValueOrDefault());

                    bauhausController.LoadViewModel(prodCode);
                    if (bauhausController.ViewModel.MainTablePeding != null)
                    {
                        //公司名称
                        if (!string.IsNullOrEmpty(bauhausController.ViewModel.MainTablePeding.CompanyCode))
                        {
                            this.CompanyID.SelectedValue = bauhausController.ViewModel.MainTablePeding.CompanyCode;
                        }
                        //年份

                        this.Year.Text = bauhausController.ViewModel.MainTablePeding.YEAR.ToString();

                        //SKU
                        this.SKU.Text = bauhausController.ViewModel.MainTablePeding.SKU;
                        //模型
                        this.MODEL.Text = bauhausController.ViewModel.MainTablePeding.MODEL;
                        //订货点水平
                        this.REORDER_LEVEL.Text = bauhausController.ViewModel.MainTablePeding.REORDER_LEVEL.ToString();
                        //下架时间
                        if (bauhausController.ViewModel.MainTable.RETIRE_DATE != null)
                        {
                            this.RETIRE_DATE.Text = Convert.ToDateTime(bauhausController.ViewModel.MainTablePeding.RETIRE_DATE).ToString("yyyy-MM-dd");
                        }
                        //标准价格
                        this.STANDARD_COST.Text = bauhausController.ViewModel.MainTablePeding.Standard_Cost.ToString();
                        //出口价格
                        this.EXPORT_COST.Text = bauhausController.ViewModel.MainTablePeding.Export_Cost.ToString();
                        //平均价格
                        this.AVG_Cost.Text = bauhausController.ViewModel.MainTablePeding.AVG_Cost.ToString();
                        //尺寸范围
                        this.SIZE_RANGE.Text = bauhausController.ViewModel.MainTablePeding.SIZE_RANGE;
                        //海关编码
                        this.HS_CODE.Text = bauhausController.ViewModel.MainTablePeding.HS_CODE;
                        //Coo
                        this.COO.Text = bauhausController.ViewModel.MainTablePeding.COO;
                        //设计师
                        this.DESIGNER.Text = bauhausController.ViewModel.MainTablePeding.DESIGNER;
                        //买主
                        this.BUYER.Text = bauhausController.ViewModel.MainTablePeding.BUYER;
                        //零售商
                        this.MERCHANDISER.Text = bauhausController.ViewModel.MainTablePeding.MERCHANDISER;
                        //尺寸1
                        this.SizeM1.Text = bauhausController.ViewModel.MainTablePeding.SizeM1.ToString();
                        //尺寸2
                        this.SizeM2.Text = bauhausController.ViewModel.MainTablePeding.SizeM2.ToString();
                        //尺寸3
                        this.SizeM3.Text = bauhausController.ViewModel.MainTablePeding.SizeM3.ToString();
                        //尺寸4
                        this.SizeM4.Text = bauhausController.ViewModel.MainTablePeding.SizeM4.ToString();
                        //尺寸5
                        this.SizeM5.Text = bauhausController.ViewModel.MainTablePeding.SizeM5.ToString();
                        //尺寸6
                        this.SizeM6.Text = bauhausController.ViewModel.MainTablePeding.SizeM6.ToString();
                        //尺寸7
                        this.SizeM7.Text = bauhausController.ViewModel.MainTablePeding.SizeM7.ToString();
                        //尺寸8
                        this.SizeM8.Text = bauhausController.ViewModel.MainTablePeding.SizeM8.ToString();
                    }

                }
                //产品表
                else
                {
                    productController.LoadViewModel(prodCode);
                    if (productController.ViewModel.MainTable != null)
                    {

                        //货品编号
                        this.ProdCode.Text = productController.ViewModel.MainTable.ProdCode;
                        //品牌编号
                        this.BrandCode.SelectedValue = productController.ViewModel.MainTable.BrandCode;
                        //部门编号
                        this.DepartCode.SelectedValue = productController.ViewModel.MainTable.DepartCode;
                        //季节
                        Edge.SVA.Model.BUY_PRODUCT_CLASSIFY ClassifySeason = _classProductFyBLL.GetPRODUCT_CLASSIFY(prodCode, "SEASON");
                        if (ClassifySeason != null)
                        {
                            //Edge.SVA.Model.SEASON season = _SeaSonBLL.GetModel(ClassifySeason.ForeignkeyID);
                            //if (season != null)
                            //{

                            this.SEASON.SelectedValue = ClassifySeason.ForeignkeyID.ToString();

                            //}

                        }
                        //性别
                        Edge.SVA.Model.BUY_PRODUCT_CLASSIFY ClassifySex = _classProductFyBLL.GetPRODUCT_CLASSIFY(prodCode, "Gender");
                        if (ClassifySex != null)
                        {
                            this.SEX.SelectedValue = ClassifySex.ForeignkeyID.ToString();

                        }


                        //InnerLayerMaterials
                        Edge.SVA.Model.BUY_PRODUCT_CLASSIFY classfyMATERIALIN = _classProductFyBLL.GetPRODUCT_CLASSIFY(prodCode, "MATERIAL_IN");
                        if (classfyMATERIALIN != null)
                        {
                            Edge.SVA.Model.MATERIAL_IN MATERIAL_IN = _MATERIAL_INBLL.GetModel(classfyMATERIALIN.ForeignkeyID);
                            if (MATERIAL_IN != null)
                            {

                                this.MATERIAL_2.SelectedValue = MATERIAL_IN.MATERIALID.ToString();
                            }
                        }
                        //OuterLayerMaterials
                        Edge.SVA.Model.BUY_PRODUCT_CLASSIFY classfyMATERIALOUT = _classProductFyBLL.GetPRODUCT_CLASSIFY(prodCode, "MATERIAL_OUT");
                        if (classfyMATERIALOUT != null)
                        {
                            Edge.SVA.Model.MATERIAL_OUT MATERIAL_OUT = _MATERIAL_OUTBLL.GetModel(classfyMATERIALOUT.ForeignkeyID);
                            if (MATERIAL_OUT != null)
                            {

                                this.MATERIAL_1.SelectedValue = MATERIAL_OUT.MATERIALID.ToString();
                            }
                        }
                        //货品颜色
                        this.ColorCode.SelectedItem.Text = productController.ViewModel.MainTable.ColorCode;
                        //货品尺寸
                        this.ProductSizeCode.SelectedItem.Text = productController.ViewModel.MainTable.ProductSizeCode;
                        //产品图片
                        if (!string.IsNullOrEmpty(productController.ViewModel.MainTable.ProdPicFile))
                        {
                            this.FormLoad.Hidden = true;
                            this.FormReLoad.Hidden = false;
                            this.btnBack.Hidden = false;
                        }
                        else
                        {
                            this.FormLoad.Hidden = false;
                            this.FormReLoad.Hidden = true;
                            this.btnBack.Hidden = true;
                        }
                        this.uploadFilePath.Text = productController.ViewModel.MainTable.ProdPicFile;

                        this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");


                        //条形码
                        if (productController.ViewModel.dtBarCode != null)
                        {
                            BindResultList(productController.ViewModel.dtBarCode);

                        }
                        //操作价格
                        if (productController.ViewModel.dtRprice != null && productController.ViewModel.dtRprice.Rows.Count > 0)
                        {
                            BindResultList2(productController.ViewModel.dtRprice);
                        }
                        //供应商产品
                        if (productController.ViewModel.dtSUPPROD != null && productController.ViewModel.dtSUPPROD.Rows.Count > 0)
                        {
                            BindResultList3(productController.ViewModel.dtSUPPROD);

                        }
                        //货品名称1
                        this.ProdDesc1.Text = productController.ViewModel.MainTable.ProdDesc1;
                        //货品名称2
                        this.ProdDesc2.Text = productController.ViewModel.MainTable.ProdDesc2;
                        //货品名称3
                        this.ProdDesc3.Text = productController.ViewModel.MainTable.ProdDesc3;
                        //描述，详细信息
                        DataSet ds = _particularsBLL.GetList(" ProdCode='" + prodCode + "'");
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                            {
                                LanguageId = Convert.ToInt32(item["LanguageID"]);
                                if (LanguageId == 1)
                                {
                                    this.ShortDescription1.Text = item["MemoTitle1"].ToString();
                                    this.DetailedDescription1.Text = item["Memo1"].ToString();
                                }
                                else if (LanguageId == 2)
                                {
                                    this.ShortDescription2.Text = item["MemoTitle1"].ToString();
                                    this.DetailedDescription2.Text = item["Memo1"].ToString();
                                }
                                else
                                {
                                    this.ShortDescription3.Text = item["MemoTitle1"].ToString();
                                    this.DetailedDescription3.Text = item["Memo1"].ToString();
                                }
                            }
                        }

                        //下架
                        if (productController.ViewModel.MainTable.NonSale == 0)
                        {
                            this.RETIRED.SelectedValue = "0";
                        }
                        else
                        {
                            this.RETIRED.SelectedValue = "1";
                        }
                        //修改时间
                        this.UpdatedOn.Text = ConvertTool.ToStringDateTime(productController.ViewModel.MainTable.UpdatedOn.GetValueOrDefault());
                        //修改人
                        this.lblUpdatedBy.Text = Tools.DALTool.GetUserName(productController.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                        //审核时间
                        this.ApprovedOn.Text = ConvertTool.ToStringDateTime(productController.ViewModel.MainTable.ApprovedOn.GetValueOrDefault());
                        //审核人
                        this.lblApprovedBy.Text = Tools.DALTool.GetUserName(productController.ViewModel.MainTable.ApprovedBy.GetValueOrDefault());
                        bauhausProductController.LoadViewModel(prodCode);
                        if (bauhausProductController.ViewModel.MainTable != null)
                        {
                            //公司名称
                            if (!string.IsNullOrEmpty(bauhausProductController.ViewModel.MainTable.CompanyCode))
                            {
                                this.CompanyID.SelectedValue = bauhausProductController.ViewModel.MainTable.CompanyCode;
                            }
                            //年份
                            this.Year.Text = bauhausProductController.ViewModel.MainTable.YEAR.ToString();

                            //SKU
                            this.SKU.Text = bauhausProductController.ViewModel.MainTable.SKU;
                            //模型
                            this.MODEL.Text = bauhausProductController.ViewModel.MainTable.MODEL;
                            //订货点水平
                            this.REORDER_LEVEL.Text = bauhausProductController.ViewModel.MainTable.REORDER_LEVEL.ToString();
                            //下架时间
                            if (bauhausProductController.ViewModel.MainTable.RETIRE_DATE != null)
                            {
                                this.RETIRE_DATE.Text = Convert.ToDateTime(bauhausProductController.ViewModel.MainTable.RETIRE_DATE).ToString("yyyy-MM-dd");
                            }
                            //标准价格
                            this.STANDARD_COST.Text = bauhausProductController.ViewModel.MainTable.Standard_Cost.ToString();
                            //出口价格
                            this.EXPORT_COST.Text = bauhausProductController.ViewModel.MainTable.Export_Cost.ToString();
                            //平均价格
                            this.AVG_Cost.Text = bauhausProductController.ViewModel.MainTable.AVG_Cost.ToString();
                            //尺寸范围
                            this.SIZE_RANGE.Text = bauhausProductController.ViewModel.MainTable.SIZE_RANGE;
                            //海关编码
                            this.HS_CODE.Text = bauhausProductController.ViewModel.MainTable.HS_CODE;
                            //Coo
                            this.COO.Text = bauhausProductController.ViewModel.MainTable.COO;
                            //设计师
                            this.DESIGNER.Text = bauhausProductController.ViewModel.MainTable.DESIGNER;
                            //买主
                            this.BUYER.Text = bauhausProductController.ViewModel.MainTable.BUYER;
                            //零售商
                            this.MERCHANDISER.Text = bauhausProductController.ViewModel.MainTable.MERCHANDISER;
                            //尺寸1
                            this.SizeM1.Text = bauhausProductController.ViewModel.MainTable.SizeM1.ToString();
                            //尺寸2
                            this.SizeM2.Text = bauhausProductController.ViewModel.MainTable.SizeM2.ToString();
                            //尺寸3
                            this.SizeM3.Text = bauhausProductController.ViewModel.MainTable.SizeM3.ToString();
                            //尺寸4
                            this.SizeM4.Text = bauhausProductController.ViewModel.MainTable.SizeM4.ToString();
                            //尺寸5
                            this.SizeM5.Text = bauhausProductController.ViewModel.MainTable.SizeM5.ToString();
                            //尺寸6
                            this.SizeM6.Text = bauhausProductController.ViewModel.MainTable.SizeM6.ToString();
                            //尺寸7
                            this.SizeM7.Text = bauhausProductController.ViewModel.MainTable.SizeM7.ToString();
                            //尺寸8
                            this.SizeM8.Text = bauhausProductController.ViewModel.MainTable.SizeM8.ToString();
                        }
                    }


                }
            }
        }

        //保存并Close
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            bool result1 = false;
            bool result2 = false;
            string str = "";
            try
            {
                logger.WriteOperationLog(this.PageName, " Update ");
                //修改BauHaus货品
                SVA.Model.BUY_PRODUCT_Pending productPeding = _productPending.GetModel(this.ProdCode.Text);
                if (productPeding == null)
                {
                    productPeding = new SVA.Model.BUY_PRODUCT_Pending();
                    //修改人
                    productPeding.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                    //修改时间
                    productPeding.CreatedOn = System.DateTime.Now;
                    str = "add";
                }
                else
                {
                    //修改人
                    productPeding.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                    //修改时间
                    productPeding.UpdatedOn = System.DateTime.Now;
                    str = "update";
                }
                //货品编号
                if (!string.IsNullOrEmpty(this.ProdCode.Text))
                {
                    productPeding.ProdCode = this.ProdCode.Text;
                }
                //品牌编号
                if (!string.IsNullOrEmpty(this.BrandCode.SelectedValue))
                {
                    productPeding.BrandCode = this.BrandCode.SelectedValue;
                }
                //部门编号
                if (!string.IsNullOrEmpty(this.DepartCode.SelectedValue))
                {
                    productPeding.DepartCode = this.DepartCode.SelectedValue;
                }
                //货品颜色
                if (!string.IsNullOrEmpty(this.ColorCode.SelectedText))
                {
                    productPeding.ColorCode = this.ColorCode.SelectedText;
                }
                //货品尺寸
                if (!string.IsNullOrEmpty(this.ProductSizeCode.SelectedText))
                {
                    productPeding.ProductSizeCode = this.ProductSizeCode.SelectedText;
                }
                if (!string.IsNullOrEmpty(this.ProdPicFile.ShortFileName) && this.FormLoad.Hidden == false)
                {
                    if (!ValidateImg(this.ProdPicFile.FileName))
                    {
                        return;
                    }
                    //货品图片
                    productPeding.ProdPicFile = this.ProdPicFile.SaveToServer("ProdPic");
                }
                else if (this.FormReLoad.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath.Text))
                {
                    if (!ValidateImg(this.uploadFilePath.Text))
                    {
                        return;
                    }
                    productPeding.ProdPicFile = this.uploadFilePath.Text;
                }
                //货品名称1
                if (!string.IsNullOrEmpty(this.ProdDesc1.Text))
                {
                    productPeding.ProdDesc1 = this.ProdDesc1.Text;
                }
                //货品名称2
                if (!string.IsNullOrEmpty(this.ProdDesc2.Text))
                {
                    productPeding.ProdDesc2 = this.ProdDesc2.Text;
                }
                //货品名称3
                if (!string.IsNullOrEmpty(this.ProdDesc3.Text))
                {
                    productPeding.ProdDesc3 = this.ProdDesc3.Text;
                }
                //下架
                if (!string.IsNullOrEmpty(this.RETIRED.SelectedValue))
                {
                    productPeding.NonSale = Convert.ToInt32(this.RETIRED.SelectedValue);
                }
                productPeding.Status = 0;

                if (!string.IsNullOrEmpty(str) && str != "add")
                {

                    result1 = _productPending.Update(productPeding);
                }
                else
                {
                    result1 = _productPending.Add(productPeding);
                }

                //修改BauHaus货品
                SVA.Model.BUY_PRODUCT_ADD_BAU_Pending addBAU = _BauhausProduct.GetModel(this.ProdCode.Text);
                if (addBAU == null)
                {
                    addBAU = new SVA.Model.BUY_PRODUCT_ADD_BAU_Pending();
                }
                if (!string.IsNullOrEmpty(this.ProdCode.Text))
                {
                    addBAU.ProdCode = this.ProdCode.Text;
                }
                //公司名称
                if (!string.IsNullOrEmpty(this.CompanyID.SelectedValue))
                {
                    addBAU.CompanyCode = this.CompanyID.SelectedValue;
                }
                if (!string.IsNullOrEmpty(this.SKU.Text))
                {
                    addBAU.SKU = this.SKU.Text;
                }
                //模型
                if (!string.IsNullOrEmpty(this.MODEL.Text))
                {
                    addBAU.MODEL = this.MODEL.Text;
                }
                //年份
                if (!string.IsNullOrEmpty(this.Year.Text))
                {
                    addBAU.YEAR = Convert.ToInt32(this.Year.Text);
                }
                //点货点水平
                if (!string.IsNullOrEmpty(this.REORDER_LEVEL.Text))
                {
                    addBAU.REORDER_LEVEL = Convert.ToInt32(this.REORDER_LEVEL.Text);
                }
                //下架日期
                if (!string.IsNullOrEmpty(this.RETIRE_DATE.Text))
                {
                    addBAU.RETIRE_DATE = Convert.ToDateTime(this.RETIRE_DATE.Text);
                }
                //标准价格
                if (!string.IsNullOrEmpty(this.STANDARD_COST.Text))
                {
                    addBAU.Standard_Cost = Convert.ToDecimal(this.STANDARD_COST.Text);
                }
                //出口价格
                if (!string.IsNullOrEmpty(this.EXPORT_COST.Text))
                {
                    addBAU.Export_Cost = Convert.ToDecimal(this.EXPORT_COST.Text);
                }
                //平均价格
                if (!string.IsNullOrEmpty(this.AVG_Cost.Text))
                {
                    addBAU.AVG_Cost = Convert.ToDecimal(this.AVG_Cost.Text);
                }
                //尺寸范围
                if (!string.IsNullOrEmpty(this.SIZE_RANGE.Text))
                {
                    addBAU.SIZE_RANGE = this.SIZE_RANGE.Text;
                }
                //海关编码
                if (!string.IsNullOrEmpty(this.HS_CODE.Text))
                {
                    addBAU.HS_CODE = this.HS_CODE.Text;
                }
                //首席运营官
                if (!string.IsNullOrEmpty(this.COO.Text))
                {
                    addBAU.COO = this.COO.Text;
                }
                //设计师
                if (!string.IsNullOrEmpty(this.DESIGNER.Text))
                {
                    addBAU.DESIGNER = this.DESIGNER.Text;
                }
                //买主
                if (!string.IsNullOrEmpty(this.BUYER.Text))
                {
                    addBAU.BUYER = this.BUYER.Text;
                }
                //零售商
                if (!string.IsNullOrEmpty(this.MERCHANDISER.Text))
                {
                    addBAU.MERCHANDISER = this.MERCHANDISER.Text;
                }
                //尺寸1
                if (!string.IsNullOrEmpty(this.SizeM1.Text))
                {
                    addBAU.SizeM1 = Convert.ToDecimal(this.SizeM1.Text);
                }
                //尺寸2
                if (!string.IsNullOrEmpty(this.SizeM2.Text))
                {
                    addBAU.SizeM2 = Convert.ToDecimal(this.SizeM2.Text);
                }
                //尺寸3
                if (!string.IsNullOrEmpty(this.SizeM3.Text))
                {
                    addBAU.SizeM3 = Convert.ToDecimal(this.SizeM3.Text);
                }
                //尺寸4
                if (!string.IsNullOrEmpty(this.SizeM4.Text))
                {
                    addBAU.SizeM4 = Convert.ToDecimal(this.SizeM4.Text);
                }
                //尺寸5
                if (!string.IsNullOrEmpty(this.SizeM5.Text))
                {
                    addBAU.SizeM5 = Convert.ToDecimal(this.SizeM5.Text);
                }
                //尺寸6
                if (!string.IsNullOrEmpty(this.SizeM6.Text))
                {
                    addBAU.SizeM6 = Convert.ToDecimal(this.SizeM6.Text);
                }
                //尺寸7
                if (!string.IsNullOrEmpty(this.SizeM7.Text))
                {
                    addBAU.SizeM7 = Convert.ToDecimal(this.SizeM7.Text);
                }
                //尺寸8
                if (!string.IsNullOrEmpty(this.SizeM8.Text))
                {
                    addBAU.SizeM8 = Convert.ToDecimal(this.SizeM8.Text);
                }
                if (!string.IsNullOrEmpty(str) && str != "add")
                {
                    result2 = _BauhausProduct.Update(addBAU);
                }
                else
                {
                    new Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending().Delete(this.ProdCode.Text);
                    result2 = _BauhausProduct.Add(addBAU);
                }
                //季节
                Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending ClassifySeason = _classFyBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "SEASON");
                if (ClassifySeason != null)
                {
                    str = "update";
                    ClassifySeason.UpdatedOn = Convert.ToDateTime(DateTime.Now);
                    ClassifySeason.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;

                }
                else
                {
                    str = "add";
                    ClassifySeason = new SVA.Model.BUY_PRODUCT_CLASSIFY_Pending();
                    ClassifySeason.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                    ClassifySeason.CreatedOn = Convert.ToDateTime(DateTime.Now);
                }
                if (!string.IsNullOrEmpty(this.SEASON.SelectedValue))
                {
                    ClassifySeason.ForeignkeyID = Convert.ToInt32(this.SEASON.SelectedValue);
                }
                ClassifySeason.ForeignTable = "SEASON";
                if (!string.IsNullOrEmpty(this.ProdCode.Text))
                {
                    ClassifySeason.ProdCode = this.ProdCode.Text;
                }
                if (!string.IsNullOrEmpty(str) && str != "add")
                {
                    _classFyBLL.Update(ClassifySeason);
                }
                else
                {
                    _classFyBLL.Add(ClassifySeason);
                }

                //性别
                Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending ClassifyGender = _classFyBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "Gender");
                if (ClassifyGender != null)
                {
                    str = "update";
                    ClassifyGender.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                    ClassifyGender.UpdatedOn = Convert.ToDateTime(DateTime.Now);

                }
                else
                {
                    str = "add";
                    ClassifyGender = new SVA.Model.BUY_PRODUCT_CLASSIFY_Pending();
                    ClassifyGender.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                    ClassifyGender.CreatedOn = Convert.ToDateTime(DateTime.Now);

                }
                if (!string.IsNullOrEmpty(this.SEX.SelectedValue))
                {
                    ClassifyGender.ForeignkeyID = Convert.ToInt32(this.SEX.SelectedValue);
                }
                ClassifyGender.ForeignTable = "Gender";
                if (!string.IsNullOrEmpty(this.ProdCode.Text))
                {
                    ClassifyGender.ProdCode = this.ProdCode.Text;
                }
                if (!string.IsNullOrEmpty(str) && str != "add")
                {

                    _classFyBLL.Update(ClassifyGender);
                }
                else
                {
                    _classFyBLL.Add(ClassifyGender);
                }
                Edge.SVA.Model.LanguageMap map = new SVA.Model.LanguageMap();
                Edge.SVA.Model.BUY_Product_Particulars_Pending particulars = null;
                //产品描述，详细描述
                if (!string.IsNullOrEmpty(this.ShortDescription1.Text) && !string.IsNullOrEmpty(this.DetailedDescription1.Text))
                {

                    map = _mapBLL.GetEntityByLanguageDesc("en-us");
                    if (map != null)
                    {
                        LanguageId = map.KeyID;//等于1
                    }
                    particulars = _particularsBLL.GetModel(this.ProdCode.Text, LanguageId);
                    if (particulars != null)
                    {
                        str = "update";

                    }
                    else
                    {
                        str = "add";
                        particulars = new SVA.Model.BUY_Product_Particulars_Pending();

                    }
                    if (!string.IsNullOrEmpty(this.ProdCode.Text))
                    {
                        particulars.ProdCode = this.ProdCode.Text;
                    }
                    particulars.LanguageID = LanguageId;
                    if (!string.IsNullOrEmpty(this.ShortDescription1.Text))
                    {
                        particulars.MemoTitle1 = this.ShortDescription1.Text;
                    }
                    if (!string.IsNullOrEmpty(this.DetailedDescription1.Text))
                    {
                        particulars.Memo1 = this.DetailedDescription1.Text;
                    }
                    if (!string.IsNullOrEmpty(str) && str != "add")
                    {
                        _particularsBLL.Update(particulars);
                    }
                    else
                    {
                        _particularsBLL.Add(particulars);
                    }
                }
                if (!string.IsNullOrEmpty(this.ShortDescription2.Text) && !string.IsNullOrEmpty(this.DetailedDescription2.Text))
                {

                    map = _mapBLL.GetEntityByLanguageDesc("zh-cn");
                    if (map != null)
                    {
                        LanguageId = map.KeyID;//等于2
                    }
                    particulars = _particularsBLL.GetModel(this.ProdCode.Text, LanguageId);
                    if (particulars != null)
                    {
                        str = "update";

                    }
                    else
                    {
                        str = "add";
                        particulars = new SVA.Model.BUY_Product_Particulars_Pending();
                    }
                    if (!string.IsNullOrEmpty(this.ProdCode.Text))
                    {
                        particulars.ProdCode = this.ProdCode.Text;
                    }
                    particulars.LanguageID = LanguageId;
                    if (!string.IsNullOrEmpty(this.ShortDescription2.Text))
                    {
                        particulars.MemoTitle1 = this.ShortDescription2.Text;
                    }
                    if (!string.IsNullOrEmpty(this.DetailedDescription2.Text))
                    {
                        particulars.Memo1 = this.DetailedDescription2.Text;
                    }
                    if (!string.IsNullOrEmpty(str) && str != "add")
                    {
                        _particularsBLL.Update(particulars);
                    }
                    else
                    {
                        _particularsBLL.Add(particulars);
                    }
                }
                if (!string.IsNullOrEmpty(this.ShortDescription3.Text) && !string.IsNullOrEmpty(this.DetailedDescription3.Text))
                {

                    map = _mapBLL.GetEntityByLanguageDesc("zh-hk");
                    if (map != null)
                    {
                        LanguageId = map.KeyID;//等于3
                    }
                    particulars = _particularsBLL.GetModel(this.ProdCode.Text, LanguageId);
                    if (particulars != null)
                    {
                        str = "update";

                    }
                    else
                    {
                        str = "add";
                        particulars = new SVA.Model.BUY_Product_Particulars_Pending();
                    }
                    if (!string.IsNullOrEmpty(this.ProdCode.Text))
                    {
                        particulars.ProdCode = this.ProdCode.Text;
                    }
                    particulars.LanguageID = LanguageId;
                    if (!string.IsNullOrEmpty(this.ShortDescription3.Text))
                    {
                        particulars.MemoTitle1 = this.ShortDescription3.Text;
                    }
                    if (!string.IsNullOrEmpty(this.DetailedDescription3.Text))
                    {
                        particulars.Memo1 = this.DetailedDescription3.Text;
                    }
                    if (!string.IsNullOrEmpty(str) && str != "add")
                    {
                        _particularsBLL.Update(particulars);
                    }
                    else
                    {
                        _particularsBLL.Add(particulars);
                    }
                }
                //InnerLayerMaterials
                if (!string.IsNullOrEmpty(this.MATERIAL_2.SelectedValue) && this.MATERIAL_2.SelectedValue != "-1")
                {
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending classfyMATERIALIN = _classFyBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "MATERIAL_IN");
                    if (classfyMATERIALIN != null)
                    {
                        str = "update";
                        classfyMATERIALIN.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                        classfyMATERIALIN.UpdatedOn = Convert.ToDateTime(DateTime.Now);

                    }
                    else
                    {
                        str = "add";
                        classfyMATERIALIN = new SVA.Model.BUY_PRODUCT_CLASSIFY_Pending();
                        classfyMATERIALIN.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                        classfyMATERIALIN.CreatedOn = Convert.ToDateTime(DateTime.Now);

                    }
                    classfyMATERIALIN.ForeignkeyID = Convert.ToInt32(this.MATERIAL_2.SelectedValue);
                    classfyMATERIALIN.ForeignTable = "MATERIAL_IN";
                    if (!string.IsNullOrEmpty(this.ProdCode.Text))
                    {
                        classfyMATERIALIN.ProdCode = this.ProdCode.Text;
                    }
                    if (!string.IsNullOrEmpty(str) && str != "add")
                    {
                        _classFyBLL.Update(classfyMATERIALIN);
                    }
                    else
                    {
                        _classFyBLL.Add(classfyMATERIALIN);
                    }
                }
                //OuterLayerMaterials
                if (!string.IsNullOrEmpty(this.MATERIAL_1.SelectedValue) && this.MATERIAL_1.SelectedValue != "-1")
                {
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending classfyMATERIALOUT = _classFyBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "MATERIAL_OUT");
                    if (classfyMATERIALOUT != null)
                    {
                        str = "update";
                        classfyMATERIALOUT.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                        classfyMATERIALOUT.UpdatedOn = Convert.ToDateTime(DateTime.Now);
                    }
                    else
                    {
                        str = "add";
                        classfyMATERIALOUT = new SVA.Model.BUY_PRODUCT_CLASSIFY_Pending();
                        classfyMATERIALOUT.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                        classfyMATERIALOUT.CreatedOn = Convert.ToDateTime(DateTime.Now);

                    }
                    classfyMATERIALOUT.ForeignkeyID = Convert.ToInt32(this.MATERIAL_1.SelectedValue);
                    classfyMATERIALOUT.ForeignTable = "MATERIAL_OUT";
                    if (!string.IsNullOrEmpty(this.ProdCode.Text))
                    {
                        classfyMATERIALOUT.ProdCode = this.ProdCode.Text;
                    }
                    if (!string.IsNullOrEmpty(str) && str != "add")
                    {
                        _classFyBLL.Update(classfyMATERIALOUT);
                    }
                    else
                    {
                        _classFyBLL.Add(classfyMATERIALOUT);
                    }

                }
                if (result1 == true && result2 == true)
                {
                    if (this.FormReLoad.Hidden == true && string.IsNullOrEmpty(productPeding.ProdPicFile))
                    {
                        DeleteFile(this.uploadFilePath.Text);
                    }
                    Tools.Logger.Instance.WriteOperationLog("Update", "Update Product Success Code:" + this.ProdCode.Text);
                    CloseAndPostBack();
                }
            }
            catch (Exception ex)
            {
                Tools.Logger.Instance.WriteOperationLog("Update", "Update Product Failed Code:" + this.ProdCode.Text);
                ShowSaveFailed(ex.Message);
            }


        }


        #region 操作条形码表

        protected void btnViewSearch_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("../BUY_BARCODE/Add.aspx?ProdCode={0}&types=productPending", this.ProdCode.Text)));
        }
        protected void btnClearAllResultItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.AddResultListGrid);
            controller.ViewModel.dtBarCode = null;
        }
        protected void btnDeleteResultItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.dtBarCode != null)
            {
                DataTable addDT = controller.ViewModel.dtBarCode;

                foreach (int row in AddResultListGrid.SelectedRowIndexArray)
                {
                    string storecode = AddResultListGrid.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["Barcode"].ToString().Trim() == storecode)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.dtBarCode = addDT;

                BindResultList(controller.ViewModel.dtBarCode);

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

            BindResultList(controller.ViewModel.dtBarCode);
        }

        #endregion

        #region 操作价格
        protected void btnViewSearch2_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("BUY_RPRICE_M/Add.aspx?ProdCode={0}&types=productPending", this.ProdCode.Text)));
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

        #region 操作供应商
        protected void btnViewSearch3_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("BUY_SUPPROD/Add.aspx?ProdCode={0}&types=productPending", this.ProdCode.Text)));
        }
        protected void btnClearAllResultItem3_Click(object sender, EventArgs e)
        {
            ClearGird(this.AddResultListGrid3);
            controller.ViewModel.dtSUPPROD = null;

        }
        protected void btnDeleteResultItem3_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.dtSUPPROD != null)
            {
                DataTable addDT = controller.ViewModel.dtSUPPROD;

                foreach (int row in AddResultListGrid3.SelectedRowIndexArray)
                {
                    string storecode = AddResultListGrid3.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["VendorCode"].ToString().Trim() == storecode)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.dtSUPPROD = addDT;

                BindResultList3(controller.ViewModel.dtSUPPROD);

            }
        }

        private void BindResultList3(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid3.PageSize = webset.ContentPageNum;
                this.AddResultListGrid3.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid3.PageIndex + 1, this.AddResultListGrid3.PageSize);
                this.AddResultListGrid3.DataSource = viewDT;
                this.AddResultListGrid3.DataBind();

            }
            else
            {
                this.AddResultListGrid3.PageSize = webset.ContentPageNum;
                this.AddResultListGrid3.PageIndex = 0;
                this.AddResultListGrid3.RecordCount = 0;
                this.AddResultListGrid3.DataSource = null;
                this.AddResultListGrid3.DataBind();
            }

            this.btnDeleteResultItem3.Enabled = btnClearAllResultItem3.Enabled = AddResultListGrid3.RecordCount > 0 ? true : false;
        }

        protected void AddResultListGrid3_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid3.PageIndex = e.NewPageIndex;

            BindResultList3(controller.ViewModel.dtSUPPROD);
        }
        #endregion


        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            BindResultList(controller.ViewModel.dtBarCode);
            BindResultList2(controller.ViewModel.dtRprice);
            BindResultList3(controller.ViewModel.dtSUPPROD);
        }

        protected void InitData()
        {
            controller.BindDepart(this.DepartCode);
            controller.BindBrand(this.BrandCode);
            controller.BindColor(this.ColorCode);
            controller.BindProSize(this.ProductSizeCode);
            //ControlTool.BindYear(this.Year);
            //绑定公司
            ControlTool.BindCompany(this.CompanyID);
            //绑定季节
            ControlTool.BindSEASON(this.SEASON);
            ControlTool.BindMATERIAL_IN(this.MATERIAL_1);
            ControlTool.BindMATERIAL_OUT(this.MATERIAL_2);
            //switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            //{
            //    case "en-us":
            //        ShortDescription2.Visible = false;
            //        DetailedDescription2.Visible = false;
            //        ShortDescription3.Visible = false;
            //        DetailedDescription3.Visible = false;
            //        break;

            //    case "zh-cn":
            //        ShortDescription1.Visible = false;
            //        DetailedDescription1.Visible = false;
            //        ShortDescription3.Visible = false;
            //        DetailedDescription3.Visible = false;
            //        break;
            //    case "zh-hk":
            //        ShortDescription1.Visible = false;
            //        DetailedDescription1.Visible = false;
            //        ShortDescription2.Visible = false;
            //        DetailedDescription2.Visible = false;
            //        break;
            //}
        }

        protected void btnReUpLoad_Click(object sender, EventArgs e)
        {
            this.FormLoad.Hidden = false;
            this.FormReLoad.Hidden = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath.Text))
            {
                this.FormLoad.Hidden = true;
                this.FormReLoad.Hidden = false;
            }
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

        protected void WindowPic_Close(object sender, FineUI.WindowCloseEventArgs e)
        {

        }
        protected string GetIsDefault(int IsDefault)
        {
            if (IsDefault == 0)
                return "No";
            else
                return "Yes";
        }
        #region text改变为大写
        protected virtual void ConvertTextboxToUpperText(object sender, EventArgs e)
        {
            FineUI.RealTextField tf = sender as FineUI.RealTextField;
            if (tf != null)
            {
                tf.Text = tf.Text.ToUpper();
            }
        }
        #endregion
    }
}