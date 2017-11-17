using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺类型表
	/// </summary>
	[Serializable]
	public partial class StoreType
	{
		public StoreType()
		{}
		#region Model
		private int _storetypeid;
		private string _storetypename1;
		private string _storetypename2;
		private string _storetypename3;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _storetypecode;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int StoreTypeID
		{
			set{ _storetypeid=value;}
			get{return _storetypeid;}
		}
		/// <summary>
		/// 店铺类型名称1
		/// </summary>
		public string StoreTypeName1
		{
			set{ _storetypename1=value;}
			get{return _storetypename1;}
		}
		/// <summary>
		/// 店铺类型名称2
		/// </summary>
		public string StoreTypeName2
		{
			set{ _storetypename2=value;}
			get{return _storetypename2;}
		}
		/// <summary>
		/// 店铺类型名称3
		/// </summary>
		public string StoreTypeName3
		{
			set{ _storetypename3=value;}
			get{return _storetypename3;}
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
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
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
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreTypeCode
		{
			set{ _storetypecode=value;}
			get{return _storetypecode;}
		}
		#endregion Model

	}
}

