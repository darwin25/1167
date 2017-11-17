using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// OprID表。
	/// </summary>
	[Serializable]
	public partial class OperationTable
	{
		public OperationTable()
		{}
		#region Model
		private int _oprid;
		private string _opriddesc1;
		private string _opriddesc2;
		private string _opriddesc3;
		private string _remark;
		/// <summary>
		/// OprID主键
		/// </summary>
		public int OprID
		{
			set{ _oprid=value;}
			get{return _oprid;}
		}
		/// <summary>
		/// OprID描述1
		/// </summary>
		public string OprIDDesc1
		{
			set{ _opriddesc1=value;}
			get{return _opriddesc1;}
		}
		/// <summary>
		/// OprID描述2
		/// </summary>
		public string OprIDDesc2
		{
			set{ _opriddesc2=value;}
			get{return _opriddesc2;}
		}
		/// <summary>
		/// OprID描述3
		/// </summary>
		public string OprIDDesc3
		{
			set{ _opriddesc3=value;}
			get{return _opriddesc3;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

