using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 获取优惠劵的规则表
	/// </summary>
	[Serializable]
	public partial class EarnCouponRule
	{
		public EarnCouponRule()
		{}
		#region Model
		private int _keyid;
		private int _coupontypeid;
		private int? _exchangetype=1;
		private int? _exchangerank;
		private decimal? _exchangeamount;
		private int? _exchangepoint;
		private int? _exchangecoupontypeid;
		private int? _exchangecouponcount=1;
		private int? _exchangeconsumeruleoper;
		private decimal? _exchangeconsumeamount;
		private int? _cardtypeidlimit;
		private int? _cardgradeidlimit;
		private int? _cardtypebrandidlimit;
		private int? _storebrandidlimit;
		private int? _storegroupidlimit;
		private int? _storeidlimit;
		private int? _memberbirthdaylimit=0;
		private int? _membersexlimit;
		private int? _memberageminlimit;
		private int? _memberagemaxlimit;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private int? _status;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 需要获取的couponID
		/// </summary>
		public int CouponTypeID
		{
			set{ _coupontypeid=value;}
			get{return _coupontypeid;}
		}
		/// <summary>
		/// 兑换方式（默认1）：1、金额兑换；2、积分兑换；3、金额+积分兑换；4、coupon兑换；5、消费金额兑换
		/// </summary>
		public int? ExchangeType
		{
			set{ _exchangetype=value;}
			get{return _exchangetype;}
		}
		/// <summary>
		/// 兑换规则排序
		/// </summary>
		public int? ExchangeRank
		{
			set{ _exchangerank=value;}
			get{return _exchangerank;}
		}
		/// <summary>
		/// 兑换需要的金额
		/// </summary>
		public decimal? ExchangeAmount
		{
			set{ _exchangeamount=value;}
			get{return _exchangeamount;}
		}
		/// <summary>
		/// 兑换需要的积分
		/// </summary>
		public int? ExchangePoint
		{
			set{ _exchangepoint=value;}
			get{return _exchangepoint;}
		}
		/// <summary>
		/// 兑换需要的CouponTypeID
		/// </summary>
		public int? ExchangeCouponTypeID
		{
			set{ _exchangecoupontypeid=value;}
			get{return _exchangecoupontypeid;}
		}
		/// <summary>
		/// 兑换需要的指定的CouponTypeID的 数量。 默认为1
		/// </summary>
		public int? ExchangeCouponCount
		{
			set{ _exchangecouponcount=value;}
			get{return _exchangecouponcount;}
		}
		/// <summary>
		/// 兑换需要的消费金额的 计算方式设置：
//0：每当消费ExchangeConsumeAmount指定的金额，就能获得指定的coupon
//1：当消费金额大于等于ExchangeConsumeAmount指定的金额，就能获得指定的coupon
//2：当消费金额小于等于ExchangeConsumeAmount指定的金额，就能获得指定的coupon


		/// </summary>
		public int? ExchangeConsumeRuleOper
		{
			set{ _exchangeconsumeruleoper=value;}
			get{return _exchangeconsumeruleoper;}
		}
		/// <summary>
		/// 兑换需要的消费金额
		/// </summary>
		public decimal? ExchangeConsumeAmount
		{
			set{ _exchangeconsumeamount=value;}
			get{return _exchangeconsumeamount;}
		}
		/// <summary>
		/// 会员卡类型限制。  NULL或空表示不做限制。
		/// </summary>
		public int? CardTypeIDLimit
		{
			set{ _cardtypeidlimit=value;}
			get{return _cardtypeidlimit;}
		}
		/// <summary>
		/// 会员卡级别限制。  NULL或空表示不做限制。
		/// </summary>
		public int? CardGradeIDLimit
		{
			set{ _cardgradeidlimit=value;}
			get{return _cardgradeidlimit;}
		}
		/// <summary>
		/// 卡类型的品牌限制：NUll或空：不做限制。
		/// </summary>
		public int? CardTypeBrandIDLimit
		{
			set{ _cardtypebrandidlimit=value;}
			get{return _cardtypebrandidlimit;}
		}
		/// <summary>
		/// 店铺的品牌限制：NUll或空：不做限制。
		/// </summary>
		public int? StoreBrandIDLimit
		{
			set{ _storebrandidlimit=value;}
			get{return _storebrandidlimit;}
		}
		/// <summary>
		/// 店铺组限制：Null或空：不加限制。  填写后即只有此店铺组登录才可以看到并领取。
		/// </summary>
		public int? StoreGroupIDLimit
		{
			set{ _storegroupidlimit=value;}
			get{return _storegroupidlimit;}
		}
		/// <summary>
		/// 店铺限制：Null或空：不加限制。  填写后即只有此店铺登录才可以看到并领取。
		/// </summary>
		public int? StoreIDLimit
		{
			set{ _storeidlimit=value;}
			get{return _storeidlimit;}
		}
		/// <summary>
		/// 生日限制：null 或 0： 不加限制。 1：生日当月。 2：生日当周。 3：生日当日。
		/// </summary>
		public int? MemberBirthdayLimit
		{
			set{ _memberbirthdaylimit=value;}
			get{return _memberbirthdaylimit;}
		}
		/// <summary>
		/// 性别设置。null或0：不加限制。 1：男性。 2：女性
		/// </summary>
		public int? MemberSexLimit
		{
			set{ _membersexlimit=value;}
			get{return _membersexlimit;}
		}
		/// <summary>
		/// 最低年龄限制：null或者0：不加限制。 其他：最低年龄（包括）。（当年 - 生年 + 1 = 年龄）
		/// </summary>
		public int? MemberAgeMinLimit
		{
			set{ _memberageminlimit=value;}
			get{return _memberageminlimit;}
		}
		/// <summary>
		/// 最高年龄限制:null或者0：不加限制。 其他：最高年龄（包括）。（当年 - 生年 + 1 = 年龄）
		/// </summary>
		public int? MemberAgeMaxLimit
		{
			set{ _memberagemaxlimit=value;}
			get{return _memberagemaxlimit;}
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
		/// 状态
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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

