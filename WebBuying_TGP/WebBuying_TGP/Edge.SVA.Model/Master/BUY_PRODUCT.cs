using System;
namespace Edge.SVA.Model
{
    /// <summary>
    /// 货品表
    /// </summary>
    [Serializable]
    public partial class BUY_PRODUCT
    {
        public BUY_PRODUCT()
        { }
        #region Model
        private string _prodcode;
        private string _proddesc1;
        private string _proddesc2;
        private string _proddesc3;
        private string _scandesc1;
        private string _scandesc2;
        private string _scandesc3;
        private string _brandcode;
        private string _packagesizecode;
        private string _departcode;
        private string _storecode;
        private decimal? _minorderqty = 1M;
        private int? _ordertype = 0;
        private string _warehousecode;
        private string _prodclasscode;
        private string _gapprodcode;
        private int? _shelflife;
        private string _prodspec;
        private decimal? _prodlength = 1M;
        private decimal? _prodwidth = 1M;
        private decimal? _prodheight = 1M;
        private decimal? _refgp = 0M;
        private int? _nonorder = 0;
        private int? _nonsale = 0;
        private int? _consignment = 0;
        private int? _weightitem = 0;
        private int? _discallow = 1;
        private int? _couponallow = 1;
        private int? _visuaitem = 0;
        private decimal? _taxrate = 0M;
        private decimal? _importtax = 0M;
        private decimal? _insurance = 0M;
        private decimal? _freight = 0M;
        private decimal? _othersexpense = 0M;
        private string _origincountrycode;
        private int? _producttype = 1;
        private int? _modifier = 1;
        private int? _bom = 0;
        private int? _mutexflag = 0;
        private int? _onaccount = 1;
        private string _fulfillmenthousecode;
        private string _replenformulacode;
        private decimal? _discountlimit = 100M;
        private string _costccc;
        private string _costwo;
        private string _revenueccc;
        private string _revenuewo;
        private int? _quotapershopperiod = 0;
        private int? _couponsku = 0;
        private DateTime? _startdate = DateTime.Now;
        private DateTime? _enddate = DateTime.Now;
        private string _defaultpickupstorecode;
        private string _colorcode;
        private int? _intax;
        private string _additional;
        private int? _isonlinesku = 0;
        private int? _flag1 = 0;
        private int? _flag2 = 0;
        private int? _flag3 = 0;
        private int? _flag4 = 0;
        private int? _flag5 = 0;
        private int? _flag6 = 0;
        private int? _flag7 = 0;
        private int? _flag8 = 0;
        private int? _flag9 = 0;
        private int? _flag10 = 0;
        private string _memo1;
        private string _memo2;
        private string _memo3;
        private string _memo4;
        private string _memo5;
        private string _memo6;
        private string _memo7;
        private string _memo8;
        private string _memo9;
        private string _memo10;
        private DateTime? _createdon = DateTime.Now;
        private int? _createdby;
        private DateTime? _updatedon = DateTime.Now;
        private int? _updatedby;
        private string _productsizecode;
        private int? _addpointflag;
        private int? _addpointvalue;
        private string _prodpicfile;
        private int? _newflag;
        private int? _hotsaleflag;
        private decimal? _sKUWeight;
        private DateTime? _approvedOn;
        private int? _approvedBy;
        private string _storeBrandCode;
        /// <summary>
        /// 货品编码
        /// </summary>
        public string ProdCode
        {
            set { _prodcode = value; }
            get { return _prodcode; }
        }
        /// <summary>
        /// 货品名称1
        /// </summary>
        public string ProdDesc1
        {
            set { _proddesc1 = value; }
            get { return _proddesc1; }
        }
        /// <summary>
        /// 货品名称2
        /// </summary>
        public string ProdDesc2
        {
            set { _proddesc2 = value; }
            get { return _proddesc2; }
        }
        /// <summary>
        /// 货品名称3
        /// </summary>
        public string ProdDesc3
        {
            set { _proddesc3 = value; }
            get { return _proddesc3; }
        }
        /// <summary>
        /// 小票打印名称1
        /// </summary>
        public string ScanDesc1
        {
            set { _scandesc1 = value; }
            get { return _scandesc1; }
        }
        /// <summary>
        /// 小票打印名称2
        /// </summary>
        public string ScanDesc2
        {
            set { _scandesc2 = value; }
            get { return _scandesc2; }
        }
        /// <summary>
        /// 小票打印名称3
        /// </summary>
        public string ScanDesc3
        {
            set { _scandesc3 = value; }
            get { return _scandesc3; }
        }
        /// <summary>
        /// 品牌Code
        /// </summary>
        public string BrandCode
        {
            set { _brandcode = value; }
            get { return _brandcode; }
        }
        /// <summary>
        /// 包装尺寸Code
        /// </summary>
        public string PackageSizeCode
        {
            set { _packagesizecode = value; }
            get { return _packagesizecode; }
        }
        /// <summary>
        /// 部门编码
        /// </summary>
        public string DepartCode
        {
            set { _departcode = value; }
            get { return _departcode; }
        }
        /// <summary>
        /// 适用店铺ID。默认空，所有店铺适用
        /// </summary>
        public string StoreCode
        {
            set { _storecode = value; }
            get { return _storecode; }
        }
        /// <summary>
        /// 最小订单数量。（一个订单中最小销售数量）
        /// </summary>
        public decimal? MinOrderQty
        {
            set { _minorderqty = value; }
            get { return _minorderqty; }
        }
        /// <summary>
        /// 适用订单类型
        //0:All
        //1:WH Order (Order at Buying) 
        //2:Store Order (Order at Store) 
        //3:Center Order (Order at Buying) 

        /// </summary>
        public int? OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WarehouseCode
        {
            set { _warehousecode = value; }
            get { return _warehousecode; }
        }
        /// <summary>
        /// 货品大类Code
        /// </summary>
        public string ProdClassCode
        {
            set { _prodclasscode = value; }
            get { return _prodclasscode; }
        }
        /// <summary>
        /// 缺货替代货品编码
        /// </summary>
        public string GapProdCode
        {
            set { _gapprodcode = value; }
            get { return _gapprodcode; }
        }
        /// <summary>
        /// 保质天数
        /// </summary>
        public int? ShelfLife
        {
            set { _shelflife = value; }
            get { return _shelflife; }
        }
        /// <summary>
        /// 货品细节内容
        /// </summary>
        public string ProdSpec
        {
            set { _prodspec = value; }
            get { return _prodspec; }
        }
        /// <summary>
        /// 货品长度
        /// </summary>
        public decimal? ProdLength
        {
            set { _prodlength = value; }
            get { return _prodlength; }
        }
        /// <summary>
        /// 货品宽度
        /// </summary>
        public decimal? ProdWidth
        {
            set { _prodwidth = value; }
            get { return _prodwidth; }
        }
        /// <summary>
        /// 货品高度
        /// </summary>
        public decimal? ProdHeight
        {
            set { _prodheight = value; }
            get { return _prodheight; }
        }
        /// <summary>
        /// 代售货品毛利比例。（0~100 百分比）
        /// </summary>
        public decimal? RefGP
        {
            set { _refgp = value; }
            get { return _refgp; }
        }
        /// <summary>
        /// 非订单货品。 0： 不是非订单货品。 1：是非订单货品
        /// </summary>
        public int? NonOrder
        {
            set { _nonorder = value; }
            get { return _nonorder; }
        }
        /// <summary>
        /// 非销售货品。 0： 不是不能销售货品。 1：是不能销售货品
        /// </summary>
        public int? NonSale
        {
            set { _nonsale = value; }
            get { return _nonsale; }
        }
        /// <summary>
        /// 委托销售货品。（货品所有权归供应商所有）
        /// </summary>
        public int? Consignment
        {
            set { _consignment = value; }
            get { return _consignment; }
        }
        /// <summary>
        /// 称重销售货品
        /// </summary>
        public int? WeightItem
        {
            set { _weightitem = value; }
            get { return _weightitem; }
        }
        /// <summary>
        /// 是否允许折扣。0：不允许，1：允许
        /// </summary>
        public int? DiscAllow
        {
            set { _discallow = value; }
            get { return _discallow; }
        }
        /// <summary>
        /// 是否允许用Coupon支付。0：不允许，1：允许
        /// </summary>
        public int? CouponAllow
        {
            set { _couponallow = value; }
            get { return _couponallow; }
        }
        /// <summary>
        /// 虚拟货品。
        /// </summary>
        public int? VisuaItem
        {
            set { _visuaitem = value; }
            get { return _visuaitem; }
        }
        /// <summary>
        /// 税率。0：表示没税。 数值为百分比值。 
        //例如： 7， 表示 7% 的税率。
        /// </summary>
        public decimal? TaxRate
        {
            set { _taxrate = value; }
            get { return _taxrate; }
        }
        /// <summary>
        /// 进口税率。
        /// </summary>
        public decimal? ImportTax
        {
            set { _importtax = value; }
            get { return _importtax; }
        }
        /// <summary>
        /// 保险费率 （百分比）
        /// </summary>
        public decimal? Insurance
        {
            set { _insurance = value; }
            get { return _insurance; }
        }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal? Freight
        {
            set { _freight = value; }
            get { return _freight; }
        }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal? OthersExpense
        {
            set { _othersexpense = value; }
            get { return _othersexpense; }
        }
        /// <summary>
        /// 产地（国家code）
        /// </summary>
        public string OriginCountryCode
        {
            set { _origincountrycode = value; }
            get { return _origincountrycode; }
        }
        /// <summary>
        /// 货品类型：
        //1：所有库存。
        //2：本地库存。
        //3：服务类型。
        /// </summary>
        public int? ProductType
        {
            set { _producttype = value; }
            get { return _producttype; }
        }
        /// <summary>
        /// 是否允许修改。0：不允许。1：允许
        /// </summary>
        public int? Modifier
        {
            set { _modifier = value; }
            get { return _modifier; }
        }
        /// <summary>
        /// 是否BOM货品，默认0
        //0： 不是BOM主货品
        //1： 是BOM主货品
        //（所有货品都可以加入BOM中）
        /// </summary>
        public int? BOM
        {
            set { _bom = value; }
            get { return _bom; }
        }
        /// <summary>
        /// 互斥标志。 必须BOM主货品，此设置才生效。默认0。  
        /// </summary>
        public int? MutexFlag
        {
            set { _mutexflag = value; }
            get { return _mutexflag; }
        }
        /// <summary>
        /// 是否允许记账销售。0：不允许。1：允许。  默认1
        //注：此设置和POS端有关。 允许记账销售时，才可以用记账的 支付方式。

        /// </summary>
        public int? OnAccount
        {
            set { _onaccount = value; }
            get { return _onaccount; }
        }
        /// <summary>
        /// 发货仓库编号
        /// </summary>
        public string FulfillmentHouseCode
        {
            set { _fulfillmenthousecode = value; }
            get { return _fulfillmenthousecode; }
        }
        /// <summary>
        /// 自动补货公式编号
        /// </summary>
        public string ReplenFormulaCode
        {
            set { _replenformulacode = value; }
            get { return _replenformulacode; }
        }
        /// <summary>
        /// 允许的最大百分比折扣限制。 0~100， 默认100.   
        /// </summary>
        public decimal? DiscountLimit
        {
            set { _discountlimit = value; }
            get { return _discountlimit; }
        }
        /// <summary>
        /// Cost CCC
        /// </summary>
        public string CostCCC
        {
            set { _costccc = value; }
            get { return _costccc; }
        }
        /// <summary>
        /// Cost Work Order Number
        /// </summary>
        public string CostWO
        {
            set { _costwo = value; }
            get { return _costwo; }
        }
        /// <summary>
        /// Revenue CCC
        /// </summary>
        public string RevenueCCC
        {
            set { _revenueccc = value; }
            get { return _revenueccc; }
        }
        /// <summary>
        /// Revenue Work Order Number
        /// </summary>
        public string RevenueWO
        {
            set { _revenuewo = value; }
            get { return _revenuewo; }
        }
        /// <summary>
        /// 每个商店一个时期段内的配额数量
        /// </summary>
        public int? QuotaPerShopPeriod
        {
            set { _quotapershopperiod = value; }
            get { return _quotapershopperiod; }
        }
        /// <summary>
        /// 是否Coupon货品。0：不是。 1：是。 默认0
        /// </summary>
        public int? CouponSKU
        {
            set { _couponsku = value; }
            get { return _couponsku; }
        }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate
        {
            set { _startdate = value; }
            get { return _startdate; }
        }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 默认提货仓库。
        /// </summary>
        public string DefaultPickupStoreCode
        {
            set { _defaultpickupstorecode = value; }
            get { return _defaultpickupstorecode; }
        }
        /// <summary>
        /// 货品颜色
        /// </summary>
        public string ColorCode
        {
            set { _colorcode = value; }
            get { return _colorcode; }
        }
        /// <summary>
        /// 供应商的进货税率
        /// </summary>
        public int? InTax
        {
            set { _intax = value; }
            get { return _intax; }
        }
        /// <summary>
        /// 附加信息
        /// </summary>
        public string Additional
        {
            set { _additional = value; }
            get { return _additional; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag1
        {
            set { _flag1 = value; }
            get { return _flag1; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag2
        {
            set { _flag2 = value; }
            get { return _flag2; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag3
        {
            set { _flag3 = value; }
            get { return _flag3; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag4
        {
            set { _flag4 = value; }
            get { return _flag4; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag5
        {
            set { _flag5 = value; }
            get { return _flag5; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag6
        {
            set { _flag6 = value; }
            get { return _flag6; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag7
        {
            set { _flag7 = value; }
            get { return _flag7; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag8
        {
            set { _flag8 = value; }
            get { return _flag8; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag9
        {
            set { _flag9 = value; }
            get { return _flag9; }
        }
        /// <summary>
        /// 预留标志位
        /// </summary>
        public int? Flag10
        {
            set { _flag10 = value; }
            get { return _flag10; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo1
        {
            set { _memo1 = value; }
            get { return _memo1; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo2
        {
            set { _memo2 = value; }
            get { return _memo2; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo3
        {
            set { _memo3 = value; }
            get { return _memo3; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo4
        {
            set { _memo4 = value; }
            get { return _memo4; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo5
        {
            set { _memo5 = value; }
            get { return _memo5; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo6
        {
            set { _memo6 = value; }
            get { return _memo6; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo7
        {
            set { _memo7 = value; }
            get { return _memo7; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo8
        {
            set { _memo8 = value; }
            get { return _memo8; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo9
        {
            set { _memo9 = value; }
            get { return _memo9; }
        }
        /// <summary>
        /// 预留属性
        /// </summary>
        public string Memo10
        {
            set { _memo10 = value; }
            get { return _memo10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedOn
        {
            set { _createdon = value; }
            get { return _createdon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreatedBy
        {
            set { _createdby = value; }
            get { return _createdby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdatedOn
        {
            set { _updatedon = value; }
            get { return _updatedon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UpdatedBy
        {
            set { _updatedby = value; }
            get { return _updatedby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductSizeCode
        {
            set { _productsizecode = value; }
            get { return _productsizecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AddPointFlag
        {
            set { _addpointflag = value; }
            get { return _addpointflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AddPointValue
        {
            set { _addpointvalue = value; }
            get { return _addpointvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProdPicFile
        {
            set { _prodpicfile = value; }
            get { return _prodpicfile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? NewFlag
        {
            set { _newflag = value; }
            get { return _newflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? HotSaleFlag
        {
            set { _hotsaleflag = value; }
            get { return _hotsaleflag; }
        }
        /// <summary>
        /// 在线商品，将更新到SVA
        /// </summary>
        public int? isOnlineSKU
        {
            set { _isonlinesku = value; }
            get { return _isonlinesku; }
        }
        /// <summary>
        ///商品重量
        /// </summary>
        public decimal? SKUWeight
        {
            get { return _sKUWeight; }
            set { _sKUWeight = value; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public int? ApprovedBy
        {
            get { return _approvedBy; }
            set { _approvedBy = value; }
        }
       /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ApprovedOn
        {
            get { return _approvedOn; }
            set { _approvedOn = value; }
        }
        /// <summary>
        /// 店铺品牌
        /// </summary>
        public string StoreBrandCode
        {
            get { return _storeBrandCode; }
            set { _storeBrandCode = value; }
        }
        #endregion Model

    }
}

