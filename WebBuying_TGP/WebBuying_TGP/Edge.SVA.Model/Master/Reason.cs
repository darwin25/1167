using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 原因列表
	/// </summary>
	[Serializable]
	public partial class Reason
	{
		public Reason()
		{}
		#region Model
		private int _reasonid;
		private string _reasoncode;
		private string _reasondesc1;
		private string _reasondesc2;
		private string _reasondesc3;
		private DateTime? _createdon;
		private DateTime? _updatedon;
		private int? _updatedby;
		private int? _createdby;
		/// <summary>
		/// 主键
		/// </summary>
		public int ReasonID
		{
			set{ _reasonid=value;}
			get{return _reasonid;}
		}
		/// <summary>
		/// 原因编码
		/// </summary>
		public string ReasonCode
		{
			set{ _reasoncode=value;}
			get{return _reasoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReasonDesc1
		{
			set{ _reasondesc1=value;}
			get{return _reasondesc1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReasonDesc2
		{
			set{ _reasondesc2=value;}
			get{return _reasondesc2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReasonDesc3
		{
			set{ _reasondesc3=value;}
			get{return _reasondesc3;}
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
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		#endregion Model

	}
}

