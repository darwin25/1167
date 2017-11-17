using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品表
	/// </summary>
	[Serializable]
	public partial class Product
	{
		public Product()
		{}
		#region Model
		private string _prodcode;
		private string _prodname1;
		private string _prodname2;
		private string _prodname3;
		private string _departcode;
		private int? _nonsale=1;
		private string _prodpicfile;
		private int? _brandid;
		private int? _prodtype;
		private string _prodnote;
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
		/// 货品名称1
		/// </summary>
		public string ProdName1
		{
			set{ _prodname1=value;}
			get{return _prodname1;}
		}
		/// <summary>
		/// 货品名称2
		/// </summary>
		public string ProdName2
		{
			set{ _prodname2=value;}
			get{return _prodname2;}
		}
		/// <summary>
		/// 货品名称3
		/// </summary>
		public string ProdName3
		{
			set{ _prodname3=value;}
			get{return _prodname3;}
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
		/// 是否允许销售。0：不允许。1：允许
		/// </summary>
		public int? NonSale
		{
			set{ _nonsale=value;}
			get{return _nonsale;}
		}
		/// <summary>
		/// 货品图片文件
		/// </summary>
		public string ProdPicFile
		{
			set{ _prodpicfile=value;}
			get{return _prodpicfile;}
		}
		/// <summary>
		/// 品牌ID
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 货品类型
		/// </summary>
		public int? ProdType
		{
			set{ _prodtype=value;}
			get{return _prodtype;}
		}
		/// <summary>
		/// 货品备注
		/// </summary>
		public string ProdNote
		{
			set{ _prodnote=value;}
			get{return _prodnote;}
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

