using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 销售单主表（字段暂定）
	///表中会员部分，为本次交易中使用的会员资料。（比如CU_CardNumber是本次交易使用的卡，没有指定的话使用默认值）
	/// </summary>
	[Serializable]
	public partial class Sales_H
	{
		public Sales_H()
		{}
		#region Model
		private string _transnum;
		private int _transtype=0;
		private string _storecode;
		private string _registercode;
		private DateTime? _busdate;
		private DateTime? _txndate= DateTime.Now;
		private int _cashierid;
		private int? _salesmanid;
		private decimal _totalamount;
		private int _status;
		private decimal? _transdiscount;
		private int? _transdiscounttype=0;
		private string _transreason;
		private string _reftransnum;
		private int? _invalidateflag;
		private int? _membersalesflag=0;
		private string _memberid;
		private string _cardnumber;
		private int? _deliveryflag=0;
		private string _deliverycountry;
		private string _deliveryprovince;
		private string _deliverycity;
		private string _deliverydistrict;
		private string _deliveryaddressdetail;
		private string _deliveryfulladdress;
		private string _deliverynumber;
		private DateTime? _requestdeliverydate;
		private DateTime? _deliverydate;
		private int? _deliveryby;
		private string _contact;
		private string _contactphone;
		private int? _pickuptype=1;
		private string _pickupstorecode;
		private int? _codflag=0;
		private string _remark;
		private DateTime? _settlementdate;
		private int? _settlementstaffid;
		private DateTime? _paysettledate;
		private DateTime? _completedate;
		private string _salesreceipt;
		private byte[] _salesreceiptbin;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private int? _logisticsproviderid;
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
		public int TransType
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
		/// 收银员ID
		/// </summary>
		public int CashierID
		{
			set{ _cashierid=value;}
			get{return _cashierid;}
		}
		/// <summary>
		/// 销售员ID
		/// </summary>
		public int? SalesManID
		{
			set{ _salesmanid=value;}
			get{return _salesmanid;}
		}
		/// <summary>
		/// 总销售金额.（已经减去TransDiscount）
		/// </summary>
		public decimal TotalAmount
		{
			set{ _totalamount=value;}
			get{return _totalamount;}
		}
		/// <summary>
		/// 交易状态。（2013.06.06增加status=0，表示在购物车中）
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 整单折扣 （Sales off ）
		/// </summary>
		public decimal? TransDiscount
		{
			set{ _transdiscount=value;}
			get{return _transdiscount;}
		}
		/// <summary>
		/// 整单折扣内容的类型。 0：没有折扣。1：金额。 2：百分比
		/// </summary>
		public int? TransDiscountType
		{
			set{ _transdiscounttype=value;}
			get{return _transdiscounttype;}
		}
		/// <summary>
		/// 整单原因
		/// </summary>
		public string TransReason
		{
			set{ _transreason=value;}
			get{return _transreason;}
		}
		/// <summary>
		/// 原单号
		/// </summary>
		public string RefTransNum
		{
			set{ _reftransnum=value;}
			get{return _reftransnum;}
		}
		/// <summary>
		/// 订单无效标志。订单无效时，状态为完成。 默认0
		/// </summary>
		public int? InvalidateFlag
		{
			set{ _invalidateflag=value;}
			get{return _invalidateflag;}
		}
		/// <summary>
		/// 是否会员销售。默认0.
		/// </summary>
		public int? MemberSalesFlag
		{
			set{ _membersalesflag=value;}
			get{return _membersalesflag;}
		}
		/// <summary>
		/// 会员号码。 MemberSalesFlag = 1时需要填
		/// </summary>
		public string MemberID
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 会员卡号码。 MemberSalesFlag = 1时需要填
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
		}
		/// <summary>
		/// 送货标志。0： 自提，不送货。 1：送货
		/// </summary>
		public int? DeliveryFlag
		{
			set{ _deliveryflag=value;}
			get{return _deliveryflag;}
		}
		/// <summary>
		/// 送货所在国家（存放Country表Code）
		/// </summary>
		public string DeliveryCountry
		{
			set{ _deliverycountry=value;}
			get{return _deliverycountry;}
		}
		/// <summary>
		/// 送货所在省 （存放Province表Code）
		/// </summary>
		public string DeliveryProvince
		{
			set{ _deliveryprovince=value;}
			get{return _deliveryprovince;}
		}
		/// <summary>
		/// 送货所在城市 （存放City表Code）
		/// </summary>
		public string DeliveryCity
		{
			set{ _deliverycity=value;}
			get{return _deliverycity;}
		}
		/// <summary>
		/// 送货地址所在区县 （存放District表Code）
		/// </summary>
		public string DeliveryDistrict
		{
			set{ _deliverydistrict=value;}
			get{return _deliverydistrict;}
		}
		/// <summary>
		/// 送货详细地址
		/// </summary>
		public string DeliveryAddressDetail
		{
			set{ _deliveryaddressdetail=value;}
			get{return _deliveryaddressdetail;}
		}
		/// <summary>
		/// 送货完整地址
		/// </summary>
		public string DeliveryFullAddress
		{
			set{ _deliveryfulladdress=value;}
			get{return _deliveryfulladdress;}
		}
		/// <summary>
		/// 送货单号码
		/// </summary>
		public string DeliveryNumber
		{
			set{ _deliverynumber=value;}
			get{return _deliverynumber;}
		}
		/// <summary>
		/// 要求送货日期  （system date）
		/// </summary>
		public DateTime? RequestDeliveryDate
		{
			set{ _requestdeliverydate=value;}
			get{return _requestdeliverydate;}
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
		/// 收货联系人
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 联系人电话
		/// </summary>
		public string ContactPhone
		{
			set{ _contactphone=value;}
			get{return _contactphone;}
		}
		/// <summary>
		/// 提货方式。默认1
		/// </summary>
		public int? PickupType
		{
			set{ _pickuptype=value;}
			get{return _pickuptype;}
		}
		/// <summary>
		/// 提货店铺编号。 （PickupType=1 时有效）
		/// </summary>
		public string PickupStoreCode
		{
			set{ _pickupstorecode=value;}
			get{return _pickupstorecode;}
		}
		/// <summary>
		/// 货到付款标志。默认 0
		/// </summary>
		public int? CODFlag
		{
			set{ _codflag=value;}
			get{return _codflag;}
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
		/// 提货最后完成日期。（business date）
		/// </summary>
		public DateTime? SettlementDate
		{
			set{ _settlementdate=value;}
			get{return _settlementdate;}
		}
		/// <summary>
		/// 提货最后确认人
		/// </summary>
		public int? SettlementStaffID
		{
			set{ _settlementstaffid=value;}
			get{return _settlementstaffid;}
		}
		/// <summary>
		/// 支付最后完成日期。（business date）
		/// </summary>
		public DateTime? PaySettleDate
		{
			set{ _paysettledate=value;}
			get{return _paysettledate;}
		}
		/// <summary>
		/// 交易单最终完成日期 （business date）
		/// </summary>
		public DateTime? CompleteDate
		{
			set{ _completedate=value;}
			get{return _completedate;}
		}
		/// <summary>
		/// 销售小票（格式文本）
		/// </summary>
		public string SalesReceipt
		{
			set{ _salesreceipt=value;}
			get{return _salesreceipt;}
		}
		/// <summary>
		/// 销售小票（二进制格式）
		/// </summary>
		public byte[] SalesReceiptBIN
		{
			set{ _salesreceiptbin=value;}
			get{return _salesreceiptbin;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		/// 创建人
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
		/// <summary>
		/// 
		/// </summary>
		public int? LogisticsProviderID
		{
			set{ _logisticsproviderid=value;}
			get{return _logisticsproviderid;}
		}
		#endregion Model

	}
}

