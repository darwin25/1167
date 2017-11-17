using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 好友表
	/// </summary>
	[Serializable]
	public partial class MemberFriend
	{
		public MemberFriend()
		{}
		#region Model
		private int _memberfriendid;
		private int _memberid;
		private int? _friendmemberid;
		private string _friendname;
		private string _mobilenumber;
		private string _email;
		private int? _snstypeid;
		private string _snsaccountno;
		private int _status=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键
		/// </summary>
		public int MemberFriendID
		{
			set{ _memberfriendid=value;}
			get{return _memberfriendid;}
		}
		/// <summary>
		/// 会员ID
		/// </summary>
		public int MemberID
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 好友ID。（member表的ID）
		/// </summary>
		public int? FriendMemberID
		{
			set{ _friendmemberid=value;}
			get{return _friendmemberid;}
		}
		/// <summary>
		/// 好友名称
		/// </summary>
		public string FriendName
		{
			set{ _friendname=value;}
			get{return _friendname;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string MobileNumber
		{
			set{ _mobilenumber=value;}
			get{return _mobilenumber;}
		}
		/// <summary>
		/// 邮件信箱
		/// </summary>
		public string EMail
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 相关SNSType 的 外键
		/// </summary>
		public int? SNSTypeID
		{
			set{ _snstypeid=value;}
			get{return _snstypeid;}
		}
		/// <summary>
		/// 在SNS 中的账号
		/// </summary>
		public string SNSAccountNo
		{
			set{ _snsaccountno=value;}
			get{return _snsaccountno;}
		}
		/// <summary>
		/// 状态。0：待审核。 1：好友状态。 2：审核不通过。 3：黑名单
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
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

