using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品同类分组表。（相同货品名称，不同货品code，不同颜色，不同尺寸）
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	///Pending表 @2016-08-08 (for bauhaus)
	/// </summary>
	[Serializable]
	public partial class BUY_PRODUCTSTYLE_Pending
	{
		public BUY_PRODUCTSTYLE_Pending()
		{}
		#region Model
		private string _prodcodestyle;
		private string _prodcode;
		private string _productsizetype;
		/// <summary>
		/// 货品系列编码，联合主键。（以prodcode作为主键，例如，同一系列不同颜色的口红，以第一个颜色的货品作为 productline 的主键，其他货品作为子货品。 主键货品也需要在子货品列表中）货品A系列： A1，A2，A3 StyleCode
		/// </summary> 
		public string ProdCodeStyle
		{
			set{ _prodcodestyle=value;}
			get{return _prodcodestyle;}
		}
		/// <summary>
		/// 货品编码，联合主键
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 此类商品使用的尺寸类型
		/// </summary>
		public string ProductSizeType
		{
			set{ _productsizetype=value;}
			get{return _productsizetype;}
		}
		#endregion Model

	}
}

