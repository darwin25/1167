using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 银行表
	/// </summary>
	[Serializable]
	public partial class BUY_BANK
	{
		public BUY_BANK()
		{}
		#region Model
		private int _bankid;
		private string _bankcode;
		private string _bankname1;
		private string _bankname2;
		private string _bankname3;
		private decimal? _commissionrate=0M;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键
		/// </summary>
		public int BankID
		{
			set{ _bankid=value;}
			get{return _bankid;}
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
		///11 银行名称1
		/// </summary>
		public string BankName1
		{
			set{ _bankname1=value;}
			get{return _bankname1;}
		}
		/// <summary>
		///11 银行名称2
		/// </summary>
		public string BankName2
		{
			set{ _bankname2=value;}
			get{return _bankname2;}
		}
		/// <summary>
		///11 银行名称3
		/// </summary>
		public string BankName3
		{
			set{ _bankname3=value;}
			get{return _bankname3;}
		}
		/// <summary>
		///11 佣金率。 （百分制）
		/// </summary>
		public decimal? Commissionrate
		{
			set{ _commissionrate=value;}
			get{return _commissionrate;}
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

