using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺表
	/// </summary>
	[Serializable]
	public partial class Store
	{
		public Store()
		{}
		#region Model
		private int _storeid;
		private string _storecode;
		private string _storename1;
		private string _storename2;
		private string _storename3;
		private int? _storetypeid;
		private int? _storegroupid;
		private int? _bankid;
		private string _storecountry;
		private string _storeprovince;
		private string _storecity;
		private string _storeaddressdetail;
		private string _storetel;
		private string _storefax;
		private string _storelongitude;
		private string _storelatitude;
		private int? _locationid;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _storenote;
		private string _storeopentime;
		private string _storeclosetime;
		private int? _brandid;
		private string _storepicfile;
		private string _mapspicfile;
		private string _mapspicshadowfile;
		private string _email;
		private string _contact;
		private string _contactphone;
		private string _storedistrict;
		private string _storefulldetail;
		private string _storeaddressdetail2;
		private string _storefulldetail2;
		private string _storeaddressdetail3;
		private string _storefulldetail3;
		private int? _status=1;
		/// <summary>
		/// 表主键
		/// </summary>
		public int StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 店铺编码
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		/// 店铺名称。
		/// </summary>
		public string StoreName1
		{
			set{ _storename1=value;}
			get{return _storename1;}
		}
		/// <summary>
		/// 店铺名称。
		/// </summary>
		public string StoreName2
		{
			set{ _storename2=value;}
			get{return _storename2;}
		}
		/// <summary>
		/// 店铺名称。
		/// </summary>
		public string StoreName3
		{
			set{ _storename3=value;}
			get{return _storename3;}
		}
		/// <summary>
		/// 店铺类型ID
		/// </summary>
		public int? StoreTypeID
		{
			set{ _storetypeid=value;}
			get{return _storetypeid;}
		}
		/// <summary>
		/// 所属店铺组
		/// </summary>
		public int? StoreGroupID
		{
			set{ _storegroupid=value;}
			get{return _storegroupid;}
		}
		/// <summary>
		/// 主键
		/// </summary>
		public int? BankID
		{
			set{ _bankid=value;}
			get{return _bankid;}
		}
		/// <summary>
		/// 店铺所在国家
		/// </summary>
		public string StoreCountry
		{
			set{ _storecountry=value;}
			get{return _storecountry;}
		}
		/// <summary>
		/// 店铺所在省
		/// </summary>
		public string StoreProvince
		{
			set{ _storeprovince=value;}
			get{return _storeprovince;}
		}
		/// <summary>
		/// 店铺所在城市
		/// </summary>
		public string StoreCity
		{
			set{ _storecity=value;}
			get{return _storecity;}
		}
		/// <summary>
		/// 店铺详细地址
		/// </summary>
		public string StoreAddressDetail
		{
			set{ _storeaddressdetail=value;}
			get{return _storeaddressdetail;}
		}
		/// <summary>
		/// 店铺电话
		/// </summary>
		public string StoreTel
		{
			set{ _storetel=value;}
			get{return _storetel;}
		}
		/// <summary>
		/// 店铺传真
		/// </summary>
		public string StoreFax
		{
			set{ _storefax=value;}
			get{return _storefax;}
		}
		/// <summary>
		/// 店铺坐标，经度
		/// </summary>
		public string StoreLongitude
		{
			set{ _storelongitude=value;}
			get{return _storelongitude;}
		}
		/// <summary>
		/// 店铺坐标，纬度
		/// </summary>
		public string StoreLatitude
		{
			set{ _storelatitude=value;}
			get{return _storelatitude;}
		}
		/// <summary>
		/// 区域ID，外键。一个店铺 只能属于一个 区域。（  最下层的那个区域）
		/// </summary>
		public int? LocationID
		{
			set{ _locationid=value;}
			get{return _locationid;}
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
		public string StoreNote
		{
			set{ _storenote=value;}
			get{return _storenote;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreOpenTime
		{
			set{ _storeopentime=value;}
			get{return _storeopentime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreCloseTime
		{
			set{ _storeclosetime=value;}
			get{return _storeclosetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StorePicFile
		{
			set{ _storepicfile=value;}
			get{return _storepicfile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MapsPicFile
		{
			set{ _mapspicfile=value;}
			get{return _mapspicfile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MapsPicShadowFile
		{
			set{ _mapspicshadowfile=value;}
			get{return _mapspicshadowfile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContactPhone
		{
			set{ _contactphone=value;}
			get{return _contactphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreDistrict
		{
			set{ _storedistrict=value;}
			get{return _storedistrict;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreFullDetail
		{
			set{ _storefulldetail=value;}
			get{return _storefulldetail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreAddressDetail2
		{
			set{ _storeaddressdetail2=value;}
			get{return _storeaddressdetail2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreFullDetail2
		{
			set{ _storefulldetail2=value;}
			get{return _storefulldetail2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreAddressDetail3
		{
			set{ _storeaddressdetail3=value;}
			get{return _storeaddressdetail3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreFullDetail3
		{
			set{ _storefulldetail3=value;}
			get{return _storefulldetail3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

