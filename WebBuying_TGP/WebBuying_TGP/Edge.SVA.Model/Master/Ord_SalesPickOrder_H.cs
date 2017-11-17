using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 拣货订单。
	///@2016-05-19. 面向订单的拣货单。 一个订单可能拆分成多个拣货单。
	///创建人：Lisa
	/// </summary>
	[Serializable]
	public partial class Ord_SalesPickOrder_H
	{
		public Ord_SalesPickOrder_H()
		{}
		#region Model
		private string _salespickordernumber;
		private int? _ordertype=0;
		private string _memberid;
		private string _cardnumber;
		private string _referenceno;
		private string _pickuplocation;
		private string _pickupstaff;
		private DateTime? _pickupdate;
		private int? _deliveryflag=0;
		private string _deliverycountry;
		private string _deliveryprovince;
		private string _deliverycity;
		private string _deliverydistrict;
		private string _deliveryaddressdetail;
		private string _deliveryfulladdress;
		private string _deliverynumber;
		private int? _logisticsproviderid;
		private string _contact;
		private string _contactphone;
		private DateTime? _requestdeliverydate;
		private DateTime? _deliverydate;
		private int? _deliveryby;
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
		public string SalesPickOrderNumber
		{
			set{ _salespickordernumber=value;}
			get{return _salespickordernumber;}
		}
		/// <summary>
		/// 订单类型。 1：直接产生快递单，拣货单完成。 2：需要第三方中转（比如门店）
		/// </summary>
		public int? OrderType
		{
			set{ _ordertype=value;}
			get{return _ordertype;}
		}
		/// <summary>
		/// 会员号码。 MemberSalesFlag = 1时需要填
		/// </summary>
		public string MemberID
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 会员卡号码。 MemberSalesFlag = 1时需要填
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
		}
		/// <summary>
		/// 销售单号
		/// </summary>
		public string ReferenceNo
		{
			set{ _referenceno=value;}
			get{return _referenceno;}
		}
		/// <summary>
		/// 拣货仓库（店铺）
		/// </summary>
		public string PickupLocation
		{
			set{ _pickuplocation=value;}
			get{return _pickuplocation;}
		}
		/// <summary>
		/// 拣货人
		/// </summary>
		public string PickupStaff
		{
			set{ _pickupstaff=value;}
			get{return _pickupstaff;}
		}
		/// <summary>
		/// 拣货日期 （business date）
		/// </summary>
		public DateTime? PickupDate
		{
			set{ _pickupdate=value;}
			get{return _pickupdate;}
		}
		/// <summary>
		/// 送货标志。0： 自提，不送货。 1：送货
		/// </summary>
		public int? DeliveryFlag
		{
			set{ _deliveryflag=value;}
			get{return _deliveryflag;}
		}
		/// <summary>
		/// 送货所在国家（存放Country表Code）
		/// </summary>
		public string DeliveryCountry
		{
			set{ _deliverycountry=value;}
			get{return _deliverycountry;}
		}
		/// <summary>
		/// 送货所在省 （存放Province表Code）
		/// </summary>
		public string DeliveryProvince
		{
			set{ _deliveryprovince=value;}
			get{return _deliveryprovince;}
		}
		/// <summary>
		/// 送货所在城市 （存放City表Code）
		/// </summary>
		public string DeliveryCity
		{
			set{ _deliverycity=value;}
			get{return _deliverycity;}
		}
		/// <summary>
		/// 送货地址所在区县 （存放District表Code）
		/// </summary>
		public string DeliveryDistrict
		{
			set{ _deliverydistrict=value;}
			get{return _deliverydistrict;}
		}
		/// <summary>
		/// 送货详细地址
		/// </summary>
		public string DeliveryAddressDetail
		{
			set{ _deliveryaddressdetail=value;}
			get{return _deliveryaddressdetail;}
		}
		/// <summary>
		/// 送货完整地址
		/// </summary>
		public string DeliveryFullAddress
		{
			set{ _deliveryfulladdress=value;}
			get{return _deliveryfulladdress;}
		}
		/// <summary>
		/// 送货单号码
		/// </summary>
		public string DeliveryNumber
		{
			set{ _deliverynumber=value;}
			get{return _deliverynumber;}
		}
		/// <summary>
		/// 物流供应商ID
		/// </summary>
		public int? LogisticsProviderID
		{
			set{ _logisticsproviderid=value;}
			get{return _logisticsproviderid;}
		}
		/// <summary>
		/// 收货联系人
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 联系人电话
		/// </summary>
		public string ContactPhone
		{
			set{ _contactphone=value;}
			get{return _contactphone;}
		}
		/// <summary>
		/// 要求送货日期  （system date）
		/// </summary>
		public DateTime? RequestDeliveryDate
		{
			set{ _requestdeliverydate=value;}
			get{return _requestdeliverydate;}
		}
		/// <summary>
		/// 货物送达日期   （system date）
		/// </summary>
		public DateTime? DeliveryDate
		{
			set{ _deliverydate=value;}
			get{return _deliverydate;}
		}
		/// <summary>
		/// 送货人ID
		/// </summary>
		public int? DeliveryBy
		{
			set{ _deliveryby=value;}
			get{return _deliveryby;}
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
		/// 单据状态。状态： P：prepare。  A:Approve 。 V：Void。
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

