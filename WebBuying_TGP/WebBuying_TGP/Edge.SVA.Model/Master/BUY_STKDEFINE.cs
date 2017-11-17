using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 库存盘点定义
	/// </summary>
	[Serializable]
	public partial class BUY_STKDEFINE
	{
		public BUY_STKDEFINE()
		{}
		#region Model
		private int _keyid;
		private string _stkdefinecode;
		private string _storecode;
		private string _deptcode;
		private int _status=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		///11 编号
		/// </summary>
		public string STKDefineCode
		{
			set{ _stkdefinecode=value;}
			get{return _stkdefinecode;}
		}
		/// <summary>
		///11 店铺编号
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		///11 部门编号
		/// </summary>
		public string DeptCode
		{
			set{ _deptcode=value;}
			get{return _deptcode;}
		}
		/// <summary>
		///11 状态。 0：无效，1：有效。
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		///11 创建时间
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 创建人
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 修改时间
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 修改人
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

