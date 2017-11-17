using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 分发优惠劵明细表
	///CardNumber：在填写数据时，根据MemberRegisterMobile，以及CouponTypeCode获得。 （cardnumber和coupontypecode 为相同的brandcode，同一个brandcode下，如果有1个以上的卡，cardnumber填空）。
	///绑定coupon时，绑定在此cardnumber下。 cardnumber为空则为错。
	/// </summary>
	[Serializable]
	public partial class Ord_ImportCouponDispense_D
	{
		public Ord_ImportCouponDispense_D()
		{}
		#region Model
		private int _keyid;
		private string _coupondispensenumber;
		private string _campaigncode;
		private string _coupontypecode;
		private string _memberregistermobile;
		private DateTime? _exportdatetime;
		private string _cardnumber;
		/// <summary>
		/// 主键，自增长
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 单据号码，外键
		/// </summary>
		public string CouponDispenseNumber
		{
			set{ _coupondispensenumber=value;}
			get{return _coupondispensenumber;}
		}
		/// <summary>
		/// 活动code
		/// </summary>
		public string CampaignCode
		{
			set{ _campaigncode=value;}
			get{return _campaigncode;}
		}
		/// <summary>
		/// 优惠劵类型code
		/// </summary>
		public string CouponTypeCode
		{
			set{ _coupontypecode=value;}
			get{return _coupontypecode;}
		}
		/// <summary>
		/// 会员注册用手机号（加上国家代码的，例如0861392572219）
		/// </summary>
		public string MemberRegisterMobile
		{
			set{ _memberregistermobile=value;}
			get{return _memberregistermobile;}
		}
		/// <summary>
		/// 导出时间
		/// </summary>
		public DateTime? ExportDatetime
		{
			set{ _exportdatetime=value;}
			get{return _exportdatetime;}
		}
		/// <summary>
		/// 会员卡号，分发的coupon，绑定在此卡上
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
		}
		#endregion Model

	}
}

