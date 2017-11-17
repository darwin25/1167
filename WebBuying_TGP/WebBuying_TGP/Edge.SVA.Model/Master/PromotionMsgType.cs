using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 优惠消息类型表
	/// </summary>
	[Serializable]
	public partial class PromotionMsgType
	{
		public PromotionMsgType()
		{}
		#region Model
		private int _promotionmsgtypeid;
		private int? _brandid;
		private string _promotionmsgtypename1;
		private string _promotionmsgtypename2;
		private string _promotionmsgtypename3;
		private int? _parentid;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int PromotionMsgTypeID
		{
			set{ _promotionmsgtypeid=value;}
			get{return _promotionmsgtypeid;}
		}
		/// <summary>
		/// 品牌ID
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 名称1
		/// </summary>
		public string PromotionMsgTypeName1
		{
			set{ _promotionmsgtypename1=value;}
			get{return _promotionmsgtypename1;}
		}
		/// <summary>
		/// 名称2
		/// </summary>
		public string PromotionMsgTypeName2
		{
			set{ _promotionmsgtypename2=value;}
			get{return _promotionmsgtypename2;}
		}
		/// <summary>
		/// 名称3
		/// </summary>
		public string PromotionMsgTypeName3
		{
			set{ _promotionmsgtypename3=value;}
			get{return _promotionmsgtypename3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

