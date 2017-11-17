using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡订货单明细。
	///表中brandID，cardtypeid，cardgradeid 关系不做校验，由UI在创建单据时做校验。
	///存储过程实际操作时，只按照CardGradeID来做。
	/// </summary>
	[Serializable]
	public partial class Ord_StoreOrder_D
	{
		public Ord_StoreOrder_D()
		{}
		#region Model
		private int _keyid;
		private string _storeordernumber;
		private string _prodcode;
		private int? _orderqty;
		/// <summary>
		/// 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 订单编号，主键
		/// </summary>
		public string StoreOrderNumber
		{
			set{ _storeordernumber=value;}
			get{return _storeordernumber;}
		}
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProdCode
        {
            set { _prodcode = value; }
            get { return _prodcode; }
        }
		/// <summary>
		/// 订单数量
		/// </summary>
		public int? OrderQty
		{
			set{ _orderqty=value;}
			get{return _orderqty;}
		}
		#endregion Model

	}
}

