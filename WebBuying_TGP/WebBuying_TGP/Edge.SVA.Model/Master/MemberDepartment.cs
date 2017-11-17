using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 会员部门表
	/// </summary>
	[Serializable]
	public partial class MemberDepartment
	{
		public MemberDepartment()
		{}
		#region Model
		private int _keyid;
		private string _deptcode;
		private string _deptdesc;
		private string _deptphone;
		private string _deptaddress;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 部门编号
		/// </summary>
		public string DeptCode
		{
			set{ _deptcode=value;}
			get{return _deptcode;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string DeptDesc
		{
			set{ _deptdesc=value;}
			get{return _deptdesc;}
		}
		/// <summary>
		/// 部门电话
		/// </summary>
		public string DeptPhone
		{
			set{ _deptphone=value;}
			get{return _deptphone;}
		}
		/// <summary>
		/// 部门地址
		/// </summary>
		public string DeptAddress
		{
			set{ _deptaddress=value;}
			get{return _deptaddress;}
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
		#endregion Model

	}
}

