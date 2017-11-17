using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// BUY_ALLOC_S_D:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BUY_ALLOC_S_D
	{
		public BUY_ALLOC_S_D()
		{}
		#region Model
		private int _keyid;
		private string _alloccode;
		private string _storecode;
		private string _prodcode;
		private decimal? _qty;
		private decimal? _balance;
		private decimal? _requestqty;
		private decimal? _suggestqty;
		private int? _status;
		private string _error;
		private DateTime? _postdate;
		private int? _postby;
		/// <summary>
		///11 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		///11 主表编码
		/// </summary>
		public string AllocCode
		{
			set{ _alloccode=value;}
			get{return _alloccode;}
		}
		/// <summary>
		///11 店铺编码
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
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
		///11 补充数量
		/// </summary>
		public decimal? Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		///11 店铺当前持有量
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		///11 根据补货规程计算出来的请求数量
		/// </summary>
		public decimal? RequestQty
		{
			set{ _requestqty=value;}
			get{return _requestqty;}
		}
		/// <summary>
		///11 实际分配数量
		/// </summary>
		public decimal? SuggestQty
		{
			set{ _suggestqty=value;}
			get{return _suggestqty;}
		}
		/// <summary>
		///11 状态：
		///0 :Waittting 
		///1: Outstanding 
		///2: Verified 
		///3: Send to LIS 
		///4: Complete
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		///11 错误信息
		/// </summary>
		public string Error
		{
			set{ _error=value;}
			get{return _error;}
		}
		/// <summary>
		///11 提交日期
		/// </summary>
		public DateTime? PostDate
		{
			set{ _postdate=value;}
			get{return _postdate;}
		}
		/// <summary>
		///11 提交人
		/// </summary>
		public int? PostBy
		{
			set{ _postby=value;}
			get{return _postby;}
		}
		#endregion Model

	}
}

