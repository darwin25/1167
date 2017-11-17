using System;
namespace Edge.SVA.Model
{
	/// <summary>
	/// 接收到的操作指令记录表。
	///
	/// </summary>
	[Serializable]
	public partial class ReceiveTxn
	{
		public ReceiveTxn()
		{}
		#region Model
		private int _keyid;
		private string _storecode;
		private string _servercode;
		private string _registercode;
		private string _txnnosn;
		private string _txnno;
		private DateTime? _busdate;
		private DateTime? _txndate;
		private string _cardnumber;
		private int _oprid;
		private decimal? _amount;
		private int? _points=0;
		private int _status;
		private int? _voidkeyid;
		private string _voidtxnno;
		private int? _tenderid;
		private string _additional;
		private string _approvestatus;
		private string _remark;
		private string _securitycode;
		private DateTime? _createddate= DateTime.Now;
		private DateTime? _updateddate= DateTime.Now;
		private string _createdby;
		private string _updatedby;
		private string _approvedby;
		private DateTime? _approveddate;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 店铺编号
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		/// 服务器编号。
		/// </summary>
		public string ServerCode
		{
			set{ _servercode=value;}
			get{return _servercode;}
		}
		/// <summary>
		/// 终端编号
		/// </summary>
		public string RegisterCode
		{
			set{ _registercode=value;}
			get{return _registercode;}
		}
		/// <summary>
		/// 调用方提供。 
		/// </summary>
		public string TxnNoSN
		{
			set{ _txnnosn=value;}
			get{return _txnnosn;}
		}
		/// <summary>
		/// 交易单号
		/// </summary>
		public string TxnNo
		{
			set{ _txnno=value;}
			get{return _txnno;}
		}
		/// <summary>
		/// 交易日期
		/// </summary>
		public DateTime? BusDate
		{
			set{ _busdate=value;}
			get{return _busdate;}
		}
		/// <summary>
		/// 交易时间
		/// </summary>
		public DateTime? TxnDate
		{
			set{ _txndate=value;}
			get{return _txndate;}
		}
		/// <summary>
		/// 交易用卡号
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
		}
		/// <summary>
		/// 操作ID：
//1、查询
//2、充值
//3、消费金额
//4、void（被void的必须是本卡交易，要校验卡号是否和原单相同），return，staffadj 这类交易直接调用充值功能。
//5、作废本卡
//6、金额转出（包括积分）
//7、金额转入（包括积分）
//8、Return
//9、卡过期，金额清空。
//10、卡金额调整（直接增减金额）
//11、批量卡激活(POS端)
//12、手机充值
//13、扣除积分（使用积分支付）
//14、购买积分
//15、兑换积分（使用卡中金额兑换积分）
//16、旧卡换新卡时金额转出（包括积分）
//17、旧卡换新卡时金额转入（包括积分）
//21、卡激活
//22、卡金额调整
//23、卡积分调整
//31、使用卡金额积分购买coupon并绑定
//32、绑定coupon到卡
//33、激活指定coupon
//34、使用指定coupon
//35、设置coupon无效（过期）
//36、转赠coupon（转出）
//37、转赠coupon（转入）


		/// </summary>
		public int OprID
		{
			set{ _oprid=value;}
			get{return _oprid;}
		}
		/// <summary>
		/// 操作金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 操作积分
		/// </summary>
		public int? Points
		{
			set{ _points=value;}
			get{return _points;}
		}
		/// <summary>
		/// 调用时，业务逻辑判断。0 正常。 小于0异常：
//0:成功。
//-1：没有找到此用户。
//-2：没有找到卡。
//-3：用户密码不正确。
//-4：卡密码不正确。
//-5：会员状态不正确（已注销）。
//-6：卡状态不正确（过期，作废...）。  
//-7：没有输入MemberID
//-8：没有输入CardNumber
//-9: 需要重新设置密码

//-10: 余额不够.
//-11: 没有找到原单.
//-12: 原单已经void不能再次void.
//-13: 原单是void单，不能再void.
//-14: 充值超过卡上限
//-15: TxnNo已经存在（重复提交）

//-99：卡号不对
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 如果是void操作，有原单时，填写原单的receivetxn 的KeyID。
		/// </summary>
		public int? VoidKeyID
		{
			set{ _voidkeyid=value;}
			get{return _voidkeyid;}
		}
		/// <summary>
		/// 如果是void单，需要填写被void的原单号(TxnNo)。
		/// </summary>
		public string VoidTxnNo
		{
			set{ _voidtxnno=value;}
			get{return _voidtxnno;}
		}
		/// <summary>
		/// 支付类型ID
		/// </summary>
		public int? TenderID
		{
			set{ _tenderid=value;}
			get{return _tenderid;}
		}
		/// <summary>
		/// 附加信息。银行卡支付时，填写卡号
		/// </summary>
		public string Additional
		{
			set{ _additional=value;}
			get{return _additional;}
		}
		/// <summary>
		/// 记录状态。P： 准备状态（未批核）。 A：已经批核。  V：已经作废
		/// </summary>
		public string ApproveStatus
		{
			set{ _approvestatus=value;}
			get{return _approvestatus;}
		}
		/// <summary>
		/// 备注。（预留字段）
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 签名校验字段。使用CardNumber+Amount+OprID （去掉空格），进行加密。填入SecurityCode。
		/// </summary>
		public string SecurityCode
		{
			set{ _securitycode=value;}
			get{return _securitycode;}
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
		/// <summary>
		/// 
		/// </summary>
		public string Approvedby
		{
			set{ _approvedby=value;}
			get{return _approvedby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ApprovedDate
		{
			set{ _approveddate=value;}
			get{return _approveddate;}
		}
		#endregion Model

	}
}

