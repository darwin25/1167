using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class STK_STAKEVAR
	{
        public STK_STAKEVAR()
		{}
		#region Model
        private int _storeid;
        private string _stocktakenumber;
        private string _prodcode;
        private string _storetype;
        private int _varqty;
        private string _serialno;

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

        public int VARQTY
        {
            set { _varqty = value; }
            get { return _varqty; }
        }

		/// <summary>
		/// 
		/// </summary>
        public string SerialNo
        {
            set { _serialno = value; }
            get { return _serialno; }
        }


		#endregion Model

	}
}

