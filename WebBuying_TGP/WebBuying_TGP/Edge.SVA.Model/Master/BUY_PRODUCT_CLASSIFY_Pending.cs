using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品划分。（辅助表。 货品和其他表配合，多对多关系）
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	///Pending表 @2016-08-08 (for bauhaus)
	/// </summary>
	[Serializable]
	public partial class BUY_PRODUCT_CLASSIFY_Pending
	{
		public BUY_PRODUCT_CLASSIFY_Pending()
		{}
		#region Model
		private string _prodcode;
		private int _foreignkeyid;
		private string _foreigntable;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 货品主键
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 外键ID。（ForeignTable指定表的外键）
		/// </summary>
		public int ForeignkeyID
		{
			set{ _foreignkeyid=value;}
			get{return _foreignkeyid;}
		}
		/// <summary>
		/// 外键表。（表名）
		/// </summary>
		public string ForeignTable
		{
			set{ _foreigntable=value;}
			get{return _foreigntable;}
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

