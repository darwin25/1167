using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 会员消息发送对象过滤表
	/// </summary>
	[Serializable]
	public partial class MemberNotice_Filter
	{
		public MemberNotice_Filter()
		{}
		#region Model
		private int _keyid;
		private string _noticenumber;
		private int? _brandid;
		private int? _cardtypeid;
		private int? _cardgradeid;
		private int? _coupontypeid;
		private int? _onbirthday=0;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 通知编号
		/// </summary>
		public string NoticeNumber
		{
			set{ _noticenumber=value;}
			get{return _noticenumber;}
		}
		/// <summary>
		/// 品牌ID
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// cardtype条件
		/// </summary>
		public int? CardTypeID
		{
			set{ _cardtypeid=value;}
			get{return _cardtypeid;}
		}
		/// <summary>
		/// cardgrade条件
		/// </summary>
		public int? CardGradeID
		{
			set{ _cardgradeid=value;}
			get{return _cardgradeid;}
		}
		/// <summary>
		/// 如果有coupon，则coupontype条件
		/// </summary>
		public int? CouponTypeID
		{
			set{ _coupontypeid=value;}
			get{return _coupontypeid;}
		}
		/// <summary>
		/// 是否需要会员生日触发。0：不是。1：是
		/// </summary>
		public int? OnBirthDay
		{
			set{ _onbirthday=value;}
			get{return _onbirthday;}
		}
		#endregion Model

	}
}

