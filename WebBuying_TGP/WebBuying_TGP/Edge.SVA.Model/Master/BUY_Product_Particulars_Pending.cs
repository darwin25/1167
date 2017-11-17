using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品细节描述。（分语言）
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	///Pending表 @2016-08-08 (for bauhaus)
	/// </summary>
	[Serializable]
	public partial class BUY_Product_Particulars_Pending
	{
		public BUY_Product_Particulars_Pending()
		{}
		#region Model
		private string _prodcode;
		private int _languageid=1;
		private string _prodfunction;
		private string _prodingredients;
		private string _prodinstructions;
		private string _packdesc;
		private string _packunit;
		private string _memo1;
		private string _memo2;
		private string _memo3;
		private string _memo4;
		private string _memo5;
		private string _memo6;
		private string _memotitle1;
		private string _memotitle2;
		private string _memotitle3;
		private string _memotitle4;
		private string _memotitle5;
		private string _memotitle6;
		private int? _productpriority=0;
		/// <summary>
		/// 货品主键
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// LanguageMap主键ID. 默认1，LanguageMap中第一条记录，母语
		/// </summary>
		public int LanguageID
		{
			set{ _languageid=value;}
			get{return _languageid;}
		}
		/// <summary>
		/// 产品功能描述
		/// </summary>
		public string ProdFunction
		{
			set{ _prodfunction=value;}
			get{return _prodfunction;}
		}
		/// <summary>
		/// 产品成分描述
		/// </summary>
		public string ProdIngredients
		{
			set{ _prodingredients=value;}
			get{return _prodingredients;}
		}
		/// <summary>
		/// 产品使用说明
		/// </summary>
		public string ProdInstructions
		{
			set{ _prodinstructions=value;}
			get{return _prodinstructions;}
		}
		/// <summary>
		/// 销售包装描述  （eg. 100ml/瓶）
		/// </summary>
		public string PackDesc
		{
			set{ _packdesc=value;}
			get{return _packdesc;}
		}
		/// <summary>
		/// 销售包装单位 （eg. ml）
		/// </summary>
		public string PackUnit
		{
			set{ _packunit=value;}
			get{return _packunit;}
		}
		/// <summary>
		/// 货品扩展属性1
		/// </summary>
		public string Memo1
		{
			set{ _memo1=value;}
			get{return _memo1;}
		}
		/// <summary>
		/// 货品扩展属性2
		/// </summary>
		public string Memo2
		{
			set{ _memo2=value;}
			get{return _memo2;}
		}
		/// <summary>
		/// 货品扩展属性3
		/// </summary>
		public string Memo3
		{
			set{ _memo3=value;}
			get{return _memo3;}
		}
		/// <summary>
		/// 货品扩展属性4
		/// </summary>
		public string Memo4
		{
			set{ _memo4=value;}
			get{return _memo4;}
		}
		/// <summary>
		/// 货品扩展属性5
		/// </summary>
		public string Memo5
		{
			set{ _memo5=value;}
			get{return _memo5;}
		}
		/// <summary>
		/// 货品扩展属性6
		/// </summary>
		public string Memo6
		{
			set{ _memo6=value;}
			get{return _memo6;}
		}
		/// <summary>
		/// 货品扩展属性标题1
		/// </summary>
		public string MemoTitle1
		{
			set{ _memotitle1=value;}
			get{return _memotitle1;}
		}
		/// <summary>
		/// 货品扩展属性标题2
		/// </summary>
		public string MemoTitle2
		{
			set{ _memotitle2=value;}
			get{return _memotitle2;}
		}
		/// <summary>
		/// 货品扩展属性标题3
		/// </summary>
		public string MemoTitle3
		{
			set{ _memotitle3=value;}
			get{return _memotitle3;}
		}
		/// <summary>
		/// 货品扩展属性标题4
		/// </summary>
		public string MemoTitle4
		{
			set{ _memotitle4=value;}
			get{return _memotitle4;}
		}
		/// <summary>
		/// 货品扩展属性标题5
		/// </summary>
		public string MemoTitle5
		{
			set{ _memotitle5=value;}
			get{return _memotitle5;}
		}
		/// <summary>
		/// 货品扩展属性标题6
		/// </summary>
		public string MemoTitle6
		{
			set{ _memotitle6=value;}
			get{return _memotitle6;}
		}
		/// <summary>
		/// 货品显示排序优先级。（默认0， 从0开始依次升高）
		/// </summary>
		public int? ProductPriority
		{
			set{ _productpriority=value;}
			get{return _productpriority;}
		}
		#endregion Model

	}
}

