using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// kiosk调用，传入的LanguageCode 绑定名称字段的设置表
	/// </summary>
	[Serializable]
	public partial class LanguageMap
	{
		public LanguageMap()
		{}
		#region Model
		private int _keyid;
		private string _languageabbr;
		private int _descfieldno;
		private string _languagedesc;
		/// <summary>
		/// 
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 语言缩写，主键
		/// </summary>
		public string LanguageAbbr
		{
			set{ _languageabbr=value;}
			get{return _languageabbr;}
		}
		/// <summary>
		/// 获取CardTypeSN，CouponTypeSN的字段选择。
//1：获取CardTypeSN1，CouponTypeSN1
//2：获取CardTypeSN2，CouponTypeSN2
//3：获取CardTypeSN3，CouponTypeSN3
//else： 获取CardTypeSN1，CouponTypeSN1

		/// </summary>
		public int DescFieldNo
		{
			set{ _descfieldno=value;}
			get{return _descfieldno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LanguageDesc
		{
			set{ _languagedesc=value;}
			get{return _languagedesc;}
		}
		#endregion Model

	}
}

