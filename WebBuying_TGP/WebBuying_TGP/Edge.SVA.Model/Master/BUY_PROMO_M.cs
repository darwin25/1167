using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 促销主档表。
	/// </summary>
	[Serializable]
	public partial class BUY_PROMO_M
	{
		public BUY_PROMO_M()
		{}
		#region Model
		private int _keyid;
		private string _promotioncode;
		private string _description1;
		private string _description2;
		private string _description3;
		private string _storecode;
		private string _storegroupcode;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private DateTime? _starttime= Convert.ToDateTime("0");
		private DateTime? _endtime= Convert.ToDateTime("0");
		private string _entitynum;
		private int _entitytype;
		private decimal _hitamount;
		private int _hitop;
		private decimal _discprice;
		private int? _disctype;
		private string _dayflagcode;
		private string _weekflagcode;
		private string _monthflagcode;
		private int? _loyaltyflag=0;
		private string _loyaltycardtypecode;
		private string _loyaltycardgradecode;
		private int? _birthdayflag=0;
		private int? _status=1;
		private DateTime? _approveon;
		private int? _approveby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		///11 促销编号
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
		///11 价格生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		///11 价格失效日期
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
		///11 号码
		/// </summary>
		public string EntityNum
		{
			set{ _entitynum=value;}
			get{return _entitynum;}
		}
		/// <summary>
		///11 决定EntityNum中内容的含义。
		///0：所有货品。EntityNum中为空
		///1：EntityNum内容为 prodcode。 销售EntityNum中指定货品时，可以生效
		///2：EntityNum内容为 DepartCode。。 销售EntityNum中指定部门的货品时，可以生效
		///3：EntityNum内容为 TenderCode。 使用EntityNum中指定货币支付时，可以生效
		/// </summary>
		public int EntityType
		{
			set{ _entitytype=value;}
			get{return _entitytype;}
		}
		/// <summary>
		///11 命中金额
		/// </summary>
		public decimal HitAmount
		{
			set{ _hitamount=value;}
			get{return _hitamount;}
		}
		/// <summary>
		///11 命中金额关系操作符。
		///0：没有操作符，不和HitAmt比较
		///1： =     （等于时， 如果金额大于此值，也符合条件）
		///2： <>
		///3： <=
		///4：>=
		///5：<
		///6：>
		///
		/// </summary>
		public int HitOP
		{
			set{ _hitop=value;}
			get{return _hitop;}
		}
		/// <summary>
		///11 折扣金额或者折扣比例
		/// </summary>
		public decimal DiscPrice
		{
			set{ _discprice=value;}
			get{return _discprice;}
		}
		/// <summary>
		///11 折扣类型。
		///1：DiscPrice为 折扣减去的金额。（即 实际销售价格= 销售价格 - DiscPrice）
		///2：DiscPrice为 折扣销售的金额。（即  实际销售价格 = DiscPrice）
		///3：DiscPrice为 折扣减去的百分比。（范围1~100） （即 实际销售价格 = 销售价格 * （1 - DiscPrice）* 0.01）
		///4：DiscPrice为 折扣销售的百分比。（范围1~100） （即 实际销售价格 = 销售价格 * DiscPrice* 0.01）
		///
		/// </summary>
		public int? DiscType
		{
			set{ _disctype=value;}
			get{return _disctype;}
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
		public int? LoyaltyFlag
		{
			set{ _loyaltyflag=value;}
			get{return _loyaltyflag;}
		}
		/// <summary>
		///11 会员卡类型Code。（会员促销有效）
		/// </summary>
		public string LoyaltyCardTypeCode
		{
			set{ _loyaltycardtypecode=value;}
			get{return _loyaltycardtypecode;}
		}
		/// <summary>
		///11 会员卡级别Code。（会员促销有效）
		/// </summary>
		public string LoyaltyCardGradeCode
		{
			set{ _loyaltycardgradecode=value;}
			get{return _loyaltycardgradecode;}
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
		///11 状态。1：有效。0：无效
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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

