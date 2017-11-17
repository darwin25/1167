using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 销售单主表（字段暂定）
	///表中会员部分，为本次交易中使用的会员资料。（比如CU_CardNumber是本次交易使用的卡，没有指定的话使用默认值）
	/// </summary>
	[Serializable]
	public partial class ScheduleWeek
	{
		public ScheduleWeek()
		{}
		#region Model
		private int _seq;
		private bool? _mon= false;
		private bool? _tue= false;
		private bool? _wed= false;
		private bool? _thu= false;
		private bool? _fri= false;
		private bool? _sat= false;
		private bool? _sun= false;
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
		public bool? Mon
		{
			set{ _mon=value;}
			get{return _mon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? Tue
		{
			set{ _tue=value;}
			get{return _tue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? wed
		{
			set{ _wed=value;}
			get{return _wed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? thu
		{
			set{ _thu=value;}
			get{return _thu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? Fri
		{
			set{ _fri=value;}
			get{return _fri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? Sat
		{
			set{ _sat=value;}
			get{return _sat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? Sun
		{
			set{ _sun=value;}
			get{return _sun;}
		}
		#endregion Model

	}
}

