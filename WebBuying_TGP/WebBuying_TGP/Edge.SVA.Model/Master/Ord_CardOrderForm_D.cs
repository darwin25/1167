using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡订货单明细。
	///表中brandID，cardtypeid，cardgradeid 关系不做校验，由UI在创建单据时做校验。
	///存储过程实际操作时，只按照CardGradeID来做。
	/// </summary>
	[Serializable]
	public partial class Ord_CardOrderForm_D
	{
		public Ord_CardOrderForm_D()
		{}
		#region Model
		private int _keyid;
		private string _cardorderformnumber;
		private int? _brandid;
		private int? _cardtypeid;
		private int _cardgradeid;
		private int? _cardqty;
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
		public string CardOrderFormNumber
		{
			set{ _cardorderformnumber=value;}
			get{return _cardorderformnumber;}
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
		/// 卡类型ID
		/// </summary>
		public int? CardTypeID
		{
			set{ _cardtypeid=value;}
			get{return _cardtypeid;}
		}
		/// <summary>
		/// 卡级别ID
		/// </summary>
		public int CardGradeID
		{
			set{ _cardgradeid=value;}
			get{return _cardgradeid;}
		}
		/// <summary>
		/// 需求数量
		/// </summary>
		public int? CardQty
		{
			set{ _cardqty=value;}
			get{return _cardqty;}
		}
		#endregion Model

	}
}

