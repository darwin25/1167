using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 混配促销明细表
	/// </summary>
	[Serializable]
	public partial class BUY_MNM_D
	{
		public BUY_MNM_D()
		{}
		#region Model
		private int _keyid;
		private string _mnmcode;
		private string _entitynum;
		private int _entitytype;
		private int? _type=0;
		private int? _qty=0;
		/// <summary>
		///11 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		///11 混配促销编码
		/// </summary>
		public string MNMCode
		{
			set{ _mnmcode=value;}
			get{return _mnmcode;}
		}
		/// <summary>
		///11 号码
		/// </summary>
		public string EntityNum
		{
			set{ _entitynum=value;}
			get{return _entitynum;}
		}
		/// <summary>
		///11 决定EntityNum中内容的含义。
		///0：所有货品。EntityNum中为空
		///1：EntityNum内容为 prodcode。 销售EntityNum中指定货品时，可以生效
		///2：EntityNum内容为 DepartCode。。 销售EntityNum中指定部门的货品时，可以生效
		///3：EntityNum内容为 TenderCode。 使用EntityNum中指定货币支付时，可以生效
		/// </summary>
		public int EntityType
		{
			set{ _entitytype=value;}
			get{return _entitytype;}
		}
		/// <summary>
		///11 EntityNum所指货品的类型。
		///0: Hit
		///1: Gift
		///2: Hit&Gift
		/// </summary>
		public int? Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		///11 货品数量
		/// </summary>
		public int? Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		#endregion Model

	}
}

