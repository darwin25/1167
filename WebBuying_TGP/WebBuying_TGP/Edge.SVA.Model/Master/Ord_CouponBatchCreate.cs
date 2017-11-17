using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 优惠劵批量创建表
	/// </summary>
	[Serializable]
	public partial class Ord_CouponBatchCreate
	{
		public Ord_CouponBatchCreate()
		{}
		#region Model
		private string _couponcreatenumber;
		private int _coupontypeid;
		private int _couponcount;
		private string _note;
		private DateTime? _issueddate;
		private DateTime? _expirydate;
		private decimal? _initamount=0M;
		private int? _initpoints=0;
		private int? _randompwd=0;
		private string _initpassword;
		private string _approvestatus="P";
		private int _batchcouponid;
		private DateTime? _approveon;
		private int? _approveby;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private DateTime? _createdbusdate;
		private DateTime? _approvebusdate;
		private string _approvalcode;
		/// <summary>
		/// 建卡单号码， 主键
		/// </summary>
		public string CouponCreateNumber
		{
			set{ _couponcreatenumber=value;}
			get{return _couponcreatenumber;}
		}
		/// <summary>
		/// 卡等级ID
		/// </summary>
		public int CouponTypeID
		{
			set{ _coupontypeid=value;}
			get{return _coupontypeid;}
		}
		/// <summary>
		/// 卡数量
		/// </summary>
		public int CouponCount
		{
			set{ _couponcount=value;}
			get{return _couponcount;}
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
		/// 发行日期
		/// </summary>
		public DateTime? IssuedDate
		{
			set{ _issueddate=value;}
			get{return _issueddate;}
		}
		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime? ExpiryDate
		{
			set{ _expirydate=value;}
			get{return _expirydate;}
		}
		/// <summary>
		/// 初始金额
		/// </summary>
		public decimal? InitAmount
		{
			set{ _initamount=value;}
			get{return _initamount;}
		}
		/// <summary>
		/// 初始积分
		/// </summary>
		public int? InitPoints
		{
			set{ _initpoints=value;}
			get{return _initpoints;}
		}
		/// <summary>
		/// 是否初始随机密码。0：不是。1:是的。 默认0
		/// </summary>
		public int? RandomPWD
		{
			set{ _randompwd=value;}
			get{return _randompwd;}
		}
		/// <summary>
		/// 初始密码。RandomPWD=1时，不需要填
		/// </summary>
		public string InitPassword
		{
			set{ _initpassword=value;}
			get{return _initpassword;}
		}
		/// <summary>
		/// 状态： P：prepare。  A:Approve 。 V：Void
		/// </summary>
		public string ApproveStatus
		{
			set{ _approvestatus=value;}
			get{return _approvestatus;}
		}
		/// <summary>
		/// 批次号
		/// </summary>
		public int BatchCouponID
		{
			set{ _batchcouponid=value;}
			get{return _batchcouponid;}
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
		#endregion Model

	}
}

