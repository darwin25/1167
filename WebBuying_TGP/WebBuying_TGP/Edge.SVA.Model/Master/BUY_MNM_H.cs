using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 混配促销配置表。主表
	/// </summary>
	[Serializable]
	public partial class BUY_MNM_H
	{
		public BUY_MNM_H()
		{}
		#region Model
		private string _mnmcode;
		private int? _mnmtype;
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
		private int? _loyaltyonly=0;
		private string _loyaltycardtypecode;
		private string _loyaltycardgradecode;
		private string _loyaltythreshold;
		private int? _hittype=0;
		private int _hitop;
		private decimal _hitamount=0M;
		private int? _hitqty=0;
		private int? _gifttype=0;
		private int? _giftqty=0;
		private int? _promotiontype=0;
		private int? _promotionon=0;
		private string _amounttype="$";
		private decimal _amount;
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
		///11 混配促销编码
		/// </summary>
		public string MNMCode
		{
			set{ _mnmcode=value;}
			get{return _mnmcode;}
		}
		/// <summary>
		///11 促销命中条件类型。
		///0: Promotion By Hit Qty
		///1: Promotion By Hit Amount
		///2: Promotion By Sales Amount
		///
		/// </summary>
		public int? MNMType
		{
			set{ _mnmtype=value;}
			get{return _mnmtype;}
		}
		/// <summary>
		///11 混配促销描述1
		/// </summary>
		public string Description1
		{
			set{ _description1=value;}
			get{return _description1;}
		}
		/// <summary>
		///11 混配促销描述2
		/// </summary>
		public string Description2
		{
			set{ _description2=value;}
			get{return _description2;}
		}
		/// <summary>
		///11 混配促销描述3
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
		///11 生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		///11 失效日期
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
		///11 是否仅会员混配促销。0：不是。1：是的
		/// </summary>
		public int? LoyaltyOnly
		{
			set{ _loyaltyonly=value;}
			get{return _loyaltyonly;}
		}
		/// <summary>
		///11 混配促销指定的会员卡类型
		/// </summary>
		public string LoyaltyCardTypeCode
		{
			set{ _loyaltycardtypecode=value;}
			get{return _loyaltycardtypecode;}
		}
		/// <summary>
		///11 混配促销指定的会员卡等级
		/// </summary>
		public string LoyaltyCardGradeCode
		{
			set{ _loyaltycardgradecode=value;}
			get{return _loyaltycardgradecode;}
		}
		/// <summary>
		///11 混配促销指定的会员忠诚度阀值
		/// </summary>
		public string LoyaltyThreshold
		{
			set{ _loyaltythreshold=value;}
			get{return _loyaltythreshold;}
		}
		/// <summary>
		///11 命中类型：
		///0: Hit must be same SKU
		///1: Hit must be each SKU
		///2: Hit can be any SKU
		///99: Hit Qty is fixed
		///
		/// </summary>
		public int? HitType
		{
			set{ _hittype=value;}
			get{return _hittype;}
		}
		/// <summary>
		///11 命中关系操作符。
		///0：没有操作符
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
		///11 命中金额
		/// </summary>
		public decimal HitAmount
		{
			set{ _hitamount=value;}
			get{return _hitamount;}
		}
		/// <summary>
		///11 命中数量
		/// </summary>
		public int? HitQty
		{
			set{ _hitqty=value;}
			get{return _hitqty;}
		}
		/// <summary>
		///11 礼品类型：
		///0: Gift must be same SKU
		///1: Gift must be each SKU
		///2: Gift can be any SKU
		///3: Gift must be same SKU with Hit
		///99: Gift Qty is fixed
		///
		/// </summary>
		public int? GiftType
		{
			set{ _gifttype=value;}
			get{return _gifttype;}
		}
		/// <summary>
		///11 礼品货品数量。
		/// </summary>
		public int? GiftQty
		{
			set{ _giftqty=value;}
			get{return _giftqty;}
		}
		/// <summary>
		///11 折扣金额设定类型。0 : Sales at   1 : Sales off
		/// </summary>
		public int? PromotionType
		{
			set{ _promotiontype=value;}
			get{return _promotiontype;}
		}
		/// <summary>
		///11 折扣实现方式。0: Discount on Hit     1: Discount on Gift    2: Discount on Transaction
		///
		///
		/// </summary>
		public int? PromotionOn
		{
			set{ _promotionon=value;}
			get{return _promotionon;}
		}
		/// <summary>
		///11 指定Amount内容类型。 
		///$: 金额。   %:百分比
		/// </summary>
		public string AmountType
		{
			set{ _amounttype=value;}
			get{return _amounttype;}
		}
		/// <summary>
		///11 金额或者折扣
		/// </summary>
		public decimal Amount
		{
			set{ _amount=value;}
			get{return _amount;}
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

