using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 促销设置明细表
	/// </summary>
	[Serializable]
	public partial class BUY_PROMO_D
	{
		public BUY_PROMO_D()
		{}
		#region Model
		private int _keyid;
		private string _promotioncode;
		private string _entitynum;
		private int _entitytype;
		private int _hitop;
		private decimal _hitamount;
		private decimal _discprice;
		private int? _disctype;
		private int? _hittype=0;
		/// <summary>
		/// 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 头表主键
		/// </summary>
		public string PromotionCode
		{
			set{ _promotioncode=value;}
			get{return _promotioncode;}
		}
		/// <summary>
		/// 号码
		/// </summary>
		public string EntityNum
		{
			set{ _entitynum=value;}
			get{return _entitynum;}
		}
		/// <summary>
		/// 决定EntityNum中内容的含义。
        //0：所有货品。EntityNum中为空
        //1：EntityNum内容为 prodcode。 销售EntityNum中指定货品时，可以生效
        //2：EntityNum内容为 DepartCode。。 销售EntityNum中指定部门的货品时，可以生效
        //3：EntityNum内容为 TenderCode。 使用EntityNum中指定货币支付时，可以生效
		/// </summary>
		public int EntityType
		{
			set{ _entitytype=value;}
			get{return _entitytype;}
		}
		/// <summary>
		/// 命中金额关系操作符。
        //0：没有操作符，不和HitAmt比较
        //1： =     （等于时， 如果金额大于此值，也符合条件）
        //2： <>
        //3： <=
        //4：>=
        //5：<
        //6：>
		/// </summary>
		public int HitOP
		{
			set{ _hitop=value;}
			get{return _hitop;}
		}
		/// <summary>
		/// 命中金额
		/// </summary>
		public decimal HitAmount
		{
			set{ _hitamount=value;}
			get{return _hitamount;}
		}
		/// <summary>
		/// 折扣金额或者折扣比例
		/// </summary>
		public decimal DiscPrice
		{
			set{ _discprice=value;}
			get{return _discprice;}
		}
		/// <summary>
		/// 折扣类型。
        //1：DiscPrice为 折扣减去的金额。（即 实际销售价格= 销售价格 - DiscPrice）
        //2：DiscPrice为 折扣销售的金额。（即  实际销售价格 = DiscPrice）
        //3：DiscPrice为 折扣减去的百分比。（范围1~100） （即 实际销售价格 = 销售价格 * （1 - DiscPrice）* 0.01）
        //4：DiscPrice为 折扣销售的百分比。（范围1~100） （即 实际销售价格 = 销售价格 * DiscPrice* 0.01）
		/// </summary>
		public int? DiscType
		{
			set{ _disctype=value;}
			get{return _disctype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? HitType
		{
			set{ _hittype=value;}
			get{return _hittype;}
		}
		#endregion Model

	}
}

