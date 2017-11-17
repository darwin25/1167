using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 促销头表。 （包含所有被动促销设置.  促销会根据具体的销售单，顾客情况，自动匹配合适的促销方案）
	/// </summary>
	[Serializable]
	public partial class Promotion_H
	{
		public Promotion_H()
		{}
		#region Model
		private string _promotioncode;
		private string _promotiondesc1;
		private string _promotiondesc2;
		private string _promotiondesc3;
		private string _promotionnote;
		private int? _storeid;
		private int? _storegroupid;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private DateTime? _starttime= null;
		private DateTime? _endtime= null;
		private string _dayflagcode;
		private string _weekflagcode;
		private string _monthflagcode;
		private int? _loyaltyflag=0;
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
		/// 促销编码
		/// </summary>
		public string PromotionCode
		{
			set{ _promotioncode=value;}
			get{return _promotioncode;}
		}
		/// <summary>
		/// 促销描述1
		/// </summary>
		public string PromotionDesc1
		{
			set{ _promotiondesc1=value;}
			get{return _promotiondesc1;}
		}
		/// <summary>
		/// 促销描述2
		/// </summary>
		public string PromotionDesc2
		{
			set{ _promotiondesc2=value;}
			get{return _promotiondesc2;}
		}
		/// <summary>
		/// 促销描述3
		/// </summary>
		public string PromotionDesc3
		{
			set{ _promotiondesc3=value;}
			get{return _promotiondesc3;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string PromotionNote
		{
			set{ _promotionnote=value;}
			get{return _promotionnote;}
		}
		/// <summary>
		/// 适用的店铺ID。0/NULL： 表示所有。
		/// </summary>
		public int? StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 这组价格针对的店铺组ID。0/NULL： 表示所有
		/// </summary>
		public int? StoreGroupID
		{
			set{ _storegroupid=value;}
			get{return _storegroupid;}
		}
		/// <summary>
		/// 生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 失效日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 促销生效时间（例如 上午9:00），默认0表示全天有效
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 促销失效时间（例如 下午20:00），默认0表示全天有效
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 一月中促销生效日 （Buy_DayFlag表Code）
		/// </summary>
		public string DayFlagCode
		{
			set{ _dayflagcode=value;}
			get{return _dayflagcode;}
		}
		/// <summary>
		/// 一周中促销生效日 （Buy_WeekFlag表Code）
		/// </summary>
		public string WeekFlagCode
		{
			set{ _weekflagcode=value;}
			get{return _weekflagcode;}
		}
		/// <summary>
		/// 促销生效月 （Buy_MonthFlag表Code）
		/// </summary>
		public string MonthFlagCode
		{
			set{ _monthflagcode=value;}
			get{return _monthflagcode;}
		}
		/// <summary>
		/// 是否仅会员促销。0：不是。1：是的
		/// </summary>
		public int? LoyaltyFlag
		{
			set{ _loyaltyflag=value;}
			get{return _loyaltyflag;}
		}
		/// <summary>
		/// 促销创建时的busdate
		/// </summary>
		public DateTime? CreatedBusDate
		{
			set{ _createdbusdate=value;}
			get{return _createdbusdate;}
		}
		/// <summary>
		/// 促销批核时的busdate
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
		/// 单据状态。状态： P：Pending。  A:Approve 。 V：Void
		/// </summary>
		public string ApproveStatus
		{
			set{ _approvestatus=value;}
			get{return _approvestatus;}
		}
		/// <summary>
		/// 批核时间
		/// </summary>
		public DateTime? ApproveOn
		{
			set{ _approveon=value;}
			get{return _approveon;}
		}
		/// <summary>
		/// 批核人
		/// </summary>
		public int? ApproveBy
		{
			set{ _approveby=value;}
			get{return _approveby;}
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
		#endregion Model

	}
}

