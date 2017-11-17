using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 导入Coupon的UID的 子表。
	/// </summary>
	[Serializable]
	public partial class Ord_ImportCouponUID_D
	{
		public Ord_ImportCouponUID_D()
		{}
		#region Model
		private int _keyid;
		private string _importcouponnumber;
		private int? _coupontypeid;
		private string _couponuid;
		private DateTime? _expirydate;
		private string _batchid;
		private decimal? _denomination;
		/// <summary>
		/// 主键，自增长
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 单据号码
		/// </summary>
		public string ImportCouponNumber
		{
			set{ _importcouponnumber=value;}
			get{return _importcouponnumber;}
		}
		/// <summary>
		/// 优惠劵类型
		/// </summary>
		public int? CouponTypeID
		{
			set{ _coupontypeid=value;}
			get{return _coupontypeid;}
		}
		/// <summary>
		/// 实体优惠劵ID 
		/// </summary>
		public string CouponUID
		{
			set{ _couponuid=value;}
			get{return _couponuid;}
		}
		/// <summary>
		/// 特定设置有效期。null表示使用coupon自己的有效期。否则使用此处的值更新到coupon
		/// </summary>
		public DateTime? ExpiryDate
		{
			set{ _expirydate=value;}
			get{return _expirydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BatchID
		{
			set{ _batchid=value;}
			get{return _batchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Denomination
		{
			set{ _denomination=value;}
			get{return _denomination;}
		}
		#endregion Model

	}
}

