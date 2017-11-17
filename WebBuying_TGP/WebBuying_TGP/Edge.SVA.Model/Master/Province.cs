using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 省资料表。（中国一级行政区，用于填写地址）
	/// </summary>
	[Serializable]
	public partial class Province
	{
		public Province()
		{}
		#region Model
		private string _provincecode;
		private string _countrycode;
		private string _provincename1;
		private string _provincename2;
		private string _provincename3;
		/// <summary>
		/// 省编码
		/// </summary>
		public string ProvinceCode
		{
			set{ _provincecode=value;}
			get{return _provincecode;}
		}
		/// <summary>
		/// 国家编码
		/// </summary>
		public string CountryCode
		{
			set{ _countrycode=value;}
			get{return _countrycode;}
		}
		/// <summary>
		/// 省名称1
		/// </summary>
		public string ProvinceName1
		{
			set{ _provincename1=value;}
			get{return _provincename1;}
		}
		/// <summary>
		/// 省名称2
		/// </summary>
		public string ProvinceName2
		{
			set{ _provincename2=value;}
			get{return _provincename2;}
		}
		/// <summary>
		/// 省名称3
		/// </summary>
		public string ProvinceName3
		{
			set{ _provincename3=value;}
			get{return _provincename3;}
		}
		#endregion Model

	}
}

