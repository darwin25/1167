using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// @2016-12-14 @Gavin
	///用户product变更表。  每次操作后清空。
	///status暂时没用。  如果需要批核的话就启用。
	///设置的字段，如果是null，则不更新。 如果有值则更新。 （同理，读入的文件中没有填写则不更新）
	/// </summary>
	[Serializable]
	public partial class ProductModifyTemp
	{
		public ProductModifyTemp()
		{}
		#region Model
		private string _prodcode;
		private int? _isonlinesku;
		private int? _feature;
		private int? _hotsale;
		private decimal? _price;
		private decimal? _refprice;
		private int? _status;
		private DateTime? _createdon= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 0:  下架。  1：上架
		/// </summary>
		public int? IsOnlineSKU
		{
			set{ _isonlinesku=value;}
			get{return _isonlinesku;}
		}
		/// <summary>
		/// 推荐标志 （Flag1）
		/// </summary>
		public int? Feature
		{
			set{ _feature=value;}
			get{return _feature;}
		}
		/// <summary>
		/// 热卖标志
		/// </summary>
		public int? HotSale
		{
			set{ _hotsale=value;}
			get{return _hotsale;}
		}
		/// <summary>
		/// 实际销售价格
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 指导价格
		/// </summary>
		public decimal? RefPrice
		{
			set{ _refprice=value;}
			get{return _refprice;}
		}
		/// <summary>
		/// 状态。 0：未审核。1：已审核。2：已经更新。-1：作废。  此字段预留，未使用
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		#endregion Model

	}
}

