using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 实体卡绑定表
	/// </summary>
	[Serializable]
	public partial class VenCardIDMap
	{
		public VenCardIDMap()
		{}
		#region Model
		private int _keyid;
		private string _vendorcardnumber;
		private string _cardnumber;
		private string _cardnumberencrypt;
		private int _validateflag=1;
		private string _laserid;
		private DateTime? _createdon= DateTime.Now;
		private DateTime? _updatedon= DateTime.Now;
		private int? _createdby;
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
		/// 实体卡ID。（UID）
		/// </summary>
		public string VendorCardNumber
		{
			set{ _vendorcardnumber=value;}
			get{return _vendorcardnumber;}
		}
		/// <summary>
		/// 卡号
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
		}
		/// <summary>
		/// 卡号密文
		/// </summary>
		public string CardNumberEncrypt
		{
			set{ _cardnumberencrypt=value;}
			get{return _cardnumberencrypt;}
		}
		/// <summary>
		/// 生效标志，默认1。0：无效。 1：生效
		/// </summary>
		public int ValidateFlag
		{
			set{ _validateflag=value;}
			get{return _validateflag;}
		}
		/// <summary>
		/// LaserID或者其他ID
		/// </summary>
		public string LaserID
		{
			set{ _laserid=value;}
			get{return _laserid;}
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
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
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
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

