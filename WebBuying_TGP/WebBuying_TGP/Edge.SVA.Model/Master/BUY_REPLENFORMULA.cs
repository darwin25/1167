using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 自动补货公式信息表
	///（根据销售货品统计每天的销售平均数，此表设置不区分货品，不区分店铺。）
	///@2016-07-13 增加正常运行库存数等字段。
    /// 创建人：lisa
    /// 创建时间：2016-07-13
	/// </summary>
	[Serializable]
	public partial class BUY_REPLENFORMULA
	{
		public BUY_REPLENFORMULA()
		{}
		#region Model
		private int _replenformulaid;
		private string _replenformulacode;
		private string _description;
		private int? _predefinedoc=7;
		private int? _runningstockdoc;
		private int? _orderroundupqty;
		private int? _avgdailysalesperiod=7;
		private int? _quotation=0;
		private int? _deposited=0;
		private int? _advsales=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int ReplenFormulaID
		{
			set{ _replenformulaid=value;}
			get{return _replenformulaid;}
		}
		/// <summary>
		/// 编码
		/// </summary>
		public string ReplenFormulaCode
		{
			set{ _replenformulacode=value;}
			get{return _replenformulacode;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 预留库存天数. (当库存数量<=预留库存天数*平均每天销售数量, 则触发补货)
		/// </summary>
		public int? PreDefineDOC
		{
			set{ _predefinedoc=value;}
			get{return _predefinedoc;}
		}
		/// <summary>
		/// 正常库存天数。（补货数量为： 平均每天销售数量 * (正常库存天数- 预留库存天数）
		/// </summary>
		public int? RunningStockDOC
		{
			set{ _runningstockdoc=value;}
			get{return _runningstockdoc;}
		}
		/// <summary>
		/// 订货数量的倍数：Sample:max=300 current=97max-current=203 203 will be rounded up to 250 since it is the next number divisible by 50.
		/// </summary>
		public int? OrderRoundUpQty
		{
			set{ _orderroundupqty=value;}
			get{return _orderroundupqty;}
		}
		/// <summary>
		/// 计算平均销售数量的周期天数（即计算多少天内交易数的平均数）
		/// </summary>
		public int? AVGDailySalesPeriod
		{
			set{ _avgdailysalesperiod=value;}
			get{return _avgdailysalesperiod;}
		}
		/// <summary>
		/// 数量统计是否包括报价销售类型。0：不是。1：是的
		/// </summary>
		public int? Quotation
		{
			set{ _quotation=value;}
			get{return _quotation;}
		}
		/// <summary>
		/// 数量统计是否包括定金销售类型。0：不是。1：是的
		/// </summary>
		public int? Deposited
		{
			set{ _deposited=value;}
			get{return _deposited;}
		}
		/// <summary>
		/// 数量统计是否包括预售销售类型。0：不是。1：是的
		/// </summary>
		public int? AdvSales
		{
			set{ _advsales=value;}
			get{return _advsales;}
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

