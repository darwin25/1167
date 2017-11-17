using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 周标志表
	/// </summary>
	[Serializable]
	public partial class BUY_WEEKFLAG
	{
		public BUY_WEEKFLAG()
		{}
		#region Model
		private int _weekflagid;
		private string _weekflagcode;
		private string _note;
		private int? _sundayflag=0;
		private int? _mondayflag=0;
		private int? _tuesdayflag=0;
		private int? _wednesdayflag=0;
		private int? _thursdayflag=0;
		private int? _fridayflag=0;
		private int? _saturdayflag=0;
		/// <summary>
		///11 主键
		/// </summary>
		public int WeekFlagID
		{
			set{ _weekflagid=value;}
			get{return _weekflagid;}
		}
		/// <summary>
		///11 编码
		/// </summary>
		public string WeekFlagCode
		{
			set{ _weekflagcode=value;}
			get{return _weekflagcode;}
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
		public int? SundayFlag
		{
			set{ _sundayflag=value;}
			get{return _sundayflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? MondayFlag
		{
			set{ _mondayflag=value;}
			get{return _mondayflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? TuesdayFlag
		{
			set{ _tuesdayflag=value;}
			get{return _tuesdayflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? WednesdayFlag
		{
			set{ _wednesdayflag=value;}
			get{return _wednesdayflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? ThursdayFlag
		{
			set{ _thursdayflag=value;}
			get{return _thursdayflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? FridayFlag
		{
			set{ _fridayflag=value;}
			get{return _fridayflag;}
		}
		/// <summary>
		///11 1：生效。 0：无效
		/// </summary>
		public int? SaturdayFlag
		{
			set{ _saturdayflag=value;}
			get{return _saturdayflag;}
		}
		#endregion Model

	}
}

