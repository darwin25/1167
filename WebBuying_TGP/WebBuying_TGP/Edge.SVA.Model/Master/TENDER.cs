using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 支付类型表
	/// </summary>
	[Serializable]
	public partial class TENDER
	{
		public TENDER()
		{}
		#region Model
		private int _tenderid;
		private string _tendercode;
		private int? _tendertyep;
		private string _tendername1;
		private string _tendername2;
		private string _tendername3;
		private int? _cashsale=0;
		private int? _status=1;
		private decimal? _base=0.01M;
		private decimal? _rate=1M;
		private decimal? _minamount;
		private decimal? _maxamount;
		private string _cardbegin;
		private string _cardend;
		private int? _cardlen;
		private string _additional;
		private int? _bankid;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键
		/// </summary>
		public int TenderID
		{
			set{ _tenderid=value;}
			get{return _tenderid;}
		}
		/// <summary>
		/// 支付类型编码
		/// </summary>
		public string TenderCode
		{
			set{ _tendercode=value;}
			get{return _tendercode;}
		}
		/// <summary>
		/// 支付类型种类
		/// </summary>
		public int? TenderTyep
		{
			set{ _tendertyep=value;}
			get{return _tendertyep;}
		}
		/// <summary>
		/// 支付类型名称1
		/// </summary>
		public string TenderName1
		{
			set{ _tendername1=value;}
			get{return _tendername1;}
		}
		/// <summary>
		/// 支付类型名称2
		/// </summary>
		public string TenderName2
		{
			set{ _tendername2=value;}
			get{return _tendername2;}
		}
		/// <summary>
		/// 支付类型名称3
		/// </summary>
		public string TenderName3
		{
			set{ _tendername3=value;}
			get{return _tendername3;}
		}
		/// <summary>
		/// 是否现金类型。0：不是。1：是的。默认0
		/// </summary>
		public int? CashSale
		{
			set{ _cashsale=value;}
			get{return _cashsale;}
		}
		/// <summary>
		/// 支付类型状态。0：无效。1：有效。默认1
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 基点. 默认0.01
		/// </summary>
		public decimal? Base
		{
			set{ _base=value;}
			get{return _base;}
		}
		/// <summary>
		/// 汇率.默认1
		/// </summary>
		public decimal? Rate
		{
			set{ _rate=value;}
			get{return _rate;}
		}
		/// <summary>
		/// 单笔最小支付金额
		/// </summary>
		public decimal? MinAmount
		{
			set{ _minamount=value;}
			get{return _minamount;}
		}
		/// <summary>
		/// 单笔最大支付金额
		/// </summary>
		public decimal? MaxAmount
		{
			set{ _maxamount=value;}
			get{return _maxamount;}
		}
		/// <summary>
		/// 卡号起始字符串
		/// </summary>
		public string CardBegin
		{
			set{ _cardbegin=value;}
			get{return _cardbegin;}
		}
		/// <summary>
		/// 卡号结尾字符串
		/// </summary>
		public string CardEnd
		{
			set{ _cardend=value;}
			get{return _cardend;}
		}
		/// <summary>
		/// 卡号长度
		/// </summary>
		public int? CardLen
		{
			set{ _cardlen=value;}
			get{return _cardlen;}
		}
		/// <summary>
		/// 附加信息。如果是卡的话，就存放卡号
		/// </summary>
		public string Additional
		{
			set{ _additional=value;}
			get{return _additional;}
		}
		/// <summary>
		/// 银行ID
		/// </summary>
		public int? BankID
		{
			set{ _bankid=value;}
			get{return _bankid;}
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
		/// 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

