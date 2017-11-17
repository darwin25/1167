using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 分发模板
	///发布方法包括：
	///1.	Delivery
	///2.	Email
	///3.	SMS
	///4.	Social Network
	///
	/// </summary>
	[Serializable]
	public partial class DistributeTemplate
	{
		public DistributeTemplate()
		{}
		#region Model
		private int _distributionid;
		private string _distributioncode;
		private string _distributiondesc1;
		private string _distributiondesc2;
		private string _distributiondesc3;
		private string _templatefile;
		private string _remark;
		private DateTime? _createdon= DateTime.Now;
		private int? _createdby;
		private DateTime? _updatedon= DateTime.Now;
		private int? _updatedby;
		/// <summary>
		/// 自增长主键
		/// </summary>
		public int DistributionID
		{
			set{ _distributionid=value;}
			get{return _distributionid;}
		}
		/// <summary>
		/// 发布方法编号
		/// </summary>
		public string DistributionCode
		{
			set{ _distributioncode=value;}
			get{return _distributioncode;}
		}
		/// <summary>
		/// 分发描述1
		/// </summary>
		public string DistributionDesc1
		{
			set{ _distributiondesc1=value;}
			get{return _distributiondesc1;}
		}
		/// <summary>
		/// 分发描述1
		/// </summary>
		public string DistributionDesc2
		{
			set{ _distributiondesc2=value;}
			get{return _distributiondesc2;}
		}
		/// <summary>
		/// 分发描述1
		/// </summary>
		public string DistributionDesc3
		{
			set{ _distributiondesc3=value;}
			get{return _distributiondesc3;}
		}
		/// <summary>
		/// 模板文件名
		/// </summary>
		public string TemplateFile
		{
			set{ _templatefile=value;}
			get{return _templatefile;}
		}
		/// <summary>
		/// 备注
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

