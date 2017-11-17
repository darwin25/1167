using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 公司表
    /// 创建人:Lisa
    /// 创建时间：2016-02-25
	/// </summary>
	[Serializable]
	public partial class Company
	{
		public Company()
		{}
		#region Model
		private int _companyid;
		private string _companycode;
		private string _companyname;
		private string _companyaddress;
		private string _companytelnum;
		private string _companyfaxnum;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _companyaddress1;
		private string _companyaddress2;
		private string _companyemail;
		private string _contactperson;
		private string _contactemail;
		private string _contactnumber;
		private string _contactphonenumber;
		private string _remark;
		private int? _isdefault=0;
		/// <summary>
		/// 主键ID 
		/// </summary>
		public int CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 公司编码
		/// </summary>
		public string CompanyCode
		{
			set{ _companycode=value;}
			get{return _companycode;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 地址ID
		/// </summary>
		public string CompanyAddress
		{
			set{ _companyaddress=value;}
			get{return _companyaddress;}
		}
		/// <summary>
		/// 公司电话
		/// </summary>
		public string CompanyTelNum
		{
			set{ _companytelnum=value;}
			get{return _companytelnum;}
		}
		/// <summary>
		/// 公司传真
		/// </summary>
		public string CompanyFaxNum
		{
			set{ _companyfaxnum=value;}
			get{return _companyfaxnum;}
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
		/// 地址1
		/// </summary>
		public string CompanyAddress1
		{
			set{ _companyaddress1=value;}
			get{return _companyaddress1;}
		}
		/// <summary>
		/// 地址2
		/// </summary>
		public string CompanyAddress2
		{
			set{ _companyaddress2=value;}
			get{return _companyaddress2;}
		}
		/// <summary>
		/// 公司邮箱
		/// </summary>
		public string CompanyEmail
		{
			set{ _companyemail=value;}
			get{return _companyemail;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string ContactPerson
		{
			set{ _contactperson=value;}
			get{return _contactperson;}
		}
		/// <summary>
		/// 联系人邮箱
		/// </summary>
		public string ContactEmail
		{
			set{ _contactemail=value;}
			get{return _contactemail;}
		}
		/// <summary>
		/// 联系人号码
		/// </summary>
		public string ContactNumber
		{
			set{ _contactnumber=value;}
			get{return _contactnumber;}
		}
		/// <summary>
		/// 联系人电话号码
		/// </summary>
		public string ContactPhoneNumber
		{
			set{ _contactphonenumber=value;}
			get{return _contactphonenumber;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 是否作为默认选择。（只能一条记录是default）
		/// </summary>
		public int? IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		#endregion Model

	}
}

