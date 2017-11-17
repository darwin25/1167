using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺货品分配表，主表
	/// </summary>
	[Serializable]
	public partial class BUY_ALLOC_S_H
	{
		public BUY_ALLOC_S_H()
		{}
		#region Model
		private string _alloccode;
		private string _refcode;
		private string _whcode;
		private DateTime _pickdate;
		private string _promotiontitle;
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
		///11 主键。
		/// </summary>
		public string AllocCode
		{
			set{ _alloccode=value;}
			get{return _alloccode;}
		}
		/// <summary>
		///11 关联号码
		/// </summary>
		public string RefCode
		{
			set{ _refcode=value;}
			get{return _refcode;}
		}
		/// <summary>
		///11 仓库编码
		/// </summary>
		public string WHCode
		{
			set{ _whcode=value;}
			get{return _whcode;}
		}
		/// <summary>
		///11 提货日期
		/// </summary>
		public DateTime PickDate
		{
			set{ _pickdate=value;}
			get{return _pickdate;}
		}
		/// <summary>
		///11 
		/// </summary>
		public string PromotionTitle
		{
			set{ _promotiontitle=value;}
			get{return _promotiontitle;}
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
		///11 单据状态。状态： P：Pending。  A:Approve 。 V：Void。 C: complete
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

