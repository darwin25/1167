using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// Promotion_H的子表，促销针对人群表。
	///（记录之间是 or 的关系）
	/// </summary>
	[Serializable]
	public partial class Promotion_Member
	{
		public Promotion_Member()
		{}
		#region Model
		private int _keyid;
		private string _promotioncode;
		private int? _loyaltycardtypeid=0;
		private int? _loyaltycardgradeid=0;
		private int? _loyaltythreshold=0;
		private int? _loyaltybirthdayflag=0;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 促销编码
		/// </summary>
		public string PromotionCode
		{
			set{ _promotioncode=value;}
			get{return _promotioncode;}
		}
		/// <summary>
		/// 促销指定的会员卡类型。默认0，表示所有类型的卡
		/// </summary>
		public int? LoyaltyCardTypeID
		{
			set{ _loyaltycardtypeid=value;}
			get{return _loyaltycardtypeid;}
		}
		/// <summary>
		/// 促销指定的会员卡等级 。默认0，表示所有等级的卡。
		/// </summary>
		public int? LoyaltyCardGradeID
		{
			set{ _loyaltycardgradeid=value;}
			get{return _loyaltycardgradeid;}
		}
		/// <summary>
		/// 促销指定的会员忠诚度阀值。(一般指会员积分数 )。 默认0，表示不设置阀值。
		/// </summary>
		public int? LoyaltyThreshold
		{
			set{ _loyaltythreshold=value;}
			get{return _loyaltythreshold;}
		}
		/// <summary>
		/// 是否销售当日生日促销。默认0.
        //0：不是生日促销。
        //1：会员生日当日
        //2：会员生日当周
        //3：会员生日当月
		/// </summary>
		public int? LoyaltyBirthdayFlag
		{
			set{ _loyaltybirthdayflag=value;}
			get{return _loyaltybirthdayflag;}
		}
		#endregion Model

	}
}

