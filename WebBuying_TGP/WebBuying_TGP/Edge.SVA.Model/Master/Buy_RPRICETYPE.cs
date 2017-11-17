using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 零售价类型表
	/// </summary>
	[Serializable]
	public partial class BUY_RPRICETYPE
	{
		public BUY_RPRICETYPE()
		{}
		#region Model
		private int _rpricetypeid;
		private string _rpricetypecode;
		private string _rpricetypename1;
		private string _rpricetypename2;
		private string _rpricetypename3;
		private int _additionaltype=0;
		private int _supervisor=0;
		private int _serialno=0;
		private int _discount=0;
		private int _typelevel=0;
		private int _membership=0;
		private string _stocktypecode="G";
		private int _ranonly=0;
		private int _damonly=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键ID
		/// </summary>
		public int RPriceTypeID
		{
			set{ _rpricetypeid=value;}
			get{return _rpricetypeid;}
		}
		/// <summary>
		///11 零售价类型编码
		/// </summary>
		public string RPriceTypeCode
		{
			set{ _rpricetypecode=value;}
			get{return _rpricetypecode;}
		}
		/// <summary>
		///11 零售价类型名称1
		/// </summary>
		public string RPriceTypeName1
		{
			set{ _rpricetypename1=value;}
			get{return _rpricetypename1;}
		}
		/// <summary>
		///11 零售价类型名称1
		/// </summary>
		public string RPriceTypeName2
		{
			set{ _rpricetypename2=value;}
			get{return _rpricetypename2;}
		}
		/// <summary>
		///11 零售价类型名称1
		/// </summary>
		public string RPriceTypeName3
		{
			set{ _rpricetypename3=value;}
			get{return _rpricetypename3;}
		}
		/// <summary>
		///11 未定义
		/// </summary>
		public int AdditionalType
		{
			set{ _additionaltype=value;}
			get{return _additionaltype;}
		}
		/// <summary>
		///11 是否需要管理员登录。0：不需要。1需要
		/// </summary>
		public int Supervisor
		{
			set{ _supervisor=value;}
			get{return _supervisor;}
		}
		/// <summary>
		///11 是否需要输入serialno。0：不需要。1需要
		/// </summary>
		public int SerialNo
		{
			set{ _serialno=value;}
			get{return _serialno;}
		}
		/// <summary>
		///11 是否折扣标志。0：不是。1：是
		/// </summary>
		public int Discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		///11 类型级别
		/// </summary>
		public int TypeLevel
		{
			set{ _typelevel=value;}
			get{return _typelevel;}
		}
		/// <summary>
		///11 是否用于会员。0：不是。1：是
		/// </summary>
		public int MemberShip
		{
			set{ _membership=value;}
			get{return _membership;}
		}
		/// <summary>
		///11 库存类型code。
		/// </summary>
		public string StockTypeCode
		{
			set{ _stocktypecode=value;}
			get{return _stocktypecode;}
		}
		/// <summary>
		///11 是否用于RAN货品。0：不是。1：是
		/// </summary>
		public int RANOnly
		{
			set{ _ranonly=value;}
			get{return _ranonly;}
		}
		/// <summary>
		///11 是否用于损坏货品。0：不是。1：是
		/// </summary>
		public int DAMOnly
		{
			set{ _damonly=value;}
			get{return _damonly;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

