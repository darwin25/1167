using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// Promotion_H的子表。 促销命中条件表
	///（多个货品固定搭配的情况，可以用多条记录，之间用and关系关联（HitLogicalOpr=0））
	/// </summary>
	[Serializable]
	public partial class Promotion_Hit
	{
		public Promotion_Hit()
		{}
		#region Model
		private string _promotioncode;
		private int _hitseq;
		private int? _hitlogicalopr=0;
		private int? _hittype=0;
		private int? _hitvalue;
		private int? _hitop=1;
		private int? _hititem=0;
		/// <summary>
		/// 促销编码
		/// </summary>
		public string PromotionCode
		{
			set{ _promotioncode=value;}
			get{return _promotioncode;}
		}
		/// <summary>
		/// Hit条件序号
		/// </summary>
		public int HitSeq
		{
			set{ _hitseq=value;}
			get{return _hitseq;}
		}
		/// <summary>
		/// hit条件之间的逻辑关系。 默认0
        //0：and   1：or
		/// </summary>
		public int? HitLogicalOpr
		{
			set{ _hitlogicalopr=value;}
			get{return _hitlogicalopr;}
		}
		/// <summary>
		/// 命中类型：
        //0：无条件命中
        //1：数量。 
        //2：金额
		/// </summary>
		public int? HitType
		{
			set{ _hittype=value;}
			get{return _hittype;}
		}
		/// <summary>
		/// 根据HitType，填写金额或者数量。  只支持整数。
		/// </summary>
		public int? HitValue
		{
			set{ _hitvalue=value;}
			get{return _hitvalue;}
		}
		/// <summary>
		/// 命中关系操作符。默认1
        //0：没有操作符
        //1： =     （等于时， 如果金额大于此值，也符合条件）
        //2： <>
        //3： <=
        //4：>=
        //5：<
        //6：>
		/// </summary>
		public int? HitOP
		{
			set{ _hitop=value;}
			get{return _hitop;}
		}
		/// <summary>
		/// 命中货品条件。默认0
        //0：没有具体的货品条件，全场货品都参与。
        //1：Promotion_Hit_PLU中的任意货品合计。
        //2：Promotion_Hit_PLU中任意一个单独货品满足数量或者金额
        //3：Promotion_Hit_PLU中每一个货品都需要满足数量或者金额
        //4：Promotion_Hit_PLU中为支付类型条件。
		/// </summary>
		public int? HitItem
		{
			set{ _hititem=value;}
			get{return _hititem;}
		}
		#endregion Model

	}
}

