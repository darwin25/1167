using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 专业表
	/// </summary>
	[Serializable]
	public partial class Profession
	{
		public Profession()
		{}
		#region Model
		private int _professionid;
		private string _professionname1;
		private string _professionname2;
		private string _professionname3;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _professioncode;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int ProfessionID
		{
			set{ _professionid=value;}
			get{return _professionid;}
		}
		/// <summary>
		/// 专业名称1
		/// </summary>
		public string ProfessionName1
		{
			set{ _professionname1=value;}
			get{return _professionname1;}
		}
		/// <summary>
		/// 专业名称2
		/// </summary>
		public string ProfessionName2
		{
			set{ _professionname2=value;}
			get{return _professionname2;}
		}
		/// <summary>
		/// 专业名称3
		/// </summary>
		public string ProfessionName3
		{
			set{ _professionname3=value;}
			get{return _professionname3;}
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
		public string ProfessionCode
		{
			set{ _professioncode=value;}
			get{return _professioncode;}
		}
		#endregion Model

	}
}

