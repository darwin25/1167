using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 会员地址表
	/// </summary>
	[Serializable]
	public partial class MemberAddress
	{
		public MemberAddress()
		{}
		#region Model
		private int _addressid;
		private int _memberid;
		private int? _memberfirstaddr=0;
		private string _addresscountry;
		private string _addressprovince;
		private string _addresscity;
		private string _addressdistrict;
		private string _addressdetail;
		private string _addressfulldetail;
		private string _addresszipcode;
		private string _contact;
		private string _contactphone;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 地址表主键
		/// </summary>
		public int AddressID
		{
			set{ _addressid=value;}
			get{return _addressid;}
		}
		/// <summary>
		/// 会员表ID。
		/// </summary>
		public int MemberID
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 是否会员首地址。（默认地址）0： 不是。 1： 是的。  默认为0。 都为0 时，随机排序。
		/// </summary>
		public int? MemberFirstAddr
		{
			set{ _memberfirstaddr=value;}
			get{return _memberfirstaddr;}
		}
		/// <summary>
		/// 国家编码
		/// </summary>
		public string AddressCountry
		{
			set{ _addresscountry=value;}
			get{return _addresscountry;}
		}
		/// <summary>
		/// 省（州）编码
		/// </summary>
		public string AddressProvince
		{
			set{ _addressprovince=value;}
			get{return _addressprovince;}
		}
		/// <summary>
		/// 城市编码
		/// </summary>
		public string AddressCity
		{
			set{ _addresscity=value;}
			get{return _addresscity;}
		}
		/// <summary>
		/// 区县编码
		/// </summary>
		public string AddressDistrict
		{
			set{ _addressdistrict=value;}
			get{return _addressdistrict;}
		}
		/// <summary>
		/// 详细地址。
		/// </summary>
		public string AddressDetail
		{
			set{ _addressdetail=value;}
			get{return _addressdetail;}
		}
		/// <summary>
		/// 完整地址。（AddressCountry，AddressProvince，AddressCity， AddressDistrict内填写是Code。这些字段对应的Name合并起来，加上AddressDetail内容，就是FullDetail）
		/// </summary>
		public string AddressFullDetail
		{
			set{ _addressfulldetail=value;}
			get{return _addressfulldetail;}
		}
		/// <summary>
		/// 邮编
		/// </summary>
		public string AddressZipCode
		{
			set{ _addresszipcode=value;}
			get{return _addresszipcode;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string ContactPhone
		{
			set{ _contactphone=value;}
			get{return _contactphone;}
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

