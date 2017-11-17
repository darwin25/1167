using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品库存表。货品实际在库数量。
	/// </summary>
	[Serializable]
	public partial class STK_StockOnhand
	{
		public STK_StockOnhand()
		{}
		#region Model
		private int _storeid;
		private string _stocktypecode;
		private string _prodcode;
		private int? _onhandqty=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// buy_Store表主键
		/// </summary>
		public int StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// buy_StockType表 Code
		/// </summary>
		public string StockTypeCode
		{
			set{ _stocktypecode=value;}
			get{return _stocktypecode;}
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
		/// 库存数量
		/// </summary>
		public int? OnhandQty
		{
			set{ _onhandqty=value;}
			get{return _onhandqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

