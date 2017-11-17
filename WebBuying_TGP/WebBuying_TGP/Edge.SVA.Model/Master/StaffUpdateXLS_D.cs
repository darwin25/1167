using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 销售单主表（字段暂定）
	///表中会员部分，为本次交易中使用的会员资料。（比如CU_CardNumber是本次交易使用的卡，没有指定的话使用默认值）
	/// </summary>
	[Serializable]
	public partial class StaffUpdateXLS_D
	{
		public StaffUpdateXLS_D()
		{}
		#region Model
		private int _keyid;
		private int _masterkeyid;
		private string _action;
		private string _birthdaymonth;
		private string _cardid;
		private string _cardstatus;
		private string _companycode;
		private string _deptcode;
		private string _entitlement;
		private string _familyname;
		private string _givenname;
		private string _positionid;
		private string _staffid;
		private string _storecode;
		private decimal? _amount;
		private string _remark;
		private DateTime? _createddate= DateTime.Now;
		private DateTime? _updateddate= DateTime.Now;
		private string _createdby;
		private string _updatedby;
		/// <summary>
		/// 
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MasterKeyID
		{
			set{ _masterkeyid=value;}
			get{return _masterkeyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Action
		{
			set{ _action=value;}
			get{return _action;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BIRTHDAYMONTH
		{
			set{ _birthdaymonth=value;}
			get{return _birthdaymonth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CARDID
		{
			set{ _cardid=value;}
			get{return _cardid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CARDSTATUS
		{
			set{ _cardstatus=value;}
			get{return _cardstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string COMPANYCODE
		{
			set{ _companycode=value;}
			get{return _companycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEPTCODE
		{
			set{ _deptcode=value;}
			get{return _deptcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Entitlement
		{
			set{ _entitlement=value;}
			get{return _entitlement;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FAMILYNAME
		{
			set{ _familyname=value;}
			get{return _familyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GIVENNAME
		{
			set{ _givenname=value;}
			get{return _givenname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string POSITIONID
		{
			set{ _positionid=value;}
			get{return _positionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string STAFFID
		{
			set{ _staffid=value;}
			get{return _staffid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string STORECODE
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? AMOUNT
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdatedDate
		{
			set{ _updateddate=value;}
			get{return _updateddate;}
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
		public string UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

