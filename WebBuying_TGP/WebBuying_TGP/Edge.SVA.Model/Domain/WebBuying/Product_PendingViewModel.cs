using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Edge.SVA.Model;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class Product_PendingViewModel
    {
        BUY_PRODUCT_Pending mainTable = new BUY_PRODUCT_Pending();

        public BUY_PRODUCT_Pending MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        DataTable _dtRprice = new DataTable();

        public DataTable dtRprice
        {
            get { return _dtRprice; }
            set { _dtRprice = value; }
        }

        BUY_CPRICE_M _dtCprice = new BUY_CPRICE_M();

        public BUY_CPRICE_M dtCprice
        {
            get { return _dtCprice; }
            set { _dtCprice = value; }
        }


        DataTable _dtBarCode = new DataTable();

        public DataTable dtBarCode
        {
            get { return _dtBarCode; }
            set { _dtBarCode = value; }
        }

        BUY_PRODUCT_CLASSIFY_Pending _dtProductClassify = new BUY_PRODUCT_CLASSIFY_Pending();
        public BUY_PRODUCT_CLASSIFY_Pending dtSeason
        {
            get { return _dtProductClassify; }
            set { _dtProductClassify = value; }
        }

        public BUY_PRODUCT_CLASSIFY_Pending dtSex
        {
            get { return _dtProductClassify; }
            set { _dtProductClassify = value; }
        }

        BUY_Product_Particulars_Pending _dtProductParticulars = new BUY_Product_Particulars_Pending();
        public BUY_Product_Particulars_Pending dtProductParticulars
        {
            get { return _dtProductParticulars; }
            set { _dtProductParticulars = value; }
        }
        DataTable _dtSUPPROD = new DataTable();

        public DataTable dtSUPPROD
        {
            get { return _dtSUPPROD; }
            set { _dtSUPPROD = value; }
        }
        DataTable _dtStore = new DataTable();
        public DataTable dtStore
        {
            get { return _dtStore; }
            set { _dtStore = value; }
        }
    }
}
