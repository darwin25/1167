using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺类型表
	/// </summary>
	[Serializable]
	public partial class SVA_ValueAdjust_D
	{
		public SVA_ValueAdjust_D()
		{}
		#region Model
		private string _number;
		private int _seqno;
		private string _uid;
		private string _cardno;
		private string _cardtypeid;
		private string _cardgradid;
		private decimal? _orderamount;
		private decimal? _actamount;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SeqNo
		{
			set{ _seqno=value;}
			get{return _seqno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardNo
		{
			set{ _cardno=value;}
			get{return _cardno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardTypeID
		{
			set{ _cardtypeid=value;}
			get{return _cardtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardGradID
		{
			set{ _cardgradid=value;}
			get{return _cardgradid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OrderAmount
		{
			set{ _orderamount=value;}
			get{return _orderamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ActAmount
		{
			set{ _actamount=value;}
			get{return _actamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

