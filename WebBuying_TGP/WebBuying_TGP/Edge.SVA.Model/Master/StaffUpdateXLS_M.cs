using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 销售单主表（字段暂定）
	///表中会员部分，为本次交易中使用的会员资料。（比如CU_CardNumber是本次交易使用的卡，没有指定的话使用默认值）
	/// </summary>
	[Serializable]
	public partial class StaffUpdateXLS_M
	{
		public StaffUpdateXLS_M()
		{}
		#region Model
		private int _keyid;
		private int _operation=0;
		private string _excelfilename;
		private string _sheetname;
		private int? _actionresult;
		private string _resultremark;
		private DateTime? _createddate= DateTime.Now;
		private DateTime? _updateddate= DateTime.Now;
		private string _createdby;
		private string _updatedby;
		/// <summary>
		/// 
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Operation
		{
			set{ _operation=value;}
			get{return _operation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExcelFileName
		{
			set{ _excelfilename=value;}
			get{return _excelfilename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SheetName
		{
			set{ _sheetname=value;}
			get{return _sheetname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ActionResult
		{
			set{ _actionresult=value;}
			get{return _actionresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResultRemark
		{
			set{ _resultremark=value;}
			get{return _resultremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdatedDate
		{
			set{ _updateddate=value;}
			get{return _updateddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreatedBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

