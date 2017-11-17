using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// PO单主表
	/// </summary>
	[Serializable]
	public partial class BUY_PO_H
	{
		public BUY_PO_H()
		{}
		#region Model
		private string _pocode;
		private int _ordertype;
		private int _vendorid;
		private int _storeid;
		private string _currencycode;
		private string _note1;
		private string _note2;
		private string _note3;
		private DateTime? _expectdate;
		private decimal _totalamount;
		private decimal _vatamount;
		private decimal _discountamount;
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
		///11 订单编号
		/// </summary>
		public string POCode
		{
			set{ _pocode=value;}
			get{return _pocode;}
		}
		/// <summary>
		///11 订单类型： 1:WH order 3:Store Order
		/// </summary>
		public int OrderType
		{
			set{ _ordertype=value;}
			get{return _ordertype;}
		}
		/// <summary>
		///11 供应商编码
		/// </summary>
		public int VendorID
		{
			set{ _vendorid=value;}
			get{return _vendorid;}
		}
		/// <summary>
		///11 店铺编码
		/// </summary>
		public int StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		///11 货币编码
		/// </summary>
		public string CurrencyCode
		{
			set{ _currencycode=value;}
			get{return _currencycode;}
		}
		/// <summary>
		///11 备注1
		/// </summary>
		public string Note1
		{
			set{ _note1=value;}
			get{return _note1;}
		}
		/// <summary>
		///11 备注2
		/// </summary>
		public string Note2
		{
			set{ _note2=value;}
			get{return _note2;}
		}
		/// <summary>
		///11 备注3
		/// </summary>
		public string Note3
		{
			set{ _note3=value;}
			get{return _note3;}
		}
		/// <summary>
		///11 预期装货日期
		/// </summary>
		public DateTime? ExpectDate
		{
			set{ _expectdate=value;}
			get{return _expectdate;}
		}
		/// <summary>
		///11 订单总金额
		/// </summary>
		public decimal TotalAmount
		{
			set{ _totalamount=value;}
			get{return _totalamount;}
		}
		/// <summary>
		///11 订单增值税总额
		/// </summary>
		public decimal VATAmount
		{
			set{ _vatamount=value;}
			get{return _vatamount;}
		}
		/// <summary>
		///11 订单折扣总额
		/// </summary>
		public decimal DiscountAmount
		{
			set{ _discountamount=value;}
			get{return _discountamount;}
		}
		/// <summary>
		///11 单据创建时的busdate
		/// </summary>
		public DateTime? CreatedBusDate
		{
			set{ _createdbusdate=value;}
			get{return _createdbusdate;}
		}
		/// <summary>
		///11 单据批核时的busdate
		/// </summary>
		public DateTime? ApproveBusDate
		{
			set{ _approvebusdate=value;}
			get{return _approvebusdate;}
		}
		/// <summary>
		///11 批核时产生授权号，并通知前台
		/// </summary>
		public string ApprovalCode
		{
			set{ _approvalcode=value;}
			get{return _approvalcode;}
		}
		/// <summary>
		///11 单据状态。状态： P：Pending。  A:Approve 。 V：Void
		/// </summary>
		public string ApproveStatus
		{
			set{ _approvestatus=value;}
			get{return _approvestatus;}
		}
		/// <summary>
		///11 批核时间
		/// </summary>
		public DateTime? ApproveOn
		{
			set{ _approveon=value;}
			get{return _approveon;}
		}
		/// <summary>
		///11 批核人
		/// </summary>
		public int? ApproveBy
		{
			set{ _approveby=value;}
			get{return _approveby;}
		}
		/// <summary>
		///11 创建时间
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 创建人
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

