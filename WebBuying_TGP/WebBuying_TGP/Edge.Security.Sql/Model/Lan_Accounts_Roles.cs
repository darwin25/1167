using System;
namespace Edge.Security.Model
{
	/// <summary>
	/// Lan_Accounts_Roles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Lan_Accounts_Roles
	{
		public Lan_Accounts_Roles()
		{}
		#region Model
		private int _roleid;
		private string _description;
		private string _lan;
		/// <summary>
		/// 
		/// </summary>
		public int RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
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
		public string Lan
		{
			set{ _lan=value;}
			get{return _lan;}
		}
		#endregion Model

	}
}

