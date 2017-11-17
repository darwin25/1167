using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 供应商与货品的关联表
    /// 创建人：Lisa
    /// 创建时间：2016-02-26
	/// </summary>
	[Serializable]
	public partial class BUY_SUPPROD
	{
		public BUY_SUPPROD()
		{}
		#region Model
		private string _vendorcode;
		private string _prodcode;
		private string _supplier_product_code;
		private decimal? _in_tax;
		private int? _prefer=0;
		private int? _isdefault=0;
		/// <summary>
		/// 供应商编码
		/// </summary>
		public string VendorCode
		{
			set{ _vendorcode=value;}
			get{return _vendorcode;}
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
		/// 供应商的货品编码
		/// </summary>
		public string SUPPLIER_PRODUCT_CODE
		{
			set{ _supplier_product_code=value;}
			get{return _supplier_product_code;}
		}
		/// <summary>
		/// 税
		/// </summary>
		public decimal? in_tax
		{
			set{ _in_tax=value;}
			get{return _in_tax;}
		}
		/// <summary>
		/// 优先权。 0 ：最低。依次增高。 默认0
		/// </summary>
		public int? Prefer
		{
			set{ _prefer=value;}
			get{return _prefer;}
		}
		/// <summary>
		/// 是否默认供应商. 0：不是。1:是的。 默认 0
		/// </summary>
		public int? IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		#endregion Model

	}
}

