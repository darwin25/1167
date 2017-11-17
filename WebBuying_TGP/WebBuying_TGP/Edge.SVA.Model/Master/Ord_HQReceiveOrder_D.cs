using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺收货单明细。
	/// </summary>
	[Serializable]
	public partial class Ord_HQReceiveOrder_D
	{
		public Ord_HQReceiveOrder_D()
		{}
		#region Model
		private int _keyid;
		private string _hqreceiveordernumber;
		private string _prodcode;
		private int? _orderqty;
        private int? _receiveqty;
        private string _stocktypecode;
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
		public string HQReceiveOrderNumber
		{
            set { _hqreceiveordernumber = value; }
            get { return _hqreceiveordernumber; }
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
		}/// <summary>
        /// 收货数量
        /// </summary>
        public int? ReceiveQty
        {
            set { _receiveqty = value; }
            get { return _receiveqty; }
        }
        /// <summary>
        /// 库存类型
        /// </summary>
        public string StockTypeCode
        {
            set { _stocktypecode = value; }
            get { return _stocktypecode; }
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

