using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品目录绑定表（货品和部门，多对多）
	///当此表数据存在时，根据部门查询货品，将根据此表查询。否则根据product表的 departcode查询
    /// 创建人:Lisa
    /// 创建时间：2016-02-25
	/// </summary>
	[Serializable]
	public partial class BUY_Product_Catalog
	{
		public BUY_Product_Catalog()
		{}
		#region Model
		private string _prodcode;
		private string _departcode;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 货品编码，主键
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 货品部门编码
		/// </summary>
		public string DepartCode
		{
			set{ _departcode=value;}
			get{return _departcode;}
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

