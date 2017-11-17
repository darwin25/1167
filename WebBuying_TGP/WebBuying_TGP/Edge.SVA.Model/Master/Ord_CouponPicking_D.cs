using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 优惠劵拣货单子表
	///表中brandID，CouponTypeID关系不做校验，由UI在创建单据时做校验。
	///存储过程实际操作时，只按照CouponTypeID来做。
	///（实际拣货首号码必须填，尾号码可以根据数量来计算，具体根据业务需求来做）
	/// </summary>
	[Serializable]
	public partial class Ord_CouponPicking_D
	{
		public Ord_CouponPicking_D()
		{}
		#region Model
		private int _keyid;
		private string _couponpickingnumber;
		private int? _brandid;
		private int? _coupontypeid;
		private string _description;
		private int? _orderqty;
		private int? _pickqty;
		private int? _actualqty;
		private string _firstcouponnumber;
		private string _endcouponnumber;
		private string _batchcouponcode;
		private DateTime? _pickupdatetime= DateTime.Now;
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
		public string CouponPickingNumber
		{
			set{ _couponpickingnumber=value;}
			get{return _couponpickingnumber;}
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
		public int? CouponTypeID
		{
			set{ _coupontypeid=value;}
			get{return _coupontypeid;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 订单数量
		/// </summary>
		public int? OrderQTY
		{
			set{ _orderqty=value;}
			get{return _orderqty;}
		}
		/// <summary>
		/// 要求拣货数量
		/// </summary>
		public int? PickQTY
		{
			set{ _pickqty=value;}
			get{return _pickqty;}
		}
		/// <summary>
		/// 实际拣货数量
		/// </summary>
		public int? ActualQTY
		{
			set{ _actualqty=value;}
			get{return _actualqty;}
		}
		/// <summary>
		/// 实际拣货批次的首coupon号
		/// </summary>
		public string FirstCouponNumber
		{
			set{ _firstcouponnumber=value;}
			get{return _firstcouponnumber;}
		}
		/// <summary>
		/// 实际拣货批次的末coupon号
		/// </summary>
		public string EndCouponNumber
		{
			set{ _endcouponnumber=value;}
			get{return _endcouponnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BatchCouponCode
		{
			set{ _batchcouponcode=value;}
			get{return _batchcouponcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PickupDateTime
		{
			set{ _pickupdatetime=value;}
			get{return _pickupdatetime;}
		}
		#endregion Model

	}
}

