using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 币种表
	/// </summary>
	[Serializable]
	public partial class STK_STake_H
	{
        public STK_STake_H()
		{}
		#region Model
		private int _stocktakeid;
        private string _stocktakenumber;
        private DateTime? _stocktakedate= DateTime.Now;
		private int _storeid;
		private int _status;
		private int _stocktaketype;
        private string _remark;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int StockTakeID
		{
			set{ _stocktakeid=value;}
			get{return _stocktakeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StockTakeNumber
		{
			set{ _stocktakenumber=value;}
			get{return _stocktakenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StockTakeDate
		{
			set{ _stocktakedate=value;}
			get{return _stocktakedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StockTakeType
		{
			set{ _stocktaketype=value;}
			get{return _stocktaketype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
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

