using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 库存调整单明细。
	/// </summary>
	[Serializable]
	public partial class Ord_StockAdjust_D
	{
		public Ord_StockAdjust_D()
		{}
		#region Model
		private int _keyid;
		private string _stockadjustnumber;
		private string _prodcode;
		private int? _adjustqty;
        private string _stocktypecode;
        private int? _reasonid;
        private string _remark;
		/// <summary>
		/// 主键
		/// </summary>
		public int KeyID
		{ 
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 库存调整单编号，主键
		/// </summary>
		public string StockAdjustNumber
		{
			set{ _stockadjustnumber=value;}
			get{return _stockadjustnumber;}
		}
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProdCode
        {
            set { _prodcode = value; }
            get { return _prodcode; }
        }
		/// <summary>
		/// 调整数量
		/// </summary>
		public int? AdjustQty
		{
			set{ _adjustqty=value;}
			get{return _adjustqty;}
		}


        public string StockTypeCode
		{
            set { _stocktypecode = value; }
            get { return _stocktypecode; }
		}
        
        /// <summary>
        /// 调整数量
        /// </summary>
        public int? ReasonID
        {
            set { _reasonid = value; }
            get { return _reasonid; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
		#endregion Model

	}
}

