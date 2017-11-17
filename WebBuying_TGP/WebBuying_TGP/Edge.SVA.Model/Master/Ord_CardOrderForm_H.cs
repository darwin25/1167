using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡订货单
	/// </summary>
	[Serializable]
	public partial class Ord_CardOrderForm_H
	{
		public Ord_CardOrderForm_H()
		{}
		#region Model
		private string _cardorderformnumber;
		private int? _storeid;
		private int? _customertype;
		private int? _customerid;
		private int? _sendmethod;
		private string _sendaddress;
		private string _contactname;
		private string _contactnumber;
		private string _email;
		private string _smsmms;
		private string _remark;
		private DateTime? _createdbusdate;
		private DateTime? _approvebusdate;
		private string _approvalcode;
		private string _approvestatus;
		private DateTime? _approveon;
		private int? _approveby;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 订单编号，主键
		/// </summary>
		public string CardOrderFormNumber
		{
			set{ _cardorderformnumber=value;}
			get{return _cardorderformnumber;}
		}
		/// <summary>
		/// 店铺主键
		/// </summary>
		public int? StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 客户类型。1：客戶訂貨。 2：店鋪訂貨
		/// </summary>
		public int? CustomerType
		{
			set{ _customertype=value;}
			get{return _customertype;}
		}
		/// <summary>
		/// customer表 主键， 外键
		/// </summary>
		public int? CustomerID
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 送货方式。1：直接交付（打印），2：SMS，3：Email，4：Social Network
		/// </summary>
		public int? SendMethod
		{
			set{ _sendmethod=value;}
			get{return _sendmethod;}
		}
		/// <summary>
		/// 送货地址
		/// </summary>
		public string SendAddress
		{
			set{ _sendaddress=value;}
			get{return _sendaddress;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string ContactName
		{
			set{ _contactname=value;}
			get{return _contactname;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string ContactNumber
		{
			set{ _contactnumber=value;}
			get{return _contactnumber;}
		}
		/// <summary>
		/// 送货邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 手机消息传递
		/// </summary>
		public string SMSMMS
		{
			set{ _smsmms=value;}
			get{return _smsmms;}
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
		/// 单据创建时的busdate
		/// </summary>
		public DateTime? CreatedBusDate
		{
			set{ _createdbusdate=value;}
			get{return _createdbusdate;}
		}
		/// <summary>
		/// 单据批核时的busdate
		/// </summary>
		public DateTime? ApproveBusDate
		{
			set{ _approvebusdate=value;}
			get{return _approvebusdate;}
		}
		/// <summary>
		/// 批核时产生授权号，并通知前台
		/// </summary>
		public string ApprovalCode
		{
			set{ _approvalcode=value;}
			get{return _approvalcode;}
		}
		/// <summary>
		/// 单据状态。状态： P：prepare。  A:Approve 。 V：Void
		/// </summary>
		public string ApproveStatus
		{
			set{ _approvestatus=value;}
			get{return _approvestatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ApproveOn
		{
			set{ _approveon=value;}
			get{return _approveon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApproveBy
		{
			set{ _approveby=value;}
			get{return _approveby;}
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

