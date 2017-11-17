using System;
namespace Edge.Messages.Model
{
	/// <summary>
	/// DialogMessage_Lan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DialogMessage_Lan
	{
		public DialogMessage_Lan()
		{}
		#region Model
		private string _tapcode;
		private string _message;
		private string _lan;
		/// <summary>
		/// 
		/// </summary>
		public string TAPCode
		{
			set{ _tapcode=value;}
			get{return _tapcode;}
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
		public string Lan
		{
			set{ _lan=value;}
			get{return _lan;}
		}
		#endregion Model

	}
}

