using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 销售订单明细
    /// 创建者：Lisa
    /// 创建时间：2016-1-2
	/// </summary>
	[Serializable]
	public partial class Sales_D
	{
		public Sales_D()
		{}
		#region Model
		private string _seqno;
		private string _transnum;
		private int? _transtype=0;
		private string _storecode;
		private string _registercode;
		private DateTime? _busdate;
		private DateTime? _txndate= DateTime.Now;
		private string _prodcode;
		private string _proddesc;
		private string _departcode;
		private decimal? _qty;
		private decimal? _orgprice;
		private decimal? _unitprice;
		private decimal? _netprice;
		private decimal? _orgamount;
		private decimal? _unitamount;
		private decimal? _netamount;
		private decimal? _totalqty;
		private decimal? _discountprice;
		private decimal? _discountamount;
		private decimal? _poprice;
		private decimal? _extraprice;
		private string _poreasoncode;
		private string _additional1;
		private string _additional2;
		private string _additional3;
		private string _rpricetypecode;
		private int? _isbom=0;
		private int? _iscoupon=0;
		private int? _isbuyback=0;
		private int? _isservice=0;
		private int? _serialnostockflag=0;
		private int? _serialnotype;
		private string _serialno;
		private string _imei;
		private string _stocktypecode;
		private int? _collected;
		private DateTime? _reserveddate;
		private string _pickuplocation;
		private string _pickupstaff;
		private DateTime? _pickupdate;
		private DateTime? _deliverydate;
		private int? _deliveryby;
		private decimal? _actprice=0M;
		private decimal? _actamount=0M;
		private string _orgtransnum;
		private string _orgseqno;
		private string _remark;
		private string _refguid;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 交易单中货品序号
		/// </summary>
		public string SeqNo
		{
			set{ _seqno=value;}
			get{return _seqno;}
		}
		/// <summary>
		/// 交易号
		/// </summary>
		public string TransNum
		{
			set{ _transnum=value;}
			get{return _transnum;}
		}
		/// <summary>
		/// 交易类型
		/// </summary>
		public int? TransType
		{
			set{ _transtype=value;}
			get{return _transtype;}
		}
		/// <summary>
		/// 店铺编码
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		/// POS机编码
		/// </summary>
		public string RegisterCode
		{
			set{ _registercode=value;}
			get{return _registercode;}
		}
		/// <summary>
		/// 交易日期。（business date）
		/// </summary>
		public DateTime? BusDate
		{
			set{ _busdate=value;}
			get{return _busdate;}
		}
		/// <summary>
		/// 交易日期时间。（system date）
		/// </summary>
		public DateTime? TxnDate
		{
			set{ _txndate=value;}
			get{return _txndate;}
		}
		/// <summary>
		/// 货品编码
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 货品名称
		/// </summary>
		public string ProdDesc
		{
			set{ _proddesc=value;}
			get{return _proddesc;}
		}
		/// <summary>
		/// 部门编码
		/// </summary>
		public string DepartCode
		{
			set{ _departcode=value;}
			get{return _departcode;}
		}
		/// <summary>
		/// 货品数量
		/// </summary>
		public decimal? Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 货品原始价格
		/// </summary>
		public decimal? OrgPrice
		{
			set{ _orgprice=value;}
			get{return _orgprice;}
		}
		/// <summary>
		/// 货品销售价格
		/// </summary>
		public decimal? UnitPrice
		{
			set{ _unitprice=value;}
			get{return _unitprice;}
		}
		/// <summary>
		/// 货品实际销售价格。（包括了折扣，改价 ...）
		/// </summary>
		public decimal? NetPrice
		{
			set{ _netprice=value;}
			get{return _netprice;}
		}
		/// <summary>
		///  = TotalQty * OrgPrice
		/// </summary>
		public decimal? OrgAmount
		{
			set{ _orgamount=value;}
			get{return _orgamount;}
		}
		/// <summary>
		///  = TotalQty * UnitPrice
		/// </summary>
		public decimal? UnitAmount
		{
			set{ _unitamount=value;}
			get{return _unitamount;}
		}
		/// <summary>
		///  = TotalQty * NetPrice
		/// </summary>
		public decimal? NetAmount
		{
			set{ _netamount=value;}
			get{return _netamount;}
		}
		/// <summary>
		/// 货品总数量。（一般情况等同Qty，BOM子货品时 = Qty * BOM主货品数量）
		/// </summary>
		public decimal? TotalQty
		{
			set{ _totalqty=value;}
			get{return _totalqty;}
		}
		/// <summary>
		/// 货品折扣掉的价格（sale off）（一般情况DiscountPrice为负数：NetPrice= UnitPrice+DiscountPrice）
		/// </summary>
		public decimal? DiscountPrice
		{
			set{ _discountprice=value;}
			get{return _discountprice;}
		}
		/// <summary>
		/// 货品折扣掉的金额（sale off）（= TotalQty * DiscountPrice）
		/// </summary>
		public decimal? DiscountAmount
		{
			set{ _discountamount=value;}
			get{return _discountamount;}
		}
		/// <summary>
		/// 货品改价扣除的价格（sale off）（一般情况DiscountPrice为负数：NetPrice= UnitPrice+POPrice）。 DiscountPrice 和 POPrice同时发生时，优先PO，在PO的基础上discount，不算作折上折。
		/// </summary>
		public decimal? POPrice
		{
			set{ _poprice=value;}
			get{return _poprice;}
		}
		/// <summary>
		/// 附加价格。（除正常价格外额外的价格，一般是BOM子货品）
		/// </summary>
		public decimal? ExtraPrice
		{
			set{ _extraprice=value;}
			get{return _extraprice;}
		}
		/// <summary>
		/// 改价原因编码
		/// </summary>
		public string POReasonCode
		{
			set{ _poreasoncode=value;}
			get{return _poreasoncode;}
		}
		/// <summary>
		/// 货品附加信息1
		/// </summary>
		public string Additional1
		{
			set{ _additional1=value;}
			get{return _additional1;}
		}
		/// <summary>
		/// 货品附加信息2
		/// </summary>
		public string Additional2
		{
			set{ _additional2=value;}
			get{return _additional2;}
		}
		/// <summary>
		/// 货品附加信息3
		/// </summary>
		public string Additional3
		{
			set{ _additional3=value;}
			get{return _additional3;}
		}
		/// <summary>
		/// 零售价类型。
		/// </summary>
		public string RPriceTypeCode
		{
			set{ _rpricetypecode=value;}
			get{return _rpricetypecode;}
		}
		/// <summary>
		/// 是否BOM货品（主货品）。 0：不是， 1：是的
		/// </summary>
		public int? IsBOM
		{
			set{ _isbom=value;}
			get{return _isbom;}
		}
		/// <summary>
		/// 是否Coupon货品。 0：不是， 1：是的
		/// </summary>
		public int? IsCoupon
		{
			set{ _iscoupon=value;}
			get{return _iscoupon;}
		}
		/// <summary>
		/// 是否BuyBack货品。 0：不是， 1：是的
		/// </summary>
		public int? IsBuyBack
		{
			set{ _isbuyback=value;}
			get{return _isbuyback;}
		}
		/// <summary>
		/// 是否服务类货品。 0：不是， 1：是的
		/// </summary>
		public int? IsService
		{
			set{ _isservice=value;}
			get{return _isservice;}
		}
		/// <summary>
		/// SerialNo是否有库存。 0：不是， 1：是的
		/// </summary>
		public int? SerialNoStockFlag
		{
			set{ _serialnostockflag=value;}
			get{return _serialnostockflag;}
		}
		/// <summary>
		/// SerialNo的类型
		/// </summary>
		public int? SerialNoType
		{
			set{ _serialnotype=value;}
			get{return _serialnotype;}
		}
		/// <summary>
		/// 货品唯一序号
		/// </summary>
		public string SerialNo
		{
			set{ _serialno=value;}
			get{return _serialno;}
		}
		/// <summary>
		/// 电子设备唯一标示
		/// </summary>
		public string IMEI
		{
			set{ _imei=value;}
			get{return _imei;}
		}
		/// <summary>
		/// 销售货品的库存类型。（和扣库有关）
		/// </summary>
		public string StockTypeCode
		{
			set{ _stocktypecode=value;}
			get{return _stocktypecode;}
		}
		/// <summary>
		/// 货品提货状态。
		/// </summary>
		public int? Collected
		{
			set{ _collected=value;}
			get{return _collected;}
		}
		/// <summary>
		/// 预留日期
		/// </summary>
		public DateTime? ReservedDate
		{
			set{ _reserveddate=value;}
			get{return _reserveddate;}
		}
		/// <summary>
		/// 提货仓库（店铺）
		/// </summary>
		public string PickupLocation
		{
			set{ _pickuplocation=value;}
			get{return _pickuplocation;}
		}
		/// <summary>
		/// 提货人
		/// </summary>
		public string PickupStaff
		{
			set{ _pickupstaff=value;}
			get{return _pickupstaff;}
		}
		/// <summary>
		/// 提货日期 （business date）
		/// </summary>
		public DateTime? PickupDate
		{
			set{ _pickupdate=value;}
			get{return _pickupdate;}
		}
		/// <summary>
		/// 货物送达日期   （system date）
		/// </summary>
		public DateTime? DeliveryDate
		{
			set{ _deliverydate=value;}
			get{return _deliverydate;}
		}
		/// <summary>
		/// 送货人ID
		/// </summary>
		public int? DeliveryBy
		{
			set{ _deliveryby=value;}
			get{return _deliveryby;}
		}
		/// <summary>
		/// BOM时有效。数据为货品在整个BOM中分摊的单价
		/// </summary>
		public decimal? ActPrice
		{
			set{ _actprice=value;}
			get{return _actprice;}
		}
		/// <summary>
		/// = ActPrice * （TotalQty / Qty）
		/// </summary>
		public decimal? ActAmount
		{
			set{ _actamount=value;}
			get{return _actamount;}
		}
		/// <summary>
		/// 原单交易号
		/// </summary>
		public string OrgTransNum
		{
			set{ _orgtransnum=value;}
			get{return _orgtransnum;}
		}
		/// <summary>
		/// 原单对应的salesD记录
		/// </summary>
		public string OrgSeqNo
		{
			set{ _orgseqno=value;}
			get{return _orgseqno;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 预留，外部编码
		/// </summary>
		public string RefGUID
		{
			set{ _refguid=value;}
			get{return _refguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

