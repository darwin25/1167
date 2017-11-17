using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 消息内容模板。
	/// </summary>
	[Serializable]
	public partial class MessageTemplate
	{
		public MessageTemplate()
		{}
		#region Model
		private int _messagetemplateid;
		private string _messagetemplatecode;
		private string _messagetemplatedesc;
		private int? _brandid;
		private int? _oprid;
		private string _remark;
		/// <summary>
		/// 主键，自增长
		/// </summary>
		public int MessageTemplateID
		{
			set{ _messagetemplateid=value;}
			get{return _messagetemplateid;}
		}
		/// <summary>
		/// 模板code
		/// </summary>
		public string MessageTemplateCode
		{
			set{ _messagetemplatecode=value;}
			get{return _messagetemplatecode;}
		}
		/// <summary>
		/// 模板描述
		/// </summary>
		public string MessageTemplateDesc
		{
			set{ _messagetemplatedesc=value;}
			get{return _messagetemplatedesc;}
		}
		/// <summary>
		/// 品牌
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 操作类型ID
		/// </summary>
		public int? OprID
		{
			set{ _oprid=value;}
			get{return _oprid;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

