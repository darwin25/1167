using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 交易的结算信息表，主表
	/// </summary>
	[Serializable]
	public partial class BUY_SETTLEMENT
	{
		public BUY_SETTLEMENT()
		{}
		#region Model
		private string _settlementcode;
		private DateTime _settlementdate;
		private decimal _settlementtotal;
		private decimal _settlementnettotal;
		private int _nooftxn;
		private DateTime? _bankindate;
		private int _status=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 单号，主键。（一般：Bus_Date+StoreID+Bank_Code+Card_Type）
		/// </summary>
		public string SettlementCode
		{
			set{ _settlementcode=value;}
			get{return _settlementcode;}
		}
		/// <summary>
		///11 结算日期
		/// </summary>
		public DateTime SettlementDate
		{
			set{ _settlementdate=value;}
			get{return _settlementdate;}
		}
		/// <summary>
		///11 此单总金额
		/// </summary>
		public decimal SettlementTotal
		{
			set{ _settlementtotal=value;}
			get{return _settlementtotal;}
		}
		/// <summary>
		///11 此单总净额
		/// </summary>
		public decimal SettlementNetTotal
		{
			set{ _settlementnettotal=value;}
			get{return _settlementnettotal;}
		}
		/// <summary>
		///11 此单总交易数
		/// </summary>
		public int NoOfTxn
		{
			set{ _nooftxn=value;}
			get{return _nooftxn;}
		}
		/// <summary>
		///11 汇款日期
		/// </summary>
		public DateTime? BankInDate
		{
			set{ _bankindate=value;}
			get{return _bankindate;}
		}
		/// <summary>
		///11 状态
		///0: Outstanding 
		///1: Partial Payment  
		///2: Full Payment 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		///11 创建时间
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 创建人
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

