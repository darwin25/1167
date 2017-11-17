using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 折扣设置表. （手动折扣）
	/// </summary>
	[Serializable]
	public partial class BUY_DISCOUNT
	{
		public BUY_DISCOUNT()
		{}
		#region Model
        private int _discountId;
		private string _discountcode;
		private string _reasoncode;
		private string _description1;
		private string _description2;
		private string _description3;
		private int? _disctype=0;
		private int? _salesdisclevel=0;
		private decimal? _discprice;
		private int? _authlevel=0;
		private int? _allowdiscondisc=0;
		private int? _allowchgdisc=0;
		private int? _transdisccontrol=0;
		private int? _status=1;
		private string _note;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键
		/// </summary>
        public int DiscountId
        {
            get { return _discountId; }
            set { _discountId = value; }
        }
		/// <summary>
		///11 折扣编码
		/// </summary>
		public string DiscountCode
		{
			set{ _discountcode=value;}
			get{return _discountcode;}
		}
		/// <summary>
		///11 原因编码
		/// </summary>
		public string ReasonCode
		{
			set{ _reasoncode=value;}
			get{return _reasoncode;}
		}
		/// <summary>
		///11 折扣描述1
		/// </summary>
		public string Description1
		{
			set{ _description1=value;}
			get{return _description1;}
		}
		/// <summary>
		///11 折扣描述2
		/// </summary>
		public string Description2
		{
			set{ _description2=value;}
			get{return _description2;}
		}
		/// <summary>
		///11 折扣描述3
		/// </summary>
		public string Description3
		{
			set{ _description3=value;}
			get{return _description3;}
		}
		/// <summary>
		///11 折扣类型。决定DiscPrice的含义。
		///0： item $ off;    
		///1： item % off
		///2： trans $ off;   
		///3： trans % off
		///4： price markdown （减价）
		///
		///
		/// </summary>
		public int? DiscType
		{
			set{ _disctype=value;}
			get{return _disctype;}
		}
		/// <summary>
		///11 折扣优先级。默认0.  0最低， 数字越大，优先级越高
		/// </summary>
		public int? SalesDiscLevel
		{
			set{ _salesdisclevel=value;}
			get{return _salesdisclevel;}
		}
		/// <summary>
		///11 折扣值。
		/// </summary>
		public decimal? DiscPrice
		{
			set{ _discprice=value;}
			get{return _discprice;}
		}
		/// <summary>
		///11 权限设置。0：没有权限要求。1：管理员权限。 2：经理权限。 默认0
		/// </summary>
		public int? AuthLevel
		{
			set{ _authlevel=value;}
			get{return _authlevel;}
		}
		/// <summary>
		///11 是否允许折上折。 0：不允许。1：允许。默认0
		/// </summary>
		public int? AllowDiscOnDisc
		{
			set{ _allowdiscondisc=value;}
			get{return _allowdiscondisc;}
		}
		/// <summary>
		///11 是否允许变动折扣值。0：不允许。1：允许（此时DiscPrice为最大限制值）。默认0
		/// </summary>
		public int? AllowChgDisc
		{
			set{ _allowchgdisc=value;}
			get{return _allowchgdisc;}
		}
		/// <summary>
		///11 整单折扣控制.
		///0：不允许用于整单折扣，只允许单个货品折扣。
		///1：允许用于整单折扣，在每个货品的Netprice基础上计算。（货品的netprice可以包括单个折扣）
		///2：允许用于整单折扣，如果货品上已经有折扣，则跳过此货品记录分摊。
		/// </summary>
		public int? TransDiscControl
		{
			set{ _transdisccontrol=value;}
			get{return _transdisccontrol;}
		}
		/// <summary>
		///11 状态。0：无效。1：有效
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		///11 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		///11 创建时间
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 创建人
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

