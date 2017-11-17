using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 消息内容模板明细。
	/// </summary>
	[Serializable]
	public partial class MessageTemplateDetail
	{
		public MessageTemplateDetail()
		{}
		#region Model
		private int _keyid;
		private int? _messagetemplateid;
		private int? _messageservicetypeid;
		private int? _status;
		private string _messagetitle1;
		private string _messagetitle3;
		private string _messagetitle2;
		private string _templatecontent1;
		private string _templatecontent2;
		private string _templatecontent3;
		/// <summary>
		/// 主键，自增长
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// MessageTemplate表主键
		/// </summary>
		public int? MessageTemplateID
		{
			set{ _messagetemplateid=value;}
			get{return _messagetemplateid;}
		}
		/// <summary>
		/// 消息发送方式 外键
		/// </summary>
		public int? MessageServiceTypeID
		{
			set{ _messageservicetypeid=value;}
			get{return _messageservicetypeid;}
		}
		/// <summary>
		/// 状态。 0：不使用。1：使用
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 消息标题1
		/// </summary>
		public string MessageTitle1
		{
			set{ _messagetitle1=value;}
			get{return _messagetitle1;}
		}
		/// <summary>
		/// 消息标题3
		/// </summary>
		public string MessageTitle3
		{
			set{ _messagetitle3=value;}
			get{return _messagetitle3;}
		}
		/// <summary>
		/// 消息标题2
		/// </summary>
		public string MessageTitle2
		{
			set{ _messagetitle2=value;}
			get{return _messagetitle2;}
		}
		/// <summary>
		/// 模板内容1
		/// </summary>
		public string TemplateContent1
		{
			set{ _templatecontent1=value;}
			get{return _templatecontent1;}
		}
		/// <summary>
		/// 模板内容2
		/// </summary>
		public string TemplateContent2
		{
			set{ _templatecontent2=value;}
			get{return _templatecontent2;}
		}
		/// <summary>
		/// 模板内容3
		/// </summary>
		public string TemplateContent3
		{
			set{ _templatecontent3=value;}
			get{return _templatecontent3;}
		}
		#endregion Model

	}
}

