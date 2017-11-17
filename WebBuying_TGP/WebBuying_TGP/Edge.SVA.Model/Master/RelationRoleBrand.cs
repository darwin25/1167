using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// RelationRoleBrand:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RelationRoleBrand
	{
		public RelationRoleBrand()
		{}
		#region Model
		private int _roleid;
		private int _brandid;
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
		public int BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		#endregion Model

	}
}

