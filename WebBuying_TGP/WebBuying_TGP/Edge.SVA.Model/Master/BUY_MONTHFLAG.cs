using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 月标志表
	/// </summary>
	[Serializable]
	public partial class BUY_MONTHFLAG
	{
		public BUY_MONTHFLAG()
		{}
		#region Model
		private int _monthflagid;
		private string _monthflagcode;
		private string _note;
		private int? _januaryflag=0;
		private int? _februaryflag=0;
		private int? _marchflag=0;
		private int? _aprilflag=0;
		private int? _mayflag=0;
		private int? _juneflag=0;
		private int? _julyflag=0;
		private int? _augustflag=0;
		private int? _septemberflag=0;
		private int? _decemberflag=0;
		private int? _octoberflag=0;
		private int? _novemberflag=0;
		/// <summary>
		///11 主键
		/// </summary>
		public int MonthFlagID
		{
			set{ _monthflagid=value;}
			get{return _monthflagid;}
		}
		/// <summary>
		///11 编码
		/// </summary>
		public string MonthFlagCode
		{
			set{ _monthflagcode=value;}
			get{return _monthflagcode;}
		}
		/// <summary>
		///11 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? JanuaryFlag
		{
			set{ _januaryflag=value;}
			get{return _januaryflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? FebruaryFlag
		{
			set{ _februaryflag=value;}
			get{return _februaryflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? MarchFlag
		{
			set{ _marchflag=value;}
			get{return _marchflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? AprilFlag
		{
			set{ _aprilflag=value;}
			get{return _aprilflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? MayFlag
		{
			set{ _mayflag=value;}
			get{return _mayflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? JuneFlag
		{
			set{ _juneflag=value;}
			get{return _juneflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? JulyFlag
		{
			set{ _julyflag=value;}
			get{return _julyflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? AugustFlag
		{
			set{ _augustflag=value;}
			get{return _augustflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? SeptemberFlag
		{
			set{ _septemberflag=value;}
			get{return _septemberflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? DecemberFlag
		{
			set{ _decemberflag=value;}
			get{return _decemberflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? OctoberFlag
		{
			set{ _octoberflag=value;}
			get{return _octoberflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? NovemberFlag
		{
			set{ _novemberflag=value;}
			get{return _novemberflag;}
		}
		#endregion Model

	}
}

