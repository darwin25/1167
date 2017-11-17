using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 促销信息（广告）的卡条件。
	/// </summary>
	[Serializable]
	public partial class PromotionCardCondition
	{
		public PromotionCardCondition()
		{}
		#region Model
		private int _promotionmsgid;
		private int _cardgradeid;
		/// <summary>
		/// PromotionMsg 主键
		/// </summary>
		public int PromotionMsgID
		{
			set{ _promotionmsgid=value;}
			get{return _promotionmsgid;}
		}
		/// <summary>
		/// Card Grade 主键
		/// </summary>
		public int CardGradeID
		{
			set{ _cardgradeid=value;}
			get{return _cardgradeid;}
		}
		#endregion Model

	}
}

