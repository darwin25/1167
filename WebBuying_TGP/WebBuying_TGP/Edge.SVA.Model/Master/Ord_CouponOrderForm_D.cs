using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 优惠劵订货单明细。
	///表中brandID，CouponTypeID关系不做校验，由UI在创建单据时做校验。
	///存储过程实际操作时，只按照CouponTypeID来做。
	/// </summary>
	[Serializable]
	public partial class Ord_CouponOrderForm_D
	{
		public Ord_CouponOrderForm_D()
		{}
		#region Model
		private int _keyid;
		private string _couponorderformnumber;
		private int? _brandid;
		private int _coupontypeid;
		private int? _couponqty;
		/// <summary>
		/// 
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 订单编号，主键
		/// </summary>
		public string CouponOrderFormNumber
		{
			set{ _couponorderformnumber=value;}
			get{return _couponorderformnumber;}
		}
		/// <summary>
		/// 品牌主键，外键
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 优惠劵类型ID
		/// </summary>
		public int CouponTypeID
		{
			set{ _coupontypeid=value;}
			get{return _coupontypeid;}
		}
		/// <summary>
		/// 需求数量
		/// </summary>
		public int? CouponQty
		{
			set{ _couponqty=value;}
			get{return _couponqty;}
		}
		#endregion Model

	}
}

