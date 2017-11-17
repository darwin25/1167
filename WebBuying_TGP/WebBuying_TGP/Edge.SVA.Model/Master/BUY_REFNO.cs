using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 交易单单号维护表。
	/// </summary>
	[Serializable]
	public partial class BUY_REFNO
	{
		public BUY_REFNO()
		{}
		#region Model
		private string _code;
		private string _refdesc;
		private string _header;
		private int _seq;
		private int _length;
		private string _auto="Y";
		private int? _active=1;
		/// <summary>
		///11 编号
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		///11 描述
		/// </summary>
		public string RefDesc
		{
			set{ _refdesc=value;}
			get{return _refdesc;}
		}
		/// <summary>
		///11 单号头
		/// </summary>
		public string Header
		{
			set{ _header=value;}
			get{return _header;}
		}
		/// <summary>
		///11 序号
		/// </summary>
		public int Seq
		{
			set{ _seq=value;}
			get{return _seq;}
		}
		/// <summary>
		///11 单号长度
		/// </summary>
		public int Length
		{
			set{ _length=value;}
			get{return _length;}
		}
		/// <summary>
		///11 是否自动增长。N：不会。 Y：会。 默认Y
		/// </summary>
		public string Auto
		{
			set{ _auto=value;}
			get{return _auto;}
		}
		/// <summary>
		///11 是否生效。0：不生效。1：生效
		/// </summary>
		public int? Active
		{
			set{ _active=value;}
			get{return _active;}
		}
		#endregion Model

	}
}

