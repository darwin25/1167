using System;
namespace Edge.SVA.Model
{
    /// <summary>
    /// Bauhaus 货品的 附加属性内容。
    /// 创建人：Lisa
    /// 创建时间：2016-02-26
    ///只是保存不 参与计算。
    /// </summary>
    [Serializable]
    public partial class BUY_PRODUCT_ADD_BAU
    {
        public BUY_PRODUCT_ADD_BAU()
        { }
        #region Model
        private string _prodcode;
        private decimal? _standard_cost;
        private decimal? _export_cost;
        private decimal? _avg_cost;
        private string _model;
        private string _sku;
        private int? _year;
        private int? _reorder_level;
        private string _hs_code;
        private string _coo;
        private string _size_range;
        private string _designer;
        private string _buyer;
        private string _merchandiser;
        private DateTime? _retire_date;
        private string _companycode;
        private string _material;
        private string _overview;
        private string _style;
        private string _fabric_care;
        private decimal? _sizeM1;
        private decimal? _sizeM2;
        private decimal? _sizeM3;
        private decimal? _sizeM4;
        private decimal? _sizeM5;
        private decimal? _sizeM6;
        private decimal? _sizeM7;
        private decimal? _sizeM8;
        /// <summary>
        /// 货品编码，主键
        /// </summary>
        public string ProdCode
        {
            set { _prodcode = value; }
            get { return _prodcode; }
        }
        /// <summary>
        /// 标准成本
        /// </summary>
        public decimal? Standard_Cost
        {
            set { _standard_cost = value; }
            get { return _standard_cost; }
        }
        /// <summary>
        /// 出口成本
        /// </summary>
        public decimal? Export_Cost
        {
            set { _export_cost = value; }
            get { return _export_cost; }
        }
        /// <summary>
        /// 平均成本
        /// </summary>
        public decimal? AVG_Cost
        {
            set { _avg_cost = value; }
            get { return _avg_cost; }
        }
        /// <summary>
        /// Model
        /// </summary>
        public string MODEL
        {
            set { _model = value; }
            get { return _model; }
        }
        /// <summary>
        /// Bauhaus用的货品sku。
        /// </summary>
        public string SKU
        {
            set { _sku = value; }
            get { return _sku; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? YEAR
        {
            set { _year = value; }
            get { return _year; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? REORDER_LEVEL
        {
            set { _reorder_level = value; }
            get { return _reorder_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HS_CODE
        {
            set { _hs_code = value; }
            get { return _hs_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COO
        {
            set { _coo = value; }
            get { return _coo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SIZE_RANGE
        {
            set { _size_range = value; }
            get { return _size_range; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DESIGNER
        {
            set { _designer = value; }
            get { return _designer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BUYER
        {
            set { _buyer = value; }
            get { return _buyer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MERCHANDISER
        {
            set { _merchandiser = value; }
            get { return _merchandiser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RETIRE_DATE
        {
            set { _retire_date = value; }
            get { return _retire_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyCode
        {
            set { _companycode = value; }
            get { return _companycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Material
        {
            set { _material = value; }
            get { return _material; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string overview
        {
            set { _overview = value; }
            get { return _overview; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string style
        {
            set { _style = value; }
            get { return _style; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fabric_care
        {
            set { _fabric_care = value; }
            get { return _fabric_care; }
        }
        public decimal? SizeM1
        {
            get { return _sizeM1; }
            set { _sizeM1 = value; }
        }
        public decimal? SizeM2
        {
            get { return _sizeM2; }
            set { _sizeM2 = value; }
        }
        public decimal? SizeM3
        {
            get { return _sizeM3; }
            set { _sizeM3 = value; }
        }
        public decimal? SizeM4
        {
            get { return _sizeM4; }
            set { _sizeM4 = value; }
        }
        public decimal? SizeM5
        {
            get { return _sizeM5; }
            set { _sizeM5 = value; }
        }
        public decimal? SizeM6
        {
            get { return _sizeM6; }
            set { _sizeM6 = value; }
        }
        public decimal? SizeM7
        {
            get { return _sizeM7; }
            set { _sizeM7 = value; }
        }
        public decimal? SizeM8
        {
            get { return _sizeM8; }
            set { _sizeM8 = value; }
        }
        #endregion Model

    }
}

