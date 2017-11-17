using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 零售价格主档表
	/// </summary>
	[Serializable]
	public partial class BUY_RPRICE_M
	{
		public BUY_RPRICE_M()
		{}
		#region Model
		private int _keyid;
		private string _rpricecode;
		private string _prodcode;
		private string _rpricetypecode;
		private decimal _refprice;
		private decimal _price;
		private string _storecode;
		private string _storegroupcode;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private int? _status=1;
		private DateTime? _approveon;
		private int? _approveby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
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
		/// BUY_RPRICE_M表code。用户可以直接写入，用户可以直接写入，允许为空
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
		/// 指导价格
		/// </summary>
		public decimal RefPrice
		{
			set{ _refprice=value;}
			get{return _refprice;}
		}
		/// <summary>
		/// 零售价格
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 店铺Code。空/NULL： 表示所有。
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		/// 这组价格针对的店铺组ID。空/NULL： 表示所有
		/// </summary>
		public string StoreGroupCode
		{
			set{ _storegroupcode=value;}
			get{return _storegroupcode;}
		}
		/// <summary>
		/// 价格生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 价格失效日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 状态。1：有效。0：无效
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 批核时间
		/// </summary>
		public DateTime? ApproveOn
		{
			set{ _approveon=value;}
			get{return _approveon;}
		}
		/// <summary>
		/// 批核人
		/// </summary>
		public int? ApproveBy
		{
			set{ _approveby=value;}
			get{return _approveby;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
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

