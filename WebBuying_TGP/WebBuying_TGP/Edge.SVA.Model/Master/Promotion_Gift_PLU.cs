using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 促销赠送表的指定货品列表
	/// </summary>
	[Serializable]
	public partial class Promotion_Gift_PLU
	{
		public Promotion_Gift_PLU()
		{}
		#region Model
		private int _keyid;
		private string _promotioncode;
		private int _giftseq;
		private string _entitynum;
		private int _entitytype;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 促销编码
		/// </summary>
		public string PromotionCode
		{
			set{ _promotioncode=value;}
			get{return _promotioncode;}
		}
		/// <summary>
		/// Promotion_Gift表主键
		/// </summary>
		public int GiftSeq
		{
			set{ _giftseq=value;}
			get{return _giftseq;}
		}
		/// <summary>
		/// 号码
		/// </summary>
		public string EntityNum
		{
			set{ _entitynum=value;}
			get{return _entitynum;}
		}
		/// <summary>
		/// 决定EntityNum中内容的含义。
        //0：所有货品。EntityNum中为空
        //1：EntityNum内容为 prodcode。
        //2：EntityNum内容为 DepartCode。
		/// </summary>
		public int EntityType
		{
			set{ _entitytype=value;}
			get{return _entitytype;}
		}
		#endregion Model

	}
}

