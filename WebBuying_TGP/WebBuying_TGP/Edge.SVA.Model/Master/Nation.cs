using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 国家表
	/// </summary>
	[Serializable]
	public partial class Nation
	{
		public Nation()
		{}
		#region Model
		private int _nationid;
		private string _nationcode;
		private string _countrycode;
		private string _nationname1;
		private string _nationname2;
		private string _nationname3;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int NationID
		{
			set{ _nationid=value;}
			get{return _nationid;}
		}
		/// <summary>
		/// 国家编码: ZH-CN
		/// </summary>
		public string NationCode
		{
			set{ _nationcode=value;}
			get{return _nationcode;}
		}
		/// <summary>
		/// 国家代码: 086
		/// </summary>
		public string CountryCode
		{
			set{ _countrycode=value;}
			get{return _countrycode;}
		}
		/// <summary>
		/// 国家名称1
		/// </summary>
		public string NationName1
		{
			set{ _nationname1=value;}
			get{return _nationname1;}
		}
		/// <summary>
		/// 国家名称2
		/// </summary>
		public string NationName2
		{
			set{ _nationname2=value;}
			get{return _nationname2;}
		}
		/// <summary>
		/// 国家名称3
		/// </summary>
		public string NationName3
		{
			set{ _nationname3=value;}
			get{return _nationname3;}
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

