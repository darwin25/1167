using System;
namespace Edge.SVA.Model
{
	/// <summary>
    /// 创建人:Lisa
    /// 创建时间：2016-02-25
	/// 性别表。（基础表，不需要维护）
	/// </summary>
	[Serializable]
	public partial class Gender
	{
		public Gender()
		{}
		#region Model
		private int _genderid;
		private string _gendercode;
		private string _genderdesc1;
		private string _genderdesc2;
		private string _genderdesc3;
		/// <summary>
		/// 主键
		/// </summary>
		public int GenderID
		{
			set{ _genderid=value;}
			get{return _genderid;}
		}
		/// <summary>
		/// 编码
		/// </summary>
		public string GenderCode
		{
			set{ _gendercode=value;}
			get{return _gendercode;}
		}
		/// <summary>
		/// 描述1
		/// </summary>
		public string GenderDesc1
		{
			set{ _genderdesc1=value;}
			get{return _genderdesc1;}
		}
		/// <summary>
		/// 描述2
		/// </summary>
		public string GenderDesc2
		{
			set{ _genderdesc2=value;}
			get{return _genderdesc2;}
		}
		/// <summary>
		/// 描述3
		/// </summary>
		public string GenderDesc3
		{
			set{ _genderdesc3=value;}
			get{return _genderdesc3;}
		}
		#endregion Model

	}
}

