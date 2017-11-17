using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.File;
using FineUI;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BANK;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BRAND;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BARCODE;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_COLOR;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_CURRENCY;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_STOREGROUP;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_REASON;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_DISCOUNT;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_VENDOR;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_STOCKTYPE;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_BLACKLIST;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_STORE;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_DAYFLAG;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_MONTHFLAG;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_WEEKFLAG;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_PRODUCTCLASS;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_PRODUCTSIZE;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_RPRICETYPE;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_DEPARTMENT;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_REPLENFORMULA;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_FULFILLMENTHOUSE;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCT_PIC;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_ProductAssociated;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCTSTYLE;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_ProductParticulars;
using Edge.Web.Controllers.WebBuying.POSStaff;
using Edge.Web.Controllers.WebBuying.MasterFiles.FreightSettings;
using Edge.Web.Controllers.Operation.DeliveryOrderManagement;
using Edge.Web.Controllers.Operation.StoreOrderManagement;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BRAND;

namespace Edge.Web.Tools
{
    public class SVASessionInfo
    {
        private const string CardGradeAddControllerStr = "SVASessionInfo_CardGradeAddController";
        private const string CardGradeModifyControllerStr = "SVASessionInfo_CardGradeModifyController";
        private const string CouponTypeAddControllerStr = "SVASessionInfo_CouponTypeAddController";
        private const string CouponTypeModifyControllerStr = "SVASessionInfo_CouponTypeModifyControllerStr";
        private const string CampaignAddControllerStr = "SVASessionInfo_CampaignAddControllerStr";
        private const string CampaignModifyControllerStr = "SVASessionInfo_CampaignModifyControllerStr";
        private const string CampaignDeleteControllerStr = "SVASessionInfo_CampaignDeleteControllerStr";

        private const string MsgTemplateControllerStr = "SVASessionInfo_MsgTemplateControllerStr";

        private const string MessageHTMLStr = "SVASessionInfo_MessageHTMLStr";
        private const string PassErrorCountStr = "SVASessionInfo_PassErrorCountStr";
        private const string SiteLanguageStr = "SVASessionInfo_SiteLanguageStr";
        private const string CheckCodeStr = "SVASessionInfo_CheckCodeStr";
        private const string ReturnPageStr = "SVASessionInfo_ReturnPageStr";
        private const string CurrentUserStr = "SVASessionInfo_CurrentUserStr";
        private const string UserStyleStr = "SVASessionInfo_UserStyleStr";
        private const string TabsStr = "SVASessionInfo_TabsStr";
        private const string MessageOfApproveStr = "SVASessionInfo_MessageOfApproveStr";
        private const string StrWheresysStr = "SVASessionInfo_StrWheresysStr";
        private const string ExportTimeStr = "SVASessionInfo_ExportTimeStr";
        private const string TempImageStr = "SVASessionInfo_TempImageStr";
        private const string CardTypeCodeNameStr = "SVASessionInfo_CardTypeCodeNameStr";
        private const string CardGradeCodeNameStr = "SVASessionInfo_CardGradeCodeNameStr";
        private const string HiddenFormInfoStr = "SVASessionInfo_HiddenFormInfoStr";
        private const string CouponIssueControllerStr = "SVASessionInfo_CouponIssueControllerStr";
        private const string CouponActiveControllerStr = "SVASessionInfo_CouponActiveControllerStr";
        private const string CouponRedeemControllerStr = "SVASessionInfo_CouponRedeemControllerStr";
        private const string CouponVoidControllerStr = "SVASessionInfo_CouponVoidControllerStr";
        private const string ChangeExpiryDateControllerStr = "SVASessionInfo_ChangeExpiryDateControllerStr";
        private const string ChangeDenominationControllerStr = "SVASessionInfo_ChangeDenominationControllerStr";
        private const string ChangeStatusControllerStr = "SVASessionInfo_ChangeStatusControllerStr";
        private const string AdvertisementsAddControllerStr = "SVASessionInfo_AdvertisementsAddControllerStr";
        private const string AdvertisementsModifyControllerStr = "SVASessionInfo_AdvertisementsModifyControllerStr";
        private const string AdvertisementsDeleteControllerStr = "SVASessionInfo_AdvertisementsDeleteControllerStr";
        private const string USEFULEXPRESSIONSAddControllerStr = "SVASessionInfo_USEFULEXPRESSIONSAddControllerStr";
        private const string USEFULEXPRESSIONSModifyControllerStr = "SVASessionInfo_USEFULEXPRESSIONSModifyControllerStr";
        private const string CurrencyControllerStr = "SVASessionInfo_CurrencyControllerStr";
        private const string DistributeTemplateControllerStr = "SVASessionInfo_DistributeTemplateControllerStr";
        private const string PasswordRulesSettingControllerStr = "SVASessionInfo_PasswordRulesSettingControllerStr";
        private const string ReasonControllerStr = "SVASessionInfo_ReasonControllerStr";
        private const string StoreNatureControllerStr = "SVASessionInfo_StoreNatureControllerStr";
        private const string BrandControllerStr = "SVASessionInfo_BrandControllerStr";
        private const string CouponPushControllerStr = "SVASessionInfo_CouponPushControllerStr";
        private const string StoreControllerStr = "SVASessionInfo_StoreControllerStr";
        private const string ImportMemberCotrollerStr = "SVASessionInfo_ImportMemberCotrollerStr";
        private const string ImportStorePathStr = "SVASessionInfo_ImportStorePathStr";
        private const string DepartmentsControllerStr = "SVASessionInfo_DepartmentsControllerStr";

        private const string BankControllerStr = "SVASessionInfo_BankControllerStr";
        private const string BuyingBrandControllerStr = "SVASessionInfo_BuyingBrandControllerStr";
        private const string BuyingBarCodeControllerStr = "SVASessionInfo_BuyingBarCodeControllerStr";
        private const string BuyingProdCodeStr = "SVASessionInfo_BuyingProdCodeStr";
        private const string BuyingProdDescStr = "SVASessionInfo_BuyingProdDescStr";
        private const string BuyingColorControllerStr = "SVASessionInfo_BuyingColorControllerStr";
        private const string BuyingCurrencyControllerStr = "SVASessionInfo_BuyingCurrencyControllerStr";
        private const string BuyingStoreGroupControllerStr = "SVASessionInfo_BuyingStoreGroupControllerStr";
        private const string BuyingReasonControllerStr = "SVASessionInfo_BuyingReasonControllerStr";
        private const string BuyingDiscountControllerStr = "SVASessionInfo_BuyingDiscountControllerStr";
        private const string BuyingVendorControllerStr = "SVASessionInfo_BuyingVendorControllerStr";
        private const string BuyingStockTypeControllerStr = "SVASessionInfo_BuyingStockTypeControllerStr";
        private const string BuyingBlackListControllerStr = "SVASessionInfo_BuyingBlackListControllerStr";
        private const string BuyingStoreControllerStr = "SVASessionInfo_BuyingStoreControllerStr";
        private const string BuyingDayFlagControllerStr = "SVASessionInfo_BuyingDayFlagControllerStr";
        private const string BuyingMonthFlagControllerStr = "SVASessionInfo_BuyingMonthFlagControllerStr";
        private const string BuyingWeekFlagControllerStr = "SVASessionInfo_BuyingWeekFlagControllerStr";
        private const string BuyingProductClassControllerStr = "SVASessionInfo_BuyingProductClassControllerStr";
        private const string BuyingProductSizeControllerStr = "SVASessionInfo_BuyingProductSizeControllerStr";
        private const string BuyingPriceControllerStr = "SVASessionInfo_BuyingPriceControllerStr";
        private const string BuyingPriceTypeControllerStr = "SVASessionInfo_BuyingPriceTypeControllerStr";
        private const string BuyingPromotionControllerStr = "SVASessionInfo_BuyingPromotionControllerStr";
        private const string BuyingCPriceControllerStr = "SVASessionInfo_BuyingCPriceControllerStr";
        private const string BuyingDepartmentControllerStr = "SVASessionInfo_BuyingDepartmentControllerStr";
        private const string BuyingProductControllerStr = "SVASessionInfo_BuyingProductControllerStr";
        private const string BuyingReplenformulaControllerStr = "SVASessionInfo_BuyingReplenformulaControllerStr";
        private const string BuyingFulfillmenthouseControllerStr = "SVASessionInfo_BuyingFulfillmenthouseControllerStr";
        private const string BuyingMnmControllerStr = "SVASessionInfo_BuyingMnmControllerStr";
        private const string BuyingBoxSaleControllerStr = "SVASessionInfo_BuyingBoxSaleControllerStr";
        private const string BuyingNewPromotionControllerStr = "SVASessionInfo_BuyingNewPromotionControllerStr";
        private const string BuyingDepartCodeStr = "SVASessionInfo_BuyingDepartCodeStr";
        private const string BuyingTendCodeStr = "SVASessionInfo_BuyingBuyingTendCodeStr";
        private const string BuyingProductPictureControllerStr = "SVASessionInfo_BuyingProductPictureControllerStr";
        private const string BuyingProdAssociatedControllerStr = "SVASessionInfo_BuyingProdAssociatedControllerStr";
        private const string BuyingProductStyleControllerStr = "SVASessionInfo_BuyingProductStyleControllerStr";
        private const string BuyingProdParticularsControllerStr = "SVASessionInfo_BuyingProdParticularsControllerStr";
        private const string POSStaffControllerStr = "SVASessionInfo_POSStaffControllerStr";
        //Add Lisa  2015-12-31
        private const string LogisticsPriceControllerStr = "SVASessionInfo_LogisticsPriceControllerStr";
        private const string DeliveryOrderControllerStr = "SVASessionInfo_DeliveryOrderControllerStr";
        //Add Lisa 2016-02-24
        private const string ImportIMP_PRODUCTPathStr = "SVASessionInfo_ImportIMP_PRODUCTPathStr";
        private const string IMP_PRODUCTControllerStr = "SVASessionInfo_IMP_PRODUCTControllerStr";
        //Add Lisa 2016-02-27
        private const string BUY_PRODUCT_ADD_BAUControllerStr = "SVASessionInfo_BUYPRODUCTADD_BAUController";
        //Add Lisa 2016-06-02
        private const string SalesPickOrderControllerStr = "SVASessionInfo_SalesPickOrderController";
        //Add Lisa 2016-06-12
        private const string SalesShipOrderControllerStr = "SVASessionInfo_SalesShipOrderController";
        //Add Lisa 2016-07-13
        private const string BUY_REPLENControllerStr = "SVASessionInfo_BUY_REPLENController";
        //Add Lisa 2016-08-08
        private const string BuyingProductPedingControllerStr = "SVASessionInfo_BUY_PRODUCT_PendingController";
        //Add Lisa 2016-08-11
        private const string BuyingStoreCodeStr = "SVASessionInfo_BuyingStoreCodeStr";
        //Add Lisa 2016-12-05
        private const string ImportNoSalesProductPathStr = "SVASessionInfo_NoSalesProductPathStr";
        //Add Lisa 2016-12-14
        private const string ProductModifyTempControllerStr = "SVASessionInfo_ProductModifyTempControllerStr";
        private const string ProductModifyTempPathStr = "SVASessionInfo_ProductModifyTempPathStr";

        #region Sample

        //public static CouponTypeModifyController Controller
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[ControllerStr] == null)
        //        {
        //            HttpContext.Current.Session[ControllerStr] = new CouponTypeModifyController();
        //        }
        //        return HttpContext.Current.Session[ControllerStr] as CouponTypeModifyController;
        //    }
        //    set { HttpContext.Current.Session[ControllerStr] = value; }
        //}
        #endregion

        #region Message HTML
        public static string MessageHTML
        {
            get
            {
                if (HttpContext.Current.Session[MessageHTMLStr] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session[MessageHTMLStr].ToString();
            }
            set { HttpContext.Current.Session[MessageHTMLStr] = value; }
        }
        #endregion

        #region PassErrorCount Admin
        public static int PassErrorCount
        {
            get
            {
                if (HttpContext.Current.Session[PassErrorCountStr] == null)
                {
                    return 0;
                }
                int val = 0;
                if (int.TryParse(HttpContext.Current.Session[PassErrorCountStr].ToString(), out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value == 0)
                {
                    HttpContext.Current.Session[PassErrorCountStr] = null;
                }
                else
                {
                    HttpContext.Current.Session[PassErrorCountStr] = value;
                }
            }
        }
        #endregion

        #region SiteLanguage
        public static string SiteLanguage
        {
            get
            {
                if (HttpContext.Current.Session[SiteLanguageStr] != null)
                {
                    return HttpContext.Current.Session[SiteLanguageStr].ToString();
                }
                return "en-us";
            }
            set
            {
                HttpContext.Current.Session[SiteLanguageStr] = value;
            }
        }
        #endregion

        #region CheckCode
        public static string CheckCode
        {
            get
            {
                if (HttpContext.Current.Session[CheckCodeStr] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session[CheckCodeStr].ToString();
            }
            set { HttpContext.Current.Session[CheckCodeStr] = value; }
        }
        #endregion

        #region ReturnPage
        public static string ReturnPage
        {
            get
            {
                if (HttpContext.Current.Session[ReturnPageStr] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session[ReturnPageStr].ToString();
            }
            set { HttpContext.Current.Session[ReturnPageStr] = value; }
        }
        #endregion

        #region CurrentUser
        public static Edge.Security.Manager.User CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session[CurrentUserStr] == null)
                {
                    HttpContext.Current.Session[CurrentUserStr] = new Edge.Security.Manager.User();
                }
                return HttpContext.Current.Session[CurrentUserStr] as Edge.Security.Manager.User;
            }
            set { HttpContext.Current.Session[CurrentUserStr] = value; }
        }
        #endregion

        #region UserStyle
        public static int UserStyle
        {
            get
            {
                if (HttpContext.Current.Session[UserStyleStr] == null)
                {
                    return 0;
                }
                int val = 0;
                if (int.TryParse(HttpContext.Current.Session[UserStyleStr].ToString(), out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value == 0)
                {
                    HttpContext.Current.Session[UserStyleStr] = null;
                }
                else
                {
                    HttpContext.Current.Session[UserStyleStr] = value;
                }
            }
        }
        #endregion

        #region Tabs
        public static string Tabs
        {
            get
            {
                if (HttpContext.Current.Session[TabsStr] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session[TabsStr].ToString();
            }
            set { HttpContext.Current.Session[TabsStr] = value; }
        }
        #endregion

        #region MessageOfApprove
        public static string MessageOfApprove
        {
            get
            {
                if (HttpContext.Current.Session[MessageOfApproveStr] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session[MessageOfApproveStr].ToString();
            }
            set { HttpContext.Current.Session[MessageOfApproveStr] = value; }
        }
        #endregion

        #region strWheresys
        public static string StrWheresys
        {
            get
            {
                if (HttpContext.Current.Session[StrWheresysStr] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session[StrWheresysStr].ToString();
            }
            set { HttpContext.Current.Session[StrWheresysStr] = value; }
        }
        #endregion

        #region ExportTime
        public static string ExportTime
        {
            get
            {
                if (HttpContext.Current.Session[ExportTimeStr] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session[ExportTimeStr].ToString();
            }
            set { HttpContext.Current.Session[ExportTimeStr] = value; }
        }
        #endregion

        #region TempImage
        public static byte[] TempImage
        {
            get
            {
                if (HttpContext.Current.Session[TempImageStr] == null)
                {
                    HttpContext.Current.Session[TempImageStr] = new byte[0];
                }
                return HttpContext.Current.Session[TempImageStr] as byte[];
            }
            set { HttpContext.Current.Session[TempImageStr] = value; }
        }
        #endregion

        #region CardTypeCodeName
        public static string CardTypeCodeName
        {
            get
            {
                if (HttpContext.Current.Session[CardTypeCodeNameStr] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session[CardTypeCodeNameStr].ToString();
            }
            set { HttpContext.Current.Session[CardTypeCodeNameStr] = value; }
        }
        #endregion

        #region CardGradeCodeName
        public static string CardGradeCodeName
        {
            get
            {
                if (HttpContext.Current.Session[CardGradeCodeNameStr] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session[CardGradeCodeNameStr].ToString();
            }
            set { HttpContext.Current.Session[CardGradeCodeNameStr] = value; }
        }
        #endregion

        #region HiddenFormInfo
        public static HiddenFormInfo HiddenFormInfo
        {
            get
            {
                if (HttpContext.Current.Session[HiddenFormInfoStr] == null)
                {
                    HiddenFormInfo model = new HiddenFormInfo();
                    model.MessageBoxIcon = MessageBoxIcon.Question;
                    model.Title = "System Info";
                    model.ExecSuccess = false;
                    HttpContext.Current.Session[HiddenFormInfoStr] = model;
                }
                return HttpContext.Current.Session[HiddenFormInfoStr] as HiddenFormInfo;
            }
            set { HttpContext.Current.Session[HiddenFormInfoStr] = value; }
        }
        #endregion

       

        

      

   

   

   
      

       

       

       

     

     

        

        

        

        

        #region ImportStorePath
        public static string ImportStorePath
        {

            get
            {
                if (HttpContext.Current.Session[ImportStorePathStr] == null)
                {
                    HttpContext.Current.Session[ImportStorePathStr] = "";
                }
                return HttpContext.Current.Session[ImportStorePathStr].ToString();
            }
            set { HttpContext.Current.Session[ImportStorePathStr] = value; }
        }
        #endregion

   

        #region WebBuying BuyingBankController
        public static BuyingBankController BuyingBankController
        {
            get
            {
                if (HttpContext.Current.Session[BankControllerStr] == null)
                {
                    HttpContext.Current.Session[BankControllerStr] = new BuyingBankController();
                }
                return HttpContext.Current.Session[BankControllerStr] as BuyingBankController;
            }
            set { HttpContext.Current.Session[BankControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingBrandController
        public static BuyingBrandController BuyingBrandController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingBrandControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingBrandControllerStr] = new BuyingBrandController();
                }
                return HttpContext.Current.Session[BuyingBrandControllerStr] as BuyingBrandController;
            }
            set { HttpContext.Current.Session[BuyingBrandControllerStr] = value; }
        }
        #endregion
        
        #region WebBuying BrandController
        public static BrandController BrandController
        {
            get
            {
                if (HttpContext.Current.Session[BrandControllerStr] == null)
                {
                    HttpContext.Current.Session[BrandControllerStr] = new BrandController();
                }
                return HttpContext.Current.Session[BrandControllerStr] as BrandController;
            }
            set { HttpContext.Current.Session[BrandControllerStr] = value; }
        }
        #endregion


        #region WebBuying BuyingBarCodeController
        public static BuyingBarCodeController BuyingBarCodeController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingBarCodeControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingBarCodeControllerStr] = new BuyingBarCodeController();
                }
                return HttpContext.Current.Session[BuyingBarCodeControllerStr] as BuyingBarCodeController;
            }
            set { HttpContext.Current.Session[BuyingBarCodeControllerStr] = value; }
        }
        #endregion

        #region BuyingProdCode
        public static string BuyingProdCode
        {

            get
            {
                if (HttpContext.Current.Session[BuyingProdCodeStr] == null)
                {
                    HttpContext.Current.Session[BuyingProdCodeStr] = "";
                }
                return HttpContext.Current.Session[BuyingProdCodeStr].ToString();
            }
            set { HttpContext.Current.Session[BuyingProdCodeStr] = value; }
        }
        #endregion
         #region BuyingStoreCode
        public static string BuyingStoreCode
        {

            get
            {
                if (HttpContext.Current.Session[BuyingStoreCodeStr] == null)
                {
                    HttpContext.Current.Session[BuyingStoreCodeStr] = "";
                }
                return HttpContext.Current.Session[BuyingStoreCodeStr].ToString();
            }
            set { HttpContext.Current.Session[BuyingStoreCodeStr] = value; }
        }
        #endregion
        
        #region BuingProdDesc
        public static string BuyingProdDesc
        {

            get
            {
                if (HttpContext.Current.Session[BuyingProdDescStr] == null)
                {
                    HttpContext.Current.Session[BuyingProdDescStr] = "";
                }
                return HttpContext.Current.Session[BuyingProdDescStr].ToString();
            }
            set { HttpContext.Current.Session[BuyingProdDescStr] = value; }
        }
        #endregion

        #region WebBuying BuyingColorController
        public static BuyingColorController BuyingColorController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingColorControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingColorControllerStr] = new BuyingColorController();
                }
                return HttpContext.Current.Session[BuyingColorControllerStr] as BuyingColorController;
            }
            set { HttpContext.Current.Session[BuyingColorControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingCurrencyController
        public static BuyingCurrencyController BuyingCurrencyController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingCurrencyControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingCurrencyControllerStr] = new BuyingCurrencyController();
                }
                return HttpContext.Current.Session[BuyingCurrencyControllerStr] as BuyingCurrencyController;
            }
            set { HttpContext.Current.Session[BuyingCurrencyControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingStoreGroupController
        public static BuyingStoreGroupController BuyingStoreGroupController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingStoreGroupControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingStoreGroupControllerStr] = new BuyingStoreGroupController();
                }
                return HttpContext.Current.Session[BuyingStoreGroupControllerStr] as BuyingStoreGroupController;
            }
            set { HttpContext.Current.Session[BuyingStoreGroupControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingReasonController
        public static BuyingReasonController BuyingReasonController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingReasonControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingReasonControllerStr] = new BuyingReasonController();
                }
                return HttpContext.Current.Session[BuyingReasonControllerStr] as BuyingReasonController;
            }
            set { HttpContext.Current.Session[BuyingReasonControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingDiscountController
        public static BuyingDiscountController BuyingDiscountController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingDiscountControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingDiscountControllerStr] = new BuyingDiscountController();
                }
                return HttpContext.Current.Session[BuyingDiscountControllerStr] as BuyingDiscountController;
            }
            set { HttpContext.Current.Session[BuyingDiscountControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingVendorController
        public static BuyingVendorController BuyingVendorController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingVendorControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingVendorControllerStr] = new BuyingVendorController();
                }
                return HttpContext.Current.Session[BuyingVendorControllerStr] as BuyingVendorController;
            }
            set { HttpContext.Current.Session[BuyingVendorControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingStockTypeController
        public static BuyingStockTypeController BuyingStockTypeController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingStockTypeControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingStockTypeControllerStr] = new BuyingStockTypeController();
                }
                return HttpContext.Current.Session[BuyingStockTypeControllerStr] as BuyingStockTypeController;
            }
            set { HttpContext.Current.Session[BuyingStockTypeControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingBlackListController
        public static BuyingBlackListController BuyingBlackListController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingBlackListControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingBlackListControllerStr] = new BuyingBlackListController();
                }
                return HttpContext.Current.Session[BuyingBlackListControllerStr] as BuyingBlackListController;
            }
            set { HttpContext.Current.Session[BuyingBlackListControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingStoreController
        public static BuyingStoreController BuyingStoreController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingStoreControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingStoreControllerStr] = new BuyingStoreController();
                }
                return HttpContext.Current.Session[BuyingStoreControllerStr] as BuyingStoreController;
            }
            set { HttpContext.Current.Session[BuyingStoreControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingDayFlagController
        public static BuyingDayFlagController BuyingDayFlagController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingDayFlagControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingDayFlagControllerStr] = new BuyingDayFlagController();
                }
                return HttpContext.Current.Session[BuyingDayFlagControllerStr] as BuyingDayFlagController;
            }
            set { HttpContext.Current.Session[BuyingDayFlagControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingMonthFlagController
        public static BuyingMonthFlagController BuyingMonthFlagController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingMonthFlagControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingMonthFlagControllerStr] = new BuyingMonthFlagController();
                }
                return HttpContext.Current.Session[BuyingMonthFlagControllerStr] as BuyingMonthFlagController;
            }
            set { HttpContext.Current.Session[BuyingMonthFlagControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingWeekFlagController
        public static BuyingWeekFlagController BuyingWeekFlagController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingWeekFlagControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingWeekFlagControllerStr] = new BuyingWeekFlagController();
                }
                return HttpContext.Current.Session[BuyingWeekFlagControllerStr] as BuyingWeekFlagController;
            }
            set { HttpContext.Current.Session[BuyingWeekFlagControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingProductClassController
        public static BuyingProductClassController BuyingProductClassController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingProductClassControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingProductClassControllerStr] = new BuyingProductClassController();
                }
                return HttpContext.Current.Session[BuyingProductClassControllerStr] as BuyingProductClassController;
            }
            set { HttpContext.Current.Session[BuyingProductClassControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingProductSizeController
        public static BuyingProductSizeController BuyingProductSizeController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingProductSizeControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingProductSizeControllerStr] = new BuyingProductSizeController();
                }
                return HttpContext.Current.Session[BuyingProductSizeControllerStr] as BuyingProductSizeController;
            }
            set { HttpContext.Current.Session[BuyingProductSizeControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingPriceController
        public static BuyingPriceController BuyingPriceController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingPriceControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingPriceControllerStr] = new BuyingPriceController();
                }
                return HttpContext.Current.Session[BuyingPriceControllerStr] as BuyingPriceController;
            }
            set { HttpContext.Current.Session[BuyingPriceControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingPriceTypeController
        public static BuyingPriceTypeController BuyingPriceTypeController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingPriceTypeControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingPriceTypeControllerStr] = new BuyingPriceTypeController();
                }
                return HttpContext.Current.Session[BuyingPriceTypeControllerStr] as BuyingPriceTypeController;
            }
            set { HttpContext.Current.Session[BuyingPriceTypeControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingPromotionController
        public static BuyingPromotionController BuyingPromotionController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingPromotionControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingPromotionControllerStr] = new BuyingPromotionController();
                }
                return HttpContext.Current.Session[BuyingPromotionControllerStr] as BuyingPromotionController;
            }
            set { HttpContext.Current.Session[BuyingPromotionControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingCPriceController
        public static BuyingCPriceController BuyingCPriceController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingCPriceControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingCPriceControllerStr] = new BuyingCPriceController();
                }
                return HttpContext.Current.Session[BuyingCPriceControllerStr] as BuyingCPriceController;
            }
            set { HttpContext.Current.Session[BuyingCPriceControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingDepartmentController
        public static BuyingDepartmentController BuyingDepartmentController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingDepartmentControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingDepartmentControllerStr] = new BuyingDepartmentController();
                }
                return HttpContext.Current.Session[BuyingDepartmentControllerStr] as BuyingDepartmentController;
            }
            set { HttpContext.Current.Session[BuyingDepartmentControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingProductController
        public static BuyingProductController BuyingProductController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingProductControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingProductControllerStr] = new BuyingProductController();
                }
                return HttpContext.Current.Session[BuyingProductControllerStr] as BuyingProductController;
            }
            set { HttpContext.Current.Session[BuyingProductControllerStr] = value; }
        }
        #endregion
        #region WebBuying BuyingProductPendingController
        public static BuyingProductPendingController BuyingProductPendingController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingProductPedingControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingProductPedingControllerStr] = new BuyingProductPendingController();
                }
                return HttpContext.Current.Session[BuyingProductPedingControllerStr] as BuyingProductPendingController;
            }
            set { HttpContext.Current.Session[BuyingProductPedingControllerStr] = value; }
        }
        #endregion
        
        #region WebBuying LogisticsPriceController
        public static LogisticsPriceController LogisticsPriceController
        {
            get
            {
                if (HttpContext.Current.Session[LogisticsPriceControllerStr] == null)
                {
                    HttpContext.Current.Session[LogisticsPriceControllerStr] = new LogisticsPriceController();
                }
                return HttpContext.Current.Session[LogisticsPriceControllerStr] as LogisticsPriceController;
            }
            set { HttpContext.Current.Session[LogisticsPriceControllerStr] = value; }
        }
        #endregion

        #region Operation DeliveryOrderController
        public static DeliveryOrderController DeliveryOrderController
        {
            get
            {
                if (HttpContext.Current.Session[DeliveryOrderControllerStr] == null)
                {
                    HttpContext.Current.Session[DeliveryOrderControllerStr] = new DeliveryOrderController();
                }
                return HttpContext.Current.Session[DeliveryOrderControllerStr] as DeliveryOrderController;
            }
            set { HttpContext.Current.Session[DeliveryOrderControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingReplenformulaController
        public static BuyingReplenformulaController BuyingReplenformulaController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingReplenformulaControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingReplenformulaControllerStr] = new BuyingReplenformulaController();
                }
                return HttpContext.Current.Session[BuyingReplenformulaControllerStr] as BuyingReplenformulaController;
            }
            set { HttpContext.Current.Session[BuyingReplenformulaControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingFulfillmenthouseController
        public static BuyingFulfillmenthouseController BuyingFulfillmenthouseController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingFulfillmenthouseControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingFulfillmenthouseControllerStr] = new BuyingFulfillmenthouseController();
                }
                return HttpContext.Current.Session[BuyingFulfillmenthouseControllerStr] as BuyingFulfillmenthouseController;
            }
            set { HttpContext.Current.Session[BuyingFulfillmenthouseControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingMnmController
        public static BuyingMnmController BuyingMnmController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingMnmControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingMnmControllerStr] = new BuyingMnmController();
                }
                return HttpContext.Current.Session[BuyingMnmControllerStr] as BuyingMnmController;
            }
            set { HttpContext.Current.Session[BuyingMnmControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingBoxSaleController
        public static BuyingBoxSaleController BuyingBoxSaleController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingBoxSaleControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingBoxSaleControllerStr] = new BuyingBoxSaleController();
                }
                return HttpContext.Current.Session[BuyingBoxSaleControllerStr] as BuyingBoxSaleController;
            }
            set { HttpContext.Current.Session[BuyingBoxSaleControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingNewPromotionController
        public static BuyingNewPromotionController BuyingNewPromotionController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingNewPromotionControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingNewPromotionControllerStr] = new BuyingNewPromotionController();
                }
                return HttpContext.Current.Session[BuyingNewPromotionControllerStr] as BuyingNewPromotionController;
            }
            set { HttpContext.Current.Session[BuyingNewPromotionControllerStr] = value; }
        }
        #endregion

        #region BuyingDepartCode
        public static string BuyingDepartCode
        {

            get
            {
                if (HttpContext.Current.Session[BuyingDepartCodeStr] == null)
                {
                    HttpContext.Current.Session[BuyingDepartCodeStr] = "";
                }
                return HttpContext.Current.Session[BuyingDepartCodeStr].ToString();
            }
            set { HttpContext.Current.Session[BuyingDepartCodeStr] = value; }
        }
        #endregion

        #region BuyingTendCode
        public static string BuyingTendCode
        {

            get
            {
                if (HttpContext.Current.Session[BuyingTendCodeStr] == null)
                {
                    HttpContext.Current.Session[BuyingTendCodeStr] = "";
                }
                return HttpContext.Current.Session[BuyingTendCodeStr].ToString();
            }
            set { HttpContext.Current.Session[BuyingTendCodeStr] = value; }
        }
        #endregion

        #region WebBuying BuyingProductPictureController
        public static BuyingProductPictureController BuyingProductPictureController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingProductPictureControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingProductPictureControllerStr] = new BuyingProductPictureController();
                }
                return HttpContext.Current.Session[BuyingProductPictureControllerStr] as BuyingProductPictureController;
            }
            set { HttpContext.Current.Session[BuyingProductPictureControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingProdAssociatedController
        public static BuyingProdAssociatedController BuyingProdAssociatedController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingProdAssociatedControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingProdAssociatedControllerStr] = new BuyingProdAssociatedController();
                }
                return HttpContext.Current.Session[BuyingProdAssociatedControllerStr] as BuyingProdAssociatedController;
            }
            set { HttpContext.Current.Session[BuyingProdAssociatedControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingProductStyleController
        public static BuyingProductStyleController BuyingProductStyleController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingProductStyleControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingProductStyleControllerStr] = new BuyingProductStyleController();
                }
                return HttpContext.Current.Session[BuyingProductStyleControllerStr] as BuyingProductStyleController;
            }
            set { HttpContext.Current.Session[BuyingProductStyleControllerStr] = value; }
        }
        #endregion

        #region WebBuying BuyingProdParticularsController
        public static BuyingProdParticularsController BuyingProdParticularsController
        {
            get
            {
                if (HttpContext.Current.Session[BuyingProdParticularsControllerStr] == null)
                {
                    HttpContext.Current.Session[BuyingProdParticularsControllerStr] = new BuyingProdParticularsController();
                }
                return HttpContext.Current.Session[BuyingProdParticularsControllerStr] as BuyingProdParticularsController;
            }
            set { HttpContext.Current.Session[BuyingProdParticularsControllerStr] = value; }
        }
        #endregion

        #region WebBuying POSStaffController
        public static POSStaffController POSStaffController
        {
            get
            {
                if (HttpContext.Current.Session[POSStaffControllerStr] == null)
                {
                    HttpContext.Current.Session[POSStaffControllerStr] = new POSStaffController();
                }
                return HttpContext.Current.Session[POSStaffControllerStr] as POSStaffController;
            }
            set { HttpContext.Current.Session[POSStaffControllerStr] = value; }
        }
        #endregion

        #region ImportIMP_PRODUCTPath
        public static string ImportIMP_PRODUCTPath
        {

            get
            {
                if (HttpContext.Current.Session[ImportIMP_PRODUCTPathStr] == null)
                {
                    HttpContext.Current.Session[ImportIMP_PRODUCTPathStr] = "";
                }
                return HttpContext.Current.Session[ImportIMP_PRODUCTPathStr].ToString();
            }
            set { HttpContext.Current.Session[ImportIMP_PRODUCTPathStr] = value; }
        }
        #endregion

        #region  ImportNoSalesPRODUCTPath
        public static string  ImportNoSalesProductTPath
        {

            get
            {
                if (HttpContext.Current.Session[ImportNoSalesProductPathStr] == null)
                {
                    HttpContext.Current.Session[ImportNoSalesProductPathStr] = "";
                }
                return HttpContext.Current.Session[ImportNoSalesProductPathStr].ToString();
            }
            set { HttpContext.Current.Session[ImportNoSalesProductPathStr] = value; }
        }
        #endregion

        #region  ProductModifyTempPath
        public static string ProductModifyTempPath
        {
            get
            {
                if (HttpContext.Current.Session[ProductModifyTempPathStr] == null)
                {
                    HttpContext.Current.Session[ProductModifyTempPathStr] = "";
                }
                return HttpContext.Current.Session[ProductModifyTempPathStr].ToString();
            }
            set { HttpContext.Current.Session[ProductModifyTempPathStr] = value; }
        }
        #endregion


        #region WebBuying IMP_PRODUCTController
        public static IMP_PRODUCTController IMP_PRODUCTController
        {
            get
            {
                if (HttpContext.Current.Session[IMP_PRODUCTControllerStr] == null)
                {
                    HttpContext.Current.Session[IMP_PRODUCTControllerStr] = new IMP_PRODUCTController();
                }
                return HttpContext.Current.Session[IMP_PRODUCTControllerStr] as IMP_PRODUCTController;
            }
            set { HttpContext.Current.Session[IMP_PRODUCTControllerStr] = value; }
        }
        #endregion


        #region WebBuying BUY_PRODUCT_ADD_BAUController
        public static BUY_PRODUCT_ADD_BAUController BUY_PRODUCT_ADD_BAUController
        {
            get
            {
                if (HttpContext.Current.Session[BUY_PRODUCT_ADD_BAUControllerStr] == null)
                {
                    HttpContext.Current.Session[BUY_PRODUCT_ADD_BAUControllerStr] = new BUY_PRODUCT_ADD_BAUController();
                }
                return HttpContext.Current.Session[BUY_PRODUCT_ADD_BAUControllerStr] as BUY_PRODUCT_ADD_BAUController;
            }
            set { HttpContext.Current.Session[BUY_PRODUCT_ADD_BAUControllerStr] = value; }
        }
        #endregion

        #region WebBuying SalesPickOrderControllerStr
        public static SalesPickOrderController SalesPickOrderController
        {
            get
            {
                if (HttpContext.Current.Session[SalesPickOrderControllerStr] == null)
                {
                    HttpContext.Current.Session[SalesPickOrderControllerStr] = new SalesPickOrderController();
                }
                return HttpContext.Current.Session[SalesPickOrderControllerStr] as SalesPickOrderController;
            }
            set { HttpContext.Current.Session[SalesPickOrderControllerStr] = value; }
        }
        #endregion

        #region WebBuying SalesShipOrderControllerStr
        public static SalesShipOrderController SalesShipOrderController
        {
            get
            {
                if (HttpContext.Current.Session[SalesShipOrderControllerStr] == null)
                {
                    HttpContext.Current.Session[SalesShipOrderControllerStr] = new SalesShipOrderController();
                }
                return HttpContext.Current.Session[SalesShipOrderControllerStr] as SalesShipOrderController;
            }
            set { HttpContext.Current.Session[SalesShipOrderControllerStr] = value; }
        }
        #endregion

        #region WebBuying BUY_REPLENControllerStr
        public static BUY_REPLENController BUY_REPLENController
        {
            get
            {
                if (HttpContext.Current.Session[BUY_REPLENControllerStr] == null)
                {
                    HttpContext.Current.Session[BUY_REPLENControllerStr] = new BUY_REPLENController();
                }
                return HttpContext.Current.Session[BUY_REPLENControllerStr] as BUY_REPLENController;
            }
            set { HttpContext.Current.Session[BUY_REPLENControllerStr] = value; }
        }
        #endregion

        #region WebBuying ProductModifyTempController
        public static ProductModifyTempController ProductModifyTempController
        {
            get
            {
                if (HttpContext.Current.Session[ProductModifyTempControllerStr] == null)
                {
                    HttpContext.Current.Session[ProductModifyTempControllerStr] = new ProductModifyTempController();
                }
                return HttpContext.Current.Session[ProductModifyTempControllerStr] as ProductModifyTempController;
            }
            set { HttpContext.Current.Session[ProductModifyTempControllerStr] = value; }
        }
        #endregion

        
    }
}