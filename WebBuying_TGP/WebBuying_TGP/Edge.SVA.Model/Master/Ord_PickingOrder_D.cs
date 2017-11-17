using System;
namespace Edge.SVA.Model
{
	/// <summary>
    /// 捡货单明细。
	/// </summary>
	[Serializable]
	public partial class Ord_PickingOrder_D
	{
		public Ord_PickingOrder_D()
		{}
		#region Model
		private int _keyid;
		private string _pickingordernumber;
		private string _prodcode;
		private int? _orderqty;
        private int? _actualqty;
        private string _remark;
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
		public string PickingOrderNumber
		{
			set{ _pickingordernumber=value;}
			get{return _pickingordernumber;}
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
        /// <summary>
        /// 实际数量
        /// </summary>
        public int? ActualQty
        {
            set { _actualqty = value; }
            get { return _actualqty; }
        }
        /// <summary>
        /// 备注 PCCW 有导入
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
		#endregion Model

	}
}

