using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 国家资料表
	/// </summary>
	[Serializable]
	public partial class Country
	{
		public Country()
		{}
		#region Model
		private string _countrycode;
		private string _countryname1;
		private string _countryname2;
		private string _countryname3;
		/// <summary>
		/// 国家编码
		/// </summary>
		public string CountryCode
		{
			set{ _countrycode=value;}
			get{return _countrycode;}
		}
		/// <summary>
		/// 国家名称1
		/// </summary>
		public string CountryName1
		{
			set{ _countryname1=value;}
			get{return _countryname1;}
		}
		/// <summary>
		/// 国家名称2
		/// </summary>
		public string CountryName2
		{
			set{ _countryname2=value;}
			get{return _countryname2;}
		}
		/// <summary>
		/// 国家名称3
		/// </summary>
		public string CountryName3
		{
			set{ _countryname3=value;}
			get{return _countryname3;}
		}
		#endregion Model

	}
}

