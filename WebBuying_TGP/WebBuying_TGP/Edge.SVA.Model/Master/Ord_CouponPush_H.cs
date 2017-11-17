using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 推送优惠劵（主表）
	///（注：根据提供的UI需求，推送会员范围在主表中设置，不允许范围多选）
	/// </summary>
	[Serializable]
	public partial class Ord_CouponPush_H
	{
		public Ord_CouponPush_H()
		{}
		#region Model
		private string _couponpushnumber;
		private int? _pushcardbrandid=0;
		private int? _pushcardtypeid=0;
		private int? _pushcardgradeid=0;
		private int? _repeatpush=0;
		private string _remark;
		private DateTime? _createdbusdate;
		private DateTime? _approvebusdate;
		private string _approvalcode;
		private string _approvestatus;
		private DateTime? _approveon;
		private int? _approveby;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 优惠劵推送单号，主键
		/// </summary>
		public string CouponPushNumber
		{
			set{ _couponpushnumber=value;}
			get{return _couponpushnumber;}
		}
		/// <summary>
		/// 推送范围：卡品牌ID。 0：默认全部。
		/// </summary>
		public int? PushCardBrandID
		{
			set{ _pushcardbrandid=value;}
			get{return _pushcardbrandid;}
		}
		/// <summary>
		/// 推送范围：卡类型ID。 0：默认全部。
		/// </summary>
		public int? PushCardTypeID
		{
			set{ _pushcardtypeid=value;}
			get{return _pushcardtypeid;}
		}
		/// <summary>
		/// 推送范围：卡级别ID。 0：默认全部。
		/// </summary>
		public int? PushCardGradeID
		{
			set{ _pushcardgradeid=value;}
			get{return _pushcardgradeid;}
		}
		/// <summary>
		/// 是否重复推送。 默认0。 0：如已绑定该列表中优惠券类型的卡，不需要再绑定列表中的优惠券类型，1：相反
		/// </summary>
		public int? RepeatPush
		{
			set{ _repeatpush=value;}
			get{return _repeatpush;}
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
		/// 批核时产生授权号，并通知前台
		/// </summary>
		public string ApprovalCode
		{
			set{ _approvalcode=value;}
			get{return _approvalcode;}
		}
		/// <summary>
		/// 单据状态。状态： R：prepare。 P: Picked.  A:Approve 。 V：Void
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
		#endregion Model

	}
}

