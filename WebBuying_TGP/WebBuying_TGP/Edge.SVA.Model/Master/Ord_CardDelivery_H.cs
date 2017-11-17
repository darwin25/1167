using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡送货单主表。
	///（从批核后的拣货单复制过来，过滤了拣货数量为0的记录。 头表状态略有不同）
	/// </summary>
	[Serializable]
	public partial class Ord_CardDelivery_H
	{
		public Ord_CardDelivery_H()
		{}
		#region Model
		private string _carddeliverynumber;
		private string _referenceno;
		private int? _storeid;
		private int? _customerid;
		private int? _needactive=0;
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
		/// 送货单单号，主键
		/// </summary>
		public string CardDeliveryNumber
		{
			set{ _carddeliverynumber=value;}
			get{return _carddeliverynumber;}
		}
		/// <summary>
		/// 参考编号。指拣货单号
		/// </summary>
		public string ReferenceNo
		{
			set{ _referenceno=value;}
			get{return _referenceno;}
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
		/// customer表 主键， 外键
		/// </summary>
		public int? CustomerID
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 客户收货确认后是否激活。0：不激活。1：激活。默认0
		/// </summary>
		public int? NeedActive
		{
			set{ _needactive=value;}
			get{return _needactive;}
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
		/// 单据状态。状态： P：prepare（送货中）。  A:Approve（送货完成，顾客签收） 。 V：Void（顾客拒收，card回到dormant状态）
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

