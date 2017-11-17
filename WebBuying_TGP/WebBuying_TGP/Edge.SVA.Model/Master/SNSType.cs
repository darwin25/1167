using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 交友系统类型表
	/// </summary>
	[Serializable]
	public partial class SNSType
	{
		public SNSType()
		{}
		#region Model
		private int _snstypeid;
		private string _snstypename1;
		private string _snstypename2;
		private string _snstypename3;
		private string _snstypeurl;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键
		/// </summary>
		public int SNSTypeID
		{
			set{ _snstypeid=value;}
			get{return _snstypeid;}
		}
		/// <summary>
		/// 名称1
		/// </summary>
		public string SNSTypeName1
		{
			set{ _snstypename1=value;}
			get{return _snstypename1;}
		}
		/// <summary>
		/// 名称2
		/// </summary>
		public string SNSTypeName2
		{
			set{ _snstypename2=value;}
			get{return _snstypename2;}
		}
		/// <summary>
		/// 名称3
		/// </summary>
		public string SNSTypeName3
		{
			set{ _snstypename3=value;}
			get{return _snstypename3;}
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		public string SNSTypeURL
		{
			set{ _snstypeurl=value;}
			get{return _snstypeurl;}
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

