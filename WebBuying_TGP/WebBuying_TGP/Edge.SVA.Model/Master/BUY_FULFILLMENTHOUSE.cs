using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 供货仓库表
	/// </summary>
	[Serializable]
	public partial class BUY_FULFILLMENTHOUSE
	{
		public BUY_FULFILLMENTHOUSE()
		{}
		#region Model
		private int _fulfillmenthouseid;
		private string _fulfillmenthousecode;
		private string _fulfillmenthousename1;
		private string _fulfillmenthousename2;
		private string _fulfillmenthousename3;
		private string _phone;
		private string _email;
		private int? _priority=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键ID
		/// </summary>
		public int FulfillmentHouseID
		{
			set{ _fulfillmenthouseid=value;}
			get{return _fulfillmenthouseid;}
		}
		/// <summary>
		///11 编码
		/// </summary>
		public string FulfillmentHouseCode
		{
			set{ _fulfillmenthousecode=value;}
			get{return _fulfillmenthousecode;}
		}
		/// <summary>
		///11 名称1
		/// </summary>
		public string FulfillmentHouseName1
		{
			set{ _fulfillmenthousename1=value;}
			get{return _fulfillmenthousename1;}
		}
		/// <summary>
		///11 名称2
		/// </summary>
		public string FulfillmentHouseName2
		{
			set{ _fulfillmenthousename2=value;}
			get{return _fulfillmenthousename2;}
		}
		/// <summary>
		///11 名称3
		/// </summary>
		public string FulfillmentHouseName3
		{
			set{ _fulfillmenthousename3=value;}
			get{return _fulfillmenthousename3;}
		}
		/// <summary>
		///11 电话
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		///11 电子邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		///11 优先标志。 1：优先。 0：普通
		/// </summary>
		public int? Priority
		{
			set{ _priority=value;}
			get{return _priority;}
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

