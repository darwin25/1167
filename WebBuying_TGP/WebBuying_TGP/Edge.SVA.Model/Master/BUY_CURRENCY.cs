using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货币支付表
	/// </summary>
	[Serializable]
	public partial class BUY_CURRENCY
	{
		public BUY_CURRENCY()
		{}
		#region Model
		private int _currencyid;
		private string _currencycode;
		private string _currencyname1;
		private string _currencyname2;
		private string _currencyname3;
		private decimal _rate=1M;
		private int _tendertype;
		private int _status;
		private int _cashsale;
		private int _couponvalue;
		private decimal _base;
		private decimal _minamt;
		private decimal _maxamt;
		private string _cardtype;
		private string _cardbegin;
		private string _cardend;
		private int? _cardlen;
		private string _accountcode;
		private string _contracode;
		private int? _paytransfer=0;
		private int? _refund_type=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 货币ID
		/// </summary>
		public int CurrencyID
		{
			set{ _currencyid=value;}
			get{return _currencyid;}
		}
		/// <summary>
		///11 货币编码
		/// </summary>
		public string CurrencyCode
		{
			set{ _currencycode=value;}
			get{return _currencycode;}
		}
		/// <summary>
		///11 货币名称1
		/// </summary>
		public string CurrencyName1
		{
			set{ _currencyname1=value;}
			get{return _currencyname1;}
		}
		/// <summary>
		///11 货币名称2
		/// </summary>
		public string CurrencyName2
		{
			set{ _currencyname2=value;}
			get{return _currencyname2;}
		}
		/// <summary>
		///11 货币名称3
		/// </summary>
		public string CurrencyName3
		{
			set{ _currencyname3=value;}
			get{return _currencyname3;}
		}
		/// <summary>
		///11 汇率
		/// </summary>
		public decimal Rate
		{
			set{ _rate=value;}
			get{return _rate;}
		}
		/// <summary>
		///11 支付类型（1是本币，其他暂定。）：  
		///0:  Type, This record just Type
		///1:  Local Cash  (只能有一个)
		///2:  Foreign Cash
		///3:  Cheque
		///4:  Credit Card
		///5:  Debit Card
		///6:  EPS Card
		///7:  Coupon
		///8:  Credit Card Installment
		///9:  Finance House Installment
		///10: On Account
		///11: On Account Inter Client
		///12: Credit Card Group
		///15: Burn Point
		///
		/// </summary>
		public int TenderType
		{
			set{ _tendertype=value;}
			get{return _tendertype;}
		}
		/// <summary>
		///11 状态。1：有效。 0：无效
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		///11 是否现金货币。 1：是。 0：不是
		/// </summary>
		public int CashSale
		{
			set{ _cashsale=value;}
			get{return _cashsale;}
		}
		/// <summary>
		///11 是否优惠劵性质。1：是。 0：不是
		/// </summary>
		public int CouponValue
		{
			set{ _couponvalue=value;}
			get{return _couponvalue;}
		}
		/// <summary>
		///11 最小单位
		/// </summary>
		public decimal Base
		{
			set{ _base=value;}
			get{return _base;}
		}
		/// <summary>
		///11 最小支付金额
		/// </summary>
		public decimal MinAmt
		{
			set{ _minamt=value;}
			get{return _minamt;}
		}
		/// <summary>
		///11 最大支付金额
		/// </summary>
		public decimal MaxAmt
		{
			set{ _maxamt=value;}
			get{return _maxamt;}
		}
		/// <summary>
		///11 卡类型。（卡类型货币）
		/// </summary>
		public string CardType
		{
			set{ _cardtype=value;}
			get{return _cardtype;}
		}
		/// <summary>
		///11 卡号号码范围（开始）。（卡类型货币）
		/// </summary>
		public string CardBegin
		{
			set{ _cardbegin=value;}
			get{return _cardbegin;}
		}
		/// <summary>
		///11 卡号号码范围（结束）。（卡类型货币）
		/// </summary>
		public string CardEnd
		{
			set{ _cardend=value;}
			get{return _cardend;}
		}
		/// <summary>
		///11 卡号长度。（卡类型货币）
		/// </summary>
		public int? CardLen
		{
			set{ _cardlen=value;}
			get{return _cardlen;}
		}
		/// <summary>
		///11 账号代码
		/// </summary>
		public string AccountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		///11 对冲账号代码
		/// </summary>
		public string ContraCode
		{
			set{ _contracode=value;}
			get{return _contracode;}
		}
		/// <summary>
		///11 是否exchange的tender。 1是的。0不是
		/// </summary>
		public int? PayTransfer
		{
			set{ _paytransfer=value;}
			get{return _paytransfer;}
		}
		/// <summary>
		///11 是否refund的tender。 1是的。0不是
		/// </summary>
		public int? Refund_Type
		{
			set{ _refund_type=value;}
			get{return _refund_type;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

