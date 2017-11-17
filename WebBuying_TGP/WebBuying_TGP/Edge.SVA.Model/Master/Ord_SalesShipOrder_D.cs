using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 发货单明细表（面向订单的）。 @2016-05-20
	///（Ord_SalesPickOrder_H 批核后，产生发货单）
    ///创建人：Lisa
	/// </summary>
	[Serializable]
	public partial class Ord_SalesShipOrder_D
	{
		public Ord_SalesShipOrder_D()
		{}
		#region Model
		private int _keyid;
		private string _salesshipordernumber;
		private string _prodcode;
		private int? _orderqty=0;
		private string _remark;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 订单编号，主键
		/// </summary>
		public string SalesShipOrderNumber
		{
			set{ _salesshipordernumber=value;}
			get{return _salesshipordernumber;}
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

