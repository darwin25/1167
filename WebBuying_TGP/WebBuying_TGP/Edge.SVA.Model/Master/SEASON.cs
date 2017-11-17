using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 季节。  for Bauhaus
    /// 创建人:Lisa
    /// 创建时间：2016-02-25
	/// </summary>
	[Serializable]
	public partial class SEASON
	{
		public SEASON()
		{}
		#region Model
		private int _seasonid;
		private string _seasoncode;
        private string _seasonname2;
        private string _seasonname3;
        private string _seasonname1;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int SeasonID
		{
			set{ _seasonid=value;}
			get{return _seasonid;}
		}
		/// <summary>
		/// 季节编码
		/// </summary>
		public string SeasonCode
		{
			set{ _seasoncode=value;}
			get{return _seasoncode;}
		}
		/// <summary>
		/// 名称2
		/// </summary>
        public string SeasonName2
		{
            set { _seasonname2 = value; }
            get { return _seasonname2; }
		}
		/// <summary>
		/// 名称3
		/// </summary>
        public string SeasonName3
		{
            set { _seasonname3 = value; }
            get { return _seasonname3; }
		}
		/// <summary>
		/// 名称1
		/// </summary>
        public string SeasonName1
		{
            set { _seasonname1 = value; }
            get { return _seasonname1; }
		}
		#endregion Model

	}
}

