using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 会员表
	/// </summary>
	[Serializable]
	public partial class Member
	{
		public Member()
		{}
		#region Model
		private int _memberid;
		private string _memberpassword;
		private int? _memberidentitytype=1;
		private string _memberidentityref;
		private string _memberregistermobile;
		private string _membermobilephone;
		private string _memberemail;
		private string _memberappellation;
		private string _memberengfamilyname;
		private string _memberenggivenname;
		private string _memberchifamilyname;
		private string _memberchigivenname;
		private int? _membersex=0;
		private DateTime _memberdateofbirth;
		private int _memberdayofbirth;
		private int _membermonthofbirth;
		private int _memberyearofbirth;
		private int? _membermarital=0;
		private string _homeaddress;
		private string _hometelnum;
		private string _homefaxnum;
		private string _officeaddress;
		private string _officetelnum;
		private string _officefaxnum;
		private int? _educationid=0;
		private int? _professionid;
		private string _memberposition;
		private int? _nationid;
		private string _companydesc;
		private string _spremark;
		private string _othercontact;
		private string _hobbies;
		private int? _status=1;
		private int? _memberdeflanguage;
		private DateTime? _createdon= DateTime.Now;
		private DateTime? _updatedon= DateTime.Now;
		private int? _createdby;
		private int? _updatedby;
		private DateTime? _passwordexpirydate;
		private int? _pwdexpirypromptdays;
		private string _countrycode;
		private string _nickname;
		private string _memberpicturefile;
		private byte[] _memberpicture;
		private int? _readreguflag=0;
		/// <summary>
		/// 会员表主键
		/// </summary>
		public int MemberID
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 会员密码。（MD5加密）
		/// </summary>
		public string MemberPassword
		{
			set{ _memberpassword=value;}
			get{return _memberpassword;}
		}
		/// <summary>
		/// 会员证件类型1：身份证号码。2：军官证。 3：回乡证
		/// </summary>
		public int? MemberIdentityType
		{
			set{ _memberidentitytype=value;}
			get{return _memberidentitytype;}
		}
		/// <summary>
		/// 会员证件号码
		/// </summary>
		public string MemberIdentityRef
		{
			set{ _memberidentityref=value;}
			get{return _memberidentityref;}
		}
		/// <summary>
		/// 会员注册用手机号（加上国家代码的，例如0861392572219）
		/// </summary>
		public string MemberRegisterMobile
		{
			set{ _memberregistermobile=value;}
			get{return _memberregistermobile;}
		}
		/// <summary>
		/// 会员手机号，不加国家代码（例如，1394592381）
		/// </summary>
		public string MemberMobilePhone
		{
			set{ _membermobilephone=value;}
			get{return _membermobilephone;}
		}
		/// <summary>
		/// 会员邮箱
		/// </summary>
		public string MemberEmail
		{
			set{ _memberemail=value;}
			get{return _memberemail;}
		}
		/// <summary>
		/// 会员称呼：Mr.  Miss.  Mrs.     或者 先生   小姐   夫人。
		/// </summary>
		public string MemberAppellation
		{
			set{ _memberappellation=value;}
			get{return _memberappellation;}
		}
		/// <summary>
		/// 会员英文名（姓）
		/// </summary>
		public string MemberEngFamilyName
		{
			set{ _memberengfamilyname=value;}
			get{return _memberengfamilyname;}
		}
		/// <summary>
		/// 会员英文名（名）
		/// </summary>
		public string MemberEngGivenName
		{
			set{ _memberenggivenname=value;}
			get{return _memberenggivenname;}
		}
		/// <summary>
		/// 会员中文名（姓）
		/// </summary>
		public string MemberChiFamilyName
		{
			set{ _memberchifamilyname=value;}
			get{return _memberchifamilyname;}
		}
		/// <summary>
		/// 会员中文名（名）
		/// </summary>
		public string MemberChiGivenName
		{
			set{ _memberchigivenname=value;}
			get{return _memberchigivenname;}
		}
		/// <summary>
		/// 会员性别null或0：保密。1：男性。 2：女性
		/// </summary>
		public int? MemberSex
		{
			set{ _membersex=value;}
			get{return _membersex;}
		}
		/// <summary>
		/// 会员生日（出生日期）
		/// </summary>
		public DateTime MemberDateOfBirth
		{
			set{ _memberdateofbirth=value;}
			get{return _memberdateofbirth;}
		}
		/// <summary>
		/// 会员生日（天）
		/// </summary>
		public int MemberDayOfBirth
		{
			set{ _memberdayofbirth=value;}
			get{return _memberdayofbirth;}
		}
		/// <summary>
		/// 会员生日（月）
		/// </summary>
		public int MemberMonthOfBirth
		{
			set{ _membermonthofbirth=value;}
			get{return _membermonthofbirth;}
		}
		/// <summary>
		/// 会员生日（年）
		/// </summary>
		public int MemberYearOfBirth
		{
			set{ _memberyearofbirth=value;}
			get{return _memberyearofbirth;}
		}
		/// <summary>
		/// 婚姻情况。默认 0 . 0: 保密  1：未婚. 2：已婚。 
		/// </summary>
		public int? MemberMarital
		{
			set{ _membermarital=value;}
			get{return _membermarital;}
		}
		/// <summary>
		/// 家庭地址
		/// </summary>
		public string HomeAddress
		{
			set{ _homeaddress=value;}
			get{return _homeaddress;}
		}
		/// <summary>
		/// 家庭电话
		/// </summary>
		public string HomeTelNum
		{
			set{ _hometelnum=value;}
			get{return _hometelnum;}
		}
		/// <summary>
		/// 家庭传真
		/// </summary>
		public string HomeFaxNum
		{
			set{ _homefaxnum=value;}
			get{return _homefaxnum;}
		}
		/// <summary>
		/// 办公室地址
		/// </summary>
		public string OfficeAddress
		{
			set{ _officeaddress=value;}
			get{return _officeaddress;}
		}
		/// <summary>
		/// 办公室电话
		/// </summary>
		public string OfficeTelNum
		{
			set{ _officetelnum=value;}
			get{return _officetelnum;}
		}
		/// <summary>
		/// 办公室传真
		/// </summary>
		public string OfficeFaxNum
		{
			set{ _officefaxnum=value;}
			get{return _officefaxnum;}
		}
		/// <summary>
		/// 外键 EducationID
		/// </summary>
		public int? EducationID
		{
			set{ _educationid=value;}
			get{return _educationid;}
		}
		/// <summary>
		/// 会员专业，外键
		/// </summary>
		public int? ProfessionID
		{
			set{ _professionid=value;}
			get{return _professionid;}
		}
		/// <summary>
		/// 会员职位
		/// </summary>
		public string MemberPosition
		{
			set{ _memberposition=value;}
			get{return _memberposition;}
		}
		/// <summary>
		/// 手机号码所属国籍,外键ID。
		/// </summary>
		public int? NationID
		{
			set{ _nationid=value;}
			get{return _nationid;}
		}
		/// <summary>
		/// 公司ID
		/// </summary>
		public string CompanyDesc
		{
			set{ _companydesc=value;}
			get{return _companydesc;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string SpRemark
		{
			set{ _spremark=value;}
			get{return _spremark;}
		}
		/// <summary>
		/// 其他联系方式
		/// </summary>
		public string OtherContact
		{
			set{ _othercontact=value;}
			get{return _othercontact;}
		}
		/// <summary>
		/// 兴趣爱好
		/// </summary>
		public string Hobbies
		{
			set{ _hobbies=value;}
			get{return _hobbies;}
		}
		/// <summary>
		/// 状态。 0：无效。 1：有效
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 外键，LanguageMap表主键
		/// </summary>
		public int? MemberDefLanguage
		{
			set{ _memberdeflanguage=value;}
			get{return _memberdeflanguage;}
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
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
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
		public DateTime? PasswordExpiryDate
		{
			set{ _passwordexpirydate=value;}
			get{return _passwordexpirydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PWDExpiryPromptDays
		{
			set{ _pwdexpirypromptdays=value;}
			get{return _pwdexpirypromptdays;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CountryCode
		{
			set{ _countrycode=value;}
			get{return _countrycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemberPictureFile
		{
			set{ _memberpicturefile=value;}
			get{return _memberpicturefile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] MemberPicture
		{
			set{ _memberpicture=value;}
			get{return _memberpicture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ReadReguFlag
		{
			set{ _readreguflag=value;}
			get{return _readreguflag;}
		}
		#endregion Model

	}
}

