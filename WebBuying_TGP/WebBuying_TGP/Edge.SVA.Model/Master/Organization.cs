using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 机构表donate
	/// </summary>
	[Serializable]
	public partial class Organization
	{
		public Organization()
		{}
		#region Model
		private int _organizationid;
		private string _organizationname1;
		private string _organizationname2;
		private string _organizationname3;
		private string _organizationnote;
		private string _cardnumber;
		private int? _cumulativepoints;
		private decimal? _cumulativeamt;
		private int? _organizationtype;
		private string _organizationpicfile;
		private int? _callinterface=0;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		private string _organizationcode;
		private string _organizationdesc1;
		private string _organizationdesc2;
		private string _organizationdesc3;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int OrganizationID
		{
			set{ _organizationid=value;}
			get{return _organizationid;}
		}
		/// <summary>
		/// 机构名称1
		/// </summary>
		public string OrganizationName1
		{
			set{ _organizationname1=value;}
			get{return _organizationname1;}
		}
		/// <summary>
		/// 机构名称2
		/// </summary>
		public string OrganizationName2
		{
			set{ _organizationname2=value;}
			get{return _organizationname2;}
		}
		/// <summary>
		/// 机构名称3
		/// </summary>
		public string OrganizationName3
		{
			set{ _organizationname3=value;}
			get{return _organizationname3;}
		}
		/// <summary>
		/// 机构备注
		/// </summary>
		public string OrganizationNote
		{
			set{ _organizationnote=value;}
			get{return _organizationnote;}
		}
		/// <summary>
		/// 关联的CardNumber
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
		}
		/// <summary>
		/// 累计获得的积分
		/// </summary>
		public int? CumulativePoints
		{
			set{ _cumulativepoints=value;}
			get{return _cumulativepoints;}
		}
		/// <summary>
		/// 累计获得的金额
		/// </summary>
		public decimal? CumulativeAmt
		{
			set{ _cumulativeamt=value;}
			get{return _cumulativeamt;}
		}
		/// <summary>
		/// 机构类型：
		/// </summary>
		public int? OrganizationType
		{
			set{ _organizationtype=value;}
			get{return _organizationtype;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string OrganizationPicFile
		{
			set{ _organizationpicfile=value;}
			get{return _organizationpicfile;}
		}
		/// <summary>
		/// 是否调用接口。0：不调用。1：调用。 默认0
		/// </summary>
		public int? CallInterface
		{
			set{ _callinterface=value;}
			get{return _callinterface;}
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
		/// <summary>
		/// 
		/// </summary>
		public string OrganizationCode
		{
			set{ _organizationcode=value;}
			get{return _organizationcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrganizationDesc1
		{
			set{ _organizationdesc1=value;}
			get{return _organizationdesc1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrganizationDesc2
		{
			set{ _organizationdesc2=value;}
			get{return _organizationdesc2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrganizationDesc3
		{
			set{ _organizationdesc3=value;}
			get{return _organizationdesc3;}
		}
		#endregion Model

	}
}

