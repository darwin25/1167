using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 交易单单号维护表。
	/// </summary>
	[Serializable]
	public partial class RSAKeyTable
	{
		public RSAKeyTable()
		{}
		#region Model
		private int _keyid;
		private string _keyvalue;
		private DateTime? _createdon= DateTime.Now;
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
		public string KeyValue
		{
			set{ _keyvalue=value;}
			get{return _keyvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		#endregion Model

	}
}

