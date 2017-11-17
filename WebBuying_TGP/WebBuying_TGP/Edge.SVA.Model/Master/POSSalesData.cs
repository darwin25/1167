using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡消费赚积分规则表
	/// </summary>
	[Serializable]
	public partial class POSSalesData
	{
		public POSSalesData()
		{}
		#region Model
		private string _sn;
		private string _txnno;
		private string _txntype;
		private decimal? _txnamount;
		private DateTime? _busdate;
		private DateTime? _txndate;
		private DateTime? _importdate= DateTime.Now;
		private string _originaltxnno;
		private string _cardid;
		private string _storeid;
		private string _serverid;
		private string _posid;
		private string _svacardnum;
		private string _cardtype;
		/// <summary>
		/// 
		/// </summary>
		public string SN
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TxnNo
		{
			set{ _txnno=value;}
			get{return _txnno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TxnType
		{
			set{ _txntype=value;}
			get{return _txntype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TxnAmount
		{
			set{ _txnamount=value;}
			get{return _txnamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BusDate
		{
			set{ _busdate=value;}
			get{return _busdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TxnDate
		{
			set{ _txndate=value;}
			get{return _txndate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ImportDate
		{
			set{ _importdate=value;}
			get{return _importdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OriginalTxnNo
		{
			set{ _originaltxnno=value;}
			get{return _originaltxnno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardID
		{
			set{ _cardid=value;}
			get{return _cardid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreId
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ServerId
		{
			set{ _serverid=value;}
			get{return _serverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PosId
		{
			set{ _posid=value;}
			get{return _posid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SVACardNum
		{
			set{ _svacardnum=value;}
			get{return _svacardnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardType
		{
			set{ _cardtype=value;}
			get{return _cardtype;}
		}
		#endregion Model

	}
}

