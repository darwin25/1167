using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 结算表子表
	/// </summary>
	[Serializable]
	public partial class BUY_SETTLEMENT_D
	{
		public BUY_SETTLEMENT_D()
		{}
		#region Model
		private int _keyid;
		private string _settlementcode;
		private string _transnum;
		private int _seqnum=1;
		private string _storecode;
		private decimal? _amount;
		private decimal? _netamount;
		private string _cardno;
		private string _cardtype;
		private string _approvalcode;
		private string _bankcode;
		private int _status=0;
		private DateTime? _settledate;
		private string _settleby;
		private int? _installment=0;
		/// <summary>
		///11 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		///11 单号
		/// </summary>
		public string SettlementCode
		{
			set{ _settlementcode=value;}
			get{return _settlementcode;}
		}
		/// <summary>
		///11 交易单号
		/// </summary>
		public string TransNum
		{
			set{ _transnum=value;}
			get{return _transnum;}
		}
		/// <summary>
		///11 salesT的序号
		/// </summary>
		public int SeqNum
		{
			set{ _seqnum=value;}
			get{return _seqnum;}
		}
		/// <summary>
		///11 交易单的storecode
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		///11 salesT的本币金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		///11 salesT的本币金额 * （1-buy_bank.commission）
		/// </summary>
		public decimal? NetAmount
		{
			set{ _netamount=value;}
			get{return _netamount;}
		}
		/// <summary>
		///11 信用卡卡号
		/// </summary>
		public string CardNo
		{
			set{ _cardno=value;}
			get{return _cardno;}
		}
		/// <summary>
		///11 信用卡类型
		/// </summary>
		public string CardType
		{
			set{ _cardtype=value;}
			get{return _cardtype;}
		}
		/// <summary>
		///11 信用卡的approvalcode
		/// </summary>
		public string ApprovalCode
		{
			set{ _approvalcode=value;}
			get{return _approvalcode;}
		}
		/// <summary>
		///11 银行代码
		/// </summary>
		public string BankCode
		{
			set{ _bankcode=value;}
			get{return _bankcode;}
		}
		/// <summary>
		///11 状态。
		///0: Outstanding 
		///1: Settled
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		///11 结算日期
		/// </summary>
		public DateTime? SettleDate
		{
			set{ _settledate=value;}
			get{return _settledate;}
		}
		/// <summary>
		///11 计算人
		/// </summary>
		public string SettleBy
		{
			set{ _settleby=value;}
			get{return _settleby;}
		}
		/// <summary>
		///11 是否分期。0：不是。1：是的
		/// </summary>
		public int? Installment
		{
			set{ _installment=value;}
			get{return _installment;}
		}
		#endregion Model

	}
}

