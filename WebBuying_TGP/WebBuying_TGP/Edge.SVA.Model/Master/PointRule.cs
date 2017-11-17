using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡消费赚积分规则表
	/// </summary>
	[Serializable]
	public partial class PointRule
	{
		public PointRule()
		{}
		#region Model
		private int _pointruleid;
		private int? _cardtypeid;
		private int? _cardgradeid;
		private int _pointruleseqno=0;
		private int _pointruleoper;
		private decimal _pointruleamount;
		private int _pointrulepoints;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private DateTime? _createdon= DateTime.Now;
		private DateTime? _updatedon= DateTime.Now;
		private int? _createdby;
		private int? _updatedby;
		/// <summary>
		/// 设置规则主键
		/// </summary>
		public int PointRuleID
		{
			set{ _pointruleid=value;}
			get{return _pointruleid;}
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
		/// 卡等级ID
		/// </summary>
		public int? CardGradeID
		{
			set{ _cardgradeid=value;}
			get{return _cardgradeid;}
		}
		/// <summary>
		/// 记录序号
		/// </summary>
		public int PointRuleSeqNo
		{
			set{ _pointruleseqno=value;}
			get{return _pointruleseqno;}
		}
		/// <summary>
		/// 计算方式设置：0：每当消费PointRuleAmount指定的金额，就能获得PointRulePoints指定的积分。  如：PointRuleAmount=100，PointRulePoints=10， 消费2000， 就可以获得 （2000 /100 ）* 10 = 200
       ///1：当消费金额大于等于PointRuleAmount指定的金额，就能获得PointRulePoints指定的积分
       ///2：当消费金额小于等于PointRuleAmount指定的金额，就能获得PointRulePoints指定的积分

		/// </summary>
		public int PointRuleOper
		{
			set{ _pointruleoper=value;}
			get{return _pointruleoper;}
		}
		/// <summary>
		/// 设定的积分规则金额
		/// </summary>
		public decimal PointRuleAmount
		{
			set{ _pointruleamount=value;}
			get{return _pointruleamount;}
		}
		/// <summary>
		/// 设定的积分规则积分
		/// </summary>
		public int PointRulePoints
		{
			set{ _pointrulepoints=value;}
			get{return _pointrulepoints;}
		}
		/// <summary>
		/// 开始日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 结束日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

