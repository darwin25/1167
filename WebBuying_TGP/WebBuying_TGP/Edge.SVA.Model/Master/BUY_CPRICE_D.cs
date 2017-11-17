using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 成本价子表
	/// </summary>
	[Serializable]
	public partial class BUY_CPRICE_D
	{
		public BUY_CPRICE_D()
		{}
		#region Model
		private int _keyid;
		private string _cpricecode;
		private string _prodcode;
		private decimal _cpricegrosscost;
		private decimal _cpricenetcost;
		private decimal? _cpricedisc1=0M;
		private decimal? _cpricedisc2=0M;
		private decimal? _cpricedisc3=0M;
		private decimal? _cpricedisc4=0M;
		private decimal? _cpricebuy=0M;
		private decimal? _cpriceget=0M;
		/// <summary>
		///11 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		///11 主键编码
		/// </summary>
		public string CPriceCode
		{
			set{ _cpricecode=value;}
			get{return _cpricecode;}
		}
		/// <summary>
		///11 货品编码
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		///11 毛成本价。不包含所有折扣
		/// </summary>
		public decimal CPriceGrossCost
		{
			set{ _cpricegrosscost=value;}
			get{return _cpricegrosscost;}
		}
		/// <summary>
		///11 净成本价。包含所有折扣
		/// </summary>
		public decimal CPriceNetCost
		{
			set{ _cpricenetcost=value;}
			get{return _cpricenetcost;}
		}
		/// <summary>
		///11 交易折扣。（Transaction Discount）
		/// </summary>
		public decimal? CPriceDisc1
		{
			set{ _cpricedisc1=value;}
			get{return _cpricedisc1;}
		}
		/// <summary>
		///11 其他折扣。（Other Discount）
		/// </summary>
		public decimal? CPriceDisc2
		{
			set{ _cpricedisc2=value;}
			get{return _cpricedisc2;}
		}
		/// <summary>
		///11 特别折扣。（Special Discount）
		/// </summary>
		public decimal? CPriceDisc3
		{
			set{ _cpricedisc3=value;}
			get{return _cpricedisc3;}
		}
		/// <summary>
		///11 折扣4。（Discount 4）
		/// </summary>
		public decimal? CPriceDisc4
		{
			set{ _cpricedisc4=value;}
			get{return _cpricedisc4;}
		}
		/// <summary>
		///11 How many to buy
		/// </summary>
		public decimal? CPriceBuy
		{
			set{ _cpricebuy=value;}
			get{return _cpricebuy;}
		}
		/// <summary>
		///11 How many to get free
		/// </summary>
		public decimal? CPriceGet
		{
			set{ _cpriceget=value;}
			get{return _cpriceget;}
		}
		#endregion Model

	}
}

