using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 会员通知发送设置表
	/// </summary>
	[Serializable]
	public partial class MemberNotice
	{
		public MemberNotice()
		{}
		#region Model
		private string _noticenumber;
		private string _noticedesc;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private string _approvestatus;
		private DateTime? _approveon;
		private int? _approveby;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 通知编号，主键
		/// </summary>
		public string NoticeNumber
		{
			set{ _noticenumber=value;}
			get{return _noticenumber;}
		}
		/// <summary>
		/// 通知描述
		/// </summary>
		public string NoticeDesc
		{
			set{ _noticedesc=value;}
			get{return _noticedesc;}
		}
		/// <summary>
		/// 生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 失效日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 单据状态。状态： P：prepare。  A:Approve 。 V：Void。Notice修改后，会从Approve状态回到prepare状态。 必须重新Approve，才能生效
		/// </summary>
		public string ApproveStatus
		{
			set{ _approvestatus=value;}
			get{return _approvestatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ApproveOn
		{
			set{ _approveon=value;}
			get{return _approveon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApproveBy
		{
			set{ _approveby=value;}
			get{return _approveby;}
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

