using System;
namespace Edge.Security.Model
{
	/// <summary>
	/// Lan_List:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Lan_List
	{
		public Lan_List()
		{}
		#region Model
		private int _id;
		private string _lan;
        private string _lanDesc;
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
		public string Lan
		{
			set{ _lan=value;}
			get{return _lan;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string LanDesc
        {
            set { _lanDesc = value; }
            get { return _lanDesc; }
        }
		#endregion Model

	}
}

