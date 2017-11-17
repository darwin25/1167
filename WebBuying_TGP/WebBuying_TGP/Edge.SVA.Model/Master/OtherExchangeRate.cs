using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 与第三方的兑换比率设置表
	/// </summary>
	[Serializable]
	public partial class OtherExchangeRate
	{
		public OtherExchangeRate()
		{}
		#region Model
		private int _keyid;
		private int _bankid;
		private string _accountcode;
		private int _inputvaluetype=0;
		private int _outputvaluetype=0;
		private decimal _exchangerate=1M;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键ID，自增长
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 银行代码
		/// </summary>
		public int BankID
		{
			set{ _bankid=value;}
			get{return _bankid;}
		}
		/// <summary>
		/// 第三方账号
		/// </summary>
		public string AccountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		/// 兑换值类型：
//0: 金额; 1:积分
		/// </summary>
		public int InputValueType
		{
			set{ _inputvaluetype=value;}
			get{return _inputvaluetype;}
		}
		/// <summary>
		/// 兑换到的值类型：
//0: 金额; 1:积分
		/// </summary>
		public int OutputValueType
		{
			set{ _outputvaluetype=value;}
			get{return _outputvaluetype;}
		}
		/// <summary>
		/// 乘 系数.   (input * ExchangeRate = output)
		/// </summary>
		public decimal ExchangeRate
		{
			set{ _exchangerate=value;}
			get{return _exchangerate;}
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

