using System;
namespace Edge.SVA.Model
{
    /// <summary>
    /// 货品部门表
    /// </summary>
    [Serializable]
    public partial class BUY_DEPARTMENT
    {
        public BUY_DEPARTMENT()
        { }
        #region Model
        private string _departcode;
        private string _departname1;
        private string _departname2;
        private string _departname3;
        private string _departpicfile;
        private string _departpicfile2;
        private string _departpicfile3;
        private string _departnote;
        private string _replenformulacode;
        private string _fulfillmenthousecode;
        private string _costccc = "      ";
        private string _costwo = "      ";
        private string _revenueccc = "      ";
        private string _revenuewo = "      ";
        private int _nonorder = 0;
        private int _nonsale = 0;
        private int _consignment = 0;
        private int _weightitem = 0;
        private int _discallow = 1;
        private int _couponallow = 1;
        private int _visuaitem = 0;
        private int? _couponsku = 0;
        private int _bom = 0;
        private int? _mutexflag = 0;
        private decimal? _discountlimit = 100M;
        private int? _onaccount = 1;
        private string _warehousecode;
        private string _defaultpickupstorecode;
        private string _additional;
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
        private string _storeBrandCode;
        /// <summary>
        ///11 部门编码
        /// </summary>
        public string DepartCode
        {
            set { _departcode = value; }
            get { return _departcode; }
        }
        /// <summary>
        ///11 部门名称1
        /// </summary>
        public string DepartName1
        {
            set { _departname1 = value; }
            get { return _departname1; }
        }
        /// <summary>
        ///11 部门名称2
        /// </summary>
        public string DepartName2
        {
            set { _departname2 = value; }
            get { return _departname2; }
        }
        /// <summary>
        ///11 部门名称3
        /// </summary>
        public string DepartName3
        {
            set { _departname3 = value; }
            get { return _departname3; }
        }
        /// <summary>
        ///11 部门图片文件
        /// </summary>
        public string DepartPicFile
        {
            set { _departpicfile = value; }
            get { return _departpicfile; }
        }
        /// <summary>
        ///11 根据要求，增加部门图片文件存储字段，存放不同语言的图片
        /// </summary>
        public string DepartPicFile2
        {
            set { _departpicfile2 = value; }
            get { return _departpicfile2; }
        }
        /// <summary>
        ///11 根据要求，增加部门图片文件存储字段，存放不同语言的图片
        /// </summary>
        public string DepartPicFile3
        {
            set { _departpicfile3 = value; }
            get { return _departpicfile3; }
        }
        /// <summary>
        ///11 部门备注
        /// </summary>
        public string DepartNote
        {
            set { _departnote = value; }
            get { return _departnote; }
        }
        /// <summary>
        ///11 自动补货公式表code
        /// </summary>
        public string ReplenFormulaCode
        {
            set { _replenformulacode = value; }
            get { return _replenformulacode; }
        }
        /// <summary>
        ///11 buy_FulfillmentHouse表Code
        /// </summary>
        public string FulfillmentHouseCode
        {
            set { _fulfillmenthousecode = value; }
            get { return _fulfillmenthousecode; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public string CostCCC
        {
            set { _costccc = value; }
            get { return _costccc; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public string CostWO
        {
            set { _costwo = value; }
            get { return _costwo; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public string RevenueCCC
        {
            set { _revenueccc = value; }
            get { return _revenueccc; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public string RevenueWO
        {
            set { _revenuewo = value; }
            get { return _revenuewo; }
        }
        /// <summary>
        ///11 非订单货品
        /// </summary>
        public int NonOrder
        {
            set { _nonorder = value; }
            get { return _nonorder; }
        }
        /// <summary>
        ///11 非零售货品
        /// </summary>
        public int NonSale
        {
            set { _nonsale = value; }
            get { return _nonsale; }
        }
        /// <summary>
        ///11 委托销售货品。（货品所有权归供应商所有）
        /// </summary>
        public int Consignment
        {
            set { _consignment = value; }
            get { return _consignment; }
        }
        /// <summary>
        ///11 称重销售货品
        /// </summary>
        public int WeightItem
        {
            set { _weightitem = value; }
            get { return _weightitem; }
        }
        /// <summary>
        ///11 是否允许折扣。0：不允许，1：允许
        /// </summary>
        public int DiscAllow
        {
            set { _discallow = value; }
            get { return _discallow; }
        }
        /// <summary>
        ///11 是否允许用Coupon支付。0：不允许，1：允许
        /// </summary>
        public int CouponAllow
        {
            set { _couponallow = value; }
            get { return _couponallow; }
        }
        /// <summary>
        ///11 虚拟货品。
        /// </summary>
        public int VisuaItem
        {
            set { _visuaitem = value; }
            get { return _visuaitem; }
        }
        /// <summary>
        ///11 是否Coupon货品。0：不是。 1：是。 默认0
        /// </summary>
        public int? CouponSKU
        {
            set { _couponsku = value; }
            get { return _couponsku; }
        }
        /// <summary>
        ///11 是否BOM货品，默认0
        ///0： 不是BOM主货品
        ///1： 是BOM主货品
        ///（所有货品都可以加入BOM中）
        /// </summary>
        public int BOM
        {
            set { _bom = value; }
            get { return _bom; }
        }
        /// <summary>
        ///11 互斥标志。 必须BOM主货品，此设置才生效。默认0。  
        /// </summary>
        public int? MutexFlag
        {
            set { _mutexflag = value; }
            get { return _mutexflag; }
        }
        /// <summary>
        ///11 允许的最大百分比折扣限制。 0~100， 默认100.   
        /// </summary>
        public decimal? DiscountLimit
        {
            set { _discountlimit = value; }
            get { return _discountlimit; }
        }
        /// <summary>
        ///11 是否允许记账销售。0：不允许。1：允许。  默认1
        ///注：此设置和POS端有关。 允许记账销售时，才可以用记账的 支付方式。
        ///
        /// </summary>
        public int? OnAccount
        {
            set { _onaccount = value; }
            get { return _onaccount; }
        }
        /// <summary>
        ///11 仓库编码
        /// </summary>
        public string WarehouseCode
        {
            set { _warehousecode = value; }
            get { return _warehousecode; }
        }
        /// <summary>
        ///11 默认提货仓库code。
        /// </summary>
        public string DefaultPickupStoreCode
        {
            set { _defaultpickupstorecode = value; }
            get { return _defaultpickupstorecode; }
        }
        /// <summary>
        ///11 附加信息
        /// </summary>
        public string Additional
        {
            set { _additional = value; }
            get { return _additional; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag1
        {
            set { _flag1 = value; }
            get { return _flag1; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag2
        {
            set { _flag2 = value; }
            get { return _flag2; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag3
        {
            set { _flag3 = value; }
            get { return _flag3; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag4
        {
            set { _flag4 = value; }
            get { return _flag4; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag5
        {
            set { _flag5 = value; }
            get { return _flag5; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag6
        {
            set { _flag6 = value; }
            get { return _flag6; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag7
        {
            set { _flag7 = value; }
            get { return _flag7; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag8
        {
            set { _flag8 = value; }
            get { return _flag8; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag9
        {
            set { _flag9 = value; }
            get { return _flag9; }
        }
        /// <summary>
        ///11 预留标志位
        /// </summary>
        public int? Flag10
        {
            set { _flag10 = value; }
            get { return _flag10; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo1
        {
            set { _memo1 = value; }
            get { return _memo1; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo2
        {
            set { _memo2 = value; }
            get { return _memo2; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo3
        {
            set { _memo3 = value; }
            get { return _memo3; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo4
        {
            set { _memo4 = value; }
            get { return _memo4; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo5
        {
            set { _memo5 = value; }
            get { return _memo5; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo6
        {
            set { _memo6 = value; }
            get { return _memo6; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo7
        {
            set { _memo7 = value; }
            get { return _memo7; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo8
        {
            set { _memo8 = value; }
            get { return _memo8; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo9
        {
            set { _memo9 = value; }
            get { return _memo9; }
        }
        /// <summary>
        ///11 预留属性
        /// </summary>
        public string Memo10
        {
            set { _memo10 = value; }
            get { return _memo10; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public DateTime? CreatedOn
        {
            set { _createdon = value; }
            get { return _createdon; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public int? CreatedBy
        {
            set { _createdby = value; }
            get { return _createdby; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public DateTime? UpdatedOn
        {
            set { _updatedon = value; }
            get { return _updatedon; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public int? UpdatedBy
        {
            set { _updatedby = value; }
            get { return _updatedby; }
        }
        public string StoreBrandCode
        {
            get { return _storeBrandCode; }
            set { _storeBrandCode = value; }
        }
        #endregion Model

    }
}

