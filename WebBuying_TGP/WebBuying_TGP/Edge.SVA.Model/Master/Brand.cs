using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺品牌表。（运营商的品牌）
	///@2016-08-09 添加
    ///创建人:Lisa
    ///创建时间：2016-08-10
	/// </summary>
	[Serializable]
	public partial class Brand
	{
        public Brand()
		{}
		#region Model
		private int _storebrandid;
		private string _storebrandcode;
		private string _storebrandname1;
		private string _storebrandname2;
		private string _storebrandname3;
		private string _storebranddesc1;
		private string _storebranddesc2;
		private string _storebranddesc3;
		private string _storebrandpicsfile;
		private string _storebrandpicmfile;
		private string _storebrandpicgfile;
		private int? _cardissuerid;
		private int? _industryid;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 货品品牌ID
		/// </summary>
		public int StoreBrandID
		{
			set{ _storebrandid=value;}
			get{return _storebrandid;}
		}
		/// <summary>
		/// 货品品牌编码
		/// </summary>
		public string StoreBrandCode
		{
			set{ _storebrandcode=value;}
			get{return _storebrandcode;}
		}
		/// <summary>
		/// 货品品牌名称1
		/// </summary>
		public string StoreBrandName1
		{
			set{ _storebrandname1=value;}
			get{return _storebrandname1;}
		}
		/// <summary>
		/// 货品品牌名称1
		/// </summary>
		public string StoreBrandName2
		{
			set{ _storebrandname2=value;}
			get{return _storebrandname2;}
		}
		/// <summary>
		/// 货品品牌名称1
		/// </summary>
		public string StoreBrandName3
		{
			set{ _storebrandname3=value;}
			get{return _storebrandname3;}
		}
		/// <summary>
		/// 货品品牌描述1
		/// </summary>
		public string StoreBrandDesc1
		{
			set{ _storebranddesc1=value;}
			get{return _storebranddesc1;}
		}
		/// <summary>
		/// 货品品牌描述2
		/// </summary>
		public string StoreBrandDesc2
		{
			set{ _storebranddesc2=value;}
			get{return _storebranddesc2;}
		}
		/// <summary>
		/// 货品品牌描述3
		/// </summary>
		public string StoreBrandDesc3
		{
			set{ _storebranddesc3=value;}
			get{return _storebranddesc3;}
		}
		/// <summary>
		/// 货品小图文件路径名
		/// </summary>
		public string StoreBrandPicSFile
		{
			set{ _storebrandpicsfile=value;}
			get{return _storebrandpicsfile;}
		}
		/// <summary>
		/// 货品中图文件路径名
		/// </summary>
		public string StoreBrandPicMFile
		{
			set{ _storebrandpicmfile=value;}
			get{return _storebrandpicmfile;}
		}
		/// <summary>
		/// 货品大图文件路径名
		/// </summary>
		public string StoreBrandPicGFile
		{
			set{ _storebrandpicgfile=value;}
			get{return _storebrandpicgfile;}
		}
		/// <summary>
		/// 货品发行方ID
		/// </summary>
		public int? CardIssuerID
		{
			set{ _cardissuerid=value;}
			get{return _cardissuerid;}
		}
		/// <summary>
		/// 外键
		/// </summary>
		public int? IndustryID
		{
			set{ _industryid=value;}
			get{return _industryid;}
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

