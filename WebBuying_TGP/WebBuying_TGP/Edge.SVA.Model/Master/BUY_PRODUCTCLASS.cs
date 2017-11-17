using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品大类
	/// </summary>
	[Serializable]
	public partial class BUY_PRODUCTCLASS
	{
		public BUY_PRODUCTCLASS()
		{}
		#region Model
		private int _prodclassid;
		private string _prodclasscode;
		private int? _parentid;
		private string _productsizetype;
		private string _prodclassdesc1;
		private string _prodclassdesc2;
		private string _prodclassdesc3;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 货品大类主键ID
		/// </summary>
		public int ProdClassID
		{
			set{ _prodclassid=value;}
			get{return _prodclassid;}
		}
		/// <summary>
		///11 货品大类Code
		/// </summary>
		public string ProdClassCode
		{
			set{ _prodclasscode=value;}
			get{return _prodclasscode;}
		}
		/// <summary>
		///11 父ID。（树状结构）
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		///11 此大类货品使用的尺寸类型
		/// </summary>
		public string ProductSizeType
		{
			set{ _productsizetype=value;}
			get{return _productsizetype;}
		}
		/// <summary>
		///11 货品大类描述1
		/// </summary>
		public string ProdClassDesc1
		{
			set{ _prodclassdesc1=value;}
			get{return _prodclassdesc1;}
		}
		/// <summary>
		///11 货品大类描述2
		/// </summary>
		public string ProdClassDesc2
		{
			set{ _prodclassdesc2=value;}
			get{return _prodclassdesc2;}
		}
		/// <summary>
		///11 货品大类描述3
		/// </summary>
		public string ProdClassDesc3
		{
			set{ _prodclassdesc3=value;}
			get{return _prodclassdesc3;}
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

