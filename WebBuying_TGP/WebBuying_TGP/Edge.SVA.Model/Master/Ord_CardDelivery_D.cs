using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡送货单子表
	///根据 Ord_CardPicking_D产生，过滤其中的实际拣货数量为0的记录。
	/// </summary>
	[Serializable]
	public partial class Ord_CardDelivery_D
	{
		public Ord_CardDelivery_D()
		{}
		#region Model
		private int _keyid;
		private string _carddeliverynumber;
		private int? _brandid;
		private int? _cardtypeid;
		private int? _cardgradeid;
		private string _description;
		private int? _orderqty;
		private int? _pickqty;
		private int? _actualqty;
		private string _firstcardnumber;
		private string _endcardnumber;
		/// <summary>
		/// 
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 订单编号，主键
		/// </summary>
		public string CardDeliveryNumber
		{
			set{ _carddeliverynumber=value;}
			get{return _carddeliverynumber;}
		}
		/// <summary>
		/// 品牌主键，外键
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 卡类型ID
		/// </summary>
		public int? CardTypeID
		{
			set{ _cardtypeid=value;}
			get{return _cardtypeid;}
		}
		/// <summary>
		/// 卡级别ID
		/// </summary>
		public int? CardGradeID
		{
			set{ _cardgradeid=value;}
			get{return _cardgradeid;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 订单数量
		/// </summary>
		public int? OrderQTY
		{
			set{ _orderqty=value;}
			get{return _orderqty;}
		}
		/// <summary>
		/// 要求拣货数量
		/// </summary>
		public int? PickQTY
		{
			set{ _pickqty=value;}
			get{return _pickqty;}
		}
		/// <summary>
		/// 实际拣货数量
		/// </summary>
		public int? ActualQTY
		{
			set{ _actualqty=value;}
			get{return _actualqty;}
		}
		/// <summary>
		/// 实际拣货批次的首卡号
		/// </summary>
		public string FirstCardNumber
		{
			set{ _firstcardnumber=value;}
			get{return _firstcardnumber;}
		}
		/// <summary>
		/// 实际拣货批次的末卡号
		/// </summary>
		public string EndCardNumber
		{
			set{ _endcardnumber=value;}
			get{return _endcardnumber;}
		}
		#endregion Model

	}
}

