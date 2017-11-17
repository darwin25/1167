using System;
namespace Edge.Messages.Model
{
	/// <summary>
	/// DialogMessage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DialogMessage
	{
		public DialogMessage()
		{}
		#region Model
		private string _tapcode;
		private string _originalcode;
		private string _message;
		private string _project;
		private string _product;
		private string _modifiedby;
		private DateTime? _adddate;
		private bool? _messageicondisplay;
		private bool? _buttondisplay;
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
		public string OriginalCode
		{
			set{ _originalcode=value;}
			get{return _originalcode;}
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
		public string Project
		{
			set{ _project=value;}
			get{return _project;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Product
		{
			set{ _product=value;}
			get{return _product;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ModifiedBy
		{
			set{ _modifiedby=value;}
			get{return _modifiedby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? MessageIconDisplay
		{
			set{ _messageicondisplay=value;}
			get{return _messageicondisplay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? ButtonDisplay
		{
			set{ _buttondisplay=value;}
			get{return _buttondisplay;}
		}
		#endregion Model

	}
}

