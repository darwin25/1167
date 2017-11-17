using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺补货设置。从表
    /// 创建人：lisa
    /// 创建时间：2016-07-13
	/// </summary>
	[Serializable]
	public partial class BUY_REPLEN_D
	{
		public BUY_REPLEN_D()
		{}
		#region Model
		private int _keyid;
		private string _replencode;
		private int _entitytype=0;
		private string _entitycode;
		private int? _minstockqty;
		private int? _runningstockqty;
		private int _orderroundupqty=1;
		/// <summary>
		/// 店铺ID
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 主表编码
		/// </summary>
		public string ReplenCode
		{
			set{ _replencode=value;}
			get{return _replencode;}
		}
		/// <summary>
		/// 决定EntityCode中内容的含义。默认0。如果是0，则只需一条记录即可。0：所有货品。EntityNum中为空1：EntityCode内容为 prodcode。 2：EntityCode内容为 DepartCode。
		/// </summary>
		public int EntityType
		{
			set{ _entitytype=value;}
			get{return _entitytype;}
		}
		/// <summary>
		/// 号码
		/// </summary>
		public string EntityCode
		{
			set{ _entitycode=value;}
			get{return _entitycode;}
		}
		/// <summary>
		/// 最小允许库存。（低于此将可能触发自动补货）
		/// </summary>
		public int? MinStockQty
		{
			set{ _minstockqty=value;}
			get{return _minstockqty;}
		}
		/// <summary>
		/// 正常库存数量。（补货数量为： 正常库存数量 - 当前库存数量）注：如果有补货的倍数要求，按照倍数要求计算。比如： 正常库存数量 - 当前库存数量 = 53.   供应商要求按50倍数订货，所以需要订货数量为 100
		/// </summary>
		public int? RunningStockQty
		{
			set{ _runningstockqty=value;}
			get{return _runningstockqty;}
		}
		/// <summary>
		/// 订货数量的倍数（包装数量）：Sample:max=300 current=97max-current=203 203 will be rounded up to 250 since it is the next number divisible by 50.

		/// </summary>
		public int OrderRoundUpQty
		{
			set{ _orderroundupqty=value;}
			get{return _orderroundupqty;}
		}
		#endregion Model

	}
}

