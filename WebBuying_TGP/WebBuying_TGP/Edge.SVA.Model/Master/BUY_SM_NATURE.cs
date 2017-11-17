using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 交易类型定义表。
	///（固定交易类型）
	/// </summary>
	[Serializable]
	public partial class BUY_SM_NATURE
	{
		public BUY_SM_NATURE()
		{}
		#region Model
		private int _transtype;
		private string _transtypename1;
		private string _transtypename2;
		private string _transtypename3;
		private string _nature;
		/// <summary>
		///11 主键。 交易类型
		/// </summary>
		public int TransType
		{
			set{ _transtype=value;}
			get{return _transtype;}
		}
		/// <summary>
		///11 交易类型名称1
		/// </summary>
		public string TransTypeName1
		{
			set{ _transtypename1=value;}
			get{return _transtypename1;}
		}
		/// <summary>
		///11 交易类型名称2
		/// </summary>
		public string TransTypeName2
		{
			set{ _transtypename2=value;}
			get{return _transtypename2;}
		}
		/// <summary>
		///11 交易类型名称3
		/// </summary>
		public string TransTypeName3
		{
			set{ _transtypename3=value;}
			get{return _transtypename3;}
		}
		/// <summary>
		///11 类型
		/// </summary>
		public string Nature
		{
			set{ _nature=value;}
			get{return _nature;}
		}
		#endregion Model

	}
}

