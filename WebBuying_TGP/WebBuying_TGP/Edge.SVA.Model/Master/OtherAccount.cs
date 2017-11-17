using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 其他账号
	/// </summary>
	[Serializable]
	public partial class OtherAccount
	{
		public OtherAccount()
		{}
		#region Model
		private int _keyid;
		private int _bankid;
		private string _accountcode;
		private string _accountnumber;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 银行主键
		/// </summary>
		public int BankID
		{
			set{ _bankid=value;}
			get{return _bankid;}
		}
		/// <summary>
		/// 账号代码
		/// </summary>
		public string AccountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		/// 账号号码
		/// </summary>
		public string AccountNumber
		{
			set{ _accountnumber=value;}
			get{return _accountnumber;}
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
		#endregion Model

	}
}

