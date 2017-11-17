using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 行业表
	/// </summary>
	[Serializable]
	public partial class Industry
	{
		public Industry()
		{}
		#region Model
		private int _industryid;
		private string _industryname1;
		private string _industryname2;
		private string _industryname3;
		private int? _updatedby;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private string _industrycode;
		/// <summary>
		/// 主键
		/// </summary>
		public int IndustryID
		{
			set{ _industryid=value;}
			get{return _industryid;}
		}
		/// <summary>
		/// 活动名称
		/// </summary>
		public string IndustryName1
		{
			set{ _industryname1=value;}
			get{return _industryname1;}
		}
		/// <summary>
		/// 活动名称
		/// </summary>
		public string IndustryName2
		{
			set{ _industryname2=value;}
			get{return _industryname2;}
		}
		/// <summary>
		/// 活动名称
		/// </summary>
		public string IndustryName3
		{
			set{ _industryname3=value;}
			get{return _industryname3;}
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
		public string IndustryCode
		{
			set{ _industrycode=value;}
			get{return _industrycode;}
		}
		#endregion Model

	}
}

