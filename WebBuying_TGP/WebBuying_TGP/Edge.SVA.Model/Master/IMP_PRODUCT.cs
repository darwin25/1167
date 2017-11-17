using System;
namespace Edge.SVA.Model
{
    /// <summary>
    /// 读入的product表。for Bauhaus。 
    ///@2016-07-08   字段根据用户提供的excel文档。
    ///创建人:Lisa
    ///创建时间：2016-07-08
    /// </summary>
    [Serializable]
    public partial class IMP_PRODUCT
    {
        public IMP_PRODUCT()
        { }
        #region Model
        private string _internal_product_code;
        private string _company_id;
        private string _barcode;
        private string _supplier_product_code;
        private string _brand;
        private int? _year;
        private string _season;
        private string _article;
        private int? _sex;
        private string _model;
        private string _color;
        private string _psize;
        private string _class;
        private string _description;
        private string _reorder_level;
        private string _retired;
        private DateTime? _retire_date;
        private DateTime? _last_update_date;
        private string _last_update_user;
        private string _description2;
        private string _supplier;
        private decimal? _standard_cost;
        private string _size_range;
        private string _hs_code;
        private decimal? _export_cost;
        private string _local_description;
        private string _coo;
        private string _material_1;
        private string _material_2;
        private string _designer;
        private string _buyer;
        private string _merchandiser;
        private string _sku;
        private decimal? _avg_cost;
        private decimal? _price;
        private decimal? _final_discount_price;
        private string _shortdescription1;
        private string _shortdescription2;
        private string _shortdescription3;
        private string _material1;
        private string _material2;
        private string _material3;
        private string _detailed1;
        private string _detailed2;
        private string _detailed3;
        private string _design1;
        private string _design2;
        private string _design3;
        private string _productname1;
        private string _productname2;
        private string _productname3;
        private int? _isonlinesku = 0;
        private string _outerlayermaterials;
        private string _innerlayermaterials;
        private string _sizecategory;
        private string _video;
        private string _360photos;


        private string _photos1;
        private string _photos2;
        private string _photos4;
        private string _photos5;
        private string _photos6;
        private string _photos7;
        private string _photos10;
        private string _photos8;
        private string _photos3;
        private string _photos9;
        private string _sizem1;
        private string _sizem2;
        private string _sizem3;
        private string _sizem4;
        private string _sizem5;
        private string _sizem6;
        private string _sizem7;
        private string _sizem8;
        /// <summary>
        /// 
        /// </summary>
        public string INTERNAL_PRODUCT_CODE
        {
            set { _internal_product_code = value; }
            get { return _internal_product_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY_ID
        {
            set { _company_id = value; }
            get { return _company_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BARCODE
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SUPPLIER_PRODUCT_CODE
        {
            set { _supplier_product_code = value; }
            get { return _supplier_product_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BRAND
        {
            set { _brand = value; }
            get { return _brand; }
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
        public string SEASON
        {
            set { _season = value; }
            get { return _season; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ARTICLE
        {
            set { _article = value; }
            get { return _article; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SEX
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MODEL
        {
            set { _model = value; }
            get { return _model; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COLOR
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PSIZE
        {
            set { _psize = value; }
            get { return _psize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CLASS
        {
            set { _class = value; }
            get { return _class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string REORDER_LEVEL
        {
            set { _reorder_level = value; }
            get { return _reorder_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RETIRED
        {
            set { _retired = value; }
            get { return _retired; }
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
        public DateTime? LAST_UPDATE_DATE
        {
            set { _last_update_date = value; }
            get { return _last_update_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPTION2
        {
            set { _description2 = value; }
            get { return _description2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SUPPLIER
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? STANDARD_COST
        {
            set { _standard_cost = value; }
            get { return _standard_cost; }
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
        public string HS_CODE
        {
            set { _hs_code = value; }
            get { return _hs_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? EXPORT_COST
        {
            set { _export_cost = value; }
            get { return _export_cost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOCAL_DESCRIPTION
        {
            set { _local_description = value; }
            get { return _local_description; }
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
        public string MATERIAL_1
        {
            set { _material_1 = value; }
            get { return _material_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MATERIAL_2
        {
            set { _material_2 = value; }
            get { return _material_2; }
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
        public string SKU
        {
            set { _sku = value; }
            get { return _sku; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AVG_COST
        {
            set { _avg_cost = value; }
            get { return _avg_cost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PRICE
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FINAL_DISCOUNT_PRICE
        {
            set { _final_discount_price = value; }
            get { return _final_discount_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortDescription1
        {
            set { _shortdescription1 = value; }
            get { return _shortdescription1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortDescription2
        {
            set { _shortdescription2 = value; }
            get { return _shortdescription2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortDescription3
        {
            set { _shortdescription3 = value; }
            get { return _shortdescription3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Material1
        {
            set { _material1 = value; }
            get { return _material1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Material2
        {
            set { _material2 = value; }
            get { return _material2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Material3
        {
            set { _material3 = value; }
            get { return _material3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Detailed1
        {
            set { _detailed1 = value; }
            get { return _detailed1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Detailed2
        {
            set { _detailed2 = value; }
            get { return _detailed2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Detailed3
        {
            set { _detailed3 = value; }
            get { return _detailed3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Design1
        {
            set { _design1 = value; }
            get { return _design1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Design2
        {
            set { _design2 = value; }
            get { return _design2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Design3
        {
            set { _design3 = value; }
            get { return _design3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName1
        {
            set { _productname1 = value; }
            get { return _productname1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName2
        {
            set { _productname2 = value; }
            get { return _productname2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName3
        {
            set { _productname3 = value; }
            get { return _productname3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsOnlineSKU
        {
            set { _isonlinesku = value; }
            get { return _isonlinesku; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OuterLayerMaterials
        {
            set { _outerlayermaterials = value; }
            get { return _outerlayermaterials; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InnerLayerMaterials
        {
            set { _innerlayermaterials = value; }
            get { return _innerlayermaterials; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeCategory
        {
            set { _sizecategory = value; }
            get { return _sizecategory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Video
        {
            set { _video = value; }
            get { return _video; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _360photos1
        {
            get { return _360photos; }
            set { _360photos = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos1
        {
            set { _photos1 = value; }
            get { return _photos1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos2
        {
            set { _photos2 = value; }
            get { return _photos2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos4
        {
            set { _photos4 = value; }
            get { return _photos4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos5
        {
            set { _photos5 = value; }
            get { return _photos5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos6
        {
            set { _photos6 = value; }
            get { return _photos6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos7
        {
            set { _photos7 = value; }
            get { return _photos7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos10
        {
            set { _photos10 = value; }
            get { return _photos10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos8
        {
            set { _photos8 = value; }
            get { return _photos8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos3
        {
            set { _photos3 = value; }
            get { return _photos3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photos9
        {
            set { _photos9 = value; }
            get { return _photos9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeM1
        {
            set { _sizem1 = value; }
            get { return _sizem1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeM2
        {
            set { _sizem2 = value; }
            get { return _sizem2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeM3
        {
            set { _sizem3 = value; }
            get { return _sizem3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeM4
        {
            set { _sizem4 = value; }
            get { return _sizem4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  SizeM5
        {
            set { _sizem5 = value; }
            get { return _sizem5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeM6
        {
            set { _sizem6 = value; }
            get { return _sizem6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeM7
        {
            set { _sizem7 = value; }
            get { return _sizem7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeM8
        {
            set { _sizem8 = value; }
            get { return _sizem8; }
        }
        #endregion Model

    }
}

