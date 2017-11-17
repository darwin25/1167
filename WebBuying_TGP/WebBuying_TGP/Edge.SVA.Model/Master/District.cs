using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 区县资料表。（city下一级。中国第三级行政区，用于填写地址）
	/// </summary>
	[Serializable]
	public partial class District
	{
		public District()
		{}
		#region Model
		private string _districtcode;
		private string _citycode;
		private string _districtname1;
		private string _districtname2;
		private string _districtname3;
		/// <summary>
		/// 区县编码
		/// </summary>
		public string DistrictCode
		{
			set{ _districtcode=value;}
			get{return _districtcode;}
		}
		/// <summary>
		/// 上级市编码
		/// </summary>
		public string CityCode
		{
			set{ _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// 区县名称1
		/// </summary>
		public string DistrictName1
		{
			set{ _districtname1=value;}
			get{return _districtname1;}
		}
		/// <summary>
		/// 区县名称1
		/// </summary>
		public string DistrictName2
		{
			set{ _districtname2=value;}
			get{return _districtname2;}
		}
		/// <summary>
		/// 区县名称1
		/// </summary>
		public string DistrictName3
		{
			set{ _districtname3=value;}
			get{return _districtname3;}
		}
		#endregion Model

	}
}

