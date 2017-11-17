using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺表。
	/// </summary>
	[Serializable]
	public partial class BUY_STORE
	{
		public BUY_STORE()
		{}
		#region Model
		private int _storeid;
		private string _storecode;
		private int? _status=1;
		private string _storename1;
		private string _storename2;
		private string _storename3;
		private int? _storetypeid;
		private string _bankcode;
        private string _storeBrandCode;
		private string _storecountry;
		private string _storeprovince;
		private string _storecity;
		private string _storedistrict;
		private string _storeaddressdetail1;
		private string _storeaddressdetail2;
		private string _storeaddressdetail3;
		private string _storefulldetail1;
		private string _storefulldetail2;
		private string _storefulldetail3;
		private string _storetel;
		private string _storefax;
		private string _storeemail;
		private string _contact;
		private string _contactphone;
		private string _storelongitude;
		private string _storelatitude;
		private string _storepicfile;
		private string _mapspicfile;
		private string _mapspicshadowfile;
		private int? _locationcode;
		private string _storenote;
		private string _storeopentime;
		private string _storeclosetime;
		private int? _comparable=0;
		private string _glcode;
		private string _regioncode;
		private string _orgcode;
		private string _storeip;
		private string _subinvcode;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 表主键
		/// </summary>
		public int StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		///11 店铺编码
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		///11 店铺状态。0：关闭。1：开放
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		///11 店铺名称1
		/// </summary>
		public string StoreName1
		{
			set{ _storename1=value;}
			get{return _storename1;}
		}
		/// <summary>
		///11 店铺名称2
		/// </summary>
		public string StoreName2
		{
			set{ _storename2=value;}
			get{return _storename2;}
		}
		/// <summary>
		///11 店铺名称3
		/// </summary>
		public string StoreName3
		{
			set{ _storename3=value;}
			get{return _storename3;}
		}
		/// <summary>
		///11 店铺类型ID：
        ///0: Company 公司非实体
        ///1: Retail
		///2: Road show
		///3: CC
		///4: CC support
		///5: RAN
		///6: Commercial BU
		///9: Warehouse
		/// </summary>
		public int? StoreTypeID
		{
			set{ _storetypeid=value;}
			get{return _storetypeid;}
		}
		/// <summary>
		///11 银行code
		/// </summary>
		public string BankCode
		{
			set{ _bankcode=value;}
			get{return _bankcode;}
		}
		/// <summary>
		///11 店铺品牌code
		/// </summary>
        public string StoreBrandCode
        {
            get { return _storeBrandCode; }
            set { _storeBrandCode = value; }
        }
		/// <summary>
		///11 店铺所在国家（存放Country表Code）
		/// </summary>
		public string StoreCountry
		{
			set{ _storecountry=value;}
			get{return _storecountry;}
		}
		/// <summary>
		///11 店铺所在省 （存放Province表Code）
		/// </summary>
		public string StoreProvince
		{
			set{ _storeprovince=value;}
			get{return _storeprovince;}
		}
		/// <summary>
		///11 店铺所在城市 （存放City表Code）
		/// </summary>
		public string StoreCity
		{
			set{ _storecity=value;}
			get{return _storecity;}
		}
		/// <summary>
		///11 店铺地址所在区县 （存放District表Code）
		/// </summary>
		public string StoreDistrict
		{
			set{ _storedistrict=value;}
			get{return _storedistrict;}
		}
		/// <summary>
		///11 店铺详细地址
		/// </summary>
		public string StoreAddressDetail1
		{
			set{ _storeaddressdetail1=value;}
			get{return _storeaddressdetail1;}
		}
		/// <summary>
		///11 店铺详细地址（第二种语言）
		/// </summary>
		public string StoreAddressDetail2
		{
			set{ _storeaddressdetail2=value;}
			get{return _storeaddressdetail2;}
		}
		/// <summary>
		///11 店铺详细地址（第三种语言）
		/// </summary>
		public string StoreAddressDetail3
		{
			set{ _storeaddressdetail3=value;}
			get{return _storeaddressdetail3;}
		}
		/// <summary>
		///11 店铺完整地址
		/// </summary>
		public string StoreFullDetail1
		{
			set{ _storefulldetail1=value;}
			get{return _storefulldetail1;}
		}
		/// <summary>
		///11 店铺完整地址（第二种语言）
		/// </summary>
		public string StoreFullDetail2
		{
			set{ _storefulldetail2=value;}
			get{return _storefulldetail2;}
		}
		/// <summary>
		///11 店铺完整地址（第三种语言）
		/// </summary>
		public string StoreFullDetail3
		{
			set{ _storefulldetail3=value;}
			get{return _storefulldetail3;}
		}
		/// <summary>
		///11 店铺电话
		/// </summary>
		public string StoreTel
		{
			set{ _storetel=value;}
			get{return _storetel;}
		}
		/// <summary>
		///11 店铺传真
		/// </summary>
		public string StoreFax
		{
			set{ _storefax=value;}
			get{return _storefax;}
		}
		/// <summary>
		///11 店铺邮箱
		/// </summary>
		public string StoreEmail
		{
			set{ _storeemail=value;}
			get{return _storeemail;}
		}
		/// <summary>
		///11 店铺联系人
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		///11 店铺联系电话
		/// </summary>
		public string ContactPhone
		{
			set{ _contactphone=value;}
			get{return _contactphone;}
		}
		/// <summary>
		///11 店铺坐标，经度
		/// </summary>
		public string StoreLongitude
		{
			set{ _storelongitude=value;}
			get{return _storelongitude;}
		}
		/// <summary>
		///11 店铺坐标，纬度
		/// </summary>
		public string StoreLatitude
		{
			set{ _storelatitude=value;}
			get{return _storelatitude;}
		}
		/// <summary>
		///11 店铺图片地址
		/// </summary>
		public string StorePicFile
		{
			set{ _storepicfile=value;}
			get{return _storepicfile;}
		}
		/// <summary>
		///11 店铺图标文件
		/// </summary>
		public string MapsPicFile
		{
			set{ _mapspicfile=value;}
			get{return _mapspicfile;}
		}
		/// <summary>
		///11 阴影图片文件
		/// </summary>
		public string MapsPicShadowFile
		{
			set{ _mapspicshadowfile=value;}
			get{return _mapspicshadowfile;}
		}
		/// <summary>
		///11 区域Code，外键。一个店铺 只能属于一个 区域。（  最下层的那个区域）
		/// </summary>
		public int? LocationCode
		{
			set{ _locationcode=value;}
			get{return _locationcode;}
		}
		/// <summary>
		///11 店铺备注
		/// </summary>
		public string StoreNote
		{
			set{ _storenote=value;}
			get{return _storenote;}
		}
		/// <summary>
		///11 开店时间，例如 09:00
		/// </summary>
		public string StoreOpenTime
		{
			set{ _storeopentime=value;}
			get{return _storeopentime;}
		}
		/// <summary>
		///11 关店时间，例如 20:00
		/// </summary>
		public string StoreCloseTime
		{
			set{ _storeclosetime=value;}
			get{return _storeclosetime;}
		}
		/// <summary>
		///11 是否是基准店铺. 0：不是。1：是
		/// </summary>
		public int? Comparable
		{
			set{ _comparable=value;}
			get{return _comparable;}
		}
		/// <summary>
		///11 总账代码
		/// </summary>
		public string GLCode
		{
			set{ _glcode=value;}
			get{return _glcode;}
		}
		/// <summary>
		///11 区域代码
		/// </summary>
		public string RegionCode
		{
			set{ _regioncode=value;}
			get{return _regioncode;}
		}
		/// <summary>
		///11 机构代码
		/// </summary>
		public string OrgCode
		{
			set{ _orgcode=value;}
			get{return _orgcode;}
		}
		/// <summary>
		///11 店铺连接IP
		/// </summary>
		public string StoreIP
		{
			set{ _storeip=value;}
			get{return _storeip;}
		}
		/// <summary>
		///11 子库存代码
		/// </summary>
		public string SubInvCode
		{
			set{ _subinvcode=value;}
			get{return _subinvcode;}
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

