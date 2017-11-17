using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 货品barcode，prodcode对照表。
	/// </summary>
	[Serializable]
	public partial class BUY_BARCODE
	{
		public BUY_BARCODE()
		{}
		#region Model
		private string _barcode;
		private string _prodcode;
		private int? _internalbarcode=1;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键，条码
		/// </summary>
		public string Barcode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		///11 货品编码。
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		///11 是否内部barcode。 0：外部导入的。1: 是内部的。默认1。
		/// </summary>
		public int? InternalBarcode
		{
			set{ _internalbarcode=value;}
			get{return _internalbarcode;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		///11 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		///11 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

