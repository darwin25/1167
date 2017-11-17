using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺补货设置。主表
    /// 创建人：lisa
    /// 创建时间：2016-07-13
	/// </summary>
	[Serializable]
	public partial class BUY_REPLEN_H
	{
		public BUY_REPLEN_H()
		{}
		#region Model
		private string _replencode;
		private int? _usereplenformula=0;
        private int? _replenFormulaID = 0;
		private int _storeid;
		private int _targettype=1;
		private int _ordertargetid;
		private DateTime? _startdate= DateTime.Now;
		private DateTime? _enddate= DateTime.Now;
		private int? _status=1;
		private int? _priority;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 编码
		/// </summary>
		public string ReplenCode
		{
			set{ _replencode=value;}
			get{return _replencode;}
		}
		/// <summary>
		/// 是否使用补货公式。0：不使用（此时如果需要补货，使用BUY_REPLEN_D的数量设置）。1：使用（补货数量使用BUY_REPLENFORMULA的设置来计算）。 默认0.
		/// </summary>
		public int? UseReplenFormula
		{
			set{ _usereplenformula=value;}
			get{return _usereplenformula;}
		}
        public int? ReplenFormulaID
        {
            get { return _replenFormulaID; }
            set { _replenFormulaID = value; }
        }
		/// <summary>
		/// 店铺ID
		/// </summary>
		public int StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 订货目标类型。 0：供应商。 1：总部。 默认1
		/// </summary>
		public int TargetType
		{
			set{ _targettype=value;}
			get{return _targettype;}
		}
		/// <summary>
		/// 订货目标ID。（如果是店铺订货，则填写总部的ID。 如果总部订货，则填写供应商ID）
		/// </summary>
		public int OrderTargetID
		{
			set{ _ordertargetid=value;}
			get{return _ordertargetid;}
		}
		/// <summary>
		/// 生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 失效日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 状态。0：无效，1：有效。
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 优先级。 （库存不足情况下。按 从小到大 优先分配。）
		/// </summary>
		public int? Priority
		{
			set{ _priority=value;}
			get{return _priority;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

