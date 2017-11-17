using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品部门表
	/// </summary>
	[Serializable]
	public partial class Department
	{
		public Department()
		{}
		#region Model
		private string _departcode;
		private int? _brandid;
		private string _departname1;
		private string _departname2;
		private string _departname3;
		private string _departpicfile;
		private string _departnote;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _departpicfile2;
		private string _departpicfile3;
		/// <summary>
		/// 部门编码
		/// </summary>
		public string DepartCode
		{
			set{ _departcode=value;}
			get{return _departcode;}
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
		/// 部门名称1
		/// </summary>
		public string DepartName1
		{
			set{ _departname1=value;}
			get{return _departname1;}
		}
		/// <summary>
		/// 部门名称2
		/// </summary>
		public string DepartName2
		{
			set{ _departname2=value;}
			get{return _departname2;}
		}
		/// <summary>
		/// 部门名称3
		/// </summary>
		public string DepartName3
		{
			set{ _departname3=value;}
			get{return _departname3;}
		}
		/// <summary>
		/// 部门图片文件
		/// </summary>
		public string DepartPicFile
		{
			set{ _departpicfile=value;}
			get{return _departpicfile;}
		}
		/// <summary>
		/// 部门备注
		/// </summary>
		public string DepartNote
		{
			set{ _departnote=value;}
			get{return _departnote;}
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
		/// <summary>
		/// 
		/// </summary>
		public string DepartPicFile2
		{
			set{ _departpicfile2=value;}
			get{return _departpicfile2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartPicFile3
		{
			set{ _departpicfile3=value;}
			get{return _departpicfile3;}
		}
		#endregion Model

	}
}

