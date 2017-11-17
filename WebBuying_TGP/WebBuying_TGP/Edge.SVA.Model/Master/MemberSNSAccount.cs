using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 交友系统账号
	/// </summary>
	[Serializable]
	public partial class MemberSNSAccount
	{
		public MemberSNSAccount()
		{}
		#region Model
		private int _snsaccountid;
		private int _memberid;
		private int _snstypeid;
		private string _accountnumber;
		private int _status=1;
		private string _note;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 账号主键ID
		/// </summary>
		public int SNSAccountID
		{
			set{ _snsaccountid=value;}
			get{return _snsaccountid;}
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
		/// SNSType 表外键
		/// </summary>
		public int SNSTypeID
		{
			set{ _snstypeid=value;}
			get{return _snstypeid;}
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

