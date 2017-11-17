using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 系统设置表
	/// </summary>
	[Serializable]
	public partial class BUY_SYSOPTION
	{
		public BUY_SYSOPTION()
		{}
		#region Model
		private string _code;
		private string _note;
		private int? _languageid;
		/// <summary>
		///11 字段名称
		/// </summary>
		public string CODE
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		///11 字段内容
		/// </summary>
		public string NOTE
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		///11 语言ID
		/// </summary>
		public int? LanguageID
		{
			set{ _languageid=value;}
			get{return _languageid;}
		}
		#endregion Model

	}
}

