using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 密码规则
	/// </summary>
	[Serializable]
	public partial class PasswordRule
	{
		public PasswordRule()
		{}
		#region Model
		private int _passwordruleid;
		private int? _pwdminlength=0;
		private int? _pwdmaxlength=0;
		private int? _pwdsecuritylevel=0;
		private int? _pwdstructure=0;
		private int? _pwdvaliddays;
		private int? _pwdvaliddaysunit;
		private int? _resetpwddays;
		private int? _memberpwdrule=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _passwordrulecode;
		private string _name1;
		private string _name2;
		private string _name3;
		/// <summary>
		/// 主键
		/// </summary>
		public int PasswordRuleID
		{
			set{ _passwordruleid=value;}
			get{return _passwordruleid;}
		}
		/// <summary>
		/// 密码最小长度
		/// </summary>
		public int? PWDMinLength
		{
			set{ _pwdminlength=value;}
			get{return _pwdminlength;}
		}
		/// <summary>
		/// 密码最大长度
		/// </summary>
		public int? PWDMaxLength
		{
			set{ _pwdmaxlength=value;}
			get{return _pwdmaxlength;}
		}
		/// <summary>
		/// 密码安全级别。0级最低。依次提高
		/// </summary>
		public int? PWDSecurityLevel
		{
			set{ _pwdsecuritylevel=value;}
			get{return _pwdsecuritylevel;}
		}
		/// <summary>
		/// 密码构成。0：没有要求。1.只能為數字。2.只能為字母。3.必須數字+字母。4.特殊符号+数字+字母

		/// </summary>
		public int? PWDStructure
		{
			set{ _pwdstructure=value;}
			get{return _pwdstructure;}
		}
		/// <summary>
		/// 密码有效天数。
		/// </summary>
		public int? PWDValidDays
		{
			set{ _pwdvaliddays=value;}
			get{return _pwdvaliddays;}
		}
		/// <summary>
		/// 密码有效天数的单位。0：永久。 1：年。 2：月。 3：星期。 4：天。
		/// </summary>
		public int? PWDValidDaysUnit
		{
			set{ _pwdvaliddaysunit=value;}
			get{return _pwdvaliddaysunit;}
		}
		/// <summary>
		/// 密码到期后，等待更新密码期限。此期限内旧密码有效，单位：天
		/// </summary>
		public int? ResetPWDDays
		{
			set{ _resetpwddays=value;}
			get{return _resetpwddays;}
		}
		/// <summary>
		/// 会员的密码的规则。0：不是。1：是。 默认0。（只能有一条记录是 1。）
		/// </summary>
		public int? MemberPWDRule
		{
			set{ _memberpwdrule=value;}
			get{return _memberpwdrule;}
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
		public string PasswordRuleCode
		{
			set{ _passwordrulecode=value;}
			get{return _passwordrulecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name1
		{
			set{ _name1=value;}
			get{return _name1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name2
		{
			set{ _name2=value;}
			get{return _name2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name3
		{
			set{ _name3=value;}
			get{return _name3;}
		}
		#endregion Model

	}
}

