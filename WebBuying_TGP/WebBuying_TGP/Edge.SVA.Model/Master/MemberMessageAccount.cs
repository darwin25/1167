using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 会员消息服务账号
	/// </summary>
	[Serializable]
	public partial class MemberMessageAccount
	{
		public MemberMessageAccount()
		{}
		#region Model
		private int _messageaccountid;
		private int _memberid;
		private int _messageservicetypeid;
		private string _accountnumber;
		private int _status=1;
		private string _note;
		private int? _isprefer;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _tokenuid;
		private string _tokenstr;
		private DateTime? _tokenupdatedate;
		/// <summary>
		/// 账号主键ID
		/// </summary>
		public int MessageAccountID
		{
			set{ _messageaccountid=value;}
			get{return _messageaccountid;}
		}
		/// <summary>
		/// 会员ID，外键
		/// </summary>
		public int MemberID
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// MessageServiceType 表外键
		/// </summary>
		public int MessageServiceTypeID
		{
			set{ _messageservicetypeid=value;}
			get{return _messageservicetypeid;}
		}
		/// <summary>
		/// 账号
		/// </summary>
		public string AccountNumber
		{
			set{ _accountnumber=value;}
			get{return _accountnumber;}
		}
		/// <summary>
		/// 状态。0：无效。 1：生效
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 金额积分变动时，是否使用此账号发送消息。0: 不使用。 1：使用。 默认0。 一个会员只能有一个 IsPrefer=1的账号。  可以全部为0.
		/// </summary>
		public int? IsPrefer
		{
			set{ _isprefer=value;}
			get{return _isprefer;}
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
		public string TokenUID
		{
			set{ _tokenuid=value;}
			get{return _tokenuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TokenStr
		{
			set{ _tokenstr=value;}
			get{return _tokenstr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TokenUpdateDate
		{
			set{ _tokenupdatedate=value;}
			get{return _tokenupdatedate;}
		}
		#endregion Model

	}
}

