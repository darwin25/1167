using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 转赠单据表
	/// </summary>
	[Serializable]
	public partial class Ord_CardTransfer
	{
		public Ord_CardTransfer()
		{}
		#region Model
		private string _cardtransfernumber;
		private string _sourcecardnumber;
		private string _destcardnumber;
		private string _originaltxnno;
		private DateTime? _txndate;
		private string _storecode;
		private string _servercode;
		private string _registercode;
		private int? _reasonid;
		private string _note;
		private decimal _actamount;
		private int? _actpoints;
		private string _actcouponnumbers;
		private string _approvestatus;
		private DateTime? _approveon;
		private int? _approveby;
		private DateTime? _createdon;
		private int? _createdby;
		private DateTime? _updatedon;
		private int? _updatedby;
		private DateTime? _createdbusdate;
		private DateTime? _approvebusdate;
		private string _approvalcode;
		private string _brandcode;
		/// <summary>
		/// 单据号码，主键
		/// </summary>
		public string CardTransferNumber
		{
			set{ _cardtransfernumber=value;}
			get{return _cardtransfernumber;}
		}
		/// <summary>
		/// 转出的卡号
		/// </summary>
		public string SourceCardNumber
		{
			set{ _sourcecardnumber=value;}
			get{return _sourcecardnumber;}
		}
		/// <summary>
		/// 转入的卡号
		/// </summary>
		public string DestCardNumber
		{
			set{ _destcardnumber=value;}
			get{return _destcardnumber;}
		}
		/// <summary>
		/// 关联的原始单据号
		/// </summary>
		public string OriginalTxnNo
		{
			set{ _originaltxnno=value;}
			get{return _originaltxnno;}
		}
		/// <summary>
		/// 交易日期
		/// </summary>
		public DateTime? TxnDate
		{
			set{ _txndate=value;}
			get{return _txndate;}
		}
		/// <summary>
		/// 店铺编号
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		/// 服务器编号
		/// </summary>
		public string ServerCode
		{
			set{ _servercode=value;}
			get{return _servercode;}
		}
		/// <summary>
		/// 终端编号
		/// </summary>
		public string RegisterCode
		{
			set{ _registercode=value;}
			get{return _registercode;}
		}
		/// <summary>
		/// 转移原因
		/// </summary>
		public int? ReasonID
		{
			set{ _reasonid=value;}
			get{return _reasonid;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 转移金额
		/// </summary>
		public decimal ActAmount
		{
			set{ _actamount=value;}
			get{return _actamount;}
		}
		/// <summary>
		/// 转移积分
		/// </summary>
		public int? ActPoints
		{
			set{ _actpoints=value;}
			get{return _actpoints;}
		}
		/// <summary>
		/// coupon列表。 例如： ‘0010001’，‘0020003’
		/// </summary>
		public string ActCouponNumbers
		{
			set{ _actcouponnumbers=value;}
			get{return _actcouponnumbers;}
		}
		/// <summary>
		/// 单据状态。状态： P：prepare。  A:Approve 。 V：Void
		/// </summary>
		public string ApproveStatus
		{
			set{ _approvestatus=value;}
			get{return _approvestatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ApproveOn
		{
			set{ _approveon=value;}
			get{return _approveon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApproveBy
		{
			set{ _approveby=value;}
			get{return _approveby;}
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
		/// <summary>
		/// 单据创建时的busdate
		/// </summary>
		public DateTime? CreatedBusDate
		{
			set{ _createdbusdate=value;}
			get{return _createdbusdate;}
		}
		/// <summary>
		/// 单据批核时的busdate
		/// </summary>
		public DateTime? ApproveBusDate
		{
			set{ _approvebusdate=value;}
			get{return _approvebusdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApprovalCode
		{
			set{ _approvalcode=value;}
			get{return _approvalcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BrandCode
		{
			set{ _brandcode=value;}
			get{return _brandcode;}
		}
		#endregion Model

	}
}

