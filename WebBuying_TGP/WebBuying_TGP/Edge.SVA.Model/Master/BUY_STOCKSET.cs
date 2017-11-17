using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品库存设置表
	/// </summary>
	[Serializable]
	public partial class BUY_STOCKSET
	{
		public BUY_STOCKSET()
		{}
		#region Model
		private int _keyid;
		private string _prodcode;
		private string _storecode;
		private decimal? _reorder=0M;
		private decimal? _maxreorder=0M;
		private decimal? _stockholding=0M;
		/// <summary>
		///11 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
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
		///11 库存编码
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		///11 重订货数量
		/// </summary>
		public decimal? ReOrder
		{
			set{ _reorder=value;}
			get{return _reorder;}
		}
		/// <summary>
		///11 最大重订货数量
		/// </summary>
		public decimal? MaxReOrder
		{
			set{ _maxreorder=value;}
			get{return _maxreorder;}
		}
		/// <summary>
		///11 库存持有量
		/// </summary>
		public decimal? StockHolding
		{
			set{ _stockholding=value;}
			get{return _stockholding;}
		}
		#endregion Model

	}
}

