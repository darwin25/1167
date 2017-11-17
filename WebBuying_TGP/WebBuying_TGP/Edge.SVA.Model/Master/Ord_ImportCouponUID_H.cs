using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 导入Coupon的UID。（销售实体coupon时，导入实体coupon的号码）
	/// </summary>
	[Serializable]
	public partial class Ord_ImportCouponUID_H
	{
		public Ord_ImportCouponUID_H()
		{}
		#region Model
		private string _importcouponnumber;
		private string _importcoupondesc1;
		private string _importcoupondesc2;
		private string _importcoupondesc3;
		private int? _needactive=0;
		private int? _neednewbatch=1;
		private int? _couponcount;
		private string _approvestatus;
		private DateTime? _approveon= DateTime.Now;
		private int? _approveby;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private DateTime? _createdbusdate;
		private DateTime? _approvebusdate;
		private string _approvalcode;
		/// <summary>
		/// 主键。导入单号
		/// </summary>
		public string ImportCouponNumber
		{
			set{ _importcouponnumber=value;}
			get{return _importcouponnumber;}
		}
		/// <summary>
		/// 单据描述1
		/// </summary>
		public string ImportCouponDesc1
		{
			set{ _importcoupondesc1=value;}
			get{return _importcoupondesc1;}
		}
		/// <summary>
		/// 单据描述2
		/// </summary>
		public string ImportCouponDesc2
		{
			set{ _importcoupondesc2=value;}
			get{return _importcoupondesc2;}
		}
		/// <summary>
		/// 单据描述3
		/// </summary>
		public string ImportCouponDesc3
		{
			set{ _importcoupondesc3=value;}
			get{return _importcoupondesc3;}
		}
		/// <summary>
		/// 绑定时激活Coupon。0：不激活。1：激活
		/// </summary>
		public int? NeedActive
		{
			set{ _needactive=value;}
			get{return _needactive;}
		}
		/// <summary>
		/// 是否先创建新批次的coupon，使用这些新的coupon来绑定。0：不创建，使用已有的coupon，没有足够coupon则报错。 1：先创建此数量的Coupon，再绑定这些coupon。
		/// </summary>
		public int? NeedNewBatch
		{
			set{ _neednewbatch=value;}
			get{return _neednewbatch;}
		}
		/// <summary>
		/// Coupon的数量
		/// </summary>
		public int? CouponCount
		{
			set{ _couponcount=value;}
			get{return _couponcount;}
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
		#endregion Model

	}
}

