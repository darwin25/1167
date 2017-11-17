using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 卡消费赚积分规则表
	/// </summary>
	[Serializable]
	public partial class Position
	{
		public Position()
		{}
		#region Model
		private int _id;
		private string _namesn1;
		private string _namesn2;
		private string _namesn3;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NameSN1
		{
			set{ _namesn1=value;}
			get{return _namesn1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NameSN2
		{
			set{ _namesn2=value;}
			get{return _namesn2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NameSN3
		{
			set{ _namesn3=value;}
			get{return _namesn3;}
		}
		#endregion Model

	}
}

