using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 店铺组
	/// </summary>
	[Serializable]
	public partial class StoreGroup
	{
		public StoreGroup()
		{}
		#region Model
		private int _storegroupid;
		private string _storegroupname1;
		private string _storegroupname2;
		private string _storegroupname3;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _storegroupcode;
		/// <summary>
		/// 店铺组ID。
		/// </summary>
		public int StoreGroupID
		{
			set{ _storegroupid=value;}
			get{return _storegroupid;}
		}
		/// <summary>
		/// 店铺组名字
		/// </summary>
		public string StoreGroupName1
		{
			set{ _storegroupname1=value;}
			get{return _storegroupname1;}
		}
		/// <summary>
		/// 店铺组名字
		/// </summary>
		public string StoreGroupName2
		{
			set{ _storegroupname2=value;}
			get{return _storegroupname2;}
		}
		/// <summary>
		/// 店铺组名字
		/// </summary>
		public string StoreGroupName3
		{
			set{ _storegroupname3=value;}
			get{return _storegroupname3;}
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
		public string StoreGroupCode
		{
			set{ _storegroupcode=value;}
			get{return _storegroupcode;}
		}
		#endregion Model

	}
}

