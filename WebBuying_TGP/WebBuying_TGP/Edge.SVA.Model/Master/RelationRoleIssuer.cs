using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// RelationRoleIssuer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RelationRoleIssuer
	{
		public RelationRoleIssuer()
		{}
		#region Model
		private int _roleid;
		private int _cardissuerid;
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
		public int CardIssuerID
		{
			set{ _cardissuerid=value;}
			get{return _cardissuerid;}
		}
		#endregion Model

	}
}

