using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 区域
	/// </summary>
	[Serializable]
	public partial class Location
	{
		public Location()
		{}
		#region Model
		private int _locationid;
		private int? _parentloactionid;
		private string _locationname1;
		private string _locationname2;
		private string _locationname3;
		private int? _locationtype;
		private string _lotitude;
		private string _longitude;
		private int? _status=1;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _locationfullpath;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int LocationID
		{
			set{ _locationid=value;}
			get{return _locationid;}
		}
		/// <summary>
		/// 父的主键ID
		/// </summary>
		public int? ParentLoactionID
		{
			set{ _parentloactionid=value;}
			get{return _parentloactionid;}
		}
		/// <summary>
		/// 区域名称1
		/// </summary>
		public string LocationName1
		{
			set{ _locationname1=value;}
			get{return _locationname1;}
		}
		/// <summary>
		/// 区域名称2
		/// </summary>
		public string LocationName2
		{
			set{ _locationname2=value;}
			get{return _locationname2;}
		}
		/// <summary>
		/// 区域名称3
		/// </summary>
		public string LocationName3
		{
			set{ _locationname3=value;}
			get{return _locationname3;}
		}
		/// <summary>
		/// 区域类型：1：城市。2：区。3：商业中心
		/// </summary>
		public int? LocationType
		{
			set{ _locationtype=value;}
			get{return _locationtype;}
		}
		/// <summary>
		/// 纬度
		/// </summary>
		public string Lotitude
		{
			set{ _lotitude=value;}
			get{return _lotitude;}
		}
		/// <summary>
		/// 经度
		/// </summary>
		public string Longitude
		{
			set{ _longitude=value;}
			get{return _longitude;}
		}
		/// <summary>
		/// 状态。0：无效。1：有效
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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
		public string LocationFullPath
		{
			set{ _locationfullpath=value;}
			get{return _locationfullpath;}
		}
		#endregion Model

	}
}

