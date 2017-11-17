using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 优惠信息表
	/// </summary>
	[Serializable]
	public partial class QuerySets
	{
		public QuerySets()
		{}
		#region Model
		private int _queryid;
		private int? _datamodelid;
		private string _querygroup;
		private string _description;
		private string _definition;
		private int? _changeparams;
		private int? _distinctquery;
		private DateTime? _createdon;
		private DateTime? _updatedon;
		private string _updatedby;
		/// <summary>
		/// 
		/// </summary>
		public int QueryID
		{
			set{ _queryid=value;}
			get{return _queryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DataModelID
		{
			set{ _datamodelid=value;}
			get{return _datamodelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QueryGroup
		{
			set{ _querygroup=value;}
			get{return _querygroup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Definition
		{
			set{ _definition=value;}
			get{return _definition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ChangeParams
		{
			set{ _changeparams=value;}
			get{return _changeparams;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DistinctQuery
		{
			set{ _distinctquery=value;}
			get{return _distinctquery;}
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
		public string UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

