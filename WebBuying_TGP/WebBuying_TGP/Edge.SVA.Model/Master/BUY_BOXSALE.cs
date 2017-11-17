using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 套餐销售设置表
	/// </summary>
	[Serializable]
	public partial class BUY_BOXSALE
	{
		public BUY_BOXSALE()
		{}
		#region Model
		private int _bomid;
		private string _bomcode;
		private string _prodcode;
		private decimal _qty;
		private int _minqty=0;
		private int _maxqty=0;
		private int _defaultqty=0;
		private decimal _price=0M;
		private decimal? _partvalue=0M;
		private int? _valuetype=0;
		private decimal? _actprice=0M;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private int? _mutextag=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键
		/// </summary>
		public int BOMID
		{
			set{ _bomid=value;}
			get{return _bomid;}
		}
		/// <summary>
		/// 主货品编码（一般也是ProdCode）
		/// </summary>
		public string BOMCode
		{
			set{ _bomcode=value;}
			get{return _bomcode;}
		}
		/// <summary>
		/// 子货品编码.（也可以是BOMCode，但不可循环嵌套）
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 子货品数量
		/// </summary>
		public decimal Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 子货品最小数量
		/// </summary>
		public int MinQty
		{
			set{ _minqty=value;}
			get{return _minqty;}
		}
		/// <summary>
		/// 子货品最大数量
		/// </summary>
		public int MaxQty
		{
			set{ _maxqty=value;}
			get{return _maxqty;}
		}
		/// <summary>
		/// 子货品默认数量
		/// </summary>
		public int DefaultQty
		{
			set{ _defaultqty=value;}
			get{return _defaultqty;}
		}
		/// <summary>
		/// 附加价格。（子货品在BOM中一般价格都是0，货品的价格都集中在主货品上。有些子货品是可以更换的，可能会要增加加额外价格）。
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 此子货品占BOM总价格的百分比或者价格
		/// </summary>
		public decimal? PartValue
		{
			set{ _partvalue=value;}
			get{return _partvalue;}
		}
		/// <summary>
		/// 决定ValueType内容是金额还是百分比。0：金额。1：百分比
		/// </summary>
		public int? ValueType
		{
			set{ _valuetype=value;}
			get{return _valuetype;}
		}
		/// <summary>
		/// 计算字段。根据BOM总价，PartValue，ValueType计算
		/// </summary>
		public decimal? ActPrice
		{
			set{ _actprice=value;}
			get{return _actprice;}
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
		/// （取消此字段。暂不删除。） 互斥功能 通过创建BOM来实现。 将需要互斥的货品归入一个BOM中，此BOM货品设置为互斥属性 ）
        //互斥标签。  默认 0 。  0： 无效。此货品没有互斥性。  其他数字，表示有效。
        //同一个BOM中，相同 MutexTag值的 货品之间互斥，只能保留一种。
        //例如：  
        //一个BOM中 设置4 种货品， A，B，C，D，  A和B互斥，C和D互斥。 MutexTag设置为
        //A： 1
        //B： 1
        //C： 2
        //D： 2
		/// </summary>
		public int? MutexTag
		{
			set{ _mutextag=value;}
			get{return _mutextag;}
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

