using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 实体卡绑定表
	/// </summary>
	[Serializable]
	public partial class VENDOR
	{
		public VENDOR()
		{}
		#region Model
		private string _vendorcode;
		private string _area;
		private string _name;
		private string _l_name;
		private string _address1;
		private string _address2;
		private string _address3;
		private string _contact;
		private string _position;
		private string _tel;
		private string _fax;
		private string _telex;
		private string _cable;
		private int _terms;
		private decimal _limit;
		private string _shipment;
		private string _payterm;
		private string _account_code;
		private string _oversea;
		private decimal _in_tax;
		private DateTime? _createdon;
		private string _nonorder;
		private string _prepareby;
		private DateTime? _updatedon;
		private string _updatedby;
		/// <summary>
		/// 
		/// </summary>
		public string VendorCode
		{
			set{ _vendorcode=value;}
			get{return _vendorcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string L_name
		{
			set{ _l_name=value;}
			get{return _l_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address1
		{
			set{ _address1=value;}
			get{return _address1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address2
		{
			set{ _address2=value;}
			get{return _address2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address3
		{
			set{ _address3=value;}
			get{return _address3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telex
		{
			set{ _telex=value;}
			get{return _telex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Cable
		{
			set{ _cable=value;}
			get{return _cable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Terms
		{
			set{ _terms=value;}
			get{return _terms;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Limit
		{
			set{ _limit=value;}
			get{return _limit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Shipment
		{
			set{ _shipment=value;}
			get{return _shipment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Payterm
		{
			set{ _payterm=value;}
			get{return _payterm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Account_code
		{
			set{ _account_code=value;}
			get{return _account_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Oversea
		{
			set{ _oversea=value;}
			get{return _oversea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal In_tax
		{
			set{ _in_tax=value;}
			get{return _in_tax;}
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
		public string Nonorder
		{
			set{ _nonorder=value;}
			get{return _nonorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Prepareby
		{
			set{ _prepareby=value;}
			get{return _prepareby;}
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
		public string UpdatedBy
		{
			set{ _updatedby=value;}
			get{return _updatedby;}
		}
		#endregion Model

	}
}

