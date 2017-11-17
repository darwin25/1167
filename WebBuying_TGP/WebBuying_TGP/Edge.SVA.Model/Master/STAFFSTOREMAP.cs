using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// Ա�����̹�������POS��¼�ã�
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
		/// Ա��������
		/// </summary>
		public int StaffID
		{
			set{ _staffid=value;}
			get{return _staffid;}
		}
		/// <summary>
		/// ���̱�����
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