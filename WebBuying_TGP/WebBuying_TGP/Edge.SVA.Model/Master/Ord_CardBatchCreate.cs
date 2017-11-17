using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// ?¨?úá?′′?¨±í
	/// </summary>
	[Serializable]
	public partial class Ord_CardBatchCreate
	{
		public Ord_CardBatchCreate()
		{}
		#region Model
		private string _cardcreatenumber;
		private int _cardgradeid;
		private int _cardcount;
		private string _note;
		private DateTime? _issueddate;
		private DateTime? _expirydate;
		private decimal? _initamount=0M;
		private int? _initpoints=0;
		private int? _randompwd=0;
		private string _initpassword;
		private int? _batchcardid;
		private string _approvalcode;
		private string _approvestatus="P";
		private DateTime? _approveon;
		private int? _approveby;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private DateTime? _createdbusdate;
		private DateTime? _approvebusdate;
		/// <summary>
		/// ?¨?¨μ￥o???￡? ?÷?ü
		/// </summary>
		public string CardCreateNumber
		{
			set{ _cardcreatenumber=value;}
			get{return _cardcreatenumber;}
		}
		/// <summary>
		/// ?¨μè??ID
		/// </summary>
		public int CardGradeID
		{
			set{ _cardgradeid=value;}
			get{return _cardgradeid;}
		}
		/// <summary>
		/// ?¨êyá?
		/// </summary>
		public int CardCount
		{
			set{ _cardcount=value;}
			get{return _cardcount;}
		}
		/// <summary>
		/// ±?×￠
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// ·￠DDè??ú
		/// </summary>
		public DateTime? IssuedDate
		{
			set{ _issueddate=value;}
			get{return _issueddate;}
		}
		/// <summary>
		/// óDD§?ú
		/// </summary>
		public DateTime? ExpiryDate
		{
			set{ _expirydate=value;}
			get{return _expirydate;}
		}
		/// <summary>
		/// 3?ê??e??
		/// </summary>
		public decimal? InitAmount
		{
			set{ _initamount=value;}
			get{return _initamount;}
		}
		/// <summary>
		/// 3?ê??y·?
		/// </summary>
		public int? InitPoints
		{
			set{ _initpoints=value;}
			get{return _initpoints;}
		}
		/// <summary>
		/// ê?·?3?ê????ú?ü???￡0￡o2?ê??￡1:ê?μ??￡ ??è?0
		/// </summary>
		public int? RandomPWD
		{
			set{ _randompwd=value;}
			get{return _randompwd;}
		}
		/// <summary>
		/// 3?ê??ü???￡RandomPWD=1ê±￡?2?Dèòaì?
		/// </summary>
		public string InitPassword
		{
			set{ _initpassword=value;}
			get{return _initpassword;}
		}
		/// <summary>
		/// ?ú′?o?
		/// </summary>
		public int? BatchCardID
		{
			set{ _batchcardid=value;}
			get{return _batchcardid;}
		}
		/// <summary>
		/// ?úo?ê±2úéúêúè¨o?￡?2￠í¨?a?°ì¨
		/// </summary>
		public string ApprovalCode
		{
			set{ _approvalcode=value;}
			get{return _approvalcode;}
		}
		/// <summary>
		/// ×′ì?￡o P￡oprepare?￡  A:Approve ?￡ V￡oVoid
		/// </summary>
		public string ApproveStatus
		{
			set{ _approvestatus=value;}
			get{return _approvestatus;}
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
		public int? ApproveBy
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
		public int? CreatedBy
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
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		/// <summary>
		/// μ￥?Y′′?¨ê±μ?busdate
		/// </summary>
		public DateTime? CreatedBusDate
		{
			set{ _createdbusdate=value;}
			get{return _createdbusdate;}
		}
		/// <summary>
		/// μ￥?Y?úo?ê±μ?busdate
		/// </summary>
		public DateTime? ApproveBusDate
		{
			set{ _approvebusdate=value;}
			get{return _approvebusdate;}
		}
		#endregion Model

	}
}

