using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 黑名单表
	/// </summary>
	[Serializable]
	public partial class BUY_BLACKLIST
	{
		public BUY_BLACKLIST()
		{}
		#region Model
		private int _blackid;
		private string _accountcode;
		private string _customername;
		private string _customercode;
		private string _extgserviceno;
		private string _deliveryaddress;
		private string _customercontact;
		private string _customercontact1;
		private string _creditcardno;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
        private string _nickName;
        private string _mobileNo;
        
		/// <summary>
		///11 
		/// </summary>
		public int BlackID
		{
			set{ _blackid=value;}
			get{return _blackid;}
		}
		/// <summary>
		///11 账号代码
		/// </summary>
		public string AccountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		///11 客户名称
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		///11 客户Code
		/// </summary>
		public string CustomerCode
		{
			set{ _customercode=value;}
			get{return _customercode;}
		}
		/// <summary>
		///11 Extg Service No
		/// </summary>
		public string ExtgServiceNo
		{
			set{ _extgserviceno=value;}
			get{return _extgserviceno;}
		}
		/// <summary>
		///11 送货地址
		/// </summary>
		public string DeliveryAddress
		{
			set{ _deliveryaddress=value;}
			get{return _deliveryaddress;}
		}
		/// <summary>
		///11 联系人
		/// </summary>
		public string CustomerContact
		{
			set{ _customercontact=value;}
			get{return _customercontact;}
		}
		/// <summary>
		///11 联系人1
		/// </summary>
		public string CustomerContact1
		{
			set{ _customercontact1=value;}
			get{return _customercontact1;}
		}
		/// <summary>
		///11 信用卡号
		/// </summary>
		public string CreditCardNo
		{
			set{ _creditcardno=value;}
			get{return _creditcardno;}
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
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; }
        }
		#endregion Model

	}
}

