using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡调整子表
	/// </summary>
	[Serializable]
	public partial class Ord_CardAdjust_D
	{
		public Ord_CardAdjust_D()
		{}
		#region Model
		private int _keyid;
		private string _cardadjustnumber;
		private string _cardnumber;
		private decimal? _orderamount;
		private decimal? _actamount;
		private int? _orderpoints;
		private int? _actpoints;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 主表ID
		/// </summary>
		public string CardAdjustNumber
		{
			set{ _cardadjustnumber=value;}
			get{return _cardadjustnumber;}
		}
		/// <summary>
		/// 卡号
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
		}
		/// <summary>
		/// 请求操作金额
		/// </summary>
		public decimal? OrderAmount
		{
			set{ _orderamount=value;}
			get{return _orderamount;}
		}
		/// <summary>
		/// 实际操作金额
		/// </summary>
		public decimal? ActAmount
		{
			set{ _actamount=value;}
			get{return _actamount;}
		}
		/// <summary>
		/// 请求操作积分
		/// </summary>
		public int? OrderPoints
		{
			set{ _orderpoints=value;}
			get{return _orderpoints;}
		}
		/// <summary>
		/// 实际操作积分
		/// </summary>
		public int? ActPoints
		{
			set{ _actpoints=value;}
			get{return _actpoints;}
		}
		#endregion Model

	}
}

