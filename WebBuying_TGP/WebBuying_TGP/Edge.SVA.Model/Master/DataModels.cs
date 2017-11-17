using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 送货员位置表
	/// </summary>
	[Serializable]
	public partial class DataModels
	{
		public DataModels()
		{}
		#region Model
		private int _datamodelid;
		private string _description;
		private string _definition;
		private DateTime? _createdon;
		private DateTime? _updatedon;
		private string _updatedby;
		/// <summary>
		/// 
		/// </summary>
		public int DataModelID
		{
			set{ _datamodelid=value;}
			get{return _datamodelid;}
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

