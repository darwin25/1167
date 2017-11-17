using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 促销礼品表。
	/// </summary>
	[Serializable]
	public partial class Promotion_Gift
	{
		public Promotion_Gift()
		{}
		#region Model
		private string _promotioncode;
		private int _giftseq;
		private int? _giftlogicalopr=0;
		private int? _promotiongifttype=1;
		private int? _promotiondiscounton=0;
		private int? _promotiondiscounttype=0;
		private decimal? _promotionvalue;
		private int? _promotiongiftqty=0;
		private int? _promotiongiftitem=0;
		/// <summary>
		/// 促销编码
		/// </summary>
		public string PromotionCode
		{
			set{ _promotioncode=value;}
			get{return _promotioncode;}
		}
		/// <summary>
		/// 序号
		/// </summary>
		public int GiftSeq
		{
			set{ _giftseq=value;}
			get{return _giftseq;}
		}
		/// <summary>
		/// 促销结果(Gift)之间的逻辑关系。默认0
        //0：and   1：or
		/// </summary>
		public int? GiftLogicalOpr
		{
			set{ _giftlogicalopr=value;}
			get{return _giftlogicalopr;}
		}
		/// <summary>
		/// 促销实现方式.. 默认1
        //1：现金返还（可以设置现金或者折扣百分比）（需要进下一步的设置）
        //2：积分返还 
        //3：实物赠送。（即Hit命中后，添加某些货品免费。需要相应的货品设置表）
		/// </summary>
		public int? PromotionGiftType
		{
			set{ _promotiongifttype=value;}
			get{return _promotiongifttype;}
		}
		/// <summary>
		/// 折扣金额实现的方式。默认0
        //0：在命中货品上实现折扣或现金抵扣 （此选项不需要设置gift货品）
        //1：在Gift货品上实现折扣或现金抵扣   
        //2：全单实现折扣或现金抵扣  （此选项不需要设置gift货品）

		/// </summary>
		public int? PromotionDiscountOn
		{
			set{ _promotiondiscounton=value;}
			get{return _promotiondiscounton;}
		}
		/// <summary>
		/// 折扣金额设定类型。默认0
        //0：Sales at （金额）
        //1：Sales at （折扣）  
        //2：Sales off（金额）
        //3：Sales off（折扣）
		/// </summary>
		public int? PromotionDiscountType
		{
			set{ _promotiondiscounttype=value;}
			get{return _promotiondiscounttype;}
		}
		/// <summary>
		/// 促销内容值。（金额或百分比）
		/// </summary>
		public decimal? PromotionValue
		{
			set{ _promotionvalue=value;}
			get{return _promotionvalue;}
		}
		/// <summary>
		/// 促销货品数量。默认0。 0表示没有Gift货品。  数字表示Gift货品不能超过。
        //PromotionGiftItem中指定每个Gift具体数值。
		/// </summary>
		public int? PromotionGiftQty
		{
			set{ _promotiongiftqty=value;}
			get{return _promotiongiftqty;}
		}
		/// <summary>
		/// 促销货品条件：默认0
        //0：没有具体的货品条件，任何货品
        //1：Promotion_Gift_PLU中的任意货品合计。
        //2：Promotion_Gift_PLU中任意一个单独货品合计。
		/// </summary>
		public int? PromotionGiftItem
		{
			set{ _promotiongiftitem=value;}
			get{return _promotiongiftitem;}
		}
		#endregion Model

	}
}

