using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 员工表。（POS登录用）
	/// </summary>
	[Serializable]
	public partial class POSSTAFF
	{
		public POSSTAFF()
		{}
		#region Model
		private int _staffid;
		private string _staffcode;
		private string _staffname;
		private string _staffpwd;
		private int? _stafflevel=0;
		private int? _status=1;
		private int? _languageid;
		private int? _def_reset_pwd_days=0;
		private int? _grace_login_count=0;
		private int? _pwd_valid_days=0;
		private DateTime? _last_reset_pwd= DateTime.Now;
		private DateTime? _lastlogintime;
		private string _lastloginstore;
		private string _lastloginregister;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键，自增长
		/// </summary>
		public int StaffID
		{
			set{ _staffid=value;}
			get{return _staffid;}
		}
		/// <summary>
		/// 员工编号
		/// </summary>
		public string StaffCode
		{
			set{ _staffcode=value;}
			get{return _staffcode;}
		}
		/// <summary>
		/// 员工姓名
		/// </summary>
		public string StaffName
		{
			set{ _staffname=value;}
			get{return _staffname;}
		}
		/// <summary>
		/// 登录密码
		/// </summary>
		public string StaffPWD
		{
			set{ _staffpwd=value;}
			get{return _staffpwd;}
		}
		/// <summary>
		/// 员工级别。数字转换为二进制数。 一共3位。 第一位管理员权限。 第二位促销员权限。第三位收银员权限
		/// 例如：
		/// 001---  1： 收银员
		/// 010---  2： 促销员
		/// 100---  4： 管理员
		/// 101...  5:    收银员 + 管理员
		/// ......
		/// 111...  7:   收银员 + 管理员 + 促销员


		/// </summary>
		public int? StaffLevel
		{
			set{ _stafflevel=value;}
			get{return _stafflevel;}
		}
		/// <summary>
		/// 状态. 0: 无效。 1：有效
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 默认语言ID。应该同LanguageMap表中的ID
		/// </summary>
		public int? LanguageID
		{
			set{ _languageid=value;}
			get{return _languageid;}
		}
		/// <summary>
		/// 默认允许超过reset pwd 的天数。默认0
		/// </summary>
		public int? Def_Reset_PWD_DAYS
		{
			set{ _def_reset_pwd_days=value;}
			get{return _def_reset_pwd_days;}
		}
		/// <summary>
		/// login允许连续失败次数。默认0，表示不设限制
		/// </summary>
		public int? Grace_Login_Count
		{
			set{ _grace_login_count=value;}
			get{return _grace_login_count;}
		}
		/// <summary>
		/// 密码有效天数。 默认0，表示永久有效
		/// </summary>
		public int? PWD_Valid_Days
		{
			set{ _pwd_valid_days=value;}
			get{return _pwd_valid_days;}
		}
		/// <summary>
		/// 最后更新密码的日期时间
		/// </summary>
		public DateTime? Last_Reset_PWD
		{
			set{ _last_reset_pwd=value;}
			get{return _last_reset_pwd;}
		}
		/// <summary>
		/// 最后登录的时间
		/// </summary>
		public DateTime? LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		/// <summary>
		/// 最后登录的StoreCode
		/// </summary>
		public string LastLoginStore
		{
			set{ _lastloginstore=value;}
			get{return _lastloginstore;}
		}
		/// <summary>
		/// 最后登录的RegisterCode
		/// </summary>
		public string LastLoginRegister
		{
			set{ _lastloginregister=value;}
			get{return _lastloginregister;}
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

