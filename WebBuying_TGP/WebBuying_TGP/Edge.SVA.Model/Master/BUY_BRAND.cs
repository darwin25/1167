using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 品牌表
	/// </summary>
	[Serializable]
	public partial class BUY_BRAND
	{
		public BUY_BRAND()
		{}
		#region Model
		private int _brandid;
		private string _brandcode;
		private string _brandname1;
		private string _brandname2;
		private string _brandname3;
		private string _branddesc1;
		private string _branddesc2;
		private string _branddesc3;
		private string _brandpicsfile;
		private string _brandpicmfile;
		private string _brandpicgfile;
		private int? _cardissuerid;
		private int? _industryid;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 品牌ID
		/// </summary>
		public int BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		///11 品牌编码
		/// </summary>
		public string BrandCode
		{
			set{ _brandcode=value;}
			get{return _brandcode;}
		}
		/// <summary>
		///11 品牌名称1
		/// </summary>
		public string BrandName1
		{
			set{ _brandname1=value;}
			get{return _brandname1;}
		}
		/// <summary>
		///11 品牌名称1
		/// </summary>
		public string BrandName2
		{
			set{ _brandname2=value;}
			get{return _brandname2;}
		}
		/// <summary>
		///11 品牌名称1
		/// </summary>
		public string BrandName3
		{
			set{ _brandname3=value;}
			get{return _brandname3;}
		}
		/// <summary>
		///11 品牌描述1
		/// </summary>
		public string BrandDesc1
		{
			set{ _branddesc1=value;}
			get{return _branddesc1;}
		}
		/// <summary>
		///11 品牌描述2
		/// </summary>
		public string BrandDesc2
		{
			set{ _branddesc2=value;}
			get{return _branddesc2;}
		}
		/// <summary>
		///11 品牌描述3
		/// </summary>
		public string BrandDesc3
		{
			set{ _branddesc3=value;}
			get{return _branddesc3;}
		}
		/// <summary>
		///11 小图文件路径名
		/// </summary>
		public string BrandPicSFile
		{
			set{ _brandpicsfile=value;}
			get{return _brandpicsfile;}
		}
		/// <summary>
		///11 中图文件路径名
		/// </summary>
		public string BrandPicMFile
		{
			set{ _brandpicmfile=value;}
			get{return _brandpicmfile;}
		}
		/// <summary>
		///11 大图文件路径名
		/// </summary>
		public string BrandPicGFile
		{
			set{ _brandpicgfile=value;}
			get{return _brandpicgfile;}
		}
		/// <summary>
		///11 发行方ID
		/// </summary>
		public int? CardIssuerID
		{
			set{ _cardissuerid=value;}
			get{return _cardissuerid;}
		}
		/// <summary>
		///11 外键
		/// </summary>
		public int? IndustryID
		{
			set{ _industryid=value;}
			get{return _industryid;}
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

