using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 优惠劵调整子表
	/// </summary>
	[Serializable]
	public partial class Ord_CouponAdjust_D
	{
		public Ord_CouponAdjust_D()
		{}
		#region Model
		private int _keyid;
		private string _couponadjustnumber;
		private string _couponnumber;
        private decimal? _couponamount;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 主表ID
		/// </summary>
		public string CouponAdjustNumber
		{
			set{ _couponadjustnumber=value;}
			get{return _couponadjustnumber;}
		}
		/// <summary>
		/// 卡号
		/// </summary>
		public string CouponNumber
		{
			set{ _couponnumber=value;}
			get{return _couponnumber;}
		}
        /// <summary>
        /// 存放coupon的金额。即CouponType中的CouponTypeAmount值。 当CouponType为不定值类型时， 此金额将和CouponTypeAmount值不同。
        /// </summary>
        public decimal? CouponAmount
        {
            set { _couponamount = value; }
            get { return _couponamount; }
        }

		#endregion Model

	}
}

