using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 原因设置表。
	/// </summary>
	[Serializable]
	public partial class BUY_REASON
	{
		public BUY_REASON()
		{}
		#region Model
		private int _reasonid;
		private string _reasoncode;
		private string _description1;
		private string _description2;
		private string _description3;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		/// <summary>
		///11 主键
		/// </summary>
		public int ReasonID
		{
            set { _reasonid = value; }
            get { return _reasonid; }
		}
		/// <summary>
		///11 原因编码
		/// </summary>
		public string ReasonCode
		{
			set{ _reasoncode=value;}
			get{return _reasoncode;}
		}
		/// <summary>
		///11 原因描述1
		/// </summary>
		public string Description1
		{
			set{ _description1=value;}
			get{return _description1;}
		}
		/// <summary>
		///11 原因描述2
		/// </summary>
		public string Description2
		{
			set{ _description2=value;}
			get{return _description2;}
		}
		/// <summary>
		///11 原因描述3
		/// </summary>
		public string Description3
		{
			set{ _description3=value;}
			get{return _description3;}
		}
		/// <summary>
		///11 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		/// <summary>
		///11 创建时间
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 创建人
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		#endregion Model

	}
}

