using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus
{
    public partial class Show: PageBase
    {
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
        Tools.Logger logger = Tools.Logger.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

            }
            controller = SVASessionInfo.BuyingProductPendingController;
            logger.WriteOperationLog(this.PageName, "Show");

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
                    this.BrandCode.Text = controller.ViewModel.MainTable.BrandCode;
                    //部门编号
                    this.DepartCode.Text = controller.ViewModel.MainTable.DepartCode;
                    //季节
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending ClassifySeason = _classFyBLL.GetPRODUCT_CLASSIFY(prodCode, "SEASON");
                    if (ClassifySeason != null)
                    {
                        Edge.SVA.Model.SEASON season = _SeaSonBLL.GetModel(ClassifySeason.ForeignkeyID);
                        if (season != null)
                        {
                            if (LanguageId == 1)
                            {
                                this.SEASON.Text = season.SeasonName1.ToString();
                            }
                            else if (LanguageId == 2)
                            {
                                this.SEASON.Text = season.SeasonName2.ToString();
                            }
                            else
                            {
                                this.SEASON.Text = season.SeasonName3.ToString();
                            }
                        }

                    }
                    //性别
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending ClassifySex = _classFyBLL.GetPRODUCT_CLASSIFY(prodCode, "Gender");
                    if (ClassifySex != null)
                    {
                        Edge.SVA.Model.Gender gender = _GenderBLL.GetModel(ClassifySex.ForeignkeyID);
                        if (gender != null)
                        {
                            if (LanguageId == 1)
                            {
                                this.SEX.Text = gender.GenderDesc1.ToString();
                            }
                            else if (LanguageId == 2)
                            {
                                this.SEX.Text = gender.GenderDesc2.ToString();
                            }
                            else
                            {
                                this.SEX.Text = gender.GenderDesc3.ToString();
                            }
                        }
                    }


                    //InnerLayerMaterials
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending classfyMATERIALIN = _classFyBLL.GetPRODUCT_CLASSIFY(prodCode, "MATERIAL_IN");
                    if (classfyMATERIALIN != null)
                    {
                        Edge.SVA.Model.MATERIAL_IN MATERIAL_IN = _MATERIAL_INBLL.GetModel(classfyMATERIALIN.ForeignkeyID);
                        if (MATERIAL_IN != null)
                        {
                            if (LanguageId == 1)
                            {
                                this.MATERIAL_2.Text = MATERIAL_IN.MATERIALName1.ToString();
                            }
                            else if (LanguageId == 2)
                            {
                                this.MATERIAL_2.Text = MATERIAL_IN.MATERIALName2.ToString();
                            }
                            else
                            {
                                this.MATERIAL_2.Text = MATERIAL_IN.MATERIALName3.ToString();
                            }

                        }
                    }
                    //OuterLayerMaterials
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending classfyMATERIALOUT = _classFyBLL.GetPRODUCT_CLASSIFY(prodCode, "MATERIAL_OUT");
                    if (classfyMATERIALOUT != null)
                    {
                        Edge.SVA.Model.MATERIAL_OUT MATERIAL_OUT = _MATERIAL_OUTBLL.GetModel(classfyMATERIALOUT.ForeignkeyID);
                        if (MATERIAL_OUT != null)
                        {
                            if (LanguageId == 1)
                            {
                                this.MATERIAL_1.Text = MATERIAL_OUT.MATERIALName1.ToString();
                            }
                            else if (LanguageId == 2)
                            {
                                this.MATERIAL_1.Text = MATERIAL_OUT.MATERIALName2.ToString();
                            }
                            else
                            {
                                this.MATERIAL_1.Text = MATERIAL_OUT.MATERIALName3.ToString();
                            }

                        }
                    }
                    //货品颜色
                    this.ColorCode.Text = controller.ViewModel.MainTable.ColorCode;
                    //货品尺寸
                    this.ProductSizeCode.Text = controller.ViewModel.MainTable.ProductSizeCode;
                    //产品图片
                    this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.CreatedOn);
                    this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.UpdatedOn);

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.ProdPicFile;
                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");

                    this.btnPreview.Hidden = string.IsNullOrEmpty(controller.ViewModel.MainTable.ProdPicFile) ? true : false;//没有照片时不显示View按钮(Len)

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
                        this.RETIRED.Text = "不是不能销售货品";
                    }
                    else
                    {
                        this.RETIRED.Text = "是不能销售货品";
                    }

                    //修改时间
                    this.UpdatedOn.Text = ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.UpdatedOn.GetValueOrDefault());
                    //修改人
                    this.UpdatedBy.Text = Tools.DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    //审核时间
                    this.ApprovedOn.Text = ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.ApprovedOn.GetValueOrDefault());
                    //审核人
                    this.ApprovedBy.Text = Tools.DALTool.GetUserName(controller.ViewModel.MainTable.ApprovedBy.GetValueOrDefault());
                    


                    bauhausController.LoadViewModel(prodCode);
                    if (bauhausController.ViewModel.MainTablePeding != null)
                    {
                        //公司名称
                        if (!string.IsNullOrEmpty(bauhausController.ViewModel.MainTablePeding.CompanyCode))
                        {
                            this.CompanyID.Text = bauhausController.ViewModel.MainTablePeding.CompanyCode;
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
                        this.BrandCode.Text = productController.ViewModel.MainTable.BrandCode;
                        //部门编号
                        this.DepartCode.Text = productController.ViewModel.MainTable.DepartCode;
                        //季节
                        Edge.SVA.Model.BUY_PRODUCT_CLASSIFY ClassifySeason = _classProductFyBLL.GetPRODUCT_CLASSIFY(prodCode, "SEASON");
                        if (ClassifySeason != null)
                        {
                            Edge.SVA.Model.SEASON season = _SeaSonBLL.GetModel(ClassifySeason.ForeignkeyID);
                            if (season != null)
                            {
                                if (LanguageId == 1)
                                {
                                    this.SEASON.Text = season.SeasonName1.ToString();
                                }
                                else if (LanguageId == 2)
                                {
                                    this.SEASON.Text = season.SeasonName2.ToString();
                                }
                                else
                                {
                                    this.SEASON.Text = season.SeasonName3.ToString();
                                }
                            }

                        }
                        //性别
                        Edge.SVA.Model.BUY_PRODUCT_CLASSIFY ClassifySex = _classProductFyBLL.GetPRODUCT_CLASSIFY(prodCode, "Gender");
                        if (ClassifySex != null)
                        {
                            Edge.SVA.Model.Gender gender = _GenderBLL.GetModel(ClassifySex.ForeignkeyID);
                            if (gender != null)
                            {
                                if (LanguageId == 1)
                                {
                                    this.SEX.Text = gender.GenderDesc1.ToString();
                                }
                                else if (LanguageId == 2)
                                {
                                    this.SEX.Text = gender.GenderDesc2.ToString();
                                }
                                else
                                {
                                    this.SEX.Text = gender.GenderDesc3.ToString();
                                }
                            }
                        }


                        //InnerLayerMaterials
                        Edge.SVA.Model.BUY_PRODUCT_CLASSIFY classfyMATERIALIN = _classProductFyBLL.GetPRODUCT_CLASSIFY(prodCode, "MATERIAL_IN");
                        if (classfyMATERIALIN != null)
                        {
                            Edge.SVA.Model.MATERIAL_IN MATERIAL_IN = _MATERIAL_INBLL.GetModel(classfyMATERIALIN.ForeignkeyID);
                            if (MATERIAL_IN != null)
                            {
                                if (LanguageId == 1)
                                {
                                    this.MATERIAL_2.Text = MATERIAL_IN.MATERIALName1.ToString();
                                }
                                else if (LanguageId == 2)
                                {
                                    this.MATERIAL_2.Text = MATERIAL_IN.MATERIALName2.ToString();
                                }
                                else
                                {
                                    this.MATERIAL_2.Text = MATERIAL_IN.MATERIALName3.ToString();
                                }

                            }
                        }
                        //OuterLayerMaterials
                        Edge.SVA.Model.BUY_PRODUCT_CLASSIFY classfyMATERIALOUT = _classProductFyBLL.GetPRODUCT_CLASSIFY(prodCode, "MATERIAL_OUT");
                        if (classfyMATERIALOUT != null)
                        {
                            Edge.SVA.Model.MATERIAL_OUT MATERIAL_OUT = _MATERIAL_OUTBLL.GetModel(classfyMATERIALOUT.ForeignkeyID);
                            if (MATERIAL_OUT != null)
                            {
                                if (LanguageId == 1)
                                {
                                    this.MATERIAL_1.Text = MATERIAL_OUT.MATERIALName1.ToString();
                                }
                                else if (LanguageId == 2)
                                {
                                    this.MATERIAL_1.Text = MATERIAL_OUT.MATERIALName2.ToString();
                                }
                                else
                                {
                                    this.MATERIAL_1.Text = MATERIAL_OUT.MATERIALName3.ToString();
                                }

                            }
                        }
                        //货品颜色
                        this.ColorCode.Text = productController.ViewModel.MainTable.ColorCode;
                        //货品尺寸
                        this.ProductSizeCode.Text = productController.ViewModel.MainTable.ProductSizeCode;
                      
                        this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(productController.ViewModel.MainTable.CreatedOn);
                        this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(productController.ViewModel.MainTable.UpdatedOn);
                        //产品图片
                        this.uploadFilePath.Text = productController.ViewModel.MainTable.ProdPicFile;
                        this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");

                        this.btnPreview.Hidden = string.IsNullOrEmpty(productController.ViewModel.MainTable.ProdPicFile) ? true : false;//没有照片时不显示View按钮(Len)
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
                            this.RETIRED.Text = "不是不能销售货品";
                        }
                        else
                        {
                            this.RETIRED.Text = "是不能销售货品";
                        }

                        //修改时间
                        this.UpdatedOn.Text = ConvertTool.ToStringDateTime(productController.ViewModel.MainTable.UpdatedOn.GetValueOrDefault());
                        //修改人
                        this.UpdatedBy.Text = Tools.DALTool.GetUserName(productController.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                        //审核时间
                        this.ApprovedOn.Text = ConvertTool.ToStringDateTime(productController.ViewModel.MainTable.ApprovedOn.GetValueOrDefault());
                        //审核人
                        this.ApprovedBy.Text = Tools.DALTool.GetUserName(productController.ViewModel.MainTable.ApprovedBy.GetValueOrDefault());


                        bauhausProductController.LoadViewModel(prodCode);
                        if (bauhausProductController.ViewModel.MainTable != null)
                        {
                            //公司名称
                            if (!string.IsNullOrEmpty(bauhausProductController.ViewModel.MainTable.CompanyCode))
                            {
                                this.CompanyID.Text = bauhausProductController.ViewModel.MainTable.CompanyCode;
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

        #region 操作条形码表

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
        }

        protected void AddResultListGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid.PageIndex = e.NewPageIndex;

            BindResultList(controller.ViewModel.dtBarCode);
        }

        #endregion

        #region 操作价格
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


        }
        protected void AddResultListGrid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid2.PageIndex = e.NewPageIndex;

            BindResultList2(controller.ViewModel.dtRprice);
        }
        #endregion

        #region 操作供应商
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
        }

        protected void AddResultListGrid3_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid3.PageIndex = e.NewPageIndex;

            BindResultList3(controller.ViewModel.dtSUPPROD);
        }
        #endregion
        protected string GetIsDefault(int IsDefault)
        {
            if (IsDefault == 0)
                return "No";
            else
                return "Yes";
        }
    }
}