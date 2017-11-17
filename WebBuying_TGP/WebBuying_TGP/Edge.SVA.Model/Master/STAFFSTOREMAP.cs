using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 员工店铺关联表。（POS登录用）
	/// </summary>
	[Serializable]
	public partial class STAFFSTOREMAP
	{
		public STAFFSTOREMAP()
		{}
		#region Model
		private int _staffid;
		private int _storeid;
        private DateTime? _createdon = DateTime.Now;
        private int? _createdby;
        private DateTime? _updatedon = DateTime.Now;
        private int? _updatedby;
		/// <summary>
		/// 员工表主键
		/// </summary>
		public int StaffID
		{
			set{ _staffid=value;}
			get{return _staffid;}
		}
		/// <summary>
		/// 店铺表主键
		/// </summary>
		public int StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedOn
        {
            set { _createdon = value; }
            get { return _createdon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreatedBy
        {
            set { _createdby = value; }
            get { return _createdby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdatedOn
        {
            set { _updatedon = value; }
            get { return _updatedon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UpdatedBy
        {
            set { _updatedby = value; }
            get { return _updatedby; }
        }
		#endregion Model

	}
}