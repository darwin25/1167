using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 拣货单（面向订单的拣货单）。 子表 @2016-05-20
    ///创建人：Lisa
	/// </summary>
	[Serializable]
	public partial class Ord_SalesPickOrder_D
	{
		public Ord_SalesPickOrder_D()
		{}
		#region Model
		private int _keyid;
		private string _salespickordernumber;
		private string _prodcode;
		private int? _orderqty=0;
		private int? _actualqty=0;
		private string _stocktypecode="G";
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 订单编号，主表主键
		/// </summary>
		public string SalesPickOrderNumber
		{
			set{ _salespickordernumber=value;}
			get{return _salespickordernumber;}
		}
		/// <summary>
		/// 货品编码
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 货品订单数量
		/// </summary>
		public int? OrderQty
		{
			set{ _orderqty=value;}
			get{return _orderqty;}
		}
		/// <summary>
		/// 实际拣货数量
		/// </summary>
		public int? ActualQty
		{
			set{ _actualqty=value;}
			get{return _actualqty;}
		}
		/// <summary>
		/// BUY_STOCKTYPE 表的 StockTypeCode。 （类似prodcode， 特殊意义表，使用code，不使用ID）
		/// </summary>
		public string StockTypeCode
		{
			set{ _stocktypecode=value;}
			get{return _stocktypecode;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

