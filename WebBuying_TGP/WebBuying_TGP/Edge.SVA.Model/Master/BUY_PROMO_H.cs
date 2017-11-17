using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 促销设置主表
	/// </summary>
	[Serializable]
	public partial class BUY_PROMO_H
	{
		public BUY_PROMO_H()
		{}
		#region Model
		private string _promotioncode;
		private string _description1;
		private string _description2;
		private string _description3;
		private string _storecode;
		private string _storegroupcode;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private string _dayflagcode;
		private string _weekflagcode;
		private string _monthflagcode;
		private int? _memberpromotionflag=0;
		private string _cardtypecode;
		private string _cardgradecode;
		private int? _birthdayflag=0;
		private string _note;
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
		///11 主键
		/// </summary>
		public string PromotionCode
		{
			set{ _promotioncode=value;}
			get{return _promotioncode;}
		}
		/// <summary>
		///11 促销描述1
		/// </summary>
		public string Description1
		{
			set{ _description1=value;}
			get{return _description1;}
		}
		/// <summary>
		///11 促销描述2
		/// </summary>
		public string Description2
		{
			set{ _description2=value;}
			get{return _description2;}
		}
		/// <summary>
		///11 促销描述3
		/// </summary>
		public string Description3
		{
			set{ _description3=value;}
			get{return _description3;}
		}
		/// <summary>
		///11 店铺Code。空/NULL： 表示所有。
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		///11 这组价格针对的店铺组ID。空/NULL： 表示所有
		/// </summary>
		public string StoreGroupCode
		{
			set{ _storegroupcode=value;}
			get{return _storegroupcode;}
		}
		/// <summary>
		///11 促销生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		///11 促销失效日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		///11 促销生效时间（例如 上午9:00），默认0表示全天有效
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		///11 促销失效时间（例如 下午20:00），默认0表示全天有效
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		///11 一月中促销生效日 （Buy_DayFlag表Code）
		/// </summary>
		public string DayFlagCode
		{
			set{ _dayflagcode=value;}
			get{return _dayflagcode;}
		}
		/// <summary>
		///11 一周中促销生效日 （Buy_WeekFlag表Code）
		/// </summary>
		public string WeekFlagCode
		{
			set{ _weekflagcode=value;}
			get{return _weekflagcode;}
		}
		/// <summary>
		///11 促销生效月 （Buy_MonthFlag表Code）
		/// </summary>
		public string MonthFlagCode
		{
			set{ _monthflagcode=value;}
			get{return _monthflagcode;}
		}
		/// <summary>
		///11 是否会员促销。0：不是。1：是的
		/// </summary>
		public int? MemberPromotionFlag
		{
			set{ _memberpromotionflag=value;}
			get{return _memberpromotionflag;}
		}
		/// <summary>
		///11 会员卡类型Code。（会员促销有效）
		/// </summary>
		public string CardTypeCode
		{
			set{ _cardtypecode=value;}
			get{return _cardtypecode;}
		}
		/// <summary>
		///11 会员卡级别Code。（会员促销有效）
		/// </summary>
		public string CardGradeCode
		{
			set{ _cardgradecode=value;}
			get{return _cardgradecode;}
		}
		/// <summary>
		///11 是否销售当日生日促销。0：不是。1：是的。（会员促销有效）
		/// </summary>
		public int? BirthdayFlag
		{
			set{ _birthdayflag=value;}
			get{return _birthdayflag;}
		}
		/// <summary>
		///11 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		///11 单据创建时的busdate
		/// </summary>
		public DateTime? CreatedBusDate
		{
			set{ _createdbusdate=value;}
			get{return _createdbusdate;}
		}
		/// <summary>
		///11 单据批核时的busdate
		/// </summary>
		public DateTime? ApproveBusDate
		{
			set{ _approvebusdate=value;}
			get{return _approvebusdate;}
		}
		/// <summary>
		///11 批核时产生授权号，并通知前台
		/// </summary>
		public string ApprovalCode
		{
			set{ _approvalcode=value;}
			get{return _approvalcode;}
		}
		/// <summary>
		///11 单据状态。状态： P：Pending。  A:Approve 。 V：Void
		/// </summary>
		public string ApproveStatus
		{
			set{ _approvestatus=value;}
			get{return _approvestatus;}
		}
		/// <summary>
		///11 批核时间
		/// </summary>
		public DateTime? ApproveOn
		{
			set{ _approveon=value;}
			get{return _approveon;}
		}
		/// <summary>
		///11 批核人
		/// </summary>
		public int? ApproveBy
		{
			set{ _approveby=value;}
			get{return _approveby;}
		}
		/// <summary>
		///11 创建时间
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 创建人
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

