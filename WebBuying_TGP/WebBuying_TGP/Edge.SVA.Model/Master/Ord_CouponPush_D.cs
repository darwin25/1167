using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 推送优惠劵（子表）（优惠劵类型列表）
	/// </summary>
	[Serializable]
	public partial class Ord_CouponPush_D
	{
		public Ord_CouponPush_D()
		{}
		#region Model
		private int _keyid;
		private string _couponpushnumber;
		private int? _couponbrandid;
		private int? _coupontypeid;
		private int _couponqty=1;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 优惠劵推送单号，主键
		/// </summary>
		public string CouponPushNumber
		{
			set{ _couponpushnumber=value;}
			get{return _couponpushnumber;}
		}
		/// <summary>
		/// 优惠劵类型的品牌ID
		/// </summary>
		public int? CouponBrandID
		{
			set{ _couponbrandid=value;}
			get{return _couponbrandid;}
		}
		/// <summary>
		/// 优惠劵类型ID
		/// </summary>
		public int? CouponTypeID
		{
			set{ _coupontypeid=value;}
			get{return _coupontypeid;}
		}
		/// <summary>
		/// 推送数量
		/// </summary>
		public int CouponQty
		{
			set{ _couponqty=value;}
			get{return _couponqty;}
		}
		#endregion Model

	}
}

