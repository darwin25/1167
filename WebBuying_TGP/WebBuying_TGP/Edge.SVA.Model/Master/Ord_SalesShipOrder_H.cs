using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 发货单（面向订单的）。 @2016-05-20
	///（Ord_SalesPickOrder_H 批核后，产生发货单）
    ///创建人：Lisa
	/// </summary>
	[Serializable]
	public partial class Ord_SalesShipOrder_H
	{
		public Ord_SalesShipOrder_H()
		{}
		#region Model
		private string _salesshipordernumber;
		private int? _ordertype=0;
		private string _memberid;
		private string _cardnumber;
		private string _referenceno;
		private string _txnno;
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
		private int? _status=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 订单编号，主键
		/// </summary>
		public string SalesShipOrderNumber
		{
			set{ _salesshipordernumber=value;}
			get{return _salesshipordernumber;}
		}
		/// <summary>
		/// 订单类型。  1：需要第三方中转（比如送到门店，顾客门店自提） 2：直接产生送货单，交付快递就算完成。
		/// </summary>
		public int? OrderType
		{
			set{ _ordertype=value;}
			get{return _ordertype;}
		}
		/// <summary>
		/// 会员号码。 
		/// </summary>
		public string MemberID
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 会员卡号码。 
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
		}
		/// <summary>
		/// 参考编号。（SalesPickOrderNumber 号码）
		/// </summary>
		public string ReferenceNo
		{
			set{ _referenceno=value;}
			get{return _referenceno;}
		}
		/// <summary>
		/// 交易单号
		/// </summary>
		public string TxnNo
		{
			set{ _txnno=value;}
			get{return _txnno;}
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
		/// 状态： 0：创建。 1：发货。 2：中转签收（门店）3：顾客签收（完成）4：未发送作废。5：退回 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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

