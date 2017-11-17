using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 优惠信息表
	/// </summary>
	[Serializable]
	public partial class PromotionMsg
	{
		public PromotionMsg()
		{}
		#region Model
		private int _keyid;
		private string _promotiontitle1;
		private string _promotiontitle2;
		private string _promotiontitle3;
		private string _promotionmsgstr1;
		private string _promotionmsgstr2;
		private string _promotionmsgstr3;
		private string _promotionpicfile;
		private string _promotionremark;
		private int? _promptscheduleid;
		private int? _birthpromotion;
		private int? _devicetype;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private int? _status=0;
		private int? _campaignid;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private int? _promotionmsgtypeid;
		private string _promotionmsgcode;
		private string _attachmentfilepath;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 优惠消息标题1
		/// </summary>
		public string PromotionTitle1
		{
			set{ _promotiontitle1=value;}
			get{return _promotiontitle1;}
		}
		/// <summary>
		/// 优惠消息标题2
		/// </summary>
		public string PromotionTitle2
		{
			set{ _promotiontitle2=value;}
			get{return _promotiontitle2;}
		}
		/// <summary>
		/// 优惠消息标题3
		/// </summary>
		public string PromotionTitle3
		{
			set{ _promotiontitle3=value;}
			get{return _promotiontitle3;}
		}
		/// <summary>
		/// 优惠消息正文1
		/// </summary>
		public string PromotionMsgStr1
		{
			set{ _promotionmsgstr1=value;}
			get{return _promotionmsgstr1;}
		}
		/// <summary>
		/// 优惠消息正文2
		/// </summary>
		public string PromotionMsgStr2
		{
			set{ _promotionmsgstr2=value;}
			get{return _promotionmsgstr2;}
		}
		/// <summary>
		/// 优惠消息正文2
		/// </summary>
		public string PromotionMsgStr3
		{
			set{ _promotionmsgstr3=value;}
			get{return _promotionmsgstr3;}
		}
		/// <summary>
		/// 促销图片索引
		/// </summary>
		public string PromotionPicFile
		{
			set{ _promotionpicfile=value;}
			get{return _promotionpicfile;}
		}
		/// <summary>
		/// 优惠备注信息。
		/// </summary>
		public string PromotionRemark
		{
			set{ _promotionremark=value;}
			get{return _promotionremark;}
		}
		/// <summary>
		/// 优惠有效日程设置ID
		/// </summary>
		public int? PromptScheduleID
		{
			set{ _promptscheduleid=value;}
			get{return _promptscheduleid;}
		}
		/// <summary>
		/// 会员生日优惠显示：0：无生日限制。 1： 生日当月. 2:生日当周。 3：生日当日
		/// </summary>
		public int? BirthPromotion
		{
			set{ _birthpromotion=value;}
			get{return _birthpromotion;}
		}
		/// <summary>
		/// 指定设备类型：NULL或0:全部  1:店铺促销. 2:生日促销  3:VIP促销.
		/// </summary>
		public int? DeviceType
		{
			set{ _devicetype=value;}
			get{return _devicetype;}
		}
		/// <summary>
		/// 生效日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 失效日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 状态0：无效。 1：生效。
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 活动表ID
		/// </summary>
		public int? CampaignID
		{
			set{ _campaignid=value;}
			get{return _campaignid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PromotionMsgTypeID
		{
			set{ _promotionmsgtypeid=value;}
			get{return _promotionmsgtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PromotionMsgCode
		{
			set{ _promotionmsgcode=value;}
			get{return _promotionmsgcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttachmentFilePath
		{
			set{ _attachmentfilepath=value;}
			get{return _attachmentfilepath;}
		}
		#endregion Model

	}
}

