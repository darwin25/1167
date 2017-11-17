using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 供应商表
	/// </summary>
	[Serializable]
	public partial class BUY_VENDOR
	{
		public BUY_VENDOR()
		{}
		#region Model
		private int _vendorid;
		private string _vendorcode;
		private string _vendorname1;
		private string _vendorname2;
		private string _vendorname3;
		private string _vendoraddress1;
		private string _vendoraddress2;
		private string _vendoraddress3;
		private string _vendornote;
		private int _preferflag=0;
		private string _contact;
		private string _contactposition;
		private string _contacttel;
		private string _contactfax;
		private string _contactmobile;
		private string _contactemail;
		private int? _terms;
		private decimal? _limit;
		private string _shipment;
		private string _payterm;
		private string _accountcode;
		private int? _oversea=0;
		private decimal? _intax=0M;
		private int? _nonorder=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 供应商ID
		/// </summary>
		public int VendorID
		{
			set{ _vendorid=value;}
			get{return _vendorid;}
		}
		/// <summary>
		///11 供应商编码
		/// </summary>
		public string VendorCode
		{
			set{ _vendorcode=value;}
			get{return _vendorcode;}
		}
		/// <summary>
		///11 供应商名称1
		/// </summary>
		public string VendorName1
		{
			set{ _vendorname1=value;}
			get{return _vendorname1;}
		}
		/// <summary>
		///11 供应商名称2
		/// </summary>
		public string VendorName2
		{
			set{ _vendorname2=value;}
			get{return _vendorname2;}
		}
		/// <summary>
		///11 供应商名称3
		/// </summary>
		public string VendorName3
		{
			set{ _vendorname3=value;}
			get{return _vendorname3;}
		}
		/// <summary>
		///11 供应商地址1
		/// </summary>
		public string VendorAddress1
		{
			set{ _vendoraddress1=value;}
			get{return _vendoraddress1;}
		}
		/// <summary>
		///11 供应商地址2
		/// </summary>
		public string VendorAddress2
		{
			set{ _vendoraddress2=value;}
			get{return _vendoraddress2;}
		}
		/// <summary>
		///11 供应商地址3
		/// </summary>
		public string VendorAddress3
		{
			set{ _vendoraddress3=value;}
			get{return _vendoraddress3;}
		}
		/// <summary>
		///11 供应商备注
		/// </summary>
		public string VendorNote
		{
			set{ _vendornote=value;}
			get{return _vendornote;}
		}
		/// <summary>
		///11 是否受欢迎供应商. 1：是。0：不是
		/// </summary>
		public int PreferFlag
		{
			set{ _preferflag=value;}
			get{return _preferflag;}
		}
		/// <summary>
		///11 联系人
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		///11 联系人职位
		/// </summary>
		public string ContactPosition
		{
			set{ _contactposition=value;}
			get{return _contactposition;}
		}
		/// <summary>
		///11 联系电话
		/// </summary>
		public string ContactTel
		{
			set{ _contacttel=value;}
			get{return _contacttel;}
		}
		/// <summary>
		///11 联系传真
		/// </summary>
		public string ContactFax
		{
			set{ _contactfax=value;}
			get{return _contactfax;}
		}
		/// <summary>
		///11 联系手机
		/// </summary>
		public string ContactMobile
		{
			set{ _contactmobile=value;}
			get{return _contactmobile;}
		}
		/// <summary>
		///11 联系邮箱
		/// </summary>
		public string ContactEmail
		{
			set{ _contactemail=value;}
			get{return _contactemail;}
		}
		/// <summary>
		///11 付款天数设定
		/// </summary>
		public int? Terms
		{
			set{ _terms=value;}
			get{return _terms;}
		}
		/// <summary>
		///11 信用额度限制
		/// </summary>
		public decimal? Limit
		{
			set{ _limit=value;}
			get{return _limit;}
		}
		/// <summary>
		///11 货运
		/// </summary>
		public string Shipment
		{
			set{ _shipment=value;}
			get{return _shipment;}
		}
		/// <summary>
		///11 付款条款
		/// </summary>
		public string PayTerm
		{
			set{ _payterm=value;}
			get{return _payterm;}
		}
		/// <summary>
		///11 账号
		/// </summary>
		public string AccountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		///11 是否海外供应商. 1：是的。 0：不是
		/// </summary>
		public int? Oversea
		{
			set{ _oversea=value;}
			get{return _oversea;}
		}
		/// <summary>
		///11 税率（供应商提供）
		/// </summary>
		public decimal? InTax
		{
			set{ _intax=value;}
			get{return _intax;}
		}
		/// <summary>
		///11 是否看订货供应商。 1：是的。 0：不是
		/// </summary>
		public int? NonOrder
		{
			set{ _nonorder=value;}
			get{return _nonorder;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

