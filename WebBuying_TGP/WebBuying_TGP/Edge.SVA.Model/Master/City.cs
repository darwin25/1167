using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 市资料表。（省下一级，中国第二级行政区，用于填写地址）
	/// </summary>
	[Serializable]
	public partial class City
	{
		public City()
		{}
		#region Model
		private string _citycode;
		private string _provincecode;
		private string _cityname1;
		private string _cityname2;
		private string _cityname3;
		/// <summary>
		/// 城市编码
		/// </summary>
		public string CityCode
		{
			set{ _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// 省编码
		/// </summary>
		public string ProvinceCode
		{
			set{ _provincecode=value;}
			get{return _provincecode;}
		}
		/// <summary>
		/// 城市名称1
		/// </summary>
		public string CityName1
		{
			set{ _cityname1=value;}
			get{return _cityname1;}
		}
		/// <summary>
		/// 城市名称2
		/// </summary>
		public string CityName2
		{
			set{ _cityname2=value;}
			get{return _cityname2;}
		}
		/// <summary>
		/// 城市名称3
		/// </summary>
		public string CityName3
		{
			set{ _cityname3=value;}
			get{return _cityname3;}
		}
		#endregion Model

	}
}

