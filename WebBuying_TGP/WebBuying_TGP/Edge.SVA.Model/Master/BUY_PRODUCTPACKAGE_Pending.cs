using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品包装设置。（销售单位）
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	///Pending表 @2016-08-08 (for bauhaus)
	/// </summary>
	[Serializable]
	public partial class BUY_PRODUCTPACKAGE_Pending
	{
		public BUY_PRODUCTPACKAGE_Pending()
		{}
		#region Model
		private int _packagesizeid;
		private string _packagesizecode;
		private string _packagesizedesc1;
		private string _packagesizedesc2;
		private string _packagesizedesc3;
		private int? _packagesizetype;
		private string _packagesizeunit;
		private int? _packagesizeqty;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int PackageSizeID
		{
			set{ _packagesizeid=value;}
			get{return _packagesizeid;}
		}
		/// <summary>
		/// 包装编码
		/// </summary>
		public string PackageSizeCode
		{
			set{ _packagesizecode=value;}
			get{return _packagesizecode;}
		}
		/// <summary>
		/// 包装描述1
		/// </summary>
		public string PackageSizeDesc1
		{
			set{ _packagesizedesc1=value;}
			get{return _packagesizedesc1;}
		}
		/// <summary>
		/// 包装描述2
		/// </summary>
		public string PackageSizeDesc2
		{
			set{ _packagesizedesc2=value;}
			get{return _packagesizedesc2;}
		}
		/// <summary>
		/// 包装描述3
		/// </summary>
		public string PackageSizeDesc3
		{
			set{ _packagesizedesc3=value;}
			get{return _packagesizedesc3;}
		}
		/// <summary>
		/// 包装货品类型
		/// </summary>
		public int? PackageSizeType
		{
			set{ _packagesizetype=value;}
			get{return _packagesizetype;}
		}
		/// <summary>
		/// 包装单位
		/// </summary>
		public string PackageSizeUnit
		{
			set{ _packagesizeunit=value;}
			get{return _packagesizeunit;}
		}
		/// <summary>
		/// 包装单位数量
		/// </summary>
		public int? PackageSizeQty
		{
			set{ _packagesizeqty=value;}
			get{return _packagesizeqty;}
		}
		#endregion Model

	}
}

