using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 内部材质。  for Bauhaus
    /// 创建人:Lisa
    /// 创建时间：2016-02-25
	/// </summary>
	[Serializable]
	public partial class MATERIAL_IN
	{
		public MATERIAL_IN()
		{}
		#region Model
		private int _materialid;
		private string _materialcode;
		private string _materialname1;
		private string _materialname2;
		private string _materialname3;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int MATERIALID
		{
			set{ _materialid=value;}
			get{return _materialid;}
		}
		/// <summary>
		/// 季节编码
		/// </summary>
		public string MATERIALCode
		{
			set{ _materialcode=value;}
			get{return _materialcode;}
		}
		/// <summary>
		/// 名称1
		/// </summary>
		public string MATERIALName1
		{
			set{ _materialname1=value;}
			get{return _materialname1;}
		}
		/// <summary>
		/// 名称2
		/// </summary>
		public string MATERIALName2
		{
			set{ _materialname2=value;}
			get{return _materialname2;}
		}
		/// <summary>
		/// 名称3
		/// </summary>
		public string MATERIALName3
		{
			set{ _materialname3=value;}
			get{return _materialname3;}
		}
		#endregion Model

	}
}

