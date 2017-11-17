using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺允许销售的货品列表。
    /// 创建人：lisa
    /// 创建时间:2016-08-11
	/// </summary>
	[Serializable]
	public partial class ProductStoreMap
	{
		public ProductStoreMap()
		{}
		#region Model
		private string _prodcode;
		private string _storecode;
		/// <summary>
		/// 货品编码
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 店铺编码
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		#endregion Model

	}
}

