using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 关联货品列表
	/// </summary>
	[Serializable]
	public partial class BUY_ProductAssociated
	{
		public BUY_ProductAssociated()
		{}
		#region Model
		private int _keyid;
		private string _prodcode;
		private int? _seqno=0;
		private string _associatedprodcode;
		private string _associatedprodname;
		private string _associatedprodfile;
		private string _note;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键，自增长
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 货品编码，主键
		/// </summary>
		public string ProdCode
		{
			set{ _prodcode=value;}
			get{return _prodcode;}
		}
		/// <summary>
		/// 此货品的关联货品序号。从0开始。
		/// </summary>
		public int? SeqNo
		{
			set{ _seqno=value;}
			get{return _seqno;}
		}
		/// <summary>
		/// 和此货品关联的货品编码
		/// </summary>
		public string AssociatedProdCode
		{
			set{ _associatedprodcode=value;}
			get{return _associatedprodcode;}
		}
		/// <summary>
		/// 和此货品关联的货品名称
		/// </summary>
		public string AssociatedProdName
		{
			set{ _associatedprodname=value;}
			get{return _associatedprodname;}
		}
		/// <summary>
		/// 和此货品关联的货品图片文件路径
		/// </summary>
		public string AssociatedProdFile
		{
			set{ _associatedprodfile=value;}
			get{return _associatedprodfile;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedOn
		{
			set{ _createdon=value;}
			get{return _createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdatedOn
		{
			set{ _updatedon=value;}
			get{return _updatedon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

