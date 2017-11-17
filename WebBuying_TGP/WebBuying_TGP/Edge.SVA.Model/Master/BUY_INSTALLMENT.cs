using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 支付分期表
	/// </summary>
	[Serializable]
	public partial class BUY_INSTALLMENT
	{
		public BUY_INSTALLMENT()
		{}
		#region Model
		private int _installmentid;
		private string _installmentcode;
		private int? _bankid;
		private string _installmentname1;
		private string _installmentname2;
		private string _installmentname3;
		private int? _nooflast;
		private decimal? _painterest;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private string _note;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键ID
		/// </summary>
		public int InstallmentID
		{
			set{ _installmentid=value;}
			get{return _installmentid;}
		}
		/// <summary>
		///11 编码
		/// </summary>
		public string InstallmentCode
		{
			set{ _installmentcode=value;}
			get{return _installmentcode;}
		}
		/// <summary>
		///11 buy_bank 表主键
		/// </summary>
		public int? BankID
		{
			set{ _bankid=value;}
			get{return _bankid;}
		}
		/// <summary>
		///11 分期付款描述1
		/// </summary>
		public string InstallmentName1
		{
			set{ _installmentname1=value;}
			get{return _installmentname1;}
		}
		/// <summary>
		///11 分期付款描述2
		/// </summary>
		public string InstallmentName2
		{
			set{ _installmentname2=value;}
			get{return _installmentname2;}
		}
		/// <summary>
		///11 分期付款描述3
		/// </summary>
		public string InstallmentName3
		{
			set{ _installmentname3=value;}
			get{return _installmentname3;}
		}
		/// <summary>
		///11 分期长度（单位月）
		/// </summary>
		public int? NoOfLast
		{
			set{ _nooflast=value;}
			get{return _nooflast;}
		}
		/// <summary>
		///11 分期利息（百分比）
		/// </summary>
		public decimal? PAInterest
		{
			set{ _painterest=value;}
			get{return _painterest;}
		}
		/// <summary>
		///11 生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		///11 结束日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		///11 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

