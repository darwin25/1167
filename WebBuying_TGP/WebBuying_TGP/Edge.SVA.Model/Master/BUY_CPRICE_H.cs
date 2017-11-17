using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 成本价头表
	/// </summary>
	[Serializable]
	public partial class BUY_CPRICE_H
	{
		public BUY_CPRICE_H()
		{}
		#region Model
		private string _cpricecode;
		private string _storecode;
		private string _storegroupcode;
		private string _vendorcode;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private string _currencycode;
		private string _note;
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
		///11 主键编码
		/// </summary>
		public string CPriceCode
		{
			set{ _cpricecode=value;}
			get{return _cpricecode;}
		}
		/// <summary>
		///11 店铺Code。空/NULL： 表示所有。
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		///11 这组价格针对的店铺组ID。空/NULL： 表示所有
		/// </summary>
		public string StoreGroupCode
		{
			set{ _storegroupcode=value;}
			get{return _storegroupcode;}
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
		///11 价格生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		///11 价格失效日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		///11 货币编码。一般应该是本币代码
		/// </summary>
		public string CurrencyCode
		{
			set{ _currencycode=value;}
			get{return _currencycode;}
		}
		/// <summary>
		///11 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
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

