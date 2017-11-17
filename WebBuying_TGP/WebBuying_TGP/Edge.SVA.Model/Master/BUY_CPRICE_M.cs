using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// BUY_CPRICE_H 单批核后产生的主档记录。
	/// </summary>
	[Serializable]
	public partial class BUY_CPRICE_M
	{
		public BUY_CPRICE_M()
		{}
		#region Model
		private int _keyid;
		private string _cpricecode;
		private string _prodcode;
		private string _vendorcode;
		private string _storecode;
		private string _storegroupcode;
		private string _currencycode;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private decimal _cpricegrosscost;
		private decimal _cpricenetcost;
		private decimal? _cpricedisc1=0M;
		private decimal? _cpricedisc2=0M;
		private decimal? _cpricedisc3=0M;
		private decimal? _cpricedisc4=0M;
		private decimal? _cpricebuy=0M;
		private decimal? _cpriceget=0M;
		private int? _status=1;
		private DateTime? _approveon;
		private int? _approveby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		///11 BUY_CPRICE_H表主键。用户可以直接写表记录，允许为空
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
		///11 供应商编码
		/// </summary>
		public string VendorCode
		{
			set{ _vendorcode=value;}
			get{return _vendorcode;}
		}
		/// <summary>
		///11 店铺Code。空/NULL： 表示所有。
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		///11 这组价格针对的店铺组ID。空/NULL： 表示所有
		/// </summary>
		public string StoreGroupCode
		{
			set{ _storegroupcode=value;}
			get{return _storegroupcode;}
		}
		/// <summary>
		///11 货币编码。一般应该是本币代码
		/// </summary>
		public string CurrencyCode
		{
			set{ _currencycode=value;}
			get{return _currencycode;}
		}
		/// <summary>
		///11 价格生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		///11 价格失效日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
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
		/// <summary>
		///11 状态。1：有效。0：无效
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		///11 批核时间
		/// </summary>
		public DateTime? ApproveOn
		{
			set{ _approveon=value;}
			get{return _approveon;}
		}
		/// <summary>
		///11 批核人
		/// </summary>
		public int? ApproveBy
		{
			set{ _approveby=value;}
			get{return _approveby;}
		}
		/// <summary>
		///11 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

