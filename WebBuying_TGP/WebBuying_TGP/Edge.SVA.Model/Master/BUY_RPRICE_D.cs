using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 零售价格明细表
	/// </summary>
	[Serializable]
	public partial class BUY_RPRICE_D
	{
		public BUY_RPRICE_D()
		{}
		#region Model
		private int _keyid;
		private string _rpricecode;
		private string _prodcode;
		private string _rpricetypecode;
		private decimal _price;
		private decimal _refprice;
		private decimal? _promotionprice;
		private decimal? _memberprice;
		/// <summary>
		/// 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// BUY_RPRICE_H表主键
		/// </summary>
		public string RPriceCode
		{
			set{ _rpricecode=value;}
			get{return _rpricecode;}
		}
		/// <summary>
		/// 货品编码
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 零售价类型编码
		/// </summary>
		public string RPriceTypeCode
		{
			set{ _rpricetypecode=value;}
			get{return _rpricetypecode;}
		}
		/// <summary>
		/// 销售单价
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 指导价格
		/// </summary>
		public decimal RefPrice
		{
			set{ _refprice=value;}
			get{return _refprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PromotionPrice
		{
			set{ _promotionprice=value;}
			get{return _promotionprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MemberPrice
		{
			set{ _memberprice=value;}
			get{return _memberprice;}
		}
		#endregion Model

	}
}

