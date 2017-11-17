using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品大类
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	///Pending表 @2016-08-08 (for bauhaus)
	/// </summary>
	[Serializable]
	public partial class BUY_PRODUCTCLASS_Pending
	{
		public BUY_PRODUCTCLASS_Pending()
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
		/// 货品大类主键ID
		/// </summary>
		public int ProdClassID
		{
			set{ _prodclassid=value;}
			get{return _prodclassid;}
		}
		/// <summary>
		/// 货品大类Code
		/// </summary>
		public string ProdClassCode
		{
			set{ _prodclasscode=value;}
			get{return _prodclasscode;}
		}
		/// <summary>
		/// 父ID。（树状结构）
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 此大类货品使用的尺寸类型
		/// </summary>
		public string ProductSizeType
		{
			set{ _productsizetype=value;}
			get{return _productsizetype;}
		}
		/// <summary>
		/// 货品大类描述1
		/// </summary>
		public string ProdClassDesc1
		{
			set{ _prodclassdesc1=value;}
			get{return _prodclassdesc1;}
		}
		/// <summary>
		/// 货品大类描述2
		/// </summary>
		public string ProdClassDesc2
		{
			set{ _prodclassdesc2=value;}
			get{return _prodclassdesc2;}
		}
		/// <summary>
		/// 货品大类描述3
		/// </summary>
		public string ProdClassDesc3
		{
			set{ _prodclassdesc3=value;}
			get{return _prodclassdesc3;}
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

