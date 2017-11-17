using System;
namespace Edge.Security.Model
{
	/// <summary>
	/// Lan_S_Tree:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Lan_S_Tree
	{
		public Lan_S_Tree()
		{}
		#region Model
		private int _nodeid;
		private string _text;
		private string _lan;
		/// <summary>
		/// 
		/// </summary>
		public int NodeID
		{
			set{ _nodeid=value;}
			get{return _nodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Text
		{
			set{ _text=value;}
			get{return _text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Lan
		{
			set{ _lan=value;}
			get{return _lan;}
		}
		#endregion Model

	}
}

