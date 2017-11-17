using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 会员消息 发送类型表。
	/// </summary>
	[Serializable]
	public partial class MemberNotice_MessageType
	{
		public MemberNotice_MessageType()
		{}
		#region Model
		private int _keyid;
		private string _noticenumber;
		private int _messagetemplateid;
		private int? _status=1;
		private int? _frequencyunit;
		private int? _frequencyvalue=1;
		private DateTime? _sendtime;
		private int? _designsendtimes=0;
		private int? _sendcount=0;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 通知编号
		/// </summary>
		public string NoticeNumber
		{
			set{ _noticenumber=value;}
			get{return _noticenumber;}
		}
		/// <summary>
		/// 模板主键
		/// </summary>
		public int MessageTemplateID
		{
			set{ _messagetemplateid=value;}
			get{return _messagetemplateid;}
		}
		/// <summary>
		/// 是否生效。0：无效。1：生效
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 发送频率单位：0：仅一次。 1：月。 2：星期。3：天。 
		/// </summary>
		public int? FrequencyUnit
		{
			set{ _frequencyunit=value;}
			get{return _frequencyunit;}
		}
		/// <summary>
		/// 发送频率数量
		/// </summary>
		public int? FrequencyValue
		{
			set{ _frequencyvalue=value;}
			get{return _frequencyvalue;}
		}
		/// <summary>
		/// 发送的时间点。（带时间）
		/// </summary>
		public DateTime? SendTime
		{
			set{ _sendtime=value;}
			get{return _sendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DesignSendTimes
		{
			set{ _designsendtimes=value;}
			get{return _designsendtimes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SendCount
		{
			set{ _sendcount=value;}
			get{return _sendcount;}
		}
		#endregion Model

	}
}

