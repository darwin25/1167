using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺类型表
	/// </summary>
	[Serializable]
	public partial class SVA_Transfer_D
	{
		public SVA_Transfer_D()
		{}
		#region Model
		private string _number;
		private int _seqno;
		private string _outuid;
		private string _outcardno;
		private string _outcardtypeid;
		private string _outcardgradid;
		private string _inuid;
		private string _incardno;
		private string _incardtypeid;
		private string _incardgradid;
		private decimal? _outamount;
		private decimal? _inamount;
		private string _remark;
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
		public int SeqNo
		{
			set{ _seqno=value;}
			get{return _seqno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OutUID
		{
			set{ _outuid=value;}
			get{return _outuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OutCardNo
		{
			set{ _outcardno=value;}
			get{return _outcardno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OutCardTypeID
		{
			set{ _outcardtypeid=value;}
			get{return _outcardtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OutCardGradID
		{
			set{ _outcardgradid=value;}
			get{return _outcardgradid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InUID
		{
			set{ _inuid=value;}
			get{return _inuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InCardNo
		{
			set{ _incardno=value;}
			get{return _incardno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InCardTypeID
		{
			set{ _incardtypeid=value;}
			get{return _incardtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InCardGradID
		{
			set{ _incardgradid=value;}
			get{return _incardgradid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OutAmount
		{
			set{ _outamount=value;}
			get{return _outamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? InAmount
		{
			set{ _inamount=value;}
			get{return _inamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

