using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 库存类型表
	/// </summary>
	[Serializable]
	public partial class BUY_STOCKTYPE
	{
		public BUY_STOCKTYPE()
		{}
		#region Model
		private int _stocktypeid;
		private string _stocktypecode;
		private string _stocktypename1;
		private string _stocktypename2;
		private string _stocktypename3;
		private int? _needserialno=0;
		private string _subinvsuffix;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键ID
		/// </summary>
		public int StockTypeID
		{
			set{ _stocktypeid=value;}
			get{return _stocktypeid;}
		}
		/// <summary>
		///11 库存类型编码
		/// </summary>
		public string StockTypeCode
		{
			set{ _stocktypecode=value;}
			get{return _stocktypecode;}
		}
		/// <summary>
		///11 库存类型名称1
		/// </summary>
		public string StockTypeName1
		{
			set{ _stocktypename1=value;}
			get{return _stocktypename1;}
		}
		/// <summary>
		///11 库存类型名称2
		/// </summary>
		public string StockTypeName2
		{
			set{ _stocktypename2=value;}
			get{return _stocktypename2;}
		}
		/// <summary>
		///11 库存类型名称3
		/// </summary>
		public string StockTypeName3
		{
			set{ _stocktypename3=value;}
			get{return _stocktypename3;}
		}
		/// <summary>
		///11 是否需要serialno.。0：不。 1：是
		/// </summary>
		public int? NeedSerialno
		{
			set{ _needserialno=value;}
			get{return _needserialno;}
		}
		/// <summary>
		///11 后缀
		/// </summary>
		public string SubInvSuffix
		{
			set{ _subinvsuffix=value;}
			get{return _subinvsuffix;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

