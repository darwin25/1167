using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class STK_STAKE01
	{
        public STK_STAKE01()
		{}
		#region Model
        private int _storeid;
        private string _stocktakenumber;
        private string _prodcode;
        private string _storetype;
        private int _qty;
        private int _status;
        private string _serialno;
        private int _seq;
		private DateTime? _createdon= DateTime.Now;

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
		public int StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}

        public string ProdCode
        {
            set { _prodcode = value; }
            get { return _prodcode; }
        }

        public string StockType
        {
            set { _storetype = value; }
            get { return _storetype; }
        }

        public int QTY
        {
            set { _qty = value; }
            get { return _qty; }
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
        public string SerialNo
        {
            set { _serialno = value; }
            get { return _serialno; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int SEQ
		{
            set { _seq = value; }
            get { return _seq; }
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

		#endregion Model

	}
}

