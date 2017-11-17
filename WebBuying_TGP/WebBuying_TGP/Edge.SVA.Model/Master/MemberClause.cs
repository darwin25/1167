using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 会员条款
	/// </summary>
	[Serializable]
	public partial class MemberClause
	{
		public MemberClause()
		{}
		#region Model
		private int _memberclauseid;
		private string _clausetypecode;
		private string _clausesubcode="1";
		private string _clausename;
		private string _memberclausedesc1;
		private string _memberclausedesc2;
		private string _memberclausedesc3;
		private int? _brandid;
		/// <summary>
		/// 主键
		/// </summary>
		public int MemberClauseID
		{
			set{ _memberclauseid=value;}
			get{return _memberclauseid;}
		}
		/// <summary>
		/// 条款类型编号。区分全局的，或者局部功能的
		/// </summary>
		public string ClauseTypeCode
		{
			set{ _clausetypecode=value;}
			get{return _clausetypecode;}
		}
		/// <summary>
		/// 子项编号
		/// </summary>
		public string ClauseSubCode
		{
			set{ _clausesubcode=value;}
			get{return _clausesubcode;}
		}
		/// <summary>
		/// 条款描述
		/// </summary>
		public string ClauseName
		{
			set{ _clausename=value;}
			get{return _clausename;}
		}
		/// <summary>
		/// 条款内容1
		/// </summary>
		public string MemberClauseDesc1
		{
			set{ _memberclausedesc1=value;}
			get{return _memberclausedesc1;}
		}
		/// <summary>
		/// 条款内容2
		/// </summary>
		public string MemberClauseDesc2
		{
			set{ _memberclausedesc2=value;}
			get{return _memberclausedesc2;}
		}
		/// <summary>
		/// 条款内容3
		/// </summary>
		public string MemberClauseDesc3
		{
			set{ _memberclausedesc3=value;}
			get{return _memberclausedesc3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		#endregion Model

	}
}

