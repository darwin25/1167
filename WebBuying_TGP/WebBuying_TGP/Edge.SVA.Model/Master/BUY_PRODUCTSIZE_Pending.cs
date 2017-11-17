using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 产品尺寸属性。
	///Pending表 @2016-08-08 (for bauhaus)
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	[Serializable]
	public partial class BUY_PRODUCTSIZE_Pending
	{
		public BUY_PRODUCTSIZE_Pending()
		{}
		#region Model
		private int _productsizeid;
		private string _productsizecode;
		private string _productsizetype;
		private string _productsizename1;
		private string _productsizename2;
		private string _productsizename3;
		private string _productsizenote;
		/// <summary>
		/// 货品尺寸主键ID
		/// </summary>
		public int ProductSizeID
		{
			set{ _productsizeid=value;}
			get{return _productsizeid;}
		}
		/// <summary>
		/// 货品尺寸Code
		/// </summary>
		public string ProductSizeCode
		{
			set{ _productsizecode=value;}
			get{return _productsizecode;}
		}
		/// <summary>
		/// 货品尺寸类型
		/// </summary>
		public string ProductSizeType
		{
			set{ _productsizetype=value;}
			get{return _productsizetype;}
		}
		/// <summary>
		/// 货品尺寸名称1
		/// </summary>
		public string ProductSizeName1
		{
			set{ _productsizename1=value;}
			get{return _productsizename1;}
		}
		/// <summary>
		/// 货品尺寸名称2
		/// </summary>
		public string ProductSizeName2
		{
			set{ _productsizename2=value;}
			get{return _productsizename2;}
		}
		/// <summary>
		/// 货品尺寸名称3
		/// </summary>
		public string ProductSizeName3
		{
			set{ _productsizename3=value;}
			get{return _productsizename3;}
		}
		/// <summary>
		/// 货品尺寸备注
		/// </summary>
		public string ProductSizeNote
		{
			set{ _productsizenote=value;}
			get{return _productsizenote;}
		}
		#endregion Model

	}
}

