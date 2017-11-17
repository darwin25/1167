using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 学历表
	/// </summary>
	[Serializable]
	public partial class Education
	{
		public Education()
		{}
		#region Model
		private int _educationid;
		private string _educationname1;
		private string _educationname2;
		private string _educationname3;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _educationcode;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int EducationID
		{
			set{ _educationid=value;}
			get{return _educationid;}
		}
		/// <summary>
		/// 学历名称1
		/// </summary>
		public string EducationName1
		{
			set{ _educationname1=value;}
			get{return _educationname1;}
		}
		/// <summary>
		/// 学历名称2
		/// </summary>
		public string EducationName2
		{
			set{ _educationname2=value;}
			get{return _educationname2;}
		}
		/// <summary>
		/// 学历名称3
		/// </summary>
		public string EducationName3
		{
			set{ _educationname3=value;}
			get{return _educationname3;}
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
		public string EducationCode
		{
			set{ _educationcode=value;}
			get{return _educationcode;}
		}
		#endregion Model

	}
}

