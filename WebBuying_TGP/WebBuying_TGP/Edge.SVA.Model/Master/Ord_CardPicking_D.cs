﻿using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡拣货单子表
	///表中brandID，cardtypeid，cardgradeid 关系不做校验，由UI在创建单据时做校验。
	///存储过程实际操作时，只按照CardGradeID来做。
	///（实际拣货首号码必须填，尾号码可以根据数量来计算，具体根据业务需求来做）
	/// </summary>
	[Serializable]
	public partial class Ord_CardPicking_D
	{
		public Ord_CardPicking_D()
		{}
		#region Model
		private int _keyid;
		private string _cardpickingnumber;
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
		public string CardPickingNumber
		{
			set{ _cardpickingnumber=value;}
			get{return _cardpickingnumber;}
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

