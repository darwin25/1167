﻿using System;
namespace Edge.SVA.Model
{
    /// <summary>
    /// 卡订货单明细。
    ///表中brandID，cardtypeid，cardgradeid 关系不做校验，由UI在创建单据时做校验。
    ///存储过程实际操作时，只按照CardGradeID来做。
    /// </summary>
    [Serializable]
    public partial class Ord_ReturnOrder_D
    {
        public Ord_ReturnOrder_D()
        { }
        #region Model
        private int _keyid;
        private string _ReturnOrdernumber;
        private string _prodcode;
        private int? _returnqty;
        private string _remark;
        /// <summary>
        /// 主键
        /// </summary>
        public int KeyID
        {
            set { _keyid = value; }
            get { return _keyid; }
        }
        /// <summary>
        /// 订单编号，主键
        /// </summary>
        public string ReturnOrderNumber
        {
            set { _ReturnOrdernumber = value; }
            get { return _ReturnOrdernumber; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProdCode
        {
            set { _prodcode = value; }
            get { return _prodcode; }
        }
        /// <summary>
        /// 订单数量
        /// </summary>
        public int? ReturnQty
        {
            set { _returnqty = value; }
            get { return _returnqty; }
        }
        /// <summary>
        /// 备注 PCCW 有导入
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

