using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺类型表
	/// </summary>
	[Serializable]
	public partial class SVA_VoidCard_H
	{
		public SVA_VoidCard_H()
		{}
		#region Model
		private string _number;
		private string _reftxnno;
		private DateTime? _txndate;
		private string _shopid;
		private string _serverid;
		private string _posid;
		private string _note;
		private int? _cardcount;
		private string _formno;
		private string _status;
		private DateTime? _approveon;
		private string _approveby;
		private DateTime? _createdon;
		private string _createdby;
		private DateTime? _updatedon;
		private string _updatedby;
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
		public string RefTxnNo
		{
			set{ _reftxnno=value;}
			get{return _reftxnno;}
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
		public string ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ServerID
		{
			set{ _serverid=value;}
			get{return _serverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string POSID
		{
			set{ _posid=value;}
			get{return _posid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CardCount
		{
			set{ _cardcount=value;}
			get{return _cardcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FormNo
		{
			set{ _formno=value;}
			get{return _formno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ApproveOn
		{
			set{ _approveon=value;}
			get{return _approveon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApproveBy
		{
			set{ _approveby=value;}
			get{return _approveby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

