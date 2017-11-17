using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT_Pending
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT_Pending, Edge.SVA.Model.BUY_PRODUCT_Pending>
    {
        int LanguageId = 0;
        #region 公用业务逻辑类全局变量
        BuyingProductPendingController controller = new BuyingProductPendingController();
        BuyingProductController pcontroller = new BuyingProductController();
        BUY_PRODUCT_ADD_BAU_PedingController bauhausController = new BUY_PRODUCT_ADD_BAU_PedingController();
        BUY_PRODUCT_ADD_BAUController bauController = new BUY_PRODUCT_ADD_BAUController();
        Edge.SVA.BLL.BUY_PRODUCT_CLASSIFY_Pending _classFyBLL = new SVA.BLL.BUY_PRODUCT_CLASSIFY_Pending();
        Edge.SVA.BLL.BUY_PRODUCT_CLASSIFY _classFyOldBLL = new SVA.BLL.BUY_PRODUCT_CLASSIFY();
        Edge.SVA.BLL.BUY_Product_Particulars_Pending _particularsBLL = new SVA.BLL.BUY_Product_Particulars_Pending();
        Edge.SVA.BLL.BUY_Product_Particulars _particularsBLLOld = new SVA.BLL.BUY_Product_Particulars();
        Edge.SVA.BLL.BUY_SUPPROD _SUPPRODBLL = new SVA.BLL.BUY_SUPPROD();
        Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU _BauhausProduct = new SVA.BLL.BUY_PRODUCT_ADD_BAU();
        Edge.SVA.BLL.SEASON _SeaSonBLL = new SVA.BLL.SEASON();
        Edge.SVA.BLL.Gender _GenderBLL = new SVA.BLL.Gender();
        Edge.SVA.BLL.MATERIAL_IN _MATERIAL_INBLL = new SVA.BLL.MATERIAL_IN();
        Edge.SVA.BLL.MATERIAL_OUT _MATERIAL_OUTBLL = new SVA.BLL.MATERIAL_OUT();

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
                SVASessionInfo.BuyingProductController = null;

            }
            controller = SVASessionInfo.BuyingProductPendingController;
            logger.WriteOperationLog(this.PageName, "Show");

        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.ProdCode);
                pcontroller.LoadViewModel(Model.ProdCode);
                if (controller.ViewModel.MainTable != null)
                {

                    //货品编号
                    this.ProdCode.Text = controller.ViewModel.MainTable.ProdCode;
                    //品牌编号
                    this.BrandCode.Text = controller.ViewModel.MainTable.BrandCode;
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": LanguageId = 1; break;
                        case "zh-cn": LanguageId = 2; break;
                        case "zh-hk": LanguageId = 3; break;
                    }
                    //季节
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending ClassifySeason = _classFyBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "SEASON");
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
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending ClassifySex = _classFyBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "Gender");
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
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending classfyMATERIALIN = _classFyBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "MATERIAL_IN");
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
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending classfyMATERIALOUT = _classFyBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "MATERIAL_OUT");
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
                    //货品名称1
                    this.ProdDesc1.Text = controller.ViewModel.MainTable.ProdDesc1;
                    //货品名称2
                    this.ProdDesc2.Text = controller.ViewModel.MainTable.ProdDesc2;
                    //货品名称3
                    this.ProdDesc3.Text = controller.ViewModel.MainTable.ProdDesc3;
                    this.UpdatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    this.CreatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());

                    this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.CreatedOn);
                    this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.UpdatedOn);

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.ProdPicFile;
                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");

                    this.btnPreview.Hidden = string.IsNullOrEmpty(Model.ProdPicFile) ? true : false;//没有照片时不显示View按钮(Len)
                    //描述，详细信息
                    Edge.SVA.Model.BUY_Product_Particulars_Pending ProductParticulars = _particularsBLL.GetModel(this.ProdCode.Text, LanguageId);
                    if (ProductParticulars != null)
                    {
                        if (LanguageId == 1)
                        {
                            this.ShortDescription1.Text = ProductParticulars.MemoTitle1;
                            this.DetailedDescription1.Text = ProductParticulars.Memo1;
                        }
                        else if (LanguageId == 2)
                        {
                            this.ShortDescription2.Text = ProductParticulars.MemoTitle1;
                            this.DetailedDescription2.Text = ProductParticulars.Memo1;
                        }
                        else
                        {
                            this.ShortDescription3.Text = ProductParticulars.MemoTitle1;
                            this.DetailedDescription3.Text = ProductParticulars.Memo1;
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


                    bauhausController.LoadViewModel(this.ProdCode.Text);
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
                        this.RETIRE_DATE.Text = bauhausController.ViewModel.MainTablePeding.RETIRE_DATE.ToString();
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
                    //操作条形码
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

                    if (pcontroller.ViewModel.MainTable != null)
                    {
                        //原货品编号
                        if (controller.ViewModel.MainTable.ProdCode != pcontroller.ViewModel.MainTable.ProdCode)
                        {
                            OldProdCode.Text = "(" + pcontroller.ViewModel.MainTable.ProdCode + ")";
                        }
                        //原货品名称1
                        if (controller.ViewModel.MainTable.ProdDesc1 != pcontroller.ViewModel.MainTable.ProdDesc1)
                        {
                            OldProdDesc1.Text = "(" + pcontroller.ViewModel.MainTable.ProdDesc1 + ")";
                        }
                        //原货品名称2
                        if (controller.ViewModel.MainTable.ProdDesc2 != pcontroller.ViewModel.MainTable.ProdDesc2)
                        {
                            OldProdDesc2.Text = "(" + pcontroller.ViewModel.MainTable.ProdDesc2 + ")";
                        }
                        //原货品名称3
                        if (controller.ViewModel.MainTable.ProdDesc3 != pcontroller.ViewModel.MainTable.ProdDesc3)
                        {
                            OldProdDesc3.Text = "(" + pcontroller.ViewModel.MainTable.ProdDesc3 + ")";
                        }
                        //原品牌
                        if (controller.ViewModel.MainTable.BrandCode != pcontroller.ViewModel.MainTable.BrandCode)
                        {
                            oldBrandCode.Text = "(" + pcontroller.ViewModel.MainTable.BrandCode + ")";
                        }
                        //原货品颜色
                        if (controller.ViewModel.MainTable.ColorCode != pcontroller.ViewModel.MainTable.ColorCode)
                        {
                            oldColorCode.Text = "(" + pcontroller.ViewModel.MainTable.ColorCode + ")";
                        }
                        //原货品尺寸
                        if (controller.ViewModel.MainTable.ProductSizeCode != pcontroller.ViewModel.MainTable.ProductSizeCode)
                        {
                            oldProductSizeCode.Text = "(" + pcontroller.ViewModel.MainTable.ProductSizeCode + ")";
                        }
                        if (controller.ViewModel.MainTable.NonSale != pcontroller.ViewModel.MainTable.NonSale)
                        {
                            if (pcontroller.ViewModel.MainTable.NonSale == 0)
                            {
                                this.oldRETIRED.Text = "不是不能销售货品";
                            }
                            else
                            {
                                this.oldRETIRED.Text = "是不能销售货品";
                            }
                        }

                    }
                    bauController.LoadViewModel(Model.ProdCode);
                    if (bauController.ViewModel.MainTable != null)
                    {
                        if (bauhausController.ViewModel.MainTablePeding != null)
                        {
                            //原公司
                            if (bauhausController.ViewModel.MainTablePeding.CompanyCode != bauController.ViewModel.MainTable.CompanyCode)
                            {
                                OldCompanyID.Text = "(" + bauController.ViewModel.MainTable.CompanyCode + ")";
                            }
                            //原SKU
                            if (bauhausController.ViewModel.MainTablePeding.SKU != bauController.ViewModel.MainTable.SKU)
                            {
                                oldSKU.Text = "(" + bauController.ViewModel.MainTable.SKU + ")";
                            }
                            //原年份
                            if (bauhausController.ViewModel.MainTablePeding.YEAR != bauController.ViewModel.MainTable.YEAR)
                            {
                                oldYear.Text = "(" + bauController.ViewModel.MainTable.YEAR + ")";
                            }
                            //原模型
                            if (bauhausController.ViewModel.MainTablePeding.MODEL != bauController.ViewModel.MainTable.MODEL)
                            {
                                oldMODEL.Text = "(" + bauController.ViewModel.MainTable.MODEL + ")";
                            }
                            //原订货点水平
                            if (bauhausController.ViewModel.MainTablePeding.REORDER_LEVEL != bauController.ViewModel.MainTable.REORDER_LEVEL)
                            {
                                oldREORDER_LEVEL.Text = "(" + bauController.ViewModel.MainTable.REORDER_LEVEL + ")";
                            }
                            //原下架日期
                            if (bauhausController.ViewModel.MainTablePeding.RETIRE_DATE != bauController.ViewModel.MainTable.RETIRE_DATE)
                            {
                                oldRETIRE_DATE.Text = "(" + bauController.ViewModel.MainTable.RETIRE_DATE + ")";
                            }
                            //原成本价格
                            if (bauhausController.ViewModel.MainTablePeding.Standard_Cost != bauController.ViewModel.MainTable.Standard_Cost)
                            {
                                oldSTANDARD_COST.Text = "(" + bauController.ViewModel.MainTable.Standard_Cost + ")";
                            }
                            //原出口价格
                            if (bauhausController.ViewModel.MainTablePeding.Export_Cost != bauController.ViewModel.MainTable.Export_Cost)
                            {
                                oldEXPORT_COST.Text = "(" + bauController.ViewModel.MainTable.Standard_Cost + ")";
                            }
                            //原平均价格
                            if (bauhausController.ViewModel.MainTablePeding.AVG_Cost != bauController.ViewModel.MainTable.AVG_Cost)
                            {
                                OldAVG_Cost.Text = "(" + bauController.ViewModel.MainTable.AVG_Cost + ")";
                            }
                            //原尺寸范围
                            if (bauhausController.ViewModel.MainTablePeding.SIZE_RANGE != bauController.ViewModel.MainTable.SIZE_RANGE)
                            {
                                oldSIZE_RANGE.Text = "(" + bauController.ViewModel.MainTable.SIZE_RANGE + ")";
                            }
                            //原海关编码
                            if (bauhausController.ViewModel.MainTablePeding.HS_CODE != bauController.ViewModel.MainTable.HS_CODE)
                            {
                                oldHS_CODE.Text = "(" + bauController.ViewModel.MainTable.HS_CODE + ")";
                            }
                            //原首席运营官
                            if (bauhausController.ViewModel.MainTablePeding.COO != bauController.ViewModel.MainTable.COO)
                            {
                                oldCOO.Text = "(" + bauController.ViewModel.MainTable.COO + ")";
                            }
                            //原设计师
                            if (bauhausController.ViewModel.MainTablePeding.DESIGNER != bauController.ViewModel.MainTable.DESIGNER)
                            {
                                oldDESIGNER.Text = "(" + bauController.ViewModel.MainTable.DESIGNER + ")";
                            }
                            //原买主
                            if (bauhausController.ViewModel.MainTablePeding.BUYER != bauController.ViewModel.MainTable.BUYER)
                            {
                                oldBUYER.Text = "(" + bauController.ViewModel.MainTable.BUYER + ")";
                            }
                            //零售商
                            if (bauhausController.ViewModel.MainTablePeding.MERCHANDISER != bauController.ViewModel.MainTable.MERCHANDISER)
                            {
                                oldMERCHANDISER.Text = "(" + bauController.ViewModel.MainTable.MERCHANDISER + ")";
                            }
                            //原尺寸1
                            if (bauhausController.ViewModel.MainTablePeding.SizeM1 != bauController.ViewModel.MainTable.SizeM1)
                            {
                                oldSizeM1.Text = "(" + bauController.ViewModel.MainTable.SizeM1.ToString() + ")";
                            }
                            //原尺寸2
                            if (bauhausController.ViewModel.MainTablePeding.SizeM2 != bauController.ViewModel.MainTable.SizeM2)
                            {
                                oldSizeM2.Text = "(" + bauController.ViewModel.MainTable.SizeM2.ToString() + ")";
                            }
                            //原尺寸3
                            if (bauhausController.ViewModel.MainTablePeding.SizeM3 != bauController.ViewModel.MainTable.SizeM3)
                            {
                                oldSizeM3.Text = "(" + bauController.ViewModel.MainTable.SizeM3.ToString() + ")";
                            }
                            //原尺寸4
                            if (bauhausController.ViewModel.MainTablePeding.SizeM4 != bauController.ViewModel.MainTable.SizeM4)
                            {
                                oldSizeM4.Text = "(" + bauController.ViewModel.MainTable.SizeM4.ToString() + ")";
                            }
                            //原尺寸5
                            if (bauhausController.ViewModel.MainTablePeding.SizeM5 != bauController.ViewModel.MainTable.SizeM5)
                            {
                                oldSizeM5.Text = "(" + bauController.ViewModel.MainTable.SizeM5.ToString() + ")";
                            }
                            //原尺寸6
                            if (bauhausController.ViewModel.MainTablePeding.SizeM6 != bauController.ViewModel.MainTable.SizeM6)
                            {
                                oldSizeM6.Text = "(" + bauController.ViewModel.MainTable.SizeM6.ToString() + ")";
                            }
                            //原尺寸7
                            if (bauhausController.ViewModel.MainTablePeding.SizeM7 != bauController.ViewModel.MainTable.SizeM7)
                            {
                                oldSizeM7.Text = "(" + bauController.ViewModel.MainTable.SizeM7.ToString() + ")";
                            }
                            //原尺寸8
                            if (bauhausController.ViewModel.MainTablePeding.SizeM8 != bauController.ViewModel.MainTable.SizeM8)
                            {
                                oldSizeM8.Text = "(" + bauController.ViewModel.MainTable.SizeM8.ToString() + ")";
                            }
                        }
                    }
                    //季节
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY ClassifySeasonOld = _classFyOldBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "SEASON");
                    if (ClassifySeasonOld != null)
                    {
                        Edge.SVA.Model.SEASON season = _SeaSonBLL.GetModel(ClassifySeasonOld.ForeignkeyID);
                        if (season != null)
                        {
                            if (LanguageId == 1)
                            {
                                if (season.SeasonName1 != SEASON.Text)
                                {
                                    this.oldSEASON.Text = season.SeasonName1.ToString();
                                }
                            }
                            else if (LanguageId == 2)
                            {
                                if (season.SeasonName2 != SEASON.Text)
                                {
                                    this.oldSEASON.Text = season.SeasonName2.ToString();
                                }
                            }
                            else
                            {
                                if (season.SeasonName3 != SEASON.Text)
                                {
                                    this.oldSEASON.Text = season.SeasonName3.ToString();
                                }
                            }
                        }

                    }
                    //性别
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY ClassifySexOld = _classFyOldBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "Gender");
                    if (ClassifySexOld != null)
                    {
                        Edge.SVA.Model.Gender gender = _GenderBLL.GetModel(ClassifySexOld.ForeignkeyID);
                        if (gender != null)
                        {
                            if (LanguageId == 1)
                            {
                                if (SEX.Text != gender.GenderDesc1)
                                {
                                    this.oldSEX.Text = gender.GenderDesc1.ToString();
                                }
                            }
                            else if (LanguageId == 2)
                            {
                                if (SEX.Text != gender.GenderDesc2)
                                {
                                    this.oldSEX.Text = gender.GenderDesc2.ToString();
                                }
                            }
                            else
                            {
                                if (SEX.Text != gender.GenderDesc3)
                                {
                                    this.oldSEX.Text = gender.GenderDesc3.ToString();
                                }
                            }
                        }
                    }
                    //描述，详细信息
                    Edge.SVA.Model.BUY_Product_Particulars ProductParticularsOld = _particularsBLLOld.GetModel(this.ProdCode.Text, LanguageId);
                    if (ProductParticularsOld != null)
                    {
                        if (LanguageId == 1)
                        {

                            this.oldShortDescription1.Text = ProductParticularsOld.MemoTitle1;
                            this.oldDetailedDescription1.Text = ProductParticularsOld.Memo1;
                        }
                        else if (LanguageId == 2)
                        {
                            this.oldShortDescription2.Text = ProductParticularsOld.MemoTitle1;
                            this.oldDetailedDescription2.Text = ProductParticularsOld.Memo1;
                        }
                        else
                        {
                            this.oldShortDescription3.Text = ProductParticularsOld.MemoTitle1;
                            this.oldDetailedDescription3.Text = ProductParticularsOld.Memo1;
                        }
                    }
                    //InnerLayerMaterials
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY classfyMATERIALINOld = _classFyOldBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "MATERIAL_IN");
                    if (classfyMATERIALINOld != null)
                    {
                        Edge.SVA.Model.MATERIAL_IN MATERIAL_IN = _MATERIAL_INBLL.GetModel(classfyMATERIALIN.ForeignkeyID);
                        if (MATERIAL_IN != null)
                        {
                            if (LanguageId == 1)
                            {

                                this.oldMATERIAL_2.Text = MATERIAL_IN.MATERIALName1.ToString();
                            }
                            else if (LanguageId == 2)
                            {
                                this.oldMATERIAL_2.Text = MATERIAL_IN.MATERIALName2.ToString();
                            }
                            else
                            {
                                this.oldMATERIAL_2.Text = MATERIAL_IN.MATERIALName3.ToString();
                            }

                        }
                    }
                    //OuterLayerMaterials
                    Edge.SVA.Model.BUY_PRODUCT_CLASSIFY classfyMATERIALOUTOld = _classFyOldBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text, "MATERIAL_OUT");
                    if (classfyMATERIALOUTOld != null && !classfyMATERIALOUT.Equals(classfyMATERIALOUTOld))
                    {
                        Edge.SVA.Model.MATERIAL_OUT MATERIAL_OUT = _MATERIAL_OUTBLL.GetModel(classfyMATERIALOUT.ForeignkeyID);
                        if (MATERIAL_OUT != null)
                        {
                            if (LanguageId == 1)
                            {
                                this.oldMATERIAL_1.Text = MATERIAL_OUT.MATERIALName1.ToString();
                            }
                            else if (LanguageId == 2)
                            {
                                this.oldMATERIAL_1.Text = MATERIAL_OUT.MATERIALName2.ToString();
                            }
                            else
                            {
                                this.oldMATERIAL_1.Text = MATERIAL_OUT.MATERIALName3.ToString();
                            }

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