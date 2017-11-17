using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// PO单明细表
	/// </summary>
	[Serializable]
	public partial class BUY_PO_D
	{
		public BUY_PO_D()
		{}
		#region Model
		private int _keyid;
		private string _pocode;
		private string _prodcode;
		private decimal _cost;
		private decimal? _averagecost;
		private decimal? _unitcost;
		private decimal _qty;
		private decimal _freeqty;
		private decimal? _grnqty;
		/// <summary>
		///11 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		///11 订单编号
		/// </summary>
		public string POCode
		{
			set{ _pocode=value;}
			get{return _pocode;}
		}
		/// <summary>
		///11 货品编码
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		///11 订单中此货品总成本 （Unit_Cost*Qty*(100-discount)/100）
		/// </summary>
		public decimal Cost
		{
			set{ _cost=value;}
			get{return _cost;}
		}
		/// <summary>
		///11 此货品平均成本 （Unit_Cost*Qty/(Qty+Get) *(100-discount)/100）
		/// </summary>
		public decimal? AverageCost
		{
			set{ _averagecost=value;}
			get{return _averagecost;}
		}
		/// <summary>
		///11 单位成本
		/// </summary>
		public decimal? UnitCost
		{
			set{ _unitcost=value;}
			get{return _unitcost;}
		}
		/// <summary>
		///11 订单货品数量
		/// </summary>
		public decimal Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		///11 免费货品数量
		/// </summary>
		public decimal FreeQty
		{
			set{ _freeqty=value;}
			get{return _freeqty;}
		}
		/// <summary>
		///11 收到货品数量
		/// </summary>
		public decimal? GRNQty
		{
			set{ _grnqty=value;}
			get{return _grnqty;}
		}
		#endregion Model

	}
}

