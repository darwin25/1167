using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 销售单主表（字段暂定）
	///表中会员部分，为本次交易中使用的会员资料。（比如CU_CardNumber是本次交易使用的卡，没有指定的话使用默认值）
	/// </summary>
	[Serializable]
	public partial class Schedule
	{
		public Schedule()
		{}
		#region Model
		private int _seq;
		private string _name;
		private int _freqtype;
		private decimal _freqvalue;
		private int? _freqat;
		private int? _weekseq;
		private DateTime _happentime;
		private DateTime _begindate;
		private DateTime _enddate;
		private bool? _valid= true;
		private DateTime? _lastcheckdate= DateTime.Now;
		private string _message;
		private int _msgtype=0;
		private int? _queryid;
		/// <summary>
		/// 
		/// </summary>
		public int Seq
		{
			set{ _seq=value;}
			get{return _seq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FreqType
		{
			set{ _freqtype=value;}
			get{return _freqtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal FreqValue
		{
			set{ _freqvalue=value;}
			get{return _freqvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FreqAt
		{
			set{ _freqat=value;}
			get{return _freqat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? WeekSeq
		{
			set{ _weekseq=value;}
			get{return _weekseq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime HappenTime
		{
			set{ _happentime=value;}
			get{return _happentime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime BeginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? Valid
		{
			set{ _valid=value;}
			get{return _valid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastCheckDate
		{
			set{ _lastcheckdate=value;}
			get{return _lastcheckdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MsgType
		{
			set{ _msgtype=value;}
			get{return _msgtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? QueryID
		{
			set{ _queryid=value;}
			get{return _queryid;}
		}
		#endregion Model

	}
}

