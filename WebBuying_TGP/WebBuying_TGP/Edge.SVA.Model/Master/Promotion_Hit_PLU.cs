using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 促销命中表的指定货品列表
	/// </summary>
	[Serializable]
	public partial class Promotion_Hit_PLU
	{
		public Promotion_Hit_PLU()
		{}
		#region Model
		private int _keyid;
		private string _promotioncode;
		private int _hitseq;
		private string _entitynum;
		private int? _entitytype=0;
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
		/// Promotion_Hit表序号
		/// </summary>
		public int HitSeq
		{
			set{ _hitseq=value;}
			get{return _hitseq;}
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
		/// 决定EntityNum中内容的含义。默认0
        //0：所有货品。EntityNum中为空
        //1：EntityNum内容为 prodcode。 销售EntityNum中指定货品时，可以生效
        //2：EntityNum内容为 DepartCode。。 销售EntityNum中指定部门的货品时，可以生效
        //3：EntityNum内容为 TenderCode。 使用EntityNum中指定货币支付时，可以生效
		/// </summary>
		public int? EntityType
		{
			set{ _entitytype=value;}
			get{return _entitytype;}
		}
		#endregion Model

	}
}

