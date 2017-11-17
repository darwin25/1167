using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 租赁代码表
	/// </summary>
	[Serializable]
	public partial class BUY_LEASECODE
	{
		public BUY_LEASECODE()
		{}
		#region Model
		private string _leasecode;
		private string _leasename1;
		private string _leasename2;
		private string _leasename3;
		private string _leaseaddress1;
		private string _leaseaddress2;
		private string _leaseaddress3;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		///11 主键
		/// </summary>
		public string LeaseCode
		{
			set{ _leasecode=value;}
			get{return _leasecode;}
		}
		/// <summary>
		///11 名称1
		/// </summary>
		public string LeaseName1
		{
			set{ _leasename1=value;}
			get{return _leasename1;}
		}
		/// <summary>
		///11 名称2
		/// </summary>
		public string LeaseName2
		{
			set{ _leasename2=value;}
			get{return _leasename2;}
		}
		/// <summary>
		///11 名称3
		/// </summary>
		public string LeaseName3
		{
			set{ _leasename3=value;}
			get{return _leasename3;}
		}
		/// <summary>
		///11 地址1
		/// </summary>
		public string LeaseAddress1
		{
			set{ _leaseaddress1=value;}
			get{return _leaseaddress1;}
		}
		/// <summary>
		///11 地址2
		/// </summary>
		public string LeaseAddress2
		{
			set{ _leaseaddress2=value;}
			get{return _leaseaddress2;}
		}
		/// <summary>
		///11 地址3
		/// </summary>
		public string LeaseAddress3
		{
			set{ _leaseaddress3=value;}
			get{return _leaseaddress3;}
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

